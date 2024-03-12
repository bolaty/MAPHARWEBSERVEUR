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
	public class clsProfildroitsaisieentrepotWSBLL: IObjetWSBLL<clsProfildroitsaisieentrepot>
	{
		private clsProfildroitsaisieentrepotWSDAL clsProfildroitsaisieentrepotWSDAL= new clsProfildroitsaisieentrepotWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitsaisieentrepotWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitsaisieentrepotWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitsaisieentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsProfildroitsaisieentrepot comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsProfildroitsaisieentrepot pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitsaisieentrepotWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfildroitsaisieentrepot">clsProfildroitsaisieentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsProfildroitsaisieentrepot clsProfildroitsaisieentrepot , clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfildroitsaisieentrepot.PO_CODEPROFIL = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsProfildroitsaisieentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsProfildroitsaisieentrepotWSDAL.pvgInsert(clsDonnee, clsProfildroitsaisieentrepot);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitsaisieentrepot.PO_CODEPROFIL.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfildroitsaisieentrepots"> Liste d'objet clsProfildroitsaisieentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsProfildroitsaisieentrepot> clsProfildroitsaisieentrepots , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsProfildroitsaisieentrepotWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsProfildroitsaisieentrepots.Count; Idx++)
			{
				clsProfildroitsaisieentrepots[Idx].PO_CODEPROFIL = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsProfildroitsaisieentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsProfildroitsaisieentrepotWSDAL.pvgInsert(clsDonnee, clsProfildroitsaisieentrepots[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitsaisieentrepots[Idx].PO_CODEPROFIL.ToString(), "A"));
			}
			return "";
		}

        public string pvgAjouterdroit(clsDonnee clsDonnee, List<clsProfildroitsaisieentrepot> clsProfildroitsaisieentrepotAjout, List<clsProfildroitsaisieentrepot> clsProfildroitsaisieentrepotSuppression, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            // clsProfildroitsaisieentrepotWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
            clsProfildroitsaisieentrepotWSDAL.pvgDelete(clsDonnee, clsProfildroitsaisieentrepotAjout[0].PO_CODEPROFIL);
            for (int Idx = 0; Idx < clsProfildroitsaisieentrepotAjout.Count; Idx++)
            {
                if (clsProfildroitsaisieentrepotAjout[Idx].COCHER == "O")
                {
                    clsProfildroitsaisieentrepotWSDAL.pvgInsert(clsDonnee, clsProfildroitsaisieentrepotAjout[Idx]);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitsaisieentrepotAjout[Idx].PO_CODEPROFIL.ToString(), "A"));
                }
            }

            //for (int Idx = 0; Idx < clsProfildroitsaisieentrepotSuppression.Count; Idx++)
            //{
            //    clsProfildroitsaisieentrepotWSDAL.pvgDelete(clsDonnee, clsProfildroitsaisieentrepotSuppression[Idx].PO_CODEPROFIL, clsProfildroitsaisieentrepotSuppression[Idx].EN_CODEENTREPOT);
            //    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitsaisieentrepotSuppression[Idx].PO_CODEPROFIL.ToString(), "A"));
            //}
            return "";
        }

        
        
        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfildroitsaisieentrepot">clsProfildroitsaisieentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsProfildroitsaisieentrepot clsProfildroitsaisieentrepot,clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfildroitsaisieentrepotWSDAL.pvgUpdate(clsDonnee, clsProfildroitsaisieentrepot, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitsaisieentrepot.PO_CODEPROFIL.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfildroitsaisieentrepotWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsProfildroitsaisieentrepot </returns>
		///<author>Home Technology</author>
		public List<clsProfildroitsaisieentrepot> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitsaisieentrepotWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfildroitsaisieentrepot </returns>
		///<author>Home Technology</author>
		public List<clsProfildroitsaisieentrepot> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitsaisieentrepotWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitsaisieentrepotWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitsaisieentrepotWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
            //clsMouchard.PO_CODEPROFIL = clsObjetEnvoi.OE_Y;
			switch (vppTypeAction)
			{
				case "A":
					clsMouchard.MO_ACTION = "OPERATEURDROITPHAPARENTREPOT  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "OPERATEURDROITPHAPARENTREPOT  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "OPERATEURDROITPHAPARENTREPOT  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "OPERATEURDROITPHAPARENTREPOT  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
