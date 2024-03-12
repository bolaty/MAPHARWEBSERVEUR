using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypefournisseurWSDAL: ITableDAL<clsPhapartypefournisseur>
	{
		private string vapCritere = "";
		private string vapRequete = ""; 
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(TF_CODETYPEFOURNISSEUR) AS TF_CODETYPEFOURNISSEUR  FROM dbo.PHAPARTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(TF_CODETYPEFOURNISSEUR) AS TF_CODETYPEFOURNISSEUR  FROM dbo.PHAPARTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(TF_CODETYPEFOURNISSEUR) AS TF_CODETYPEFOURNISSEUR  FROM dbo.PHAPARTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypefournisseur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypefournisseur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TF_LIBELLE  , TF_DESCRIPTION  FROM dbo.PHAPARTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypefournisseur clsPhapartypefournisseur = new clsPhapartypefournisseur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypefournisseur.TF_LIBELLE = clsDonnee.vogDataReader["TF_LIBELLE"].ToString();
					clsPhapartypefournisseur.TF_DESCRIPTION = clsDonnee.vogDataReader["TF_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypefournisseur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypefournisseur>clsPhapartypefournisseur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypefournisseur clsPhapartypefournisseur)
		{
			//Préparation des paramètres
			SqlParameter vppParamTF_CODETYPEFOURNISSEUR = new SqlParameter("@TF_CODETYPEFOURNISSEUR", SqlDbType.VarChar, 3);
			vppParamTF_CODETYPEFOURNISSEUR.Value  = clsPhapartypefournisseur.TF_CODETYPEFOURNISSEUR ;

			SqlParameter vppParamTF_LIBELLE = new SqlParameter("@TF_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTF_LIBELLE.Value  = clsPhapartypefournisseur.TF_LIBELLE ;

			SqlParameter vppParamTF_DESCRIPTION = new SqlParameter("@TF_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTF_DESCRIPTION.Value  = clsPhapartypefournisseur.TF_DESCRIPTION ;

            SqlParameter vppParamTF_NUMEROORDRE = new SqlParameter("@TF_NUMEROORDRE", SqlDbType.VarChar, 10);
            vppParamTF_NUMEROORDRE.Value = clsPhapartypefournisseur.TF_NUMEROORDRE;

			//Préparation de la commande
            this.vapRequete = "INSERT INTO PHAPARTYPEFOURNISSEUR (  TF_CODETYPEFOURNISSEUR, TF_LIBELLE, TF_DESCRIPTION, TF_NUMEROORDRE) " +
                     "VALUES ( @TF_CODETYPEFOURNISSEUR, @TF_LIBELLE, @TF_DESCRIPTION, @TF_NUMEROORDRE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTF_CODETYPEFOURNISSEUR);
			vppSqlCmd.Parameters.Add(vppParamTF_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTF_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamTF_NUMEROORDRE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypefournisseur>clsPhapartypefournisseur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypefournisseur clsPhapartypefournisseur,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTF_LIBELLE = new SqlParameter("@TF_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTF_LIBELLE.Value  = clsPhapartypefournisseur.TF_LIBELLE ;

			SqlParameter vppParamTF_DESCRIPTION = new SqlParameter("@TF_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTF_DESCRIPTION.Value  = clsPhapartypefournisseur.TF_DESCRIPTION ;

            SqlParameter vppParamTF_NUMEROORDRE = new SqlParameter("@TF_NUMEROORDRE", SqlDbType.VarChar, 10);
            vppParamTF_NUMEROORDRE.Value = clsPhapartypefournisseur.TF_NUMEROORDRE;
			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARTYPEFOURNISSEUR SET " +
							"TF_LIBELLE = @TF_LIBELLE, "+
							"TF_DESCRIPTION = @TF_DESCRIPTION," + 
                            "TF_NUMEROORDRE = @TF_NUMEROORDRE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTF_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTF_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamTF_NUMEROORDRE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARTYPEFOURNISSEUR "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypefournisseur </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypefournisseur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TF_CODETYPEFOURNISSEUR, TF_LIBELLE, TF_DESCRIPTION FROM dbo.PHAPARTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypefournisseur> clsPhapartypefournisseurs = new List<clsPhapartypefournisseur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypefournisseur clsPhapartypefournisseur = new clsPhapartypefournisseur();
					clsPhapartypefournisseur.TF_CODETYPEFOURNISSEUR = clsDonnee.vogDataReader["TF_CODETYPEFOURNISSEUR"].ToString();
					clsPhapartypefournisseur.TF_LIBELLE = clsDonnee.vogDataReader["TF_LIBELLE"].ToString();
					clsPhapartypefournisseur.TF_DESCRIPTION = clsDonnee.vogDataReader["TF_DESCRIPTION"].ToString();
					clsPhapartypefournisseurs.Add(clsPhapartypefournisseur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypefournisseurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypefournisseur </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypefournisseur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypefournisseur> clsPhapartypefournisseurs = new List<clsPhapartypefournisseur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TF_CODETYPEFOURNISSEUR, TF_LIBELLE, TF_DESCRIPTION FROM dbo.PHAPARTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypefournisseur clsPhapartypefournisseur = new clsPhapartypefournisseur();
					clsPhapartypefournisseur.TF_CODETYPEFOURNISSEUR = Dataset.Tables["TABLE"].Rows[Idx]["TF_CODETYPEFOURNISSEUR"].ToString();
					clsPhapartypefournisseur.TF_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TF_LIBELLE"].ToString();
					clsPhapartypefournisseur.TF_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["TF_DESCRIPTION"].ToString();
					clsPhapartypefournisseurs.Add(clsPhapartypefournisseur);
				}
				Dataset.Dispose();
			}
		return clsPhapartypefournisseurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.PHAPARTYPEFOURNISSEUR " + this.vapCritere + " ORDER BY TF_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT TF_CODETYPEFOURNISSEUR , TF_LIBELLE FROM dbo.PHAPARTYPEFOURNISSEUR " + this.vapCritere + " ORDER BY TF_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TF_CODETYPEFOURNISSEUR)</summary>
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
				this.vapCritere ="WHERE TF_CODETYPEFOURNISSEUR=@TF_CODETYPEFOURNISSEUR";
				vapNomParametre = new string[]{"@TF_CODETYPEFOURNISSEUR"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
