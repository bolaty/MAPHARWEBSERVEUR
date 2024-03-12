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
    public class clsMicbudgetparamtypedetailWSBLL : IObjetWSBLL<clsMicbudgetparamtypedetail>
    {
        private clsMicbudgetparamtypedetailWSDAL clsMicbudgetparamtypedetailWSDAL = new clsMicbudgetparamtypedetailWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparamtypedetailWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparamtypedetailWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparamtypedetailWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMicbudgetparamtypedetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMicbudgetparamtypedetail pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparamtypedetailWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicbudgetparamtypedetail">clsMicbudgetparamtypedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter(clsDonnee clsDonnee, clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsMicbudgetparamtypedetailWSDAL.pvgInsert(clsDonnee, clsMicbudgetparamtypedetail);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL.ToString(), "A"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicbudgetparamtypedetails"> Liste d'objet clsMicbudgetparamtypedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            clsMicbudgetparamtypedetailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            for (int Idx = 0; Idx < clsMicbudgetparamtypedetails.Count; Idx++)
            {
                clsMicbudgetparamtypedetails[Idx].BD_CODETYPEBUDGETDETAIL = string.Format("{0:0000}", double.Parse(clsMicbudgetparamtypedetailWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                clsMicbudgetparamtypedetailWSDAL.pvgInsert(clsDonnee, clsMicbudgetparamtypedetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetparamtypedetails[Idx].BD_CODETYPEBUDGETDETAIL.ToString(), "A"));
            }
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicbudgetparamtypedetail">clsMicbudgetparamtypedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifier(clsDonnee clsDonnee, clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsMicbudgetparamtypedetailWSDAL.pvgUpdate(clsDonnee, clsMicbudgetparamtypedetail, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsMicbudgetparamtypedetailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            string vppValeurMouchard = clsObjetEnvoi.OE_PARAM.Length > 0 ? clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
            return "";
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Une collection de clsMicbudgetparamtypedetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparamtypedetail> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparamtypedetailWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetparamtypedetail </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetparamtypedetail> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparamtypedetailWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparamtypedetailWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicbudgetparamtypedetailWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
                    clsMouchard.MO_ACTION = "MICBUDGETPARAMTYPEDETAIL  (Ajout)  : " + vppAction;
                    break;
                case "M": clsMouchard.MO_ACTION = "MICBUDGETPARAMTYPEDETAIL  (Modification)  : " + vppAction;
                    break;
                case "S":
                    clsMouchard.MO_ACTION = "MICBUDGETPARAMTYPEDETAIL  (Suppression)  : " + vppAction;
                    break;
                case "E":
                    clsMouchard.MO_ACTION = "MICBUDGETPARAMTYPEDETAIL  (Edition de l'etatEdition de l'etat)  : " + vppAction;
                    break;
            }
            return clsMouchard;
        }
    }
}
