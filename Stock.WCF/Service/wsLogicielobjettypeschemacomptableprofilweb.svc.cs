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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsLogicielobjettypeschemacomptableprofilweb" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsLogicielobjettypeschemacomptableprofilweb.svc ou wsLogicielobjettypeschemacomptableprofilweb.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsLogicielobjettypeschemacomptableprofilweb : IwsLogicielobjettypeschemacomptableprofilweb
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsLogicielobjettypeschemacomptableprofilwebWSBLL clsLogicielobjettypeschemacomptableprofilwebWSBLL = new clsLogicielobjettypeschemacomptableprofilwebWSBLL();

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
        public string pvgAjouter(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> Objet)
        {
            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();


            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilwebDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB = clsLogicielobjettypeschemacomptableprofilwebDTO.PO_CODEPROFILWEB.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilwebDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NO_CODENATUREOPERATION = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_CODENATUREOPERATION.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE = clsLogicielobjettypeschemacomptableprofilwebDTO.AG_CODEAGENCE.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilwebDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.FO_LIBELLEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilwebDTO.FO_LIBELLEFAMILLEOPERATION.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.LB_ACTIF = clsLogicielobjettypeschemacomptableprofilwebDTO.LB_ACTIF.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.COCHER = clsLogicielobjettypeschemacomptableprofilwebDTO.COCHER.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.PL_CODENUMCOMPTE = clsLogicielobjettypeschemacomptableprofilwebDTO.PL_CODENUMCOMPTE.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NO_LIBELLE = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_LIBELLE.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.PL_NUMCOMPTE = clsLogicielobjettypeschemacomptableprofilwebDTO.PL_NUMCOMPTE.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NO_SENS = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_SENS.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NO_PREFIXECOMPTE = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_PREFIXECOMPTE.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NO_REFPIECE = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_REFPIECE.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NC_CODENATURECOMPTE = clsLogicielobjettypeschemacomptableprofilwebDTO.NC_CODENATURECOMPTE.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NO_ABREVIATION = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_ABREVIATION.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NO_MONTANT = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_MONTANT.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.NO_NUMEROORDRE = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_NUMEROORDRE.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableprofilwebDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableprofilwebDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableprofilwebWSBLL.pvgAjouter(clsDonnee, clsLogicielobjettypeschemacomptableprofilweb, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "00";
                    dr["SL_RESULTAT"] = "TRUE";
                    dr["SL_MESSAGE"] = "Opération réalisée avec succès !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Echec de l'opération !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                }



            }
            catch (SqlException SQLEx)
            {

                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                //Execution du log
                Log.Error(SQLEx.Message, null);

            }
            catch (Exception SQLEx)
            {

                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);


                //Execution du log
                Log.Error(SQLEx.Message, null);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
     /*   public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> pvgAjouterdroit(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsLogicielobjettypeschemacomptableprofilwebs = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableprofilwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();

                List<Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebAjout=new List<BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                List<Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebSuppression = new List<BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilwebDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();

                    clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE = clsLogicielobjettypeschemacomptableprofilwebDTO.AG_CODEAGENCE;
                    clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB = clsLogicielobjettypeschemacomptableprofilwebDTO.PO_CODEPROFILWEB;
                    clsLogicielobjettypeschemacomptableprofilweb.NO_CODENATUREOPERATION = clsLogicielobjettypeschemacomptableprofilwebDTO.NO_CODENATUREOPERATION;
                    clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilwebDTO.FO_CODEFAMILLEOPERATION;
                    clsLogicielobjettypeschemacomptableprofilweb.NF_CODENATUREFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilwebDTO.NF_CODENATUREFAMILLEOPERATION;

                    clsLogicielobjettypeschemacomptableprofilweb.LB_ACTIF = "O"; //vppGrille.GetDataRow(vppIndex)["TC_CODETYPETIERS"].ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.COCHER = clsLogicielobjettypeschemacomptableprofilwebDTO.COCHER;
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableprofilwebDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableprofilwebDTO.clsObjetEnvoi.OE_Y;
                    //@AG_CODEAGENCE, @PO_CODEPROFILWEB, '', @FO_CODEFAMILLEOPERATION, '' ,@NF_CODENATUREFAMILLEOPERATION, @CODECRYPTAGE, 2
                    clsObjetEnvoi.OE_PARAM = new string[] {clsLogicielobjettypeschemacomptableprofilwebDTO.AG_CODEAGENCE, clsLogicielobjettypeschemacomptableprofilwebDTO.PO_CODEPROFILWEB, clsLogicielobjettypeschemacomptableprofilwebDTO.FO_CODEFAMILLEOPERATION, clsLogicielobjettypeschemacomptableprofilwebDTO.NF_CODENATUREFAMILLEOPERATION };
                    clsLogicielobjettypeschemacomptableprofilwebAjout.Add(clsLogicielobjettypeschemacomptableprofilweb);

                }
              
                List<Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebss = new List<BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableprofilwebWSBLL.pvgAjouterListe(clsDonnee, clsLogicielobjettypeschemacomptableprofilwebAjout, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableprofilwebs;
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> pvgModifier(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
            //    clsLogicielobjettypeschemacomptableprofilwebs = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableprofilwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilwebDTO in Objet)
                {
                    Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB = clsLogicielobjettypeschemacomptableprofilwebDTO.PO_CODEPROFILWEB.ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION = clsLogicielobjettypeschemacomptableprofilwebDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsObjetEnvoi.OE_A = clsLogicielobjettypeschemacomptableprofilwebDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsLogicielobjettypeschemacomptableprofilwebDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsLogicielobjettypeschemacomptableprofilwebDTO.PO_CODEPROFILWEB };
                    clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableprofilwebWSBLL.pvgModifier(clsDonnee, clsLogicielobjettypeschemacomptableprofilweb, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableprofilwebs;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> pvgSupprimer(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
            //    clsLogicielobjettypeschemacomptableprofilwebs = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
                //--TEST CONTRAINTE
                clsLogicielobjettypeschemacomptableprofilwebs = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PO_CODEPROFILWEB };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsLogicielobjettypeschemacomptableprofilwebWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
                }
                else
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
                clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsLogicielobjettypeschemacomptableprofilwebs;
        }*/


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public string pvgChargerDansDataSet(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> Objet)
            {

            DataSet DataSet = new DataSet();
            string json = "";
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            //DataSet DataSeterror = new DataSet();

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                DataSet = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
                //--TEST CONTRAINTE
                DataSet = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].AG_CODEAGENCE, Objet[0].NF_CODENATUREFAMILLEOPERATION, Objet[0].FO_CODEFAMILLEOPERATION, Objet[0].PO_CODEPROFILWEB };
           // DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjettypeschemacomptableprofilwebWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

                    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    {
                        DataSet.Tables[0].Rows[i]["SL_CODEMESSAGE"] = "00";
                        DataSet.Tables[0].Rows[i]["SL_RESULTAT"] = "TRUE";
                        DataSet.Tables[0].Rows[i]["SL_MESSAGE"] = "Opération réalisée avec succès !!!";

                    }

                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
            else
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Aucun enregistrement trouvé !!!";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                


            }
            catch (SqlException SQLEx)
            {

                //HT_Stock.BOJ.clsPhatiers clsProfilwebdroit = new HT_Stock.BOJ.clsProfilwebdroit();
                //  clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);

            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

                //Execution du log
                Log.Error(SQLEx.Message, null);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return json;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
     /*   public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> pvgChargerDansDataSetOperateurDroit(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        for (int Idx = 0; Idx < Objet.Count; Idx++)
        {
            //--TEST DES CHAMPS OBLIGATOIRES
            clsLogicielobjettypeschemacomptableprofilwebs = TestChampObligatoireListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
            //--TEST CONTRAINTE
            clsLogicielobjettypeschemacomptableprofilwebs = TestTestContrainteListe(Objet[Idx]);
            //--VERIFICATION DU RESULTAT DU TEST
            if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
        }

           // "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION", "@PO_CODEPROFILWEB"
        clsObjetEnvoi.OE_PARAM= new string[] {Objet[0].AG_CODEAGENCE, Objet[0].NF_CODENATUREFAMILLEOPERATION, Objet[0].FO_CODEFAMILLEOPERATION, Objet[0].PO_CODEPROFILWEB };
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsLogicielobjettypeschemacomptableprofilwebWSBLL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi);
        clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.FO_LIBELLEFAMILLEOPERATION = row["FO_LIBELLEFAMILLEOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NO_SENS = row["NO_SENS"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NO_PREFIXECOMPTE = row["NO_PREFIXECOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NO_REFPIECE = row["NO_REFPIECE"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.COCHER = row["COCHER"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NO_ABREVIATION = row["NO_ABREVIATION"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NO_MONTANT = row["NO_MONTANT"].ToString();
                clsLogicielobjettypeschemacomptableprofilweb.NO_NUMEROORDRE = row["NO_NUMEROORDRE"].ToString();



                        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
            }
        }
        else
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
        clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
        clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeschemacomptableprofilwebs;
        }







        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsLogicielobjettypeschemacomptableprofilwebs = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
        //    //--TEST CONTRAINTE
        //    clsLogicielobjettypeschemacomptableprofilwebs = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsLogicielobjettypeschemacomptableprofilwebs[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsLogicielobjettypeschemacomptableprofilwebs;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsLogicielobjettypeschemacomptableprofilwebWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                    clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB = row["PO_CODEPROFILWEB"].ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
                }
            }
            else
            {
                HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
            clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb();
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsLogicielobjettypeschemacomptableprofilweb.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsLogicielobjettypeschemacomptableprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofilweb>();
            clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsLogicielobjettypeschemacomptableprofilwebs;
    }
        */

        
    }
}
