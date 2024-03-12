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
	public class clsProfilwebdroitWSBLL: IObjetWSBLL<clsProfilwebdroit>
	{
		private clsProfilwebdroitWSDAL clsProfilwebdroitWSDAL= new clsProfilwebdroitWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebdroitWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebdroitWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebdroitWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsProfilwebdroit comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsProfilwebdroit pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebdroitWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfilwebdroit">clsProfilwebdroit</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsProfilwebdroit clsProfilwebdroit , clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfilwebdroit.PO_CODEPROFILWEB = string.Format( "{0:00}" , double.Parse(clsProfilwebdroitWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsProfilwebdroitWSDAL.pvgInsert(clsDonnee, clsProfilwebdroit);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilwebdroit.PO_CODEPROFILWEB.ToString(), "A"));
			return "";
		}


        public string pvgAjouterdroit(clsDonnee clsDonnee, List<clsProfilwebdroit> clsProfilwebdroitAjout, clsObjetEnvoi clsObjetEnvoi)
        {
            //// Sppression des données existantes avant insertion dans la base de données 
            //// clsOperateurdroitWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
            //for (int Idx = 0; Idx < clsOperateurdroitSuppression.Count; Idx++)
            //{

            //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroitAjout[0].OP_CODEOPERATEUR.ToString(), "A"));
            //}

            for (int Idx = 0; Idx < clsProfilwebdroitAjout.Count; Idx++)
            {
                clsProfilwebdroitWSDAL.pvgDelete(clsDonnee, clsProfilwebdroitAjout[0].PO_CODEPROFILWEB, clsProfilwebdroitAjout[Idx].OB_CODEOBJET.ToString());
                clsProfilwebdroitWSDAL.pvgInsert(clsDonnee, clsProfilwebdroitAjout[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilwebdroitAjout[Idx].PO_CODEPROFILWEB.ToString(), "A"));
            }

            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsProfilwebdroits"> Liste d'objet clsProfilwebdroit</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsProfilwebdroit> clsProfilwebdroits , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsProfilwebdroitWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsProfilwebdroits.Count; Idx++)
			{
				clsProfilwebdroits[Idx].PO_CODEPROFILWEB = string.Format( "{0:00}" , double.Parse(clsProfilwebdroitWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsProfilwebdroitWSDAL.pvgInsert(clsDonnee, clsProfilwebdroits[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilwebdroits[Idx].PO_CODEPROFILWEB.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfilwebdroit">clsProfilwebdroit</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsProfilwebdroit clsProfilwebdroit,clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfilwebdroitWSDAL.pvgUpdate(clsDonnee, clsProfilwebdroit, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilwebdroit.PO_CODEPROFILWEB.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfilwebdroitWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsProfilwebdroit </returns>
		///<author>Home Technology</author>
		public List<clsProfilwebdroit> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebdroitWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfilwebdroit </returns>
		///<author>Home Technology</author>
		public List<clsProfilwebdroit> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebdroitWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebdroitWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebdroitWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "Profilwebdroit  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "Profilwebdroit  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "Profilwebdroit  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "Profilwebdroit  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}

        public string pvgAjouterdroit(clsDonnee clsDonnee, List<clsProfilwebdroit> clsProfilwebdroitAjout, List<clsProfilwebdroit> clsProfilwebdroitSuppression, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            // clsProfilwebdroitWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
            for (int Idx = 0; Idx < clsProfilwebdroitSuppression.Count; Idx++)
            {
                clsProfilwebdroitWSDAL.pvgDelete(clsDonnee, clsProfilwebdroitSuppression[Idx].PO_CODEPROFILWEB, clsProfilwebdroitSuppression[Idx].OB_CODEOBJET.ToString());
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilwebdroitSuppression[Idx].PO_CODEPROFILWEB.ToString(), "A"));
            }

            for (int Idx = 0; Idx < clsProfilwebdroitAjout.Count; Idx++)
            {
                clsProfilwebdroitWSDAL.pvgInsert(clsDonnee, clsProfilwebdroitAjout[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilwebdroitAjout[Idx].PO_CODEPROFILWEB.ToString(), "A"));
            }

            return "";
        }

	}
}
