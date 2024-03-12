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
	public class clsTresorerieplantresorerieWSBLL: IObjetWSBLL<clsTresorerieplantresorerie>
	{
		private clsTresorerieplantresorerieWSDAL clsTresorerieplantresorerieWSDAL= new clsTresorerieplantresorerieWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieplantresorerieWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieplantresorerieWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieplantresorerieWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsTresorerieplantresorerie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsTresorerieplantresorerie pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieplantresorerieWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsTresorerieplantresorerie">clsTresorerieplantresorerie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsTresorerieplantresorerie clsTresorerieplantresorerie , clsObjetEnvoi clsObjetEnvoi)
		{
			
			clsTresorerieplantresorerieWSDAL.pvgInsert(clsDonnee, clsTresorerieplantresorerie);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE.ToString(), "A"));
			return "";
		}
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicbudget">clsMicbudget</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterComplement(clsDonnee clsDonnee, clsTresorerieplantresorerie clsTresorerieplantresorerie, clsObjetEnvoi clsObjetEnvoi)
        {
            clsTresorerieplantresorerieWSDAL.pvgInsertComplement(clsDonnee, clsTresorerieplantresorerie);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE.ToString(), "A"));
            return "";
        }
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsTresorerieplantresoreries"> Liste d'objet clsTresorerieplantresorerie</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsTresorerieplantresorerie> clsTresorerieplantresoreries , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsTresorerieplantresorerieWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsTresorerieplantresoreries.Count; Idx++)
			{
				clsTresorerieplantresoreries[Idx].TB_CODEPLANTRESORERIE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsTresorerieplantresorerieWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsTresorerieplantresorerieWSDAL.pvgInsert(clsDonnee, clsTresorerieplantresoreries[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieplantresoreries[Idx].TB_CODEPLANTRESORERIE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsTresorerieplantresorerie">clsTresorerieplantresorerie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsTresorerieplantresorerie clsTresorerieplantresorerie,clsObjetEnvoi clsObjetEnvoi)
		{
			clsTresorerieplantresorerieWSDAL.pvgUpdate(clsDonnee, clsTresorerieplantresorerie, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE.ToString(), "M"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicbudget">clsMicbudget</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifierComplement(clsDonnee clsDonnee, clsTresorerieplantresorerie clsTresorerieplantresorerie, clsObjetEnvoi clsObjetEnvoi)
        {
            clsTresorerieplantresorerieWSDAL.pvgUpdateComplement(clsDonnee, clsTresorerieplantresorerie, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsTresorerieplantresorerieWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsTresorerieplantresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieplantresorerie> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieplantresorerieWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieplantresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieplantresorerie> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieplantresorerieWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieplantresorerieWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsTresorerieplantresorerieWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsTresorerieplantresorerieWSDAL.pvgChargerDansDataSetPourCombo1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetComplement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsTresorerieplantresorerieWSDAL.pvgChargerDansDataSetComplement(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboComplement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsTresorerieplantresorerieWSDAL.pvgChargerDansDataSetPourComboComplement(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "TRESORERIEPLANTRESORERIE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "TRESORERIEPLANTRESORERIE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "TRESORERIEPLANTRESORERIE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "TRESORERIEPLANTRESORERIE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
