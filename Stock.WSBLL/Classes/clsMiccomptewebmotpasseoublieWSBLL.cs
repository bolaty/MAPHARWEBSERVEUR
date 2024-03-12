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
	public class clsMiccomptewebmotpasseoublieWSBLL: IObjetWSBLL<clsMiccomptewebmotpasseoublie>
	{
		private clsMiccomptewebmotpasseoublieWSDAL clsMiccomptewebmotpasseoublieWSDAL= new clsMiccomptewebmotpasseoublieWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMiccomptewebmotpasseoublieWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMiccomptewebmotpasseoublieWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMiccomptewebmotpasseoublieWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMiccomptewebmotpasseoublie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMiccomptewebmotpasseoublie pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMiccomptewebmotpasseoublieWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMiccomptewebmotpasseoublie">clsMiccomptewebmotpasseoublie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie , clsObjetEnvoi clsObjetEnvoi)
		{
			clsMiccomptewebmotpasseoublie.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsMiccomptewebmotpasseoublieWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsMiccomptewebmotpasseoublieWSDAL.pvgInsert(clsDonnee, clsMiccomptewebmotpasseoublie);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMiccomptewebmotpasseoublie.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMiccomptewebmotpasseoublies"> Liste d'objet clsMiccomptewebmotpasseoublie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsMiccomptewebmotpasseoublieWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsMiccomptewebmotpasseoublies.Count; Idx++)
			{
				clsMiccomptewebmotpasseoublies[Idx].AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsMiccomptewebmotpasseoublieWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsMiccomptewebmotpasseoublieWSDAL.pvgInsert(clsDonnee, clsMiccomptewebmotpasseoublies[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMiccomptewebmotpasseoublies[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMiccomptewebmotpasseoublie">clsMiccomptewebmotpasseoublie</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMiccomptewebmotpasseoublieWSDAL.pvgUpdate(clsDonnee, clsMiccomptewebmotpasseoublie, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMiccomptewebmotpasseoublie.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMiccomptewebmotpasseoublieWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsMiccomptewebmotpasseoublie </returns>
		///<author>Home Technology</author>
		public List<clsMiccomptewebmotpasseoublie> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMiccomptewebmotpasseoublieWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMiccomptewebmotpasseoublie </returns>
		///<author>Home Technology</author>
		public List<clsMiccomptewebmotpasseoublie> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMiccomptewebmotpasseoublieWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMiccomptewebmotpasseoublieWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, RP_DATE, RP_NUMSEQUENCE, MB_IDTIERS, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMiccomptewebmotpasseoublieWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public List<clsMiccomptewebmotpasseoublie> pvgSelectDataSetUserForgotPassword(clsDonnee clsDonnee, string LG_CODELANGUE, string CL_CONTACT, string CL_CODECLIENT, string TYPEOPERATION)
        {
            return clsMiccomptewebmotpasseoublieWSDAL.pvgSelectDataSetUserForgotPassword(clsDonnee, LG_CODELANGUE, CL_CONTACT, CL_CODECLIENT, TYPEOPERATION);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public List<clsMiccomptewebUserNewPassword> pvgUserUpdatePassword(clsDonnee clsDonnee, string LG_CODELANGUE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW)
        {
            return clsMiccomptewebmotpasseoublieWSDAL.pvgUserUpdatePassword(clsDonnee, LG_CODELANGUE, SL_MOTPASSEOLD, SL_LOGINOLD, SL_MOTPASSENEW, SL_LOGINNEW);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public List<clsMiccomptewebUserNewPassword> pvgUserUpdatePasswordClient(clsDonnee clsDonnee, string LG_CODELANGUE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW)
        {
            return clsMiccomptewebmotpasseoublieWSDAL.pvgUserUpdatePasswordClient(clsDonnee, LG_CODELANGUE, SL_MOTPASSEOLD, SL_LOGINOLD, SL_MOTPASSENEW, SL_LOGINNEW);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTETontineMobile, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsTontineweb </returns>
        ///<author>Home Technology</author>
        public List<clsMiccomptewebUserNewPassword> pvgUserNewPassword(clsDonnee clsDonnee, string LG_CODELANGUE, string SL_MOTPASSE, string RP_CODEVALIDATION, string RP_DATE, string RP_HEURE, string TYPEOPERATION)
        {
            return clsMiccomptewebmotpasseoublieWSDAL.pvgUserNewPassword(clsDonnee, LG_CODELANGUE, SL_MOTPASSE, RP_CODEVALIDATION, RP_DATE, RP_HEURE, TYPEOPERATION);
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
					clsMouchard.MO_ACTION = "Miccomptewebmotpasseoublie  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "Miccomptewebmotpasseoublie  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "Miccomptewebmotpasseoublie  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "Miccomptewebmotpasseoublie  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
