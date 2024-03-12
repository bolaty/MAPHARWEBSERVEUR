using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratsuivieclientWSDAL: ITableDAL<clsCtcontratsuivieclient>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATSUIVIECLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATSUIVIECLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATSUIVIECLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratsuivieclient comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratsuivieclient pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , SU_DATESUIVIE  , CA_CODECONTRAT  , SU_DESCRIPTIONEVENEMENT  , OP_CODEOPERATEUR  FROM dbo.FT_CTCONTRATSUIVIECLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratsuivieclient clsCtcontratsuivieclient = new clsCtcontratsuivieclient();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratsuivieclient.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratsuivieclient.SU_DATESUIVIE = DateTime.Parse(clsDonnee.vogDataReader["SU_DATESUIVIE"].ToString());
					clsCtcontratsuivieclient.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratsuivieclient.SU_DESCRIPTIONEVENEMENT = clsDonnee.vogDataReader["SU_DESCRIPTIONEVENEMENT"].ToString();
					clsCtcontratsuivieclient.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratsuivieclient;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratsuivieclient>clsCtcontratsuivieclient</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratsuivieclient clsCtcontratsuivieclient)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratsuivieclient.AG_CODEAGENCE ;
			SqlParameter vppParamSU_INDEXSUIVIE = new SqlParameter("@SU_INDEXSUIVIE", SqlDbType.VarChar, 25);
			vppParamSU_INDEXSUIVIE.Value  = clsCtcontratsuivieclient.SU_INDEXSUIVIE ;
			SqlParameter vppParamSU_DATESAISIE = new SqlParameter("@SU_DATESAISIE", SqlDbType.DateTime);
			vppParamSU_DATESAISIE.Value  = clsCtcontratsuivieclient.SU_DATESAISIE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratsuivieclient.EN_CODEENTREPOT ;
			SqlParameter vppParamSU_DATESUIVIE = new SqlParameter("@SU_DATESUIVIE", SqlDbType.DateTime);
			vppParamSU_DATESUIVIE.Value  = clsCtcontratsuivieclient.SU_DATESUIVIE ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratsuivieclient.CA_CODECONTRAT ;
			SqlParameter vppParamSU_DESCRIPTIONEVENEMENT = new SqlParameter("@SU_DESCRIPTIONEVENEMENT", SqlDbType.VarChar, 1000);
			vppParamSU_DESCRIPTIONEVENEMENT.Value  = clsCtcontratsuivieclient.SU_DESCRIPTIONEVENEMENT ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontratsuivieclient.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATSUIVIECLIENT  @AG_CODEAGENCE, @SU_INDEXSUIVIE, @SU_DATESAISIE, @EN_CODEENTREPOT, @SU_DATESUIVIE, @CA_CODECONTRAT, @SU_DESCRIPTIONEVENEMENT, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSU_INDEXSUIVIE);
			vppSqlCmd.Parameters.Add(vppParamSU_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamSU_DATESUIVIE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamSU_DESCRIPTIONEVENEMENT);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratsuivieclient>clsCtcontratsuivieclient</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratsuivieclient clsCtcontratsuivieclient,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratsuivieclient.AG_CODEAGENCE ;
			SqlParameter vppParamSU_INDEXSUIVIE = new SqlParameter("@SU_INDEXSUIVIE", SqlDbType.VarChar, 25);
			vppParamSU_INDEXSUIVIE.Value  = clsCtcontratsuivieclient.SU_INDEXSUIVIE ;
			SqlParameter vppParamSU_DATESAISIE = new SqlParameter("@SU_DATESAISIE", SqlDbType.DateTime);
			vppParamSU_DATESAISIE.Value  = clsCtcontratsuivieclient.SU_DATESAISIE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratsuivieclient.EN_CODEENTREPOT ;
			SqlParameter vppParamSU_DATESUIVIE = new SqlParameter("@SU_DATESUIVIE", SqlDbType.DateTime);
			vppParamSU_DATESUIVIE.Value  = clsCtcontratsuivieclient.SU_DATESUIVIE ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratsuivieclient.CA_CODECONTRAT ;
			SqlParameter vppParamSU_DESCRIPTIONEVENEMENT = new SqlParameter("@SU_DESCRIPTIONEVENEMENT", SqlDbType.VarChar, 1000);
			vppParamSU_DESCRIPTIONEVENEMENT.Value  = clsCtcontratsuivieclient.SU_DESCRIPTIONEVENEMENT ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontratsuivieclient.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATSUIVIECLIENT  @AG_CODEAGENCE, @SU_INDEXSUIVIE, @SU_DATESAISIE, @EN_CODEENTREPOT, @SU_DATESUIVIE, @CA_CODECONTRAT, @SU_DESCRIPTIONEVENEMENT, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSU_INDEXSUIVIE);
			vppSqlCmd.Parameters.Add(vppParamSU_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamSU_DATESUIVIE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamSU_DESCRIPTIONEVENEMENT);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATSUIVIECLIENT  @AG_CODEAGENCE, @SU_INDEXSUIVIE, @SU_DATESAISIE, '' , '' , '' , '' , '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratsuivieclient </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratsuivieclient> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, EN_CODEENTREPOT, SU_DATESUIVIE, CA_CODECONTRAT, SU_DESCRIPTIONEVENEMENT, OP_CODEOPERATEUR FROM dbo.FT_CTCONTRATSUIVIECLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratsuivieclient> clsCtcontratsuivieclients = new List<clsCtcontratsuivieclient>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratsuivieclient clsCtcontratsuivieclient = new clsCtcontratsuivieclient();
					clsCtcontratsuivieclient.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratsuivieclient.SU_INDEXSUIVIE = clsDonnee.vogDataReader["SU_INDEXSUIVIE"].ToString();
					clsCtcontratsuivieclient.SU_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SU_DATESAISIE"].ToString());
					clsCtcontratsuivieclient.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratsuivieclient.SU_DATESUIVIE = DateTime.Parse(clsDonnee.vogDataReader["SU_DATESUIVIE"].ToString());
					clsCtcontratsuivieclient.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratsuivieclient.SU_DESCRIPTIONEVENEMENT = clsDonnee.vogDataReader["SU_DESCRIPTIONEVENEMENT"].ToString();
					clsCtcontratsuivieclient.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratsuivieclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratsuivieclient </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratsuivieclient> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratsuivieclient> clsCtcontratsuivieclients = new List<clsCtcontratsuivieclient>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, EN_CODEENTREPOT, SU_DATESUIVIE, CA_CODECONTRAT, SU_DESCRIPTIONEVENEMENT, OP_CODEOPERATEUR FROM dbo.FT_CTCONTRATSUIVIECLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratsuivieclient clsCtcontratsuivieclient = new clsCtcontratsuivieclient();
					clsCtcontratsuivieclient.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratsuivieclient.SU_INDEXSUIVIE = Dataset.Tables["TABLE"].Rows[Idx]["SU_INDEXSUIVIE"].ToString();
					clsCtcontratsuivieclient.SU_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SU_DATESAISIE"].ToString());
					clsCtcontratsuivieclient.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratsuivieclient.SU_DATESUIVIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SU_DATESUIVIE"].ToString());
					clsCtcontratsuivieclient.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratsuivieclient.SU_DESCRIPTIONEVENEMENT = Dataset.Tables["TABLE"].Rows[Idx]["SU_DESCRIPTIONEVENEMENT"].ToString();
					clsCtcontratsuivieclient.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
				}
				Dataset.Dispose();
			}
		return clsCtcontratsuivieclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CA_CODECONTRAT", "@SU_DESCRIPTIONEVENEMENT", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN" , "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4] , vppCritere[5] , vppCritere[6] };
            this.vapRequete = "EXEC PS_CTCONTRATSUIVIECLIENT @AG_CODEAGENCE,@CA_CODECONTRAT,@SU_DESCRIPTIONEVENEMENT,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE " ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SU_INDEXSUIVIE , SU_DESCRIPTIONEVENEMENT FROM dbo.FT_CTCONTRATSUIVIECLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SU_INDEXSUIVIE, SU_DATESAISIE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SU_INDEXSUIVIE=@SU_INDEXSUIVIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SU_INDEXSUIVIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SU_INDEXSUIVIE=@SU_INDEXSUIVIE AND SU_DATESAISIE=@SU_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SU_INDEXSUIVIE","@SU_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SU_INDEXSUIVIE=@SU_INDEXSUIVIE AND SU_DATESAISIE=@SU_DATESAISIE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SU_INDEXSUIVIE","@SU_DATESAISIE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
