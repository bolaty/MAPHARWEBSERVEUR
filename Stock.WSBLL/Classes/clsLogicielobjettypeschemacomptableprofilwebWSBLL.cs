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
	public class clsLogicielobjettypeschemacomptableprofilwebWSBLL: IObjetWSBLL<clsLogicielobjettypeschemacomptableprofilweb>
	{
		private clsLogicielobjettypeschemacomptableprofilwebWSDAL clsLogicielobjettypeschemacomptableprofilwebWSDAL= new clsLogicielobjettypeschemacomptableprofilwebWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsLogicielobjettypeschemacomptableprofilweb comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsLogicielobjettypeschemacomptableprofilweb pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsLogicielobjettypeschemacomptableprofilweb">clsLogicielobjettypeschemacomptableprofilweb</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgInsert(clsDonnee, clsLogicielobjettypeschemacomptableprofilweb);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsLogicielobjettypeschemacomptableprofilwebs"> Liste d'objet clsLogicielobjettypeschemacomptableprofilweb</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsLogicielobjettypeschemacomptableprofilwebs.Count; Idx++)
			{
                //clsLogicielobjettypeschemacomptableprofilwebs[Idx].AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                if (clsLogicielobjettypeschemacomptableprofilwebs[Idx].COCHER == "O")
                {
                    clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgInsert(clsDonnee, clsLogicielobjettypeschemacomptableprofilwebs[Idx]);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsLogicielobjettypeschemacomptableprofilwebs[Idx].AG_CODEAGENCE.ToString(), "A"));
                }
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsLogicielobjettypeschemacomptableprofilweb">clsLogicielobjettypeschemacomptableprofilweb</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb,clsObjetEnvoi clsObjetEnvoi)
		{
			clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgUpdate(clsDonnee, clsLogicielobjettypeschemacomptableprofilweb, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsLogicielobjettypeschemacomptableprofilweb </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeschemacomptableprofilweb> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeschemacomptableprofilweb </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeschemacomptableprofilweb> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurDroit(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsLogicielobjettypeschemacomptableprofilwebWSDAL.pvgChargerDansDataSetOperateurDroit(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



		///<summary>Cette fonction permet de generer le mouchard</summary>
		///<param name="vppAction">Action réalisé</param>
		///<param name="vppTypeAction">Type d'action</param>
		///<returns>clsMouchard</returns>
		///<author>Home Technologie</author>
		public clsMouchard pvpGenererMouchard(clsObjetEnvoi clsObjetEnvoi,string vppAction, string vppTypeAction)
		{
			clsMouchard clsMouchard = new clsMouchard();
			clsMouchard.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
			clsMouchard.OP_CODEOPERATEUR = clsObjetEnvoi.OE_Y;
			switch (vppTypeAction)
			{
				case "A":
					clsMouchard.MO_ACTION = "LOGICIELOBJETTYPESCHEMACOMPTABLEOPERATEUR2  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "LOGICIELOBJETTYPESCHEMACOMPTABLEOPERATEUR2  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "LOGICIELOBJETTYPESCHEMACOMPTABLEOPERATEUR2  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "LOGICIELOBJETTYPESCHEMACOMPTABLEOPERATEUR2  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
