using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsZoneautoWSDAL: ITableDAL<clsZoneauto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(ZA_CODEZONEAUTO) AS ZA_CODEZONEAUTO  FROM dbo.FT_ZONEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(ZA_CODEZONEAUTO) AS ZA_CODEZONEAUTO  FROM dbo.FT_ZONEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(ZA_CODEZONEAUTO) AS ZA_CODEZONEAUTO  FROM dbo.FT_ZONEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsZoneauto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsZoneauto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ZA_NOMZONEAUTO  , ZA_DESCRIPTIONZONEAUTO  FROM dbo.FT_ZONEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsZoneauto clsZoneauto = new clsZoneauto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsZoneauto.ZA_NOMZONEAUTO = clsDonnee.vogDataReader["ZA_NOMZONEAUTO"].ToString();
					clsZoneauto.ZA_DESCRIPTIONZONEAUTO = clsDonnee.vogDataReader["ZA_DESCRIPTIONZONEAUTO"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsZoneauto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsZoneauto>clsZoneauto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsZoneauto clsZoneauto)
		{
			//Préparation des paramètres
			SqlParameter vppParamZA_CODEZONEAUTO = new SqlParameter("@ZA_CODEZONEAUTO", SqlDbType.VarChar, 7);
			vppParamZA_CODEZONEAUTO.Value  = clsZoneauto.ZA_CODEZONEAUTO ;
			SqlParameter vppParamZA_NOMZONEAUTO = new SqlParameter("@ZA_NOMZONEAUTO", SqlDbType.VarChar, 150);
			vppParamZA_NOMZONEAUTO.Value  = clsZoneauto.ZA_NOMZONEAUTO ;
			SqlParameter vppParamZA_DESCRIPTIONZONEAUTO = new SqlParameter("@ZA_DESCRIPTIONZONEAUTO", SqlDbType.VarChar, 150);
			vppParamZA_DESCRIPTIONZONEAUTO.Value  = clsZoneauto.ZA_DESCRIPTIONZONEAUTO ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEAUTO  @ZA_CODEZONEAUTO, @ZA_NOMZONEAUTO, @ZA_DESCRIPTIONZONEAUTO, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZA_CODEZONEAUTO);
			vppSqlCmd.Parameters.Add(vppParamZA_NOMZONEAUTO);
			vppSqlCmd.Parameters.Add(vppParamZA_DESCRIPTIONZONEAUTO);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsZoneauto>clsZoneauto</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsZoneauto clsZoneauto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamZA_CODEZONEAUTO = new SqlParameter("@ZA_CODEZONEAUTO", SqlDbType.VarChar, 7);
			vppParamZA_CODEZONEAUTO.Value  = clsZoneauto.ZA_CODEZONEAUTO ;
			SqlParameter vppParamZA_NOMZONEAUTO = new SqlParameter("@ZA_NOMZONEAUTO", SqlDbType.VarChar, 150);
			vppParamZA_NOMZONEAUTO.Value  = clsZoneauto.ZA_NOMZONEAUTO ;
			SqlParameter vppParamZA_DESCRIPTIONZONEAUTO = new SqlParameter("@ZA_DESCRIPTIONZONEAUTO", SqlDbType.VarChar, 150);
			vppParamZA_DESCRIPTIONZONEAUTO.Value  = clsZoneauto.ZA_DESCRIPTIONZONEAUTO ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEAUTO  @ZA_CODEZONEAUTO, @ZA_NOMZONEAUTO, @ZA_DESCRIPTIONZONEAUTO, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZA_CODEZONEAUTO);
			vppSqlCmd.Parameters.Add(vppParamZA_NOMZONEAUTO);
			vppSqlCmd.Parameters.Add(vppParamZA_DESCRIPTIONZONEAUTO);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_ZONEAUTO  @ZA_CODEZONEAUTO, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsZoneauto </returns>
		///<author>Home Technology</author>
		public List<clsZoneauto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ZA_CODEZONEAUTO, ZA_NOMZONEAUTO, ZA_DESCRIPTIONZONEAUTO FROM dbo.FT_ZONEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsZoneauto> clsZoneautos = new List<clsZoneauto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsZoneauto clsZoneauto = new clsZoneauto();
					clsZoneauto.ZA_CODEZONEAUTO = clsDonnee.vogDataReader["ZA_CODEZONEAUTO"].ToString();
					clsZoneauto.ZA_NOMZONEAUTO = clsDonnee.vogDataReader["ZA_NOMZONEAUTO"].ToString();
					clsZoneauto.ZA_DESCRIPTIONZONEAUTO = clsDonnee.vogDataReader["ZA_DESCRIPTIONZONEAUTO"].ToString();
					clsZoneautos.Add(clsZoneauto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsZoneautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsZoneauto </returns>
		///<author>Home Technology</author>
		public List<clsZoneauto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsZoneauto> clsZoneautos = new List<clsZoneauto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ZA_CODEZONEAUTO, ZA_NOMZONEAUTO, ZA_DESCRIPTIONZONEAUTO FROM dbo.FT_ZONEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsZoneauto clsZoneauto = new clsZoneauto();
					clsZoneauto.ZA_CODEZONEAUTO = Dataset.Tables["TABLE"].Rows[Idx]["ZA_CODEZONEAUTO"].ToString();
					clsZoneauto.ZA_NOMZONEAUTO = Dataset.Tables["TABLE"].Rows[Idx]["ZA_NOMZONEAUTO"].ToString();
					clsZoneauto.ZA_DESCRIPTIONZONEAUTO = Dataset.Tables["TABLE"].Rows[Idx]["ZA_DESCRIPTIONZONEAUTO"].ToString();
					clsZoneautos.Add(clsZoneauto);
				}
				Dataset.Dispose();
			}
		return clsZoneautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_ZONEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : ZA_CODEZONEAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ZA_CODEZONEAUTO , ZA_NOMZONEAUTO FROM dbo.FT_ZONEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :ZA_CODEZONEAUTO)</summary>
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
				this.vapCritere ="WHERE ZA_CODEZONEAUTO=@ZA_CODEZONEAUTO";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ZA_CODEZONEAUTO"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
