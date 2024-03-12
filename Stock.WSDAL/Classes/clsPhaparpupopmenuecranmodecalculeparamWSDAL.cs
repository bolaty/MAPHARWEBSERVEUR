using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpupopmenuecranmodecalculeparamWSDAL: ITableDAL<clsPhaparpupopmenuecranmodecalculeparam>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(EC_CODECRAN) AS EC_CODECRAN  FROM dbo.FT_PHAPARPUPOPMENUECRANMODECALCULEPARAM(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(EC_CODECRAN) AS EC_CODECRAN  FROM dbo.FT_PHAPARPUPOPMENUECRANMODECALCULEPARAM(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(EC_CODECRAN) AS EC_CODECRAN  FROM dbo.FT_PHAPARPUPOPMENUECRANMODECALCULEPARAM(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpupopmenuecranmodecalculeparam comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpupopmenuecranmodecalculeparam pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MC_CODEMODECALCUE,MC_LIBELLE  FROM dbo.FT_PHAPARPUPOPMENUECRANMODECALCULEPARAM(@EC_CODECRAN,@TP_CODETYPEPRIX) ";// +this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpupopmenuecranmodecalculeparam clsPhaparpupopmenuecranmodecalculeparam = new clsPhaparpupopmenuecranmodecalculeparam();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenuecranmodecalculeparam.MC_CODEMODECALCUE = clsDonnee.vogDataReader["MC_CODEMODECALCUE"].ToString();
                    clsPhaparpupopmenuecranmodecalculeparam.MC_LIBELLE = clsDonnee.vogDataReader["MC_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpupopmenuecranmodecalculeparam;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenuecranmodecalculeparam>clsPhaparpupopmenuecranmodecalculeparam</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpupopmenuecranmodecalculeparam clsPhaparpupopmenuecranmodecalculeparam)
		{
			//Préparation des paramètres
			SqlParameter vppParamEC_CODECRAN = new SqlParameter("@EC_CODECRAN", SqlDbType.VarChar, 2);
			vppParamEC_CODECRAN.Value  = clsPhaparpupopmenuecranmodecalculeparam.EC_CODECRAN ;
			SqlParameter vppParamTP_CODETYPEPRIX = new SqlParameter("@TP_CODETYPEPRIX", SqlDbType.VarChar, 2);
			vppParamTP_CODETYPEPRIX.Value  = clsPhaparpupopmenuecranmodecalculeparam.TP_CODETYPEPRIX ;
			SqlParameter vppParamMC_CODEMODECALCUE = new SqlParameter("@MC_CODEMODECALCUE", SqlDbType.VarChar, 2);
			vppParamMC_CODEMODECALCUE.Value  = clsPhaparpupopmenuecranmodecalculeparam.MC_CODEMODECALCUE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUECRANMODECALCULEPARAM  @EC_CODECRAN, @TP_CODETYPEPRIX, @MC_CODEMODECALCUE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEC_CODECRAN);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPRIX);
			vppSqlCmd.Parameters.Add(vppParamMC_CODEMODECALCUE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenuecranmodecalculeparam>clsPhaparpupopmenuecranmodecalculeparam</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpupopmenuecranmodecalculeparam clsPhaparpupopmenuecranmodecalculeparam,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamEC_CODECRAN = new SqlParameter("@EC_CODECRAN", SqlDbType.VarChar, 2);
			vppParamEC_CODECRAN.Value  = clsPhaparpupopmenuecranmodecalculeparam.EC_CODECRAN ;
			SqlParameter vppParamTP_CODETYPEPRIX = new SqlParameter("@TP_CODETYPEPRIX", SqlDbType.VarChar, 2);
			vppParamTP_CODETYPEPRIX.Value  = clsPhaparpupopmenuecranmodecalculeparam.TP_CODETYPEPRIX ;
			SqlParameter vppParamMC_CODEMODECALCUE = new SqlParameter("@MC_CODEMODECALCUE", SqlDbType.VarChar, 2);
			vppParamMC_CODEMODECALCUE.Value  = clsPhaparpupopmenuecranmodecalculeparam.MC_CODEMODECALCUE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUECRANMODECALCULEPARAM  @EC_CODECRAN, @TP_CODETYPEPRIX, @MC_CODEMODECALCUE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEC_CODECRAN);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPRIX);
			vppSqlCmd.Parameters.Add(vppParamMC_CODEMODECALCUE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUECRANMODECALCULEPARAM  @EC_CODECRAN, @TP_CODETYPEPRIX, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenuecranmodecalculeparam </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenuecranmodecalculeparam> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EC_CODECRAN, TP_CODETYPEPRIX, MC_CODEMODECALCUE FROM dbo.FT_PHAPARPUPOPMENUECRANMODECALCULEPARAM(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpupopmenuecranmodecalculeparam> clsPhaparpupopmenuecranmodecalculeparams = new List<clsPhaparpupopmenuecranmodecalculeparam>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenuecranmodecalculeparam clsPhaparpupopmenuecranmodecalculeparam = new clsPhaparpupopmenuecranmodecalculeparam();
					clsPhaparpupopmenuecranmodecalculeparam.EC_CODECRAN = clsDonnee.vogDataReader["EC_CODECRAN"].ToString();
					clsPhaparpupopmenuecranmodecalculeparam.TP_CODETYPEPRIX = clsDonnee.vogDataReader["TP_CODETYPEPRIX"].ToString();
					clsPhaparpupopmenuecranmodecalculeparam.MC_CODEMODECALCUE = clsDonnee.vogDataReader["MC_CODEMODECALCUE"].ToString();
					clsPhaparpupopmenuecranmodecalculeparams.Add(clsPhaparpupopmenuecranmodecalculeparam);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpupopmenuecranmodecalculeparams;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenuecranmodecalculeparam </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenuecranmodecalculeparam> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpupopmenuecranmodecalculeparam> clsPhaparpupopmenuecranmodecalculeparams = new List<clsPhaparpupopmenuecranmodecalculeparam>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EC_CODECRAN, TP_CODETYPEPRIX, MC_CODEMODECALCUE FROM dbo.FT_PHAPARPUPOPMENUECRANMODECALCULEPARAM(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpupopmenuecranmodecalculeparam clsPhaparpupopmenuecranmodecalculeparam = new clsPhaparpupopmenuecranmodecalculeparam();
					clsPhaparpupopmenuecranmodecalculeparam.EC_CODECRAN = Dataset.Tables["TABLE"].Rows[Idx]["EC_CODECRAN"].ToString();
					clsPhaparpupopmenuecranmodecalculeparam.TP_CODETYPEPRIX = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPEPRIX"].ToString();
					clsPhaparpupopmenuecranmodecalculeparam.MC_CODEMODECALCUE = Dataset.Tables["TABLE"].Rows[Idx]["MC_CODEMODECALCUE"].ToString();
					clsPhaparpupopmenuecranmodecalculeparams.Add(clsPhaparpupopmenuecranmodecalculeparam);
				}
				Dataset.Dispose();
			}
		return clsPhaparpupopmenuecranmodecalculeparams;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENUECRANMODECALCULEPARAM(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EC_CODECRAN, TP_CODETYPEPRIX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EC_CODECRAN , MC_CODEMODECALCUE FROM dbo.FT_PHAPARPUPOPMENUECRANMODECALCULEPARAM(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :EC_CODECRAN, TP_CODETYPEPRIX)</summary>
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
				this.vapCritere ="WHERE EC_CODECRAN=@EC_CODECRAN";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@EC_CODECRAN"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                //this.vapCritere ="WHERE EC_CODECRAN=@EC_CODECRAN AND TP_CODETYPEPRIX=@TP_CODETYPEPRIX";
				vapNomParametre = new string[]{"@EC_CODECRAN","@TP_CODETYPEPRIX"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
