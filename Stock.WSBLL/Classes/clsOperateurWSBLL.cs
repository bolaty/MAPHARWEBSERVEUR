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

	public class clsOperateurWSBLL : IObjetWSBLL<clsOperateur>
	{

        private clsOperateurWSDAL clsOperateurWSDAL = new clsOperateurWSDAL();
        private clsOperateurphotoWSDAL clsOperateurphotoWSDAL = new clsOperateurphotoWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec des critères(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurWSDAL.pvgValueScalarRequeteCount(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec des critères(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurWSDAL.pvgValueScalarRequeteMin(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec des critères(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax( clsDonnee clsDonnee , clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurWSDAL.pvgValueScalarRequeteMax(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsOperateur </returns>
		///<author>Home Technologie</author>
		public clsOperateur pvgTableLibelle( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurWSDAL.pvgTableLabel(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}
        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsOperateur </returns>
		///<author>Home Technologie</author>
		public clsOperateur pvgTableLabel1( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurWSDAL.pvgTableLabel1(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsOperateur">clsOperateur</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsOperateur clsOperateur ,clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateur.OP_CODEOPERATEUR =  (double.Parse(clsOperateurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString() ;
			clsOperateurWSDAL.pvgInsert(clsDonnee, clsOperateur);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateur.OP_CODEOPERATEUR.ToString(), "A"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsMicclient">clsMicclient</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgAjouterOperateurPhoto(clsDonnee clsDonnee, clsOperateur clsOperateur, clsOperateurphoto clsOperateurphoto, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOperateur.OP_CODEOPERATEUR = (double.Parse(clsOperateurWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_A)) + 1).ToString();
            if (clsOperateur.OP_CODEOPERATEUR == "1") clsOperateur.OP_CODEOPERATEUR = clsObjetEnvoi.OE_A + "00001";
            //
            clsOperateurWSDAL.pvgInsert(clsDonnee, clsOperateur);
            //Photo Operateur
            if (clsOperateurphoto.OH_PHOTO != null || clsOperateurphoto.OH_SIGNATURE != null)
            {
                clsOperateurphoto.AG_CODEAGENCE = clsOperateur.AG_CODEAGENCE;
                clsOperateurphoto.OP_CODEOPERATEUR = clsOperateur.OP_CODEOPERATEUR;
                clsOperateurphotoWSDAL.pvgInsert(clsDonnee, clsOperateurphoto);
            }
            //
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateur.OP_CODEOPERATEUR.ToString(), "A"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsOperateurs">Collection de clsOperateur </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsOperateur> clsOperateurs, clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsOperateurs.Count; Idx++)
			{
                clsOperateurs[Idx].OP_CODEOPERATEUR = (double.Parse(clsOperateurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
				clsOperateurWSDAL.pvgInsert(clsDonnee ,clsOperateurs[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsOperateurs[Idx].OP_CODEOPERATEUR.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsOperateur">clsOperateur</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<author>Home Technologie</author>
        public string pvgModifier(clsDonnee clsDonnee, clsOperateur clsOperateur, clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurWSDAL.pvgUpdate(clsDonnee, clsOperateur,clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsOperateur.OP_CODEOPERATEUR.ToString(), "M"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsOperateur">clsOperateur</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<author>Home Technologie</author>
        public string pvgModifierDesactiverOperateur(clsDonnee clsDonnee, clsOperateur clsOperateur, clsObjetEnvoi clsObjetEnvoi)
		{
            clsOperateurWSDAL.pvgUpdateDesactiverOperateur(clsDonnee, clsOperateur, clsObjetEnvoi.OE_PARAM);
            //Mise à jour du mouchard
            clsMouchard clsMouchard = new clsMouchard();
            clsMouchard.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
            clsMouchard.MO_ACTION = "Acceuil(Modification) : Désactivation de l'opérateur : " + clsObjetEnvoi.OE_PARAM[1] + " de l'agence " + clsObjetEnvoi.OE_PARAM[0] + " Raison:Violation du système de sécurité, Application interrompue !!!";
            //Ici nous avons déclaré l'objet d'envoi particulièrement dans la procedure
            //parce que cette procedure n'a pas encore de code opérateur,ce qui peut fausser
            //le resultat de cette requete,
            clsMouchardWSDAL.pvgInsert(clsDonnee, clsMouchard);
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsOperateur">clsOperateur</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<author>Home Technologie</author>
        public string pvgModifierOP_MOTPASSE(clsDonnee clsDonnee, clsOperateur clsOperateur, clsObjetEnvoi clsObjetEnvoi)
		{
            clsOperateurWSDAL.pvgUpdateOP_MOTPASSE(clsDonnee, clsOperateur, clsObjetEnvoi.OE_PARAM);
            //Mise à jour du mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateur.OP_CODEOPERATEUR.ToString(), "M"));
            return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsOperateur">clsOperateur</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<author>Home Technologie</author>
        public string pvgModifierOP_JOURNEEOUVERTE(clsDonnee clsDonnee, clsOperateur clsOperateur, clsObjetEnvoi clsObjetEnvoi)
		{
            clsOperateurWSDAL.pvgUpdateOP_JOURNEEOUVERTE(clsDonnee, clsOperateur, clsObjetEnvoi.OE_PARAM);
            //Mise à jour du mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateur.OP_CODEOPERATEUR.ToString(), "M"));
            return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:CL_IDCLIENT)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsMicclient">clsMicclient</param>
        ///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgModifierOperateurPhoto(clsDonnee clsDonnee, clsOperateur clsOperateur, clsOperateurphoto clsOperateurphoto, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOperateurWSDAL.pvgUpdate(clsDonnee, clsOperateur, clsObjetEnvoi.OE_PARAM);
            //
            clsOperateurphotoWSDAL.pvgDelete(clsDonnee, clsOperateur.AG_CODEAGENCE, clsOperateur.OP_CODEOPERATEUR);
            //
            if (clsOperateurphoto.OH_PHOTO != null || clsOperateurphoto.OH_SIGNATURE != null)
            {
                clsOperateurphoto.AG_CODEAGENCE = clsOperateur.AG_CODEAGENCE;
                clsOperateurphoto.OP_CODEOPERATEUR = clsOperateur.OP_CODEOPERATEUR;
                clsOperateurphotoWSDAL.pvgInsert(clsDonnee, clsOperateurphoto);
            }
            //
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsOperateur.OP_CODEOPERATEUR.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			clsOperateurWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,vppValeurMouchard , "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsOperateur</returns>
		///<author>Home Technologie</author>
		public List<clsOperateur> pvgCharger( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurWSDAL.pvgSelect(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsOperateur</returns>
		///<author>Home Technologie</author>
		public List<clsOperateur> pvgChargerAPartirDataSet( clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsOperateurWSDAL.pvgSelectDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsOperateurWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOperateurWSDAL.pvgChargerDansDataSet1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetLOGIN(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsOperateurWSDAL.pvgChargerDansDataSetLOGIN(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		/// (Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR) elle est destinée generalement aux combobox, treeview ...///</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsOperateurWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		/// (Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR) elle est destinée generalement aux combobox, treeview ...///</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourComboOP_GESTIONNAIRE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsOperateurWSDAL.pvgChargerDansDataSetPourComboOP_GESTIONNAIRE(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
        /// (Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR) elle est destinée generalement aux combobox, treeview ...///</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetOP_GESTIONNAIRE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOperateurWSDAL.pvgChargerDansDataSetOP_GESTIONNAIRE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		/// (Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR) elle est destinée generalement aux combobox, treeview ...///</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourComboOP_CAISSIER(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsOperateurWSDAL.pvgChargerDansDataSetPourComboOP_CAISSIER(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		/// (Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR) elle est destinée generalement aux combobox, treeview ...///</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourComboOP_CAISSIERPassationFond(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsOperateurWSDAL.pvgChargerDansDataSetPourComboOP_CAISSIERPassationFond(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
        /// (Ordre critere:PO_CODEPROFIL,OP_CODEOPERATEUR) elle est destinée generalement aux combobox, treeview ...///</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetOperateurEntrepot(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsOperateurWSDAL.pvgChargerDansDataSetOperateurEntrepot(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "OPERATEUR  (Ajout)  : "+ vppAction;
					break;
				case "M":
					clsMouchard.MO_ACTION = "OPERATEUR  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "OPERATEUR  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "OPERATEUR  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;
			}
			return clsMouchard;
		}


        
	}
}