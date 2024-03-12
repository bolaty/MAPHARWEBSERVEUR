using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsSmsgatewayWSDAL: ITableDAL<clsSmsgateway>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(GW_CODEGATEWAY) AS GW_CODEGATEWAY  FROM dbo.SMSGATEWAY " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(GW_CODEGATEWAY) AS GW_CODEGATEWAY  FROM dbo.SMSGATEWAY " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(GW_CODEGATEWAY) AS GW_CODEGATEWAY  FROM dbo.SMSGATEWAY " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsSmsgateway comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsSmsgateway pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT GW_MARQUE  , GW_MODELE  , GW_PORT  , GW_ADRESSEIP  , GW_PIN  , GW_ACTIF  FROM dbo.SMSGATEWAY " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsSmsgateway clsSmsgateway = new clsSmsgateway();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSmsgateway.GW_MARQUE = clsDonnee.vogDataReader["GW_MARQUE"].ToString();
					clsSmsgateway.GW_MODELE = clsDonnee.vogDataReader["GW_MODELE"].ToString();
					clsSmsgateway.GW_PORT = clsDonnee.vogDataReader["GW_PORT"].ToString();
					clsSmsgateway.GW_ADRESSEIP = clsDonnee.vogDataReader["GW_ADRESSEIP"].ToString();
					clsSmsgateway.GW_PIN = clsDonnee.vogDataReader["GW_PIN"].ToString();
					clsSmsgateway.GW_ACTIF = clsDonnee.vogDataReader["GW_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsSmsgateway;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSmsgateway>clsSmsgateway</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsSmsgateway clsSmsgateway)
		{
			//Préparation des paramètres
			SqlParameter vppParamGW_CODEGATEWAY = new SqlParameter("@GW_CODEGATEWAY", SqlDbType.BigInt);
			vppParamGW_CODEGATEWAY.Value  = clsSmsgateway.GW_CODEGATEWAY ;
			SqlParameter vppParamGW_MARQUE = new SqlParameter("@GW_MARQUE", SqlDbType.VarChar, 150);
			vppParamGW_MARQUE.Value  = clsSmsgateway.GW_MARQUE ;
			SqlParameter vppParamGW_MODELE = new SqlParameter("@GW_MODELE", SqlDbType.VarChar, 150);
			vppParamGW_MODELE.Value  = clsSmsgateway.GW_MODELE ;
			SqlParameter vppParamGW_PORT = new SqlParameter("@GW_PORT", SqlDbType.VarChar, 50);
			vppParamGW_PORT.Value  = clsSmsgateway.GW_PORT ;
			SqlParameter vppParamGW_ADRESSEIP = new SqlParameter("@GW_ADRESSEIP", SqlDbType.VarChar, 50);
			vppParamGW_ADRESSEIP.Value  = clsSmsgateway.GW_ADRESSEIP ;
			SqlParameter vppParamGW_PIN = new SqlParameter("@GW_PIN", SqlDbType.VarChar, 50);
			vppParamGW_PIN.Value  = clsSmsgateway.GW_PIN ;
			SqlParameter vppParamGW_ACTIF = new SqlParameter("@GW_ACTIF", SqlDbType.VarChar, 1);
			vppParamGW_ACTIF.Value  = clsSmsgateway.GW_ACTIF ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO SMSGATEWAY (  GW_CODEGATEWAY, GW_MARQUE, GW_MODELE, GW_PORT, GW_ADRESSEIP, GW_PIN, GW_ACTIF) " +
					 "VALUES ( @GW_CODEGATEWAY, @GW_MARQUE, @GW_MODELE, @GW_PORT, @GW_ADRESSEIP, @GW_PIN, @GW_ACTIF) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamGW_CODEGATEWAY);
			vppSqlCmd.Parameters.Add(vppParamGW_MARQUE);
			vppSqlCmd.Parameters.Add(vppParamGW_MODELE);
			vppSqlCmd.Parameters.Add(vppParamGW_PORT);
			vppSqlCmd.Parameters.Add(vppParamGW_ADRESSEIP);
			vppSqlCmd.Parameters.Add(vppParamGW_PIN);
			vppSqlCmd.Parameters.Add(vppParamGW_ACTIF);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSmsgateway>clsSmsgateway</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsSmsgateway clsSmsgateway,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamGW_MARQUE = new SqlParameter("@GW_MARQUE", SqlDbType.VarChar, 150);
			vppParamGW_MARQUE.Value  = clsSmsgateway.GW_MARQUE ;
			SqlParameter vppParamGW_MODELE = new SqlParameter("@GW_MODELE", SqlDbType.VarChar, 150);
			vppParamGW_MODELE.Value  = clsSmsgateway.GW_MODELE ;
			SqlParameter vppParamGW_PORT = new SqlParameter("@GW_PORT", SqlDbType.VarChar, 50);
			vppParamGW_PORT.Value  = clsSmsgateway.GW_PORT ;
			SqlParameter vppParamGW_ADRESSEIP = new SqlParameter("@GW_ADRESSEIP", SqlDbType.VarChar, 50);
			vppParamGW_ADRESSEIP.Value  = clsSmsgateway.GW_ADRESSEIP ;
			SqlParameter vppParamGW_PIN = new SqlParameter("@GW_PIN", SqlDbType.VarChar, 50);
			vppParamGW_PIN.Value  = clsSmsgateway.GW_PIN ;
			SqlParameter vppParamGW_ACTIF = new SqlParameter("@GW_ACTIF", SqlDbType.VarChar, 1);
			vppParamGW_ACTIF.Value  = clsSmsgateway.GW_ACTIF ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE SMSGATEWAY SET " +
							"GW_MARQUE = @GW_MARQUE, "+
							"GW_MODELE = @GW_MODELE, "+
							"GW_PORT = @GW_PORT, "+
							"GW_ADRESSEIP = @GW_ADRESSEIP, "+
							"GW_PIN = @GW_PIN " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamGW_MARQUE);
			vppSqlCmd.Parameters.Add(vppParamGW_MODELE);
			vppSqlCmd.Parameters.Add(vppParamGW_PORT);
			vppSqlCmd.Parameters.Add(vppParamGW_ADRESSEIP);
			vppSqlCmd.Parameters.Add(vppParamGW_PIN);
			vppSqlCmd.Parameters.Add(vppParamGW_ACTIF);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  SMSGATEWAY "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsgateway </returns>
		///<author>Home Technology</author>
		public List<clsSmsgateway> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  GW_CODEGATEWAY, GW_MARQUE, GW_MODELE, GW_PORT, GW_ADRESSEIP, GW_PIN, GW_ACTIF FROM dbo.SMSGATEWAY " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsSmsgateway> clsSmsgateways = new List<clsSmsgateway>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSmsgateway clsSmsgateway = new clsSmsgateway();
					clsSmsgateway.GW_CODEGATEWAY = double.Parse(clsDonnee.vogDataReader["GW_CODEGATEWAY"].ToString());
					clsSmsgateway.GW_MARQUE = clsDonnee.vogDataReader["GW_MARQUE"].ToString();
					clsSmsgateway.GW_MODELE = clsDonnee.vogDataReader["GW_MODELE"].ToString();
					clsSmsgateway.GW_PORT = clsDonnee.vogDataReader["GW_PORT"].ToString();
					clsSmsgateway.GW_ADRESSEIP = clsDonnee.vogDataReader["GW_ADRESSEIP"].ToString();
					clsSmsgateway.GW_PIN = clsDonnee.vogDataReader["GW_PIN"].ToString();
					clsSmsgateway.GW_ACTIF = clsDonnee.vogDataReader["GW_ACTIF"].ToString();
					clsSmsgateways.Add(clsSmsgateway);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSmsgateways;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsgateway </returns>
		///<author>Home Technology</author>
		public List<clsSmsgateway> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSmsgateway> clsSmsgateways = new List<clsSmsgateway>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  GW_CODEGATEWAY, GW_MARQUE, GW_MODELE, GW_PORT, GW_ADRESSEIP, GW_PIN, GW_ACTIF FROM dbo.SMSGATEWAY " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsSmsgateway clsSmsgateway = new clsSmsgateway();
					clsSmsgateway.GW_CODEGATEWAY = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["GW_CODEGATEWAY"].ToString());
					clsSmsgateway.GW_MARQUE = Dataset.Tables["TABLE"].Rows[Idx]["GW_MARQUE"].ToString();
					clsSmsgateway.GW_MODELE = Dataset.Tables["TABLE"].Rows[Idx]["GW_MODELE"].ToString();
					clsSmsgateway.GW_PORT = Dataset.Tables["TABLE"].Rows[Idx]["GW_PORT"].ToString();
					clsSmsgateway.GW_ADRESSEIP = Dataset.Tables["TABLE"].Rows[Idx]["GW_ADRESSEIP"].ToString();
					clsSmsgateway.GW_PIN = Dataset.Tables["TABLE"].Rows[Idx]["GW_PIN"].ToString();
					clsSmsgateway.GW_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["GW_ACTIF"].ToString();
					clsSmsgateways.Add(clsSmsgateway);
				}
				Dataset.Dispose();
			}
		return clsSmsgateways;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.SMSGATEWAY " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : GW_CODEGATEWAY ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT GW_CODEGATEWAY , GW_MARQUE FROM dbo.SMSGATEWAY " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :GW_CODEGATEWAY)</summary>
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
				this.vapCritere ="WHERE GW_CODEGATEWAY=@GW_CODEGATEWAY";
				vapNomParametre = new string[]{"@GW_CODEGATEWAY"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
