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
using HT_Stock.BOJ;
using Stock.BOJ;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparcontratstatutdemande" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparcontratstatutdemande.svc ou wsCtparcontratstatutdemande.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparcontratstatutdemande : IwsCtparcontratstatutdemande
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparcontratstatutdemandeWSBLL clsCtparcontratstatutdemandeWSBLL = new clsCtparcontratstatutdemandeWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> pvgAjouter(List<HT_Stock.BOJ.clsCtparcontratstatutdemande> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparcontratstatutdemandes = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
                //--TEST CONTRAINTE
                clsCtparcontratstatutdemandes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemandeDTO in Objet)
                {
                    Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.SD_CODEPIECE = clsCtparcontratstatutdemandeDTO.SD_CODEPIECE.ToString();
                    clsCtparcontratstatutdemande.SD_LIBELLEPIECE = clsCtparcontratstatutdemandeDTO.SD_LIBELLEPIECE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparcontratstatutdemandeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparcontratstatutdemandeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparcontratstatutdemandeWSBLL.pvgAjouter(clsDonnee, clsCtparcontratstatutdemande, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparcontratstatutdemandes;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> pvgModifier(List<HT_Stock.BOJ.clsCtparcontratstatutdemande> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparcontratstatutdemandes = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
                //--TEST CONTRAINTE
                clsCtparcontratstatutdemandes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemandeDTO in Objet)
                {
                    Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.SD_CODEPIECE = clsCtparcontratstatutdemandeDTO.SD_CODEPIECE.ToString();
                    clsCtparcontratstatutdemande.SD_LIBELLEPIECE = clsCtparcontratstatutdemandeDTO.SD_LIBELLEPIECE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparcontratstatutdemandeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparcontratstatutdemandeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparcontratstatutdemandeDTO.SD_CODEPIECE };
                    clsObjetRetour.SetValue(true, clsCtparcontratstatutdemandeWSBLL.pvgModifier(clsDonnee, clsCtparcontratstatutdemande, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparcontratstatutdemandes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> pvgSupprimer(List<HT_Stock.BOJ.clsCtparcontratstatutdemande> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparcontratstatutdemandes = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
                //--TEST CONTRAINTE
                clsCtparcontratstatutdemandes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SD_CODEPIECE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparcontratstatutdemandeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparcontratstatutdemandes;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public string pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparcontratstatutdemande> Objet)
            {
                DataSet DataSet = new DataSet();

                DataTable dt = new DataTable("TABLE");
                dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
                dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
                dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
                 string json = "";

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparcontratstatutdemandes = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
            //    //--TEST CONTRAINTE
            //    clsCtparcontratstatutdemandes = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            //DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparcontratstatutdemandeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
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
        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparcontratstatutdemande> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparcontratstatutdemandes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
        //    //--TEST CONTRAINTE
        //    clsCtparcontratstatutdemandes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparcontratstatutdemandes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparcontratstatutdemandes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparcontratstatutdemandeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                    clsCtparcontratstatutdemande.SD_CODEPIECE = row["SD_CODEPIECE"].ToString();
                    clsCtparcontratstatutdemande.SD_LIBELLEPIECE = row["SD_LIBELLEPIECE"].ToString();
                    clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
            clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
            clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparcontratstatutdemandes;
    }


        
    }
}
