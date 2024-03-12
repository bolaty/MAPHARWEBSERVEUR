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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtpartauxauto" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtpartauxauto.svc ou wsCtpartauxauto.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtpartauxauto : IwsCtpartauxauto
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpartauxautoWSBLL clsCtpartauxautoWSBLL = new clsCtpartauxautoWSBLL();

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
        public List<HT_Stock.BOJ.clsCtpartauxauto> pvgAjouter(List<HT_Stock.BOJ.clsCtpartauxauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartauxautos = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
                //--TEST CONTRAINTE
                clsCtpartauxautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxautoDTO in Objet)
                {
                    Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.TX_CODETAUX =double.Parse( clsCtpartauxautoDTO.TX_CODETAUX.ToString());
                    clsCtpartauxauto.TX_TAUX =decimal.Parse( clsCtpartauxautoDTO.TX_TAUX.ToString());
                    clsObjetEnvoi.OE_A = clsCtpartauxautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpartauxautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtpartauxautoWSBLL.pvgAjouter(clsDonnee, clsCtpartauxauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartauxautos.Add(clsCtpartauxauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartauxautos.Add(clsCtpartauxauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                clsCtpartauxautos.Add(clsCtpartauxauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                clsCtpartauxautos.Add(clsCtpartauxauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartauxautos;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartauxauto> pvgModifier(List<HT_Stock.BOJ.clsCtpartauxauto> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartauxautos = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
                //--TEST CONTRAINTE
                clsCtpartauxautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxautoDTO in Objet)
                {
                    Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.TX_CODETAUX =double.Parse( clsCtpartauxautoDTO.TX_CODETAUX.ToString());
                    clsCtpartauxauto.TX_TAUX =decimal.Parse( clsCtpartauxautoDTO.TX_TAUX.ToString());
                    clsObjetEnvoi.OE_A = clsCtpartauxautoDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpartauxautoDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtpartauxautoDTO.TX_CODETAUX };
                    clsObjetRetour.SetValue(true, clsCtpartauxautoWSBLL.pvgModifier(clsDonnee, clsCtpartauxauto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartauxautos.Add(clsCtpartauxauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartauxautos.Add(clsCtpartauxauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                clsCtpartauxautos.Add(clsCtpartauxauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                clsCtpartauxautos.Add(clsCtpartauxauto);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartauxautos;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartauxauto> pvgSupprimer(List<HT_Stock.BOJ.clsCtpartauxauto> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartauxautos = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
                //--TEST CONTRAINTE
                clsCtpartauxautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TX_CODETAUX };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtpartauxautoWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartauxautos.Add(clsCtpartauxauto);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartauxautos.Add(clsCtpartauxauto);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                clsCtpartauxautos.Add(clsCtpartauxauto);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
                clsCtpartauxautos.Add(clsCtpartauxauto);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartauxautos;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtpartauxauto> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtpartauxauto> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartauxautos = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
                //--TEST CONTRAINTE
                clsCtpartauxautos = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].DATEDEBUT,Objet[0].DATEFIN,"01" };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpartauxautoWSBLL.pvgChargerDansDataSetSelonDuree(clsDonnee, clsObjetEnvoi);
            clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.TX_CODETAUX = row["TX_CODETAUX"].ToString();
                    clsCtpartauxauto.TX_TAUX = row["TX_TAUX"].ToString();

                    clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpartauxautos.Add(clsCtpartauxauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpartauxautos.Add(clsCtpartauxauto);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
            clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            clsCtpartauxautos.Add(clsCtpartauxauto);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
            clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            clsCtpartauxautos.Add(clsCtpartauxauto);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartauxautos;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartauxauto> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtpartauxauto> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtpartauxautos = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
        //    //--TEST CONTRAINTE
        //    clsCtpartauxautos = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpartauxautos[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartauxautos;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpartauxautoWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                    clsCtpartauxauto.TX_CODETAUX = row["TX_CODETAUX"].ToString();
                    clsCtpartauxauto.TX_TAUX = row["TX_TAUX"].ToString();
                    clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpartauxautos.Add(clsCtpartauxauto);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpartauxautos.Add(clsCtpartauxauto);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
            clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            clsCtpartauxautos.Add(clsCtpartauxauto);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
            clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            clsCtpartauxautos.Add(clsCtpartauxauto);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpartauxautos;
    }


        
    }
}
