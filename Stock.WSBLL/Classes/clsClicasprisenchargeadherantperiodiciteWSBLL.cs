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
	public class clsClicasprisenchargeadherantperiodiciteWSBLL: IObjetWSBLL<clsClicasprisenchargeadherantperiodicite>
	{
		private clsClicasprisenchargeadherantperiodiciteWSDAL clsClicasprisenchargeadherantperiodiciteWSDAL= new clsClicasprisenchargeadherantperiodiciteWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeadherantperiodiciteWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeadherantperiodiciteWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeadherantperiodiciteWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsClicasprisenchargeadherantperiodicite comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsClicasprisenchargeadherantperiodicite pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeadherantperiodiciteWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsClicasprisenchargeadherantperiodicite">clsClicasprisenchargeadherantperiodicite</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsClicasprisenchargeadherantperiodicite clsClicasprisenchargeadherantperiodicite , clsObjetEnvoi clsObjetEnvoi)
		{
			clsClicasprisenchargeadherantperiodicite.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsClicasprisenchargeadherantperiodiciteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsClicasprisenchargeadherantperiodiciteWSDAL.pvgInsert(clsDonnee, clsClicasprisenchargeadherantperiodicite);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsClicasprisenchargeadherantperiodicite.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsClicasprisenchargeadherantperiodicites"> Liste d'objet clsClicasprisenchargeadherantperiodicite</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsClicasprisenchargeadherantperiodicite> clsClicasprisenchargeadherantperiodicites , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsClicasprisenchargeadherantperiodiciteWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsClicasprisenchargeadherantperiodicites.Count; Idx++)
			{
				clsClicasprisenchargeadherantperiodicites[Idx].AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsClicasprisenchargeadherantperiodiciteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsClicasprisenchargeadherantperiodiciteWSDAL.pvgInsert(clsDonnee, clsClicasprisenchargeadherantperiodicites[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsClicasprisenchargeadherantperiodicites[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsClicasprisenchargeadherantperiodicite">clsClicasprisenchargeadherantperiodicite</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsClicasprisenchargeadherantperiodicite clsClicasprisenchargeadherantperiodicite,clsObjetEnvoi clsObjetEnvoi)
		{
			clsClicasprisenchargeadherantperiodiciteWSDAL.pvgUpdate(clsDonnee, clsClicasprisenchargeadherantperiodicite, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsClicasprisenchargeadherantperiodicite.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsClicasprisenchargeadherantperiodiciteWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsClicasprisenchargeadherantperiodicite </returns>
		///<author>Home Technology</author>
		public List<clsClicasprisenchargeadherantperiodicite> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeadherantperiodiciteWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClicasprisenchargeadherantperiodicite </returns>
		///<author>Home Technology</author>
		public List<clsClicasprisenchargeadherantperiodicite> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeadherantperiodiciteWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeadherantperiodiciteWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeadherantperiodiciteWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CLICASPRISENCHARGEADHERANTPERIODICITE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CLICASPRISENCHARGEADHERANTPERIODICITE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CLICASPRISENCHARGEADHERANTPERIODICITE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CLICASPRISENCHARGEADHERANTPERIODICITE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}