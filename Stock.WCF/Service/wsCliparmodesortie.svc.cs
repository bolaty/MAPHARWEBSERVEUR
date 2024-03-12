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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsCliparmodesortie" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsCliparmodesortie.svc ou wsCliparmodesortie.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsCliparmodesortie : IwsCliparmodesortie
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsCliparmodesortieWSBLL clsCliparmodesortieWSBLL = new clsCliparmodesortieWSBLL();

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
        public List<HT_Stock.BOJ.clsCliparmodesortie> pvgAjouter(List<HT_Stock.BOJ.clsCliparmodesortie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliparmodesorties = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
                //--TEST CONTRAINTE
                clsCliparmodesorties = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortieDTO in Objet)
                {
                    Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.MS_CODEMODESORTIE = clsCliparmodesortieDTO.MS_CODEMODESORTIE.ToString();
                    clsCliparmodesortie.MS_LIBELLEMODESORTIE = clsCliparmodesortieDTO.MS_LIBELLEMODESORTIE.ToString();
                    clsObjetEnvoi.OE_A = clsCliparmodesortieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCliparmodesortieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsCliparmodesortieWSBLL.pvgAjouter(clsDonnee, clsCliparmodesortie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliparmodesorties.Add(clsCliparmodesortie);
                }
                else
                {
                    HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliparmodesorties.Add(clsCliparmodesortie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                clsCliparmodesorties.Add(clsCliparmodesortie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                clsCliparmodesorties.Add(clsCliparmodesortie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliparmodesorties;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliparmodesortie> pvgModifier(List<HT_Stock.BOJ.clsCliparmodesortie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliparmodesorties = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
                //--TEST CONTRAINTE
                clsCliparmodesorties = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortieDTO in Objet)
                {
                    Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.MS_CODEMODESORTIE = clsCliparmodesortieDTO.MS_CODEMODESORTIE.ToString();
                    clsCliparmodesortie.MS_LIBELLEMODESORTIE = clsCliparmodesortieDTO.MS_LIBELLEMODESORTIE.ToString();
                    clsObjetEnvoi.OE_A = clsCliparmodesortieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsCliparmodesortieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsCliparmodesortieDTO.MS_CODEMODESORTIE };
                    clsObjetRetour.SetValue(true, clsCliparmodesortieWSBLL.pvgModifier(clsDonnee, clsCliparmodesortie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliparmodesorties.Add(clsCliparmodesortie);
                }
                else
                {
                    HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliparmodesorties.Add(clsCliparmodesortie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                clsCliparmodesorties.Add(clsCliparmodesortie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                clsCliparmodesorties.Add(clsCliparmodesortie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliparmodesorties;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliparmodesortie> pvgSupprimer(List<HT_Stock.BOJ.clsCliparmodesortie> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsCliparmodesorties = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
                //--TEST CONTRAINTE
                clsCliparmodesorties = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].MS_CODEMODESORTIE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsCliparmodesortieWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsCliparmodesorties.Add(clsCliparmodesortie);
                }
                else
                {
                    HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsCliparmodesorties.Add(clsCliparmodesortie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                clsCliparmodesorties.Add(clsCliparmodesortie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
                clsCliparmodesorties.Add(clsCliparmodesortie);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsCliparmodesorties;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsCliparmodesortie> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCliparmodesortie> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsCliparmodesorties = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
            //    //--TEST CONTRAINTE
            //    clsCliparmodesorties = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCliparmodesortieWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.MS_CODEMODESORTIE = row["MS_CODEMODESORTIE"].ToString();
                    clsCliparmodesortie.MS_LIBELLEMODESORTIE = row["MS_LIBELLEMODESORTIE"].ToString();
                    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCliparmodesorties.Add(clsCliparmodesortie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCliparmodesorties.Add(clsCliparmodesortie);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
            clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliparmodesortie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            clsCliparmodesorties.Add(clsCliparmodesortie);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
            clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliparmodesortie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            clsCliparmodesorties.Add(clsCliparmodesortie);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsCliparmodesorties;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsCliparmodesortie> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCliparmodesortie> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsCliparmodesorties = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
        //    //--TEST CONTRAINTE
        //    clsCliparmodesorties = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsCliparmodesorties[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsCliparmodesorties;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsCliparmodesortieWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                    clsCliparmodesortie.MS_CODEMODESORTIE = row["MS_CODEMODESORTIE"].ToString();
                    clsCliparmodesortie.MS_LIBELLEMODESORTIE = row["MS_LIBELLEMODESORTIE"].ToString();
                    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsCliparmodesorties.Add(clsCliparmodesortie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsCliparmodesorties.Add(clsCliparmodesortie);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
            clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliparmodesortie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            clsCliparmodesorties.Add(clsCliparmodesortie);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
            clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsCliparmodesortie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            clsCliparmodesorties.Add(clsCliparmodesortie);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsCliparmodesorties;
    }


        
    }
}
