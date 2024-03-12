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
	public class clsPhapartypearticlecompteplancomptableWSBLL: IObjetWSBLL<clsPhapartypearticlecompteplancomptable>
	{
		private clsPhapartypearticlecompteplancomptableWSDAL clsPhapartypearticlecompteplancomptableWSDAL= new clsPhapartypearticlecompteplancomptableWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptableWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptableWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptableWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypearticlecompteplancomptable comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypearticlecompteplancomptable pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptableWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypearticlecompteplancomptable">clsPhapartypearticlecompteplancomptable</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhapartypearticlecompteplancomptable clsPhapartypearticlecompteplancomptable , clsObjetEnvoi clsObjetEnvoi)
		{
            //clsPhapartypearticlecompteplancomptable.TA_CODETYPEARTICLE = string.Format( "{0:000}" , double.Parse(clsPhapartypearticlecompteplancomptableWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPhapartypearticlecompteplancomptableWSDAL.pvgInsert(clsDonnee, clsPhapartypearticlecompteplancomptable);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypearticlecompteplancomptable.TA_CODETYPEARTICLE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypearticlecompteplancomptables"> Liste d'objet clsPhapartypearticlecompteplancomptable</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhapartypearticlecompteplancomptable> clsPhapartypearticlecompteplancomptables , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
            clsPhapartypearticlecompteplancomptableWSDAL.pvgDelete(clsDonnee, clsPhapartypearticlecompteplancomptables[0].TA_CODETYPEARTICLE, clsPhapartypearticlecompteplancomptables[0].TO_CODEOPERATION);
			for (int Idx = 0; Idx < clsPhapartypearticlecompteplancomptables.Count; Idx++)
			{
                //clsPhapartypearticlecompteplancomptables[Idx].TA_CODETYPEARTICLE = string.Format( "{0:000}" , double.Parse(clsPhapartypearticlecompteplancomptableWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                if (clsPhapartypearticlecompteplancomptables[Idx].PL_NUMCOMPTE != "")
                {
                    clsPhapartypearticlecompteplancomptableWSDAL.pvgInsert(clsDonnee, clsPhapartypearticlecompteplancomptables[Idx]);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypearticlecompteplancomptables[Idx].TA_CODETYPEARTICLE.ToString(), "A"));
                }
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypearticlecompteplancomptable">clsPhapartypearticlecompteplancomptable</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhapartypearticlecompteplancomptable clsPhapartypearticlecompteplancomptable,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhapartypearticlecompteplancomptableWSDAL.pvgUpdate(clsDonnee, clsPhapartypearticlecompteplancomptable, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypearticlecompteplancomptable.TA_CODETYPEARTICLE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhapartypearticlecompteplancomptableWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhapartypearticlecompteplancomptable </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticlecompteplancomptable> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptableWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticlecompteplancomptable </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticlecompteplancomptable> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptableWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptableWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETYPEARTICLE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptableWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAPARTYPEARTICLECOMPTEPLANCOMPTABLE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
