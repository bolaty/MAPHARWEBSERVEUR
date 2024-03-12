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
	public class clsPhamouvementStockdetailcommandeWSBLL: IObjetWSBLL<clsPhamouvementStockdetailcommande>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsPhamouvementStockdetailcommandeWSDAL clsPhamouvementStockdetailcommandeWSDAL= new clsPhamouvementStockdetailcommandeWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailcommandeWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailcommandeWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockdetailcommande comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockdetailcommande pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailcommandeWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockdetailcommande">clsPhamouvementStockdetailcommande</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE = ( double.Parse(clsPhamouvementStockdetailcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
			clsPhamouvementStockdetailcommandeWSDAL.pvgInsert(clsDonnee, clsPhamouvementStockdetailcommande);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockdetailcommandes"> Liste d'objet clsPhamouvementStockdetailcommande</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
            for (int Idx = 0; Idx < clsPhamouvementStockdetailcommandes.Count; Idx++)
            {
                if (Idx == 0)
                {
                    clsPhamouvementStockdetailcommandeWSDAL.pvgDelete(clsDonnee, clsPhamouvementStockdetailcommandes[Idx].AG_CODEAGENCE, clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE);
                }
                clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE = (double.Parse(clsPhamouvementStockdetailcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
                clsPhamouvementStockdetailcommandeWSDAL.pvgInsert(clsDonnee, clsPhamouvementStockdetailcommandes[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE.ToString(), "A"));
            }
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockdetailcommande">clsPhamouvementStockdetailcommande</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockdetailcommandeWSDAL.pvgUpdate(clsDonnee, clsPhamouvementStockdetailcommande, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockdetailcommandeWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementStockdetailcommande </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockdetailcommande> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailcommandeWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockdetailcommande </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockdetailcommande> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailcommandeWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères(Ordre critere:Mk_NUMPIECE)</summary>
        ///<param name="vppCritere">Chaine de la requète SELECT</param>
        ///<returns>List<BusinessObject>,une liste d'objets</returns>
        ///<author>Home Technologie</author>
        public List<clsPhamouvementStockdetailcommande> pvgSelectCommandeFournisseur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailcommandeWSDAL.pvgSelectCommandeFournisseur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public List<clsPhamouvementStockdetailcommande> pvgSelectCommandeClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailcommandeWSDAL.pvgSelectCommandeClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailcommandeWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public DataSet pvgInsertIntoDatasetcommandeFournisseur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailcommandeWSDAL.pvgInsertIntoDatasetcommandeFournisseur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:Mk_NUMPIECE)</summary>
        ///<param name="vppCritere">Critère de la requète SELECT</param>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>

        public DataSet pvgInsertIntoDatasetcommandeClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockdetailcommandeWSDAL.pvgInsertIntoDatasetcommandeClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockdetailcommandeWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PhamouvementStockDETAILCOMMANDE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PhamouvementStockDETAILCOMMANDE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PhamouvementStockDETAILCOMMANDE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PhamouvementStockDETAILCOMMANDE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
