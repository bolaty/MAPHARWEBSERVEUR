using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockreglementrepartitionWSDAL: ITableDAL<clsPhamouvementstockreglementrepartition>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MV_NUMPIECE) AS MV_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTREPARTITION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MV_NUMPIECE) AS MV_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTREPARTITION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MV_NUMPIECE) AS MV_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTREPARTITION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglementrepartition comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglementrepartition pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT TA_CODETYPEARTICLE  , NA_CODENATUREOPERATION  , RP_MONTANTDEBIT  , RP_MONTANTCREDIT  , RP_ANNULATIONPIECE  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTREPARTITION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockreglementrepartition clsPhamouvementstockreglementrepartition = new clsPhamouvementstockreglementrepartition();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementrepartition.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
					clsPhamouvementstockreglementrepartition.NA_CODENATUREOPERATION = clsDonnee.vogDataReader["NA_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockreglementrepartition.RP_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["RP_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglementrepartition.RP_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["RP_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglementrepartition.RP_ANNULATIONPIECE = clsDonnee.vogDataReader["RP_ANNULATIONPIECE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockreglementrepartition;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementrepartition>clsPhamouvementstockreglementrepartition</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockreglementrepartition clsPhamouvementstockreglementrepartition)
		{
			//Préparation des paramètres

            //private string _AG_CODEAGENCE = "";
            //private DateTime _RP_DATEREPARTION = DateTime.Parse("01/01/1900");
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglementrepartition.AG_CODEAGENCE;

            SqlParameter vppParamRP_DATEREPARTION = new SqlParameter("@RP_DATEREPARTION", SqlDbType.DateTime);
            vppParamRP_DATEREPARTION.Value = clsPhamouvementstockreglementrepartition.RP_DATEREPARTION;


			SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMV_NUMPIECE.Value  = clsPhamouvementstockreglementrepartition.MV_NUMPIECE ;
			SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 5);
			vppParamTA_CODETYPEARTICLE.Value  = clsPhamouvementstockreglementrepartition.TA_CODETYPEARTICLE ;
			SqlParameter vppParamNA_CODENATUREOPERATION = new SqlParameter("@NA_CODENATUREOPERATION", SqlDbType.VarChar,5);
			vppParamNA_CODENATUREOPERATION.Value  = clsPhamouvementstockreglementrepartition.NA_CODENATUREOPERATION ;
			SqlParameter vppParamRP_MONTANTDEBIT = new SqlParameter("@RP_MONTANTDEBIT", SqlDbType.Money);
			vppParamRP_MONTANTDEBIT.Value  = clsPhamouvementstockreglementrepartition.RP_MONTANTDEBIT ;
			SqlParameter vppParamRP_MONTANTCREDIT = new SqlParameter("@RP_MONTANTCREDIT", SqlDbType.Money);
			vppParamRP_MONTANTCREDIT.Value  = clsPhamouvementstockreglementrepartition.RP_MONTANTCREDIT ;
			SqlParameter vppParamRP_ANNULATIONPIECE = new SqlParameter("@RP_ANNULATIONPIECE", SqlDbType.VarChar, 1);
			vppParamRP_ANNULATIONPIECE.Value  = clsPhamouvementstockreglementrepartition.RP_ANNULATIONPIECE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTREPARTITION  @AG_CODEAGENCE,@RP_DATEREPARTION,@MV_NUMPIECE, @TA_CODETYPEARTICLE, @NA_CODENATUREOPERATION, @RP_MONTANTDEBIT, @RP_MONTANTCREDIT, @RP_ANNULATIONPIECE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamRP_DATEREPARTION);
			vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamNA_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamRP_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamRP_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamRP_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementrepartition>clsPhamouvementstockreglementrepartition</param>
		///<author>Home Technology</author>
		public void pvgInsertTEMP(clsDonnee clsDonnee, clsPhamouvementstockreglementrepartition clsPhamouvementstockreglementrepartition)
        {
            //Préparation des paramètres

            //private string _AG_CODEAGENCE = "";
            //private DateTime _RP_DATEREPARTION = DateTime.Parse("01/01/1900");
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglementrepartition.AG_CODEAGENCE;

            SqlParameter vppParamRP_DATEREPARTION = new SqlParameter("@RP_DATEREPARTION", SqlDbType.DateTime);
            vppParamRP_DATEREPARTION.Value = clsPhamouvementstockreglementrepartition.RP_DATEREPARTION;


            SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMPIECE.Value = clsPhamouvementstockreglementrepartition.MV_NUMPIECE;
            SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 5);
            vppParamTA_CODETYPEARTICLE.Value = clsPhamouvementstockreglementrepartition.TA_CODETYPEARTICLE;
            SqlParameter vppParamNA_CODENATUREOPERATION = new SqlParameter("@NA_CODENATUREOPERATION", SqlDbType.VarChar, 5);
            vppParamNA_CODENATUREOPERATION.Value = clsPhamouvementstockreglementrepartition.NA_CODENATUREOPERATION;
            SqlParameter vppParamRP_MONTANTDEBIT = new SqlParameter("@RP_MONTANTDEBIT", SqlDbType.Money);
            vppParamRP_MONTANTDEBIT.Value = clsPhamouvementstockreglementrepartition.RP_MONTANTDEBIT;
            SqlParameter vppParamRP_MONTANTCREDIT = new SqlParameter("@RP_MONTANTCREDIT", SqlDbType.Money);
            vppParamRP_MONTANTCREDIT.Value = clsPhamouvementstockreglementrepartition.RP_MONTANTCREDIT;
            SqlParameter vppParamRP_ANNULATIONPIECE = new SqlParameter("@RP_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamRP_ANNULATIONPIECE.Value = clsPhamouvementstockreglementrepartition.RP_ANNULATIONPIECE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTREPARTITIONTEMP  @AG_CODEAGENCE,@RP_DATEREPARTION,@MV_NUMPIECE, @TA_CODETYPEARTICLE, @NA_CODENATUREOPERATION, @RP_MONTANTDEBIT, @RP_MONTANTCREDIT, @RP_ANNULATIONPIECE, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamRP_DATEREPARTION);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamNA_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamRP_MONTANTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamRP_MONTANTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamRP_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglementrepartition>clsPhamouvementstockreglementrepartition</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockreglementrepartition clsPhamouvementstockreglementrepartition,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglementrepartition.AG_CODEAGENCE;

            SqlParameter vppParamRP_DATEREPARTION = new SqlParameter("@RP_DATEREPARTION", SqlDbType.DateTime);
            vppParamRP_DATEREPARTION.Value = clsPhamouvementstockreglementrepartition.RP_DATEREPARTION;
			SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMV_NUMPIECE.Value  = clsPhamouvementstockreglementrepartition.MV_NUMPIECE ;
			SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 5);
			vppParamTA_CODETYPEARTICLE.Value  = clsPhamouvementstockreglementrepartition.TA_CODETYPEARTICLE ;
			SqlParameter vppParamNA_CODENATUREOPERATION = new SqlParameter("@NA_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNA_CODENATUREOPERATION.Value  = clsPhamouvementstockreglementrepartition.NA_CODENATUREOPERATION ;
			SqlParameter vppParamRP_MONTANTDEBIT = new SqlParameter("@RP_MONTANTDEBIT", SqlDbType.Money);
			vppParamRP_MONTANTDEBIT.Value  = clsPhamouvementstockreglementrepartition.RP_MONTANTDEBIT ;
			SqlParameter vppParamRP_MONTANTCREDIT = new SqlParameter("@RP_MONTANTCREDIT", SqlDbType.Money);
			vppParamRP_MONTANTCREDIT.Value  = clsPhamouvementstockreglementrepartition.RP_MONTANTCREDIT ;
			SqlParameter vppParamRP_ANNULATIONPIECE = new SqlParameter("@RP_ANNULATIONPIECE", SqlDbType.VarChar, 1);
			vppParamRP_ANNULATIONPIECE.Value  = clsPhamouvementstockreglementrepartition.RP_ANNULATIONPIECE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTREPARTITION  @AG_CODEAGENCE,@RP_DATEREPARTION,@MV_NUMPIECE, @TA_CODETYPEARTICLE, @NA_CODENATUREOPERATION, @RP_MONTANTDEBIT, @RP_MONTANTCREDIT, @RP_ANNULATIONPIECE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamRP_DATEREPARTION);
			vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamNA_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamRP_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamRP_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamRP_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTREPARTITION  @AG_CODEAGENCE,'01/01/1900',@MV_NUMPIECE, @TA_CODETYPEARTICLE, '', 0, 0, '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDeleteTEMP(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] {  "@AG_CODEAGENCE", "@MV_DATEPIECE", "@MV_NUMEROPIECE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] };
            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_PHAMOUVEMENTSTOCKREGLEMENTREPARTITIONTEMP  @AG_CODEAGENCE,@MV_DATEPIECE,@MV_NUMEROPIECE,@OP_CODEOPERATEUR";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsPhamouvementstockreglementrepartition </returns>
        ///<author>Home Technology</author>
        public List<clsPhamouvementstockreglementrepartition> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION, RP_MONTANTDEBIT, RP_MONTANTCREDIT, RP_ANNULATIONPIECE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTREPARTITION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions = new List<clsPhamouvementstockreglementrepartition>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementrepartition clsPhamouvementstockreglementrepartition = new clsPhamouvementstockreglementrepartition();
					clsPhamouvementstockreglementrepartition.MV_NUMPIECE = clsDonnee.vogDataReader["MV_NUMPIECE"].ToString();
					clsPhamouvementstockreglementrepartition.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
					clsPhamouvementstockreglementrepartition.NA_CODENATUREOPERATION = clsDonnee.vogDataReader["NA_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockreglementrepartition.RP_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["RP_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglementrepartition.RP_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["RP_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglementrepartition.RP_ANNULATIONPIECE = clsDonnee.vogDataReader["RP_ANNULATIONPIECE"].ToString();
					clsPhamouvementstockreglementrepartitions.Add(clsPhamouvementstockreglementrepartition);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockreglementrepartitions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementrepartition </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementrepartition> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions = new List<clsPhamouvementstockreglementrepartition>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION, RP_MONTANTDEBIT, RP_MONTANTCREDIT, RP_ANNULATIONPIECE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTREPARTITION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockreglementrepartition clsPhamouvementstockreglementrepartition = new clsPhamouvementstockreglementrepartition();
					clsPhamouvementstockreglementrepartition.MV_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MV_NUMPIECE"].ToString();
					clsPhamouvementstockreglementrepartition.TA_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEARTICLE"].ToString();
					clsPhamouvementstockreglementrepartition.NA_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NA_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockreglementrepartition.RP_MONTANTDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RP_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglementrepartition.RP_MONTANTCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RP_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglementrepartition.RP_ANNULATIONPIECE = Dataset.Tables["TABLE"].Rows[Idx]["RP_ANNULATIONPIECE"].ToString();
					clsPhamouvementstockreglementrepartitions.Add(clsPhamouvementstockreglementrepartition);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockreglementrepartitions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTREPARTITION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MV_NUMPIECE , RP_MONTANTDEBIT FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTREPARTITION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MV_NUMPIECE, TA_CODETYPEARTICLE, NA_CODENATUREOPERATION)</summary>
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
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MV_NUMPIECE=@MV_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MV_NUMPIECE=@MV_NUMPIECE AND TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_NUMPIECE", "@TA_CODETYPEARTICLE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;

                case 4 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MV_NUMPIECE=@MV_NUMPIECE AND TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE AND NA_CODENATUREOPERATION=@NA_CODENATUREOPERATION";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_NUMPIECE", "@TA_CODETYPEARTICLE", "@NA_CODENATUREOPERATION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;

				
			}
		}
	}
}
