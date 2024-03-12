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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtsinistre" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtsinistre.svc ou wsCtsinistre.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtsinistre : IwsCtsinistre
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtsinistreWSBLL clsCtsinistreWSBLL = new clsCtsinistreWSBLL();

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
        public List<HT_Stock.BOJ.clsCtsinistre> pvgAjouter(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {
            
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistre clsCtsinistreDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistre clsCtsinistre = new Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.SI_CODESINISTRE = clsCtsinistreDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistre.AG_CODEAGENCE = clsCtsinistreDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistre.EN_CODEENTREPOT = clsCtsinistreDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistre.NS_CODENATURESINISTRE = clsCtsinistreDTO.NS_CODENATURESINISTRE.ToString();
                    clsCtsinistre.CA_CODECONTRAT = clsCtsinistreDTO.CA_CODECONTRAT.ToString();
                    clsCtsinistre.SI_NUMSINISTRE = clsCtsinistreDTO.SI_NUMSINISTRE.ToString();
                    clsCtsinistre.SI_DATESAISIE =DateTime.Parse(clsCtsinistreDTO.SI_DATESAISIE.ToString());
                    clsCtsinistre.SI_DATESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATESINISTRE.ToString());
                    clsCtsinistre.SI_HEURESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_HEURESINISTRE.ToString());
                    clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = clsCtsinistreDTO.SI_NOMPRENOMSCONDUCTEURSINISTRE.ToString();
                    clsCtsinistre.CO_CODECOMMUNE = clsCtsinistreDTO.CO_CODECOMMUNE.ToString();
                    clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = clsCtsinistreDTO.SI_ADRESSEGEOGRPHIQUESINISTRE.ToString();
                    clsCtsinistre.SI_DESCRIPTIONSINISTRE = clsCtsinistreDTO.SI_DESCRIPTIONSINISTRE.ToString();
                    clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATETRANSMISSIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATEVALIDATIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEVALIDATIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATESUSPENSIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATESUSPENSIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATECLOTURESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATECLOTURESINISTRE.ToString());
                    clsCtsinistre.OP_CODEOPERATEUR =clsCtsinistreDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistre.SI_DOCUMENTTRANSMIS = clsCtsinistreDTO.SI_DOCUMENTTRANSMIS.ToString();
                    clsCtsinistre.SI_MONTANTPREJUDICE =double.Parse( clsCtsinistreDTO.SI_MONTANTPREJUDICE.ToString());
                    clsCtsinistre.EP_CODEEXPERTNOMME = clsCtsinistreDTO.EP_CODEEXPERTNOMME.ToString();
                    clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE =DateTime.Parse(clsCtsinistreDTO.SI_DATEEXPERTNOMMESINISTRE.ToString());
                    //clsCtsinistre.TYPEOPERATION =int.Parse(clsCtsinistreDTO.TYPEOPERATION.ToString());
                    clsObjetEnvoi.OE_A = clsCtsinistreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistreDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtsinistreWSBLL.pvgAjouter(clsDonnee, clsCtsinistre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgModifier(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistre clsCtsinistreDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistre clsCtsinistre = new Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.SI_CODESINISTRE = clsCtsinistreDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistre.AG_CODEAGENCE = clsCtsinistreDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistre.EN_CODEENTREPOT = clsCtsinistreDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistre.NS_CODENATURESINISTRE = clsCtsinistreDTO.NS_CODENATURESINISTRE.ToString();
                    clsCtsinistre.CA_CODECONTRAT = clsCtsinistreDTO.CA_CODECONTRAT.ToString();
                    clsCtsinistre.SI_NUMSINISTRE = clsCtsinistreDTO.SI_NUMSINISTRE.ToString();
                    clsCtsinistre.SI_DATESAISIE = DateTime.Parse(clsCtsinistreDTO.SI_DATESAISIE.ToString());
                    clsCtsinistre.SI_DATESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATESINISTRE.ToString());
                    clsCtsinistre.SI_HEURESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_HEURESINISTRE.ToString());
                    clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = clsCtsinistreDTO.SI_NOMPRENOMSCONDUCTEURSINISTRE.ToString();
                    clsCtsinistre.CO_CODECOMMUNE = clsCtsinistreDTO.CO_CODECOMMUNE.ToString();
                    clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = clsCtsinistreDTO.SI_ADRESSEGEOGRPHIQUESINISTRE.ToString();
                    clsCtsinistre.SI_DESCRIPTIONSINISTRE = clsCtsinistreDTO.SI_DESCRIPTIONSINISTRE.ToString();
                    clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATETRANSMISSIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATEVALIDATIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEVALIDATIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATESUSPENSIONSINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATESUSPENSIONSINISTRE.ToString());
                    clsCtsinistre.SI_DATECLOTURESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATECLOTURESINISTRE.ToString());
                    clsCtsinistre.OP_CODEOPERATEUR = clsCtsinistreDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistre.SI_DOCUMENTTRANSMIS = clsCtsinistreDTO.SI_DOCUMENTTRANSMIS.ToString();
                    clsCtsinistre.SI_MONTANTPREJUDICE = double.Parse(clsCtsinistreDTO.SI_MONTANTPREJUDICE.ToString());
                    clsCtsinistre.EP_CODEEXPERTNOMME = clsCtsinistreDTO.EP_CODEEXPERTNOMME.ToString();
                    clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = DateTime.Parse(clsCtsinistreDTO.SI_DATEEXPERTNOMMESINISTRE.ToString());
                    clsCtsinistre.TYPEOPERATION = int.Parse(clsCtsinistreDTO.TYPEOPERATION.ToString());
                    clsObjetEnvoi.OE_A = clsCtsinistreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistreDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtsinistreDTO.SI_CODESINISTRE };
                    clsObjetRetour.SetValue(true, clsCtsinistreWSBLL.pvgModifier(clsDonnee, clsCtsinistre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }


        public List<HT_Stock.BOJ.clsCtsinistre> pvgMiseAjourStatutContrat(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireUpdateStatut(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }

            Stock.BOJ.clsCtsinistre clsCtsinistre1 = new Stock.BOJ.clsCtsinistre();
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            //List<Stock.BOJ.clsCtsinistregarantie> clsCtsinistregaranties = new List<BOJ.clsCtsinistregarantie>();
            //List<Stock.BOJ.clsCtsinistreprime> clsCtsinistreprimes = new List<BOJ.clsCtsinistreprime>();
            //List<Stock.BOJ.clsCtsinistrereduction> clsCtsinistrereductions = new List<BOJ.clsCtsinistrereduction>();
            //List<Stock.BOJ.clsCtsinistreayantdroit> clsCtsinistreayantdroits = new List<BOJ.clsCtsinistreayantdroit>();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtsinistre clsCtsinistreDTO in Objet)
                {
                    Stock.BOJ.clsCtsinistre clsCtsinistre = new Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.SI_CODESINISTRE = clsCtsinistreDTO.SI_CODESINISTRE.ToString();
                    clsCtsinistre.AG_CODEAGENCE = clsCtsinistreDTO.AG_CODEAGENCE.ToString();
                    clsCtsinistre.EN_CODEENTREPOT = clsCtsinistreDTO.EN_CODEENTREPOT.ToString();
                    clsCtsinistre.OP_CODEOPERATEUR = clsCtsinistreDTO.OP_CODEOPERATEUR.ToString();
                    clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = (clsCtsinistreDTO.SI_DATETRANSMISSIONSINISTRE.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATETRANSMISSIONSINISTRE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtsinistre.SI_DATEVALIDATIONSINISTRE = (clsCtsinistreDTO.SI_DATEVALIDATIONSINISTRE.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATEVALIDATIONSINISTRE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtsinistre.SI_DATESUSPENSIONSINISTRE = (clsCtsinistreDTO.SI_DATESUSPENSIONSINISTRE.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATESUSPENSIONSINISTRE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtsinistre.SI_DATECLOTURESINISTRE = (clsCtsinistreDTO.SI_DATECLOTURESINISTRE.ToString() != "") ? DateTime.Parse(clsCtsinistreDTO.SI_DATECLOTURESINISTRE.ToString()) : DateTime.Parse("01/01/1900");
                    clsCtsinistre.TYPEOPERATION = int.Parse(clsCtsinistreDTO.TYPEOPERATION.ToString());
                    clsObjetEnvoi.OE_A = clsCtsinistreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtsinistreDTO.clsObjetEnvoi.OE_Y;
                    //=====
                    clsObjetRetour.SetValue(true, clsCtsinistreWSBLL.pvgModifier(clsDonnee, clsCtsinistre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgSupprimer(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].SI_CODESINISTRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtsinistreWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
                else
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
                clsCtsinistres.Add(clsCtsinistre);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtsinistre> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtsinistre> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtsinistres = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
                //--TEST CONTRAINTE
                clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE,Objet[0].EN_CODEENTREPOT,Objet[0].CA_NUMPOLICE,Objet[0].CA_CODECONTRAT,Objet[0].NS_CODENATURESINISTRE, Objet[0].SI_NUMSINISTRE,Objet[0].TI_NUMTIERS, Objet[0].TI_DENOMINATION,Objet[0].DATEDEBUT, Objet[0].DATEFIN,Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistreWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                clsCtsinistre.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                clsCtsinistre.EN_CODEENTREPOT = row["EN_CODEENTREPOT"].ToString();
                clsCtsinistre.NS_CODENATURESINISTRE = row["NS_CODENATURESINISTRE"].ToString();
                clsCtsinistre.CA_CODECONTRAT = row["CA_CODECONTRAT"].ToString();
                clsCtsinistre.SI_NUMSINISTRE = row["SI_NUMSINISTRE"].ToString();
                clsCtsinistre.SI_DATESAISIE = (row["SI_DATESAISIE"].ToString() != "") ? DateTime.Parse(row["SI_DATESAISIE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                clsCtsinistre.SI_DATESAISIE = (clsCtsinistre.SI_DATESAISIE != "01-01-1900") ? clsCtsinistre.SI_DATESAISIE : "";
                clsCtsinistre.SI_DATESINISTRE = (row["SI_DATESINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATESINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                clsCtsinistre.SI_DATESINISTRE = (clsCtsinistre.SI_DATESINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATESINISTRE : "";
                clsCtsinistre.SI_HEURESINISTRE = (row["SI_HEURESINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_HEURESINISTRE"].ToString()).ToShortTimeString() : "";
                clsCtsinistre.SI_HEURESINISTRE = (clsCtsinistre.SI_HEURESINISTRE != "01-01-1900") ? clsCtsinistre.SI_HEURESINISTRE : "";
                clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = row["SI_NOMPRENOMSCONDUCTEURSINISTRE"].ToString();
                clsCtsinistre.CO_CODECOMMUNE = row["CO_CODECOMMUNE"].ToString();
                clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = row["SI_ADRESSEGEOGRPHIQUESINISTRE"].ToString();
                clsCtsinistre.SI_DESCRIPTIONSINISTRE = row["SI_DESCRIPTIONSINISTRE"].ToString();
                clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = (row["SI_DATETRANSMISSIONSINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATETRANSMISSIONSINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = (clsCtsinistre.SI_DATETRANSMISSIONSINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATETRANSMISSIONSINISTRE : "";
                clsCtsinistre.SI_DATEVALIDATIONSINISTRE = (row["SI_DATEVALIDATIONSINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATEVALIDATIONSINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                clsCtsinistre.SI_DATEVALIDATIONSINISTRE = (clsCtsinistre.SI_DATEVALIDATIONSINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATEVALIDATIONSINISTRE : "";
                clsCtsinistre.SI_DATESUSPENSIONSINISTRE = (row["SI_DATESUSPENSIONSINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATESUSPENSIONSINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                clsCtsinistre.SI_DATESUSPENSIONSINISTRE = (clsCtsinistre.SI_DATESUSPENSIONSINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATESUSPENSIONSINISTRE : "";
                clsCtsinistre.SI_DATECLOTURESINISTRE = (row["SI_DATECLOTURESINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATECLOTURESINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                clsCtsinistre.SI_DATECLOTURESINISTRE = (clsCtsinistre.SI_DATECLOTURESINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATECLOTURESINISTRE : "";
                clsCtsinistre.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                clsCtsinistre.SI_DOCUMENTTRANSMIS = row["SI_DOCUMENTTRANSMIS"].ToString();
                clsCtsinistre.SI_MONTANTPREJUDICE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["SI_MONTANTPREJUDICE"].ToString()).ToString(), "M");// row["SI_MONTANTPREJUDICE"].ToString();
                clsCtsinistre.EP_CODEEXPERTNOMME = row["EP_CODEEXPERTNOMME"].ToString();
                clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = (row["SI_DATEEXPERTNOMMESINISTRE"].ToString() != "") ? DateTime.Parse(row["SI_DATEEXPERTNOMMESINISTRE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = (clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE != "01-01-1900") ? clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE : "";
                clsCtsinistre.SI_NOMBRECONTRAT =int.Parse(row["SI_NOMBRECONTRAT"].ToString()).ToString();
                clsCtsinistre.VL_LIBELLE = row["VL_LIBELLE"].ToString();
                clsCtsinistre.PY_LIBELLE = row["PY_LIBELLE"].ToString();
                clsCtsinistre.CO_LIBELLE = row["CO_LIBELLE"].ToString();
                clsCtsinistre.NS_LIBELLENATURESINISTRE = row["NS_LIBELLENATURESINISTRE"].ToString();
                clsCtsinistre.PY_CODEPAYS = row["PY_CODEPAYS"].ToString();
                clsCtsinistre.VL_CODEVILLE = row["VL_CODEVILLE"].ToString();
                clsCtsinistre.SI_MONTANTPREJUDICENF = Double.Parse(row["SI_MONTANTPREJUDICE"].ToString()).ToString();
                clsCtsinistre.SI_MONTANTPREJUDICEVALIDERNF = Double.Parse(row["SI_MONTANTPREJUDICEVALIDER"].ToString()).ToString();
                clsCtsinistre.SI_MONTANTPREJUDICEVALIDER = Double.Parse(row["SI_MONTANTPREJUDICEVALIDER"].ToString()).ToString();
                        clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsCtsinistres.Add(clsCtsinistre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistres.Add(clsCtsinistre);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            clsCtsinistres.Add(clsCtsinistre);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            clsCtsinistres.Add(clsCtsinistre);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtsinistres;
            }

    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgInsertIntoDatasetEtatConsultation(List<HT_Stock.BOJ.clsCtsinistre> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsCtsinistres = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
            //--TEST CONTRAINTE
            clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
        }

            //@AG_CODEAGENCE,@EN_CODEENTREPOT, @MATRICULE,@MS_NUMPIECE,@MC_DATEPIECE1, @MC_DATEPIECE2,@DATEJOURNEE,@TYPEETAT,@OP_CODEOPERATEUREDITION,@NO_CODENATUREOPERATION,
        clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE,Objet[0].EN_CODEENTREPOT,Objet[0].TI_NUMTIERS, Objet[0].MS_NUMPIECE, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].DATEJOURNEE, Objet[0].TYPEOPERATION,Objet[0].OP_CODEOPERATEUR, Objet[0].NO_CODENATUREOPERATION, Objet[0].CA_CODECONTRAT };
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        clsEditionEtatClientFournisseurWSBLL clsEditionEtatClientFournisseurWSBLL = new clsEditionEtatClientFournisseurWSBLL();
        DataSet = clsEditionEtatClientFournisseurWSBLL.pvgInsertIntoDatasetEtatConsultation(clsDonnee, clsObjetEnvoi);
        clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();

                clsCtsinistre.TI_NUMTIERS = row["TI_NUMTIERS"].ToString();
                clsCtsinistre.TI_DENOMINATION = row["TI_DENOMINATION"].ToString();
                clsCtsinistre.TI_TELEPHONE = row["TI_TELEPHONE"].ToString();
                clsCtsinistre.TI_ADRESSEPOSTALE = row["TI_ADRESSEPOSTALE"].ToString();
                clsCtsinistre.TI_ADRESSEGEOGRAPHIQUE = row["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                clsCtsinistre.TP_LIBELLE = row["TP_LIBELLE"].ToString();
                clsCtsinistre.SOLDEPRECEDENT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["SOLDEPRECEDENT"].ToString()).ToString(), "M");
                clsCtsinistre.MONTANTFACTUREINITIAL = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MONTANTFACTUREINITIAL"].ToString()).ToString(), "M");
                clsCtsinistre.MONTANTVERSE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MONTANTVERSE"].ToString()).ToString(), "M");
                clsCtsinistre.MV_SOLDEFINAL = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MV_SOLDEFINAL"].ToString()).ToString(), "M");

                clsCtsinistre.MV_DATEPIECE = (row["MV_DATEPIECE"].ToString() != "") ? DateTime.Parse(row["MV_DATEPIECE"].ToString()).ToShortDateString().Replace("/", "-") : "";
                clsCtsinistre.MV_DATEPIECE = (clsCtsinistre.MV_DATEPIECE != "01-01-1900") ? clsCtsinistre.MV_DATEPIECE : "";
                clsCtsinistre.MS_NUMPIECE = row["MS_NUMPIECE"].ToString();
                clsCtsinistre.NUMEROBORDEREAU = row["NUMEROBORDEREAU"].ToString();
                clsCtsinistre.MV_REFERENCEPIECE = row["MV_REFERENCEPIECE"].ToString();
                clsCtsinistre.MV_LIBELLEOPERATION = row["MV_LIBELLEOPERATION"].ToString();
                clsCtsinistre.MV_MONTANTDEBIT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MV_MONTANTDEBIT"].ToString()).ToString(), "M");
                clsCtsinistre.MV_MONTANTCREDIT = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MV_MONTANTCREDIT"].ToString()).ToString(), "M");
                clsCtsinistre.MV_SOLDE = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Double.Parse(row["MV_SOLDE"].ToString()).ToString(), "M");




                        

                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsCtsinistres.Add(clsCtsinistre);
            }
        }
        else
        {
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsCtsinistres.Add(clsCtsinistre);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
        clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
        clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsCtsinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
        clsCtsinistres.Add(clsCtsinistre);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
        clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
        clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsCtsinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
        clsCtsinistres.Add(clsCtsinistre);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsCtsinistres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtsinistre> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtsinistre> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtsinistres = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
        //    //--TEST CONTRAINTE
        //    clsCtsinistres = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtsinistres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtsinistres;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtsinistreWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                    clsCtsinistre.SI_CODESINISTRE = row["SI_CODESINISTRE"].ToString();
                    clsCtsinistre.SI_NUMSINISTRE = row["SI_NUMSINISTRE"].ToString();
                    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtsinistre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtsinistres.Add(clsCtsinistre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtsinistres.Add(clsCtsinistre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            clsCtsinistres.Add(clsCtsinistre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtsinistre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            clsCtsinistres.Add(clsCtsinistre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtsinistres;
    }


        
    }
}
