using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsClicasprisenchargeadherantperiodiciteWSDAL: ITableDAL<clsClicasprisenchargeadherantperiodicite>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICASPRISENCHARGEADHERANTPERIODICITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICASPRISENCHARGEADHERANTPERIODICITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICASPRISENCHARGEADHERANTPERIODICITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsClicasprisenchargeadherantperiodicite comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsClicasprisenchargeadherantperiodicite pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AR_CODEARTICLE  , AP_CODEPRODUIT  , PE_CODEPERIODICITE  , TI_IDTIERSADHERANT  , CP_TAUXREMBOURSEMENT  , CP_PLAFOND  , CP_NOMBRE  , CP_DATEFINDERNIEREPERIODICITE  FROM dbo.FT_CLICASPRISENCHARGEADHERANTPERIODICITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsClicasprisenchargeadherantperiodicite clsClicasprisenchargeadherantperiodicite = new clsClicasprisenchargeadherantperiodicite();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClicasprisenchargeadherantperiodicite.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsClicasprisenchargeadherantperiodicite.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsClicasprisenchargeadherantperiodicite.PE_CODEPERIODICITE = clsDonnee.vogDataReader["PE_CODEPERIODICITE"].ToString();
					clsClicasprisenchargeadherantperiodicite.TI_IDTIERSADHERANT = clsDonnee.vogDataReader["TI_IDTIERSADHERANT"].ToString();
					clsClicasprisenchargeadherantperiodicite.CP_TAUXREMBOURSEMENT = float.Parse(clsDonnee.vogDataReader["CP_TAUXREMBOURSEMENT"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_PLAFOND = double.Parse(clsDonnee.vogDataReader["CP_PLAFOND"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_NOMBRE = int.Parse(clsDonnee.vogDataReader["CP_NOMBRE"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_DATEFINDERNIEREPERIODICITE = DateTime.Parse(clsDonnee.vogDataReader["CP_DATEFINDERNIEREPERIODICITE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsClicasprisenchargeadherantperiodicite;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClicasprisenchargeadherantperiodicite>clsClicasprisenchargeadherantperiodicite</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsClicasprisenchargeadherantperiodicite clsClicasprisenchargeadherantperiodicite)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsClicasprisenchargeadherantperiodicite.AG_CODEAGENCE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsClicasprisenchargeadherantperiodicite.AR_CODEARTICLE ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsClicasprisenchargeadherantperiodicite.AP_CODEPRODUIT ;
			SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE", SqlDbType.VarChar, 2);
			vppParamPE_CODEPERIODICITE.Value  = clsClicasprisenchargeadherantperiodicite.PE_CODEPERIODICITE ;
			SqlParameter vppParamTI_IDTIERSADHERANT = new SqlParameter("@TI_IDTIERSADHERANT", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSADHERANT.Value  = clsClicasprisenchargeadherantperiodicite.TI_IDTIERSADHERANT ;
			SqlParameter vppParamCP_TAUXREMBOURSEMENT = new SqlParameter("@CP_TAUXREMBOURSEMENT", SqlDbType.Float);
			vppParamCP_TAUXREMBOURSEMENT.Value  = clsClicasprisenchargeadherantperiodicite.CP_TAUXREMBOURSEMENT ;

			SqlParameter vppParamCP_MONTANT = new SqlParameter("@CP_MONTANT", SqlDbType.Money);
            vppParamCP_MONTANT.Value  = clsClicasprisenchargeadherantperiodicite.CP_MONTANT;

			SqlParameter vppParamCP_PLAFOND = new SqlParameter("@CP_PLAFOND", SqlDbType.Money);
			vppParamCP_PLAFOND.Value  = clsClicasprisenchargeadherantperiodicite.CP_PLAFOND ;
			SqlParameter vppParamCP_NOMBRE = new SqlParameter("@CP_NOMBRE", SqlDbType.Int);
			vppParamCP_NOMBRE.Value  = clsClicasprisenchargeadherantperiodicite.CP_NOMBRE ;
			SqlParameter vppParamCP_DATEFINDERNIEREPERIODICITE = new SqlParameter("@CP_DATEFINDERNIEREPERIODICITE", SqlDbType.DateTime);
			vppParamCP_DATEFINDERNIEREPERIODICITE.Value  = clsClicasprisenchargeadherantperiodicite.CP_DATEFINDERNIEREPERIODICITE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICASPRISENCHARGEADHERANTPERIODICITE  @AG_CODEAGENCE, @AR_CODEARTICLE, @AP_CODEPRODUIT, @PE_CODEPERIODICITE, @TI_IDTIERSADHERANT, @CP_TAUXREMBOURSEMENT,@CP_MONTANT, @CP_PLAFOND, @CP_NOMBRE, @CP_DATEFINDERNIEREPERIODICITE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSADHERANT);
			vppSqlCmd.Parameters.Add(vppParamCP_TAUXREMBOURSEMENT);
			vppSqlCmd.Parameters.Add(vppParamCP_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCP_PLAFOND);
			vppSqlCmd.Parameters.Add(vppParamCP_NOMBRE);
			vppSqlCmd.Parameters.Add(vppParamCP_DATEFINDERNIEREPERIODICITE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClicasprisenchargeadherantperiodicite>clsClicasprisenchargeadherantperiodicite</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsClicasprisenchargeadherantperiodicite clsClicasprisenchargeadherantperiodicite,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsClicasprisenchargeadherantperiodicite.AG_CODEAGENCE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsClicasprisenchargeadherantperiodicite.AR_CODEARTICLE ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsClicasprisenchargeadherantperiodicite.AP_CODEPRODUIT ;
			SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE", SqlDbType.VarChar, 2);
			vppParamPE_CODEPERIODICITE.Value  = clsClicasprisenchargeadherantperiodicite.PE_CODEPERIODICITE ;
			SqlParameter vppParamTI_IDTIERSADHERANT = new SqlParameter("@TI_IDTIERSADHERANT", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSADHERANT.Value  = clsClicasprisenchargeadherantperiodicite.TI_IDTIERSADHERANT ;
			SqlParameter vppParamCP_TAUXREMBOURSEMENT = new SqlParameter("@CP_TAUXREMBOURSEMENT", SqlDbType.Float);
			vppParamCP_TAUXREMBOURSEMENT.Value  = clsClicasprisenchargeadherantperiodicite.CP_TAUXREMBOURSEMENT ;

			SqlParameter vppParamCP_MONTANT = new SqlParameter("@CP_MONTANT", SqlDbType.Money);
            vppParamCP_MONTANT.Value  = clsClicasprisenchargeadherantperiodicite.CP_MONTANT;

			SqlParameter vppParamCP_PLAFOND = new SqlParameter("@CP_PLAFOND", SqlDbType.Money);
			vppParamCP_PLAFOND.Value  = clsClicasprisenchargeadherantperiodicite.CP_PLAFOND ;
			SqlParameter vppParamCP_NOMBRE = new SqlParameter("@CP_NOMBRE", SqlDbType.Int);
			vppParamCP_NOMBRE.Value  = clsClicasprisenchargeadherantperiodicite.CP_NOMBRE ;
			SqlParameter vppParamCP_DATEFINDERNIEREPERIODICITE = new SqlParameter("@CP_DATEFINDERNIEREPERIODICITE", SqlDbType.DateTime);
			vppParamCP_DATEFINDERNIEREPERIODICITE.Value  = clsClicasprisenchargeadherantperiodicite.CP_DATEFINDERNIEREPERIODICITE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICASPRISENCHARGEADHERANTPERIODICITE  @AG_CODEAGENCE, @AR_CODEARTICLE, @AP_CODEPRODUIT, @PE_CODEPERIODICITE, @TI_IDTIERSADHERANT, @CP_TAUXREMBOURSEMENT,@CP_MONTANT, @CP_PLAFOND, @CP_NOMBRE, @CP_DATEFINDERNIEREPERIODICITE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSADHERANT);
			vppSqlCmd.Parameters.Add(vppParamCP_TAUXREMBOURSEMENT);
			vppSqlCmd.Parameters.Add(vppParamCP_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCP_PLAFOND);
			vppSqlCmd.Parameters.Add(vppParamCP_NOMBRE);
			vppSqlCmd.Parameters.Add(vppParamCP_DATEFINDERNIEREPERIODICITE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICASPRISENCHARGEADHERANTPERIODICITE  @AG_CODEAGENCE, @AR_CODEARTICLE, @AP_CODEPRODUIT, @PE_CODEPERIODICITE, @TI_IDTIERSADHERANT, '' , '' , '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClicasprisenchargeadherantperiodicite </returns>
		///<author>Home Technology</author>
		public List<clsClicasprisenchargeadherantperiodicite> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT, CP_TAUXREMBOURSEMENT, CP_PLAFOND, CP_NOMBRE, CP_DATEFINDERNIEREPERIODICITE FROM dbo.FT_CLICASPRISENCHARGEADHERANTPERIODICITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsClicasprisenchargeadherantperiodicite> clsClicasprisenchargeadherantperiodicites = new List<clsClicasprisenchargeadherantperiodicite>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClicasprisenchargeadherantperiodicite clsClicasprisenchargeadherantperiodicite = new clsClicasprisenchargeadherantperiodicite();
					clsClicasprisenchargeadherantperiodicite.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsClicasprisenchargeadherantperiodicite.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsClicasprisenchargeadherantperiodicite.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsClicasprisenchargeadherantperiodicite.PE_CODEPERIODICITE = clsDonnee.vogDataReader["PE_CODEPERIODICITE"].ToString();
					clsClicasprisenchargeadherantperiodicite.TI_IDTIERSADHERANT = clsDonnee.vogDataReader["TI_IDTIERSADHERANT"].ToString();
					clsClicasprisenchargeadherantperiodicite.CP_TAUXREMBOURSEMENT = float.Parse(clsDonnee.vogDataReader["CP_TAUXREMBOURSEMENT"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_PLAFOND = double.Parse(clsDonnee.vogDataReader["CP_PLAFOND"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_NOMBRE = int.Parse(clsDonnee.vogDataReader["CP_NOMBRE"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_DATEFINDERNIEREPERIODICITE = DateTime.Parse(clsDonnee.vogDataReader["CP_DATEFINDERNIEREPERIODICITE"].ToString());
					clsClicasprisenchargeadherantperiodicites.Add(clsClicasprisenchargeadherantperiodicite);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsClicasprisenchargeadherantperiodicites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClicasprisenchargeadherantperiodicite </returns>
		///<author>Home Technology</author>
		public List<clsClicasprisenchargeadherantperiodicite> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsClicasprisenchargeadherantperiodicite> clsClicasprisenchargeadherantperiodicites = new List<clsClicasprisenchargeadherantperiodicite>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT, CP_TAUXREMBOURSEMENT, CP_PLAFOND, CP_NOMBRE, CP_DATEFINDERNIEREPERIODICITE FROM dbo.FT_CLICASPRISENCHARGEADHERANTPERIODICITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsClicasprisenchargeadherantperiodicite clsClicasprisenchargeadherantperiodicite = new clsClicasprisenchargeadherantperiodicite();
					clsClicasprisenchargeadherantperiodicite.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsClicasprisenchargeadherantperiodicite.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsClicasprisenchargeadherantperiodicite.AP_CODEPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["AP_CODEPRODUIT"].ToString();
					clsClicasprisenchargeadherantperiodicite.PE_CODEPERIODICITE = Dataset.Tables["TABLE"].Rows[Idx]["PE_CODEPERIODICITE"].ToString();
					clsClicasprisenchargeadherantperiodicite.TI_IDTIERSADHERANT = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSADHERANT"].ToString();
					clsClicasprisenchargeadherantperiodicite.CP_TAUXREMBOURSEMENT = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CP_TAUXREMBOURSEMENT"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_PLAFOND = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CP_PLAFOND"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_NOMBRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CP_NOMBRE"].ToString());
					clsClicasprisenchargeadherantperiodicite.CP_DATEFINDERNIEREPERIODICITE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CP_DATEFINDERNIEREPERIODICITE"].ToString());
					clsClicasprisenchargeadherantperiodicites.Add(clsClicasprisenchargeadherantperiodicite);
				}
				Dataset.Dispose();
			}
		return clsClicasprisenchargeadherantperiodicites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICASPRISENCHARGEADHERANTPERIODICITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , CP_TAUXREMBOURSEMENT FROM dbo.FT_CLICASPRISENCHARGEADHERANTPERIODICITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT, PE_CODEPERIODICITE, TI_IDTIERSADHERANT)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@AR_CODEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE AND AP_CODEPRODUIT=@AP_CODEPRODUIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@AR_CODEARTICLE","@AP_CODEPRODUIT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE AND AP_CODEPRODUIT=@AP_CODEPRODUIT AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@AR_CODEARTICLE","@AP_CODEPRODUIT","@PE_CODEPERIODICITE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE AND AP_CODEPRODUIT=@AP_CODEPRODUIT AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE AND TI_IDTIERSADHERANT=@TI_IDTIERSADHERANT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@AR_CODEARTICLE","@AP_CODEPRODUIT","@PE_CODEPERIODICITE","@TI_IDTIERSADHERANT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}
	}
}
