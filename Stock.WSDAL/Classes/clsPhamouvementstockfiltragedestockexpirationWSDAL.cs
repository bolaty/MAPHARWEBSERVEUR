using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockfiltragedestockexpirationWSDAL: ITableDAL<clsPhamouvementstockfiltragedestockexpiration>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(ME_IDFILTRAGEDESTOCKEXPIRATION) AS ME_IDFILTRAGEDESTOCKEXPIRATION  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(ME_IDFILTRAGEDESTOCKEXPIRATION) AS ME_IDFILTRAGEDESTOCKEXPIRATION  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(ME_IDFILTRAGEDESTOCKEXPIRATION) AS ME_IDFILTRAGEDESTOCKEXPIRATION  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockfiltragedestockexpiration comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockfiltragedestockexpiration pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ME_LIBELLEFILTRAGEDESTOCKEXPIRATION  , OP_CODEOPERATEUR  , ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION  , ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION  , ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION  FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new clsPhamouvementstockfiltragedestockexpiration();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockfiltragedestockexpiration.ME_LIBELLEFILTRAGEDESTOCKEXPIRATION = clsDonnee.vogDataReader["ME_LIBELLEFILTRAGEDESTOCKEXPIRATION"].ToString();
					clsPhamouvementstockfiltragedestockexpiration.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockexpiration.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(clsDonnee.vogDataReader["ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION"].ToString());
					clsPhamouvementstockfiltragedestockexpiration.ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(clsDonnee.vogDataReader["ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION"].ToString());
					clsPhamouvementstockfiltragedestockexpiration.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(clsDonnee.vogDataReader["ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockfiltragedestockexpiration;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockfiltragedestockexpiration>clsPhamouvementstockfiltragedestockexpiration</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration)
		{
			//Préparation des paramètres
			SqlParameter vppParamME_IDFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_IDFILTRAGEDESTOCKEXPIRATION1", SqlDbType.VarChar, 50);
			vppParamME_IDFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION ;
			SqlParameter vppParamME_LIBELLEFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_LIBELLEFILTRAGEDESTOCKEXPIRATION", SqlDbType.VarChar, 1000);
			vppParamME_LIBELLEFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_LIBELLEFILTRAGEDESTOCKEXPIRATION ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockfiltragedestockexpiration.OP_CODEOPERATEUR ;
			SqlParameter vppParamME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION", SqlDbType.DateTime);
			vppParamME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION ;
			SqlParameter vppParamME_DATESAISIEFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION", SqlDbType.DateTime);
			vppParamME_DATESAISIEFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION ;
			SqlParameter vppParamME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION", SqlDbType.DateTime);
			vppParamME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION ;
            if (clsPhamouvementstockfiltragedestockexpiration.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION.Year < 1900) vppParamME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION.Value = "01/01/1900";
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION  @ME_IDFILTRAGEDESTOCKEXPIRATION1, @ME_LIBELLEFILTRAGEDESTOCKEXPIRATION, @OP_CODEOPERATEUR, @ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION, @ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION, @ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamME_IDFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamME_LIBELLEFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamME_DATESAISIEFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockfiltragedestockexpiration>clsPhamouvementstockfiltragedestockexpiration</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamME_IDFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_IDFILTRAGEDESTOCKEXPIRATION1", SqlDbType.VarChar, 50);
			vppParamME_IDFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION ;
			SqlParameter vppParamME_LIBELLEFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_LIBELLEFILTRAGEDESTOCKEXPIRATION", SqlDbType.VarChar, 1000);
			vppParamME_LIBELLEFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_LIBELLEFILTRAGEDESTOCKEXPIRATION ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockfiltragedestockexpiration.OP_CODEOPERATEUR ;
			SqlParameter vppParamME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION", SqlDbType.DateTime);
			vppParamME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION ;
			SqlParameter vppParamME_DATESAISIEFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION", SqlDbType.DateTime);
			vppParamME_DATESAISIEFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION ;
			SqlParameter vppParamME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION", SqlDbType.DateTime);
			vppParamME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION.Value  = clsPhamouvementstockfiltragedestockexpiration.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION ;
            if (clsPhamouvementstockfiltragedestockexpiration.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION.Year < 1900) vppParamME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION.Value = "01/01/1900";


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 25);
            vppParamTYPEOPERATION.Value  = clsPhamouvementstockfiltragedestockexpiration.TYPEOPERATION;
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION  @ME_IDFILTRAGEDESTOCKEXPIRATION1, @ME_LIBELLEFILTRAGEDESTOCKEXPIRATION, @OP_CODEOPERATEUR, @ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION, @ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION, @ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamME_IDFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamME_LIBELLEFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamME_DATESAISIEFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION  @ME_IDFILTRAGEDESTOCKEXPIRATION, '' , '', '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestockexpiration </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestockexpiration> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ME_IDFILTRAGEDESTOCKEXPIRATION, ME_LIBELLEFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR, ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION, ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION, ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations = new List<clsPhamouvementstockfiltragedestockexpiration>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new clsPhamouvementstockfiltragedestockexpiration();
					clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION = clsDonnee.vogDataReader["ME_IDFILTRAGEDESTOCKEXPIRATION"].ToString();
					clsPhamouvementstockfiltragedestockexpiration.ME_LIBELLEFILTRAGEDESTOCKEXPIRATION = clsDonnee.vogDataReader["ME_LIBELLEFILTRAGEDESTOCKEXPIRATION"].ToString();
					clsPhamouvementstockfiltragedestockexpiration.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockexpiration.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(clsDonnee.vogDataReader["ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION"].ToString());
					clsPhamouvementstockfiltragedestockexpiration.ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(clsDonnee.vogDataReader["ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION"].ToString());
					clsPhamouvementstockfiltragedestockexpiration.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(clsDonnee.vogDataReader["ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION"].ToString());
					clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockfiltragedestockexpirations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestockexpiration </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestockexpiration> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations = new List<clsPhamouvementstockfiltragedestockexpiration>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ME_IDFILTRAGEDESTOCKEXPIRATION, ME_LIBELLEFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR, ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION, ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION, ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new clsPhamouvementstockfiltragedestockexpiration();
					clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION = Dataset.Tables["TABLE"].Rows[Idx]["ME_IDFILTRAGEDESTOCKEXPIRATION"].ToString();
					clsPhamouvementstockfiltragedestockexpiration.ME_LIBELLEFILTRAGEDESTOCKEXPIRATION = Dataset.Tables["TABLE"].Rows[Idx]["ME_LIBELLEFILTRAGEDESTOCKEXPIRATION"].ToString();
					clsPhamouvementstockfiltragedestockexpiration.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockexpiration.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION"].ToString());
					clsPhamouvementstockfiltragedestockexpiration.ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION"].ToString());
					clsPhamouvementstockfiltragedestockexpiration.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION"].ToString());
					clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockfiltragedestockexpirations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ME_IDFILTRAGEDESTOCKEXPIRATION , ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKEXPIRATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :ME_IDFILTRAGEDESTOCKEXPIRATION, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE ME_IDFILTRAGEDESTOCKEXPIRATION=@ME_IDFILTRAGEDESTOCKEXPIRATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ME_IDFILTRAGEDESTOCKEXPIRATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE ME_IDFILTRAGEDESTOCKEXPIRATION=@ME_IDFILTRAGEDESTOCKEXPIRATION AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ME_IDFILTRAGEDESTOCKEXPIRATION","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
