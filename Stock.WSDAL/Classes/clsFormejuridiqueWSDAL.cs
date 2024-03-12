using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsFormejuridiqueWSDAL : ITableDAL<clsFormejuridique>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(FM_CODEFORMEJURIDIQUE) AS FM_CODEFORMEJURIDIQUE  FROM FORMEJURIDIQUE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(FM_CODEFORMEJURIDIQUE) AS FM_CODEFORMEJURIDIQUE  FROM FORMEJURIDIQUE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(FM_CODEFORMEJURIDIQUE) AS FM_CODEFORMEJURIDIQUE  FROM FORMEJURIDIQUE "+ this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsFormejuridique">clsFormejuridique</param>
		///<author>Home Technologie</author>
		public clsFormejuridique pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT FM_FORMEJURIDIQUECODE,FM_LIBELLE FROM FORMEJURIDIQUE " + this.vapCritere ;
			this.vapCritere = "";

			clsFormejuridique clsFormejuridique = new clsFormejuridique(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsFormejuridique.FM_FORMEJURIDIQUECODE = clsDonnee.vogDataReader["FM_FORMEJURIDIQUECODE"].ToString();
					clsFormejuridique.FM_LIBELLE = clsDonnee.vogDataReader["FM_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsFormejuridique;
		}

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsFormejuridique">clsFormejuridique</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsFormejuridique clsFormejuridique)
		{
			//Préparation des paramètres

			SqlParameter vppParamFM_CODEFORMEJURIDIQUE = new SqlParameter("@FM_CODEFORMEJURIDIQUE", SqlDbType.VarChar, 2);
			vppParamFM_CODEFORMEJURIDIQUE.Value = clsFormejuridique.FM_CODEFORMEJURIDIQUE;

			SqlParameter vppParamFM_FORMEJURIDIQUECODE = new SqlParameter("@FM_FORMEJURIDIQUECODE", SqlDbType.VarChar, 4);
			vppParamFM_FORMEJURIDIQUECODE.Value = clsFormejuridique.FM_FORMEJURIDIQUECODE;

			SqlParameter vppParamFM_LIBELLE = new SqlParameter("@FM_LIBELLE", SqlDbType.VarChar, 150);
			vppParamFM_LIBELLE.Value = clsFormejuridique.FM_LIBELLE;

			//Préparation de la commande
			this.vapRequete = "INSERT INTO FORMEJURIDIQUE " +
			" (FM_CODEFORMEJURIDIQUE,FM_FORMEJURIDIQUECODE,FM_LIBELLE)" + 
			" VALUES(@FM_CODEFORMEJURIDIQUE,@FM_FORMEJURIDIQUECODE,@FM_LIBELLE)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamFM_CODEFORMEJURIDIQUE);
			vppSqlCmd.Parameters.Add(vppParamFM_FORMEJURIDIQUECODE);
			vppSqlCmd.Parameters.Add(vppParamFM_LIBELLE);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsFormejuridique">clsFormejuridique</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsFormejuridique clsFormejuridique, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamFM_FORMEJURIDIQUECODE = new SqlParameter("@FM_FORMEJURIDIQUECODE", SqlDbType.VarChar, 4);
			vppParamFM_FORMEJURIDIQUECODE.Value = clsFormejuridique.FM_FORMEJURIDIQUECODE;

			SqlParameter vppParamFM_LIBELLE = new SqlParameter("@FM_LIBELLE", SqlDbType.VarChar, 150);
			vppParamFM_LIBELLE.Value = clsFormejuridique.FM_LIBELLE;

			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE FORMEJURIDIQUE SET " + 
			" FM_FORMEJURIDIQUECODE = @FM_FORMEJURIDIQUECODE , " + 
			" FM_LIBELLE = @FM_LIBELLE" + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamFM_FORMEJURIDIQUECODE);
			vppSqlCmd.Parameters.Add(vppParamFM_LIBELLE);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM FORMEJURIDIQUE " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsFormejuridique </returns>
		///<author>Home Technologie</author>
		public List<clsFormejuridique> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsFormejuridique> clsFormejuridiques = new List<clsFormejuridique>();

			pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM FORMEJURIDIQUE " +this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsFormejuridique clsFormejuridique = new clsFormejuridique();
					clsFormejuridique.FM_CODEFORMEJURIDIQUE = clsDonnee.vogDataReader["FM_CODEFORMEJURIDIQUE"].ToString();
					clsFormejuridique.FM_FORMEJURIDIQUECODE = clsDonnee.vogDataReader["FM_FORMEJURIDIQUECODE"].ToString();
					clsFormejuridique.FM_LIBELLE = clsDonnee.vogDataReader["FM_LIBELLE"].ToString();
					clsFormejuridiques.Add(clsFormejuridique);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsFormejuridiques;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsFormejuridique </returns>
		///<author>Home Technologie</author>
		public List<clsFormejuridique> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsFormejuridique> clsFormejuridiques = new List<clsFormejuridique>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM FORMEJURIDIQUE "+ this.vapCritere ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsFormejuridique clsFormejuridique = new clsFormejuridique();
					clsFormejuridique.FM_CODEFORMEJURIDIQUE = Dataset.Tables["TABLE"].Rows[Idx]["FM_CODEFORMEJURIDIQUE"].ToString();
					clsFormejuridique.FM_FORMEJURIDIQUECODE = Dataset.Tables["TABLE"].Rows[Idx]["FM_FORMEJURIDIQUECODE"].ToString();
					clsFormejuridique.FM_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["FM_LIBELLE"].ToString();
					clsFormejuridiques.Add(clsFormejuridique);
				}
				Dataset.Dispose();
			}
			return clsFormejuridiques;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT * FROM FORMEJURIDIQUE " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT FM_CODEFORMEJURIDIQUE,FM_FORMEJURIDIQUECODE,FM_LIBELLE FROM FORMEJURIDIQUE " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : FM_CODEFORMEJURIDIQUE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			{
				
				case 0:
					this.vapCritere ="" ;
					vapNomParametre = new string[]{  };
					vapValeurParametre = new object[]{  };
					break ;				
				case 1:
					this.vapCritere =" WHERE FM_CODEFORMEJURIDIQUE=@FM_CODEFORMEJURIDIQUE "; 
					vapNomParametre = new string[]{ "@FM_CODEFORMEJURIDIQUE" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
			}
		}


        }
}