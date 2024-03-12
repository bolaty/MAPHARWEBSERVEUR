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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtsinistresuivie" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtsinistresuivie.svc ou wsCtsinistresuivie.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtsinistresuivie : IwsCtsinistresuivie
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtsinistresuivieWSBLL clsCtsinistresuivieWSBLL = new clsCtsinistresuivieWSBLL();

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
        public List<HT_Stock.BOJ.clsCtsinistresuivie> pvgAjouter(List<HT_Stock.BOJ.clsCtsinistresuivie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistresuivies = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
                //--TEST CONTRAINTE
                clsCtsinistresuivies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivieDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.AG_CODEAGENCE = clsCtsinistresuivieDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistresuivie.EN_CODEENTREPOT = clsCtsinistresuivieDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistresuivie.SD_INDEXSUIVIE = clsCtsinistresuivieDTO.SD_INDEXSUIVIE.ToString();
                    clsCtsinistresuivie.SD_DATESAISIE = DateTime.Parse(clsCtsinistresuivieDTO.SD_DATESAISIE.ToString());
                    clsCtsinistresuivie.SD_DATESUIVIE =DateTime.Parse(clsCtsinistresuivieDTO.SD_DATESUIVIE.ToString());
                    clsCtsinistresuivie.SI_CODESINISTRE = clsCtsinistresuivieDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = clsCtsinistresuivieDTO.SD_DESCRIPTIONEVENEMENT.ToString();
                    clsCtsinistresuivie.OP_CODEOPERATEUR = clsCtsinistresuivieDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = clsCtsinistresuivieDTO.SD_DESCRIPTIONEVENEMENT.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinistresuivieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistresuivieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtsinistresuivieWSBLL.pvgAjouter(clsDonnee, clsCtsinistresuivie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistresuivies.Add(clsCtsinistresuivie);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistresuivies.Add(clsCtsinistresuivie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistresuivies;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistresuivie> pvgModifier(List<HT_Stock.BOJ.clsCtsinistresuivie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistresuivies = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
                //--TEST CONTRAINTE
                clsCtsinistresuivies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivieDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.AG_CODEAGENCE = clsCtsinistresuivieDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistresuivie.EN_CODEENTREPOT = clsCtsinistresuivieDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistresuivie.SD_INDEXSUIVIE = clsCtsinistresuivieDTO.SD_INDEXSUIVIE.ToString();
                    clsCtsinistresuivie.SD_DATESAISIE = DateTime.Parse(clsCtsinistresuivieDTO.SD_DATESAISIE.ToString());
                    clsCtsinistresuivie.SD_DATESUIVIE = DateTime.Parse(clsCtsinistresuivieDTO.SD_DATESUIVIE.ToString());
                    clsCtsinistresuivie.SI_CODESINISTRE = clsCtsinistresuivieDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = clsCtsinistresuivieDTO.SD_DESCRIPTIONEVENEMENT.ToString();
                    clsCtsinistresuivie.OP_CODEOPERATEUR = clsCtsinistresuivieDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = clsCtsinistresuivieDTO.SD_DESCRIPTIONEVENEMENT.ToString();
                    clsObjetEnvoi.OE_A = clsCtsinistresuivieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistresuivieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinistresuivieDTO.AG_CODEAGENCE ,clsCtsinistresuivieDTO.SD_INDEXSUIVIE ,clsCtsinistresuivieDTO.SD_DATESUIVIE };
                    clsObjetRetour.SetValue(true, clsCtsinistresuivieWSBLL.pvgModifier(clsDonnee, clsCtsinistresuivie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistresuivies.Add(clsCtsinistresuivie);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistresuivies.Add(clsCtsinistresuivie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistresuivies;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistresuivie> pvgSupprimer(List<HT_Stock.BOJ.clsCtsinistresuivie> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistresuivies = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
                //--TEST CONTRAINTE
                clsCtsinistresuivies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
            }


            clsObjetEnvoi.OE_PARAM = new string[] {Objet[0].AG_CODEAGENCE, Objet[0].SD_INDEXSUIVIE, Objet[0].SD_DATESAISIE, Objet[0].SI_CODESINISTRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinistresuivieWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistresuivies.Add(clsCtsinistresuivie);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistresuivies.Add(clsCtsinistresuivie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistresuivies;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtsinistresuivie> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtsinistresuivie> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistresuivies = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
                //--TEST CONTRAINTE
                clsCtsinistresuivies = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].SI_CODESINISTRE, Objet[0].DATEDEBUT,Objet[0].DATEFIN,Objet[0].SD_DESCRIPTIONEVENEMENT, Objet[0].OP_CODEOPERATEUR,Objet[0].TYPEOPERATION};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistresuivieWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtsinistresuivie.SD_INDEXSUIVIE = row["SD_INDEXSUIVIE"].ToString();
                    clsCtsinistresuivie.SD_DATESUIVIE =DateTime.Parse(row["SD_DATESUIVIE"].ToString()).ToShortDateString();
                    clsCtsinistresuivie.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                    clsCtsinistresuivie.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                    clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = row["SD_DESCRIPTIONEVENEMENT"].ToString();
                    clsCtsinistresuivie.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistresuivies.Add(clsCtsinistresuivie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
            clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
            clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistresuivies;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistresuivie> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtsinistresuivie> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtsinistresuivies = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
        //    //--TEST CONTRAINTE
        //    clsCtsinistresuivies = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistresuivies[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistresuivies;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistresuivieWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                    clsCtsinistresuivie.SI_CODESINISTRE = row["SD_INDEXSUIVIE"].ToString();
                    clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = row["SD_DESCRIPTIONEVENEMENT"].ToString();
                    clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistresuivies.Add(clsCtsinistresuivie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
            clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            clsCtsinistresuivies.Add(clsCtsinistresuivie);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
            clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            clsCtsinistresuivies.Add(clsCtsinistresuivie);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtsinistresuivies;
    }


        
    }
}
