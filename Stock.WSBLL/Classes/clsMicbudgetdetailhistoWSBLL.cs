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
	public class clsMicbudgetdetailhistoWSBLL: IObjetWSBLL<clsMicbudgetdetailhisto>
	{
		private clsMicbudgetdetailhistoWSDAL clsMicbudgetdetailhistoWSDAL= new clsMicbudgetdetailhistoWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicbudgetdetailhistoWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicbudgetdetailhistoWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicbudgetdetailhistoWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMicbudgetdetailhisto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMicbudgetdetailhisto pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicbudgetdetailhistoWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicbudgetdetailhisto">clsMicbudgetdetailhisto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsMicbudgetdetailhisto clsMicbudgetdetailhisto , clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicbudgetdetailhisto.BU_CODEBUDGET = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsMicbudgetdetailhistoWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsMicbudgetdetailhistoWSDAL.pvgInsert(clsDonnee, clsMicbudgetdetailhisto);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetdetailhisto.BU_CODEBUDGET.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicbudgetdetailhistos"> Liste d'objet clsMicbudgetdetailhisto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsMicbudgetdetailhisto> clsMicbudgetdetailhistos , clsObjetEnvoi clsObjetEnvoi)
		{
            // Sppression des données existantes avant insertion dans la base de données 
            if(clsMicbudgetdetailhistos[0].TY_TYPEBUDGETDEATAIL=="R")
            clsMicbudgetdetailhistoWSDAL.pvgDelete(clsDonnee, clsMicbudgetdetailhistos[0].AG_CODEAGENCE, clsMicbudgetdetailhistos[0].TY_TYPEBUDGETDEATAIL, clsMicbudgetdetailhistos[0].BE_DATEDEBUT.ToShortDateString(), clsMicbudgetdetailhistos[0].BE_DATEFIN.ToShortDateString(), clsMicbudgetdetailhistos[0].BT_CODETYPEBUDGET);
            if (clsMicbudgetdetailhistos[0].TY_TYPEBUDGETDEATAIL == "P")
                clsMicbudgetdetailhistoWSDAL.pvgDelete1(clsDonnee, clsMicbudgetdetailhistos[0].AG_CODEAGENCE, clsMicbudgetdetailhistos[0].TY_TYPEBUDGETDEATAIL, clsMicbudgetdetailhistos[0].BE_DATEDEBUT.ToShortDateString(), clsMicbudgetdetailhistos[0].BE_DATEFIN.ToShortDateString());

            for (int Idx = 0; Idx < clsMicbudgetdetailhistos.Count; Idx++)
			{
                if (clsMicbudgetdetailhistos[0].TY_TYPEBUDGETDEATAIL == "P")
                {
                    clsMicbudgetdetailhistoWSDAL.pvgInsert(clsDonnee, clsMicbudgetdetailhistos[Idx]);
				    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetdetailhistos[Idx].BU_CODEBUDGET.ToString(), "A"));
                }

                //if (clsMicbudgetdetailhistos[0].TY_TYPEBUDGETDEATAIL == "R")
                //    clsMicbudgetdetailhistoWSDAL.pvgMajSoldePoste(clsDonnee, clsMicbudgetdetailhistos[Idx].AG_CODEAGENCE, clsMicbudgetdetailhistos[Idx].PV_CODEPOINTVENTE, clsMicbudgetdetailhistos[Idx].BE_DATEDEBUT.ToShortDateString(), clsMicbudgetdetailhistos[Idx].BE_DATEFIN.ToShortDateString(), clsMicbudgetdetailhistos[Idx].BU_CODEBUDGET, clsMicbudgetdetailhistos[Idx].BG_CODEPOSTEBUDGETAIRE, clsMicbudgetdetailhistos[Idx].SR_CODESERVICE, clsMicbudgetdetailhistos[Idx].PE_CODEPERIODICITE, clsMicbudgetdetailhistos[Idx].BE_MONTANTREALISATIONMONTANT.ToString(), clsMicbudgetdetailhistos[Idx].BE_MONTANTREALISATIONTAUX.ToString(), clsMicbudgetdetailhistos[Idx].BE_MONTANTSOLDE.ToString(), clsMicbudgetdetailhistos[Idx].OP_CODEOPERATEUR);
            }


            //if (clsMicbudgetdetailhistos[0].TY_TYPEBUDGETDEATAIL == "R")
                clsMicbudgetdetailhistoWSDAL.pvgMajSoldePoste(clsDonnee, clsMicbudgetdetailhistos[0].AG_CODEAGENCE, clsMicbudgetdetailhistos[0].PV_CODEPOINTVENTE, clsMicbudgetdetailhistos[0].BE_DATEDEBUT.ToShortDateString(), clsMicbudgetdetailhistos[0].BE_DATEFIN.ToShortDateString(), clsMicbudgetdetailhistos[0].BU_CODEBUDGET, clsMicbudgetdetailhistos[0].BG_CODEPOSTEBUDGETAIRE, clsMicbudgetdetailhistos[0].SR_CODESERVICE, clsMicbudgetdetailhistos[0].PE_CODEPERIODICITE, clsMicbudgetdetailhistos[0].BE_MONTANTREALISATIONMONTANT.ToString(), clsMicbudgetdetailhistos[0].BE_MONTANTREALISATIONTAUX.ToString(), clsMicbudgetdetailhistos[0].BE_MONTANTSOLDE.ToString(), clsMicbudgetdetailhistos[0].OP_CODEOPERATEUR);

            //string BE_DATEDEBUT="01/01/"+
            //"@AG_CODEAGENCE2", "@PV_CODEPOINTVENTE2", "@BE_DATEDEBUT2", "@BE_DATEFIN2", "@BU_CODEBUDGET2", "@BG_CODEPOSTEBUDGETAIRE2", "@SR_CODESERVICE2", "@PE_CODEPERIODICITE2", "@BE_MONTANTREALISATIONMONTANT2", "@BE_MONTANTREALISATIONTAUX2", "@BE_MONTANTSOLDE2", "@OP_CODEOPERATEUR2",



            return "";
		}





		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicbudgetdetailhisto">clsMicbudgetdetailhisto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsMicbudgetdetailhisto clsMicbudgetdetailhisto,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicbudgetdetailhistoWSDAL.pvgUpdate(clsDonnee, clsMicbudgetdetailhisto, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicbudgetdetailhisto.BU_CODEBUDGET.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicbudgetdetailhistoWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsMicbudgetdetailhisto </returns>
		///<author>Home Technology</author>
		public List<clsMicbudgetdetailhisto> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicbudgetdetailhistoWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicbudgetdetailhisto </returns>
		///<author>Home Technology</author>
		public List<clsMicbudgetdetailhisto> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicbudgetdetailhistoWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicbudgetdetailhistoWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicbudgetdetailhistoWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "MICBUDGETDETAILHISTO  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "MICBUDGETDETAILHISTO  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "MICBUDGETDETAILHISTO  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "MICBUDGETDETAILHISTO  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
