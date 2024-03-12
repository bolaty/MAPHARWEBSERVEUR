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
	public class clsPhamouvementstockfiltragedestockexpirationWSBLL: IObjetWSBLL<clsPhamouvementstockfiltragedestockexpiration>
	{
		private clsPhamouvementstockfiltragedestockexpirationWSDAL clsPhamouvementstockfiltragedestockexpirationWSDAL= new clsPhamouvementstockfiltragedestockexpirationWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockfiltragedestockexpiration comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockfiltragedestockexpiration pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockfiltragedestockexpiration">clsPhamouvementstockfiltragedestockexpiration</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgInsert(clsDonnee, clsPhamouvementstockfiltragedestockexpiration);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockfiltragedestockexpirations"> Liste d'objet clsPhamouvementstockfiltragedestockexpiration</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhamouvementstockfiltragedestockexpirations.Count; Idx++)
			{
				clsPhamouvementstockfiltragedestockexpirations[Idx].ME_IDFILTRAGEDESTOCKEXPIRATION = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgInsert(clsDonnee, clsPhamouvementstockfiltragedestockexpirations[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockfiltragedestockexpirations[Idx].ME_IDFILTRAGEDESTOCKEXPIRATION.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockfiltragedestockexpiration">clsPhamouvementstockfiltragedestockexpiration</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgUpdate(clsDonnee, clsPhamouvementstockfiltragedestockexpiration, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestockexpiration </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestockexpiration> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestockexpiration </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestockexpiration> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockfiltragedestockexpirationWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
