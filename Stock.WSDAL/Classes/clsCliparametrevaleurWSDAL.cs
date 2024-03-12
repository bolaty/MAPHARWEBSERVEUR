using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliparametrevaleurWSDAL: ITableDAL<clsCliparametrevaleur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PT_CODEPRIME) AS PT_CODEPRIME  FROM dbo.FT_CLIPARAMETREVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PT_CODEPRIME) AS PT_CODEPRIME  FROM dbo.FT_CLIPARAMETREVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PT_CODEPRIME) AS PT_CODEPRIME  FROM dbo.FT_CLIPARAMETREVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliparametrevaleur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliparametrevaleur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AP_CODEPRODUIT  , LP_CODEPARAMETRELIBELLE  , PT_BORNEMIN  , PT_BORNEMAX  , PT_MONTANTMINI  , PT_MONTANTMAXI  , PT_TAUX  , PT_MONTANT  FROM dbo.FT_CLIPARAMETREVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliparametrevaleur clsCliparametrevaleur = new clsCliparametrevaleur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparametrevaleur.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsCliparametrevaleur.LP_CODEPARAMETRELIBELLE = clsDonnee.vogDataReader["LP_CODEPARAMETRELIBELLE"].ToString();
					clsCliparametrevaleur.PT_BORNEMIN = decimal.Parse(clsDonnee.vogDataReader["PT_BORNEMIN"].ToString());
					clsCliparametrevaleur.PT_BORNEMAX = decimal.Parse(clsDonnee.vogDataReader["PT_BORNEMAX"].ToString());
					clsCliparametrevaleur.PT_MONTANTMINI = decimal.Parse(clsDonnee.vogDataReader["PT_MONTANTMINI"].ToString());
					clsCliparametrevaleur.PT_MONTANTMAXI = decimal.Parse(clsDonnee.vogDataReader["PT_MONTANTMAXI"].ToString());
					clsCliparametrevaleur.PT_TAUX = decimal.Parse(clsDonnee.vogDataReader["PT_TAUX"].ToString());
					clsCliparametrevaleur.PT_MONTANT = decimal.Parse(clsDonnee.vogDataReader["PT_MONTANT"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliparametrevaleur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparametrevaleur>clsCliparametrevaleur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliparametrevaleur clsCliparametrevaleur)
		{
			//Préparation des paramètres
			SqlParameter vppParamPT_CODEPRIME = new SqlParameter("@PT_CODEPRIME", SqlDbType.VarChar, 50);
			vppParamPT_CODEPRIME.Value  = clsCliparametrevaleur.PT_CODEPRIME ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar, 4);
			vppParamAP_CODEPRODUIT.Value  = clsCliparametrevaleur.AP_CODEPRODUIT ;
			SqlParameter vppParamLP_CODEPARAMETRELIBELLE = new SqlParameter("@LP_CODEPARAMETRELIBELLE", SqlDbType.VarChar, 4);
			vppParamLP_CODEPARAMETRELIBELLE.Value  = clsCliparametrevaleur.LP_CODEPARAMETRELIBELLE ;
			SqlParameter vppParamPT_BORNEMIN = new SqlParameter("@PT_BORNEMIN", SqlDbType.Decimal, 4);
			vppParamPT_BORNEMIN.Value  = clsCliparametrevaleur.PT_BORNEMIN ;
			SqlParameter vppParamPT_BORNEMAX = new SqlParameter("@PT_BORNEMAX", SqlDbType.Decimal, 4);
			vppParamPT_BORNEMAX.Value  = clsCliparametrevaleur.PT_BORNEMAX ;
			SqlParameter vppParamPT_MONTANTMINI = new SqlParameter("@PT_MONTANTMINI", SqlDbType.Decimal, 4);
			vppParamPT_MONTANTMINI.Value  = clsCliparametrevaleur.PT_MONTANTMINI ;
			SqlParameter vppParamPT_MONTANTMAXI = new SqlParameter("@PT_MONTANTMAXI", SqlDbType.Decimal, 4);
			vppParamPT_MONTANTMAXI.Value  = clsCliparametrevaleur.PT_MONTANTMAXI ;
			SqlParameter vppParamPT_TAUX = new SqlParameter("@PT_TAUX", SqlDbType.Decimal, 4);
			vppParamPT_TAUX.Value  = clsCliparametrevaleur.PT_TAUX ;
			SqlParameter vppParamPT_MONTANT = new SqlParameter("@PT_MONTANT", SqlDbType.Decimal, 4);
			vppParamPT_MONTANT.Value  = clsCliparametrevaleur.PT_MONTANT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARAMETREVALEUR  @PT_CODEPRIME, @AP_CODEPRODUIT, @LP_CODEPARAMETRELIBELLE, @PT_BORNEMIN, @PT_BORNEMAX, @PT_MONTANTMINI, @PT_MONTANTMAXI, @PT_TAUX, @PT_MONTANT, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPT_CODEPRIME);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamLP_CODEPARAMETRELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPT_BORNEMIN);
			vppSqlCmd.Parameters.Add(vppParamPT_BORNEMAX);
			vppSqlCmd.Parameters.Add(vppParamPT_MONTANTMINI);
			vppSqlCmd.Parameters.Add(vppParamPT_MONTANTMAXI);
			vppSqlCmd.Parameters.Add(vppParamPT_TAUX);
			vppSqlCmd.Parameters.Add(vppParamPT_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparametrevaleur>clsCliparametrevaleur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliparametrevaleur clsCliparametrevaleur,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPT_CODEPRIME = new SqlParameter("@PT_CODEPRIME", SqlDbType.VarChar, 50);
			vppParamPT_CODEPRIME.Value  = clsCliparametrevaleur.PT_CODEPRIME ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar, 4);
			vppParamAP_CODEPRODUIT.Value  = clsCliparametrevaleur.AP_CODEPRODUIT ;
			SqlParameter vppParamLP_CODEPARAMETRELIBELLE = new SqlParameter("@LP_CODEPARAMETRELIBELLE", SqlDbType.VarChar, 4);
			vppParamLP_CODEPARAMETRELIBELLE.Value  = clsCliparametrevaleur.LP_CODEPARAMETRELIBELLE ;
			SqlParameter vppParamPT_BORNEMIN = new SqlParameter("@PT_BORNEMIN", SqlDbType.Decimal, 4);
			vppParamPT_BORNEMIN.Value  = clsCliparametrevaleur.PT_BORNEMIN ;
			SqlParameter vppParamPT_BORNEMAX = new SqlParameter("@PT_BORNEMAX", SqlDbType.Decimal, 4);
			vppParamPT_BORNEMAX.Value  = clsCliparametrevaleur.PT_BORNEMAX ;
			SqlParameter vppParamPT_MONTANTMINI = new SqlParameter("@PT_MONTANTMINI", SqlDbType.Decimal, 4);
			vppParamPT_MONTANTMINI.Value  = clsCliparametrevaleur.PT_MONTANTMINI ;
			SqlParameter vppParamPT_MONTANTMAXI = new SqlParameter("@PT_MONTANTMAXI", SqlDbType.Decimal, 4);
			vppParamPT_MONTANTMAXI.Value  = clsCliparametrevaleur.PT_MONTANTMAXI ;
			SqlParameter vppParamPT_TAUX = new SqlParameter("@PT_TAUX", SqlDbType.Decimal, 4);
			vppParamPT_TAUX.Value  = clsCliparametrevaleur.PT_TAUX ;
			SqlParameter vppParamPT_MONTANT = new SqlParameter("@PT_MONTANT", SqlDbType.Decimal, 4);
			vppParamPT_MONTANT.Value  = clsCliparametrevaleur.PT_MONTANT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARAMETREVALEUR  @PT_CODEPRIME, @AP_CODEPRODUIT, @LP_CODEPARAMETRELIBELLE, @PT_BORNEMIN, @PT_BORNEMAX, @PT_MONTANTMINI, @PT_MONTANTMAXI, @PT_TAUX, @PT_MONTANT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPT_CODEPRIME);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamLP_CODEPARAMETRELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPT_BORNEMIN);
			vppSqlCmd.Parameters.Add(vppParamPT_BORNEMAX);
			vppSqlCmd.Parameters.Add(vppParamPT_MONTANTMINI);
			vppSqlCmd.Parameters.Add(vppParamPT_MONTANTMAXI);
			vppSqlCmd.Parameters.Add(vppParamPT_TAUX);
			vppSqlCmd.Parameters.Add(vppParamPT_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARAMETREVALEUR  @PT_CODEPRIME, @AP_CODEPRODUIT, @LP_CODEPARAMETRELIBELLE, '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparametrevaleur </returns>
		///<author>Home Technology</author>
		public List<clsCliparametrevaleur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE, PT_BORNEMIN, PT_BORNEMAX, PT_MONTANTMINI, PT_MONTANTMAXI, PT_TAUX, PT_MONTANT FROM dbo.FT_CLIPARAMETREVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliparametrevaleur> clsCliparametrevaleurs = new List<clsCliparametrevaleur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparametrevaleur clsCliparametrevaleur = new clsCliparametrevaleur();
					clsCliparametrevaleur.PT_CODEPRIME = clsDonnee.vogDataReader["PT_CODEPRIME"].ToString();
					clsCliparametrevaleur.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsCliparametrevaleur.LP_CODEPARAMETRELIBELLE = clsDonnee.vogDataReader["LP_CODEPARAMETRELIBELLE"].ToString();
					clsCliparametrevaleur.PT_BORNEMIN = decimal.Parse(clsDonnee.vogDataReader["PT_BORNEMIN"].ToString());
					clsCliparametrevaleur.PT_BORNEMAX = decimal.Parse(clsDonnee.vogDataReader["PT_BORNEMAX"].ToString());
					clsCliparametrevaleur.PT_MONTANTMINI = decimal.Parse(clsDonnee.vogDataReader["PT_MONTANTMINI"].ToString());
					clsCliparametrevaleur.PT_MONTANTMAXI = decimal.Parse(clsDonnee.vogDataReader["PT_MONTANTMAXI"].ToString());
					clsCliparametrevaleur.PT_TAUX = decimal.Parse(clsDonnee.vogDataReader["PT_TAUX"].ToString());
					clsCliparametrevaleur.PT_MONTANT = decimal.Parse(clsDonnee.vogDataReader["PT_MONTANT"].ToString());
					clsCliparametrevaleurs.Add(clsCliparametrevaleur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliparametrevaleurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparametrevaleur </returns>
		///<author>Home Technology</author>
		public List<clsCliparametrevaleur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliparametrevaleur> clsCliparametrevaleurs = new List<clsCliparametrevaleur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE, PT_BORNEMIN, PT_BORNEMAX, PT_MONTANTMINI, PT_MONTANTMAXI, PT_TAUX, PT_MONTANT FROM dbo.FT_CLIPARAMETREVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliparametrevaleur clsCliparametrevaleur = new clsCliparametrevaleur();
					clsCliparametrevaleur.PT_CODEPRIME = Dataset.Tables["TABLE"].Rows[Idx]["PT_CODEPRIME"].ToString();
					clsCliparametrevaleur.AP_CODEPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["AP_CODEPRODUIT"].ToString();
					clsCliparametrevaleur.LP_CODEPARAMETRELIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["LP_CODEPARAMETRELIBELLE"].ToString();
					clsCliparametrevaleur.PT_BORNEMIN = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PT_BORNEMIN"].ToString());
					clsCliparametrevaleur.PT_BORNEMAX = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PT_BORNEMAX"].ToString());
					clsCliparametrevaleur.PT_MONTANTMINI = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PT_MONTANTMINI"].ToString());
					clsCliparametrevaleur.PT_MONTANTMAXI = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PT_MONTANTMAXI"].ToString());
					clsCliparametrevaleur.PT_TAUX = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PT_TAUX"].ToString());
					clsCliparametrevaleur.PT_MONTANT = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PT_MONTANT"].ToString());
					clsCliparametrevaleurs.Add(clsCliparametrevaleur);
				}
				Dataset.Dispose();
			}
		return clsCliparametrevaleurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARAMETREVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PT_CODEPRIME , PT_BORNEMIN FROM dbo.FT_CLIPARAMETREVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PT_CODEPRIME, AP_CODEPRODUIT, LP_CODEPARAMETRELIBELLE)</summary>
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
				this.vapCritere ="WHERE PT_CODEPRIME=@PT_CODEPRIME";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PT_CODEPRIME"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PT_CODEPRIME=@PT_CODEPRIME AND AP_CODEPRODUIT=@AP_CODEPRODUIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PT_CODEPRIME","@AP_CODEPRODUIT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE PT_CODEPRIME=@PT_CODEPRIME AND AP_CODEPRODUIT=@AP_CODEPRODUIT AND LP_CODEPARAMETRELIBELLE=@LP_CODEPARAMETRELIBELLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PT_CODEPRIME","@AP_CODEPRODUIT","@LP_CODEPARAMETRELIBELLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
