using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsLogicielobjettypeschemacomptableprofilwebWSDAL: ITableDAL<clsLogicielobjettypeschemacomptableprofilweb>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_Logicielobjettypeschemacomptableprofilweb2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_Logicielobjettypeschemacomptableprofilweb2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_Logicielobjettypeschemacomptableprofilweb2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsLogicielobjettypeschemacomptableprofilweb comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsLogicielobjettypeschemacomptableprofilweb pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT LB_ACTIF  FROM dbo.FT_Logicielobjettypeschemacomptableprofilweb2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new clsLogicielobjettypeschemacomptableprofilweb();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjettypeschemacomptableprofilweb.LB_ACTIF = clsDonnee.vogDataReader["LB_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsLogicielobjettypeschemacomptableprofilweb;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjettypeschemacomptableprofilweb>clsLogicielobjettypeschemacomptableprofilweb</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE ;
			SqlParameter vppParamPO_CODEPROFILWEB = new SqlParameter("@PO_CODEPROFILWEB1", SqlDbType.VarChar, 50);
			vppParamPO_CODEPROFILWEB.Value  = clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB ;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNO_CODENATUREOPERATION.Value  = clsLogicielobjettypeschemacomptableprofilweb.NO_CODENATUREOPERATION ;


			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION1", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION ;

			SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION1", SqlDbType.VarChar, 2);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsLogicielobjettypeschemacomptableprofilweb.NF_CODENATUREFAMILLEOPERATION;


			SqlParameter vppParamLB_ACTIF = new SqlParameter("@LB_ACTIF", SqlDbType.VarChar, 1);
			vppParamLB_ACTIF.Value  = clsLogicielobjettypeschemacomptableprofilweb.LB_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_Logicielobjettypeschemacomptableprofilweb  @AG_CODEAGENCE1, @PO_CODEPROFILWEB1, @NO_CODENATUREOPERATION, @FO_CODEFAMILLEOPERATION1, @LB_ACTIF, @NF_CODENATUREFAMILLEOPERATION1, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFILWEB);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamLB_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjettypeschemacomptableprofilweb>clsLogicielobjettypeschemacomptableprofilweb</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE ;
			SqlParameter vppParamPO_CODEPROFILWEB = new SqlParameter("@PO_CODEPROFILWEB", SqlDbType.VarChar, 50);
			vppParamPO_CODEPROFILWEB.Value  = clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB ;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNO_CODENATUREOPERATION.Value  = clsLogicielobjettypeschemacomptableprofilweb.NO_CODENATUREOPERATION ;
			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION ;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 2);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsLogicielobjettypeschemacomptableprofilweb.NF_CODENATUREFAMILLEOPERATION;

			SqlParameter vppParamLB_ACTIF = new SqlParameter("@LB_ACTIF", SqlDbType.VarChar, 1);
			vppParamLB_ACTIF.Value  = clsLogicielobjettypeschemacomptableprofilweb.LB_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_Logicielobjettypeschemacomptableprofilweb2  @AG_CODEAGENCE, @PO_CODEPROFILWEB, @NO_CODENATUREOPERATION, @FO_CODEFAMILLEOPERATION, @LB_ACTIF,@NF_CODENATUREFAMILLEOPERATION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFILWEB);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);

			vppSqlCmd.Parameters.Add(vppParamLB_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_Logicielobjettypeschemacomptableprofilweb  @AG_CODEAGENCE, @PO_CODEPROFILWEB, '', @FO_CODEFAMILLEOPERATION, '' ,@NF_CODENATUREFAMILLEOPERATION, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeschemacomptableprofilweb </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeschemacomptableprofilweb> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION, LB_ACTIF FROM dbo.FT_Logicielobjettypeschemacomptableprofilweb2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<clsLogicielobjettypeschemacomptableprofilweb>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new clsLogicielobjettypeschemacomptableprofilweb();
					clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB = clsDonnee.vogDataReader["PO_CODEPROFILWEB"].ToString();
					clsLogicielobjettypeschemacomptableprofilweb.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_CODEFAMILLEOPERATION"].ToString();
					clsLogicielobjettypeschemacomptableprofilweb.LB_ACTIF = clsDonnee.vogDataReader["LB_ACTIF"].ToString();
					clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsLogicielobjettypeschemacomptableprofilwebs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeschemacomptableprofilweb </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeschemacomptableprofilweb> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsLogicielobjettypeschemacomptableprofilweb> clsLogicielobjettypeschemacomptableprofilwebs = new List<clsLogicielobjettypeschemacomptableprofilweb>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION, LB_ACTIF FROM dbo.FT_Logicielobjettypeschemacomptableprofilweb2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsLogicielobjettypeschemacomptableprofilweb clsLogicielobjettypeschemacomptableprofilweb = new clsLogicielobjettypeschemacomptableprofilweb();
					clsLogicielobjettypeschemacomptableprofilweb.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsLogicielobjettypeschemacomptableprofilweb.PO_CODEPROFILWEB = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFILWEB"].ToString();
					clsLogicielobjettypeschemacomptableprofilweb.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsLogicielobjettypeschemacomptableprofilweb.FO_CODEFAMILLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFAMILLEOPERATION"].ToString();
					clsLogicielobjettypeschemacomptableprofilweb.LB_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["LB_ACTIF"].ToString();
					clsLogicielobjettypeschemacomptableprofilwebs.Add(clsLogicielobjettypeschemacomptableprofilweb);
				}
				Dataset.Dispose();
			}
		return clsLogicielobjettypeschemacomptableprofilwebs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_Logicielobjettypeschemacomptableprofilweb2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , LB_ACTIF FROM dbo.FT_Logicielobjettypeschemacomptableprofilweb2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFILWEB, FO_CODEFAMILLEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurDroit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION", "@PO_CODEPROFILWEB" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] };
            this.vapRequete = "SELECT * FROM dbo.FT_LogicielobjettypeschemacomptableprofilwebDROIT(@AG_CODEAGENCE,@NF_CODENATUREFAMILLEOPERATION,@FO_CODEFAMILLEOPERATION ,@PO_CODEPROFILWEB)  ORDER BY NO_NUMEROORDRE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, PO_CODEPROFILWEB, NO_CODENATUREOPERATION, FO_CODEFAMILLEOPERATION)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFILWEB=@PO_CODEPROFILWEB";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFILWEB"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;


                case 3 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFILWEB=@PO_CODEPROFILWEB AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFILWEB", "@NF_CODENATUREFAMILLEOPERATION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;

                case 4 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFILWEB=@PO_CODEPROFILWEB AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION AND FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION ";
                vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFILWEB", "@NF_CODENATUREFAMILLEOPERATION" , "@FO_CODEFAMILLEOPERATION" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
                break;

                case 5 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFILWEB=@PO_CODEPROFILWEB AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION AND FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFILWEB", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION", "@NO_CODENATUREOPERATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFILWEB=@PO_CODEPROFILWEB AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFILWEB","@NO_CODENATUREOPERATION","@FO_CODEFAMILLEOPERATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
