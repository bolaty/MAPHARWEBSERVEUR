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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtparduree" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtparduree.svc ou wsCtparduree.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtparduree : IwsCtparduree
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpardureeWSBLL clsCtpardureeWSBLL = new clsCtpardureeWSBLL();

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
        public List<HT_Stock.BOJ.clsCtparduree> pvgAjouter(List<HT_Stock.BOJ.clsCtparduree> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpardurees = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
                //--TEST CONTRAINTE
                clsCtpardurees = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparduree clsCtpardureeDTO in Objet)
                {
                    Stock.BOJ.clsCtparduree clsCtparduree = new Stock.BOJ.clsCtparduree();
                    clsCtparduree.DU_CODEDUREE = clsCtpardureeDTO.DU_CODEDUREE.ToString();
                    clsCtparduree.DU_LIBELLEDUREE = clsCtpardureeDTO.DU_LIBELLEDUREE.ToString();
                    clsObjetEnvoi.OE_A = clsCtpardureeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpardureeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtpardureeWSBLL.pvgAjouter(clsDonnee, clsCtparduree, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparduree.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpardurees.Add(clsCtparduree);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparduree.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpardurees.Add(clsCtparduree);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                clsCtpardurees.Add(clsCtparduree);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                clsCtpardurees.Add(clsCtparduree);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpardurees;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparduree> pvgModifier(List<HT_Stock.BOJ.clsCtparduree> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpardurees = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
                //--TEST CONTRAINTE
                clsCtpardurees = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtparduree clsCtpardureeDTO in Objet)
                {
                    Stock.BOJ.clsCtparduree clsCtparduree = new Stock.BOJ.clsCtparduree();
                    clsCtparduree.DU_CODEDUREE = clsCtpardureeDTO.DU_CODEDUREE.ToString();
                    clsCtparduree.DU_LIBELLEDUREE = clsCtpardureeDTO.DU_LIBELLEDUREE.ToString();
                    clsObjetEnvoi.OE_A = clsCtpardureeDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpardureeDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtpardureeDTO.DU_CODEDUREE };
                    clsObjetRetour.SetValue(true, clsCtpardureeWSBLL.pvgModifier(clsDonnee, clsCtparduree, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparduree.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpardurees.Add(clsCtparduree);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparduree.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpardurees.Add(clsCtparduree);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                clsCtpardurees.Add(clsCtparduree);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                clsCtpardurees.Add(clsCtparduree);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpardurees;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparduree> pvgSupprimer(List<HT_Stock.BOJ.clsCtparduree> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpardurees = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
                //--TEST CONTRAINTE
                clsCtpardurees = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].DU_CODEDUREE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtpardureeWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparduree.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpardurees.Add(clsCtparduree);
                }
                else
                {
                    HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtparduree.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpardurees.Add(clsCtparduree);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                clsCtpardurees.Add(clsCtparduree);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
                clsCtpardurees.Add(clsCtparduree);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpardurees;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtparduree> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparduree> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtpardurees = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
            //    //--TEST CONTRAINTE
            //    clsCtpardurees = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpardureeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                    clsCtparduree.DU_CODEDUREE = row["DU_CODEDUREE"].ToString();
                    clsCtparduree.DU_LIBELLEDUREE = row["DU_LIBELLEDUREE"].ToString();
                    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparduree.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpardurees.Add(clsCtparduree);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpardurees.Add(clsCtparduree);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
            clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparduree.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            clsCtpardurees.Add(clsCtparduree);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
            clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparduree.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            clsCtpardurees.Add(clsCtparduree);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpardurees;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtparduree> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparduree> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtpardurees = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
        //    //--TEST CONTRAINTE
        //    clsCtpardurees = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpardurees[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpardurees;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpardureeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                    clsCtparduree.DU_CODEDUREE = row["DU_CODEDUREE"].ToString();
                    clsCtparduree.DU_LIBELLEDUREE = row["DU_LIBELLEDUREE"].ToString();
                    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtparduree.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpardurees.Add(clsCtparduree);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpardurees.Add(clsCtparduree);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
            clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparduree.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            clsCtpardurees.Add(clsCtparduree);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
            clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtparduree.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtparduree.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            clsCtpardurees.Add(clsCtparduree);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpardurees;
    }


        
    }
}
