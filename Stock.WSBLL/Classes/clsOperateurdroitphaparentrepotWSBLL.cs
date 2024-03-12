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
	public class clsOperateurdroitphaparentrepotWSBLL: IObjetWSBLL<clsOperateurdroitphaparentrepot>
	{
		private clsOperateurdroitphaparentrepotWSDAL clsOperateurdroitphaparentrepotWSDAL= new clsOperateurdroitphaparentrepotWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitphaparentrepotWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitphaparentrepotWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitphaparentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsOperateurdroitphaparentrepot comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsOperateurdroitphaparentrepot pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitphaparentrepotWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsOperateurdroitphaparentrepot">clsOperateurdroitphaparentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot , clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurdroitphaparentrepot.OP_CODEOPERATEUR = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsOperateurdroitphaparentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsOperateurdroitphaparentrepotWSDAL.pvgInsert(clsDonnee, clsOperateurdroitphaparentrepot);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroitphaparentrepot.OP_CODEOPERATEUR.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsOperateurdroitphaparentrepots"> Liste d'objet clsOperateurdroitphaparentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsOperateurdroitphaparentrepotWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsOperateurdroitphaparentrepots.Count; Idx++)
			{
				clsOperateurdroitphaparentrepots[Idx].OP_CODEOPERATEUR = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsOperateurdroitphaparentrepotWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsOperateurdroitphaparentrepotWSDAL.pvgInsert(clsDonnee, clsOperateurdroitphaparentrepots[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroitphaparentrepots[Idx].OP_CODEOPERATEUR.ToString(), "A"));
			}
			return "";
		}

        public string pvgAjouterdroit(clsDonnee clsDonnee, List<clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepotAjout, List<clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepotSuppression, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            // clsOperateurdroitphaparentrepotWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
            clsOperateurdroitphaparentrepotWSDAL.pvgDelete(clsDonnee, clsOperateurdroitphaparentrepotAjout[0].OP_CODEOPERATEUR);
            for (int Idx = 0; Idx < clsOperateurdroitphaparentrepotAjout.Count; Idx++)
            {
                if (clsOperateurdroitphaparentrepotAjout[Idx].COCHER == "O")
                {
                    clsOperateurdroitphaparentrepotWSDAL.pvgInsert(clsDonnee, clsOperateurdroitphaparentrepotAjout[Idx]);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroitphaparentrepotAjout[Idx].OP_CODEOPERATEUR.ToString(), "A"));
                }
            }

            //for (int Idx = 0; Idx < clsOperateurdroitphaparentrepotSuppression.Count; Idx++)
            //{
            //    clsOperateurdroitphaparentrepotWSDAL.pvgDelete(clsDonnee, clsOperateurdroitphaparentrepotSuppression[Idx].OP_CODEOPERATEUR, clsOperateurdroitphaparentrepotSuppression[Idx].EN_CODEENTREPOT);
            //    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroitphaparentrepotSuppression[Idx].OP_CODEOPERATEUR.ToString(), "A"));
            //}
            return "";
        }

        
        
        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsOperateurdroitphaparentrepot">clsOperateurdroitphaparentrepot</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot,clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurdroitphaparentrepotWSDAL.pvgUpdate(clsDonnee, clsOperateurdroitphaparentrepot, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroitphaparentrepot.OP_CODEOPERATEUR.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurdroitphaparentrepotWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsOperateurdroitphaparentrepot </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitphaparentrepot> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitphaparentrepotWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitphaparentrepot </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitphaparentrepot> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitphaparentrepotWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitphaparentrepotWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitphaparentrepotWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
