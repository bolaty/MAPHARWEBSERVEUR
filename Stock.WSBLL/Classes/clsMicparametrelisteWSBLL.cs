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
	public class clsMicparametrelisteWSBLL: IObjetWSBLL<clsMicparametreliste>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsMicparametrelisteWSDAL clsMicparametrelisteWSDAL= new clsMicparametrelisteWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMicparametreliste comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMicparametreliste pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicparametreliste">clsMicparametreliste</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsMicparametreliste clsMicparametreliste , clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicparametreliste.PL_CODEPARAMETRELISTE = string.Format( "{0:00000}" , double.Parse(clsMicparametrelisteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsMicparametrelisteWSDAL.pvgInsert(clsDonnee, clsMicparametreliste);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametreliste.PL_CODEPARAMETRELISTE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicparametrelistes"> Liste d'objet clsMicparametreliste</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsMicparametreliste> clsMicparametrelistes , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsMicparametrelisteWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsMicparametrelistes.Count; Idx++)
			{
				clsMicparametrelistes[Idx].PL_CODEPARAMETRELISTE = string.Format( "{0:00000}" , double.Parse(clsMicparametrelisteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsMicparametrelisteWSDAL.pvgInsert(clsDonnee, clsMicparametrelistes[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametrelistes[Idx].PL_CODEPARAMETRELISTE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicparametreliste">clsMicparametreliste</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsMicparametreliste clsMicparametreliste,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicparametrelisteWSDAL.pvgUpdate(clsDonnee, clsMicparametreliste, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametreliste.PL_CODEPARAMETRELISTE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicparametrelisteWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsMicparametreliste </returns>
		///<author>Home Technology</author>
		public List<clsMicparametreliste> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicparametreliste </returns>
		///<author>Home Technology</author>
		public List<clsMicparametreliste> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetProduitSousProduit(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsMicparametrelisteWSDAL.pvgChargerDansDataSetProduitSousProduit(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetProduitSousProduitSimulation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsMicparametrelisteWSDAL.pvgChargerDansDataSetProduitSousProduitSimulation(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboFrais(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsMicparametrelisteWSDAL.pvgChargerDansDataSetPourComboFrais(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "MICPARAMETRELISTE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "MICPARAMETRELISTE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "MICPARAMETRELISTE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "MICPARAMETRELISTE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
