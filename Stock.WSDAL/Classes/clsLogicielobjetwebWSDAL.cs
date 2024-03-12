using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsLogicielobjetwebWSDAL: ITableDAL<clsLogicielobjetweb>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(OB_CODEOBJET) AS OB_CODEOBJET  FROM dbo.FT_LOGICIELOBJET(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(OB_CODEOBJET) AS OB_CODEOBJET  FROM dbo.FT_LOGICIELOBJET(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(OB_CODEOBJET) AS OB_CODEOBJET  FROM dbo.FT_LOGICIELOBJET(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsLogicielobjetweb comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsLogicielobjetweb pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT OT_CODETYPEOBJET  , OB_NOMOBJET  , LO_CODELOGICIEL  , OB_LIBELLE  , OB_STATUT  , OB_RATTACHEA  FROM dbo.FT_LOGICIELOBJET(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsLogicielobjetweb clsLogicielobjetweb = new clsLogicielobjetweb();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjetweb.OT_CODETYPEOBJET = clsDonnee.vogDataReader["OT_CODETYPEOBJET"].ToString();
					clsLogicielobjetweb.OB_NOMOBJET = clsDonnee.vogDataReader["OB_NOMOBJET"].ToString();
					clsLogicielobjetweb.LO_CODELOGICIEL = clsDonnee.vogDataReader["LO_CODELOGICIEL"].ToString();
					clsLogicielobjetweb.OB_LIBELLE = clsDonnee.vogDataReader["OB_LIBELLE"].ToString();
					clsLogicielobjetweb.OB_STATUT = clsDonnee.vogDataReader["OB_STATUT"].ToString();
					clsLogicielobjetweb.OB_RATTACHEA = int.Parse(clsDonnee.vogDataReader["OB_RATTACHEA"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsLogicielobjetweb;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjetweb>clsLogicielobjetweb</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsLogicielobjetweb clsLogicielobjetweb)
		{
			//Préparation des paramètres
			SqlParameter vppParamOT_CODETYPEOBJET = new SqlParameter("@OT_CODETYPEOBJET", SqlDbType.VarChar, 25);
			vppParamOT_CODETYPEOBJET.Value  = clsLogicielobjetweb.OT_CODETYPEOBJET ;
			SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.VarChar, 25);
			vppParamOB_CODEOBJET.Value  = clsLogicielobjetweb.OB_CODEOBJET ;
			SqlParameter vppParamOB_NOMOBJET = new SqlParameter("@OB_NOMOBJET", SqlDbType.VarChar, 150);
			vppParamOB_NOMOBJET.Value  = clsLogicielobjetweb.OB_NOMOBJET ;
			SqlParameter vppParamLO_CODELOGICIEL = new SqlParameter("@LO_CODELOGICIEL", SqlDbType.VarChar, 25);
			vppParamLO_CODELOGICIEL.Value  = clsLogicielobjetweb.LO_CODELOGICIEL ;
			SqlParameter vppParamOB_LIBELLE = new SqlParameter("@OB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamOB_LIBELLE.Value  = clsLogicielobjetweb.OB_LIBELLE ;
			SqlParameter vppParamOB_STATUT = new SqlParameter("@OB_STATUT", SqlDbType.VarChar, 1);
			vppParamOB_STATUT.Value  = clsLogicielobjetweb.OB_STATUT ;
			SqlParameter vppParamOB_RATTACHEA = new SqlParameter("@OB_RATTACHEA", SqlDbType.Int);
			vppParamOB_RATTACHEA.Value  = clsLogicielobjetweb.OB_RATTACHEA ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJET  @OT_CODETYPEOBJET, @OB_CODEOBJET, @OB_NOMOBJET, @LO_CODELOGICIEL, @OB_LIBELLE, @OB_STATUT, @OB_RATTACHEA, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOT_CODETYPEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOB_NOMOBJET);
			vppSqlCmd.Parameters.Add(vppParamLO_CODELOGICIEL);
			vppSqlCmd.Parameters.Add(vppParamOB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamOB_STATUT);
			vppSqlCmd.Parameters.Add(vppParamOB_RATTACHEA);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjetweb>clsLogicielobjetweb</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsLogicielobjetweb clsLogicielobjetweb,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamOT_CODETYPEOBJET = new SqlParameter("@OT_CODETYPEOBJET", SqlDbType.VarChar, 25);
			vppParamOT_CODETYPEOBJET.Value  = clsLogicielobjetweb.OT_CODETYPEOBJET ;
			SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.VarChar, 25);
			vppParamOB_CODEOBJET.Value  = clsLogicielobjetweb.OB_CODEOBJET ;
			SqlParameter vppParamOB_NOMOBJET = new SqlParameter("@OB_NOMOBJET", SqlDbType.VarChar, 150);
			vppParamOB_NOMOBJET.Value  = clsLogicielobjetweb.OB_NOMOBJET ;
			SqlParameter vppParamLO_CODELOGICIEL = new SqlParameter("@LO_CODELOGICIEL", SqlDbType.VarChar, 25);
			vppParamLO_CODELOGICIEL.Value  = clsLogicielobjetweb.LO_CODELOGICIEL ;
			SqlParameter vppParamOB_LIBELLE = new SqlParameter("@OB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamOB_LIBELLE.Value  = clsLogicielobjetweb.OB_LIBELLE ;
			SqlParameter vppParamOB_STATUT = new SqlParameter("@OB_STATUT", SqlDbType.VarChar, 1);
			vppParamOB_STATUT.Value  = clsLogicielobjetweb.OB_STATUT ;
			SqlParameter vppParamOB_RATTACHEA = new SqlParameter("@OB_RATTACHEA", SqlDbType.Int);
			vppParamOB_RATTACHEA.Value  = clsLogicielobjetweb.OB_RATTACHEA ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJET  @OT_CODETYPEOBJET, @OB_CODEOBJET, @OB_NOMOBJET, @LO_CODELOGICIEL, @OB_LIBELLE, @OB_STATUT, @OB_RATTACHEA, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOT_CODETYPEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOB_NOMOBJET);
			vppSqlCmd.Parameters.Add(vppParamLO_CODELOGICIEL);
			vppSqlCmd.Parameters.Add(vppParamOB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamOB_STATUT);
			vppSqlCmd.Parameters.Add(vppParamOB_RATTACHEA);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            SqlParameter vppParamOT_CODETYPEOBJET = new SqlParameter("@OT_CODETYPEOBJET", SqlDbType.VarChar, 25);
            vppParamOT_CODETYPEOBJET.Value = 1;

            SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.VarChar, 25);
            vppParamOB_CODEOBJET.Value = 1;
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJET  @OT_CODETYPEOBJET, @OB_CODEOBJET, '' , '' , '' , '' , 1, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            vppSqlCmd.Parameters.Add(vppParamOT_CODETYPEOBJET);
            vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjetweb </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjetweb> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  OT_CODETYPEOBJET, OB_CODEOBJET, OB_NOMOBJET, LO_CODELOGICIEL, OB_LIBELLE, OB_STATUT, OB_RATTACHEA FROM dbo.FT_LOGICIELOBJET(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsLogicielobjetweb> clsLogicielobjetwebs = new List<clsLogicielobjetweb>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjetweb clsLogicielobjetweb = new clsLogicielobjetweb();
					clsLogicielobjetweb.OT_CODETYPEOBJET = clsDonnee.vogDataReader["OT_CODETYPEOBJET"].ToString();
					clsLogicielobjetweb.OB_CODEOBJET = clsDonnee.vogDataReader["OB_CODEOBJET"].ToString();
					clsLogicielobjetweb.OB_NOMOBJET = clsDonnee.vogDataReader["OB_NOMOBJET"].ToString();
					clsLogicielobjetweb.LO_CODELOGICIEL = clsDonnee.vogDataReader["LO_CODELOGICIEL"].ToString();
					clsLogicielobjetweb.OB_LIBELLE = clsDonnee.vogDataReader["OB_LIBELLE"].ToString();
					clsLogicielobjetweb.OB_STATUT = clsDonnee.vogDataReader["OB_STATUT"].ToString();
					clsLogicielobjetweb.OB_RATTACHEA = int.Parse(clsDonnee.vogDataReader["OB_RATTACHEA"].ToString());
					clsLogicielobjetwebs.Add(clsLogicielobjetweb);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsLogicielobjetwebs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjetweb </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjetweb> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsLogicielobjetweb> clsLogicielobjetwebs = new List<clsLogicielobjetweb>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  OT_CODETYPEOBJET, OB_CODEOBJET, OB_NOMOBJET, LO_CODELOGICIEL, OB_LIBELLE, OB_STATUT, OB_RATTACHEA FROM dbo.FT_LOGICIELOBJET(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsLogicielobjetweb clsLogicielobjetweb = new clsLogicielobjetweb();
					clsLogicielobjetweb.OT_CODETYPEOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OT_CODETYPEOBJET"].ToString();
					clsLogicielobjetweb.OB_CODEOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OB_CODEOBJET"].ToString();
					clsLogicielobjetweb.OB_NOMOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OB_NOMOBJET"].ToString();
					clsLogicielobjetweb.LO_CODELOGICIEL = Dataset.Tables["TABLE"].Rows[Idx]["LO_CODELOGICIEL"].ToString();
					clsLogicielobjetweb.OB_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["OB_LIBELLE"].ToString();
					clsLogicielobjetweb.OB_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["OB_STATUT"].ToString();
					clsLogicielobjetweb.OB_RATTACHEA = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OB_RATTACHEA"].ToString());
					clsLogicielobjetwebs.Add(clsLogicielobjetweb);
				}
				Dataset.Dispose();
			}
		return clsLogicielobjetwebs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_LOGICIELOBJET(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT OB_RATTACHEA , OB_LIBELLE,OB_CODEOBJET FROM dbo.FT_LOGICIELOBJET(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboEcrandroit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "EXEC [dbo].[PS_COMBOECRAN]";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA)</summary>
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
				this.vapCritere ="WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@OT_CODETYPEOBJET"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET AND OB_CODEOBJET=@OB_CODEOBJET";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@OT_CODETYPEOBJET","@OB_CODEOBJET"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET AND OB_CODEOBJET=@OB_CODEOBJET AND OB_RATTACHEA=@OB_RATTACHEA";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@OT_CODETYPEOBJET","@OB_CODEOBJET","@OB_RATTACHEA"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}


        /////<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA)</summary>
        /////<param name="clsDonnee"> clsDonnee</param>
        /////<param name="vppCritere">Les critères de la requète</param>
        /////<author>Home Technologie</author>
        //public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    switch (vppCritere.Length)
        //    {
        //        case 0:
        //            this.vapCritere = "";
        //            vapNomParametre = new string[] { "@CODECRYPTAGE" };
        //            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
        //            break;
        //        case 1:
        //            this.vapCritere = "WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET";
        //            vapNomParametre = new string[] { "@CODECRYPTAGE", "@OT_CODETYPEOBJET" };
        //            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
        //            break;
        //        case 2:
        //            this.vapCritere = "WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET AND OB_RATTACHEA=OB_CODEOBJET";
        //            vapNomParametre = new string[] { "@CODECRYPTAGE", "@OT_CODETYPEOBJET"};
        //            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0]};
        //            break;
        //        case 3:
        //            this.vapCritere = "WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET AND OB_CODEOBJET=@OB_CODEOBJET AND OB_RATTACHEA=@OB_RATTACHEA";
        //            vapNomParametre = new string[] { "@CODECRYPTAGE", "@OT_CODETYPEOBJET", "@OB_CODEOBJET", "@OB_RATTACHEA" };
        //            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
        //            break;
        //    }
        //}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OT_CODETYPEOBJET, OB_CODEOBJET, OB_RATTACHEA)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 2:
                    this.vapCritere = "WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET AND LO_CODELOGICIEL=@LO_CODELOGICIEL ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@OT_CODETYPEOBJET", "@LO_CODELOGICIEL" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET AND LO_CODELOGICIEL=@LO_CODELOGICIEL AND OB_RATTACHEA=OB_CODEOBJET";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@OT_CODETYPEOBJET","@LO_CODELOGICIEL" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;

                case 4:
                    this.vapCritere = "WHERE OT_CODETYPEOBJET=@OT_CODETYPEOBJET AND LO_CODELOGICIEL=@LO_CODELOGICIEL AND OB_RATTACHEA<>OB_CODEOBJET AND OB_RATTACHEA=@OB_CODEOBJET ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@OT_CODETYPEOBJET", "@LO_CODELOGICIEL", "@OB_CODEOBJET" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] , vppCritere[2] };
                break;
                
            }
        }
	}
}
