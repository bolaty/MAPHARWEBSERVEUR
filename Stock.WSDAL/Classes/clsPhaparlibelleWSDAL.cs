using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparlibelleWSDAL: ITableDAL<clsPhaparlibelle>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PL_CODEPARAMETRE) AS PL_CODEPARAMETRE  FROM dbo.PHAPARLIBELLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PL_CODEPARAMETRE) AS PL_CODEPARAMETRE  FROM dbo.PHAPARLIBELLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PL_CODEPARAMETRE) AS PL_CODEPARAMETRE  FROM dbo.PHAPARLIBELLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparlibelle comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparlibelle pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PL_LIBELLE  , PL_ECRAN  , PL_TABLE  , PL_CHAMPS  FROM dbo.PHAPARLIBELLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparlibelle clsPhaparlibelle = new clsPhaparlibelle();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparlibelle.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
					clsPhaparlibelle.PL_ECRAN = clsDonnee.vogDataReader["PL_ECRAN"].ToString();
					clsPhaparlibelle.PL_TABLE = clsDonnee.vogDataReader["PL_TABLE"].ToString();
					clsPhaparlibelle.PL_CHAMPS = clsDonnee.vogDataReader["PL_CHAMPS"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparlibelle;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparlibelle>clsPhaparlibelle</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparlibelle clsPhaparlibelle)
		{
			//Préparation des paramètres
			SqlParameter vppParamPL_CODEPARAMETRE = new SqlParameter("@PL_CODEPARAMETRE", SqlDbType.VarChar, 3);
			vppParamPL_CODEPARAMETRE.Value  = clsPhaparlibelle.PL_CODEPARAMETRE ;

			SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPL_LIBELLE.Value  = clsPhaparlibelle.PL_LIBELLE ;

			SqlParameter vppParamPL_ECRAN = new SqlParameter("@PL_ECRAN", SqlDbType.VarChar, 150);
			vppParamPL_ECRAN.Value  = clsPhaparlibelle.PL_ECRAN ;

			SqlParameter vppParamPL_TABLE = new SqlParameter("@PL_TABLE", SqlDbType.VarChar, 150);
			vppParamPL_TABLE.Value  = clsPhaparlibelle.PL_TABLE ;

			SqlParameter vppParamPL_CHAMPS = new SqlParameter("@PL_CHAMPS", SqlDbType.VarChar, 150);
			vppParamPL_CHAMPS.Value  = clsPhaparlibelle.PL_CHAMPS ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARLIBELLE (  PL_CODEPARAMETRE, PL_LIBELLE, PL_ECRAN, PL_TABLE, PL_CHAMPS) " +
					 "VALUES ( @PL_CODEPARAMETRE, @PL_LIBELLE, @PL_ECRAN, @PL_TABLE, @PL_CHAMPS) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPL_CODEPARAMETRE);
			vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPL_ECRAN);
			vppSqlCmd.Parameters.Add(vppParamPL_TABLE);
			vppSqlCmd.Parameters.Add(vppParamPL_CHAMPS);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparlibelle>clsPhaparlibelle</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparlibelle clsPhaparlibelle,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPL_LIBELLE.Value  = clsPhaparlibelle.PL_LIBELLE ;

			SqlParameter vppParamPL_ECRAN = new SqlParameter("@PL_ECRAN", SqlDbType.VarChar, 150);
			vppParamPL_ECRAN.Value  = clsPhaparlibelle.PL_ECRAN ;

			SqlParameter vppParamPL_TABLE = new SqlParameter("@PL_TABLE", SqlDbType.VarChar, 150);
			vppParamPL_TABLE.Value  = clsPhaparlibelle.PL_TABLE ;

			SqlParameter vppParamPL_CHAMPS = new SqlParameter("@PL_CHAMPS", SqlDbType.VarChar, 150);
			vppParamPL_CHAMPS.Value  = clsPhaparlibelle.PL_CHAMPS ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARLIBELLE SET " +
							"PL_LIBELLE = @PL_LIBELLE, "+
							"PL_ECRAN = @PL_ECRAN, "+
							"PL_TABLE = @PL_TABLE, "+
							"PL_CHAMPS = @PL_CHAMPS " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPL_ECRAN);
			vppSqlCmd.Parameters.Add(vppParamPL_TABLE);
			vppSqlCmd.Parameters.Add(vppParamPL_CHAMPS);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARLIBELLE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparlibelle </returns>
		///<author>Home Technology</author>
		public List<clsPhaparlibelle> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PL_CODEPARAMETRE, PL_LIBELLE, PL_ECRAN, PL_TABLE, PL_CHAMPS FROM dbo.PHAPARLIBELLE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparlibelle> clsPhaparlibelles = new List<clsPhaparlibelle>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparlibelle clsPhaparlibelle = new clsPhaparlibelle();
					clsPhaparlibelle.PL_CODEPARAMETRE = clsDonnee.vogDataReader["PL_CODEPARAMETRE"].ToString();
					clsPhaparlibelle.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
					clsPhaparlibelle.PL_ECRAN = clsDonnee.vogDataReader["PL_ECRAN"].ToString();
					clsPhaparlibelle.PL_TABLE = clsDonnee.vogDataReader["PL_TABLE"].ToString();
					clsPhaparlibelle.PL_CHAMPS = clsDonnee.vogDataReader["PL_CHAMPS"].ToString();
					clsPhaparlibelles.Add(clsPhaparlibelle);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparlibelles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparlibelle </returns>
		///<author>Home Technology</author>
		public List<clsPhaparlibelle> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparlibelle> clsPhaparlibelles = new List<clsPhaparlibelle>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PL_CODEPARAMETRE, PL_LIBELLE, PL_ECRAN, PL_TABLE, PL_CHAMPS FROM dbo.PHAPARLIBELLE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparlibelle clsPhaparlibelle = new clsPhaparlibelle();
					clsPhaparlibelle.PL_CODEPARAMETRE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODEPARAMETRE"].ToString();
					clsPhaparlibelle.PL_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PL_LIBELLE"].ToString();
					clsPhaparlibelle.PL_ECRAN = Dataset.Tables["TABLE"].Rows[Idx]["PL_ECRAN"].ToString();
					clsPhaparlibelle.PL_TABLE = Dataset.Tables["TABLE"].Rows[Idx]["PL_TABLE"].ToString();
					clsPhaparlibelle.PL_CHAMPS = Dataset.Tables["TABLE"].Rows[Idx]["PL_CHAMPS"].ToString();
					clsPhaparlibelles.Add(clsPhaparlibelle);
				}
				Dataset.Dispose();
			}
		return clsPhaparlibelles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARLIBELLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PL_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PL_CODEPARAMETRE , PL_LIBELLE FROM dbo.PHAPARLIBELLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PL_CODEPARAMETRE)</summary>
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
				this.vapCritere ="WHERE PL_CODEPARAMETRE=@PL_CODEPARAMETRE";
				vapNomParametre = new string[]{"@PL_CODEPARAMETRE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
