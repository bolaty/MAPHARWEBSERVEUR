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

	public class clsJourneetravailWSBLL : IObjetWSBLL<clsJourneetravail>
	{

        private clsJourneetravailWSDAL clsJourneetravailWSDAL  = new clsJourneetravailWSDAL();
        private clsOperateurWSDAL clsOperateurWSDAL = new clsOperateurWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgValueScalarRequeteCount(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgValueScalarRequeteCount1(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requète scalaire de type count,avec des critères(Ordre critere:OP_CODEOPERATEUR,CP_NOMFEUILLE,CP_NOMCOMMANDE)</summary>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValeurScalaireRequeteCount2(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {

            //clsOperateur clsOperateur=new clsOperateur();

            //   clsOperateurWSDAL clsOperateurWSDAL = new clsOperateurWSDAL();
            //   clsOperateur = (clsOperateur)clsOperateurWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_Y);
            
            //Code agence////Date journée de travail//Statut de la journée de travail
            string vlpResultat=clsJourneetravailWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_A, clsObjetEnvoi.OE_J.ToShortDateString(), "O");
            //Recupération du statut de OP_JOURNEEOUVERTE de l'opérateur
            clsOperateur clsOperateur=new clsOperateur(clsOperateurWSDAL.pvgTableLabel1(clsDonnee, clsObjetEnvoi.OE_A, clsObjetEnvoi.OE_Y));
            
            //Si la journée est encore ouverte
            if (vlpResultat != "0")
            {
                //On doit verifier si la journée est fermée pour un caissier,si c'est un caissier qui éffectue cette opération.

                //Si la journée est encore ouverte et que la journée est fermée pour un opérateur caissier en cours,
                //alors on considère que la journée est globalement fermée pour ce opérateur(vlpResultat = "0"),même si la journée est ouverte.
                if (clsOperateur.OP_JOURNEEOUVERTE == "N" && clsOperateur.OP_CAISSIER == "O") vlpResultat = "0";


                //Si la journée de travail est ouverte et que l'opérateur en cours est l'opérateur du bilan,alors il faut considerer qque la journée est
                //fermée,car l'opérateur du bilan ne peut travailler dans une journée fermée.
                if (clsOperateur.OP_LOGIN.Contains("BILAN") && !clsObjetEnvoi.OE_J.ToShortDateString().Contains("31/12/"))
                    return "0";

            }

            if (vlpResultat == "1" && clsObjetEnvoi.OE_J.ToShortDateString().Contains("31/12/"))
                if (clsOperateur.OP_LOGIN.Contains("BILAN"))
                {
                    return "0";
                }

            //Si la journée en cours est fermée et est un 31/12/  et que l'opérateur en cours est l'opérateur du bilan,
            //et que le bilan a démmaré et que nous ne somme pas sur l'écran de démmarrage,
            //alors la journée peut être considéré comme ouverte même si elle est fermée.
            if (vlpResultat == "0" && clsObjetEnvoi.OE_J.ToShortDateString().Contains("31/12/"))
                if (clsOperateur.OP_LOGIN.Contains("BILAN"))
                {
                    //Si le bilan n'a pas encore été démmarré et que nous somme sur l'écran de démmarrage du bilan
                    //alors la journée peut être considéré comme ouverte même si elle est fermée.
                        vlpResultat = "1";
                }





            return vlpResultat;
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgValueScalarRequeteMin(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee , clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgValueScalarRequeteMax(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgValueScalarRequeteMax1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsJourneetravailWSDAL.pvgValueScalarRequeteMax1(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsJourneetravail </returns>
		///<author>Home Technologie</author>
		public clsJourneetravail pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgTableLabel(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsJourneetravail">clsJourneetravail</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsJourneetravail clsJourneetravail, clsObjetEnvoi clsObjetEnvoi)
		{
			clsJourneetravailWSDAL.pvgInsert(clsDonnee, clsJourneetravail);
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsJourneetravail.JT_DATEJOURNEETRAVAIL.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsJourneetravails">Collection de clsJourneetravail </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsJourneetravail> clsJourneetravails, clsObjetEnvoi clsObjetEnvoi)
		{
			clsJourneetravailWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsJourneetravails.Count; Idx++)
			{
				clsJourneetravailWSDAL.pvgInsert(clsDonnee ,clsJourneetravails[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsJourneetravails[Idx].JT_DATEJOURNEETRAVAIL.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsJourneetravail">clsJourneetravail</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsJourneetravail clsJourneetravail ,clsObjetEnvoi clsObjetEnvoi)
		{
			clsJourneetravailWSDAL.pvgUpdate(clsDonnee, clsJourneetravail,clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsJourneetravail.JT_DATEJOURNEETRAVAIL.ToString(), "M"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			clsJourneetravailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,vppValeurMouchard , "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsJourneetravail</returns>
		///<author>Home Technologie</author>
		public List<clsJourneetravail> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgSelect(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsJourneetravail</returns>
		///<author>Home Technologie</author>
		public List<clsJourneetravail> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgSelectDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgChargerDansDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

       ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetJourneeEncours(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgChargerDansDataSetJourneeEncours(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		///(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT) elle est destinée generalement aux combobox, treeview ...</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsJourneetravailWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee , clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "JOURNEETRAVAIL  (Ajout)  : "+ vppAction;
					break;
				case "M":
					clsMouchard.MO_ACTION = "JOURNEETRAVAIL  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "JOURNEETRAVAIL  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "JOURNEETRAVAIL  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;
			}
			return clsMouchard;
		}


        
	}
}