using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratreductionWSDAL: ITableDAL<clsCtcontratreduction>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratreduction comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratreduction pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , RD_TAUX  , RD_MONTANT  FROM dbo.FT_CTCONTRATREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratreduction clsCtcontratreduction = new clsCtcontratreduction();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratreduction.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratreduction.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratreduction.RD_TAUX = float.Parse(clsDonnee.vogDataReader["RD_TAUX"].ToString());
					clsCtcontratreduction.RD_MONTANT = double.Parse(clsDonnee.vogDataReader["RD_MONTANT"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratreduction;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratreduction>clsCtcontratreduction</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratreduction clsCtcontratreduction)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratreduction.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT1", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratreduction.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT1", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratreduction.CA_CODECONTRAT ;
			SqlParameter vppParamRD_CODEREDUCTION = new SqlParameter("@RD_CODEREDUCTION", SqlDbType.VarChar, 2);
			vppParamRD_CODEREDUCTION.Value  = clsCtcontratreduction.RD_CODEREDUCTION ;
			SqlParameter vppParamRD_TAUX = new SqlParameter("@RD_TAUX", SqlDbType.Float);
			vppParamRD_TAUX.Value  = clsCtcontratreduction.RD_TAUX ;
			SqlParameter vppParamRD_MONTANT = new SqlParameter("@RD_MONTANT", SqlDbType.Money);
			vppParamRD_MONTANT.Value  = clsCtcontratreduction.RD_MONTANT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATREDUCTION  @AG_CODEAGENCE1, @EN_CODEENTREPOT1, @CA_CODECONTRAT1, @RD_CODEREDUCTION, @RD_TAUX, @RD_MONTANT, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamRD_CODEREDUCTION);
			vppSqlCmd.Parameters.Add(vppParamRD_TAUX);
			vppSqlCmd.Parameters.Add(vppParamRD_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratreduction>clsCtcontratreduction</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratreduction clsCtcontratreduction,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratreduction.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratreduction.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratreduction.CA_CODECONTRAT ;
			SqlParameter vppParamRD_CODEREDUCTION = new SqlParameter("@RD_CODEREDUCTION", SqlDbType.VarChar, 2);
			vppParamRD_CODEREDUCTION.Value  = clsCtcontratreduction.RD_CODEREDUCTION ;
			SqlParameter vppParamRD_TAUX = new SqlParameter("@RD_TAUX", SqlDbType.Float);
			vppParamRD_TAUX.Value  = clsCtcontratreduction.RD_TAUX ;
			SqlParameter vppParamRD_MONTANT = new SqlParameter("@RD_MONTANT", SqlDbType.Money);
			vppParamRD_MONTANT.Value  = clsCtcontratreduction.RD_MONTANT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATREDUCTION  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT, @RD_CODEREDUCTION, @RD_TAUX, @RD_MONTANT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamRD_CODEREDUCTION);
			vppSqlCmd.Parameters.Add(vppParamRD_TAUX);
			vppSqlCmd.Parameters.Add(vppParamRD_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATREDUCTION  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT,'', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratreduction </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratreduction> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION, RD_TAUX, RD_MONTANT FROM dbo.FT_CTCONTRATREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratreduction> clsCtcontratreductions = new List<clsCtcontratreduction>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratreduction clsCtcontratreduction = new clsCtcontratreduction();
					clsCtcontratreduction.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratreduction.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratreduction.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratreduction.RD_CODEREDUCTION = clsDonnee.vogDataReader["RD_CODEREDUCTION"].ToString();
					clsCtcontratreduction.RD_TAUX = float.Parse(clsDonnee.vogDataReader["RD_TAUX"].ToString());
					clsCtcontratreduction.RD_MONTANT = double.Parse(clsDonnee.vogDataReader["RD_MONTANT"].ToString());
					clsCtcontratreductions.Add(clsCtcontratreduction);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratreductions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratreduction </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratreduction> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratreduction> clsCtcontratreductions = new List<clsCtcontratreduction>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION, RD_TAUX, RD_MONTANT FROM dbo.FT_CTCONTRATREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratreduction clsCtcontratreduction = new clsCtcontratreduction();
					clsCtcontratreduction.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratreduction.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratreduction.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratreduction.RD_CODEREDUCTION = Dataset.Tables["TABLE"].Rows[Idx]["RD_CODEREDUCTION"].ToString();
					clsCtcontratreduction.RD_TAUX = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_TAUX"].ToString());
					clsCtcontratreduction.RD_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_MONTANT"].ToString());
					clsCtcontratreductions.Add(clsCtcontratreduction);
				}
				Dataset.Dispose();
			}
		return clsCtcontratreductions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTCONTRATREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CA_CODECONTRAT , RD_TAUX FROM dbo.FT_CTCONTRATREDUCTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RD_CODEREDUCTION)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CA_CODECONTRAT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT AND RD_CODEREDUCTION=@RD_CODEREDUCTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CA_CODECONTRAT","@RD_CODEREDUCTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
