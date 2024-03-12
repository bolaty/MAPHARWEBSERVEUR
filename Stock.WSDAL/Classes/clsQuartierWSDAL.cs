using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsQuartierWSDAL: ITableDAL<clsQuartier>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(QU_CODEQUARTIER) AS QU_CODEQUARTIER  FROM dbo.FT_QUARTIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(QU_CODEQUARTIER) AS QU_CODEQUARTIER  FROM dbo.FT_QUARTIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(QU_CODEQUARTIER) AS QU_CODEQUARTIER  FROM dbo.FT_QUARTIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsQuartier comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsQuartier pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CO_CODECOMMUNE  , QU_LIBELLE  FROM dbo.FT_QUARTIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsQuartier clsQuartier = new clsQuartier();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsQuartier.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();
					clsQuartier.QU_LIBELLE = clsDonnee.vogDataReader["QU_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsQuartier;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsQuartier>clsQuartier</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsQuartier clsQuartier)
		{
			//Préparation des paramètres
			SqlParameter vppParamQU_CODEQUARTIER = new SqlParameter("@QU_CODEQUARTIER1", SqlDbType.VarChar, 12);
			vppParamQU_CODEQUARTIER.Value  = clsQuartier.QU_CODEQUARTIER ;
			SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE1", SqlDbType.VarChar, 10);
			vppParamCO_CODECOMMUNE.Value  = clsQuartier.CO_CODECOMMUNE ;
			SqlParameter vppParamQU_LIBELLE = new SqlParameter("@QU_LIBELLE", SqlDbType.VarChar, 150);
			vppParamQU_LIBELLE.Value  = clsQuartier.QU_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_QUARTIER  @QU_CODEQUARTIER1, @CO_CODECOMMUNE1, @QU_LIBELLE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamQU_CODEQUARTIER);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
			vppSqlCmd.Parameters.Add(vppParamQU_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsQuartier>clsQuartier</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsQuartier clsQuartier,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamQU_CODEQUARTIER = new SqlParameter("@QU_CODEQUARTIER", SqlDbType.VarChar, 12);
			vppParamQU_CODEQUARTIER.Value  = clsQuartier.QU_CODEQUARTIER ;
			SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
			vppParamCO_CODECOMMUNE.Value  = clsQuartier.CO_CODECOMMUNE ;
			SqlParameter vppParamQU_LIBELLE = new SqlParameter("@QU_LIBELLE", SqlDbType.VarChar, 150);
			vppParamQU_LIBELLE.Value  = clsQuartier.QU_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_QUARTIER  @QU_CODEQUARTIER, @CO_CODECOMMUNE, @QU_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamQU_CODEQUARTIER);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
			vppSqlCmd.Parameters.Add(vppParamQU_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_QUARTIER  @QU_CODEQUARTIER, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsQuartier </returns>
		///<author>Home Technology</author>
		public List<clsQuartier> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  QU_CODEQUARTIER, CO_CODECOMMUNE, QU_LIBELLE FROM dbo.FT_QUARTIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsQuartier> clsQuartiers = new List<clsQuartier>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsQuartier clsQuartier = new clsQuartier();
					clsQuartier.QU_CODEQUARTIER = clsDonnee.vogDataReader["QU_CODEQUARTIER"].ToString();
					clsQuartier.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();
					clsQuartier.QU_LIBELLE = clsDonnee.vogDataReader["QU_LIBELLE"].ToString();
					clsQuartiers.Add(clsQuartier);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsQuartiers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsQuartier </returns>
		///<author>Home Technology</author>
		public List<clsQuartier> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsQuartier> clsQuartiers = new List<clsQuartier>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  QU_CODEQUARTIER, CO_CODECOMMUNE, QU_LIBELLE FROM dbo.FT_QUARTIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsQuartier clsQuartier = new clsQuartier();
					clsQuartier.QU_CODEQUARTIER = Dataset.Tables["TABLE"].Rows[Idx]["QU_CODEQUARTIER"].ToString();
					clsQuartier.CO_CODECOMMUNE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMMUNE"].ToString();
					clsQuartier.QU_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["QU_LIBELLE"].ToString();
					clsQuartiers.Add(clsQuartier);
				}
				Dataset.Dispose();
			}
		return clsQuartiers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_QUARTIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : QU_CODEQUARTIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT QU_CODEQUARTIER , QU_LIBELLE FROM dbo.FT_QUARTIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :QU_CODEQUARTIER)</summary>
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
                case 1:
                    this.vapCritere = "WHERE CO_CODECOMMUNE=@CO_CODECOMMUNE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CO_CODECOMMUNE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                 break;

                case 2:
                this.vapCritere = "WHERE CO_CODECOMMUNE=@CO_CODECOMMUNE AND QU_CODEQUARTIER=@QU_CODEQUARTIER  ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@CO_CODECOMMUNE", "@QU_CODEQUARTIER" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                break;
            }
		}
	}
}
