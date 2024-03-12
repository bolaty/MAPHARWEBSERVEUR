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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsBanqueagence" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsBanqueagence.svc ou wsBanqueagence.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsBanqueagence : IwsBanqueagence
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsBanqueagenceWSBLL clsBanqueagenceWSBLL = new clsBanqueagenceWSBLL();

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
        public List<HT_Stock.BOJ.clsBanqueagence> pvgAjouter(List<HT_Stock.BOJ.clsBanqueagence> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBanqueagences = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
                //--TEST CONTRAINTE
                clsBanqueagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsBanqueagence clsBanqueagenceDTO in Objet)
                {
                    Stock.BOJ.clsBanqueagence clsBanqueagence = new Stock.BOJ.clsBanqueagence();
                    //clsBanqueagence.AB_CODEAGENCEBANCAIRE =int.Parse( clsBanqueagenceDTO.AB_CODEAGENCEBANCAIRE.ToString());

                    clsBanqueagence.BQ_CODEBANQUE = int.Parse(clsBanqueagenceDTO.BQ_CODEBANQUE.ToString());
                    clsBanqueagence.AB_LIBELLE = clsBanqueagenceDTO.AB_LIBELLE.ToString();
                    clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE = clsBanqueagenceDTO.AB_ADRESSEGEOGRAPHIQUE.ToString();
                    clsBanqueagence.AB_BOITEPOSTALE = clsBanqueagenceDTO.AB_BOITEPOSTALE.ToString();
                    clsBanqueagence.AB_EMAIL = clsBanqueagenceDTO.AB_EMAIL.ToString();
                    clsBanqueagence.AB_TELEPHONE = clsBanqueagenceDTO.AB_TELEPHONE.ToString();
                    clsBanqueagence.AB_FAX = clsBanqueagenceDTO.AB_FAX.ToString();
                    clsBanqueagence.BQ_ABREGE = clsBanqueagenceDTO.BQ_ABREGE.ToString();
                    clsBanqueagence.BQ_CODEBIC = clsBanqueagenceDTO.BQ_CODEBIC.ToString();
                    clsBanqueagence.BQ_SITEWEB = clsBanqueagenceDTO.BQ_SITEWEB.ToString();
                    clsBanqueagence.BQ_AUTREINFOS = clsBanqueagenceDTO.BQ_AUTREINFOS.ToString();
                    clsBanqueagence.CO_CODECOMMUNE = clsBanqueagenceDTO.CO_CODECOMMUNE.ToString();






                    clsObjetEnvoi.OE_A = clsBanqueagenceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsBanqueagenceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgAjouter(clsDonnee, clsBanqueagence, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBanqueagences.Add(clsBanqueagence);
                }
                else
                {
                    HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBanqueagences.Add(clsBanqueagence);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                clsBanqueagences.Add(clsBanqueagence);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                clsBanqueagences.Add(clsBanqueagence);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBanqueagences;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBanqueagence> pvgModifier(List<HT_Stock.BOJ.clsBanqueagence> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBanqueagences = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
                //--TEST CONTRAINTE
                clsBanqueagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsBanqueagence clsBanqueagenceDTO in Objet)
                {
                    Stock.BOJ.clsBanqueagence clsBanqueagence = new Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.AB_CODEAGENCEBANCAIRE =int.Parse(clsBanqueagenceDTO.AB_CODEAGENCEBANCAIRE.ToString());

                    clsBanqueagence.BQ_CODEBANQUE = int.Parse(clsBanqueagenceDTO.BQ_CODEBANQUE.ToString());
                    clsBanqueagence.AB_LIBELLE = clsBanqueagenceDTO.AB_LIBELLE.ToString();
                    clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE = clsBanqueagenceDTO.AB_ADRESSEGEOGRAPHIQUE.ToString();
                    clsBanqueagence.AB_BOITEPOSTALE = clsBanqueagenceDTO.AB_BOITEPOSTALE.ToString();
                    clsBanqueagence.AB_EMAIL = clsBanqueagenceDTO.AB_EMAIL.ToString();
                    clsBanqueagence.AB_TELEPHONE = clsBanqueagenceDTO.AB_TELEPHONE.ToString();
                    clsBanqueagence.AB_FAX = clsBanqueagenceDTO.AB_FAX.ToString();
                    clsBanqueagence.BQ_ABREGE = clsBanqueagenceDTO.BQ_ABREGE.ToString();
                    clsBanqueagence.BQ_CODEBIC = clsBanqueagenceDTO.BQ_CODEBIC.ToString();
                    clsBanqueagence.BQ_SITEWEB = clsBanqueagenceDTO.BQ_SITEWEB.ToString();
                    clsBanqueagence.BQ_AUTREINFOS = clsBanqueagenceDTO.BQ_AUTREINFOS.ToString();
                    clsBanqueagence.CO_CODECOMMUNE = clsBanqueagenceDTO.CO_CODECOMMUNE.ToString();



                    clsBanqueagence.AB_LIBELLE = clsBanqueagenceDTO.AB_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsBanqueagenceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsBanqueagenceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] {  clsBanqueagenceDTO.AB_CODEAGENCEBANCAIRE ,clsBanqueagenceDTO.BQ_CODEBANQUE.ToString() };
                    clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgModifier(clsDonnee, clsBanqueagence, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBanqueagences.Add(clsBanqueagence);
                }
                else
                {
                    HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBanqueagences.Add(clsBanqueagence);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                clsBanqueagences.Add(clsBanqueagence);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                clsBanqueagences.Add(clsBanqueagence);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBanqueagences;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBanqueagence> pvgSupprimer(List<HT_Stock.BOJ.clsBanqueagence> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBanqueagences = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
                //--TEST CONTRAINTE
                clsBanqueagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AB_CODEAGENCEBANCAIRE ,Objet[0].BQ_CODEBANQUE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBanqueagences.Add(clsBanqueagence);
                }
                else
                {
                    HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBanqueagences.Add(clsBanqueagence);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                clsBanqueagences.Add(clsBanqueagence);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
                clsBanqueagences.Add(clsBanqueagence);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBanqueagences;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsBanqueagence> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsBanqueagence> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBanqueagences = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
                //--TEST CONTRAINTE
                clsBanqueagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].BQ_CODEBANQUE };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsBanqueagenceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.AB_CODEAGENCEBANCAIRE = row["AB_CODEAGENCEBANCAIRE"].ToString();
                    clsBanqueagence.AB_LIBELLE = row["AB_LIBELLE"].ToString();
                    clsBanqueagence.BQ_CODEBANQUE = row["BQ_CODEBANQUE"].ToString();
                    clsBanqueagence.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                    clsBanqueagence.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                    clsBanqueagence.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                    clsBanqueagence.BQ_CODEBIC = row["BQ_CODEBIC"].ToString();
                    clsBanqueagence.BQ_ABREGE = row["BQ_ABREGE"].ToString();
                    clsBanqueagence.BQ_SITEWEB = row["BQ_SITEWEB"].ToString();
                    clsBanqueagence.BQ_AUTREINFOS = row["BQ_AUTREINFOS"].ToString();
                    //clsBanqueagence.AB_CODEGUICHET1 = row["AB_CODEGUICHET1"].ToString();
                    clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE = row["AB_ADRESSEGEOGRAPHIQUE"].ToString();
                    clsBanqueagence.AB_BOITEPOSTALE = row["AB_BOITEPOSTALE"].ToString();
                    clsBanqueagence.AB_TELEPHONE = row["AB_TELEPHONE"].ToString();
                    clsBanqueagence.AB_FAX = row["AB_FAX"].ToString();
                    clsBanqueagence.AB_EMAIL = row["AB_EMAIL"].ToString();
                    //clsBanqueagence.AB_CODEGUICHET = row["AB_CODEGUICHET"].ToString();

                    clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanqueagence.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsBanqueagences.Add(clsBanqueagence);
                }
            }
            else
            {
                HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsBanqueagences.Add(clsBanqueagence);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
            clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
            clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBanqueagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            clsBanqueagences.Add(clsBanqueagence);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
            clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
            clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBanqueagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            clsBanqueagences.Add(clsBanqueagence);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsBanqueagences;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBanqueagence> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsBanqueagence> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBanqueagences = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
                //--TEST CONTRAINTE
                clsBanqueagences = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBanqueagences[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBanqueagences;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].BQ_CODEBANQUE };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsBanqueagenceWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                    clsBanqueagence.AB_CODEAGENCEBANCAIRE = row["AB_CODEAGENCEBANCAIRE"].ToString();
                    clsBanqueagence.AB_LIBELLE = row["AB_LIBELLE"].ToString();
                    clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBanqueagence.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsBanqueagences.Add(clsBanqueagence);
                }
            }
            else
            {
                HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsBanqueagences.Add(clsBanqueagence);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
            clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
            clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBanqueagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            clsBanqueagences.Add(clsBanqueagence);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
            clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
            clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBanqueagence.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBanqueagence.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            clsBanqueagences.Add(clsBanqueagence);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsBanqueagences;
    }


        
    }
}
