using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsMicbudgetparampostebudgetairenatureWSDAL: ITableDAL<clsMicbudgetparampostebudgetairenature>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(BN_CODENATUREPOSTEBUDGETAIRE) AS BN_CODENATUREPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(BN_CODENATUREPOSTEBUDGETAIRE) AS BN_CODENATUREPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(BN_CODENATUREPOSTEBUDGETAIRE) AS BN_CODENATUREPOSTEBUDGETAIRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMicbudgetparampostebudgetairenature comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMicbudgetparampostebudgetairenature pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT BN_LIBELLE  , BN_NUMEROORDRE  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new clsMicbudgetparampostebudgetairenature();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicbudgetparampostebudgetairenature.BN_LIBELLE = clsDonnee.vogDataReader["BN_LIBELLE"].ToString();
					clsMicbudgetparampostebudgetairenature.BN_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["BN_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsMicbudgetparampostebudgetairenature;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMicbudgetparampostebudgetairenature>clsMicbudgetparampostebudgetairenature</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature)
		{
			//Préparation des paramètres
			SqlParameter vppParamBN_CODENATUREPOSTEBUDGETAIRE = new SqlParameter("@BN_CODENATUREPOSTEBUDGETAIRE", SqlDbType.VarChar, 2);
			vppParamBN_CODENATUREPOSTEBUDGETAIRE.Value  = clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE ;
			SqlParameter vppParamBN_LIBELLE = new SqlParameter("@BN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamBN_LIBELLE.Value  = clsMicbudgetparampostebudgetairenature.BN_LIBELLE ;
			SqlParameter vppParamBN_NUMEROORDRE = new SqlParameter("@BN_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamBN_NUMEROORDRE.Value  = clsMicbudgetparampostebudgetairenature.BN_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIRENATURE  @BN_CODENATUREPOSTEBUDGETAIRE, @BN_LIBELLE, @BN_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamBN_CODENATUREPOSTEBUDGETAIRE);
			vppSqlCmd.Parameters.Add(vppParamBN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamBN_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMicbudgetparampostebudgetairenature>clsMicbudgetparampostebudgetairenature</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamBN_CODENATUREPOSTEBUDGETAIRE = new SqlParameter("@BN_CODENATUREPOSTEBUDGETAIRE", SqlDbType.VarChar, 2);
			vppParamBN_CODENATUREPOSTEBUDGETAIRE.Value  = clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE ;
			SqlParameter vppParamBN_LIBELLE = new SqlParameter("@BN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamBN_LIBELLE.Value  = clsMicbudgetparampostebudgetairenature.BN_LIBELLE ;
			SqlParameter vppParamBN_NUMEROORDRE = new SqlParameter("@BN_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamBN_NUMEROORDRE.Value  = clsMicbudgetparampostebudgetairenature.BN_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIRENATURE  @BN_CODENATUREPOSTEBUDGETAIRE, @BN_LIBELLE, @BN_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamBN_CODENATUREPOSTEBUDGETAIRE);
			vppSqlCmd.Parameters.Add(vppParamBN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamBN_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MICBUDGETPARAMPOSTEBUDGETAIRENATURE  @BN_CODENATUREPOSTEBUDGETAIRE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicbudgetparampostebudgetairenature </returns>
		///<author>Home Technology</author>
		public List<clsMicbudgetparampostebudgetairenature> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  BN_CODENATUREPOSTEBUDGETAIRE, BN_LIBELLE, BN_NUMEROORDRE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsMicbudgetparampostebudgetairenature> clsMicbudgetparampostebudgetairenatures = new List<clsMicbudgetparampostebudgetairenature>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new clsMicbudgetparampostebudgetairenature();
					clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE = clsDonnee.vogDataReader["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
					clsMicbudgetparampostebudgetairenature.BN_LIBELLE = clsDonnee.vogDataReader["BN_LIBELLE"].ToString();
					clsMicbudgetparampostebudgetairenature.BN_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["BN_NUMEROORDRE"].ToString());
					clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsMicbudgetparampostebudgetairenatures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicbudgetparampostebudgetairenature </returns>
		///<author>Home Technology</author>
		public List<clsMicbudgetparampostebudgetairenature> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsMicbudgetparampostebudgetairenature> clsMicbudgetparampostebudgetairenatures = new List<clsMicbudgetparampostebudgetairenature>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  BN_CODENATUREPOSTEBUDGETAIRE, BN_LIBELLE, BN_NUMEROORDRE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature = new clsMicbudgetparampostebudgetairenature();
					clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE = Dataset.Tables["TABLE"].Rows[Idx]["BN_CODENATUREPOSTEBUDGETAIRE"].ToString();
					clsMicbudgetparampostebudgetairenature.BN_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["BN_LIBELLE"].ToString();
					clsMicbudgetparampostebudgetairenature.BN_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BN_NUMEROORDRE"].ToString());
					clsMicbudgetparampostebudgetairenatures.Add(clsMicbudgetparampostebudgetairenature);
				}
				Dataset.Dispose();
			}
		return clsMicbudgetparampostebudgetairenatures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BN_CODENATUREPOSTEBUDGETAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT BN_CODENATUREPOSTEBUDGETAIRE , BN_LIBELLE FROM dbo.FT_MICBUDGETPARAMPOSTEBUDGETAIRENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :BN_CODENATUREPOSTEBUDGETAIRE)</summary>
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
				this.vapCritere ="WHERE BN_CODENATUREPOSTEBUDGETAIRE=@BN_CODENATUREPOSTEBUDGETAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BN_CODENATUREPOSTEBUDGETAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
