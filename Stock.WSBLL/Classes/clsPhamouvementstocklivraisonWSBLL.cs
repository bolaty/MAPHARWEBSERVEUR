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
	public class clsPhamouvementstocklivraisonWSBLL: IObjetWSBLL<clsPhamouvementstocklivraison>
	{
		private clsPhamouvementstocklivraisonWSDAL clsPhamouvementstocklivraisonWSDAL= new clsPhamouvementstocklivraisonWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstocklivraisonWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstocklivraisonWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstocklivraisonWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstocklivraison comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstocklivraison pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstocklivraisonWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstocklivraison">clsPhamouvementstocklivraison</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementstocklivraison clsPhamouvementstocklivraison , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstocklivraison.LV_NUMSEQUENCE = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsPhamouvementstocklivraisonWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPhamouvementstocklivraisonWSDAL.pvgInsert(clsDonnee, clsPhamouvementstocklivraison);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstocklivraison.LV_NUMSEQUENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstocklivraisons"> Liste d'objet clsPhamouvementstocklivraison</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementstocklivraison> clsPhamouvementstocklivraisons , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhamouvementstocklivraisonWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhamouvementstocklivraisons.Count; Idx++)
			{
				clsPhamouvementstocklivraisons[Idx].LV_NUMSEQUENCE = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsPhamouvementstocklivraisonWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsPhamouvementstocklivraisonWSDAL.pvgInsert(clsDonnee, clsPhamouvementstocklivraisons[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstocklivraisons[Idx].LV_NUMSEQUENCE.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstocklivraisons"> Liste d'objet clsPhamouvementstocklivraison</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListeLivraison(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, List<clsPhamouvementstocklivraison> clsPhamouvementstocklivraisons, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            //clsPhamouvementstocklivraisonWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            string VlpNumPiece = "";
            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementstocklivraisonWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstocklivraisons[0].AG_CODEAGENCE, clsPhamouvementstocklivraisons[0].MS_NUMPIECE)) + 1).ToString();
            for (int Idx = 0; Idx < clsPhamouvementstocklivraisons.Count; Idx++)
            {
                //clsPhamouvementstocklivraisons[Idx].LV_NUMSEQUENCE = string.Format("{0:00000000000000000000000000000000000000000000000000}", double.Parse(clsPhamouvementstocklivraisonWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                clsPhamouvementstocklivraisons[Idx].TYPEOPERATION = 0;
                clsPhamouvementstocklivraisons[Idx].LV_NUMEROPIECE = double.Parse(VlpNumPiece0);
              VlpNumPiece=clsPhamouvementstocklivraisonWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementstocklivraisons[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstocklivraisons[Idx].LV_NUMSEQUENCE.ToString(), "A"));
            }




            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";

           
                clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementstocklivraisons[0].MS_NUMPIECE;
                //clsPhamouvementstockreglement.TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementstockreglementWSDAL().pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);



           
        //}


            //for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            //{

            //    VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString()))).ToString();
            //    if (VlpNatureOperation != clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION)
            //    { VlpNumPiece2 = (double.Parse(VlpNumPiece1) + 1).ToString(); }
            //    else { VlpNumPiece2 = (double.Parse(VlpNumPiece1)).ToString(); }
            //    VlpNatureOperation = clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION;
            //    clsPhamouvementstockreglements[Idx].MS_NUMPIECE = clsPhamouvementstocklivraisons[0].MS_NUMPIECE;
            //    clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece2;
            //    clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
            //    //insertion dans mouvementStockdetail
            //    new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);




            //}


            return VlpNumPiece;
        }
		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstocklivraison">clsPhamouvementstocklivraison</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementstocklivraison clsPhamouvementstocklivraison,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstocklivraisonWSDAL.pvgUpdate(clsDonnee, clsPhamouvementstocklivraison, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstocklivraison.LV_NUMSEQUENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstocklivraisonWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementstocklivraison </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstocklivraison> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstocklivraisonWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstocklivraison </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstocklivraison> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstocklivraisonWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstocklivraisonWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetLivraison(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstocklivraisonWSDAL.pvgChargerDansDataSetLivraison(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetFactureLivraison(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstocklivraisonWSDAL.pvgChargerDansDataSetFactureLivraison(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetListeLivraison(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstocklivraisonWSDAL.pvgChargerDansDataSetListeLivraison(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetBonLivraison(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstocklivraisonWSDAL.pvgChargerDansDataSetBonLivraison(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }




		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstocklivraisonWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKLIVRAISON  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKLIVRAISON  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKLIVRAISON  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKLIVRAISON  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
