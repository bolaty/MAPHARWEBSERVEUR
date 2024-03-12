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

	public class clsExerciceWSBLL : IObjetWSBLL<clsExercice>
	{
        private clsJourneetravailWSDAL clsJourneetravailWSDAL = new clsJourneetravailWSDAL(); 
        private clsExerciceWSDAL clsExerciceWSDAL  = new clsExerciceWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgValueScalarRequeteCount(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgValueScalarRequeteMin(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:EX_EXERCICE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValeurScalaireRequeteMin1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsExerciceWSDAL.pvgValueScalarRequeteMin1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee , clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgValueScalarRequeteMax(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsExercice </returns>
		///<author>Home Technologie</author>
		public clsExercice pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgTableLabel(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsExercice">clsExercice</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsExercice clsExercice, clsObjetEnvoi clsObjetEnvoi)
		{
            //Création de la première journée de travail de l'exercice créé.
            clsJourneetravail clsJourneetravail = new clsJourneetravail();
            clsJourneetravail.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
            clsJourneetravail.JT_DATEJOURNEETRAVAIL = clsExercice.JT_DATEJOURNEETRAVAIL;
            clsJourneetravail.JT_STATUT = "O";
            clsJourneetravail.OP_CODEOPERATEUR = clsObjetEnvoi.OE_Y;
            //
            clsJourneetravailWSDAL.pvgInsert(clsDonnee, clsJourneetravail);
            //========
            if(clsExercice.EX_EXERCICEENCOURS=="O")
            {
                clsExercice clsExercice1 = new clsExercice();
                clsExercice1.EX_EXERCICEENCOURS = "N";
                clsExercice1.AG_CODEAGENCE = clsExercice.AG_CODEAGENCE ;
                clsExerciceWSDAL.pvgUpdateEXERCICEENCOURS(clsDonnee, clsExercice1, clsExercice1.AG_CODEAGENCE);
            }
			
            //=======
            //Création de l'exercice
			clsExerciceWSDAL.pvgInsert(clsDonnee, clsExercice);
            //le mouchard sera executé si ce n'est pas la première execution
            if (!clsObjetEnvoi.OE_Z)
			    clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsExercice.EX_EXERCICE.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsExercices">Collection de clsExercice </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsExercice> clsExercices, clsObjetEnvoi clsObjetEnvoi)
		{
			clsExerciceWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsExercices.Count; Idx++)
			{
                clsExercices[Idx].EX_EXERCICE = (double.Parse(clsExerciceWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
				clsExerciceWSDAL.pvgInsert(clsDonnee ,clsExercices[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsExercices[Idx].EX_EXERCICE.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsExercice">clsExercice</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsExercice clsExercice ,clsObjetEnvoi clsObjetEnvoi)
		{


            //========
            if (clsExercice.EX_EXERCICEENCOURS == "O")
            {
                clsExercice clsExercice1 = new clsExercice();
                clsExercice1.EX_EXERCICEENCOURS = "N";
                clsExercice1.AG_CODEAGENCE = clsExercice.AG_CODEAGENCE;
                clsExerciceWSDAL.pvgUpdateEXERCICEENCOURS(clsDonnee, clsExercice1, clsExercice1.AG_CODEAGENCE);
            }

            //=======

            clsExerciceWSDAL.pvgUpdate(clsDonnee, clsExercice,clsObjetEnvoi.OE_PARAM);
            //le mouchard sera executé si ce n'est pas la première execution
            if (!clsObjetEnvoi.OE_Z)
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsExercice.EX_EXERCICE.ToString(), "M"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			clsExerciceWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            //Suppression des journées de travail créées dans l'exercice
            clsJourneetravailWSDAL.pvgDelete1(clsDonnee, clsObjetEnvoi.OE_PARAM);
            //
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            //le mouchard sera executé si ce n'est pas la première execution
            if (!clsObjetEnvoi.OE_Z)
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,vppValeurMouchard , "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsExercice</returns>
		///<author>Home Technologie</author>
		public List<clsExercice> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgSelect(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsExercice</returns>
		///<author>Home Technologie</author>
		public List<clsExercice> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgSelectDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgChargerDansDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetExerciceEncours(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgChargerDansDataSetExerciceEncours(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		///(Ordre critere:EX_EXERCICE) elle est destinée generalement aux combobox, treeview ...</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsExerciceWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee , clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "EXERCICE  (Ajout)  : "+ vppAction;
					break;
				case "M":
					clsMouchard.MO_ACTION = "EXERCICE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "EXERCICE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "EXERCICE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;
			}
			return clsMouchard;
		}


        
	}
}