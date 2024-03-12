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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtsinistrechequephoto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtsinistrechequephoto.svc ou wsCtsinistrechequephoto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtsinistrechequephoto : IwsCtsinistrechequephoto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtsinistrechequephotoWSBLL clsCtsinistrechequephotoWSBLL = new clsCtsinistrechequephotoWSBLL();

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
        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> pvgAjouter(List<HT_Stock.BOJ.clsCtsinistrechequephoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotoss = new List<BOJ.clsCtsinistrechequephoto>();

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrechequephotos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
                //--TEST CONTRAINTE
                clsCtsinistrechequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephotoDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.AG_CODEAGENCE = clsCtsinistrechequephotoDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistrechequephoto.CH_DATESAISIECHEQUE =DateTime.Parse(clsCtsinistrechequephotoDTO.CH_DATESAISIECHEQUE.ToString());
                    clsCtsinistrechequephoto.CH_IDEXCHEQUE = clsCtsinistrechequephotoDTO.CH_IDEXCHEQUE.ToString();
                    clsCtsinistrechequephoto.CH_NUMSEQUENCEPHOTO = clsCtsinistrechequephotoDTO.CH_NUMSEQUENCEPHOTO.ToString();
                    clsCtsinistrechequephoto.CH_CHEMINPHOTOCHEQUE = clsCtsinistrechequephotoDTO.CH_CHEMINPHOTOCHEQUE.ToString();
                    clsCtsinistrechequephoto.CH_LIBELLEPHOTOCHEQUE = clsCtsinistrechequephotoDTO.CH_LIBELLEPHOTOCHEQUE.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinistrechequephotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistrechequephotoDTO.clsObjetEnvoi.OE_Y;
                    clsCtsinistrechequephotoss.Add(clsCtsinistrechequephoto);

                }


                bool vlpTestRepertoire = true;
                clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                vlpTestRepertoire = clsParametreWSBLL.pvgTestCheminRepertoirePhotoSignature(clsDonnee, "PHOT2");
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                if (!vlpTestRepertoire)
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Le dossier n'est pas paramètré ou est inexistant !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                    return clsCtsinistrechequephotos;
                }

                clsObjetRetour.SetValue(true, clsCtsinistrechequephotoWSBLL.pvgAjouterListeSansSuppression(clsDonnee, clsCtsinistrechequephotoss, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrechequephotos;
        }






        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> pvgModifier(List<HT_Stock.BOJ.clsCtsinistrechequephoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrechequephotos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
                //--TEST CONTRAINTE
                clsCtsinistrechequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephotoDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.AG_CODEAGENCE = clsCtsinistrechequephotoDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistrechequephoto.CH_DATESAISIECHEQUE = DateTime.Parse(clsCtsinistrechequephotoDTO.CH_DATESAISIECHEQUE.ToString());
                    clsCtsinistrechequephoto.CH_IDEXCHEQUE = clsCtsinistrechequephotoDTO.CH_IDEXCHEQUE.ToString();
                    clsCtsinistrechequephoto.CH_NUMSEQUENCEPHOTO = clsCtsinistrechequephotoDTO.CH_NUMSEQUENCEPHOTO.ToString();
                    clsCtsinistrechequephoto.CH_CHEMINPHOTOCHEQUE = clsCtsinistrechequephotoDTO.CH_CHEMINPHOTOCHEQUE.ToString();
                    clsCtsinistrechequephoto.CH_LIBELLEPHOTOCHEQUE = clsCtsinistrechequephotoDTO.CH_LIBELLEPHOTOCHEQUE.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinistrechequephotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistrechequephotoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinistrechequephotoDTO.CH_NUMSEQUENCEPHOTO };
                    clsObjetRetour.SetValue(true, clsCtsinistrechequephotoWSBLL.pvgModifier(clsDonnee, clsCtsinistrechequephoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrechequephotos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> pvgSupprimer(List<HT_Stock.BOJ.clsCtsinistrechequephoto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrechequephotos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
                //--TEST CONTRAINTE
                clsCtsinistrechequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE,Objet[0].CH_DATESAISIECHEQUE,Objet[0].CH_IDEXCHEQUE, Objet[0].CH_NUMSEQUENCEPHOTO };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinistrechequephotoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrechequephotos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtsinistrechequephoto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtsinistrechequephoto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistrechequephotos = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
                //--TEST CONTRAINTE
                clsCtsinistrechequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].CH_DATESAISIECHEQUE, Objet[0].CH_IDEXCHEQUE,Objet[0].SI_CODESINISTRE,Objet[0].OP_CODEOPERATEUR,Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistrechequephotoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtsinistrechequephoto.CH_DATESAISIECHEQUE = row["CH_DATESAISIECHEQUE"].ToString();
                    clsCtsinistrechequephoto.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                    clsCtsinistrechequephoto.CH_NUMSEQUENCEPHOTO = row["CH_NUMSEQUENCEPHOTO"].ToString();
                    clsCtsinistrechequephoto.CH_CHEMINPHOTOCHEQUE = row["CH_CHEMINPHOTOCHEQUE"].ToString();
                    clsCtsinistrechequephoto.CH_LIBELLEPHOTOCHEQUE = row["CH_LIBELLEPHOTOCHEQUE"].ToString();

                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistrechequephotos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtsinistrechequephoto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtsinistrechequephotos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
        //    //--TEST CONTRAINTE
        //    clsCtsinistrechequephotos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistrechequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistrechequephotos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistrechequephotoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                    clsCtsinistrechequephoto.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtsinistrechequephoto.CH_CHEMINPHOTOCHEQUE = row["CH_CHEMINPHOTOCHEQUE"].ToString();
                    clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtsinistrechequephotos;
    }


        
    }
}
