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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsJournal" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsJournal.svc ou wsJournal.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsJournal : IwsJournal
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsJournalWSBLL clsJournalWSBLL = new clsJournalWSBLL();

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
        public List<HT_Stock.BOJ.clsJournal> pvgAjouter(List<HT_Stock.BOJ.clsJournal> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsJournals = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
                //--TEST CONTRAINTE
                clsJournals = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsJournal clsJournalDTO in Objet)
                {
                    Stock.BOJ.clsJournal clsJournal = new Stock.BOJ.clsJournal();
                    clsJournal.JO_CODEJOURNAL = clsJournalDTO.JO_CODEJOURNAL.ToString();
                    clsJournal.JO_JOURNALCODE = clsJournalDTO.JO_JOURNALCODE.ToString();
                    clsJournal.JO_LIBELLE = clsJournalDTO.JO_LIBELLE.ToString();
                    clsJournal.EN_CODEENTREPOT = clsJournalDTO.EN_CODEENTREPOT.ToString();
                    clsJournal.PL_CODENUMCOMPTE = clsJournalDTO.PL_CODENUMCOMPTE.ToString();
                    clsJournal.JO_C = clsJournalDTO.JO_C.ToString();
                    clsJournal.JO_NUMEROORDRE =int.Parse(clsJournalDTO.JO_NUMEROORDRE.ToString());
                    clsJournal.TJ_CODETYPEJOURNAL = clsJournalDTO.TJ_CODETYPEJOURNAL.ToString();
                    clsJournal.JO_SAISIEANALYTIQUE = clsJournalDTO.JO_SAISIEANALYTIQUE.ToString();
                    clsJournal.JO_CONTREPARTIE = clsJournalDTO.JO_CONTREPARTIE.ToString();

                    clsObjetEnvoi.OE_A = clsJournalDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsJournalDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsJournalWSBLL.pvgAjouter(clsDonnee, clsJournal, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJournal.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsJournals.Add(clsJournal);
                }
                else
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsJournal.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsJournals.Add(clsJournal);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                clsJournals.Add(clsJournal);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                clsJournals.Add(clsJournal);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsJournals;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsJournal> pvgModifier(List<HT_Stock.BOJ.clsJournal> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsJournals = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
                //--TEST CONTRAINTE
                clsJournals = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsJournal clsJournalDTO in Objet)
                {
                    Stock.BOJ.clsJournal clsJournal = new Stock.BOJ.clsJournal();
                    clsJournal.JO_CODEJOURNAL = clsJournalDTO.JO_CODEJOURNAL.ToString();
                    clsJournal.JO_JOURNALCODE = clsJournalDTO.JO_JOURNALCODE.ToString();
                    clsJournal.JO_LIBELLE = clsJournalDTO.JO_LIBELLE.ToString();
                    clsJournal.EN_CODEENTREPOT = clsJournalDTO.EN_CODEENTREPOT.ToString();
                    clsJournal.PL_CODENUMCOMPTE = clsJournalDTO.PL_CODENUMCOMPTE.ToString();
                    clsJournal.JO_C = clsJournalDTO.JO_C.ToString();
                    clsJournal.JO_NUMEROORDRE = int.Parse(clsJournalDTO.JO_NUMEROORDRE.ToString());
                    clsJournal.TJ_CODETYPEJOURNAL = clsJournalDTO.TJ_CODETYPEJOURNAL.ToString();
                    clsJournal.JO_SAISIEANALYTIQUE = clsJournalDTO.JO_SAISIEANALYTIQUE.ToString();
                    clsJournal.JO_CONTREPARTIE = clsJournalDTO.JO_CONTREPARTIE.ToString();



                    clsObjetEnvoi.OE_A = clsJournalDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsJournalDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsJournalDTO.JO_CODEJOURNAL };
                    clsObjetRetour.SetValue(true, clsJournalWSBLL.pvgModifier(clsDonnee, clsJournal, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJournal.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsJournals.Add(clsJournal);
                }
                else
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsJournal.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsJournals.Add(clsJournal);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                clsJournals.Add(clsJournal);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                clsJournals.Add(clsJournal);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsJournals;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsJournal> pvgSupprimer(List<HT_Stock.BOJ.clsJournal> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsJournals = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
                //--TEST CONTRAINTE
                clsJournals = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].JO_CODEJOURNAL };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsJournalWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJournal.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsJournals.Add(clsJournal);
                }
                else
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsJournal.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsJournals.Add(clsJournal);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                clsJournals.Add(clsJournal);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsJournals = new List<HT_Stock.BOJ.clsJournal>();
                clsJournals.Add(clsJournal);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsJournals;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsJournal> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsJournal> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsJournals = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
            //    //--TEST CONTRAINTE
            //    clsJournals = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsJournalWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsJournal.TJ_CODETYPEJOURNAL = row["TJ_CODETYPEJOURNAL"].ToString();
                    clsJournal.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();
                    clsJournal.JO_JOURNALCODE = row["JO_JOURNALCODE"].ToString();
                    clsJournal.JO_LIBELLE = row["JO_LIBELLE"].ToString();
                    clsJournal.JO_C = row["JO_C"].ToString();
                    clsJournal.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsJournal.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                    clsJournal.JO_NUMEROORDRE =row["JO_NUMEROORDRE"].ToString();
                    clsJournal.EN_DENOMINATION = row["EN_DENOMINATION"].ToString();
                    clsJournal.TJ_LIBELLE = row["TJ_LIBELLE"].ToString();
                    clsJournal.JO_SAISIEANALYTIQUE = row["JO_SAISIEANALYTIQUE"].ToString();
                    clsJournal.JO_CONTREPARTIE = row["JO_CONTREPARTIE"].ToString();


                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJournal.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsJournals.Add(clsJournal);
                }
            }
            else
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsJournal.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsJournals.Add(clsJournal);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            clsJournals.Add(clsJournal);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            clsJournals.Add(clsJournal);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsJournals;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsJournal> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsJournal> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsJournals = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
        //    //--TEST CONTRAINTE
        //    clsJournals = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsJournalWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();
                    clsJournal.JO_LIBELLE = row["JO_LIBELLE"].ToString();
                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJournal.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsJournals.Add(clsJournal);
                }
            }
            else
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsJournal.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsJournals.Add(clsJournal);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            clsJournals.Add(clsJournal);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            clsJournals.Add(clsJournal);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsJournals;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsJournal> pvgChargerDansDataSetPourComboSelonEcran(List<HT_Stock.BOJ.clsJournal> Objet)
            {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsJournals = TestChampObligatoireListeEcran(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
                //--TEST CONTRAINTE
                clsJournals = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsJournals[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsJournals;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].TJ_CODETYPEJOURNAL,Objet[0].TYPEOPERATION };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsJournalWSBLL.pvgChargerDansDataSetPourComboSelonEcran(clsDonnee, clsObjetEnvoi);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                    clsJournal.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();
                    clsJournal.JO_LIBELLE = row["JO_LIBELLE"].ToString();
                    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                    clsJournal.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsJournal.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsJournals.Add(clsJournal);
                }
            }
            else
            {
                HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsJournal.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsJournals.Add(clsJournal);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            clsJournals.Add(clsJournal);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsJournal.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsJournal.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            clsJournals.Add(clsJournal);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsJournals;
        }
        
    }
}
