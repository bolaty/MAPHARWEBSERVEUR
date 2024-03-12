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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsJourneetravail" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsJourneetravail.svc ou wsJourneetravail.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsJourneetravail : IwsJourneetravail
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();

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
        public List<HT_Stock.BOJ.clsJourneetravail> pvgAjouter(List<HT_Stock.BOJ.clsJourneetravail> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsJourneetravails = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
                //--TEST CONTRAINTE
                clsJourneetravails = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsJourneetravail clsJourneetravailDTO in Objet)
                {
                    Stock.BOJ.clsJourneetravail clsJourneetravail = new Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.AG_CODEAGENCE = clsJourneetravailDTO.AG_CODEAGENCE.ToString();
                    clsJourneetravail.JT_DATEJOURNEETRAVAIL =DateTime.Parse( clsJourneetravailDTO.JT_DATEJOURNEETRAVAIL.ToString());
                    clsJourneetravail.JT_STATUT = clsJourneetravailDTO.JT_STATUT.ToString();
                    clsJourneetravail.OP_CODEOPERATEUR = clsJourneetravailDTO.OP_CODEOPERATEUR.ToString();
                    clsObjetEnvoi.OE_A = clsJourneetravailDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsJourneetravailDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsJourneetravailWSBLL.pvgAjouter(clsDonnee, clsJourneetravail, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsJourneetravails.Add(clsJourneetravail);
                }
                else
                {
                    HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsJourneetravails.Add(clsJourneetravail);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                clsJourneetravails.Add(clsJourneetravail);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                clsJourneetravails.Add(clsJourneetravail);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsJourneetravails;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsJourneetravail> pvgModifier(List<HT_Stock.BOJ.clsJourneetravail> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsJourneetravails = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
                //--TEST CONTRAINTE
                clsJourneetravails = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsJourneetravail clsJourneetravailDTO in Objet)
                {
                    Stock.BOJ.clsJourneetravail clsJourneetravail = new Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.AG_CODEAGENCE = clsJourneetravailDTO.AG_CODEAGENCE.ToString();
                    clsJourneetravail.JT_DATEJOURNEETRAVAIL = DateTime.Parse(clsJourneetravailDTO.JT_DATEJOURNEETRAVAIL.ToString());
                    clsJourneetravail.JT_STATUT = clsJourneetravailDTO.JT_STATUT.ToString();
                    clsJourneetravail.OP_CODEOPERATEUR = clsJourneetravailDTO.OP_CODEOPERATEUR.ToString();
                    clsObjetEnvoi.OE_A = clsJourneetravailDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsJourneetravailDTO.clsObjetEnvoi.OE_Y;

                    clsObjetEnvoi.OE_PARAM = new string[] { clsJourneetravailDTO.AG_CODEAGENCE, clsJourneetravailDTO.JT_DATEJOURNEETRAVAIL };
                    clsObjetRetour.SetValue(true, clsJourneetravailWSBLL.pvgModifier(clsDonnee, clsJourneetravail, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsJourneetravails.Add(clsJourneetravail);
                }
                else
                {
                    HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsJourneetravails.Add(clsJourneetravail);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                clsJourneetravails.Add(clsJourneetravail);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                clsJourneetravails.Add(clsJourneetravail);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsJourneetravails;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsJourneetravail> pvgSupprimer(List<HT_Stock.BOJ.clsJourneetravail> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsJourneetravails = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
                //--TEST CONTRAINTE
                clsJourneetravails = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].JT_DATEJOURNEETRAVAIL };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsJourneetravailWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsJourneetravails.Add(clsJourneetravail);
                }
                else
                {
                    HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsJourneetravails.Add(clsJourneetravail);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                clsJourneetravails.Add(clsJourneetravail);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
                clsJourneetravails.Add(clsJourneetravail);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsJourneetravails;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsJourneetravail> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsJourneetravail> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsJourneetravails = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
                //--TEST CONTRAINTE
                clsJourneetravails = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE, Objet[0].EX_EXERCICE, Objet[0].JT_STATUT };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsJourneetravailWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsJourneetravail.JT_DATEJOURNEETRAVAIL = row["JT_DATEJOURNEETRAVAIL"].ToString();
                    clsJourneetravail.JT_STATUT = row["JT_STATUT"].ToString();
                        //JT_DATEJOURNEETRAVAIL", "JT_STATUT"
                    clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJourneetravail.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsJourneetravails.Add(clsJourneetravail);
                }
            }
            else
            {
                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsJourneetravails.Add(clsJourneetravail);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
            clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
            clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJourneetravail.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            clsJourneetravails.Add(clsJourneetravail);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
            clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
            clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJourneetravail.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            clsJourneetravails.Add(clsJourneetravail);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsJourneetravails;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsJourneetravail> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsJourneetravail> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsJourneetravails = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
        //    //--TEST CONTRAINTE
        //    clsJourneetravails = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsJourneetravails[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJourneetravails;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsJourneetravailWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                    clsJourneetravail.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsJourneetravail.JT_DATEJOURNEETRAVAIL = row["JT_DATEJOURNEETRAVAIL"].ToString();
                    clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJourneetravail.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsJourneetravails.Add(clsJourneetravail);
                }
            }
            else
            {
                HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsJourneetravails.Add(clsJourneetravail);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
            clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
            clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJourneetravail.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            clsJourneetravails.Add(clsJourneetravail);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
            clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
            clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJourneetravail.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJourneetravail.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            clsJourneetravails.Add(clsJourneetravail);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsJourneetravails;
    }


        
    }
}
