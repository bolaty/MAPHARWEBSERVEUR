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
	public class clsCliconsultationWSBLL: IObjetWSBLL<clsCliconsultation>
	{
		private clsCliconsultationWSDAL clsCliconsultationWSDAL= new clsCliconsultationWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliconsultationWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliconsultationWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliconsultationWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultation pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliconsultationWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCliconsultation">clsCliconsultation</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCliconsultation clsCliconsultation , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsCliconsultation.CO_CODECONSULTATION = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsCliconsultationWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCliconsultationWSDAL.pvgInsert(clsDonnee, clsCliconsultation);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCliconsultation.CO_CODECONSULTATION.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCliconsultations"> Liste d'objet clsCliconsultation</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCliconsultation> clsCliconsultations , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsCliconsultationWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsCliconsultations.Count; Idx++)
			{
				clsCliconsultations[Idx].CO_CODECONSULTATION = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsCliconsultationWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsCliconsultationWSDAL.pvgInsert(clsDonnee, clsCliconsultations[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCliconsultations[Idx].CO_CODECONSULTATION.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCliconsultation">clsCliconsultation</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsCliconsultation clsCliconsultation,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCliconsultationWSDAL.pvgUpdate(clsDonnee, clsCliconsultation, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCliconsultation.CO_CODECONSULTATION.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCliconsultationWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCliconsultation </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultation> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliconsultationWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultation </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultation> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliconsultationWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliconsultationWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetConsultation(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsCliconsultationWSDAL.pvgChargerDansDataSetConsultation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetConsultationLiaison(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsCliconsultationWSDAL.pvgChargerDansDataSetConsultationLiaison(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliconsultationWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CLICONSULTATION  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CLICONSULTATION  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CLICONSULTATION  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CLICONSULTATION  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
