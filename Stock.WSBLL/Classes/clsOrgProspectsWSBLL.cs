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
	public class clsOrgProspectsWSBLL: IObjetWSBLL<clsOrgProspects>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsOrgProspectsWSDAL clsOrgProspectsWSDAL= new clsOrgProspectsWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOrgProspectsWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOrgProspectsWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOrgProspectsWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsOrgProspects comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsOrgProspects pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOrgProspectsWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsOrgProspects comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsOrgProspects pvgTableLabelVENTE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOrgProspectsWSDAL.pvgTableLabelVENTE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsOrgProspects comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsOrgProspects pvgTableLabelVENTECaisse(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOrgProspectsWSDAL.pvgTableLabelVENTECaisse(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PR_IDTIERS)</summary>
        ///<param name="vppCritere">Critère de la requète SELECT</param>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>
        //public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsOrgProspectsWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}

        public DataSet pvgInsertIntoDatasetRecherche(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOrgProspectsWSDAL.pvgChargerDansDataSetRecherche(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetParSexe(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOrgProspectsWSDAL.pvgChargerDansDataSetParSexe(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsOrgProspects">clsOrgProspects</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects , clsObjetEnvoi clsObjetEnvoi)
		{
            //clsOrgProspects.PR_IDTIERS = (double.Parse(clsOrgProspectsWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            //if (clsOrgProspects.PR_IDTIERS == "1") clsOrgProspects.PR_IDTIERS = clsObjetEnvoi.OE_A + "00000001";
            //clsOrgProspects.PR_NUMTIERS = string.Format("{0:0000000}", double.Parse(clsOrgProspectsWSDAL.pvgValueScalarRequeteMax1(clsDonnee, clsObjetEnvoi.OE_A)) + 1);

            clsOrgProspectsWSDAL.pvgMiseajour(clsDonnee, clsOrgProspects);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOrgProspects.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsOrgProspects">clsOrgProspects</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>

        public DataSet pvgControlComptesLies(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOrgProspectsWSDAL.pvgControlComptesLies(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsOrgProspects">clsOrgProspects</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseajourNumero(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOrgProspectsWSDAL.pvgMiseajourNumero(clsDonnee, clsOrgProspects);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOrgProspects.AG_CODEAGENCE.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, IN_CODEINSCRIPTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgDepartTiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOrgProspectsWSDAL.pvgDepartTiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsOrgProspectss"> Liste d'objet clsOrgProspects</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsOrgProspects> clsOrgProspectss , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
            //clsOrgProspectsWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsOrgProspectss.Count; Idx++)
			{
                //clsOrgProspectss[Idx].AG_CODEAGENCE = string.Format( "{0:000}" , double.Parse(clsOrgProspectsWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                clsOrgProspectsWSDAL.pvgMiseajour(clsDonnee, clsOrgProspectss[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOrgProspectss[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsOrgProspectss"> Liste d'objet clsOrgProspects</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterTiers(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects, clsObjetEnvoi clsObjetEnvoi)
        {
            //clsOrgProspects.TYPEOPERATION = "0";//definition de l'action a mener
            //
            string vlpPR_NUMTIERSRETOUR = clsOrgProspectsWSDAL.pvgMiseajour(clsDonnee, clsOrgProspects);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOrgProspects.PR_IDTIERS.ToString(), "A"));
            return vlpPR_NUMTIERSRETOUR;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsOrgProspectss"> Liste d'objet clsOrgProspects</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifierTiers(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOrgProspects.TYPEOPERATION = "1";//definition de l'action a mener
            clsOrgProspectsWSDAL.pvgMiseajour(clsDonnee, clsOrgProspects);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOrgProspects.PR_IDTIERS.ToString(), "M"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsOrgProspects">clsOrgProspects</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects,clsObjetEnvoi clsObjetEnvoi)
		{
			clsOrgProspectsWSDAL.pvgUpdate(clsDonnee, clsOrgProspects, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOrgProspects.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}


        //<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:EJ_IDEPARGNANTJOURNALIER)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsStockepargnantjournalier">clsStockepargnantjournalier</param>
        ///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgSupprimerTiers(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOrgProspects.TYPEOPERATION = "2";//definition de l'action a mener
            clsOrgProspectsWSDAL.pvgMiseajour(clsDonnee, clsOrgProspects);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOrgProspects.PR_IDTIERS.ToString(), "S"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            clsOrgProspectsPhotoWSDAL clsOrgProspectsPhotoWSDAL = new clsOrgProspectsPhotoWSDAL();
            clsOrgProspectsPhotoWSDAL.pvgDelete1(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsOrgProspectsWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);

			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsOrgProspects </returns>
		///<author>Home Technology</author>
		public List<clsOrgProspects> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOrgProspectsWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOrgProspects </returns>
		///<author>Home Technology</author>
		public List<clsOrgProspects> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOrgProspectsWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOrgProspectsWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerRechercheTiersparNom(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOrgProspectsWSDAL.pvgChargerRechercheTiersparNom(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }	

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOrgProspectsWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOrgProspectsWSDAL.pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOrgProspectsWSDAL.pvgChargerDansDataSetTiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHATIERS  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHATIERS  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHATIERS  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHATIERS  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
