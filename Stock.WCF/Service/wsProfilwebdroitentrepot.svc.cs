using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using HT_Stock.BOJ;
using Stock.WSTOOLS;
using log4net;
using System.Reflection;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Stock.WSBLL;
using System.Data;
using Stock.BOJ;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsProfilwebdroitentrepot" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsProfilwebdroitentrepot.svc ou wsProfilwebdroitentrepot.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsProfilwebdroitentrepot : IwsProfilwebdroitentrepot
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsProfilwebdroitentrepotWSBLL clsProfilwebdroitentrepotWSBLL = new clsProfilwebdroitentrepotWSBLL();

        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }

        //Déclaration du log
        log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter(List<HT_Stock.BOJ.clsProfilwebdroitentrepot> Objet)
        {
            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitentrepot> clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepotDTO in Objet)
                {
                    Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new Stock.BOJ.clsProfilwebdroitentrepot();
                    clsProfilwebdroitentrepot.PO_CODEPROFILWEB = clsProfilwebdroitentrepotDTO.PO_CODEPROFILWEB.ToString();
                    clsProfilwebdroitentrepot.EN_CODEENTREPOT = clsProfilwebdroitentrepotDTO.EN_CODEENTREPOT.ToString();
                    clsProfilwebdroitentrepot.COCHER = clsProfilwebdroitentrepotDTO.COCHER.ToString();
                    clsObjetEnvoi.OE_A = clsProfilwebdroitentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilwebdroitentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsProfilwebdroitentrepotWSBLL.pvgAjouter(clsDonnee, clsProfilwebdroitentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "00";
                    dr["SL_RESULTAT"] = "TRUE";
                    dr["SL_MESSAGE"] = "Opération réalisée avec succès !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Echec de l'opération !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                }



            }
            catch (SqlException SQLEx)
            {

                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                //Execution du log
                Log.Error(SQLEx.Message, null);

            }
            catch (Exception SQLEx)
            {

                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                //Execution du log
                Log.Error(SQLEx.Message, null);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterdroit(List<HT_Stock.BOJ.clsProfilwebdroitentrepot> Objet)
        {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitentrepot> clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                List<Stock.BOJ.clsProfilwebdroitentrepot> clsProfilwebdroitentrepotAjout = new List<BOJ.clsProfilwebdroitentrepot>();
                List<Stock.BOJ.clsProfilwebdroitentrepot> clsProfilwebdroitentrepotSuppression = new List<BOJ.clsProfilwebdroitentrepot>();
                foreach (HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepotDTO in Objet)
                {
                    Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new Stock.BOJ.clsProfilwebdroitentrepot();
                    clsProfilwebdroitentrepot.EN_CODEENTREPOT = clsProfilwebdroitentrepotDTO.EN_CODEENTREPOT;
                    clsProfilwebdroitentrepot.PO_CODEPROFILWEB = clsProfilwebdroitentrepotDTO.PO_CODEPROFILWEB;
                    clsProfilwebdroitentrepot.COCHER = clsProfilwebdroitentrepotDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsProfilwebdroitentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilwebdroitentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsProfilwebdroitentrepotAjout.Add(clsProfilwebdroitentrepot);

                }


                clsObjetRetour.SetValue(true, clsProfilwebdroitentrepotWSBLL.pvgAjouterdroit(clsDonnee, clsProfilwebdroitentrepotAjout, clsProfilwebdroitentrepotSuppression, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
                if (clsObjetRetour.OR_BOOLEEN)
                {

                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "00";
                    dr["SL_RESULTAT"] = "TRUE";
                    dr["SL_MESSAGE"] = "Opération réalisée avec succès !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Echec de l'opération !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }



            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                //Execution du log
                Log.Error(SQLEx.Message, null);
            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                //Execution du log
                Log.Error(SQLEx.Message, null);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }






        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        /*   public List<HT_Stock.BOJ.clsProfilwebdroitentrepot> pvgModifier(List<HT_Stock.BOJ.clsProfilwebdroitentrepot> Objet)
           {
               List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
               List<HT_Stock.BOJ.clsProfilwebdroitentrepot> clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
               Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
               clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
               clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
               clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
               clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

               for (int Idx = 0; Idx < Objet.Count; Idx++)
               {
                   //--TEST DES CHAMPS OBLIGATOIRES
                  // clsProfilwebdroitentrepots = TestChampObligatoireUpdate(Objet[Idx]);
                   //--VERIFICATION DU RESULTAT DU TEST
                   if (clsProfilwebdroitentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitentrepots;
                   //--TEST CONTRAINTE
                   // TestTestContrainteListe(Objet[Idx]);
                   //--VERIFICATION DU RESULTAT DU TEST
                   if (clsProfilwebdroitentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitentrepots;
               }

               HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
               try
               {
                   clsDonnee.pvgConnectionBase();
                   foreach (HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepotDTO in Objet)
                   {
                       Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new Stock.BOJ.clsProfilwebdroitentrepot();
                       clsProfilwebdroitentrepot.PO_CODEPROFILWEB = clsProfilwebdroitentrepotDTO.PO_CODEPROFILWEB.ToString();
                       clsProfilwebdroitentrepot.EN_CODEENTREPOT = clsProfilwebdroitentrepotDTO.EN_CODEENTREPOT.ToString();
                       clsObjetEnvoi.OE_A = clsProfilwebdroitentrepotDTO.clsObjetEnvoi.OE_A;
                       clsObjetEnvoi.OE_Y = clsProfilwebdroitentrepotDTO.clsObjetEnvoi.OE_Y;
                       clsObjetEnvoi.OE_PARAM = new string[] { clsProfilwebdroitentrepotDTO.PO_CODEPROFILWEB };
                       clsObjetRetour.SetValue(true, clsProfilwebdroitentrepotWSBLL.pvgModifier(clsDonnee, clsProfilwebdroitentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                   }
                   clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
                   if (clsObjetRetour.OR_BOOLEEN)
                   {
                       HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                       clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                       clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                       clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                       clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                       clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
                   }
                   else
                   {
                       HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                       clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                       clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                       clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                       clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                       clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
                   }



               }
               catch (SqlException SQLEx)
               {
                   HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                   clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                   clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                   clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                   clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                   //Execution du log
                   Log.Error(SQLEx.Message, null);
                   clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
                   clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
               }
               catch (Exception SQLEx)
               {
                   HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                   clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                   clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                   clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                   clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                   //Execution du log
                   Log.Error(SQLEx.Message, null);
                   clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
                   clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
               }

               finally
               {
                   clsDonnee.pvgDeConnectionBase();
               }
               return clsProfilwebdroitentrepots;
           }*/


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        /* public List<HT_Stock.BOJ.clsProfilwebdroitentrepot> pvgSupprimer(List<HT_Stock.BOJ.clsProfilwebdroitentrepot> Objet)
         {

             List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
             List<HT_Stock.BOJ.clsProfilwebdroitentrepot> clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();

             Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
             clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
             clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
             clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
             clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


             for (int Idx = 0; Idx < Objet.Count; Idx++)
             {
                 //--TEST DES CHAMPS OBLIGATOIRES
                // clsProfilwebdroitentrepots = TestChampObligatoireDelete(Objet[Idx]);
                 //--VERIFICATION DU RESULTAT DU TEST
                 if (clsProfilwebdroitentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitentrepots;
                 //--TEST CONTRAINTE
                // clsProfilwebdroitentrepots = TestTestContrainteListe(Objet[Idx]);
                 //--VERIFICATION DU RESULTAT DU TEST
                 if (clsProfilwebdroitentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitentrepots;
             }


             clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PO_CODEPROFILWEB };
             HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

             try
             {
                 clsDonnee.pvgConnectionBase();
                 clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                 clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                 clsObjetRetour.SetValue(true, clsProfilwebdroitentrepotWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                 clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
                 if (clsObjetRetour.OR_BOOLEEN)
                 {
                     HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                     clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                     clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                     clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                     clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                     clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
                 }
                 else
                 {
                     HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                     clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                     clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                     clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                     clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                     clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
                 }



             }
             catch (SqlException SQLEx)
             {
                 HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                 clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                 clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                 clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                 clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                 //Execution du log
                 Log.Error(SQLEx.Message, null);
                 clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
                 clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
             }
             catch (Exception SQLEx)
             {
                 HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                 clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                 clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                 clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                 clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                 //Execution du log
                 Log.Error(SQLEx.Message, null);
                 clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
                 clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
             }


             finally
             {
                 clsDonnee.pvgDeConnectionBase();
             }
             return clsProfilwebdroitentrepots;
         }*/


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgChargerDansDataSet(List<HT_Stock.BOJ.clsProfilwebdroitentrepot> Objet)
            {
            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitentrepot> clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].PO_CODEPROFILWEB };
            //DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfilwebdroitentrepotWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

                    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    {
                        DataSet.Tables[0].Rows[i]["SL_CODEMESSAGE"] = "00";
                        DataSet.Tables[0].Rows[i]["SL_RESULTAT"] = "TRUE";
                        DataSet.Tables[0].Rows[i]["SL_MESSAGE"] = "Opération réalisée avec succès !!!";

                    }

                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
            else
            {
                HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Aucun enregistrement trouvé !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                


            }
            catch (SqlException SQLEx)
            {

                //HT_Stock.BOJ.clsPhatiers clsProfilwebdroit = new HT_Stock.BOJ.clsProfilwebdroit();
                //  clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);

            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
    /*    public List<HT_Stock.BOJ.clsProfilwebdroitentrepot> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsProfilwebdroitentrepot> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsProfilwebdroitentrepot> clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsProfilwebdroitentrepots = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsProfilwebdroitentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitentrepots;
        //    //--TEST CONTRAINTE
        //    clsProfilwebdroitentrepots = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsProfilwebdroitentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitentrepots;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfilwebdroitentrepotWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                    clsProfilwebdroitentrepot.PO_CODEPROFILWEB = row["PO_CODEPROFILWEB"].ToString();
                    clsProfilwebdroitentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
                }
            }
            else
            {
                HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
                clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
            clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
            clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsProfilwebdroitentrepot clsProfilwebdroitentrepot = new HT_Stock.BOJ.clsProfilwebdroitentrepot();
            clsProfilwebdroitentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfilwebdroitentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfilwebdroitentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfilwebdroitentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitentrepot>();
            clsProfilwebdroitentrepots.Add(clsProfilwebdroitentrepot);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsProfilwebdroitentrepots;
    }*/


        
    }
}
