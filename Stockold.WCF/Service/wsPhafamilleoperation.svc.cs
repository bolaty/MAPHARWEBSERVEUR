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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhafamilleoperation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhafamilleoperation.svc ou wsPhafamilleoperation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhafamilleoperation : IwsPhafamilleoperation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhafamilleoperationWSBLL clsPhafamilleoperationWSBLL = new clsPhafamilleoperationWSBLL();

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
        public List<HT_Stock.BOJ.clsPhafamilleoperation> pvgAjouter(List<HT_Stock.BOJ.clsPhafamilleoperation> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhafamilleoperations = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
                //--TEST CONTRAINTE
                clsPhafamilleoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperationDTO in Objet)
                {
                    Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.FO_CODEFAMILLEOPERATION = clsPhafamilleoperationDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION = clsPhafamilleoperationDTO.FO_LIBELLEFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsPhafamilleoperationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhafamilleoperationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhafamilleoperationWSBLL.pvgAjouter(clsDonnee, clsPhafamilleoperation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhafamilleoperations;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhafamilleoperation> pvgModifier(List<HT_Stock.BOJ.clsPhafamilleoperation> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhafamilleoperations = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
                //--TEST CONTRAINTE
                clsPhafamilleoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperationDTO in Objet)
                {
                    Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.FO_CODEFAMILLEOPERATION = clsPhafamilleoperationDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION = clsPhafamilleoperationDTO.FO_LIBELLEFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsPhafamilleoperationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhafamilleoperationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhafamilleoperationDTO.FO_CODEFAMILLEOPERATION };
                    clsObjetRetour.SetValue(true, clsPhafamilleoperationWSBLL.pvgModifier(clsDonnee, clsPhafamilleoperation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhafamilleoperations;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhafamilleoperation> pvgSupprimer(List<HT_Stock.BOJ.clsPhafamilleoperation> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhafamilleoperations = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
                //--TEST CONTRAINTE
                clsPhafamilleoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].FO_CODEFAMILLEOPERATION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhafamilleoperationWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhafamilleoperations;
        }





            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhafamilleoperation> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhafamilleoperation> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhafamilleoperations = TestChampObligatoireListeTreso(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
                //--TEST CONTRAINTE
                clsPhafamilleoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE,Objet[0].NF_CODENATUREFAMILLEOPERATION, Objet[0].OP_CODEOPERATEUR };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhafamilleoperationWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION = row["FO_LIBELLEFAMILLEOPERATION"].ToString();
                    clsPhafamilleoperation.FO_NUMEROORDRE = row["FO_NUMEROORDRE"].ToString();
                    clsPhafamilleoperation.COCHER = row["COCHER"].ToString();

                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhafamilleoperations;
            }




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhafamilleoperation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhafamilleoperation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhafamilleoperations = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
                //--TEST CONTRAINTE
                clsPhafamilleoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhafamilleoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhafamilleoperations;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].NF_CODENATUREFAMILLEOPERATION};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhafamilleoperationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                    clsPhafamilleoperation.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION = row["FO_LIBELLEFAMILLEOPERATION"].ToString();
                    clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhafamilleoperations.Add(clsPhafamilleoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhafamilleoperations;
    }


        
    }
}
