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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhapartypetierscompterattacheadditionnel" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhapartypetierscompterattacheadditionnel.svc ou wsPhapartypetierscompterattacheadditionnel.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhapartypetierscompterattacheadditionnel : IwsPhapartypetierscompterattacheadditionnel
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhapartypetierscompterattacheadditionnelWSBLL clsPhapartypetierscompterattacheadditionnelWSBLL = new clsPhapartypetierscompterattacheadditionnelWSBLL();

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
        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> pvgAjouter(List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypetierscompterattacheadditionnels = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
                //--TEST CONTRAINTE
                clsPhapartypetierscompterattacheadditionnels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnelDTO in Objet)
                {
                    Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS = clsPhapartypetierscompterattacheadditionnelDTO.TC_CODECOMPTETYPETIERS.ToString();
                    clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE = clsPhapartypetierscompterattacheadditionnelDTO.TC_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapartypetierscompterattacheadditionnelDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapartypetierscompterattacheadditionnelDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhapartypetierscompterattacheadditionnelWSBLL.pvgAjouter(clsDonnee, clsPhapartypetierscompterattacheadditionnel, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypetierscompterattacheadditionnels;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> pvgModifier(List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypetierscompterattacheadditionnels = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
                //--TEST CONTRAINTE
                clsPhapartypetierscompterattacheadditionnels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnelDTO in Objet)
                {
                    Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS = clsPhapartypetierscompterattacheadditionnelDTO.TC_CODECOMPTETYPETIERS.ToString();
                    clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE = clsPhapartypetierscompterattacheadditionnelDTO.TC_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapartypetierscompterattacheadditionnelDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapartypetierscompterattacheadditionnelDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhapartypetierscompterattacheadditionnelDTO.TC_CODECOMPTETYPETIERS };
                    clsObjetRetour.SetValue(true, clsPhapartypetierscompterattacheadditionnelWSBLL.pvgModifier(clsDonnee, clsPhapartypetierscompterattacheadditionnel, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypetierscompterattacheadditionnels;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> pvgSupprimer(List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypetierscompterattacheadditionnels = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
                //--TEST CONTRAINTE
                clsPhapartypetierscompterattacheadditionnels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TC_CODECOMPTETYPETIERS };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhapartypetierscompterattacheadditionnelWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypetierscompterattacheadditionnels;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhapartypetierscompterattacheadditionnels = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
            //    //--TEST CONTRAINTE
            //    clsPhapartypetierscompterattacheadditionnels = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypetierscompterattacheadditionnelWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS = row["TC_CODECOMPTETYPETIERS"].ToString();
                    clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE = row["TC_LIBELLE"].ToString();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypetierscompterattacheadditionnels;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhapartypetierscompterattacheadditionnels = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
        //    //--TEST CONTRAINTE
        //    clsPhapartypetierscompterattacheadditionnels = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypetierscompterattacheadditionnelWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                    clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS = row["TC_CODECOMPTETYPETIERS"].ToString();
                    clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE = row["TC_LIBELLE"].ToString();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhapartypetierscompterattacheadditionnels;
    }

    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> pvgChargerDansDataSetPourComboEdition(List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> Objet)
        {

    List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
    List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
           
    Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
    clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
    clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
    clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
    clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypetierscompterattacheadditionnels = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
                //--TEST CONTRAINTE
                clsPhapartypetierscompterattacheadditionnels = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypetierscompterattacheadditionnels[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypetierscompterattacheadditionnels;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].TC_CODECOMPTETYPETIERS };
    DataSet DataSet = new DataSet();

    try
    {
        clsDonnee.pvgConnectionBase();
        DataSet = clsPhapartypetierscompterattacheadditionnelWSBLL.pvgChargerDansDataSetPourComboEdition(clsDonnee, clsObjetEnvoi);
        clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
                clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS = row["TC_CODECOMPTETYPETIERS"].ToString();
                clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE = row["TC_LIBELLE"].ToString();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            }
        }
        else
        {
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
        }
                


    }
    catch (SqlException SQLEx)
    {
        HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
        clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
        clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
        clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
    }
    catch (Exception SQLEx)
    {
        HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
        clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
        clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
        clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
    }


    finally
    {
        clsDonnee.pvgDeConnectionBase();
    }
    return clsPhapartypetierscompterattacheadditionnels;
    }
        
    }
}
