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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsOperateurdroitCompteTresorerie" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsOperateurdroitCompteTresorerie.svc ou wsOperateurdroitCompteTresorerie.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsOperateurdroitCompteTresorerie : IwsOperateurdroitCompteTresorerie
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsOperateurdroitCompteTresorerieWSBLL clsOperateurdroitCompteTresorerieWSBLL = new clsOperateurdroitCompteTresorerieWSBLL();

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
        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> pvgAjouter(List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitCompteTresoreries = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
                //--TEST CONTRAINTE
                clsOperateurdroitCompteTresoreries = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerieDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new Stock.BOJ.clsOperateurdroitCompteTresorerie();

                 

                    clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR = clsOperateurdroitCompteTresorerieDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroitCompteTresorerie.NO_CODENATUREOPERATION = clsOperateurdroitCompteTresorerieDTO.NO_CODENATUREOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsOperateurdroitCompteTresorerieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitCompteTresorerieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsOperateurdroitCompteTresorerieWSBLL.pvgAjouter(clsDonnee, clsOperateurdroitCompteTresorerie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitCompteTresoreries;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> pvgAjouterdroit(List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitCompteTresoreries = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
                //--TEST CONTRAINTE
                clsOperateurdroitCompteTresoreries = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                List<Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresorerieAjout=new List<BOJ.clsOperateurdroitCompteTresorerie>();
                List<Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresorerieSuppression = new List<BOJ.clsOperateurdroitCompteTresorerie>();
                foreach (HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerieDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new Stock.BOJ.clsOperateurdroitCompteTresorerie();


                    clsOperateurdroitCompteTresorerie.AG_CODEAGENCE = clsOperateurdroitCompteTresorerieDTO.AG_CODEAGENCE;
                    clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR = clsOperateurdroitCompteTresorerieDTO.OP_CODEOPERATEUR;
                    clsOperateurdroitCompteTresorerie.NO_CODENATUREOPERATION = clsOperateurdroitCompteTresorerieDTO.NO_CODENATUREOPERATION;
                    clsOperateurdroitCompteTresorerie.OB_CODEOBJET = clsOperateurdroitCompteTresorerieDTO.OB_CODEOBJET;
                    clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE = clsOperateurdroitCompteTresorerieDTO.PL_CODENUMCOMPTE;
                    clsOperateurdroitCompteTresorerie.LO_ACTIF = "O"; //vppGrille.GetDataRow(vppIndex)["TC_CODETYPETIERS"].ToString();
                    clsOperateurdroitCompteTresorerie.COCHER = clsOperateurdroitCompteTresorerieDTO.COCHER;

                    clsObjetEnvoi.OE_A = clsOperateurdroitCompteTresorerieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitCompteTresorerieDTO.clsObjetEnvoi.OE_Y;


                    ///@AG_CODEAGENCE, @OP_CODEOPERATEUR, @NO_CODENATUREOPERATION, @OB_CODEOBJET
                    clsObjetEnvoi.OE_PARAM = new string[] {clsOperateurdroitCompteTresorerieDTO.AG_CODEAGENCE, clsOperateurdroitCompteTresorerieDTO.OP_CODEOPERATEUR, clsOperateurdroitCompteTresorerieDTO.NO_CODENATUREOPERATION, clsOperateurdroitCompteTresorerieDTO.OB_CODEOBJET };
                    clsOperateurdroitCompteTresorerieAjout.Add(clsOperateurdroitCompteTresorerie);

                }
              
                List<Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreriess = new List<BOJ.clsOperateurdroitCompteTresorerie>();
                clsObjetRetour.SetValue(true, clsOperateurdroitCompteTresorerieWSBLL.pvgAjouterListe(clsDonnee, clsOperateurdroitCompteTresorerieAjout, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitCompteTresoreries;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> pvgModifier(List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitCompteTresoreries = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
                //--TEST CONTRAINTE
                clsOperateurdroitCompteTresoreries = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerieDTO in Objet)
                {
                    Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new Stock.BOJ.clsOperateurdroitCompteTresorerie();

  


                    clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR = clsOperateurdroitCompteTresorerieDTO.OP_CODEOPERATEUR.ToString();
                    clsOperateurdroitCompteTresorerie.NO_CODENATUREOPERATION = clsOperateurdroitCompteTresorerieDTO.NO_CODENATUREOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsOperateurdroitCompteTresorerieDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsOperateurdroitCompteTresorerieDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsOperateurdroitCompteTresorerieDTO.OP_CODEOPERATEUR };
                    clsObjetRetour.SetValue(true, clsOperateurdroitCompteTresorerieWSBLL.pvgModifier(clsDonnee, clsOperateurdroitCompteTresorerie, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitCompteTresoreries;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> pvgSupprimer(List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitCompteTresoreries = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
                //--TEST CONTRAINTE
                clsOperateurdroitCompteTresoreries = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].OP_CODEOPERATEUR };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsOperateurdroitCompteTresorerieWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }
                else
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitCompteTresoreries;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsOperateurdroitCompteTresoreries = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
                //--TEST CONTRAINTE
                clsOperateurdroitCompteTresoreries = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].NO_CODENATUREOPERATION, Objet[0].OB_CODEOBJET };
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitCompteTresorerieWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsOperateurdroitCompteTresorerie.COCHER = row["COCHER"].ToString();
                    clsOperateurdroitCompteTresorerie.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsOperateurdroitCompteTresoreries;
            }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> pvgChargerDansDataSetOperateurDroit(List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsOperateurdroitCompteTresoreries = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
            //--TEST CONTRAINTE
            clsOperateurdroitCompteTresoreries = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
        }

            // "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" , "@NO_CODENATUREOPERATION", "@OB_CODEOBJET"
            clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].NO_CODENATUREOPERATION, Objet[0].OB_CODEOBJET };
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsOperateurdroitCompteTresorerieWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
        clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                clsOperateurdroitCompteTresorerie.PL_LIBELLE = row["PL_LIBELLE"].ToString();
                clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                clsOperateurdroitCompteTresorerie.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                clsOperateurdroitCompteTresorerie.COCHER = row["COCHER"].ToString();
               
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }
        }
        else
        {
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
        clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
        clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
        clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
        clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
        clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
        clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsOperateurdroitCompteTresoreries;
        }







        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsOperateurdroitCompteTresoreries = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
        //    //--TEST CONTRAINTE
        //    clsOperateurdroitCompteTresoreries = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsOperateurdroitCompteTresoreries[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsOperateurdroitCompteTresoreries;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsOperateurdroitCompteTresorerieWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                    clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR = row["OP_CODEOPERATEUR"].ToString();
                    clsOperateurdroitCompteTresorerie.OB_CODEOBJET = row["OB_CODEOBJET"].ToString();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                }
            }
            else
            {
                HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsOperateurdroitCompteTresoreries;
    }


        
    }
}
