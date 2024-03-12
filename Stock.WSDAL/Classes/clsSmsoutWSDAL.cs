using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsSmsoutWSDAL: ITableDAL<clsSmsout>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.SMSOUT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.SMSOUT" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.SMSOUT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsSmsout comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsSmsout pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT CO_CODECOMPTE  , SM_MESSAGE  , SM_TELEPHONE  , SM_STATUT  FROM dbo.FT_SMSOUT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsSmsout clsSmsout = new clsSmsout();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSmsout.CO_CODECOMPTE = clsDonnee.vogDataReader["CO_CODECOMPTE"].ToString();
					clsSmsout.SM_MESSAGE = clsDonnee.vogDataReader["SM_MESSAGE"].ToString();
					clsSmsout.SM_TELEPHONE = clsDonnee.vogDataReader["SM_TELEPHONE"].ToString();
					clsSmsout.SM_STATUT = clsDonnee.vogDataReader["SM_STATUT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsSmsout;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSmsout>clsSmsout</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsSmsout clsSmsout)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 20);
			vppParamAG_CODEAGENCE.Value  = clsSmsout.AG_CODEAGENCE ;
			SqlParameter vppParamSM_DATEPIECE = new SqlParameter("@SM_DATEPIECE", SqlDbType.VarChar, 20);
			vppParamSM_DATEPIECE.Value  = clsSmsout.SM_DATEPIECE ;
			SqlParameter vppParamSM_NUMPIECE = new SqlParameter("@SM_NUMPIECE", SqlDbType.VarChar, 20);
			vppParamSM_NUMPIECE.Value  = clsSmsout.SM_NUMPIECE ;
			SqlParameter vppParamSM_NUMSEQUENCE = new SqlParameter("@SM_NUMSEQUENCE", SqlDbType.VarChar, 20);
			vppParamSM_NUMSEQUENCE.Value  = clsSmsout.SM_NUMSEQUENCE ;
			SqlParameter vppParamCO_CODECOMPTE = new SqlParameter("@CO_CODECOMPTE", SqlDbType.VarChar, 20);
			vppParamCO_CODECOMPTE.Value  = clsSmsout.CO_CODECOMPTE ;
			SqlParameter vppParamSM_MESSAGE = new SqlParameter("@SM_MESSAGE", SqlDbType.VarChar, 1000);
			vppParamSM_MESSAGE.Value  = clsSmsout.SM_MESSAGE ;
			SqlParameter vppParamSM_TELEPHONE = new SqlParameter("@SM_TELEPHONE", SqlDbType.VarChar, 1000);
			vppParamSM_TELEPHONE.Value  = clsSmsout.SM_TELEPHONE ;
			SqlParameter vppParamSM_STATUT = new SqlParameter("@SM_STATUT", SqlDbType.VarChar, 1);
			vppParamSM_STATUT.Value  = clsSmsout.SM_STATUT ;

      

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_SMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMSEQUENCE, '01/01/1900', '', '', '', '', @SM_MESSAGE, @SM_TELEPHONE, @SM_STATUT, @CODECRYPTAGE1, 0,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSM_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamSM_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamSM_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamSM_MESSAGE);
			vppSqlCmd.Parameters.Add(vppParamSM_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamSM_STATUT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSmsout>clsSmsout</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsSmsout clsSmsout,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 20);
			vppParamAG_CODEAGENCE.Value  = clsSmsout.AG_CODEAGENCE ;
			SqlParameter vppParamSM_DATEPIECE = new SqlParameter("@SM_DATEPIECE", SqlDbType.VarChar, 20);
			vppParamSM_DATEPIECE.Value  = clsSmsout.SM_DATEPIECE ;
			SqlParameter vppParamSM_NUMPIECE = new SqlParameter("@SM_NUMPIECE", SqlDbType.VarChar, 20);
			vppParamSM_NUMPIECE.Value  = clsSmsout.SM_NUMPIECE ;
			SqlParameter vppParamSM_NUMSEQUENCE = new SqlParameter("@SM_NUMSEQUENCE", SqlDbType.VarChar, 20);
			vppParamSM_NUMSEQUENCE.Value  = clsSmsout.SM_NUMSEQUENCE ;
			SqlParameter vppParamCO_CODECOMPTE = new SqlParameter("@CO_CODECOMPTE", SqlDbType.VarChar, 20);
			vppParamCO_CODECOMPTE.Value  = clsSmsout.CO_CODECOMPTE ;
			SqlParameter vppParamSM_MESSAGE = new SqlParameter("@SM_MESSAGE", SqlDbType.VarChar, 1000);
			vppParamSM_MESSAGE.Value  = clsSmsout.SM_MESSAGE ;
			SqlParameter vppParamSM_TELEPHONE = new SqlParameter("@SM_TELEPHONE", SqlDbType.VarChar, 1000);
			vppParamSM_TELEPHONE.Value  = clsSmsout.SM_TELEPHONE ;
			SqlParameter vppParamSM_STATUT = new SqlParameter("@SM_STATUT", SqlDbType.VarChar, 1);
			vppParamSM_STATUT.Value  = clsSmsout.SM_STATUT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_SMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMPIECE, @SM_NUMSEQUENCE, @CO_CODECOMPTE, @SM_MESSAGE, @SM_TELEPHONE, @SM_STATUT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSM_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamSM_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamSM_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamSM_MESSAGE);
			vppSqlCmd.Parameters.Add(vppParamSM_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamSM_STATUT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_SMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMPIECE, @SM_NUMSEQUENCE, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsout </returns>
		///<author>Home Technology</author>
		public List<clsSmsout> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE, CO_CODECOMPTE, SM_MESSAGE, SM_TELEPHONE, SM_STATUT FROM dbo.FT_SMSOUT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsSmsout> clsSmsouts = new List<clsSmsout>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSmsout clsSmsout = new clsSmsout();
					clsSmsout.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsSmsout.SM_DATEPIECE = clsDonnee.vogDataReader["SM_DATEPIECE"].ToString();
					clsSmsout.SM_NUMPIECE = clsDonnee.vogDataReader["SM_NUMPIECE"].ToString();
					clsSmsout.SM_NUMSEQUENCE = clsDonnee.vogDataReader["SM_NUMSEQUENCE"].ToString();
					clsSmsout.CO_CODECOMPTE = clsDonnee.vogDataReader["CO_CODECOMPTE"].ToString();
					clsSmsout.SM_MESSAGE = clsDonnee.vogDataReader["SM_MESSAGE"].ToString();
					clsSmsout.SM_TELEPHONE = clsDonnee.vogDataReader["SM_TELEPHONE"].ToString();
					clsSmsout.SM_STATUT = clsDonnee.vogDataReader["SM_STATUT"].ToString();
					clsSmsouts.Add(clsSmsout);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSmsouts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsout </returns>
		///<author>Home Technology</author>
		public List<clsSmsout> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSmsout> clsSmsouts = new List<clsSmsout>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE, CO_CODECOMPTE, SM_MESSAGE, SM_TELEPHONE, SM_STATUT FROM dbo.FT_SMSOUT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsSmsout clsSmsout = new clsSmsout();
					clsSmsout.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsSmsout.SM_DATEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["SM_DATEPIECE"].ToString();
					clsSmsout.SM_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["SM_NUMPIECE"].ToString();
					clsSmsout.SM_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["SM_NUMSEQUENCE"].ToString();
					clsSmsout.CO_CODECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMPTE"].ToString();
					clsSmsout.SM_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SM_MESSAGE"].ToString();
					clsSmsout.SM_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["SM_TELEPHONE"].ToString();
					clsSmsout.SM_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["SM_STATUT"].ToString();
					clsSmsouts.Add(clsSmsout);
				}
				Dataset.Dispose();
			}
		return clsSmsouts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_SMSOUT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , CO_CODECOMPTE FROM dbo.FT_SMSOUT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}






        public void pvgUpdateStatut(clsDonnee clsDonnee, clsSmsout clsSmsout, params string[] vppCritere)
        {
            //Préparation de la commande

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@SM_DATEPIECE", "@SM_NUMSEQUENCE", "@TE_CODESMSTYPEOPERATION", "@IN_CODEINSCRIPTION", "@SM_MESSAGE", "@SM_TELEPHONE", "@SM_STATUT", "@SM_DATESAISIE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { clsSmsout.AG_CODEAGENCE, clsSmsout.SM_DATEPIECE, clsSmsout.SM_NUMSEQUENCE, clsSmsout.TE_CODESMSTYPEOPERATION, clsSmsout.CO_CODECOMPTE, clsSmsout.SM_MESSAGE, clsSmsout.SM_TELEPHONE, clsSmsout.SM_STATUT, clsSmsout.SM_DATESAISIE, clsDonnee.vogCleCryptage };

            this.vapRequete = "EXECUTE PC_SMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE,  @SM_NUMSEQUENCE, @TE_CODESMSTYPEOPERATION, @IN_CODEINSCRIPTION, @SM_MESSAGE, @SM_TELEPHONE, @SM_STATUT,@SM_DATESAISIE, @CODECRYPTAGE, 3 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees via la procedure stockee PE_ACTIVITE </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsApisms">clsApisms</param>
        ///<returns>Une collection de clsApisms valeur du resultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<clsSmsout> pvgMobileSms(clsDonnee clsDonnee, clsParams clsParams)
        {




            List<clsSmsout> clsSmss = new List<clsSmsout>();
            DataSet Dataset = new DataSet();
            vapNomParametre = new string[] { "@LG_CODELANGUE", "@PV_CODEPOINTVENTE", "@CO_CODECOMPTE", "@CL_TELEPHONE", "@SM_RAISONNONENVOISMS", "@SL_MESSAGECLIENT", "@SM_DATEPIECE", "@LO_LOGICIEL", "@OB_NOMOBJET", "@EJ_IDEPARGNANTJOURNALIER", "@MB_IDTIERS", "@CL_IDCLIENT", "@TE_CODESMSTYPEOPERATION", "@SM_NUMSEQUENCE", "@SM_DATEEMISSIONSMS", "@MC_NUMPIECE", "@MC_NUMSEQUENCE", "@SM_STATUT", "@TYPEOPERATION", "@SL_LIBELLE1", "@SL_LIBELLE2", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { clsParams.LG_CODELANGUE, clsParams.PV_CODEPOINTVENTE, clsParams.CO_CODECOMPTE, clsParams.RECIPIENTPHONE, clsParams.SM_RAISONNONENVOISMS, clsParams.SMSTEXT, clsParams.SM_DATEPIECE, clsParams.LO_LOGICIEL, clsParams.OB_NOMOBJET, clsParams.EJ_IDEPARGNANTJOURNALIER, clsParams.MB_IDTIERS, clsParams.CL_IDCLIENT, clsParams.TE_CODESMSTYPEOPERATION, clsParams.SM_NUMSEQUENCE, clsParams.SM_DATEEMISSIONSMS, DBNull.Value, DBNull.Value, clsParams.SM_STATUT, clsParams.TYPEOPERATION, clsParams.SL_LIBELLE1, clsParams.SL_LIBELLE2, clsDonnee.vogCleCryptage };

            this.vapRequete = " EXEC PS_APISMS  @LG_CODELANGUE , @PV_CODEPOINTVENTE,@CO_CODECOMPTE,@CL_TELEPHONE,@SM_RAISONNONENVOISMS,@SL_MESSAGECLIENT,@SM_DATEPIECE,@LO_LOGICIEL,@OB_NOMOBJET,@EJ_IDEPARGNANTJOURNALIER,@MB_IDTIERS,@CL_IDCLIENT,@TE_CODESMSTYPEOPERATION,@SM_NUMSEQUENCE,@SM_DATEEMISSIONSMS,@MC_NUMPIECE,@MC_NUMSEQUENCE,@SM_STATUT ,@TYPEOPERATION, @SL_LIBELLE1,@SL_LIBELLE2,@CODECRYPTAGE";


            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);

            if (double.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {

                foreach (DataRow row in Dataset.Tables[0].Rows)
                {
                    clsSmsout clsSms = new clsSmsout();
                    //clsSms.CL_IDCLIENT = row["CL_IDCLIENT"].ToString();
                    //clsSms.CL_CODECLIENT = row["CL_CODECLIENT"].ToString();
                    //clsSms.AG_EMAIL = row["AG_EMAIL"].ToString();
                    //clsSms.AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                    clsSms.SL_RESULTAT = row["SL_RESULTAT"].ToString();
                    clsSms.SL_MESSAGE = row["SL_MESSAGE"].ToString();
                    clsSms.SM_TELEPHONE = row["CL_TELEPHONE"].ToString();
                    //clsSms.SL_MESSAGEOBJET = row["SL_OBJET"].ToString();
                    clsSms.SM_MESSAGE = row["SL_MESSAGECLIENT"].ToString();
                    clsSms.SM_DATEPIECE = row["SM_DATEPIECE"].ToString();
                    clsSms.SM_NUMSEQUENCE = row["SM_NUMSEQUENCERETOURS"].ToString();
                    clsSms.SL_MESSAGEOBJET = row["SL_MESSAGEOBJET"].ToString();
                    clsSms.AG_EMAIL = row["AG_EMAIL"].ToString();
                    clsSms.AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                    clsSmss.Add(clsSms);
                }

            }
            Dataset.Dispose();
            return clsSmss;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees via la procedure stockee PE_ACTIVITE </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsApisms">clsApisms</param>
        ///<returns>Une collection de clsApisms valeur du resultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<clsSmsout> pvgMobileSmsUpdateStatut(clsDonnee clsDonnee, string AG_CODEAGENCE, DateTime SM_DATEPIECE, DateTime SM_DATEEMISSIONSMS, string SM_NUMSEQUENCE, string SM_STATUT, string SM_RAISONNONENVOISMS)
        {
            List<clsSmsout> clsSmsouts = new List<clsSmsout>();
            DataSet Dataset = new DataSet();
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@SM_DATEPIECE", "@SM_DATEEMISSIONSMS", "@SM_NUMSEQUENCE", "@SM_STATUT", "@SM_RAISONNONENVOISMS", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { AG_CODEAGENCE, SM_DATEPIECE, SM_DATEEMISSIONSMS, SM_NUMSEQUENCE, SM_STATUT, SM_RAISONNONENVOISMS, clsDonnee.vogCleCryptage };

            this.vapRequete = " EXEC PS_MOBILESMSUPDATESTATUT  @AG_CODEAGENCE , @SM_DATEPIECE, @SM_DATEEMISSIONSMS, @SM_NUMSEQUENCE,@SM_STATUT,@SM_RAISONNONENVOISMS,@CODECRYPTAGE";


            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);

            if (double.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {

                foreach (DataRow row in Dataset.Tables[0].Rows)
                {
                    clsSmsout clsSmsout = new clsSmsout();
                    clsSmsout.SL_CODEMESSAGE = row["SL_CODEMESSAGE"].ToString();
                    clsSmsout.SL_RESULTAT = row["SL_RESULTAT"].ToString();
                    clsSmsout.SL_MESSAGE = row["SL_MESSAGE"].ToString();
                    clsSmsouts.Add(clsSmsout);
                }

            }
            Dataset.Dispose();
            return clsSmsouts;
        }






        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SM_DATEPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE AND SM_NUMPIECE=@SM_NUMPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SM_DATEPIECE","@SM_NUMPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE AND SM_NUMPIECE=@SM_NUMPIECE AND SM_NUMSEQUENCE=@SM_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SM_DATEPIECE","@SM_NUMPIECE","@SM_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
