using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparsituationdossiersinistreWSDAL: ITableDAL<clsCtparsituationdossiersinistre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(SD_CODESITUATIONDOSSIER) AS SD_CODESITUATIONDOSSIER  FROM dbo.FT_CTPARSITUATIONDOSSIERSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(SD_CODESITUATIONDOSSIER) AS SD_CODESITUATIONDOSSIER  FROM dbo.FT_CTPARSITUATIONDOSSIERSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(SD_CODESITUATIONDOSSIER) AS SD_CODESITUATIONDOSSIER  FROM dbo.FT_CTPARSITUATIONDOSSIERSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparsituationdossiersinistre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparsituationdossiersinistre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SD_LIBELLESITUATIONDOSSIER  , SD_ACTIFSITUATIONDOSSIER  , SD_NUMEROORDRESITUATIONDOSSIER  FROM dbo.FT_CTPARSITUATIONDOSSIERSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparsituationdossiersinistre clsCtparsituationdossiersinistre = new clsCtparsituationdossiersinistre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparsituationdossiersinistre.SD_LIBELLESITUATIONDOSSIER = clsDonnee.vogDataReader["SD_LIBELLESITUATIONDOSSIER"].ToString();
					clsCtparsituationdossiersinistre.SD_ACTIFSITUATIONDOSSIER = clsDonnee.vogDataReader["SD_ACTIFSITUATIONDOSSIER"].ToString();
					clsCtparsituationdossiersinistre.SD_NUMEROORDRESITUATIONDOSSIER = int.Parse(clsDonnee.vogDataReader["SD_NUMEROORDRESITUATIONDOSSIER"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparsituationdossiersinistre;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparsituationdossiersinistre>clsCtparsituationdossiersinistre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparsituationdossiersinistre clsCtparsituationdossiersinistre)
		{
			//Préparation des paramètres
			SqlParameter vppParamSD_CODESITUATIONDOSSIER = new SqlParameter("@SD_CODESITUATIONDOSSIER", SqlDbType.VarChar, 2);
			vppParamSD_CODESITUATIONDOSSIER.Value  = clsCtparsituationdossiersinistre.SD_CODESITUATIONDOSSIER ;
			SqlParameter vppParamSD_LIBELLESITUATIONDOSSIER = new SqlParameter("@SD_LIBELLESITUATIONDOSSIER", SqlDbType.VarChar, 150);
			vppParamSD_LIBELLESITUATIONDOSSIER.Value  = clsCtparsituationdossiersinistre.SD_LIBELLESITUATIONDOSSIER ;
			SqlParameter vppParamSD_ACTIFSITUATIONDOSSIER = new SqlParameter("@SD_ACTIFSITUATIONDOSSIER", SqlDbType.VarChar, 1);
			vppParamSD_ACTIFSITUATIONDOSSIER.Value  = clsCtparsituationdossiersinistre.SD_ACTIFSITUATIONDOSSIER ;
			SqlParameter vppParamSD_NUMEROORDRESITUATIONDOSSIER = new SqlParameter("@SD_NUMEROORDRESITUATIONDOSSIER", SqlDbType.Int);
			vppParamSD_NUMEROORDRESITUATIONDOSSIER.Value  = clsCtparsituationdossiersinistre.SD_NUMEROORDRESITUATIONDOSSIER ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSITUATIONDOSSIERSINISTRE  @SD_CODESITUATIONDOSSIER, @SD_LIBELLESITUATIONDOSSIER, @SD_ACTIFSITUATIONDOSSIER, @SD_NUMEROORDRESITUATIONDOSSIER, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSD_CODESITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamSD_LIBELLESITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamSD_ACTIFSITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamSD_NUMEROORDRESITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparsituationdossiersinistre>clsCtparsituationdossiersinistre</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparsituationdossiersinistre clsCtparsituationdossiersinistre,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamSD_CODESITUATIONDOSSIER = new SqlParameter("@SD_CODESITUATIONDOSSIER", SqlDbType.VarChar, 2);
			vppParamSD_CODESITUATIONDOSSIER.Value  = clsCtparsituationdossiersinistre.SD_CODESITUATIONDOSSIER ;
			SqlParameter vppParamSD_LIBELLESITUATIONDOSSIER = new SqlParameter("@SD_LIBELLESITUATIONDOSSIER", SqlDbType.VarChar, 150);
			vppParamSD_LIBELLESITUATIONDOSSIER.Value  = clsCtparsituationdossiersinistre.SD_LIBELLESITUATIONDOSSIER ;
			SqlParameter vppParamSD_ACTIFSITUATIONDOSSIER = new SqlParameter("@SD_ACTIFSITUATIONDOSSIER", SqlDbType.VarChar, 1);
			vppParamSD_ACTIFSITUATIONDOSSIER.Value  = clsCtparsituationdossiersinistre.SD_ACTIFSITUATIONDOSSIER ;
			SqlParameter vppParamSD_NUMEROORDRESITUATIONDOSSIER = new SqlParameter("@SD_NUMEROORDRESITUATIONDOSSIER", SqlDbType.Int);
			vppParamSD_NUMEROORDRESITUATIONDOSSIER.Value  = clsCtparsituationdossiersinistre.SD_NUMEROORDRESITUATIONDOSSIER ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSITUATIONDOSSIERSINISTRE  @SD_CODESITUATIONDOSSIER, @SD_LIBELLESITUATIONDOSSIER, @SD_ACTIFSITUATIONDOSSIER, @SD_NUMEROORDRESITUATIONDOSSIER, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSD_CODESITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamSD_LIBELLESITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamSD_ACTIFSITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamSD_NUMEROORDRESITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSITUATIONDOSSIERSINISTRE  @SD_CODESITUATIONDOSSIER, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparsituationdossiersinistre </returns>
		///<author>Home Technology</author>
		public List<clsCtparsituationdossiersinistre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SD_CODESITUATIONDOSSIER, SD_LIBELLESITUATIONDOSSIER, SD_ACTIFSITUATIONDOSSIER, SD_NUMEROORDRESITUATIONDOSSIER FROM dbo.FT_CTPARSITUATIONDOSSIERSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparsituationdossiersinistre> clsCtparsituationdossiersinistres = new List<clsCtparsituationdossiersinistre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparsituationdossiersinistre clsCtparsituationdossiersinistre = new clsCtparsituationdossiersinistre();
					clsCtparsituationdossiersinistre.SD_CODESITUATIONDOSSIER = clsDonnee.vogDataReader["SD_CODESITUATIONDOSSIER"].ToString();
					clsCtparsituationdossiersinistre.SD_LIBELLESITUATIONDOSSIER = clsDonnee.vogDataReader["SD_LIBELLESITUATIONDOSSIER"].ToString();
					clsCtparsituationdossiersinistre.SD_ACTIFSITUATIONDOSSIER = clsDonnee.vogDataReader["SD_ACTIFSITUATIONDOSSIER"].ToString();
					clsCtparsituationdossiersinistre.SD_NUMEROORDRESITUATIONDOSSIER = int.Parse(clsDonnee.vogDataReader["SD_NUMEROORDRESITUATIONDOSSIER"].ToString());
					clsCtparsituationdossiersinistres.Add(clsCtparsituationdossiersinistre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparsituationdossiersinistres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparsituationdossiersinistre </returns>
		///<author>Home Technology</author>
		public List<clsCtparsituationdossiersinistre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparsituationdossiersinistre> clsCtparsituationdossiersinistres = new List<clsCtparsituationdossiersinistre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SD_CODESITUATIONDOSSIER, SD_LIBELLESITUATIONDOSSIER, SD_ACTIFSITUATIONDOSSIER, SD_NUMEROORDRESITUATIONDOSSIER FROM dbo.FT_CTPARSITUATIONDOSSIERSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparsituationdossiersinistre clsCtparsituationdossiersinistre = new clsCtparsituationdossiersinistre();
					clsCtparsituationdossiersinistre.SD_CODESITUATIONDOSSIER = Dataset.Tables["TABLE"].Rows[Idx]["SD_CODESITUATIONDOSSIER"].ToString();
					clsCtparsituationdossiersinistre.SD_LIBELLESITUATIONDOSSIER = Dataset.Tables["TABLE"].Rows[Idx]["SD_LIBELLESITUATIONDOSSIER"].ToString();
					clsCtparsituationdossiersinistre.SD_ACTIFSITUATIONDOSSIER = Dataset.Tables["TABLE"].Rows[Idx]["SD_ACTIFSITUATIONDOSSIER"].ToString();
					clsCtparsituationdossiersinistre.SD_NUMEROORDRESITUATIONDOSSIER = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SD_NUMEROORDRESITUATIONDOSSIER"].ToString());
					clsCtparsituationdossiersinistres.Add(clsCtparsituationdossiersinistre);
				}
				Dataset.Dispose();
			}
		return clsCtparsituationdossiersinistres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARSITUATIONDOSSIERSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SD_CODESITUATIONDOSSIER , SD_LIBELLESITUATIONDOSSIER FROM dbo.FT_CTPARSITUATIONDOSSIERSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SD_CODESITUATIONDOSSIER)</summary>
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
				this.vapCritere ="WHERE SD_CODESITUATIONDOSSIER=@SD_CODESITUATIONDOSSIER";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SD_CODESITUATIONDOSSIER"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
