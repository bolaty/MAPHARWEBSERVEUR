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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsLogicielobjettypeoperationprofilweb" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsLogicielobjettypeoperationprofilweb.svc ou wsLogicielobjettypeoperationprofilweb.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsLogicielobjettypeoperationprofilweb : IwsLogicielobjettypeoperationprofilweb
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsLogicielobjettypeoperationprofilwebWSBLL clsLogicielobjettypeoperationprofilwebWSBLL = new clsLogicielobjettypeoperationprofilwebWSBLL();

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
        public string pvgAjouter(List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> Objet)
        {
            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
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
                foreach (HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilwebDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                    clsLogicielobjettypeoperationprofilweb.PO_CODEPROFILWEB = clsLogicielobjettypeoperationprofilwebDTO.PO_CODEPROFILWEB.ToString();
                    clsLogicielobjettypeoperationprofilweb.AG_CODEAGENCE = clsLogicielobjettypeoperationprofilwebDTO.AG_CODEAGENCE.ToString();
                    clsLogicielobjettypeoperationprofilweb.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeoperationprofilwebDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeoperationprofilweb.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeoperationprofilwebDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeoperationprofilweb.LO_ACTIF = clsLogicielobjettypeoperationprofilwebDTO.LO_ACTIF.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeoperationprofilwebDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeoperationprofilwebDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeoperationprofilwebWSBLL.pvgAjouter(clsDonnee, clsLogicielobjettypeoperationprofilweb, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
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
        public string pvgAjouterListe(List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> Objet)
        {
            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
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
            List<Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebss = new List<BOJ.clsLogicielobjettypeoperationprofilweb>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilwebDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                    clsLogicielobjettypeoperationprofilweb.PO_CODEPROFILWEB = clsLogicielobjettypeoperationprofilwebDTO.PO_CODEPROFILWEB.ToString();
                    clsLogicielobjettypeoperationprofilweb.AG_CODEAGENCE = clsLogicielobjettypeoperationprofilwebDTO.AG_CODEAGENCE.ToString();
                    clsLogicielobjettypeoperationprofilweb.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeoperationprofilwebDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeoperationprofilweb.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeoperationprofilwebDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeoperationprofilweb.LO_ACTIF = clsLogicielobjettypeoperationprofilwebDTO.LO_ACTIF.ToString();
                    clsLogicielobjettypeoperationprofilweb.COCHER = clsLogicielobjettypeoperationprofilwebDTO.COCHER.ToString();

                    clsObjetEnvoi.OE_A = clsLogicielobjettypeoperationprofilwebDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeoperationprofilwebDTO.clsObjetEnvoi.OE_Y;

                    clsLogicielobjettypeoperationprofilwebss.Add(clsLogicielobjettypeoperationprofilweb);

                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjettypeoperationprofilwebDTO.AG_CODEAGENCE, clsLogicielobjettypeoperationprofilwebDTO.PO_CODEPROFILWEB, clsLogicielobjettypeoperationprofilwebDTO.NF_CODENATUREFAMILLEOPERATION };
                }
                clsObjetRetour.SetValue(true, clsLogicielobjettypeoperationprofilwebWSBLL.pvgAjouterListe(clsDonnee, clsLogicielobjettypeoperationprofilwebss, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
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
      /*  public List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> pvgModifier(List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
               // clsLogicielobjettypeoperationprofilwebs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationprofilwebs;
                //--TEST CONTRAINTE
                // TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationprofilwebs;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilwebDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                   // clsLogicielobjettypeoperationprofilweb.PO_CODEPROFILWEB = clsLogicielobjettypeoperationprofilwebDTO.PO_CODEPROFILWEB.ToString();
                  //  clsLogicielobjettypeoperationprofilweb.AG_CODEAGENCE = clsLogicielobjettypeoperationprofilwebDTO.AG_CODEAGENCE.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeoperationprofilwebDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeoperationprofilwebDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjettypeoperationprofilwebDTO.PO_CODEPROFILWEB };
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeoperationprofilwebWSBLL.pvgModifier(clsDonnee, clsLogicielobjettypeoperationprofilweb, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
                clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
                clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeoperationprofilwebs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> pvgSupprimer(List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
               // clsLogicielobjettypeoperationprofilwebs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationprofilwebs;
                //--TEST CONTRAINTE
               // clsLogicielobjettypeoperationprofilwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeoperationprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeoperationprofilwebs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PO_CODEPROFILWEB };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsLogicielobjettypeoperationprofilwebWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
                clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
                clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeoperationprofilwebs;
        }*/


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public string pvgChargerDansDataSet(List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> Objet)
            {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
           
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


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].NF_CODENATUREFAMILLEOPERATION, Objet[0].PO_CODEPROFILWEB };
           // DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjettypeoperationprofilwebWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
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
                HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
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



      


        
    }
}
