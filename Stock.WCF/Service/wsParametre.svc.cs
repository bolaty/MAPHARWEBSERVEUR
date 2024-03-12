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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsParametre" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsParametre.svc ou wsParametre.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsParametre : IwsParametre
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();

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
        public List<HT_Stock.BOJ.clsParametre> pvgAjouter(List<HT_Stock.BOJ.clsParametre> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsParametres = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
                //--TEST CONTRAINTE
                clsParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsParametre clsParametreDTO in Objet)
                {
                    Stock.BOJ.clsParametre clsParametre = new Stock.BOJ.clsParametre();

                    clsParametre.SO_CODESOCIETE = clsParametreDTO.SO_CODESOCIETE.ToString();
                    clsParametre.PP_CODEPARAMETRE = clsParametreDTO.PP_CODEPARAMETRE.ToString();
                    clsParametre.PP_LIBELLE = clsParametreDTO.PP_LIBELLE.ToString();

                    if (clsParametreDTO.PP_MONTANTMINI.ToString() != "")
                        clsParametre.PP_MONTANTMINI = double.Parse(clsParametreDTO.PP_MONTANTMINI.ToString());
                    else
                        clsParametre.PP_MONTANTMINI = 0;

                    if (clsParametreDTO.PP_MONTANTMAXI.ToString() != "")
                        clsParametre.PP_MONTANTMAXI = double.Parse(clsParametreDTO.PP_MONTANTMAXI.ToString());
                    else
                        clsParametre.PP_MONTANTMAXI = 0;

                    if (clsParametreDTO.PP_MONTANT.ToString() != "")
                        clsParametre.PP_MONTANT = double.Parse(clsParametreDTO.PP_MONTANT.ToString());
                    else
                        clsParametre.PP_MONTANT = 0;

                    if (clsParametreDTO.PP_TAUX.ToString() != "")
                        clsParametre.PP_TAUX = decimal.Parse(clsParametreDTO.PP_TAUX.ToString());
                    else
                        clsParametre.PP_TAUX = 0;



                    clsParametre.PP_VALEUR = clsParametreDTO.PP_VALEUR.ToString();
                    clsParametre.PL_NUMCOMPTE = clsParametreDTO.PL_NUMCOMPTE.ToString();


                    clsObjetEnvoi.OE_A = clsParametreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsParametreDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsParametreWSBLL.pvgAjouter(clsDonnee, clsParametre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsParametre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsParametre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsParametres.Add(clsParametre);
                }
                else
                {
                    HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsParametre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsParametres.Add(clsParametre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                clsParametres.Add(clsParametre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                clsParametres.Add(clsParametre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsParametres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsParametre> pvgModifier(List<HT_Stock.BOJ.clsParametre> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsParametres = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
                //--TEST CONTRAINTE
                clsParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsParametre clsParametreDTO in Objet)
                {
                    Stock.BOJ.clsParametre clsParametre = new Stock.BOJ.clsParametre();

                    clsParametre.SO_CODESOCIETE = clsParametreDTO.SO_CODESOCIETE.ToString();
                    clsParametre.PP_CODEPARAMETRE = clsParametreDTO.PP_CODEPARAMETRE.ToString();
                    clsParametre.PP_LIBELLE = clsParametreDTO.PP_LIBELLE.ToString();

                    if (clsParametreDTO.PP_MONTANTMINI.ToString() != "")
                        clsParametre.PP_MONTANTMINI = double.Parse(clsParametreDTO.PP_MONTANTMINI.ToString());
                    else
                        clsParametre.PP_MONTANTMINI = 0;

                    if (clsParametreDTO.PP_MONTANTMAXI.ToString() != "")
                        clsParametre.PP_MONTANTMAXI = double.Parse(clsParametreDTO.PP_MONTANTMAXI.ToString());
                    else
                        clsParametre.PP_MONTANTMAXI = 0;

                    if (clsParametreDTO.PP_MONTANT.ToString() != "")
                        clsParametre.PP_MONTANT = double.Parse(clsParametreDTO.PP_MONTANT.ToString());
                    else
                        clsParametre.PP_MONTANT = 0;

                    if (clsParametreDTO.PP_TAUX.ToString() != "")
                        clsParametre.PP_TAUX = decimal.Parse(clsParametreDTO.PP_TAUX.ToString());
                    else
                        clsParametre.PP_TAUX = 0;


                    clsParametre.PP_VALEUR = clsParametreDTO.PP_VALEUR.ToString();
                    clsParametre.PL_NUMCOMPTE = clsParametreDTO.PL_NUMCOMPTE.ToString();

                    clsObjetEnvoi.OE_A = clsParametreDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsParametreDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsParametreDTO.PP_CODEPARAMETRE };
                    clsObjetRetour.SetValue(true, clsParametreWSBLL.pvgModifier(clsDonnee, clsParametre, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsParametre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsParametre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsParametres.Add(clsParametre);
                }
                else
                {
                    HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsParametre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsParametres.Add(clsParametre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                clsParametres.Add(clsParametre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                clsParametres.Add(clsParametre);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsParametres;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsParametre> pvgSupprimer(List<HT_Stock.BOJ.clsParametre> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsParametres = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
                //--TEST CONTRAINTE
                clsParametres = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PP_CODEPARAMETRE };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsParametreWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsParametre.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsParametre.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsParametres.Add(clsParametre);
                }
                else
                {
                    HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsParametre.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsParametres.Add(clsParametre);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                clsParametres.Add(clsParametre);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsParametres = new List<HT_Stock.BOJ.clsParametre>();
                clsParametres.Add(clsParametre);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsParametres;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsParametre> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsParametre> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsParametres = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
            //    //--TEST CONTRAINTE
            //    clsParametres = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsParametreWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                    clsParametre.SO_CODESOCIETE = row["SO_CODESOCIETE"].ToString();
                    clsParametre.PP_CODEPARAMETRE = row["PP_CODEPARAMETRE"].ToString();
                    clsParametre.PP_LIBELLE = row["PP_LIBELLE"].ToString();

                        if (row["PP_MONTANTMINI"].ToString() != "")
                            clsParametre.PP_MONTANTMINI = double.Parse(row["PP_MONTANTMINI"].ToString());
                        else
                            clsParametre.PP_MONTANTMINI = 0;

                        if (row["PP_MONTANTMAXI"].ToString() != "")
                            clsParametre.PP_MONTANTMAXI = double.Parse(row["PP_MONTANTMAXI"].ToString());
                        else
                            clsParametre.PP_MONTANTMAXI = 0;

                        if (row["PP_TAUX"].ToString() != "")
                            clsParametre.PP_TAUX = decimal.Parse(row["PP_TAUX"].ToString());
                        else
                            clsParametre.PP_TAUX = 0;

                        if (row["PP_MONTANT"].ToString() != "")
                            clsParametre.PP_MONTANT = double.Parse(row["PP_MONTANT"].ToString());
                        else
                            clsParametre.PP_MONTANT = 0;

                    clsParametre.PP_VALEUR = row["PP_VALEUR"].ToString();
                    clsParametre.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsParametre.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                    clsParametre.PP_AFFICHER = row["PP_AFFICHER"].ToString();

                    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsParametres.Add(clsParametre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsParametres.Add(clsParametre);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
            clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            clsParametres.Add(clsParametre);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
            clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            clsParametres.Add(clsParametre);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsParametres;
            }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsParametre> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsParametre> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsParametres = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
        //    //--TEST CONTRAINTE
        //    clsParametres = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsParametres[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsParametres;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsParametreWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                    clsParametre.PP_CODEPARAMETRE = row["PP_CODEPARAMETRE"].ToString();
                    clsParametre.PP_LIBELLE = row["PP_LIBELLE"].ToString();
                    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                    clsParametre.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsParametre.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsParametres.Add(clsParametre);
                }
            }
            else
            {
                HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsParametre.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsParametres.Add(clsParametre);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
            clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            clsParametres.Add(clsParametre);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
            clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsParametre.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsParametre.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsParametre.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            clsParametres.Add(clsParametre);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsParametres;
    }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public HT_Stock.BOJ.clsCommissioncinetpay pvgCommissioncinetpay(string MONTANT, string MONTANTMF, string TYPEOPERATION, string LG_CODELANGUE)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
        HT_Stock.BOJ.clsCommissioncinetpay clsResultats = new HT_Stock.BOJ.clsCommissioncinetpay();
        List < Stock.BOJ.clsCommissioncinetpay> clsResultatss = new List<Stock.BOJ.clsCommissioncinetpay>();
        HT_Stock.BOJ.clsCommissioncinetpay clsResultat = new HT_Stock.BOJ.clsCommissioncinetpay();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            //Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

        if (string.IsNullOrEmpty(LG_CODELANGUE))
        {
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsResultats.SL_CODEMESSAGE = "99";
            clsResultats.SL_RESULTAT = "FALSE";
            clsResultats.SL_MESSAGE = "Saisie obligatoire  !!! "+ LG_CODELANGUE;
            return clsResultats;

        }



        if (string.IsNullOrEmpty(MONTANT))
        {
         
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsResultats.SL_CODEMESSAGE = "99";
            clsResultats.SL_RESULTAT = "FALSE";
            clsResultats.SL_MESSAGE = "Saisie obligatoire  !!! MONTANT";
            return clsResultats;

        }

        if (string.IsNullOrEmpty(MONTANTMF))
        {
          
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsResultats.SL_CODEMESSAGE = "99";
            clsResultats.SL_RESULTAT = "FALSE";
            clsResultats.SL_MESSAGE = "Saisie obligatoire  !!! MONTANTMF";
            return clsResultats;

        }

        if (double.Parse(MONTANTMF) > 0 && double.Parse(MONTANT) > 0)
        {
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsResultats.SL_CODEMESSAGE = "99";
            clsResultats.SL_RESULTAT = "FALSE";
            clsResultats.SL_MESSAGE = "Les deux montants ne doivent pas être supérieur à zéro !!!";
            return clsResultats;

        }

        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            clsResultatss = clsParametreWSBLL.pvgCommissioncinetpay(clsDonnee, MONTANT, MONTANTMF, TYPEOPERATION, LG_CODELANGUE);

            foreach (Stock.BOJ.clsCommissioncinetpay clsCommissioncinetpay in clsResultatss)
            {
                clsResultat.SL_CODEMESSAGE = "00";
                clsResultat.SL_MESSAGE = "Opération réalisée avec succès !!!";
                clsResultat.SL_RESULTAT = "TRUE";
                clsResultat.SL_MONTANT = clsCommissioncinetpay.SL_MONTANT;
                clsResultat.SL_TAUX = clsCommissioncinetpay.SL_TAUX;
                clsResultat.SL_RESULTAT = "TRUE";
                clsResultat.SL_MESSAGE = "Opération réalisée avec succès !!!";
                clsResultat.SL_CODEMESSAGE = "00 !!!";
                }
            

            }
        catch (SqlException SQLEx)
        {

            clsResultat.SL_CODEMESSAGE = "99";
            clsResultat.SL_MESSAGE = SQLEx.Message;
            clsResultat.SL_RESULTAT = "FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
        }
        catch (Exception SQLEx)
        {

                clsResultat.SL_CODEMESSAGE = "99";
                clsResultat.SL_MESSAGE = SQLEx.Message;
                clsResultat.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);

        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsResultat;
        }
       

    }
}
