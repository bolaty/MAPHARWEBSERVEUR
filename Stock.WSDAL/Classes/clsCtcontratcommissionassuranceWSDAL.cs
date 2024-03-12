using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratcommissionassuranceWSDAL: ITableDAL<clsCtcontratcommissionassurance>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCOMMISSIONASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCOMMISSIONASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCOMMISSIONASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratcommissionassurance comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratcommissionassurance pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , CM_REFERENCEPIECE  , CA_CODECONTRAT  , CM_LIBELLEOPERATION  , CM_MONTANTDEBIT  , CM_MONTANTCREDIT  , CM_ANNULER  , OP_CODEOPERATEUR  FROM dbo.FT_CTCONTRATCOMMISSIONASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratcommissionassurance clsCtcontratcommissionassurance = new clsCtcontratcommissionassurance();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratcommissionassurance.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratcommissionassurance.CM_REFERENCEPIECE = clsDonnee.vogDataReader["CM_REFERENCEPIECE"].ToString();
					clsCtcontratcommissionassurance.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratcommissionassurance.CM_LIBELLEOPERATION = clsDonnee.vogDataReader["CM_LIBELLEOPERATION"].ToString();
					clsCtcontratcommissionassurance.CM_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["CM_MONTANTDEBIT"].ToString());
					clsCtcontratcommissionassurance.CM_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["CM_MONTANTCREDIT"].ToString());
					clsCtcontratcommissionassurance.CM_ANNULER = clsDonnee.vogDataReader["CM_ANNULER"].ToString();
					clsCtcontratcommissionassurance.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratcommissionassurance;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratcommissionassurance>clsCtcontratcommissionassurance</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratcommissionassurance clsCtcontratcommissionassurance)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratcommissionassurance.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratcommissionassurance.EN_CODEENTREPOT ;
			SqlParameter vppParamCM_DATEPIECE = new SqlParameter("@CM_DATEPIECE", SqlDbType.DateTime);
			vppParamCM_DATEPIECE.Value  = clsCtcontratcommissionassurance.CM_DATEPIECE ;
			SqlParameter vppParamCM_NUMPIECE = new SqlParameter("@CM_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamCM_NUMPIECE.Value  = clsCtcontratcommissionassurance.CM_NUMPIECE ;
			SqlParameter vppParamCM_NUMSEQUENCE = new SqlParameter("@CM_NUMSEQUENCE", SqlDbType.VarChar, 50);
			vppParamCM_NUMSEQUENCE.Value  = clsCtcontratcommissionassurance.CM_NUMSEQUENCE ;
			SqlParameter vppParamCM_REFERENCEPIECE = new SqlParameter("@CM_REFERENCEPIECE", SqlDbType.VarChar, 1000);
			vppParamCM_REFERENCEPIECE.Value  = clsCtcontratcommissionassurance.CM_REFERENCEPIECE ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratcommissionassurance.CA_CODECONTRAT ;
			SqlParameter vppParamCM_LIBELLEOPERATION = new SqlParameter("@CM_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
			vppParamCM_LIBELLEOPERATION.Value  = clsCtcontratcommissionassurance.CM_LIBELLEOPERATION ;
			SqlParameter vppParamCM_MONTANTDEBIT = new SqlParameter("@CM_MONTANTDEBIT", SqlDbType.Money);
			vppParamCM_MONTANTDEBIT.Value  = clsCtcontratcommissionassurance.CM_MONTANTDEBIT ;
			SqlParameter vppParamCM_MONTANTCREDIT = new SqlParameter("@CM_MONTANTCREDIT", SqlDbType.Money);
			vppParamCM_MONTANTCREDIT.Value  = clsCtcontratcommissionassurance.CM_MONTANTCREDIT ;
			SqlParameter vppParamCM_ANNULER = new SqlParameter("@CM_ANNULER", SqlDbType.VarChar, 1);
			vppParamCM_ANNULER.Value  = clsCtcontratcommissionassurance.CM_ANNULER ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontratcommissionassurance.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCOMMISSIONASSURANCE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CM_DATEPIECE, @CM_NUMPIECE, @CM_NUMSEQUENCE, @CM_REFERENCEPIECE, @CA_CODECONTRAT, @CM_LIBELLEOPERATION, @CM_MONTANTDEBIT, @CM_MONTANTCREDIT, @CM_ANNULER, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCM_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCM_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamCM_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCM_REFERENCEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamCM_LIBELLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamCM_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamCM_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamCM_ANNULER);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratcommissionassurance>clsCtcontratcommissionassurance</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratcommissionassurance clsCtcontratcommissionassurance,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratcommissionassurance.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratcommissionassurance.EN_CODEENTREPOT ;
			SqlParameter vppParamCM_DATEPIECE = new SqlParameter("@CM_DATEPIECE", SqlDbType.DateTime);
			vppParamCM_DATEPIECE.Value  = clsCtcontratcommissionassurance.CM_DATEPIECE ;
			SqlParameter vppParamCM_NUMPIECE = new SqlParameter("@CM_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamCM_NUMPIECE.Value  = clsCtcontratcommissionassurance.CM_NUMPIECE ;
			SqlParameter vppParamCM_NUMSEQUENCE = new SqlParameter("@CM_NUMSEQUENCE", SqlDbType.VarChar, 50);
			vppParamCM_NUMSEQUENCE.Value  = clsCtcontratcommissionassurance.CM_NUMSEQUENCE ;
			SqlParameter vppParamCM_REFERENCEPIECE = new SqlParameter("@CM_REFERENCEPIECE", SqlDbType.VarChar, 1000);
			vppParamCM_REFERENCEPIECE.Value  = clsCtcontratcommissionassurance.CM_REFERENCEPIECE ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratcommissionassurance.CA_CODECONTRAT ;
			SqlParameter vppParamCM_LIBELLEOPERATION = new SqlParameter("@CM_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
			vppParamCM_LIBELLEOPERATION.Value  = clsCtcontratcommissionassurance.CM_LIBELLEOPERATION ;
			SqlParameter vppParamCM_MONTANTDEBIT = new SqlParameter("@CM_MONTANTDEBIT", SqlDbType.Money);
			vppParamCM_MONTANTDEBIT.Value  = clsCtcontratcommissionassurance.CM_MONTANTDEBIT ;
			SqlParameter vppParamCM_MONTANTCREDIT = new SqlParameter("@CM_MONTANTCREDIT", SqlDbType.Money);
			vppParamCM_MONTANTCREDIT.Value  = clsCtcontratcommissionassurance.CM_MONTANTCREDIT ;
			SqlParameter vppParamCM_ANNULER = new SqlParameter("@CM_ANNULER", SqlDbType.VarChar, 1);
			vppParamCM_ANNULER.Value  = clsCtcontratcommissionassurance.CM_ANNULER ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontratcommissionassurance.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCOMMISSIONASSURANCE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CM_DATEPIECE, @CM_NUMPIECE, @CM_NUMSEQUENCE, @CM_REFERENCEPIECE, @CA_CODECONTRAT, @CM_LIBELLEOPERATION, @CM_MONTANTDEBIT, @CM_MONTANTCREDIT, @CM_ANNULER, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCM_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCM_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamCM_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCM_REFERENCEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamCM_LIBELLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamCM_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamCM_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamCM_ANNULER);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCOMMISSIONASSURANCE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CM_DATEPIECE, @CM_NUMPIECE, @CM_NUMSEQUENCE, '' , @CA_CODECONTRAT, '' , '' , '' , '' , @OP_CODEOPERATEUR, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratcommissionassurance </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratcommissionassurance> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CM_REFERENCEPIECE, CA_CODECONTRAT, CM_LIBELLEOPERATION, CM_MONTANTDEBIT, CM_MONTANTCREDIT, CM_ANNULER, OP_CODEOPERATEUR FROM dbo.FT_CTCONTRATCOMMISSIONASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratcommissionassurance> clsCtcontratcommissionassurances = new List<clsCtcontratcommissionassurance>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratcommissionassurance clsCtcontratcommissionassurance = new clsCtcontratcommissionassurance();
					clsCtcontratcommissionassurance.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratcommissionassurance.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratcommissionassurance.CM_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["CM_DATEPIECE"].ToString());
					clsCtcontratcommissionassurance.CM_NUMPIECE = clsDonnee.vogDataReader["CM_NUMPIECE"].ToString();
					clsCtcontratcommissionassurance.CM_NUMSEQUENCE = clsDonnee.vogDataReader["CM_NUMSEQUENCE"].ToString();
					clsCtcontratcommissionassurance.CM_REFERENCEPIECE = clsDonnee.vogDataReader["CM_REFERENCEPIECE"].ToString();
					clsCtcontratcommissionassurance.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratcommissionassurance.CM_LIBELLEOPERATION = clsDonnee.vogDataReader["CM_LIBELLEOPERATION"].ToString();
					clsCtcontratcommissionassurance.CM_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["CM_MONTANTDEBIT"].ToString());
					clsCtcontratcommissionassurance.CM_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["CM_MONTANTCREDIT"].ToString());
					clsCtcontratcommissionassurance.CM_ANNULER = clsDonnee.vogDataReader["CM_ANNULER"].ToString();
					clsCtcontratcommissionassurance.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtcontratcommissionassurances.Add(clsCtcontratcommissionassurance);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratcommissionassurances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratcommissionassurance </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratcommissionassurance> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratcommissionassurance> clsCtcontratcommissionassurances = new List<clsCtcontratcommissionassurance>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CM_REFERENCEPIECE, CA_CODECONTRAT, CM_LIBELLEOPERATION, CM_MONTANTDEBIT, CM_MONTANTCREDIT, CM_ANNULER, OP_CODEOPERATEUR FROM dbo.FT_CTCONTRATCOMMISSIONASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratcommissionassurance clsCtcontratcommissionassurance = new clsCtcontratcommissionassurance();
					clsCtcontratcommissionassurance.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratcommissionassurance.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratcommissionassurance.CM_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CM_DATEPIECE"].ToString());
					clsCtcontratcommissionassurance.CM_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["CM_NUMPIECE"].ToString();
					clsCtcontratcommissionassurance.CM_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["CM_NUMSEQUENCE"].ToString();
					clsCtcontratcommissionassurance.CM_REFERENCEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["CM_REFERENCEPIECE"].ToString();
					clsCtcontratcommissionassurance.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratcommissionassurance.CM_LIBELLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["CM_LIBELLEOPERATION"].ToString();
					clsCtcontratcommissionassurance.CM_MONTANTDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CM_MONTANTDEBIT"].ToString());
					clsCtcontratcommissionassurance.CM_MONTANTCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CM_MONTANTCREDIT"].ToString());
					clsCtcontratcommissionassurance.CM_ANNULER = Dataset.Tables["TABLE"].Rows[Idx]["CM_ANNULER"].ToString();
					clsCtcontratcommissionassurance.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtcontratcommissionassurances.Add(clsCtcontratcommissionassurance);
				}
				Dataset.Dispose();
			}
		return clsCtcontratcommissionassurances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTCONTRATCOMMISSIONASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , CM_REFERENCEPIECE FROM dbo.FT_CTCONTRATCOMMISSIONASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT, CM_DATEPIECE, CM_NUMPIECE, CM_NUMSEQUENCE, CA_CODECONTRAT, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CM_DATEPIECE=@CM_DATEPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CM_DATEPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CM_DATEPIECE=@CM_DATEPIECE AND CM_NUMPIECE=@CM_NUMPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CM_DATEPIECE","@CM_NUMPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CM_DATEPIECE=@CM_DATEPIECE AND CM_NUMPIECE=@CM_NUMPIECE AND CM_NUMSEQUENCE=@CM_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CM_DATEPIECE","@CM_NUMPIECE","@CM_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CM_DATEPIECE=@CM_DATEPIECE AND CM_NUMPIECE=@CM_NUMPIECE AND CM_NUMSEQUENCE=@CM_NUMSEQUENCE AND CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CM_DATEPIECE","@CM_NUMPIECE","@CM_NUMSEQUENCE","@CA_CODECONTRAT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
				case 7 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CM_DATEPIECE=@CM_DATEPIECE AND CM_NUMPIECE=@CM_NUMPIECE AND CM_NUMSEQUENCE=@CM_NUMSEQUENCE AND CA_CODECONTRAT=@CA_CODECONTRAT AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CM_DATEPIECE","@CM_NUMPIECE","@CM_NUMSEQUENCE","@CA_CODECONTRAT","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
				break;
			}
		}
	}
}
