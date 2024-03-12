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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCtpartypecontratsante" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCtpartypecontratsante.svc ou wsCtpartypecontratsante.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCtpartypecontratsante : IwsCtpartypecontratsante
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCtpartypecontratsanteWSBLL clsCtpartypecontratsanteWSBLL = new clsCtpartypecontratsanteWSBLL();

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
        public List<HT_Stock.BOJ.clsCtpartypecontratsante> pvgAjouter(List<HT_Stock.BOJ.clsCtpartypecontratsante> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartypecontratsantes = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
                //--TEST CONTRAINTE
                clsCtpartypecontratsantes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsanteDTO in Objet)
                {
                    Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE = clsCtpartypecontratsanteDTO.TA_CODETYPECONTRATSANTE.ToString();
                    clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE = clsCtpartypecontratsanteDTO.TA_LIBELLETYPECONTRATSANTE.ToString();
                    clsObjetEnvoi.OE_A = clsCtpartypecontratsanteDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpartypecontratsanteDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCtpartypecontratsanteWSBLL.pvgAjouter(clsDonnee, clsCtpartypecontratsante, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartypecontratsantes;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartypecontratsante> pvgModifier(List<HT_Stock.BOJ.clsCtpartypecontratsante> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartypecontratsantes = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
                //--TEST CONTRAINTE
                clsCtpartypecontratsantes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsanteDTO in Objet)
                {
                    Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE = clsCtpartypecontratsanteDTO.TA_CODETYPECONTRATSANTE.ToString();
                    clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE = clsCtpartypecontratsanteDTO.TA_LIBELLETYPECONTRATSANTE.ToString();
                    clsObjetEnvoi.OE_A = clsCtpartypecontratsanteDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCtpartypecontratsanteDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCtpartypecontratsanteDTO.TA_CODETYPECONTRATSANTE };
                    clsObjetRetour.SetValue(true, clsCtpartypecontratsanteWSBLL.pvgModifier(clsDonnee, clsCtpartypecontratsante, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartypecontratsantes;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartypecontratsante> pvgSupprimer(List<HT_Stock.BOJ.clsCtpartypecontratsante> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCtpartypecontratsantes = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
                //--TEST CONTRAINTE
                clsCtpartypecontratsantes = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].TA_CODETYPECONTRATSANTE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCtpartypecontratsanteWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                }
                else
                {
                    HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartypecontratsantes;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCtpartypecontratsante> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtpartypecontratsante> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCtpartypecontratsantes = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
            //    //--TEST CONTRAINTE
            //    clsCtpartypecontratsantes = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpartypecontratsanteWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE = row["TA_CODETYPECONTRATSANTE"].ToString();
                    clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE = row["TA_LIBELLETYPECONTRATSANTE"].ToString();
                    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
            clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
            clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCtpartypecontratsantes;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCtpartypecontratsante> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtpartypecontratsante> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCtpartypecontratsantes = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
        //    //--TEST CONTRAINTE
        //    clsCtpartypecontratsantes = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCtpartypecontratsantes[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCtpartypecontratsantes;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCtpartypecontratsanteWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                    clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE = row["TA_CODETYPECONTRATSANTE"].ToString();
                    clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE = row["TA_LIBELLETYPECONTRATSANTE"].ToString();
                    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
            clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
            clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCtpartypecontratsantes;
    }


        
    }
}
