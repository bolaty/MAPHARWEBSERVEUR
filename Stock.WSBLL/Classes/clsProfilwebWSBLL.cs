using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSDAL;


namespace Stock.WSBLL
{

	public class clsProfilwebWSBLL : IObjetWSBLL<clsProfilweb>
	{

        private clsProfilwebWSDAL clsProfilwebWSDAL  = new clsProfilwebWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebWSDAL.pvgValueScalarRequeteCount(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebWSDAL.pvgValueScalarRequeteMin(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee , clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebWSDAL.pvgValueScalarRequeteMax(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsProfilweb </returns>
		///<author>Home Technologie</author>
		public clsProfilweb pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebWSDAL.pvgTableLabel(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsProfilweb">clsProfilweb</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsProfilweb clsProfilweb,clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfilweb.PO_CODEPROFILWEB = string.Format( "{0:00}" , double.Parse(clsProfilwebWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsProfilwebWSDAL.pvgInsert(clsDonnee, clsProfilweb);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilweb.PO_CODEPROFILWEB.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsProfilwebs">Collection de clsProfilweb </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsProfilweb> clsProfilwebs, clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfilwebWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsProfilwebs.Count; Idx++)
			{
				clsProfilwebs[Idx].PO_CODEPROFILWEB = string.Format( "{0:00}" , double.Parse(clsProfilwebWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsProfilwebWSDAL.pvgInsert(clsDonnee ,clsProfilwebs[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilwebs[Idx].PO_CODEPROFILWEB.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsProfilweb">clsProfilweb</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsProfilweb clsProfilweb ,clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfilwebWSDAL.pvgUpdate(clsDonnee, clsProfilweb,clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsProfilweb.PO_CODEPROFILWEB.ToString(), "M"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			clsProfilwebWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi,vppValeurMouchard, "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsProfilweb</returns>
		///<author>Home Technologie</author>
		public List<clsProfilweb> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebWSDAL.pvgSelect(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsProfilweb</returns>
		///<author>Home Technologie</author>
		public List<clsProfilweb> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsProfilwebWSDAL.pvgSelectDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsProfilwebWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		///(Ordre critere:PO_CODEPROFILWEB) elle est destinée generalement aux combobox, treeview ...</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsProfilwebWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de generer le mouchard</summary>
		///<param name="vppAction">Action réalisé</param>
		///<param name="vppTypeAction">Type d'action</param>
		///<returns>clsMouchard</returns>
		///<author>Home Technologie</author>
        public clsMouchard pvpGenererMouchard(clsObjetEnvoi clsObjetEnvoi, string vppAction, string vppTypeAction)
        {
            clsMouchard clsMouchard = new clsMouchard();
            clsMouchard.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
            clsMouchard.OP_CODEOPERATEUR = clsObjetEnvoi.OE_Y;

            switch (vppTypeAction) 
			{
				case "A":
					clsMouchard.MO_ACTION = "Profilweb  (Ajout)  : "+ vppAction;
					break;
				case "M":
					clsMouchard.MO_ACTION = "Profilweb  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "Profilweb  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "Profilweb  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;
			}
			return clsMouchard;
		}


        
	}
}