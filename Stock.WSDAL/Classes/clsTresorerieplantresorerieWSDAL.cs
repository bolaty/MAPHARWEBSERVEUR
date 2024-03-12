using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsTresorerieplantresorerieWSDAL: ITableDAL<clsTresorerieplantresorerie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TB_CODEPLANTRESORERIE) AS TB_CODEPLANTRESORERIE  FROM dbo.TRESORERIEPLANTRESORERIE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TB_CODEPLANTRESORERIE) AS TB_CODEPLANTRESORERIE  FROM dbo.TRESORERIEPLANTRESORERIE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TB_CODEPLANTRESORERIE) AS TB_CODEPLANTRESORERIE  FROM dbo.TRESORERIEPLANTRESORERIE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsTresorerieplantresorerie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsTresorerieplantresorerie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , PV_CODEPOINTVENTE  , TB_LIBELLE  , TB_DATESAISIE  , TB_CODEPLANTRESORERIELIAISON  , OP_CODEOPERATEUR  , TB_DATEDEBUT  , TB_DATEFIN  FROM dbo.FT_TRESORERIEPLANTRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsTresorerieplantresorerie clsTresorerieplantresorerie = new clsTresorerieplantresorerie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTresorerieplantresorerie.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsTresorerieplantresorerie.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsTresorerieplantresorerie.TB_LIBELLE = clsDonnee.vogDataReader["TB_LIBELLE"].ToString();
					clsTresorerieplantresorerie.TB_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TB_DATESAISIE"].ToString());
					clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON = clsDonnee.vogDataReader["TB_CODEPLANTRESORERIELIAISON"].ToString();
					clsTresorerieplantresorerie.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsTresorerieplantresorerie.TB_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["TB_DATEDEBUT"].ToString());
					clsTresorerieplantresorerie.TB_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["TB_DATEFIN"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsTresorerieplantresorerie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieplantresorerie>clsTresorerieplantresorerie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsTresorerieplantresorerie clsTresorerieplantresorerie)
		{
			//Préparation des paramètres
			SqlParameter vppParamTB_CODEPLANTRESORERIE = new SqlParameter("@TB_CODEPLANTRESORERIE", SqlDbType.VarChar, 25);
			vppParamTB_CODEPLANTRESORERIE.Value  = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsTresorerieplantresorerie.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 4);
			vppParamPV_CODEPOINTVENTE.Value  = clsTresorerieplantresorerie.PV_CODEPOINTVENTE ;
			if(clsTresorerieplantresorerie.PV_CODEPOINTVENTE== ""  ) vppParamPV_CODEPOINTVENTE.Value  = DBNull.Value;
			SqlParameter vppParamTB_LIBELLE = new SqlParameter("@TB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTB_LIBELLE.Value  = clsTresorerieplantresorerie.TB_LIBELLE ;
			SqlParameter vppParamTB_DATESAISIE = new SqlParameter("@TB_DATESAISIE", SqlDbType.DateTime);
			vppParamTB_DATESAISIE.Value  = clsTresorerieplantresorerie.TB_DATESAISIE ;
			SqlParameter vppParamTB_CODEPLANTRESORERIELIAISON = new SqlParameter("@TB_CODEPLANTRESORERIELIAISON", SqlDbType.VarChar, 25);
			vppParamTB_CODEPLANTRESORERIELIAISON.Value  = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON ;
			if(clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON== ""  ) vppParamTB_CODEPLANTRESORERIELIAISON.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsTresorerieplantresorerie.OP_CODEOPERATEUR ;
			SqlParameter vppParamTB_DATEDEBUT = new SqlParameter("@TB_DATEDEBUT", SqlDbType.DateTime);
			vppParamTB_DATEDEBUT.Value  = clsTresorerieplantresorerie.TB_DATEDEBUT ;
			SqlParameter vppParamTB_DATEFIN = new SqlParameter("@TB_DATEFIN", SqlDbType.DateTime);
			vppParamTB_DATEFIN.Value  = clsTresorerieplantresorerie.TB_DATEFIN ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIE  @TB_CODEPLANTRESORERIE, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @TB_LIBELLE, @TB_DATESAISIE, @TB_CODEPLANTRESORERIELIAISON, @OP_CODEOPERATEUR, @TB_DATEDEBUT, @TB_DATEFIN, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamTB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTB_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIELIAISON);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamTB_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamTB_DATEFIN);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsTresorerieplantresorerie>clsTresorerieplantresorerie</param>
        ///<author>Home Technology</author>
        public void pvgInsertComplement(clsDonnee clsDonnee, clsTresorerieplantresorerie clsTresorerieplantresorerie)
        {
	        //Préparation des paramètres
	        SqlParameter vppParamTB_CODEPLANTRESORERIE = new SqlParameter("@TB_CODEPLANTRESORERIE", SqlDbType.VarChar, 25);
	        vppParamTB_CODEPLANTRESORERIE.Value  = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE ;
	        SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
	        vppParamAG_CODEAGENCE.Value  = clsTresorerieplantresorerie.AG_CODEAGENCE ;
	        SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 4);
	        vppParamPV_CODEPOINTVENTE.Value  = clsTresorerieplantresorerie.PV_CODEPOINTVENTE ;
	        if(clsTresorerieplantresorerie.PV_CODEPOINTVENTE== ""  ) vppParamPV_CODEPOINTVENTE.Value  = DBNull.Value;
	        SqlParameter vppParamTB_LIBELLE = new SqlParameter("@TB_LIBELLE", SqlDbType.VarChar, 150);
	        vppParamTB_LIBELLE.Value  = clsTresorerieplantresorerie.TB_LIBELLE ;
	        SqlParameter vppParamTB_DATESAISIE = new SqlParameter("@TB_DATESAISIE", SqlDbType.DateTime);
	        vppParamTB_DATESAISIE.Value  = clsTresorerieplantresorerie.TB_DATESAISIE ;
	        SqlParameter vppParamTB_CODEPLANTRESORERIELIAISON = new SqlParameter("@TB_CODEPLANTRESORERIELIAISON", SqlDbType.VarChar, 25);
	        vppParamTB_CODEPLANTRESORERIELIAISON.Value  = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON ;
	        if(clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON== ""  ) vppParamTB_CODEPLANTRESORERIELIAISON.Value  = DBNull.Value;
	        SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
	        vppParamOP_CODEOPERATEUR.Value  = clsTresorerieplantresorerie.OP_CODEOPERATEUR ;
	        SqlParameter vppParamTB_DATEDEBUT = new SqlParameter("@TB_DATEDEBUT", SqlDbType.DateTime);
	        vppParamTB_DATEDEBUT.Value  = clsTresorerieplantresorerie.TB_DATEDEBUT ;
	        SqlParameter vppParamTB_DATEFIN = new SqlParameter("@TB_DATEFIN", SqlDbType.DateTime);
	        vppParamTB_DATEFIN.Value  = clsTresorerieplantresorerie.TB_DATEFIN ;
	        SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
	        vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

	        //Préparation de la commande
		        this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIE  @TB_CODEPLANTRESORERIE, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @TB_LIBELLE, @TB_DATESAISIE, @TB_CODEPLANTRESORERIELIAISON, @OP_CODEOPERATEUR, @TB_DATEDEBUT, @TB_DATEFIN, @CODECRYPTAGE, 3 ";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

	        //Ajout des paramètre à la commande
	        vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIE);
	        vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
	        vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
	        vppSqlCmd.Parameters.Add(vppParamTB_LIBELLE);
	        vppSqlCmd.Parameters.Add(vppParamTB_DATESAISIE);
	        vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIELIAISON);
	        vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
	        vppSqlCmd.Parameters.Add(vppParamTB_DATEDEBUT);
	        vppSqlCmd.Parameters.Add(vppParamTB_DATEFIN);
	        vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
	        //Ouverture de la connection et exécution de la commande
	        clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }



		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieplantresorerie>clsTresorerieplantresorerie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsTresorerieplantresorerie clsTresorerieplantresorerie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTB_CODEPLANTRESORERIE = new SqlParameter("@TB_CODEPLANTRESORERIE", SqlDbType.VarChar, 25);
			vppParamTB_CODEPLANTRESORERIE.Value  = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsTresorerieplantresorerie.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 4);
			vppParamPV_CODEPOINTVENTE.Value  = clsTresorerieplantresorerie.PV_CODEPOINTVENTE ;
			if(clsTresorerieplantresorerie.PV_CODEPOINTVENTE== ""  ) vppParamPV_CODEPOINTVENTE.Value  = DBNull.Value;
			SqlParameter vppParamTB_LIBELLE = new SqlParameter("@TB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTB_LIBELLE.Value  = clsTresorerieplantresorerie.TB_LIBELLE ;
			SqlParameter vppParamTB_DATESAISIE = new SqlParameter("@TB_DATESAISIE", SqlDbType.DateTime);
			vppParamTB_DATESAISIE.Value  = clsTresorerieplantresorerie.TB_DATESAISIE ;
			SqlParameter vppParamTB_CODEPLANTRESORERIELIAISON = new SqlParameter("@TB_CODEPLANTRESORERIELIAISON", SqlDbType.VarChar, 25);
			vppParamTB_CODEPLANTRESORERIELIAISON.Value  = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON ;
			if(clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON== ""  ) vppParamTB_CODEPLANTRESORERIELIAISON.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsTresorerieplantresorerie.OP_CODEOPERATEUR ;
			SqlParameter vppParamTB_DATEDEBUT = new SqlParameter("@TB_DATEDEBUT", SqlDbType.DateTime);
			vppParamTB_DATEDEBUT.Value  = clsTresorerieplantresorerie.TB_DATEDEBUT ;
			SqlParameter vppParamTB_DATEFIN = new SqlParameter("@TB_DATEFIN", SqlDbType.DateTime);
			vppParamTB_DATEFIN.Value  = clsTresorerieplantresorerie.TB_DATEFIN ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIE  @TB_CODEPLANTRESORERIE, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @TB_LIBELLE, @TB_DATESAISIE, @TB_CODEPLANTRESORERIELIAISON, @OP_CODEOPERATEUR, @TB_DATEDEBUT, @TB_DATEFIN, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamTB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTB_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIELIAISON);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamTB_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamTB_DATEFIN);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieplantresorerie>clsTresorerieplantresorerie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdateComplement(clsDonnee clsDonnee, clsTresorerieplantresorerie clsTresorerieplantresorerie, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamTB_CODEPLANTRESORERIE = new SqlParameter("@TB_CODEPLANTRESORERIE", SqlDbType.VarChar, 25);
            vppParamTB_CODEPLANTRESORERIE.Value = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsTresorerieplantresorerie.AG_CODEAGENCE;
            SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 4);
            vppParamPV_CODEPOINTVENTE.Value = clsTresorerieplantresorerie.PV_CODEPOINTVENTE;
            if (clsTresorerieplantresorerie.PV_CODEPOINTVENTE == "") vppParamPV_CODEPOINTVENTE.Value = DBNull.Value;
            SqlParameter vppParamTB_LIBELLE = new SqlParameter("@TB_LIBELLE", SqlDbType.VarChar, 150);
            vppParamTB_LIBELLE.Value = clsTresorerieplantresorerie.TB_LIBELLE;
            SqlParameter vppParamTB_DATESAISIE = new SqlParameter("@TB_DATESAISIE", SqlDbType.DateTime);
            vppParamTB_DATESAISIE.Value = clsTresorerieplantresorerie.TB_DATESAISIE;
            SqlParameter vppParamTB_CODEPLANTRESORERIELIAISON = new SqlParameter("@TB_CODEPLANTRESORERIELIAISON", SqlDbType.VarChar, 25);
            vppParamTB_CODEPLANTRESORERIELIAISON.Value = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON;
            if (clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON == "") vppParamTB_CODEPLANTRESORERIELIAISON.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsTresorerieplantresorerie.OP_CODEOPERATEUR;
            SqlParameter vppParamTB_DATEDEBUT = new SqlParameter("@TB_DATEDEBUT", SqlDbType.DateTime);
            vppParamTB_DATEDEBUT.Value = clsTresorerieplantresorerie.TB_DATEDEBUT;
            SqlParameter vppParamTB_DATEFIN = new SqlParameter("@TB_DATEFIN", SqlDbType.DateTime);
            vppParamTB_DATEFIN.Value = clsTresorerieplantresorerie.TB_DATEFIN;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIE  @TB_CODEPLANTRESORERIE, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @TB_LIBELLE, @TB_DATESAISIE, @TB_CODEPLANTRESORERIELIAISON, @OP_CODEOPERATEUR, @TB_DATEDEBUT, @TB_DATEFIN, @CODECRYPTAGE, 4 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
            vppSqlCmd.Parameters.Add(vppParamTB_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamTB_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamTB_CODEPLANTRESORERIELIAISON);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamTB_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamTB_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPLANTRESORERIE  @TB_CODEPLANTRESORERIE, @AG_CODEAGENCE, '' , '' , '' , '', '', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieplantresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieplantresorerie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TB_CODEPLANTRESORERIE, AG_CODEAGENCE, PV_CODEPOINTVENTE, TB_LIBELLE, TB_DATESAISIE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR, TB_DATEDEBUT, TB_DATEFIN FROM dbo.FT_TRESORERIEPLANTRESORERIE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsTresorerieplantresorerie> clsTresorerieplantresoreries = new List<clsTresorerieplantresorerie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTresorerieplantresorerie clsTresorerieplantresorerie = new clsTresorerieplantresorerie();
					clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE = clsDonnee.vogDataReader["TB_CODEPLANTRESORERIE"].ToString();
					clsTresorerieplantresorerie.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsTresorerieplantresorerie.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsTresorerieplantresorerie.TB_LIBELLE = clsDonnee.vogDataReader["TB_LIBELLE"].ToString();
					clsTresorerieplantresorerie.TB_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TB_DATESAISIE"].ToString());
					clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON = clsDonnee.vogDataReader["TB_CODEPLANTRESORERIELIAISON"].ToString();
					clsTresorerieplantresorerie.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsTresorerieplantresorerie.TB_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["TB_DATEDEBUT"].ToString());
					clsTresorerieplantresorerie.TB_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["TB_DATEFIN"].ToString());
					clsTresorerieplantresoreries.Add(clsTresorerieplantresorerie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsTresorerieplantresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieplantresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieplantresorerie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsTresorerieplantresorerie> clsTresorerieplantresoreries = new List<clsTresorerieplantresorerie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TB_CODEPLANTRESORERIE, AG_CODEAGENCE, PV_CODEPOINTVENTE, TB_LIBELLE, TB_DATESAISIE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR, TB_DATEDEBUT, TB_DATEFIN FROM dbo.FT_TRESORERIEPLANTRESORERIE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsTresorerieplantresorerie clsTresorerieplantresorerie = new clsTresorerieplantresorerie();
					clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TB_CODEPLANTRESORERIE"].ToString();
					clsTresorerieplantresorerie.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsTresorerieplantresorerie.PV_CODEPOINTVENTE = Dataset.Tables["TABLE"].Rows[Idx]["PV_CODEPOINTVENTE"].ToString();
					clsTresorerieplantresorerie.TB_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TB_LIBELLE"].ToString();
					clsTresorerieplantresorerie.TB_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TB_DATESAISIE"].ToString());
					clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON = Dataset.Tables["TABLE"].Rows[Idx]["TB_CODEPLANTRESORERIELIAISON"].ToString();
					clsTresorerieplantresorerie.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsTresorerieplantresorerie.TB_DATEDEBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TB_DATEDEBUT"].ToString());
					clsTresorerieplantresorerie.TB_DATEFIN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TB_DATEFIN"].ToString());
					clsTresorerieplantresoreries.Add(clsTresorerieplantresorerie);
				}
				Dataset.Dispose();
			}
		return clsTresorerieplantresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_TRESORERIEPLANTRESORERIE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TB_CODEPLANTRESORERIE , TB_LIBELLE FROM dbo.FT_TRESORERIEPLANTRESORERIE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + " AND TB_CODEPLANTRESORERIELIAISON IS NULL";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TB_CODEPLANTRESORERIE , TB_LIBELLE FROM dbo.TRESORERIEPLANTRESORERIE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetComplement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_TRESORERIEPLANTRESORERIE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + " AND TB_CODEPLANTRESORERIELIAISON IS NOT NULL";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboComplement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TB_CODEPLANTRESORERIE , TB_LIBELLE FROM dbo.FT_TRESORERIEPLANTRESORERIE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + " AND TB_CODEPLANTRESORERIELIAISON IS NOT NULL";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TB_CODEPLANTRESORERIE, AG_CODEAGENCE, TB_CODEPLANTRESORERIELIAISON, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere = "WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND TB_CODEPLANTRESORERIE=@TB_CODEPLANTRESORERIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@TB_CODEPLANTRESORERIE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE TB_CODEPLANTRESORERIE=@TB_CODEPLANTRESORERIE AND AG_CODEAGENCE=@AG_CODEAGENCE AND TB_CODEPLANTRESORERIELIAISON=@TB_CODEPLANTRESORERIELIAISON";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TB_CODEPLANTRESORERIE","@AG_CODEAGENCE","@TB_CODEPLANTRESORERIELIAISON"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE TB_CODEPLANTRESORERIE=@TB_CODEPLANTRESORERIE AND AG_CODEAGENCE=@AG_CODEAGENCE AND TB_CODEPLANTRESORERIELIAISON=@TB_CODEPLANTRESORERIELIAISON AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TB_CODEPLANTRESORERIE","@AG_CODEAGENCE","@TB_CODEPLANTRESORERIELIAISON","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
