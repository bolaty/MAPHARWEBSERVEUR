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
	public class clsCtcontratchequephotoWSDAL: ITableDAL<clsCtcontratchequephoto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
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

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
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

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
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

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratchequephoto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratchequephoto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CH_CHEMINPHOTOCHEQUE  , CH_LIBELLEPHOTOCHEQUE  FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratchequephoto clsCtcontratchequephoto = new clsCtcontratchequephoto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = clsDonnee.vogDataReader["CH_CHEMINPHOTOCHEQUE"].ToString();
					clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = clsDonnee.vogDataReader["CH_LIBELLEPHOTOCHEQUE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratchequephoto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratchequephoto>clsCtcontratchequephoto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratchequephoto clsCtcontratchequephoto)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratchequephoto.AG_CODEAGENCE ;
			SqlParameter vppParamCH_DATESAISIECHEQUE = new SqlParameter("@CH_DATESAISIECHEQUE1", SqlDbType.DateTime);
			vppParamCH_DATESAISIECHEQUE.Value  = clsCtcontratchequephoto.CH_DATESAISIECHEQUE ;
			SqlParameter vppParamCH_IDEXCHEQUE = new SqlParameter("@CH_IDEXCHEQUE1", SqlDbType.VarChar, 25);
			vppParamCH_IDEXCHEQUE.Value  = clsCtcontratchequephoto.CH_IDEXCHEQUE ;
			SqlParameter vppParamCH_NUMSEQUENCEPHOTO = new SqlParameter("@CH_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
			vppParamCH_NUMSEQUENCEPHOTO.Value  = clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO ;
			SqlParameter vppParamCH_CHEMINPHOTOCHEQUE = new SqlParameter("@CH_CHEMINPHOTOCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCH_CHEMINPHOTOCHEQUE.Value  = clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE ;
			SqlParameter vppParamCH_LIBELLEPHOTOCHEQUE = new SqlParameter("@CH_LIBELLEPHOTOCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCH_LIBELLEPHOTOCHEQUE.Value  = clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE1, @CH_DATESAISIECHEQUE1, @CH_IDEXCHEQUE1, @CH_NUMSEQUENCEPHOTO, @CH_CHEMINPHOTOCHEQUE, @CH_LIBELLEPHOTOCHEQUE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATESAISIECHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_IDEXCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_NUMSEQUENCEPHOTO);
			vppSqlCmd.Parameters.Add(vppParamCH_CHEMINPHOTOCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_LIBELLEPHOTOCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsCtcontratchequephoto>clsCtcontratchequephoto</param>
        ///<author>Home Technology</author>
        public string pvgMiseAJour(clsDonnee clsDonnee, clsCtcontratchequephoto clsCtcontratchequephoto)
        {
	        //Préparation des paramètres
	        SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
	        vppParamAG_CODEAGENCE.Value  = clsCtcontratchequephoto.AG_CODEAGENCE ;
	        SqlParameter vppParamCH_DATESAISIECHEQUE = new SqlParameter("@CH_DATESAISIECHEQUE", SqlDbType.DateTime);
	        vppParamCH_DATESAISIECHEQUE.Value  = clsCtcontratchequephoto.CH_DATESAISIECHEQUE ;
	        SqlParameter vppParamCH_IDEXCHEQUE = new SqlParameter("@CH_IDEXCHEQUE", SqlDbType.VarChar, 25);
	        vppParamCH_IDEXCHEQUE.Value  = clsCtcontratchequephoto.CH_IDEXCHEQUE ;
	        SqlParameter vppParamCH_NUMSEQUENCEPHOTO = new SqlParameter("@CH_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
	        vppParamCH_NUMSEQUENCEPHOTO.Value  = clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO ;
	        SqlParameter vppParamCH_CHEMINPHOTOCHEQUE = new SqlParameter("@CH_CHEMINPHOTOCHEQUE", SqlDbType.VarChar, 1000);
	        vppParamCH_CHEMINPHOTOCHEQUE.Value  = clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE ;
	        SqlParameter vppParamCH_LIBELLEPHOTOCHEQUE = new SqlParameter("@CH_LIBELLEPHOTOCHEQUE", SqlDbType.VarChar, 1000);
	        vppParamCH_LIBELLEPHOTOCHEQUE.Value  = clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE ;
	        SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
	        vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

	        SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value  = clsCtcontratchequephoto.TYPEOPERATION;


            SqlParameter vppParamCH_NUMSEQUENCEPHOTORETOUR = new SqlParameter("@CH_NUMSEQUENCEPHOTORETOUR", SqlDbType.VarChar, 50);

            //Préparation de la commande
            // this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE1, @CH_DATESAISIECHEQUE1, @CH_IDEXCHEQUE1, @CH_NUMSEQUENCEPHOTO, @CH_CHEMINPHOTOCHEQUE, @CH_LIBELLEPHOTOCHEQUE, @CODECRYPTAGE1, 0 ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            SqlCommand vppSqlCmd = new SqlCommand("PC_CTCONTRATCHEQUEPHOTO", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;


            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
	        vppSqlCmd.Parameters.Add(vppParamCH_DATESAISIECHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCH_IDEXCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCH_NUMSEQUENCEPHOTO);
	        vppSqlCmd.Parameters.Add(vppParamCH_CHEMINPHOTOCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCH_LIBELLEPHOTOCHEQUE);

	        vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
	        vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            vppSqlCmd.Parameters.Add(vppParamCH_NUMSEQUENCEPHOTORETOUR);
            vppParamCH_NUMSEQUENCEPHOTORETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@CH_NUMSEQUENCEPHOTORETOUR"].Value.ToString();

            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }
		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratchequephoto>clsCtcontratchequephoto</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratchequephoto clsCtcontratchequephoto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratchequephoto.AG_CODEAGENCE ;
			SqlParameter vppParamCH_DATESAISIECHEQUE = new SqlParameter("@CH_DATESAISIECHEQUE", SqlDbType.DateTime);
			vppParamCH_DATESAISIECHEQUE.Value  = clsCtcontratchequephoto.CH_DATESAISIECHEQUE ;
			SqlParameter vppParamCH_IDEXCHEQUE = new SqlParameter("@CH_IDEXCHEQUE", SqlDbType.VarChar, 25);
			vppParamCH_IDEXCHEQUE.Value  = clsCtcontratchequephoto.CH_IDEXCHEQUE ;
			SqlParameter vppParamCH_NUMSEQUENCEPHOTO = new SqlParameter("@CH_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
			vppParamCH_NUMSEQUENCEPHOTO.Value  = clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO ;
			SqlParameter vppParamCH_CHEMINPHOTOCHEQUE = new SqlParameter("@CH_CHEMINPHOTOCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCH_CHEMINPHOTOCHEQUE.Value  = clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE ;
			SqlParameter vppParamCH_LIBELLEPHOTOCHEQUE = new SqlParameter("@CH_LIBELLEPHOTOCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCH_LIBELLEPHOTOCHEQUE.Value  = clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE, @CH_DATESAISIECHEQUE, @CH_IDEXCHEQUE, @CH_NUMSEQUENCEPHOTO, @CH_CHEMINPHOTOCHEQUE, @CH_LIBELLEPHOTOCHEQUE, @CODECRYPTAGE, 1,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATESAISIECHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_IDEXCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_NUMSEQUENCEPHOTO);
			vppSqlCmd.Parameters.Add(vppParamCH_CHEMINPHOTOCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_LIBELLEPHOTOCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE, @CH_DATESAISIECHEQUE, @CH_IDEXCHEQUE, @CH_NUMSEQUENCEPHOTO, '' , '' , @CODECRYPTAGE, 2,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDeleteListe(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUEPHOTO  @AG_CODEAGENCE, @CH_DATESAISIECHEQUE, @CH_IDEXCHEQUE, '', '' , '' , @CODECRYPTAGE, 3,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratchequephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequephoto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO, CH_CHEMINPHOTOCHEQUE, CH_LIBELLEPHOTOCHEQUE FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratchequephoto> clsCtcontratchequephotos = new List<clsCtcontratchequephoto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratchequephoto clsCtcontratchequephoto = new clsCtcontratchequephoto();
					clsCtcontratchequephoto.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratchequephoto.CH_DATESAISIECHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATESAISIECHEQUE"].ToString());
					clsCtcontratchequephoto.CH_IDEXCHEQUE = clsDonnee.vogDataReader["CH_IDEXCHEQUE"].ToString();
					clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO = clsDonnee.vogDataReader["CH_NUMSEQUENCEPHOTO"].ToString();
					clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = clsDonnee.vogDataReader["CH_CHEMINPHOTOCHEQUE"].ToString();
					clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = clsDonnee.vogDataReader["CH_LIBELLEPHOTOCHEQUE"].ToString();
					clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratchequephotos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratchequephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequephoto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratchequephoto> clsCtcontratchequephotos = new List<clsCtcontratchequephoto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO, CH_CHEMINPHOTOCHEQUE, CH_LIBELLEPHOTOCHEQUE FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratchequephoto clsCtcontratchequephoto = new clsCtcontratchequephoto();
					clsCtcontratchequephoto.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratchequephoto.CH_DATESAISIECHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATESAISIECHEQUE"].ToString());
					clsCtcontratchequephoto.CH_IDEXCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CH_IDEXCHEQUE"].ToString();
					clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO = Dataset.Tables["TABLE"].Rows[Idx]["CH_NUMSEQUENCEPHOTO"].ToString();
					clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString();
					clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CH_LIBELLEPHOTOCHEQUE"].ToString();
					clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
				}
				Dataset.Dispose();
			}
		return clsCtcontratchequephotos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
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
            pathImage = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT2").PP_VALEUR;

            DataSet DataSet = new DataSet();
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CH_DATESAISIECHEQUE", "@CH_IDEXCHEQUE", "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC PS_CTCONTRATCHEQUEPHOTO @AG_CODEAGENCE,@CH_DATESAISIECHEQUE,@CH_IDEXCHEQUE,@CA_CODECONTRAT,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE " ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
            for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
            {
                //---Test de l'exitance du chemin de sauvegarde
                if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg"))
                {
                    DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
                }
                
            }
            return DataSet;
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPhotoAfficher(clsDonnee clsDonnee, params string[] vppCritere)
        {
        string pathImage = "";
        string pathImage01 = "";
        string pathImage02 = "";
        //---Récupération du chemin de sauvegarde
        clsParametre clsParametre = new clsParametre();
        clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
        pathImage01 = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT1").PP_VALEUR;
        pathImage02 = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT2").PP_VALEUR;
        DataSet DataSet = new DataSet();
        vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE",  "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
        vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3]  };
        this.vapRequete = "EXEC PS_CTCONTRATCHEQUEPHOTOAFFICHER @AG_CODEAGENCE,@CA_CODECONTRAT,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
        this.vapCritere = "";
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        DataSet = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
        {
            if (DataSet.Tables[0].Rows[Idx]["CH_TYPECHEQUE"].ToString() == "01")
                pathImage = pathImage02;                
            if (DataSet.Tables[0].Rows[Idx]["CH_TYPECHEQUE"].ToString() == "02")
                pathImage = pathImage01;
                //---Test de l'exitance du chemin de sauvegarde
                if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg"))
            {
                DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
            }
                
        }
        return DataSet;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetContratCheque(clsDonnee clsDonnee, params string[] vppCritere)
        {
        string pathImage = "";
        string pathImage01 = "";
        string pathImage02 = "";
        //---Récupération du chemin de sauvegarde
        clsParametre clsParametre = new clsParametre();
        clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
        pathImage01 = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT1").PP_VALEUR;
        pathImage02 = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT2").PP_VALEUR;
        DataSet DataSet = new DataSet();



        vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE",  "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@CH_DATESAISIECHEQUE1", "@CH_DATESAISIECHEQUE2", "@RQ_CODERISQUE", "@TA_CODETYPEAFFAIRES", "@TYPEOPERATION" };
        vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5].Replace("''", "'"), vppCritere[6], vppCritere[7]  };
        this.vapRequete = "EXEC PS_ETATCTCONTRATCHEQUE @AG_CODEAGENCE,@CA_CODECONTRAT,@OP_CODEOPERATEUREDITION,@CH_DATESAISIECHEQUE1,@CH_DATESAISIECHEQUE2, @RQ_CODERISQUE, @TA_CODETYPEAFFAIRES, @TYPEOPERATION,@CODECRYPTAGE ";
        this.vapCritere = "";
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        DataSet = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        //for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
        //{
        //    if (DataSet.Tables[0].Rows[Idx]["CH_TYPECHEQUE"].ToString() == "01")
        //        pathImage = pathImage02;                
        //    if (DataSet.Tables[0].Rows[Idx]["CH_TYPECHEQUE"].ToString() == "02")
        //        pathImage = pathImage01;
        //        //---Test de l'exitance du chemin de sauvegarde
        //        if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg"))
        //    {
        //        DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
        //    }
                
        //}
        return DataSet;
        }




        public void pvgChargerDansDataSetDeletePhoto(clsDonnee clsDonnee, params string[] vppCritere)
        {

            string pathImage = "";
            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            pathImage = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT2").PP_VALEUR;

            DataSet DataSet = new DataSet();
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CH_DATESAISIECHEQUE", "@CH_IDEXCHEQUE", "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC PS_CTCONTRATCHEQUEPHOTO @AG_CODEAGENCE,@CH_DATESAISIECHEQUE,@CH_IDEXCHEQUE,@CA_CODECONTRAT,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
            for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
            {
                //---Test de l'exitance du chemin de sauvegarde
                if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg"))
                {
                    pvgSupprimerPhotoSignature(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
                    DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
                }

            }
  
        }


        public void pvgDeletePhoto(clsDonnee clsDonnee, DataSet DataSet)
        {

            string pathImage = "";
            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            pathImage = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT2").PP_VALEUR;

            for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
            {
                //---Test de l'exitance du chemin de sauvegarde
                if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg"))
                {
                    pvgSupprimerPhotoSignature(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
                    DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
                }

            }

        }


        public DataSet pvgChargerDansDataSetDeletePhoto1(clsDonnee clsDonnee, params string[] vppCritere)
        {

            string pathImage = "";
            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            pathImage = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT2").PP_VALEUR;

            DataSet DataSet = new DataSet();
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CH_DATESAISIECHEQUE", "@CH_IDEXCHEQUE", "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC PS_CTCONTRATCHEQUEPHOTO @AG_CODEAGENCE,@CH_DATESAISIECHEQUE,@CH_IDEXCHEQUE,@CA_CODECONTRAT,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
           return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);


        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , CH_CHEMINPHOTOCHEQUE FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , CH_CHEMINPHOTOCHEQUE FROM dbo.FT_CTCONTRATCHEQUEPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CH_DATESAISIECHEQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE AND CH_IDEXCHEQUE=@CH_IDEXCHEQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CH_DATESAISIECHEQUE","@CH_IDEXCHEQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE AND CH_IDEXCHEQUE=@CH_IDEXCHEQUE AND CH_NUMSEQUENCEPHOTO=@CH_NUMSEQUENCEPHOTO";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CH_DATESAISIECHEQUE","@CH_IDEXCHEQUE","@CH_NUMSEQUENCEPHOTO"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}





        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public bool pvgUploadPhotoSignature(clsDonnee clsDonnee, string PHOTO, string NOMPHOTO)
        {
            bool vlpResultat = true;
            //List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogins = new List<clsMiccomptewebUserLogin>();
            //clsMiccomptewebUserLogin clsMiccomptewebUserLogin = new clsMiccomptewebUserLogin();


            //List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            string pathPhoto = clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT2").PP_VALEUR;
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


        public bool pvgSupprimerPhotoSignature( string chemin)
        {
            bool vlpResultat = false;
            if (File.Exists(chemin))
            {
                File.Delete(chemin);
                if (!File.Exists(chemin))
                    vlpResultat = true;
            }


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
