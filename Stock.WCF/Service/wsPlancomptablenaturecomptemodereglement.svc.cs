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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPlancomptablenaturecomptemodereglement" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPlancomptablenaturecomptemodereglement.svc ou wsPlancomptablenaturecomptemodereglement.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPlancomptablenaturecomptemodereglement : IwsPlancomptablenaturecomptemodereglement
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPlancomptablenaturecomptemodereglementWSBLL clsPlancomptablenaturecomptemodereglementWSBLL = new clsPlancomptablenaturecomptemodereglementWSBLL();

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
        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> pvgAjouter(List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPlancomptablenaturecomptemodereglements = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
                //--TEST CONTRAINTE
                clsPlancomptablenaturecomptemodereglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglementDTO in Objet)
                {
                    Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE = clsPlancomptablenaturecomptemodereglementDTO.NC_CODENATURECOMPTE.ToString();
                    //clsPlancomptablenaturecomptemodereglement.NC_LIBELLENATURECOMPTE = clsPlancomptablenaturecomptemodereglementDTO.NC_LIBELLENATURECOMPTE.ToString();
                    clsObjetEnvoi.OE_A = clsPlancomptablenaturecomptemodereglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPlancomptablenaturecomptemodereglementDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPlancomptablenaturecomptemodereglementWSBLL.pvgAjouter(clsDonnee, clsPlancomptablenaturecomptemodereglement, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptablenaturecomptemodereglements;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> pvgModifier(List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPlancomptablenaturecomptemodereglements = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
                //--TEST CONTRAINTE
                clsPlancomptablenaturecomptemodereglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglementDTO in Objet)
                {
                    Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE = clsPlancomptablenaturecomptemodereglementDTO.NC_CODENATURECOMPTE.ToString();
                    //clsPlancomptablenaturecomptemodereglement.NC_LIBELLENATURECOMPTE = clsPlancomptablenaturecomptemodereglementDTO.NC_LIBELLENATURECOMPTE.ToString();
                    clsObjetEnvoi.OE_A = clsPlancomptablenaturecomptemodereglementDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPlancomptablenaturecomptemodereglementDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPlancomptablenaturecomptemodereglementDTO.NC_CODENATURECOMPTE };
                    clsObjetRetour.SetValue(true, clsPlancomptablenaturecomptemodereglementWSBLL.pvgModifier(clsDonnee, clsPlancomptablenaturecomptemodereglement, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptablenaturecomptemodereglements;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> pvgSupprimer(List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPlancomptablenaturecomptemodereglements = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
                //--TEST CONTRAINTE
                clsPlancomptablenaturecomptemodereglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].NC_CODENATURECOMPTE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPlancomptablenaturecomptemodereglementWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                }
                else
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptablenaturecomptemodereglements;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPlancomptablenaturecomptemodereglements = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
            //    //--TEST CONTRAINTE
            //    clsPlancomptablenaturecomptemodereglements = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPlancomptablenaturecomptemodereglementWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                    clsPlancomptablenaturecomptemodereglement.NC_LIBELLENATURECOMPTE = row["NC_LIBELLENATURECOMPTE"].ToString();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPlancomptablenaturecomptemodereglements;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPlancomptablenaturecomptemodereglements = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
                //--TEST CONTRAINTE
                clsPlancomptablenaturecomptemodereglements = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPlancomptablenaturecomptemodereglements[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPlancomptablenaturecomptemodereglements;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].MR_CODEMODEREGLEMENT};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPlancomptablenaturecomptemodereglementWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                    clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                    clsPlancomptablenaturecomptemodereglement.NC_LIBELLENATURECOMPTE = row["NC_LIBELLENATURECOMPTE"].ToString();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPlancomptablenaturecomptemodereglements;
    }


        
    }
}
