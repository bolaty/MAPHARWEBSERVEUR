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
	public class clsCtcontratecheancierWSBLL: IObjetWSBLL<clsCtcontratecheancier>
	{
		private clsCtcontratecheancierWSDAL clsCtcontratecheancierWSDAL= new clsCtcontratecheancierWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratecheancierWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratecheancierWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratecheancierWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratecheancier comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratecheancier pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratecheancierWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratecheancier">clsCtcontratecheancier</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCtcontratecheancier clsCtcontratecheancier , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsCtcontratecheancier.CA_CODECONTRAT = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsCtcontratecheancierWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCtcontratecheancierWSDAL.pvgInsert(clsDonnee, clsCtcontratecheancier);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratecheancier.CA_CODECONTRAT.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratecheanciers"> Liste d'objet clsCtcontratecheancier</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCtcontratecheancier> clsCtcontratecheanciers , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsCtcontratecheancierWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsCtcontratecheanciers.Count; Idx++)
			{
				//clsCtcontratecheanciers[Idx].CA_CODECONTRAT = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsCtcontratecheancierWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsCtcontratecheancierWSDAL.pvgInsert(clsDonnee, clsCtcontratecheanciers[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratecheanciers[Idx].CA_CODECONTRAT.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratecheancier">clsCtcontratecheancier</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsCtcontratecheancier clsCtcontratecheancier,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtcontratecheancierWSDAL.pvgUpdate(clsDonnee, clsCtcontratecheancier, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratecheancier.CA_CODECONTRAT.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtcontratecheancierWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}
        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgDeleteInsertion(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        clsCtcontratecheancierWSDAL.pvgDeleteInsertion(clsDonnee, clsObjetEnvoi.OE_PARAM);
	        string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
	        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
	        return "";
        }
		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCtcontratecheancier </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratecheancier> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratecheancierWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratecheancier </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratecheancier> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratecheancierWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratecheancierWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, EC_DATEECHEANCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratecheancierWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CTCONTRATECHEANCIER  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CTCONTRATECHEANCIER  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CTCONTRATECHEANCIER  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CTCONTRATECHEANCIER  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}