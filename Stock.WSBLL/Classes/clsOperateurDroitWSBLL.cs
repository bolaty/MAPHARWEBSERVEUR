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

	public class clsOperateurdroitWSBLL : IObjetWSBLL<clsOperateurdroit>
	{

        private clsOperateurdroitWSDAL clsOperateurdroitWSDAL  = new clsOperateurdroitWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec des critères(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitWSDAL.pvgValueScalarRequeteCount(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec des critères(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitWSDAL.pvgValueScalarRequeteMin(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec des critères(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax( clsDonnee clsDonnee , clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitWSDAL.pvgValueScalarRequeteMax(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsOperateurdroit </returns>
		///<author>Home Technologie</author>
		public clsOperateurdroit pvgTableLibelle( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitWSDAL.pvgTableLabel(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsOperateurdroit">clsOperateurdroit</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsOperateurdroit clsOperateurdroit ,clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurdroit.OB_CODEOBJET =  int.Parse(clsOperateurdroitWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1 ;
			clsOperateurdroitWSDAL.pvgInsert(clsDonnee, clsOperateurdroit);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroit.OB_CODEOBJET.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsOperateurdroits">Collection de clsOperateurdroit </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsOperateurdroit> clsOperateurdroits, clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurdroitWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsOperateurdroits.Count; Idx++)
			{
                //clsOperateurdroits[Idx].OB_CODEOBJET =  int.Parse(clsOperateurdroitWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1 ;
				clsOperateurdroitWSDAL.pvgInsert(clsDonnee ,clsOperateurdroits[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsOperateurdroits[Idx].OB_CODEOBJET.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsOperateurdroit">clsOperateurdroit</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<author>Home Technologie</author>
        public string pvgModifier(clsDonnee clsDonnee, clsOperateurdroit clsOperateurdroit, clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurdroitWSDAL.pvgUpdate(clsDonnee, clsOperateurdroit,clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsOperateurdroit.OB_CODEOBJET.ToString(), "M"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurdroitWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,vppValeurMouchard , "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsOperateurdroit</returns>
		///<author>Home Technologie</author>
		public List<clsOperateurdroit> pvgCharger( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitWSDAL.pvgSelect(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsOperateurdroit</returns>
		///<author>Home Technologie</author>
		public List<clsOperateurdroit> pvgChargerAPartirDataSet( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurdroitWSDAL.pvgSelectDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        public List<string> pvgDroitOperateur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOperateurdroitWSDAL.pvgDroitOperateur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PO_CODEPROFIL,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsOperateurdroitWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		/// (Ordre critere:PO_CODEPROFIL,OB_CODEOBJET) elle est destinée generalement aux combobox, treeview ...///</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsOperateurdroitWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public DataSet pvgInsertIntoDatasetGrille(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOperateurdroitWSDAL.pvgInsertIntoDatasetGrille(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        

        /// <summary>
        /// Cette fonction permet de recuperer les droits d'un utilisateur sur un objet
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="clsObjetEnvoi"></param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetDroitSurObjet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOperateurdroitWSDAL.pvgInsertIntoDatasetDroitSurObjet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        /// <summary> Cette fonction permet de generer le mouchard </summary>
		/// <param name="vppAction">Action réalisé</param>
		/// <param name="vppTypeAction">Type d'action</param>
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
					clsMouchard.MO_ACTION = "OPERATEURDROIT  (Ajout)  : "+ vppAction;
					break;
				case "M":
					clsMouchard.MO_ACTION = "OPERATEURDROIT  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "OPERATEURDROIT  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "OPERATEURDROIT  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;
			}
			return clsMouchard;
		}


        public string pvgAjouterdroit(clsDonnee clsDonnee, List<clsOperateurdroit> clsOperateurdroitAjout,  clsObjetEnvoi clsObjetEnvoi)
        {
            //// Sppression des données existantes avant insertion dans la base de données 
            //// clsOperateurdroitWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
            //for (int Idx = 0; Idx < clsOperateurdroitSuppression.Count; Idx++)
            //{

            //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroitAjout[0].OP_CODEOPERATEUR.ToString(), "A"));
            //}


          

            for (int Idx = 0; Idx < clsOperateurdroitAjout.Count; Idx++)
            {
                clsOperateurdroitWSDAL.pvgDelete(clsDonnee, clsOperateurdroitAjout[Idx].AG_CODEAGENCE, clsOperateurdroitAjout[Idx].OP_CODEOPERATEUR, clsOperateurdroitAjout[Idx].OB_CODEOBJET.ToString());
                //clsOperateurdroitWSDAL.pvgDelete(clsDonnee, clsOperateurdroitAjout[0].AG_CODEAGENCE, clsOperateurdroitAjout[0].OP_CODEOPERATEUR, clsOperateurdroitAjout[Idx].OB_CODEOBJET.ToString());
                clsOperateurdroitWSDAL.pvgInsert(clsDonnee, clsOperateurdroitAjout[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateurdroitAjout[Idx].OP_CODEOPERATEUR.ToString(), "A"));
            }

            return "";
        }



        
	}
}