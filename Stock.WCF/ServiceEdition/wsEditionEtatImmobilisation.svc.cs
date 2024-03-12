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
using Stock.BOJ;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsEditionEtatImmobilisation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsEditionEtatImmobilisation.svc ou wsEditionEtatImmobilisation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsEditionEtatImmobilisation : IwsEditionEtatImmobilisation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsEditionEtatImmobilisationWSBLL clsEditionEtatImmobilisationWSBLL = new clsEditionEtatImmobilisationWSBLL();

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
        public List<HT_Stock.BOJ.clsEditionEtatImmobilisation> pvgETATFAMILLEIMMOBILISATION(List<HT_Stock.BOJ.clsEditionEtatImmobilisation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsEditionEtatImmobilisation> clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsEditionEtatImmobilisations = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatImmobilisations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatImmobilisations;
                //--TEST CONTRAINTE
                clsEditionEtatImmobilisations = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsEditionEtatImmobilisations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsEditionEtatImmobilisations;
            }


            clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
                Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation1 = new Stock.BOJ.clsEditionEtatImmobilisation();


                foreach (HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisationDTO in Objet)
                {
                    clsEditionEtatImmobilisation1.AG_CODEAGENCE = clsEditionEtatImmobilisationDTO.AG_CODEAGENCE.ToString();
                    clsEditionEtatImmobilisation1.EN_CODEENTREPOT = clsEditionEtatImmobilisationDTO.EN_CODEENTREPOT.ToString();
                    clsEditionEtatImmobilisation1.PS_CODESOUSPRODUIT = clsEditionEtatImmobilisationDTO.PS_CODESOUSPRODUIT.ToString();
                    clsEditionEtatImmobilisation1.OP_CODEOPERATEUREDITION = clsEditionEtatImmobilisationDTO.OP_CODEOPERATEUREDITION.ToString();
                    clsEditionEtatImmobilisation1.DATEDEBUT = clsEditionEtatImmobilisationDTO.DATEDEBUT.ToString();
                    clsEditionEtatImmobilisation1.DATEFIN = clsEditionEtatImmobilisationDTO.DATEFIN.ToString();
                    clsEditionEtatImmobilisation1.OP_CODEOPERATEUR = clsEditionEtatImmobilisationDTO.OP_CODEOPERATEUR.ToString();
                    clsEditionEtatImmobilisation1.ET_TYPEETAT = clsEditionEtatImmobilisationDTO.ET_TYPEETAT.ToString();
                    clsObjetEnvoi.OE_A = clsEditionEtatImmobilisationDTO.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = clsEditionEtatImmobilisationDTO.clsObjetEnvoi.OE_Y;


                }


                DataSet = clsEditionEtatImmobilisationWSBLL.pvgETATFAMILLEIMMOBILISATION(clsDonnee, clsEditionEtatImmobilisation1, clsObjetEnvoi);
                clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();
                      
                    clsEditionEtatImmobilisation.PS_CODESOUSPRODUIT = row["PS_CODESOUSPRODUIT"].ToString();
                    clsEditionEtatImmobilisation.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = row["PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT"].ToString();

                    clsEditionEtatImmobilisation.NT_CODENATUREBIEN = row["NT_CODENATUREBIEN"].ToString();
                    clsEditionEtatImmobilisation.PL_CODENUMCOMPTE = row["PL_CODENUMCOMPTE"].ToString();
                    clsEditionEtatImmobilisation.PS_LIBELLECOMPTEAMORTISSEMENT = row["PS_LIBELLECOMPTEAMORTISSEMENT"].ToString();
                    clsEditionEtatImmobilisation.PL_NUMCOMPTEAMORTISSEMENT = row["PL_NUMCOMPTEAMORTISSEMENT"].ToString();
                    clsEditionEtatImmobilisation.PL_NUMCOMPTE = row["PL_NUMCOMPTE"].ToString();
                    clsEditionEtatImmobilisation.PS_LIBELLE = row["PS_LIBELLE"].ToString();
                    clsEditionEtatImmobilisation.PS_DUREEMINIMUM = row["PS_DUREEMINIMUM"].ToString();
                    clsEditionEtatImmobilisation.PS_DUREEMAXIMUM = row["PS_DUREEMAXIMUM"].ToString();
                    clsEditionEtatImmobilisation.PS_AMORTISSEMENTDIRECT = row["PS_AMORTISSEMENTDIRECT"].ToString();
                    clsEditionEtatImmobilisation.PS_AMORTISSEMENTBIEN = row["PS_AMORTISSEMENTBIEN"].ToString();
                    clsEditionEtatImmobilisation.PS_AMORTISSEMENTVALEURRESIDUELLEZERO = row["PS_AMORTISSEMENTVALEURRESIDUELLEZERO"].ToString();
                    clsEditionEtatImmobilisation.PS_ACTIF = row["PS_ACTIF"].ToString();
                    clsEditionEtatImmobilisation.PS_NUMEROORDRE = row["PS_NUMEROORDRE"].ToString();
                    clsEditionEtatImmobilisation.PS_DATESAISIE =DateTime.Parse( row["PS_DATESAISIE"].ToString()).ToShortDateString();
                        
                    clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
                    clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès !!!";
                    clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();
                clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsEditionEtatImmobilisations;
    }


    }
}
