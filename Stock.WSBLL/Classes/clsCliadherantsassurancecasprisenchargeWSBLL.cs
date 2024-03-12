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
	public class clsCliadherantsassurancecasprisenchargeWSBLL: IObjetWSBLL<clsCliadherantsassurancecasprisencharge>
	{
		private clsCliadherantsassurancecasprisenchargeWSDAL clsCliadherantsassurancecasprisenchargeWSDAL= new clsCliadherantsassurancecasprisenchargeWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliadherantsassurancecasprisenchargeWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliadherantsassurancecasprisenchargeWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliadherantsassurancecasprisenchargeWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliadherantsassurancecasprisencharge comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliadherantsassurancecasprisencharge pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliadherantsassurancecasprisenchargeWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCliadherantsassurancecasprisencharge">clsCliadherantsassurancecasprisencharge</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCliadherantsassurancecasprisencharge clsCliadherantsassurancecasprisencharge , clsObjetEnvoi clsObjetEnvoi)
		{
			clsCliadherantsassurancecasprisencharge.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsCliadherantsassurancecasprisenchargeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCliadherantsassurancecasprisenchargeWSDAL.pvgInsert(clsDonnee, clsCliadherantsassurancecasprisencharge);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCliadherantsassurancecasprisencharge.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCliadherantsassurancecasprisencharges"> Liste d'objet clsCliadherantsassurancecasprisencharge</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCliadherantsassurancecasprisencharge> clsCliadherantsassurancecasprisencharges , clsObjetEnvoi clsObjetEnvoi)
		{

			for (int Idx = 0; Idx < clsCliadherantsassurancecasprisencharges.Count; Idx++)
			{
                if (clsCliadherantsassurancecasprisencharges[Idx].COCHER == "O")
                {
                    // Sppression des données existantes avant insertion dans la base de données 
                    clsCliadherantsassurancecasprisenchargeWSDAL.pvgDelete(clsDonnee, clsCliadherantsassurancecasprisencharges[Idx].AG_CODEAGENCE, clsCliadherantsassurancecasprisencharges[Idx].AP_CODEPRODUIT, clsCliadherantsassurancecasprisencharges[Idx].TI_IDTIERSADHERANT, clsCliadherantsassurancecasprisencharges[Idx].AR_CODEARTICLE);
                    clsCliadherantsassurancecasprisenchargeWSDAL.pvgInsert(clsDonnee, clsCliadherantsassurancecasprisencharges[Idx]);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCliadherantsassurancecasprisencharges[Idx].AG_CODEAGENCE.ToString(), "A"));
                }
               
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCliadherantsassurancecasprisencharge">clsCliadherantsassurancecasprisencharge</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsCliadherantsassurancecasprisencharge clsCliadherantsassurancecasprisencharge,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCliadherantsassurancecasprisenchargeWSDAL.pvgUpdate(clsDonnee, clsCliadherantsassurancecasprisencharge, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCliadherantsassurancecasprisencharge.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCliadherantsassurancecasprisenchargeWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCliadherantsassurancecasprisencharge </returns>
		///<author>Home Technology</author>
		public List<clsCliadherantsassurancecasprisencharge> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliadherantsassurancecasprisenchargeWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliadherantsassurancecasprisencharge </returns>
		///<author>Home Technology</author>
		public List<clsCliadherantsassurancecasprisencharge> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliadherantsassurancecasprisenchargeWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliadherantsassurancecasprisenchargeWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetConfiguration(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsCliadherantsassurancecasprisenchargeWSDAL.pvgChargerDansDataSetConfiguration(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCliadherantsassurancecasprisenchargeWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CLIADHERANTSASSURANCECASPRISENCHARGE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CLIADHERANTSASSURANCECASPRISENCHARGE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CLIADHERANTSASSURANCECASPRISENCHARGE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CLIADHERANTSASSURANCECASPRISENCHARGE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
