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

	public class clsVilleWSBLL : IObjetWSBLL<clsVille>
	{

        private clsVilleWSDAL clsVilleWSDAL  = new clsVilleWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsVilleWSDAL.pvgValueScalarRequeteCount(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsVilleWSDAL.pvgValueScalarRequeteMin(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee , clsObjetEnvoi clsObjetEnvoi)
		{
			return clsVilleWSDAL.pvgValueScalarRequeteMax(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsVille </returns>
		///<author>Home Technologie</author>
		public clsVille pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsVilleWSDAL.pvgTableLabel(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
        ///<returns>clsVille </returns>
        ///<author>Home Technologie</author>
        public clsVille pvgTableLabelVilleReference(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsVilleWSDAL.pvgTableLabelVilleReference(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsVille">clsVille</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsVille clsVille, clsObjetEnvoi clsObjetEnvoi)
		{
			clsVille.VL_CODEVILLE = string.Format( "{0:00000000}" , double.Parse(clsVilleWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsVilleWSDAL.pvgInsert(clsDonnee, clsVille);
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsVille.VL_CODEVILLE.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsVilles">Collection de clsVille </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsVille> clsVilles, clsObjetEnvoi clsObjetEnvoi)
		{
			clsVilleWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsVilles.Count; Idx++)
			{
				clsVilles[Idx].VL_CODEVILLE = string.Format( "{0:00000000}" , double.Parse(clsVilleWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsVilleWSDAL.pvgInsert(clsDonnee ,clsVilles[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsVilles[Idx].VL_CODEVILLE.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsVille">clsVille</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsVille clsVille ,clsObjetEnvoi clsObjetEnvoi)
		{
			clsVilleWSDAL.pvgUpdate(clsDonnee, clsVille,clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsVille.VL_CODEVILLE.ToString(), "M"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
        ///<param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="clsVilles">Collection de clsVille </param>
        ///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgModifierListeVilleReference(clsDonnee clsDonnee, List<clsVille> clsVilles, clsObjetEnvoi clsObjetEnvoi)
        {
            clsVille clsVille = new clsVille();
            clsVilleWSDAL.pvgUpdateVilleReference1(clsDonnee, clsVille);
            for (int Idx = 0; Idx < clsVilles.Count; Idx++)
            {
                clsVilleWSDAL.pvgUpdateVilleReference(clsDonnee, clsVilles[Idx], clsVilles[Idx].VL_CODEVILLE);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsVilles[Idx].VL_CODEVILLE.ToString(), "M"));
            }
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			clsVilleWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,vppValeurMouchard , "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsVille</returns>
		///<author>Home Technologie</author>
		public List<clsVille> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsVilleWSDAL.pvgSelect(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsVille</returns>
		///<author>Home Technologie</author>
		public List<clsVille> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsVilleWSDAL.pvgSelectDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsVilleWSDAL.pvgChargerDansDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPaysVille(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsVilleWSDAL.pvgChargerDansDataSetPaysVille(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		///(Ordre critere:VL_CODEVILLE) elle est destinée generalement aux combobox, treeview ...</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsVilleWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
        ///(Ordre critere:VL_CODEVILLE) elle est destinée generalement aux combobox, treeview ...</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourComboSelonZone(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsVilleWSDAL.pvgChargerDansDataSetPourComboSelonZone(clsDonnee , clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "VILLE  (Ajout)  : "+ vppAction;
					break;
				case "M":
					clsMouchard.MO_ACTION = "VILLE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "VILLE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "VILLE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;
			}
			return clsMouchard;
		}


        
	}
}