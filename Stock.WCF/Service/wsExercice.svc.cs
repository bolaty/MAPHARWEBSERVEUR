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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsExercice" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsExercice.svc ou wsExercice.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsExercice : IwsExercice
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsExerciceWSBLL clsExerciceWSBLL = new clsExerciceWSBLL();

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
        public List<HT_Stock.BOJ.clsExercice> pvgAjouter(List<HT_Stock.BOJ.clsExercice> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsExercice> clsExercices = new List<HT_Stock.BOJ.clsExercice>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsExercices = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
                //--TEST CONTRAINTE
                clsExercices = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsExercice clsExerciceDTO in Objet)
                {
                    Stock.BOJ.clsExercice clsExercice = new Stock.BOJ.clsExercice();
                    clsExercice.AG_CODEAGENCE = clsExerciceDTO.AG_CODEAGENCE.ToString();
                    clsExercice.EX_EXERCICE = clsExerciceDTO.EX_EXERCICE.ToString();
                    if (clsExerciceDTO.JT_DATEJOURNEETRAVAIL.ToString() != "")
                        clsExercice.JT_DATEJOURNEETRAVAIL =DateTime.Parse( clsExerciceDTO.JT_DATEJOURNEETRAVAIL.ToString());
                    else
                        clsExercice.JT_DATEJOURNEETRAVAIL = DateTime.Parse("01/01/1900");

                    if (clsExerciceDTO.EX_DATEDEBUT.ToString() != "")
                        clsExercice.EX_DATEDEBUT = DateTime.Parse(clsExerciceDTO.EX_DATEDEBUT.ToString());
                    else
                        clsExercice.EX_DATEDEBUT = DateTime.Parse("01/01/1900");

                    if (clsExerciceDTO.EX_DATEFIN.ToString() != "")
                        clsExercice.EX_DATEFIN = DateTime.Parse(clsExerciceDTO.EX_DATEFIN.ToString());
                    else
                        clsExercice.EX_DATEFIN = DateTime.Parse("01/01/1900");

                    clsExercice.EX_DESCEXERCICE = clsExerciceDTO.EX_DESCEXERCICE.ToString();
                    clsExercice.EX_ETATEXERCICE = clsExerciceDTO.EX_ETATEXERCICE.ToString();
                    if (clsExerciceDTO.EX_DATESAISIE.ToString() != "")
                        clsExercice.EX_DATESAISIE = DateTime.Parse(clsExerciceDTO.EX_DATESAISIE.ToString());
                    else
                        clsExercice.EX_DATESAISIE = DateTime.Parse("01/01/1900");
                    //clsExercice.JT_DATEDEBUTPREMIEREXERCICE = DateTime.Parse(clsExerciceDTO.JT_DATEDEBUTPREMIEREXERCICE.ToString());
                    clsExercice.EX_EXERCICEENCOURS = clsExerciceDTO.EX_EXERCICEENCOURS.ToString();



                    clsObjetEnvoi.OE_A = clsExerciceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsExerciceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsExerciceWSBLL.pvgAjouter(clsDonnee, clsExercice, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                    clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                    clsExercice.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsExercice.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsExercice.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsExercices.Add(clsExercice);
                }
                else
                {
                    HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                    clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                    clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsExercice.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsExercices.Add(clsExercice);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsExercices;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsExercice> pvgModifier(List<HT_Stock.BOJ.clsExercice> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsExercice> clsExercices = new List<HT_Stock.BOJ.clsExercice>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsExercices = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
                //--TEST CONTRAINTE
                clsExercices = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
            }

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsExercice clsExerciceDTO in Objet)
                {
                    Stock.BOJ.clsExercice clsExercice = new Stock.BOJ.clsExercice();
                    clsExercice.AG_CODEAGENCE = clsExerciceDTO.AG_CODEAGENCE.ToString();
                    clsExercice.EX_EXERCICE = clsExerciceDTO.EX_EXERCICE.ToString();
                    if (clsExerciceDTO.JT_DATEJOURNEETRAVAIL.ToString() != "")
                        clsExercice.JT_DATEJOURNEETRAVAIL = DateTime.Parse(clsExerciceDTO.JT_DATEJOURNEETRAVAIL.ToString());
                    else
                        clsExercice.JT_DATEJOURNEETRAVAIL = DateTime.Parse("01/01/1900");

                    if (clsExerciceDTO.EX_DATEDEBUT.ToString() != "")
                        clsExercice.EX_DATEDEBUT = DateTime.Parse(clsExerciceDTO.EX_DATEDEBUT.ToString());
                    else
                        clsExercice.EX_DATEDEBUT = DateTime.Parse("01/01/1900");

                    if (clsExerciceDTO.EX_DATEFIN.ToString() != "")
                        clsExercice.EX_DATEFIN = DateTime.Parse(clsExerciceDTO.EX_DATEFIN.ToString());
                    else
                        clsExercice.EX_DATEFIN = DateTime.Parse("01/01/1900");

                    clsExercice.EX_DESCEXERCICE = clsExerciceDTO.EX_DESCEXERCICE.ToString();
                    clsExercice.EX_ETATEXERCICE = clsExerciceDTO.EX_ETATEXERCICE.ToString();
                    if (clsExerciceDTO.EX_DATESAISIE.ToString() != "")
                        clsExercice.EX_DATESAISIE = DateTime.Parse(clsExerciceDTO.EX_DATESAISIE.ToString());
                    else
                        clsExercice.EX_DATESAISIE = DateTime.Parse("01/01/1900");

                    clsExercice.EX_EXERCICEENCOURS = clsExerciceDTO.EX_EXERCICEENCOURS.ToString();

                    clsObjetEnvoi.OE_A = clsExerciceDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsExerciceDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsExerciceDTO.AG_CODEAGENCE, Objet[0].EX_EXERCICE };
                    clsObjetRetour.SetValue(true, clsExerciceWSBLL.pvgModifier(clsDonnee, clsExercice, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                    clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                    clsExercice.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsExercice.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsExercice.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsExercices.Add(clsExercice);
                }
                else
                {
                    HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                    clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                    clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsExercice.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsExercices.Add(clsExercice);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsExercices;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsExercice> pvgSupprimer(List<HT_Stock.BOJ.clsExercice> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsExercice> clsExercices = new List<HT_Stock.BOJ.clsExercice>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsExercices = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
                //--TEST CONTRAINTE
                clsExercices = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].EX_EXERCICE};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsExerciceWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                    clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                    clsExercice.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsExercice.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsExercice.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsExercices.Add(clsExercice);
                }
                else
                {
                    HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                    clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                    clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsExercice.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsExercices.Add(clsExercice);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsExercices;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsExercice> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsExercice> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsExercice> clsExercices = new List<HT_Stock.BOJ.clsExercice>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsExercices = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
                //--TEST CONTRAINTE
                clsExercices = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsExerciceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                        clsExercice.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                        clsExercice.EX_EXERCICE = row["EX_EXERCICE"].ToString();

                        if(row["JT_DATEJOURNEETRAVAIL"].ToString()!="")
                        clsExercice.JT_DATEJOURNEETRAVAIL =DateTime.Parse( row["JT_DATEJOURNEETRAVAIL"].ToString()).ToShortDateString();
                        if (row["EX_DATEDEBUT"].ToString() != "")
                            clsExercice.EX_DATEDEBUT = DateTime.Parse(row["EX_DATEDEBUT"].ToString()).ToShortDateString();
                        if (row["EX_DATEFIN"].ToString() != "")
                            clsExercice.EX_DATEFIN = DateTime.Parse(row["EX_DATEFIN"].ToString()).ToShortDateString();
                        clsExercice.EX_DESCEXERCICE = row["EX_DESCEXERCICE"].ToString();
                        clsExercice.EX_ETATEXERCICE = row["EX_ETATEXERCICE"].ToString();
                        if (row["EX_DATESAISIE"].ToString() != "")
                            clsExercice.EX_DATESAISIE = DateTime.Parse(row["EX_DATESAISIE"].ToString()).ToShortDateString();
                        clsExercice.EX_EXERCICEENCOURS = row["EX_EXERCICEENCOURS"].ToString();
                        // clsExercice.JT_DATEDEBUTPREMIEREXERCICE = row["JT_DATEDEBUTPREMIEREXERCICE"].ToString();
                        //private string _AG_CODEAGENCE = "";
                        //private string _EX_EXERCICE = "";
                        //private string _JT_DATEJOURNEETRAVAIL = "";
                        //private string _EX_DATEDEBUT = "";
                        //private string _EX_DATEFIN = "";
                        //private string _EX_DESCEXERCICE = "";
                        //private string _EX_ETATEXERCICE = "";
                        //private string _EX_DATESAISIE = "";
                        //private string _JT_DATEDEBUTPREMIEREXERCICE = "";


                        clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                        clsExercice.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsExercice.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsExercice.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsExercices.Add(clsExercice);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                    clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                    clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsExercice.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsExercices.Add(clsExercice);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsExercices;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsExercice> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsExercice> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsExercice> clsExercices = new List<HT_Stock.BOJ.clsExercice>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsExercices = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
                //--TEST CONTRAINTE
                clsExercices = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsExercices[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsExercices;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsExerciceWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();

                        clsExercice.EX_EXERCICE = row["EX_EXERCICE"].ToString();
                        clsExercice.EX_DATEDEBUT = row["EX_DATEDEBUT"].ToString();
                        clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                        clsExercice.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsExercice.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsExercice.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsExercices.Add(clsExercice);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                    clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                    clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsExercice.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsExercices.Add(clsExercice);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
                clsExercice.clsObjetRetour = new Common.clsObjetRetour();
                clsExercice.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsExercice.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsExercice.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsExercices = new List<HT_Stock.BOJ.clsExercice>();
                clsExercices.Add(clsExercice);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsExercices;
        }



    }
}
