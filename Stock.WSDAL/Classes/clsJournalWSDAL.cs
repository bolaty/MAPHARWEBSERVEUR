using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsJournalWSDAL: ITableDAL<clsJournal>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(JO_CODEJOURNAL) AS JO_CODEJOURNAL  FROM dbo.FT_JOURNAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(JO_CODEJOURNAL) AS JO_CODEJOURNAL  FROM dbo.FT_JOURNAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(JO_CODEJOURNAL) AS JO_CODEJOURNAL  FROM dbo.FT_JOURNAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsJournal comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsJournal pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT EN_CODEENTREPOT  , JO_LIBELLE  , JO_C  , PL_CODENUMCOMPTE  , JO_NUMEROORDRE, JO_SAISIEANALYTIQUE, JO_CONTREPARTIE  FROM dbo.FT_JOURNAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsJournal clsJournal = new clsJournal();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsJournal.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsJournal.JO_LIBELLE = clsDonnee.vogDataReader["JO_LIBELLE"].ToString();
					clsJournal.JO_C = clsDonnee.vogDataReader["JO_C"].ToString();
					clsJournal.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsJournal.JO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["JO_NUMEROORDRE"].ToString());
                    clsJournal.JO_SAISIEANALYTIQUE = clsDonnee.vogDataReader["JO_SAISIEANALYTIQUE"].ToString();
                    clsJournal.JO_CONTREPARTIE = clsDonnee.vogDataReader["JO_CONTREPARTIE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsJournal;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsJournal>clsJournal</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsJournal clsJournal)
		{
			//Préparation des paramètres
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsJournal.EN_CODEENTREPOT ;
			if(clsJournal.EN_CODEENTREPOT== ""  ) vppParamEN_CODEENTREPOT.Value  = DBNull.Value;
			SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.VarChar, 25);
			vppParamJO_CODEJOURNAL.Value  = clsJournal.JO_CODEJOURNAL ;
            SqlParameter vppParamJO_JOURNALCODE = new SqlParameter("@JO_JOURNALCODE", SqlDbType.VarChar, 150);
            vppParamJO_JOURNALCODE.Value = clsJournal.JO_JOURNALCODE;
			SqlParameter vppParamJO_LIBELLE = new SqlParameter("@JO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamJO_LIBELLE.Value  = clsJournal.JO_LIBELLE ;
			SqlParameter vppParamJO_C = new SqlParameter("@JO_C", SqlDbType.VarChar, 1);
			vppParamJO_C.Value  = clsJournal.JO_C ;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsJournal.PL_CODENUMCOMPTE ;
			if(clsJournal.PL_CODENUMCOMPTE== ""  ) vppParamPL_CODENUMCOMPTE.Value  = DBNull.Value;
            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsJournal.PL_CODENUMCOMPTE;
            if (clsJournal.PL_NUMCOMPTE == "") vppParamPL_NUMCOMPTE.Value = DBNull.Value;

			SqlParameter vppParamJO_NUMEROORDRE = new SqlParameter("@JO_NUMEROORDRE", SqlDbType.Int);
			vppParamJO_NUMEROORDRE.Value  = clsJournal.JO_NUMEROORDRE ;

            SqlParameter vppParamTJ_CODETYPEJOURNAL = new SqlParameter("@TJ_CODETYPEJOURNAL", SqlDbType.VarChar, 2);
            vppParamTJ_CODETYPEJOURNAL.Value = clsJournal.TJ_CODETYPEJOURNAL;

            SqlParameter vppParamJO_SAISIEANALYTIQUE = new SqlParameter("@JO_SAISIEANALYTIQUE", SqlDbType.VarChar, 1);
            vppParamJO_SAISIEANALYTIQUE.Value = clsJournal.JO_SAISIEANALYTIQUE;

            SqlParameter vppParamJO_CONTREPARTIE = new SqlParameter("@JO_CONTREPARTIE", SqlDbType.VarChar, 1);
            vppParamJO_CONTREPARTIE.Value = clsJournal.JO_CONTREPARTIE;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_JOURNAL  @EN_CODEENTREPOT, @JO_CODEJOURNAL, @JO_JOURNALCODE, @JO_LIBELLE, @JO_C, @PL_CODENUMCOMPTE,@PL_NUMCOMPTE, @JO_NUMEROORDRE,@TJ_CODETYPEJOURNAL, @JO_SAISIEANALYTIQUE, @JO_CONTREPARTIE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamJO_JOURNALCODE);
			vppSqlCmd.Parameters.Add(vppParamJO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamJO_C);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamJO_NUMEROORDRE);
            vppSqlCmd.Parameters.Add(vppParamTJ_CODETYPEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamJO_SAISIEANALYTIQUE);
            vppSqlCmd.Parameters.Add(vppParamJO_CONTREPARTIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsJournal>clsJournal</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsJournal clsJournal,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsJournal.EN_CODEENTREPOT ;
			if(clsJournal.EN_CODEENTREPOT== ""  ) vppParamEN_CODEENTREPOT.Value  = DBNull.Value;
			SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.VarChar, 25);
			vppParamJO_CODEJOURNAL.Value  = clsJournal.JO_CODEJOURNAL ;
            SqlParameter vppParamJO_JOURNALCODE = new SqlParameter("@JO_JOURNALCODE", SqlDbType.VarChar, 150);
            vppParamJO_JOURNALCODE.Value = clsJournal.JO_JOURNALCODE;
			SqlParameter vppParamJO_LIBELLE = new SqlParameter("@JO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamJO_LIBELLE.Value  = clsJournal.JO_LIBELLE ;
			SqlParameter vppParamJO_C = new SqlParameter("@JO_C", SqlDbType.VarChar, 1);
			vppParamJO_C.Value  = clsJournal.JO_C ;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsJournal.PL_CODENUMCOMPTE ;
            if (clsJournal.PL_CODENUMCOMPTE == "") vppParamPL_CODENUMCOMPTE.Value = DBNull.Value;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsJournal.PL_NUMCOMPTE;
            if (clsJournal.PL_NUMCOMPTE == "") vppParamPL_NUMCOMPTE.Value = DBNull.Value;

			
			SqlParameter vppParamJO_NUMEROORDRE = new SqlParameter("@JO_NUMEROORDRE", SqlDbType.Int);
			vppParamJO_NUMEROORDRE.Value  = clsJournal.JO_NUMEROORDRE ;

            SqlParameter vppParamTJ_CODETYPEJOURNAL = new SqlParameter("@TJ_CODETYPEJOURNAL", SqlDbType.VarChar,2);
            vppParamTJ_CODETYPEJOURNAL.Value = clsJournal.TJ_CODETYPEJOURNAL;

            SqlParameter vppParamJO_SAISIEANALYTIQUE = new SqlParameter("@JO_SAISIEANALYTIQUE", SqlDbType.VarChar, 1);
            vppParamJO_SAISIEANALYTIQUE.Value = clsJournal.JO_SAISIEANALYTIQUE;

            SqlParameter vppParamJO_CONTREPARTIE = new SqlParameter("@JO_CONTREPARTIE", SqlDbType.VarChar, 1);
            vppParamJO_CONTREPARTIE.Value = clsJournal.JO_CONTREPARTIE;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_JOURNAL  @EN_CODEENTREPOT, @JO_CODEJOURNAL,@JO_JOURNALCODE, @JO_LIBELLE, @JO_C, @PL_CODENUMCOMPTE,@PL_NUMCOMPTE, @JO_NUMEROORDRE, @TJ_CODETYPEJOURNAL, @JO_SAISIEANALYTIQUE, @JO_CONTREPARTIE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamJO_JOURNALCODE);
			vppSqlCmd.Parameters.Add(vppParamJO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamJO_C);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamJO_NUMEROORDRE);
            vppSqlCmd.Parameters.Add(vppParamTJ_CODETYPEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamJO_SAISIEANALYTIQUE);
            vppSqlCmd.Parameters.Add(vppParamJO_CONTREPARTIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_JOURNAL  '', @JO_CODEJOURNAL, '' , '' ,'' , '' , '' ,'','', '', '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsJournal </returns>
		///<author>Home Technology</author>
		public List<clsJournal> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  EN_CODEENTREPOT, JO_CODEJOURNAL, JO_LIBELLE, JO_C, PL_CODENUMCOMPTE, JO_NUMEROORDRE, JO_SAISIEANALYTIQUE, JO_CONTREPARTIE FROM dbo.FT_JOURNAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsJournal> clsJournals = new List<clsJournal>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsJournal clsJournal = new clsJournal();
					clsJournal.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsJournal.JO_CODEJOURNAL = clsDonnee.vogDataReader["JO_CODEJOURNAL"].ToString();
					clsJournal.JO_LIBELLE = clsDonnee.vogDataReader["JO_LIBELLE"].ToString();
					clsJournal.JO_C = clsDonnee.vogDataReader["JO_C"].ToString();
					clsJournal.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsJournal.JO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["JO_NUMEROORDRE"].ToString());
                    clsJournal.JO_SAISIEANALYTIQUE = clsDonnee.vogDataReader["JO_SAISIEANALYTIQUE"].ToString();
                    clsJournal.JO_CONTREPARTIE = clsDonnee.vogDataReader["JO_CONTREPARTIE"].ToString();
					clsJournals.Add(clsJournal);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsJournals;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsJournal </returns>
		///<author>Home Technology</author>
		public List<clsJournal> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsJournal> clsJournals = new List<clsJournal>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  EN_CODEENTREPOT, JO_CODEJOURNAL, JO_LIBELLE, JO_C, PL_CODENUMCOMPTE, JO_NUMEROORDRE, JO_SAISIEANALYTIQUE, JO_CONTREPARTIE FROM dbo.FT_JOURNAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsJournal clsJournal = new clsJournal();
					clsJournal.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsJournal.JO_CODEJOURNAL = Dataset.Tables["TABLE"].Rows[Idx]["JO_CODEJOURNAL"].ToString();
					clsJournal.JO_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["JO_LIBELLE"].ToString();
					clsJournal.JO_C = Dataset.Tables["TABLE"].Rows[Idx]["JO_C"].ToString();
					clsJournal.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsJournal.JO_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["JO_NUMEROORDRE"].ToString());
                    clsJournal.JO_SAISIEANALYTIQUE = Dataset.Tables["TABLE"].Rows[Idx]["JO_SAISIEANALYTIQUE"].ToString();
                    clsJournal.JO_CONTREPARTIE = Dataset.Tables["TABLE"].Rows[Idx]["JO_CONTREPARTIE"].ToString();
					clsJournals.Add(clsJournal);
				}
				Dataset.Dispose();
			}
		return clsJournals;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_JOURNAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT JO_CODEJOURNAL , JO_LIBELLE,TJ_CODETYPEJOURNAL FROM dbo.FT_JOURNAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}




        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EN_CODEENTREPOT, JO_CODEJOURNAL ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboSelonEcran(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@TJ_CODETYPEJOURNAL", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1] };
            this.vapRequete = " EXEC [dbo].[PS_COMBOJOURNAL] @TJ_CODETYPEJOURNAL,@TYPEOPERATION ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :EN_CODEENTREPOT, JO_CODEJOURNAL)</summary>
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
                this.vapCritere = "WHERE JO_CODEJOURNAL=@JO_CODEJOURNAL";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@JO_CODEJOURNAL" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

				case 2 :
				this.vapCritere ="WHERE EN_CODEENTREPOT=@EN_CODEENTREPOT AND JO_CODEJOURNAL=@JO_CODEJOURNAL";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@EN_CODEENTREPOT","@JO_CODEJOURNAL"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;

                case 4:
                this.vapCritere = "WHERE TJ_CODETYPEJOURNAL = 02";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@EN_CODEENTREPOT", "@JO_CODEJOURNAL" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                break;

			}
		}
	}
}
