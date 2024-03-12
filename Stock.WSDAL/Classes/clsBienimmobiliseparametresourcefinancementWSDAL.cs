using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBienimmobiliseparametresourcefinancementWSDAL: ITableDAL<clsBienimmobiliseparametresourcefinancement>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(SF_CODESOURCEFINANCEMENT) AS SF_CODESOURCEFINANCEMENT  FROM dbo.FT_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(SF_CODESOURCEFINANCEMENT) AS SF_CODESOURCEFINANCEMENT  FROM dbo.FT_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(SF_CODESOURCEFINANCEMENT) AS SF_CODESOURCEFINANCEMENT  FROM dbo.FT_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBienimmobiliseparametresourcefinancement comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBienimmobiliseparametresourcefinancement pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SF_LIBELLE  FROM dbo.FT_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBienimmobiliseparametresourcefinancement clsBienimmobiliseparametresourcefinancement = new clsBienimmobiliseparametresourcefinancement();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBienimmobiliseparametresourcefinancement.SF_LIBELLE = clsDonnee.vogDataReader["SF_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBienimmobiliseparametresourcefinancement;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBienimmobiliseparametresourcefinancement>clsBienimmobiliseparametresourcefinancement</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBienimmobiliseparametresourcefinancement clsBienimmobiliseparametresourcefinancement)
		{
			//Préparation des paramètres
			SqlParameter vppParamSF_CODESOURCEFINANCEMENT = new SqlParameter("@SF_CODESOURCEFINANCEMENT", SqlDbType.VarChar, 2);
			vppParamSF_CODESOURCEFINANCEMENT.Value  = clsBienimmobiliseparametresourcefinancement.SF_CODESOURCEFINANCEMENT ;
			SqlParameter vppParamSF_LIBELLE = new SqlParameter("@SF_LIBELLE", SqlDbType.VarChar, 500);
			vppParamSF_LIBELLE.Value  = clsBienimmobiliseparametresourcefinancement.SF_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT  @SF_CODESOURCEFINANCEMENT, @SF_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSF_CODESOURCEFINANCEMENT);
			vppSqlCmd.Parameters.Add(vppParamSF_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBienimmobiliseparametresourcefinancement>clsBienimmobiliseparametresourcefinancement</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBienimmobiliseparametresourcefinancement clsBienimmobiliseparametresourcefinancement,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamSF_CODESOURCEFINANCEMENT = new SqlParameter("@SF_CODESOURCEFINANCEMENT", SqlDbType.VarChar, 2);
			vppParamSF_CODESOURCEFINANCEMENT.Value  = clsBienimmobiliseparametresourcefinancement.SF_CODESOURCEFINANCEMENT ;
			SqlParameter vppParamSF_LIBELLE = new SqlParameter("@SF_LIBELLE", SqlDbType.VarChar, 500);
			vppParamSF_LIBELLE.Value  = clsBienimmobiliseparametresourcefinancement.SF_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT  @SF_CODESOURCEFINANCEMENT, @SF_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSF_CODESOURCEFINANCEMENT);
			vppSqlCmd.Parameters.Add(vppParamSF_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT  @SF_CODESOURCEFINANCEMENT, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBienimmobiliseparametresourcefinancement </returns>
		///<author>Home Technology</author>
		public List<clsBienimmobiliseparametresourcefinancement> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SF_CODESOURCEFINANCEMENT, SF_LIBELLE FROM dbo.FT_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBienimmobiliseparametresourcefinancement> clsBienimmobiliseparametresourcefinancements = new List<clsBienimmobiliseparametresourcefinancement>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBienimmobiliseparametresourcefinancement clsBienimmobiliseparametresourcefinancement = new clsBienimmobiliseparametresourcefinancement();
					clsBienimmobiliseparametresourcefinancement.SF_CODESOURCEFINANCEMENT = clsDonnee.vogDataReader["SF_CODESOURCEFINANCEMENT"].ToString();
					clsBienimmobiliseparametresourcefinancement.SF_LIBELLE = clsDonnee.vogDataReader["SF_LIBELLE"].ToString();
					clsBienimmobiliseparametresourcefinancements.Add(clsBienimmobiliseparametresourcefinancement);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBienimmobiliseparametresourcefinancements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBienimmobiliseparametresourcefinancement </returns>
		///<author>Home Technology</author>
		public List<clsBienimmobiliseparametresourcefinancement> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBienimmobiliseparametresourcefinancement> clsBienimmobiliseparametresourcefinancements = new List<clsBienimmobiliseparametresourcefinancement>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SF_CODESOURCEFINANCEMENT, SF_LIBELLE FROM dbo.FT_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBienimmobiliseparametresourcefinancement clsBienimmobiliseparametresourcefinancement = new clsBienimmobiliseparametresourcefinancement();
					clsBienimmobiliseparametresourcefinancement.SF_CODESOURCEFINANCEMENT = Dataset.Tables["TABLE"].Rows[Idx]["SF_CODESOURCEFINANCEMENT"].ToString();
					clsBienimmobiliseparametresourcefinancement.SF_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["SF_LIBELLE"].ToString();
					clsBienimmobiliseparametresourcefinancements.Add(clsBienimmobiliseparametresourcefinancement);
				}
				Dataset.Dispose();
			}
		return clsBienimmobiliseparametresourcefinancements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SF_CODESOURCEFINANCEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SF_CODESOURCEFINANCEMENT , SF_LIBELLE FROM dbo.FT_BIENIMMOBILISEPARAMETRESOURCEFINANCEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SF_CODESOURCEFINANCEMENT)</summary>
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
				this.vapCritere ="WHERE SF_CODESOURCEFINANCEMENT=@SF_CODESOURCEFINANCEMENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SF_CODESOURCEFINANCEMENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
