using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliparcoeficientcoutWSDAL: ITableDAL<clsCliparcoeficientcout>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CF_CODECOEFICIENT) AS CF_CODECOEFICIENT  FROM dbo.FT_CLIPARCOEFICIENTCOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CF_CODECOEFICIENT) AS CF_CODECOEFICIENT  FROM dbo.FT_CLIPARCOEFICIENTCOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CF_CODECOEFICIENT) AS CF_CODECOEFICIENT  FROM dbo.FT_CLIPARCOEFICIENTCOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliparcoeficientcout comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliparcoeficientcout pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NT_CODENATURETIERS  , CF_COUTCOEFICIENT  FROM dbo.FT_CLIPARCOEFICIENTCOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliparcoeficientcout clsCliparcoeficientcout = new clsCliparcoeficientcout();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparcoeficientcout.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
					clsCliparcoeficientcout.CF_COUTCOEFICIENT = double.Parse(clsDonnee.vogDataReader["CF_COUTCOEFICIENT"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliparcoeficientcout;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparcoeficientcout>clsCliparcoeficientcout</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliparcoeficientcout clsCliparcoeficientcout)
		{
			//Préparation des paramètres
			SqlParameter vppParamCF_CODECOEFICIENT = new SqlParameter("@CF_CODECOEFICIENT", SqlDbType.VarChar, 50);
			vppParamCF_CODECOEFICIENT.Value  = clsCliparcoeficientcout.CF_CODECOEFICIENT ;
			SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 3);
			vppParamNT_CODENATURETIERS.Value  = clsCliparcoeficientcout.NT_CODENATURETIERS ;
			SqlParameter vppParamCF_COUTCOEFICIENT = new SqlParameter("@CF_COUTCOEFICIENT", SqlDbType.Money);
			vppParamCF_COUTCOEFICIENT.Value  = clsCliparcoeficientcout.CF_COUTCOEFICIENT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENTCOUT  @CF_CODECOEFICIENT, @NT_CODENATURETIERS, @CF_COUTCOEFICIENT, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCF_CODECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
			vppSqlCmd.Parameters.Add(vppParamCF_COUTCOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparcoeficientcout>clsCliparcoeficientcout</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliparcoeficientcout clsCliparcoeficientcout,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCF_CODECOEFICIENT = new SqlParameter("@CF_CODECOEFICIENT", SqlDbType.VarChar, 50);
			vppParamCF_CODECOEFICIENT.Value  = clsCliparcoeficientcout.CF_CODECOEFICIENT ;
			SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 3);
			vppParamNT_CODENATURETIERS.Value  = clsCliparcoeficientcout.NT_CODENATURETIERS ;
			SqlParameter vppParamCF_COUTCOEFICIENT = new SqlParameter("@CF_COUTCOEFICIENT", SqlDbType.Money);
			vppParamCF_COUTCOEFICIENT.Value  = clsCliparcoeficientcout.CF_COUTCOEFICIENT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENTCOUT  @CF_CODECOEFICIENT, @NT_CODENATURETIERS, @CF_COUTCOEFICIENT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCF_CODECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
			vppSqlCmd.Parameters.Add(vppParamCF_COUTCOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENTCOUT  @CF_CODECOEFICIENT, @NT_CODENATURETIERS, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparcoeficientcout </returns>
		///<author>Home Technology</author>
		public List<clsCliparcoeficientcout> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CF_CODECOEFICIENT, NT_CODENATURETIERS, CF_COUTCOEFICIENT FROM dbo.FT_CLIPARCOEFICIENTCOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliparcoeficientcout> clsCliparcoeficientcouts = new List<clsCliparcoeficientcout>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparcoeficientcout clsCliparcoeficientcout = new clsCliparcoeficientcout();
					clsCliparcoeficientcout.CF_CODECOEFICIENT = clsDonnee.vogDataReader["CF_CODECOEFICIENT"].ToString();
					clsCliparcoeficientcout.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
					clsCliparcoeficientcout.CF_COUTCOEFICIENT = double.Parse(clsDonnee.vogDataReader["CF_COUTCOEFICIENT"].ToString());
					clsCliparcoeficientcouts.Add(clsCliparcoeficientcout);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliparcoeficientcouts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparcoeficientcout </returns>
		///<author>Home Technology</author>
		public List<clsCliparcoeficientcout> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliparcoeficientcout> clsCliparcoeficientcouts = new List<clsCliparcoeficientcout>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CF_CODECOEFICIENT, NT_CODENATURETIERS, CF_COUTCOEFICIENT FROM dbo.FT_CLIPARCOEFICIENTCOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliparcoeficientcout clsCliparcoeficientcout = new clsCliparcoeficientcout();
					clsCliparcoeficientcout.CF_CODECOEFICIENT = Dataset.Tables["TABLE"].Rows[Idx]["CF_CODECOEFICIENT"].ToString();
					clsCliparcoeficientcout.NT_CODENATURETIERS = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETIERS"].ToString();
					clsCliparcoeficientcout.CF_COUTCOEFICIENT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CF_COUTCOEFICIENT"].ToString());
					clsCliparcoeficientcouts.Add(clsCliparcoeficientcout);
				}
				Dataset.Dispose();
			}
		return clsCliparcoeficientcouts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARCOEFICIENTCOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CF_CODECOEFICIENT, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CF_CODECOEFICIENT , CF_COUTCOEFICIENT FROM dbo.FT_CLIPARCOEFICIENTCOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CF_CODECOEFICIENT, NT_CODENATURETIERS)</summary>
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
				case 2 :
				this.vapCritere ="WHERE CF_CODECOEFICIENT=@CF_CODECOEFICIENT AND NT_CODENATURETIERS=@NT_CODENATURETIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CF_CODECOEFICIENT","@NT_CODENATURETIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}