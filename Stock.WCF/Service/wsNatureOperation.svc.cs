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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsNatureOperation" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsNatureOperation.svc ou wsNatureOperation.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsNatureOperation : IwsNatureOperation
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsPhaparnatureoperationWSBLL clsPhaparnatureoperationWSBLL = new clsPhaparnatureoperationWSBLL();

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
        public List<HT_Stock.BOJ.clsPhaparnatureoperation> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhaparnatureoperation> Objet)
         {

        List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
        List<HT_Stock.BOJ.clsPhaparnatureoperation> clsPhaparnatureoperations = new List<HT_Stock.BOJ.clsPhaparnatureoperation>();
           
        Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
        clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
        clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


        //for (int Idx = 0; Idx < Objet.Count; Idx++)
        //{
        //    //--TEST DES CHAMPS OBLIGATOIRES
        //    clsPhaparnatureoperations = TestChampObligatoireListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhaparnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnatureoperations;
        //    //--TEST CONTRAINTE
        //    clsPhaparnatureoperations = TestTestContrainteListe(Objet[Idx]);
        //    //--VERIFICATION DU RESULTAT DU TEST
        //    if (clsPhaparnatureoperations[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsPhaparnatureoperations;
        //}

      
        clsObjetEnvoi.OE_PARAM= new string[] {};
        DataSet DataSet = new DataSet();

        try
        {
            clsDonnee.pvgConnectionBase();
            DataSet = clsPhaparnatureoperationWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi);
            clsPhaparnatureoperations = new List<HT_Stock.BOJ.clsPhaparnatureoperation>();
            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DataSet.Tables[0].Rows)
                {
                    HT_Stock.BOJ.clsPhaparnatureoperation clsPhaparnatureoperation = new HT_Stock.BOJ.clsPhaparnatureoperation();
                    clsPhaparnatureoperation.NO_CODENATUREOPERATION = row["NO_CODENATUREOPERATION"].ToString();
                    clsPhaparnatureoperation.NO_LIBELLE = row["NO_LIBELLE"].ToString();
                    clsPhaparnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhaparnatureoperation.clsObjetRetour.SL_CODEMESSAGE ="00";
                    clsPhaparnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhaparnatureoperation.clsObjetRetour.SL_MESSAGE ="Opération réalisée avec succès";
                    clsPhaparnatureoperations.Add(clsPhaparnatureoperation);
                }
            }
            else
            {
                HT_Stock.BOJ.clsPhaparnatureoperation clsPhaparnatureoperation = new HT_Stock.BOJ.clsPhaparnatureoperation();
                clsPhaparnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsPhaparnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhaparnatureoperation.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé";
                clsPhaparnatureoperations.Add(clsPhaparnatureoperation);
            }
                


        }
        catch (SqlException SQLEx)
        {
            HT_Stock.BOJ.clsPhaparnatureoperation clsPhaparnatureoperation = new HT_Stock.BOJ.clsPhaparnatureoperation();
            clsPhaparnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnatureoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnatureoperations = new List<HT_Stock.BOJ.clsPhaparnatureoperation>();
            clsPhaparnatureoperations.Add(clsPhaparnatureoperation);
        }
        catch (Exception SQLEx)
        {
            HT_Stock.BOJ.clsPhaparnatureoperation clsPhaparnatureoperation = new HT_Stock.BOJ.clsPhaparnatureoperation();
            clsPhaparnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "99";
            clsPhaparnatureoperation.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
            clsPhaparnatureoperation.clsObjetRetour.SL_RESULTAT ="FALSE";
            //Execution du log
            Log.Error(SQLEx.Message, null);
            clsPhaparnatureoperations = new List<HT_Stock.BOJ.clsPhaparnatureoperation>();
            clsPhaparnatureoperations.Add(clsPhaparnatureoperation);
        }


        finally
        {
            clsDonnee.pvgDeConnectionBase();
        }
        return clsPhaparnatureoperations;
    }


        
    }
}
