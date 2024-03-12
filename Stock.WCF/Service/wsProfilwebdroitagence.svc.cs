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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsProfilwebdroitagence" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsProfilwebdroitagence.svc ou wsProfilwebdroitagence.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsProfilwebdroitagence : IwsProfilwebdroitagence
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsProfilwebdroitagenceWSBLL clsProfilwebdroitagenceWSBLL = new clsProfilwebdroitagenceWSBLL();

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
        public string pvgAjouter(List<HT_Stock.BOJ.clsProfilwebdroitagence> Objet)
        {
            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
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
                foreach (HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagenceDTO in Objet)
                {
                    Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new Stock.BOJ.clsProfilwebdroitagence();
                    clsProfilwebdroitagence.PO_CODEPROFILWEB = clsProfilwebdroitagenceDTO.PO_CODEPROFILWEB.ToString();
                    clsProfilwebdroitagence.AG_CODEAGENCE = clsProfilwebdroitagenceDTO.AG_CODEAGENCE.ToString();
                    clsProfilwebdroitagence.COCHER = clsProfilwebdroitagenceDTO.COCHER.ToString();
                    clsProfilwebdroitagence.AG_RAISONSOCIAL = clsProfilwebdroitagenceDTO.AG_RAISONSOCIAL.ToString();
                    clsObjetEnvoi.OE_A = clsProfilwebdroitagenceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilwebdroitagenceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsProfilwebdroitagenceWSBLL.pvgAjouter(clsDonnee, clsProfilwebdroitagence, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
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
        public string pvgAjouterdroit(List<HT_Stock.BOJ.clsProfilwebdroitagence> Objet)
        {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
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

                List<Stock.BOJ.clsProfilwebdroitagence> clsOperateurdroitagenceAjout = new List<BOJ.clsProfilwebdroitagence>();
                List<Stock.BOJ.clsProfilwebdroitagence> clsOperateurdroitagenceSuppression = new List<BOJ.clsProfilwebdroitagence>();
                foreach (HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagenceDTO in Objet)
                {
                    Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new Stock.BOJ.clsProfilwebdroitagence();
                    clsProfilwebdroitagence.AG_CODEAGENCE = clsProfilwebdroitagenceDTO.AG_CODEAGENCE;
                    clsProfilwebdroitagence.PO_CODEPROFILWEB = clsProfilwebdroitagenceDTO.PO_CODEPROFILWEB;
                    clsProfilwebdroitagence.COCHER = clsProfilwebdroitagenceDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsProfilwebdroitagenceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilwebdroitagenceDTO.clsObjetEnvoi.OE_Y;
                    clsOperateurdroitagenceAjout.Add(clsProfilwebdroitagence);

                }


                clsObjetRetour.SetValue(true, clsProfilwebdroitagenceWSBLL.pvgAjouterdroit(clsDonnee, clsOperateurdroitagenceAjout, clsOperateurdroitagenceSuppression, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsOperateurdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
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
        /* public List<HT_Stock.BOJ.clsProfilwebdroitagence> pvgModifier(List<HT_Stock.BOJ.clsProfilwebdroitagence> Objet)
         {
             List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
             List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
             Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
             clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
             clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
             clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
             clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

             for (int Idx = 0; Idx < Objet.Count; Idx++)
             {
                 //--TEST DES CHAMPS OBLIGATOIRES
                // clsProfilwebdroitagences = TestChampObligatoireUpdate(Objet[Idx]);
                 //--VERIFICATION DU RESULTAT DU TEST
                 if (clsProfilwebdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitagences;
                 //--TEST CONTRAINTE
                 // TestTestContrainteListe(Objet[Idx]);
                 //--VERIFICATION DU RESULTAT DU TEST
                 if (clsProfilwebdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitagences;
             }

             HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
             try
             {
                 clsDonnee.pvgConnectionBase();
                 foreach (HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagenceDTO in Objet)
                 {
                     Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new Stock.BOJ.clsProfilwebdroitagence();
                     clsProfilwebdroitagence.PO_CODEPROFILWEB = clsProfilwebdroitagenceDTO.PO_CODEPROFILWEB.ToString();
                     clsProfilwebdroitagence.AG_CODEAGENCE = clsProfilwebdroitagenceDTO.AG_CODEAGENCE.ToString();
                     clsObjetEnvoi.OE_A = clsProfilwebdroitagenceDTO.clsObjetEnvoi.OE_A;
                     clsObjetEnvoi.OE_Y = clsProfilwebdroitagenceDTO.clsObjetEnvoi.OE_Y;
                     clsObjetEnvoi.OE_PARAM = new string[] { clsProfilwebdroitagenceDTO.PO_CODEPROFILWEB };
                     clsObjetRetour.SetValue(true, clsProfilwebdroitagenceWSBLL.pvgModifier(clsDonnee, clsProfilwebdroitagence, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                 }
                 clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
                 if (clsObjetRetour.OR_BOOLEEN)
                 {
                     HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                     clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                     clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                     clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                     clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                     clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
                 }
                 else
                 {
                     HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                     clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                     clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                     clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                     clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                     clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
                 }



             }
             catch (SqlException SQLEx)
             {
                 HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                 clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                 clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                 clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                 clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                 //Execution du log
                 Log.Error(SQLEx.Message, null);
                 clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
                 clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
             }
             catch (Exception SQLEx)
             {
                 HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                 clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                 clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                 clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                 clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                 //Execution du log
                 Log.Error(SQLEx.Message, null);
                 clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
                 clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
             }

             finally
             {
                 clsDonnee.pvgDeConnectionBase();
             }
             return clsProfilwebdroitagences;
         }*/


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        /*  public List<HT_Stock.BOJ.clsProfilwebdroitagence> pvgSupprimer(List<HT_Stock.BOJ.clsProfilwebdroitagence> Objet)
          {

              List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
              List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();

              Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
              clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
              clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
              clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
              clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


              for (int Idx = 0; Idx < Objet.Count; Idx++)
              {
                  //--TEST DES CHAMPS OBLIGATOIRES
                 // clsProfilwebdroitagences = TestChampObligatoireDelete(Objet[Idx]);
                  //--VERIFICATION DU RESULTAT DU TEST
                  if (clsProfilwebdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitagences;
                  //--TEST CONTRAINTE
                 // clsProfilwebdroitagences = TestTestContrainteListe(Objet[Idx]);
                  //--VERIFICATION DU RESULTAT DU TEST
                  if (clsProfilwebdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitagences;
              }


              clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PO_CODEPROFILWEB };
              HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

              try
              {
                  clsDonnee.pvgConnectionBase();
                  clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                  clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                  clsObjetRetour.SetValue(true, clsProfilwebdroitagenceWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                  clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
                  if (clsObjetRetour.OR_BOOLEEN)
                  {
                      HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                      clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                      clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                      clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                      clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                      clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
                  }
                  else
                  {
                      HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                      clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                      clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                      clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                      clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                      clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
                  }



              }
              catch (SqlException SQLEx)
              {
                  HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                  clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                  clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                  clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                  clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                  //Execution du log
                  Log.Error(SQLEx.Message, null);
                  clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
                  clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
              }
              catch (Exception SQLEx)
              {
                  HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                  clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                  clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                  clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                  clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                  //Execution du log
                  Log.Error(SQLEx.Message, null);
                  clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
                  clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
              }


              finally
              {
                  clsDonnee.pvgDeConnectionBase();
              }
              return clsProfilwebdroitagences;
          }*/


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgChargerDansDataSet(List<HT_Stock.BOJ.clsProfilwebdroitagence> Objet)
            {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
           
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
           // DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfilwebdroitagenceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
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
                HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
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
    /*    public List<HT_Stock.BOJ.clsProfilwebdroitagence> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsProfilwebdroitagence> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsProfilwebdroitagences = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsProfilwebdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitagences;
        //    //--TEST CONTRAINTE
        //    clsProfilwebdroitagences = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsProfilwebdroitagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroitagences;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfilwebdroitagenceWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                    clsProfilwebdroitagence.PO_CODEPROFILWEB = row["PO_CODEPROFILWEB"].ToString();
                    clsProfilwebdroitagence.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
                }
            }
            else
            {
                HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
            clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
            clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
            clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
            clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsProfilwebdroitagences;
    }*/


        
    }
}
