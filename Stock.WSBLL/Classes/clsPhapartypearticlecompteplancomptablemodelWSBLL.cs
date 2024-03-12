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
	public class clsPhapartypearticlecompteplancomptablemodelWSBLL: IObjetWSBLL<clsPhapartypearticlecompteplancomptablemodel>
	{
		private clsPhapartypearticlecompteplancomptablemodelWSDAL clsPhapartypearticlecompteplancomptablemodelWSDAL= new clsPhapartypearticlecompteplancomptablemodelWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypearticlecompteplancomptablemodel comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypearticlecompteplancomptablemodel pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypearticlecompteplancomptablemodel">clsPhapartypearticlecompteplancomptablemodel</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE = string.Format( "{0:000}" , double.Parse(clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgInsert(clsDonnee, clsPhapartypearticlecompteplancomptablemodel);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypearticlecompteplancomptablemodels"> Liste d'objet clsPhapartypearticlecompteplancomptablemodel</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhapartypearticlecompteplancomptablemodels.Count; Idx++)
			{
				clsPhapartypearticlecompteplancomptablemodels[Idx].CP_CODEOPERATIONLIBELLECPTE = string.Format( "{0:000}" , double.Parse(clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgInsert(clsDonnee, clsPhapartypearticlecompteplancomptablemodels[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypearticlecompteplancomptablemodels[Idx].CP_CODEOPERATIONLIBELLECPTE.ToString(), "A"));
			}
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhapartypearticlecompteplancomptablemodels"> Liste d'objet clsPhapartypearticlecompteplancomptablemodel</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifierListe(clsDonnee clsDonnee, List<clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels , clsObjetEnvoi clsObjetEnvoi)
        {
	        // Sppression des données existantes avant insertion dans la base de données 
            //clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
	        for (int Idx = 0; Idx < clsPhapartypearticlecompteplancomptablemodels.Count; Idx++)
	        {
                //clsPhapartypearticlecompteplancomptablemodels[Idx].CP_CODEOPERATIONLIBELLECPTE = string.Format( "{0:000}" , double.Parse(clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
		        clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgUpdate(clsDonnee, clsPhapartypearticlecompteplancomptablemodels[Idx]);
		        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypearticlecompteplancomptablemodels[Idx].CP_CODEOPERATIONLIBELLECPTE.ToString(), "M"));
	        }
	        return "";
        }
		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapartypearticlecompteplancomptablemodel">clsPhapartypearticlecompteplancomptablemodel</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgUpdate(clsDonnee, clsPhapartypearticlecompteplancomptablemodel, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhapartypearticlecompteplancomptablemodel </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticlecompteplancomptablemodel> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticlecompteplancomptablemodel </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticlecompteplancomptablemodel> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapartypearticlecompteplancomptablemodelWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
