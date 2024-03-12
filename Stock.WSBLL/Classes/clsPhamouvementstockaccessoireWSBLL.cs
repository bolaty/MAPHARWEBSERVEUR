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
	public class clsPhamouvementStockaccessoireWSBLL: IObjetWSBLL<clsPhamouvementStockaccessoire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsPhamouvementStockaccessoireWSDAL clsPhamouvementStockaccessoireWSDAL= new clsPhamouvementStockaccessoireWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockaccessoireWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockaccessoireWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockaccessoireWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockaccessoire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockaccessoire pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockaccessoireWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockaccessoire">clsPhamouvementStockaccessoire</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire , clsObjetEnvoi clsObjetEnvoi)
		{
            //clsPhamouvementStockaccessoire.AC_NUMSEQUENCE = double.Parse(clsPhamouvementStockaccessoireWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1;
			clsPhamouvementStockaccessoireWSDAL.pvgInsert(clsDonnee, clsPhamouvementStockaccessoire);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockaccessoire.AC_NUMSEQUENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockaccessoires"> Liste d'objet clsPhamouvementStockaccessoire</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementStockaccessoire> clsPhamouvementStockaccessoires , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhamouvementStockaccessoireWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhamouvementStockaccessoires.Count; Idx++)
			{
                //clsPhamouvementStockaccessoires[Idx].AC_NUMSEQUENCE = double.Parse(clsPhamouvementStockaccessoireWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1;
				clsPhamouvementStockaccessoireWSDAL.pvgInsert(clsDonnee, clsPhamouvementStockaccessoires[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockaccessoires[Idx].AC_NUMSEQUENCE.ToString(), "A"));
			}
			return "";
		}



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementStockaccessoires"> Liste d'objet clsPhamouvementStockaccessoire</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterRetoursAccessoires(clsDonnee clsDonnee, List<clsPhamouvementStockaccessoire> clsPhamouvementStockaccessoires, clsObjetEnvoi clsObjetEnvoi)
        {
            
            for (int Idx = 0; Idx < clsPhamouvementStockaccessoires.Count; Idx++)
            {
                clsPhamouvementStockaccessoireWSDAL.pvgMiseAjour(clsDonnee, clsPhamouvementStockaccessoires[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockaccessoires[Idx].AC_NUMSEQUENCE.ToString(), "A"));
            }
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementStockaccessoires"> Liste d'objet clsPhamouvementStockaccessoire</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterRetoursAccessoires1(clsDonnee clsDonnee, List<clsPhamouvementStockaccessoire> clsPhamouvementStockaccessoires, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, clsObjetEnvoi clsObjetEnvoi)
        {
            
        for (int Idx = 0; Idx < clsPhamouvementStockaccessoires.Count; Idx++)
        {
            clsPhamouvementStockaccessoireWSDAL.pvgMiseAjour(clsDonnee, clsPhamouvementStockaccessoires[Idx]);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockaccessoires[Idx].AC_NUMSEQUENCE.ToString(), "A"));
        }


        string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();

        //les articles du mouvementstock
        for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
        {
            //clsPhamouvementstockreglements[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
            //clsPhamouvementstockreglements[Idx].MS_NUMPIECE = vlpNumPiece;
            clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece1;
            clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
            //insertion dans mouvementStockdetail
            new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);
            //

            //;
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
        }


        return "";
        }


		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockaccessoire">clsPhamouvementStockaccessoire</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockaccessoireWSDAL.pvgUpdate(clsDonnee, clsPhamouvementStockaccessoire, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockaccessoire.AC_NUMSEQUENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockaccessoireWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementStockaccessoire </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockaccessoire> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockaccessoireWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        public List<clsPhamouvementStockaccessoire> pvgChargerAccessoiresVente(clsDonnee clsDonnee ,clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockaccessoireWSDAL.pvgChargerAccessoiresVente(clsDonnee, clsObjetEnvoi.OE_PARAM );
        }
        public List<clsPhamouvementStockaccessoire> pvgChargerAccessoiresAppro(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockaccessoireWSDAL.pvgChargerAccessoiresAppro(clsDonnee,clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockaccessoire </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockaccessoire> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockaccessoireWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockaccessoireWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockaccessoireWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PhamouvementStockACCESSOIRE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PhamouvementStockACCESSOIRE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PhamouvementStockACCESSOIRE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PhamouvementStockACCESSOIRE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
