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
	public class clsPhamouvementStockdetailWSBLL: IObjetWSBLL<clsPhamouvementStockdetail>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsPhamouvementStockdetailWSDAL clsPhamouvementStockdetailWSDAL= new clsPhamouvementStockdetailWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockdetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockdetail pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPhamouvementStockdetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPhamouvementStockdetail pvgTableLabelDatePeremption(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailWSDAL.pvgTableLabelDatePeremption(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockdetail">clsPhamouvementStockdetail</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementStockdetail clsPhamouvementStockdetail , clsObjetEnvoi clsObjetEnvoi)
		{
            string vlpNumsequence = clsPhamouvementStockdetailWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStockdetail);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetail.MD_NUMSEQUENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockdetails"> Liste d'objet clsPhamouvementStockdetail</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhamouvementStockdetailWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
			{
                //clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE = double.Parse(clsPhamouvementStockdetailWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1;
                clsPhamouvementStockdetailWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
                //DEVELOPPEMENT DE LA NOTION  D ACCESSOIRE

                //foreach (clsPhamouvementStockdetail clsPhamouvementStockdetail in clsPhamouvementStockdetails)
                //{
                //    clsPhamouvementStockdetail.MS_NUMPIECE = clsPhamouvementStock.MS_NUMPIECE;
                //    clsPhamouvementStockdetail.MD_NUMSEQUENCE = int.Parse(clsPhamouvementStockdetailWSDAL.pvgValueScalarRequeteMax()) + 1;
                //    clsPhamouvementStockdetailWSDAL.pvgInsert(clsPhamouvementStockdetail);
                //    //LES ACCESSOIRES DES ARTICLES DE LA VENTE
                //    if (vppCritere.Length > 0)
                //    {
                //        clsPhamouvementStockaccessoireWSDAL.pvgDelete(clsPhamouvementStockdetail.MD_NUMSEQUENCE.ToString());
                //        if (clsPhamouvementStockdetail.MD_QUANTITEENTREE == 0)
                //        {
                //            clsPhamouvementStockaccessoires = clsPhamouvementStockaccessoireWSDAL.pvgChargerAccessoiresVente(clsPhamouvementStockdetail.AR_CODEARTICLE, vppCritere[0],
                //                                              Stock.TOOLS.clsDate.ClasseDate.pvgDateJourneeComptable().ToShortDateString(), clsPhamouvementStockdetail.MD_NUMSEQUENCE.ToString(), clsPhamouvementStockdetail.MD_QUANTITESORTIE.ToString());
                //        }
                //        else
                //        {
                //            clsPhamouvementStockaccessoires = clsPhamouvementStockaccessoireWSDAL.pvgChargerAccessoiresAppro(clsPhamouvementStockdetail.AR_CODEARTICLE, vppCritere[0],
                //                                              Stock.TOOLS.clsDate.ClasseDate.pvgDateJourneeComptable().ToShortDateString(), clsPhamouvementStockdetail.MD_NUMSEQUENCE.ToString(), clsPhamouvementStockdetail.MD_QUANTITEENTREE.ToString());
                //        }

                //        foreach (clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire in clsPhamouvementStockaccessoires)
                //        {
                //            clsPhamouvementStockaccessoire.AC_NUMSEQUENCE = double.Parse(clsPhamouvementStockaccessoireWSDAL.pvgValueScalarRequeteMax()) + 1;
                //            clsPhamouvementStockaccessoireWSDAL.pvgInsert(clsPhamouvementStockaccessoire);
                //        }
                //    }
                //}

			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementStockdetails"> Liste d'objet clsPhamouvementStockdetail</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifierListe(clsDonnee clsDonnee, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsObjetEnvoi clsObjetEnvoi)
        {
	        for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
	        {
                clsPhamouvementStockdetailWSDAL.pvgUPDATE(clsDonnee, clsPhamouvementStockdetails[Idx]);
		        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
	        }
	        return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockdetail">clsPhamouvementStockdetail</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementStockdetail clsPhamouvementStockdetail,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockdetailWSDAL.pvgUpdate(clsDonnee, clsPhamouvementStockdetail, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetail.MD_NUMSEQUENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockdetailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementStockdetail </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockdetail> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockdetail </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockdetail> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        public DataSet pvgInsertIntoDatasetAppro(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailWSDAL.pvgInsertIntoDatasetInitialiseAppro(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetPourDatePeremption(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailWSDAL.pvgInsertIntoDatasetPourDatePeremption(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetInitialiseFabTrans(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailWSDAL.pvgInsertIntoDatasetInitialiseFabTrans(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetVente(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailWSDAL.pvgInsertIntoDatasetInitialiseVente(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:AR_CODEARTICLE,MD_NUMPIECE)</summary>
        ///<param name="vppCritere">Critère de la requète SELECT</param>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgInsertIntoDatasetSortie(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailWSDAL.pvgInsertIntoDatasetSortie(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PhamouvementStockDETAIL  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PhamouvementStockDETAIL  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PhamouvementStockDETAIL  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PhamouvementStockDETAIL  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
