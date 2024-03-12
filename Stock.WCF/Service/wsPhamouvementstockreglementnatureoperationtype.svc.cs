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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhamouvementstockreglementnatureoperationtype" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhamouvementstockreglementnatureoperationtype.svc ou wsPhamouvementstockreglementnatureoperationtype.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhamouvementstockreglementnatureoperationtype : IwsPhamouvementstockreglementnatureoperationtype
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhamouvementstockreglementnatureoperationtypeWSBLL clsPhamouvementstockreglementnatureoperationtypeWSBLL = new clsPhamouvementstockreglementnatureoperationtypeWSBLL();

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
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> pvgAjouter(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglementnatureoperationtypes = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglementnatureoperationtypes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtypeDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE = clsPhamouvementstockreglementnatureoperationtypeDTO.RO_CODENATUREOPERATIONTYPE.ToString();
                    clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE = clsPhamouvementstockreglementnatureoperationtypeDTO.RO_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementnatureoperationtypeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementnatureoperationtypeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementnatureoperationtypeWSBLL.pvgAjouter(clsDonnee, clsPhamouvementstockreglementnatureoperationtype, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglementnatureoperationtypes;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> pvgModifier(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglementnatureoperationtypes = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglementnatureoperationtypes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtypeDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE = clsPhamouvementstockreglementnatureoperationtypeDTO.RO_CODENATUREOPERATIONTYPE.ToString();
                    clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE = clsPhamouvementstockreglementnatureoperationtypeDTO.RO_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementnatureoperationtypeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementnatureoperationtypeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhamouvementstockreglementnatureoperationtypeDTO.RO_CODENATUREOPERATIONTYPE };
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementnatureoperationtypeWSBLL.pvgModifier(clsDonnee, clsPhamouvementstockreglementnatureoperationtype, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglementnatureoperationtypes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> pvgSupprimer(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglementnatureoperationtypes = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglementnatureoperationtypes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].RO_CODENATUREOPERATIONTYPE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhamouvementstockreglementnatureoperationtypeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglementnatureoperationtypes;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhamouvementstockreglementnatureoperationtypes = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
            //    //--TEST CONTRAINTE
            //    clsPhamouvementstockreglementnatureoperationtypes = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockreglementnatureoperationtypeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE = row["RO_CODENATUREOPERATIONTYPE"].ToString();
                    clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE = row["RO_LIBELLE"].ToString();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglementnatureoperationtypes;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhamouvementstockreglementnatureoperationtypes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
        //    //--TEST CONTRAINTE
        //    clsPhamouvementstockreglementnatureoperationtypes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockreglementnatureoperationtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperationtypes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockreglementnatureoperationtypeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                    clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE = row["RO_CODENATUREOPERATIONTYPE"].ToString();
                    clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE = row["RO_LIBELLE"].ToString();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhamouvementstockreglementnatureoperationtypes;
    }


        
    }
}
