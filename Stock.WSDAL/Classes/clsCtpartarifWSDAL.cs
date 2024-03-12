using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpartarifWSDAL: ITableDAL<clsCtpartarif>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TA_CODETARIF) AS TA_CODETARIF  FROM dbo.FT_CTPARTARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TA_CODETARIF) AS TA_CODETARIF  FROM dbo.FT_CTPARTARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TA_CODETARIF) AS TA_CODETARIF  FROM dbo.FT_CTPARTARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpartarif comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpartarif pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_LIBELLETARIF  , TA_ACTIF  , TA_NUMEROORDRE  FROM dbo.FT_CTPARTARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpartarif clsCtpartarif = new clsCtpartarif();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartarif.TA_LIBELLETARIF = clsDonnee.vogDataReader["TA_LIBELLETARIF"].ToString();
					clsCtpartarif.TA_ACTIF = clsDonnee.vogDataReader["TA_ACTIF"].ToString();
					clsCtpartarif.TA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TA_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpartarif;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartarif>clsCtpartarif</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpartarif clsCtpartarif)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETARIF = new SqlParameter("@TA_CODETARIF", SqlDbType.VarChar, 25);
			vppParamTA_CODETARIF.Value  = clsCtpartarif.TA_CODETARIF ;
			SqlParameter vppParamTA_LIBELLETARIF = new SqlParameter("@TA_LIBELLETARIF", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLETARIF.Value  = clsCtpartarif.TA_LIBELLETARIF ;
			SqlParameter vppParamTA_ACTIF = new SqlParameter("@TA_ACTIF", SqlDbType.VarChar, 1);
			vppParamTA_ACTIF.Value  = clsCtpartarif.TA_ACTIF ;
			SqlParameter vppParamTA_NUMEROORDRE = new SqlParameter("@TA_NUMEROORDRE", SqlDbType.Int);
			vppParamTA_NUMEROORDRE.Value  = clsCtpartarif.TA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTARIF  @TA_CODETARIF, @TA_LIBELLETARIF, @TA_ACTIF, @TA_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETARIF);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLETARIF);
			vppSqlCmd.Parameters.Add(vppParamTA_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamTA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartarif>clsCtpartarif</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpartarif clsCtpartarif,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETARIF = new SqlParameter("@TA_CODETARIF", SqlDbType.VarChar, 25);
			vppParamTA_CODETARIF.Value  = clsCtpartarif.TA_CODETARIF ;
			SqlParameter vppParamTA_LIBELLETARIF = new SqlParameter("@TA_LIBELLETARIF", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLETARIF.Value  = clsCtpartarif.TA_LIBELLETARIF ;
			SqlParameter vppParamTA_ACTIF = new SqlParameter("@TA_ACTIF", SqlDbType.VarChar, 1);
			vppParamTA_ACTIF.Value  = clsCtpartarif.TA_ACTIF ;
			SqlParameter vppParamTA_NUMEROORDRE = new SqlParameter("@TA_NUMEROORDRE", SqlDbType.Int);
			vppParamTA_NUMEROORDRE.Value  = clsCtpartarif.TA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTARIF  @TA_CODETARIF, @TA_LIBELLETARIF, @TA_ACTIF, @TA_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETARIF);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLETARIF);
			vppSqlCmd.Parameters.Add(vppParamTA_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamTA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTARIF  @TA_CODETARIF, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartarif </returns>
		///<author>Home Technology</author>
		public List<clsCtpartarif> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETARIF, TA_LIBELLETARIF, TA_ACTIF, TA_NUMEROORDRE FROM dbo.FT_CTPARTARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpartarif> clsCtpartarifs = new List<clsCtpartarif>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartarif clsCtpartarif = new clsCtpartarif();
					clsCtpartarif.TA_CODETARIF = clsDonnee.vogDataReader["TA_CODETARIF"].ToString();
					clsCtpartarif.TA_LIBELLETARIF = clsDonnee.vogDataReader["TA_LIBELLETARIF"].ToString();
					clsCtpartarif.TA_ACTIF = clsDonnee.vogDataReader["TA_ACTIF"].ToString();
					clsCtpartarif.TA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TA_NUMEROORDRE"].ToString());
					clsCtpartarifs.Add(clsCtpartarif);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpartarifs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartarif </returns>
		///<author>Home Technology</author>
		public List<clsCtpartarif> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpartarif> clsCtpartarifs = new List<clsCtpartarif>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETARIF, TA_LIBELLETARIF, TA_ACTIF, TA_NUMEROORDRE FROM dbo.FT_CTPARTARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpartarif clsCtpartarif = new clsCtpartarif();
					clsCtpartarif.TA_CODETARIF = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETARIF"].ToString();
					clsCtpartarif.TA_LIBELLETARIF = Dataset.Tables["TABLE"].Rows[Idx]["TA_LIBELLETARIF"].ToString();
					clsCtpartarif.TA_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["TA_ACTIF"].ToString();
					clsCtpartarif.TA_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TA_NUMEROORDRE"].ToString());
					clsCtpartarifs.Add(clsCtpartarif);
				}
				Dataset.Dispose();
			}
		return clsCtpartarifs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARTARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_CODETARIF , TA_LIBELLETARIF FROM dbo.FT_CTPARTARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETARIF)</summary>
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
				this.vapCritere ="WHERE TA_CODETARIF=@TA_CODETARIF";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TA_CODETARIF"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
