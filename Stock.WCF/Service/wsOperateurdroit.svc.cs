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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOperateurdroit" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOperateurdroit.svc ou wsOperateurdroit.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOperateurdroit : IwsOperateurdroit
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsOperateurdroitWSBLL clsOperateurdroitWSBLL = new clsOperateurdroitWSBLL();

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
        public List<HT_Stock.BOJ.clsOperateurdroit> pvgAjouter(List<HT_Stock.BOJ.clsOperateurdroit> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroits = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
                //--TEST CONTRAINTE
                clsOperateurdroits = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroit clsOperateurdroitDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroit clsOperateurdroit = new Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.OP_CODEOPERATEUR = clsOperateurdroitDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroit.OB_CODEOBJET =int.Parse( clsOperateurdroitDTO.OB_CODEOBJET.ToString());
                    clsObjetEnvoi.OE_A = clsOperateurdroitDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsOperateurdroitWSBLL.pvgAjouter(clsDonnee, clsOperateurdroit, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroits;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroit> pvgAjouterdroit(List<HT_Stock.BOJ.clsOperateurdroit> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<Stock.BOJ.clsOperateurdroit> clsOperateurdroitBOJs = new List<Stock.BOJ.clsOperateurdroit>();
            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroits = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
                //--TEST CONTRAINTE
                clsOperateurdroits = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
            }
          
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroit clsOperateurdroitDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroit clsOperateurdroit = new Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.AG_CODEAGENCE = clsOperateurdroitDTO.AG_CODEAGENCE.ToString();
                    clsOperateurdroit.OP_CODEOPERATEUR = clsOperateurdroitDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroit.OB_CODEOBJET =int.Parse(clsOperateurdroitDTO.OB_CODEOBJET.ToString());
                    clsOperateurdroit.OD_AJOUTER =  clsOperateurdroitDTO.OD_AJOUTER.ToString();
                    clsOperateurdroit.OD_MODIFIER =  clsOperateurdroitDTO.OD_MODIFIER.ToString();
                    clsOperateurdroit.OD_SUPPRIMER =  clsOperateurdroitDTO.OD_SUPPRIMER.ToString();
                    clsOperateurdroit.OD_APERCU =  clsOperateurdroitDTO.OD_APERCU.ToString();
                    clsOperateurdroit.OD_AUTORISER =  clsOperateurdroitDTO.OD_AUTORISER.ToString();
                    clsOperateurdroit.OD_IMPRIMER =  clsOperateurdroitDTO.OD_IMPRIMER.ToString();
                    clsOperateurdroit.OD_IMPRIMERTOUT =  clsOperateurdroitDTO.OD_IMPRIMERTOUT.ToString();
                    clsOperateurdroit.LO_CODELOGICIEL =  clsOperateurdroitDTO.LO_CODELOGICIEL.ToString();
                    clsOperateurdroit.OB_RATTACHEA =  clsOperateurdroitDTO.OB_RATTACHEA.ToString();
                    clsOperateurdroit.OD_NUMEROORDRE =int.Parse(clsOperateurdroitDTO.OD_NUMEROORDRE.ToString());
                    clsObjetEnvoi.OE_A = clsOperateurdroitDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsOperateurdroitDTO.AG_CODEAGENCE.ToString(), clsOperateurdroitDTO.OP_CODEOPERATEUR.ToString(), clsOperateurdroitDTO.OB_CODEOBJET.ToString() };
                    clsOperateurdroitBOJs.Add(clsOperateurdroit);
                }


                clsObjetRetour.SetValue(true, clsOperateurdroitWSBLL.pvgAjouterdroit(clsDonnee, clsOperateurdroitBOJs, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroits;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroit> pvgModifier(List<HT_Stock.BOJ.clsOperateurdroit> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroits = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
                //--TEST CONTRAINTE
                clsOperateurdroits = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroit clsOperateurdroitDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroit clsOperateurdroit = new Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.OP_CODEOPERATEUR = clsOperateurdroitDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroit.OB_CODEOBJET =int.Parse( clsOperateurdroitDTO.OB_CODEOBJET.ToString());
                    clsObjetEnvoi.OE_A = clsOperateurdroitDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsOperateurdroitDTO.OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsOperateurdroitWSBLL.pvgModifier(clsDonnee, clsOperateurdroit, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroits;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroit> pvgSupprimer(List<HT_Stock.BOJ.clsOperateurdroit> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroits = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
                //--TEST CONTRAINTE
                clsOperateurdroits = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OP_CODEOPERATEUR };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsOperateurdroitWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroits;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsOperateurdroit> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsOperateurdroit> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroits = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
                //--TEST CONTRAINTE
                clsOperateurdroits = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
            }

            //"@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OB_CODEOBJET", "@LO_CODELOGICIEL", "@OB_RATTACHEA"
            //c
            if (Objet[0].OB_CODEOBJET == "5")
                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].OB_CODEOBJET, Objet[0].LO_CODELOGICIEL };
            else
                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].OB_CODEOBJET, Objet[0].LO_CODELOGICIEL, Objet[0].OB_RATTACHEA };

            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitWSBLL.pvgInsertIntoDatasetGrille(clsDonnee, clsObjetEnvoi);
            clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsOperateurdroit.OB_NOMOBJET = row["OB_NOMOBJET"].ToString();
                    clsOperateurdroit.OT_CODETYPEOBJET = row["OT_CODETYPEOBJET"].ToString();
                    clsOperateurdroit.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                    clsOperateurdroit.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsOperateurdroit.OD_AUTORISER = row["OD_AUTORISER"].ToString();
                    clsOperateurdroit.OD_AJOUTER = row["OD_AJOUTER"].ToString();
                    clsOperateurdroit.OD_MODIFIER = row["OD_MODIFIER"].ToString();
                    clsOperateurdroit.OD_SUPPRIMER = row["OD_SUPPRIMER"].ToString();
                    clsOperateurdroit.OD_IMPRIMER = row["OD_IMPRIMER"].ToString();
                    clsOperateurdroit.OD_APERCU = row["OD_APERCU"].ToString();
                    clsOperateurdroit.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();
                    clsOperateurdroit.OD_IMPRIMERTOUT = row["OD_IMPRIMERTOUT"].ToString();
                    clsOperateurdroit.OD_NUMEROORDRE = row["OD_NUMEROORDRE"].ToString();
                    clsOperateurdroit.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroits.Add(clsOperateurdroit);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
            clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroit.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            clsOperateurdroits.Add(clsOperateurdroit);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
            clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroit.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            clsOperateurdroits.Add(clsOperateurdroit);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroits;
            }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroit> pvgChargerDansDataSetOperateurDroit(List<HT_Stock.BOJ.clsOperateurdroit> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroits = TestChampObligatoireListeOperateurDroit(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
                //--TEST CONTRAINTE
                clsOperateurdroits = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
            }

            //"@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OB_CODEOBJET", "@LO_CODELOGICIEL", "@OB_RATTACHEA"
            //c
            //if (Objet[0].OB_CODEOBJET == "5")
                clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].OB_CODEOBJET, Objet[0].LO_CODELOGICIEL };
            //else
            //    clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].OB_CODEOBJET, Objet[0].LO_CODELOGICIEL, Objet[0].OB_RATTACHEA };

            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsOperateurdroitWSBLL.pvgInsertIntoDatasetGrille(clsDonnee, clsObjetEnvoi);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                        clsOperateurdroit.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                        clsOperateurdroit.OB_NOMOBJET = row["OB_NOMOBJET"].ToString();
                        clsOperateurdroit.OT_CODETYPEOBJET = row["OT_CODETYPEOBJET"].ToString();
                        clsOperateurdroit.OB_LIBELLE = row["OB_LIBELLE"].ToString();
                        clsOperateurdroit.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                        clsOperateurdroit.OD_AUTORISER = row["OD_AUTORISER"].ToString();
                        clsOperateurdroit.OD_AJOUTER = row["OD_AJOUTER"].ToString();
                        clsOperateurdroit.OD_MODIFIER = row["OD_MODIFIER"].ToString();
                        clsOperateurdroit.OD_SUPPRIMER = row["OD_SUPPRIMER"].ToString();
                        clsOperateurdroit.OD_IMPRIMER = row["OD_IMPRIMER"].ToString();
                        clsOperateurdroit.OD_APERCU = row["OD_APERCU"].ToString();
                        clsOperateurdroit.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();
                        clsOperateurdroit.OD_IMPRIMERTOUT = row["OD_IMPRIMERTOUT"].ToString();
                        clsOperateurdroit.OD_NUMEROORDRE = row["OD_NUMEROORDRE"].ToString();
                        clsOperateurdroit.OB_RATTACHEA = row["OB_RATTACHEA"].ToString();
                        clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                        clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsOperateurdroits.Add(clsOperateurdroit);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
                clsOperateurdroits.Add(clsOperateurdroit);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroits;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroit> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOperateurdroit> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsOperateurdroits = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
        //    //--TEST CONTRAINTE
        //    clsOperateurdroits = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroits[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroits;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                    clsOperateurdroit.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsOperateurdroit.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroit.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroits.Add(clsOperateurdroit);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroits.Add(clsOperateurdroit);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
            clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroit.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            clsOperateurdroits.Add(clsOperateurdroit);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
            clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroit.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroit.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            clsOperateurdroits.Add(clsOperateurdroit);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsOperateurdroits;
    }


        
    }
}
