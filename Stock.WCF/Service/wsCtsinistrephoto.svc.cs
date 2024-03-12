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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtsinistrephoto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtsinistrephoto.svc ou wsCtsinistrephoto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtsinistrephoto : IwsCtsinistrephoto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtsinistrephotoWSBLL clsCtsinistrephotoWSBLL = new clsCtsinistrephotoWSBLL();

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
        public List<HT_Stock.BOJ.clsCtsinistrephoto> pvgAjouter(List<HT_Stock.BOJ.clsCtsinistrephoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrephotos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
                //--TEST CONTRAINTE
                clsCtsinistrephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
               List<Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotosBOJ = new List<Stock.BOJ.clsCtsinistrephoto>();
                foreach (HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephotoDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.SI_CODESINISTRE = clsCtsinistrephotoDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO = clsCtsinistrephotoDTO.SI_NUMSEQUENCEPHOTO.ToString();
                    clsCtsinistrephoto.SI_CHEMINPHOTO = clsCtsinistrephotoDTO.SI_CHEMINPHOTO.ToString();
                    clsCtsinistrephoto.SI_LIBELLEPHOTO = clsCtsinistrephotoDTO.SI_LIBELLEPHOTO.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinistrephotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistrephotoDTO.clsObjetEnvoi.OE_Y;
                    clsCtsinistrephotosBOJ.Add(clsCtsinistrephoto);
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinistrephotoDTO.SI_CODESINISTRE.ToString() };
                    //clsObjetRetour.SetValue(true, clsCtsinistrephotoWSBLL.pvgAjouter(clsDonnee, clsCtsinistrephoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }

                bool vlpTestRepertoire = true;
                clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                vlpTestRepertoire = clsParametreWSBLL.pvgTestCheminRepertoirePhotoSignature(clsDonnee, "PHOT3");
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                if (!vlpTestRepertoire)
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Le dossier n'est pas paramètré ou est inexistant !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                    return clsCtsinistrephotos;
                }

                clsObjetRetour.SetValue(true, clsCtsinistrephotoWSBLL.pvgAjouterListe(clsDonnee, clsCtsinistrephotosBOJ, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrephotos;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrephoto> pvgModifier(List<HT_Stock.BOJ.clsCtsinistrephoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrephotos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
                //--TEST CONTRAINTE
                clsCtsinistrephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephotoDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.SI_CODESINISTRE = clsCtsinistrephotoDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO = clsCtsinistrephotoDTO.SI_NUMSEQUENCEPHOTO.ToString();
                    clsCtsinistrephoto.SI_CHEMINPHOTO = clsCtsinistrephotoDTO.SI_CHEMINPHOTO.ToString();
                    clsCtsinistrephoto.SI_LIBELLEPHOTO = clsCtsinistrephotoDTO.SI_LIBELLEPHOTO.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinistrephotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistrephotoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinistrephotoDTO.SI_CODESINISTRE };
                    clsObjetRetour.SetValue(true, clsCtsinistrephotoWSBLL.pvgModifier(clsDonnee, clsCtsinistrephoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrephotos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrephoto> pvgSupprimer(List<HT_Stock.BOJ.clsCtsinistrephoto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrephotos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
                //--TEST CONTRAINTE
                clsCtsinistrephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SI_CODESINISTRE,Objet[0].SI_NUMSEQUENCEPHOTO };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinistrephotoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrephotos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtsinistrephoto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtsinistrephoto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrephotos = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
                //--TEST CONTRAINTE
                clsCtsinistrephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].SI_CODESINISTRE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistrephotoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                    clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO = row["SI_NUMSEQUENCEPHOTO"].ToString();
                    clsCtsinistrephoto.SI_CHEMINPHOTO = row["SI_CHEMINPHOTO"].ToString();
                    clsCtsinistrephoto.SI_LIBELLEPHOTO = row["SI_LIBELLEPHOTO"].ToString();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
            clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
            clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrephotos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrephoto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtsinistrephoto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtsinistrephotos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
        //    //--TEST CONTRAINTE
        //    clsCtsinistrephotos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistrephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrephotos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistrephotoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                    clsCtsinistrephoto.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                    clsCtsinistrephoto.SI_LIBELLEPHOTO = row["SI_LIBELLEPHOTO"].ToString();
                    clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistrephotos.Add(clsCtsinistrephoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
            clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            clsCtsinistrephotos.Add(clsCtsinistrephoto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
            clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            clsCtsinistrephotos.Add(clsCtsinistrephoto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtsinistrephotos;
    }


        
    }
}
