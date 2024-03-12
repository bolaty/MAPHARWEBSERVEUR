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
	public class clsPhapartypetierscompterattacheadditionnelWSBLL: IObjetWSBLL<clsPhapartypetierscompterattacheadditionnel>
	{
		private clsPhapartypetierscompterattacheadditionnelWSDAL clsPhapartypetierscompterattacheadditionnelWSDAL= new clsPhapartypetierscompterattacheadditionnelWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypetierscompterattacheadditionnel comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypetierscompterattacheadditionnel pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypetierscompterattacheadditionnel">clsPhapartypetierscompterattacheadditionnel</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS = string.Format( "{0:0000}" , double.Parse(clsPhapartypetierscompterattacheadditionnelWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPhapartypetierscompterattacheadditionnelWSDAL.pvgInsert(clsDonnee, clsPhapartypetierscompterattacheadditionnel);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypetierscompterattacheadditionnels"> Liste d'objet clsPhapartypetierscompterattacheadditionnel</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhapartypetierscompterattacheadditionnelWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhapartypetierscompterattacheadditionnels.Count; Idx++)
			{
				clsPhapartypetierscompterattacheadditionnels[Idx].TC_CODECOMPTETYPETIERS = string.Format( "{0:0000}" , double.Parse(clsPhapartypetierscompterattacheadditionnelWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsPhapartypetierscompterattacheadditionnelWSDAL.pvgInsert(clsDonnee, clsPhapartypetierscompterattacheadditionnels[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypetierscompterattacheadditionnels[Idx].TC_CODECOMPTETYPETIERS.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypetierscompterattacheadditionnel">clsPhapartypetierscompterattacheadditionnel</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhapartypetierscompterattacheadditionnelWSDAL.pvgUpdate(clsDonnee, clsPhapartypetierscompterattacheadditionnel, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhapartypetierscompterattacheadditionnelWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhapartypetierscompterattacheadditionnel </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypetierscompterattacheadditionnel> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypetierscompterattacheadditionnel </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypetierscompterattacheadditionnel> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboEdition(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapartypetierscompterattacheadditionnelWSDAL.pvgChargerDansDataSetPourComboEdition(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
