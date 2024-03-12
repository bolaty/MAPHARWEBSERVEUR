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

	public class clsSituationmatrimonialeWSBLL : IObjetWSBLL<clsSituationmatrimoniale>
	{

        private clsSituationmatrimonialeWSDAL clsSituationmatrimonialeWSDAL  = new clsSituationmatrimonialeWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSituationmatrimonialeWSDAL.pvgValueScalarRequeteCount(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSituationmatrimonialeWSDAL.pvgValueScalarRequeteMin(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee , clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSituationmatrimonialeWSDAL.pvgValueScalarRequeteMax(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsSituationmatrimoniale </returns>
		///<author>Home Technologie</author>
		public clsSituationmatrimoniale pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSituationmatrimonialeWSDAL.pvgTableLabel(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsSituationmatrimoniale">clsSituationmatrimoniale</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsSituationmatrimoniale clsSituationmatrimoniale, clsObjetEnvoi clsObjetEnvoi)
		{
			clsSituationmatrimoniale.SM_CODESITUATIONMATRIMONIALE = string.Format( "{0:00}" , double.Parse(clsSituationmatrimonialeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsSituationmatrimonialeWSDAL.pvgInsert(clsDonnee, clsSituationmatrimoniale);
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsSituationmatrimoniale.SM_CODESITUATIONMATRIMONIALE.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsSituationmatrimoniales">Collection de clsSituationmatrimoniale </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouterListe(clsDonnee  clsDonnee , List<clsSituationmatrimoniale> clsSituationmatrimoniales,  clsObjetEnvoi clsObjetEnvoi)
		{
			clsSituationmatrimonialeWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsSituationmatrimoniales.Count; Idx++)
			{
				clsSituationmatrimoniales[Idx].SM_CODESITUATIONMATRIMONIALE = string.Format( "{0:00}" , double.Parse(clsSituationmatrimonialeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsSituationmatrimonialeWSDAL.pvgInsert(clsDonnee ,clsSituationmatrimoniales[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsSituationmatrimoniales[Idx].SM_CODESITUATIONMATRIMONIALE.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsSituationmatrimoniale">clsSituationmatrimoniale</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsSituationmatrimoniale clsSituationmatrimoniale ,clsObjetEnvoi clsObjetEnvoi)
		{
			clsSituationmatrimonialeWSDAL.pvgUpdate(clsDonnee, clsSituationmatrimoniale,clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,clsSituationmatrimoniale.SM_CODESITUATIONMATRIMONIALE.ToString(), "M"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			clsSituationmatrimonialeWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsObjetEnvoi,vppValeurMouchard , "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsSituationmatrimoniale</returns>
		///<author>Home Technologie</author>
		public List<clsSituationmatrimoniale> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSituationmatrimonialeWSDAL.pvgSelect(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsSituationmatrimoniale</returns>
		///<author>Home Technologie</author>
		public List<clsSituationmatrimoniale> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSituationmatrimonialeWSDAL.pvgSelectDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSituationmatrimonialeWSDAL.pvgChargerDansDataSet(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		///(Ordre critere:SM_CODESITUATIONMATRIMONIALE) elle est destinée generalement aux combobox, treeview ...</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSituationmatrimonialeWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee , clsObjetEnvoi.OE_PARAM);
		}

		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            return clsSituationmatrimonialeWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, vppCritere);
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
					clsMouchard.MO_ACTION = "SITUATIONMATRIMONIALE  (Ajout)  : "+ vppAction;
					break;
				case "M":
					clsMouchard.MO_ACTION = "SITUATIONMATRIMONIALE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "SITUATIONMATRIMONIALE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "SITUATIONMATRIMONIALE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;
			}
			return clsMouchard;
		}


        
	}
}