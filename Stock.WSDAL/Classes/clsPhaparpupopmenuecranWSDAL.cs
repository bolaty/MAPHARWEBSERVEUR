using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpupopmenuecranWSDAL: ITableDAL<clsPhaparpupopmenuecran>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(EC_CODECRAN) AS EC_CODECRAN  FROM dbo.FT_PHAPARPUPOPMENUECRAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(EC_CODECRAN) AS EC_CODECRAN  FROM dbo.FT_PHAPARPUPOPMENUECRAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(EC_CODECRAN) AS EC_CODECRAN  FROM dbo.FT_PHAPARPUPOPMENUECRAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpupopmenuecran comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpupopmenuecran pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EC_NOM  , EC_LIBELLE  FROM dbo.FT_PHAPARPUPOPMENUECRAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpupopmenuecran clsPhaparpupopmenuecran = new clsPhaparpupopmenuecran();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenuecran.EC_NOM = clsDonnee.vogDataReader["EC_NOM"].ToString();
					clsPhaparpupopmenuecran.EC_LIBELLE = clsDonnee.vogDataReader["EC_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpupopmenuecran;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenuecran>clsPhaparpupopmenuecran</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpupopmenuecran clsPhaparpupopmenuecran)
		{
			//Préparation des paramètres
			SqlParameter vppParamEC_CODECRAN = new SqlParameter("@EC_CODECRAN", SqlDbType.VarChar, 2);
			vppParamEC_CODECRAN.Value  = clsPhaparpupopmenuecran.EC_CODECRAN ;
			SqlParameter vppParamEC_NOM = new SqlParameter("@EC_NOM", SqlDbType.VarChar, 150);
			vppParamEC_NOM.Value  = clsPhaparpupopmenuecran.EC_NOM ;
			SqlParameter vppParamEC_LIBELLE = new SqlParameter("@EC_LIBELLE", SqlDbType.VarChar, 150);
			vppParamEC_LIBELLE.Value  = clsPhaparpupopmenuecran.EC_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUECRAN  @EC_CODECRAN, @EC_NOM, @EC_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEC_CODECRAN);
			vppSqlCmd.Parameters.Add(vppParamEC_NOM);
			vppSqlCmd.Parameters.Add(vppParamEC_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenuecran>clsPhaparpupopmenuecran</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpupopmenuecran clsPhaparpupopmenuecran,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamEC_CODECRAN = new SqlParameter("@EC_CODECRAN", SqlDbType.VarChar, 2);
			vppParamEC_CODECRAN.Value  = clsPhaparpupopmenuecran.EC_CODECRAN ;
			SqlParameter vppParamEC_NOM = new SqlParameter("@EC_NOM", SqlDbType.VarChar, 150);
			vppParamEC_NOM.Value  = clsPhaparpupopmenuecran.EC_NOM ;
			SqlParameter vppParamEC_LIBELLE = new SqlParameter("@EC_LIBELLE", SqlDbType.VarChar, 150);
			vppParamEC_LIBELLE.Value  = clsPhaparpupopmenuecran.EC_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUECRAN  @EC_CODECRAN, @EC_NOM, @EC_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEC_CODECRAN);
			vppSqlCmd.Parameters.Add(vppParamEC_NOM);
			vppSqlCmd.Parameters.Add(vppParamEC_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUECRAN  @EC_CODECRAN, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenuecran </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenuecran> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EC_CODECRAN, EC_NOM, EC_LIBELLE FROM dbo.FT_PHAPARPUPOPMENUECRAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpupopmenuecran> clsPhaparpupopmenuecrans = new List<clsPhaparpupopmenuecran>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenuecran clsPhaparpupopmenuecran = new clsPhaparpupopmenuecran();
					clsPhaparpupopmenuecran.EC_CODECRAN = clsDonnee.vogDataReader["EC_CODECRAN"].ToString();
					clsPhaparpupopmenuecran.EC_NOM = clsDonnee.vogDataReader["EC_NOM"].ToString();
					clsPhaparpupopmenuecran.EC_LIBELLE = clsDonnee.vogDataReader["EC_LIBELLE"].ToString();
					clsPhaparpupopmenuecrans.Add(clsPhaparpupopmenuecran);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpupopmenuecrans;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenuecran </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenuecran> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpupopmenuecran> clsPhaparpupopmenuecrans = new List<clsPhaparpupopmenuecran>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EC_CODECRAN, EC_NOM, EC_LIBELLE FROM dbo.FT_PHAPARPUPOPMENUECRAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpupopmenuecran clsPhaparpupopmenuecran = new clsPhaparpupopmenuecran();
					clsPhaparpupopmenuecran.EC_CODECRAN = Dataset.Tables["TABLE"].Rows[Idx]["EC_CODECRAN"].ToString();
					clsPhaparpupopmenuecran.EC_NOM = Dataset.Tables["TABLE"].Rows[Idx]["EC_NOM"].ToString();
					clsPhaparpupopmenuecran.EC_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["EC_LIBELLE"].ToString();
					clsPhaparpupopmenuecrans.Add(clsPhaparpupopmenuecran);
				}
				Dataset.Dispose();
			}
		return clsPhaparpupopmenuecrans;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENUECRAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EC_CODECRAN , EC_NOM FROM dbo.FT_PHAPARPUPOPMENUECRAN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :EC_CODECRAN)</summary>
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
				this.vapCritere ="WHERE EC_CODECRAN=@EC_CODECRAN";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@EC_CODECRAN"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
