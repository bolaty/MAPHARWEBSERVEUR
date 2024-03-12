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
	public class clsPha_attributionchambreWSBLL: IObjetWSBLL<clsPha_attributionchambre>
	{
		private clsPha_attributionchambreWSDAL clsPha_attributionchambreWSDAL= new clsPha_attributionchambreWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPha_attributionchambreWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCountVerificationOccupationChambre(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPha_attributionchambreWSDAL.pvgValueScalarRequeteCountVerificationOccupationChambre(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPha_attributionchambreWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPha_attributionchambreWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPha_attributionchambre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPha_attributionchambre pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPha_attributionchambreWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPha_attributionchambre comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<clsPha_attributionchambre> pvgTableLabelListe(clsDonnee clsDonnee,  params string[] vppCritere)
        {
            return clsPha_attributionchambreWSDAL.pvgTableLabelListe(clsDonnee, vppCritere);
        }




        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPha_attributionchambre comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPha_attributionchambre pvgTableLabelPeriodeDerniereOccupation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPha_attributionchambreWSDAL.pvgTableLabelPeriodeDerniereOccupation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPha_attributionchambre">clsPha_attributionchambre</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPha_attributionchambre clsPha_attributionchambre , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPha_attributionchambre.TI_IDATTRIBUTION = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsPha_attributionchambreWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPha_attributionchambreWSDAL.pvgInsert(clsDonnee, clsPha_attributionchambre);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPha_attributionchambre.TI_IDATTRIBUTION.ToString(), "A"));
			return "";
		}
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPha_attributionchambre">clsPha_attributionchambre</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseAjours(clsDonnee clsDonnee, clsPha_attributionchambre clsPha_attributionchambre, clsObjetEnvoi clsObjetEnvoi)
        {
	        clsPha_attributionchambre.TI_IDATTRIBUTION = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsPha_attributionchambreWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
            clsPha_attributionchambreWSDAL.pvgMiseAjours(clsDonnee, clsPha_attributionchambre);
	        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPha_attributionchambre.TI_IDATTRIBUTION.ToString(), "A"));
	        return "";
        }
		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPha_attributionchambres"> Liste d'objet clsPha_attributionchambre</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPha_attributionchambre> clsPha_attributionchambres , clsObjetEnvoi clsObjetEnvoi)
		{
            string TI_IDATTRIBUTION = "";
			// Sppression des données existantes avant insertion dans la base de données 
			clsPha_attributionchambreWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPha_attributionchambres.Count; Idx++)
			{
				clsPha_attributionchambres[Idx].TI_IDATTRIBUTION = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsPha_attributionchambreWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);

                clsPha_attributionchambres[Idx].TYPEOPERATION = 0;
                TI_IDATTRIBUTION= clsPha_attributionchambreWSDAL.pvgMiseAjours(clsDonnee, clsPha_attributionchambres[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPha_attributionchambres[Idx].TI_IDATTRIBUTION.ToString(), "A"));
			}
            return TI_IDATTRIBUTION;
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPha_attributionchambres"> Liste d'objet clsPha_attributionchambre</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifierListe(clsDonnee clsDonnee, List<clsPha_attributionchambre> clsPha_attributionchambres, clsPhamouvementStock clsPhamouvementStock, clsPhamouvementStockdetail clsPhamouvementStockdetail, clsObjetEnvoi clsObjetEnvoi)
        {
            for (int Idx = 0; Idx < clsPha_attributionchambres.Count; Idx++)
            {
                clsPha_attributionchambres[Idx].TYPEOPERATION = 1;
                clsPha_attributionchambreWSDAL.pvgMiseAjours(clsDonnee, clsPha_attributionchambres[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi,clsPha_attributionchambres[Idx].TI_IDATTRIBUTION.ToString(), "M"));


                string vlpNumPiece = new clsPhamouvementStockWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStock);
                // mouchard
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));
                //}

                string VlpNumPiece0 = "";

                VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();
                clsPhamouvementStockdetail.AR_CODEARTICLE = clsPha_attributionchambres[Idx].AR_CODEARTICLE;
                clsPhamouvementStockdetail.MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetail.TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                clsPhamouvementStockdetail.MD_NUMEROPIECE = VlpNumPiece0;
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetail);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetail.MD_NUMSEQUENCE.ToString(), "A"));


            }
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPha_attributionchambre">clsPha_attributionchambre</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPha_attributionchambre clsPha_attributionchambre,clsObjetEnvoi clsObjetEnvoi)
		{
            clsPha_attributionchambre.TYPEOPERATION = 1;
            clsPha_attributionchambreWSDAL.pvgMiseAjours(clsDonnee, clsPha_attributionchambre);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPha_attributionchambre.TI_IDATTRIBUTION.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPha_attributionchambreWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPha_attributionchambre </returns>
		///<author>Home Technology</author>
		public List<clsPha_attributionchambre> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPha_attributionchambreWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPha_attributionchambre </returns>
		///<author>Home Technology</author>
		public List<clsPha_attributionchambre> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPha_attributionchambreWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPha_attributionchambreWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetReservation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPha_attributionchambreWSDAL.pvgChargerDansDataSetReservation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetChambreLibere(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPha_attributionchambreWSDAL.pvgChargerDansDataSetChambreLibere(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPha_attributionchambreWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHA_ATTRIBUTIONCHAMBRE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHA_ATTRIBUTIONCHAMBRE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHA_ATTRIBUTIONCHAMBRE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHA_ATTRIBUTIONCHAMBRE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
