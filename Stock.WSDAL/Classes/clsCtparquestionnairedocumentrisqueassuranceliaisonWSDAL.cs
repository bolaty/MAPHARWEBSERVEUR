using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparquestionnairedocumentrisqueassuranceliaisonWSDAL: ITableDAL<clsCtparquestionnairedocumentrisqueassuranceliaison>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(DC_CODEDOCUMENT) AS DC_CODEDOCUMENT  FROM dbo.FT_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(DC_CODEDOCUMENT) AS DC_CODEDOCUMENT  FROM dbo.FT_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(DC_CODEDOCUMENT) AS DC_CODEDOCUMENT  FROM dbo.FT_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparquestionnairedocumentrisqueassuranceliaison comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparquestionnairedocumentrisqueassuranceliaison pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT GL_NUMEROORDRE  FROM dbo.FT_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new clsCtparquestionnairedocumentrisqueassuranceliaison();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparquestionnairedocumentrisqueassuranceliaison.GL_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["GL_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparquestionnairedocumentrisqueassuranceliaison;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparquestionnairedocumentrisqueassuranceliaison>clsCtparquestionnairedocumentrisqueassuranceliaison</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison)
		{
			//Préparation des paramètres
			SqlParameter vppParamDC_CODEDOCUMENT = new SqlParameter("@DC_CODEDOCUMENT", SqlDbType.VarChar, 2);
			vppParamDC_CODEDOCUMENT.Value  = clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE ;
			SqlParameter vppParamGL_NUMEROORDRE = new SqlParameter("@GL_NUMEROORDRE", SqlDbType.Int);
			vppParamGL_NUMEROORDRE.Value  = clsCtparquestionnairedocumentrisqueassuranceliaison.GL_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON  @DC_CODEDOCUMENT, @RQ_CODERISQUE, @GL_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDC_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamGL_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparquestionnairedocumentrisqueassuranceliaison>clsCtparquestionnairedocumentrisqueassuranceliaison</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDC_CODEDOCUMENT = new SqlParameter("@DC_CODEDOCUMENT", SqlDbType.VarChar, 2);
			vppParamDC_CODEDOCUMENT.Value  = clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE ;
			SqlParameter vppParamGL_NUMEROORDRE = new SqlParameter("@GL_NUMEROORDRE", SqlDbType.Int);
			vppParamGL_NUMEROORDRE.Value  = clsCtparquestionnairedocumentrisqueassuranceliaison.GL_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON  @DC_CODEDOCUMENT, @RQ_CODERISQUE, @GL_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDC_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamGL_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON  @DC_CODEDOCUMENT, @RQ_CODERISQUE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparquestionnairedocumentrisqueassuranceliaison </returns>
		///<author>Home Technology</author>
		public List<clsCtparquestionnairedocumentrisqueassuranceliaison> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DC_CODEDOCUMENT, RQ_CODERISQUE, GL_NUMEROORDRE FROM dbo.FT_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<clsCtparquestionnairedocumentrisqueassuranceliaison>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new clsCtparquestionnairedocumentrisqueassuranceliaison();
					clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT = clsDonnee.vogDataReader["DC_CODEDOCUMENT"].ToString();
					clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE = clsDonnee.vogDataReader["RQ_CODERISQUE"].ToString();
					clsCtparquestionnairedocumentrisqueassuranceliaison.GL_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["GL_NUMEROORDRE"].ToString());
					clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparquestionnairedocumentrisqueassuranceliaisons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparquestionnairedocumentrisqueassuranceliaison </returns>
		///<author>Home Technology</author>
		public List<clsCtparquestionnairedocumentrisqueassuranceliaison> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<clsCtparquestionnairedocumentrisqueassuranceliaison>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DC_CODEDOCUMENT, RQ_CODERISQUE, GL_NUMEROORDRE FROM dbo.FT_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new clsCtparquestionnairedocumentrisqueassuranceliaison();
					clsCtparquestionnairedocumentrisqueassuranceliaison.DC_CODEDOCUMENT = Dataset.Tables["TABLE"].Rows[Idx]["DC_CODEDOCUMENT"].ToString();
					clsCtparquestionnairedocumentrisqueassuranceliaison.RQ_CODERISQUE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODERISQUE"].ToString();
					clsCtparquestionnairedocumentrisqueassuranceliaison.GL_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["GL_NUMEROORDRE"].ToString());
					clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
				}
				Dataset.Dispose();
			}
		return clsCtparquestionnairedocumentrisqueassuranceliaisons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : DC_CODEDOCUMENT, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DC_CODEDOCUMENT,DC_LIBELLEDOCUMENT FROM dbo.FT_CTPARQUESTIONNAIREDOCUMENTRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :DC_CODEDOCUMENT, RQ_CODERISQUE)</summary>
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
				this.vapCritere = "WHERE RQ_CODERISQUE=@RQ_CODERISQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@RQ_CODERISQUE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE DC_CODEDOCUMENT=@DC_CODEDOCUMENT AND RQ_CODERISQUE=@RQ_CODERISQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DC_CODEDOCUMENT","@RQ_CODERISQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
