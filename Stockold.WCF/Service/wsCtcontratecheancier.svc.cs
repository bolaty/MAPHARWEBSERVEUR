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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtcontratecheancier" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtcontratecheancier.svc ou wsCtcontratecheancier.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtcontratecheancier : IwsCtcontratecheancier
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtcontratecheancierWSBLL clsCtcontratecheancierWSBLL = new clsCtcontratecheancierWSBLL();

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
        public List<HT_Stock.BOJ.clsCtcontratecheancier> pvgAjouter(List<HT_Stock.BOJ.clsCtcontratecheancier> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratecheanciers = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
                //--TEST CONTRAINTE
                clsCtcontratecheanciers = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();


                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].CA_CODECONTRAT };

                if (Objet[0].TYPEOPERATION!="2")
                {
                    clsCtcontratecheancierWSBLL.pvgDeleteInsertion(clsDonnee, clsObjetEnvoi);
                }
                else
                {
                    clsObjetRetour.SetValue(true, clsCtcontratecheancierWSBLL.pvgDeleteInsertion(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                        clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                        clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                        return clsCtcontratecheanciers;
                    }
                    else
                    {
                        HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                        clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                        clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                        clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                        clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                        clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                        return clsCtcontratecheanciers;
                    }
                }

                
                foreach (HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancierDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.AG_CODEAGENCE = clsCtcontratecheancierDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratecheancier.EN_CODEENTREPOT = clsCtcontratecheancierDTO.EN_CODEENTREPOT.ToString();
                    clsCtcontratecheancier.CA_CODECONTRAT = clsCtcontratecheancierDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratecheancier.EC_DATEECHEANCE =DateTime.Parse(clsCtcontratecheancierDTO.EC_DATEECHEANCE.ToString());
                    clsCtcontratecheancier.EC_MONTANTECHEANCE =double.Parse(clsCtcontratecheancierDTO.EC_MONTANTECHEANCE.ToString());

                    clsObjetEnvoi.OE_A = clsCtcontratecheancierDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratecheancierDTO.clsObjetEnvoi.OE_Y;

                    clsObjetRetour.SetValue(true, clsCtcontratecheancierWSBLL.pvgAjouter(clsDonnee, clsCtcontratecheancier, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratecheanciers;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratecheancier> pvgModifier(List<HT_Stock.BOJ.clsCtcontratecheancier> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratecheanciers = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
                //--TEST CONTRAINTE
                clsCtcontratecheanciers = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancierDTO in Objet)
                {
                    Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.AG_CODEAGENCE = clsCtcontratecheancierDTO.AG_CODEAGENCE.ToString();
                    clsCtcontratecheancier.EN_CODEENTREPOT = clsCtcontratecheancierDTO.EN_CODEENTREPOT.ToString();
                    clsCtcontratecheancier.CA_CODECONTRAT = clsCtcontratecheancierDTO.CA_CODECONTRAT.ToString();
                    clsCtcontratecheancier.EC_DATEECHEANCE = DateTime.Parse(clsCtcontratecheancierDTO.EC_DATEECHEANCE.ToString());
                    clsCtcontratecheancier.EC_MONTANTECHEANCE = double.Parse(clsCtcontratecheancierDTO.EC_MONTANTECHEANCE.ToString());
                    clsObjetEnvoi.OE_A = clsCtcontratecheancierDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtcontratecheancierDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtcontratecheancierDTO.CA_CODECONTRAT };
                    clsObjetRetour.SetValue(true, clsCtcontratecheancierWSBLL.pvgModifier(clsDonnee, clsCtcontratecheancier, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratecheanciers;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratecheancier> pvgSupprimer(List<HT_Stock.BOJ.clsCtcontratecheancier> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratecheanciers = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
                //--TEST CONTRAINTE
                clsCtcontratecheanciers = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
            }


            clsObjetEnvoi.OE_PARAM = new string[] {Objet[0].AG_CODEAGENCE, Objet[0].CA_CODECONTRAT , Objet[0].EC_DATEECHEANCE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtcontratecheancierWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                }
                else
                {
                    HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratecheanciers;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtcontratecheancier> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtcontratecheancier> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtcontratecheanciers = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
                //--TEST CONTRAINTE
                clsCtcontratecheanciers = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE , Objet[0].CA_CODECONTRAT  };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratecheancierWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtcontratecheancier.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                   clsCtcontratecheancier.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                        clsCtcontratecheancier.EC_DATEECHEANCE = (row["EC_DATEECHEANCE"].ToString() != "") ? DateTime.Parse(row["EC_DATEECHEANCE"].ToString()).ToShortDateString(): "";
                        clsCtcontratecheancier.EC_DATEECHEANCE = (clsCtcontratecheancier.EC_DATEECHEANCE != "01-01-1900") ? clsCtcontratecheancier.EC_DATEECHEANCE : "";
                        clsCtcontratecheancier.EC_MONTANTECHEANCENF = Double.Parse(row["EC_MONTANTECHEANCE"].ToString()).ToString();// row["EC_MONTANTECHEANCE"].ToString();
                        clsCtcontratecheancier.EC_MONTANTECHEANCE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["EC_MONTANTECHEANCE"].ToString()).ToString(), "M");// row["EC_MONTANTECHEANCE"].ToString();

                        clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
            clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
            clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtcontratecheanciers;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtcontratecheancier> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtcontratecheancier> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtcontratecheanciers = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
        //    //--TEST CONTRAINTE
        //    clsCtcontratecheanciers = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtcontratecheanciers[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtcontratecheanciers;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtcontratecheancierWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                    clsCtcontratecheancier.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                    clsCtcontratecheancier.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                    clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
            clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            clsCtcontratecheanciers.Add(clsCtcontratecheancier);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
            clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            clsCtcontratecheanciers.Add(clsCtcontratecheancier);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtcontratecheanciers;
    }


        
    }
}
