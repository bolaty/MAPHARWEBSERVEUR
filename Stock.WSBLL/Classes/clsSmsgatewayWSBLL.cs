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
	public class clsSmsgatewayWSBLL: IObjetWSBLL<clsSmsgateway>
	{
		private clsSmsgatewayWSDAL clsSmsgatewayWSDAL= new clsSmsgatewayWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsgatewayWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsgatewayWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsgatewayWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsSmsgateway comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsSmsgateway pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsgatewayWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsgateway">clsSmsgateway</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsSmsgateway clsSmsgateway , clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsgateway.GW_CODEGATEWAY =  double.Parse(clsSmsgatewayWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1 ;
			clsSmsgatewayWSDAL.pvgInsert(clsDonnee, clsSmsgateway);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsgateway.GW_CODEGATEWAY.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsgateways"> Liste d'objet clsSmsgateway</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsSmsgateway> clsSmsgateways , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsSmsgatewayWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsSmsgateways.Count; Idx++)
			{
				clsSmsgateways[Idx].GW_CODEGATEWAY =  double.Parse(clsSmsgatewayWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1 ;
				clsSmsgatewayWSDAL.pvgInsert(clsDonnee, clsSmsgateways[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsgateways[Idx].GW_CODEGATEWAY.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsgateway">clsSmsgateway</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsSmsgateway clsSmsgateway,clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsgatewayWSDAL.pvgUpdate(clsDonnee, clsSmsgateway, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsgateway.GW_CODEGATEWAY.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsgatewayWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsSmsgateway </returns>
		///<author>Home Technology</author>
		public List<clsSmsgateway> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsgatewayWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsgateway </returns>
		///<author>Home Technology</author>
		public List<clsSmsgateway> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsgatewayWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsgatewayWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsgatewayWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "SMSGATEWAY  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "SMSGATEWAY  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "SMSGATEWAY  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "SMSGATEWAY  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
