using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratdemandecreationWSDAL: ITableDAL<clsCtcontratdemandecreation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(DE_CODEDEMANADE) AS DE_CODEDEMANADE  FROM dbo.FT_CTCONTRATDEMANDECREATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(DE_CODEDEMANADE) AS DE_CODEDEMANADE  FROM dbo.FT_CTCONTRATDEMANDECREATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(DE_CODEDEMANADE) AS DE_CODEDEMANADE  FROM dbo.FT_CTCONTRATDEMANDECREATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratdemandecreation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratdemandecreation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , DE_DATESAISIE  , DE_DATEVALIDATION  , RQ_CODERISQUE  , TI_IDTIERSASSUREUR  , TI_IDTIERS  , CA_CODECONTRAT  FROM dbo.FT_CTCONTRATDEMANDECREATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratdemandecreation clsCtcontratdemandecreation = new clsCtcontratdemandecreation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratdemandecreation.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratdemandecreation.DE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["DE_DATESAISIE"].ToString());
					clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["DE_DATEVALIDATION"].ToString());
					clsCtcontratdemandecreation.RQ_CODERISQUE = clsDonnee.vogDataReader["RQ_CODERISQUE"].ToString();
					clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = clsDonnee.vogDataReader["TI_IDTIERSASSUREUR"].ToString();
					clsCtcontratdemandecreation.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsCtcontratdemandecreation.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratdemandecreation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratdemandecreation>clsCtcontratdemandecreation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratdemandecreation clsCtcontratdemandecreation)
		{
			//Préparation des paramètres
			SqlParameter vppParamDE_CODEDEMANADE = new SqlParameter("@DE_CODEDEMANADE", SqlDbType.VarChar, 50);
			vppParamDE_CODEDEMANADE.Value  = clsCtcontratdemandecreation.DE_CODEDEMANADE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratdemandecreation.AG_CODEAGENCE ;
			SqlParameter vppParamDE_DATESAISIE = new SqlParameter("@DE_DATESAISIE", SqlDbType.DateTime);
			vppParamDE_DATESAISIE.Value  = clsCtcontratdemandecreation.DE_DATESAISIE ;
			SqlParameter vppParamDE_DATEVALIDATION = new SqlParameter("@DE_DATEVALIDATION", SqlDbType.DateTime);
			vppParamDE_DATEVALIDATION.Value  = clsCtcontratdemandecreation.DE_DATEVALIDATION ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtcontratdemandecreation.RQ_CODERISQUE ;
			SqlParameter vppParamTI_IDTIERSASSUREUR = new SqlParameter("@TI_IDTIERSASSUREUR", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSASSUREUR.Value  = clsCtcontratdemandecreation.TI_IDTIERSASSUREUR ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERS.Value  = clsCtcontratdemandecreation.TI_IDTIERS ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratdemandecreation.CA_CODECONTRAT ;
			if(clsCtcontratdemandecreation.CA_CODECONTRAT== ""  ) vppParamCA_CODECONTRAT.Value  = DBNull.Value;

            SqlParameter vppParamDE_DATEANNULATION = new SqlParameter("@DE_DATEANNULATION", SqlDbType.DateTime);
            vppParamDE_DATEANNULATION.Value = clsCtcontratdemandecreation.DE_DATEANNULATION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATDEMANDECREATION  @DE_CODEDEMANADE, @AG_CODEAGENCE, @DE_DATESAISIE, @DE_DATEVALIDATION, @RQ_CODERISQUE, @TI_IDTIERSASSUREUR, @TI_IDTIERS, @CA_CODECONTRAT,@DE_DATEANNULATION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDE_CODEDEMANADE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamDE_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamDE_DATEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamDE_DATEANNULATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratdemandecreation>clsCtcontratdemandecreation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratdemandecreation clsCtcontratdemandecreation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDE_CODEDEMANADE = new SqlParameter("@DE_CODEDEMANADE", SqlDbType.VarChar, 50);
			vppParamDE_CODEDEMANADE.Value  = clsCtcontratdemandecreation.DE_CODEDEMANADE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratdemandecreation.AG_CODEAGENCE ;
			SqlParameter vppParamDE_DATESAISIE = new SqlParameter("@DE_DATESAISIE", SqlDbType.DateTime);
			vppParamDE_DATESAISIE.Value  = clsCtcontratdemandecreation.DE_DATESAISIE ;
			SqlParameter vppParamDE_DATEVALIDATION = new SqlParameter("@DE_DATEVALIDATION", SqlDbType.DateTime);
			vppParamDE_DATEVALIDATION.Value  = clsCtcontratdemandecreation.DE_DATEVALIDATION ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtcontratdemandecreation.RQ_CODERISQUE ;
			SqlParameter vppParamTI_IDTIERSASSUREUR = new SqlParameter("@TI_IDTIERSASSUREUR", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSASSUREUR.Value  = clsCtcontratdemandecreation.TI_IDTIERSASSUREUR ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERS.Value  = clsCtcontratdemandecreation.TI_IDTIERS ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratdemandecreation.CA_CODECONTRAT ;
			if(clsCtcontratdemandecreation.CA_CODECONTRAT== ""  ) vppParamCA_CODECONTRAT.Value  = DBNull.Value;

            SqlParameter vppParamDE_DATEANNULATION = new SqlParameter("@DE_DATEANNULATION", SqlDbType.DateTime);
            vppParamDE_DATEANNULATION.Value = clsCtcontratdemandecreation.DE_DATEANNULATION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATDEMANDECREATION  @DE_CODEDEMANADE, @AG_CODEAGENCE, @DE_DATESAISIE, @DE_DATEVALIDATION, @RQ_CODERISQUE, @TI_IDTIERSASSUREUR, @TI_IDTIERS, @CA_CODECONTRAT, @DE_DATEANNULATION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDE_CODEDEMANADE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamDE_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamDE_DATEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamDE_DATEANNULATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratdemandecreation>clsCtcontratdemandecreation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdateAnnulationDemande(clsDonnee clsDonnee, clsCtcontratdemandecreation clsCtcontratdemandecreation, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamDE_CODEDEMANADE = new SqlParameter("@DE_CODEDEMANADE", SqlDbType.VarChar, 50);
            vppParamDE_CODEDEMANADE.Value = clsCtcontratdemandecreation.DE_CODEDEMANADE;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsCtcontratdemandecreation.AG_CODEAGENCE;
            SqlParameter vppParamDE_DATESAISIE = new SqlParameter("@DE_DATESAISIE", SqlDbType.DateTime);
            vppParamDE_DATESAISIE.Value = clsCtcontratdemandecreation.DE_DATESAISIE;
            SqlParameter vppParamDE_DATEVALIDATION = new SqlParameter("@DE_DATEVALIDATION", SqlDbType.DateTime);
            vppParamDE_DATEVALIDATION.Value = clsCtcontratdemandecreation.DE_DATEVALIDATION;

            SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
            vppParamRQ_CODERISQUE.Value = clsCtcontratdemandecreation.RQ_CODERISQUE;
            SqlParameter vppParamTI_IDTIERSASSUREUR = new SqlParameter("@TI_IDTIERSASSUREUR", SqlDbType.VarChar, 25);
            vppParamTI_IDTIERSASSUREUR.Value = clsCtcontratdemandecreation.TI_IDTIERSASSUREUR;
            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
            vppParamTI_IDTIERS.Value = clsCtcontratdemandecreation.TI_IDTIERS;
            SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
            vppParamCA_CODECONTRAT.Value = clsCtcontratdemandecreation.CA_CODECONTRAT;
            if (clsCtcontratdemandecreation.CA_CODECONTRAT == "") vppParamCA_CODECONTRAT.Value = DBNull.Value;

            SqlParameter vppParamDE_DATEANNULATION = new SqlParameter("@DE_DATEANNULATION", SqlDbType.DateTime);
            vppParamDE_DATEANNULATION.Value = clsCtcontratdemandecreation.DE_DATEANNULATION;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 50);
            vppParamTYPEOPERATION.Value = clsCtcontratdemandecreation.TYPEOPERATION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_CTCONTRATDEMANDECREATION  @DE_CODEDEMANADE, @AG_CODEAGENCE, @DE_DATESAISIE, @DE_DATEVALIDATION, @RQ_CODERISQUE, @TI_IDTIERSASSUREUR, @TI_IDTIERS, @CA_CODECONTRAT, @DE_DATEANNULATION, @CODECRYPTAGE, @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamDE_CODEDEMANADE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamDE_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamDE_DATEVALIDATION);
            vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSASSUREUR);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
            vppSqlCmd.Parameters.Add(vppParamDE_DATEANNULATION);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATDEMANDECREATION  @DE_CODEDEMANADE, @AG_CODEAGENCE, '' , '' , '' , '' , '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratdemandecreation </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratdemandecreation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DE_CODEDEMANADE, AG_CODEAGENCE, DE_DATESAISIE, DE_DATEVALIDATION, RQ_CODERISQUE, TI_IDTIERSASSUREUR, TI_IDTIERS, CA_CODECONTRAT FROM dbo.FT_CTCONTRATDEMANDECREATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<clsCtcontratdemandecreation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratdemandecreation clsCtcontratdemandecreation = new clsCtcontratdemandecreation();
					clsCtcontratdemandecreation.DE_CODEDEMANADE = clsDonnee.vogDataReader["DE_CODEDEMANADE"].ToString();
					clsCtcontratdemandecreation.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratdemandecreation.DE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["DE_DATESAISIE"].ToString());
					clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["DE_DATEVALIDATION"].ToString());
					clsCtcontratdemandecreation.RQ_CODERISQUE = clsDonnee.vogDataReader["RQ_CODERISQUE"].ToString();
					clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = clsDonnee.vogDataReader["TI_IDTIERSASSUREUR"].ToString();
					clsCtcontratdemandecreation.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsCtcontratdemandecreation.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratdemandecreations.Add(clsCtcontratdemandecreation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratdemandecreations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratdemandecreation </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratdemandecreation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<clsCtcontratdemandecreation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DE_CODEDEMANADE, AG_CODEAGENCE, DE_DATESAISIE, DE_DATEVALIDATION, RQ_CODERISQUE, TI_IDTIERSASSUREUR, TI_IDTIERS, CA_CODECONTRAT FROM dbo.FT_CTCONTRATDEMANDECREATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratdemandecreation clsCtcontratdemandecreation = new clsCtcontratdemandecreation();
					clsCtcontratdemandecreation.DE_CODEDEMANADE = Dataset.Tables["TABLE"].Rows[Idx]["DE_CODEDEMANADE"].ToString();
					clsCtcontratdemandecreation.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratdemandecreation.DE_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["DE_DATESAISIE"].ToString());
					clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["DE_DATEVALIDATION"].ToString());
					clsCtcontratdemandecreation.RQ_CODERISQUE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODERISQUE"].ToString();
					clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSASSUREUR"].ToString();
					clsCtcontratdemandecreation.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsCtcontratdemandecreation.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratdemandecreations.Add(clsCtcontratdemandecreation);
				}
				Dataset.Dispose();
			}
		return clsCtcontratdemandecreations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DATEDEBUT", "@DATEFIN", "@RQ_CODERISQUE", "@TI_NUMTIERS", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC [dbo].[PS_CTCONTRATDEMANDECREATION] @AG_CODEAGENCE,@DATEDEBUT,@DATEFIN,@RQ_CODERISQUE,@TI_NUMTIERS,@TYPEOPERATION,@CODECRYPTAGE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : DE_CODEDEMANADE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DE_CODEDEMANADE , DE_DATESAISIE FROM dbo.FT_CTCONTRATDEMANDECREATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :DE_CODEDEMANADE, AG_CODEAGENCE)</summary>
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
				this.vapCritere ="WHERE DE_CODEDEMANADE=@DE_CODEDEMANADE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DE_CODEDEMANADE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE DE_CODEDEMANADE=@DE_CODEDEMANADE AND AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DE_CODEDEMANADE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
