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
    public class clsBusinessplanparampostedetailWSBLL : IObjetWSBLL<clsBusinessplanparampostedetail>
    {
        private clsBusinessplanparampostedetailWSDAL clsBusinessplanparampostedetailWSDAL = new clsBusinessplanparampostedetailWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsBusinessplanparampostedetailWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsBusinessplanparampostedetailWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsBusinessplanparampostedetailWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsBusinessplanparampostedetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsBusinessplanparampostedetail pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsBusinessplanparampostedetailWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsBusinessplanparampostedetail">clsBusinessplanparampostedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter(clsDonnee clsDonnee, clsBusinessplanparampostedetail clsBusinessplanparampostedetail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsBusinessplanparampostedetail.PO_CODEPOSTEBUSINESSPLAN = string.Format("{0:0000000}", double.Parse(clsBusinessplanparampostedetailWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
            clsBusinessplanparampostedetailWSDAL.pvgInsert(clsDonnee, clsBusinessplanparampostedetail);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsBusinessplanparampostedetail.PO_CODEPOSTEBUSINESSPLAN.ToString(), "A"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsBusinessplanparampostedetails"> Liste d'objet clsBusinessplanparampostedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsBusinessplanparampostedetail> clsBusinessplanparampostedetails, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            clsBusinessplanparampostedetailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            for (int Idx = 0; Idx < clsBusinessplanparampostedetails.Count; Idx++)
            {
                clsBusinessplanparampostedetailWSDAL.pvgInsert(clsDonnee, clsBusinessplanparampostedetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsBusinessplanparampostedetails[Idx].PO_CODEPOSTEBUSINESSPLAN.ToString(), "A"));
            }
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsBusinessplanparampostedetail">clsBusinessplanparampostedetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifier(clsDonnee clsDonnee, clsBusinessplanparampostedetail clsBusinessplanparampostedetail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsBusinessplanparampostedetailWSDAL.pvgUpdate(clsDonnee, clsBusinessplanparampostedetail, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsBusinessplanparampostedetail.PO_CODEPOSTEBUSINESSPLAN.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsBusinessplanparampostedetailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            string vppValeurMouchard = clsObjetEnvoi.OE_PARAM.Length > 0 ? clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
            return "";
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Une collection de clsBusinessplanparampostedetail </returns>
        ///<author>Home Technology</author>
        public List<clsBusinessplanparampostedetail> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsBusinessplanparampostedetailWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsBusinessplanparampostedetail </returns>
        ///<author>Home Technology</author>
        public List<clsBusinessplanparampostedetail> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsBusinessplanparampostedetailWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsBusinessplanparampostedetailWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsBusinessplanparampostedetailWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
                    clsMouchard.MO_ACTION = "Businessplanparampostedetail  (Ajout)  : " + vppAction;
                    break;
                case "M": clsMouchard.MO_ACTION = "Businessplanparampostedetail  (Modification)  : " + vppAction;
                    break;
                case "S":
                    clsMouchard.MO_ACTION = "Businessplanparampostedetail  (Suppression)  : " + vppAction;
                    break;
                case "E":
                    clsMouchard.MO_ACTION = "Businessplanparampostedetail  (Edition de l'etatEdition de l'etat)  : " + vppAction;
                    break;
            }
            return clsMouchard;
        }
    }
}
