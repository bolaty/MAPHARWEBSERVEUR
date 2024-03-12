using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsMicbudgetdetailhistoWSDAL: ITableDAL<clsMicbudgetdetailhisto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(BU_CODEBUDGET) AS BU_CODEBUDGET  FROM dbo.FT_MICBUDGETDETAILHISTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(BU_CODEBUDGET) AS BU_CODEBUDGET  FROM dbo.FT_MICBUDGETDETAILHISTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(BU_CODEBUDGET) AS BU_CODEBUDGET  FROM dbo.FT_MICBUDGETDETAILHISTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMicbudgetdetailhisto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMicbudgetdetailhisto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT BG_CODEPOSTEBUDGETAIRE  , SR_CODESERVICE  , BE_DATEDEBUT  , BE_DATEFIN  , TY_TYPEBUDGETDEATAIL  , AG_CODEAGENCE  , PV_CODEPOINTVENTE  , PE_CODEPERIODICITE  , BE_MONTANT  , BE_DATESAISIE  , BE_DATEVALIDATION  , OP_CODEOPERATEURVALIDATION  , OP_CODEOPERATEUR  , BU_CODEBUDGETLIAISON  , BE_MONTANTREALISATIONMONTANT  , BE_MONTANTREALISATIONTAUX  , BE_MONTANTSOLDE  , BE_OBSERVATION  , BN_CODENATUREPOSTEBUDGETAIRE  , BT_CODETYPEBUDGET  , BD_CODETYPEBUDGETDETAIL  , OP_CODEOPERATEURBUDGETDETAIL  FROM dbo.FT_MICBUDGETDETAILHISTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsMicbudgetdetailhisto clsMicbudgetdetailhisto = new clsMicbudgetdetailhisto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicbudgetdetailhisto.BG_CODEPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BG_CODEPOSTEBUDGETAIRE"].ToString();
					clsMicbudgetdetailhisto.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsMicbudgetdetailhisto.BE_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEDEBUT"].ToString());
					clsMicbudgetdetailhisto.BE_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEFIN"].ToString());
					clsMicbudgetdetailhisto.TY_TYPEBUDGETDEATAIL = clsDonnee.vogDataReader["TY_TYPEBUDGETDEATAIL"].ToString();
					clsMicbudgetdetailhisto.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsMicbudgetdetailhisto.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsMicbudgetdetailhisto.PE_CODEPERIODICITE = clsDonnee.vogDataReader["PE_CODEPERIODICITE"].ToString();
					clsMicbudgetdetailhisto.BE_MONTANT = double.Parse(clsDonnee.vogDataReader["BE_MONTANT"].ToString());
					clsMicbudgetdetailhisto.BE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["BE_DATESAISIE"].ToString());
					clsMicbudgetdetailhisto.BE_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEVALIDATION"].ToString());
					clsMicbudgetdetailhisto.OP_CODEOPERATEURVALIDATION = clsDonnee.vogDataReader["OP_CODEOPERATEURVALIDATION"].ToString();
					clsMicbudgetdetailhisto.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsMicbudgetdetailhisto.BU_CODEBUDGETLIAISON = clsDonnee.vogDataReader["BU_CODEBUDGETLIAISON"].ToString();
					clsMicbudgetdetailhisto.BE_MONTANTREALISATIONMONTANT = double.Parse(clsDonnee.vogDataReader["BE_MONTANTREALISATIONMONTANT"].ToString());
					clsMicbudgetdetailhisto.BE_MONTANTREALISATIONTAUX = double.Parse(clsDonnee.vogDataReader["BE_MONTANTREALISATIONTAUX"].ToString());
					clsMicbudgetdetailhisto.BE_MONTANTSOLDE = double.Parse(clsDonnee.vogDataReader["BE_MONTANTSOLDE"].ToString());
					clsMicbudgetdetailhisto.BE_OBSERVATION = clsDonnee.vogDataReader["BE_OBSERVATION"].ToString();
					clsMicbudgetdetailhisto.BN_CODENATUREPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
					clsMicbudgetdetailhisto.BT_CODETYPEBUDGET = clsDonnee.vogDataReader["BT_CODETYPEBUDGET"].ToString();
					clsMicbudgetdetailhisto.BD_CODETYPEBUDGETDETAIL = clsDonnee.vogDataReader["BD_CODETYPEBUDGETDETAIL"].ToString();
					clsMicbudgetdetailhisto.OP_CODEOPERATEURBUDGETDETAIL = clsDonnee.vogDataReader["OP_CODEOPERATEURBUDGETDETAIL"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsMicbudgetdetailhisto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMicbudgetdetailhisto>clsMicbudgetdetailhisto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMicbudgetdetailhisto clsMicbudgetdetailhisto)
		{
			//Préparation des paramètres
			SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET", SqlDbType.VarChar, 25);
			vppParamBU_CODEBUDGET.Value  = clsMicbudgetdetailhisto.BU_CODEBUDGET ;
			SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE", SqlDbType.VarChar, 7);
			vppParamBG_CODEPOSTEBUDGETAIRE.Value  = clsMicbudgetdetailhisto.BG_CODEPOSTEBUDGETAIRE ;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsMicbudgetdetailhisto.SR_CODESERVICE ;
			SqlParameter vppParamBE_DATEDEBUT = new SqlParameter("@BE_DATEDEBUT1", SqlDbType.DateTime);
			vppParamBE_DATEDEBUT.Value  = clsMicbudgetdetailhisto.BE_DATEDEBUT ;
			SqlParameter vppParamBE_DATEFIN = new SqlParameter("@BE_DATEFIN1", SqlDbType.DateTime);
			vppParamBE_DATEFIN.Value  = clsMicbudgetdetailhisto.BE_DATEFIN ;
			SqlParameter vppParamTY_TYPEBUDGETDEATAIL = new SqlParameter("@TY_TYPEBUDGETDEATAIL1", SqlDbType.VarChar, 1);
			vppParamTY_TYPEBUDGETDEATAIL.Value  = clsMicbudgetdetailhisto.TY_TYPEBUDGETDEATAIL ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsMicbudgetdetailhisto.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 4);
			vppParamPV_CODEPOINTVENTE.Value  = clsMicbudgetdetailhisto.PV_CODEPOINTVENTE ;
			if(clsMicbudgetdetailhisto.PV_CODEPOINTVENTE== ""  ) vppParamPV_CODEPOINTVENTE.Value  = DBNull.Value;
			SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE", SqlDbType.VarChar, 2);
			vppParamPE_CODEPERIODICITE.Value  = clsMicbudgetdetailhisto.PE_CODEPERIODICITE ;
			SqlParameter vppParamBE_MONTANT = new SqlParameter("@BE_MONTANT", SqlDbType.Money);
			vppParamBE_MONTANT.Value  = clsMicbudgetdetailhisto.BE_MONTANT ;
			SqlParameter vppParamBE_DATESAISIE = new SqlParameter("@BE_DATESAISIE", SqlDbType.DateTime);
			vppParamBE_DATESAISIE.Value  = clsMicbudgetdetailhisto.BE_DATESAISIE ;
			SqlParameter vppParamBE_DATEVALIDATION = new SqlParameter("@BE_DATEVALIDATION", SqlDbType.DateTime);
			vppParamBE_DATEVALIDATION.Value  = clsMicbudgetdetailhisto.BE_DATEVALIDATION ;
			SqlParameter vppParamOP_CODEOPERATEURVALIDATION = new SqlParameter("@OP_CODEOPERATEURVALIDATION", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEURVALIDATION.Value  = clsMicbudgetdetailhisto.OP_CODEOPERATEURVALIDATION ;
			if(clsMicbudgetdetailhisto.OP_CODEOPERATEURVALIDATION== ""  ) vppParamOP_CODEOPERATEURVALIDATION.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsMicbudgetdetailhisto.OP_CODEOPERATEUR ;
			SqlParameter vppParamBU_CODEBUDGETLIAISON = new SqlParameter("@BU_CODEBUDGETLIAISON", SqlDbType.VarChar, 25);
			vppParamBU_CODEBUDGETLIAISON.Value  = clsMicbudgetdetailhisto.BU_CODEBUDGETLIAISON ;
			if(clsMicbudgetdetailhisto.BU_CODEBUDGETLIAISON== ""  ) vppParamBU_CODEBUDGETLIAISON.Value  = DBNull.Value;
			SqlParameter vppParamBE_MONTANTREALISATIONMONTANT = new SqlParameter("@BE_MONTANTREALISATIONMONTANT", SqlDbType.Money);
			vppParamBE_MONTANTREALISATIONMONTANT.Value  = clsMicbudgetdetailhisto.BE_MONTANTREALISATIONMONTANT ;
			if(clsMicbudgetdetailhisto.BE_MONTANTREALISATIONMONTANT== 0  ) vppParamBE_MONTANTREALISATIONMONTANT.Value  = DBNull.Value;
			SqlParameter vppParamBE_MONTANTREALISATIONTAUX = new SqlParameter("@BE_MONTANTREALISATIONTAUX", SqlDbType.Money);
			vppParamBE_MONTANTREALISATIONTAUX.Value  = clsMicbudgetdetailhisto.BE_MONTANTREALISATIONTAUX ;
			if(clsMicbudgetdetailhisto.BE_MONTANTREALISATIONTAUX== 0 ) vppParamBE_MONTANTREALISATIONTAUX.Value  = DBNull.Value;
			SqlParameter vppParamBE_MONTANTSOLDE = new SqlParameter("@BE_MONTANTSOLDE", SqlDbType.Money);
			vppParamBE_MONTANTSOLDE.Value  = clsMicbudgetdetailhisto.BE_MONTANTSOLDE ;
			if(clsMicbudgetdetailhisto.BE_MONTANTSOLDE==0  ) vppParamBE_MONTANTSOLDE.Value  = DBNull.Value;
			SqlParameter vppParamBE_OBSERVATION = new SqlParameter("@BE_OBSERVATION", SqlDbType.VarChar, 150);
			vppParamBE_OBSERVATION.Value  = clsMicbudgetdetailhisto.BE_OBSERVATION ;
			if(clsMicbudgetdetailhisto.BE_OBSERVATION== ""  ) vppParamBE_OBSERVATION.Value  = DBNull.Value;
			SqlParameter vppParamBN_CODENATUREPOSTEBUDGETAIRE = new SqlParameter("@BN_CODENATUREPOSTEBUDGETAIRE", SqlDbType.VarChar, 3);
			vppParamBN_CODENATUREPOSTEBUDGETAIRE.Value  = clsMicbudgetdetailhisto.BN_CODENATUREPOSTEBUDGETAIRE ;
			if(clsMicbudgetdetailhisto.BN_CODENATUREPOSTEBUDGETAIRE== ""  ) vppParamBN_CODENATUREPOSTEBUDGETAIRE.Value  = DBNull.Value;
			SqlParameter vppParamBT_CODETYPEBUDGET = new SqlParameter("@BT_CODETYPEBUDGET1", SqlDbType.VarChar, 3);
			vppParamBT_CODETYPEBUDGET.Value  = clsMicbudgetdetailhisto.BT_CODETYPEBUDGET ;
			if(clsMicbudgetdetailhisto.BT_CODETYPEBUDGET== ""  ) vppParamBT_CODETYPEBUDGET.Value  = DBNull.Value;
			SqlParameter vppParamBD_CODETYPEBUDGETDETAIL = new SqlParameter("@BD_CODETYPEBUDGETDETAIL", SqlDbType.VarChar, 4);
			vppParamBD_CODETYPEBUDGETDETAIL.Value  = clsMicbudgetdetailhisto.BD_CODETYPEBUDGETDETAIL ;
			if(clsMicbudgetdetailhisto.BD_CODETYPEBUDGETDETAIL== ""  ) vppParamBD_CODETYPEBUDGETDETAIL.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEURBUDGETDETAIL = new SqlParameter("@OP_CODEOPERATEURBUDGETDETAIL", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEURBUDGETDETAIL.Value  = clsMicbudgetdetailhisto.OP_CODEOPERATEURBUDGETDETAIL ;
			if(clsMicbudgetdetailhisto.OP_CODEOPERATEURBUDGETDETAIL== ""  ) vppParamOP_CODEOPERATEURBUDGETDETAIL.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MICBUDGETDETAILHISTO  @BU_CODEBUDGET, @BG_CODEPOSTEBUDGETAIRE, @SR_CODESERVICE, @BE_DATEDEBUT1, @BE_DATEFIN1, @TY_TYPEBUDGETDEATAIL1, @AG_CODEAGENCE1, @PV_CODEPOINTVENTE, @PE_CODEPERIODICITE, @BE_MONTANT, @BE_DATESAISIE, @BE_DATEVALIDATION, @OP_CODEOPERATEURVALIDATION, @OP_CODEOPERATEUR, @BU_CODEBUDGETLIAISON, @BE_MONTANTREALISATIONMONTANT, @BE_MONTANTREALISATIONTAUX, @BE_MONTANTSOLDE, @BE_OBSERVATION, @BN_CODENATUREPOSTEBUDGETAIRE, @BT_CODETYPEBUDGET1, @BD_CODETYPEBUDGETDETAIL, @OP_CODEOPERATEURBUDGETDETAIL, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
			vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamBE_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamBE_DATEFIN);
			vppSqlCmd.Parameters.Add(vppParamTY_TYPEBUDGETDEATAIL);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);
			vppSqlCmd.Parameters.Add(vppParamBE_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamBE_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamBE_DATEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGETLIAISON);
			vppSqlCmd.Parameters.Add(vppParamBE_MONTANTREALISATIONMONTANT);
			vppSqlCmd.Parameters.Add(vppParamBE_MONTANTREALISATIONTAUX);
			vppSqlCmd.Parameters.Add(vppParamBE_MONTANTSOLDE);
			vppSqlCmd.Parameters.Add(vppParamBE_OBSERVATION);
			vppSqlCmd.Parameters.Add(vppParamBN_CODENATUREPOSTEBUDGETAIRE);
			vppSqlCmd.Parameters.Add(vppParamBT_CODETYPEBUDGET);
			vppSqlCmd.Parameters.Add(vppParamBD_CODETYPEBUDGETDETAIL);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURBUDGETDETAIL);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMicbudgetdetailhisto>clsMicbudgetdetailhisto</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMicbudgetdetailhisto clsMicbudgetdetailhisto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET", SqlDbType.VarChar, 25);
			vppParamBU_CODEBUDGET.Value  = clsMicbudgetdetailhisto.BU_CODEBUDGET ;
			SqlParameter vppParamBG_CODEPOSTEBUDGETAIRE = new SqlParameter("@BG_CODEPOSTEBUDGETAIRE", SqlDbType.VarChar, 7);
			vppParamBG_CODEPOSTEBUDGETAIRE.Value  = clsMicbudgetdetailhisto.BG_CODEPOSTEBUDGETAIRE ;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsMicbudgetdetailhisto.SR_CODESERVICE ;
			SqlParameter vppParamBE_DATEDEBUT = new SqlParameter("@BE_DATEDEBUT", SqlDbType.DateTime);
			vppParamBE_DATEDEBUT.Value  = clsMicbudgetdetailhisto.BE_DATEDEBUT ;
			SqlParameter vppParamBE_DATEFIN = new SqlParameter("@BE_DATEFIN", SqlDbType.DateTime);
			vppParamBE_DATEFIN.Value  = clsMicbudgetdetailhisto.BE_DATEFIN ;
			SqlParameter vppParamTY_TYPEBUDGETDEATAIL = new SqlParameter("@TY_TYPEBUDGETDEATAIL", SqlDbType.VarChar, 1);
			vppParamTY_TYPEBUDGETDEATAIL.Value  = clsMicbudgetdetailhisto.TY_TYPEBUDGETDEATAIL ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsMicbudgetdetailhisto.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 4);
			vppParamPV_CODEPOINTVENTE.Value  = clsMicbudgetdetailhisto.PV_CODEPOINTVENTE ;
			if(clsMicbudgetdetailhisto.PV_CODEPOINTVENTE== ""  ) vppParamPV_CODEPOINTVENTE.Value  = DBNull.Value;
			SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE", SqlDbType.VarChar, 2);
			vppParamPE_CODEPERIODICITE.Value  = clsMicbudgetdetailhisto.PE_CODEPERIODICITE ;
			SqlParameter vppParamBE_MONTANT = new SqlParameter("@BE_MONTANT", SqlDbType.Money);
			vppParamBE_MONTANT.Value  = clsMicbudgetdetailhisto.BE_MONTANT ;
			SqlParameter vppParamBE_DATESAISIE = new SqlParameter("@BE_DATESAISIE", SqlDbType.DateTime);
			vppParamBE_DATESAISIE.Value  = clsMicbudgetdetailhisto.BE_DATESAISIE ;
			SqlParameter vppParamBE_DATEVALIDATION = new SqlParameter("@BE_DATEVALIDATION", SqlDbType.DateTime);
			vppParamBE_DATEVALIDATION.Value  = clsMicbudgetdetailhisto.BE_DATEVALIDATION ;
			SqlParameter vppParamOP_CODEOPERATEURVALIDATION = new SqlParameter("@OP_CODEOPERATEURVALIDATION", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEURVALIDATION.Value  = clsMicbudgetdetailhisto.OP_CODEOPERATEURVALIDATION ;
			if(clsMicbudgetdetailhisto.OP_CODEOPERATEURVALIDATION== ""  ) vppParamOP_CODEOPERATEURVALIDATION.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsMicbudgetdetailhisto.OP_CODEOPERATEUR ;
			SqlParameter vppParamBU_CODEBUDGETLIAISON = new SqlParameter("@BU_CODEBUDGETLIAISON", SqlDbType.VarChar, 25);
			vppParamBU_CODEBUDGETLIAISON.Value  = clsMicbudgetdetailhisto.BU_CODEBUDGETLIAISON ;
			if(clsMicbudgetdetailhisto.BU_CODEBUDGETLIAISON== ""  ) vppParamBU_CODEBUDGETLIAISON.Value  = DBNull.Value;
			SqlParameter vppParamBE_MONTANTREALISATIONMONTANT = new SqlParameter("@BE_MONTANTREALISATIONMONTANT", SqlDbType.Money);
			vppParamBE_MONTANTREALISATIONMONTANT.Value  = clsMicbudgetdetailhisto.BE_MONTANTREALISATIONMONTANT ;
			if(clsMicbudgetdetailhisto.BE_MONTANTREALISATIONMONTANT== 0  ) vppParamBE_MONTANTREALISATIONMONTANT.Value  = DBNull.Value;
			SqlParameter vppParamBE_MONTANTREALISATIONTAUX = new SqlParameter("@BE_MONTANTREALISATIONTAUX", SqlDbType.Money);
			vppParamBE_MONTANTREALISATIONTAUX.Value  = clsMicbudgetdetailhisto.BE_MONTANTREALISATIONTAUX ;
			if(clsMicbudgetdetailhisto.BE_MONTANTREALISATIONTAUX== 0 ) vppParamBE_MONTANTREALISATIONTAUX.Value  = DBNull.Value;
			SqlParameter vppParamBE_MONTANTSOLDE = new SqlParameter("@BE_MONTANTSOLDE", SqlDbType.Money);
			vppParamBE_MONTANTSOLDE.Value  = clsMicbudgetdetailhisto.BE_MONTANTSOLDE ;
			if(clsMicbudgetdetailhisto.BE_MONTANTSOLDE== 0 ) vppParamBE_MONTANTSOLDE.Value  = DBNull.Value;
			SqlParameter vppParamBE_OBSERVATION = new SqlParameter("@BE_OBSERVATION", SqlDbType.VarChar, 150);
			vppParamBE_OBSERVATION.Value  = clsMicbudgetdetailhisto.BE_OBSERVATION ;
			if(clsMicbudgetdetailhisto.BE_OBSERVATION== ""  ) vppParamBE_OBSERVATION.Value  = DBNull.Value;
			SqlParameter vppParamBN_CODENATUREPOSTEBUDGETAIRE = new SqlParameter("@BN_CODENATUREPOSTEBUDGETAIRE", SqlDbType.VarChar, 3);
			vppParamBN_CODENATUREPOSTEBUDGETAIRE.Value  = clsMicbudgetdetailhisto.BN_CODENATUREPOSTEBUDGETAIRE ;
			if(clsMicbudgetdetailhisto.BN_CODENATUREPOSTEBUDGETAIRE== ""  ) vppParamBN_CODENATUREPOSTEBUDGETAIRE.Value  = DBNull.Value;
			SqlParameter vppParamBT_CODETYPEBUDGET = new SqlParameter("@BT_CODETYPEBUDGET", SqlDbType.VarChar, 3);
			vppParamBT_CODETYPEBUDGET.Value  = clsMicbudgetdetailhisto.BT_CODETYPEBUDGET ;
			if(clsMicbudgetdetailhisto.BT_CODETYPEBUDGET== ""  ) vppParamBT_CODETYPEBUDGET.Value  = DBNull.Value;
			SqlParameter vppParamBD_CODETYPEBUDGETDETAIL = new SqlParameter("@BD_CODETYPEBUDGETDETAIL", SqlDbType.VarChar, 4);
			vppParamBD_CODETYPEBUDGETDETAIL.Value  = clsMicbudgetdetailhisto.BD_CODETYPEBUDGETDETAIL ;
			if(clsMicbudgetdetailhisto.BD_CODETYPEBUDGETDETAIL== ""  ) vppParamBD_CODETYPEBUDGETDETAIL.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEURBUDGETDETAIL = new SqlParameter("@OP_CODEOPERATEURBUDGETDETAIL", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEURBUDGETDETAIL.Value  = clsMicbudgetdetailhisto.OP_CODEOPERATEURBUDGETDETAIL ;
			if(clsMicbudgetdetailhisto.OP_CODEOPERATEURBUDGETDETAIL== ""  ) vppParamOP_CODEOPERATEURBUDGETDETAIL.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MICBUDGETDETAILHISTO  @BU_CODEBUDGET, @BG_CODEPOSTEBUDGETAIRE, @SR_CODESERVICE, @BE_DATEDEBUT, @BE_DATEFIN, @TY_TYPEBUDGETDEATAIL, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @PE_CODEPERIODICITE, @BE_MONTANT, @BE_DATESAISIE, @BE_DATEVALIDATION, @OP_CODEOPERATEURVALIDATION, @OP_CODEOPERATEUR, @BU_CODEBUDGETLIAISON, @BE_MONTANTREALISATIONMONTANT, @BE_MONTANTREALISATIONTAUX, @BE_MONTANTSOLDE, @BE_OBSERVATION, @BN_CODENATUREPOSTEBUDGETAIRE, @BT_CODETYPEBUDGET, @BD_CODETYPEBUDGETDETAIL, @OP_CODEOPERATEURBUDGETDETAIL, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
			vppSqlCmd.Parameters.Add(vppParamBG_CODEPOSTEBUDGETAIRE);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamBE_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamBE_DATEFIN);
			vppSqlCmd.Parameters.Add(vppParamTY_TYPEBUDGETDEATAIL);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);
			vppSqlCmd.Parameters.Add(vppParamBE_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamBE_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamBE_DATEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGETLIAISON);
			vppSqlCmd.Parameters.Add(vppParamBE_MONTANTREALISATIONMONTANT);
			vppSqlCmd.Parameters.Add(vppParamBE_MONTANTREALISATIONTAUX);
			vppSqlCmd.Parameters.Add(vppParamBE_MONTANTSOLDE);
			vppSqlCmd.Parameters.Add(vppParamBE_OBSERVATION);
			vppSqlCmd.Parameters.Add(vppParamBN_CODENATUREPOSTEBUDGETAIRE);
			vppSqlCmd.Parameters.Add(vppParamBT_CODETYPEBUDGET);
			vppSqlCmd.Parameters.Add(vppParamBD_CODETYPEBUDGETDETAIL);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURBUDGETDETAIL);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MICBUDGETDETAILHISTO '', '', '', @BE_DATEDEBUT, @BE_DATEFIN, @TY_TYPEBUDGETDEATAIL, @AG_CODEAGENCE, '' , '', '' , '' , '' ,'', '', '' , '' , '' , '' , '' , '' ,@BT_CODETYPEBUDGET , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete1(clsDonnee clsDonnee,params string[] vppCritere)
        {
	        pvpChoixCritere(clsDonnee ,vppCritere);
	        //Préparation de la commande
		        this.vapRequete = "EXECUTE PC_MICBUDGETDETAILHISTO '', '', '', @BE_DATEDEBUT, @BE_DATEFIN, @TY_TYPEBUDGETDEATAIL, @AG_CODEAGENCE, '' , '', '' , '' , '' ,'', '', '' , '' , '' , '' , '' , '' ,'' , '' , '' , @CODECRYPTAGE, 3 ";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

	        //Ouverture de la connection et exécution de la commande
	        clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }



        public void pvgMajSoldePoste(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE2", "@PV_CODEPOINTVENTE2", "@BE_DATEDEBUT2", "@BE_DATEFIN2", "@BU_CODEBUDGET2", "@BG_CODEPOSTEBUDGETAIRE2", "@SR_CODESERVICE2", "@PE_CODEPERIODICITE2", "@BE_MONTANTREALISATIONMONTANT2", "@BE_MONTANTREALISATIONTAUX2", "@BE_MONTANTSOLDE2", "@OP_CODEOPERATEUR2", "@CODEDECRYPTAGE2" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],vppCritere[5],vppCritere[6], vppCritere[7],vppCritere[8],vppCritere[9], vppCritere[10],vppCritere[11], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC [dbo].[PS_MICBUDGETDETAILHISTO] @AG_CODEAGENCE2,@PV_CODEPOINTVENTE2,@BE_DATEDEBUT2,@BE_DATEFIN2,@BU_CODEBUDGET2,@BG_CODEPOSTEBUDGETAIRE2,@SR_CODESERVICE2,@PE_CODEPERIODICITE2,@BE_MONTANTREALISATIONMONTANT2,@BE_MONTANTREALISATIONTAUX2,@BE_MONTANTSOLDE2,@OP_CODEOPERATEUR2,@CODEDECRYPTAGE2";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }





        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMicbudgetdetailhisto </returns>
        ///<author>Home Technology</author>
        public List<clsMicbudgetdetailhisto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PV_CODEPOINTVENTE, PE_CODEPERIODICITE, BE_MONTANT, BE_DATESAISIE, BE_DATEVALIDATION, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR, BU_CODEBUDGETLIAISON, BE_MONTANTREALISATIONMONTANT, BE_MONTANTREALISATIONTAUX, BE_MONTANTSOLDE, BE_OBSERVATION, BN_CODENATUREPOSTEBUDGETAIRE, BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL, OP_CODEOPERATEURBUDGETDETAIL FROM dbo.FT_MICBUDGETDETAILHISTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsMicbudgetdetailhisto> clsMicbudgetdetailhistos = new List<clsMicbudgetdetailhisto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicbudgetdetailhisto clsMicbudgetdetailhisto = new clsMicbudgetdetailhisto();
					clsMicbudgetdetailhisto.BU_CODEBUDGET = clsDonnee.vogDataReader["BU_CODEBUDGET"].ToString();
					clsMicbudgetdetailhisto.BG_CODEPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BG_CODEPOSTEBUDGETAIRE"].ToString();
					clsMicbudgetdetailhisto.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsMicbudgetdetailhisto.BE_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEDEBUT"].ToString());
					clsMicbudgetdetailhisto.BE_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEFIN"].ToString());
					clsMicbudgetdetailhisto.TY_TYPEBUDGETDEATAIL = clsDonnee.vogDataReader["TY_TYPEBUDGETDEATAIL"].ToString();
					clsMicbudgetdetailhisto.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsMicbudgetdetailhisto.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsMicbudgetdetailhisto.PE_CODEPERIODICITE = clsDonnee.vogDataReader["PE_CODEPERIODICITE"].ToString();
					clsMicbudgetdetailhisto.BE_MONTANT = double.Parse(clsDonnee.vogDataReader["BE_MONTANT"].ToString());
					clsMicbudgetdetailhisto.BE_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["BE_DATESAISIE"].ToString());
					clsMicbudgetdetailhisto.BE_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["BE_DATEVALIDATION"].ToString());
					clsMicbudgetdetailhisto.OP_CODEOPERATEURVALIDATION = clsDonnee.vogDataReader["OP_CODEOPERATEURVALIDATION"].ToString();
					clsMicbudgetdetailhisto.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsMicbudgetdetailhisto.BU_CODEBUDGETLIAISON = clsDonnee.vogDataReader["BU_CODEBUDGETLIAISON"].ToString();
					clsMicbudgetdetailhisto.BE_MONTANTREALISATIONMONTANT = double.Parse(clsDonnee.vogDataReader["BE_MONTANTREALISATIONMONTANT"].ToString());
					clsMicbudgetdetailhisto.BE_MONTANTREALISATIONTAUX = double.Parse(clsDonnee.vogDataReader["BE_MONTANTREALISATIONTAUX"].ToString());
					clsMicbudgetdetailhisto.BE_MONTANTSOLDE = double.Parse(clsDonnee.vogDataReader["BE_MONTANTSOLDE"].ToString());
					clsMicbudgetdetailhisto.BE_OBSERVATION = clsDonnee.vogDataReader["BE_OBSERVATION"].ToString();
					clsMicbudgetdetailhisto.BN_CODENATUREPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
					clsMicbudgetdetailhisto.BT_CODETYPEBUDGET = clsDonnee.vogDataReader["BT_CODETYPEBUDGET"].ToString();
					clsMicbudgetdetailhisto.BD_CODETYPEBUDGETDETAIL = clsDonnee.vogDataReader["BD_CODETYPEBUDGETDETAIL"].ToString();
					clsMicbudgetdetailhisto.OP_CODEOPERATEURBUDGETDETAIL = clsDonnee.vogDataReader["OP_CODEOPERATEURBUDGETDETAIL"].ToString();
					clsMicbudgetdetailhistos.Add(clsMicbudgetdetailhisto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsMicbudgetdetailhistos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicbudgetdetailhisto </returns>
		///<author>Home Technology</author>
		public List<clsMicbudgetdetailhisto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsMicbudgetdetailhisto> clsMicbudgetdetailhistos = new List<clsMicbudgetdetailhisto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PV_CODEPOINTVENTE, PE_CODEPERIODICITE, BE_MONTANT, BE_DATESAISIE, BE_DATEVALIDATION, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR, BU_CODEBUDGETLIAISON, BE_MONTANTREALISATIONMONTANT, BE_MONTANTREALISATIONTAUX, BE_MONTANTSOLDE, BE_OBSERVATION, BN_CODENATUREPOSTEBUDGETAIRE, BT_CODETYPEBUDGET, BD_CODETYPEBUDGETDETAIL, OP_CODEOPERATEURBUDGETDETAIL FROM dbo.FT_MICBUDGETDETAILHISTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsMicbudgetdetailhisto clsMicbudgetdetailhisto = new clsMicbudgetdetailhisto();
					clsMicbudgetdetailhisto.BU_CODEBUDGET = Dataset.Tables["TABLE"].Rows[Idx]["BU_CODEBUDGET"].ToString();
					clsMicbudgetdetailhisto.BG_CODEPOSTEBUDGETAIRE = Dataset.Tables["TABLE"].Rows[Idx]["BG_CODEPOSTEBUDGETAIRE"].ToString();
					clsMicbudgetdetailhisto.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
					clsMicbudgetdetailhisto.BE_DATEDEBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_DATEDEBUT"].ToString());
					clsMicbudgetdetailhisto.BE_DATEFIN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_DATEFIN"].ToString());
					clsMicbudgetdetailhisto.TY_TYPEBUDGETDEATAIL = Dataset.Tables["TABLE"].Rows[Idx]["TY_TYPEBUDGETDEATAIL"].ToString();
					clsMicbudgetdetailhisto.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsMicbudgetdetailhisto.PV_CODEPOINTVENTE = Dataset.Tables["TABLE"].Rows[Idx]["PV_CODEPOINTVENTE"].ToString();
					clsMicbudgetdetailhisto.PE_CODEPERIODICITE = Dataset.Tables["TABLE"].Rows[Idx]["PE_CODEPERIODICITE"].ToString();
					clsMicbudgetdetailhisto.BE_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_MONTANT"].ToString());
					clsMicbudgetdetailhisto.BE_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_DATESAISIE"].ToString());
					clsMicbudgetdetailhisto.BE_DATEVALIDATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_DATEVALIDATION"].ToString());
					clsMicbudgetdetailhisto.OP_CODEOPERATEURVALIDATION = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEURVALIDATION"].ToString();
					clsMicbudgetdetailhisto.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsMicbudgetdetailhisto.BU_CODEBUDGETLIAISON = Dataset.Tables["TABLE"].Rows[Idx]["BU_CODEBUDGETLIAISON"].ToString();
					clsMicbudgetdetailhisto.BE_MONTANTREALISATIONMONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_MONTANTREALISATIONMONTANT"].ToString());
					clsMicbudgetdetailhisto.BE_MONTANTREALISATIONTAUX = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_MONTANTREALISATIONTAUX"].ToString());
					clsMicbudgetdetailhisto.BE_MONTANTSOLDE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BE_MONTANTSOLDE"].ToString());
					clsMicbudgetdetailhisto.BE_OBSERVATION = Dataset.Tables["TABLE"].Rows[Idx]["BE_OBSERVATION"].ToString();
					clsMicbudgetdetailhisto.BN_CODENATUREPOSTEBUDGETAIRE = Dataset.Tables["TABLE"].Rows[Idx]["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
					clsMicbudgetdetailhisto.BT_CODETYPEBUDGET = Dataset.Tables["TABLE"].Rows[Idx]["BT_CODETYPEBUDGET"].ToString();
					clsMicbudgetdetailhisto.BD_CODETYPEBUDGETDETAIL = Dataset.Tables["TABLE"].Rows[Idx]["BD_CODETYPEBUDGETDETAIL"].ToString();
					clsMicbudgetdetailhisto.OP_CODEOPERATEURBUDGETDETAIL = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEURBUDGETDETAIL"].ToString();
					clsMicbudgetdetailhistos.Add(clsMicbudgetdetailhisto);
				}
				Dataset.Dispose();
			}
		return clsMicbudgetdetailhistos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGETDETAILHISTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT BU_CODEBUDGET , PV_CODEPOINTVENTE FROM dbo.FT_MICBUDGETDETAILHISTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :BU_CODEBUDGET, BG_CODEPOSTEBUDGETAIRE, SR_CODESERVICE, BE_DATEDEBUT, BE_DATEFIN, TY_TYPEBUDGETDEATAIL, AG_CODEAGENCE, PE_CODEPERIODICITE, OP_CODEOPERATEURVALIDATION, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE BU_CODEBUDGET=@BU_CODEBUDGET";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BU_CODEBUDGET"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE BU_CODEBUDGET=@BU_CODEBUDGET AND BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BU_CODEBUDGET","@BG_CODEPOSTEBUDGETAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE BU_CODEBUDGET=@BU_CODEBUDGET AND BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE AND SR_CODESERVICE=@SR_CODESERVICE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BU_CODEBUDGET","@BG_CODEPOSTEBUDGETAIRE","@SR_CODESERVICE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TY_TYPEBUDGETDEATAIL=@TY_TYPEBUDGETDEATAIL AND BE_DATEDEBUT=@BE_DATEDEBUT AND BE_DATEFIN=@BE_DATEFIN";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@TY_TYPEBUDGETDEATAIL", "@BE_DATEDEBUT", "@BE_DATEFIN" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;

                case 5:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TY_TYPEBUDGETDEATAIL=@TY_TYPEBUDGETDEATAIL AND BE_DATEDEBUT=@BE_DATEDEBUT AND BE_DATEFIN=@BE_DATEFIN AND BT_CODETYPEBUDGET=@BT_CODETYPEBUDGET";
                vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@TY_TYPEBUDGETDEATAIL", "@BE_DATEDEBUT", "@BE_DATEFIN", "@BT_CODETYPEBUDGET" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
                break;


             
				case 6 :
				this.vapCritere ="WHERE BU_CODEBUDGET=@BU_CODEBUDGET AND BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE AND SR_CODESERVICE=@SR_CODESERVICE AND BE_DATEDEBUT=@BE_DATEDEBUT AND BE_DATEFIN=@BE_DATEFIN AND TY_TYPEBUDGETDEATAIL=@TY_TYPEBUDGETDEATAIL";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BU_CODEBUDGET","@BG_CODEPOSTEBUDGETAIRE","@SR_CODESERVICE","@BE_DATEDEBUT","@BE_DATEFIN","@TY_TYPEBUDGETDEATAIL"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
				case 7 :
				this.vapCritere ="WHERE BU_CODEBUDGET=@BU_CODEBUDGET AND BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE AND SR_CODESERVICE=@SR_CODESERVICE AND BE_DATEDEBUT=@BE_DATEDEBUT AND BE_DATEFIN=@BE_DATEFIN AND TY_TYPEBUDGETDEATAIL=@TY_TYPEBUDGETDEATAIL AND AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BU_CODEBUDGET","@BG_CODEPOSTEBUDGETAIRE","@SR_CODESERVICE","@BE_DATEDEBUT","@BE_DATEFIN","@TY_TYPEBUDGETDEATAIL","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
				break;
				case 8 :
				this.vapCritere ="WHERE BU_CODEBUDGET=@BU_CODEBUDGET AND BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE AND SR_CODESERVICE=@SR_CODESERVICE AND BE_DATEDEBUT=@BE_DATEDEBUT AND BE_DATEFIN=@BE_DATEFIN AND TY_TYPEBUDGETDEATAIL=@TY_TYPEBUDGETDEATAIL AND AG_CODEAGENCE=@AG_CODEAGENCE AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BU_CODEBUDGET","@BG_CODEPOSTEBUDGETAIRE","@SR_CODESERVICE","@BE_DATEDEBUT","@BE_DATEFIN","@TY_TYPEBUDGETDEATAIL","@AG_CODEAGENCE","@PE_CODEPERIODICITE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7]};
				break;
				case 9 :
				this.vapCritere ="WHERE BU_CODEBUDGET=@BU_CODEBUDGET AND BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE AND SR_CODESERVICE=@SR_CODESERVICE AND BE_DATEDEBUT=@BE_DATEDEBUT AND BE_DATEFIN=@BE_DATEFIN AND TY_TYPEBUDGETDEATAIL=@TY_TYPEBUDGETDEATAIL AND AG_CODEAGENCE=@AG_CODEAGENCE AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE AND OP_CODEOPERATEURVALIDATION=@OP_CODEOPERATEURVALIDATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BU_CODEBUDGET","@BG_CODEPOSTEBUDGETAIRE","@SR_CODESERVICE","@BE_DATEDEBUT","@BE_DATEFIN","@TY_TYPEBUDGETDEATAIL","@AG_CODEAGENCE","@PE_CODEPERIODICITE","@OP_CODEOPERATEURVALIDATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8]};
				break;
				case 10 :
				this.vapCritere ="WHERE BU_CODEBUDGET=@BU_CODEBUDGET AND BG_CODEPOSTEBUDGETAIRE=@BG_CODEPOSTEBUDGETAIRE AND SR_CODESERVICE=@SR_CODESERVICE AND BE_DATEDEBUT=@BE_DATEDEBUT AND BE_DATEFIN=@BE_DATEFIN AND TY_TYPEBUDGETDEATAIL=@TY_TYPEBUDGETDEATAIL AND AG_CODEAGENCE=@AG_CODEAGENCE AND PE_CODEPERIODICITE=@PE_CODEPERIODICITE AND OP_CODEOPERATEURVALIDATION=@OP_CODEOPERATEURVALIDATION AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BU_CODEBUDGET","@BG_CODEPOSTEBUDGETAIRE","@SR_CODESERVICE","@BE_DATEDEBUT","@BE_DATEFIN","@TY_TYPEBUDGETDEATAIL","@AG_CODEAGENCE","@PE_CODEPERIODICITE","@OP_CODEOPERATEURVALIDATION","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9]};
				break;
			}
		}
	}
}
