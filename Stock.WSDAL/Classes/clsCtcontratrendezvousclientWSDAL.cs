using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratrendezvousclientWSDAL: ITableDAL<clsCtcontratrendezvousclient>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATRENDEZVOUSCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATRENDEZVOUSCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATRENDEZVOUSCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratrendezvousclient comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratrendezvousclient pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , CA_CODECONTRAT  , RD_DATERENDEZVOUS  , RD_OBJETRENDEZVOUS  FROM dbo.FT_CTCONTRATRENDEZVOUSCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new clsCtcontratrendezvousclient();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratrendezvousclient.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratrendezvousclient.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratrendezvousclient.RD_DATERENDEZVOUS = DateTime.Parse(clsDonnee.vogDataReader["RD_DATERENDEZVOUS"].ToString());
					clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS = clsDonnee.vogDataReader["RD_OBJETRENDEZVOUS"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratrendezvousclient;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratrendezvousclient>clsCtcontratrendezvousclient</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratrendezvousclient clsCtcontratrendezvousclient)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratrendezvousclient.AG_CODEAGENCE ;
			SqlParameter vppParamRD_INDEXRENDEZVOUS = new SqlParameter("@RD_INDEXRENDEZVOUS", SqlDbType.VarChar, 25);
			vppParamRD_INDEXRENDEZVOUS.Value  = clsCtcontratrendezvousclient.RD_INDEXRENDEZVOUS ;
			SqlParameter vppParamRD_DATESAISIERENDEZVOUS = new SqlParameter("@RD_DATESAISIERENDEZVOUS", SqlDbType.DateTime);
			vppParamRD_DATESAISIERENDEZVOUS.Value  = clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratrendezvousclient.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratrendezvousclient.CA_CODECONTRAT ;
			SqlParameter vppParamRD_DATERENDEZVOUS = new SqlParameter("@RD_DATERENDEZVOUS", SqlDbType.DateTime);
			vppParamRD_DATERENDEZVOUS.Value  = clsCtcontratrendezvousclient.RD_DATERENDEZVOUS ;
			SqlParameter vppParamRD_OBJETRENDEZVOUS = new SqlParameter("@RD_OBJETRENDEZVOUS", SqlDbType.VarChar, 1000);
			vppParamRD_OBJETRENDEZVOUS.Value  = clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value  = clsCtcontratrendezvousclient.OP_CODEOPERATEUR;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATRENDEZVOUSCLIENT  @AG_CODEAGENCE, @RD_INDEXRENDEZVOUS, @RD_DATESAISIERENDEZVOUS, @EN_CODEENTREPOT, @CA_CODECONTRAT, @RD_DATERENDEZVOUS, @RD_OBJETRENDEZVOUS, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamRD_INDEXRENDEZVOUS);
			vppSqlCmd.Parameters.Add(vppParamRD_DATESAISIERENDEZVOUS);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamRD_DATERENDEZVOUS);
			vppSqlCmd.Parameters.Add(vppParamRD_OBJETRENDEZVOUS);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratrendezvousclient>clsCtcontratrendezvousclient</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratrendezvousclient clsCtcontratrendezvousclient,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratrendezvousclient.AG_CODEAGENCE ;
			SqlParameter vppParamRD_INDEXRENDEZVOUS = new SqlParameter("@RD_INDEXRENDEZVOUS", SqlDbType.VarChar, 25);
			vppParamRD_INDEXRENDEZVOUS.Value  = clsCtcontratrendezvousclient.RD_INDEXRENDEZVOUS ;
			SqlParameter vppParamRD_DATESAISIERENDEZVOUS = new SqlParameter("@RD_DATESAISIERENDEZVOUS", SqlDbType.DateTime);
			vppParamRD_DATESAISIERENDEZVOUS.Value  = clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratrendezvousclient.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratrendezvousclient.CA_CODECONTRAT ;
			SqlParameter vppParamRD_DATERENDEZVOUS = new SqlParameter("@RD_DATERENDEZVOUS", SqlDbType.DateTime);
			vppParamRD_DATERENDEZVOUS.Value  = clsCtcontratrendezvousclient.RD_DATERENDEZVOUS ;

			SqlParameter vppParamRD_OBJETRENDEZVOUS = new SqlParameter("@RD_OBJETRENDEZVOUS", SqlDbType.VarChar, 1000);
			vppParamRD_OBJETRENDEZVOUS.Value  = clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value  = clsCtcontratrendezvousclient.OP_CODEOPERATEUR;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATRENDEZVOUSCLIENT  @AG_CODEAGENCE, @RD_INDEXRENDEZVOUS, @RD_DATESAISIERENDEZVOUS, @EN_CODEENTREPOT, @CA_CODECONTRAT, @RD_DATERENDEZVOUS, @RD_OBJETRENDEZVOUS, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamRD_INDEXRENDEZVOUS);
			vppSqlCmd.Parameters.Add(vppParamRD_DATESAISIERENDEZVOUS);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamRD_DATERENDEZVOUS);
			vppSqlCmd.Parameters.Add(vppParamRD_OBJETRENDEZVOUS);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATRENDEZVOUSCLIENT  @AG_CODEAGENCE, @RD_INDEXRENDEZVOUS, @RD_DATESAISIERENDEZVOUS, '' , '' , '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratrendezvousclient </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratrendezvousclient> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS, EN_CODEENTREPOT, CA_CODECONTRAT, RD_DATERENDEZVOUS, RD_OBJETRENDEZVOUS FROM dbo.FT_CTCONTRATRENDEZVOUSCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<clsCtcontratrendezvousclient>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new clsCtcontratrendezvousclient();
					clsCtcontratrendezvousclient.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratrendezvousclient.RD_INDEXRENDEZVOUS = clsDonnee.vogDataReader["RD_INDEXRENDEZVOUS"].ToString();
					clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS = DateTime.Parse(clsDonnee.vogDataReader["RD_DATESAISIERENDEZVOUS"].ToString());
					clsCtcontratrendezvousclient.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratrendezvousclient.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratrendezvousclient.RD_DATERENDEZVOUS = DateTime.Parse(clsDonnee.vogDataReader["RD_DATERENDEZVOUS"].ToString());
					clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS = clsDonnee.vogDataReader["RD_OBJETRENDEZVOUS"].ToString();
					clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratrendezvousclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratrendezvousclient </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratrendezvousclient> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<clsCtcontratrendezvousclient>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS, EN_CODEENTREPOT, CA_CODECONTRAT, RD_DATERENDEZVOUS, RD_OBJETRENDEZVOUS FROM dbo.FT_CTCONTRATRENDEZVOUSCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new clsCtcontratrendezvousclient();
					clsCtcontratrendezvousclient.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratrendezvousclient.RD_INDEXRENDEZVOUS = Dataset.Tables["TABLE"].Rows[Idx]["RD_INDEXRENDEZVOUS"].ToString();
					clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_DATESAISIERENDEZVOUS"].ToString());
					clsCtcontratrendezvousclient.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratrendezvousclient.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratrendezvousclient.RD_DATERENDEZVOUS = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_DATERENDEZVOUS"].ToString());
					clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS = Dataset.Tables["TABLE"].Rows[Idx]["RD_OBJETRENDEZVOUS"].ToString();
					clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
				}
				Dataset.Dispose();
			}
		return clsCtcontratrendezvousclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CA_CODECONTRAT", "@RD_OBJETRENDEZVOUS", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
            this.vapRequete = "EXEC PS_CTCONTRATRENDEZVOUSCLIENT @AG_CODEAGENCE,@CA_CODECONTRAT,@RD_OBJETRENDEZVOUS,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , EN_CODEENTREPOT FROM dbo.FT_CTCONTRATRENDEZVOUSCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, RD_INDEXRENDEZVOUS, RD_DATESAISIERENDEZVOUS)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND RD_INDEXRENDEZVOUS=@RD_INDEXRENDEZVOUS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@RD_INDEXRENDEZVOUS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND RD_INDEXRENDEZVOUS=@RD_INDEXRENDEZVOUS AND RD_DATESAISIERENDEZVOUS=@RD_DATESAISIERENDEZVOUS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@RD_INDEXRENDEZVOUS","@RD_DATESAISIERENDEZVOUS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
