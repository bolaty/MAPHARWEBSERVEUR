using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCampangeagricoleWSDAL: ITableDAL<clsCampangeagricole>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(CA_CODECAMPAGNE) AS CA_CODECAMPAGNE  FROM dbo.CAMPAGNEAGRICOLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(CA_CODECAMPAGNE) AS CA_CODECAMPAGNE  FROM dbo.CAMPAGNEAGRICOLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(CA_CODECAMPAGNE) AS CA_CODECAMPAGNE  FROM dbo.CAMPAGNEAGRICOLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteAnneeEncours(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] {"@AG_CODEAGENCE" };
            vapValeurParametre = new object[] {vppCritere[0] };
            this.vapRequete = "EXEC [dbo].[PS_CAMPAGNECOURS] @AG_CODEAGENCE ";// +this.vapCritere + " ORDER BY CA_DATEDEBUT DESC";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCampangeagricole comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCampangeagricole pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , CA_LIBELLEANNEEDEBUT  , CA_DATEDEBUT  , CA_DATECLOTURE  , CA_LIBELLEANNEEFIN  FROM dbo.FT_CAMPAGNEAGRICOLE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCampangeagricole clsCampangeagricole = new clsCampangeagricole();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCampangeagricole.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCampangeagricole.CA_LIBELLEANNEEDEBUT = double.Parse(clsDonnee.vogDataReader["CA_LIBELLEANNEEDEBUT"].ToString());
					clsCampangeagricole.CA_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEDEBUT"].ToString());
					clsCampangeagricole.CA_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["CA_DATECLOTURE"].ToString());
                    clsCampangeagricole.CA_LIBELLEANNEEFIN = double.Parse(clsDonnee.vogDataReader["CA_LIBELLEANNEEFIN"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCampangeagricole;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCampangeagricole>clsCampangeagricole</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCampangeagricole clsCampangeagricole)
		{
			//Préparation des paramètres
			SqlParameter vppParamCA_CODECAMPAGNE = new SqlParameter("@CA_CODECAMPAGNE", SqlDbType.VarChar, 25);
			vppParamCA_CODECAMPAGNE.Value  = clsCampangeagricole.CA_CODECAMPAGNE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCampangeagricole.AG_CODEAGENCE ;
			SqlParameter vppParamCA_LIBELLEANNEEDEBUT = new SqlParameter("@CA_LIBELLEANNEEDEBUT", SqlDbType.Int);
			vppParamCA_LIBELLEANNEEDEBUT.Value  = clsCampangeagricole.CA_LIBELLEANNEEDEBUT ;
			SqlParameter vppParamCA_DATEDEBUT = new SqlParameter("@CA_DATEDEBUT", SqlDbType.DateTime);
			vppParamCA_DATEDEBUT.Value  = clsCampangeagricole.CA_DATEDEBUT ;
			SqlParameter vppParamCA_DATECLOTURE = new SqlParameter("@CA_DATECLOTURE", SqlDbType.DateTime);
			vppParamCA_DATECLOTURE.Value  = clsCampangeagricole.CA_DATECLOTURE ;
			SqlParameter vppParamCA_LIBELLEANNEEFIN = new SqlParameter("@CA_LIBELLEANNEEFIN", SqlDbType.Int);
			vppParamCA_LIBELLEANNEEFIN.Value  = clsCampangeagricole.CA_LIBELLEANNEEFIN ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CAMPAGNEAGRICOLE  @CA_CODECAMPAGNE, @AG_CODEAGENCE, @CA_LIBELLEANNEEDEBUT, @CA_DATEDEBUT, @CA_DATECLOTURE, @CA_LIBELLEANNEEFIN, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCA_CODECAMPAGNE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCA_LIBELLEANNEEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamCA_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamCA_LIBELLEANNEEFIN);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        public void pvgMiseaJour(clsDonnee clsDonnee, clsCampangeagricole clsCampangeagricole)
        {
            //Préparation des paramètres
            SqlParameter vppParamCA_CODECAMPAGNE = new SqlParameter("@CA_CODECAMPAGNE", SqlDbType.VarChar, 25);
            vppParamCA_CODECAMPAGNE.Value = clsCampangeagricole.CA_CODECAMPAGNE;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
            vppParamAG_CODEAGENCE.Value = clsCampangeagricole.AG_CODEAGENCE;
            SqlParameter vppParamCA_LIBELLEANNEEDEBUT = new SqlParameter("@CA_LIBELLEANNEEDEBUT", SqlDbType.Int);
            vppParamCA_LIBELLEANNEEDEBUT.Value = clsCampangeagricole.CA_LIBELLEANNEEDEBUT;
            SqlParameter vppParamCA_DATEDEBUT = new SqlParameter("@CA_DATEDEBUT", SqlDbType.DateTime);
            vppParamCA_DATEDEBUT.Value = clsCampangeagricole.CA_DATEDEBUT;
            SqlParameter vppParamCA_DATECLOTURE = new SqlParameter("@CA_DATECLOTURE", SqlDbType.DateTime);
            vppParamCA_DATECLOTURE.Value = clsCampangeagricole.CA_DATECLOTURE;
            SqlParameter vppParamCA_LIBELLEANNEEFIN = new SqlParameter("@CA_LIBELLEANNEEFIN", SqlDbType.Int);
            vppParamCA_LIBELLEANNEEFIN.Value = clsCampangeagricole.CA_LIBELLEANNEEFIN;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;
            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsCampangeagricole.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_CAMPAGNEAGRICOLE  @CA_CODECAMPAGNE, @AG_CODEAGENCE, @CA_LIBELLEANNEEDEBUT, @CA_DATEDEBUT, @CA_DATECLOTURE, @CA_LIBELLEANNEEFIN, @CODECRYPTAGE, @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamCA_CODECAMPAGNE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamCA_LIBELLEANNEEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamCA_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamCA_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamCA_LIBELLEANNEEFIN);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCampangeagricole>clsCampangeagricole</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCampangeagricole clsCampangeagricole,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCA_CODECAMPAGNE = new SqlParameter("@CA_CODECAMPAGNE", SqlDbType.VarChar, 25);
			vppParamCA_CODECAMPAGNE.Value  = clsCampangeagricole.CA_CODECAMPAGNE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCampangeagricole.AG_CODEAGENCE ;
			SqlParameter vppParamCA_LIBELLEANNEEDEBUT = new SqlParameter("@CA_LIBELLEANNEEDEBUT", SqlDbType.Money);
			vppParamCA_LIBELLEANNEEDEBUT.Value  = clsCampangeagricole.CA_LIBELLEANNEEDEBUT ;
			SqlParameter vppParamCA_DATEDEBUT = new SqlParameter("@CA_DATEDEBUT", SqlDbType.DateTime);
			vppParamCA_DATEDEBUT.Value  = clsCampangeagricole.CA_DATEDEBUT ;
			SqlParameter vppParamCA_DATECLOTURE = new SqlParameter("@CA_DATECLOTURE", SqlDbType.DateTime);
			vppParamCA_DATECLOTURE.Value  = clsCampangeagricole.CA_DATECLOTURE ;
			SqlParameter vppParamCA_LIBELLEANNEEFIN = new SqlParameter("@CA_LIBELLEANNEEFIN", SqlDbType.Money);
			vppParamCA_LIBELLEANNEEFIN.Value  = clsCampangeagricole.CA_LIBELLEANNEEFIN ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CAMPAGNEAGRICOLE  @CA_CODECAMPAGNE, @AG_CODEAGENCE, @CA_LIBELLEANNEEDEBUT, @CA_DATEDEBUT, @CA_DATECLOTURE, @CA_LIBELLEANNEEFIN, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCA_CODECAMPAGNE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCA_LIBELLEANNEEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamCA_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamCA_LIBELLEANNEEFIN);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CAMPAGNEAGRICOLE  @CA_CODECAMPAGNE, @AG_CODEAGENCE, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgClotureAnnulationCloture(clsDonnee clsDonnee, clsCampangeagricole clsCampangeagricole, params string[] vppCritere)
        {
            SqlParameter vppParamCA_CODECAMPAGNE = new SqlParameter("@CA_CODECAMPAGNE", SqlDbType.VarChar, 25);
            vppParamCA_CODECAMPAGNE.Value = clsCampangeagricole.CA_CODECAMPAGNE;

            SqlParameter vppParamCA_DATECLOTURE = new SqlParameter("@CA_DATECLOTURE", SqlDbType.DateTime);
            vppParamCA_DATECLOTURE.Value = clsCampangeagricole.CA_DATECLOTURE;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsCampangeagricole.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_CAMPAGNEAGRICOLE  @CA_CODECAMPAGNE, '', '' , '' , @CA_DATECLOTURE , '' , '', @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamCA_CODECAMPAGNE);
            vppSqlCmd.Parameters.Add(vppParamCA_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCampangeagricole </returns>
		///<author>Home Technology</author>
		public List<clsCampangeagricole> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  CA_CODECAMPAGNE, AG_CODEAGENCE, CA_LIBELLEANNEEDEBUT, CA_DATEDEBUT, CA_DATECLOTURE, CA_LIBELLEANNEEFIN FROM dbo.FT_CAMPAGNEAGRICOLE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCampangeagricole> clsCampangeagricoles = new List<clsCampangeagricole>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCampangeagricole clsCampangeagricole = new clsCampangeagricole();
					clsCampangeagricole.CA_CODECAMPAGNE = clsDonnee.vogDataReader["CA_CODECAMPAGNE"].ToString();
					clsCampangeagricole.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsCampangeagricole.CA_LIBELLEANNEEDEBUT = double.Parse(clsDonnee.vogDataReader["CA_LIBELLEANNEEDEBUT"].ToString());
					clsCampangeagricole.CA_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEDEBUT"].ToString());
					clsCampangeagricole.CA_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["CA_DATECLOTURE"].ToString());
                    clsCampangeagricole.CA_LIBELLEANNEEFIN = double.Parse(clsDonnee.vogDataReader["CA_LIBELLEANNEEFIN"].ToString());
					clsCampangeagricoles.Add(clsCampangeagricole);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCampangeagricoles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCampangeagricole </returns>
		///<author>Home Technology</author>
		public List<clsCampangeagricole> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCampangeagricole> clsCampangeagricoles = new List<clsCampangeagricole>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  CA_CODECAMPAGNE, AG_CODEAGENCE, CA_LIBELLEANNEEDEBUT, CA_DATEDEBUT, CA_DATECLOTURE, CA_LIBELLEANNEEFIN FROM dbo.FT_CAMPAGNEAGRICOLE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCampangeagricole clsCampangeagricole = new clsCampangeagricole();
					clsCampangeagricole.CA_CODECAMPAGNE = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECAMPAGNE"].ToString();
					clsCampangeagricole.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsCampangeagricole.CA_LIBELLEANNEEDEBUT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_LIBELLEANNEEDEBUT"].ToString());
					clsCampangeagricole.CA_DATEDEBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATEDEBUT"].ToString());
					clsCampangeagricole.CA_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATECLOTURE"].ToString());
                    clsCampangeagricole.CA_LIBELLEANNEEFIN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_LIBELLEANNEEFIN"].ToString());
					clsCampangeagricoles.Add(clsCampangeagricole);
				}
				Dataset.Dispose();
			}
		return clsCampangeagricoles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_CAMPAGNEAGRICOLE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT CA_CODECAMPAGNE , CA_LIBELLEANNEE,CA_DATEDEBUT,CA_DATECLOTURE FROM dbo.FT_CAMPAGNEAGRICOLE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + " AND CA_DATECLOTURE IS NULL";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CA_CODECAMPAGNE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboEleve(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT CA_CODECAMPAGNE , CA_LIBELLEANNEE,CA_DATEDEBUT,CA_DATECLOTURE FROM dbo.FT_CAMPAGNEAGRICOLE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CA_CODECAMPAGNE, AG_CODEAGENCE)</summary>
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
                this.vapCritere = "WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND CA_CODECAMPAGNE=@CA_CODECAMPAGNE ";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CA_CODECAMPAGNE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}







	}
}
