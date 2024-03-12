using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratWSDAL: ITableDAL<clsCtcontrat>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF,  AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontrat comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontrat pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , CA_NUMPOLICE  , CA_DATESAISIE  , TI_IDTIERS  , IT_CODEINTERMEDIAIRE  , AP_CODETYPEAPPARTEMENT  , OC_CODETYPEOCCUPANT  ,  ZA_CODEZONEAUTO  , CB_IDBRANCHE  , CA_DATEEFFET  , CA_DATEECHEANCE  , OP_CODEOPERATEUR  , CA_AVENANT  , CA_SITUATIONGEOGRAPHIQUE  , CA_CONDITIONHABITUEL  , ST_CODESTATUTSOCIOPROF  , AU_CODECATEGORIE  , TA_CODETARIF  , US_CODEUSAGE  , GE_CODEGENRE  , TVH_CODETYPE  , EN_CODEENERGIE  , CA_TAUX  , CA_TYPE  , CA_NUMSERIE  , CA_IMMATRICULATION  , CA_PUISSANCEADMISE  , CA_CHARGEUTILE  , CA_NBREPLACE  , CA_VALNEUVE  , CA_VALVENALE  , CA_DATEMISECIRCULATION  , CA_CLIENTEXONERETAXE  , TI_IDTIERSCOMMERCIAL  , TI_IDTIERSASSUREUR  , CA_DATETRANSMISSIONAASSUREUR  , CA_DATEVALIDATIONASSUREUR  ,   CA_DATESUSPENSION  , CA_DATECLOTURE  , CA_DATERESILIATION  , CA_NOMINTERLOCUTEUR  , CA_CONTACTINTERLOCUTEUR  , DI_CODEDESIGNATION  , TA_CODETYPECONTRATSANTE  , CA_CODECONTRATSECONDAIRE  ,  CO_CODECOMMUNE  , RQ_CODERISQUE  FROM dbo.FT_CTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontrat clsCtcontrat = new clsCtcontrat();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontrat.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontrat.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontrat.CA_NUMPOLICE = clsDonnee.vogDataReader["CA_NUMPOLICE"].ToString();
					clsCtcontrat.CA_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CA_DATESAISIE"].ToString());
					clsCtcontrat.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsCtcontrat.IT_CODEINTERMEDIAIRE = clsDonnee.vogDataReader["IT_CODEINTERMEDIAIRE"].ToString();
					clsCtcontrat.AP_CODETYPEAPPARTEMENT = clsDonnee.vogDataReader["AP_CODETYPEAPPARTEMENT"].ToString();
					clsCtcontrat.OC_CODETYPEOCCUPANT = clsDonnee.vogDataReader["OC_CODETYPEOCCUPANT"].ToString();
					clsCtcontrat.ZA_CODEZONEAUTO = clsDonnee.vogDataReader["ZA_CODEZONEAUTO"].ToString();
					clsCtcontrat.CB_IDBRANCHE = clsDonnee.vogDataReader["CB_IDBRANCHE"].ToString();
					clsCtcontrat.CA_DATEEFFET = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEEFFET"].ToString());
					clsCtcontrat.CA_DATEECHEANCE = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEECHEANCE"].ToString());
					clsCtcontrat.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtcontrat.CA_AVENANT = clsDonnee.vogDataReader["CA_AVENANT"].ToString();
					clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = clsDonnee.vogDataReader["CA_SITUATIONGEOGRAPHIQUE"].ToString();
					clsCtcontrat.CA_CONDITIONHABITUEL = clsDonnee.vogDataReader["CA_CONDITIONHABITUEL"].ToString();
					clsCtcontrat.ST_CODESTATUTSOCIOPROF = clsDonnee.vogDataReader["ST_CODESTATUTSOCIOPROF"].ToString();
					clsCtcontrat.AU_CODECATEGORIE = clsDonnee.vogDataReader["AU_CODECATEGORIE"].ToString();
					clsCtcontrat.TA_CODETARIF = clsDonnee.vogDataReader["TA_CODETARIF"].ToString();
					clsCtcontrat.US_CODEUSAGE = clsDonnee.vogDataReader["US_CODEUSAGE"].ToString();
					clsCtcontrat.GE_CODEGENRE = clsDonnee.vogDataReader["GE_CODEGENRE"].ToString();
					clsCtcontrat.TVH_CODETYPE = clsDonnee.vogDataReader["TVH_CODETYPE"].ToString();
					clsCtcontrat.EN_CODEENERGIE = clsDonnee.vogDataReader["EN_CODEENERGIE"].ToString();
					clsCtcontrat.CA_TAUX = float.Parse(clsDonnee.vogDataReader["CA_TAUX"].ToString());
					clsCtcontrat.CA_TYPE = clsDonnee.vogDataReader["CA_TYPE"].ToString();
					clsCtcontrat.CA_NUMSERIE = clsDonnee.vogDataReader["CA_NUMSERIE"].ToString();
					clsCtcontrat.CA_IMMATRICULATION = clsDonnee.vogDataReader["CA_IMMATRICULATION"].ToString();
					clsCtcontrat.CA_PUISSANCEADMISE = int.Parse(clsDonnee.vogDataReader["CA_PUISSANCEADMISE"].ToString());
					clsCtcontrat.CA_CHARGEUTILE = float.Parse(clsDonnee.vogDataReader["CA_CHARGEUTILE"].ToString());
					clsCtcontrat.CA_NBREPLACE = int.Parse(clsDonnee.vogDataReader["CA_NBREPLACE"].ToString());
					clsCtcontrat.CA_VALNEUVE = double.Parse(clsDonnee.vogDataReader["CA_VALNEUVE"].ToString());
					clsCtcontrat.CA_VALVENALE = double.Parse(clsDonnee.vogDataReader["CA_VALVENALE"].ToString());
					clsCtcontrat.CA_DATEMISECIRCULATION = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEMISECIRCULATION"].ToString());
					clsCtcontrat.CA_CLIENTEXONERETAXE = clsDonnee.vogDataReader["CA_CLIENTEXONERETAXE"].ToString();
					clsCtcontrat.TI_IDTIERSCOMMERCIAL = clsDonnee.vogDataReader["TI_IDTIERSCOMMERCIAL"].ToString();
					clsCtcontrat.TI_IDTIERSASSUREUR = clsDonnee.vogDataReader["TI_IDTIERSASSUREUR"].ToString();
					clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = DateTime.Parse(clsDonnee.vogDataReader["CA_DATETRANSMISSIONAASSUREUR"].ToString());
					clsCtcontrat.CA_DATEVALIDATIONASSUREUR = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEVALIDATIONASSUREUR"].ToString());
					
					clsCtcontrat.CA_DATESUSPENSION = DateTime.Parse(clsDonnee.vogDataReader["CA_DATESUSPENSION"].ToString());
					clsCtcontrat.CA_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["CA_DATECLOTURE"].ToString());
					clsCtcontrat.CA_DATERESILIATION = DateTime.Parse(clsDonnee.vogDataReader["CA_DATERESILIATION"].ToString());
					clsCtcontrat.CA_NOMINTERLOCUTEUR = clsDonnee.vogDataReader["CA_NOMINTERLOCUTEUR"].ToString();
					clsCtcontrat.CA_CONTACTINTERLOCUTEUR = clsDonnee.vogDataReader["CA_CONTACTINTERLOCUTEUR"].ToString();
					clsCtcontrat.DI_CODEDESIGNATION = clsDonnee.vogDataReader["DI_CODEDESIGNATION"].ToString();
					clsCtcontrat.TA_CODETYPECONTRATSANTE = clsDonnee.vogDataReader["TA_CODETYPECONTRATSANTE"].ToString();
					clsCtcontrat.CA_CODECONTRATSECONDAIRE = clsDonnee.vogDataReader["CA_CODECONTRATSECONDAIRE"].ToString();
					clsCtcontrat.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();
					clsCtcontrat.RQ_CODERISQUE = clsDonnee.vogDataReader["RQ_CODERISQUE"].ToString();
                    clsCtcontrat.TA_CODETYPEAFFAIRES = clsDonnee.vogDataReader["TA_CODETYPEAFFAIRES"].ToString();

				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontrat;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontrat>clsCtcontrat</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontrat clsCtcontrat)
		{
			//Préparation des paramètres
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontrat.CA_CODECONTRAT ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 50);
			vppParamAG_CODEAGENCE.Value  = clsCtcontrat.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontrat.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_NUMPOLICE = new SqlParameter("@CA_NUMPOLICE", SqlDbType.VarChar, 1000);
			vppParamCA_NUMPOLICE.Value  = clsCtcontrat.CA_NUMPOLICE ;
			if(clsCtcontrat.CA_NUMPOLICE== ""  ) vppParamCA_NUMPOLICE.Value  = DBNull.Value;
			SqlParameter vppParamCA_DATESAISIE = new SqlParameter("@CA_DATESAISIE", SqlDbType.DateTime);
			vppParamCA_DATESAISIE.Value  = clsCtcontrat.CA_DATESAISIE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsCtcontrat.TI_IDTIERS ;
			SqlParameter vppParamIT_CODEINTERMEDIAIRE = new SqlParameter("@IT_CODEINTERMEDIAIRE", SqlDbType.VarChar, 5);
			vppParamIT_CODEINTERMEDIAIRE.Value  = clsCtcontrat.IT_CODEINTERMEDIAIRE ;
			if(clsCtcontrat.IT_CODEINTERMEDIAIRE== ""  ) vppParamIT_CODEINTERMEDIAIRE.Value  = DBNull.Value;
			SqlParameter vppParamAP_CODETYPEAPPARTEMENT = new SqlParameter("@AP_CODETYPEAPPARTEMENT", SqlDbType.VarChar, 5);
			vppParamAP_CODETYPEAPPARTEMENT.Value  = clsCtcontrat.AP_CODETYPEAPPARTEMENT ;
			if(clsCtcontrat.AP_CODETYPEAPPARTEMENT== ""  ) vppParamAP_CODETYPEAPPARTEMENT.Value  = DBNull.Value;
			SqlParameter vppParamOC_CODETYPEOCCUPANT = new SqlParameter("@OC_CODETYPEOCCUPANT", SqlDbType.VarChar, 2);
			vppParamOC_CODETYPEOCCUPANT.Value  = clsCtcontrat.OC_CODETYPEOCCUPANT ;
			if(clsCtcontrat.OC_CODETYPEOCCUPANT== ""  ) vppParamOC_CODETYPEOCCUPANT.Value  = DBNull.Value;
			SqlParameter vppParamZA_CODEZONEAUTO = new SqlParameter("@ZA_CODEZONEAUTO", SqlDbType.VarChar, 7);
			vppParamZA_CODEZONEAUTO.Value  = clsCtcontrat.ZA_CODEZONEAUTO ;
			if(clsCtcontrat.ZA_CODEZONEAUTO== ""  ) vppParamZA_CODEZONEAUTO.Value  = DBNull.Value;
			SqlParameter vppParamCB_IDBRANCHE = new SqlParameter("@CB_IDBRANCHE", SqlDbType.VarChar, 50);
			vppParamCB_IDBRANCHE.Value  = clsCtcontrat.CB_IDBRANCHE ;
			if(clsCtcontrat.CB_IDBRANCHE== ""  ) vppParamCB_IDBRANCHE.Value  = DBNull.Value;
			SqlParameter vppParamCA_DATEEFFET = new SqlParameter("@CA_DATEEFFET", SqlDbType.DateTime);
			vppParamCA_DATEEFFET.Value  = clsCtcontrat.CA_DATEEFFET ;
			SqlParameter vppParamCA_DATEECHEANCE = new SqlParameter("@CA_DATEECHEANCE", SqlDbType.DateTime);
			vppParamCA_DATEECHEANCE.Value  = clsCtcontrat.CA_DATEECHEANCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontrat.OP_CODEOPERATEUR ;
			SqlParameter vppParamCA_AVENANT = new SqlParameter("@CA_AVENANT", SqlDbType.VarChar, 1000);
			vppParamCA_AVENANT.Value  = clsCtcontrat.CA_AVENANT ;
			if(clsCtcontrat.CA_AVENANT== ""  ) vppParamCA_AVENANT.Value  = DBNull.Value;
			SqlParameter vppParamCA_SITUATIONGEOGRAPHIQUE = new SqlParameter("@CA_SITUATIONGEOGRAPHIQUE", SqlDbType.VarChar, 1000);
			vppParamCA_SITUATIONGEOGRAPHIQUE.Value  = clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE ;
			if(clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE== ""  ) vppParamCA_SITUATIONGEOGRAPHIQUE.Value  = DBNull.Value;
			SqlParameter vppParamCA_CONDITIONHABITUEL = new SqlParameter("@CA_CONDITIONHABITUEL", SqlDbType.VarChar, 1000);
			vppParamCA_CONDITIONHABITUEL.Value  = clsCtcontrat.CA_CONDITIONHABITUEL ;
			if(clsCtcontrat.CA_CONDITIONHABITUEL== ""  ) vppParamCA_CONDITIONHABITUEL.Value  = DBNull.Value;
			SqlParameter vppParamST_CODESTATUTSOCIOPROF = new SqlParameter("@ST_CODESTATUTSOCIOPROF", SqlDbType.VarChar, 2);
			vppParamST_CODESTATUTSOCIOPROF.Value  = clsCtcontrat.ST_CODESTATUTSOCIOPROF ;
			if(clsCtcontrat.ST_CODESTATUTSOCIOPROF== ""  ) vppParamST_CODESTATUTSOCIOPROF.Value  = DBNull.Value;

			SqlParameter vppParamAU_CODECATEGORIE = new SqlParameter("@AU_CODECATEGORIE", SqlDbType.VarChar, 50);
			vppParamAU_CODECATEGORIE.Value  = clsCtcontrat.AU_CODECATEGORIE ;
			if(clsCtcontrat.AU_CODECATEGORIE== ""  ) vppParamAU_CODECATEGORIE.Value  = DBNull.Value;
			SqlParameter vppParamTA_CODETARIF = new SqlParameter("@TA_CODETARIF", SqlDbType.VarChar, 50);
			vppParamTA_CODETARIF.Value  = clsCtcontrat.TA_CODETARIF ;
			if(clsCtcontrat.TA_CODETARIF== ""  ) vppParamTA_CODETARIF.Value  = DBNull.Value;
			SqlParameter vppParamUS_CODEUSAGE = new SqlParameter("@US_CODEUSAGE", SqlDbType.VarChar, 3);
			vppParamUS_CODEUSAGE.Value  = clsCtcontrat.US_CODEUSAGE ;
			if(clsCtcontrat.US_CODEUSAGE== ""  ) vppParamUS_CODEUSAGE.Value  = DBNull.Value;
			SqlParameter vppParamGE_CODEGENRE = new SqlParameter("@GE_CODEGENRE", SqlDbType.VarChar, 3);
			vppParamGE_CODEGENRE.Value  = clsCtcontrat.GE_CODEGENRE ;
			if(clsCtcontrat.GE_CODEGENRE== ""  ) vppParamGE_CODEGENRE.Value  = DBNull.Value;
			SqlParameter vppParamTVH_CODETYPE = new SqlParameter("@TVH_CODETYPE", SqlDbType.VarChar, 50);
			vppParamTVH_CODETYPE.Value  = clsCtcontrat.TVH_CODETYPE ;
			if(clsCtcontrat.TVH_CODETYPE== ""  ) vppParamTVH_CODETYPE.Value  = DBNull.Value;
			SqlParameter vppParamEN_CODEENERGIE = new SqlParameter("@EN_CODEENERGIE", SqlDbType.VarChar, 50);
			vppParamEN_CODEENERGIE.Value  = clsCtcontrat.EN_CODEENERGIE ;
			if(clsCtcontrat.EN_CODEENERGIE== ""  ) vppParamEN_CODEENERGIE.Value  = DBNull.Value;
			SqlParameter vppParamCA_TAUX = new SqlParameter("@CA_TAUX", SqlDbType.Float);
			vppParamCA_TAUX.Value  = clsCtcontrat.CA_TAUX ;
			if(clsCtcontrat.CA_TAUX== 0 ) vppParamCA_TAUX.Value  = DBNull.Value;
			SqlParameter vppParamCA_TYPE = new SqlParameter("@CA_TYPE", SqlDbType.VarChar, 1000);
			vppParamCA_TYPE.Value  = clsCtcontrat.CA_TYPE ;
			if(clsCtcontrat.CA_TYPE== ""  ) vppParamCA_TYPE.Value  = DBNull.Value;
			SqlParameter vppParamCA_NUMSERIE = new SqlParameter("@CA_NUMSERIE", SqlDbType.VarChar, 1000);
			vppParamCA_NUMSERIE.Value  = clsCtcontrat.CA_NUMSERIE ;
			if(clsCtcontrat.CA_NUMSERIE== ""  ) vppParamCA_NUMSERIE.Value  = DBNull.Value;
			SqlParameter vppParamCA_IMMATRICULATION = new SqlParameter("@CA_IMMATRICULATION", SqlDbType.VarChar, 1000);
			vppParamCA_IMMATRICULATION.Value  = clsCtcontrat.CA_IMMATRICULATION ;
			if(clsCtcontrat.CA_IMMATRICULATION== ""  ) vppParamCA_IMMATRICULATION.Value  = DBNull.Value;
			SqlParameter vppParamCA_PUISSANCEADMISE = new SqlParameter("@CA_PUISSANCEADMISE", SqlDbType.Int);
			vppParamCA_PUISSANCEADMISE.Value  = clsCtcontrat.CA_PUISSANCEADMISE ;
			if(clsCtcontrat.CA_PUISSANCEADMISE== 0  ) vppParamCA_PUISSANCEADMISE.Value  = DBNull.Value;
			SqlParameter vppParamCA_CHARGEUTILE = new SqlParameter("@CA_CHARGEUTILE", SqlDbType.Float);
			vppParamCA_CHARGEUTILE.Value  = clsCtcontrat.CA_CHARGEUTILE ;
			if(clsCtcontrat.CA_CHARGEUTILE== 0  ) vppParamCA_CHARGEUTILE.Value  = DBNull.Value;
			SqlParameter vppParamCA_NBREPLACE = new SqlParameter("@CA_NBREPLACE", SqlDbType.Int);
			vppParamCA_NBREPLACE.Value  = clsCtcontrat.CA_NBREPLACE ;
			if(clsCtcontrat.CA_NBREPLACE== 0  ) vppParamCA_NBREPLACE.Value  = DBNull.Value;
			SqlParameter vppParamCA_VALNEUVE = new SqlParameter("@CA_VALNEUVE", SqlDbType.Money);
			vppParamCA_VALNEUVE.Value  = clsCtcontrat.CA_VALNEUVE ;
			if(clsCtcontrat.CA_VALNEUVE== 0  ) vppParamCA_VALNEUVE.Value  = DBNull.Value;
			SqlParameter vppParamCA_VALVENALE = new SqlParameter("@CA_VALVENALE", SqlDbType.Money);
			vppParamCA_VALVENALE.Value  = clsCtcontrat.CA_VALVENALE ;
			if(clsCtcontrat.CA_VALVENALE== 0  ) vppParamCA_VALVENALE.Value  = DBNull.Value;
			SqlParameter vppParamCA_DATEMISECIRCULATION = new SqlParameter("@CA_DATEMISECIRCULATION", SqlDbType.DateTime);
			vppParamCA_DATEMISECIRCULATION.Value  = clsCtcontrat.CA_DATEMISECIRCULATION ;
			if(clsCtcontrat.CA_DATEMISECIRCULATION.Year < 1900 ) vppParamCA_DATEMISECIRCULATION.Value  = DateTime.Parse("01/01/1900");
			SqlParameter vppParamCA_CLIENTEXONERETAXE = new SqlParameter("@CA_CLIENTEXONERETAXE", SqlDbType.VarChar, 1);
			vppParamCA_CLIENTEXONERETAXE.Value  = clsCtcontrat.CA_CLIENTEXONERETAXE ;
			if(clsCtcontrat.CA_CLIENTEXONERETAXE== ""  ) vppParamCA_CLIENTEXONERETAXE.Value  = DBNull.Value;
			SqlParameter vppParamTI_IDTIERSCOMMERCIAL = new SqlParameter("@TI_IDTIERSCOMMERCIAL", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSCOMMERCIAL.Value  = clsCtcontrat.TI_IDTIERSCOMMERCIAL ;
			SqlParameter vppParamTI_IDTIERSASSUREUR = new SqlParameter("@TI_IDTIERSASSUREUR", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSASSUREUR.Value  = clsCtcontrat.TI_IDTIERSASSUREUR ;
			SqlParameter vppParamCA_DATETRANSMISSIONAASSUREUR = new SqlParameter("@CA_DATETRANSMISSIONAASSUREUR", SqlDbType.DateTime);
			vppParamCA_DATETRANSMISSIONAASSUREUR.Value  = clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR ;
			SqlParameter vppParamCA_DATEVALIDATIONASSUREUR = new SqlParameter("@CA_DATEVALIDATIONASSUREUR", SqlDbType.DateTime);
			vppParamCA_DATEVALIDATIONASSUREUR.Value  = clsCtcontrat.CA_DATEVALIDATIONASSUREUR ;
			
			SqlParameter vppParamCA_DATESUSPENSION = new SqlParameter("@CA_DATESUSPENSION", SqlDbType.DateTime);
			vppParamCA_DATESUSPENSION.Value  = clsCtcontrat.CA_DATESUSPENSION ;
			SqlParameter vppParamCA_DATECLOTURE = new SqlParameter("@CA_DATECLOTURE", SqlDbType.DateTime);
			vppParamCA_DATECLOTURE.Value  = clsCtcontrat.CA_DATECLOTURE ;

			SqlParameter vppParamCA_DATERESILIATION = new SqlParameter("@CA_DATERESILIATION", SqlDbType.DateTime);
			vppParamCA_DATERESILIATION.Value  = clsCtcontrat.CA_DATERESILIATION ;

			SqlParameter vppParamCA_NOMINTERLOCUTEUR = new SqlParameter("@CA_NOMINTERLOCUTEUR", SqlDbType.VarChar, 1000);
			vppParamCA_NOMINTERLOCUTEUR.Value  = clsCtcontrat.CA_NOMINTERLOCUTEUR ;
			SqlParameter vppParamCA_CONTACTINTERLOCUTEUR = new SqlParameter("@CA_CONTACTINTERLOCUTEUR", SqlDbType.VarChar, 1000);
			vppParamCA_CONTACTINTERLOCUTEUR.Value  = clsCtcontrat.CA_CONTACTINTERLOCUTEUR ;
			SqlParameter vppParamDI_CODEDESIGNATION = new SqlParameter("@DI_CODEDESIGNATION", SqlDbType.VarChar, 2);
			vppParamDI_CODEDESIGNATION.Value  = clsCtcontrat.DI_CODEDESIGNATION ;
			if(clsCtcontrat.DI_CODEDESIGNATION== ""  ) vppParamDI_CODEDESIGNATION.Value  = DBNull.Value;
			SqlParameter vppParamTA_CODETYPECONTRATSANTE = new SqlParameter("@TA_CODETYPECONTRATSANTE", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPECONTRATSANTE.Value  = clsCtcontrat.TA_CODETYPECONTRATSANTE ;
			if(clsCtcontrat.TA_CODETYPECONTRATSANTE== ""  ) vppParamTA_CODETYPECONTRATSANTE.Value  = DBNull.Value;
			SqlParameter vppParamCA_CODECONTRATSECONDAIRE = new SqlParameter("@CA_CODECONTRATSECONDAIRE", SqlDbType.Decimal, 4);
			vppParamCA_CODECONTRATSECONDAIRE.Value  = clsCtcontrat.CA_CODECONTRATSECONDAIRE ;
			if(clsCtcontrat.CA_CODECONTRATSECONDAIRE== ""  ) vppParamCA_CODECONTRATSECONDAIRE.Value  = DBNull.Value;

			SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
			vppParamCO_CODECOMMUNE.Value  = clsCtcontrat.CO_CODECOMMUNE ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtcontrat.RQ_CODERISQUE ;
			SqlParameter vppParamTA_CODETYPEAFFAIRES = new SqlParameter("@TA_CODETYPEAFFAIRES", SqlDbType.VarChar, 2);
            vppParamTA_CODETYPEAFFAIRES.Value  = clsCtcontrat.TA_CODETYPEAFFAIRES;

            SqlParameter vppParamCA_DATEDEMANDERENOUVELEMENT = new SqlParameter("@CA_DATEDEMANDERENOUVELEMENT", SqlDbType.DateTime);
            vppParamCA_DATEDEMANDERENOUVELEMENT.Value = clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT;

            SqlParameter vppParamCA_CODECONTRATORIGINE = new SqlParameter("@CA_CODECONTRATORIGINE", SqlDbType.VarChar, 50);
            vppParamCA_CODECONTRATORIGINE.Value = clsCtcontrat.CA_CODECONTRATORIGINE;
            if (clsCtcontrat.CA_CODECONTRATORIGINE == "") vppParamCA_CODECONTRATORIGINE.Value = DBNull.Value;

            SqlParameter vppParamGR_CODEGARENTIEPRIME = new SqlParameter("@GR_CODEGARENTIEPRIME", SqlDbType.VarChar, 50);
            vppParamGR_CODEGARENTIEPRIME.Value = clsCtcontrat.GR_CODEGARENTIEPRIME;
            if (clsCtcontrat.GR_CODEGARENTIEPRIME == "") vppParamGR_CODEGARENTIEPRIME.Value = DBNull.Value;

            SqlParameter vppParamCA_OBSERVATION = new SqlParameter("@CA_OBSERVATION", SqlDbType.VarChar, 150);
            vppParamCA_OBSERVATION.Value = clsCtcontrat.CA_OBSERVATION;
            if (clsCtcontrat.CA_OBSERVATION == "") vppParamCA_OBSERVATION.Value = DBNull.Value;



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRAT  @CA_CODECONTRAT, @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_NUMPOLICE, @CA_DATESAISIE, @TI_IDTIERS, @IT_CODEINTERMEDIAIRE, @AP_CODETYPEAPPARTEMENT, @OC_CODETYPEOCCUPANT,  @ZA_CODEZONEAUTO, @CB_IDBRANCHE, @CA_DATEEFFET, @CA_DATEECHEANCE, @OP_CODEOPERATEUR, @CA_AVENANT, @CA_SITUATIONGEOGRAPHIQUE, @CA_CONDITIONHABITUEL, @ST_CODESTATUTSOCIOPROF, @AU_CODECATEGORIE, @TA_CODETARIF, @US_CODEUSAGE, @GE_CODEGENRE, @TVH_CODETYPE, @EN_CODEENERGIE, @CA_TAUX, @CA_TYPE, @CA_NUMSERIE, @CA_IMMATRICULATION, @CA_PUISSANCEADMISE, @CA_CHARGEUTILE, @CA_NBREPLACE, @CA_VALNEUVE, @CA_VALVENALE, @CA_DATEMISECIRCULATION, @CA_CLIENTEXONERETAXE, @TI_IDTIERSCOMMERCIAL, @TI_IDTIERSASSUREUR, @CA_DATETRANSMISSIONAASSUREUR, @CA_DATEVALIDATIONASSUREUR,   @CA_DATESUSPENSION, @CA_DATECLOTURE, @CA_DATERESILIATION, @CA_NOMINTERLOCUTEUR, @CA_CONTACTINTERLOCUTEUR, @DI_CODEDESIGNATION, @TA_CODETYPECONTRATSANTE, @CA_CODECONTRATSECONDAIRE, @CO_CODECOMMUNE, @RQ_CODERISQUE,@TA_CODETYPEAFFAIRES,@CA_DATEDEMANDERENOUVELEMENT,@CA_CODECONTRATORIGINE,@GR_CODEGARENTIEPRIME,@CA_OBSERVATION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_NUMPOLICE);
			vppSqlCmd.Parameters.Add(vppParamCA_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamIT_CODEINTERMEDIAIRE);
			vppSqlCmd.Parameters.Add(vppParamAP_CODETYPEAPPARTEMENT);
			vppSqlCmd.Parameters.Add(vppParamOC_CODETYPEOCCUPANT);
			vppSqlCmd.Parameters.Add(vppParamZA_CODEZONEAUTO);
			vppSqlCmd.Parameters.Add(vppParamCB_IDBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEEFFET);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEECHEANCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCA_AVENANT);
			vppSqlCmd.Parameters.Add(vppParamCA_SITUATIONGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamCA_CONDITIONHABITUEL);
			vppSqlCmd.Parameters.Add(vppParamST_CODESTATUTSOCIOPROF);
			vppSqlCmd.Parameters.Add(vppParamAU_CODECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETARIF);
			vppSqlCmd.Parameters.Add(vppParamUS_CODEUSAGE);
			vppSqlCmd.Parameters.Add(vppParamGE_CODEGENRE);
			vppSqlCmd.Parameters.Add(vppParamTVH_CODETYPE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENERGIE);
			vppSqlCmd.Parameters.Add(vppParamCA_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCA_TYPE);
			vppSqlCmd.Parameters.Add(vppParamCA_NUMSERIE);
			vppSqlCmd.Parameters.Add(vppParamCA_IMMATRICULATION);
			vppSqlCmd.Parameters.Add(vppParamCA_PUISSANCEADMISE);
			vppSqlCmd.Parameters.Add(vppParamCA_CHARGEUTILE);
			vppSqlCmd.Parameters.Add(vppParamCA_NBREPLACE);
			vppSqlCmd.Parameters.Add(vppParamCA_VALNEUVE);
			vppSqlCmd.Parameters.Add(vppParamCA_VALVENALE);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEMISECIRCULATION);
			vppSqlCmd.Parameters.Add(vppParamCA_CLIENTEXONERETAXE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSCOMMERCIAL);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamCA_DATETRANSMISSIONAASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEVALIDATIONASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamCA_DATESUSPENSION);
			vppSqlCmd.Parameters.Add(vppParamCA_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamCA_DATERESILIATION);
			vppSqlCmd.Parameters.Add(vppParamCA_NOMINTERLOCUTEUR);
			vppSqlCmd.Parameters.Add(vppParamCA_CONTACTINTERLOCUTEUR);
			vppSqlCmd.Parameters.Add(vppParamDI_CODEDESIGNATION);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPECONTRATSANTE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRATSECONDAIRE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEAFFAIRES);

			vppSqlCmd.Parameters.Add(vppParamCA_DATEDEMANDERENOUVELEMENT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRATORIGINE);
			vppSqlCmd.Parameters.Add(vppParamGR_CODEGARENTIEPRIME);
			vppSqlCmd.Parameters.Add(vppParamCA_OBSERVATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontrat>clsCtcontrat</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontrat clsCtcontrat,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontrat.CA_CODECONTRAT ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 50);
			vppParamAG_CODEAGENCE.Value  = clsCtcontrat.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontrat.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_NUMPOLICE = new SqlParameter("@CA_NUMPOLICE", SqlDbType.VarChar, 1000);
			vppParamCA_NUMPOLICE.Value  = clsCtcontrat.CA_NUMPOLICE ;
			if(clsCtcontrat.CA_NUMPOLICE== ""  ) vppParamCA_NUMPOLICE.Value  = DBNull.Value;
			SqlParameter vppParamCA_DATESAISIE = new SqlParameter("@CA_DATESAISIE", SqlDbType.DateTime);
			vppParamCA_DATESAISIE.Value  = clsCtcontrat.CA_DATESAISIE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsCtcontrat.TI_IDTIERS ;
			SqlParameter vppParamIT_CODEINTERMEDIAIRE = new SqlParameter("@IT_CODEINTERMEDIAIRE", SqlDbType.VarChar, 5);
			vppParamIT_CODEINTERMEDIAIRE.Value  = clsCtcontrat.IT_CODEINTERMEDIAIRE ;
			if(clsCtcontrat.IT_CODEINTERMEDIAIRE== ""  ) vppParamIT_CODEINTERMEDIAIRE.Value  = DBNull.Value;
			SqlParameter vppParamAP_CODETYPEAPPARTEMENT = new SqlParameter("@AP_CODETYPEAPPARTEMENT", SqlDbType.VarChar, 5);
			vppParamAP_CODETYPEAPPARTEMENT.Value  = clsCtcontrat.AP_CODETYPEAPPARTEMENT ;
			if(clsCtcontrat.AP_CODETYPEAPPARTEMENT== ""  ) vppParamAP_CODETYPEAPPARTEMENT.Value  = DBNull.Value;
			SqlParameter vppParamOC_CODETYPEOCCUPANT = new SqlParameter("@OC_CODETYPEOCCUPANT", SqlDbType.VarChar, 2);
			vppParamOC_CODETYPEOCCUPANT.Value  = clsCtcontrat.OC_CODETYPEOCCUPANT ;
			if(clsCtcontrat.OC_CODETYPEOCCUPANT== ""  ) vppParamOC_CODETYPEOCCUPANT.Value  = DBNull.Value;

			SqlParameter vppParamZA_CODEZONEAUTO = new SqlParameter("@ZA_CODEZONEAUTO", SqlDbType.VarChar, 7);
			vppParamZA_CODEZONEAUTO.Value  = clsCtcontrat.ZA_CODEZONEAUTO ;
			if(clsCtcontrat.ZA_CODEZONEAUTO== ""  ) vppParamZA_CODEZONEAUTO.Value  = DBNull.Value;
			SqlParameter vppParamCB_IDBRANCHE = new SqlParameter("@CB_IDBRANCHE", SqlDbType.VarChar, 50);
			vppParamCB_IDBRANCHE.Value  = clsCtcontrat.CB_IDBRANCHE ;
			if(clsCtcontrat.CB_IDBRANCHE== ""  ) vppParamCB_IDBRANCHE.Value  = DBNull.Value;
			SqlParameter vppParamCA_DATEEFFET = new SqlParameter("@CA_DATEEFFET", SqlDbType.DateTime);
			vppParamCA_DATEEFFET.Value  = clsCtcontrat.CA_DATEEFFET ;
			SqlParameter vppParamCA_DATEECHEANCE = new SqlParameter("@CA_DATEECHEANCE", SqlDbType.DateTime);
			vppParamCA_DATEECHEANCE.Value  = clsCtcontrat.CA_DATEECHEANCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontrat.OP_CODEOPERATEUR ;
			SqlParameter vppParamCA_AVENANT = new SqlParameter("@CA_AVENANT", SqlDbType.VarChar, 1000);
			vppParamCA_AVENANT.Value  = clsCtcontrat.CA_AVENANT ;
			if(clsCtcontrat.CA_AVENANT== ""  ) vppParamCA_AVENANT.Value  = DBNull.Value;
			SqlParameter vppParamCA_SITUATIONGEOGRAPHIQUE = new SqlParameter("@CA_SITUATIONGEOGRAPHIQUE", SqlDbType.VarChar, 1000);
			vppParamCA_SITUATIONGEOGRAPHIQUE.Value  = clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE ;
			if(clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE== ""  ) vppParamCA_SITUATIONGEOGRAPHIQUE.Value  = DBNull.Value;
			SqlParameter vppParamCA_CONDITIONHABITUEL = new SqlParameter("@CA_CONDITIONHABITUEL", SqlDbType.VarChar, 1000);
			vppParamCA_CONDITIONHABITUEL.Value  = clsCtcontrat.CA_CONDITIONHABITUEL ;
			if(clsCtcontrat.CA_CONDITIONHABITUEL== ""  ) vppParamCA_CONDITIONHABITUEL.Value  = DBNull.Value;
			SqlParameter vppParamST_CODESTATUTSOCIOPROF = new SqlParameter("@ST_CODESTATUTSOCIOPROF", SqlDbType.VarChar, 2);
			vppParamST_CODESTATUTSOCIOPROF.Value  = clsCtcontrat.ST_CODESTATUTSOCIOPROF ;
			if(clsCtcontrat.ST_CODESTATUTSOCIOPROF== ""  ) vppParamST_CODESTATUTSOCIOPROF.Value  = DBNull.Value;

			SqlParameter vppParamAU_CODECATEGORIE = new SqlParameter("@AU_CODECATEGORIE", SqlDbType.VarChar, 50);
			vppParamAU_CODECATEGORIE.Value  = clsCtcontrat.AU_CODECATEGORIE ;
			if(clsCtcontrat.AU_CODECATEGORIE== ""  ) vppParamAU_CODECATEGORIE.Value  = DBNull.Value;
			SqlParameter vppParamTA_CODETARIF = new SqlParameter("@TA_CODETARIF", SqlDbType.VarChar, 50);
			vppParamTA_CODETARIF.Value  = clsCtcontrat.TA_CODETARIF ;
			if(clsCtcontrat.TA_CODETARIF== ""  ) vppParamTA_CODETARIF.Value  = DBNull.Value;
			SqlParameter vppParamUS_CODEUSAGE = new SqlParameter("@US_CODEUSAGE", SqlDbType.VarChar, 3);
			vppParamUS_CODEUSAGE.Value  = clsCtcontrat.US_CODEUSAGE ;
			if(clsCtcontrat.US_CODEUSAGE== ""  ) vppParamUS_CODEUSAGE.Value  = DBNull.Value;
			SqlParameter vppParamGE_CODEGENRE = new SqlParameter("@GE_CODEGENRE", SqlDbType.VarChar, 3);
			vppParamGE_CODEGENRE.Value  = clsCtcontrat.GE_CODEGENRE ;
			if(clsCtcontrat.GE_CODEGENRE== ""  ) vppParamGE_CODEGENRE.Value  = DBNull.Value;
			SqlParameter vppParamTVH_CODETYPE = new SqlParameter("@TVH_CODETYPE", SqlDbType.VarChar, 50);
			vppParamTVH_CODETYPE.Value  = clsCtcontrat.TVH_CODETYPE ;
			if(clsCtcontrat.TVH_CODETYPE== ""  ) vppParamTVH_CODETYPE.Value  = DBNull.Value;
			SqlParameter vppParamEN_CODEENERGIE = new SqlParameter("@EN_CODEENERGIE", SqlDbType.VarChar, 50);
			vppParamEN_CODEENERGIE.Value  = clsCtcontrat.EN_CODEENERGIE ;
			if(clsCtcontrat.EN_CODEENERGIE== ""  ) vppParamEN_CODEENERGIE.Value  = DBNull.Value;
			SqlParameter vppParamCA_TAUX = new SqlParameter("@CA_TAUX", SqlDbType.Float);
			vppParamCA_TAUX.Value  = clsCtcontrat.CA_TAUX ;
			if(clsCtcontrat.CA_TAUX== 0  ) vppParamCA_TAUX.Value  = DBNull.Value;
			SqlParameter vppParamCA_TYPE = new SqlParameter("@CA_TYPE", SqlDbType.VarChar, 1000);
			vppParamCA_TYPE.Value  = clsCtcontrat.CA_TYPE ;
			if(clsCtcontrat.CA_TYPE== ""  ) vppParamCA_TYPE.Value  = DBNull.Value;
			SqlParameter vppParamCA_NUMSERIE = new SqlParameter("@CA_NUMSERIE", SqlDbType.VarChar, 1000);
			vppParamCA_NUMSERIE.Value  = clsCtcontrat.CA_NUMSERIE ;
			if(clsCtcontrat.CA_NUMSERIE== ""  ) vppParamCA_NUMSERIE.Value  = DBNull.Value;
			SqlParameter vppParamCA_IMMATRICULATION = new SqlParameter("@CA_IMMATRICULATION", SqlDbType.VarChar, 1000);
			vppParamCA_IMMATRICULATION.Value  = clsCtcontrat.CA_IMMATRICULATION ;
			if(clsCtcontrat.CA_IMMATRICULATION== ""  ) vppParamCA_IMMATRICULATION.Value  = DBNull.Value;
			SqlParameter vppParamCA_PUISSANCEADMISE = new SqlParameter("@CA_PUISSANCEADMISE", SqlDbType.Int);
			vppParamCA_PUISSANCEADMISE.Value  = clsCtcontrat.CA_PUISSANCEADMISE ;
			if(clsCtcontrat.CA_PUISSANCEADMISE== 0  ) vppParamCA_PUISSANCEADMISE.Value  = DBNull.Value;
			SqlParameter vppParamCA_CHARGEUTILE = new SqlParameter("@CA_CHARGEUTILE", SqlDbType.Float);
			vppParamCA_CHARGEUTILE.Value  = clsCtcontrat.CA_CHARGEUTILE ;
			if(clsCtcontrat.CA_CHARGEUTILE== 0  ) vppParamCA_CHARGEUTILE.Value  = DBNull.Value;
			SqlParameter vppParamCA_NBREPLACE = new SqlParameter("@CA_NBREPLACE", SqlDbType.Int);
			vppParamCA_NBREPLACE.Value  = clsCtcontrat.CA_NBREPLACE ;
			if(clsCtcontrat.CA_NBREPLACE== 0  ) vppParamCA_NBREPLACE.Value  = DBNull.Value;
			SqlParameter vppParamCA_VALNEUVE = new SqlParameter("@CA_VALNEUVE", SqlDbType.Money);
			vppParamCA_VALNEUVE.Value  = clsCtcontrat.CA_VALNEUVE ;
			if(clsCtcontrat.CA_VALNEUVE== 0  ) vppParamCA_VALNEUVE.Value  = DBNull.Value;
			SqlParameter vppParamCA_VALVENALE = new SqlParameter("@CA_VALVENALE", SqlDbType.Money);
			vppParamCA_VALVENALE.Value  = clsCtcontrat.CA_VALVENALE ;
			if(clsCtcontrat.CA_VALVENALE== 0  ) vppParamCA_VALVENALE.Value  = DBNull.Value;
			SqlParameter vppParamCA_DATEMISECIRCULATION = new SqlParameter("@CA_DATEMISECIRCULATION", SqlDbType.DateTime);
			vppParamCA_DATEMISECIRCULATION.Value  = clsCtcontrat.CA_DATEMISECIRCULATION ;
			if(clsCtcontrat.CA_DATEMISECIRCULATION.Year < 1900 ) vppParamCA_DATEMISECIRCULATION.Value  = DateTime.Parse("01/01/1900");
			SqlParameter vppParamCA_CLIENTEXONERETAXE = new SqlParameter("@CA_CLIENTEXONERETAXE", SqlDbType.VarChar, 1);
			vppParamCA_CLIENTEXONERETAXE.Value  = clsCtcontrat.CA_CLIENTEXONERETAXE ;
			if(clsCtcontrat.CA_CLIENTEXONERETAXE== ""  ) vppParamCA_CLIENTEXONERETAXE.Value  = DBNull.Value;
			SqlParameter vppParamTI_IDTIERSCOMMERCIAL = new SqlParameter("@TI_IDTIERSCOMMERCIAL", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSCOMMERCIAL.Value  = clsCtcontrat.TI_IDTIERSCOMMERCIAL ;
			SqlParameter vppParamTI_IDTIERSASSUREUR = new SqlParameter("@TI_IDTIERSASSUREUR", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSASSUREUR.Value  = clsCtcontrat.TI_IDTIERSASSUREUR ;
			SqlParameter vppParamCA_DATETRANSMISSIONAASSUREUR = new SqlParameter("@CA_DATETRANSMISSIONAASSUREUR", SqlDbType.DateTime);
			vppParamCA_DATETRANSMISSIONAASSUREUR.Value  = clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR ;
			SqlParameter vppParamCA_DATEVALIDATIONASSUREUR = new SqlParameter("@CA_DATEVALIDATIONASSUREUR", SqlDbType.DateTime);
			vppParamCA_DATEVALIDATIONASSUREUR.Value  = clsCtcontrat.CA_DATEVALIDATIONASSUREUR ;
			SqlParameter vppParamCA_DATESUSPENSION = new SqlParameter("@CA_DATESUSPENSION", SqlDbType.DateTime);
			vppParamCA_DATESUSPENSION.Value  = clsCtcontrat.CA_DATESUSPENSION ;
			SqlParameter vppParamCA_DATECLOTURE = new SqlParameter("@CA_DATECLOTURE", SqlDbType.DateTime);
			vppParamCA_DATECLOTURE.Value  = clsCtcontrat.CA_DATECLOTURE ;
			SqlParameter vppParamCA_DATERESILIATION = new SqlParameter("@CA_DATERESILIATION", SqlDbType.DateTime);
			vppParamCA_DATERESILIATION.Value  = clsCtcontrat.CA_DATERESILIATION ;
			SqlParameter vppParamCA_NOMINTERLOCUTEUR = new SqlParameter("@CA_NOMINTERLOCUTEUR", SqlDbType.VarChar, 1000);
			vppParamCA_NOMINTERLOCUTEUR.Value  = clsCtcontrat.CA_NOMINTERLOCUTEUR ;
			SqlParameter vppParamCA_CONTACTINTERLOCUTEUR = new SqlParameter("@CA_CONTACTINTERLOCUTEUR", SqlDbType.VarChar, 1000);
			vppParamCA_CONTACTINTERLOCUTEUR.Value  = clsCtcontrat.CA_CONTACTINTERLOCUTEUR ;
			SqlParameter vppParamDI_CODEDESIGNATION = new SqlParameter("@DI_CODEDESIGNATION", SqlDbType.VarChar, 2);
			vppParamDI_CODEDESIGNATION.Value  = clsCtcontrat.DI_CODEDESIGNATION ;
			if(clsCtcontrat.DI_CODEDESIGNATION== ""  ) vppParamDI_CODEDESIGNATION.Value  = DBNull.Value;
			SqlParameter vppParamTA_CODETYPECONTRATSANTE = new SqlParameter("@TA_CODETYPECONTRATSANTE", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPECONTRATSANTE.Value  = clsCtcontrat.TA_CODETYPECONTRATSANTE ;
			if(clsCtcontrat.TA_CODETYPECONTRATSANTE== ""  ) vppParamTA_CODETYPECONTRATSANTE.Value  = DBNull.Value;
			SqlParameter vppParamCA_CODECONTRATSECONDAIRE = new SqlParameter("@CA_CODECONTRATSECONDAIRE", SqlDbType.Decimal, 4);
			vppParamCA_CODECONTRATSECONDAIRE.Value  = clsCtcontrat.CA_CODECONTRATSECONDAIRE ;
			if(clsCtcontrat.CA_CODECONTRATSECONDAIRE== ""  ) vppParamCA_CODECONTRATSECONDAIRE.Value  = DBNull.Value;
			SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
			vppParamCO_CODECOMMUNE.Value  = clsCtcontrat.CO_CODECOMMUNE ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtcontrat.RQ_CODERISQUE ;
			SqlParameter vppParamTA_CODETYPEAFFAIRES = new SqlParameter("@TA_CODETYPEAFFAIRES", SqlDbType.VarChar, 2);
            vppParamTA_CODETYPEAFFAIRES.Value  = clsCtcontrat.TA_CODETYPEAFFAIRES;

            SqlParameter vppParamCA_DATEDEMANDERENOUVELEMENT = new SqlParameter("@CA_DATEDEMANDERENOUVELEMENT", SqlDbType.DateTime);
            vppParamCA_DATEDEMANDERENOUVELEMENT.Value = clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT;

            SqlParameter vppParamCA_CODECONTRATORIGINE = new SqlParameter("@CA_CODECONTRATORIGINE", SqlDbType.VarChar, 50);
            vppParamCA_CODECONTRATORIGINE.Value = clsCtcontrat.CA_CODECONTRATORIGINE;
            if (clsCtcontrat.CA_CODECONTRATORIGINE == "") vppParamCA_CODECONTRATORIGINE.Value = DBNull.Value;

            SqlParameter vppParamGR_CODEGARENTIEPRIME = new SqlParameter("@GR_CODEGARENTIEPRIME", SqlDbType.VarChar, 50);
            vppParamGR_CODEGARENTIEPRIME.Value = clsCtcontrat.GR_CODEGARENTIEPRIME;
            if (clsCtcontrat.GR_CODEGARENTIEPRIME == "") vppParamGR_CODEGARENTIEPRIME.Value = DBNull.Value;

            SqlParameter vppParamCA_OBSERVATION = new SqlParameter("@CA_OBSERVATION", SqlDbType.VarChar, 150);
            vppParamCA_OBSERVATION.Value = clsCtcontrat.CA_OBSERVATION;
            if (clsCtcontrat.CA_OBSERVATION == "") vppParamCA_OBSERVATION.Value = DBNull.Value;



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRAT  @CA_CODECONTRAT, @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_NUMPOLICE, @CA_DATESAISIE, @TI_IDTIERS, @IT_CODEINTERMEDIAIRE, @AP_CODETYPEAPPARTEMENT, @OC_CODETYPEOCCUPANT,  @ZA_CODEZONEAUTO, @CB_IDBRANCHE, @CA_DATEEFFET, @CA_DATEECHEANCE, @OP_CODEOPERATEUR, @CA_AVENANT, @CA_SITUATIONGEOGRAPHIQUE, @CA_CONDITIONHABITUEL, @ST_CODESTATUTSOCIOPROF, @AU_CODECATEGORIE, @TA_CODETARIF, @US_CODEUSAGE, @GE_CODEGENRE, @TVH_CODETYPE, @EN_CODEENERGIE, @CA_TAUX, @CA_TYPE, @CA_NUMSERIE, @CA_IMMATRICULATION, @CA_PUISSANCEADMISE, @CA_CHARGEUTILE, @CA_NBREPLACE, @CA_VALNEUVE, @CA_VALVENALE, @CA_DATEMISECIRCULATION, @CA_CLIENTEXONERETAXE, @TI_IDTIERSCOMMERCIAL, @TI_IDTIERSASSUREUR, @CA_DATETRANSMISSIONAASSUREUR,   @CA_DATESUSPENSION, @CA_DATECLOTURE, @CA_DATERESILIATION, @CA_NOMINTERLOCUTEUR, @CA_CONTACTINTERLOCUTEUR, @DI_CODEDESIGNATION, @TA_CODETYPECONTRATSANTE, @CA_CODECONTRATSECONDAIRE,  @CO_CODECOMMUNE, @RQ_CODERISQUE,@TA_CODETYPEAFFAIRES,@CA_DATEDEMANDERENOUVELEMENT,@GR_CODEGARENTIEPRIME,@GR_CODEGARENTIEPRIME, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_NUMPOLICE);
			vppSqlCmd.Parameters.Add(vppParamCA_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamIT_CODEINTERMEDIAIRE);
			vppSqlCmd.Parameters.Add(vppParamAP_CODETYPEAPPARTEMENT);
			vppSqlCmd.Parameters.Add(vppParamOC_CODETYPEOCCUPANT);
			vppSqlCmd.Parameters.Add(vppParamZA_CODEZONEAUTO);
			vppSqlCmd.Parameters.Add(vppParamCB_IDBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEEFFET);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEECHEANCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCA_AVENANT);
			vppSqlCmd.Parameters.Add(vppParamCA_SITUATIONGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamCA_CONDITIONHABITUEL);
			vppSqlCmd.Parameters.Add(vppParamST_CODESTATUTSOCIOPROF);
			vppSqlCmd.Parameters.Add(vppParamAU_CODECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETARIF);
			vppSqlCmd.Parameters.Add(vppParamUS_CODEUSAGE);
			vppSqlCmd.Parameters.Add(vppParamGE_CODEGENRE);
			vppSqlCmd.Parameters.Add(vppParamTVH_CODETYPE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENERGIE);
			vppSqlCmd.Parameters.Add(vppParamCA_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCA_TYPE);
			vppSqlCmd.Parameters.Add(vppParamCA_NUMSERIE);
			vppSqlCmd.Parameters.Add(vppParamCA_IMMATRICULATION);
			vppSqlCmd.Parameters.Add(vppParamCA_PUISSANCEADMISE);
			vppSqlCmd.Parameters.Add(vppParamCA_CHARGEUTILE);
			vppSqlCmd.Parameters.Add(vppParamCA_NBREPLACE);
			vppSqlCmd.Parameters.Add(vppParamCA_VALNEUVE);
			vppSqlCmd.Parameters.Add(vppParamCA_VALVENALE);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEMISECIRCULATION);
			vppSqlCmd.Parameters.Add(vppParamCA_CLIENTEXONERETAXE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSCOMMERCIAL);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamCA_DATETRANSMISSIONAASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEVALIDATIONASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamCA_DATESUSPENSION);
			vppSqlCmd.Parameters.Add(vppParamCA_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamCA_DATERESILIATION);
			vppSqlCmd.Parameters.Add(vppParamCA_NOMINTERLOCUTEUR);
			vppSqlCmd.Parameters.Add(vppParamCA_CONTACTINTERLOCUTEUR);
			vppSqlCmd.Parameters.Add(vppParamDI_CODEDESIGNATION);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPECONTRATSANTE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRATSECONDAIRE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEAFFAIRES);
			vppSqlCmd.Parameters.Add(vppParamCA_DATEDEMANDERENOUVELEMENT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRATORIGINE);
			vppSqlCmd.Parameters.Add(vppParamGR_CODEGARENTIEPRIME);
			vppSqlCmd.Parameters.Add(vppParamCA_OBSERVATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontrat>clsCtcontrat</param>
		///<author>Home Technology</author>
		public string pvgMiseAjour(clsDonnee clsDonnee, clsCtcontrat clsCtcontrat)
        {
            //Préparation des paramètres
            SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
            vppParamCA_CODECONTRAT.Value = clsCtcontrat.CA_CODECONTRAT;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 50);
            vppParamAG_CODEAGENCE.Value = clsCtcontrat.AG_CODEAGENCE;
            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsCtcontrat.EN_CODEENTREPOT;
            SqlParameter vppParamCA_NUMPOLICE = new SqlParameter("@CA_NUMPOLICE", SqlDbType.VarChar, 1000);
            vppParamCA_NUMPOLICE.Value = clsCtcontrat.CA_NUMPOLICE;
            if (clsCtcontrat.CA_NUMPOLICE == "") vppParamCA_NUMPOLICE.Value = DBNull.Value;
            SqlParameter vppParamCA_DATESAISIE = new SqlParameter("@CA_DATESAISIE", SqlDbType.DateTime);
            vppParamCA_DATESAISIE.Value = clsCtcontrat.CA_DATESAISIE;
            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERS.Value = clsCtcontrat.TI_IDTIERS;
            SqlParameter vppParamIT_CODEINTERMEDIAIRE = new SqlParameter("@IT_CODEINTERMEDIAIRE", SqlDbType.VarChar, 5);
            vppParamIT_CODEINTERMEDIAIRE.Value = clsCtcontrat.IT_CODEINTERMEDIAIRE;
            if (clsCtcontrat.IT_CODEINTERMEDIAIRE == "") vppParamIT_CODEINTERMEDIAIRE.Value = DBNull.Value;
            SqlParameter vppParamAP_CODETYPEAPPARTEMENT = new SqlParameter("@AP_CODETYPEAPPARTEMENT", SqlDbType.VarChar, 5);
            vppParamAP_CODETYPEAPPARTEMENT.Value = clsCtcontrat.AP_CODETYPEAPPARTEMENT;
            if (clsCtcontrat.AP_CODETYPEAPPARTEMENT == "") vppParamAP_CODETYPEAPPARTEMENT.Value = DBNull.Value;
            SqlParameter vppParamOC_CODETYPEOCCUPANT = new SqlParameter("@OC_CODETYPEOCCUPANT", SqlDbType.VarChar, 2);
            vppParamOC_CODETYPEOCCUPANT.Value = clsCtcontrat.OC_CODETYPEOCCUPANT;
            if (clsCtcontrat.OC_CODETYPEOCCUPANT == "") vppParamOC_CODETYPEOCCUPANT.Value = DBNull.Value;
            SqlParameter vppParamZA_CODEZONEAUTO = new SqlParameter("@ZA_CODEZONEAUTO", SqlDbType.VarChar, 7);
            vppParamZA_CODEZONEAUTO.Value = clsCtcontrat.ZA_CODEZONEAUTO;
            if (clsCtcontrat.ZA_CODEZONEAUTO == "") vppParamZA_CODEZONEAUTO.Value = DBNull.Value;
            SqlParameter vppParamCB_IDBRANCHE = new SqlParameter("@CB_IDBRANCHE", SqlDbType.VarChar, 50);
            vppParamCB_IDBRANCHE.Value = clsCtcontrat.CB_IDBRANCHE;
            if (clsCtcontrat.CB_IDBRANCHE == "") vppParamCB_IDBRANCHE.Value = DBNull.Value;
            SqlParameter vppParamCA_DATEEFFET = new SqlParameter("@CA_DATEEFFET", SqlDbType.DateTime);
            vppParamCA_DATEEFFET.Value = clsCtcontrat.CA_DATEEFFET;
            SqlParameter vppParamCA_DATEECHEANCE = new SqlParameter("@CA_DATEECHEANCE", SqlDbType.DateTime);
            vppParamCA_DATEECHEANCE.Value = clsCtcontrat.CA_DATEECHEANCE;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsCtcontrat.OP_CODEOPERATEUR;
            SqlParameter vppParamCA_AVENANT = new SqlParameter("@CA_AVENANT", SqlDbType.VarChar, 1000);
            vppParamCA_AVENANT.Value = clsCtcontrat.CA_AVENANT;
            if (clsCtcontrat.CA_AVENANT == "") vppParamCA_AVENANT.Value = DBNull.Value;
            SqlParameter vppParamCA_SITUATIONGEOGRAPHIQUE = new SqlParameter("@CA_SITUATIONGEOGRAPHIQUE", SqlDbType.VarChar, 1000);
            vppParamCA_SITUATIONGEOGRAPHIQUE.Value = clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE;
            if (clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE == "") vppParamCA_SITUATIONGEOGRAPHIQUE.Value = DBNull.Value;
            SqlParameter vppParamCA_CONDITIONHABITUEL = new SqlParameter("@CA_CONDITIONHABITUEL", SqlDbType.VarChar, 1000);
            vppParamCA_CONDITIONHABITUEL.Value = clsCtcontrat.CA_CONDITIONHABITUEL;
            if (clsCtcontrat.CA_CONDITIONHABITUEL == "") vppParamCA_CONDITIONHABITUEL.Value = DBNull.Value;
            SqlParameter vppParamST_CODESTATUTSOCIOPROF = new SqlParameter("@ST_CODESTATUTSOCIOPROF", SqlDbType.VarChar, 2);
            vppParamST_CODESTATUTSOCIOPROF.Value = clsCtcontrat.ST_CODESTATUTSOCIOPROF;
            if (clsCtcontrat.ST_CODESTATUTSOCIOPROF == "") vppParamST_CODESTATUTSOCIOPROF.Value = DBNull.Value;

            SqlParameter vppParamAU_CODECATEGORIE = new SqlParameter("@AU_CODECATEGORIE", SqlDbType.VarChar, 50);
            vppParamAU_CODECATEGORIE.Value = clsCtcontrat.AU_CODECATEGORIE;
            if (clsCtcontrat.AU_CODECATEGORIE == "") vppParamAU_CODECATEGORIE.Value = DBNull.Value;
            SqlParameter vppParamTA_CODETARIF = new SqlParameter("@TA_CODETARIF", SqlDbType.VarChar, 50);
            vppParamTA_CODETARIF.Value = clsCtcontrat.TA_CODETARIF;
            if (clsCtcontrat.TA_CODETARIF == "") vppParamTA_CODETARIF.Value = DBNull.Value;
            SqlParameter vppParamUS_CODEUSAGE = new SqlParameter("@US_CODEUSAGE", SqlDbType.VarChar, 3);
            vppParamUS_CODEUSAGE.Value = clsCtcontrat.US_CODEUSAGE;
            if (clsCtcontrat.US_CODEUSAGE == "") vppParamUS_CODEUSAGE.Value = DBNull.Value;
            SqlParameter vppParamGE_CODEGENRE = new SqlParameter("@GE_CODEGENRE", SqlDbType.VarChar, 3);
            vppParamGE_CODEGENRE.Value = clsCtcontrat.GE_CODEGENRE;
            if (clsCtcontrat.GE_CODEGENRE == "") vppParamGE_CODEGENRE.Value = DBNull.Value;
            SqlParameter vppParamTVH_CODETYPE = new SqlParameter("@TVH_CODETYPE", SqlDbType.VarChar, 50);
            vppParamTVH_CODETYPE.Value = clsCtcontrat.TVH_CODETYPE;
            if (clsCtcontrat.TVH_CODETYPE == "") vppParamTVH_CODETYPE.Value = DBNull.Value;
            SqlParameter vppParamEN_CODEENERGIE = new SqlParameter("@EN_CODEENERGIE", SqlDbType.VarChar, 50);
            vppParamEN_CODEENERGIE.Value = clsCtcontrat.EN_CODEENERGIE;
            if (clsCtcontrat.EN_CODEENERGIE == "") vppParamEN_CODEENERGIE.Value = DBNull.Value;
            SqlParameter vppParamCA_TAUX = new SqlParameter("@CA_TAUX", SqlDbType.Float);
            vppParamCA_TAUX.Value = clsCtcontrat.CA_TAUX;
            //if (clsCtcontrat.CA_TAUX == 0) vppParamCA_TAUX.Value = DBNull.Value;
            SqlParameter vppParamCA_TYPE = new SqlParameter("@CA_TYPE", SqlDbType.VarChar, 1000);
            vppParamCA_TYPE.Value = clsCtcontrat.CA_TYPE;
            if (clsCtcontrat.CA_TYPE == "") vppParamCA_TYPE.Value = DBNull.Value;
            SqlParameter vppParamCA_NUMSERIE = new SqlParameter("@CA_NUMSERIE", SqlDbType.VarChar, 1000);
            vppParamCA_NUMSERIE.Value = clsCtcontrat.CA_NUMSERIE;
            if (clsCtcontrat.CA_NUMSERIE == "") vppParamCA_NUMSERIE.Value = DBNull.Value;
            SqlParameter vppParamCA_IMMATRICULATION = new SqlParameter("@CA_IMMATRICULATION", SqlDbType.VarChar, 1000);
            vppParamCA_IMMATRICULATION.Value = clsCtcontrat.CA_IMMATRICULATION;
            if (clsCtcontrat.CA_IMMATRICULATION == "") vppParamCA_IMMATRICULATION.Value = DBNull.Value;
            SqlParameter vppParamCA_PUISSANCEADMISE = new SqlParameter("@CA_PUISSANCEADMISE", SqlDbType.Int);
            vppParamCA_PUISSANCEADMISE.Value = clsCtcontrat.CA_PUISSANCEADMISE;
            //if (clsCtcontrat.CA_PUISSANCEADMISE == 0) vppParamCA_PUISSANCEADMISE.Value = DBNull.Value;
            SqlParameter vppParamCA_CHARGEUTILE = new SqlParameter("@CA_CHARGEUTILE", SqlDbType.Float);
            vppParamCA_CHARGEUTILE.Value = clsCtcontrat.CA_CHARGEUTILE;
           // if (clsCtcontrat.CA_CHARGEUTILE == 0) vppParamCA_CHARGEUTILE.Value = DBNull.Value;
            SqlParameter vppParamCA_NBREPLACE = new SqlParameter("@CA_NBREPLACE", SqlDbType.Int);
            vppParamCA_NBREPLACE.Value = clsCtcontrat.CA_NBREPLACE;
            //if (clsCtcontrat.CA_NBREPLACE == 0) vppParamCA_NBREPLACE.Value = DBNull.Value;
            SqlParameter vppParamCA_VALNEUVE = new SqlParameter("@CA_VALNEUVE", SqlDbType.Money);
            vppParamCA_VALNEUVE.Value = clsCtcontrat.CA_VALNEUVE;
            //if (clsCtcontrat.CA_VALNEUVE == 0) vppParamCA_VALNEUVE.Value = DBNull.Value;
            SqlParameter vppParamCA_VALVENALE = new SqlParameter("@CA_VALVENALE", SqlDbType.Money);
            vppParamCA_VALVENALE.Value = clsCtcontrat.CA_VALVENALE;
            //if (clsCtcontrat.CA_VALVENALE == 0) vppParamCA_VALVENALE.Value = DBNull.Value;
            SqlParameter vppParamCA_DATEMISECIRCULATION = new SqlParameter("@CA_DATEMISECIRCULATION", SqlDbType.DateTime);
            vppParamCA_DATEMISECIRCULATION.Value = clsCtcontrat.CA_DATEMISECIRCULATION;
            if (clsCtcontrat.CA_DATEMISECIRCULATION.Year < 1900) vppParamCA_DATEMISECIRCULATION.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamCA_CLIENTEXONERETAXE = new SqlParameter("@CA_CLIENTEXONERETAXE", SqlDbType.VarChar, 1);
            vppParamCA_CLIENTEXONERETAXE.Value = clsCtcontrat.CA_CLIENTEXONERETAXE;
            if (clsCtcontrat.CA_CLIENTEXONERETAXE == "") vppParamCA_CLIENTEXONERETAXE.Value = DBNull.Value;
            SqlParameter vppParamTI_IDTIERSCOMMERCIAL = new SqlParameter("@TI_IDTIERSCOMMERCIAL", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERSCOMMERCIAL.Value = clsCtcontrat.TI_IDTIERSCOMMERCIAL;
            SqlParameter vppParamTI_IDTIERSASSUREUR = new SqlParameter("@TI_IDTIERSASSUREUR", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERSASSUREUR.Value = clsCtcontrat.TI_IDTIERSASSUREUR;
            SqlParameter vppParamCA_DATETRANSMISSIONAASSUREUR = new SqlParameter("@CA_DATETRANSMISSIONAASSUREUR", SqlDbType.DateTime);
            vppParamCA_DATETRANSMISSIONAASSUREUR.Value = clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR;
            SqlParameter vppParamCA_DATEVALIDATIONASSUREUR = new SqlParameter("@CA_DATEVALIDATIONASSUREUR", SqlDbType.DateTime);
            vppParamCA_DATEVALIDATIONASSUREUR.Value = clsCtcontrat.CA_DATEVALIDATIONASSUREUR;


            SqlParameter vppParamCA_DATESUSPENSION = new SqlParameter("@CA_DATESUSPENSION", SqlDbType.DateTime);
            vppParamCA_DATESUSPENSION.Value = clsCtcontrat.CA_DATESUSPENSION;
            SqlParameter vppParamCA_DATECLOTURE = new SqlParameter("@CA_DATECLOTURE", SqlDbType.DateTime);
            vppParamCA_DATECLOTURE.Value = clsCtcontrat.CA_DATECLOTURE;
            SqlParameter vppParamCA_DATERESILIATION = new SqlParameter("@CA_DATERESILIATION", SqlDbType.DateTime);
            vppParamCA_DATERESILIATION.Value = clsCtcontrat.CA_DATERESILIATION;
            SqlParameter vppParamCA_NOMINTERLOCUTEUR = new SqlParameter("@CA_NOMINTERLOCUTEUR", SqlDbType.VarChar, 1000);
            vppParamCA_NOMINTERLOCUTEUR.Value = clsCtcontrat.CA_NOMINTERLOCUTEUR;
            SqlParameter vppParamCA_CONTACTINTERLOCUTEUR = new SqlParameter("@CA_CONTACTINTERLOCUTEUR", SqlDbType.VarChar, 1000);
            vppParamCA_CONTACTINTERLOCUTEUR.Value = clsCtcontrat.CA_CONTACTINTERLOCUTEUR;
            SqlParameter vppParamDI_CODEDESIGNATION = new SqlParameter("@DI_CODEDESIGNATION", SqlDbType.VarChar, 2);
            vppParamDI_CODEDESIGNATION.Value = clsCtcontrat.DI_CODEDESIGNATION;
            if (clsCtcontrat.DI_CODEDESIGNATION == "") vppParamDI_CODEDESIGNATION.Value = DBNull.Value;
            SqlParameter vppParamTA_CODETYPECONTRATSANTE = new SqlParameter("@TA_CODETYPECONTRATSANTE", SqlDbType.VarChar, 2);
            vppParamTA_CODETYPECONTRATSANTE.Value = clsCtcontrat.TA_CODETYPECONTRATSANTE;
            if (clsCtcontrat.TA_CODETYPECONTRATSANTE == "") vppParamTA_CODETYPECONTRATSANTE.Value = DBNull.Value;
            SqlParameter vppParamCA_CODECONTRATSECONDAIRE = new SqlParameter("@CA_CODECONTRATSECONDAIRE", SqlDbType.Decimal, 4);
            vppParamCA_CODECONTRATSECONDAIRE.Value = clsCtcontrat.CA_CODECONTRATSECONDAIRE;
            if (clsCtcontrat.CA_CODECONTRATSECONDAIRE == "") vppParamCA_CODECONTRATSECONDAIRE.Value = DBNull.Value;

            SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
            vppParamCO_CODECOMMUNE.Value = clsCtcontrat.CO_CODECOMMUNE;

            SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
            vppParamRQ_CODERISQUE.Value = clsCtcontrat.RQ_CODERISQUE;

            SqlParameter vppParamTA_CODETYPEAFFAIRES = new SqlParameter("@TA_CODETYPEAFFAIRES", SqlDbType.VarChar, 2);
            vppParamTA_CODETYPEAFFAIRES.Value = clsCtcontrat.TA_CODETYPEAFFAIRES;


            SqlParameter vppParamMF_CODEMAINFORTE = new SqlParameter("@MF_CODEMAINFORTE", SqlDbType.VarChar, 2);
            vppParamMF_CODEMAINFORTE.Value = clsCtcontrat.MF_CODEMAINFORTE;
            if (clsCtcontrat.MF_CODEMAINFORTE == "") vppParamMF_CODEMAINFORTE.Value = DBNull.Value;

            SqlParameter vppParamZM_CODEZONEVOYAGE = new SqlParameter("@ZM_CODEZONEVOYAGE", SqlDbType.VarChar, 50);
            vppParamZM_CODEZONEVOYAGE.Value = clsCtcontrat.ZM_CODEZONEVOYAGE;
            if (clsCtcontrat.ZM_CODEZONEVOYAGE == "") vppParamZM_CODEZONEVOYAGE.Value = DBNull.Value;


            SqlParameter vppParamCA_NOMBREPIECE = new SqlParameter("@CA_NOMBREPIECE", SqlDbType.Int);
            vppParamCA_NOMBREPIECE.Value = clsCtcontrat.CA_NOMBREPIECE;
            //if (clsCtcontrat.CA_NOMBREPIECE == 0) vppParamCA_NOMBREPIECE.Value = DBNull.Value;

            SqlParameter vppParamCA_SUPERFICIE = new SqlParameter("@CA_SUPERFICIE", SqlDbType.Money);
            vppParamCA_SUPERFICIE.Value = clsCtcontrat.CA_SUPERFICIE;
            //if (clsCtcontrat.CA_SUPERFICIE == 0) vppParamCA_SUPERFICIE.Value = DBNull.Value;


            SqlParameter vppParamCA_LOYERMENSUEL = new SqlParameter("@CA_LOYERMENSUEL", SqlDbType.Money);
            vppParamCA_LOYERMENSUEL.Value = clsCtcontrat.CA_LOYERMENSUEL;
           // if (clsCtcontrat.CA_LOYERMENSUEL == 0) vppParamCA_LOYERMENSUEL.Value = DBNull.Value;


            SqlParameter vppParamCA_DATENAISSANCE = new SqlParameter("@CA_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCA_DATENAISSANCE.Value = clsCtcontrat.CA_DATENAISSANCE;

            SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 50);
            vppParamPF_CODEPROFESSION.Value = clsCtcontrat.PF_CODEPROFESSION;
            if (clsCtcontrat.PF_CODEPROFESSION == "") vppParamPF_CODEPROFESSION.Value = DBNull.Value;

            SqlParameter vppParamCA_LIEUNAISSANCE = new SqlParameter("@CA_LIEUNAISSANCE", SqlDbType.VarChar, 150);
            vppParamCA_LIEUNAISSANCE.Value = clsCtcontrat.CA_LIEUNAISSANCE;
            if (clsCtcontrat.CA_LIEUNAISSANCE == "") vppParamCA_LIEUNAISSANCE.Value = DBNull.Value;

            SqlParameter vppParamCD_CODECONDITION = new SqlParameter("@CD_CODECONDITION", SqlDbType.VarChar, 2);
            vppParamCD_CODECONDITION.Value = clsCtcontrat.CD_CODECONDITION;
            if (clsCtcontrat.CD_CODECONDITION == "") vppParamCD_CODECONDITION.Value = DBNull.Value;


            SqlParameter vppParamCA_DUREEENMOIS = new SqlParameter("@CA_DUREEENMOIS", SqlDbType.Int);
            vppParamCA_DUREEENMOIS.Value = clsCtcontrat.CA_DUREEENMOIS;
            //if (clsCtcontrat.CA_DUREEENMOIS == 0) vppParamCA_DUREEENMOIS.Value = DBNull.Value;
            SqlParameter vppParamAC_SPORT = new SqlParameter("@AC_SPORT", SqlDbType.VarChar, 150);
            vppParamAC_SPORT.Value = clsCtcontrat.AC_SPORT;
            if (clsCtcontrat.AC_SPORT == "") vppParamAC_SPORT.Value = DBNull.Value;

            SqlParameter vppParamCA_ADRESSE = new SqlParameter("@CA_ADRESSE", SqlDbType.VarChar, 150);
            vppParamCA_ADRESSE.Value = clsCtcontrat.CA_ADRESSE;
            if (clsCtcontrat.CA_ADRESSE == "") vppParamCA_ADRESSE.Value = DBNull.Value;

            SqlParameter vppParamGA_CODEGARANTIE = new SqlParameter("@GA_CODEGARANTIE", SqlDbType.VarChar, 150);
            vppParamGA_CODEGARANTIE.Value = clsCtcontrat.GA_CODEGARANTIE;
            if (clsCtcontrat.GA_CODEGARANTIE == "") vppParamGA_CODEGARANTIE.Value = DBNull.Value;

            SqlParameter vppParamCA_NUMPASSEPORT = new SqlParameter("@CA_NUMPASSEPORT", SqlDbType.VarChar, 150);
            vppParamCA_NUMPASSEPORT.Value = clsCtcontrat.CA_NUMPASSEPORT;
            if (clsCtcontrat.CA_NUMPASSEPORT == "") vppParamCA_NUMPASSEPORT.Value = DBNull.Value;

            SqlParameter vppParamPY_CODEPAYSDESTINATION = new SqlParameter("@PY_CODEPAYSDESTINATION", SqlDbType.VarChar, 4);
            vppParamPY_CODEPAYSDESTINATION.Value = clsCtcontrat.PY_CODEPAYSDESTINATION;
            if (clsCtcontrat.PY_CODEPAYSDESTINATION == "") vppParamPY_CODEPAYSDESTINATION.Value = DBNull.Value;

            SqlParameter vppParamCA_DUREESEJOUR = new SqlParameter("@CA_DUREESEJOUR", SqlDbType.Int);
            vppParamCA_DUREESEJOUR.Value = clsCtcontrat.CA_DUREESEJOUR;

            SqlParameter vppParamCA_OPTION = new SqlParameter("@CA_OPTION", SqlDbType.VarChar, 150);
            vppParamCA_OPTION.Value = clsCtcontrat.CA_OPTION;
            if (clsCtcontrat.CA_OPTION == "") vppParamCA_OPTION.Value = DBNull.Value;

            SqlParameter vppParamAU_CODETYPECONTRATAUTO = new SqlParameter("@AU_CODETYPECONTRATAUTO", SqlDbType.VarChar, 2);
            vppParamAU_CODETYPECONTRATAUTO.Value = clsCtcontrat.AU_CODETYPECONTRATAUTO;
            if (clsCtcontrat.AU_CODETYPECONTRATAUTO == "") vppParamAU_CODETYPECONTRATAUTO.Value = DBNull.Value;

            SqlParameter vppParamCA_DATEDEMANDERENOUVELEMENT = new SqlParameter("@CA_DATEDEMANDERENOUVELEMENT", SqlDbType.DateTime);
            vppParamCA_DATEDEMANDERENOUVELEMENT.Value = clsCtcontrat.CA_DATEDEMANDERENOUVELEMENT;

            SqlParameter vppParamCA_CODECONTRATORIGINE = new SqlParameter("@CA_CODECONTRATORIGINE", SqlDbType.VarChar, 50);
            vppParamCA_CODECONTRATORIGINE.Value = clsCtcontrat.CA_CODECONTRATORIGINE;
            if (clsCtcontrat.CA_CODECONTRATORIGINE == "") vppParamCA_CODECONTRATORIGINE.Value = DBNull.Value;

            SqlParameter vppParamGR_CODEGARENTIEPRIME = new SqlParameter("@GR_CODEGARENTIEPRIME", SqlDbType.VarChar, 50);
            vppParamGR_CODEGARENTIEPRIME.Value = clsCtcontrat.GR_CODEGARENTIEPRIME;
            if (clsCtcontrat.GR_CODEGARENTIEPRIME == "") vppParamGR_CODEGARENTIEPRIME.Value = DBNull.Value;

            SqlParameter vppParamCA_OBSERVATION = new SqlParameter("@CA_OBSERVATION", SqlDbType.VarChar, 150);
            vppParamCA_OBSERVATION.Value = clsCtcontrat.CA_OBSERVATION;
            if (clsCtcontrat.CA_OBSERVATION == "") vppParamCA_OBSERVATION.Value = DBNull.Value;

            SqlParameter vppParamEX_EXERCICE = new SqlParameter("@EX_EXERCICE", SqlDbType.VarChar, 150);
            vppParamEX_EXERCICE.Value = clsCtcontrat.EX_EXERCICE;

            SqlParameter vppParamAS_NUMEROASSUREUR = new SqlParameter("@AS_NUMEROASSUREUR", SqlDbType.VarChar, 150);
            vppParamAS_NUMEROASSUREUR.Value = clsCtcontrat.AS_NUMEROASSUREUR;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsCtcontrat.TYPEOPERATION;

            SqlParameter vppParamCA_CODECONTRATRETOUR = new SqlParameter("@CA_CODECONTRATRETOUR", SqlDbType.VarChar, 50);

            //Préparation de la commande

            SqlCommand vppSqlCmd = new SqlCommand("PC_CTCONTRAT", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //this.vapRequete = "EXECUTE PC_CTCONTRAT  @CA_CODECONTRAT, @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_NUMPOLICE, @CA_DATESAISIE, @TI_IDTIERS, @IT_CODEINTERMEDIAIRE, @AP_CODETYPEAPPARTEMENT, @OC_CODETYPEOCCUPANT,  @ZA_CODEZONEAUTO, @CB_IDBRANCHE, @CA_DATEEFFET, @CA_DATEECHEANCE, @OP_CODEOPERATEUR, @CA_AVENANT, @CA_SITUATIONGEOGRAPHIQUE, @CA_CONDITIONHABITUEL, @ST_CODESTATUTSOCIOPROF, @AU_CODECATEGORIE, @TA_CODETARIF, @US_CODEUSAGE, @GE_CODEGENRE, @TVH_CODETYPE, @EN_CODEENERGIE, @CA_TAUX, @CA_TYPE, @CA_NUMSERIE, @CA_IMMATRICULATION, @CA_PUISSANCEADMISE, @CA_CHARGEUTILE, @CA_NBREPLACE, @CA_VALNEUVE, @CA_VALVENALE, @CA_DATEMISECIRCULATION, @CA_CLIENTEXONERETAXE, @TI_IDTIERSCOMMERCIAL, @TI_IDTIERSASSUREUR, @CA_DATETRANSMISSIONAASSUREUR, @CA_DATEVALIDATIONASSUREUR,   @CA_DATESUSPENSION, @CA_DATECLOTURE, @CA_DATERESILIATION, @CA_NOMINTERLOCUTEUR, @CA_CONTACTINTERLOCUTEUR, @DI_CODEDESIGNATION, @TA_CODETYPECONTRATSANTE, @CA_CODECONTRATSECONDAIRE,  @CO_CODECOMMUNE, @RQ_CODERISQUE, @CODECRYPTAGE, @TYPEOPERATION ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamCA_NUMPOLICE);
            vppSqlCmd.Parameters.Add(vppParamCA_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamIT_CODEINTERMEDIAIRE);
            vppSqlCmd.Parameters.Add(vppParamAP_CODETYPEAPPARTEMENT);
            vppSqlCmd.Parameters.Add(vppParamOC_CODETYPEOCCUPANT);
            vppSqlCmd.Parameters.Add(vppParamZA_CODEZONEAUTO);
            vppSqlCmd.Parameters.Add(vppParamCB_IDBRANCHE);
            vppSqlCmd.Parameters.Add(vppParamCA_DATEEFFET);
            vppSqlCmd.Parameters.Add(vppParamCA_DATEECHEANCE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCA_AVENANT);
            vppSqlCmd.Parameters.Add(vppParamCA_SITUATIONGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamCA_CONDITIONHABITUEL);
            vppSqlCmd.Parameters.Add(vppParamST_CODESTATUTSOCIOPROF);
            vppSqlCmd.Parameters.Add(vppParamAU_CODECATEGORIE);
            vppSqlCmd.Parameters.Add(vppParamTA_CODETARIF);
            vppSqlCmd.Parameters.Add(vppParamUS_CODEUSAGE);
            vppSqlCmd.Parameters.Add(vppParamGE_CODEGENRE);
            vppSqlCmd.Parameters.Add(vppParamTVH_CODETYPE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENERGIE);
            vppSqlCmd.Parameters.Add(vppParamCA_TAUX);
            vppSqlCmd.Parameters.Add(vppParamCA_TYPE);
            vppSqlCmd.Parameters.Add(vppParamCA_NUMSERIE);
            vppSqlCmd.Parameters.Add(vppParamCA_IMMATRICULATION);
            vppSqlCmd.Parameters.Add(vppParamCA_PUISSANCEADMISE);
            vppSqlCmd.Parameters.Add(vppParamCA_CHARGEUTILE);
            vppSqlCmd.Parameters.Add(vppParamCA_NBREPLACE);
            vppSqlCmd.Parameters.Add(vppParamCA_VALNEUVE);
            vppSqlCmd.Parameters.Add(vppParamCA_VALVENALE);
            vppSqlCmd.Parameters.Add(vppParamCA_DATEMISECIRCULATION);
            vppSqlCmd.Parameters.Add(vppParamCA_CLIENTEXONERETAXE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSASSUREUR);
            vppSqlCmd.Parameters.Add(vppParamCA_DATETRANSMISSIONAASSUREUR);
            vppSqlCmd.Parameters.Add(vppParamCA_DATEVALIDATIONASSUREUR);

            vppSqlCmd.Parameters.Add(vppParamCA_DATESUSPENSION);
            vppSqlCmd.Parameters.Add(vppParamCA_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamCA_DATERESILIATION);
            vppSqlCmd.Parameters.Add(vppParamCA_NOMINTERLOCUTEUR);
            vppSqlCmd.Parameters.Add(vppParamCA_CONTACTINTERLOCUTEUR);
            vppSqlCmd.Parameters.Add(vppParamDI_CODEDESIGNATION);
            vppSqlCmd.Parameters.Add(vppParamTA_CODETYPECONTRATSANTE);
            vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRATSECONDAIRE);
            vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
            vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
            vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEAFFAIRES);
            vppSqlCmd.Parameters.Add(vppParamMF_CODEMAINFORTE);
            vppSqlCmd.Parameters.Add(vppParamZM_CODEZONEVOYAGE);
            vppSqlCmd.Parameters.Add(vppParamCA_NOMBREPIECE);
            vppSqlCmd.Parameters.Add(vppParamCA_SUPERFICIE);
            vppSqlCmd.Parameters.Add(vppParamCA_LOYERMENSUEL);
            vppSqlCmd.Parameters.Add(vppParamCA_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
            vppSqlCmd.Parameters.Add(vppParamCA_LIEUNAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamCD_CODECONDITION);
            vppSqlCmd.Parameters.Add(vppParamCA_DUREEENMOIS);
            vppSqlCmd.Parameters.Add(vppParamAC_SPORT);
            vppSqlCmd.Parameters.Add(vppParamCA_ADRESSE);
            vppSqlCmd.Parameters.Add(vppParamGA_CODEGARANTIE);
            vppSqlCmd.Parameters.Add(vppParamCA_NUMPASSEPORT);
            vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYSDESTINATION);
            vppSqlCmd.Parameters.Add(vppParamCA_DUREESEJOUR);
            vppSqlCmd.Parameters.Add(vppParamCA_OPTION);
            vppSqlCmd.Parameters.Add(vppParamAU_CODETYPECONTRATAUTO);
            vppSqlCmd.Parameters.Add(vppParamCA_DATEDEMANDERENOUVELEMENT);
            vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRATORIGINE);
            vppSqlCmd.Parameters.Add(vppParamGR_CODEGARENTIEPRIME);
            vppSqlCmd.Parameters.Add(vppParamCA_OBSERVATION);
            vppSqlCmd.Parameters.Add(vppParamEX_EXERCICE);
            vppSqlCmd.Parameters.Add(vppParamAS_NUMEROASSUREUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRATRETOUR);
            vppParamCA_CODECONTRATRETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@CA_CODECONTRATRETOUR"].Value.ToString();



            //Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }





        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            //pvpChoixCritere(clsDonnee ,vppCritere);
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@CA_CODECONTRAT", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_CTCONTRAT  @CA_CODECONTRAT, @AG_CODEAGENCE, @EN_CODEENTREPOT, '', '', '', '', '', '', '',  '', '', '','', '','', '', '', '', '', '', '', '','', '', '', '', '', '', '', '','', '', '', '', '', '', '',  '',  '', '', '', '', '','', '0', '',  '', '','','','','','0','','','','','','','','','','','','','','','','','','','', @CODECRYPTAGE, 2,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF,  AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontrat </returns>
		///<author>Home Technology</author>
		public List<clsCtcontrat> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CA_CODECONTRAT, AG_CODEAGENCE, EN_CODEENTREPOT, CA_NUMPOLICE, CA_DATESAISIE, TI_IDTIERS, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, ZA_CODEZONEAUTO, CB_IDBRANCHE, CA_DATEEFFET, CA_DATEECHEANCE, OP_CODEOPERATEUR, CA_AVENANT, CA_SITUATIONGEOGRAPHIQUE, CA_CONDITIONHABITUEL, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, TVH_CODETYPE, EN_CODEENERGIE, CA_TAUX, CA_TYPE, CA_NUMSERIE, CA_IMMATRICULATION, CA_PUISSANCEADMISE, CA_CHARGEUTILE, CA_NBREPLACE, CA_VALNEUVE, CA_VALVENALE, CA_DATEMISECIRCULATION, CA_CLIENTEXONERETAXE, TI_IDTIERSCOMMERCIAL, TI_IDTIERSASSUREUR, CA_DATETRANSMISSIONAASSUREUR, CA_DATEVALIDATIONASSUREUR, CA_DATESUSPENSION, CA_DATECLOTURE, CA_DATERESILIATION, CA_NOMINTERLOCUTEUR, CA_CONTACTINTERLOCUTEUR, DI_CODEDESIGNATION, TA_CODETYPECONTRATSANTE, CA_CODECONTRATSECONDAIRE,  CO_CODECOMMUNE, RQ_CODERISQUE FROM dbo.FT_CTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontrat> clsCtcontrats = new List<clsCtcontrat>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontrat clsCtcontrat = new clsCtcontrat();
					clsCtcontrat.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontrat.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontrat.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontrat.CA_NUMPOLICE = clsDonnee.vogDataReader["CA_NUMPOLICE"].ToString();
					clsCtcontrat.CA_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CA_DATESAISIE"].ToString());
					clsCtcontrat.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsCtcontrat.IT_CODEINTERMEDIAIRE = clsDonnee.vogDataReader["IT_CODEINTERMEDIAIRE"].ToString();
					clsCtcontrat.AP_CODETYPEAPPARTEMENT = clsDonnee.vogDataReader["AP_CODETYPEAPPARTEMENT"].ToString();
					clsCtcontrat.OC_CODETYPEOCCUPANT = clsDonnee.vogDataReader["OC_CODETYPEOCCUPANT"].ToString();
					clsCtcontrat.ZA_CODEZONEAUTO = clsDonnee.vogDataReader["ZA_CODEZONEAUTO"].ToString();
					clsCtcontrat.CB_IDBRANCHE = clsDonnee.vogDataReader["CB_IDBRANCHE"].ToString();
					clsCtcontrat.CA_DATEEFFET = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEEFFET"].ToString());
					clsCtcontrat.CA_DATEECHEANCE = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEECHEANCE"].ToString());
					clsCtcontrat.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtcontrat.CA_AVENANT = clsDonnee.vogDataReader["CA_AVENANT"].ToString();
					clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = clsDonnee.vogDataReader["CA_SITUATIONGEOGRAPHIQUE"].ToString();
					clsCtcontrat.CA_CONDITIONHABITUEL = clsDonnee.vogDataReader["CA_CONDITIONHABITUEL"].ToString();
					clsCtcontrat.ST_CODESTATUTSOCIOPROF = clsDonnee.vogDataReader["ST_CODESTATUTSOCIOPROF"].ToString();
					clsCtcontrat.AU_CODECATEGORIE = clsDonnee.vogDataReader["AU_CODECATEGORIE"].ToString();
					clsCtcontrat.TA_CODETARIF = clsDonnee.vogDataReader["TA_CODETARIF"].ToString();
					clsCtcontrat.US_CODEUSAGE = clsDonnee.vogDataReader["US_CODEUSAGE"].ToString();
					clsCtcontrat.GE_CODEGENRE = clsDonnee.vogDataReader["GE_CODEGENRE"].ToString();
					clsCtcontrat.TVH_CODETYPE = clsDonnee.vogDataReader["TVH_CODETYPE"].ToString();
					clsCtcontrat.EN_CODEENERGIE = clsDonnee.vogDataReader["EN_CODEENERGIE"].ToString();
					clsCtcontrat.CA_TAUX = float.Parse(clsDonnee.vogDataReader["CA_TAUX"].ToString());
					clsCtcontrat.CA_TYPE = clsDonnee.vogDataReader["CA_TYPE"].ToString();
					clsCtcontrat.CA_NUMSERIE = clsDonnee.vogDataReader["CA_NUMSERIE"].ToString();
					clsCtcontrat.CA_IMMATRICULATION = clsDonnee.vogDataReader["CA_IMMATRICULATION"].ToString();
					clsCtcontrat.CA_PUISSANCEADMISE = int.Parse(clsDonnee.vogDataReader["CA_PUISSANCEADMISE"].ToString());
					clsCtcontrat.CA_CHARGEUTILE = float.Parse(clsDonnee.vogDataReader["CA_CHARGEUTILE"].ToString());
					clsCtcontrat.CA_NBREPLACE = int.Parse(clsDonnee.vogDataReader["CA_NBREPLACE"].ToString());
					clsCtcontrat.CA_VALNEUVE = double.Parse(clsDonnee.vogDataReader["CA_VALNEUVE"].ToString());
					clsCtcontrat.CA_VALVENALE = double.Parse(clsDonnee.vogDataReader["CA_VALVENALE"].ToString());
					clsCtcontrat.CA_DATEMISECIRCULATION = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEMISECIRCULATION"].ToString());
					clsCtcontrat.CA_CLIENTEXONERETAXE = clsDonnee.vogDataReader["CA_CLIENTEXONERETAXE"].ToString();
					clsCtcontrat.TI_IDTIERSCOMMERCIAL = clsDonnee.vogDataReader["TI_IDTIERSCOMMERCIAL"].ToString();
					clsCtcontrat.TI_IDTIERSASSUREUR = clsDonnee.vogDataReader["TI_IDTIERSASSUREUR"].ToString();
					clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = DateTime.Parse(clsDonnee.vogDataReader["CA_DATETRANSMISSIONAASSUREUR"].ToString());
					clsCtcontrat.CA_DATEVALIDATIONASSUREUR = DateTime.Parse(clsDonnee.vogDataReader["CA_DATEVALIDATIONASSUREUR"].ToString());
				
					clsCtcontrat.CA_DATESUSPENSION = DateTime.Parse(clsDonnee.vogDataReader["CA_DATESUSPENSION"].ToString());
					clsCtcontrat.CA_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["CA_DATECLOTURE"].ToString());
					clsCtcontrat.CA_DATERESILIATION = DateTime.Parse(clsDonnee.vogDataReader["CA_DATERESILIATION"].ToString());
					clsCtcontrat.CA_NOMINTERLOCUTEUR = clsDonnee.vogDataReader["CA_NOMINTERLOCUTEUR"].ToString();
					clsCtcontrat.CA_CONTACTINTERLOCUTEUR = clsDonnee.vogDataReader["CA_CONTACTINTERLOCUTEUR"].ToString();
					clsCtcontrat.DI_CODEDESIGNATION = clsDonnee.vogDataReader["DI_CODEDESIGNATION"].ToString();
					clsCtcontrat.TA_CODETYPECONTRATSANTE = clsDonnee.vogDataReader["TA_CODETYPECONTRATSANTE"].ToString();
					clsCtcontrat.CA_CODECONTRATSECONDAIRE = clsDonnee.vogDataReader["CA_CODECONTRATSECONDAIRE"].ToString();
					clsCtcontrat.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();
					clsCtcontrat.RQ_CODERISQUE = clsDonnee.vogDataReader["RQ_CODERISQUE"].ToString();
					clsCtcontrats.Add(clsCtcontrat);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontrats;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontrat </returns>
		///<author>Home Technology</author>
		public List<clsCtcontrat> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontrat> clsCtcontrats = new List<clsCtcontrat>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CA_CODECONTRAT, AG_CODEAGENCE, EN_CODEENTREPOT, CA_NUMPOLICE, CA_DATESAISIE, TI_IDTIERS, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, ZA_CODEZONEAUTO, CB_IDBRANCHE, CA_DATEEFFET, CA_DATEECHEANCE, OP_CODEOPERATEUR, CA_AVENANT, CA_SITUATIONGEOGRAPHIQUE, CA_CONDITIONHABITUEL, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, TVH_CODETYPE, EN_CODEENERGIE, CA_TAUX, CA_TYPE, CA_NUMSERIE, CA_IMMATRICULATION, CA_PUISSANCEADMISE, CA_CHARGEUTILE, CA_NBREPLACE, CA_VALNEUVE, CA_VALVENALE, CA_DATEMISECIRCULATION, CA_CLIENTEXONERETAXE, TI_IDTIERSCOMMERCIAL, TI_IDTIERSASSUREUR, CA_DATETRANSMISSIONAASSUREUR, CA_DATEVALIDATIONASSUREUR, CA_DATESUSPENSION, CA_DATECLOTURE, CA_DATERESILIATION, CA_NOMINTERLOCUTEUR, CA_CONTACTINTERLOCUTEUR, DI_CODEDESIGNATION, TA_CODETYPECONTRATSANTE, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE FROM dbo.FT_CTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontrat clsCtcontrat = new clsCtcontrat();
					clsCtcontrat.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontrat.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontrat.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontrat.CA_NUMPOLICE = Dataset.Tables["TABLE"].Rows[Idx]["CA_NUMPOLICE"].ToString();
					clsCtcontrat.CA_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATESAISIE"].ToString());
					clsCtcontrat.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsCtcontrat.IT_CODEINTERMEDIAIRE = Dataset.Tables["TABLE"].Rows[Idx]["IT_CODEINTERMEDIAIRE"].ToString();
					clsCtcontrat.AP_CODETYPEAPPARTEMENT = Dataset.Tables["TABLE"].Rows[Idx]["AP_CODETYPEAPPARTEMENT"].ToString();
					clsCtcontrat.OC_CODETYPEOCCUPANT = Dataset.Tables["TABLE"].Rows[Idx]["OC_CODETYPEOCCUPANT"].ToString();
					clsCtcontrat.ZA_CODEZONEAUTO = Dataset.Tables["TABLE"].Rows[Idx]["ZA_CODEZONEAUTO"].ToString();
					clsCtcontrat.CB_IDBRANCHE = Dataset.Tables["TABLE"].Rows[Idx]["CB_IDBRANCHE"].ToString();
					clsCtcontrat.CA_DATEEFFET = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATEEFFET"].ToString());
					clsCtcontrat.CA_DATEECHEANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATEECHEANCE"].ToString());
					clsCtcontrat.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtcontrat.CA_AVENANT = Dataset.Tables["TABLE"].Rows[Idx]["CA_AVENANT"].ToString();
					clsCtcontrat.CA_SITUATIONGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["CA_SITUATIONGEOGRAPHIQUE"].ToString();
					clsCtcontrat.CA_CONDITIONHABITUEL = Dataset.Tables["TABLE"].Rows[Idx]["CA_CONDITIONHABITUEL"].ToString();
					clsCtcontrat.ST_CODESTATUTSOCIOPROF = Dataset.Tables["TABLE"].Rows[Idx]["ST_CODESTATUTSOCIOPROF"].ToString();

					clsCtcontrat.AU_CODECATEGORIE = Dataset.Tables["TABLE"].Rows[Idx]["AU_CODECATEGORIE"].ToString();
					clsCtcontrat.TA_CODETARIF = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETARIF"].ToString();
					clsCtcontrat.US_CODEUSAGE = Dataset.Tables["TABLE"].Rows[Idx]["US_CODEUSAGE"].ToString();
					clsCtcontrat.GE_CODEGENRE = Dataset.Tables["TABLE"].Rows[Idx]["GE_CODEGENRE"].ToString();
					clsCtcontrat.TVH_CODETYPE = Dataset.Tables["TABLE"].Rows[Idx]["TVH_CODETYPE"].ToString();
					clsCtcontrat.EN_CODEENERGIE = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENERGIE"].ToString();
					clsCtcontrat.CA_TAUX = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_TAUX"].ToString());
					clsCtcontrat.CA_TYPE = Dataset.Tables["TABLE"].Rows[Idx]["CA_TYPE"].ToString();
					clsCtcontrat.CA_NUMSERIE = Dataset.Tables["TABLE"].Rows[Idx]["CA_NUMSERIE"].ToString();
					clsCtcontrat.CA_IMMATRICULATION = Dataset.Tables["TABLE"].Rows[Idx]["CA_IMMATRICULATION"].ToString();
					clsCtcontrat.CA_PUISSANCEADMISE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_PUISSANCEADMISE"].ToString());
					clsCtcontrat.CA_CHARGEUTILE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_CHARGEUTILE"].ToString());
					clsCtcontrat.CA_NBREPLACE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_NBREPLACE"].ToString());
					clsCtcontrat.CA_VALNEUVE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_VALNEUVE"].ToString());
					clsCtcontrat.CA_VALVENALE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_VALVENALE"].ToString());
					clsCtcontrat.CA_DATEMISECIRCULATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATEMISECIRCULATION"].ToString());
					clsCtcontrat.CA_CLIENTEXONERETAXE = Dataset.Tables["TABLE"].Rows[Idx]["CA_CLIENTEXONERETAXE"].ToString();
					clsCtcontrat.TI_IDTIERSCOMMERCIAL = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSCOMMERCIAL"].ToString();
					clsCtcontrat.TI_IDTIERSASSUREUR = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSASSUREUR"].ToString();
					clsCtcontrat.CA_DATETRANSMISSIONAASSUREUR = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATETRANSMISSIONAASSUREUR"].ToString());
					clsCtcontrat.CA_DATEVALIDATIONASSUREUR = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATEVALIDATIONASSUREUR"].ToString());
					
					clsCtcontrat.CA_DATESUSPENSION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATESUSPENSION"].ToString());
					clsCtcontrat.CA_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATECLOTURE"].ToString());
					clsCtcontrat.CA_DATERESILIATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CA_DATERESILIATION"].ToString());
					clsCtcontrat.CA_NOMINTERLOCUTEUR = Dataset.Tables["TABLE"].Rows[Idx]["CA_NOMINTERLOCUTEUR"].ToString();
					clsCtcontrat.CA_CONTACTINTERLOCUTEUR = Dataset.Tables["TABLE"].Rows[Idx]["CA_CONTACTINTERLOCUTEUR"].ToString();
					clsCtcontrat.DI_CODEDESIGNATION = Dataset.Tables["TABLE"].Rows[Idx]["DI_CODEDESIGNATION"].ToString();
					clsCtcontrat.TA_CODETYPECONTRATSANTE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPECONTRATSANTE"].ToString();
					clsCtcontrat.CA_CODECONTRATSECONDAIRE =Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRATSECONDAIRE"].ToString();
					clsCtcontrat.CO_CODECOMMUNE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMMUNE"].ToString();
					clsCtcontrat.RQ_CODERISQUE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODERISQUE"].ToString();
					clsCtcontrats.Add(clsCtcontrat);
				}
				Dataset.Dispose();
			}
		return clsCtcontrats;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CA_CODECONTRAT", "@CA_NUMPOLICE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TI_NUMTIERSCOMMERCIAL", "@TI_DENOMINATIONCOMMERCIAL", "@MS_DATEPIECEDEBUT" , "@MS_DATEPIECEFIN" , "@RQ_CODERISQUE", "@EX_EXERCICE", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] , vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11], vppCritere[12], vppCritere[13] };
            this.vapRequete = "EXEC  [dbo].[PS_CTCONTRAT] @AG_CODEAGENCE,@EN_CODEENTREPOT,@CA_CODECONTRAT,@CA_NUMPOLICE,@TI_NUMTIERS,@TI_DENOMINATION ,@TI_NUMTIERSCOMMERCIAL,@TI_DENOMINATIONCOMMERCIAL,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN ,@RQ_CODERISQUE ,@EX_EXERCICE , @OP_CODEOPERATEUREDITION,	@TYPEOPERATION,@CODECRYPTAGE ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
    
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMontantFacture(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CA_CODECONTRAT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            this.vapRequete = "EXEC  [dbo].[PS_CTCONTRATMONTANTFACTURE] @AG_CODEAGENCE,@CA_CODECONTRAT,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }



		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF,  AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CA_CODECONTRAT , EN_CODEENTREPOT FROM dbo.FT_CTCONTRAT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF,  AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPARID(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereMV(clsDonnee, vppCritere);
            this.vapRequete = "SELECT CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',CA_NUMPOLICE) AS varchar(150)) AS CA_NUMPOLICE  FROM dbo.VUE_PHAMOUVEMENTSTOCKCONTRAT " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE)</summary>
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
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CA_CODECONTRAT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND CA_CODECONTRAT=@CA_CODECONTRAT AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CA_CODECONTRAT","@IT_CODEINTERMEDIAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
				case 7 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
				break;
				case 8 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7]};
				break;
				case 9 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF ";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8]};
				break;
				case 10 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF  AND AU_CODECATEGORIE=@AU_CODECATEGORIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9]};
				break;
				case 11 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF AND  AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE","@TA_CODETARIF"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10]};
				break;
				case 12 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF AND AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF AND US_CODEUSAGE=@US_CODEUSAGE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE","@TA_CODETARIF","@US_CODEUSAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11]};
				break;
				case 13 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF  AND AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF AND US_CODEUSAGE=@US_CODEUSAGE AND GE_CODEGENRE=@GE_CODEGENRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE","@TA_CODETARIF","@US_CODEUSAGE","@GE_CODEGENRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11],vppCritere[12]};
				break;
				case 14 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF  AND AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF AND US_CODEUSAGE=@US_CODEUSAGE AND GE_CODEGENRE=@GE_CODEGENRE AND EN_CODEENERGIE=@EN_CODEENERGIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE","@TA_CODETARIF","@US_CODEUSAGE","@GE_CODEGENRE","@EN_CODEENERGIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11],vppCritere[12],vppCritere[13]};
				break;
				case 15 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF AND AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF AND US_CODEUSAGE=@US_CODEUSAGE AND GE_CODEGENRE=@GE_CODEGENRE AND EN_CODEENERGIE=@EN_CODEENERGIE AND DI_CODEDESIGNATION=@DI_CODEDESIGNATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE","@TA_CODETARIF","@US_CODEUSAGE","@GE_CODEGENRE","@EN_CODEENERGIE","@DI_CODEDESIGNATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11],vppCritere[12],vppCritere[13],vppCritere[14]};
				break;
				case 16 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF  AND AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF AND US_CODEUSAGE=@US_CODEUSAGE AND GE_CODEGENRE=@GE_CODEGENRE AND EN_CODEENERGIE=@EN_CODEENERGIE AND DI_CODEDESIGNATION=@DI_CODEDESIGNATION AND CA_CODECONTRATSECONDAIRE=@CA_CODECONTRATSECONDAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE","@TA_CODETARIF","@US_CODEUSAGE","@GE_CODEGENRE","@EN_CODEENERGIE","@DI_CODEDESIGNATION","@CA_CODECONTRATSECONDAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11],vppCritere[12],vppCritere[13],vppCritere[14],vppCritere[15]};
				break;
				case 17 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF AND AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF AND US_CODEUSAGE=@US_CODEUSAGE AND GE_CODEGENRE=@GE_CODEGENRE AND EN_CODEENERGIE=@EN_CODEENERGIE AND DI_CODEDESIGNATION=@DI_CODEDESIGNATION AND CA_CODECONTRATSECONDAIRE=@CA_CODECONTRATSECONDAIRE AND CO_CODECOMMUNE=@CO_CODECOMMUNE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE","@TA_CODETARIF","@US_CODEUSAGE","@GE_CODEGENRE","@EN_CODEENERGIE","@DI_CODEDESIGNATION","@CA_CODECONTRATSECONDAIRE","@CO_CODECOMMUNE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11],vppCritere[12],vppCritere[13],vppCritere[14],vppCritere[15],vppCritere[16]};
				break;
				case 18 :
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND AG_CODEAGENCE=@AG_CODEAGENCE AND IT_CODEINTERMEDIAIRE=@IT_CODEINTERMEDIAIRE AND AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT AND OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT AND CB_IDBRANCHE=@CB_IDBRANCHE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF  AND AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF AND US_CODEUSAGE=@US_CODEUSAGE AND GE_CODEGENRE=@GE_CODEGENRE AND EN_CODEENERGIE=@EN_CODEENERGIE AND DI_CODEDESIGNATION=@DI_CODEDESIGNATION AND CA_CODECONTRATSECONDAIRE=@CA_CODECONTRATSECONDAIRE AND CO_CODECOMMUNE=@CO_CODECOMMUNE AND RQ_CODERISQUE=@RQ_CODERISQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT","@AG_CODEAGENCE","@IT_CODEINTERMEDIAIRE","@AP_CODETYPEAPPARTEMENT","@OC_CODETYPEOCCUPANT","@CB_IDBRANCHE","@OP_CODEOPERATEUR","@ST_CODESTATUTSOCIOPROF","@AU_CODECATEGORIE","@TA_CODETARIF","@US_CODEUSAGE","@GE_CODEGENRE","@EN_CODEENERGIE","@DI_CODEDESIGNATION","@CA_CODECONTRATSECONDAIRE","@CO_CODECOMMUNE","@RQ_CODERISQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11],vppCritere[12],vppCritere[13],vppCritere[14],vppCritere[15],vppCritere[16],vppCritere[17]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereMV(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
               
            }
        }

    }
}
