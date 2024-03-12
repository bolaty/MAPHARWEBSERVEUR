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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsMicbudgetparamtype" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsMicbudgetparamtype.svc ou wsMicbudgetparamtype.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsMicbudgetparamtype : IwsMicbudgetparamtype
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsMicbudgetparamtypeWSBLL clsMicbudgetparamtypeWSBLL = new clsMicbudgetparamtypeWSBLL();

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
        public List<HT_Stock.BOJ.clsMicbudgetparamtype> pvgAjouter(List<HT_Stock.BOJ.clsMicbudgetparamtype> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparamtypes = TestChampObligatoireInsert1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
                //--TEST CONTRAINTE
                clsMicbudgetparamtypes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtypeDTO in Objet)
                {
                    Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new Stock.BOJ.clsMicbudgetparamtype();
                    //clsMicbudgetparamtype.BT_CODETYPEBUDGET = clsMicbudgetparamtypeDTO.BT_CODETYPEBUDGET.ToString();
                    clsMicbudgetparamtype.BT_LIBELLE = clsMicbudgetparamtypeDTO.BT_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsMicbudgetparamtypeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMicbudgetparamtypeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsMicbudgetparamtypeWSBLL.pvgAjouter(clsDonnee, clsMicbudgetparamtype, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparamtypes;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparamtype> pvgModifier(List<HT_Stock.BOJ.clsMicbudgetparamtype> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparamtypes = TestChampObligatoireUpdate1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
                //--TEST CONTRAINTE
                clsMicbudgetparamtypes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtypeDTO in Objet)
                {
                    Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.BT_CODETYPEBUDGET = clsMicbudgetparamtypeDTO.BT_CODETYPEBUDGET.ToString();
                    clsMicbudgetparamtype.BT_LIBELLE = clsMicbudgetparamtypeDTO.BT_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsMicbudgetparamtypeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsMicbudgetparamtypeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsMicbudgetparamtypeDTO.BT_CODETYPEBUDGET };
                    clsObjetRetour.SetValue(true, clsMicbudgetparamtypeWSBLL.pvgModifier(clsDonnee, clsMicbudgetparamtype, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparamtypes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparamtype> pvgSupprimer(List<HT_Stock.BOJ.clsMicbudgetparamtype> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMicbudgetparamtypes = TestChampObligatoireDelete1(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
                //--TEST CONTRAINTE
                clsMicbudgetparamtypes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].BT_CODETYPEBUDGET };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsMicbudgetparamtypeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparamtypes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparamtype> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsMicbudgetparamtype> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsMicbudgetparamtypes = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
            //    //--TEST CONTRAINTE
            //    clsMicbudgetparamtypes = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
            //}


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].BT_CODETYPEBUDGET , Objet[0].BT_LIBELLE };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsMicbudgetparamtypeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                        clsMicbudgetparamtype.BT_CODETYPEBUDGET = row["BT_CODETYPEBUDGET"].ToString();
                        clsMicbudgetparamtype.BT_LIBELLE = row["BT_LIBELLE"].ToString();
                        clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                        clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMicbudgetparamtypes;
        }





        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMicbudgetparamtype> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsMicbudgetparamtype> Objet)
    {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
           // clsMicbudgetparamtypes = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
            //--TEST CONTRAINTE
          //  clsMicbudgetparamtypes = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
           // if (clsMicbudgetparamtypes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMicbudgetparamtypes;
        }

      
        clsObjetEnvoi.OE_PARAM= new string[] {  };
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsMicbudgetparamtypeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                    clsMicbudgetparamtype.BT_CODETYPEBUDGET = row["BT_CODETYPEBUDGET"].ToString();
                    clsMicbudgetparamtype.BT_LIBELLE = row["BT_LIBELLE"].ToString();
                    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                }
            }
            else
            {
                HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
            clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
            clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsMicbudgetparamtypes;
    }


        
    }
}
