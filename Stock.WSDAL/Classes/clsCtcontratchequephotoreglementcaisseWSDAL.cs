using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;
using System.IO;

namespace Stock.WSDAL
{
	public class clsCtcontratchequephotoreglementcaisseWSDAL: ITableDAL<clsCtcontratchequephotoreglementcaisse>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratchequephotoreglementcaisse comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratchequephotoreglementcaisse pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CHC_CHEMINPHOTOCHEQUE  , CHC_LIBELLEPHOTOCHEQUE  FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse = new clsCtcontratchequephotoreglementcaisse();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE = clsDonnee.vogDataReader["CHC_CHEMINPHOTOCHEQUE"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE = clsDonnee.vogDataReader["CHC_LIBELLEPHOTOCHEQUE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratchequephotoreglementcaisse;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratchequephotoreglementcaisse>clsCtcontratchequephotoreglementcaisse</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE ;
			SqlParameter vppParamCHC_DATESAISIECHEQUE = new SqlParameter("@CHC_DATESAISIECHEQUE1", SqlDbType.DateTime);
			vppParamCHC_DATESAISIECHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_DATESAISIECHEQUE ;
			SqlParameter vppParamCHC_IDEXCHEQUE = new SqlParameter("@CHC_IDEXCHEQUE1", SqlDbType.VarChar, 25);
			vppParamCHC_IDEXCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_IDEXCHEQUE ;
			SqlParameter vppParamCHC_NUMSEQUENCEPHOTO = new SqlParameter("@CHC_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
			vppParamCHC_NUMSEQUENCEPHOTO.Value  = clsCtcontratchequephotoreglementcaisse.CHC_NUMSEQUENCEPHOTO ;
			SqlParameter vppParamCHC_CHEMINPHOTOCHEQUE = new SqlParameter("@CHC_CHEMINPHOTOCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCHC_CHEMINPHOTOCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE ;
			SqlParameter vppParamCHC_LIBELLEPHOTOCHEQUE = new SqlParameter("@CHC_LIBELLEPHOTOCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCHC_LIBELLEPHOTOCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE1, @CHC_DATESAISIECHEQUE1, @CHC_IDEXCHEQUE1, @CHC_NUMSEQUENCEPHOTO, @CHC_CHEMINPHOTOCHEQUE, @CHC_LIBELLEPHOTOCHEQUE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATESAISIECHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_IDEXCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_NUMSEQUENCEPHOTO);
			vppSqlCmd.Parameters.Add(vppParamCHC_CHEMINPHOTOCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_LIBELLEPHOTOCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsCtcontratchequephotoreglementcaisse>clsCtcontratchequephotoreglementcaisse</param>
        ///<author>Home Technology</author>
        public string pvgMiseAJour(clsDonnee clsDonnee, clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse)
        {
	        //Préparation des paramètres
	        SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
	        vppParamAG_CODEAGENCE.Value  = clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE ;
	        SqlParameter vppParamCHC_DATESAISIECHEQUE = new SqlParameter("@CHC_DATESAISIECHEQUE", SqlDbType.DateTime);
	        vppParamCHC_DATESAISIECHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_DATESAISIECHEQUE ;
	        SqlParameter vppParamCHC_IDEXCHEQUE = new SqlParameter("@CHC_IDEXCHEQUE", SqlDbType.VarChar, 25);
	        vppParamCHC_IDEXCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_IDEXCHEQUE ;
	        SqlParameter vppParamCHC_NUMSEQUENCEPHOTO = new SqlParameter("@CHC_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
	        vppParamCHC_NUMSEQUENCEPHOTO.Value  = clsCtcontratchequephotoreglementcaisse.CHC_NUMSEQUENCEPHOTO ;
	        SqlParameter vppParamCHC_CHEMINPHOTOCHEQUE = new SqlParameter("@CHC_CHEMINPHOTOCHEQUE", SqlDbType.VarChar, 1000);
	        vppParamCHC_CHEMINPHOTOCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE ;
	        SqlParameter vppParamCHC_LIBELLEPHOTOCHEQUE = new SqlParameter("@CHC_LIBELLEPHOTOCHEQUE", SqlDbType.VarChar, 1000);
	        vppParamCHC_LIBELLEPHOTOCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE ;
	        SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
	        vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

	        SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value  = clsCtcontratchequephotoreglementcaisse.TYPEOPERATION;


            SqlParameter vppParamCHC_NUMSEQUENCEPHOTORETOUR = new SqlParameter("@CHC_NUMSEQUENCEPHOTORETOUR", SqlDbType.VarChar, 50);

            //Préparation de la commande
            // this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE1, @CHC_DATESAISIECHEQUE1, @CHC_IDEXCHEQUE1, @CHC_NUMSEQUENCEPHOTO, @CHC_CHEMINPHOTOCHEQUE, @CHC_LIBELLEPHOTOCHEQUE, @CODECRYPTAGE1, 0 ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            SqlCommand vppSqlCmd = new SqlCommand("PC_CTCONTRATCHEQUEPHOTOREGLEMENTCAISSE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;


            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATESAISIECHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_IDEXCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_NUMSEQUENCEPHOTO);
	        vppSqlCmd.Parameters.Add(vppParamCHC_CHEMINPHOTOCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_LIBELLEPHOTOCHEQUE);

	        vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
	        vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            vppSqlCmd.Parameters.Add(vppParamCHC_NUMSEQUENCEPHOTORETOUR);
            vppParamCHC_NUMSEQUENCEPHOTORETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@CHC_NUMSEQUENCEPHOTORETOUR"].Value.ToString();

            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }
		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratchequephotoreglementcaisse>clsCtcontratchequephotoreglementcaisse</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE ;
			SqlParameter vppParamCHC_DATESAISIECHEQUE = new SqlParameter("@CHC_DATESAISIECHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATESAISIECHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_DATESAISIECHEQUE ;
			SqlParameter vppParamCHC_IDEXCHEQUE = new SqlParameter("@CHC_IDEXCHEQUE", SqlDbType.VarChar, 25);
			vppParamCHC_IDEXCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_IDEXCHEQUE ;
			SqlParameter vppParamCHC_NUMSEQUENCEPHOTO = new SqlParameter("@CHC_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
			vppParamCHC_NUMSEQUENCEPHOTO.Value  = clsCtcontratchequephotoreglementcaisse.CHC_NUMSEQUENCEPHOTO ;
			SqlParameter vppParamCHC_CHEMINPHOTOCHEQUE = new SqlParameter("@CHC_CHEMINPHOTOCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCHC_CHEMINPHOTOCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE ;
			SqlParameter vppParamCHC_LIBELLEPHOTOCHEQUE = new SqlParameter("@CHC_LIBELLEPHOTOCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCHC_LIBELLEPHOTOCHEQUE.Value  = clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE, @CHC_DATESAISIECHEQUE, @CHC_IDEXCHEQUE, @CHC_NUMSEQUENCEPHOTO, @CHC_CHEMINPHOTOCHEQUE, @CHC_LIBELLEPHOTOCHEQUE, @CODECRYPTAGE, 1,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATESAISIECHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_IDEXCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_NUMSEQUENCEPHOTO);
			vppSqlCmd.Parameters.Add(vppParamCHC_CHEMINPHOTOCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_LIBELLEPHOTOCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE, @CHC_DATESAISIECHEQUE, @CHC_IDEXCHEQUE, @CHC_NUMSEQUENCEPHOTO, '' , '' , @CODECRYPTAGE, 2,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDeleteListe(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE, @CHC_DATESAISIECHEQUE, @CHC_IDEXCHEQUE, '', '' , '' , @CODECRYPTAGE, 3,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratchequephotoreglementcaisse </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequephotoreglementcaisse> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO, CHC_CHEMINPHOTOCHEQUE, CHC_LIBELLEPHOTOCHEQUE FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses = new List<clsCtcontratchequephotoreglementcaisse>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse = new clsCtcontratchequephotoreglementcaisse();
					clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_DATESAISIECHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATESAISIECHEQUE"].ToString());
					clsCtcontratchequephotoreglementcaisse.CHC_IDEXCHEQUE = clsDonnee.vogDataReader["CHC_IDEXCHEQUE"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_NUMSEQUENCEPHOTO = clsDonnee.vogDataReader["CHC_NUMSEQUENCEPHOTO"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE = clsDonnee.vogDataReader["CHC_CHEMINPHOTOCHEQUE"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE = clsDonnee.vogDataReader["CHC_LIBELLEPHOTOCHEQUE"].ToString();
					clsCtcontratchequephotoreglementcaisses.Add(clsCtcontratchequephotoreglementcaisse);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratchequephotoreglementcaisses;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratchequephotoreglementcaisse </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequephotoreglementcaisse> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses = new List<clsCtcontratchequephotoreglementcaisse>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO, CHC_CHEMINPHOTOCHEQUE, CHC_LIBELLEPHOTOCHEQUE FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse = new clsCtcontratchequephotoreglementcaisse();
					clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_DATESAISIECHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_DATESAISIECHEQUE"].ToString());
					clsCtcontratchequephotoreglementcaisse.CHC_IDEXCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CHC_IDEXCHEQUE"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_NUMSEQUENCEPHOTO = Dataset.Tables["TABLE"].Rows[Idx]["CHC_NUMSEQUENCEPHOTO"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CHC_CHEMINPHOTOCHEQUE"].ToString();
					clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CHC_LIBELLEPHOTOCHEQUE"].ToString();
					clsCtcontratchequephotoreglementcaisses.Add(clsCtcontratchequephotoreglementcaisse);
				}
				Dataset.Dispose();
			}
		return clsCtcontratchequephotoreglementcaisses;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{

            string pathImage = "";
            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            pathImage = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT").PP_VALEUR;

            DataSet DataSet = new DataSet();
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CHC_DATESAISIECHEQUE", "@CHC_IDEXCHEQUE", "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC PS_CTCONTRATCHEQUEPHOTO @AG_CODEAGENCE,@CHC_DATESAISIECHEQUE,@CHC_IDEXCHEQUE,@CA_CODECONTRAT,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE " ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
            for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
            {
                //---Test de l'exitance du chemin de sauvegarde
                if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["CHC_CHEMINPHOTOCHEQUE"].ToString() + ".jpg"))
                {
                    DataSet.Tables[0].Rows[Idx]["CHC_CHEMINPHOTOCHEQUE"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["CHC_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
                }
                
            }
            return DataSet;
		}

        
		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , CHC_CHEMINPHOTOCHEQUE FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, CHC_NUMSEQUENCEPHOTO)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CHC_DATESAISIECHEQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE AND CHC_IDEXCHEQUE=@CHC_IDEXCHEQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CHC_DATESAISIECHEQUE","@CHC_IDEXCHEQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE AND CHC_IDEXCHEQUE=@CHC_IDEXCHEQUE AND CHC_NUMSEQUENCEPHOTO=@CHC_NUMSEQUENCEPHOTO";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CHC_DATESAISIECHEQUE","@CHC_IDEXCHEQUE","@CHC_NUMSEQUENCEPHOTO"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}





        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public bool pvgUploadPhotoSignature(clsDonnee clsDonnee, string PHOTO, string NOMPHOTO, string PP_CODEPARAMETRE)
        {
            bool vlpResultat = true;
            //List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogins = new List<clsMiccomptewebUserLogin>();
            //clsMiccomptewebUserLogin clsMiccomptewebUserLogin = new clsMiccomptewebUserLogin();


            //List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            string pathPhoto = clsParametreWSDAL.pvgTableLabel(clsDonnee, PP_CODEPARAMETRE).PP_VALEUR;
            //string pathSignature = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "SIGN").PP_VALEUR;
            //---Test de l'exitance du chemin de sauvegarde
            if (!Directory.Exists(pathPhoto))
            {
                vlpResultat = false;
                //clsMiccomptewebResultats = pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0262", "01");
                //clsMiccomptewebUserLogin.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                //clsMiccomptewebUserLogin.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                //clsMiccomptewebUserLogin.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                //clsMiccomptewebUserLogins.Add(clsMiccomptewebUserLogin);
                return vlpResultat;
            }
            //if (!Directory.Exists(pathSignature))
            //{
            //    clsMiccomptewebResultats = pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0262", "01");
            //    clsMiccomptewebUserLogin.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserLogin.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebUserLogin.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //    clsMiccomptewebUserLogins.Add(clsMiccomptewebUserLogin);
            //    return clsMiccomptewebUserLogins;
            //}

            //---sauvegarde des immages
            if (PHOTO != "" && NOMPHOTO != "")
                Base64ToImageSave(PHOTO).Save(pathPhoto + NOMPHOTO + ".jpg");
            //clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();
            //clsMiccomptewebmotpasseoublie.SL_RESULTAT = "TRUE";
            //pvgRenommerFichierJoint( clsDonnee,  clsMiccomptewebmotpasseoublie);
            //if (SIGNATURE != "" && NOMSIGNATURE != "")
            //    Base64ToImageSave(SIGNATURE).Save(pathSignature + NOMSIGNATURE+ ".jpg");
            //---Message retourné au client
            //clsMiccomptewebResultats = pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0099", "02");
            //clsMiccomptewebUserLogin.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //clsMiccomptewebUserLogin.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //clsMiccomptewebUserLogin.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //clsMiccomptewebUserLogins.Add(clsMiccomptewebUserLogin);


            return vlpResultat;
        }


        public System.Drawing.Image Base64ToImageSave(string base64String)
        {

            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        public string ImageToBase64(string path)
        {
             string base64String = null;
            if (!File.Exists(path)) return "";
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

    }
}
