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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsPhamouvementstockreglementnatureoperation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsPhamouvementstockreglementnatureoperation.svc ou wsPhamouvementstockreglementnatureoperation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsPhamouvementstockreglementnatureoperation : IwsPhamouvementstockreglementnatureoperation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhamouvementstockreglementnatureoperationWSBLL clsPhamouvementstockreglementnatureoperationWSBLL = new clsPhamouvementstockreglementnatureoperationWSBLL();

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
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> pvgAjouter(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglementnatureoperations = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglementnatureoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
            }
            //clsObjetEnvoi.OE_PARAM = new string[] {};
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperationDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = clsPhamouvementstockreglementnatureoperationDTO.NO_CODENATUREOPERATION.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = clsPhamouvementstockreglementnatureoperationDTO.NO_LIBELLE.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION = clsPhamouvementstockreglementnatureoperationDTO.NO_ABREVIATION.ToString();
                    clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION = clsPhamouvementstockreglementnatureoperationDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsPhamouvementstockreglementnatureoperation.NF_CODENATUREFAMILLEOPERATION = clsPhamouvementstockreglementnatureoperationDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE = clsPhamouvementstockreglementnatureoperationDTO.PL_CODENUMCOMPTE.ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTE = clsPhamouvementstockreglementnatureoperationDTO.PL_NUMCOMPTE.ToString();
                    clsPhamouvementstockreglementnatureoperation.RO_CODENATUREOPERATIONTYPE = clsPhamouvementstockreglementnatureoperationDTO.RO_CODENATUREOPERATIONTYPE.ToString();


                     clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperationDTO.PL_CODENUMCOMPTECONTREPARTIE.ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperationDTO.PL_NUMCOMPTECONTREPARTIE.ToString();


                    clsPhamouvementstockreglementnatureoperation.NO_MONTANT =double.Parse(clsPhamouvementstockreglementnatureoperationDTO.NO_MONTANT.ToString());
                    clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE =int.Parse( clsPhamouvementstockreglementnatureoperationDTO.NO_NUMEROORDRE.ToString());
                    clsPhamouvementstockreglementnatureoperation.NO_MODIFIERMONTANT = clsPhamouvementstockreglementnatureoperationDTO.NO_MODIFIERMONTANT.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_AFFICHER = clsPhamouvementstockreglementnatureoperationDTO.NO_AFFICHER.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME = clsPhamouvementstockreglementnatureoperationDTO.NO_OPERATIONSYSTEME.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_ECRAN = clsPhamouvementstockreglementnatureoperationDTO.NO_ECRAN.ToString();
                    clsPhamouvementstockreglementnatureoperation.TYPEOPERATION =int.Parse( clsPhamouvementstockreglementnatureoperationDTO.TYPEOPERATION.ToString());
                    clsPhamouvementstockreglementnatureoperation.NO_SENS = clsPhamouvementstockreglementnatureoperationDTO.NO_SENS.ToString();
                    clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTE = clsPhamouvementstockreglementnatureoperationDTO.NC_CODENATURECOMPTE.ToString();
                    clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperationDTO.NC_CODENATURECOMPTECONTREPARTIE.ToString();
                    clsPhamouvementstockreglementnatureoperation.JO_CODEJOURNAL = clsPhamouvementstockreglementnatureoperationDTO.JO_CODEJOURNAL.ToString();
                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementnatureoperationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementnatureoperationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementnatureoperationWSBLL.pvgAjouter(clsDonnee, clsPhamouvementstockreglementnatureoperation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglementnatureoperations;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> pvgModifier(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> Objet)
        {
            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglementnatureoperations = TestChampObligatoireUpdate(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglementnatureoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
            }
            
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            try
            {
                clsDonnee.pvgConnectionBase();
                foreach (HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperationDTO in Objet)
                {
                    Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new Stock.BOJ.clsPhamouvementstockreglementnatureoperation();

                    clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = clsPhamouvementstockreglementnatureoperationDTO.NO_CODENATUREOPERATION.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = clsPhamouvementstockreglementnatureoperationDTO.NO_LIBELLE.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION = clsPhamouvementstockreglementnatureoperationDTO.NO_ABREVIATION.ToString();
                    clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION = clsPhamouvementstockreglementnatureoperationDTO.FO_CODEFAMILLEOPERATION.ToString();
                    clsPhamouvementstockreglementnatureoperation.NF_CODENATUREFAMILLEOPERATION = clsPhamouvementstockreglementnatureoperationDTO.NF_CODENATUREFAMILLEOPERATION.ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE = clsPhamouvementstockreglementnatureoperationDTO.PL_CODENUMCOMPTE.ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTE = clsPhamouvementstockreglementnatureoperationDTO.PL_NUMCOMPTE.ToString();
                    clsPhamouvementstockreglementnatureoperation.RO_CODENATUREOPERATIONTYPE = clsPhamouvementstockreglementnatureoperationDTO.RO_CODENATUREOPERATIONTYPE.ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperationDTO.PL_CODENUMCOMPTECONTREPARTIE.ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperationDTO.PL_NUMCOMPTECONTREPARTIE.ToString();



                    clsPhamouvementstockreglementnatureoperation.NO_MONTANT = double.Parse(clsPhamouvementstockreglementnatureoperationDTO.NO_MONTANT.ToString());
                    clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE = int.Parse(clsPhamouvementstockreglementnatureoperationDTO.NO_NUMEROORDRE.ToString());
                    clsPhamouvementstockreglementnatureoperation.NO_MODIFIERMONTANT = clsPhamouvementstockreglementnatureoperationDTO.NO_MODIFIERMONTANT.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_AFFICHER = clsPhamouvementstockreglementnatureoperationDTO.NO_AFFICHER.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME = clsPhamouvementstockreglementnatureoperationDTO.NO_OPERATIONSYSTEME.ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_ECRAN = clsPhamouvementstockreglementnatureoperationDTO.NO_ECRAN.ToString();
                    clsPhamouvementstockreglementnatureoperation.TYPEOPERATION = int.Parse(clsPhamouvementstockreglementnatureoperationDTO.TYPEOPERATION.ToString());
                    clsPhamouvementstockreglementnatureoperation.NO_SENS = clsPhamouvementstockreglementnatureoperationDTO.NO_SENS.ToString();
                    clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTE = clsPhamouvementstockreglementnatureoperationDTO.NC_CODENATURECOMPTE.ToString();
                    clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperationDTO.NC_CODENATURECOMPTECONTREPARTIE.ToString();
                    clsPhamouvementstockreglementnatureoperation.JO_CODEJOURNAL = clsPhamouvementstockreglementnatureoperationDTO.JO_CODEJOURNAL.ToString();



                    clsObjetEnvoi.OE_A = clsPhamouvementstockreglementnatureoperationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsPhamouvementstockreglementnatureoperationDTO.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsPhamouvementstockreglementnatureoperationDTO.NO_CODENATUREOPERATION };
                    clsObjetRetour.SetValue(true, clsPhamouvementstockreglementnatureoperationWSBLL.pvgModifier(clsDonnee, clsPhamouvementstockreglementnatureoperation, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);

                }
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }

            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglementnatureoperations;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> pvgSupprimer(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglementnatureoperations = TestChampObligatoireDelete(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglementnatureoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
            }


            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].NO_CODENATUREOPERATION };
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();

            try
            {
                clsDonnee.pvgConnectionBase();
                clsObjetEnvoi.OE_A = Objet[0].clsObjetEnvoi.OE_A;
                clsObjetEnvoi.OE_Y = Objet[0].clsObjetEnvoi.OE_Y;
                clsObjetRetour.SetValue(true, clsPhamouvementstockreglementnatureoperationWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "00";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                }
                else
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Echec de l'opération !!!";
                    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                }



            }
            catch (SqlException SQLEx)
            {


                string vlpMessage = (SQLEx.Number == 547) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
                if(SQLEx.Number != 547) vlpMessage =SQLEx.Message;

                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = vlpMessage;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(vlpMessage, null);
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglementnatureoperations;
        }


            ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
            ///<param name="Objet">Collection de clsInput </param>
            ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
            ///<author>Home Technology</author>
            public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> Objet)
            {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
           
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //    //--TEST DES CHAMPS OBLIGATOIRES
            //    clsPhamouvementstockreglementnatureoperations = TestChampObligatoireListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
            //    //--TEST CONTRAINTE
            //    clsPhamouvementstockreglementnatureoperations = TestTestContrainteListe(Objet[Idx]);
            //    //--VERIFICATION DU RESULTAT DU TEST
            //    if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
            //}

      
            clsObjetEnvoi.OE_PARAM= new string[] {};
            DataSet DataSet = new DataSet();

            try
            {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockreglementnatureoperationWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }
                


            }
            catch (SqlException SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }
            catch (Exception SQLEx)
            {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }


            finally
            {
            clsDonnee.pvgDeConnectionBase();
            }
            return clsPhamouvementstockreglementnatureoperations;
            }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> pvgChargerDansDataSetEcranParametrage(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> Objet)
        {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsPhamouvementstockreglementnatureoperations = TestChampObligatoireListeEcranParametrage(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
                //--TEST CONTRAINTE
                clsPhamouvementstockreglementnatureoperations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
            }


            clsObjetEnvoi.OE_PARAM= new string[] { Objet[0].NF_CODENATUREFAMILLEOPERATION ,Objet[0].FO_CODEFAMILLEOPERATION, Objet[0].ET_TYPEETAT1 };
        DataSet DataSet = new DataSet();

        try
        {
        clsDonnee.pvgConnectionBase();
        DataSet = clsPhamouvementstockreglementnatureoperationWSBLL.pvgChargerDansDataSetEcranParametrage(clsDonnee, clsObjetEnvoi);
        clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
        if (DataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION = row["NO_ABREVIATION"].ToString();
                clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION = row["FO_CODEFAMILLEOPERATION"].ToString();
                clsPhamouvementstockreglementnatureoperation.RO_CODENATUREOPERATIONTYPE = row["RO_CODENATUREOPERATIONTYPE"].ToString();
                clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTECONTREPARTIE = row["PL_CODENUMCOMPTECONTREPARTIE"].ToString();
                clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTECONTREPARTIE = row["PL_NUMCOMPTECONTREPARTIE"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_SENS = row["NO_SENS"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE = row["NO_PREFIXECOMPTE"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_REFPIECE = row["NO_REFPIECE"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_MONTANT =double.Parse(row["NO_MONTANT"].ToString());
                clsPhamouvementstockreglementnatureoperation.NO_AFFICHER = row["NO_AFFICHER"].ToString();
                clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS = row["PL_CODENUMCOMPTESURPLUS"].ToString();
                clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTESURPLUS = row["PL_NUMCOMPTESURPLUS"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME = row["NO_OPERATIONSYSTEME"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_ECRAN = row["NO_ECRAN"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE =int.Parse(row["NO_NUMEROORDRE"].ToString());
                clsPhamouvementstockreglementnatureoperation.NO_MODIFIERMONTANT = row["NO_MODIFIERMONTANT"].ToString();
                clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTE = row["NC_CODENATURECOMPTE"].ToString();
                clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTECONTREPARTIE = row["NC_CODENATURECOMPTECONTREPARTIE"].ToString();
                clsPhamouvementstockreglementnatureoperation.JO_CODEJOURNAL = row["JO_CODEJOURNAL"].ToString();

                clsPhamouvementstockreglementnatureoperation.NC_LIBELLENATURECOMPTECONTREPARTIE = row["NC_LIBELLENATURECOMPTECONTREPARTIE"].ToString();
                clsPhamouvementstockreglementnatureoperation.JO_LIBELLE = row["JO_LIBELLE"].ToString();
                clsPhamouvementstockreglementnatureoperation.NO_SENSLIBELLE = row["NO_SENSLIBELLE"].ToString();
                //this.JO_LIBELLE = clsPhamouvementstockreglementnatureoperation.JO_LIBELLE;
                //this.NC_LIBELLENATURECOMPTE = clsPhamouvementstockreglementnatureoperation.NC_LIBELLENATURECOMPTE;
                //this.NO_SENSLIBELLE = clsPhamouvementstockreglementnatureoperation.NO_SENSLIBELLE;



                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }
        }
        else
        {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
        }
                


        }
        catch (SqlException SQLEx)
        {
        HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
        clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
        clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
        clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
        }
        catch (Exception SQLEx)
        {
        HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
        clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
        clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
        clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
        clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
        //Execution du log
        Log.Error(SQLEx.Message, null);
        clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
        clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
        }


        finally
        {
        clsDonnee.pvgDeConnectionBase();
        }
        return clsPhamouvementstockreglementnatureoperations;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhamouvementstockreglementnatureoperations = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
        //    //--TEST CONTRAINTE
        //    clsPhamouvementstockreglementnatureoperations = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhamouvementstockreglementnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhamouvementstockreglementnatureoperations;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhamouvementstockreglementnatureoperationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                    clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhamouvementstockreglementnatureoperations;
    }


        
    }
}
