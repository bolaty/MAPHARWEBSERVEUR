using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparetatfactureWSDAL: ITableDAL<clsPhaparetatfacture>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(EF_INDEX) AS EF_INDEX  FROM dbo.FT_PHAPARETATFACTURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(EF_INDEX) AS EF_INDEX  FROM dbo.FT_PHAPARETATFACTURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(EF_INDEX) AS EF_INDEX  FROM dbo.FT_PHAPARETATFACTURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparetatfacture comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparetatfacture pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MG_CODEMODEGESTION  , EC_CODECRAN  , EF_NOMGROUPE  , EF_NOMETAT  , EF_LIBELLEETAT  , EF_NOMETATSOUSETAT1  , EF_NOMETATSOUSETAT2  , EF_AFFICHER  , EF_DOSSIER  , EF_TYPEETAT  FROM dbo.FT_PHAPARETATFACTURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparetatfacture clsPhaparetatfacture = new clsPhaparetatfacture();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparetatfacture.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
					clsPhaparetatfacture.EC_CODECRAN = clsDonnee.vogDataReader["EC_CODECRAN"].ToString();
					clsPhaparetatfacture.EF_NOMGROUPE = clsDonnee.vogDataReader["EF_NOMGROUPE"].ToString();
					clsPhaparetatfacture.EF_NOMETAT = clsDonnee.vogDataReader["EF_NOMETAT"].ToString();
					clsPhaparetatfacture.EF_LIBELLEETAT = clsDonnee.vogDataReader["EF_LIBELLEETAT"].ToString();
					clsPhaparetatfacture.EF_NOMETATSOUSETAT1 = clsDonnee.vogDataReader["EF_NOMETATSOUSETAT1"].ToString();
					clsPhaparetatfacture.EF_NOMETATSOUSETAT2 = clsDonnee.vogDataReader["EF_NOMETATSOUSETAT2"].ToString();
					clsPhaparetatfacture.EF_AFFICHER = clsDonnee.vogDataReader["EF_AFFICHER"].ToString();
					clsPhaparetatfacture.EF_DOSSIER = clsDonnee.vogDataReader["EF_DOSSIER"].ToString();
					clsPhaparetatfacture.EF_TYPEETAT = clsDonnee.vogDataReader["EF_TYPEETAT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparetatfacture;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparetatfacture>clsPhaparetatfacture</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparetatfacture clsPhaparetatfacture)
		{
			//Préparation des paramètres
			SqlParameter vppParamEF_INDEX = new SqlParameter("@EF_INDEX", SqlDbType.VarChar, 45);
			vppParamEF_INDEX.Value  = clsPhaparetatfacture.EF_INDEX ;
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparetatfacture.MG_CODEMODEGESTION ;
			SqlParameter vppParamEC_CODECRAN = new SqlParameter("@EC_CODECRAN", SqlDbType.VarChar, 2);
			vppParamEC_CODECRAN.Value  = clsPhaparetatfacture.EC_CODECRAN ;
			SqlParameter vppParamEF_NOMGROUPE = new SqlParameter("@EF_NOMGROUPE", SqlDbType.VarChar, 50);
			vppParamEF_NOMGROUPE.Value  = clsPhaparetatfacture.EF_NOMGROUPE ;
			SqlParameter vppParamEF_NOMETAT = new SqlParameter("@EF_NOMETAT", SqlDbType.VarChar, 50);
			vppParamEF_NOMETAT.Value  = clsPhaparetatfacture.EF_NOMETAT ;
			SqlParameter vppParamEF_LIBELLEETAT = new SqlParameter("@EF_LIBELLEETAT", SqlDbType.VarChar, 250);
			vppParamEF_LIBELLEETAT.Value  = clsPhaparetatfacture.EF_LIBELLEETAT ;
			SqlParameter vppParamEF_NOMETATSOUSETAT1 = new SqlParameter("@EF_NOMETATSOUSETAT1", SqlDbType.VarChar, 50);
			vppParamEF_NOMETATSOUSETAT1.Value  = clsPhaparetatfacture.EF_NOMETATSOUSETAT1 ;
			if(clsPhaparetatfacture.EF_NOMETATSOUSETAT1== ""  ) vppParamEF_NOMETATSOUSETAT1.Value  = DBNull.Value;
			SqlParameter vppParamEF_NOMETATSOUSETAT2 = new SqlParameter("@EF_NOMETATSOUSETAT2", SqlDbType.VarChar, 50);
			vppParamEF_NOMETATSOUSETAT2.Value  = clsPhaparetatfacture.EF_NOMETATSOUSETAT2 ;
			if(clsPhaparetatfacture.EF_NOMETATSOUSETAT2== ""  ) vppParamEF_NOMETATSOUSETAT2.Value  = DBNull.Value;
			SqlParameter vppParamEF_AFFICHER = new SqlParameter("@EF_AFFICHER", SqlDbType.VarChar, 1);
			vppParamEF_AFFICHER.Value  = clsPhaparetatfacture.EF_AFFICHER ;
			SqlParameter vppParamEF_DOSSIER = new SqlParameter("@EF_DOSSIER", SqlDbType.VarChar, 50);
			vppParamEF_DOSSIER.Value  = clsPhaparetatfacture.EF_DOSSIER ;
			SqlParameter vppParamEF_TYPEETAT = new SqlParameter("@EF_TYPEETAT", SqlDbType.VarChar, 50);
			vppParamEF_TYPEETAT.Value  = clsPhaparetatfacture.EF_TYPEETAT ;
			if(clsPhaparetatfacture.EF_TYPEETAT== ""  ) vppParamEF_TYPEETAT.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARETATFACTURE  @EF_INDEX, @MG_CODEMODEGESTION, @EC_CODECRAN, @EF_NOMGROUPE, @EF_NOMETAT, @EF_LIBELLEETAT, @EF_NOMETATSOUSETAT1, @EF_NOMETATSOUSETAT2, @EF_AFFICHER, @EF_DOSSIER, @EF_TYPEETAT, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEF_INDEX);
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamEC_CODECRAN);
			vppSqlCmd.Parameters.Add(vppParamEF_NOMGROUPE);
			vppSqlCmd.Parameters.Add(vppParamEF_NOMETAT);
			vppSqlCmd.Parameters.Add(vppParamEF_LIBELLEETAT);
			vppSqlCmd.Parameters.Add(vppParamEF_NOMETATSOUSETAT1);
			vppSqlCmd.Parameters.Add(vppParamEF_NOMETATSOUSETAT2);
			vppSqlCmd.Parameters.Add(vppParamEF_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamEF_DOSSIER);
			vppSqlCmd.Parameters.Add(vppParamEF_TYPEETAT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparetatfacture>clsPhaparetatfacture</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparetatfacture clsPhaparetatfacture,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamEF_INDEX = new SqlParameter("@EF_INDEX", SqlDbType.VarChar, 45);
			vppParamEF_INDEX.Value  = clsPhaparetatfacture.EF_INDEX ;
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparetatfacture.MG_CODEMODEGESTION ;
			SqlParameter vppParamEC_CODECRAN = new SqlParameter("@EC_CODECRAN", SqlDbType.VarChar, 2);
			vppParamEC_CODECRAN.Value  = clsPhaparetatfacture.EC_CODECRAN ;
			SqlParameter vppParamEF_NOMGROUPE = new SqlParameter("@EF_NOMGROUPE", SqlDbType.VarChar, 50);
			vppParamEF_NOMGROUPE.Value  = clsPhaparetatfacture.EF_NOMGROUPE ;
			SqlParameter vppParamEF_NOMETAT = new SqlParameter("@EF_NOMETAT", SqlDbType.VarChar, 50);
			vppParamEF_NOMETAT.Value  = clsPhaparetatfacture.EF_NOMETAT ;
			SqlParameter vppParamEF_LIBELLEETAT = new SqlParameter("@EF_LIBELLEETAT", SqlDbType.VarChar, 250);
			vppParamEF_LIBELLEETAT.Value  = clsPhaparetatfacture.EF_LIBELLEETAT ;
			SqlParameter vppParamEF_NOMETATSOUSETAT1 = new SqlParameter("@EF_NOMETATSOUSETAT1", SqlDbType.VarChar, 50);
			vppParamEF_NOMETATSOUSETAT1.Value  = clsPhaparetatfacture.EF_NOMETATSOUSETAT1 ;
			if(clsPhaparetatfacture.EF_NOMETATSOUSETAT1== ""  ) vppParamEF_NOMETATSOUSETAT1.Value  = DBNull.Value;
			SqlParameter vppParamEF_NOMETATSOUSETAT2 = new SqlParameter("@EF_NOMETATSOUSETAT2", SqlDbType.VarChar, 50);
			vppParamEF_NOMETATSOUSETAT2.Value  = clsPhaparetatfacture.EF_NOMETATSOUSETAT2 ;
			if(clsPhaparetatfacture.EF_NOMETATSOUSETAT2== ""  ) vppParamEF_NOMETATSOUSETAT2.Value  = DBNull.Value;
			SqlParameter vppParamEF_AFFICHER = new SqlParameter("@EF_AFFICHER", SqlDbType.VarChar, 1);
			vppParamEF_AFFICHER.Value  = clsPhaparetatfacture.EF_AFFICHER ;
			SqlParameter vppParamEF_DOSSIER = new SqlParameter("@EF_DOSSIER", SqlDbType.VarChar, 50);
			vppParamEF_DOSSIER.Value  = clsPhaparetatfacture.EF_DOSSIER ;
			SqlParameter vppParamEF_TYPEETAT = new SqlParameter("@EF_TYPEETAT", SqlDbType.VarChar, 50);
			vppParamEF_TYPEETAT.Value  = clsPhaparetatfacture.EF_TYPEETAT ;
			if(clsPhaparetatfacture.EF_TYPEETAT== ""  ) vppParamEF_TYPEETAT.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARETATFACTURE  @EF_INDEX, @MG_CODEMODEGESTION, @EC_CODECRAN, @EF_NOMGROUPE, @EF_NOMETAT, @EF_LIBELLEETAT, @EF_NOMETATSOUSETAT1, @EF_NOMETATSOUSETAT2, @EF_AFFICHER, @EF_DOSSIER, @EF_TYPEETAT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEF_INDEX);
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamEC_CODECRAN);
			vppSqlCmd.Parameters.Add(vppParamEF_NOMGROUPE);
			vppSqlCmd.Parameters.Add(vppParamEF_NOMETAT);
			vppSqlCmd.Parameters.Add(vppParamEF_LIBELLEETAT);
			vppSqlCmd.Parameters.Add(vppParamEF_NOMETATSOUSETAT1);
			vppSqlCmd.Parameters.Add(vppParamEF_NOMETATSOUSETAT2);
			vppSqlCmd.Parameters.Add(vppParamEF_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamEF_DOSSIER);
			vppSqlCmd.Parameters.Add(vppParamEF_TYPEETAT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARETATFACTURE  @EF_INDEX, '' , @EC_CODECRAN, '' , '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparetatfacture </returns>
		///<author>Home Technology</author>
		public List<clsPhaparetatfacture> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EF_INDEX, MG_CODEMODEGESTION, EC_CODECRAN, EF_NOMGROUPE, EF_NOMETAT, EF_LIBELLEETAT, EF_NOMETATSOUSETAT1, EF_NOMETATSOUSETAT2, EF_AFFICHER, EF_DOSSIER, EF_TYPEETAT FROM dbo.FT_PHAPARETATFACTURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparetatfacture> clsPhaparetatfactures = new List<clsPhaparetatfacture>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparetatfacture clsPhaparetatfacture = new clsPhaparetatfacture();
					clsPhaparetatfacture.EF_INDEX = clsDonnee.vogDataReader["EF_INDEX"].ToString();
					clsPhaparetatfacture.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
					clsPhaparetatfacture.EC_CODECRAN = clsDonnee.vogDataReader["EC_CODECRAN"].ToString();
					clsPhaparetatfacture.EF_NOMGROUPE = clsDonnee.vogDataReader["EF_NOMGROUPE"].ToString();
					clsPhaparetatfacture.EF_NOMETAT = clsDonnee.vogDataReader["EF_NOMETAT"].ToString();
					clsPhaparetatfacture.EF_LIBELLEETAT = clsDonnee.vogDataReader["EF_LIBELLEETAT"].ToString();
					clsPhaparetatfacture.EF_NOMETATSOUSETAT1 = clsDonnee.vogDataReader["EF_NOMETATSOUSETAT1"].ToString();
					clsPhaparetatfacture.EF_NOMETATSOUSETAT2 = clsDonnee.vogDataReader["EF_NOMETATSOUSETAT2"].ToString();
					clsPhaparetatfacture.EF_AFFICHER = clsDonnee.vogDataReader["EF_AFFICHER"].ToString();
					clsPhaparetatfacture.EF_DOSSIER = clsDonnee.vogDataReader["EF_DOSSIER"].ToString();
					clsPhaparetatfacture.EF_TYPEETAT = clsDonnee.vogDataReader["EF_TYPEETAT"].ToString();
					clsPhaparetatfactures.Add(clsPhaparetatfacture);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparetatfactures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparetatfacture </returns>
		///<author>Home Technology</author>
		public List<clsPhaparetatfacture> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparetatfacture> clsPhaparetatfactures = new List<clsPhaparetatfacture>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EF_INDEX, MG_CODEMODEGESTION, EC_CODECRAN, EF_NOMGROUPE, EF_NOMETAT, EF_LIBELLEETAT, EF_NOMETATSOUSETAT1, EF_NOMETATSOUSETAT2, EF_AFFICHER, EF_DOSSIER, EF_TYPEETAT FROM dbo.FT_PHAPARETATFACTURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparetatfacture clsPhaparetatfacture = new clsPhaparetatfacture();
					clsPhaparetatfacture.EF_INDEX = Dataset.Tables["TABLE"].Rows[Idx]["EF_INDEX"].ToString();
					clsPhaparetatfacture.MG_CODEMODEGESTION = Dataset.Tables["TABLE"].Rows[Idx]["MG_CODEMODEGESTION"].ToString();
					clsPhaparetatfacture.EC_CODECRAN = Dataset.Tables["TABLE"].Rows[Idx]["EC_CODECRAN"].ToString();
					clsPhaparetatfacture.EF_NOMGROUPE = Dataset.Tables["TABLE"].Rows[Idx]["EF_NOMGROUPE"].ToString();
					clsPhaparetatfacture.EF_NOMETAT = Dataset.Tables["TABLE"].Rows[Idx]["EF_NOMETAT"].ToString();
					clsPhaparetatfacture.EF_LIBELLEETAT = Dataset.Tables["TABLE"].Rows[Idx]["EF_LIBELLEETAT"].ToString();
					clsPhaparetatfacture.EF_NOMETATSOUSETAT1 = Dataset.Tables["TABLE"].Rows[Idx]["EF_NOMETATSOUSETAT1"].ToString();
					clsPhaparetatfacture.EF_NOMETATSOUSETAT2 = Dataset.Tables["TABLE"].Rows[Idx]["EF_NOMETATSOUSETAT2"].ToString();
					clsPhaparetatfacture.EF_AFFICHER = Dataset.Tables["TABLE"].Rows[Idx]["EF_AFFICHER"].ToString();
					clsPhaparetatfacture.EF_DOSSIER = Dataset.Tables["TABLE"].Rows[Idx]["EF_DOSSIER"].ToString();
					clsPhaparetatfacture.EF_TYPEETAT = Dataset.Tables["TABLE"].Rows[Idx]["EF_TYPEETAT"].ToString();
					clsPhaparetatfactures.Add(clsPhaparetatfacture);
				}
				Dataset.Dispose();
			}
		return clsPhaparetatfactures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARETATFACTURE(@MG_CODEMODEGESTION, @EC_CODECRAN, @EF_NOMGROUPE,@EF_AFFICHER,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EF_INDEX , MG_CODEMODEGESTION FROM dbo.FT_PHAPARETATFACTURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :EF_INDEX, EC_CODECRAN)</summary>
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
                this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@MG_CODEMODEGESTION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND EC_CODECRAN=@EC_CODECRAN";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@MG_CODEMODEGESTION", "@EC_CODECRAN" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;

                case 3:
                this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND EC_CODECRAN=@EC_CODECRAN  AND EF_NOMGROUPE=@EF_NOMGROUPE ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@MG_CODEMODEGESTION", "@EC_CODECRAN", "@EF_NOMGROUPE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                break;
                case 4:
                this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND EC_CODECRAN=@EC_CODECRAN  AND EF_NOMGROUPE=@EF_NOMGROUPE AND EF_AFFICHER=@EF_AFFICHER ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@MG_CODEMODEGESTION", "@EC_CODECRAN", "@EF_NOMGROUPE", "@EF_AFFICHER" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                break;



			}
		}
	}
}
