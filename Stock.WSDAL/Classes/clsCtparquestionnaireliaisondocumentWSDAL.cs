using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparquestionnaireliaisondocumentWSDAL: ITableDAL<clsCtparquestionnaireliaisondocument>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(DC_CODEDOCUMENT) AS DC_CODEDOCUMENT  FROM dbo.FT_CTPARQUESTIONNAIRELIAISONDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(DC_CODEDOCUMENT) AS DC_CODEDOCUMENT  FROM dbo.FT_CTPARQUESTIONNAIRELIAISONDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(DC_CODEDOCUMENT) AS DC_CODEDOCUMENT  FROM dbo.FT_CTPARQUESTIONNAIRELIAISONDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparquestionnaireliaisondocument comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparquestionnaireliaisondocument pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT QE_CODEQUESTIONNAIRE  FROM dbo.FT_CTPARQUESTIONNAIRELIAISONDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new clsCtparquestionnaireliaisondocument();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE = int.Parse(clsDonnee.vogDataReader["QE_CODEQUESTIONNAIRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparquestionnaireliaisondocument;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparquestionnaireliaisondocument>clsCtparquestionnaireliaisondocument</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument)
		{
			//Préparation des paramètres
			SqlParameter vppParamDC_CODEDOCUMENT = new SqlParameter("@DC_CODEDOCUMENT", SqlDbType.VarChar, 2);
			vppParamDC_CODEDOCUMENT.Value  = clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT ;
			SqlParameter vppParamQE_CODEQUESTIONNAIRE = new SqlParameter("@QE_CODEQUESTIONNAIRE", SqlDbType.Int);
			vppParamQE_CODEQUESTIONNAIRE.Value  = clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARQUESTIONNAIRELIAISONDOCUMENT  @DC_CODEDOCUMENT, @QE_CODEQUESTIONNAIRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDC_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamQE_CODEQUESTIONNAIRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparquestionnaireliaisondocument>clsCtparquestionnaireliaisondocument</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDC_CODEDOCUMENT = new SqlParameter("@DC_CODEDOCUMENT", SqlDbType.VarChar, 2);
			vppParamDC_CODEDOCUMENT.Value  = clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT ;
			SqlParameter vppParamQE_CODEQUESTIONNAIRE = new SqlParameter("@QE_CODEQUESTIONNAIRE", SqlDbType.Int);
			vppParamQE_CODEQUESTIONNAIRE.Value  = clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARQUESTIONNAIRELIAISONDOCUMENT  @DC_CODEDOCUMENT, @QE_CODEQUESTIONNAIRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDC_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamQE_CODEQUESTIONNAIRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARQUESTIONNAIRELIAISONDOCUMENT  @DC_CODEDOCUMENT, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparquestionnaireliaisondocument </returns>
		///<author>Home Technology</author>
		public List<clsCtparquestionnaireliaisondocument> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DC_CODEDOCUMENT, QE_CODEQUESTIONNAIRE FROM dbo.FT_CTPARQUESTIONNAIRELIAISONDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<clsCtparquestionnaireliaisondocument>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new clsCtparquestionnaireliaisondocument();
					clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT = clsDonnee.vogDataReader["DC_CODEDOCUMENT"].ToString();
					clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE = int.Parse(clsDonnee.vogDataReader["QE_CODEQUESTIONNAIRE"].ToString());
					clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparquestionnaireliaisondocuments;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparquestionnaireliaisondocument </returns>
		///<author>Home Technology</author>
		public List<clsCtparquestionnaireliaisondocument> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<clsCtparquestionnaireliaisondocument>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DC_CODEDOCUMENT, QE_CODEQUESTIONNAIRE FROM dbo.FT_CTPARQUESTIONNAIRELIAISONDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new clsCtparquestionnaireliaisondocument();
					clsCtparquestionnaireliaisondocument.DC_CODEDOCUMENT = Dataset.Tables["TABLE"].Rows[Idx]["DC_CODEDOCUMENT"].ToString();
					clsCtparquestionnaireliaisondocument.QE_CODEQUESTIONNAIRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["QE_CODEQUESTIONNAIRE"].ToString());
					clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
				}
				Dataset.Dispose();
			}
		return clsCtparquestionnaireliaisondocuments;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARQUESTIONNAIRELIAISONDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : DC_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DC_CODEDOCUMENT , QE_CODEQUESTIONNAIRE FROM dbo.FT_CTPARQUESTIONNAIRELIAISONDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :DC_CODEDOCUMENT)</summary>
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
				this.vapCritere ="WHERE DC_CODEDOCUMENT=@DC_CODEDOCUMENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DC_CODEDOCUMENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
