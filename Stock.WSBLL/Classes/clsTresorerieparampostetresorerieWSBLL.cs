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
	public class clsTresorerieparampostetresorerieWSBLL: IObjetWSBLL<clsTresorerieparampostetresorerie>
	{
		private clsTresorerieparampostetresorerieWSDAL clsTresorerieparampostetresorerieWSDAL= new clsTresorerieparampostetresorerieWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparampostetresorerieWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparampostetresorerieWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparampostetresorerieWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsTresorerieparampostetresorerie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsTresorerieparampostetresorerie pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparampostetresorerieWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsTresorerieparampostetresorerie">clsTresorerieparampostetresorerie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsTresorerieparampostetresorerie clsTresorerieparampostetresorerie , clsObjetEnvoi clsObjetEnvoi)
		{
			clsTresorerieparampostetresorerie.TP_CODEPOSTETRESORERIE = string.Format( "{0:0000000}" , double.Parse(clsTresorerieparampostetresorerieWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsTresorerieparampostetresorerieWSDAL.pvgInsert(clsDonnee, clsTresorerieparampostetresorerie);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieparampostetresorerie.TP_CODEPOSTETRESORERIE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsTresorerieparampostetresoreries"> Liste d'objet clsTresorerieparampostetresorerie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsTresorerieparampostetresorerie> clsTresorerieparampostetresoreries , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsTresorerieparampostetresorerieWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsTresorerieparampostetresoreries.Count; Idx++)
			{
				clsTresorerieparampostetresoreries[Idx].TP_CODEPOSTETRESORERIE = string.Format( "{0:0000000}" , double.Parse(clsTresorerieparampostetresorerieWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsTresorerieparampostetresorerieWSDAL.pvgInsert(clsDonnee, clsTresorerieparampostetresoreries[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieparampostetresoreries[Idx].TP_CODEPOSTETRESORERIE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsTresorerieparampostetresorerie">clsTresorerieparampostetresorerie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsTresorerieparampostetresorerie clsTresorerieparampostetresorerie,clsObjetEnvoi clsObjetEnvoi)
		{
			clsTresorerieparampostetresorerieWSDAL.pvgUpdate(clsDonnee, clsTresorerieparampostetresorerie, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieparampostetresorerie.TP_CODEPOSTETRESORERIE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsTresorerieparampostetresorerieWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsTresorerieparampostetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparampostetresorerie> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparampostetresorerieWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieparampostetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparampostetresorerie> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparampostetresorerieWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparampostetresorerieWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparampostetresorerieWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "TRESORERIEPARAMPOSTETRESORERIE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "TRESORERIEPARAMPOSTETRESORERIE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "TRESORERIEPARAMPOSTETRESORERIE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "TRESORERIEPARAMPOSTETRESORERIE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
