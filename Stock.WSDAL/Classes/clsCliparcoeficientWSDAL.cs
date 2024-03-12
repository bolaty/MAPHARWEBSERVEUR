using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliparcoeficientWSDAL: ITableDAL<clsCliparcoeficient>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CF_CODECOEFICIENT) AS CF_CODECOEFICIENT  FROM dbo.FT_CLIPARCOEFICIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CF_CODECOEFICIENT) AS CF_CODECOEFICIENT  FROM dbo.FT_CLIPARCOEFICIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CF_CODECOEFICIENT) AS CF_CODECOEFICIENT  FROM dbo.FT_CLIPARCOEFICIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliparcoeficient comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliparcoeficient pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CF_LETTRECOEFICIENT  , CF_LIBELLECOEFICIENT  , CF_ACTIF  , CF_NUMEROORDRE  FROM dbo.FT_CLIPARCOEFICIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliparcoeficient clsCliparcoeficient = new clsCliparcoeficient();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparcoeficient.CF_LETTRECOEFICIENT = clsDonnee.vogDataReader["CF_LETTRECOEFICIENT"].ToString();
					clsCliparcoeficient.CF_LIBELLECOEFICIENT = clsDonnee.vogDataReader["CF_LIBELLECOEFICIENT"].ToString();
					clsCliparcoeficient.CF_ACTIF = clsDonnee.vogDataReader["CF_ACTIF"].ToString();
					clsCliparcoeficient.CF_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CF_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliparcoeficient;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparcoeficient>clsCliparcoeficient</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliparcoeficient clsCliparcoeficient)
		{
			//Préparation des paramètres
			SqlParameter vppParamCF_CODECOEFICIENT = new SqlParameter("@CF_CODECOEFICIENT", SqlDbType.VarChar, 25);
			vppParamCF_CODECOEFICIENT.Value  = clsCliparcoeficient.CF_CODECOEFICIENT ;
			SqlParameter vppParamCF_LETTRECOEFICIENT = new SqlParameter("@CF_LETTRECOEFICIENT", SqlDbType.VarChar, 50);
			vppParamCF_LETTRECOEFICIENT.Value  = clsCliparcoeficient.CF_LETTRECOEFICIENT ;
			SqlParameter vppParamCF_LIBELLECOEFICIENT = new SqlParameter("@CF_LIBELLECOEFICIENT", SqlDbType.VarChar, 150);
			vppParamCF_LIBELLECOEFICIENT.Value  = clsCliparcoeficient.CF_LIBELLECOEFICIENT ;
			SqlParameter vppParamCF_ACTIF = new SqlParameter("@CF_ACTIF", SqlDbType.VarChar, 1);
			vppParamCF_ACTIF.Value  = clsCliparcoeficient.CF_ACTIF ;
			SqlParameter vppParamCF_NUMEROORDRE = new SqlParameter("@CF_NUMEROORDRE", SqlDbType.Int);
			vppParamCF_NUMEROORDRE.Value  = clsCliparcoeficient.CF_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENT  @CF_CODECOEFICIENT, @CF_LETTRECOEFICIENT, @CF_LIBELLECOEFICIENT, @CF_ACTIF, @CF_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCF_CODECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCF_LETTRECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCF_LIBELLECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCF_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCF_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparcoeficient>clsCliparcoeficient</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliparcoeficient clsCliparcoeficient,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCF_CODECOEFICIENT = new SqlParameter("@CF_CODECOEFICIENT", SqlDbType.VarChar, 25);
			vppParamCF_CODECOEFICIENT.Value  = clsCliparcoeficient.CF_CODECOEFICIENT ;
			SqlParameter vppParamCF_LETTRECOEFICIENT = new SqlParameter("@CF_LETTRECOEFICIENT", SqlDbType.VarChar, 50);
			vppParamCF_LETTRECOEFICIENT.Value  = clsCliparcoeficient.CF_LETTRECOEFICIENT ;
			SqlParameter vppParamCF_LIBELLECOEFICIENT = new SqlParameter("@CF_LIBELLECOEFICIENT", SqlDbType.VarChar, 150);
			vppParamCF_LIBELLECOEFICIENT.Value  = clsCliparcoeficient.CF_LIBELLECOEFICIENT ;
			SqlParameter vppParamCF_ACTIF = new SqlParameter("@CF_ACTIF", SqlDbType.VarChar, 1);
			vppParamCF_ACTIF.Value  = clsCliparcoeficient.CF_ACTIF ;
			SqlParameter vppParamCF_NUMEROORDRE = new SqlParameter("@CF_NUMEROORDRE", SqlDbType.Int);
			vppParamCF_NUMEROORDRE.Value  = clsCliparcoeficient.CF_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENT  @CF_CODECOEFICIENT, @CF_LETTRECOEFICIENT, @CF_LIBELLECOEFICIENT, @CF_ACTIF, @CF_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCF_CODECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCF_LETTRECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCF_LIBELLECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCF_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCF_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENT  @CF_CODECOEFICIENT, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparcoeficient </returns>
		///<author>Home Technology</author>
		public List<clsCliparcoeficient> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CF_CODECOEFICIENT, CF_LETTRECOEFICIENT, CF_LIBELLECOEFICIENT, CF_ACTIF, CF_NUMEROORDRE FROM dbo.FT_CLIPARCOEFICIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliparcoeficient> clsCliparcoeficients = new List<clsCliparcoeficient>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparcoeficient clsCliparcoeficient = new clsCliparcoeficient();
					clsCliparcoeficient.CF_CODECOEFICIENT = clsDonnee.vogDataReader["CF_CODECOEFICIENT"].ToString();
					clsCliparcoeficient.CF_LETTRECOEFICIENT = clsDonnee.vogDataReader["CF_LETTRECOEFICIENT"].ToString();
					clsCliparcoeficient.CF_LIBELLECOEFICIENT = clsDonnee.vogDataReader["CF_LIBELLECOEFICIENT"].ToString();
					clsCliparcoeficient.CF_ACTIF = clsDonnee.vogDataReader["CF_ACTIF"].ToString();
					clsCliparcoeficient.CF_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CF_NUMEROORDRE"].ToString());
					clsCliparcoeficients.Add(clsCliparcoeficient);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliparcoeficients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparcoeficient </returns>
		///<author>Home Technology</author>
		public List<clsCliparcoeficient> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliparcoeficient> clsCliparcoeficients = new List<clsCliparcoeficient>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CF_CODECOEFICIENT, CF_LETTRECOEFICIENT, CF_LIBELLECOEFICIENT, CF_ACTIF, CF_NUMEROORDRE FROM dbo.FT_CLIPARCOEFICIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliparcoeficient clsCliparcoeficient = new clsCliparcoeficient();
					clsCliparcoeficient.CF_CODECOEFICIENT = Dataset.Tables["TABLE"].Rows[Idx]["CF_CODECOEFICIENT"].ToString();
					clsCliparcoeficient.CF_LETTRECOEFICIENT = Dataset.Tables["TABLE"].Rows[Idx]["CF_LETTRECOEFICIENT"].ToString();
					clsCliparcoeficient.CF_LIBELLECOEFICIENT = Dataset.Tables["TABLE"].Rows[Idx]["CF_LIBELLECOEFICIENT"].ToString();
					clsCliparcoeficient.CF_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["CF_ACTIF"].ToString();
					clsCliparcoeficient.CF_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CF_NUMEROORDRE"].ToString());
					clsCliparcoeficients.Add(clsCliparcoeficient);
				}
				Dataset.Dispose();
			}
		return clsCliparcoeficients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARCOEFICIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CF_CODECOEFICIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CF_CODECOEFICIENT , CF_LETTRECOEFICIENT FROM dbo.FT_CLIPARCOEFICIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CF_CODECOEFICIENT)</summary>
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
				this.vapCritere ="WHERE CF_CODECOEFICIENT=@CF_CODECOEFICIENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CF_CODECOEFICIENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
