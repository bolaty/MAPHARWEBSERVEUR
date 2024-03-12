using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaentrevehiculeWSDAL: ITableDAL<clsPhaentrevehicule>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RV_IDENTREE) AS RV_IDENTREE  FROM dbo.PHAENTREVEHICULE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RV_IDENTREE) AS RV_IDENTREE  FROM dbo.PHAENTREVEHICULE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RV_IDENTREE) AS RV_IDENTREE  FROM dbo.PHAENTREVEHICULE" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaentrevehicule comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaentrevehicule pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT RV_DATESAISIE  , MS_NUMPIECE  , TI_IDTIERS  , AR_CODEARTICLE  , RV_DATEPROCHAINEVISITETECH  , RV_DATEPROCHAINEVIDANGE  , RV_DATEDEBUT  , RV_DATEFIN  , RV_DATECLOTURE  FROM dbo.FT_PHAENTREVEHICULE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaentrevehicule clsPhaentrevehicule = new clsPhaentrevehicule();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaentrevehicule.RV_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["RV_DATESAISIE"].ToString());
					clsPhaentrevehicule.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhaentrevehicule.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhaentrevehicule.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaentrevehicule.RV_DATEPROCHAINEVISITETECH = DateTime.Parse(clsDonnee.vogDataReader["RV_DATEPROCHAINEVISITETECH"].ToString());
                    clsPhaentrevehicule.RV_DATEPROCHAINEVIDANGE = DateTime.Parse(clsDonnee.vogDataReader["RV_DATEPROCHAINEVIDANGE"].ToString());
					clsPhaentrevehicule.RV_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["RV_DATEDEBUT"].ToString());
					clsPhaentrevehicule.RV_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["RV_DATEFIN"].ToString());
					clsPhaentrevehicule.RV_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["RV_DATECLOTURE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaentrevehicule;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaentrevehicule>clsPhaentrevehicule</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaentrevehicule clsPhaentrevehicule)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaentrevehicule.AG_CODEAGENCE;
			SqlParameter vppParamRV_IDENTREE = new SqlParameter("@RV_IDENTREE", SqlDbType.Decimal, 4);
			vppParamRV_IDENTREE.Value  = clsPhaentrevehicule.RV_IDENTREE ;
			SqlParameter vppParamRV_DATESAISIE = new SqlParameter("@RV_DATESAISIE", SqlDbType.DateTime);
			vppParamRV_DATESAISIE.Value  = clsPhaentrevehicule.RV_DATESAISIE ;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhaentrevehicule.MS_NUMPIECE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsPhaentrevehicule.TI_IDTIERS ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaentrevehicule.AR_CODEARTICLE ;
			SqlParameter vppParamRV_DATEPROCHAINEVISITETECH = new SqlParameter("@RV_DATEPROCHAINEVISITETECH", SqlDbType.DateTime);
			vppParamRV_DATEPROCHAINEVISITETECH.Value  = clsPhaentrevehicule.RV_DATEPROCHAINEVISITETECH ;

            SqlParameter vppParamRV_DATEPROCHAINEVIDANGE = new SqlParameter("@RV_DATEPROCHAINEVIDANGE", SqlDbType.DateTime);
            vppParamRV_DATEPROCHAINEVIDANGE.Value = clsPhaentrevehicule.RV_DATEPROCHAINEVIDANGE;

			SqlParameter vppParamRV_DATEDEBUT = new SqlParameter("@RV_DATEDEBUT", SqlDbType.DateTime);
			vppParamRV_DATEDEBUT.Value  = clsPhaentrevehicule.RV_DATEDEBUT ;
			SqlParameter vppParamRV_DATEFIN = new SqlParameter("@RV_DATEFIN", SqlDbType.DateTime);
			vppParamRV_DATEFIN.Value  = clsPhaentrevehicule.RV_DATEFIN ;
			SqlParameter vppParamRV_DATECLOTURE = new SqlParameter("@RV_DATECLOTURE", SqlDbType.DateTime);
			vppParamRV_DATECLOTURE.Value  = clsPhaentrevehicule.RV_DATECLOTURE ;

            SqlParameter vppParamRV_COMPTEENTREPRISE = new SqlParameter("@RV_COMPTEENTREPRISE", SqlDbType.VarChar,1);
            vppParamRV_COMPTEENTREPRISE.Value = clsPhaentrevehicule.RV_COMPTEENTREPRISE;

            SqlParameter vppParamRV_COMPTEPARTICULIER = new SqlParameter("@RV_COMPTEPARTICULIER", SqlDbType.VarChar, 1);
            vppParamRV_COMPTEPARTICULIER.Value = clsPhaentrevehicule.RV_COMPTEPARTICULIER;

            SqlParameter vppParamRV_RECEPTEUR = new SqlParameter("@RV_RECEPTEUR", SqlDbType.VarChar, 150);
            vppParamRV_RECEPTEUR.Value = clsPhaentrevehicule.RV_RECEPTEUR;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhaentrevehicule.OP_CODEOPERATEUR;

			if(clsPhaentrevehicule.RV_DATECLOTURE.Year < 1900 ) vppParamRV_DATECLOTURE.Value  = DateTime.Parse("01/01/1900");
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAENTREVEHICULE  @AG_CODEAGENCE,@RV_IDENTREE, @RV_DATESAISIE, @MS_NUMPIECE, @TI_IDTIERS, @AR_CODEARTICLE, @RV_DATEPROCHAINEVISITETECH,@RV_DATEPROCHAINEVIDANGE, @RV_DATEDEBUT, @RV_DATEFIN, @RV_DATECLOTURE,@RV_COMPTEENTREPRISE,@RV_COMPTEPARTICULIER,@RV_RECEPTEUR,@OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRV_IDENTREE);
			vppSqlCmd.Parameters.Add(vppParamRV_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamRV_DATEPROCHAINEVISITETECH);
            vppSqlCmd.Parameters.Add(vppParamRV_DATEPROCHAINEVIDANGE);

			vppSqlCmd.Parameters.Add(vppParamRV_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamRV_DATEFIN);
			vppSqlCmd.Parameters.Add(vppParamRV_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamRV_COMPTEENTREPRISE);
            vppSqlCmd.Parameters.Add(vppParamRV_COMPTEPARTICULIER);
            vppSqlCmd.Parameters.Add(vppParamRV_RECEPTEUR);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaentrevehicule>clsPhaentrevehicule</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaentrevehicule clsPhaentrevehicule,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaentrevehicule.AG_CODEAGENCE;
			SqlParameter vppParamRV_IDENTREE = new SqlParameter("@RV_IDENTREE", SqlDbType.Decimal, 4);
			vppParamRV_IDENTREE.Value  = clsPhaentrevehicule.RV_IDENTREE ;
			SqlParameter vppParamRV_DATESAISIE = new SqlParameter("@RV_DATESAISIE", SqlDbType.DateTime);
			vppParamRV_DATESAISIE.Value  = clsPhaentrevehicule.RV_DATESAISIE ;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhaentrevehicule.MS_NUMPIECE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsPhaentrevehicule.TI_IDTIERS ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaentrevehicule.AR_CODEARTICLE ;
			SqlParameter vppParamRV_DATEPROCHAINEVISITETECH = new SqlParameter("@RV_DATEPROCHAINEVISITETECH", SqlDbType.DateTime);
			vppParamRV_DATEPROCHAINEVISITETECH.Value  = clsPhaentrevehicule.RV_DATEPROCHAINEVISITETECH ;

            SqlParameter vppParamRV_DATEPROCHAINEVIDANGE = new SqlParameter("@RV_DATEPROCHAINEVIDANGE", SqlDbType.DateTime);
            vppParamRV_DATEPROCHAINEVIDANGE.Value = clsPhaentrevehicule.RV_DATEPROCHAINEVIDANGE;

			SqlParameter vppParamRV_DATEDEBUT = new SqlParameter("@RV_DATEDEBUT", SqlDbType.DateTime);
			vppParamRV_DATEDEBUT.Value  = clsPhaentrevehicule.RV_DATEDEBUT ;
			SqlParameter vppParamRV_DATEFIN = new SqlParameter("@RV_DATEFIN", SqlDbType.DateTime);
			vppParamRV_DATEFIN.Value  = clsPhaentrevehicule.RV_DATEFIN ;
			SqlParameter vppParamRV_DATECLOTURE = new SqlParameter("@RV_DATECLOTURE", SqlDbType.DateTime);
			vppParamRV_DATECLOTURE.Value  = clsPhaentrevehicule.RV_DATECLOTURE ;
			if(clsPhaentrevehicule.RV_DATECLOTURE.Year < 1900 ) vppParamRV_DATECLOTURE.Value  = DateTime.Parse("01/01/1900");


            SqlParameter vppParamRV_COMPTEENTREPRISE = new SqlParameter("@RV_COMPTEENTREPRISE", SqlDbType.VarChar, 1);
            vppParamRV_COMPTEENTREPRISE.Value = clsPhaentrevehicule.RV_COMPTEENTREPRISE;

            SqlParameter vppParamRV_COMPTEPARTICULIER = new SqlParameter("@RV_COMPTEPARTICULIER", SqlDbType.VarChar, 1);
            vppParamRV_COMPTEPARTICULIER.Value = clsPhaentrevehicule.RV_COMPTEPARTICULIER;

            SqlParameter vppParamRV_RECEPTEUR = new SqlParameter("@RV_RECEPTEUR", SqlDbType.VarChar, 150);
            vppParamRV_RECEPTEUR.Value = clsPhaentrevehicule.RV_RECEPTEUR;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhaentrevehicule.OP_CODEOPERATEUR;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAENTREVEHICULE  @AG_CODEAGENCE,@RV_IDENTREE, @RV_DATESAISIE, @MS_NUMPIECE, @TI_IDTIERS, @AR_CODEARTICLE, @RV_DATEPROCHAINEVISITETECH, @RV_DATEPROCHAINEVIDANGE,@RV_DATEDEBUT, @RV_DATEFIN, @RV_DATECLOTURE,@RV_COMPTEENTREPRISE,@RV_COMPTEPARTICULIER,@RV_RECEPTEUR, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamRV_IDENTREE);
			vppSqlCmd.Parameters.Add(vppParamRV_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamRV_DATEPROCHAINEVISITETECH);
            vppSqlCmd.Parameters.Add(vppParamRV_DATEPROCHAINEVIDANGE);
			vppSqlCmd.Parameters.Add(vppParamRV_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamRV_DATEFIN);
			vppSqlCmd.Parameters.Add(vppParamRV_DATECLOTURE);

            vppSqlCmd.Parameters.Add(vppParamRV_COMPTEENTREPRISE);
            vppSqlCmd.Parameters.Add(vppParamRV_COMPTEPARTICULIER);
            vppSqlCmd.Parameters.Add(vppParamRV_RECEPTEUR);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);

			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAENTREVEHICULE  @AG_CODEAGENCE,@RV_IDENTREE, '' , @MS_NUMPIECE, @TI_IDTIERS, @AR_CODEARTICLE, '' ,'' , '' , '' , '' ,'' , '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaentrevehicule </returns>
		///<author>Home Technology</author>
		public List<clsPhaentrevehicule> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  RV_IDENTREE, RV_DATESAISIE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE, RV_DATEPROCHAINEVISITETECH,RV_DATEPROCHAINEVIDANGE, RV_DATEDEBUT, RV_DATEFIN, RV_DATECLOTURE FROM dbo.FT_PHAENTREVEHICULE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaentrevehicule> clsPhaentrevehicules = new List<clsPhaentrevehicule>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaentrevehicule clsPhaentrevehicule = new clsPhaentrevehicule();
					clsPhaentrevehicule.RV_IDENTREE = decimal.Parse(clsDonnee.vogDataReader["RV_IDENTREE"].ToString());
					clsPhaentrevehicule.RV_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["RV_DATESAISIE"].ToString());
					clsPhaentrevehicule.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhaentrevehicule.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhaentrevehicule.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaentrevehicule.RV_DATEPROCHAINEVISITETECH = DateTime.Parse(clsDonnee.vogDataReader["RV_DATEPROCHAINEVISITETECH"].ToString());
                    clsPhaentrevehicule.RV_DATEPROCHAINEVIDANGE = DateTime.Parse(clsDonnee.vogDataReader["RV_DATEPROCHAINEVIDANGE"].ToString());
					clsPhaentrevehicule.RV_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["RV_DATEDEBUT"].ToString());
					clsPhaentrevehicule.RV_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["RV_DATEFIN"].ToString());
					clsPhaentrevehicule.RV_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["RV_DATECLOTURE"].ToString());
					clsPhaentrevehicules.Add(clsPhaentrevehicule);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaentrevehicules;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaentrevehicule </returns>
		///<author>Home Technology</author>
		public List<clsPhaentrevehicule> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaentrevehicule> clsPhaentrevehicules = new List<clsPhaentrevehicule>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  RV_IDENTREE, RV_DATESAISIE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE, RV_DATEPROCHAINEVISITETECH,RV_DATEPROCHAINEVIDANGE, RV_DATEDEBUT, RV_DATEFIN, RV_DATECLOTURE FROM dbo.FT_PHAENTREVEHICULE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaentrevehicule clsPhaentrevehicule = new clsPhaentrevehicule();
					clsPhaentrevehicule.RV_IDENTREE = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RV_IDENTREE"].ToString());
					clsPhaentrevehicule.RV_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RV_DATESAISIE"].ToString());
					clsPhaentrevehicule.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhaentrevehicule.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsPhaentrevehicule.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaentrevehicule.RV_DATEPROCHAINEVISITETECH = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RV_DATEPROCHAINEVISITETECH"].ToString());
                    clsPhaentrevehicule.RV_DATEPROCHAINEVIDANGE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RV_DATEPROCHAINEVIDANGE"].ToString());
					clsPhaentrevehicule.RV_DATEDEBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RV_DATEDEBUT"].ToString());
					clsPhaentrevehicule.RV_DATEFIN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RV_DATEFIN"].ToString());
					clsPhaentrevehicule.RV_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RV_DATECLOTURE"].ToString());
					clsPhaentrevehicules.Add(clsPhaentrevehicule);
				}
				Dataset.Dispose();
			}
		return clsPhaentrevehicules;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAENTREVEHICULE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT RV_IDENTREE , RV_DATESAISIE FROM dbo.FT_PHAENTREVEHICULE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RV_IDENTREE, MS_NUMPIECE, TI_IDTIERS, AR_CODEARTICLE)</summary>
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
                this.vapCritere = " ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
                break;

				case 2 :
                this.vapCritere = "WHERE  MS_NUMPIECE=@MS_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE RV_IDENTREE=@RV_IDENTREE AND MS_NUMPIECE=@MS_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RV_IDENTREE", "@MS_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE RV_IDENTREE=@RV_IDENTREE AND MS_NUMPIECE=@MS_NUMPIECE AND TI_IDTIERS=@TI_IDTIERS";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RV_IDENTREE", "@MS_NUMPIECE", "@TI_IDTIERS" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE RV_IDENTREE=@RV_IDENTREE AND MS_NUMPIECE=@MS_NUMPIECE AND TI_IDTIERS=@TI_IDTIERS AND AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RV_IDENTREE", "@MS_NUMPIECE", "@TI_IDTIERS", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}
	}
}
