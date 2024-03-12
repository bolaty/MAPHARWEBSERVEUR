using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSDAL;
using System.IO;

namespace Stock.WSBLL
{
	public class clsCtcontratchequephotoreglementcaisseWSBLL: IObjetWSBLL<clsCtcontratchequephotoreglementcaisse>
	{
		private clsCtcontratchequephotoreglementcaisseWSDAL clsCtcontratchequephotoreglementcaisseWSDAL= new clsCtcontratchequephotoreglementcaisseWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoreglementcaisseWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoreglementcaisseWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoreglementcaisseWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratchequephotoreglementcaisse comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratchequephotoreglementcaisse pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoreglementcaisseWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratchequephotoreglementcaisse">clsCtcontratchequephotoreglementcaisse</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsCtcontratchequephotoreglementcaisseWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCtcontratchequephotoreglementcaisseWSDAL.pvgInsert(clsDonnee, clsCtcontratchequephotoreglementcaisse);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratchequephotoreglementcaisses"> Liste d'objet clsCtcontratchequephotoreglementcaisse</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses , clsObjetEnvoi clsObjetEnvoi)
		{
            // Sppression des données existantes avant insertion dans la base de données 
           
            clsCtcontratchequephotoreglementcaisseWSDAL.pvgDeleteListe(clsDonnee , clsCtcontratchequephotoreglementcaisses[0].AG_CODEAGENCE, clsCtcontratchequephotoreglementcaisses[0].CHC_DATESAISIECHEQUE.ToShortDateString(), clsCtcontratchequephotoreglementcaisses[0].CHC_IDEXCHEQUE);
			for (int Idx = 0; Idx < clsCtcontratchequephotoreglementcaisses.Count; Idx++)
			{
                string vlpIndex = "";
                string vlpFichier = clsCtcontratchequephotoreglementcaisses[Idx].CHC_CHEMINPHOTOCHEQUE;
                clsCtcontratchequephotoreglementcaisses[Idx].CHC_CHEMINPHOTOCHEQUE = clsCtcontratchequephotoreglementcaisses[Idx].AG_CODEAGENCE + "_" + clsCtcontratchequephotoreglementcaisses[Idx].CHC_DATESAISIECHEQUE.ToShortDateString().Replace("/", "") + "_" + clsCtcontratchequephotoreglementcaisses[Idx].CHC_IDEXCHEQUE;
                clsCtcontratchequephotoreglementcaisses[Idx].TYPEOPERATION = 0;
                vlpIndex = clsCtcontratchequephotoreglementcaisseWSDAL.pvgMiseAJour(clsDonnee, clsCtcontratchequephotoreglementcaisses[Idx]);

                clsCtcontratchequephotoreglementcaisseWSDAL.pvgUploadPhotoSignature(clsDonnee, vlpFichier, "CHEQ_" + clsCtcontratchequephotoreglementcaisses[Idx].AG_CODEAGENCE + "_" + clsCtcontratchequephotoreglementcaisses[Idx].CHC_DATESAISIECHEQUE.ToShortDateString().Replace("/","") + "_" + clsCtcontratchequephotoreglementcaisses[Idx].CHC_IDEXCHEQUE + "_" + vlpIndex, "PHOT1");

                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephotoreglementcaisses[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratchequephotoreglementcaisse">clsCtcontratchequephotoreglementcaisse</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtcontratchequephotoreglementcaisseWSDAL.pvgUpdate(clsDonnee, clsCtcontratchequephotoreglementcaisse, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtcontratchequephotoreglementcaisseWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCtcontratchequephotoreglementcaisse </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequephotoreglementcaisse> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoreglementcaisseWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratchequephotoreglementcaisse </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequephotoreglementcaisse> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoreglementcaisseWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            return clsCtcontratchequephotoreglementcaisseWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoreglementcaisseWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CTCONTRATCHEQUEPHOTO  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CTCONTRATCHEQUEPHOTO  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CTCONTRATCHEQUEPHOTO  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CTCONTRATCHEQUEPHOTO  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
