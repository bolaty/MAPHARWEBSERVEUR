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
	public class clsPhatiersWSBLL: IObjetWSBLL<clsPhatiers>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsPhatiersWSDAL clsPhatiersWSDAL= new clsPhatiersWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhatiersWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhatiersWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhatiersWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhatiers comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhatiers pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhatiersWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPhatiers comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPhatiers pvgTableLabelVENTE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgTableLabelVENTE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPhatiers comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPhatiers pvgTableLabelVENTECaisse(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgTableLabelVENTECaisse(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:TI_IDTIERS)</summary>
        ///<param name="vppCritere">Critère de la requète SELECT</param>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>
        //public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsPhatiersWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}

        public DataSet pvgInsertIntoDatasetRecherche(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetRecherche(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetParSexe(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetParSexe(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhatiers">clsPhatiers</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhatiers clsPhatiers , clsObjetEnvoi clsObjetEnvoi)
		{
            //clsPhatiers.TI_IDTIERS = (double.Parse(clsPhatiersWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            //if (clsPhatiers.TI_IDTIERS == "1") clsPhatiers.TI_IDTIERS = clsObjetEnvoi.OE_A + "00000001";
            //clsPhatiers.TI_NUMTIERS = string.Format("{0:0000000}", double.Parse(clsPhatiersWSDAL.pvgValueScalarRequeteMax1(clsDonnee, clsObjetEnvoi.OE_A)) + 1);
            string TI_NUMTIERSRETOUR = "";
            TI_NUMTIERSRETOUR = clsPhatiersWSDAL.pvgMiseajour(clsDonnee, clsPhatiers);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhatiers.AG_CODEAGENCE.ToString(), "A"));
			return TI_NUMTIERSRETOUR;
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhatiers">clsPhatiers</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>

        public DataSet pvgControlComptesLies(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgControlComptesLies(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhatiers">clsPhatiers</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseajourNumero(clsDonnee clsDonnee, clsPhatiers clsPhatiers, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhatiersWSDAL.pvgMiseajourNumero(clsDonnee, clsPhatiers);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhatiers.AG_CODEAGENCE.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, IN_CODEINSCRIPTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgDepartTiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhatiersWSDAL.pvgDepartTiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhatierss"> Liste d'objet clsPhatiers</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhatiers> clsPhatierss , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
            //clsPhatiersWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhatierss.Count; Idx++)
			{
                //clsPhatierss[Idx].AG_CODEAGENCE = string.Format( "{0:000}" , double.Parse(clsPhatiersWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                clsPhatiersWSDAL.pvgMiseajour(clsDonnee, clsPhatierss[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhatierss[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhatierss"> Liste d'objet clsPhatiers</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterTiers(clsDonnee clsDonnee, clsPhatiers clsPhatiers, clsObjetEnvoi clsObjetEnvoi)
        {
            //clsPhatiers.TYPEOPERATION = "0";//definition de l'action a mener
            //
            string vlpTI_NUMTIERSRETOUR = clsPhatiersWSDAL.pvgMiseajour(clsDonnee, clsPhatiers);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhatiers.TI_IDTIERS.ToString(), "A"));
            return vlpTI_NUMTIERSRETOUR;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhatierss"> Liste d'objet clsPhatiers</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifierTiers(clsDonnee clsDonnee, clsPhatiers clsPhatiers, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhatiers.TYPEOPERATION = "1";//definition de l'action a mener
            clsPhatiersWSDAL.pvgMiseajour(clsDonnee, clsPhatiers);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhatiers.TI_IDTIERS.ToString(), "M"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhatiers">clsPhatiers</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhatiers clsPhatiers,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhatiersWSDAL.pvgUpdate(clsDonnee, clsPhatiers, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhatiers.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}


        //<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:EJ_IDEPARGNANTJOURNALIER)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsStockepargnantjournalier">clsStockepargnantjournalier</param>
        ///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgSupprimerTiers(clsDonnee clsDonnee, clsPhatiers clsPhatiers, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhatiers.TYPEOPERATION = "2";//definition de l'action a mener
          
            clsPhatiersWSDAL.pvgMiseajour(clsDonnee, clsPhatiers);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhatiers.TI_IDTIERS.ToString(), "S"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{

            clsPhatiersphotoWSDAL clsPhatiersphotoWSDAL = new clsPhatiersphotoWSDAL();
            clsPhatiersphotoWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM[0].ToString(), clsObjetEnvoi.OE_PARAM[1].ToString());
            clsPhatiersWSDAL.pvgDeleteCompteWeb(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsPhatiersWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhatiers </returns>
		///<author>Home Technology</author>
		public List<clsPhatiers> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhatiersWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhatiers </returns>
		///<author>Home Technology</author>
		public List<clsPhatiers> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhatiersWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhatiersWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerRechercheTiersparNom(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerRechercheTiersparNom(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }	

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhatiersWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetLOGIN(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetLOGIN(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetAssure(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetAssure(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetAssureAvecCodeClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetAssureAvecCodeClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetAssureur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetAssureur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTiersN(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetTiersN(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhatiersWSDAL.pvgChargerDansDataSetTiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
