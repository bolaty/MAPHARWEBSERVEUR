using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSDAL;

namespace Stock.WSBLL
{
    public class clsMicbudgetparampostebudgetairedetailWSBLL : IObjetWSBLL<clsMicbudgetparampostebudgetairedetail>
    {
        private clsMicbudgetparampostebudgetairedetailWSDAL clsMicbudgetparampostebudgetairedetailWSDAL = new clsMicbudgetparampostebudgetairedetailWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparampostebudgetairedetailWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparampostebudgetairedetailWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparampostebudgetairedetailWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMicbudgetparampostebudgetairedetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMicbudgetparampostebudgetairedetail pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparampostebudgetairedetailWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicbudgetparampostebudgetairedetail">clsMicbudgetparampostebudgetairedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter(clsDonnee clsDonnee, clsMicbudgetparampostebudgetairedetail clsMicbudgetparampostebudgetairedetail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsMicbudgetparampostebudgetairedetail.BG_CODEPOSTEBUDGETAIRE = string.Format("{0:0000000}", double.Parse(clsMicbudgetparampostebudgetairedetailWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
            clsMicbudgetparampostebudgetairedetailWSDAL.pvgInsert(clsDonnee, clsMicbudgetparampostebudgetairedetail);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetparampostebudgetairedetail.BG_CODEPOSTEBUDGETAIRE.ToString(), "A"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicbudgetparampostebudgetairedetails"> Liste d'objet clsMicbudgetparampostebudgetairedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsMicbudgetparampostebudgetairedetail> clsMicbudgetparampostebudgetairedetails, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            clsMicbudgetparampostebudgetairedetailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            for (int Idx = 0; Idx < clsMicbudgetparampostebudgetairedetails.Count; Idx++)
            {
                clsMicbudgetparampostebudgetairedetailWSDAL.pvgInsert(clsDonnee, clsMicbudgetparampostebudgetairedetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetparampostebudgetairedetails[Idx].BG_CODEPOSTEBUDGETAIRE.ToString(), "A"));
            }
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicbudgetparampostebudgetairedetail">clsMicbudgetparampostebudgetairedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifier(clsDonnee clsDonnee, clsMicbudgetparampostebudgetairedetail clsMicbudgetparampostebudgetairedetail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsMicbudgetparampostebudgetairedetailWSDAL.pvgUpdate(clsDonnee, clsMicbudgetparampostebudgetairedetail, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetparampostebudgetairedetail.BG_CODEPOSTEBUDGETAIRE.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsMicbudgetparampostebudgetairedetailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            string vppValeurMouchard = clsObjetEnvoi.OE_PARAM.Length > 0 ? clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
            return "";
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Une collection de clsMicbudgetparampostebudgetairedetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparampostebudgetairedetail> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparampostebudgetairedetailWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparampostebudgetairedetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparampostebudgetairedetail> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparampostebudgetairedetailWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparampostebudgetairedetailWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BG_CODEPOSTEBUDGETAIRE, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparampostebudgetairedetailWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de generer le mouchard</summary>
        ///<param name="vppAction">Action réalisé</param>
        ///<param name="vppTypeAction">Type d'action</param>
        ///<returns>clsMouchard</returns>
        ///<author>Home Technologie</author>
        public clsMouchard pvpGenererMouchard(clsObjetEnvoi clsObjetEnvoi, string vppAction, string vppTypeAction)
        {
            clsMouchard clsMouchard = new clsMouchard();
            clsMouchard.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
            clsMouchard.OP_CODEOPERATEUR = clsObjetEnvoi.OE_Y;
            switch (vppTypeAction)
            {
                case "A":
                    clsMouchard.MO_ACTION = "MICBUDGETPARAMPOSTEBUDGETAIREDETAIL  (Ajout)  : " + vppAction;
                    break;
                case "M": clsMouchard.MO_ACTION = "MICBUDGETPARAMPOSTEBUDGETAIREDETAIL  (Modification)  : " + vppAction;
                    break;
                case "S":
                    clsMouchard.MO_ACTION = "MICBUDGETPARAMPOSTEBUDGETAIREDETAIL  (Suppression)  : " + vppAction;
                    break;
                case "E":
                    clsMouchard.MO_ACTION = "MICBUDGETPARAMPOSTEBUDGETAIREDETAIL  (Edition de l'etatEdition de l'etat)  : " + vppAction;
                    break;
            }
            return clsMouchard;
        }
    }
}
