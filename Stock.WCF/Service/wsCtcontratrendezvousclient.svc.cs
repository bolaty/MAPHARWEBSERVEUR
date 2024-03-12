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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtcontratrendezvousclient" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtcontratrendezvousclient.svc ou wsCtcontratrendezvousclient.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtcontratrendezvousclient : IwsCtcontratrendezvousclient
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtcontratrendezvousclientWSBLL clsCtcontratrendezvousclientWSBLL = new clsCtcontratrendezvousclientWSBLL();

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
        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> pvgAjouter(List<HT_Stock.BOJ.clsCtcontratrendezvousclient> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratrendezvousclients = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
                //--TEST CONTRAINTE
                clsCtcontratrendezvousclients = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclientDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.AG_CODEAGENCE = clsCtcontratrendezvousclientDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratrendezvousclient.EN_CODEENTREPOT = clsCtcontratrendezvousclientDTO.EN_CODEENTREPOT.ToString();
                    clsCtcontratrendezvousclient.RD_INDEXRENDEZVOUS = clsCtcontratrendezvousclientDTO.RD_INDEXRENDEZVOUS.ToString();
                    clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS =DateTime.Parse(clsCtcontratrendezvousclientDTO.RD_DATESAISIERENDEZVOUS.ToString());
                    clsCtcontratrendezvousclient.CA_CODECONTRAT = clsCtcontratrendezvousclientDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratrendezvousclient.RD_DATERENDEZVOUS = DateTime.Parse(clsCtcontratrendezvousclientDTO.RD_DATERENDEZVOUS.ToString());
                    clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS = clsCtcontratrendezvousclientDTO.RD_OBJETRENDEZVOUS.ToString();
                    clsCtcontratrendezvousclient.OP_CODEOPERATEUR = clsCtcontratrendezvousclientDTO.OP_CODEOPERATEUR.ToString();
                    clsCtcontratrendezvousclient.TYPEOPERATION = clsCtcontratrendezvousclientDTO.TYPEOPERATION.ToString();

                    clsObjetEnvoi.OE_A = clsCtcontratrendezvousclientDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratrendezvousclientDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtcontratrendezvousclientWSBLL.pvgAjouter(clsDonnee, clsCtcontratrendezvousclient, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratrendezvousclients;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> pvgModifier(List<HT_Stock.BOJ.clsCtcontratrendezvousclient> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratrendezvousclients = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
                //--TEST CONTRAINTE
                clsCtcontratrendezvousclients = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclientDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.AG_CODEAGENCE = clsCtcontratrendezvousclientDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratrendezvousclient.EN_CODEENTREPOT = clsCtcontratrendezvousclientDTO.EN_CODEENTREPOT.ToString();
                    clsCtcontratrendezvousclient.RD_INDEXRENDEZVOUS = clsCtcontratrendezvousclientDTO.RD_INDEXRENDEZVOUS.ToString();
                    clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS = DateTime.Parse(clsCtcontratrendezvousclientDTO.RD_DATESAISIERENDEZVOUS.ToString());
                    clsCtcontratrendezvousclient.CA_CODECONTRAT = clsCtcontratrendezvousclientDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratrendezvousclient.RD_DATERENDEZVOUS = DateTime.Parse(clsCtcontratrendezvousclientDTO.RD_DATERENDEZVOUS.ToString());
                    clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS = clsCtcontratrendezvousclientDTO.RD_OBJETRENDEZVOUS.ToString();
                    clsCtcontratrendezvousclient.OP_CODEOPERATEUR = clsCtcontratrendezvousclientDTO.OP_CODEOPERATEUR.ToString();
                    clsCtcontratrendezvousclient.TYPEOPERATION = clsCtcontratrendezvousclientDTO.TYPEOPERATION.ToString();



                    clsObjetEnvoi.OE_A = clsCtcontratrendezvousclientDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratrendezvousclientDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontratrendezvousclientDTO.RD_INDEXRENDEZVOUS };
                    clsObjetRetour.SetValue(true, clsCtcontratrendezvousclientWSBLL.pvgModifier(clsDonnee, clsCtcontratrendezvousclient, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratrendezvousclients;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> pvgSupprimer(List<HT_Stock.BOJ.clsCtcontratrendezvousclient> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratrendezvousclients = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
                //--TEST CONTRAINTE
                clsCtcontratrendezvousclients = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
            }


            clsObjetEnvoi.OE_PARAM = new string[] {Objet[0].AG_CODEAGENCE, Objet[0].RD_INDEXRENDEZVOUS, Objet[0].RD_DATESAISIERENDEZVOUS };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtcontratrendezvousclientWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratrendezvousclients;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtcontratrendezvousclient> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratrendezvousclients = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
                //--TEST CONTRAINTE
                clsCtcontratrendezvousclients = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].CA_CODECONTRAT, Objet[0].RD_OBJETRENDEZVOUS, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratrendezvousclientWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtcontratrendezvousclient.RD_INDEXRENDEZVOUS = row["RD_INDEXRENDEZVOUS"].ToString();

                    clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS = (row["RD_DATESAISIERENDEZVOUS"].ToString() != "") ? DateTime.Parse(row["RD_DATESAISIERENDEZVOUS"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS = (clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS != "01-01-1900") ? clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS : "";
                    clsCtcontratrendezvousclient.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsCtcontratrendezvousclient.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                    clsCtcontratrendezvousclient.RD_DATERENDEZVOUS = (row["RD_DATERENDEZVOUS"].ToString() != "") ? DateTime.Parse(row["RD_DATERENDEZVOUS"].ToString()).ToShortDateString().Replace("/", "-") : "";
                    clsCtcontratrendezvousclient.RD_DATERENDEZVOUS = (clsCtcontratrendezvousclient.RD_DATERENDEZVOUS != "01-01-1900") ? clsCtcontratrendezvousclient.RD_DATERENDEZVOUS : "";
                    clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS = row["RD_OBJETRENDEZVOUS"].ToString();
                    clsCtcontratrendezvousclient.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
            clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
            clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratrendezvousclients;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtcontratrendezvousclient> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtcontratrendezvousclients = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
        //    //--TEST CONTRAINTE
        //    clsCtcontratrendezvousclients = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratrendezvousclients[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratrendezvousclients;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratrendezvousclientWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                    clsCtcontratrendezvousclient.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtcontratrendezvousclient.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
            clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
            clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontratrendezvousclients;
    }


        
    }
}
