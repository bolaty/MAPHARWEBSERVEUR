using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparribWSDAL: ITableDAL<clsPhaparrib>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(RIB_CODERIB) AS RIB_CODERIB  FROM dbo.FT_COMPTAPAR_RIB(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(RIB_CODERIB) AS RIB_CODERIB  FROM dbo.FT_COMPTAPAR_RIB(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(RIB_CODERIB) AS RIB_CODERIB  FROM dbo.FT_COMPTAPAR_RIB(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparrib comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparrib pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT DE_CODEDEVISE  , PY_CODEPAYS  , LO_CODELOCALE  , RIB_CODEBANQUE  , RIB_CODEQUICHET  , RIB_NUMCOMPTE  , RIB_CLE  , RIB_COMMENTAIRE  , JO_CODEJOURNAL, RIB_ABREGE  FROM dbo.FT_COMPTAPAR_RIB(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparrib clsPhaparrib = new clsPhaparrib();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparrib.DE_CODEDEVISE = clsDonnee.vogDataReader["DE_CODEDEVISE"].ToString();
					clsPhaparrib.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
					clsPhaparrib.LO_CODELOCALE = clsDonnee.vogDataReader["LO_CODELOCALE"].ToString();
					clsPhaparrib.RIB_CODEBANQUE = clsDonnee.vogDataReader["RIB_CODEBANQUE"].ToString();
					clsPhaparrib.RIB_CODEQUICHET = clsDonnee.vogDataReader["RIB_CODEQUICHET"].ToString();
					clsPhaparrib.RIB_NUMCOMPTE = clsDonnee.vogDataReader["RIB_NUMCOMPTE"].ToString();
					clsPhaparrib.RIB_CLE = clsDonnee.vogDataReader["RIB_CLE"].ToString();
					clsPhaparrib.RIB_COMMENTAIRE = clsDonnee.vogDataReader["RIB_COMMENTAIRE"].ToString();
					clsPhaparrib.JO_CODEJOURNAL = clsDonnee.vogDataReader["JO_CODEJOURNAL"].ToString();
                    clsPhaparrib.RIB_ABREGE = clsDonnee.vogDataReader["RIB_ABREGE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparrib;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparrib>clsPhaparrib</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparrib clsPhaparrib)
		{
			//Préparation des paramètres
			SqlParameter vppParamRIB_CODERIB = new SqlParameter("@RIB_CODERIB", SqlDbType.VarChar, 7);
			vppParamRIB_CODERIB.Value  = clsPhaparrib.RIB_CODERIB ;
			SqlParameter vppParamDE_CODEDEVISE = new SqlParameter("@DE_CODEDEVISE", SqlDbType.VarChar, 4);
			vppParamDE_CODEDEVISE.Value  = clsPhaparrib.DE_CODEDEVISE ;
			if(clsPhaparrib.DE_CODEDEVISE== ""  ) vppParamDE_CODEDEVISE.Value  = DBNull.Value;
			SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 4);
			vppParamPY_CODEPAYS.Value  = clsPhaparrib.PY_CODEPAYS ;
			if(clsPhaparrib.PY_CODEPAYS== ""  ) vppParamPY_CODEPAYS.Value  = DBNull.Value;
			SqlParameter vppParamLO_CODELOCALE = new SqlParameter("@LO_CODELOCALE", SqlDbType.VarChar, 2);
			vppParamLO_CODELOCALE.Value  = clsPhaparrib.LO_CODELOCALE ;
			if(clsPhaparrib.LO_CODELOCALE== ""  ) vppParamLO_CODELOCALE.Value  = DBNull.Value;
			SqlParameter vppParamRIB_CODEBANQUE = new SqlParameter("@RIB_CODEBANQUE", SqlDbType.VarChar, 150);
			vppParamRIB_CODEBANQUE.Value  = clsPhaparrib.RIB_CODEBANQUE ;
			if(clsPhaparrib.RIB_CODEBANQUE== ""  ) vppParamRIB_CODEBANQUE.Value  = DBNull.Value;
			SqlParameter vppParamRIB_CODEQUICHET = new SqlParameter("@RIB_CODEQUICHET", SqlDbType.VarChar, 150);
			vppParamRIB_CODEQUICHET.Value  = clsPhaparrib.RIB_CODEQUICHET ;
			if(clsPhaparrib.RIB_CODEQUICHET== ""  ) vppParamRIB_CODEQUICHET.Value  = DBNull.Value;
			SqlParameter vppParamRIB_NUMCOMPTE = new SqlParameter("@RIB_NUMCOMPTE", SqlDbType.VarChar, 150);
			vppParamRIB_NUMCOMPTE.Value  = clsPhaparrib.RIB_NUMCOMPTE ;
			if(clsPhaparrib.RIB_NUMCOMPTE== ""  ) vppParamRIB_NUMCOMPTE.Value  = DBNull.Value;
			SqlParameter vppParamRIB_CLE = new SqlParameter("@RIB_CLE", SqlDbType.VarChar, 150);
			vppParamRIB_CLE.Value  = clsPhaparrib.RIB_CLE ;
			if(clsPhaparrib.RIB_CLE== ""  ) vppParamRIB_CLE.Value  = DBNull.Value;
			SqlParameter vppParamRIB_COMMENTAIRE = new SqlParameter("@RIB_COMMENTAIRE", SqlDbType.VarChar, 150);
			vppParamRIB_COMMENTAIRE.Value  = clsPhaparrib.RIB_COMMENTAIRE ;
			if(clsPhaparrib.RIB_COMMENTAIRE== ""  ) vppParamRIB_COMMENTAIRE.Value  = DBNull.Value;

			SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.Int);
			vppParamJO_CODEJOURNAL.Value  = clsPhaparrib.JO_CODEJOURNAL;
			if(clsPhaparrib.JO_CODEJOURNAL== ""  ) vppParamJO_CODEJOURNAL.Value  = DBNull.Value;

            SqlParameter vppParamRIB_ABREGE = new SqlParameter("@RIB_ABREGE", SqlDbType.VarChar, 150);
			vppParamRIB_ABREGE.Value  = clsPhaparrib.RIB_ABREGE;
			if(clsPhaparrib.RIB_ABREGE== ""  ) vppParamRIB_ABREGE.Value  = DBNull.Value;


            SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.Int);
            vppParamAB_CODEAGENCEBANCAIRE.Value = clsPhaparrib.AB_CODEAGENCEBANCAIRE;
            if (clsPhaparrib.AB_CODEAGENCEBANCAIRE == "") vppParamAB_CODEAGENCEBANCAIRE.Value = DBNull.Value;

           
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_RIB  @RIB_CODERIB, @DE_CODEDEVISE, @PY_CODEPAYS, @LO_CODELOCALE, @RIB_CODEBANQUE, @RIB_CODEQUICHET, @RIB_NUMCOMPTE, @RIB_CLE, @RIB_COMMENTAIRE, @JO_CODEJOURNAL, @RIB_ABREGE, @AB_CODEAGENCEBANCAIRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRIB_CODERIB);
			vppSqlCmd.Parameters.Add(vppParamDE_CODEDEVISE);
			vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
			vppSqlCmd.Parameters.Add(vppParamLO_CODELOCALE);
			vppSqlCmd.Parameters.Add(vppParamRIB_CODEBANQUE);
			vppSqlCmd.Parameters.Add(vppParamRIB_CODEQUICHET);
			vppSqlCmd.Parameters.Add(vppParamRIB_NUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamRIB_CLE);
			vppSqlCmd.Parameters.Add(vppParamRIB_COMMENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamRIB_ABREGE);
            vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparrib>clsPhaparrib</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparrib clsPhaparrib,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRIB_CODERIB = new SqlParameter("@RIB_CODERIB", SqlDbType.VarChar, 7);
			vppParamRIB_CODERIB.Value  = clsPhaparrib.RIB_CODERIB ;
			SqlParameter vppParamDE_CODEDEVISE = new SqlParameter("@DE_CODEDEVISE", SqlDbType.VarChar, 4);
			vppParamDE_CODEDEVISE.Value  = clsPhaparrib.DE_CODEDEVISE ;
			if(clsPhaparrib.DE_CODEDEVISE== ""  ) vppParamDE_CODEDEVISE.Value  = DBNull.Value;
			SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 4);
			vppParamPY_CODEPAYS.Value  = clsPhaparrib.PY_CODEPAYS ;
			if(clsPhaparrib.PY_CODEPAYS== ""  ) vppParamPY_CODEPAYS.Value  = DBNull.Value;
			SqlParameter vppParamLO_CODELOCALE = new SqlParameter("@LO_CODELOCALE", SqlDbType.VarChar, 2);
			vppParamLO_CODELOCALE.Value  = clsPhaparrib.LO_CODELOCALE ;
			if(clsPhaparrib.LO_CODELOCALE== ""  ) vppParamLO_CODELOCALE.Value  = DBNull.Value;
			SqlParameter vppParamRIB_CODEBANQUE = new SqlParameter("@RIB_CODEBANQUE", SqlDbType.VarChar, 150);
			vppParamRIB_CODEBANQUE.Value  = clsPhaparrib.RIB_CODEBANQUE ;
			if(clsPhaparrib.RIB_CODEBANQUE== ""  ) vppParamRIB_CODEBANQUE.Value  = DBNull.Value;
			SqlParameter vppParamRIB_CODEQUICHET = new SqlParameter("@RIB_CODEQUICHET", SqlDbType.VarChar, 150);
			vppParamRIB_CODEQUICHET.Value  = clsPhaparrib.RIB_CODEQUICHET ;
			if(clsPhaparrib.RIB_CODEQUICHET== ""  ) vppParamRIB_CODEQUICHET.Value  = DBNull.Value;
			SqlParameter vppParamRIB_NUMCOMPTE = new SqlParameter("@RIB_NUMCOMPTE", SqlDbType.VarChar, 150);
			vppParamRIB_NUMCOMPTE.Value  = clsPhaparrib.RIB_NUMCOMPTE ;
			if(clsPhaparrib.RIB_NUMCOMPTE== ""  ) vppParamRIB_NUMCOMPTE.Value  = DBNull.Value;
			SqlParameter vppParamRIB_CLE = new SqlParameter("@RIB_CLE", SqlDbType.VarChar, 150);
			vppParamRIB_CLE.Value  = clsPhaparrib.RIB_CLE ;
			if(clsPhaparrib.RIB_CLE== ""  ) vppParamRIB_CLE.Value  = DBNull.Value;
			SqlParameter vppParamRIB_COMMENTAIRE = new SqlParameter("@RIB_COMMENTAIRE", SqlDbType.VarChar, 150);
			vppParamRIB_COMMENTAIRE.Value  = clsPhaparrib.RIB_COMMENTAIRE ;
			if(clsPhaparrib.RIB_COMMENTAIRE== ""  ) vppParamRIB_COMMENTAIRE.Value  = DBNull.Value;

			SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.Int);
			vppParamJO_CODEJOURNAL.Value  = clsPhaparrib.JO_CODEJOURNAL ;
			if(clsPhaparrib.JO_CODEJOURNAL== ""  ) vppParamJO_CODEJOURNAL.Value  = DBNull.Value;

            SqlParameter vppParamRIB_ABREGE = new SqlParameter("@RIB_ABREGE", SqlDbType.VarChar, 150);
            vppParamRIB_ABREGE.Value = clsPhaparrib.RIB_ABREGE;
            if (clsPhaparrib.RIB_ABREGE == "") vppParamRIB_ABREGE.Value = DBNull.Value;

            SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.Int);
            vppParamAB_CODEAGENCEBANCAIRE.Value = clsPhaparrib.AB_CODEAGENCEBANCAIRE;
            if (clsPhaparrib.AB_CODEAGENCEBANCAIRE == "") vppParamAB_CODEAGENCEBANCAIRE.Value = DBNull.Value;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_RIB  @RIB_CODERIB, @DE_CODEDEVISE, @PY_CODEPAYS, @LO_CODELOCALE, @RIB_CODEBANQUE, @RIB_CODEQUICHET, @RIB_NUMCOMPTE, @RIB_CLE, @RIB_COMMENTAIRE, @JO_CODEJOURNAL, @RIB_ABREGE, @AB_CODEAGENCEBANCAIRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRIB_CODERIB);
			vppSqlCmd.Parameters.Add(vppParamDE_CODEDEVISE);
			vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
			vppSqlCmd.Parameters.Add(vppParamLO_CODELOCALE);
			vppSqlCmd.Parameters.Add(vppParamRIB_CODEBANQUE);
			vppSqlCmd.Parameters.Add(vppParamRIB_CODEQUICHET);
			vppSqlCmd.Parameters.Add(vppParamRIB_NUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamRIB_CLE);
			vppSqlCmd.Parameters.Add(vppParamRIB_COMMENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamRIB_ABREGE);
            vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_RIB  @RIB_CODERIB, '' , '' , '' , '' , '' , '' , '' , '' , '', '', '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparrib </returns>
		///<author>Home Technology</author>
		public List<clsPhaparrib> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  RIB_CODERIB, DE_CODEDEVISE, PY_CODEPAYS, LO_CODELOCALE, RIB_CODEBANQUE, RIB_CODEQUICHET, RIB_NUMCOMPTE, RIB_CLE, RIB_COMMENTAIRE, JO_CODEJOURNAL, RIB_ABREGE, AB_CODEAGENCEBANCAIRE FROM dbo.FT_COMPTAPAR_RIB(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparrib> clsPhaparribs = new List<clsPhaparrib>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparrib clsPhaparrib = new clsPhaparrib();
					clsPhaparrib.RIB_CODERIB = clsDonnee.vogDataReader["RIB_CODERIB"].ToString();
					clsPhaparrib.DE_CODEDEVISE = clsDonnee.vogDataReader["DE_CODEDEVISE"].ToString();
					clsPhaparrib.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
					clsPhaparrib.LO_CODELOCALE = clsDonnee.vogDataReader["LO_CODELOCALE"].ToString();
					clsPhaparrib.RIB_CODEBANQUE = clsDonnee.vogDataReader["RIB_CODEBANQUE"].ToString();
					clsPhaparrib.RIB_CODEQUICHET = clsDonnee.vogDataReader["RIB_CODEQUICHET"].ToString();
					clsPhaparrib.RIB_NUMCOMPTE = clsDonnee.vogDataReader["RIB_NUMCOMPTE"].ToString();
					clsPhaparrib.RIB_CLE = clsDonnee.vogDataReader["RIB_CLE"].ToString();
					clsPhaparrib.RIB_COMMENTAIRE = clsDonnee.vogDataReader["RIB_COMMENTAIRE"].ToString();
					clsPhaparrib.JO_CODEJOURNAL = clsDonnee.vogDataReader["JO_CODEJOURNAL"].ToString();
                    clsPhaparrib.RIB_ABREGE = clsDonnee.vogDataReader["RIB_ABREGE"].ToString();
                    clsPhaparrib.AB_CODEAGENCEBANCAIRE = clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString();
					clsPhaparribs.Add(clsPhaparrib);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparribs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparrib </returns>
		///<author>Home Technology</author>
		public List<clsPhaparrib> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparrib> clsPhaparribs = new List<clsPhaparrib>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  RIB_CODERIB, DE_CODEDEVISE, PY_CODEPAYS, LO_CODELOCALE, RIB_CODEBANQUE, RIB_CODEQUICHET, RIB_NUMCOMPTE, RIB_CLE, RIB_COMMENTAIRE, JO_CODEJOURNAL, RIB_ABREGE, AB_CODEAGENCEBANCAIRE FROM dbo.FT_COMPTAPAR_RIB(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparrib clsPhaparrib = new clsPhaparrib();
					clsPhaparrib.RIB_CODERIB = Dataset.Tables["TABLE"].Rows[Idx]["RIB_CODERIB"].ToString();
					clsPhaparrib.DE_CODEDEVISE = Dataset.Tables["TABLE"].Rows[Idx]["DE_CODEDEVISE"].ToString();
					clsPhaparrib.PY_CODEPAYS = Dataset.Tables["TABLE"].Rows[Idx]["PY_CODEPAYS"].ToString();
					clsPhaparrib.LO_CODELOCALE = Dataset.Tables["TABLE"].Rows[Idx]["LO_CODELOCALE"].ToString();
					clsPhaparrib.RIB_CODEBANQUE = Dataset.Tables["TABLE"].Rows[Idx]["RIB_CODEBANQUE"].ToString();
					clsPhaparrib.RIB_CODEQUICHET = Dataset.Tables["TABLE"].Rows[Idx]["RIB_CODEQUICHET"].ToString();
					clsPhaparrib.RIB_NUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["RIB_NUMCOMPTE"].ToString();
					clsPhaparrib.RIB_CLE = Dataset.Tables["TABLE"].Rows[Idx]["RIB_CLE"].ToString();
					clsPhaparrib.RIB_COMMENTAIRE = Dataset.Tables["TABLE"].Rows[Idx]["RIB_COMMENTAIRE"].ToString();
					clsPhaparrib.JO_CODEJOURNAL = Dataset.Tables["TABLE"].Rows[Idx]["JO_CODEJOURNAL"].ToString();
                    clsPhaparrib.RIB_ABREGE = Dataset.Tables["TABLE"].Rows[Idx]["RIB_ABREGE"].ToString();
                    clsPhaparrib.AB_CODEAGENCEBANCAIRE = Dataset.Tables["TABLE"].Rows[Idx]["AB_CODEAGENCEBANCAIRE"].ToString();
					clsPhaparribs.Add(clsPhaparrib);
				}
				Dataset.Dispose();
			}
		return clsPhaparribs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_COMPTAPAR_RIB(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RIB_CODERIB ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT RIB_CODERIB , DE_CODEDEVISE FROM dbo.FT_COMPTAPAR_RIB(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RIB_CODERIB)</summary>
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
				this.vapCritere ="WHERE RIB_CODERIB=@RIB_CODERIB";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RIB_CODERIB"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

			}
		}
	}
}
