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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhapartypetiers" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhapartypetiers.svc ou wsPhapartypetiers.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhapartypetiers : IwsPhapartypetiers
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhapartypetiersWSBLL clsPhapartypetiersWSBLL = new clsPhapartypetiersWSBLL();

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
        public List<HT_Stock.BOJ.clsPhapartypetiers> pvgAjouter(List<HT_Stock.BOJ.clsPhapartypetiers> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypetierss = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
                //--TEST CONTRAINTE
                clsPhapartypetierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiersDTO in Objet)
                {
                    Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.TP_CODETYPETIERS = clsPhapartypetiersDTO.TP_CODETYPETIERS.ToString();
                    clsPhapartypetiers.TP_LIBELLE = clsPhapartypetiersDTO.TP_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapartypetiersDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapartypetiersDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhapartypetiersWSBLL.pvgAjouter(clsDonnee, clsPhapartypetiers, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypetierss.Add(clsPhapartypetiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypetierss.Add(clsPhapartypetiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                clsPhapartypetierss.Add(clsPhapartypetiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                clsPhapartypetierss.Add(clsPhapartypetiers);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypetierss;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypetiers> pvgModifier(List<HT_Stock.BOJ.clsPhapartypetiers> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypetierss = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
                //--TEST CONTRAINTE
                clsPhapartypetierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiersDTO in Objet)
                {
                    Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.TP_CODETYPETIERS = clsPhapartypetiersDTO.TP_CODETYPETIERS.ToString();
                    clsPhapartypetiers.TP_LIBELLE = clsPhapartypetiersDTO.TP_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapartypetiersDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapartypetiersDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhapartypetiersDTO.TP_CODETYPETIERS };
                    clsObjetRetour.SetValue(true, clsPhapartypetiersWSBLL.pvgModifier(clsDonnee, clsPhapartypetiers, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypetierss.Add(clsPhapartypetiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypetierss.Add(clsPhapartypetiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                clsPhapartypetierss.Add(clsPhapartypetiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                clsPhapartypetierss.Add(clsPhapartypetiers);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypetierss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypetiers> pvgSupprimer(List<HT_Stock.BOJ.clsPhapartypetiers> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypetierss = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
                //--TEST CONTRAINTE
                clsPhapartypetierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TP_CODETYPETIERS };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhapartypetiersWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypetierss.Add(clsPhapartypetiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypetierss.Add(clsPhapartypetiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                clsPhapartypetierss.Add(clsPhapartypetiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
                clsPhapartypetierss.Add(clsPhapartypetiers);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypetierss;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhapartypetiers> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhapartypetiers> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhapartypetierss = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
            //    //--TEST CONTRAINTE
            //    clsPhapartypetierss = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypetiersWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
                    clsPhapartypetiers.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                    clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypetierss.Add(clsPhapartypetiers);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypetierss.Add(clsPhapartypetiers);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
            clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypetiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            clsPhapartypetierss.Add(clsPhapartypetiers);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
            clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypetiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            clsPhapartypetierss.Add(clsPhapartypetiers);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypetierss;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypetiers> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhapartypetiers> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhapartypetierss = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
        //    //--TEST CONTRAINTE
        //    clsPhapartypetierss = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierss;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] { "11", "32"};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypetiersWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                    clsPhapartypetiers.TP_CODETYPETIERS = row["TP_CODETYPETIERS"].ToString();
                    clsPhapartypetiers.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                    clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypetierss.Add(clsPhapartypetiers);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypetierss.Add(clsPhapartypetiers);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
            clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypetiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            clsPhapartypetierss.Add(clsPhapartypetiers);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
            clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypetiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            clsPhapartypetierss.Add(clsPhapartypetiers);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhapartypetierss;
    }


        
    }
}
