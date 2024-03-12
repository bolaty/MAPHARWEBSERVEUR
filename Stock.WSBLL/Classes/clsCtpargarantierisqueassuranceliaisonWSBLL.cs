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
	public class clsCtpargarantierisqueassuranceliaisonWSBLL: IObjetWSBLL<clsCtpargarantierisqueassuranceliaison>
	{
		private clsCtpargarantierisqueassuranceliaisonWSDAL clsCtpargarantierisqueassuranceliaisonWSDAL= new clsCtpargarantierisqueassuranceliaisonWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtpargarantierisqueassuranceliaisonWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtpargarantierisqueassuranceliaisonWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtpargarantierisqueassuranceliaisonWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpargarantierisqueassuranceliaison comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpargarantierisqueassuranceliaison pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtpargarantierisqueassuranceliaisonWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtpargarantierisqueassuranceliaison">clsCtpargarantierisqueassuranceliaison</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison , clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtpargarantierisqueassuranceliaison.GA_CODEGARANTIE = string.Format( "{0:00000}" , double.Parse(clsCtpargarantierisqueassuranceliaisonWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCtpargarantierisqueassuranceliaisonWSDAL.pvgInsert(clsDonnee, clsCtpargarantierisqueassuranceliaison);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtpargarantierisqueassuranceliaison.GA_CODEGARANTIE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtpargarantierisqueassuranceliaisons"> Liste d'objet clsCtpargarantierisqueassuranceliaison</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCtpargarantierisqueassuranceliaison> clsCtpargarantierisqueassuranceliaisons , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsCtpargarantierisqueassuranceliaisonWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsCtpargarantierisqueassuranceliaisons.Count; Idx++)
			{
				clsCtpargarantierisqueassuranceliaisons[Idx].GA_CODEGARANTIE = string.Format( "{0:00000}" , double.Parse(clsCtpargarantierisqueassuranceliaisonWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsCtpargarantierisqueassuranceliaisonWSDAL.pvgInsert(clsDonnee, clsCtpargarantierisqueassuranceliaisons[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtpargarantierisqueassuranceliaisons[Idx].GA_CODEGARANTIE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtpargarantierisqueassuranceliaison">clsCtpargarantierisqueassuranceliaison</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtpargarantierisqueassuranceliaisonWSDAL.pvgUpdate(clsDonnee, clsCtpargarantierisqueassuranceliaison, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtpargarantierisqueassuranceliaison.GA_CODEGARANTIE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtpargarantierisqueassuranceliaisonWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCtpargarantierisqueassuranceliaison </returns>
		///<author>Home Technology</author>
		public List<clsCtpargarantierisqueassuranceliaison> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtpargarantierisqueassuranceliaisonWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpargarantierisqueassuranceliaison </returns>
		///<author>Home Technology</author>
		public List<clsCtpargarantierisqueassuranceliaison> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtpargarantierisqueassuranceliaisonWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtpargarantierisqueassuranceliaisonWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtpargarantierisqueassuranceliaisonWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CTPARGARANTIERISQUEASSURANCELIAISON  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CTPARGARANTIERISQUEASSURANCELIAISON  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CTPARGARANTIERISQUEASSURANCELIAISON  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CTPARGARANTIERISQUEASSURANCELIAISON  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
