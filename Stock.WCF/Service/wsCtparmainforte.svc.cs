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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparmainforte" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparmainforte.svc ou wsCtparmainforte.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparmainforte : IwsCtparmainforte
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtparmainforteWSBLL clsCtparmainforteWSBLL = new clsCtparmainforteWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparmainforte> pvgAjouter(List<HT_Stock.BOJ.clsCtparmainforte> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparmainfortes = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
                //--TEST CONTRAINTE
                clsCtparmainfortes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparmainforte clsCtparmainforteDTO in Objet)
                {
                    Stock.BOJ.clsCtparmainforte clsCtparmainforte = new Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.MF_CODEMAINFORTE = clsCtparmainforteDTO.MF_CODEMAINFORTE.ToString();
                    clsCtparmainforte.MF_LIBLLEMAINFORTE = clsCtparmainforteDTO.MF_LIBLLEMAINFORTE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparmainforteDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparmainforteDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtparmainforteWSBLL.pvgAjouter(clsDonnee, clsCtparmainforte, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparmainfortes.Add(clsCtparmainforte);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparmainfortes.Add(clsCtparmainforte);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                clsCtparmainfortes.Add(clsCtparmainforte);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                clsCtparmainfortes.Add(clsCtparmainforte);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparmainfortes;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparmainforte> pvgModifier(List<HT_Stock.BOJ.clsCtparmainforte> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparmainfortes = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
                //--TEST CONTRAINTE
                clsCtparmainfortes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparmainforte clsCtparmainforteDTO in Objet)
                {
                    Stock.BOJ.clsCtparmainforte clsCtparmainforte = new Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.MF_CODEMAINFORTE = clsCtparmainforteDTO.MF_CODEMAINFORTE.ToString();
                    clsCtparmainforte.MF_LIBLLEMAINFORTE = clsCtparmainforteDTO.MF_LIBLLEMAINFORTE.ToString();
                    clsObjetEnvoi.OE_A = clsCtparmainforteDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtparmainforteDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtparmainforteDTO.MF_CODEMAINFORTE };
                    clsObjetRetour.SetValue(true, clsCtparmainforteWSBLL.pvgModifier(clsDonnee, clsCtparmainforte, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparmainfortes.Add(clsCtparmainforte);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparmainfortes.Add(clsCtparmainforte);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                clsCtparmainfortes.Add(clsCtparmainforte);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                clsCtparmainfortes.Add(clsCtparmainforte);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparmainfortes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparmainforte> pvgSupprimer(List<HT_Stock.BOJ.clsCtparmainforte> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtparmainfortes = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
                //--TEST CONTRAINTE
                clsCtparmainfortes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].MF_CODEMAINFORTE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtparmainforteWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtparmainfortes.Add(clsCtparmainforte);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtparmainfortes.Add(clsCtparmainforte);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                clsCtparmainfortes.Add(clsCtparmainforte);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
                clsCtparmainfortes.Add(clsCtparmainforte);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparmainfortes;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparmainforte> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparmainforte> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtparmainfortes = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
            //    //--TEST CONTRAINTE
            //    clsCtparmainfortes = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparmainforteWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.MF_CODEMAINFORTE = row["MF_CODEMAINFORTE"].ToString();
                    clsCtparmainforte.MF_LIBLLEMAINFORTE = row["MF_LIBLLEMAINFORTE"].ToString();
                    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparmainforte.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparmainfortes.Add(clsCtparmainforte);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparmainfortes.Add(clsCtparmainforte);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
            clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparmainforte.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            clsCtparmainfortes.Add(clsCtparmainforte);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
            clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparmainforte.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            clsCtparmainfortes.Add(clsCtparmainforte);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtparmainfortes;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparmainforte> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparmainforte> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtparmainfortes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
        //    //--TEST CONTRAINTE
        //    clsCtparmainfortes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtparmainfortes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtparmainfortes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtparmainforteWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                    clsCtparmainforte.MF_CODEMAINFORTE = row["MF_CODEMAINFORTE"].ToString();
                    clsCtparmainforte.MF_LIBLLEMAINFORTE = row["MF_LIBLLEMAINFORTE"].ToString();
                    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparmainforte.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtparmainfortes.Add(clsCtparmainforte);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtparmainfortes.Add(clsCtparmainforte);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
            clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparmainforte.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            clsCtparmainfortes.Add(clsCtparmainforte);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
            clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparmainforte.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparmainforte.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            clsCtparmainfortes.Add(clsCtparmainforte);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtparmainfortes;
    }


        
    }
}
