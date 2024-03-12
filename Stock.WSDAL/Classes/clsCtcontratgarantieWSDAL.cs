using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratgarantieWSDAL: ITableDAL<clsCtcontratgarantie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratgarantie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratgarantie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , CG_CAPITAUXASSURES  , CG_PRIMES  , CG_APRESREDUCTION  , CG_PRORATA  , CG_FRANCHISES  , CG_TAUX  , CG_MONTANT  , CG_LIBELLE  FROM dbo.FT_CTCONTRATGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratgarantie clsCtcontratgarantie = new clsCtcontratgarantie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratgarantie.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratgarantie.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratgarantie.CG_CAPITAUXASSURES = double.Parse(clsDonnee.vogDataReader["CG_CAPITAUXASSURES"].ToString());
					clsCtcontratgarantie.CG_PRIMES = double.Parse(clsDonnee.vogDataReader["CG_PRIMES"].ToString());
					clsCtcontratgarantie.CG_APRESREDUCTION = double.Parse(clsDonnee.vogDataReader["CG_APRESREDUCTION"].ToString());
					clsCtcontratgarantie.CG_PRORATA = double.Parse(clsDonnee.vogDataReader["CG_PRORATA"].ToString());
					clsCtcontratgarantie.CG_FRANCHISES = clsDonnee.vogDataReader["CG_FRANCHISES"].ToString();
					clsCtcontratgarantie.CG_TAUX = float.Parse(clsDonnee.vogDataReader["CG_TAUX"].ToString());
					clsCtcontratgarantie.CG_MONTANT = double.Parse(clsDonnee.vogDataReader["CG_MONTANT"].ToString());
					clsCtcontratgarantie.CG_LIBELLE = clsDonnee.vogDataReader["CG_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratgarantie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratgarantie>clsCtcontratgarantie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratgarantie clsCtcontratgarantie)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 50);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratgarantie.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT1", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratgarantie.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT1", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratgarantie.CA_CODECONTRAT ;
			SqlParameter vppParamGA_CODEGARANTIE = new SqlParameter("@GA_CODEGARANTIE", SqlDbType.VarChar, 5);
			vppParamGA_CODEGARANTIE.Value  = clsCtcontratgarantie.GA_CODEGARANTIE ;
			SqlParameter vppParamCG_CAPITAUXASSURES = new SqlParameter("@CG_CAPITAUXASSURES", SqlDbType.Money);
			vppParamCG_CAPITAUXASSURES.Value  = clsCtcontratgarantie.CG_CAPITAUXASSURES ;
			SqlParameter vppParamCG_PRIMES = new SqlParameter("@CG_PRIMES", SqlDbType.Money);
			vppParamCG_PRIMES.Value  = clsCtcontratgarantie.CG_PRIMES ;
			SqlParameter vppParamCG_APRESREDUCTION = new SqlParameter("@CG_APRESREDUCTION", SqlDbType.Money);
			vppParamCG_APRESREDUCTION.Value  = clsCtcontratgarantie.CG_APRESREDUCTION ;
			SqlParameter vppParamCG_PRORATA = new SqlParameter("@CG_PRORATA", SqlDbType.Money);
			vppParamCG_PRORATA.Value  = clsCtcontratgarantie.CG_PRORATA ;
			SqlParameter vppParamCG_FRANCHISES = new SqlParameter("@CG_FRANCHISES", SqlDbType.VarChar, 150);
			vppParamCG_FRANCHISES.Value  = clsCtcontratgarantie.CG_FRANCHISES ;
            if (clsCtcontratgarantie.CG_FRANCHISES == "") vppParamCG_FRANCHISES.Value = DBNull.Value;

            SqlParameter vppParamCG_TAUX = new SqlParameter("@CG_TAUX", SqlDbType.Float);
			vppParamCG_TAUX.Value  = clsCtcontratgarantie.CG_TAUX ;
			SqlParameter vppParamCG_MONTANT = new SqlParameter("@CG_MONTANT", SqlDbType.Money);
			vppParamCG_MONTANT.Value  = clsCtcontratgarantie.CG_MONTANT ;
			if(clsCtcontratgarantie.CG_MONTANT== 0  ) vppParamCG_MONTANT.Value  = DBNull.Value;
			SqlParameter vppParamCG_LIBELLE = new SqlParameter("@CG_LIBELLE", SqlDbType.VarChar, 1000);
			vppParamCG_LIBELLE.Value  = clsCtcontratgarantie.CG_LIBELLE ;
			if(clsCtcontratgarantie.CG_LIBELLE== ""  ) vppParamCG_LIBELLE.Value  = DBNull.Value;

			SqlParameter vppParamCG_GARANTIE = new SqlParameter("@CG_GARANTIE", SqlDbType.VarChar, 1);
            vppParamCG_GARANTIE.Value  = clsCtcontratgarantie.CG_GARANTIE;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATGARANTIE  @AG_CODEAGENCE1, @EN_CODEENTREPOT1, @CA_CODECONTRAT1, @GA_CODEGARANTIE, @CG_CAPITAUXASSURES, @CG_PRIMES, @CG_APRESREDUCTION, @CG_PRORATA, @CG_FRANCHISES, @CG_TAUX, @CG_MONTANT, @CG_LIBELLE, @CG_GARANTIE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamGA_CODEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamCG_CAPITAUXASSURES);
			vppSqlCmd.Parameters.Add(vppParamCG_PRIMES);
			vppSqlCmd.Parameters.Add(vppParamCG_APRESREDUCTION);
			vppSqlCmd.Parameters.Add(vppParamCG_PRORATA);
			vppSqlCmd.Parameters.Add(vppParamCG_FRANCHISES);
			vppSqlCmd.Parameters.Add(vppParamCG_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCG_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCG_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCG_GARANTIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratgarantie>clsCtcontratgarantie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratgarantie clsCtcontratgarantie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 50);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratgarantie.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratgarantie.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratgarantie.CA_CODECONTRAT ;
			SqlParameter vppParamGA_CODEGARANTIE = new SqlParameter("@GA_CODEGARANTIE", SqlDbType.VarChar, 5);
			vppParamGA_CODEGARANTIE.Value  = clsCtcontratgarantie.GA_CODEGARANTIE ;
			SqlParameter vppParamCG_CAPITAUXASSURES = new SqlParameter("@CG_CAPITAUXASSURES", SqlDbType.Money);
			vppParamCG_CAPITAUXASSURES.Value  = clsCtcontratgarantie.CG_CAPITAUXASSURES ;
			SqlParameter vppParamCG_PRIMES = new SqlParameter("@CG_PRIMES", SqlDbType.Money);
			vppParamCG_PRIMES.Value  = clsCtcontratgarantie.CG_PRIMES ;
			SqlParameter vppParamCG_APRESREDUCTION = new SqlParameter("@CG_APRESREDUCTION", SqlDbType.Money);
			vppParamCG_APRESREDUCTION.Value  = clsCtcontratgarantie.CG_APRESREDUCTION ;
			SqlParameter vppParamCG_PRORATA = new SqlParameter("@CG_PRORATA", SqlDbType.Money);
			vppParamCG_PRORATA.Value  = clsCtcontratgarantie.CG_PRORATA ;
			SqlParameter vppParamCG_FRANCHISES = new SqlParameter("@CG_FRANCHISES", SqlDbType.VarChar, 150);
			vppParamCG_FRANCHISES.Value  = clsCtcontratgarantie.CG_FRANCHISES ;
            if (clsCtcontratgarantie.CG_FRANCHISES == "") vppParamCG_FRANCHISES.Value = DBNull.Value;
            SqlParameter vppParamCG_TAUX = new SqlParameter("@CG_TAUX", SqlDbType.Float);
			vppParamCG_TAUX.Value  = clsCtcontratgarantie.CG_TAUX ;
			SqlParameter vppParamCG_MONTANT = new SqlParameter("@CG_MONTANT", SqlDbType.Money);
			vppParamCG_MONTANT.Value  = clsCtcontratgarantie.CG_MONTANT ;
			if(clsCtcontratgarantie.CG_MONTANT== 0  ) vppParamCG_MONTANT.Value  = DBNull.Value;
			SqlParameter vppParamCG_LIBELLE = new SqlParameter("@CG_LIBELLE", SqlDbType.VarChar, 1000);
			vppParamCG_LIBELLE.Value  = clsCtcontratgarantie.CG_LIBELLE ;
			if(clsCtcontratgarantie.CG_LIBELLE== ""  ) vppParamCG_LIBELLE.Value  = DBNull.Value;

			SqlParameter vppParamCG_GARANTIE = new SqlParameter("@CG_GARANTIE", SqlDbType.VarChar, 1);
            vppParamCG_GARANTIE.Value  = clsCtcontratgarantie.CG_GARANTIE;


			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATGARANTIE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT, @GA_CODEGARANTIE, @CG_CAPITAUXASSURES, @CG_PRIMES, @CG_APRESREDUCTION, @CG_PRORATA, @CG_FRANCHISES, @CG_TAUX, @CG_MONTANT, @CG_LIBELLE,@CG_GARANTIE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamGA_CODEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamCG_CAPITAUXASSURES);
			vppSqlCmd.Parameters.Add(vppParamCG_PRIMES);
			vppSqlCmd.Parameters.Add(vppParamCG_APRESREDUCTION);
			vppSqlCmd.Parameters.Add(vppParamCG_PRORATA);
			vppSqlCmd.Parameters.Add(vppParamCG_FRANCHISES);
			vppSqlCmd.Parameters.Add(vppParamCG_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCG_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCG_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCG_GARANTIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATGARANTIE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT, '', '' , '' , '' , '' , '' , '' , '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratgarantie </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratgarantie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE, CG_CAPITAUXASSURES, CG_PRIMES, CG_APRESREDUCTION, CG_PRORATA, CG_FRANCHISES, CG_TAUX, CG_MONTANT, CG_LIBELLE FROM dbo.FT_CTCONTRATGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratgarantie> clsCtcontratgaranties = new List<clsCtcontratgarantie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratgarantie clsCtcontratgarantie = new clsCtcontratgarantie();
					clsCtcontratgarantie.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratgarantie.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratgarantie.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratgarantie.GA_CODEGARANTIE = clsDonnee.vogDataReader["GA_CODEGARANTIE"].ToString();
					clsCtcontratgarantie.CG_CAPITAUXASSURES = double.Parse(clsDonnee.vogDataReader["CG_CAPITAUXASSURES"].ToString());
					clsCtcontratgarantie.CG_PRIMES = double.Parse(clsDonnee.vogDataReader["CG_PRIMES"].ToString());
					clsCtcontratgarantie.CG_APRESREDUCTION = double.Parse(clsDonnee.vogDataReader["CG_APRESREDUCTION"].ToString());
					clsCtcontratgarantie.CG_PRORATA = double.Parse(clsDonnee.vogDataReader["CG_PRORATA"].ToString());
					clsCtcontratgarantie.CG_FRANCHISES = clsDonnee.vogDataReader["CG_FRANCHISES"].ToString();
					clsCtcontratgarantie.CG_TAUX = float.Parse(clsDonnee.vogDataReader["CG_TAUX"].ToString());
					clsCtcontratgarantie.CG_MONTANT = double.Parse(clsDonnee.vogDataReader["CG_MONTANT"].ToString());
					clsCtcontratgarantie.CG_LIBELLE = clsDonnee.vogDataReader["CG_LIBELLE"].ToString();
					clsCtcontratgaranties.Add(clsCtcontratgarantie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratgaranties;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratgarantie </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratgarantie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratgarantie> clsCtcontratgaranties = new List<clsCtcontratgarantie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE, CG_CAPITAUXASSURES, CG_PRIMES, CG_APRESREDUCTION, CG_PRORATA, CG_FRANCHISES, CG_TAUX, CG_MONTANT, CG_LIBELLE FROM dbo.FT_CTCONTRATGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratgarantie clsCtcontratgarantie = new clsCtcontratgarantie();
					clsCtcontratgarantie.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratgarantie.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratgarantie.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratgarantie.GA_CODEGARANTIE = Dataset.Tables["TABLE"].Rows[Idx]["GA_CODEGARANTIE"].ToString();
					clsCtcontratgarantie.CG_CAPITAUXASSURES = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CG_CAPITAUXASSURES"].ToString());
					clsCtcontratgarantie.CG_PRIMES = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CG_PRIMES"].ToString());
					clsCtcontratgarantie.CG_APRESREDUCTION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CG_APRESREDUCTION"].ToString());
					clsCtcontratgarantie.CG_PRORATA = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CG_PRORATA"].ToString());
					clsCtcontratgarantie.CG_FRANCHISES = Dataset.Tables["TABLE"].Rows[Idx]["CG_FRANCHISES"].ToString();
					clsCtcontratgarantie.CG_TAUX = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CG_TAUX"].ToString());
					clsCtcontratgarantie.CG_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CG_MONTANT"].ToString());
					clsCtcontratgarantie.CG_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["CG_LIBELLE"].ToString();
					clsCtcontratgaranties.Add(clsCtcontratgarantie);
				}
				Dataset.Dispose();
			}
		return clsCtcontratgaranties;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTCONTRATGARANTIE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY GL_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CA_CODECONTRAT , CG_CAPITAUXASSURES FROM dbo.FT_CTCONTRATGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, GA_CODEGARANTIE)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CA_CODECONTRAT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT AND GA_CODEGARANTIE=@GA_CODEGARANTIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CA_CODECONTRAT","@GA_CODEGARANTIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
