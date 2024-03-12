using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsTresorerieparamnaturepostetresorerieWSDAL: ITableDAL<clsTresorerieparamnaturepostetresorerie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TN_CODENATUREPOSTETRESORERIE) AS TN_CODENATUREPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMNATUREPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TN_CODENATUREPOSTETRESORERIE) AS TN_CODENATUREPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMNATUREPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TN_CODENATUREPOSTETRESORERIE) AS TN_CODENATUREPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMNATUREPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsTresorerieparamnaturepostetresorerie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsTresorerieparamnaturepostetresorerie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TN_LIBELLE  , TN_NUMEROORDRE  FROM dbo.FT_TRESORERIEPARAMNATUREPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsTresorerieparamnaturepostetresorerie clsTresorerieparamnaturepostetresorerie = new clsTresorerieparamnaturepostetresorerie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTresorerieparamnaturepostetresorerie.TN_LIBELLE = clsDonnee.vogDataReader["TN_LIBELLE"].ToString();
					clsTresorerieparamnaturepostetresorerie.TN_NUMEROORDRE = clsDonnee.vogDataReader["TN_NUMEROORDRE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsTresorerieparamnaturepostetresorerie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieparamnaturepostetresorerie>clsTresorerieparamnaturepostetresorerie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsTresorerieparamnaturepostetresorerie clsTresorerieparamnaturepostetresorerie)
		{
			//Préparation des paramètres
			SqlParameter vppParamTN_CODENATUREPOSTETRESORERIE = new SqlParameter("@TN_CODENATUREPOSTETRESORERIE", SqlDbType.VarChar, 3);
			vppParamTN_CODENATUREPOSTETRESORERIE.Value  = clsTresorerieparamnaturepostetresorerie.TN_CODENATUREPOSTETRESORERIE ;
			SqlParameter vppParamTN_LIBELLE = new SqlParameter("@TN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTN_LIBELLE.Value  = clsTresorerieparamnaturepostetresorerie.TN_LIBELLE ;
			SqlParameter vppParamTN_NUMEROORDRE = new SqlParameter("@TN_NUMEROORDRE", SqlDbType.VarChar, 25);
			vppParamTN_NUMEROORDRE.Value  = clsTresorerieparamnaturepostetresorerie.TN_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMNATUREPOSTETRESORERIE  @TN_CODENATUREPOSTETRESORERIE, @TN_LIBELLE, @TN_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTN_CODENATUREPOSTETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTN_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieparamnaturepostetresorerie>clsTresorerieparamnaturepostetresorerie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsTresorerieparamnaturepostetresorerie clsTresorerieparamnaturepostetresorerie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTN_CODENATUREPOSTETRESORERIE = new SqlParameter("@TN_CODENATUREPOSTETRESORERIE", SqlDbType.VarChar, 3);
			vppParamTN_CODENATUREPOSTETRESORERIE.Value  = clsTresorerieparamnaturepostetresorerie.TN_CODENATUREPOSTETRESORERIE ;
			SqlParameter vppParamTN_LIBELLE = new SqlParameter("@TN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTN_LIBELLE.Value  = clsTresorerieparamnaturepostetresorerie.TN_LIBELLE ;
			SqlParameter vppParamTN_NUMEROORDRE = new SqlParameter("@TN_NUMEROORDRE", SqlDbType.VarChar, 25);
			vppParamTN_NUMEROORDRE.Value  = clsTresorerieparamnaturepostetresorerie.TN_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMNATUREPOSTETRESORERIE  @TN_CODENATUREPOSTETRESORERIE, @TN_LIBELLE, @TN_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTN_CODENATUREPOSTETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTN_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMNATUREPOSTETRESORERIE  @TN_CODENATUREPOSTETRESORERIE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieparamnaturepostetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparamnaturepostetresorerie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TN_CODENATUREPOSTETRESORERIE, TN_LIBELLE, TN_NUMEROORDRE FROM dbo.FT_TRESORERIEPARAMNATUREPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsTresorerieparamnaturepostetresorerie> clsTresorerieparamnaturepostetresoreries = new List<clsTresorerieparamnaturepostetresorerie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTresorerieparamnaturepostetresorerie clsTresorerieparamnaturepostetresorerie = new clsTresorerieparamnaturepostetresorerie();
					clsTresorerieparamnaturepostetresorerie.TN_CODENATUREPOSTETRESORERIE = clsDonnee.vogDataReader["TN_CODENATUREPOSTETRESORERIE"].ToString();
					clsTresorerieparamnaturepostetresorerie.TN_LIBELLE = clsDonnee.vogDataReader["TN_LIBELLE"].ToString();
					clsTresorerieparamnaturepostetresorerie.TN_NUMEROORDRE = clsDonnee.vogDataReader["TN_NUMEROORDRE"].ToString();
					clsTresorerieparamnaturepostetresoreries.Add(clsTresorerieparamnaturepostetresorerie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsTresorerieparamnaturepostetresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieparamnaturepostetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparamnaturepostetresorerie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsTresorerieparamnaturepostetresorerie> clsTresorerieparamnaturepostetresoreries = new List<clsTresorerieparamnaturepostetresorerie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TN_CODENATUREPOSTETRESORERIE, TN_LIBELLE, TN_NUMEROORDRE FROM dbo.FT_TRESORERIEPARAMNATUREPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsTresorerieparamnaturepostetresorerie clsTresorerieparamnaturepostetresorerie = new clsTresorerieparamnaturepostetresorerie();
					clsTresorerieparamnaturepostetresorerie.TN_CODENATUREPOSTETRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TN_CODENATUREPOSTETRESORERIE"].ToString();
					clsTresorerieparamnaturepostetresorerie.TN_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TN_LIBELLE"].ToString();
					clsTresorerieparamnaturepostetresorerie.TN_NUMEROORDRE = Dataset.Tables["TABLE"].Rows[Idx]["TN_NUMEROORDRE"].ToString();
					clsTresorerieparamnaturepostetresoreries.Add(clsTresorerieparamnaturepostetresorerie);
				}
				Dataset.Dispose();
			}
		return clsTresorerieparamnaturepostetresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_TRESORERIEPARAMNATUREPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY TN_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TN_CODENATUREPOSTETRESORERIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TN_CODENATUREPOSTETRESORERIE , TN_LIBELLE FROM dbo.FT_TRESORERIEPARAMNATUREPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY TN_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TN_CODENATUREPOSTETRESORERIE)</summary>
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
				this.vapCritere ="WHERE TN_CODENATUREPOSTETRESORERIE=@TN_CODENATUREPOSTETRESORERIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TN_CODENATUREPOSTETRESORERIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
