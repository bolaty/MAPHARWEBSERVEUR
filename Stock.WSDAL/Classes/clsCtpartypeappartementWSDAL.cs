using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpartypeappartementWSDAL: ITableDAL<clsCtpartypeappartement>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AP_CODETYPEAPPARTEMENT) AS AP_CODETYPEAPPARTEMENT  FROM dbo.FT_CTPARTYPEAPPARTEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AP_CODETYPEAPPARTEMENT) AS AP_CODETYPEAPPARTEMENT  FROM dbo.FT_CTPARTYPEAPPARTEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AP_CODETYPEAPPARTEMENT) AS AP_CODETYPEAPPARTEMENT  FROM dbo.FT_CTPARTYPEAPPARTEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpartypeappartement comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpartypeappartement pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AP_LIBLLETYPEAPPARTEMENT  , AP_ACTIF  , AP_NUMEROORDRE  FROM dbo.FT_CTPARTYPEAPPARTEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpartypeappartement clsCtpartypeappartement = new clsCtpartypeappartement();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypeappartement.AP_LIBLLETYPEAPPARTEMENT = clsDonnee.vogDataReader["AP_LIBLLETYPEAPPARTEMENT"].ToString();
					clsCtpartypeappartement.AP_ACTIF = clsDonnee.vogDataReader["AP_ACTIF"].ToString();
					clsCtpartypeappartement.AP_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["AP_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpartypeappartement;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypeappartement>clsCtpartypeappartement</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpartypeappartement clsCtpartypeappartement)
		{
			//Préparation des paramètres
			SqlParameter vppParamAP_CODETYPEAPPARTEMENT = new SqlParameter("@AP_CODETYPEAPPARTEMENT", SqlDbType.VarChar, 5);
			vppParamAP_CODETYPEAPPARTEMENT.Value  = clsCtpartypeappartement.AP_CODETYPEAPPARTEMENT ;
			SqlParameter vppParamAP_LIBLLETYPEAPPARTEMENT = new SqlParameter("@AP_LIBLLETYPEAPPARTEMENT", SqlDbType.VarChar, 150);
			vppParamAP_LIBLLETYPEAPPARTEMENT.Value  = clsCtpartypeappartement.AP_LIBLLETYPEAPPARTEMENT ;
			SqlParameter vppParamAP_ACTIF = new SqlParameter("@AP_ACTIF", SqlDbType.VarChar, 1);
			vppParamAP_ACTIF.Value  = clsCtpartypeappartement.AP_ACTIF ;
			SqlParameter vppParamAP_NUMEROORDRE = new SqlParameter("@AP_NUMEROORDRE", SqlDbType.Int);
			vppParamAP_NUMEROORDRE.Value  = clsCtpartypeappartement.AP_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEAPPARTEMENT  @AP_CODETYPEAPPARTEMENT, @AP_LIBLLETYPEAPPARTEMENT, @AP_ACTIF, @AP_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAP_CODETYPEAPPARTEMENT);
			vppSqlCmd.Parameters.Add(vppParamAP_LIBLLETYPEAPPARTEMENT);
			vppSqlCmd.Parameters.Add(vppParamAP_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamAP_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypeappartement>clsCtpartypeappartement</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpartypeappartement clsCtpartypeappartement,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAP_CODETYPEAPPARTEMENT = new SqlParameter("@AP_CODETYPEAPPARTEMENT", SqlDbType.VarChar, 5);
			vppParamAP_CODETYPEAPPARTEMENT.Value  = clsCtpartypeappartement.AP_CODETYPEAPPARTEMENT ;
			SqlParameter vppParamAP_LIBLLETYPEAPPARTEMENT = new SqlParameter("@AP_LIBLLETYPEAPPARTEMENT", SqlDbType.VarChar, 150);
			vppParamAP_LIBLLETYPEAPPARTEMENT.Value  = clsCtpartypeappartement.AP_LIBLLETYPEAPPARTEMENT ;
			SqlParameter vppParamAP_ACTIF = new SqlParameter("@AP_ACTIF", SqlDbType.VarChar, 1);
			vppParamAP_ACTIF.Value  = clsCtpartypeappartement.AP_ACTIF ;
			SqlParameter vppParamAP_NUMEROORDRE = new SqlParameter("@AP_NUMEROORDRE", SqlDbType.Int);
			vppParamAP_NUMEROORDRE.Value  = clsCtpartypeappartement.AP_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEAPPARTEMENT  @AP_CODETYPEAPPARTEMENT, @AP_LIBLLETYPEAPPARTEMENT, @AP_ACTIF, @AP_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAP_CODETYPEAPPARTEMENT);
			vppSqlCmd.Parameters.Add(vppParamAP_LIBLLETYPEAPPARTEMENT);
			vppSqlCmd.Parameters.Add(vppParamAP_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamAP_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEAPPARTEMENT  @AP_CODETYPEAPPARTEMENT, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypeappartement </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypeappartement> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AP_CODETYPEAPPARTEMENT, AP_LIBLLETYPEAPPARTEMENT, AP_ACTIF, AP_NUMEROORDRE FROM dbo.FT_CTPARTYPEAPPARTEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpartypeappartement> clsCtpartypeappartements = new List<clsCtpartypeappartement>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypeappartement clsCtpartypeappartement = new clsCtpartypeappartement();
					clsCtpartypeappartement.AP_CODETYPEAPPARTEMENT = clsDonnee.vogDataReader["AP_CODETYPEAPPARTEMENT"].ToString();
					clsCtpartypeappartement.AP_LIBLLETYPEAPPARTEMENT = clsDonnee.vogDataReader["AP_LIBLLETYPEAPPARTEMENT"].ToString();
					clsCtpartypeappartement.AP_ACTIF = clsDonnee.vogDataReader["AP_ACTIF"].ToString();
					clsCtpartypeappartement.AP_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["AP_NUMEROORDRE"].ToString());
					clsCtpartypeappartements.Add(clsCtpartypeappartement);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpartypeappartements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypeappartement </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypeappartement> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpartypeappartement> clsCtpartypeappartements = new List<clsCtpartypeappartement>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AP_CODETYPEAPPARTEMENT, AP_LIBLLETYPEAPPARTEMENT, AP_ACTIF, AP_NUMEROORDRE FROM dbo.FT_CTPARTYPEAPPARTEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpartypeappartement clsCtpartypeappartement = new clsCtpartypeappartement();
					clsCtpartypeappartement.AP_CODETYPEAPPARTEMENT = Dataset.Tables["TABLE"].Rows[Idx]["AP_CODETYPEAPPARTEMENT"].ToString();
					clsCtpartypeappartement.AP_LIBLLETYPEAPPARTEMENT = Dataset.Tables["TABLE"].Rows[Idx]["AP_LIBLLETYPEAPPARTEMENT"].ToString();
					clsCtpartypeappartement.AP_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["AP_ACTIF"].ToString();
					clsCtpartypeappartement.AP_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AP_NUMEROORDRE"].ToString());
					clsCtpartypeappartements.Add(clsCtpartypeappartement);
				}
				Dataset.Dispose();
			}
		return clsCtpartypeappartements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARTYPEAPPARTEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AP_CODETYPEAPPARTEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AP_CODETYPEAPPARTEMENT , AP_LIBLLETYPEAPPARTEMENT FROM dbo.FT_CTPARTYPEAPPARTEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AP_CODETYPEAPPARTEMENT)</summary>
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
				this.vapCritere ="WHERE AP_CODETYPEAPPARTEMENT=@AP_CODETYPEAPPARTEMENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AP_CODETYPEAPPARTEMENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
