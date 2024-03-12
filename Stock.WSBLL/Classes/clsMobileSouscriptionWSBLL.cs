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
	public class clsMobileSouscriptionWSBLL: IObjetWSBLL<clsMobileSouscription>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsMobileSouscriptionWSDAL clsMobileSouscriptionWSDAL= new clsMobileSouscriptionWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMobileSouscriptionWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMobileSouscriptionWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMobileSouscriptionWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMobileSouscription comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMobileSouscription pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMobileSouscriptionWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMobileSouscription comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMobileSouscription pvgTableLabelVENTE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMobileSouscriptionWSDAL.pvgTableLabelVENTE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMobileSouscription comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMobileSouscription pvgTableLabelVENTECaisse(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMobileSouscriptionWSDAL.pvgTableLabelVENTECaisse(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:TI_IDTIERS)</summary>
        ///<param name="vppCritere">Critère de la requète SELECT</param>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>
        //public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsMobileSouscriptionWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}

        public DataSet pvgInsertIntoDatasetRecherche(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMobileSouscriptionWSDAL.pvgChargerDansDataSetRecherche(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetParSexe(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMobileSouscriptionWSDAL.pvgChargerDansDataSetParSexe(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMobileSouscription">clsMobileSouscription</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription , clsObjetEnvoi clsObjetEnvoi)
		{
            //clsMobileSouscription.TI_IDTIERS = (double.Parse(clsMobileSouscriptionWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            //if (clsMobileSouscription.TI_IDTIERS == "1") clsMobileSouscription.TI_IDTIERS = clsObjetEnvoi.OE_A + "00000001";
            //clsMobileSouscription.TI_NUMTIERS = string.Format("{0:0000000}", double.Parse(clsMobileSouscriptionWSDAL.pvgValueScalarRequeteMax1(clsDonnee, clsObjetEnvoi.OE_A)) + 1);

            clsMobileSouscriptionWSDAL.pvgMiseajour(clsDonnee, clsMobileSouscription);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMobileSouscription.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMobileSouscription">clsMobileSouscription</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>

        public DataSet pvgControlComptesLies(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMobileSouscriptionWSDAL.pvgControlComptesLies(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMobileSouscription">clsMobileSouscription</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseajourNumero(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription, clsObjetEnvoi clsObjetEnvoi)
        {
            //clsMobileSouscriptionWSDAL.pvgMiseajourNumero(clsDonnee, clsMobileSouscription);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMobileSouscription.AG_CODEAGENCE.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, IN_CODEINSCRIPTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgDepartTiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsMobileSouscriptionWSDAL.pvgDepartTiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMobileSouscriptions"> Liste d'objet clsMobileSouscription</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsMobileSouscription> clsMobileSouscriptions , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
            //clsMobileSouscriptionWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsMobileSouscriptions.Count; Idx++)
			{
                //clsMobileSouscriptions[Idx].AG_CODEAGENCE = string.Format( "{0:000}" , double.Parse(clsMobileSouscriptionWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                clsMobileSouscriptionWSDAL.pvgMiseajour(clsDonnee, clsMobileSouscriptions[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMobileSouscriptions[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMobileSouscriptions"> Liste d'objet clsMobileSouscription</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterTiers(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription, clsObjetEnvoi clsObjetEnvoi)
        {
            //clsMobileSouscription.TYPEOPERATION = "0";//definition de l'action a mener
            //
            string vlpTI_NUMTIERSRETOUR = clsMobileSouscriptionWSDAL.pvgMiseajour(clsDonnee, clsMobileSouscription);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMobileSouscription.TI_IDTIERS.ToString(), "A"));
            return vlpTI_NUMTIERSRETOUR;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMobileSouscriptions"> Liste d'objet clsMobileSouscription</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifierTiers(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription, clsObjetEnvoi clsObjetEnvoi)
        {
            //clsMobileSouscription.TYPEOPERATION = "1";//definition de l'action a mener
            clsMobileSouscriptionWSDAL.pvgMiseajour(clsDonnee, clsMobileSouscription);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMobileSouscription.TI_IDTIERS.ToString(), "M"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMobileSouscription">clsMobileSouscription</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMobileSouscriptionWSDAL.pvgUpdate(clsDonnee, clsMobileSouscription, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMobileSouscription.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}


        //<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:EJ_IDEPARGNANTJOURNALIER)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsStockepargnantjournalier">clsStockepargnantjournalier</param>
        ///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgSupprimerTiers(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription, clsObjetEnvoi clsObjetEnvoi)
        {
            //clsMobileSouscription.TYPEOPERATION = "2";//definition de l'action a mener
            clsMobileSouscriptionWSDAL.pvgMiseajour(clsDonnee, clsMobileSouscription);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMobileSouscription.TI_IDTIERS.ToString(), "S"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMobileSouscriptionWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsMobileSouscription </returns>
		///<author>Home Technology</author>
		public List<clsMobileSouscription> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMobileSouscriptionWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMobileSouscription </returns>
		///<author>Home Technology</author>
		public List<clsMobileSouscription> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMobileSouscriptionWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMobileSouscriptionWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerRechercheTiersparNom(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMobileSouscriptionWSDAL.pvgChargerRechercheTiersparNom(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }	

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMobileSouscriptionWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMobileSouscriptionWSDAL.pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMobileSouscriptionWSDAL.pvgChargerDansDataSetTiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEZenithMobile, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public DataSet pvgSouscriptionMobileBanking(clsDonnee clsDonnee, string LG_CODELANGUE, string AG_CODEAGENCE, string TI_IDTIERS, string SO_CODESOUSCRIPTION, string PY_CODEPAYS, string SO_TELEPHONE, string DATEJOURNEE, string SO_EMAIL, string SO_LIEURESIDENCE,  string TYPEOPERATION)
        {
            return clsMobileSouscriptionWSDAL.pvgSouscriptionMobileBanking(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TI_IDTIERS, SO_CODESOUSCRIPTION, PY_CODEPAYS, SO_TELEPHONE, DATEJOURNEE, SO_EMAIL, SO_LIEURESIDENCE, TYPEOPERATION);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEZenithMobile, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public DataSet pvgCompteMobileMappe(clsDonnee clsDonnee, string LG_CODELANGUE, string AG_CODEAGENCE, string TI_IDTIERS, string TYPEOPERATION)
        {
            return clsMobileSouscriptionWSDAL.pvgCompteMobileMappe(clsDonnee, LG_CODELANGUE, AG_CODEAGENCE, TI_IDTIERS, TYPEOPERATION);
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
					clsMouchard.MO_ACTION = "MobileSouscription  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "MobileSouscription  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "MobileSouscription  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "MobileSouscription  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
