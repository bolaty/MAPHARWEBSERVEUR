using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratquestionnaireWSDAL: ITableDAL<clsCtcontratquestionnaire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATQUESTIONNAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATQUESTIONNAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATQUESTIONNAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratquestionnaire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratquestionnaire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CQ_VALEUR1  , CQ_VALEUR2  FROM dbo.FT_CTCONTRATQUESTIONNAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratquestionnaire clsCtcontratquestionnaire = new clsCtcontratquestionnaire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratquestionnaire.CQ_VALEUR1 = clsDonnee.vogDataReader["CQ_VALEUR1"].ToString();
					clsCtcontratquestionnaire.CQ_VALEUR2 = clsDonnee.vogDataReader["CQ_VALEUR2"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratquestionnaire;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratquestionnaire>clsCtcontratquestionnaire</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratquestionnaire clsCtcontratquestionnaire)
		{
			//Préparation des paramètres
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT1", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratquestionnaire.CA_CODECONTRAT ;
			SqlParameter vppParamQE_CODEQUESTIONNAIRE = new SqlParameter("@QE_CODEQUESTIONNAIRE", SqlDbType.VarChar, 4);
			vppParamQE_CODEQUESTIONNAIRE.Value  = clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE ;
			SqlParameter vppParamDC_CODEDOCUMENT = new SqlParameter("@DC_CODEDOCUMENT1", SqlDbType.VarChar, 4);
            vppParamDC_CODEDOCUMENT.Value  = clsCtcontratquestionnaire.DC_CODEDOCUMENT;

			SqlParameter vppParamCQ_VALEUR1 = new SqlParameter("@CQ_VALEUR1", SqlDbType.VarChar, 1);
			vppParamCQ_VALEUR1.Value  = clsCtcontratquestionnaire.CQ_VALEUR1 ;
			SqlParameter vppParamCQ_VALEUR2 = new SqlParameter("@CQ_VALEUR2", SqlDbType.VarChar, 150);
			vppParamCQ_VALEUR2.Value  = clsCtcontratquestionnaire.CQ_VALEUR2 ;
			if(clsCtcontratquestionnaire.CQ_VALEUR2== ""  ) vppParamCQ_VALEUR2.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATQUESTIONNAIRE  @CA_CODECONTRAT1, @QE_CODEQUESTIONNAIRE,@DC_CODEDOCUMENT1, @CQ_VALEUR1, @CQ_VALEUR2, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamQE_CODEQUESTIONNAIRE);
			vppSqlCmd.Parameters.Add(vppParamDC_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamCQ_VALEUR1);
			vppSqlCmd.Parameters.Add(vppParamCQ_VALEUR2);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratquestionnaire>clsCtcontratquestionnaire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratquestionnaire clsCtcontratquestionnaire,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratquestionnaire.CA_CODECONTRAT ;
			SqlParameter vppParamQE_CODEQUESTIONNAIRE = new SqlParameter("@QE_CODEQUESTIONNAIRE", SqlDbType.VarChar, 4);
			vppParamQE_CODEQUESTIONNAIRE.Value  = clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE ;
			SqlParameter vppParamDC_CODEDOCUMENT = new SqlParameter("@DC_CODEDOCUMENT", SqlDbType.VarChar, 4);
            vppParamDC_CODEDOCUMENT.Value  = clsCtcontratquestionnaire.DC_CODEDOCUMENT;

			SqlParameter vppParamCQ_VALEUR1 = new SqlParameter("@CQ_VALEUR1", SqlDbType.VarChar, 1);
			vppParamCQ_VALEUR1.Value  = clsCtcontratquestionnaire.CQ_VALEUR1 ;
			SqlParameter vppParamCQ_VALEUR2 = new SqlParameter("@CQ_VALEUR2", SqlDbType.VarChar, 150);
			vppParamCQ_VALEUR2.Value  = clsCtcontratquestionnaire.CQ_VALEUR2 ;
			if(clsCtcontratquestionnaire.CQ_VALEUR2== ""  ) vppParamCQ_VALEUR2.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATQUESTIONNAIRE  @CA_CODECONTRAT, @QE_CODEQUESTIONNAIRE,@DC_CODEDOCUMENT, @CQ_VALEUR1, @CQ_VALEUR2, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamQE_CODEQUESTIONNAIRE);
			vppSqlCmd.Parameters.Add(vppParamDC_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamCQ_VALEUR1);
			vppSqlCmd.Parameters.Add(vppParamCQ_VALEUR2);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATQUESTIONNAIRE  @CA_CODECONTRAT, '',@DC_CODEDOCUMENT, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratquestionnaire </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratquestionnaire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CA_CODECONTRAT, QE_CODEQUESTIONNAIRE, CQ_VALEUR1, CQ_VALEUR2 FROM dbo.FT_CTCONTRATQUESTIONNAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<clsCtcontratquestionnaire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratquestionnaire clsCtcontratquestionnaire = new clsCtcontratquestionnaire();
					clsCtcontratquestionnaire.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE = clsDonnee.vogDataReader["QE_CODEQUESTIONNAIRE"].ToString();
					clsCtcontratquestionnaire.CQ_VALEUR1 = clsDonnee.vogDataReader["CQ_VALEUR1"].ToString();
					clsCtcontratquestionnaire.CQ_VALEUR2 = clsDonnee.vogDataReader["CQ_VALEUR2"].ToString();
					clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratquestionnaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratquestionnaire </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratquestionnaire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<clsCtcontratquestionnaire>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CA_CODECONTRAT, QE_CODEQUESTIONNAIRE, CQ_VALEUR1, CQ_VALEUR2 FROM dbo.FT_CTCONTRATQUESTIONNAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratquestionnaire clsCtcontratquestionnaire = new clsCtcontratquestionnaire();
					clsCtcontratquestionnaire.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratquestionnaire.QE_CODEQUESTIONNAIRE = Dataset.Tables["TABLE"].Rows[Idx]["QE_CODEQUESTIONNAIRE"].ToString();
					clsCtcontratquestionnaire.CQ_VALEUR1 = Dataset.Tables["TABLE"].Rows[Idx]["CQ_VALEUR1"].ToString();
					clsCtcontratquestionnaire.CQ_VALEUR2 = Dataset.Tables["TABLE"].Rows[Idx]["CQ_VALEUR2"].ToString();
					clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
				}
				Dataset.Dispose();
			}
		return clsCtcontratquestionnaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CA_CODECONTRAT", "@DC_CODEDOCUMENT", "@OP_CODEOPERATEUREDITION", "@ET_TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] , vppCritere[5] };
            this.vapRequete = "EXEC PS_CTCONTRATQUESTIONNAIRE @AG_CODEAGENCE,@EN_CODEENTREPOT,@CA_CODECONTRAT,@DC_CODEDOCUMENT,@OP_CODEOPERATEUREDITION,@ET_TYPEETAT, @CODECRYPTAGE ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CA_CODECONTRAT, QE_CODEQUESTIONNAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CA_CODECONTRAT , CQ_VALEUR1 FROM dbo.FT_CTCONTRATQUESTIONNAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CA_CODECONTRAT, QE_CODEQUESTIONNAIRE)</summary>
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
				this.vapCritere ="WHERE CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere = "WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND DC_CODEDOCUMENT=@DC_CODEDOCUMENT  ";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT", "@DC_CODEDOCUMENT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere = "WHERE CA_CODECONTRAT=@CA_CODECONTRAT AND DC_CODEDOCUMENT=@DC_CODEDOCUMENT AND QE_CODEQUESTIONNAIRE=@QE_CODEQUESTIONNAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CA_CODECONTRAT", "@DC_CODEDOCUMENT", "@QE_CODEQUESTIONNAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
