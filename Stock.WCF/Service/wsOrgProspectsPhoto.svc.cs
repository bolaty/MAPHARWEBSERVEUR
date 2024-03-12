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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOrgProspectsPhoto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOrgProspectsPhoto.svc ou wsOrgProspectsPhoto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOrgProspectsPhoto : IwsOrgProspectsPhoto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsOrgProspectsPhotoWSBLL clsOrgProspectsPhotoWSBLL = new clsOrgProspectsPhotoWSBLL();

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
        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> pvgAjouter(List<HT_Stock.BOJ.clsOrgProspectsPhoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectsPhotos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
                //--TEST CONTRAINTE
                clsOrgProspectsPhotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhotoDTO in Objet)
                {
                    Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.PR_IDTIERS = clsOrgProspectsPhotoDTO.PR_IDTIERS.ToString();
                    clsOrgProspectsPhoto.AG_CODEAGENCE = clsOrgProspectsPhotoDTO.AG_CODEAGENCE.ToString();
                    clsObjetEnvoi.OE_A = clsOrgProspectsPhotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOrgProspectsPhotoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsOrgProspectsPhotoWSBLL.pvgAjouter(clsDonnee, clsOrgProspectsPhoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                }
                else
                {
                    HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectsPhotos;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> pvgModifier(List<HT_Stock.BOJ.clsOrgProspectsPhoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectsPhotos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
                //--TEST CONTRAINTE
                clsOrgProspectsPhotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhotoDTO in Objet)
                {
                    Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.PR_IDTIERS = clsOrgProspectsPhotoDTO.PR_IDTIERS.ToString();
                    clsOrgProspectsPhoto.AG_CODEAGENCE = clsOrgProspectsPhotoDTO.AG_CODEAGENCE.ToString();
                    clsObjetEnvoi.OE_A = clsOrgProspectsPhotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOrgProspectsPhotoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsOrgProspectsPhotoDTO.PR_IDTIERS };
                    clsObjetRetour.SetValue(true, clsOrgProspectsPhotoWSBLL.pvgModifier(clsDonnee, clsOrgProspectsPhoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                }
                else
                {
                    HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectsPhotos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> pvgSupprimer(List<HT_Stock.BOJ.clsOrgProspectsPhoto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectsPhotos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
                //--TEST CONTRAINTE
                clsOrgProspectsPhotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PR_IDTIERS };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsOrgProspectsPhotoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                }
                else
                {
                    HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectsPhotos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsOrgProspectsPhoto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsOrgProspectsPhoto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOrgProspectsPhotos = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
                //--TEST CONTRAINTE
                clsOrgProspectsPhotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
                //+++++++++++DEBUT PHOTO&SIGNATURE
                clsOrgProspectsPhotoWSBLL clsOrgProspectsPhotoWSBLL = new clsOrgProspectsPhotoWSBLL();
                Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhotoAffichage = new Stock.BOJ.clsOrgProspectsPhoto();

                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].PR_IDTIERS };
                clsOrgProspectsPhotoAffichage = clsOrgProspectsPhotoWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                //DataSet = clsOrgProspectsPhotoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            if (clsOrgProspectsPhotoAffichage!=null)
            {
                //foreach (DataRow row in DataSet.Tables[0].Rows)
                //{
                string PR_PHOTOBASE64 = "";
                string PR_SIGNATUREBASE64 = "";
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                if (clsOrgProspectsPhotoAffichage != null)
                {
                    if (clsOrgProspectsPhotoAffichage.PR_PHOTO != null)
                        PR_PHOTOBASE64 = Convert.ToBase64String(clsOrgProspectsPhotoAffichage.PR_PHOTO);
                    if (clsOrgProspectsPhotoAffichage.PR_SIGNATURE != null)
                        PR_SIGNATUREBASE64 = Convert.ToBase64String(clsOrgProspectsPhotoAffichage.PR_SIGNATURE);
                }
                clsOrgProspectsPhoto.PR_PHOTO = PR_PHOTOBASE64;
                clsOrgProspectsPhoto.PR_SIGNATURE = PR_SIGNATUREBASE64;
                //+++++++++++FIN PHOTO&SIGNATURE
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                if (clsOrgProspectsPhotoAffichage.PR_PHOTO != null || clsOrgProspectsPhotoAffichage.PR_SIGNATURE != null)
                {
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                }
                else
                {
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                }
                    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                //}
            }
            else
            {
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
            clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
            clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsOrgProspectsPhotos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOrgProspectsPhoto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsOrgProspectsPhotos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
        //    //--TEST CONTRAINTE
        //    clsOrgProspectsPhotos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOrgProspectsPhotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOrgProspectsPhotos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOrgProspectsPhotoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                    clsOrgProspectsPhoto.PR_IDTIERS = row["PR_IDTIERS"].ToString();
                    clsOrgProspectsPhoto.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
            clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
            clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsOrgProspectsPhotos;
    }


        
    }
}
