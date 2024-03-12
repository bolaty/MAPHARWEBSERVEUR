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

using Stock.BOJ;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsBienimmobilisefamille" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsBienimmobilisefamille.svc ou wsBienimmobilisefamille.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsBienimmobilisefamille : IwsBienimmobilisefamille
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsBienimmobilisefamilleWSBLL clsBienimmobilisefamilleWSBLL = new clsBienimmobilisefamilleWSBLL();

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
        public List<HT_Stock.BOJ.clsBienimmobilisefamille> pvgAjouter(List<HT_Stock.BOJ.clsBienimmobilisefamille> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBienimmobilisefamilles = TestChampObligatoireInsert1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
                //--TEST CONTRAINTE
                clsBienimmobilisefamilles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamilleDTO in Objet)
                {
                    Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.PS_CODESOUSPRODUIT = clsBienimmobilisefamilleDTO.PS_CODESOUSPRODUIT.ToString();
                    clsBienimmobilisefamille.PS_LIBELLE = clsBienimmobilisefamilleDTO.PS_LIBELLE.ToString();
                    clsBienimmobilisefamille.PL_CODENUMCOMPTE = clsBienimmobilisefamilleDTO.PL_CODENUMCOMPTE.ToString();
                    clsBienimmobilisefamille.NT_CODENATUREBIEN = clsBienimmobilisefamilleDTO.NT_CODENATUREBIEN.ToString();
                    clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = clsBienimmobilisefamilleDTO.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT.ToString();
                    clsBienimmobilisefamille.PS_NUMEROORDRE = int.Parse(clsBienimmobilisefamilleDTO.PS_NUMEROORDRE.ToString());
                    clsBienimmobilisefamille.PS_DUREEMINIMUM =  int.Parse(clsBienimmobilisefamilleDTO.PS_DUREEMINIMUM.ToString());
                    clsBienimmobilisefamille.PS_DUREEMAXIMUM = int.Parse(clsBienimmobilisefamilleDTO.PS_DUREEMAXIMUM.ToString());
                    clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT = clsBienimmobilisefamilleDTO.PS_AMORTISSEMENTDIRECT.ToString();
                    clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN = clsBienimmobilisefamilleDTO.PS_AMORTISSEMENTBIEN.ToString();
                    clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO = int.Parse(clsBienimmobilisefamilleDTO.PS_AMORTISSEMENTVALEURRESIDUELLEZERO.ToString());
                    clsBienimmobilisefamille.PS_ACTIF = clsBienimmobilisefamilleDTO.PS_ACTIF.ToString();
                    clsBienimmobilisefamille.PS_DATESAISIE = DateTime.Parse(clsBienimmobilisefamilleDTO.PS_DATESAISIE.ToString());
                    clsObjetEnvoi.OE_A = clsBienimmobilisefamilleDTO.clsObjetEnvoi.OE_A; 
                    clsObjetEnvoi.OE_Y = clsBienimmobilisefamilleDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsBienimmobilisefamilleWSBLL.pvgAjouter(clsDonnee, clsBienimmobilisefamille, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }
                else
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBienimmobilisefamilles;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBienimmobilisefamille> pvgModifier(List<HT_Stock.BOJ.clsBienimmobilisefamille> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBienimmobilisefamilles = TestChampObligatoireUpdate1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
                //--TEST CONTRAINTE
                clsBienimmobilisefamilles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamilleDTO in Objet)
                {
                    Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.PS_CODESOUSPRODUIT = clsBienimmobilisefamilleDTO.PS_CODESOUSPRODUIT.ToString();
                    clsBienimmobilisefamille.PS_LIBELLE = clsBienimmobilisefamilleDTO.PS_LIBELLE.ToString();
                    clsBienimmobilisefamille.PL_CODENUMCOMPTE = clsBienimmobilisefamilleDTO.PL_CODENUMCOMPTE.ToString();
                    clsBienimmobilisefamille.NT_CODENATUREBIEN = clsBienimmobilisefamilleDTO.NT_CODENATUREBIEN.ToString();
                    clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = clsBienimmobilisefamilleDTO.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT.ToString();
                    clsBienimmobilisefamille.PS_NUMEROORDRE = int.Parse(clsBienimmobilisefamilleDTO.PS_NUMEROORDRE.ToString());
                    clsBienimmobilisefamille.PS_DUREEMINIMUM = int.Parse(clsBienimmobilisefamilleDTO.PS_DUREEMINIMUM.ToString());
                    clsBienimmobilisefamille.PS_DUREEMAXIMUM = int.Parse(clsBienimmobilisefamilleDTO.PS_DUREEMAXIMUM.ToString());
                    clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT = clsBienimmobilisefamilleDTO.PS_AMORTISSEMENTDIRECT.ToString();
                    clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN = clsBienimmobilisefamilleDTO.PS_AMORTISSEMENTBIEN.ToString();
                    clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO = int.Parse(clsBienimmobilisefamilleDTO.PS_AMORTISSEMENTVALEURRESIDUELLEZERO.ToString());
                    clsBienimmobilisefamille.PS_ACTIF = clsBienimmobilisefamilleDTO.PS_ACTIF.ToString();
                    clsBienimmobilisefamille.PS_DATESAISIE = DateTime.Parse(clsBienimmobilisefamilleDTO.PS_DATESAISIE.ToString());
                    clsObjetEnvoi.OE_A = clsBienimmobilisefamilleDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsBienimmobilisefamilleDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsBienimmobilisefamilleDTO.PS_CODESOUSPRODUIT };
                    clsObjetRetour.SetValue(true, clsBienimmobilisefamilleWSBLL.pvgModifier(clsDonnee, clsBienimmobilisefamille, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }
                else
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBienimmobilisefamilles;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBienimmobilisefamille> pvgSupprimer(List<HT_Stock.BOJ.clsBienimmobilisefamille> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBienimmobilisefamilles = TestChampObligatoireDelete1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
                //--TEST CONTRAINTE
                clsBienimmobilisefamilles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PS_CODESOUSPRODUIT };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsBienimmobilisefamilleWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }
                else
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBienimmobilisefamilles;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBienimmobilisefamille> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsBienimmobilisefamille> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBienimmobilisefamilles = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
                //--TEST CONTRAINTE
                clsBienimmobilisefamilles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].NT_CODENATUREBIEN };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsBienimmobilisefamilleWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                        clsBienimmobilisefamille.PS_CODESOUSPRODUIT = row["PS_CODESOUSPRODUIT"].ToString();
                        clsBienimmobilisefamille.PS_LIBELLE = row["PS_LIBELLE"].ToString();
                        clsBienimmobilisefamille.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                        clsBienimmobilisefamille.NT_CODENATUREBIEN = row["NT_CODENATUREBIEN"].ToString();
                       // clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = row["PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT"].ToString();
                        clsBienimmobilisefamille.PS_DUREEMINIMUM = row["PS_DUREEMINIMUM"].ToString();
                        clsBienimmobilisefamille.PS_DUREEMAXIMUM = row["PS_DUREEMAXIMUM"].ToString();
                        clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT = row["PS_AMORTISSEMENTDIRECT"].ToString();
                        clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN = row["PS_AMORTISSEMENTBIEN"].ToString();
                        clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO = row["PS_AMORTISSEMENTVALEURRESIDUELLEZERO"].ToString();
                        clsBienimmobilisefamille.PS_ACTIF = row["PS_ACTIF"].ToString();
                        clsBienimmobilisefamille.PS_NUMEROORDRE = row["PS_NUMEROORDRE"].ToString();
                        clsBienimmobilisefamille.PS_DATESAISIE = DateTime.Parse(row["PS_DATESAISIE"].ToString()).ToShortDateString();
                        clsBienimmobilisefamille.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                        clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                        clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsBienimmobilisefamilles;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsBienimmobilisefamille> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsBienimmobilisefamille> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsBienimmobilisefamilles = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
                //--TEST CONTRAINTE
                clsBienimmobilisefamilles = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsBienimmobilisefamilles[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsBienimmobilisefamilles;
            }

      
        clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].NT_CODENATUREBIEN, "" };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsBienimmobilisefamilleWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                    clsBienimmobilisefamille.PS_CODESOUSPRODUIT = row["PS_CODESOUSPRODUIT"].ToString();
                    clsBienimmobilisefamille.PS_LIBELLE = row["PS_LIBELLE"].ToString();
                        
                        clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                }
            }
            else
            {
                HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
            clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
            clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsBienimmobilisefamilles;
    }


        
    }
}
