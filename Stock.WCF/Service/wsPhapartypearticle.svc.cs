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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhapartypearticle" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhapartypearticle.svc ou wsPhapartypearticle.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhapartypearticle : IwsPhapartypearticle
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhapartypearticleWSBLL clsPhapartypearticleWSBLL = new clsPhapartypearticleWSBLL();

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
        public List<HT_Stock.BOJ.clsPhapartypearticle> pvgAjouter(List<HT_Stock.BOJ.clsPhapartypearticle> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypearticles = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
                //--TEST CONTRAINTE
                clsPhapartypearticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticleDTO in Objet)
                {
                    Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.TA_CODETYPEARTICLE = clsPhapartypearticleDTO.TA_CODETYPEARTICLE.ToString();
                    clsPhapartypearticle.TA_LIBELLE = clsPhapartypearticleDTO.TA_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapartypearticleDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapartypearticleDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhapartypearticleWSBLL.pvgAjouter(clsDonnee, clsPhapartypearticle, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypearticles.Add(clsPhapartypearticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypearticles.Add(clsPhapartypearticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                clsPhapartypearticles.Add(clsPhapartypearticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                clsPhapartypearticles.Add(clsPhapartypearticle);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypearticles;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypearticle> pvgModifier(List<HT_Stock.BOJ.clsPhapartypearticle> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypearticles = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
                //--TEST CONTRAINTE
                clsPhapartypearticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticleDTO in Objet)
                {
                    Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.TA_CODETYPEARTICLE = clsPhapartypearticleDTO.TA_CODETYPEARTICLE.ToString();
                    clsPhapartypearticle.TA_LIBELLE = clsPhapartypearticleDTO.TA_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhapartypearticleDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhapartypearticleDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhapartypearticleDTO.TA_CODETYPEARTICLE };
                    clsObjetRetour.SetValue(true, clsPhapartypearticleWSBLL.pvgModifier(clsDonnee, clsPhapartypearticle, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypearticles.Add(clsPhapartypearticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypearticles.Add(clsPhapartypearticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                clsPhapartypearticles.Add(clsPhapartypearticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                clsPhapartypearticles.Add(clsPhapartypearticle);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypearticles;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypearticle> pvgSupprimer(List<HT_Stock.BOJ.clsPhapartypearticle> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypearticles = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
                //--TEST CONTRAINTE
                clsPhapartypearticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TA_CODETYPEARTICLE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhapartypearticleWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhapartypearticles.Add(clsPhapartypearticle);
                }
                else
                {
                    HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhapartypearticles.Add(clsPhapartypearticle);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                clsPhapartypearticles.Add(clsPhapartypearticle);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
                clsPhapartypearticles.Add(clsPhapartypearticle);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypearticles;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhapartypearticle> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhapartypearticle> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhapartypearticles = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
                //--TEST CONTRAINTE
                clsPhapartypearticles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].NT_CODENATURETYPEARTICLE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypearticleWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.TA_CODETYPEARTICLE = row["TA_CODETYPEARTICLE"].ToString();
                    clsPhapartypearticle.TA_LIBELLE = row["TA_LIBELLE"].ToString();
                    clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypearticles.Add(clsPhapartypearticle);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypearticles.Add(clsPhapartypearticle);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
            clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            clsPhapartypearticles.Add(clsPhapartypearticle);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
            clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            clsPhapartypearticles.Add(clsPhapartypearticle);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhapartypearticles;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhapartypearticle> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhapartypearticle> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhapartypearticles = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
        //    //--TEST CONTRAINTE
        //    clsPhapartypearticles = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhapartypearticles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhapartypearticles;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhapartypearticleWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                    clsPhapartypearticle.TA_CODETYPEARTICLE = row["TA_CODETYPEARTICLE"].ToString();
                    clsPhapartypearticle.TA_LIBELLE = row["TA_LIBELLE"].ToString();
                    clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhapartypearticles.Add(clsPhapartypearticle);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhapartypearticles.Add(clsPhapartypearticle);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
            clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            clsPhapartypearticles.Add(clsPhapartypearticle);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
            clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhapartypearticle.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            clsPhapartypearticles.Add(clsPhapartypearticle);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhapartypearticles;
    }


        
    }
}
