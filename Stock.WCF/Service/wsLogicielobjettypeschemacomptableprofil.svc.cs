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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsLogicielobjettypeschemacomptableprofil" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsLogicielobjettypeschemacomptableprofil.svc ou wsLogicielobjettypeschemacomptableprofil.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsLogicielobjettypeschemacomptableprofil : IwsLogicielobjettypeschemacomptableprofil
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsLogicielobjettypeschemacomptableprofilWSBLL clsLogicielobjettypeschemacomptableprofilWSBLL = new clsLogicielobjettypeschemacomptableprofilWSBLL();

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
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> pvgAjouter(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableprofils = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableprofils = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofilDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL = clsLogicielobjettypeschemacomptableprofilDTO.PO_CODEPROFIL.ToString();
                    clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableprofilDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableprofilDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableprofilWSBLL.pvgAjouter(clsDonnee, clsLogicielobjettypeschemacomptableprofil, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableprofils;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> pvgAjouterdroit(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableprofils = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableprofils = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                List<Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofilAjout=new List<BOJ.clsLogicielobjettypeschemacomptableprofil>();
                List<Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofilSuppression = new List<BOJ.clsLogicielobjettypeschemacomptableprofil>();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofilDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();

                    clsLogicielobjettypeschemacomptableprofil.AG_CODEAGENCE = clsLogicielobjettypeschemacomptableprofilDTO.AG_CODEAGENCE;
                    clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL = clsLogicielobjettypeschemacomptableprofilDTO.PO_CODEPROFIL;
                    clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION = clsLogicielobjettypeschemacomptableprofilDTO.NO_CODENATUREOPERATION;
                    clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilDTO.FO_CODEFAMILLEOPERATION;
                    clsLogicielobjettypeschemacomptableprofil.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilDTO.NF_CODENATUREFAMILLEOPERATION;

                    clsLogicielobjettypeschemacomptableprofil.LB_ACTIF = "O"; //vppGrille.GetDataRow(vppIndex)["TC_CODETYPETIERS"].ToString();
                    clsLogicielobjettypeschemacomptableprofil.COCHER = clsLogicielobjettypeschemacomptableprofilDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableprofilDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableprofilDTO.clsObjetEnvoi.OE_Y;
                    //@AG_CODEAGENCE, @PO_CODEPROFIL, '', @FO_CODEFAMILLEOPERATION, '' ,@NF_CODENATUREFAMILLEOPERATION, @CODECRYPTAGE, 2
                    clsObjetEnvoi.OE_PARAM = new string[] {clsLogicielobjettypeschemacomptableprofilDTO.AG_CODEAGENCE, clsLogicielobjettypeschemacomptableprofilDTO.PO_CODEPROFIL, clsLogicielobjettypeschemacomptableprofilDTO.FO_CODEFAMILLEOPERATION, clsLogicielobjettypeschemacomptableprofilDTO.NF_CODENATUREFAMILLEOPERATION };
                    clsLogicielobjettypeschemacomptableprofilAjout.Add(clsLogicielobjettypeschemacomptableprofil);

                }
              
                List<Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofilss = new List<BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableprofilWSBLL.pvgAjouterListe(clsDonnee, clsLogicielobjettypeschemacomptableprofilAjout, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableprofils;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> pvgModifier(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableprofils = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableprofils = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofilDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL = clsLogicielobjettypeschemacomptableprofilDTO.PO_CODEPROFIL.ToString();
                    clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableprofilDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableprofilDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjettypeschemacomptableprofilDTO.PO_CODEPROFIL };
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableprofilWSBLL.pvgModifier(clsDonnee, clsLogicielobjettypeschemacomptableprofil, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableprofils;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> pvgSupprimer(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableprofils = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableprofils = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PO_CODEPROFIL };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableprofilWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableprofils;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableprofils = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableprofils = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].PO_CODEPROFIL };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjettypeschemacomptableprofilWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsLogicielobjettypeschemacomptableprofil.COCHER = row["COCHER"].ToString();
                    clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableprofils;
            }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> pvgChargerDansDataSetOperateurDroit(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsLogicielobjettypeschemacomptableprofils = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
            //--TEST CONTRAINTE
            clsLogicielobjettypeschemacomptableprofils = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
        }

           // "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION", "@PO_CODEPROFIL"
        clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE, Objet[0].NF_CODENATUREFAMILLEOPERATION, Objet[0].FO_CODEFAMILLEOPERATION, Objet[0].PO_CODEPROFIL };
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsLogicielobjettypeschemacomptableprofilWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
        clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableprofil.FO_LIBELLEFAMILLEOPERATION = row["FO_LIBELLEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableprofil.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                clsLogicielobjettypeschemacomptableprofil.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NO_SENS = row["NO_SENS"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NO_PREFIXECOMPTE = row["NO_PREFIXECOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NO_REFPIECE = row["NO_REFPIECE"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableprofil.COCHER = row["COCHER"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NO_ABREVIATION = row["NO_ABREVIATION"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NO_MONTANT = row["NO_MONTANT"].ToString();
                clsLogicielobjettypeschemacomptableprofil.NO_NUMEROORDRE = row["NO_NUMEROORDRE"].ToString();



                        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }
        }
        else
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
        clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
        clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeschemacomptableprofils;
        }







        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsLogicielobjettypeschemacomptableprofils = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
        //    //--TEST CONTRAINTE
        //    clsLogicielobjettypeschemacomptableprofils = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeschemacomptableprofils[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofils;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjettypeschemacomptableprofilWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                    clsLogicielobjettypeschemacomptableprofil.PO_CODEPROFIL = row["PO_CODEPROFIL"].ToString();
                    clsLogicielobjettypeschemacomptableprofil.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeschemacomptableprofils;
    }


        
    }
}
