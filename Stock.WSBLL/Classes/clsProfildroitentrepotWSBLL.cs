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
	public class clsProfildroitentrepotWSBLL: IObjetWSBLL<clsProfildroitentrepot>
	{
		private clsProfildroitentrepotWSDAL clsProfildroitentrepotWSDAL= new clsProfildroitentrepotWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitentrepotWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitentrepotWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsProfildroitentrepot comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsProfildroitentrepot pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitentrepotWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfildroitentrepot">clsProfildroitentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsProfildroitentrepot clsProfildroitentrepot , clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfildroitentrepot.PO_CODEPROFIL = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsProfildroitentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsProfildroitentrepotWSDAL.pvgInsert(clsDonnee, clsProfildroitentrepot);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitentrepot.PO_CODEPROFIL.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfildroitentrepots"> Liste d'objet clsProfildroitentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsProfildroitentrepot> clsProfildroitentrepots , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsProfildroitentrepotWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsProfildroitentrepots.Count; Idx++)
			{
				clsProfildroitentrepots[Idx].PO_CODEPROFIL = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsProfildroitentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsProfildroitentrepotWSDAL.pvgInsert(clsDonnee, clsProfildroitentrepots[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitentrepots[Idx].PO_CODEPROFIL.ToString(), "A"));
			}
			return "";
		}

        public string pvgAjouterdroit(clsDonnee clsDonnee, List<clsProfildroitentrepot> clsProfildroitentrepotAjout, List<clsProfildroitentrepot> clsProfildroitentrepotSuppression, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            // clsProfildroitentrepotWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
            clsProfildroitentrepotWSDAL.pvgDelete(clsDonnee, clsProfildroitentrepotAjout[0].PO_CODEPROFIL);
            for (int Idx = 0; Idx < clsProfildroitentrepotAjout.Count; Idx++)
            {
                if (clsProfildroitentrepotAjout[Idx].COCHER == "O")
                {
                    clsProfildroitentrepotWSDAL.pvgInsert(clsDonnee, clsProfildroitentrepotAjout[Idx]);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitentrepotAjout[Idx].PO_CODEPROFIL.ToString(), "A"));
                }
            }

            //for (int Idx = 0; Idx < clsProfildroitentrepotSuppression.Count; Idx++)
            //{
            //    clsProfildroitentrepotWSDAL.pvgDelete(clsDonnee, clsProfildroitentrepotSuppression[Idx].PO_CODEPROFIL, clsProfildroitentrepotSuppression[Idx].EN_CODEENTREPOT);
            //    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitentrepotSuppression[Idx].PO_CODEPROFIL.ToString(), "A"));
            //}
            return "";
        }

        
        
        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfildroitentrepot">clsProfildroitentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsProfildroitentrepot clsProfildroitentrepot,clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfildroitentrepotWSDAL.pvgUpdate(clsDonnee, clsProfildroitentrepot, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfildroitentrepot.PO_CODEPROFIL.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfildroitentrepotWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsProfildroitentrepot </returns>
		///<author>Home Technology</author>
		public List<clsProfildroitentrepot> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitentrepotWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfildroitentrepot </returns>
		///<author>Home Technology</author>
		public List<clsProfildroitentrepot> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitentrepotWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitentrepotWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPROFIL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfildroitentrepotWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
