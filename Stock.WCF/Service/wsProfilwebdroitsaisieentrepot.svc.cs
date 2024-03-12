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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsProfilwebdroitsaisieentrepot" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsProfilwebdroitsaisieentrepot.svc ou wsProfilwebdroitsaisieentrepot.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsProfilwebdroitsaisieentrepot : IwsProfilwebdroitsaisieentrepot
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsProfilwebdroitsaisieentrepotWSBLL clsProfilwebdroitsaisieentrepotWSBLL = new clsProfilwebdroitsaisieentrepotWSBLL();

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
        public string pvgAjouter(List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> Objet)
        {
            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
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
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepotDTO in Objet)
                {
                    Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                    clsProfilwebdroitsaisieentrepot.PO_CODEPROFILWEB = clsProfilwebdroitsaisieentrepotDTO.PO_CODEPROFILWEB.ToString();
                    clsProfilwebdroitsaisieentrepot.EN_CODEENTREPOT = clsProfilwebdroitsaisieentrepotDTO.EN_CODEENTREPOT.ToString();
                    clsProfilwebdroitsaisieentrepot.COCHER = clsProfilwebdroitsaisieentrepotDTO.COCHER.ToString();
                    clsObjetEnvoi.OE_A = clsProfilwebdroitsaisieentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilwebdroitsaisieentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsProfilwebdroitsaisieentrepotWSBLL.pvgAjouter(clsDonnee, clsProfilwebdroitsaisieentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
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
        public string pvgAjouterdroit(List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> Objet)
        {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
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

                List<Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepotAjout = new List<BOJ.clsProfilwebdroitsaisieentrepot>();
                List<Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepotSuppression = new List<BOJ.clsProfilwebdroitsaisieentrepot>();
                foreach (HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepotDTO in Objet)
                {
                    Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                    clsProfilwebdroitsaisieentrepot.EN_CODEENTREPOT = clsProfilwebdroitsaisieentrepotDTO.EN_CODEENTREPOT;
                    clsProfilwebdroitsaisieentrepot.PO_CODEPROFILWEB = clsProfilwebdroitsaisieentrepotDTO.PO_CODEPROFILWEB;
                    clsProfilwebdroitsaisieentrepot.COCHER = clsProfilwebdroitsaisieentrepotDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsProfilwebdroitsaisieentrepotDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilwebdroitsaisieentrepotDTO.clsObjetEnvoi.OE_Y;
                    clsProfilwebdroitsaisieentrepotAjout.Add(clsProfilwebdroitsaisieentrepot);

                }


                clsObjetRetour.SetValue(true, clsProfilwebdroitsaisieentrepotWSBLL.pvgAjouterdroit(clsDonnee, clsProfilwebdroitsaisieentrepotAjout, clsProfilwebdroitsaisieentrepotSuppression, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
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
        /*   public List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> pvgModifier(List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> Objet)
           {
               List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
               List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
               Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
               clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
               clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
               clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
               clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

               for (int Idx = 0; Idx < Objet.Count; Idx++)
               {
                   //--TEST DES CHAMPS OBLIGATOIRES
                  // clsProfilwebdroitsaisieentrepots = TestChampObligatoireUpdate(Objet[Idx]);
                   //--VERIFICATION DU RESULTAT DU TEST
                   if (clsProfilwebdroitsaisieentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitsaisieentrepots;
                   //--TEST CONTRAINTE
                   // TestTestContrainteListe(Objet[Idx]);
                   //--VERIFICATION DU RESULTAT DU TEST
                   if (clsProfilwebdroitsaisieentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitsaisieentrepots;
               }

               HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
               try
               {
                   clsDonnee.pvgConnectionBase();
                   foreach (HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepotDTO in Objet)
                   {
                       Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                       clsProfilwebdroitsaisieentrepot.PO_CODEPROFILWEB = clsProfilwebdroitsaisieentrepotDTO.PO_CODEPROFILWEB.ToString();
                       clsProfilwebdroitsaisieentrepot.EN_CODEENTREPOT = clsProfilwebdroitsaisieentrepotDTO.EN_CODEENTREPOT.ToString();
                       clsObjetEnvoi.OE_A = clsProfilwebdroitsaisieentrepotDTO.clsObjetEnvoi.OE_A;
                       clsObjetEnvoi.OE_Y = clsProfilwebdroitsaisieentrepotDTO.clsObjetEnvoi.OE_Y;
                       clsObjetEnvoi.OE_PARAM = new string[] { clsProfilwebdroitsaisieentrepotDTO.PO_CODEPROFILWEB };
                       clsObjetRetour.SetValue(true, clsProfilwebdroitsaisieentrepotWSBLL.pvgModifier(clsDonnee, clsProfilwebdroitsaisieentrepot, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                   }
                   clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
                   if (clsObjetRetour.OR_BOOLEEN)
                   {
                       HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                       clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                       clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                       clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                       clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                       clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
                   }
                   else
                   {
                       HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                       clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                       clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                       clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                       clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                       clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
                   }



               }
               catch (SqlException SQLEx)
               {
                   HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                   clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                   clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                   clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                   clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                   //Execution du log
                   Log.Error(SQLEx.Message, null);
                   clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
                   clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
               }
               catch (Exception SQLEx)
               {
                   HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                   clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                   clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                   clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                   clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                   //Execution du log
                   Log.Error(SQLEx.Message, null);
                   clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
                   clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
               }

               finally
               {
                   clsDonnee.pvgDeConnectionBase();
               }
               return clsProfilwebdroitsaisieentrepots;
           }*/


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        /*  public List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> pvgSupprimer(List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> Objet)
          {

              List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
              List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();

              Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
              clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
              clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
              clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
              clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


              for (int Idx = 0; Idx < Objet.Count; Idx++)
              {
                  //--TEST DES CHAMPS OBLIGATOIRES
                 // clsProfilwebdroitsaisieentrepots = TestChampObligatoireDelete(Objet[Idx]);
                  //--VERIFICATION DU RESULTAT DU TEST
                  if (clsProfilwebdroitsaisieentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitsaisieentrepots;
                  //--TEST CONTRAINTE
                 // clsProfilwebdroitsaisieentrepots = TestTestContrainteListe(Objet[Idx]);
                  //--VERIFICATION DU RESULTAT DU TEST
                  if (clsProfilwebdroitsaisieentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitsaisieentrepots;
              }


              clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PO_CODEPROFILWEB };
              HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

              try
              {
                  clsDonnee.pvgConnectionBase();
                  clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                  clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                  clsObjetRetour.SetValue(true, clsProfilwebdroitsaisieentrepotWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                  clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
                  if (clsObjetRetour.OR_BOOLEEN)
                  {
                      HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                      clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                      clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "00";
                      clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                      clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                      clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
                  }
                  else
                  {
                      HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                      clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                      clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                      clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                      clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                      clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
                  }



              }
              catch (SqlException SQLEx)
              {
                  HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                  clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                  clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                  clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                  clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                  //Execution du log
                  Log.Error(SQLEx.Message, null);
                  clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
                  clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
              }
              catch (Exception SQLEx)
              {
                  HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                  clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                  clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                  clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                  clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                  //Execution du log
                  Log.Error(SQLEx.Message, null);
                  clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
                  clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
              }


              finally
              {
                  clsDonnee.pvgDeConnectionBase();
              }
              return clsProfilwebdroitsaisieentrepots;
          }*/


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgChargerDansDataSet(List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> Objet)
            {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
           
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
            DataSet = clsProfilwebdroitsaisieentrepotWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
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
                HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
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
    /*    public List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsProfilwebdroitsaisieentrepots = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsProfilwebdroitsaisieentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitsaisieentrepots;
        //    //--TEST CONTRAINTE
        //    clsProfilwebdroitsaisieentrepots = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsProfilwebdroitsaisieentrepots[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitsaisieentrepots;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfilwebdroitsaisieentrepotWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                    clsProfilwebdroitsaisieentrepot.PO_CODEPROFILWEB = row["PO_CODEPROFILWEB"].ToString();
                    clsProfilwebdroitsaisieentrepot.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
                }
            }
            else
            {
                HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
            clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
            clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsProfilwebdroitsaisieentrepots;
    }*/


        
    }
}
