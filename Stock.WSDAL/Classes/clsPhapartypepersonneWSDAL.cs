using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypepersonneWSDAL: ITableDAL<clsPhapartypepersonne>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TP_CODETYPEPERSONNE) AS TP_CODETYPEPERSONNE  FROM dbo.FT_PHAPARTYPEPERSONNE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TP_CODETYPEPERSONNE) AS TP_CODETYPEPERSONNE  FROM dbo.FT_PHAPARTYPEPERSONNE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TP_CODETYPEPERSONNE) AS TP_CODETYPEPERSONNE  FROM dbo.FT_PHAPARTYPEPERSONNE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypepersonne comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypepersonne pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TP_LIBELLETYPEPERSONNE  FROM dbo.FT_PHAPARTYPEPERSONNE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypepersonne clsPhapartypepersonne = new clsPhapartypepersonne();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypepersonne.TP_LIBELLETYPEPERSONNE = clsDonnee.vogDataReader["TP_LIBELLETYPEPERSONNE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypepersonne;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypepersonne>clsPhapartypepersonne</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypepersonne clsPhapartypepersonne)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_CODETYPEPERSONNE = new SqlParameter("@TP_CODETYPEPERSONNE", SqlDbType.VarChar, 2);
			vppParamTP_CODETYPEPERSONNE.Value  = clsPhapartypepersonne.TP_CODETYPEPERSONNE ;
			SqlParameter vppParamTP_LIBELLETYPEPERSONNE = new SqlParameter("@TP_LIBELLETYPEPERSONNE", SqlDbType.VarChar, 50);
			vppParamTP_LIBELLETYPEPERSONNE.Value  = clsPhapartypepersonne.TP_LIBELLETYPEPERSONNE ;
			if(clsPhapartypepersonne.TP_LIBELLETYPEPERSONNE== ""  ) vppParamTP_LIBELLETYPEPERSONNE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEPERSONNE  @TP_CODETYPEPERSONNE, @TP_LIBELLETYPEPERSONNE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPERSONNE);
			vppSqlCmd.Parameters.Add(vppParamTP_LIBELLETYPEPERSONNE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypepersonne>clsPhapartypepersonne</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypepersonne clsPhapartypepersonne,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_CODETYPEPERSONNE = new SqlParameter("@TP_CODETYPEPERSONNE", SqlDbType.VarChar, 2);
			vppParamTP_CODETYPEPERSONNE.Value  = clsPhapartypepersonne.TP_CODETYPEPERSONNE ;
			SqlParameter vppParamTP_LIBELLETYPEPERSONNE = new SqlParameter("@TP_LIBELLETYPEPERSONNE", SqlDbType.VarChar, 50);
			vppParamTP_LIBELLETYPEPERSONNE.Value  = clsPhapartypepersonne.TP_LIBELLETYPEPERSONNE ;
			if(clsPhapartypepersonne.TP_LIBELLETYPEPERSONNE== ""  ) vppParamTP_LIBELLETYPEPERSONNE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEPERSONNE  @TP_CODETYPEPERSONNE, @TP_LIBELLETYPEPERSONNE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPERSONNE);
			vppSqlCmd.Parameters.Add(vppParamTP_LIBELLETYPEPERSONNE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEPERSONNE  @TP_CODETYPEPERSONNE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypepersonne </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypepersonne> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TP_CODETYPEPERSONNE, TP_LIBELLETYPEPERSONNE FROM dbo.FT_PHAPARTYPEPERSONNE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypepersonne> clsPhapartypepersonnes = new List<clsPhapartypepersonne>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypepersonne clsPhapartypepersonne = new clsPhapartypepersonne();
					clsPhapartypepersonne.TP_CODETYPEPERSONNE = clsDonnee.vogDataReader["TP_CODETYPEPERSONNE"].ToString();
					clsPhapartypepersonne.TP_LIBELLETYPEPERSONNE = clsDonnee.vogDataReader["TP_LIBELLETYPEPERSONNE"].ToString();
					clsPhapartypepersonnes.Add(clsPhapartypepersonne);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypepersonnes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypepersonne </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypepersonne> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypepersonne> clsPhapartypepersonnes = new List<clsPhapartypepersonne>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TP_CODETYPEPERSONNE, TP_LIBELLETYPEPERSONNE FROM dbo.FT_PHAPARTYPEPERSONNE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypepersonne clsPhapartypepersonne = new clsPhapartypepersonne();
					clsPhapartypepersonne.TP_CODETYPEPERSONNE = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPEPERSONNE"].ToString();
					clsPhapartypepersonne.TP_LIBELLETYPEPERSONNE = Dataset.Tables["TABLE"].Rows[Idx]["TP_LIBELLETYPEPERSONNE"].ToString();
					clsPhapartypepersonnes.Add(clsPhapartypepersonne);
				}
				Dataset.Dispose();
			}
		return clsPhapartypepersonnes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARTYPEPERSONNE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TP_CODETYPEPERSONNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TP_CODETYPEPERSONNE , TP_LIBELLETYPEPERSONNE FROM dbo.FT_PHAPARTYPEPERSONNE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TP_CODETYPEPERSONNE)</summary>
		///<param name="clsDonnee"> clsDonnee</param>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{"@CODECRYPTAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
				break;
				case 1 :
				this.vapCritere ="WHERE TP_CODETYPEPERSONNE=@TP_CODETYPEPERSONNE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TP_CODETYPEPERSONNE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
