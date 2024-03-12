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

	public class clsPlancomptableWSBLL : IObjetWSBLL<clsPlancomptable>
	{

        private clsPlancomptableWSDAL clsPlancomptableWSDAL  = new clsPlancomptableWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPlancomptableWSDAL.pvgValueScalarRequeteCount(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPlancomptableWSDAL.pvgValueScalarRequeteMin(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee , clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPlancomptableWSDAL.pvgValueScalarRequeteMax(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsPlancomptable </returns>
		///<author>Home Technologie</author>
		public clsPlancomptable pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPlancomptableWSDAL.pvgTableLabel(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsPlancomptable </returns>
		///<author>Home Technologie</author>
        public clsPlancomptable pvgTableLabel1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsPlancomptableWSDAL.pvgTableLabel1(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsPlancomptable </returns>
		///<author>Home Technologie</author>
        public clsPlancomptable pvgTableLabelAvecSolde(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsPlancomptableWSDAL.pvgTableLabelAvecSolde(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsPlancomptable">clsPlancomptable</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsPlancomptable clsPlancomptable, clsObjetEnvoi clsObjetEnvoi )
		{
			clsPlancomptable.PL_CODENUMCOMPTE =  (double.Parse(clsPlancomptableWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString() ;
			clsPlancomptableWSDAL.pvgInsert(clsDonnee, clsPlancomptable);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPlancomptable.PL_CODENUMCOMPTE.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsPlancomptables">Collection de clsPlancomptable </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPlancomptable> clsPlancomptables, clsObjetEnvoi clsObjetEnvoi)
		{
			clsPlancomptableWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPlancomptables.Count; Idx++)
			{
                clsPlancomptables[Idx].PL_CODENUMCOMPTE = (double.Parse(clsPlancomptableWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
				clsPlancomptableWSDAL.pvgInsert(clsDonnee ,clsPlancomptables[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPlancomptables[Idx].PL_CODENUMCOMPTE.ToString(), "A"));
			}
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
        ///<param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="clsPlancomptables">Collection de clsPlancomptable </param>
        ///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgGenerationCpteCollectif(clsDonnee clsDonnee,  clsObjetEnvoi clsObjetEnvoi)
        {
            clsPlancomptableWSDAL.pvgGenerationCpteCollectif(clsDonnee, clsObjetEnvoi.OE_PARAM);
	        return "";
        }
        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsPlancomptable">clsPlancomptable</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPlancomptable clsPlancomptable ,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPlancomptableWSDAL.pvgUpdate(clsDonnee, clsPlancomptable,clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPlancomptable.PL_CODENUMCOMPTE.ToString(), "M"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			clsPlancomptableWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsPlancomptable</returns>
		///<author>Home Technologie</author>
		public List<clsPlancomptable> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPlancomptableWSDAL.pvgSelect(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsPlancomptable</returns>
		///<author>Home Technologie</author>
		public List<clsPlancomptable> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPlancomptableWSDAL.pvgSelectDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsPlancomptableWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetCompteAdditionnel(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetCompteAdditionnel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetCompteAdditionnelTiers(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetCompteAdditionnelTiers(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSet1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetTousLesComptes(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetTousLesComptes(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetComptesIndividuels(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetComptesIndividuels(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetComptesCollectifs(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetComptesCollectifs(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetComptesAConfigurer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetComptesAConfigurer(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetCpteCharge(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetCpteCharge(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		///(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE) elle est destinée generalement aux combobox, treeview ...</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsPlancomptableWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
        ///(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE) elle est destinée generalement aux combobox, treeview ...</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourComboComptesCollectif(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetPourComboComptesCollectif(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
        ///(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE) elle est destinée generalement aux combobox, treeview ...</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetOperation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetOperation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
        ///(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE) elle est destinée generalement aux combobox, treeview ...</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetControlCompte(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetControlCompte(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
        ///(Ordre critere:PL_CODENUMCOMPTE,SO_CODESOCIETE) elle est destinée generalement aux combobox, treeview ...</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetControlNatureCompte(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPlancomptableWSDAL.pvgChargerDansDataSetControlNatureCompte(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PLANCOMPTABLE  (Ajout)  : "+ vppAction;
					break;
				case "M":
					clsMouchard.MO_ACTION = "PLANCOMPTABLE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PLANCOMPTABLE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PLANCOMPTABLE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;
			}
			return clsMouchard;
		}


        
	}
}