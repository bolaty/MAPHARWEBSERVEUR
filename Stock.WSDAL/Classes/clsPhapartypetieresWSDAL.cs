using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypetiersWSDAL: ITableDAL<clsPhapartypetiers>
	{
		private string vapCritere = "";
		private string vapRequete = ""; 
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(TP_CODETYPETIERS) AS TP_CODETYPETIERS  FROM dbo.PHAPARTYPETIERS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(TP_CODETYPETIERS) AS TP_CODETYPETIERS  FROM dbo.PHAPARTYPETIERS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(TP_CODETYPETIERS) AS TP_CODETYPETIERS  FROM dbo.PHAPARTYPETIERS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypetiers comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypetiers pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TP_LIBELLE  , TP_DESCRIPTION  FROM dbo.PHAPARTYPETIERS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypetiers clsPhapartypetiers = new clsPhapartypetiers();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypetiers.TP_LIBELLE = clsDonnee.vogDataReader["TP_LIBELLE"].ToString();
					clsPhapartypetiers.TP_DESCRIPTION = clsDonnee.vogDataReader["TP_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypetiers;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypetiers>clsPhapartypetiers</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypetiers clsPhapartypetiers)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
			vppParamTP_CODETYPETIERS.Value  = clsPhapartypetiers.TP_CODETYPETIERS ;

			SqlParameter vppParamTP_LIBELLE = new SqlParameter("@TP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTP_LIBELLE.Value  = clsPhapartypetiers.TP_LIBELLE ;

			SqlParameter vppParamTP_DESCRIPTION = new SqlParameter("@TP_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTP_DESCRIPTION.Value  = clsPhapartypetiers.TP_DESCRIPTION ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARTYPETIERS (  TP_CODETYPETIERS, TP_LIBELLE, TP_DESCRIPTION) " +
					 "VALUES ( @TP_CODETYPETIERS, @TP_LIBELLE, @TP_DESCRIPTION) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamTP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTP_DESCRIPTION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypetiers>clsPhapartypetiers</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypetiers clsPhapartypetiers,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_LIBELLE = new SqlParameter("@TP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTP_LIBELLE.Value  = clsPhapartypetiers.TP_LIBELLE ;

			SqlParameter vppParamTP_DESCRIPTION = new SqlParameter("@TP_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamTP_DESCRIPTION.Value  = clsPhapartypetiers.TP_DESCRIPTION ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARTYPETIERS SET " +
							"TP_LIBELLE = @TP_LIBELLE, "+
							"TP_DESCRIPTION = @TP_DESCRIPTION " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTP_DESCRIPTION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARTYPETIERS "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypetiers </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypetiers> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TP_CODETYPETIERS, TP_LIBELLE, TP_DESCRIPTION FROM dbo.PHAPARTYPETIERS " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypetiers> clsPhapartypetierss = new List<clsPhapartypetiers>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypetiers clsPhapartypetiers = new clsPhapartypetiers();
					clsPhapartypetiers.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					clsPhapartypetiers.TP_LIBELLE = clsDonnee.vogDataReader["TP_LIBELLE"].ToString();
					clsPhapartypetiers.TP_DESCRIPTION = clsDonnee.vogDataReader["TP_DESCRIPTION"].ToString();
					clsPhapartypetierss.Add(clsPhapartypetiers);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypetierss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypetiers </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypetiers> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypetiers> clsPhapartypetierss = new List<clsPhapartypetiers>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TP_CODETYPETIERS, TP_LIBELLE, TP_DESCRIPTION FROM dbo.PHAPARTYPETIERS " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypetiers clsPhapartypetiers = new clsPhapartypetiers();
					clsPhapartypetiers.TP_CODETYPETIERS = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPETIERS"].ToString();
					clsPhapartypetiers.TP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TP_LIBELLE"].ToString();
					clsPhapartypetiers.TP_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["TP_DESCRIPTION"].ToString();
					clsPhapartypetierss.Add(clsPhapartypetiers);
				}
				Dataset.Dispose();
			}
		return clsPhapartypetierss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARTYPETIERS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT DISTINCT TP_CODETYPETIERS , TP_LIBELLE FROM dbo.VUE_PHAPARTYPETIERSPARAMETRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TP_CODETYPETIERS)</summary>
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
				this.vapCritere ="WHERE TP_CODETYPETIERS=@TP_CODETYPETIERS";
				vapNomParametre = new string[]{"@TP_CODETYPETIERS"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
                case 2 :
                this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND   EC_CODECRAN=@EC_CODECRAN  AND TT_ACTIF='O'  ";
                vapNomParametre = new string[] { "@MG_CODEMODEGESTION", "@EC_CODECRAN" };
                vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
                break;
                case 3 :
                this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION  AND   EC_CODECRAN=@EC_CODECRAN  AND   TP_CODETYPETIERS=@TP_CODETYPETIERS AND TT_ACTIF='O'  ";
                vapNomParametre = new string[] { "@MG_CODEMODEGESTION", "@EC_CODECRAN", "@TP_CODETYPETIERS" };
                vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
                break;

			}
		}
	}
}
