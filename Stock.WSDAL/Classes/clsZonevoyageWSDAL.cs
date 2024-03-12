using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsZonevoyageWSDAL: ITableDAL<clsZonevoyage>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(ZM_CODEZONEVOYAGE) AS ZM_CODEZONEVOYAGE  FROM dbo.FT_ZONEVOYAGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(ZM_CODEZONEVOYAGE) AS ZM_CODEZONEVOYAGE  FROM dbo.FT_ZONEVOYAGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(ZM_CODEZONEVOYAGE) AS ZM_CODEZONEVOYAGE  FROM dbo.FT_ZONEVOYAGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsZonevoyage comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsZonevoyage pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ZM_NOMZONEVOYAGE  , ZM_DESCRIPTIONZONEVOYAGE  FROM dbo.FT_ZONEVOYAGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsZonevoyage clsZonevoyage = new clsZonevoyage();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsZonevoyage.ZM_NOMZONEVOYAGE = clsDonnee.vogDataReader["ZM_NOMZONEVOYAGE"].ToString();
					clsZonevoyage.ZM_DESCRIPTIONZONEVOYAGE = clsDonnee.vogDataReader["ZM_DESCRIPTIONZONEVOYAGE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsZonevoyage;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsZonevoyage>clsZonevoyage</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsZonevoyage clsZonevoyage)
		{
			//Préparation des paramètres
			SqlParameter vppParamZM_CODEZONEVOYAGE = new SqlParameter("@ZM_CODEZONEVOYAGE", SqlDbType.VarChar, 7);
			vppParamZM_CODEZONEVOYAGE.Value  = clsZonevoyage.ZM_CODEZONEVOYAGE ;
			SqlParameter vppParamZM_NOMZONEVOYAGE = new SqlParameter("@ZM_NOMZONEVOYAGE", SqlDbType.VarChar, 150);
			vppParamZM_NOMZONEVOYAGE.Value  = clsZonevoyage.ZM_NOMZONEVOYAGE ;
			SqlParameter vppParamZM_DESCRIPTIONZONEVOYAGE = new SqlParameter("@ZM_DESCRIPTIONZONEVOYAGE", SqlDbType.VarChar, 150);
			vppParamZM_DESCRIPTIONZONEVOYAGE.Value  = clsZonevoyage.ZM_DESCRIPTIONZONEVOYAGE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEVOYAGE  @ZM_CODEZONEVOYAGE, @ZM_NOMZONEVOYAGE, @ZM_DESCRIPTIONZONEVOYAGE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZM_CODEZONEVOYAGE);
			vppSqlCmd.Parameters.Add(vppParamZM_NOMZONEVOYAGE);
			vppSqlCmd.Parameters.Add(vppParamZM_DESCRIPTIONZONEVOYAGE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsZonevoyage>clsZonevoyage</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsZonevoyage clsZonevoyage,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamZM_CODEZONEVOYAGE = new SqlParameter("@ZM_CODEZONEVOYAGE", SqlDbType.VarChar, 7);
			vppParamZM_CODEZONEVOYAGE.Value  = clsZonevoyage.ZM_CODEZONEVOYAGE ;
			SqlParameter vppParamZM_NOMZONEVOYAGE = new SqlParameter("@ZM_NOMZONEVOYAGE", SqlDbType.VarChar, 150);
			vppParamZM_NOMZONEVOYAGE.Value  = clsZonevoyage.ZM_NOMZONEVOYAGE ;
			SqlParameter vppParamZM_DESCRIPTIONZONEVOYAGE = new SqlParameter("@ZM_DESCRIPTIONZONEVOYAGE", SqlDbType.VarChar, 150);
			vppParamZM_DESCRIPTIONZONEVOYAGE.Value  = clsZonevoyage.ZM_DESCRIPTIONZONEVOYAGE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEVOYAGE  @ZM_CODEZONEVOYAGE, @ZM_NOMZONEVOYAGE, @ZM_DESCRIPTIONZONEVOYAGE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZM_CODEZONEVOYAGE);
			vppSqlCmd.Parameters.Add(vppParamZM_NOMZONEVOYAGE);
			vppSqlCmd.Parameters.Add(vppParamZM_DESCRIPTIONZONEVOYAGE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEVOYAGE  @ZM_CODEZONEVOYAGE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsZonevoyage </returns>
		///<author>Home Technology</author>
		public List<clsZonevoyage> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ZM_CODEZONEVOYAGE, ZM_NOMZONEVOYAGE, ZM_DESCRIPTIONZONEVOYAGE FROM dbo.FT_ZONEVOYAGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsZonevoyage> clsZonevoyages = new List<clsZonevoyage>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsZonevoyage clsZonevoyage = new clsZonevoyage();
					clsZonevoyage.ZM_CODEZONEVOYAGE = clsDonnee.vogDataReader["ZM_CODEZONEVOYAGE"].ToString();
					clsZonevoyage.ZM_NOMZONEVOYAGE = clsDonnee.vogDataReader["ZM_NOMZONEVOYAGE"].ToString();
					clsZonevoyage.ZM_DESCRIPTIONZONEVOYAGE = clsDonnee.vogDataReader["ZM_DESCRIPTIONZONEVOYAGE"].ToString();
					clsZonevoyages.Add(clsZonevoyage);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsZonevoyages;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsZonevoyage </returns>
		///<author>Home Technology</author>
		public List<clsZonevoyage> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsZonevoyage> clsZonevoyages = new List<clsZonevoyage>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ZM_CODEZONEVOYAGE, ZM_NOMZONEVOYAGE, ZM_DESCRIPTIONZONEVOYAGE FROM dbo.FT_ZONEVOYAGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsZonevoyage clsZonevoyage = new clsZonevoyage();
					clsZonevoyage.ZM_CODEZONEVOYAGE = Dataset.Tables["TABLE"].Rows[Idx]["ZM_CODEZONEVOYAGE"].ToString();
					clsZonevoyage.ZM_NOMZONEVOYAGE = Dataset.Tables["TABLE"].Rows[Idx]["ZM_NOMZONEVOYAGE"].ToString();
					clsZonevoyage.ZM_DESCRIPTIONZONEVOYAGE = Dataset.Tables["TABLE"].Rows[Idx]["ZM_DESCRIPTIONZONEVOYAGE"].ToString();
					clsZonevoyages.Add(clsZonevoyage);
				}
				Dataset.Dispose();
			}
		return clsZonevoyages;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_ZONEVOYAGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : ZM_CODEZONEVOYAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ZM_CODEZONEVOYAGE , ZM_NOMZONEVOYAGE FROM dbo.FT_ZONEVOYAGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :ZM_CODEZONEVOYAGE)</summary>
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
				this.vapCritere ="WHERE ZM_CODEZONEVOYAGE=@ZM_CODEZONEVOYAGE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ZM_CODEZONEVOYAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
