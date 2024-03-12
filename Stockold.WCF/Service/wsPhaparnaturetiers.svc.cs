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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhaparnaturetiers" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhaparnaturetiers.svc ou wsPhaparnaturetiers.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhaparnaturetiers : IwsPhaparnaturetiers
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhaparnaturetiersWSBLL clsPhaparnaturetiersWSBLL = new clsPhaparnaturetiersWSBLL();

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
        public List<HT_Stock.BOJ.clsPhaparnaturetiers> pvgAjouter(List<HT_Stock.BOJ.clsPhaparnaturetiers> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparnaturetierss = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
                //--TEST CONTRAINTE
                clsPhaparnaturetierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiersDTO in Objet)
                {
                    Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.NT_CODENATURETIERS = clsPhaparnaturetiersDTO.NT_CODENATURETIERS.ToString();
                    clsPhaparnaturetiers.NT_LIBELLE = clsPhaparnaturetiersDTO.NT_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparnaturetiersDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparnaturetiersDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhaparnaturetiersWSBLL.pvgAjouter(clsDonnee, clsPhaparnaturetiers, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparnaturetierss;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparnaturetiers> pvgModifier(List<HT_Stock.BOJ.clsPhaparnaturetiers> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparnaturetierss = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
                //--TEST CONTRAINTE
                clsPhaparnaturetierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiersDTO in Objet)
                {
                    Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.NT_CODENATURETIERS = clsPhaparnaturetiersDTO.NT_CODENATURETIERS.ToString();
                    clsPhaparnaturetiers.NT_LIBELLE = clsPhaparnaturetiersDTO.NT_LIBELLE.ToString();
                    clsObjetEnvoi.OE_A = clsPhaparnaturetiersDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhaparnaturetiersDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhaparnaturetiersDTO.NT_CODENATURETIERS };
                    clsObjetRetour.SetValue(true, clsPhaparnaturetiersWSBLL.pvgModifier(clsDonnee, clsPhaparnaturetiers, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparnaturetierss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparnaturetiers> pvgSupprimer(List<HT_Stock.BOJ.clsPhaparnaturetiers> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhaparnaturetierss = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
                //--TEST CONTRAINTE
                clsPhaparnaturetierss = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].NT_CODENATURETIERS };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhaparnaturetiersWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                }
                else
                {
                    HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparnaturetierss;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhaparnaturetiers> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhaparnaturetiers> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhaparnaturetierss = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
            //    //--TEST CONTRAINTE
            //    clsPhaparnaturetierss = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparnaturetiersWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
                    clsPhaparnaturetiers.NT_LIBELLE = row["NT_LIBELLE"].ToString();
                    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
            clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
            clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhaparnaturetierss;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhaparnaturetiers> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhaparnaturetiers> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhaparnaturetierss = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
        //    //--TEST CONTRAINTE
        //    clsPhaparnaturetierss = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhaparnaturetierss[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnaturetierss;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparnaturetiersWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                    clsPhaparnaturetiers.NT_CODENATURETIERS = row["NT_CODENATURETIERS"].ToString();
                    clsPhaparnaturetiers.NT_LIBELLE = row["NT_LIBELLE"].ToString();
                    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
            clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
            clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhaparnaturetierss;
    }


        
    }
}
