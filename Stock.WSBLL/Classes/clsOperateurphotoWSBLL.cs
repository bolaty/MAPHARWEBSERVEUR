using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSDAL;


namespace Stock.WSBLL
{

    public class clsOperateurphotoWSBLL
    {

        private clsOperateurphotoWSDAL clsOperateurphotoWSDAL = new clsOperateurphotoWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:OP_CODEOPERATEUR)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
        ///<returns>clsOperateur </returns>
        ///<author>Home Technologie</author>
        public clsOperateurphoto pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOperateurphotoWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsOperateurphoto">clsOperateurphoto</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgAjouter(clsDonnee clsDonnee, clsOperateurphoto clsOperateurphoto, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOperateurphotoWSDAL.pvgInsert(clsDonnee, clsOperateurphoto);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurphoto.OP_CODEOPERATEUR.ToString(), "A"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:AC_CODEACTIVITE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOperateurphotoWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            string vppValeurMouchard = clsObjetEnvoi.OE_PARAM.Length > 0 ? clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
            return "";
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
                    clsMouchard.MO_ACTION = "OperateurPHOTO  (Ajout)  : " + vppAction;
                    break;
                case "M":
                    clsMouchard.MO_ACTION = "OperateurPHOTO  (Modification)  : " + vppAction;
                    break;
                case "S":
                    clsMouchard.MO_ACTION = "OperateurPHOTO  (Suppression)  : " + vppAction;
                    break;
                case "E":
                    clsMouchard.MO_ACTION = "OperateurPHOTO  (Edition de l'etatEdition de l'etat)  : " + vppAction;
                    break;
            }
            return clsMouchard;
        }



    }
}