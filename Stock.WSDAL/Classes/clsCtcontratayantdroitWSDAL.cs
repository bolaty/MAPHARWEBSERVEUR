using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratayantdroitWSDAL: ITableDAL<clsCtcontratayantdroit>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATAYANTDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATAYANTDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATAYANTDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratayantdroit comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratayantdroit pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , AY_DATECLOTURE  , TA_CODETITREAYANTDROIT  , OP_CODEOPERATEUR  FROM dbo.FT_CTCONTRATAYANTDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratayantdroit clsCtcontratayantdroit = new clsCtcontratayantdroit();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratayantdroit.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratayantdroit.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratayantdroit.AY_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AY_DATECLOTURE"].ToString());
					clsCtcontratayantdroit.TA_CODETITREAYANTDROIT = clsDonnee.vogDataReader["TA_CODETITREAYANTDROIT"].ToString();
					clsCtcontratayantdroit.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratayantdroit;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratayantdroit>clsCtcontratayantdroit</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratayantdroit clsCtcontratayantdroit)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratayantdroit.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT1", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratayantdroit.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT1", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratayantdroit.CA_CODECONTRAT ;
			SqlParameter vppParamAY_DENOMMINATIONAYANTDROIT = new SqlParameter("@AY_DENOMMINATIONAYANTDROIT", SqlDbType.VarChar, 1000);
			vppParamAY_DENOMMINATIONAYANTDROIT.Value  = clsCtcontratayantdroit.AY_DENOMMINATIONAYANTDROIT ;
			SqlParameter vppParamAY_DATESAISIE = new SqlParameter("@AY_DATESAISIE", SqlDbType.DateTime);
			vppParamAY_DATESAISIE.Value  = clsCtcontratayantdroit.AY_DATESAISIE ;
			SqlParameter vppParamAY_INDEX = new SqlParameter("@AY_INDEX", SqlDbType.VarChar, 25);
			vppParamAY_INDEX.Value  = clsCtcontratayantdroit.AY_INDEX ;
			SqlParameter vppParamAY_DATECLOTURE = new SqlParameter("@AY_DATECLOTURE", SqlDbType.DateTime);
			vppParamAY_DATECLOTURE.Value  = clsCtcontratayantdroit.AY_DATECLOTURE ;
			SqlParameter vppParamTA_CODETITREAYANTDROIT = new SqlParameter("@TA_CODETITREAYANTDROIT", SqlDbType.VarChar, 2);
			vppParamTA_CODETITREAYANTDROIT.Value  = clsCtcontratayantdroit.TA_CODETITREAYANTDROIT ;

            SqlParameter vppParamAY_TAUX = new SqlParameter("@AY_TAUX", SqlDbType.Float);
            vppParamAY_TAUX.Value = clsCtcontratayantdroit.AY_TAUX;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontratayantdroit.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATAYANTDROIT  @AG_CODEAGENCE1, @EN_CODEENTREPOT1, @CA_CODECONTRAT1, @AY_DENOMMINATIONAYANTDROIT, @AY_DATESAISIE, @AY_INDEX, @AY_DATECLOTURE, @TA_CODETITREAYANTDROIT,@AY_TAUX, @OP_CODEOPERATEUR, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamAY_DENOMMINATIONAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamAY_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAY_INDEX);
			vppSqlCmd.Parameters.Add(vppParamAY_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETITREAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamAY_TAUX);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratayantdroit>clsCtcontratayantdroit</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratayantdroit clsCtcontratayantdroit,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratayantdroit.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratayantdroit.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratayantdroit.CA_CODECONTRAT ;
			SqlParameter vppParamAY_DENOMMINATIONAYANTDROIT = new SqlParameter("@AY_DENOMMINATIONAYANTDROIT", SqlDbType.VarChar, 1000);
			vppParamAY_DENOMMINATIONAYANTDROIT.Value  = clsCtcontratayantdroit.AY_DENOMMINATIONAYANTDROIT ;
			SqlParameter vppParamAY_DATESAISIE = new SqlParameter("@AY_DATESAISIE", SqlDbType.DateTime);
			vppParamAY_DATESAISIE.Value  = clsCtcontratayantdroit.AY_DATESAISIE ;
			SqlParameter vppParamAY_INDEX = new SqlParameter("@AY_INDEX", SqlDbType.VarChar, 25);
			vppParamAY_INDEX.Value  = clsCtcontratayantdroit.AY_INDEX ;
			SqlParameter vppParamAY_DATECLOTURE = new SqlParameter("@AY_DATECLOTURE", SqlDbType.DateTime);
			vppParamAY_DATECLOTURE.Value  = clsCtcontratayantdroit.AY_DATECLOTURE ;
			SqlParameter vppParamTA_CODETITREAYANTDROIT = new SqlParameter("@TA_CODETITREAYANTDROIT", SqlDbType.VarChar, 2);
			vppParamTA_CODETITREAYANTDROIT.Value  = clsCtcontratayantdroit.TA_CODETITREAYANTDROIT ;

            SqlParameter vppParamAY_TAUX = new SqlParameter("@AY_TAUX", SqlDbType.Float);
            vppParamAY_TAUX.Value = clsCtcontratayantdroit.AY_TAUX;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontratayantdroit.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATAYANTDROIT  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT, @AY_DENOMMINATIONAYANTDROIT, @AY_DATESAISIE, @AY_INDEX, @AY_DATECLOTURE, @TA_CODETITREAYANTDROIT,@AY_TAUX, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamAY_DENOMMINATIONAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamAY_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAY_INDEX);
			vppSqlCmd.Parameters.Add(vppParamAY_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETITREAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamAY_TAUX);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATAYANTDROIT  @AG_CODEAGENCE, '' , @CA_CODECONTRAT, @AY_DENOMMINATIONAYANTDROIT, @AY_DATESAISIE, @AY_INDEX, '' , '' ,'0' , @OP_CODEOPERATEUR, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDeleteSelonCT(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CA_CODECONTRAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_CTCONTRATAYANTDROIT  @AG_CODEAGENCE, @EN_CODEENTREPOT , @CA_CODECONTRAT, '0', '01-01-1900','', '' , '' , '0', '',@CODECRYPTAGE, 3 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsCtcontratayantdroit </returns>
        ///<author>Home Technology</author>
        public List<clsCtcontratayantdroit> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, AY_DATECLOTURE, TA_CODETITREAYANTDROIT, OP_CODEOPERATEUR FROM dbo.FT_CTCONTRATAYANTDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratayantdroit> clsCtcontratayantdroits = new List<clsCtcontratayantdroit>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratayantdroit clsCtcontratayantdroit = new clsCtcontratayantdroit();
					clsCtcontratayantdroit.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratayantdroit.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratayantdroit.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratayantdroit.AY_DENOMMINATIONAYANTDROIT = clsDonnee.vogDataReader["AY_DENOMMINATIONAYANTDROIT"].ToString();
					clsCtcontratayantdroit.AY_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["AY_DATESAISIE"].ToString());
					clsCtcontratayantdroit.AY_INDEX = clsDonnee.vogDataReader["AY_INDEX"].ToString();
					clsCtcontratayantdroit.AY_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AY_DATECLOTURE"].ToString());
					clsCtcontratayantdroit.TA_CODETITREAYANTDROIT = clsDonnee.vogDataReader["TA_CODETITREAYANTDROIT"].ToString();
					clsCtcontratayantdroit.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtcontratayantdroits.Add(clsCtcontratayantdroit);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratayantdroits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratayantdroit </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratayantdroit> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratayantdroit> clsCtcontratayantdroits = new List<clsCtcontratayantdroit>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, AY_DATECLOTURE, TA_CODETITREAYANTDROIT, OP_CODEOPERATEUR FROM dbo.FT_CTCONTRATAYANTDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratayantdroit clsCtcontratayantdroit = new clsCtcontratayantdroit();
					clsCtcontratayantdroit.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratayantdroit.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratayantdroit.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratayantdroit.AY_DENOMMINATIONAYANTDROIT = Dataset.Tables["TABLE"].Rows[Idx]["AY_DENOMMINATIONAYANTDROIT"].ToString();
					clsCtcontratayantdroit.AY_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AY_DATESAISIE"].ToString());
					clsCtcontratayantdroit.AY_INDEX = Dataset.Tables["TABLE"].Rows[Idx]["AY_INDEX"].ToString();
					clsCtcontratayantdroit.AY_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AY_DATECLOTURE"].ToString());
					clsCtcontratayantdroit.TA_CODETITREAYANTDROIT = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETITREAYANTDROIT"].ToString();
					clsCtcontratayantdroit.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtcontratayantdroits.Add(clsCtcontratayantdroit);
				}
				Dataset.Dispose();
			}
		return clsCtcontratayantdroits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTCONTRATAYANTDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CA_CODECONTRAT , EN_CODEENTREPOT FROM dbo.FT_CTCONTRATAYANTDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CA_CODECONTRAT, AY_DENOMMINATIONAYANTDROIT, AY_DATESAISIE, AY_INDEX, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@CA_CODECONTRAT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@EN_CODEENTREPOT","@CA_CODECONTRAT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT AND AY_DENOMMINATIONAYANTDROIT=@AY_DENOMMINATIONAYANTDROIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@EN_CODEENTREPOT","@CA_CODECONTRAT", "@AY_DENOMMINATIONAYANTDROIT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;


				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CA_CODECONTRAT=@CA_CODECONTRAT AND AY_DENOMMINATIONAYANTDROIT=@AY_DENOMMINATIONAYANTDROIT AND AY_DATESAISIE=@AY_DATESAISIE AND AY_INDEX=@AY_INDEX";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CA_CODECONTRAT","@AY_DENOMMINATIONAYANTDROIT","@AY_DATESAISIE","@AY_INDEX"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CA_CODECONTRAT=@CA_CODECONTRAT AND AY_DENOMMINATIONAYANTDROIT=@AY_DENOMMINATIONAYANTDROIT AND AY_DATESAISIE=@AY_DATESAISIE AND AY_INDEX=@AY_INDEX AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CA_CODECONTRAT","@AY_DENOMMINATIONAYANTDROIT","@AY_DATESAISIE","@AY_INDEX","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
