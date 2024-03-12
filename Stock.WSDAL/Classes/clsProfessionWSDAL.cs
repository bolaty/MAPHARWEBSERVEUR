using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsProfessionWSDAL : ITableDAL<clsProfession>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PF_CODEPROFESSION) AS PF_CODEPROFESSION  FROM PROFESSION " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PF_CODEPROFESSION) AS PF_CODEPROFESSION  FROM PROFESSION " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PF_CODEPROFESSION) AS PF_CODEPROFESSION  FROM PROFESSION "+ this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsProfession">clsProfession</param>
		///<author>Home Technologie</author>
		public clsProfession pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PF_LIBELLE FROM PROFESSION " + this.vapCritere ;
			this.vapCritere = "";

			clsProfession clsProfession = new clsProfession(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsProfession.PF_LIBELLE = clsDonnee.vogDataReader["PF_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsProfession;
		}

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfession">clsProfession</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsProfession clsProfession)
		{
			//Préparation des paramètres

			SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
			vppParamPF_CODEPROFESSION.Value = clsProfession.PF_CODEPROFESSION;

			SqlParameter vppParamPF_LIBELLE = new SqlParameter("@PF_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPF_LIBELLE.Value = clsProfession.PF_LIBELLE;

			//Préparation de la commande
			this.vapRequete = "INSERT INTO PROFESSION " +
			" (PF_CODEPROFESSION,PF_LIBELLE)" + 
			" VALUES(@PF_CODEPROFESSION,@PF_LIBELLE)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
			vppSqlCmd.Parameters.Add(vppParamPF_LIBELLE);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfession">clsProfession</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsProfession clsProfession, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamPF_LIBELLE = new SqlParameter("@PF_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPF_LIBELLE.Value = clsProfession.PF_LIBELLE;

			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE PROFESSION SET " + 
			" PF_LIBELLE = @PF_LIBELLE" + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPF_LIBELLE);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM PROFESSION " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsProfession </returns>
		///<author>Home Technologie</author>
		public List<clsProfession> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsProfession> clsProfessions = new List<clsProfession>();

			pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM PROFESSION " +this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsProfession clsProfession = new clsProfession();
					clsProfession.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
					clsProfession.PF_LIBELLE = clsDonnee.vogDataReader["PF_LIBELLE"].ToString();
					clsProfessions.Add(clsProfession);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsProfessions;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsProfession </returns>
		///<author>Home Technologie</author>
		public List<clsProfession> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsProfession> clsProfessions = new List<clsProfession>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM PROFESSION "+ this.vapCritere ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsProfession clsProfession = new clsProfession();
					clsProfession.PF_CODEPROFESSION = Dataset.Tables["TABLE"].Rows[Idx]["PF_CODEPROFESSION"].ToString();
					clsProfession.PF_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PF_LIBELLE"].ToString();
					clsProfessions.Add(clsProfession);
				}
				Dataset.Dispose();
			}
			return clsProfessions;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT * FROM PROFESSION " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : PF_CODEPROFESSION)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PF_CODEPROFESSION,PF_LIBELLE FROM PROFESSION " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : PF_CODEPROFESSION)</summary>
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
					this.vapCritere =" WHERE PF_CODEPROFESSION=@PF_CODEPROFESSION "; 
					vapNomParametre = new string[]{ "@PF_CODEPROFESSION" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
			}
		}


        }
}