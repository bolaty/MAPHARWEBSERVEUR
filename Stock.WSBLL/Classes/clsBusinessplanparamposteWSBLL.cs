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
	public class clsBusinessplanparamposteWSBLL: IObjetWSBLL<clsBusinessplanparamposte>
	{
		private clsBusinessplanparamposteWSDAL clsBusinessplanparamposteWSDAL= new clsBusinessplanparamposteWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsBusinessplanparamposteWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsBusinessplanparamposteWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsBusinessplanparamposteWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBusinessplanparamposte comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBusinessplanparamposte pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsBusinessplanparamposteWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsBusinessplanparamposte">clsBusinessplanparamposte</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsBusinessplanparamposte clsBusinessplanparamposte , clsObjetEnvoi clsObjetEnvoi)
		{
			clsBusinessplanparamposte.PO_CODEPOSTEBUSINESSPLAN = string.Format( "{0:0000000}" , double.Parse(clsBusinessplanparamposteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsBusinessplanparamposteWSDAL.pvgInsert(clsDonnee, clsBusinessplanparamposte);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsBusinessplanparamposte.PO_CODEPOSTEBUSINESSPLAN.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsBusinessplanparampostes"> Liste d'objet clsBusinessplanparamposte</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsBusinessplanparamposte> clsBusinessplanparampostes , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsBusinessplanparamposteWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsBusinessplanparampostes.Count; Idx++)
			{
				clsBusinessplanparampostes[Idx].PO_CODEPOSTEBUSINESSPLAN = string.Format( "{0:0000000}" , double.Parse(clsBusinessplanparamposteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsBusinessplanparamposteWSDAL.pvgInsert(clsDonnee, clsBusinessplanparampostes[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsBusinessplanparampostes[Idx].PO_CODEPOSTEBUSINESSPLAN.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsBusinessplanparamposte">clsBusinessplanparamposte</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsBusinessplanparamposte clsBusinessplanparamposte,clsObjetEnvoi clsObjetEnvoi)
		{
			clsBusinessplanparamposteWSDAL.pvgUpdate(clsDonnee, clsBusinessplanparamposte, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsBusinessplanparamposte.PO_CODEPOSTEBUSINESSPLAN.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsBusinessplanparamposteWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsBusinessplanparamposte </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamposte> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsBusinessplanparamposteWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamposte </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamposte> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsBusinessplanparamposteWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsBusinessplanparamposteWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsBusinessplanparamposteWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "BUSINESSPLANPARAMPOSTE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "BUSINESSPLANPARAMPOSTE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "BUSINESSPLANPARAMPOSTE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "BUSINESSPLANPARAMPOSTE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
