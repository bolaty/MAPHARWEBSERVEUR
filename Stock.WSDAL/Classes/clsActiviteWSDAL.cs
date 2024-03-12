using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsActiviteWSDAL : ITableDAL<clsActivite>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(AC_CODEACTIVITE) AS AC_CODEACTIVITE  FROM ACTIVITE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(AC_CODEACTIVITE) AS AC_CODEACTIVITE  FROM ACTIVITE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(AC_CODEACTIVITE) AS AC_CODEACTIVITE  FROM ACTIVITE "+ this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsActivite">clsActivite</param>
		///<author>Home Technologie</author>
		public clsActivite pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AC_LIBELLE FROM ACTIVITE " + this.vapCritere ;
			this.vapCritere = "";
			clsActivite clsActivite = new clsActivite(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsActivite.AC_LIBELLE = clsDonnee.vogDataReader["AC_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsActivite;
		}

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsActivite">clsActivite</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsActivite clsActivite)
		{
			//Préparation des paramètres

			SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
			vppParamAC_CODEACTIVITE.Value = clsActivite.AC_CODEACTIVITE;

			SqlParameter vppParamAC_LIBELLE = new SqlParameter("@AC_LIBELLE", SqlDbType.VarChar, 150);
			vppParamAC_LIBELLE.Value = clsActivite.AC_LIBELLE;
            SqlParameter vppParamAC_NUMEROORDRE = new SqlParameter("@AC_NUMEROORDRE", SqlDbType.VarChar, 2);
            vppParamAC_NUMEROORDRE.Value = clsActivite.AC_NUMEROORDRE;
			//Préparation de la commande
			this.vapRequete = "INSERT INTO ACTIVITE " +
            " (AC_CODEACTIVITE,AC_LIBELLE,AC_NUMEROORDRE)" +
            " VALUES(@AC_CODEACTIVITE,@AC_LIBELLE,@AC_NUMEROORDRE)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
			vppSqlCmd.Parameters.Add(vppParamAC_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamAC_NUMEROORDRE);
			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsActivite">clsActivite</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsActivite clsActivite, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamAC_LIBELLE = new SqlParameter("@AC_LIBELLE", SqlDbType.VarChar, 150);
			vppParamAC_LIBELLE.Value = clsActivite.AC_LIBELLE;
            SqlParameter vppParamAC_NUMEROORDRE = new SqlParameter("@AC_NUMEROORDRE", SqlDbType.VarChar, 2);
            vppParamAC_NUMEROORDRE.Value = clsActivite.AC_NUMEROORDRE;
			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE ACTIVITE SET " +
            " AC_LIBELLE = @AC_LIBELLE,AC_NUMEROORDRE=@AC_NUMEROORDRE" + this.vapCritere;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAC_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamAC_NUMEROORDRE);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM ACTIVITE " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsActivite </returns>
		///<author>Home Technologie</author>
		public List<clsActivite> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsActivite> clsActivites = new List<clsActivite>();

			pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM ACTIVITE " +this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsActivite clsActivite = new clsActivite();
					clsActivite.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
					clsActivite.AC_LIBELLE = clsDonnee.vogDataReader["AC_LIBELLE"].ToString();
					clsActivites.Add(clsActivite);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsActivites;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsActivite </returns>
		///<author>Home Technologie</author>
		public List<clsActivite> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsActivite> clsActivites = new List<clsActivite>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM ACTIVITE "+ this.vapCritere ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsActivite clsActivite = new clsActivite();
					clsActivite.AC_CODEACTIVITE = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEACTIVITE"].ToString();
					clsActivite.AC_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["AC_LIBELLE"].ToString();
					clsActivites.Add(clsActivite);
				}
				Dataset.Dispose();
			}
			return clsActivites;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM ACTIVITE " + this.vapCritere + " ORDER BY AC_LIBELLE";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT AC_CODEACTIVITE,AC_LIBELLE FROM ACTIVITE " + this.vapCritere + " ORDER BY AC_NUMEROORDRE";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
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
					this.vapCritere =" WHERE AC_CODEACTIVITE=@AC_CODEACTIVITE "; 
					vapNomParametre = new string[]{ "@AC_CODEACTIVITE" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
			}
		}


        }
}