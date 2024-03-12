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

	public class clsEtatWSBLL //: IObjetWSBLL<clsEtat>
	{

        private clsEtatWSDAL clsEtatWSDAL  = new clsEtatWSDAL(); 
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec des critères(Ordre critere:ET_INDEX)</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount( clsDonnee clsDonnee, params string[] vppCritere)
		{
			return clsEtatWSDAL.pvgValueScalarRequeteCount(clsDonnee , vppCritere);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec des critères(Ordre critere:ET_INDEX)</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin( clsDonnee clsDonnee, params string[] vppCritere)
		{
			return clsEtatWSDAL.pvgValueScalarRequeteMin(clsDonnee , vppCritere);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec des critères(Ordre critere:ET_INDEX)</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax( clsDonnee clsDonnee , params string[] vppCritere)
		{
			return clsEtatWSDAL.pvgValueScalarRequeteMax(clsDonnee , vppCritere);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:ET_INDEX)</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>clsEtat </returns>
		///<author>Home Technologie</author>
		public clsEtat pvgTableLibelle( clsDonnee clsDonnee, params string[] vppCritere)
		{
			return clsEtatWSDAL.pvgTableLabel(clsDonnee , vppCritere);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="clsEtat">clsEtat</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee  clsDonnee , clsEtat clsEtat)
		{
				
				clsEtatWSDAL.pvgInsert(clsDonnee, clsEtat);
                //clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsEtat.ET_INDEX.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsEtats">Collection de clsEtat </param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter( clsDonnee  clsDonnee , List<clsEtat> clsEtats,  params  string[] vppCritere)
		{
			clsEtatWSDAL.pvgDelete(clsDonnee , vppCritere);
			for (int Idx = 0; Idx < clsEtats.Count; Idx++)
			{
				
				clsEtatWSDAL.pvgInsert(clsDonnee ,clsEtats[Idx]);
                //clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsEtats[Idx].ET_INDEX.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:ET_INDEX)</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">BusinessObject</param>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsEtat clsEtat ,params  string[] vppCritere)
		{
				clsEtatWSDAL.pvgUpdate(clsDonnee, clsEtat,vppCritere);
                //clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(clsEtat.ET_INDEX.ToString(), "M"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees(Ordre critere:ET_INDEX)</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, params string[] vppCritere)
		{
				clsEtatWSDAL.pvgDelete(clsDonnee, vppCritere);
				string vppValeurMouchard =  vppCritere.Length>0?vppCritere[0] : "Table entièrement vidée";
                //clsMouchardWSDAL.pvgInsert(clsDonnee , pvpGenererMouchard(vppValeurMouchard , "S"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères(Ordre critere:ET_INDEX)</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">Chaine de la requête SELECT</param>
		///<returns>Collection de clsEtat</returns>
		///<author>Home Technologie</author>
		public List<clsEtat> pvgCharger( clsDonnee clsDonnee, params string[] vppCritere)
		{
			return clsEtatWSDAL.pvgSelect(clsDonnee , vppCritere);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères(Ordre critere:ET_INDEX)</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">Chaine de la requête SELECT</param>
		///<returns>Collection de clsEtat</returns>
		///<author>Home Technologie</author>
		public List<clsEtat> pvgChargerAPartirDataSet( clsDonnee clsDonnee, params string[] vppCritere)
		{
			return clsEtatWSDAL.pvgSelectDataSet(clsDonnee , vppCritere);
		}


       

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEtatWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		/// (Ordre critere:ET_INDEX) elle est destinée generalement aux combobox, treeview ...///</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgInsertIntoDatasetCombo( clsDonnee clsDonnee, params string[] vppCritere)
		{
            return clsEtatWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, vppCritere);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		/// (Ordre critere:ET_INDEX) elle est destinée generalement aux combobox, treeview ...///</summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param> 
		///<param name="vppCritere">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgInsertIntoDatasetCombo( clsDonnee clsDonnee,string vppChamps, string vppChampOrdre, params string[] vppCritere)
		{
            return clsEtatWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, vppChamps, vppChampOrdre, vppCritere);
		}
	}
}