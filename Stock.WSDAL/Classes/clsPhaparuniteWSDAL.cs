using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparuniteWSDAL: ITableDAL<clsPhaparunite> 
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(UN_CODEUNITE) AS UN_CODEUNITE  FROM dbo.PHAPARUNITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(UN_CODEUNITE) AS UN_CODEUNITE  FROM dbo.PHAPARUNITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(UN_CODEUNITE) AS UN_CODEUNITE  FROM dbo.PHAPARUNITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparunite comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparunite pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT UN_LIBELLE  FROM dbo.PHAPARUNITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparunite clsPhaparunite = new clsPhaparunite();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparunite.UN_LIBELLE = clsDonnee.vogDataReader["UN_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparunite;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparunite>clsPhaparunite</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparunite clsPhaparunite)
		{
			//Préparation des paramètres
			SqlParameter vppParamUN_CODEUNITE = new SqlParameter("@UN_CODEUNITE", SqlDbType.VarChar, 3);
			vppParamUN_CODEUNITE.Value  = clsPhaparunite.UN_CODEUNITE ;

			SqlParameter vppParamUN_LIBELLE = new SqlParameter("@UN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamUN_LIBELLE.Value  = clsPhaparunite.UN_LIBELLE ;

            SqlParameter vppParamUN_FLAG = new SqlParameter("@UN_FLAG", SqlDbType.VarChar, 50);
            vppParamUN_FLAG.Value = clsPhaparunite.UN_FLAG;
			//Préparation de la commande
            this.vapRequete = "INSERT INTO PHAPARUNITE (  UN_CODEUNITE, UN_LIBELLE, UN_FLAG) " +
                     "VALUES ( @UN_CODEUNITE, @UN_LIBELLE, @UN_FLAG) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamUN_CODEUNITE);
			vppSqlCmd.Parameters.Add(vppParamUN_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamUN_FLAG);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparunite>clsPhaparunite</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparunite clsPhaparunite,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamUN_LIBELLE = new SqlParameter("@UN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamUN_LIBELLE.Value  = clsPhaparunite.UN_LIBELLE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARUNITE SET " +
							"UN_LIBELLE = @UN_LIBELLE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamUN_LIBELLE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARUNITE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparunite </returns>
		///<author>Home Technology</author>
		public List<clsPhaparunite> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  UN_CODEUNITE, UN_LIBELLE FROM dbo.PHAPARUNITE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparunite> clsPhaparunites = new List<clsPhaparunite>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparunite clsPhaparunite = new clsPhaparunite();
					clsPhaparunite.UN_CODEUNITE = clsDonnee.vogDataReader["UN_CODEUNITE"].ToString();
					clsPhaparunite.UN_LIBELLE = clsDonnee.vogDataReader["UN_LIBELLE"].ToString();
					clsPhaparunites.Add(clsPhaparunite);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparunites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparunite </returns>
		///<author>Home Technology</author>
		public List<clsPhaparunite> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparunite> clsPhaparunites = new List<clsPhaparunite>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  UN_CODEUNITE, UN_LIBELLE FROM dbo.PHAPARUNITE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparunite clsPhaparunite = new clsPhaparunite();
					clsPhaparunite.UN_CODEUNITE = Dataset.Tables["TABLE"].Rows[Idx]["UN_CODEUNITE"].ToString();
					clsPhaparunite.UN_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["UN_LIBELLE"].ToString();
					clsPhaparunites.Add(clsPhaparunite);
				}
				Dataset.Dispose();
			}
		return clsPhaparunites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARUNITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : UN_CODEUNITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
			this.vapRequete = "SELECT UN_CODEUNITE , UN_LIBELLE FROM dbo.PHAPARUNITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :UN_CODEUNITE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
				this.vapCritere ="WHERE UN_CODEUNITE=@UN_CODEUNITE";
				vapNomParametre = new string[]{"@UN_CODEUNITE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;

			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :UN_CODEUNITE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1( params string[] vppCritere)
        {
	        switch (vppCritere.Length) 
		        {
		        case 0 :
		        this.vapCritere ="";
		        vapNomParametre = new string[]{};
		        vapValeurParametre = new object[]{};
		        break;
		        case 1 :
		        this.vapCritere ="WHERE UN_FLAG=@UN_FLAG";
		        vapNomParametre = new string[]{"@UN_FLAG"};
		        vapValeurParametre = new object[]{vppCritere[0]};
                break;

		        case 2 :
		        this.vapCritere ="WHERE UN_CODEUNITE=@UN_CODEUNITE AND UN_CODEUNITE=@UN_CODEUNITE";
                vapNomParametre = new string[] { "@UN_FLAG", "@UN_CODEUNITE" };
		        vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
		        break;

	        }
        }

	}
}
