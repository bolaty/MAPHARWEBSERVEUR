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
                    clsCtcontratchequephoto.CH_DATESAISIECHEQUE = row["CH_DATESAISIECHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_IDEXCHEQUE = row["CH_IDEXCHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO = row["CH_NUMSEQUENCEPHOTO"].ToString();
                    clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = row["CH_CHEMINPHOTOCHEQUE"].ToString();
                    clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = row["CH_LIBELLEPHOTOCHEQUE"].ToString();

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
