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
	public class clsMicparametrelisteproduitsousproduitvaleurWSBLL: IObjetWSBLL<clsMicparametrelisteproduitsousproduitvaleur>
	{
		private clsMicparametrelisteproduitsousproduitvaleurWSDAL clsMicparametrelisteproduitsousproduitvaleurWSDAL= new clsMicparametrelisteproduitsousproduitvaleurWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMicparametrelisteproduitsousproduitvaleur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMicparametrelisteproduitsousproduitvaleur pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicparametrelisteproduitsousproduitvaleur">clsMicparametrelisteproduitsousproduitvaleur</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsMicparametrelisteproduitsousproduitvaleur clsMicparametrelisteproduitsousproduitvaleur , clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicparametrelisteproduitsousproduitvaleur.LP_CODEPARAMETRELISTEVALEUR =  double.Parse(clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1 ;
			clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgInsert(clsDonnee, clsMicparametrelisteproduitsousproduitvaleur);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametrelisteproduitsousproduitvaleur.LP_CODEPARAMETRELISTEVALEUR.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicparametrelisteproduitsousproduitvaleurs"> Liste d'objet clsMicparametrelisteproduitsousproduitvaleur</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsMicparametrelisteproduitsousproduitvaleur> clsMicparametrelisteproduitsousproduitvaleurs , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			//clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsMicparametrelisteproduitsousproduitvaleurs.Count; Idx++)
			{
				clsMicparametrelisteproduitsousproduitvaleurs[Idx].LP_CODEPARAMETRELISTEVALEUR =  double.Parse(clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1 ;
				clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgInsert(clsDonnee, clsMicparametrelisteproduitsousproduitvaleurs[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametrelisteproduitsousproduitvaleurs[Idx].LP_CODEPARAMETRELISTEVALEUR.ToString(), "A"));
			}
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicparametrelisteproduitsousproduitvaleurs"> Liste d'objet clsMicparametrelisteproduitsousproduitvaleur</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListeParametrageModel(clsDonnee clsDonnee, List<clsMicparametrelisteproduitsousproduitvaleur> clsMicparametrelisteproduitsousproduitvaleurs, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgDeleteParametrageModel(clsDonnee, clsMicparametrelisteproduitsousproduitvaleurs[0].AP_CODEPRODUIT, clsMicparametrelisteproduitsousproduitvaleurs[0].PL_CODEPARAMETRELISTE, clsMicparametrelisteproduitsousproduitvaleurs[0].LP_MONTANTMINI.ToString(), clsMicparametrelisteproduitsousproduitvaleurs[0].LP_MONTANTMAXI.ToString());
            for (int Idx = 0; Idx < clsMicparametrelisteproduitsousproduitvaleurs.Count; Idx++)
            {
                //clsMicparametrelisteproduitsousproduitvaleurs[Idx].LP_CODEPARAMETRELISTEVALEUR = double.Parse(clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1;
                clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgInsert(clsDonnee, clsMicparametrelisteproduitsousproduitvaleurs[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametrelisteproduitsousproduitvaleurs[Idx].LP_CODEPARAMETRELISTEVALEUR.ToString(), "A"));
            }
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicparametrelisteproduitsousproduitvaleurs"> Liste d'objet clsMicparametrelisteproduitsousproduitvaleur</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListeParametrageSpecifique(clsDonnee clsDonnee, List<clsMicparametrelisteproduitsousproduitvaleur> clsMicparametrelisteproduitsousproduitvaleurs, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgDeleteParametrageSpecifique(clsDonnee, clsMicparametrelisteproduitsousproduitvaleurs[0].AP_CODEPRODUIT, clsMicparametrelisteproduitsousproduitvaleurs[0].PL_CODEPARAMETRELISTE, clsMicparametrelisteproduitsousproduitvaleurs[0].LP_MONTANTMINI.ToString(), clsMicparametrelisteproduitsousproduitvaleurs[0].LP_MONTANTMAXI.ToString(), clsMicparametrelisteproduitsousproduitvaleurs[0].SX_CODESEXE);
            for (int Idx = 0; Idx < clsMicparametrelisteproduitsousproduitvaleurs.Count; Idx++)
            {
                //clsMicparametrelisteproduitsousproduitvaleurs[Idx].LP_CODEPARAMETRELISTEVALEUR = double.Parse(clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1;
                clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgInsert(clsDonnee, clsMicparametrelisteproduitsousproduitvaleurs[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametrelisteproduitsousproduitvaleurs[Idx].LP_CODEPARAMETRELISTEVALEUR.ToString(), "A"));
            }
            return "";
        }
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsMicparametrelisteproduitsousproduitvaleurs"> Liste d'objet clsMicparametrelisteproduitsousproduitvaleur</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListeParametrageSpecifiqueAdherant(clsDonnee clsDonnee, List<clsMicparametrelisteproduitsousproduitvaleur> clsMicparametrelisteproduitsousproduitvaleurs, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgDeleteParametrageSpecifiqueAdherant(clsDonnee, clsMicparametrelisteproduitsousproduitvaleurs[0].AP_CODEPRODUIT, clsMicparametrelisteproduitsousproduitvaleurs[0].PL_CODEPARAMETRELISTE, clsMicparametrelisteproduitsousproduitvaleurs[0].LP_MONTANTMINI.ToString(), clsMicparametrelisteproduitsousproduitvaleurs[0].LP_MONTANTMAXI.ToString(), clsMicparametrelisteproduitsousproduitvaleurs[0].SX_CODESEXE);
            for (int Idx = 0; Idx < clsMicparametrelisteproduitsousproduitvaleurs.Count; Idx++)
            {
                //clsMicparametrelisteproduitsousproduitvaleurs[Idx].LP_CODEPARAMETRELISTEVALEUR = double.Parse(clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1;
                clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgInsert(clsDonnee, clsMicparametrelisteproduitsousproduitvaleurs[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametrelisteproduitsousproduitvaleurs[Idx].LP_CODEPARAMETRELISTEVALEUR.ToString(), "A"));
            }
            return "";
        }


		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMicparametrelisteproduitsousproduitvaleur">clsMicparametrelisteproduitsousproduitvaleur</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsMicparametrelisteproduitsousproduitvaleur clsMicparametrelisteproduitsousproduitvaleur,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgUpdate(clsDonnee, clsMicparametrelisteproduitsousproduitvaleur, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsMicparametrelisteproduitsousproduitvaleur.LP_CODEPARAMETRELISTEVALEUR.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsMicparametrelisteproduitsousproduitvaleur </returns>
		///<author>Home Technology</author>
		public List<clsMicparametrelisteproduitsousproduitvaleur> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicparametrelisteproduitsousproduitvaleur </returns>
		///<author>Home Technology</author>
		public List<clsMicparametrelisteproduitsousproduitvaleur> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetParametrage(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgChargerDansDataSetParametrage(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboMontantMinMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsMicparametrelisteproduitsousproduitvaleurWSDAL.pvgChargerDansDataSetPourComboMontantMinMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
