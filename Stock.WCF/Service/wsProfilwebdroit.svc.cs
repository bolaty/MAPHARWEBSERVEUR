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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsProfilwebdroit" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsProfilwebdroit.svc ou wsProfilwebdroit.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsProfilwebdroit : IwsProfilwebdroit
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsProfilwebdroitWSBLL clsProfilwebdroitWSBLL = new clsProfilwebdroitWSBLL();

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
        public string pvgAjouter(List<HT_Stock.BOJ.clsProfilwebdroit> Objet)
        {
            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroit> clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
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
                //if (clsProfilwebdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroits;
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
                foreach (HT_Stock.BOJ.clsProfilwebdroit clsProfilwebdroitDTO in Objet)
                {
                    Stock.BOJ.clsProfilwebdroit clsProfilwebdroit = new Stock.BOJ.clsProfilwebdroit();
                    clsProfilwebdroit.PO_CODEPROFILWEB = clsProfilwebdroitDTO.PO_CODEPROFILWEB.ToString();
                    clsProfilwebdroit.OB_CODEOBJET = int.Parse(clsProfilwebdroitDTO.OB_CODEOBJET.ToString());
                    clsProfilwebdroit.PD_AUTORISER = clsProfilwebdroitDTO.PD_AUTORISER.ToString();
                    clsProfilwebdroit.PD_AJOUTER = clsProfilwebdroitDTO.PD_AJOUTER.ToString();
                    clsProfilwebdroit.PD_MODIFIER = clsProfilwebdroitDTO.PD_MODIFIER.ToString();
                    clsProfilwebdroit.PD_SUPPRIMER = clsProfilwebdroitDTO.PD_SUPPRIMER.ToString();
                    clsProfilwebdroit.PD_APERCU = clsProfilwebdroitDTO.PD_APERCU.ToString();
                    clsProfilwebdroit.PD_IMPRIMER = clsProfilwebdroitDTO.PD_IMPRIMER.ToString();
                    clsProfilwebdroit.PD_IMPRIMERTOUT = clsProfilwebdroitDTO.PD_IMPRIMERTOUT.ToString();
                    clsProfilwebdroit.PD_NUMEROORDRE = int.Parse(clsProfilwebdroitDTO.PD_NUMEROORDRE.ToString());
                    clsProfilwebdroit.LO_CODELOGICIEL = clsProfilwebdroitDTO.LO_CODELOGICIEL.ToString();
                    clsProfilwebdroit.OB_RATTACHEA = clsProfilwebdroitDTO.OB_RATTACHEA.ToString();
                  //  clsProfilwebdroit.OT_CODETYPEOBJET = clsProfilwebdroitDTO.OT_CODETYPEOBJET.ToString();
                    clsObjetEnvoi.OE_A = clsProfilwebdroitDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilwebdroitDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsProfilwebdroitWSBLL.pvgAjouter(clsDonnee, clsProfilwebdroit, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
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
        public string pvgAjouterdroit(List<HT_Stock.BOJ.clsProfilwebdroit> Objet)
        {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<Stock.BOJ.clsProfilwebdroit> clsProfilwebdroitBOJs = new List<Stock.BOJ.clsProfilwebdroit>();
            List<HT_Stock.BOJ.clsProfilwebdroit> clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
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
                //if (clsProfilwebdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsProfilwebdroits;
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
                foreach (HT_Stock.BOJ.clsProfilwebdroit clsProfilwebdroitDTO in Objet)
                {
                    Stock.BOJ.clsProfilwebdroit clsProfilwebdroit = new Stock.BOJ.clsProfilwebdroit();
                    //clsProfilwebdroit.AG_CODEAGENCE = clsProfilwebdroitDTO.AG_CODEAGENCE.ToString();
                    clsProfilwebdroit.PO_CODEPROFILWEB = clsProfilwebdroitDTO.PO_CODEPROFILWEB.ToString();
                    clsProfilwebdroit.OB_CODEOBJET = int.Parse(clsProfilwebdroitDTO.OB_CODEOBJET.ToString());
                    clsProfilwebdroit.PD_AJOUTER = clsProfilwebdroitDTO.PD_AJOUTER.ToString();
                    clsProfilwebdroit.PD_MODIFIER = clsProfilwebdroitDTO.PD_MODIFIER.ToString();
                    clsProfilwebdroit.PD_SUPPRIMER = clsProfilwebdroitDTO.PD_SUPPRIMER.ToString();
                    clsProfilwebdroit.PD_APERCU = clsProfilwebdroitDTO.PD_APERCU.ToString();
                    clsProfilwebdroit.PD_AUTORISER = clsProfilwebdroitDTO.PD_AUTORISER.ToString();
                    clsProfilwebdroit.PD_IMPRIMER = clsProfilwebdroitDTO.PD_IMPRIMER.ToString();
                    clsProfilwebdroit.PD_IMPRIMERTOUT = clsProfilwebdroitDTO.PD_IMPRIMERTOUT.ToString();
                    clsProfilwebdroit.LO_CODELOGICIEL = clsProfilwebdroitDTO.LO_CODELOGICIEL.ToString();
                    clsProfilwebdroit.OB_RATTACHEA = clsProfilwebdroitDTO.OB_RATTACHEA.ToString();
                    clsProfilwebdroit.PD_NUMEROORDRE = int.Parse(clsProfilwebdroitDTO.PD_NUMEROORDRE.ToString());
                    clsObjetEnvoi.OE_A = clsProfilwebdroitDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsProfilwebdroitDTO.clsObjetEnvoi.OE_Y;

                    clsProfilwebdroitBOJs.Add(clsProfilwebdroit);
                }


                clsObjetRetour.SetValue(true, clsProfilwebdroitWSBLL.pvgAjouterdroit(clsDonnee, clsProfilwebdroitBOJs, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
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
        public string pvgChargerDansDataSet(List<HT_Stock.BOJ.clsProfilwebdroit> Objet)
            {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));



            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsProfilwebdroit> clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
           
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


            //clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].PO_CODEPROFILWEB, Objet[0].OB_CODEOBJET };

            if (Objet[0].OB_CODEOBJET == "5")
                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PO_CODEPROFILWEB, Objet[0].OB_CODEOBJET, Objet[0].LO_CODELOGICIEL };
            else
                clsObjetEnvoi.OE_PARAM = new string[] {  Objet[0].PO_CODEPROFILWEB, Objet[0].OB_CODEOBJET, Objet[0].LO_CODELOGICIEL, Objet[0].OB_RATTACHEA };



            //  DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsProfilwebdroitWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
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
                    HT_Stock.BOJ.clsProfilwebdroit clsProfilwebdroit = new HT_Stock.BOJ.clsProfilwebdroit();
                    clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();

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
