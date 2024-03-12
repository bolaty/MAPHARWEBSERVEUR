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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhatiersphoto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhatiersphoto.svc ou wsPhatiersphoto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhatiersphoto : IwsPhatiersphoto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhatiersphotoWSBLL clsPhatiersphotoWSBLL = new clsPhatiersphotoWSBLL();

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
        public List<HT_Stock.BOJ.clsPhatiersphoto> pvgAjouter(List<HT_Stock.BOJ.clsPhatiersphoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatiersphotos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
                //--TEST CONTRAINTE
                clsPhatiersphotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphotoDTO in Objet)
                {
                    Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.TI_IDTIERS = clsPhatiersphotoDTO.TI_IDTIERS.ToString();
                    clsPhatiersphoto.AG_CODEAGENCE = clsPhatiersphotoDTO.AG_CODEAGENCE.ToString();
                    clsObjetEnvoi.OE_A = clsPhatiersphotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhatiersphotoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhatiersphotoWSBLL.pvgAjouter(clsDonnee, clsPhatiersphoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhatiersphotos.Add(clsPhatiersphoto);
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhatiersphotos.Add(clsPhatiersphoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                clsPhatiersphotos.Add(clsPhatiersphoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                clsPhatiersphotos.Add(clsPhatiersphoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatiersphotos;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiersphoto> pvgModifier(List<HT_Stock.BOJ.clsPhatiersphoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatiersphotos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
                //--TEST CONTRAINTE
                clsPhatiersphotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphotoDTO in Objet)
                {
                    Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.TI_IDTIERS = clsPhatiersphotoDTO.TI_IDTIERS.ToString();
                    clsPhatiersphoto.AG_CODEAGENCE = clsPhatiersphotoDTO.AG_CODEAGENCE.ToString();
                    clsObjetEnvoi.OE_A = clsPhatiersphotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhatiersphotoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhatiersphotoDTO.TI_IDTIERS };
                    clsObjetRetour.SetValue(true, clsPhatiersphotoWSBLL.pvgModifier(clsDonnee, clsPhatiersphoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhatiersphotos.Add(clsPhatiersphoto);
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhatiersphotos.Add(clsPhatiersphoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                clsPhatiersphotos.Add(clsPhatiersphoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                clsPhatiersphotos.Add(clsPhatiersphoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatiersphotos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiersphoto> pvgSupprimer(List<HT_Stock.BOJ.clsPhatiersphoto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatiersphotos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
                //--TEST CONTRAINTE
                clsPhatiersphotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TI_IDTIERS };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhatiersphotoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhatiersphotos.Add(clsPhatiersphoto);
                }
                else
                {
                    HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhatiersphotos.Add(clsPhatiersphoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                clsPhatiersphotos.Add(clsPhatiersphoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
                clsPhatiersphotos.Add(clsPhatiersphoto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatiersphotos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhatiersphoto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhatiersphoto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhatiersphotos = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
                //--TEST CONTRAINTE
                clsPhatiersphotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
                //+++++++++++DEBUT PHOTO&SIGNATURE
                clsPhatiersphotoWSBLL clsPhatiersphotoWSBLL = new clsPhatiersphotoWSBLL();
                Stock.BOJ.clsPhatiersphoto clsPhatiersphotoAffichage = new Stock.BOJ.clsPhatiersphoto();

                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].TI_IDTIERS };
                clsPhatiersphotoAffichage = clsPhatiersphotoWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                //DataSet = clsPhatiersphotoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            if (clsPhatiersphotoAffichage!=null)
            {
                //foreach (DataRow row in DataSet.Tables[0].Rows)
                //{
                string TI_PHOTOBASE64 = "";
                string TI_SIGNATUREBASE64 = "";
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                if (clsPhatiersphotoAffichage != null)
                {
                    if (clsPhatiersphotoAffichage.TI_PHOTO != null)
                        TI_PHOTOBASE64 = Convert.ToBase64String(clsPhatiersphotoAffichage.TI_PHOTO);
                    if (clsPhatiersphotoAffichage.TI_SIGNATURE != null)
                        TI_SIGNATUREBASE64 = Convert.ToBase64String(clsPhatiersphotoAffichage.TI_SIGNATURE);
                }
                clsPhatiersphoto.TI_PHOTO = TI_PHOTOBASE64;
                clsPhatiersphoto.TI_SIGNATURE = TI_SIGNATUREBASE64;
                //+++++++++++FIN PHOTO&SIGNATURE
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                if (clsPhatiersphotoAffichage.TI_PHOTO != null || clsPhatiersphotoAffichage.TI_SIGNATURE != null)
                {
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                }
                else
                {
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                }
                    clsPhatiersphotos.Add(clsPhatiersphoto);
                //}
            }
            else
            {
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhatiersphotos.Add(clsPhatiersphoto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
            clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiersphoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            clsPhatiersphotos.Add(clsPhatiersphoto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
            clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiersphoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            clsPhatiersphotos.Add(clsPhatiersphoto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhatiersphotos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhatiersphoto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhatiersphoto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhatiersphotos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
        //    //--TEST CONTRAINTE
        //    clsPhatiersphotos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhatiersphotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhatiersphotos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhatiersphotoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                    clsPhatiersphoto.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                    clsPhatiersphoto.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhatiersphotos.Add(clsPhatiersphoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhatiersphotos.Add(clsPhatiersphoto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
            clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiersphoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            clsPhatiersphotos.Add(clsPhatiersphoto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
            clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhatiersphoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            clsPhatiersphotos.Add(clsPhatiersphoto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhatiersphotos;
    }


        
    }
}
