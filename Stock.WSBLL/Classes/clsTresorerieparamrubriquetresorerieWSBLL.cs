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
	public class clsTresorerieparamrubriquetresorerieWSBLL: IObjetWSBLL<clsTresorerieparamrubriquetresorerie>
	{
		private clsTresorerieparamrubriquetresorerieWSDAL clsTresorerieparamrubriquetresorerieWSDAL= new clsTresorerieparamrubriquetresorerieWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparamrubriquetresorerieWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparamrubriquetresorerieWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparamrubriquetresorerieWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsTresorerieparamrubriquetresorerie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsTresorerieparamrubriquetresorerie pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparamrubriquetresorerieWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsTresorerieparamrubriquetresorerie">clsTresorerieparamrubriquetresorerie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsTresorerieparamrubriquetresorerie clsTresorerieparamrubriquetresorerie , clsObjetEnvoi clsObjetEnvoi)
		{
			
			clsTresorerieparamrubriquetresorerieWSDAL.pvgInsert(clsDonnee, clsTresorerieparamrubriquetresorerie);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieparamrubriquetresorerie.TR_CODERUBRIQUETRESORERIE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsTresorerieparamrubriquetresoreries"> Liste d'objet clsTresorerieparamrubriquetresorerie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsTresorerieparamrubriquetresorerie> clsTresorerieparamrubriquetresoreries , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsTresorerieparamrubriquetresorerieWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsTresorerieparamrubriquetresoreries.Count; Idx++)
			{
				clsTresorerieparamrubriquetresoreries[Idx].TR_CODERUBRIQUETRESORERIE = string.Format( "{0:0000}" , double.Parse(clsTresorerieparamrubriquetresorerieWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsTresorerieparamrubriquetresorerieWSDAL.pvgInsert(clsDonnee, clsTresorerieparamrubriquetresoreries[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieparamrubriquetresoreries[Idx].TR_CODERUBRIQUETRESORERIE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsTresorerieparamrubriquetresorerie">clsTresorerieparamrubriquetresorerie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsTresorerieparamrubriquetresorerie clsTresorerieparamrubriquetresorerie,clsObjetEnvoi clsObjetEnvoi)
		{
			clsTresorerieparamrubriquetresorerieWSDAL.pvgUpdate(clsDonnee, clsTresorerieparamrubriquetresorerie, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieparamrubriquetresorerie.TR_CODERUBRIQUETRESORERIE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsTresorerieparamrubriquetresorerieWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsTresorerieparamrubriquetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparamrubriquetresorerie> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparamrubriquetresorerieWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieparamrubriquetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparamrubriquetresorerie> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparamrubriquetresorerieWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparamrubriquetresorerieWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieparamrubriquetresorerieWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "TRESORERIEPARAMRUBRIQUETRESORERIE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "TRESORERIEPARAMRUBRIQUETRESORERIE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "TRESORERIEPARAMRUBRIQUETRESORERIE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "TRESORERIEPARAMRUBRIQUETRESORERIE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
