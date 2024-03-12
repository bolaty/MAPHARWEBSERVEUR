using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparprimerisqueassuranceliaisonWSDAL: ITableDAL<clsCtparprimerisqueassuranceliaison>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RE_CODERESUME) AS RE_CODERESUME  FROM dbo.FT_CTPARPRIMERISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RE_CODERESUME) AS RE_CODERESUME  FROM dbo.FT_CTPARPRIMERISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RE_CODERESUME) AS RE_CODERESUME  FROM dbo.FT_CTPARPRIMERISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparprimerisqueassuranceliaison comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparprimerisqueassuranceliaison pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RL_NUMEROORDRE  FROM dbo.FT_CTPARPRIMERISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new clsCtparprimerisqueassuranceliaison();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparprimerisqueassuranceliaison.RL_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RL_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparprimerisqueassuranceliaison;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparprimerisqueassuranceliaison>clsCtparprimerisqueassuranceliaison</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison)
		{
			//Préparation des paramètres
			SqlParameter vppParamRE_CODERESUME = new SqlParameter("@RE_CODERESUME", SqlDbType.VarChar, 2);
			vppParamRE_CODERESUME.Value  = clsCtparprimerisqueassuranceliaison.RE_CODERESUME ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtparprimerisqueassuranceliaison.RQ_CODERISQUE ;
			SqlParameter vppParamRL_NUMEROORDRE = new SqlParameter("@RL_NUMEROORDRE", SqlDbType.Int);
			vppParamRL_NUMEROORDRE.Value  = clsCtparprimerisqueassuranceliaison.RL_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARPRIMERISQUEASSURANCELIAISON  @RE_CODERESUME, @RQ_CODERISQUE, @RL_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRE_CODERESUME);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamRL_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparprimerisqueassuranceliaison>clsCtparprimerisqueassuranceliaison</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRE_CODERESUME = new SqlParameter("@RE_CODERESUME", SqlDbType.VarChar, 2);
			vppParamRE_CODERESUME.Value  = clsCtparprimerisqueassuranceliaison.RE_CODERESUME ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtparprimerisqueassuranceliaison.RQ_CODERISQUE ;
			SqlParameter vppParamRL_NUMEROORDRE = new SqlParameter("@RL_NUMEROORDRE", SqlDbType.Int);
			vppParamRL_NUMEROORDRE.Value  = clsCtparprimerisqueassuranceliaison.RL_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARPRIMERISQUEASSURANCELIAISON  @RE_CODERESUME, @RQ_CODERISQUE, @RL_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRE_CODERESUME);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamRL_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARPRIMERISQUEASSURANCELIAISON  @RE_CODERESUME, @RQ_CODERISQUE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparprimerisqueassuranceliaison </returns>
		///<author>Home Technology</author>
		public List<clsCtparprimerisqueassuranceliaison> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RE_CODERESUME, RQ_CODERISQUE, RL_NUMEROORDRE FROM dbo.FT_CTPARPRIMERISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparprimerisqueassuranceliaison> clsCtparprimerisqueassuranceliaisons = new List<clsCtparprimerisqueassuranceliaison>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new clsCtparprimerisqueassuranceliaison();
					clsCtparprimerisqueassuranceliaison.RE_CODERESUME = clsDonnee.vogDataReader["RE_CODERESUME"].ToString();
					clsCtparprimerisqueassuranceliaison.RQ_CODERISQUE = clsDonnee.vogDataReader["RQ_CODERISQUE"].ToString();
					clsCtparprimerisqueassuranceliaison.RL_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RL_NUMEROORDRE"].ToString());
					clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparprimerisqueassuranceliaisons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparprimerisqueassuranceliaison </returns>
		///<author>Home Technology</author>
		public List<clsCtparprimerisqueassuranceliaison> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparprimerisqueassuranceliaison> clsCtparprimerisqueassuranceliaisons = new List<clsCtparprimerisqueassuranceliaison>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RE_CODERESUME, RQ_CODERISQUE, RL_NUMEROORDRE FROM dbo.FT_CTPARPRIMERISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new clsCtparprimerisqueassuranceliaison();
					clsCtparprimerisqueassuranceliaison.RE_CODERESUME = Dataset.Tables["TABLE"].Rows[Idx]["RE_CODERESUME"].ToString();
					clsCtparprimerisqueassuranceliaison.RQ_CODERISQUE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODERISQUE"].ToString();
					clsCtparprimerisqueassuranceliaison.RL_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RL_NUMEROORDRE"].ToString());
					clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
				}
				Dataset.Dispose();
			}
		return clsCtparprimerisqueassuranceliaisons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARPRIMERISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY RL_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RE_CODERESUME, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RE_CODERESUME , RL_NUMEROORDRE FROM dbo.FT_CTPARPRIMERISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RE_CODERESUME, RQ_CODERISQUE)</summary>
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
				this.vapCritere ="WHERE RE_CODERESUME=@RE_CODERESUME AND RQ_CODERISQUE=@RQ_CODERISQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RE_CODERESUME","@RQ_CODERISQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
