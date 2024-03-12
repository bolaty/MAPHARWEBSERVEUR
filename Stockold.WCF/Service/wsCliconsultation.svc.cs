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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCliconsultation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCliconsultation.svc ou wsCliconsultation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCliconsultation : IwsCliconsultation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCliconsultationWSBLL clsCliconsultationWSBLL = new clsCliconsultationWSBLL();

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
        public List<HT_Stock.BOJ.clsCliconsultation> pvgAjouter(List<HT_Stock.BOJ.clsCliconsultation> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliconsultations = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
                //--TEST CONTRAINTE
                clsCliconsultations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCliconsultation clsCliconsultationDTO in Objet)
                {
                    Stock.BOJ.clsCliconsultation clsCliconsultation = new Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.CO_CODECONSULTATION = clsCliconsultationDTO.CO_CODECONSULTATION.ToString();
                    clsCliconsultation.CO_NUMERODOSSIER = clsCliconsultationDTO.CO_NUMERODOSSIER.ToString();

                    clsCliconsultation.CO_CODECONSULTATION = clsCliconsultationDTO.CO_CODECONSULTATION.ToString();
                    clsCliconsultation.AG_CODEAGENCE = clsCliconsultationDTO.AG_CODEAGENCE.ToString();
                    clsCliconsultation.SR_CODESERVICE = clsCliconsultationDTO.SR_CODESERVICE.ToString();//--ok
                    clsCliconsultation.TY_CODETYPECONSULTATION = clsCliconsultationDTO.TY_CODETYPECONSULTATION.ToString();//--ok
                    clsCliconsultation.MD_CODEMODEADMISSION = clsCliconsultationDTO.MD_CODEMODEADMISSION.ToString();//--
                    clsCliconsultation.MS_CODEMODESORTIE = clsCliconsultationDTO.MS_CODEMODESORTIE.ToString();//--
                    clsCliconsultation.TI_IDTIERSPATIENT = clsCliconsultationDTO.TI_IDTIERSPATIENT.ToString();
                    clsCliconsultation.TI_IDTIERSMEDECIN = clsCliconsultationDTO.TI_IDTIERSMEDECIN.ToString();
                    clsCliconsultation.CO_CODECONSULTATION1 = clsCliconsultationDTO.CO_CODECONSULTATION1.ToString();
                    clsCliconsultation.OP_CODEOPERATEUR = clsCliconsultationDTO.OP_CODEOPERATEUR.ToString();
                    //clsCliconsultation.TI_IDTIERSASSUREUR = clsCliconsultationDTO.TI_IDTIERSASSUREUR.ToString();
                    //clsCliconsultation.AP_CODEPRODUIT = clsCliconsultationDTO.AP_CODEPRODUIT.ToString();
                    clsCliconsultation.CO_NUMERODOSSIER = clsCliconsultationDTO.CO_NUMERODOSSIER.ToString();
                    clsCliconsultation.CO_DATEDECONSULTATION =DateTime.Parse( clsCliconsultationDTO.CO_DATEDECONSULTATION.ToString());
                    clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION =DateTime.Parse( clsCliconsultationDTO.CO_DATEEXPIRATIONCONSULTATION.ToString());
                    clsCliconsultation.CO_MOTIFCONSULTATION = clsCliconsultationDTO.CO_MOTIFCONSULTATION.ToString();
                    clsCliconsultation.CO_AUTRESINFORMATIONS = clsCliconsultationDTO.CO_AUTRESINFORMATIONS.ToString();
                    clsCliconsultation.CO_TAUXASSURANCE =double.Parse( clsCliconsultationDTO.CO_TAUXASSURANCE.ToString());
                    clsCliconsultation.CO_MONTANTASSURANCE =double.Parse( clsCliconsultationDTO.CO_MONTANTASSURANCE.ToString());
                    clsCliconsultation.CO_DATESAISIE =DateTime.Parse( clsCliconsultationDTO.CO_DATESAISIE.ToString());
                    clsCliconsultation.CO_DESCRIPTIONREPRESENTANT = clsCliconsultationDTO.CO_DESCRIPTIONREPRESENTANT.ToString();
                    clsCliconsultation.CO_CONTACTREPRESENTANT = clsCliconsultationDTO.CO_CONTACTREPRESENTANT.ToString();
                    clsCliconsultation.CO_DATESORTIE =DateTime.Parse( clsCliconsultationDTO.CO_DATESORTIE.ToString());
                    clsCliconsultation.CO_TAUXMEDECIN =double.Parse( clsCliconsultationDTO.CO_TAUXMEDECIN.ToString());
                    clsCliconsultation.CO_MONTANTMEDECIN =double.Parse( clsCliconsultationDTO.CO_MONTANTMEDECIN.ToString());

                    clsCliconsultation.TI_NUMTIERSMEDECIN = clsCliconsultationDTO.TI_NUMTIERSMEDECIN.ToString();
                    clsCliconsultation.TI_DENOMINATIONMEDECIN = clsCliconsultationDTO.TI_DENOMINATIONMEDECIN.ToString();
                    clsCliconsultation.TI_TELEPHONEMEDECIN = clsCliconsultationDTO.TI_TELEPHONEMEDECIN.ToString();
                    clsCliconsultation.TI_NUMTIERSPATIENT = clsCliconsultationDTO.TI_NUMTIERSPATIENT.ToString();
                    clsCliconsultation.TI_DENOMINATIONPATIENT = clsCliconsultationDTO.TI_DENOMINATIONPATIENT.ToString();
                    clsCliconsultation.TI_TELEPHONEPATIENT = clsCliconsultationDTO.TI_TELEPHONEPATIENT.ToString();


                    clsObjetEnvoi.OE_A = clsCliconsultationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCliconsultationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCliconsultationWSBLL.pvgAjouter(clsDonnee, clsCliconsultation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }
                else
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                clsCliconsultations.Add(clsCliconsultation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                clsCliconsultations.Add(clsCliconsultation);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliconsultations;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliconsultation> pvgModifier(List<HT_Stock.BOJ.clsCliconsultation> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliconsultations = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
                //--TEST CONTRAINTE
                clsCliconsultations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();


                foreach (HT_Stock.BOJ.clsCliconsultation clsCliconsultationDTO in Objet)
                {
                    Stock.BOJ.clsCliconsultation clsCliconsultation = new Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.CO_CODECONSULTATION = clsCliconsultationDTO.CO_CODECONSULTATION.ToString();
                    clsCliconsultation.CO_NUMERODOSSIER = clsCliconsultationDTO.CO_NUMERODOSSIER.ToString();

                    clsCliconsultation.CO_CODECONSULTATION = clsCliconsultationDTO.CO_CODECONSULTATION.ToString();
                    clsCliconsultation.AG_CODEAGENCE = clsCliconsultationDTO.AG_CODEAGENCE.ToString();
                    clsCliconsultation.SR_CODESERVICE = clsCliconsultationDTO.SR_CODESERVICE.ToString();//--ok
                    clsCliconsultation.TY_CODETYPECONSULTATION = clsCliconsultationDTO.TY_CODETYPECONSULTATION.ToString();//--ok
                    clsCliconsultation.MD_CODEMODEADMISSION = clsCliconsultationDTO.MD_CODEMODEADMISSION.ToString();//--
                    clsCliconsultation.MS_CODEMODESORTIE = clsCliconsultationDTO.MS_CODEMODESORTIE.ToString();//--
                    clsCliconsultation.TI_IDTIERSPATIENT = clsCliconsultationDTO.TI_IDTIERSPATIENT.ToString();
                    clsCliconsultation.TI_IDTIERSMEDECIN = clsCliconsultationDTO.TI_IDTIERSMEDECIN.ToString();
                    clsCliconsultation.CO_CODECONSULTATION1 = clsCliconsultationDTO.CO_CODECONSULTATION1.ToString();
                    clsCliconsultation.OP_CODEOPERATEUR = clsCliconsultationDTO.OP_CODEOPERATEUR.ToString();
                    //clsCliconsultation.TI_IDTIERSASSUREUR = clsCliconsultationDTO.TI_IDTIERSASSUREUR.ToString();
                    //clsCliconsultation.AP_CODEPRODUIT = clsCliconsultationDTO.AP_CODEPRODUIT.ToString();
                    clsCliconsultation.CO_NUMERODOSSIER = clsCliconsultationDTO.CO_NUMERODOSSIER.ToString();
                    clsCliconsultation.CO_DATEDECONSULTATION = DateTime.Parse(clsCliconsultationDTO.CO_DATEDECONSULTATION.ToString());
                    clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION = DateTime.Parse(clsCliconsultationDTO.CO_DATEEXPIRATIONCONSULTATION.ToString());
                    clsCliconsultation.CO_MOTIFCONSULTATION = clsCliconsultationDTO.CO_MOTIFCONSULTATION.ToString();
                    clsCliconsultation.CO_AUTRESINFORMATIONS = clsCliconsultationDTO.CO_AUTRESINFORMATIONS.ToString();
                    clsCliconsultation.CO_TAUXASSURANCE = double.Parse(clsCliconsultationDTO.CO_TAUXASSURANCE.ToString());
                    clsCliconsultation.CO_MONTANTASSURANCE = double.Parse(clsCliconsultationDTO.CO_MONTANTASSURANCE.ToString());
                    clsCliconsultation.CO_DATESAISIE = DateTime.Parse(clsCliconsultationDTO.CO_DATESAISIE.ToString());
                    clsCliconsultation.CO_DESCRIPTIONREPRESENTANT = clsCliconsultationDTO.CO_DESCRIPTIONREPRESENTANT.ToString();
                    clsCliconsultation.CO_CONTACTREPRESENTANT = clsCliconsultationDTO.CO_CONTACTREPRESENTANT.ToString();
                    clsCliconsultation.CO_DATESORTIE = DateTime.Parse(clsCliconsultationDTO.CO_DATESORTIE.ToString());
                    clsCliconsultation.CO_TAUXMEDECIN = double.Parse(clsCliconsultationDTO.CO_TAUXMEDECIN.ToString());
                    clsCliconsultation.CO_MONTANTMEDECIN = double.Parse(clsCliconsultationDTO.CO_MONTANTMEDECIN.ToString());

                    clsCliconsultation.TI_NUMTIERSMEDECIN = clsCliconsultationDTO.TI_NUMTIERSMEDECIN.ToString();
                    clsCliconsultation.TI_DENOMINATIONMEDECIN = clsCliconsultationDTO.TI_DENOMINATIONMEDECIN.ToString();
                    clsCliconsultation.TI_TELEPHONEMEDECIN = clsCliconsultationDTO.TI_TELEPHONEMEDECIN.ToString();
                    clsCliconsultation.TI_NUMTIERSPATIENT = clsCliconsultationDTO.TI_NUMTIERSPATIENT.ToString();
                    clsCliconsultation.TI_DENOMINATIONPATIENT = clsCliconsultationDTO.TI_DENOMINATIONPATIENT.ToString();
                    clsCliconsultation.TI_TELEPHONEPATIENT = clsCliconsultationDTO.TI_TELEPHONEPATIENT.ToString();


                    clsObjetEnvoi.OE_A = clsCliconsultationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCliconsultationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCliconsultationDTO.CO_CODECONSULTATION };
                    clsObjetRetour.SetValue(true, clsCliconsultationWSBLL.pvgModifier(clsDonnee, clsCliconsultation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
               
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }
                else
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                clsCliconsultations.Add(clsCliconsultation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                clsCliconsultations.Add(clsCliconsultation);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliconsultations;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliconsultation> pvgSupprimer(List<HT_Stock.BOJ.clsCliconsultation> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliconsultations = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
                //--TEST CONTRAINTE
                clsCliconsultations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
            }


            clsObjetEnvoi.OE_PARAM = new string[] {Objet[0].AG_CODEAGENCE   ,Objet[0].CO_CODECONSULTATION};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCliconsultationWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }
                else
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                clsCliconsultations.Add(clsCliconsultation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
                clsCliconsultations.Add(clsCliconsultation);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliconsultations;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCliconsultation> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCliconsultation> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCliconsultations = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
            //    //--TEST CONTRAINTE
            //    clsCliconsultations = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCliconsultationWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.CO_CODECONSULTATION = row["CO_CODECONSULTATION"].ToString();
                    clsCliconsultation.CO_NUMERODOSSIER = row["CO_NUMERODOSSIER"].ToString();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCliconsultations.Add(clsCliconsultation);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliconsultation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            clsCliconsultations.Add(clsCliconsultation);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliconsultation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            clsCliconsultations.Add(clsCliconsultation);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCliconsultations;
            }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCliconsultation> pvgChargerDansDataSetConsultation(List<HT_Stock.BOJ.clsCliconsultation> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliconsultations = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
                //--TEST CONTRAINTE
                clsCliconsultations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].TI_NUMTIERSPATIENT, Objet[0].TI_DENOMINATIONPATIENT, Objet[0].TI_NUMTIERSMEDECIN, Objet[0].TI_DENOMINATIONMEDECIN, Objet[0].CO_NUMERODOSSIER, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].CO_CODECONSULTATION, Objet[0].CO_CODECONSULTATION1, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCliconsultationWSBLL.pvgChargerDansDataSetConsultation(clsDonnee, clsObjetEnvoi);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();

                        clsCliconsultation.CO_CODECONSULTATION = row["CO_CODECONSULTATION"].ToString();
                        clsCliconsultation.CO_NUMERODOSSIER = row["CO_NUMERODOSSIER"].ToString();

                        clsCliconsultation.CO_CODECONSULTATION = row["CO_CODECONSULTATION"].ToString();
                        clsCliconsultation.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsCliconsultation.SR_CODESERVICE = row["SR_CODESERVICE"].ToString();//--ok
                        clsCliconsultation.TY_CODETYPECONSULTATION = row["TY_CODETYPECONSULTATION"].ToString();//--ok
                        clsCliconsultation.MD_CODEMODEADMISSION = row["MD_CODEMODEADMISSION"].ToString();//--
                        clsCliconsultation.MS_CODEMODESORTIE = row["MS_CODEMODESORTIE"].ToString();//--
                        clsCliconsultation.TI_IDTIERSPATIENT = row["TI_IDTIERSPATIENT"].ToString();
                        clsCliconsultation.TI_IDTIERSMEDECIN = row["TI_IDTIERSMEDECIN"].ToString();
                        clsCliconsultation.CO_CODECONSULTATION1 = row["CO_CODECONSULTATION1"].ToString();
                        clsCliconsultation.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        //clsCliconsultation.TI_IDTIERSASSUREUR = row["TI_IDTIERSASSUREUR"].ToString();
                        //clsCliconsultation.AP_CODEPRODUIT = row["AP_CODEPRODUIT"].ToString();
                        clsCliconsultation.CO_NUMERODOSSIER = row["CO_NUMERODOSSIER"].ToString();
                        clsCliconsultation.CO_DATEDECONSULTATION =DateTime.Parse( row["CO_DATEDECONSULTATION"].ToString()).ToShortDateString().Replace("/","-");
                        clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION = row["CO_DATEEXPIRATIONCONSULTATION"].ToString();
                        clsCliconsultation.CO_MOTIFCONSULTATION = row["CO_MOTIFCONSULTATION"].ToString();
                        clsCliconsultation.CO_AUTRESINFORMATIONS = row["CO_AUTRESINFORMATIONS"].ToString();
                        clsCliconsultation.CO_TAUXASSURANCE = row["CO_TAUXASSURANCE"].ToString();
                        clsCliconsultation.CO_MONTANTASSURANCE = row["CO_MONTANTASSURANCE"].ToString();
                        clsCliconsultation.CO_DATESAISIE = row["CO_DATESAISIE"].ToString();
                        clsCliconsultation.CO_DESCRIPTIONREPRESENTANT = row["CO_DESCRIPTIONREPRESENTANT"].ToString();
                        clsCliconsultation.CO_CONTACTREPRESENTANT = row["CO_CONTACTREPRESENTANT"].ToString();
                        clsCliconsultation.CO_DATESORTIE = row["CO_DATESORTIE"].ToString();
                        clsCliconsultation.CO_TAUXMEDECIN = row["CO_TAUXMEDECIN"].ToString();
                        clsCliconsultation.CO_MONTANTMEDECIN = row["CO_MONTANTMEDECIN"].ToString();

                        clsCliconsultation.TI_NUMTIERSMEDECIN = row["TI_NUMTIERSMEDECIN"].ToString();
                        clsCliconsultation.TI_DENOMINATIONMEDECIN = row["TI_DENOMINATIONMEDECIN"].ToString();
                        clsCliconsultation.TI_TELEPHONEMEDECIN = row["TI_TELEPHONEMEDECIN"].ToString();
                        clsCliconsultation.TI_NUMTIERSPATIENT = row["TI_NUMTIERSPATIENT"].ToString();
                        clsCliconsultation.TI_DENOMINATIONPATIENT = row["TI_DENOMINATIONPATIENT"].ToString();
                        clsCliconsultation.TI_TELEPHONEPATIENT = row["TI_TELEPHONEPATIENT"].ToString();
                        clsCliconsultation.MD_LIBELLEMODEADMISSION = row["MD_LIBELLEMODEADMISSION"].ToString();
                        clsCliconsultation.TY_LIBELLETYPECONSULTATION = row["TY_LIBELLETYPECONSULTATION"].ToString();
                        clsCliconsultation.SR_LIBELLE = row["SR_LIBELLE"].ToString();
                        //private string _MD_LIBELLEMODEADMISSION = "";
                        //private string _TY_LIBELLETYPECONSULTATION = "";
                        //private string _SR_LIBELLE = "";


                        clsCliconsultation.CO_CODECONSULTATION = row["CO_CODECONSULTATION"].ToString();
                    clsCliconsultation.CO_NUMERODOSSIER = row["CO_NUMERODOSSIER"].ToString();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCliconsultations.Add(clsCliconsultation);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliconsultation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            clsCliconsultations.Add(clsCliconsultation);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliconsultation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            clsCliconsultations.Add(clsCliconsultation);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCliconsultations;
            }






        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliconsultation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCliconsultation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCliconsultations = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
        //    //--TEST CONTRAINTE
        //    clsCliconsultations = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCliconsultations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliconsultations;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCliconsultationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                    clsCliconsultation.CO_CODECONSULTATION = row["CO_CODECONSULTATION"].ToString();
                    clsCliconsultation.CO_NUMERODOSSIER = row["CO_NUMERODOSSIER"].ToString();
                    clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliconsultation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCliconsultations.Add(clsCliconsultation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCliconsultations.Add(clsCliconsultation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliconsultation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            clsCliconsultations.Add(clsCliconsultation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliconsultation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            clsCliconsultations.Add(clsCliconsultation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCliconsultations;
    }


        
    }
}
