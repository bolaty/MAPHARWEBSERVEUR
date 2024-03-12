using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsZonemaladieWSDAL: ITableDAL<clsZonemaladie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(ZM_CODEZONEMALADIE) AS ZM_CODEZONEMALADIE  FROM dbo.FT_ZONEMALADIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(ZM_CODEZONEMALADIE) AS ZM_CODEZONEMALADIE  FROM dbo.FT_ZONEMALADIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(ZM_CODEZONEMALADIE) AS ZM_CODEZONEMALADIE  FROM dbo.FT_ZONEMALADIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsZonemaladie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsZonemaladie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ZM_NOMZONEMALADIE  , ZM_DESCRIPTIONZONEMALADIE  FROM dbo.FT_ZONEMALADIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsZonemaladie clsZonemaladie = new clsZonemaladie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsZonemaladie.ZM_NOMZONEMALADIE = clsDonnee.vogDataReader["ZM_NOMZONEMALADIE"].ToString();
					clsZonemaladie.ZM_DESCRIPTIONZONEMALADIE = clsDonnee.vogDataReader["ZM_DESCRIPTIONZONEMALADIE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsZonemaladie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsZonemaladie>clsZonemaladie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsZonemaladie clsZonemaladie)
		{
			//Préparation des paramètres
			SqlParameter vppParamZM_CODEZONEMALADIE = new SqlParameter("@ZM_CODEZONEMALADIE", SqlDbType.VarChar, 7);
			vppParamZM_CODEZONEMALADIE.Value  = clsZonemaladie.ZM_CODEZONEMALADIE ;
			SqlParameter vppParamZM_NOMZONEMALADIE = new SqlParameter("@ZM_NOMZONEMALADIE", SqlDbType.VarChar, 150);
			vppParamZM_NOMZONEMALADIE.Value  = clsZonemaladie.ZM_NOMZONEMALADIE ;
			SqlParameter vppParamZM_DESCRIPTIONZONEMALADIE = new SqlParameter("@ZM_DESCRIPTIONZONEMALADIE", SqlDbType.VarChar, 150);
			vppParamZM_DESCRIPTIONZONEMALADIE.Value  = clsZonemaladie.ZM_DESCRIPTIONZONEMALADIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEMALADIE  @ZM_CODEZONEMALADIE, @ZM_NOMZONEMALADIE, @ZM_DESCRIPTIONZONEMALADIE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZM_CODEZONEMALADIE);
			vppSqlCmd.Parameters.Add(vppParamZM_NOMZONEMALADIE);
			vppSqlCmd.Parameters.Add(vppParamZM_DESCRIPTIONZONEMALADIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsZonemaladie>clsZonemaladie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsZonemaladie clsZonemaladie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamZM_CODEZONEMALADIE = new SqlParameter("@ZM_CODEZONEMALADIE", SqlDbType.VarChar, 7);
			vppParamZM_CODEZONEMALADIE.Value  = clsZonemaladie.ZM_CODEZONEMALADIE ;
			SqlParameter vppParamZM_NOMZONEMALADIE = new SqlParameter("@ZM_NOMZONEMALADIE", SqlDbType.VarChar, 150);
			vppParamZM_NOMZONEMALADIE.Value  = clsZonemaladie.ZM_NOMZONEMALADIE ;
			SqlParameter vppParamZM_DESCRIPTIONZONEMALADIE = new SqlParameter("@ZM_DESCRIPTIONZONEMALADIE", SqlDbType.VarChar, 150);
			vppParamZM_DESCRIPTIONZONEMALADIE.Value  = clsZonemaladie.ZM_DESCRIPTIONZONEMALADIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEMALADIE  @ZM_CODEZONEMALADIE, @ZM_NOMZONEMALADIE, @ZM_DESCRIPTIONZONEMALADIE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZM_CODEZONEMALADIE);
			vppSqlCmd.Parameters.Add(vppParamZM_NOMZONEMALADIE);
			vppSqlCmd.Parameters.Add(vppParamZM_DESCRIPTIONZONEMALADIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEMALADIE  @ZM_CODEZONEMALADIE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsZonemaladie </returns>
		///<author>Home Technology</author>
		public List<clsZonemaladie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ZM_CODEZONEMALADIE, ZM_NOMZONEMALADIE, ZM_DESCRIPTIONZONEMALADIE FROM dbo.FT_ZONEMALADIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsZonemaladie> clsZonemaladies = new List<clsZonemaladie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsZonemaladie clsZonemaladie = new clsZonemaladie();
					clsZonemaladie.ZM_CODEZONEMALADIE = clsDonnee.vogDataReader["ZM_CODEZONEMALADIE"].ToString();
					clsZonemaladie.ZM_NOMZONEMALADIE = clsDonnee.vogDataReader["ZM_NOMZONEMALADIE"].ToString();
					clsZonemaladie.ZM_DESCRIPTIONZONEMALADIE = clsDonnee.vogDataReader["ZM_DESCRIPTIONZONEMALADIE"].ToString();
					clsZonemaladies.Add(clsZonemaladie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsZonemaladies;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsZonemaladie </returns>
		///<author>Home Technology</author>
		public List<clsZonemaladie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsZonemaladie> clsZonemaladies = new List<clsZonemaladie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ZM_CODEZONEMALADIE, ZM_NOMZONEMALADIE, ZM_DESCRIPTIONZONEMALADIE FROM dbo.FT_ZONEMALADIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsZonemaladie clsZonemaladie = new clsZonemaladie();
					clsZonemaladie.ZM_CODEZONEMALADIE = Dataset.Tables["TABLE"].Rows[Idx]["ZM_CODEZONEMALADIE"].ToString();
					clsZonemaladie.ZM_NOMZONEMALADIE = Dataset.Tables["TABLE"].Rows[Idx]["ZM_NOMZONEMALADIE"].ToString();
					clsZonemaladie.ZM_DESCRIPTIONZONEMALADIE = Dataset.Tables["TABLE"].Rows[Idx]["ZM_DESCRIPTIONZONEMALADIE"].ToString();
					clsZonemaladies.Add(clsZonemaladie);
				}
				Dataset.Dispose();
			}
		return clsZonemaladies;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_ZONEMALADIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : ZM_CODEZONEMALADIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ZM_CODEZONEMALADIE , ZM_NOMZONEMALADIE FROM dbo.FT_ZONEMALADIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :ZM_CODEZONEMALADIE)</summary>
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
				this.vapCritere ="WHERE ZM_CODEZONEMALADIE=@ZM_CODEZONEMALADIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ZM_CODEZONEMALADIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
