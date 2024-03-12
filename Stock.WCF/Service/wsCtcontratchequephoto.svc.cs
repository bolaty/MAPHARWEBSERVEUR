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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtcontratchequephoto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtcontratchequephoto.svc ou wsCtcontratchequephoto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtcontratchequephoto : IwsCtcontratchequephoto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtcontratchequephotoWSBLL clsCtcontratchequephotoWSBLL = new clsCtcontratchequephotoWSBLL();

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
        public List<HT_Stock.BOJ.clsCtcontratchequephoto> pvgAjouter(List<HT_Stock.BOJ.clsCtcontratchequephoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotoss = new List<BOJ.clsCtcontratchequephoto>();

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratchequephotos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
                //--TEST CONTRAINTE
                clsCtcontratchequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephotoDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.AG_CODEAGENCE = clsCtcontratchequephotoDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratchequephoto.CH_DATESAISIECHEQUE =DateTime.Parse(clsCtcontratchequephotoDTO.CH_DATESAISIECHEQUE.ToString());
                    clsCtcontratchequephoto.CH_IDEXCHEQUE = clsCtcontratchequephotoDTO.CH_IDEXCHEQUE.ToString();
                    clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO = clsCtcontratchequephotoDTO.CH_NUMSEQUENCEPHOTO.ToString();
                    clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = clsCtcontratchequephotoDTO.CH_CHEMINPHOTOCHEQUE.ToString();
                    clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = clsCtcontratchequephotoDTO.CH_LIBELLEPHOTOCHEQUE.ToString();
                    clsObjetEnvoi.OE_A = clsCtcontratchequephotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratchequephotoDTO.clsObjetEnvoi.OE_Y;
                    clsCtcontratchequephotoss.Add(clsCtcontratchequephoto);

                }

                bool vlpTestRepertoire = true;
                clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                vlpTestRepertoire= clsParametreWSBLL.pvgTestCheminRepertoirePhotoSignature(clsDonnee, "PHOT2");
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                if (!vlpTestRepertoire)
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Le dossier n'est pas paramètré ou est inexistant !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                    return clsCtcontratchequephotos;
                }



                clsObjetRetour.SetValue(true, clsCtcontratchequephotoWSBLL.pvgAjouterListeSansSuppression(clsDonnee, clsCtcontratchequephotoss, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratchequephotos;
        }






        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratchequephoto> pvgModifier(List<HT_Stock.BOJ.clsCtcontratchequephoto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratchequephotos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
                //--TEST CONTRAINTE
                clsCtcontratchequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephotoDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.AG_CODEAGENCE = clsCtcontratchequephotoDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratchequephoto.CH_DATESAISIECHEQUE = DateTime.Parse(clsCtcontratchequephotoDTO.CH_DATESAISIECHEQUE.ToString());
                    clsCtcontratchequephoto.CH_IDEXCHEQUE = clsCtcontratchequephotoDTO.CH_IDEXCHEQUE.ToString();
                    clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO = clsCtcontratchequephotoDTO.CH_NUMSEQUENCEPHOTO.ToString();
                    clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = clsCtcontratchequephotoDTO.CH_CHEMINPHOTOCHEQUE.ToString();
                    clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = clsCtcontratchequephotoDTO.CH_LIBELLEPHOTOCHEQUE.ToString();
                    clsObjetEnvoi.OE_A = clsCtcontratchequephotoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratchequephotoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontratchequephotoDTO.CH_NUMSEQUENCEPHOTO };
                    clsObjetRetour.SetValue(true, clsCtcontratchequephotoWSBLL.pvgModifier(clsDonnee, clsCtcontratchequephoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratchequephotos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratchequephoto> pvgSupprimer(List<HT_Stock.BOJ.clsCtcontratchequephoto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratchequephotos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
                //--TEST CONTRAINTE
                clsCtcontratchequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE,Objet[0].CH_DATESAISIECHEQUE,Objet[0].CH_IDEXCHEQUE, Objet[0].CH_NUMSEQUENCEPHOTO };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtcontratchequephotoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratchequephotos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtcontratchequephoto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtcontratchequephoto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratchequephotos = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
                //--TEST CONTRAINTE
                clsCtcontratchequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].CH_DATESAISIECHEQUE, Objet[0].CH_IDEXCHEQUE,Objet[0].CA_CODECONTRAT,Objet[0].OP_CODEOPERATEUR,Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratchequephotoWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtcontratchequephoto.CH_DATESAISIECHEQUE = DateTime.Parse(row["CH_DATESAISIECHEQUE"].ToString()).ToShortDateString();
                    clsCtcontratchequephoto.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO = row["CH_NUMSEQUENCEPHOTO"].ToString();
                    clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = row["CH_CHEMINPHOTOCHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = row["CH_LIBELLEPHOTOCHEQUE"].ToString();

                 clsCtcontratchequephoto.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                 clsCtcontratchequephoto.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();

                 clsCtcontratchequephoto.CH_DATEEMISSIONCHEQUE =DateTime.Parse( row["CH_DATEEMISSIONCHEQUE"].ToString()).ToShortDateString();
                 clsCtcontratchequephoto.CH_DATEFINCOUVERTURE =DateTime.Parse(  row["CH_DATEFINCOUVERTURE"].ToString()).ToShortDateString();
                 clsCtcontratchequephoto.CH_DATEDEBUTCOUVERTURE = DateTime.Parse(  row["CH_DATEDEBUTCOUVERTURE"].ToString()).ToShortDateString();
                 clsCtcontratchequephoto.AB_LIBELLE = row["AB_LIBELLE"].ToString();
                 clsCtcontratchequephoto.CH_NOMTIRE = row["CH_NOMTIRE"].ToString();
                 clsCtcontratchequephoto.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                 clsCtcontratchequephoto.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                 clsCtcontratchequephoto.CH_VALEURCHEQUE =double.Parse( row["CH_VALEURCHEQUE"].ToString());
                 clsCtcontratchequephoto.BQ_RAISONSOCIAL = row["BQ_RAISONSOCIAL"].ToString();
                 clsCtcontratchequephoto.CH_NOMTIREUR = row["CH_NOMTIREUR"].ToString();
                 clsCtcontratchequephoto.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                 clsCtcontratchequephoto.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                 clsCtcontratchequephoto.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                 clsCtcontratchequephoto.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                 clsCtcontratchequephoto.TI_NUMEROASSUREUR = row["TI_NUMEROASSUREUR"].ToString();

                clsCtcontratchequephoto.AB_LIBELLEASSUEUR = row["AB_LIBELLEASSUEUR"].ToString();
                //clsCtcontratchequephoto.BQ_CODEBANQUEASSUREUR = row["BQ_CODEBANQUEASSUREUR"].ToString();
                clsCtcontratchequephoto.BQ_RAISONSOCIALASSUREUR = row["BQ_RAISONSOCIALASSUREUR"].ToString();
                //clsCtcontratchequephoto.BQ_SIGLEASSUREUR = row["BQ_SIGLEASSUREUR"].ToString();

                        clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratchequephotos;
            }



            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtcontratchequephoto> pvgChargerDansDataSetPhotoAfficher(List<HT_Stock.BOJ.clsCtcontratchequephoto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratchequephotos = TestChampObligatoireListeReglementCheque(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
                //--TEST CONTRAINTE
                clsCtcontratchequephotos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
            }

           // "@AG_CODEAGENCE",  "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION"
            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].CA_CODECONTRAT, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratchequephotoWSBLL.pvgChargerDansDataSetPhotoAfficher(clsDonnee, clsObjetEnvoi);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtcontratchequephoto.CH_DATESAISIECHEQUE = row["CH_DATESAISIECHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO = row["CH_NUMSEQUENCEPHOTO"].ToString();
                    clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = row["CH_CHEMINPHOTOCHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = row["CH_LIBELLEPHOTOCHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
                    clsCtcontratchequephoto.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();


                    clsCtcontratchequephoto.AB_LIBELLE = row["AB_LIBELLE"].ToString();
                    clsCtcontratchequephoto.BQ_RAISONSOCIAL = row["BQ_RAISONSOCIAL"].ToString();

                    clsCtcontratchequephoto.AB_LIBELLEASSUEUR = row["AB_LIBELLEASSUEUR"].ToString();
                    clsCtcontratchequephoto.BQ_RAISONSOCIALASSUREUR = row["BQ_RAISONSOCIALASSUREUR"].ToString();

                    clsCtcontratchequephoto.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();



                    clsCtcontratchequephoto.CH_VALEURCHEQUE =double.Parse( row["CH_VALEURCHEQUE"].ToString());
                    clsCtcontratchequephoto.CH_NOMTIRE = row["CH_NOMTIRE"].ToString();
                    clsCtcontratchequephoto.CH_NOMTIREUR = row["CH_NOMTIREUR"].ToString();
                    clsCtcontratchequephoto.CH_DATEEMISSIONCHEQUE = row["CH_DATEEMISSIONCHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_TYPECHEQUE = row["CH_TYPECHEQUE"].ToString();
                    clsCtcontratchequephoto.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                    clsCtcontratchequephoto.CA_DATEEFFET = row["CA_DATEEFFET"].ToString();
                    clsCtcontratchequephoto.CA_DATEECHEANCE = row["CA_DATEECHEANCE"].ToString();
                    clsCtcontratchequephoto.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                    clsCtcontratchequephoto.CH_DATEDEBUTCOUVERTURE = row["CH_DATEDEBUTCOUVERTURE"].ToString();
                    clsCtcontratchequephoto.CH_DATEFINCOUVERTURE = row["CH_DATEFINCOUVERTURE"].ToString();
                    clsCtcontratchequephoto.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                    clsCtcontratchequephoto.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                    clsCtcontratchequephoto.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                    clsCtcontratchequephoto.TI_NUMEROASSUREUR = row["TI_NUMEROASSUREUR"].ToString();

                        //private string _TI_NUMTIERS = "";
                        //private string _AB_LIBELLE = "";
                        //private string _BQ_RAISONSOCIAL = "";
                        //private string _TI_DENOMINATION = "";
                        //private double _CH_VALEURCHEQUE = 0;
                        //private string _CH_NOMTIRE = "";
                        //private string _CH_NOMTIREUR = "";
                        //private string _CH_DATEEMISSIONCHEQUE = "";
                        //private string _CH_TYPECHEQUE = "";
                        //private string _CA_NUMPOLICE = "";
                        //private string _CA_DATEEFFET = "";
                        //private string _CA_DATEECHEANCE = "";
                        //private string _CB_LIBELLEBRANCHE = "";
                        //private string _CH_DATEDEBUTCOUVERTURE = "";
                        //private string _CH_DATEFINCOUVERTURE = "";
                        //private string _RQ_CODERISQUE = "";
                        //private string _RQ_LIBELLERISQUE = "";
                        //private string _OP_NOMPRENOM = "";


                        clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratchequephotos;
            }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratchequephoto> pvgChargerDansDataSetContratCheque(List<HT_Stock.BOJ.clsCtcontratchequephoto> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCtcontratchequephotos = TestChampObligatoireListeEtatCheque(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
            //--TEST CONTRAINTE
            clsCtcontratchequephotos = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
        }

        // "@AG_CODEAGENCE",  "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION"
        clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].CA_CODECONTRAT, Objet[0].OP_CODEOPERATEUR,Objet[0].DATEDEBUT,Objet[0].DATEFIN,Objet[0].RQ_CODERISQUE,Objet[0].TA_CODETYPEAFFAIRES, Objet[0].TYPEOPERATION };
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsCtcontratchequephotoWSBLL.pvgChargerDansDataSetContratCheque(clsDonnee, clsObjetEnvoi);
        clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                clsCtcontratchequephoto.CH_DATESAISIECHEQUE = row["CH_DATESAISIECHEQUE"].ToString();
                clsCtcontratchequephoto.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO = row["CH_NUMSEQUENCEPHOTO"].ToString();
                clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = row["CH_CHEMINPHOTOCHEQUE"].ToString();
                clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = row["CH_LIBELLEPHOTOCHEQUE"].ToString();
                clsCtcontratchequephoto.CH_REFCHEQUE = row["CH_REFCHEQUE"].ToString();
                clsCtcontratchequephoto.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                clsCtcontratchequephoto.AB_LIBELLE = row["AB_LIBELLE"].ToString();
                clsCtcontratchequephoto.BQ_RAISONSOCIAL = row["BQ_RAISONSOCIAL"].ToString();
                clsCtcontratchequephoto.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                clsCtcontratchequephoto.CH_VALEURCHEQUE =double.Parse( row["CH_VALEURCHEQUE"].ToString());
                clsCtcontratchequephoto.CH_NOMTIRE = row["CH_NOMTIRE"].ToString();
                clsCtcontratchequephoto.CH_NOMTIREUR = row["CH_NOMTIREUR"].ToString();
                clsCtcontratchequephoto.CH_DATEEMISSIONCHEQUE = row["CH_DATEEMISSIONCHEQUE"].ToString();
                clsCtcontratchequephoto.CH_TYPECHEQUE = row["CH_TYPECHEQUE"].ToString();
                clsCtcontratchequephoto.CA_NUMPOLICE = row["CA_NUMPOLICE"].ToString();
                clsCtcontratchequephoto.CA_DATEEFFET = row["CA_DATEEFFET"].ToString();
                clsCtcontratchequephoto.CA_DATEECHEANCE = row["CA_DATEECHEANCE"].ToString();
                clsCtcontratchequephoto.CB_LIBELLEBRANCHE = row["CB_LIBELLEBRANCHE"].ToString();
                clsCtcontratchequephoto.CH_DATEDEBUTCOUVERTURE = row["CH_DATEDEBUTCOUVERTURE"].ToString();
                clsCtcontratchequephoto.CH_DATEFINCOUVERTURE = row["CH_DATEFINCOUVERTURE"].ToString();
                clsCtcontratchequephoto.RQ_CODERISQUE = row["RQ_CODERISQUE"].ToString();
                clsCtcontratchequephoto.RQ_LIBELLERISQUE = row["RQ_LIBELLERISQUE"].ToString();
                clsCtcontratchequephoto.OP_NOMPRENOM = row["OP_NOMPRENOM"].ToString();
                clsCtcontratchequephoto.BQ_SIGLE = row["BQ_SIGLE"].ToString();
                clsCtcontratchequephoto.TI_NUMTIERSASSUREUR = row["TI_NUMTIERSASSUREUR"].ToString();
                clsCtcontratchequephoto.TI_DENOMINATIONASSUREUR = row["TI_DENOMINATIONASSUREUR"].ToString();
                    
                        
                    //private string _TI_NUMTIERS = "";
                    //private string _AB_LIBELLE = "";
                    //private string _BQ_RAISONSOCIAL = "";
                    //private string _TI_DENOMINATION = "";
                    //private double _CH_VALEURCHEQUE = 0;
                    //private string _CH_NOMTIRE = "";
                    //private string _CH_NOMTIREUR = "";
                    //private string _CH_DATEEMISSIONCHEQUE = "";
                    //private string _CH_TYPECHEQUE = "";
                    //private string _CA_NUMPOLICE = "";
                    //private string _CA_DATEEFFET = "";
                    //private string _CA_DATEECHEANCE = "";
                    //private string _CB_LIBELLEBRANCHE = "";
                    //private string _CH_DATEDEBUTCOUVERTURE = "";
                    //private string _CH_DATEFINCOUVERTURE = "";
                    //private string _RQ_CODERISQUE = "";
                    //private string _RQ_LIBELLERISQUE = "";
                    //private string _OP_NOMPRENOM = "";


                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
        }
        else
        {
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
        clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
        clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
        clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
        clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
        clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
        clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontratchequephotos;
        }




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratchequephoto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtcontratchequephoto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtcontratchequephotos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
        //    //--TEST CONTRAINTE
        //    clsCtcontratchequephotos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratchequephotos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratchequephotos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratchequephotoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                    clsCtcontratchequephoto.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = row["CH_CHEMINPHOTOCHEQUE"].ToString();
                    clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontratchequephotos;
    }


        
    }
}
