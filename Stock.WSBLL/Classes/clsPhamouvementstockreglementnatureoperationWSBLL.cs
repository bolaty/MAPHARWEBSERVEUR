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
	public class clsPhamouvementstockreglementnatureoperationWSBLL: IObjetWSBLL<clsPhamouvementstockreglementnatureoperation>
	{
		private clsPhamouvementstockreglementnatureoperationWSDAL clsPhamouvementstockreglementnatureoperationWSDAL= new clsPhamouvementstockreglementnatureoperationWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementnatureoperationWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementnatureoperationWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementnatureoperationWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglementnatureoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglementnatureoperation pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementnatureoperationWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPhamouvementstockreglementnatureoperation comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPhamouvementstockreglementnatureoperation pvgTableLabel_RO_CODENATUREOPERATIONTYPE(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsPhamouvementstockreglementnatureoperationWSDAL.pvgTableLabel_RO_CODENATUREOPERATIONTYPE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockreglementnatureoperation">clsPhamouvementstockreglementnatureoperation</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = string.Format( "{0:00000}" , double.Parse(clsPhamouvementstockreglementnatureoperationWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPhamouvementstockreglementnatureoperationWSDAL.pvgInsert(clsDonnee, clsPhamouvementstockreglementnatureoperation);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockreglementnatureoperations"> Liste d'objet clsPhamouvementstockreglementnatureoperation</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhamouvementstockreglementnatureoperationWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhamouvementstockreglementnatureoperations.Count; Idx++)
			{
				clsPhamouvementstockreglementnatureoperations[Idx].NO_CODENATUREOPERATION = string.Format( "{0:00000}" , double.Parse(clsPhamouvementstockreglementnatureoperationWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsPhamouvementstockreglementnatureoperationWSDAL.pvgInsert(clsDonnee, clsPhamouvementstockreglementnatureoperations[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementnatureoperations[Idx].NO_CODENATUREOPERATION.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockreglementnatureoperation">clsPhamouvementstockreglementnatureoperation</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockreglementnatureoperationWSDAL.pvgUpdate(clsDonnee, clsPhamouvementstockreglementnatureoperation, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockreglementnatureoperationWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementstockreglementnatureoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementnatureoperation> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementnatureoperationWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementnatureoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementnatureoperation> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementnatureoperationWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementnatureoperationWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetEcranParametrage(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementnatureoperationWSDAL.pvgChargerDansDataSetEcranParametrage(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementnatureoperationWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboEdition(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsPhamouvementstockreglementnatureoperationWSDAL.pvgChargerDansDataSetPourComboEdition(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
