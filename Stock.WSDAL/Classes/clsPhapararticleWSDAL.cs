using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapararticleWSDAL: ITableDAL<clsPhapararticle>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        public string pvgStockActuel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CODEARTICLE", "@DATE", "@EN_CODEENTREPOT", "@MF_IDFILTRAGEDESTOCK", "@ME_IDFILTRAGEDESTOCKEXPIRATION", "@MF_IDFILTRAGEDESTOCKM1", "@MF_IDFILTRAGEDESTOCKM2" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4] , vppCritere[5], vppCritere[6] , vppCritere[7] };

            this.vapRequete = "SELECT [dbo].FC_STOCKACTUEL(@AG_CODEAGENCE, @CODEARTICLE, @DATE, @EN_CODEENTREPOT, @MF_IDFILTRAGEDESTOCK, @ME_IDFILTRAGEDESTOCKEXPIRATION, @MF_IDFILTRAGEDESTOCKM1, @MF_IDFILTRAGEDESTOCKM2) ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        public string pvgValueScalarRequeteCountCodeBarre(clsDonnee clsDonnee,params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AR_CODEBARRE"};
            vapValeurParametre = new object[] { vppCritere[0] };

            this.vapRequete = "SELECT COUNT(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARARTICLE  WHERE AR_CODEBARRE = @AR_CODEBARRE  AND RTRIM(AR_CODEBARRE) <>''";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }
        /// <summary>
        /// CETTE FONCTION PERMET DE VERIFIER L'UNICITE DU CODE CIP
        /// </summary>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValueScalarRequeteCountCodeCIP(clsDonnee clsDonnee,params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AR_CODECIP" };
            vapValeurParametre = new object[] { vppCritere[0] };

            this.vapRequete = "SELECT COUNT(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARARTICLE  WHERE AR_CODECIP = @AR_CODECIP  AND RTRIM(AR_CODECIP) <>''";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }



		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapararticle comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapararticle pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE, AR_CODECIP  , AR_CODEBARRE  , RY_CODERAYON  , FO_CODEFORME  , TB_CODETABLEAU  , TA_CODETYPEARTICLE  , FA_CODEFABRICANT  , MO_CODEMODEL  , MA_CODEMARQUE  , DA_CODEDESTINATION  , UN_CODEUNITE  , AR_NOMCOMMERCIALE  , AR_NOMSCIENTIFIQUE  , AR_DESCRIPTION  , AR_CONDITIONNEMENT  , AR_CONTENANCE  , AR_SEUILMINI  , AR_SEUILMAXI  , AR_RATTACHE  , AR_STATUT  , AR_ASDI  , AR_TVA  , AR_DUREEGARANTIE  , AR_DATECLOTURE  , AR_REPORTSORTIE  , AR_REPORTENTREE  , AR_NOMBREPERIODEPRECEDENTSORTIE  , AR_NOMBREPERIODEPRECEDENTENTREE  , AR_NOMBREPERIODESORTIEENCOURS  , AR_NOMBREPERIODEENTREEENCOURS  , AR_NOMBRESTOCKFINALSORTIE  , AR_NOMBRESTOCKFINALENTREE  , AR_QUANTIFIABLE  FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapararticle clsPhapararticle = new clsPhapararticle();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    clsPhapararticle.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_CODECIP = clsDonnee.vogDataReader["AR_CODECIP"].ToString();
                    clsPhapararticle.AR_CODEBARRE = clsDonnee.vogDataReader["AR_CODEBARRE"].ToString();
                    clsPhapararticle.RY_CODERAYON = clsDonnee.vogDataReader["RY_CODERAYON"].ToString();
                    clsPhapararticle.FO_CODEFORME = clsDonnee.vogDataReader["FO_CODEFORME"].ToString();
                    clsPhapararticle.TB_CODETABLEAU = clsDonnee.vogDataReader["TB_CODETABLEAU"].ToString();
                    clsPhapararticle.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
                    clsPhapararticle.FA_CODEFABRICANT = clsDonnee.vogDataReader["FA_CODEFABRICANT"].ToString();
                    clsPhapararticle.MO_CODEMODEL = clsDonnee.vogDataReader["MO_CODEMODEL"].ToString();
                    clsPhapararticle.MA_CODEMARQUE = clsDonnee.vogDataReader["MA_CODEMARQUE"].ToString();
                    clsPhapararticle.DA_CODEDESTINATION = clsDonnee.vogDataReader["DA_CODEDESTINATION"].ToString();
                    clsPhapararticle.UN_CODEUNITE = clsDonnee.vogDataReader["UN_CODEUNITE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = clsDonnee.vogDataReader["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.AR_NOMSCIENTIFIQUE = clsDonnee.vogDataReader["AR_NOMSCIENTIFIQUE"].ToString();
                    clsPhapararticle.AR_DESCRIPTION = clsDonnee.vogDataReader["AR_DESCRIPTION"].ToString();
                    clsPhapararticle.AR_CONDITIONNEMENT = clsDonnee.vogDataReader["AR_CONDITIONNEMENT"].ToString();
                    clsPhapararticle.AR_CONTENANCE = double.Parse(clsDonnee.vogDataReader["AR_CONTENANCE"].ToString());
                    clsPhapararticle.AR_SEUILMINI = int.Parse(clsDonnee.vogDataReader["AR_SEUILMINI"].ToString());
                    clsPhapararticle.AR_SEUILMAXI = int.Parse(clsDonnee.vogDataReader["AR_SEUILMAXI"].ToString());
                    clsPhapararticle.AR_RATTACHE = clsDonnee.vogDataReader["AR_RATTACHE"].ToString();
                    clsPhapararticle.AR_STATUT = clsDonnee.vogDataReader["AR_STATUT"].ToString();
                    clsPhapararticle.AR_ASDI = clsDonnee.vogDataReader["AR_ASDI"].ToString();
                    clsPhapararticle.AR_TVA = clsDonnee.vogDataReader["AR_TVA"].ToString();
                    clsPhapararticle.AR_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AR_DATECLOTURE"].ToString());
                    clsPhapararticle.AR_DUREEGARANTIE = int.Parse(clsDonnee.vogDataReader["AR_DUREEGARANTIE"].ToString());
                }
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapararticle;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapararticle comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapararticle pvgTableLabelSelonLeRisque(clsDonnee clsDonnee, params string[] vppCritere)
		{
            this.vapCritere = "WHERE RQ_CODERISQUE=@RQ_CODERISQUE ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODERISQUE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };

            this.vapRequete = "SELECT AR_CODEARTICLE, AR_CODECIP  , AR_CODEBARRE  , RY_CODERAYON  , FO_CODEFORME  , TB_CODETABLEAU  , TA_CODETYPEARTICLE  , FA_CODEFABRICANT  , MO_CODEMODEL  , MA_CODEMARQUE  , DA_CODEDESTINATION  , UN_CODEUNITE  , AR_NOMCOMMERCIALE  , AR_NOMSCIENTIFIQUE  , AR_DESCRIPTION  , AR_CONDITIONNEMENT  , AR_CONTENANCE  , AR_SEUILMINI  , AR_SEUILMAXI  , AR_RATTACHE  , AR_STATUT  , AR_ASDI  , AR_TVA  , AR_DUREEGARANTIE  , AR_DATECLOTURE  , AR_REPORTSORTIE  , AR_REPORTENTREE  , AR_NOMBREPERIODEPRECEDENTSORTIE  , AR_NOMBREPERIODEPRECEDENTENTREE  , AR_NOMBREPERIODESORTIEENCOURS  , AR_NOMBREPERIODEENTREEENCOURS  , AR_NOMBRESTOCKFINALSORTIE  , AR_NOMBRESTOCKFINALENTREE  , AR_QUANTIFIABLE  FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapararticle clsPhapararticle = new clsPhapararticle();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    clsPhapararticle.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_CODECIP = clsDonnee.vogDataReader["AR_CODECIP"].ToString();
                    clsPhapararticle.AR_CODEBARRE = clsDonnee.vogDataReader["AR_CODEBARRE"].ToString();
                    clsPhapararticle.RY_CODERAYON = clsDonnee.vogDataReader["RY_CODERAYON"].ToString();
                    clsPhapararticle.FO_CODEFORME = clsDonnee.vogDataReader["FO_CODEFORME"].ToString();
                    clsPhapararticle.TB_CODETABLEAU = clsDonnee.vogDataReader["TB_CODETABLEAU"].ToString();
                    clsPhapararticle.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
                    clsPhapararticle.FA_CODEFABRICANT = clsDonnee.vogDataReader["FA_CODEFABRICANT"].ToString();
                    clsPhapararticle.MO_CODEMODEL = clsDonnee.vogDataReader["MO_CODEMODEL"].ToString();
                    clsPhapararticle.MA_CODEMARQUE = clsDonnee.vogDataReader["MA_CODEMARQUE"].ToString();
                    clsPhapararticle.DA_CODEDESTINATION = clsDonnee.vogDataReader["DA_CODEDESTINATION"].ToString();
                    clsPhapararticle.UN_CODEUNITE = clsDonnee.vogDataReader["UN_CODEUNITE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = clsDonnee.vogDataReader["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.AR_NOMSCIENTIFIQUE = clsDonnee.vogDataReader["AR_NOMSCIENTIFIQUE"].ToString();
                    clsPhapararticle.AR_DESCRIPTION = clsDonnee.vogDataReader["AR_DESCRIPTION"].ToString();
                    clsPhapararticle.AR_CONDITIONNEMENT = clsDonnee.vogDataReader["AR_CONDITIONNEMENT"].ToString();
                    clsPhapararticle.AR_CONTENANCE = double.Parse(clsDonnee.vogDataReader["AR_CONTENANCE"].ToString());
                    clsPhapararticle.AR_SEUILMINI = int.Parse(clsDonnee.vogDataReader["AR_SEUILMINI"].ToString());
                    clsPhapararticle.AR_SEUILMAXI = int.Parse(clsDonnee.vogDataReader["AR_SEUILMAXI"].ToString());
                    clsPhapararticle.AR_RATTACHE = clsDonnee.vogDataReader["AR_RATTACHE"].ToString();
                    clsPhapararticle.AR_STATUT = clsDonnee.vogDataReader["AR_STATUT"].ToString();
                    clsPhapararticle.AR_ASDI = clsDonnee.vogDataReader["AR_ASDI"].ToString();
                    clsPhapararticle.AR_TVA = clsDonnee.vogDataReader["AR_TVA"].ToString();
                    clsPhapararticle.AR_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AR_DATECLOTURE"].ToString());
                    clsPhapararticle.AR_DUREEGARANTIE = int.Parse(clsDonnee.vogDataReader["AR_DUREEGARANTIE"].ToString());
                }
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapararticle;
		}





        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPhapararticle comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPhapararticle pvgTableLabel1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE, AR_CODECIP  , AR_CODEBARRE  , RY_CODERAYON  , FO_CODEFORME  , TB_CODETABLEAU  , TA_CODETYPEARTICLE  , FA_CODEFABRICANT  , MO_CODEMODEL  , MA_CODEMARQUE  , DA_CODEDESTINATION  , UN_CODEUNITE  , AR_NOMCOMMERCIALE  , AR_NOMSCIENTIFIQUE  , AR_DESCRIPTION  , AR_CONDITIONNEMENT  , AR_CONTENANCE  , AR_SEUILMINI  , AR_SEUILMAXI  , AR_RATTACHE  , AR_STATUT  , AR_ASDI  , AR_TVA  , AR_DUREEGARANTIE  , AR_DATECLOTURE  , AR_REPORTSORTIE  , AR_REPORTENTREE  , AR_NOMBREPERIODEPRECEDENTSORTIE  , AR_NOMBREPERIODEPRECEDENTENTREE  , AR_NOMBREPERIODESORTIEENCOURS  , AR_NOMBREPERIODEENTREEENCOURS  , AR_NOMBRESTOCKFINALSORTIE  , AR_NOMBRESTOCKFINALENTREE  , AR_QUANTIFIABLE  FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsPhapararticle clsPhapararticle = new clsPhapararticle();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPhapararticle.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_CODECIP = clsDonnee.vogDataReader["AR_CODECIP"].ToString();
                    clsPhapararticle.AR_CODEBARRE = clsDonnee.vogDataReader["AR_CODEBARRE"].ToString();
                    clsPhapararticle.RY_CODERAYON = clsDonnee.vogDataReader["RY_CODERAYON"].ToString();
                    clsPhapararticle.FO_CODEFORME = clsDonnee.vogDataReader["FO_CODEFORME"].ToString();
                    clsPhapararticle.TB_CODETABLEAU = clsDonnee.vogDataReader["TB_CODETABLEAU"].ToString();
                    clsPhapararticle.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
                    clsPhapararticle.FA_CODEFABRICANT = clsDonnee.vogDataReader["FA_CODEFABRICANT"].ToString();
                    clsPhapararticle.MO_CODEMODEL = clsDonnee.vogDataReader["MO_CODEMODEL"].ToString();
                    clsPhapararticle.MA_CODEMARQUE = clsDonnee.vogDataReader["MA_CODEMARQUE"].ToString();
                    clsPhapararticle.DA_CODEDESTINATION = clsDonnee.vogDataReader["DA_CODEDESTINATION"].ToString();
                    clsPhapararticle.UN_CODEUNITE = clsDonnee.vogDataReader["UN_CODEUNITE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = clsDonnee.vogDataReader["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.AR_NOMSCIENTIFIQUE = clsDonnee.vogDataReader["AR_NOMSCIENTIFIQUE"].ToString();
                    clsPhapararticle.AR_DESCRIPTION = clsDonnee.vogDataReader["AR_DESCRIPTION"].ToString();
                    clsPhapararticle.AR_CONDITIONNEMENT = clsDonnee.vogDataReader["AR_CONDITIONNEMENT"].ToString();
                    clsPhapararticle.AR_CONTENANCE = double.Parse(clsDonnee.vogDataReader["AR_CONTENANCE"].ToString());
                    clsPhapararticle.AR_SEUILMINI = int.Parse(clsDonnee.vogDataReader["AR_SEUILMINI"].ToString());
                    clsPhapararticle.AR_SEUILMAXI = int.Parse(clsDonnee.vogDataReader["AR_SEUILMAXI"].ToString());
                    clsPhapararticle.AR_RATTACHE = clsDonnee.vogDataReader["AR_RATTACHE"].ToString();
                    clsPhapararticle.AR_STATUT = clsDonnee.vogDataReader["AR_STATUT"].ToString();
                    clsPhapararticle.AR_ASDI = clsDonnee.vogDataReader["AR_ASDI"].ToString();
                    clsPhapararticle.AR_TVA = clsDonnee.vogDataReader["AR_TVA"].ToString();
                    clsPhapararticle.AR_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AR_DATECLOTURE"].ToString());
                    clsPhapararticle.AR_DUREEGARANTIE = int.Parse(clsDonnee.vogDataReader["AR_DUREEGARANTIE"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPhapararticle;
        }



		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapararticle>clsPhapararticle</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapararticle clsPhapararticle)
		{
			//Préparation des paramètres
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhapararticle.AR_CODEARTICLE ;

			SqlParameter vppParamAR_CODECIP = new SqlParameter("@AR_CODECIP", SqlDbType.VarChar, 10);
			vppParamAR_CODECIP.Value  = clsPhapararticle.AR_CODECIP ;

			SqlParameter vppParamAR_CODEBARRE = new SqlParameter("@AR_CODEBARRE", SqlDbType.VarChar, 13);
			vppParamAR_CODEBARRE.Value  = clsPhapararticle.AR_CODEBARRE ;

			SqlParameter vppParamRY_CODERAYON = new SqlParameter("@RY_CODERAYON", SqlDbType.VarChar, 3);
			vppParamRY_CODERAYON.Value  = clsPhapararticle.RY_CODERAYON ;
            if (clsPhapararticle.RY_CODERAYON == "") vppParamRY_CODERAYON.Value = DBNull.Value;

			SqlParameter vppParamFO_CODEFORME = new SqlParameter("@FO_CODEFORME", SqlDbType.VarChar, 3);
			vppParamFO_CODEFORME.Value  = clsPhapararticle.FO_CODEFORME ;
            if (clsPhapararticle.FO_CODEFORME == "") vppParamFO_CODEFORME.Value = DBNull.Value;

			SqlParameter vppParamTB_CODETABLEAU = new SqlParameter("@TB_CODETABLEAU", SqlDbType.VarChar, 3);
			vppParamTB_CODETABLEAU.Value  = clsPhapararticle.TB_CODETABLEAU ;
            if (clsPhapararticle.TB_CODETABLEAU == "") vppParamTB_CODETABLEAU.Value = DBNull.Value;

			SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 3);
			vppParamTA_CODETYPEARTICLE.Value  = clsPhapararticle.TA_CODETYPEARTICLE ;
            if (clsPhapararticle.TA_CODETYPEARTICLE == "") vppParamTA_CODETYPEARTICLE.Value = DBNull.Value;

			SqlParameter vppParamFA_CODEFABRICANT = new SqlParameter("@FA_CODEFABRICANT", SqlDbType.VarChar, 6);
			vppParamFA_CODEFABRICANT.Value  = clsPhapararticle.FA_CODEFABRICANT ;
            if (clsPhapararticle.FA_CODEFABRICANT == "") vppParamFA_CODEFABRICANT.Value = DBNull.Value;

			SqlParameter vppParamMO_CODEMODEL = new SqlParameter("@MO_CODEMODEL", SqlDbType.VarChar, 3);
			vppParamMO_CODEMODEL.Value  = clsPhapararticle.MO_CODEMODEL ;
            if (clsPhapararticle.MO_CODEMODEL == "") vppParamMO_CODEMODEL.Value = DBNull.Value;

			SqlParameter vppParamMA_CODEMARQUE = new SqlParameter("@MA_CODEMARQUE", SqlDbType.VarChar, 3);
			vppParamMA_CODEMARQUE.Value  = clsPhapararticle.MA_CODEMARQUE ;
            if (clsPhapararticle.MA_CODEMARQUE == "") vppParamMA_CODEMARQUE.Value = DBNull.Value;

			SqlParameter vppParamDA_CODEDESTINATION = new SqlParameter("@DA_CODEDESTINATION", SqlDbType.VarChar, 3);
			vppParamDA_CODEDESTINATION.Value  = clsPhapararticle.DA_CODEDESTINATION ;
            if (clsPhapararticle.DA_CODEDESTINATION == "") vppParamDA_CODEDESTINATION.Value = DBNull.Value;

			SqlParameter vppParamUN_CODEUNITE = new SqlParameter("@UN_CODEUNITE", SqlDbType.VarChar, 3);
			vppParamUN_CODEUNITE.Value  = clsPhapararticle.UN_CODEUNITE ;
            if (clsPhapararticle.UN_CODEUNITE == "") vppParamUN_CODEUNITE.Value = DBNull.Value;

			SqlParameter vppParamAR_NOMCOMMERCIALE = new SqlParameter("@AR_NOMCOMMERCIALE", SqlDbType.VarChar, 150);
			vppParamAR_NOMCOMMERCIALE.Value  = clsPhapararticle.AR_NOMCOMMERCIALE ;

			SqlParameter vppParamAR_NOMSCIENTIFIQUE = new SqlParameter("@AR_NOMSCIENTIFIQUE", SqlDbType.VarChar, 150);
			vppParamAR_NOMSCIENTIFIQUE.Value  = clsPhapararticle.AR_NOMSCIENTIFIQUE ;

			SqlParameter vppParamAR_DESCRIPTION = new SqlParameter("@AR_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamAR_DESCRIPTION.Value  = clsPhapararticle.AR_DESCRIPTION ;

			SqlParameter vppParamAR_CONDITIONNEMENT = new SqlParameter("@AR_CONDITIONNEMENT", SqlDbType.VarChar, 150);
			vppParamAR_CONDITIONNEMENT.Value  = clsPhapararticle.AR_CONDITIONNEMENT ;

			SqlParameter vppParamAR_CONTENANCE = new SqlParameter("@AR_CONTENANCE", SqlDbType.Decimal, 4);
			vppParamAR_CONTENANCE.Value  = clsPhapararticle.AR_CONTENANCE ;

			SqlParameter vppParamAR_SEUILMINI = new SqlParameter("@AR_SEUILMINI", SqlDbType.BigInt);
			vppParamAR_SEUILMINI.Value  = clsPhapararticle.AR_SEUILMINI ;

			SqlParameter vppParamAR_SEUILMAXI = new SqlParameter("@AR_SEUILMAXI", SqlDbType.BigInt);
			vppParamAR_SEUILMAXI.Value  = clsPhapararticle.AR_SEUILMAXI ;

			SqlParameter vppParamAR_RATTACHE = new SqlParameter("@AR_RATTACHE", SqlDbType.VarChar, 7);
            vppParamAR_RATTACHE.Value = clsPhapararticle.AR_RATTACHE;
            if(clsPhapararticle.AR_RATTACHE=="") vppParamAR_RATTACHE.Value = DBNull.Value ;

			SqlParameter vppParamAR_STATUT = new SqlParameter("@AR_STATUT", SqlDbType.VarChar, 2);
			vppParamAR_STATUT.Value  = clsPhapararticle.AR_STATUT ;

			SqlParameter vppParamAR_ASDI = new SqlParameter("@AR_ASDI", SqlDbType.VarChar, 1);
			vppParamAR_ASDI.Value  = clsPhapararticle.AR_ASDI ;

			SqlParameter vppParamAR_TVA = new SqlParameter("@AR_TVA", SqlDbType.VarChar, 1);
			vppParamAR_TVA.Value  = clsPhapararticle.AR_TVA ;

			SqlParameter vppParamAR_DUREEGARANTIE = new SqlParameter("@AR_DUREEGARANTIE", SqlDbType.Int);
			vppParamAR_DUREEGARANTIE.Value  = clsPhapararticle.AR_DUREEGARANTIE ;

			SqlParameter vppParamAR_DATECLOTURE = new SqlParameter("@AR_DATECLOTURE", SqlDbType.DateTime);
			vppParamAR_DATECLOTURE.Value  = clsPhapararticle.AR_DATECLOTURE ;
            if (clsPhapararticle.AR_DATECLOTURE.ToShortDateString() == "01/01/0001") vppParamAR_DATECLOTURE.Value = DateTime.Parse("01/01/1900"); 

			SqlParameter vppParamAR_REPORTSORTIE = new SqlParameter("@AR_REPORTSORTIE", SqlDbType.Money);
			vppParamAR_REPORTSORTIE.Value  = clsPhapararticle.AR_REPORTSORTIE ;

			SqlParameter vppParamAR_REPORTENTREE = new SqlParameter("@AR_REPORTENTREE", SqlDbType.Money);
			vppParamAR_REPORTENTREE.Value  = clsPhapararticle.AR_REPORTENTREE ;

			SqlParameter vppParamAR_NOMBREPERIODEPRECEDENTSORTIE = new SqlParameter("@AR_NOMBREPERIODEPRECEDENTSORTIE", SqlDbType.Money);
			vppParamAR_NOMBREPERIODEPRECEDENTSORTIE.Value  = clsPhapararticle.AR_NOMBREPERIODEPRECEDENTSORTIE ;

			SqlParameter vppParamAR_NOMBREPERIODEPRECEDENTENTREE = new SqlParameter("@AR_NOMBREPERIODEPRECEDENTENTREE", SqlDbType.Money);
			vppParamAR_NOMBREPERIODEPRECEDENTENTREE.Value  = clsPhapararticle.AR_NOMBREPERIODEPRECEDENTENTREE ;

			SqlParameter vppParamAR_NOMBREPERIODESORTIEENCOURS = new SqlParameter("@AR_NOMBREPERIODESORTIEENCOURS", SqlDbType.Money);
			vppParamAR_NOMBREPERIODESORTIEENCOURS.Value  = clsPhapararticle.AR_NOMBREPERIODESORTIEENCOURS ;

			SqlParameter vppParamAR_NOMBREPERIODEENTREEENCOURS = new SqlParameter("@AR_NOMBREPERIODEENTREEENCOURS", SqlDbType.Money);
			vppParamAR_NOMBREPERIODEENTREEENCOURS.Value  = clsPhapararticle.AR_NOMBREPERIODEENTREEENCOURS ;

			SqlParameter vppParamAR_NOMBRESTOCKFINALSORTIE = new SqlParameter("@AR_NOMBRESTOCKFINALSORTIE", SqlDbType.Money);
			vppParamAR_NOMBRESTOCKFINALSORTIE.Value  = clsPhapararticle.AR_NOMBRESTOCKFINALSORTIE ;

			SqlParameter vppParamAR_NOMBRESTOCKFINALENTREE = new SqlParameter("@AR_NOMBRESTOCKFINALENTREE", SqlDbType.Money);
			vppParamAR_NOMBRESTOCKFINALENTREE.Value  = clsPhapararticle.AR_NOMBRESTOCKFINALENTREE ;

			SqlParameter vppParamAR_QUANTIFIABLE = new SqlParameter("@AR_QUANTIFIABLE", SqlDbType.VarChar, 1);
			vppParamAR_QUANTIFIABLE.Value  = clsPhapararticle.AR_QUANTIFIABLE ;
            SqlParameter vppParamAR_DATECREATION = new SqlParameter("@AR_DATECREATION", SqlDbType.DateTime);
            vppParamAR_DATECREATION.Value = clsPhapararticle.AR_DATECREATION;

            SqlParameter vppParamAR_NUMEROORDRE = new SqlParameter("@AR_NUMEROORDRE", SqlDbType.Int);
            vppParamAR_NUMEROORDRE.Value = clsPhapararticle.AR_NUMEROORDRE;

           

            SqlParameter vppParamIN_CODETYPEARTICLE = new SqlParameter("@IN_CODETYPEARTICLE", SqlDbType.VarChar, 3);
            vppParamIN_CODETYPEARTICLE.Value = clsPhapararticle.IN_CODETYPEARTICLE;
            if (clsPhapararticle.IN_CODETYPEARTICLE == "") vppParamIN_CODETYPEARTICLE.Value = DBNull.Value;



            SqlParameter vppParamPR_CODEPRESENTATION = new SqlParameter("@PR_CODEPRESENTATION", SqlDbType.VarChar, 3);
            vppParamPR_CODEPRESENTATION.Value = clsPhapararticle.PR_CODEPRESENTATION;
            if (clsPhapararticle.PR_CODEPRESENTATION == "") vppParamPR_CODEPRESENTATION.Value = DBNull.Value;

            SqlParameter vppParamAR_PAOBLIGATOIRE = new SqlParameter("@AR_PAOBLIGATOIRE", SqlDbType.VarChar, 1);
            vppParamAR_PAOBLIGATOIRE.Value = clsPhapararticle.AR_PAOBLIGATOIRE;


            SqlParameter vppParamAR_PVOBLIGATOIRE = new SqlParameter("@AR_PVOBLIGATOIRE", SqlDbType.VarChar, 1);
            vppParamAR_PVOBLIGATOIRE.Value = clsPhapararticle.AR_PVOBLIGATOIRE;

            SqlParameter vppParamIN_CODEINGREDIENT = new SqlParameter("@IN_CODEINGREDIENT", SqlDbType.VarChar, 3);
            vppParamIN_CODEINGREDIENT.Value = clsPhapararticle.IN_CODEINGREDIENT;
            if (clsPhapararticle.IN_CODEINGREDIENT == "") vppParamIN_CODEINGREDIENT.Value = DBNull.Value;

            SqlParameter vppParamAR_DATEPREMIEREMISEENSERVICE = new SqlParameter("@AR_DATEPREMIEREMISEENSERVICE", SqlDbType.DateTime);
            vppParamAR_DATEPREMIEREMISEENSERVICE.Value = clsPhapararticle.AR_DATEPREMIEREMISEENSERVICE;
            if (clsPhapararticle.AR_DATEPREMIEREMISEENSERVICE.ToShortDateString() == "01/01/0001") vppParamAR_DATEPREMIEREMISEENSERVICE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAR_COLLISAGE = new SqlParameter("@AR_COLLISAGE", SqlDbType.Int);
            vppParamAR_COLLISAGE.Value = clsPhapararticle.AR_COLLISAGE;

            SqlParameter vppParamAR_PERISSABLE = new SqlParameter("@AR_PERISSABLE", SqlDbType.VarChar, 1);
            vppParamAR_PERISSABLE.Value = clsPhapararticle.AR_PERISSABLE;

            SqlParameter vppParamAR_DUREEPEREMPTION = new SqlParameter("@AR_DUREEPEREMPTION", SqlDbType.Int);
            vppParamAR_DUREEPEREMPTION.Value = clsPhapararticle.AR_DUREEPEREMPTION;

            SqlParameter vppParamCF_CODECOEFICIENT = new SqlParameter("@CF_CODECOEFICIENT", SqlDbType.VarChar, 25);
            vppParamCF_CODECOEFICIENT.Value = clsPhapararticle.CF_CODECOEFICIENT;
            if (clsPhapararticle.CF_CODECOEFICIENT == "") vppParamCF_CODECOEFICIENT.Value = DBNull.Value;

            SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 25);
            vppParamRQ_CODERISQUE.Value = clsPhapararticle.RQ_CODERISQUE;
            if (clsPhapararticle.RQ_CODERISQUE == "") vppParamRQ_CODERISQUE.Value = DBNull.Value;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 2);
            vppParamTYPEOPERATION.Value = clsPhapararticle.TYPEOPERATION;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARARTICLE  @AR_CODEARTICLE, @AR_CODECIP, @AR_CODEBARRE, @RY_CODERAYON, @FO_CODEFORME, @TB_CODETABLEAU, @TA_CODETYPEARTICLE, @FA_CODEFABRICANT, @MO_CODEMODEL, @MA_CODEMARQUE, @DA_CODEDESTINATION, @UN_CODEUNITE, @AR_NOMCOMMERCIALE, @AR_NOMSCIENTIFIQUE, @AR_DESCRIPTION, @AR_CONDITIONNEMENT, @AR_CONTENANCE, @AR_SEUILMINI, @AR_SEUILMAXI, @AR_RATTACHE, @AR_STATUT, @AR_ASDI, @AR_TVA, @AR_DUREEGARANTIE, @AR_DATECLOTURE, @AR_REPORTSORTIE, @AR_REPORTENTREE, @AR_NOMBREPERIODEPRECEDENTSORTIE, @AR_NOMBREPERIODEPRECEDENTENTREE, @AR_NOMBREPERIODESORTIEENCOURS, @AR_NOMBREPERIODEENTREEENCOURS, @AR_NOMBRESTOCKFINALSORTIE, @AR_NOMBRESTOCKFINALENTREE, @AR_QUANTIFIABLE, @AR_DATECREATION,@AR_NUMEROORDRE, @IN_CODETYPEARTICLE,@PR_CODEPRESENTATION,@AR_PAOBLIGATOIRE,@AR_PVOBLIGATOIRE,@IN_CODEINGREDIENT,@AR_DATEPREMIEREMISEENSERVICE,@AR_COLLISAGE,@AR_PERISSABLE,@AR_DUREEPEREMPTION,@CF_CODECOEFICIENT,@RQ_CODERISQUE, @CODECRYPTAGE, @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODECIP);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEBARRE);
			vppSqlCmd.Parameters.Add(vppParamRY_CODERAYON);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFORME);
			vppSqlCmd.Parameters.Add(vppParamTB_CODETABLEAU);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamFA_CODEFABRICANT);
			vppSqlCmd.Parameters.Add(vppParamMO_CODEMODEL);
			vppSqlCmd.Parameters.Add(vppParamMA_CODEMARQUE);
			vppSqlCmd.Parameters.Add(vppParamDA_CODEDESTINATION);
			vppSqlCmd.Parameters.Add(vppParamUN_CODEUNITE);
			vppSqlCmd.Parameters.Add(vppParamAR_NOMCOMMERCIALE);
			vppSqlCmd.Parameters.Add(vppParamAR_NOMSCIENTIFIQUE);
			vppSqlCmd.Parameters.Add(vppParamAR_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamAR_CONDITIONNEMENT);
			vppSqlCmd.Parameters.Add(vppParamAR_CONTENANCE);
			vppSqlCmd.Parameters.Add(vppParamAR_SEUILMINI);
			vppSqlCmd.Parameters.Add(vppParamAR_SEUILMAXI);
			vppSqlCmd.Parameters.Add(vppParamAR_RATTACHE);
			vppSqlCmd.Parameters.Add(vppParamAR_STATUT);
			vppSqlCmd.Parameters.Add(vppParamAR_ASDI);
			vppSqlCmd.Parameters.Add(vppParamAR_TVA);
			vppSqlCmd.Parameters.Add(vppParamAR_DUREEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamAR_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamAR_REPORTSORTIE);
			vppSqlCmd.Parameters.Add(vppParamAR_REPORTENTREE);
			vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEPRECEDENTSORTIE);
			vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEPRECEDENTENTREE);
			vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODESORTIEENCOURS);
			vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEENTREEENCOURS);
			vppSqlCmd.Parameters.Add(vppParamAR_NOMBRESTOCKFINALSORTIE);
			vppSqlCmd.Parameters.Add(vppParamAR_NOMBRESTOCKFINALENTREE);
			vppSqlCmd.Parameters.Add(vppParamAR_QUANTIFIABLE);
            vppSqlCmd.Parameters.Add(vppParamAR_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamAR_NUMEROORDRE);
            vppSqlCmd.Parameters.Add(vppParamIN_CODETYPEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamPR_CODEPRESENTATION);
            vppSqlCmd.Parameters.Add(vppParamAR_PAOBLIGATOIRE);
            vppSqlCmd.Parameters.Add(vppParamAR_PVOBLIGATOIRE);
            vppSqlCmd.Parameters.Add(vppParamIN_CODEINGREDIENT);
            vppSqlCmd.Parameters.Add(vppParamAR_DATEPREMIEREMISEENSERVICE);
            vppSqlCmd.Parameters.Add(vppParamAR_COLLISAGE);
            vppSqlCmd.Parameters.Add(vppParamAR_PERISSABLE);
            vppSqlCmd.Parameters.Add(vppParamAR_DUREEPEREMPTION);
            vppSqlCmd.Parameters.Add(vppParamCF_CODECOEFICIENT);
            vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}



        /////<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        /////<param name=clsDonnee>Classe d'acces aux donnees</param>
        /////<param name=clsPhapararticle>clsPhapararticle</param>
        /////<author>Home Technology</author>
        //public string pvgMiseAJours(clsDonnee clsDonnee, clsPhapararticle clsPhapararticle)
        //{
        //    //Préparation des paramètres
        //    SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
        //    vppParamAR_CODEARTICLE.Value = clsPhapararticle.AR_CODEARTICLE;

        //    SqlParameter vppParamAR_CODECIP = new SqlParameter("@AR_CODECIP", SqlDbType.VarChar, 10);
        //    vppParamAR_CODECIP.Value = clsPhapararticle.AR_CODECIP;

        //    SqlParameter vppParamAR_CODEBARRE = new SqlParameter("@AR_CODEBARRE", SqlDbType.VarChar, 13);
        //    vppParamAR_CODEBARRE.Value = clsPhapararticle.AR_CODEBARRE;

        //    SqlParameter vppParamRY_CODERAYON = new SqlParameter("@RY_CODERAYON", SqlDbType.VarChar, 3);
        //    vppParamRY_CODERAYON.Value = clsPhapararticle.RY_CODERAYON;
        //    if (clsPhapararticle.RY_CODERAYON == "") vppParamRY_CODERAYON.Value = DBNull.Value;

        //    SqlParameter vppParamFO_CODEFORME = new SqlParameter("@FO_CODEFORME", SqlDbType.VarChar, 3);
        //    vppParamFO_CODEFORME.Value = clsPhapararticle.FO_CODEFORME;
        //    if (clsPhapararticle.FO_CODEFORME == "") vppParamFO_CODEFORME.Value = DBNull.Value;

        //    SqlParameter vppParamTB_CODETABLEAU = new SqlParameter("@TB_CODETABLEAU", SqlDbType.VarChar, 3);
        //    vppParamTB_CODETABLEAU.Value = clsPhapararticle.TB_CODETABLEAU;
        //    if (clsPhapararticle.TB_CODETABLEAU == "") vppParamTB_CODETABLEAU.Value = DBNull.Value;

        //    SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 3);
        //    vppParamTA_CODETYPEARTICLE.Value = clsPhapararticle.TA_CODETYPEARTICLE;
        //    if (clsPhapararticle.TA_CODETYPEARTICLE == "") vppParamTA_CODETYPEARTICLE.Value = DBNull.Value;

        //    SqlParameter vppParamFA_CODEFABRICANT = new SqlParameter("@FA_CODEFABRICANT", SqlDbType.VarChar, 6);
        //    vppParamFA_CODEFABRICANT.Value = clsPhapararticle.FA_CODEFABRICANT;
        //    if (clsPhapararticle.FA_CODEFABRICANT == "") vppParamFA_CODEFABRICANT.Value = DBNull.Value;

        //    SqlParameter vppParamMO_CODEMODEL = new SqlParameter("@MO_CODEMODEL", SqlDbType.VarChar, 3);
        //    vppParamMO_CODEMODEL.Value = clsPhapararticle.MO_CODEMODEL;
        //    if (clsPhapararticle.MO_CODEMODEL == "") vppParamMO_CODEMODEL.Value = DBNull.Value;

        //    SqlParameter vppParamMA_CODEMARQUE = new SqlParameter("@MA_CODEMARQUE", SqlDbType.VarChar, 3);
        //    vppParamMA_CODEMARQUE.Value = clsPhapararticle.MA_CODEMARQUE;
        //    if (clsPhapararticle.MA_CODEMARQUE == "") vppParamMA_CODEMARQUE.Value = DBNull.Value;

        //    SqlParameter vppParamDA_CODEDESTINATION = new SqlParameter("@DA_CODEDESTINATION", SqlDbType.VarChar, 3);
        //    vppParamDA_CODEDESTINATION.Value = clsPhapararticle.DA_CODEDESTINATION;
        //    if (clsPhapararticle.DA_CODEDESTINATION == "") vppParamDA_CODEDESTINATION.Value = DBNull.Value;

        //    SqlParameter vppParamUN_CODEUNITE = new SqlParameter("@UN_CODEUNITE", SqlDbType.VarChar, 3);
        //    vppParamUN_CODEUNITE.Value = clsPhapararticle.UN_CODEUNITE;
        //    if (clsPhapararticle.UN_CODEUNITE == "") vppParamUN_CODEUNITE.Value = DBNull.Value;

        //    SqlParameter vppParamAR_NOMCOMMERCIALE = new SqlParameter("@AR_NOMCOMMERCIALE", SqlDbType.VarChar, 150);
        //    vppParamAR_NOMCOMMERCIALE.Value = clsPhapararticle.AR_NOMCOMMERCIALE;

        //    SqlParameter vppParamAR_NOMSCIENTIFIQUE = new SqlParameter("@AR_NOMSCIENTIFIQUE", SqlDbType.VarChar, 150);
        //    vppParamAR_NOMSCIENTIFIQUE.Value = clsPhapararticle.AR_NOMSCIENTIFIQUE;

        //    SqlParameter vppParamAR_DESCRIPTION = new SqlParameter("@AR_DESCRIPTION", SqlDbType.VarChar, 150);
        //    vppParamAR_DESCRIPTION.Value = clsPhapararticle.AR_DESCRIPTION;

        //    SqlParameter vppParamAR_CONDITIONNEMENT = new SqlParameter("@AR_CONDITIONNEMENT", SqlDbType.VarChar, 150);
        //    vppParamAR_CONDITIONNEMENT.Value = clsPhapararticle.AR_CONDITIONNEMENT;

        //    SqlParameter vppParamAR_CONTENANCE = new SqlParameter("@AR_CONTENANCE", SqlDbType.Decimal, 4);
        //    vppParamAR_CONTENANCE.Value = clsPhapararticle.AR_CONTENANCE;

        //    SqlParameter vppParamAR_SEUILMINI = new SqlParameter("@AR_SEUILMINI", SqlDbType.BigInt);
        //    vppParamAR_SEUILMINI.Value = clsPhapararticle.AR_SEUILMINI;

        //    SqlParameter vppParamAR_SEUILMAXI = new SqlParameter("@AR_SEUILMAXI", SqlDbType.BigInt);
        //    vppParamAR_SEUILMAXI.Value = clsPhapararticle.AR_SEUILMAXI;

        //    SqlParameter vppParamAR_RATTACHE = new SqlParameter("@AR_RATTACHE", SqlDbType.VarChar, 7);
        //    vppParamAR_RATTACHE.Value = clsPhapararticle.AR_RATTACHE;
        //    if (clsPhapararticle.AR_RATTACHE == "") vppParamAR_RATTACHE.Value = DBNull.Value;

        //    SqlParameter vppParamAR_STATUT = new SqlParameter("@AR_STATUT", SqlDbType.VarChar, 2);
        //    vppParamAR_STATUT.Value = clsPhapararticle.AR_STATUT;

        //    SqlParameter vppParamAR_ASDI = new SqlParameter("@AR_ASDI", SqlDbType.VarChar, 1);
        //    vppParamAR_ASDI.Value = clsPhapararticle.AR_ASDI;

        //    SqlParameter vppParamAR_TVA = new SqlParameter("@AR_TVA", SqlDbType.VarChar, 1);
        //    vppParamAR_TVA.Value = clsPhapararticle.AR_TVA;

        //    SqlParameter vppParamAR_DUREEGARANTIE = new SqlParameter("@AR_DUREEGARANTIE", SqlDbType.Int);
        //    vppParamAR_DUREEGARANTIE.Value = clsPhapararticle.AR_DUREEGARANTIE;

        //    SqlParameter vppParamAR_DATECLOTURE = new SqlParameter("@AR_DATECLOTURE", SqlDbType.DateTime);
        //    vppParamAR_DATECLOTURE.Value = clsPhapararticle.AR_DATECLOTURE;
        //    if (clsPhapararticle.AR_DATECLOTURE.ToShortDateString() == "01/01/0001") vppParamAR_DATECLOTURE.Value = DateTime.Parse("01/01/1900");

        //    SqlParameter vppParamAR_REPORTSORTIE = new SqlParameter("@AR_REPORTSORTIE", SqlDbType.Money);
        //    vppParamAR_REPORTSORTIE.Value = clsPhapararticle.AR_REPORTSORTIE;

        //    SqlParameter vppParamAR_REPORTENTREE = new SqlParameter("@AR_REPORTENTREE", SqlDbType.Money);
        //    vppParamAR_REPORTENTREE.Value = clsPhapararticle.AR_REPORTENTREE;

        //    SqlParameter vppParamAR_NOMBREPERIODEPRECEDENTSORTIE = new SqlParameter("@AR_NOMBREPERIODEPRECEDENTSORTIE", SqlDbType.Money);
        //    vppParamAR_NOMBREPERIODEPRECEDENTSORTIE.Value = clsPhapararticle.AR_NOMBREPERIODEPRECEDENTSORTIE;

        //    SqlParameter vppParamAR_NOMBREPERIODEPRECEDENTENTREE = new SqlParameter("@AR_NOMBREPERIODEPRECEDENTENTREE", SqlDbType.Money);
        //    vppParamAR_NOMBREPERIODEPRECEDENTENTREE.Value = clsPhapararticle.AR_NOMBREPERIODEPRECEDENTENTREE;

        //    SqlParameter vppParamAR_NOMBREPERIODESORTIEENCOURS = new SqlParameter("@AR_NOMBREPERIODESORTIEENCOURS", SqlDbType.Money);
        //    vppParamAR_NOMBREPERIODESORTIEENCOURS.Value = clsPhapararticle.AR_NOMBREPERIODESORTIEENCOURS;

        //    SqlParameter vppParamAR_NOMBREPERIODEENTREEENCOURS = new SqlParameter("@AR_NOMBREPERIODEENTREEENCOURS", SqlDbType.Money);
        //    vppParamAR_NOMBREPERIODEENTREEENCOURS.Value = clsPhapararticle.AR_NOMBREPERIODEENTREEENCOURS;

        //    SqlParameter vppParamAR_NOMBRESTOCKFINALSORTIE = new SqlParameter("@AR_NOMBRESTOCKFINALSORTIE", SqlDbType.Money);
        //    vppParamAR_NOMBRESTOCKFINALSORTIE.Value = clsPhapararticle.AR_NOMBRESTOCKFINALSORTIE;

        //    SqlParameter vppParamAR_NOMBRESTOCKFINALENTREE = new SqlParameter("@AR_NOMBRESTOCKFINALENTREE", SqlDbType.Money);
        //    vppParamAR_NOMBRESTOCKFINALENTREE.Value = clsPhapararticle.AR_NOMBRESTOCKFINALENTREE;

        //    SqlParameter vppParamAR_QUANTIFIABLE = new SqlParameter("@AR_QUANTIFIABLE", SqlDbType.VarChar, 1);
        //    vppParamAR_QUANTIFIABLE.Value = clsPhapararticle.AR_QUANTIFIABLE;
        //    SqlParameter vppParamAR_DATECREATION = new SqlParameter("@AR_DATECREATION", SqlDbType.DateTime);
        //    vppParamAR_DATECREATION.Value = clsPhapararticle.AR_DATECREATION;

        //    SqlParameter vppParamAR_NUMEROORDRE = new SqlParameter("@AR_NUMEROORDRE", SqlDbType.Int);
        //    vppParamAR_NUMEROORDRE.Value = clsPhapararticle.AR_NUMEROORDRE;



        //    SqlParameter vppParamIN_CODETYPEARTICLE = new SqlParameter("@IN_CODETYPEARTICLE", SqlDbType.VarChar, 3);
        //    vppParamIN_CODETYPEARTICLE.Value = clsPhapararticle.IN_CODETYPEARTICLE;
        //    if (clsPhapararticle.IN_CODETYPEARTICLE == "") vppParamIN_CODETYPEARTICLE.Value = DBNull.Value;

        //    SqlParameter vppParamPR_CODEPRESENTATION = new SqlParameter("@PR_CODEPRESENTATION", SqlDbType.VarChar, 3);
        //    vppParamPR_CODEPRESENTATION.Value = clsPhapararticle.PR_CODEPRESENTATION;
        //    if (clsPhapararticle.PR_CODEPRESENTATION == "") vppParamPR_CODEPRESENTATION.Value = DBNull.Value;

        //    SqlParameter vppParamAR_PAOBLIGATOIRE = new SqlParameter("@AR_PAOBLIGATOIRE", SqlDbType.VarChar, 1);
        //    vppParamAR_PAOBLIGATOIRE.Value = clsPhapararticle.AR_PAOBLIGATOIRE;


        //    SqlParameter vppParamAR_PVOBLIGATOIRE = new SqlParameter("@AR_PVOBLIGATOIRE", SqlDbType.VarChar, 1);
        //    vppParamAR_PVOBLIGATOIRE.Value = clsPhapararticle.AR_PVOBLIGATOIRE;

        //    SqlParameter vppParamIN_CODEINGREDIENT = new SqlParameter("@IN_CODEINGREDIENT", SqlDbType.VarChar, 3);
        //    vppParamIN_CODEINGREDIENT.Value = clsPhapararticle.IN_CODEINGREDIENT;
        //    if (clsPhapararticle.IN_CODEINGREDIENT == "") vppParamIN_CODEINGREDIENT.Value = DBNull.Value;

        //    SqlParameter vppParamAR_DATEPREMIEREMISEENSERVICE = new SqlParameter("@AR_DATEPREMIEREMISEENSERVICE", SqlDbType.DateTime);
        //    vppParamAR_DATEPREMIEREMISEENSERVICE.Value = clsPhapararticle.AR_DATEPREMIEREMISEENSERVICE;
        //    if (clsPhapararticle.AR_DATEPREMIEREMISEENSERVICE.ToShortDateString() == "01/01/0001") vppParamAR_DATEPREMIEREMISEENSERVICE.Value = DateTime.Parse("01/01/1900");

        //    SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 2);
        //    vppParamTYPEOPERATION.Value = clsPhapararticle.TYPEOPERATION;
        //    SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
        //    vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;


        //    SqlParameter vppParamAR_CODEARTICLERETOUR = new SqlParameter("@AR_CODEARTICLERETOUR", SqlDbType.VarChar, 50);

        //    SqlCommand vppSqlCmd = new SqlCommand("PC_PHAPARARTICLE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    vppSqlCmd.CommandType = CommandType.StoredProcedure;



        //    ////Préparation de la commande
        //    //this.vapRequete = "EXECUTE PC_PHAPARARTICLE  @AR_CODEARTICLE, @AR_CODECIP, @AR_CODEBARRE, @RY_CODERAYON, @FO_CODEFORME, @TB_CODETABLEAU, @TA_CODETYPEARTICLE, @FA_CODEFABRICANT, @MO_CODEMODEL, @MA_CODEMARQUE, @DA_CODEDESTINATION, @UN_CODEUNITE, @AR_NOMCOMMERCIALE, @AR_NOMSCIENTIFIQUE, @AR_DESCRIPTION, @AR_CONDITIONNEMENT, @AR_CONTENANCE, @AR_SEUILMINI, @AR_SEUILMAXI, @AR_RATTACHE, @AR_STATUT, @AR_ASDI, @AR_TVA, @AR_DUREEGARANTIE, @AR_DATECLOTURE, @AR_REPORTSORTIE, @AR_REPORTENTREE, @AR_NOMBREPERIODEPRECEDENTSORTIE, @AR_NOMBREPERIODEPRECEDENTENTREE, @AR_NOMBREPERIODESORTIEENCOURS, @AR_NOMBREPERIODEENTREEENCOURS, @AR_NOMBRESTOCKFINALSORTIE, @AR_NOMBRESTOCKFINALENTREE, @AR_QUANTIFIABLE, @AR_DATECREATION,@AR_NUMEROORDRE, @IN_CODETYPEARTICLE,@PR_CODEPRESENTATION,@AR_PAOBLIGATOIRE,@AR_PVOBLIGATOIRE,@IN_CODEINGREDIENT,@AR_DATEPREMIEREMISEENSERVICE, @CODECRYPTAGE, @TYPEOPERATION ";
        //    //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

        //    //Ajout des paramètre à la commande
        //    vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_CODECIP);
        //    vppSqlCmd.Parameters.Add(vppParamAR_CODEBARRE);
        //    vppSqlCmd.Parameters.Add(vppParamRY_CODERAYON);
        //    vppSqlCmd.Parameters.Add(vppParamFO_CODEFORME);
        //    vppSqlCmd.Parameters.Add(vppParamTB_CODETABLEAU);
        //    vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
        //    vppSqlCmd.Parameters.Add(vppParamFA_CODEFABRICANT);
        //    vppSqlCmd.Parameters.Add(vppParamMO_CODEMODEL);
        //    vppSqlCmd.Parameters.Add(vppParamMA_CODEMARQUE);
        //    vppSqlCmd.Parameters.Add(vppParamDA_CODEDESTINATION);
        //    vppSqlCmd.Parameters.Add(vppParamUN_CODEUNITE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NOMCOMMERCIALE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NOMSCIENTIFIQUE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_DESCRIPTION);
        //    vppSqlCmd.Parameters.Add(vppParamAR_CONDITIONNEMENT);
        //    vppSqlCmd.Parameters.Add(vppParamAR_CONTENANCE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_SEUILMINI);
        //    vppSqlCmd.Parameters.Add(vppParamAR_SEUILMAXI);
        //    vppSqlCmd.Parameters.Add(vppParamAR_RATTACHE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_STATUT);
        //    vppSqlCmd.Parameters.Add(vppParamAR_ASDI);
        //    vppSqlCmd.Parameters.Add(vppParamAR_TVA);
        //    vppSqlCmd.Parameters.Add(vppParamAR_DUREEGARANTIE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_DATECLOTURE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_REPORTSORTIE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_REPORTENTREE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEPRECEDENTSORTIE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEPRECEDENTENTREE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODESORTIEENCOURS);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEENTREEENCOURS);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NOMBRESTOCKFINALSORTIE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NOMBRESTOCKFINALENTREE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_QUANTIFIABLE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_DATECREATION);
        //    vppSqlCmd.Parameters.Add(vppParamAR_NUMEROORDRE);
        //    vppSqlCmd.Parameters.Add(vppParamIN_CODETYPEARTICLE);
        //    vppSqlCmd.Parameters.Add(vppParamPR_CODEPRESENTATION);
        //    vppSqlCmd.Parameters.Add(vppParamAR_PAOBLIGATOIRE);
        //    vppSqlCmd.Parameters.Add(vppParamAR_PVOBLIGATOIRE);
        //    vppSqlCmd.Parameters.Add(vppParamIN_CODEINGREDIENT);
        //    vppSqlCmd.Parameters.Add(vppParamAR_DATEPREMIEREMISEENSERVICE);
        //    vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
        //    vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);


        //    vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLERETOUR);
        //    vppParamAR_CODEARTICLERETOUR.Direction = ParameterDirection.Output;

        //    ////Ouverture de la connection et exécution de la commande
        //    //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        //    //Ouverture de la connection et exécution de la commande
        //    clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        //    // valeurs de retour de la procedure stockée
        //    return vppSqlCmd.Parameters["@AR_CODEARTICLERETOUR"].Value.ToString();




        //    ////Ouverture de la connection et exécution de la commande
        //    //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        //}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapararticle>clsPhapararticle</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapararticle clsPhapararticle,params string[] vppCritere)
		{
			
            //Préparation des paramètres
            SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
            vppParamAR_CODEARTICLE.Value = clsPhapararticle.AR_CODEARTICLE;

            SqlParameter vppParamAR_CODECIP = new SqlParameter("@AR_CODECIP", SqlDbType.VarChar, 10);
            vppParamAR_CODECIP.Value = clsPhapararticle.AR_CODECIP;

            SqlParameter vppParamAR_CODEBARRE = new SqlParameter("@AR_CODEBARRE", SqlDbType.VarChar, 13);
            vppParamAR_CODEBARRE.Value = clsPhapararticle.AR_CODEBARRE;

            SqlParameter vppParamRY_CODERAYON = new SqlParameter("@RY_CODERAYON", SqlDbType.VarChar, 3);
            vppParamRY_CODERAYON.Value = clsPhapararticle.RY_CODERAYON;
            if (clsPhapararticle.RY_CODERAYON == "") vppParamRY_CODERAYON.Value = DBNull.Value;

            SqlParameter vppParamFO_CODEFORME = new SqlParameter("@FO_CODEFORME", SqlDbType.VarChar, 3);
            vppParamFO_CODEFORME.Value = clsPhapararticle.FO_CODEFORME;
            if (clsPhapararticle.FO_CODEFORME == "") vppParamFO_CODEFORME.Value = DBNull.Value;

            SqlParameter vppParamTB_CODETABLEAU = new SqlParameter("@TB_CODETABLEAU", SqlDbType.VarChar, 3);
            vppParamTB_CODETABLEAU.Value = clsPhapararticle.TB_CODETABLEAU;
            if (clsPhapararticle.TB_CODETABLEAU == "") vppParamTB_CODETABLEAU.Value = DBNull.Value;

            SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 3);
            vppParamTA_CODETYPEARTICLE.Value = clsPhapararticle.TA_CODETYPEARTICLE;
            if (clsPhapararticle.TA_CODETYPEARTICLE == "") vppParamTA_CODETYPEARTICLE.Value = DBNull.Value;

            SqlParameter vppParamFA_CODEFABRICANT = new SqlParameter("@FA_CODEFABRICANT", SqlDbType.VarChar, 6);
            vppParamFA_CODEFABRICANT.Value = clsPhapararticle.FA_CODEFABRICANT;
            if (clsPhapararticle.FA_CODEFABRICANT == "") vppParamFA_CODEFABRICANT.Value = DBNull.Value;

            SqlParameter vppParamMO_CODEMODEL = new SqlParameter("@MO_CODEMODEL", SqlDbType.VarChar, 3);
            vppParamMO_CODEMODEL.Value = clsPhapararticle.MO_CODEMODEL;
            if (clsPhapararticle.MO_CODEMODEL == "") vppParamMO_CODEMODEL.Value = DBNull.Value;

            SqlParameter vppParamMA_CODEMARQUE = new SqlParameter("@MA_CODEMARQUE", SqlDbType.VarChar, 3);
            vppParamMA_CODEMARQUE.Value = clsPhapararticle.MA_CODEMARQUE;
            if (clsPhapararticle.MA_CODEMARQUE == "") vppParamMA_CODEMARQUE.Value = DBNull.Value;

            SqlParameter vppParamDA_CODEDESTINATION = new SqlParameter("@DA_CODEDESTINATION", SqlDbType.VarChar, 3);
            vppParamDA_CODEDESTINATION.Value = clsPhapararticle.DA_CODEDESTINATION;
            if (clsPhapararticle.DA_CODEDESTINATION == "") vppParamDA_CODEDESTINATION.Value = DBNull.Value;

            SqlParameter vppParamUN_CODEUNITE = new SqlParameter("@UN_CODEUNITE", SqlDbType.VarChar, 3);
            vppParamUN_CODEUNITE.Value = clsPhapararticle.UN_CODEUNITE;
            if (clsPhapararticle.UN_CODEUNITE == "") vppParamUN_CODEUNITE.Value = DBNull.Value;

            SqlParameter vppParamAR_NOMCOMMERCIALE = new SqlParameter("@AR_NOMCOMMERCIALE", SqlDbType.VarChar, 150);
            vppParamAR_NOMCOMMERCIALE.Value = clsPhapararticle.AR_NOMCOMMERCIALE;

            SqlParameter vppParamAR_NOMSCIENTIFIQUE = new SqlParameter("@AR_NOMSCIENTIFIQUE", SqlDbType.VarChar, 150);
            vppParamAR_NOMSCIENTIFIQUE.Value = clsPhapararticle.AR_NOMSCIENTIFIQUE;

            SqlParameter vppParamAR_DESCRIPTION = new SqlParameter("@AR_DESCRIPTION", SqlDbType.VarChar, 150);
            vppParamAR_DESCRIPTION.Value = clsPhapararticle.AR_DESCRIPTION;

            SqlParameter vppParamAR_CONDITIONNEMENT = new SqlParameter("@AR_CONDITIONNEMENT", SqlDbType.VarChar, 150);
            vppParamAR_CONDITIONNEMENT.Value = clsPhapararticle.AR_CONDITIONNEMENT;

            SqlParameter vppParamAR_CONTENANCE = new SqlParameter("@AR_CONTENANCE", SqlDbType.Decimal, 4);
            vppParamAR_CONTENANCE.Value = clsPhapararticle.AR_CONTENANCE;

            SqlParameter vppParamAR_SEUILMINI = new SqlParameter("@AR_SEUILMINI", SqlDbType.BigInt);
            vppParamAR_SEUILMINI.Value = clsPhapararticle.AR_SEUILMINI;

            SqlParameter vppParamAR_SEUILMAXI = new SqlParameter("@AR_SEUILMAXI", SqlDbType.BigInt);
            vppParamAR_SEUILMAXI.Value = clsPhapararticle.AR_SEUILMAXI;

            SqlParameter vppParamAR_RATTACHE = new SqlParameter("@AR_RATTACHE", SqlDbType.VarChar, 7);
            vppParamAR_RATTACHE.Value = clsPhapararticle.AR_RATTACHE;
            if (clsPhapararticle.AR_RATTACHE == "") vppParamAR_RATTACHE.Value = DBNull.Value;

            SqlParameter vppParamAR_STATUT = new SqlParameter("@AR_STATUT", SqlDbType.VarChar, 2);
            vppParamAR_STATUT.Value = clsPhapararticle.AR_STATUT;

            SqlParameter vppParamAR_ASDI = new SqlParameter("@AR_ASDI", SqlDbType.VarChar, 1);
            vppParamAR_ASDI.Value = clsPhapararticle.AR_ASDI;

            SqlParameter vppParamAR_TVA = new SqlParameter("@AR_TVA", SqlDbType.VarChar, 1);
            vppParamAR_TVA.Value = clsPhapararticle.AR_TVA;

            SqlParameter vppParamAR_DUREEGARANTIE = new SqlParameter("@AR_DUREEGARANTIE", SqlDbType.Int);
            vppParamAR_DUREEGARANTIE.Value = clsPhapararticle.AR_DUREEGARANTIE;

            SqlParameter vppParamAR_DATECLOTURE = new SqlParameter("@AR_DATECLOTURE", SqlDbType.DateTime);
            vppParamAR_DATECLOTURE.Value = clsPhapararticle.AR_DATECLOTURE;
            if (clsPhapararticle.AR_DATECLOTURE.ToShortDateString() == "01/01/0001") vppParamAR_DATECLOTURE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAR_REPORTSORTIE = new SqlParameter("@AR_REPORTSORTIE", SqlDbType.Money);
            vppParamAR_REPORTSORTIE.Value = clsPhapararticle.AR_REPORTSORTIE;

            SqlParameter vppParamAR_REPORTENTREE = new SqlParameter("@AR_REPORTENTREE", SqlDbType.Money);
            vppParamAR_REPORTENTREE.Value = clsPhapararticle.AR_REPORTENTREE;

            SqlParameter vppParamAR_NOMBREPERIODEPRECEDENTSORTIE = new SqlParameter("@AR_NOMBREPERIODEPRECEDENTSORTIE", SqlDbType.Money);
            vppParamAR_NOMBREPERIODEPRECEDENTSORTIE.Value = clsPhapararticle.AR_NOMBREPERIODEPRECEDENTSORTIE;

            SqlParameter vppParamAR_NOMBREPERIODEPRECEDENTENTREE = new SqlParameter("@AR_NOMBREPERIODEPRECEDENTENTREE", SqlDbType.Money);
            vppParamAR_NOMBREPERIODEPRECEDENTENTREE.Value = clsPhapararticle.AR_NOMBREPERIODEPRECEDENTENTREE;

            SqlParameter vppParamAR_NOMBREPERIODESORTIEENCOURS = new SqlParameter("@AR_NOMBREPERIODESORTIEENCOURS", SqlDbType.Money);
            vppParamAR_NOMBREPERIODESORTIEENCOURS.Value = clsPhapararticle.AR_NOMBREPERIODESORTIEENCOURS;

            SqlParameter vppParamAR_NOMBREPERIODEENTREEENCOURS = new SqlParameter("@AR_NOMBREPERIODEENTREEENCOURS", SqlDbType.Money);
            vppParamAR_NOMBREPERIODEENTREEENCOURS.Value = clsPhapararticle.AR_NOMBREPERIODEENTREEENCOURS;

            SqlParameter vppParamAR_NOMBRESTOCKFINALSORTIE = new SqlParameter("@AR_NOMBRESTOCKFINALSORTIE", SqlDbType.Money);
            vppParamAR_NOMBRESTOCKFINALSORTIE.Value = clsPhapararticle.AR_NOMBRESTOCKFINALSORTIE;

            SqlParameter vppParamAR_NOMBRESTOCKFINALENTREE = new SqlParameter("@AR_NOMBRESTOCKFINALENTREE", SqlDbType.Money);
            vppParamAR_NOMBRESTOCKFINALENTREE.Value = clsPhapararticle.AR_NOMBRESTOCKFINALENTREE;

            SqlParameter vppParamAR_QUANTIFIABLE = new SqlParameter("@AR_QUANTIFIABLE", SqlDbType.VarChar, 1);
            vppParamAR_QUANTIFIABLE.Value = clsPhapararticle.AR_QUANTIFIABLE;
            SqlParameter vppParamAR_DATECREATION = new SqlParameter("@AR_DATECREATION", SqlDbType.DateTime);
            vppParamAR_DATECREATION.Value = clsPhapararticle.AR_DATECREATION;
            SqlParameter vppParamAR_NUMEROORDRE = new SqlParameter("@AR_NUMEROORDRE", SqlDbType.Int);
            vppParamAR_NUMEROORDRE.Value = clsPhapararticle.AR_NUMEROORDRE;

           

            SqlParameter vppParamIN_CODETYPEARTICLE = new SqlParameter("@IN_CODETYPEARTICLE", SqlDbType.VarChar, 3);
            vppParamIN_CODETYPEARTICLE.Value = clsPhapararticle.IN_CODETYPEARTICLE;
            if (clsPhapararticle.IN_CODETYPEARTICLE == "") vppParamIN_CODETYPEARTICLE.Value = DBNull.Value;

            SqlParameter vppParamPR_CODEPRESENTATION = new SqlParameter("@PR_CODEPRESENTATION", SqlDbType.VarChar, 150);
            vppParamPR_CODEPRESENTATION.Value = clsPhapararticle.PR_CODEPRESENTATION;
            if (clsPhapararticle.PR_CODEPRESENTATION == "") vppParamPR_CODEPRESENTATION.Value = DBNull.Value;

            SqlParameter vppParamAR_PAOBLIGATOIRE = new SqlParameter("@AR_PAOBLIGATOIRE", SqlDbType.VarChar, 1);
            vppParamAR_PAOBLIGATOIRE.Value = clsPhapararticle.AR_PAOBLIGATOIRE;


            SqlParameter vppParamAR_PVOBLIGATOIRE = new SqlParameter("@AR_PVOBLIGATOIRE", SqlDbType.VarChar, 1);
            vppParamAR_PVOBLIGATOIRE.Value = clsPhapararticle.AR_PVOBLIGATOIRE;

            SqlParameter vppParamIN_CODEINGREDIENT = new SqlParameter("@IN_CODEINGREDIENT", SqlDbType.VarChar, 3);
            vppParamIN_CODEINGREDIENT.Value = clsPhapararticle.IN_CODEINGREDIENT;
            if (clsPhapararticle.IN_CODEINGREDIENT == "") vppParamIN_CODEINGREDIENT.Value = DBNull.Value;



            SqlParameter vppParamAR_DATEPREMIEREMISEENSERVICE = new SqlParameter("@AR_DATEPREMIEREMISEENSERVICE", SqlDbType.DateTime);
            vppParamAR_DATEPREMIEREMISEENSERVICE.Value = clsPhapararticle.AR_DATEPREMIEREMISEENSERVICE;
            if (clsPhapararticle.AR_DATEPREMIEREMISEENSERVICE.ToShortDateString() == "01/01/0001") vppParamAR_DATEPREMIEREMISEENSERVICE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAR_COLLISAGE = new SqlParameter("@AR_COLLISAGE", SqlDbType.Int);
            vppParamAR_COLLISAGE.Value = clsPhapararticle.AR_COLLISAGE;

            SqlParameter vppParamAR_PERISSABLE = new SqlParameter("@AR_PERISSABLE", SqlDbType.VarChar, 1);
            vppParamAR_PERISSABLE.Value = clsPhapararticle.AR_PERISSABLE;

            SqlParameter vppParamAR_DUREEPEREMPTION = new SqlParameter("@AR_DUREEPEREMPTION", SqlDbType.Int);
            vppParamAR_DUREEPEREMPTION.Value = clsPhapararticle.AR_DUREEPEREMPTION;


            SqlParameter vppParamCF_CODECOEFICIENT = new SqlParameter("@CF_CODECOEFICIENT", SqlDbType.VarChar, 25);
            vppParamCF_CODECOEFICIENT.Value = clsPhapararticle.CF_CODECOEFICIENT;
            if (clsPhapararticle.CF_CODECOEFICIENT == "") vppParamCF_CODECOEFICIENT.Value = DBNull.Value;

            SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 25);
            vppParamRQ_CODERISQUE.Value = clsPhapararticle.RQ_CODERISQUE;
            if (clsPhapararticle.RQ_CODERISQUE == "") vppParamRQ_CODERISQUE.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;




            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARARTICLE  @AR_CODEARTICLE, @AR_CODECIP, @AR_CODEBARRE, @RY_CODERAYON, @FO_CODEFORME, @TB_CODETABLEAU, @TA_CODETYPEARTICLE, @FA_CODEFABRICANT, @MO_CODEMODEL, @MA_CODEMARQUE, @DA_CODEDESTINATION, @UN_CODEUNITE, @AR_NOMCOMMERCIALE, @AR_NOMSCIENTIFIQUE, @AR_DESCRIPTION, @AR_CONDITIONNEMENT, @AR_CONTENANCE, @AR_SEUILMINI, @AR_SEUILMAXI, @AR_RATTACHE, @AR_STATUT, @AR_ASDI, @AR_TVA, @AR_DUREEGARANTIE, @AR_DATECLOTURE, @AR_REPORTSORTIE, @AR_REPORTENTREE, @AR_NOMBREPERIODEPRECEDENTSORTIE, @AR_NOMBREPERIODEPRECEDENTENTREE, @AR_NOMBREPERIODESORTIEENCOURS, @AR_NOMBREPERIODEENTREEENCOURS, @AR_NOMBRESTOCKFINALSORTIE, @AR_NOMBRESTOCKFINALENTREE, @AR_QUANTIFIABLE, @AR_DATECREATION,@AR_NUMEROORDRE,@IN_CODETYPEARTICLE,@PR_CODEPRESENTATION,@AR_PAOBLIGATOIRE,@AR_PVOBLIGATOIRE,@IN_CODEINGREDIENT,@AR_DATEPREMIEREMISEENSERVICE,@AR_COLLISAGE,@AR_PERISSABLE,@AR_DUREEPEREMPTION,@CF_CODECOEFICIENT,@RQ_CODERISQUE, @CODECRYPTAGE, @TYPEOPERATION";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamAR_CODECIP);
            vppSqlCmd.Parameters.Add(vppParamAR_CODEBARRE);
            vppSqlCmd.Parameters.Add(vppParamRY_CODERAYON);
            vppSqlCmd.Parameters.Add(vppParamFO_CODEFORME);
            vppSqlCmd.Parameters.Add(vppParamTB_CODETABLEAU);
            vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamFA_CODEFABRICANT);
            vppSqlCmd.Parameters.Add(vppParamMO_CODEMODEL);
            vppSqlCmd.Parameters.Add(vppParamMA_CODEMARQUE);
            vppSqlCmd.Parameters.Add(vppParamDA_CODEDESTINATION);
            vppSqlCmd.Parameters.Add(vppParamUN_CODEUNITE);
            vppSqlCmd.Parameters.Add(vppParamAR_NOMCOMMERCIALE);
            vppSqlCmd.Parameters.Add(vppParamAR_NOMSCIENTIFIQUE);
            vppSqlCmd.Parameters.Add(vppParamAR_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamAR_CONDITIONNEMENT);
            vppSqlCmd.Parameters.Add(vppParamAR_CONTENANCE);
            vppSqlCmd.Parameters.Add(vppParamAR_SEUILMINI);
            vppSqlCmd.Parameters.Add(vppParamAR_SEUILMAXI);
            vppSqlCmd.Parameters.Add(vppParamAR_RATTACHE);
            vppSqlCmd.Parameters.Add(vppParamAR_STATUT);
            vppSqlCmd.Parameters.Add(vppParamAR_ASDI);
            vppSqlCmd.Parameters.Add(vppParamAR_TVA);
            vppSqlCmd.Parameters.Add(vppParamAR_DUREEGARANTIE);
            vppSqlCmd.Parameters.Add(vppParamAR_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamAR_REPORTSORTIE);
            vppSqlCmd.Parameters.Add(vppParamAR_REPORTENTREE);
            vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEPRECEDENTSORTIE);
            vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEPRECEDENTENTREE);
            vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODESORTIEENCOURS);
            vppSqlCmd.Parameters.Add(vppParamAR_NOMBREPERIODEENTREEENCOURS);
            vppSqlCmd.Parameters.Add(vppParamAR_NOMBRESTOCKFINALSORTIE);
            vppSqlCmd.Parameters.Add(vppParamAR_NOMBRESTOCKFINALENTREE);
            vppSqlCmd.Parameters.Add(vppParamAR_QUANTIFIABLE);
            vppSqlCmd.Parameters.Add(vppParamAR_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamAR_NUMEROORDRE);
            vppSqlCmd.Parameters.Add(vppParamIN_CODETYPEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamPR_CODEPRESENTATION);
            vppSqlCmd.Parameters.Add(vppParamAR_PAOBLIGATOIRE);
            vppSqlCmd.Parameters.Add(vppParamAR_PVOBLIGATOIRE);
            vppSqlCmd.Parameters.Add(vppParamIN_CODEINGREDIENT);
            vppSqlCmd.Parameters.Add(vppParamAR_DATEPREMIEREMISEENSERVICE);
            vppSqlCmd.Parameters.Add(vppParamAR_COLLISAGE);
            vppSqlCmd.Parameters.Add(vppParamAR_PERISSABLE);
            vppSqlCmd.Parameters.Add(vppParamAR_DUREEPEREMPTION);
            vppSqlCmd.Parameters.Add(vppParamCF_CODECOEFICIENT);
            vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        //public void pvgUpdateCodeBare(clsDonnee clsDonnee, string vppNouveauCode,params string[] vppCritere)
        public void pvgUpdateCodeBare(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //Préparation des paramètres
            vapNomParametre = new string[] { "@AR_CODEARTICLE", "@AR_CODEBARRE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };

            //Préparation de la commande
            //pvpChoixCritere(vppCritere);
            this.vapRequete = "UPDATE PHAPARARTICLE SET " +
                           "AR_CODEBARRE = @AR_CODEBARRE WHERE AR_CODEARTICLE=@AR_CODEARTICLE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        public void pvgUpdateCodeCIP(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AR_CODEARTICLE", "@AR_CODECIP" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };

            //Préparation de la commande
            //pvpChoixCritere(vppCritere);
            this.vapRequete = "UPDATE PHAPARARTICLE SET " +
                           "AR_CODECIP = @AR_CODECIP WHERE AR_CODEARTICLE=@AR_CODEARTICLE ";

            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        //public void pvgUpdateTauxRemise(clsDonnee clsDonnee, string vppNouveauCode, params string[] vppCritere)
        public void pvgUpdateTauxRemise(clsDonnee clsDonnee,  params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AR_CODEARTICLE", "@AR_TAUXREMISE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };

            //Préparation de la commande
            pvpChoixCritere(vppCritere);
            this.vapRequete = "UPDATE PHAPARARTICLE SET " +
                           "AR_TAUXREMISE = @AR_TAUXREMISE WHERE AR_CODEARTICLE=@AR_CODEARTICLE ";

            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARARTICLE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapararticle </returns>
		///<author>Home Technology</author>
		public List<clsPhapararticle> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            List<clsPhapararticle> clsPhapararticles = new List<clsPhapararticle>();
            pvpChoixCritere(vppCritere);
            clsPhapararticles = pvgSelectGenerique(clsDonnee, vppCritere);
			return clsPhapararticles;
		}

        public DataSet pvgChargerArticle(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT  AR_CODEARTICLE, AR_CODECIP, AR_CODEBARRE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_NOMCOMMERCIALE, AR_NOMSCIENTIFIQUE, AR_DESCRIPTION, AR_CONDITIONNEMENT, AR_CONTENANCE, AR_SEUILMINI, AR_SEUILMAXI, AR_RATTACHE, AR_STATUT, AR_ASDI, AR_TVA, AR_DUREEGARANTIE, AR_DATECLOTURE, AR_REPORTSORTIE, AR_REPORTENTREE, AR_NOMBREPERIODEPRECEDENTSORTIE, AR_NOMBREPERIODEPRECEDENTENTREE, AR_NOMBREPERIODESORTIEENCOURS, AR_NOMBREPERIODEENTREEENCOURS, AR_NOMBRESTOCKFINALSORTIE, AR_NOMBRESTOCKFINALENTREE, AR_QUANTIFIABLE, AR_NUMEROORDRE , AR_COLLISAGE, CF_CODECOEFICIENT FROM dbo.PHAPARARTICLE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

        public DataSet pvgSelectArticleRecherche(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AR_CODEARTICLE, AR_CODECIP, AR_CODEBARRE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_NOMCOMMERCIALE, AR_NOMSCIENTIFIQUE, AR_DESCRIPTION, AR_CONDITIONNEMENT, AR_CONTENANCE, AR_SEUILMINI, AR_SEUILMAXI, AR_RATTACHE, AR_STATUT, AR_ASDI, AR_TVA, AR_DUREEGARANTIE, AR_DATECLOTURE, AR_REPORTSORTIE, AR_REPORTENTREE, AR_NOMBREPERIODEPRECEDENTSORTIE, AR_NOMBREPERIODEPRECEDENTENTREE, AR_NOMBREPERIODESORTIEENCOURS, AR_NOMBREPERIODEENTREEENCOURS, AR_NOMBRESTOCKFINALSORTIE, AR_NOMBRESTOCKFINALENTREE, AR_QUANTIFIABLE,AR_NUMEROORDRE ,AR_COLLISAGE,CF_CODECOEFICIENT FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE)  " + this.vapCritere ;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapararticle </returns>
		///<author>Home Technology</author>
		public List<clsPhapararticle> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapararticle> clsPhapararticles = new List<clsPhapararticle>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE, AR_CODECIP, AR_CODEBARRE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_NOMCOMMERCIALE, AR_NOMSCIENTIFIQUE, AR_DESCRIPTION, AR_CONDITIONNEMENT, AR_CONTENANCE, AR_SEUILMINI, AR_SEUILMAXI, AR_RATTACHE, AR_STATUT, AR_ASDI, AR_TVA, AR_DUREEGARANTIE, AR_DATECLOTURE, AR_REPORTSORTIE, AR_REPORTENTREE, AR_NOMBREPERIODEPRECEDENTSORTIE, AR_NOMBREPERIODEPRECEDENTENTREE, AR_NOMBREPERIODESORTIEENCOURS, AR_NOMBREPERIODEENTREEENCOURS, AR_NOMBRESTOCKFINALSORTIE, AR_NOMBRESTOCKFINALENTREE, AR_QUANTIFIABLE, AR_COLLISAGE, CF_CODECOEFICIENT FROM dbo.PHAPARARTICLE " + this.vapCritere;
			this.vapCritere="";			
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapararticle clsPhapararticle = new clsPhapararticle();
                    clsPhapararticle.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_CODECIP = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODECIP"].ToString();
                    clsPhapararticle.AR_CODEBARRE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEBARRE"].ToString();
                    clsPhapararticle.RY_CODERAYON = Dataset.Tables["TABLE"].Rows[Idx]["RY_CODERAYON"].ToString();
                    clsPhapararticle.FO_CODEFORME = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFORME"].ToString();
                    clsPhapararticle.TB_CODETABLEAU = Dataset.Tables["TABLE"].Rows[Idx]["TB_CODETABLEAU"].ToString();
                    clsPhapararticle.TA_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEARTICLE"].ToString();
                    clsPhapararticle.FA_CODEFABRICANT = Dataset.Tables["TABLE"].Rows[Idx]["FA_CODEFABRICANT"].ToString();
                    clsPhapararticle.MO_CODEMODEL = Dataset.Tables["TABLE"].Rows[Idx]["MO_CODEMODEL"].ToString();
                    clsPhapararticle.MA_CODEMARQUE = Dataset.Tables["TABLE"].Rows[Idx]["MA_CODEMARQUE"].ToString();
                    clsPhapararticle.DA_CODEDESTINATION = Dataset.Tables["TABLE"].Rows[Idx]["DA_CODEDESTINATION"].ToString();
                    clsPhapararticle.UN_CODEUNITE = Dataset.Tables["TABLE"].Rows[Idx]["UN_CODEUNITE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = Dataset.Tables["TABLE"].Rows[Idx]["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.AR_NOMSCIENTIFIQUE = Dataset.Tables["TABLE"].Rows[Idx]["AR_NOMSCIENTIFIQUE"].ToString();
                    clsPhapararticle.AR_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["AR_DESCRIPTION"].ToString();
                    clsPhapararticle.AR_CONDITIONNEMENT = Dataset.Tables["TABLE"].Rows[Idx]["AR_CONDITIONNEMENT"].ToString();
                    clsPhapararticle.AR_CONTENANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_CONTENANCE"].ToString());
                    clsPhapararticle.AR_SEUILMINI = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_SEUILMINI"].ToString());
                    clsPhapararticle.AR_SEUILMAXI = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_SEUILMAXI"].ToString());
                    clsPhapararticle.AR_RATTACHE = Dataset.Tables["TABLE"].Rows[Idx]["AR_RATTACHE"].ToString();
                    clsPhapararticle.AR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["AR_STATUT"].ToString();
                    clsPhapararticle.AR_ASDI = Dataset.Tables["TABLE"].Rows[Idx]["AR_ASDI"].ToString();
                    clsPhapararticle.AR_TVA = Dataset.Tables["TABLE"].Rows[Idx]["AR_TVA"].ToString();
                    clsPhapararticle.AR_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_DATECLOTURE"].ToString());
                    clsPhapararticle.AR_COLLISAGE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_COLLISAGE"].ToString());
                    clsPhapararticle.CF_CODECOEFICIENT = Dataset.Tables["TABLE"].Rows[Idx]["CF_CODECOEFICIENT"].ToString();

                    clsPhapararticles.Add(clsPhapararticle);
				}
				Dataset.Dispose();
			}
		return clsPhapararticles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereRechercheDataSet(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY AR_NUMEROORDRE,AR_NOMCOMMERCIALE ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetAvecStock(clsDonnee clsDonnee, params string[] vppCritere)
        {
            
               
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@NT_CODENATURETYPEARTICLE", "@TA_CODETYPEARTICLE", "@AR_CODECIP", "@AR_NOMCOMMERCIALE" , "@MA_CODEMARQUE", "@AR_STATUT", "@DATEJOURNEE", "MF_IDFILTRAGEDESTOCK", "ME_IDFILTRAGEDESTOCKEXPIRATION", "MF_IDFILTRAGEDESTOCKM1", "MF_IDFILTRAGEDESTOCKM2", "MK_NUMPIECE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2].Replace("''", "'"), vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] , vppCritere[7] , vppCritere[8] , vppCritere[9] , vppCritere[10], vppCritere[11], vppCritere[12] , vppCritere[13] };
            this.vapRequete = "EXEC [dbo].[PS_PHAPARARTICLEAVECSTOCK] @AG_CODEAGENCE,	@EN_CODEENTREPOT,@NT_CODENATURETYPEARTICLE, @TA_CODETYPEARTICLE, @AR_CODECIP, @AR_NOMCOMMERCIALE,@MA_CODEMARQUE, @AR_STATUT,@DATEJOURNEE, @MF_IDFILTRAGEDESTOCK, @ME_IDFILTRAGEDESTOCKEXPIRATION, @MF_IDFILTRAGEDESTOCKM1, @MF_IDFILTRAGEDESTOCKM2,@MK_NUMPIECE,@CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPgarage(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE", "@MA_CODEMARQUE", "@MO_CODEMODEL", "@FO_CODEFORME", "@FA_CODEFABRICANT", "@RY_CODERAYON", "@DATEDEBUT", "@DATEFIN", "@NT_CODENATURETYPEARTICLE", "@TI_NUMTIERS", "@TI_DENOMINATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11] , vppCritere[12], vppCritere[13] };

            //vapNomParametre = new string[] { "@NT_CODENATURETYPEARTICLE", "@TA_CODETYPEARTICLE", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@MA_CODEMARQUE", "@AR_STATUT", "@NT_CODENATURETIERS", "@TYPEMONTANT", "@DATEJOURNEE", "@CODECRYPTAGE" };
            //vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAPARARTICLEPOURDATASET @AR_STATUT,@AR_CODECIP,@AR_NOMCOMMERCIALE,@TA_CODETYPEARTICLE, @MA_CODEMARQUE,@MO_CODEMODEL,@FO_CODEFORME,@FA_CODEFABRICANT,@RY_CODERAYON,@DATEDEBUT,@DATEFIN,@NT_CODENATURETYPEARTICLE,@TI_NUMTIERS,@TI_DENOMINATION, @CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboPgarage(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0],vppCritere[1], vppCritere[2]};

            //vapNomParametre = new string[] { "@NT_CODENATURETYPEARTICLE", "@TA_CODETYPEARTICLE", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@MA_CODEMARQUE", "@AR_STATUT", "@NT_CODENATURETIERS", "@TYPEMONTANT", "@DATEJOURNEE", "@CODECRYPTAGE" };
            //vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_COMBOLISTEVEHICULE @AG_CODEAGENCE,@TI_NUMTIERS,@TI_DENOMINATION, @CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

       


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetACCESSOIRS(clsDonnee clsDonnee, params string[] vppCritere)
        {
            
        this.vapCritere = " WHERE AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' "+
                        " AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND ISNULL(IN_CODETYPEARTICLE,'') LIKE '%'+ @IN_CODETYPEARTICLE + '%' ";
        vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE", "@MA_CODEMARQUE", "@IN_CODETYPEARTICLE" };
        vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] , vppCritere[5] };
			
        this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY AR_NUMEROORDRE,AR_NOMCOMMERCIALE ";
        this.vapCritere = "";
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetVenteAlaCaisse(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE", "@MA_CODEMARQUE", "@AR_CODEBARRE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = " EXEC [dbo].[PS_PHAPARARTICLEVENTEALACAISSE]  @AR_STATUT, @AR_CODECIP,  @AR_NOMCOMMERCIALE, @TA_CODETYPEARTICLE, @MA_CODEMARQUE, @AR_CODEBARRE,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        public DataSet pvgInsertIntoDatasetPrestation(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritereRechercheDataSet(vppCritere);
            vapNomParametre = new string[] { "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage};
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE)  WHERE AR_QUANTIFIABLE  ='N' AND AR_STATUT ='N'  ORDER BY AR_NUMEROORDRE,AR_NOMCOMMERCIALE ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgInsertIntoDatasetArticleQuantite(clsDonnee clsDonnee)
        {
            this.vapRequete = "SELECT * FROM TABLESUPPORT ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        //public DataSet pvgInsertIntoDatasetGestionPromotinnelle(clsDonnee clsDonnee,string vppCodeTypeClient, params string[] vppCritere)
        public DataSet pvgInsertIntoDatasetGestionPromotinnelle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritereRechercheDataSet(clsDonnee,vppCritere);


            this.vapCritere = " WHERE NT_CODENATURETIERS LIKE '%'+ @NT_CODENATURETIERS +'%' AND AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND   ISNULL(AR_CODECIP,'')  LIKE '%'+ @AR_CODECIP +'%' AND ISNULL(AR_NOMCOMMERCIALE,'')    LIKE '%'+ @AR_NOMCOMMERCIALE +'%' " +
                                  " AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND ISNULL(MO_CODEMODEL,'') LIKE '%'+ @MO_CODEMODEL + '%'   AND ISNULL(RY_CODERAYON,'') LIKE '%'+ @RY_CODERAYON + '%'  AND AR_QUANTIFIABLE  ='O' AND AR_DATECLOTURE='01/01/1900' AND JF_CODETYPEJOURFACTURATION=@JF_CODETYPEJOURFACTURATION AND LF_CODELIEUFACTURATION=@LF_CODELIEUFACTURATION ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@NT_CODENATURETIERS", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@MA_CODEMARQUE", "@TA_CODETYPEARTICLE", "@MO_CODEMODEL", "@RY_CODERAYON", "@JF_CODETYPEJOURFACTURATION", "@LF_CODELIEUFACTURATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9] };

            //vapCritere += vppCritere.Length == 0 ? "WHERE TP_CODETYPECLIENT  ='" + vppCodeTypeClient + "' ORDER BY AR_NOMCOMMERCIALE " : " AND TP_CODETYPECLIENT  ='" + vppCodeTypeClient + "'  ORDER BY AR_NOMCOMMERCIALE ";
            this.vapRequete = " SELECT AR_CODEARTICLE, AR_CODECIP, AR_CODEBARRE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, " +
            " MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_NOMCOMMERCIALE, AR_NOMSCIENTIFIQUE, AR_DESCRIPTION, AR_STATUT, NT_CODENATURETIERS, PY_PRIXVENTE, PY_TAUXREMISE, " +
            " PY_MONTANTREMISE, PY_TAUXCOMMISSION, PY_MONTANTCOMMISSION, PY_DATEREMISE1, PY_DATEREMISE2, PY_DATETARIFICATION,COCHER FROM FT_ARTTICLEPRIXACTUELTYPECLIENT(@CODECRYPTAGE) " + this.vapCritere + "  ORDER BY AR_NOMCOMMERCIALE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">ORDRE DES CRITERES CODEAGENCE, CODETYPECLIENT, CODETYPEFOURNISSEUR, DATE, </param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetFactureDDH(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODEAGENCE", "@MK_NUMPIECE", "@CODETYPECLIENT", "@DATE", "@TA_CODETYPEARTICLE", "@EN_CODEENTREPOT", "@TYPEMONTANT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],vppCritere[5],vppCritere[6],  clsDonnee.vogCleCryptage };

            this.vapRequete = "SELECT DISTINCT NT_CODENATURETYPEARTICLE,MK_NUMPIECE ='', AR_MONTANTVAUNITAIRE=0, AR_MONTANASDIUNITAIRE=0, MONTANTTCTOTALAVECREMISE=0, TOTALENTREEHT=0,TOTALTTC=0, TOTALENTREETTCPLUSAIRSI=0,MD_ARTICLETOTALHTPLUSAR_PRIXEMBALLAGETOTALE=0, * FROM [dbo].[FC_PHACOMMANDECLIENTAVECACCESSOIRE] (@CODEAGENCE,@MK_NUMPIECE,@CODETYPECLIENT,@DATE,@TA_CODETYPEARTICLE,@EN_CODEENTREPOT,@TYPEMONTANT,@CODECRYPTAGE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">ORDRE DES CRITERES CODEAGENCE, CODETYPEFOURNISSEUR, DATE,</param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetFactureApproDDH(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@CODEAGENCE", "@MK_NUMPIECE", "@DATE", "@TA_CODETYPEARTICLE", "@TYPEMONTANT", "@EN_CODEENTREPOT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],vppCritere[5], clsDonnee.vogCleCryptage };

            this.vapRequete = "SELECT DISTINCT MK_NUMPIECE ='', AR_MONTANTVAUNITAIRE=0, AR_MONTANASDIUNITAIRE=0, MONTANTTCTOTALAVECREMISE=0, TOTALENTREEHT=0, TOTALENTREETTCPLUSAIRSI=0,MD_ARTICLETOTALHTPLUSAR_PRIXEMBALLAGETOTALE=0, * FROM dbo.FC_PHACOMMANDEFOURNISSEURAVECACCESSOIRE(@CODEAGENCE,@MK_NUMPIECE,@DATE,@TA_CODETYPEARTICLE,@TYPEMONTANT,@EN_CODEENTREPOT,@CODECRYPTAGE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">ORDRE DES CRITERES CODEAGENCE, CODETYPEFOURNISSEUR, DATE,</param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetRetoursAccessoir(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@CODEAGENCE", "@MS_NUMPIECE", "@CL_NUMCLIENT", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1],vppCritere[2], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_RETOURSACCESSOIR @CODEAGENCE,@MS_NUMPIECE,@CL_NUMCLIENT,@CODECRYPTAGE ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">ORDRE DES CRITERES CODEARTICLE, CODETYPECLIENT</param>
        /// <returns></returns>
        public string pvgPrixActuel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODEARTICLE", "@CODETYPECLIENT", "@CODECRYPTAGE"};
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };

            this.vapRequete = "SELECT [dbo].FC_PRIXACTUEL( @CODEARTICLE, @CODETYPECLIENT,@CODECRYPTAGE)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">ORDRE DES CRITERES CODEARTICLE, CODETYPECLIENT, DATE</param>
        /// <returns></returns>
        public clsPhapararticle pvgSelectArticleAvecPrixClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            clsPhapararticle clsPhapararticle = new clsPhapararticle();
            DataSet Dataset = new DataSet();
            vapNomParametre = new string[] { "@CODEARTICLE", "@CODETYPECLIENT", "@DATE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };

            this.vapRequete = "SELECT * FROM [dbo].FC_ARTICLEPRIXACTUELTYPECLIENT (@CODEARTICLE,@CODETYPECLIENT,@DATE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsPhapararticle.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_CODECIP = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODECIP"].ToString();
                    clsPhapararticle.AR_CODEBARRE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEBARRE"].ToString();
                    clsPhapararticle.RY_CODERAYON = Dataset.Tables["TABLE"].Rows[Idx]["RY_CODERAYON"].ToString();
                    clsPhapararticle.FO_CODEFORME = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFORME"].ToString();
                    clsPhapararticle.TB_CODETABLEAU = Dataset.Tables["TABLE"].Rows[Idx]["TB_CODETABLEAU"].ToString();
                    clsPhapararticle.TA_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEARTICLE"].ToString();
                    clsPhapararticle.FA_CODEFABRICANT = Dataset.Tables["TABLE"].Rows[Idx]["FA_CODEFABRICANT"].ToString();
                    clsPhapararticle.MO_CODEMODEL = Dataset.Tables["TABLE"].Rows[Idx]["MO_CODEMODEL"].ToString();
                    clsPhapararticle.MA_CODEMARQUE = Dataset.Tables["TABLE"].Rows[Idx]["MA_CODEMARQUE"].ToString();
                    clsPhapararticle.DA_CODEDESTINATION = Dataset.Tables["TABLE"].Rows[Idx]["DA_CODEDESTINATION"].ToString();
                    clsPhapararticle.UN_CODEUNITE = Dataset.Tables["TABLE"].Rows[Idx]["UN_CODEUNITE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = Dataset.Tables["TABLE"].Rows[Idx]["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.AR_NOMSCIENTIFIQUE = Dataset.Tables["TABLE"].Rows[Idx]["AR_NOMSCIENTIFIQUE"].ToString();
                    clsPhapararticle.AR_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["AR_DESCRIPTION"].ToString();
                    clsPhapararticle.AR_CONDITIONNEMENT = Dataset.Tables["TABLE"].Rows[Idx]["AR_CONDITIONNEMENT"].ToString();
                    clsPhapararticle.AR_CONTENANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_CONTENANCE"].ToString());
                    clsPhapararticle.AR_SEUILMINI = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_SEUILMINI"].ToString());
                    clsPhapararticle.AR_SEUILMAXI = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_SEUILMAXI"].ToString());
                    clsPhapararticle.AR_RATTACHE = Dataset.Tables["TABLE"].Rows[Idx]["AR_RATTACHE"].ToString();
                    clsPhapararticle.AR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["AR_STATUT"].ToString();
                    clsPhapararticle.AR_ASDI = Dataset.Tables["TABLE"].Rows[Idx]["AR_ASDI"].ToString();
                    clsPhapararticle.AR_TVA = Dataset.Tables["TABLE"].Rows[Idx]["AR_TVA"].ToString();
                    clsPhapararticle.AR_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_DATECLOTURE"].ToString());
                    clsPhapararticle.PRIXARTICLE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PRIXARTICLE"].ToString());
                }
                Dataset.Dispose();
            }
            return clsPhapararticle;
        }

        /// <summary>
        /// Cette fonction permet de charger les accessoires d'un article avec leur prix et la quantite 
        /// </summary>
        /// <param name="vppCodeArticle"></param>
        /// <param name="vppCodeTypeClient"></param>
        /// <param name="vppDate"></param>
        /// <returns></returns>
        public List<clsPhapararticle> pvgSelectArticleAccessoireAvecPrixClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsPhapararticle> clsPhapararticles = new List<clsPhapararticle>();
            clsPhapararticle clsPhapararticle = new clsPhapararticle();
            DataSet Dataset = new DataSet();

            vapNomParametre = new string[] { "@CODEARTICLE", "@CODETYPECLIENT", "@DATE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };

            this.vapRequete = "SELECT * FROM [dbo].FC_ARTICLEACCESSOIRES (@CODEARTICLE,@CODETYPECLIENT,@DATE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsPhapararticle.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_CODECIP = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODECIP"].ToString();
                    clsPhapararticle.AR_CODEBARRE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEBARRE"].ToString();
                    clsPhapararticle.RY_CODERAYON = Dataset.Tables["TABLE"].Rows[Idx]["RY_CODERAYON"].ToString();
                    clsPhapararticle.FO_CODEFORME = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFORME"].ToString();
                    clsPhapararticle.TB_CODETABLEAU = Dataset.Tables["TABLE"].Rows[Idx]["TB_CODETABLEAU"].ToString();
                    clsPhapararticle.TA_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEARTICLE"].ToString();
                    clsPhapararticle.FA_CODEFABRICANT = Dataset.Tables["TABLE"].Rows[Idx]["FA_CODEFABRICANT"].ToString();
                    clsPhapararticle.MO_CODEMODEL = Dataset.Tables["TABLE"].Rows[Idx]["MO_CODEMODEL"].ToString();
                    clsPhapararticle.MA_CODEMARQUE = Dataset.Tables["TABLE"].Rows[Idx]["MA_CODEMARQUE"].ToString();
                    clsPhapararticle.DA_CODEDESTINATION = Dataset.Tables["TABLE"].Rows[Idx]["DA_CODEDESTINATION"].ToString();
                    clsPhapararticle.UN_CODEUNITE = Dataset.Tables["TABLE"].Rows[Idx]["UN_CODEUNITE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = Dataset.Tables["TABLE"].Rows[Idx]["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.AR_NOMSCIENTIFIQUE = Dataset.Tables["TABLE"].Rows[Idx]["AR_NOMSCIENTIFIQUE"].ToString();
                    clsPhapararticle.AR_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["AR_DESCRIPTION"].ToString();
                    clsPhapararticle.AR_CONDITIONNEMENT = Dataset.Tables["TABLE"].Rows[Idx]["AR_CONDITIONNEMENT"].ToString();
                    clsPhapararticle.AR_CONTENANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_CONTENANCE"].ToString());
                    clsPhapararticle.AR_SEUILMINI = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_SEUILMINI"].ToString());
                    clsPhapararticle.AR_SEUILMAXI = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_SEUILMAXI"].ToString());
                    clsPhapararticle.AR_RATTACHE = Dataset.Tables["TABLE"].Rows[Idx]["AR_RATTACHE"].ToString();
                    clsPhapararticle.AR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["AR_STATUT"].ToString();
                    clsPhapararticle.AR_ASDI = Dataset.Tables["TABLE"].Rows[Idx]["AR_ASDI"].ToString();
                    clsPhapararticle.AR_TVA = Dataset.Tables["TABLE"].Rows[Idx]["AR_TVA"].ToString();
                    clsPhapararticle.AR_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_DATECLOTURE"].ToString());
                    clsPhapararticle.PRIXARTICLE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PRIXARTICLE"].ToString());
                    clsPhapararticles.Add(clsPhapararticle);
                }
                Dataset.Dispose();
            }

            return clsPhapararticles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">ORDRE DE CRITERE "@CODEARTICLE", "@CODETYPEFOURNISSEUR", "@DATE"</param>
        /// <returns></returns>
        public clsPhapararticle pvgSelectArticleAvecPrixFournisseur(clsDonnee clsDonnee,params string[] vppCritere )
        {
            clsPhapararticle clsPhapararticle = new clsPhapararticle();
            DataSet Dataset = new DataSet();
            vapNomParametre = new string[] { "@CODEARTICLE", "@TYPEMONTANT", "@DATE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1],vppCritere[2],  clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT * FROM [dbo].FC_ARTICLEPRIXACTUELTYPEFOURNISSEUR (@CODEARTICLE,@TYPEMONTANT, @DATE,@CODECRYPTAGE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsPhapararticle.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_CODECIP = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODECIP"].ToString();
                    clsPhapararticle.AR_CODEBARRE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEBARRE"].ToString();
                    clsPhapararticle.RY_CODERAYON = Dataset.Tables["TABLE"].Rows[Idx]["RY_CODERAYON"].ToString();
                    clsPhapararticle.FO_CODEFORME = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFORME"].ToString();
                    clsPhapararticle.TB_CODETABLEAU = Dataset.Tables["TABLE"].Rows[Idx]["TB_CODETABLEAU"].ToString();
                    clsPhapararticle.TA_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEARTICLE"].ToString();
                    clsPhapararticle.FA_CODEFABRICANT = Dataset.Tables["TABLE"].Rows[Idx]["FA_CODEFABRICANT"].ToString();
                    clsPhapararticle.MO_CODEMODEL = Dataset.Tables["TABLE"].Rows[Idx]["MO_CODEMODEL"].ToString();
                    clsPhapararticle.MA_CODEMARQUE = Dataset.Tables["TABLE"].Rows[Idx]["MA_CODEMARQUE"].ToString();
                    clsPhapararticle.DA_CODEDESTINATION = Dataset.Tables["TABLE"].Rows[Idx]["DA_CODEDESTINATION"].ToString();
                    clsPhapararticle.UN_CODEUNITE = Dataset.Tables["TABLE"].Rows[Idx]["UN_CODEUNITE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = Dataset.Tables["TABLE"].Rows[Idx]["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.AR_NOMSCIENTIFIQUE = Dataset.Tables["TABLE"].Rows[Idx]["AR_NOMSCIENTIFIQUE"].ToString();
                    clsPhapararticle.AR_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["AR_DESCRIPTION"].ToString();
                    clsPhapararticle.AR_CONDITIONNEMENT = Dataset.Tables["TABLE"].Rows[Idx]["AR_CONDITIONNEMENT"].ToString();
                    clsPhapararticle.AR_CONTENANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_CONTENANCE"].ToString());
                    clsPhapararticle.AR_SEUILMINI = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_SEUILMINI"].ToString());
                    clsPhapararticle.AR_SEUILMAXI = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_SEUILMAXI"].ToString());
                    clsPhapararticle.AR_RATTACHE = Dataset.Tables["TABLE"].Rows[Idx]["AR_RATTACHE"].ToString();
                    clsPhapararticle.AR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["AR_STATUT"].ToString();
                    clsPhapararticle.AR_ASDI = Dataset.Tables["TABLE"].Rows[Idx]["AR_ASDI"].ToString();
                    clsPhapararticle.AR_TVA = Dataset.Tables["TABLE"].Rows[Idx]["AR_TVA"].ToString();
                    clsPhapararticle.AR_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_DATECLOTURE"].ToString());
                    clsPhapararticle.PRIXARTICLE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PRIXARTICLE"].ToString());
                }
                Dataset.Dispose();
            }
            return clsPhapararticle;
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AR_CODEARTICLE , AR_CODECIP FROM dbo.PHAPARARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboSelonType(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE ";
            vapNomParametre = new string[] { "@TA_CODETYPEARTICLE" };
            vapValeurParametre = new object[] { vppCritere[0] };
            this.vapRequete = "SELECT AR_CODEARTICLE , AR_NOMCOMMERCIALE FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE) " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }




        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboProduitFini(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE AND IN_CODETYPEARTICLE LIKE '%'+@IN_CODETYPEARTICLE+'%' ";
            vapNomParametre = new string[] { "@TA_CODETYPEARTICLE", "@IN_CODETYPEARTICLE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0],vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT AR_CODEARTICLE,AR_NOMCOMMERCIALE  FROM dbo.FT_PHAPARARTICLE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY AR_NUMEROORDRE,AR_NOMCOMMERCIALE ";
        this.vapCritere = "";
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMatierePremiere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //this.vapCritere = "WHERE IN_CODETYPEARTICLE LIKE '%'+@IN_CODETYPEARTICLE+'%' ";
            vapNomParametre = new string[] { "@AR_CODEARTICLE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAPARMATIEREPREMIERE @AR_CODEARTICLE,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMatierePremiereFabrication(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //this.vapCritere = "WHERE IN_CODETYPEARTICLE LIKE '%'+@IN_CODETYPEARTICLE+'%' ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@AR_CODEARTICLE", "@DATE", "@EN_CODEENTREPOT", "@MF_IDFILTRAGEDESTOCK", "@ME_IDFILTRAGEDESTOCKEXPIRATION", "@MF_IDFILTRAGEDESTOCKM1", "@MF_IDFILTRAGEDESTOCKM2", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0],vppCritere[1].Replace("''", "'"), vppCritere[2],vppCritere[3],vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAPARMATIEREPREMIERE1 @AG_CODEAGENCE,@AR_CODEARTICLE,@DATE,@EN_CODEENTREPOT,@MF_IDFILTRAGEDESTOCK,@ME_IDFILTRAGEDESTOCKEXPIRATION,@MF_IDFILTRAGEDESTOCKM1,@MF_IDFILTRAGEDESTOCKM2,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMatierePremiereChargement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //this.vapCritere = "WHERE IN_CODETYPEARTICLE LIKE '%'+@IN_CODETYPEARTICLE+'%' ";
            vapNomParametre = new string[] { "@IN_CODETYPEARTICLE", "@TA_CODETYPEARTICLE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"),vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAPARMATIEREPREMIERECHARGEMENT @IN_CODETYPEARTICLE,@TA_CODETYPEARTICLE,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetAevcPrix(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //this.vapCritere = "WHERE IN_CODETYPEARTICLE LIKE '%'+@IN_CODETYPEARTICLE+'%' ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@NT_CODENATURETYPEARTICLE", "@TA_CODETYPEARTICLE", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@MA_CODEMARQUE", "@AR_STATUT", "@NT_CODENATURETIERS", "@TYPEMONTANT", "@DATEJOURNEE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1].Replace("''", "'"), vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9],vppCritere[10], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAPARARTICLE @AG_CODEAGENCE,@EN_CODEENTREPOT,@NT_CODENATURETYPEARTICLE,@TA_CODETYPEARTICLE,@AR_CODECIP,@AR_NOMCOMMERCIALE,@MA_CODEMARQUE,@AR_STATUT,@NT_CODENATURETIERS,@TYPEMONTANT,@DATEJOURNEE,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //this.vapCritere = "WHERE IN_CODETYPEARTICLE LIKE '%'+@IN_CODETYPEARTICLE+'%' ";
            vapNomParametre = new string[] { "@TA_CODETYPEARTICLE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAPARARTICLECHARGEMENT @TA_CODETYPEARTICLE,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public void pvgClotureArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@AR_CODEARTICLE", "@DATEJOURNEE", "@EN_CODEENTREPOT" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2],vppCritere[3],   clsDonnee.vogCleCryptage };
            //Préparation de la commande
            this.vapRequete = " EXECUTE dbo.PS_CLOTUREARTICLE @AG_CODEAGENCE,@AR_CODEARTICLE,@DATEJOURNEE,@EN_CODEENTREPOT";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }



        private List<clsPhapararticle> pvgSelectGenerique(clsDonnee clsDonnee,  params string[] vppCritere)
        {
            this.vapRequete = "SELECT  AR_CODEARTICLE, AR_CODECIP, AR_CODEBARRE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_NOMCOMMERCIALE, AR_NOMSCIENTIFIQUE, AR_DESCRIPTION, AR_CONDITIONNEMENT, AR_CONTENANCE, AR_SEUILMINI, AR_SEUILMAXI, AR_RATTACHE, AR_STATUT, AR_ASDI, AR_TVA, AR_DUREEGARANTIE, AR_DATECLOTURE, AR_REPORTSORTIE, AR_REPORTENTREE, AR_NOMBREPERIODEPRECEDENTSORTIE, AR_NOMBREPERIODEPRECEDENTENTREE, AR_NOMBREPERIODESORTIEENCOURS, AR_NOMBREPERIODEENTREEENCOURS, AR_NOMBRESTOCKFINALSORTIE, AR_NOMBRESTOCKFINALENTREE, AR_QUANTIFIABLE FROM dbo.PHAPARARTICLE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsPhapararticle> clsPhapararticles = new List<clsPhapararticle>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPhapararticle clsPhapararticle = new clsPhapararticle();
                    clsPhapararticle.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPhapararticle.AR_CODECIP = clsDonnee.vogDataReader["AR_CODECIP"].ToString();
                    clsPhapararticle.AR_CODEBARRE = clsDonnee.vogDataReader["AR_CODEBARRE"].ToString();
                    clsPhapararticle.RY_CODERAYON = clsDonnee.vogDataReader["RY_CODERAYON"].ToString();
                    clsPhapararticle.FO_CODEFORME = clsDonnee.vogDataReader["FO_CODEFORME"].ToString();
                    clsPhapararticle.TB_CODETABLEAU = clsDonnee.vogDataReader["TB_CODETABLEAU"].ToString();
                    clsPhapararticle.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
                    clsPhapararticle.FA_CODEFABRICANT = clsDonnee.vogDataReader["FA_CODEFABRICANT"].ToString();
                    clsPhapararticle.MO_CODEMODEL = clsDonnee.vogDataReader["MO_CODEMODEL"].ToString();
                    clsPhapararticle.MA_CODEMARQUE = clsDonnee.vogDataReader["MA_CODEMARQUE"].ToString();
                    clsPhapararticle.DA_CODEDESTINATION = clsDonnee.vogDataReader["DA_CODEDESTINATION"].ToString();
                    clsPhapararticle.UN_CODEUNITE = clsDonnee.vogDataReader["UN_CODEUNITE"].ToString();
                    clsPhapararticle.AR_NOMCOMMERCIALE = clsDonnee.vogDataReader["AR_NOMCOMMERCIALE"].ToString();
                    clsPhapararticle.AR_NOMSCIENTIFIQUE = clsDonnee.vogDataReader["AR_NOMSCIENTIFIQUE"].ToString();
                    clsPhapararticle.AR_DESCRIPTION = clsDonnee.vogDataReader["AR_DESCRIPTION"].ToString();
                    clsPhapararticle.AR_CONDITIONNEMENT = clsDonnee.vogDataReader["AR_CONDITIONNEMENT"].ToString();
                    clsPhapararticle.AR_CONTENANCE = double.Parse(clsDonnee.vogDataReader["AR_CONTENANCE"].ToString());
                    clsPhapararticle.AR_SEUILMINI = int.Parse(clsDonnee.vogDataReader["AR_SEUILMINI"].ToString());
                    clsPhapararticle.AR_SEUILMAXI = int.Parse(clsDonnee.vogDataReader["AR_SEUILMAXI"].ToString());
                    clsPhapararticle.AR_RATTACHE = clsDonnee.vogDataReader["AR_RATTACHE"].ToString();
                    clsPhapararticle.AR_STATUT = clsDonnee.vogDataReader["AR_STATUT"].ToString();
                    clsPhapararticle.AR_ASDI = clsDonnee.vogDataReader["AR_ASDI"].ToString();
                    clsPhapararticle.AR_TVA = clsDonnee.vogDataReader["AR_TVA"].ToString();
                    clsPhapararticle.AR_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AR_DATECLOTURE"].ToString());
                    clsPhapararticle.AR_DUREEGARANTIE = int.Parse(clsDonnee.vogDataReader["AR_DUREEGARANTIE"].ToString());
                    clsPhapararticles.Add(clsPhapararticle);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPhapararticles;
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = "";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
                this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE ";
				vapNomParametre = new string[]{"@AR_CODEARTICLE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE AND AR_CODECIP =@AR_CODECIP ";
                vapNomParametre = new string[] { "@AR_CODEARTICLE", "@AR_CODECIP" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE AND AR_CODECIP=@AR_CODECIP AND AR_CODEBARRE=@AR_CODEBARRE ";
                vapNomParametre = new string[] { "@AR_CODEARTICLE", "@AR_CODECIP", "@AR_CODEBARRE" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
				break;

			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE"};
                    vapValeurParametre = new object[] {clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE AND AR_CODECIP =@AR_CODECIP ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE", "@AR_CODECIP" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE AND AR_CODECIP=@AR_CODECIP AND AR_CODEBARRE=@AR_CODEBARRE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE", "@AR_CODECIP", "@AR_CODEBARRE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = " WHERE  AR_CODEARTICLE LIKE '%'+ @AR_CODEARTICLE +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND ISNULL(AR_CODEBARRE,'') LIKE '%'+ @AR_CODEBARRE +'%' AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%'  AND AR_DATECLOTURE='01/01/1900' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE", "@AR_CODECIP", "@AR_CODEBARRE", "@TA_CODETYPEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3]};
                    break;

            }
        }
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = "ORDER BY AR_NUMEROORDRE";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage};
				break;
				case 1 :
                this.vapCritere = "WHERE AR_CODECIP=@AR_CODECIP ORDER BY AR_NUMEROORDRE";
                vapNomParametre = new string[] {"@CODECRYPTAGE" , "@AR_CODECIP" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AR_CODECIP=@AR_CODECIP AND AR_CODEBARRE=@AR_CODEBARRE ORDER BY AR_NUMEROORDRE";
                vapNomParametre = new string[] {"@CODECRYPTAGE" ,  "@AR_CODECIP", "@AR_CODEBARRE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;

			}
		}
        public void pvpChoixCritereRecherche(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = "ORDER BY AR_NUMEROORDRE";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
				break;
				case 1 :
                this.vapCritere = "WHERE AR_CODEARTICLE LIKE '%'+ @AR_CODEARTICLE +'%' ORDER BY AR_NUMEROORDRE ";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AR_CODEARTICLE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AR_CODEARTICLE LIKE '%'+ @AR_CODEARTICLE +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' ORDER BY AR_NUMEROORDRE ";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AR_CODEARTICLE", "@AR_NOMCOMMERCIALE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;
			}
		}
		public void pvpChoixCritereRechercheDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = "WHERE AR_QUANTIFIABLE  ='O' AND AR_DATECLOTURE='01/01/1900'  ";
                     vapNomParametre = new string[] { "@CODECRYPTAGE" };
                     vapValeurParametre = new object[] { clsDonnee.vogCleCryptage};
				break;
				case 1 :
                this.vapCritere = "WHERE AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_QUANTIFIABLE  ='O' AND AR_DATECLOTURE='01/01/1900' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AR_STATUT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = " WHERE AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_QUANTIFIABLE  ='O' AND AR_DATECLOTURE='01/01/1900'  ";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AR_STATUT", "@AR_CODECIP" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = " WHERE AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%'  AND AR_DATECLOTURE='01/01/1900'";//AND AR_QUANTIFIABLE  ='O'  
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
				break;
				case 4 :
                this.vapCritere = " WHERE AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' AND AR_DATECLOTURE='01/01/1900' " +
                                  "  AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND AR_QUANTIFIABLE  ='O'  ";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@MA_CODEMARQUE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
				break;
				case 5 :
                this.vapCritere = " WHERE AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' AND AR_DATECLOTURE='01/01/1900' " +
                                  " AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%'  ";
                vapNomParametre = new string[] {"@CODECRYPTAGE", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE" , "@MA_CODEMARQUE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
				break;


                case 6 :
                this.vapCritere = " WHERE AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' "+
                                    " AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND NT_CODENATURETYPEARTICLE IN(" + clsDonnee.pvpParametreIN(vppCritere[5], "NT_CODENATURETYPEARTICLE") + ") AND AR_DATECLOTURE='01/01/1900' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE", "@MA_CODEMARQUE", "@NT_CODENATURETYPEARTICLE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[5], 6, "NT_CODENATURETYPEARTICLE");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 6, "NT_CODENATURETYPEARTICLE");
                break;





                case 8:
                this.vapCritere = " WHERE NT_CODENATURETIERS LIKE '%'+ @NT_CODENATURETIERS +'%' AND AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND   ISNULL(AR_CODECIP,'')  LIKE '%'+ @AR_CODECIP +'%' AND ISNULL(AR_NOMCOMMERCIALE,'')    LIKE '%'+ @AR_NOMCOMMERCIALE +'%' " +
                                  " AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND ISNULL(MO_CODEMODEL,'') LIKE '%'+ @MO_CODEMODEL + '%'   AND ISNULL(RY_CODERAYON,'') LIKE '%'+ @RY_CODERAYON + '%'  AND AR_QUANTIFIABLE  ='O' AND AR_DATECLOTURE='01/01/1900' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@NT_CODENATURETIERS", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@MA_CODEMARQUE", "@TA_CODETYPEARTICLE", "@MO_CODEMODEL", "@RY_CODERAYON" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] };
                break;

				case 9 :
                this.vapCritere = " WHERE  AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' " +
                                  " AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(MO_CODEMODEL,'') LIKE '%'+ @MO_CODEMODEL + '%'  " +
                                  " AND ISNULL(FO_CODEFORME,'') LIKE '%'+ @FO_CODEFORME + '%' AND ISNULL(FA_CODEFABRICANT,'') LIKE '%'+ @FA_CODEFABRICANT + '%' AND ISNULL(RY_CODERAYON,'') LIKE '%'+ @RY_CODERAYON + '%' AND AR_QUANTIFIABLE ='O' AND AR_DATECLOTURE='01/01/1900' ";
                vapNomParametre = new string[] {"@CODECRYPTAGE", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE", "@MA_CODEMARQUE", "@MO_CODEMODEL", "@FO_CODEFORME", "@FA_CODEFABRICANT", "@RY_CODERAYON" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8] };
				break;

                case 10:
                this.vapCritere = " WHERE  AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' " +
                                  " AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(MO_CODEMODEL,'') LIKE '%'+ @MO_CODEMODEL + '%'  " +
                                  " AND ISNULL(FO_CODEFORME,'') LIKE '%'+ @FO_CODEFORME + '%' AND ISNULL(FA_CODEFABRICANT,'') LIKE '%'+ @FA_CODEFABRICANT + '%' AND ISNULL(RY_CODERAYON,'') LIKE '%'+ @RY_CODERAYON + '%' AND AR_QUANTIFIABLE ='O' AND AR_DATECREATION=@DATEDEBUT  AND AR_DATECLOTURE='01/01/1900' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE", "@MA_CODEMARQUE", "@MO_CODEMODEL", "@FO_CODEFORME", "@FA_CODEFABRICANT", "@RY_CODERAYON", "@DATEDEBUT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9] };
                break;
                case 11:
                this.vapCritere = " WHERE  AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' " +
                                  " AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(MO_CODEMODEL,'') LIKE '%'+ @MO_CODEMODEL + '%'  " +
                                  " AND ISNULL(FO_CODEFORME,'') LIKE '%'+ @FO_CODEFORME + '%' AND ISNULL(FA_CODEFABRICANT,'') LIKE '%'+ @FA_CODEFABRICANT + '%' AND ISNULL(RY_CODERAYON,'') LIKE '%'+ @RY_CODERAYON + '%' AND AR_QUANTIFIABLE ='O' AND AR_DATECREATION BETWEEN @DATEDEBUT AND @DATEFIN AND AR_DATECLOTURE='01/01/1900' ";
                vapNomParametre = new string[] {"@CODECRYPTAGE", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE", "@MA_CODEMARQUE", "@MO_CODEMODEL", "@FO_CODEFORME", "@FA_CODEFABRICANT", "@RY_CODERAYON", "@DATEDEBUT", "@DATEFIN" };
                vapValeurParametre = new object[] {clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8] , vppCritere[9], vppCritere[10] };
                break;

                case 12:
                if (vppCritere[11] == "03")
                {
                    this.vapCritere = " WHERE  AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' " +
                                        " AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(MO_CODEMODEL,'') LIKE '%'+ @MO_CODEMODEL + '%'  " +
                                        " AND ISNULL(FO_CODEFORME,'') LIKE '%'+ @FO_CODEFORME + '%' AND ISNULL(FA_CODEFABRICANT,'') LIKE '%'+ @FA_CODEFABRICANT + '%' AND ISNULL(RY_CODERAYON,'') LIKE '%'+ @RY_CODERAYON + '%' AND AR_QUANTIFIABLE ='O' AND AR_DATECREATION BETWEEN @DATEDEBUT AND @DATEFIN AND NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE AND AR_DATECLOTURE='01/01/1900'  ";
                }
                else 
                {
                    vppCritere[11] = "03";
                    this.vapCritere = " WHERE  AR_STATUT LIKE '%'+ @AR_STATUT +'%' AND AR_CODECIP  LIKE '%'+ @AR_CODECIP +'%' AND AR_NOMCOMMERCIALE  LIKE '%'+ @AR_NOMCOMMERCIALE +'%' " +
                                                            " AND ISNULL(TA_CODETYPEARTICLE,'') LIKE '%'+ @TA_CODETYPEARTICLE + '%' AND ISNULL(MA_CODEMARQUE,'') LIKE '%'+ @MA_CODEMARQUE + '%' AND ISNULL(MO_CODEMODEL,'') LIKE '%'+ @MO_CODEMODEL + '%'  " +
                                                            " AND ISNULL(FO_CODEFORME,'') LIKE '%'+ @FO_CODEFORME + '%' AND ISNULL(FA_CODEFABRICANT,'') LIKE '%'+ @FA_CODEFABRICANT + '%' AND ISNULL(RY_CODERAYON,'') LIKE '%'+ @RY_CODERAYON + '%' AND AR_QUANTIFIABLE ='O' AND AR_DATECREATION BETWEEN @DATEDEBUT AND @DATEFIN AND NT_CODENATURETYPEARTICLE<>@NT_CODENATURETYPEARTICLE AND AR_DATECLOTURE='01/01/1900'  ";
                }
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_STATUT", "@AR_CODECIP", "@AR_NOMCOMMERCIALE", "@TA_CODETYPEARTICLE", "@MA_CODEMARQUE", "@MO_CODEMODEL", "@FO_CODEFORME", "@FA_CODEFABRICANT", "@RY_CODERAYON", "@DATEDEBUT", "@DATEFIN", "@NT_CODENATURETYPEARTICLE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11] };
                break;


			}

		}






	}
}
