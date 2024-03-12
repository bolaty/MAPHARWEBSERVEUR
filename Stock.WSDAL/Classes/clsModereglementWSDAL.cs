using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsModereglementWSDAL: ITableDAL<clsModereglement>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(MR_CODEMODEREGLEMENT) AS MR_CODEMODEREGLEMENT  FROM dbo.MODEREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(MR_CODEMODEREGLEMENT) AS MR_CODEMODEREGLEMENT  FROM dbo.MODEREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(MR_CODEMODEREGLEMENT) AS MR_CODEMODEREGLEMENT  FROM dbo.MODEREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsModereglement comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsModereglement pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MR_LIBELLE  , MR_ACTIF  FROM dbo.MODEREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsModereglement clsModereglement = new clsModereglement();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsModereglement.MR_LIBELLE = clsDonnee.vogDataReader["MR_LIBELLE"].ToString();
					clsModereglement.MR_ACTIF = clsDonnee.vogDataReader["MR_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsModereglement;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsModereglement>clsModereglement</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsModereglement clsModereglement)
		{
			//Préparation des paramètres
			SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
			vppParamMR_CODEMODEREGLEMENT.Value  = clsModereglement.MR_CODEMODEREGLEMENT ;
			SqlParameter vppParamMR_LIBELLE = new SqlParameter("@MR_LIBELLE", SqlDbType.VarChar, 150);
			vppParamMR_LIBELLE.Value  = clsModereglement.MR_LIBELLE ;
			if(clsModereglement.MR_LIBELLE== ""  ) vppParamMR_LIBELLE.Value  = DBNull.Value;
			SqlParameter vppParamMR_ACTIF = new SqlParameter("@MR_ACTIF", SqlDbType.VarChar, 1);
			vppParamMR_ACTIF.Value  = clsModereglement.MR_ACTIF ;
			if(clsModereglement.MR_ACTIF== ""  ) vppParamMR_ACTIF.Value  = DBNull.Value;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO MODEREGLEMENT (  MR_CODEMODEREGLEMENT, MR_LIBELLE, MR_ACTIF) " +
					 "VALUES ( @MR_CODEMODEREGLEMENT, @MR_LIBELLE, @MR_ACTIF) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamMR_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamMR_ACTIF);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsModereglement>clsModereglement</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsModereglement clsModereglement,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMR_LIBELLE = new SqlParameter("@MR_LIBELLE", SqlDbType.VarChar, 150);
			vppParamMR_LIBELLE.Value  = clsModereglement.MR_LIBELLE ;
			if(clsModereglement.MR_LIBELLE== ""  ) vppParamMR_LIBELLE.Value  = DBNull.Value;
			SqlParameter vppParamMR_ACTIF = new SqlParameter("@MR_ACTIF", SqlDbType.VarChar, 1);
			vppParamMR_ACTIF.Value  = clsModereglement.MR_ACTIF ;
			if(clsModereglement.MR_ACTIF== ""  ) vppParamMR_ACTIF.Value  = DBNull.Value;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE MODEREGLEMENT SET " +
							"MR_LIBELLE = @MR_LIBELLE, "+
							"MR_ACTIF = @MR_ACTIF " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMR_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamMR_ACTIF);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  MODEREGLEMENT "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsModereglement </returns>
		///<author>Home Technology</author>
		public List<clsModereglement> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  MR_CODEMODEREGLEMENT, MR_LIBELLE, MR_ACTIF FROM dbo.MODEREGLEMENT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsModereglement> clsModereglements = new List<clsModereglement>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsModereglement clsModereglement = new clsModereglement();
					clsModereglement.MR_CODEMODEREGLEMENT = clsDonnee.vogDataReader["MR_CODEMODEREGLEMENT"].ToString();
					clsModereglement.MR_LIBELLE = clsDonnee.vogDataReader["MR_LIBELLE"].ToString();
					clsModereglement.MR_ACTIF = clsDonnee.vogDataReader["MR_ACTIF"].ToString();
					clsModereglements.Add(clsModereglement);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsModereglements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsModereglement </returns>
		///<author>Home Technology</author>
		public List<clsModereglement> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsModereglement> clsModereglements = new List<clsModereglement>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  MR_CODEMODEREGLEMENT, MR_LIBELLE, MR_ACTIF FROM dbo.MODEREGLEMENT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsModereglement clsModereglement = new clsModereglement();
					clsModereglement.MR_CODEMODEREGLEMENT = Dataset.Tables["TABLE"].Rows[Idx]["MR_CODEMODEREGLEMENT"].ToString();
					clsModereglement.MR_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["MR_LIBELLE"].ToString();
					clsModereglement.MR_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["MR_ACTIF"].ToString();
					clsModereglements.Add(clsModereglement);
				}
				Dataset.Dispose();
			}
		return clsModereglements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.MODEREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MR_CODEMODEREGLEMENT , MR_LIBELLE FROM dbo.MODEREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboVenteAppro(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT MR_CODEMODEREGLEMENT , MR_LIBELLE FROM dbo.MODEREGLEMENT " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOD(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(vppCritere);
            this.vapRequete = "SELECT MR_CODEMODEREGLEMENT , MR_LIBELLE FROM dbo.MODEREGLEMENT " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MR_CODEMODEREGLEMENT)</summary>
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
                this.vapCritere = "WHERE MR_ACTIF=@MR_ACTIF";
                vapNomParametre = new string[] { "@MR_ACTIF" };
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MR_CODEMODEREGLEMENT)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = "WHERE MR_ACTIF=@MR_ACTIF OR MR_CODEMODEREGLEMENT='03'";
                    vapNomParametre = new string[] { "@MR_ACTIF" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MR_CODEMODEREGLEMENT)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere2(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = "WHERE MR_ACTIF=@MR_ACTIF AND MR_CODEMODEREGLEMENT<>'03'";
                    vapNomParametre = new string[] { "@MR_ACTIF" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
            }
        }



	}
}
