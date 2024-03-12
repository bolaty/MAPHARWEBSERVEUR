using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparnaturesinistreWSDAL: ITableDAL<clsCtparnaturesinistre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(NS_CODENATURESINISTRE) AS NS_CODENATURESINISTRE  FROM dbo.FT_CTPARNATURESINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(NS_CODENATURESINISTRE) AS NS_CODENATURESINISTRE  FROM dbo.FT_CTPARNATURESINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(NS_CODENATURESINISTRE) AS NS_CODENATURESINISTRE  FROM dbo.FT_CTPARNATURESINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparnaturesinistre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparnaturesinistre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NS_LIBELLENATURESINISTRE  , NS_ACTIF  , NS_NUMEROORDRE  FROM dbo.FT_CTPARNATURESINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparnaturesinistre clsCtparnaturesinistre = new clsCtparnaturesinistre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE = clsDonnee.vogDataReader["NS_LIBELLENATURESINISTRE"].ToString();
					clsCtparnaturesinistre.NS_ACTIF = clsDonnee.vogDataReader["NS_ACTIF"].ToString();
					clsCtparnaturesinistre.NS_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NS_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparnaturesinistre;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparnaturesinistre>clsCtparnaturesinistre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparnaturesinistre clsCtparnaturesinistre)
		{
			//Préparation des paramètres
			SqlParameter vppParamNS_CODENATURESINISTRE = new SqlParameter("@NS_CODENATURESINISTRE1", SqlDbType.VarChar, 4);
			vppParamNS_CODENATURESINISTRE.Value  = clsCtparnaturesinistre.NS_CODENATURESINISTRE ;
			SqlParameter vppParamNS_LIBELLENATURESINISTRE = new SqlParameter("@NS_LIBELLENATURESINISTRE", SqlDbType.VarChar, 150);
			vppParamNS_LIBELLENATURESINISTRE.Value  = clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE ;
			SqlParameter vppParamNS_ACTIF = new SqlParameter("@NS_ACTIF", SqlDbType.VarChar, 1);
			vppParamNS_ACTIF.Value  = clsCtparnaturesinistre.NS_ACTIF ;
			SqlParameter vppParamNS_NUMEROORDRE = new SqlParameter("@NS_NUMEROORDRE", SqlDbType.Int);
			vppParamNS_NUMEROORDRE.Value  = clsCtparnaturesinistre.NS_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARNATURESINISTRE  @NS_CODENATURESINISTRE1, @NS_LIBELLENATURESINISTRE, @NS_ACTIF, @NS_NUMEROORDRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNS_CODENATURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamNS_LIBELLENATURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamNS_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamNS_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparnaturesinistre>clsCtparnaturesinistre</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparnaturesinistre clsCtparnaturesinistre,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamNS_CODENATURESINISTRE = new SqlParameter("@NS_CODENATURESINISTRE1", SqlDbType.VarChar, 4);
			vppParamNS_CODENATURESINISTRE.Value  = clsCtparnaturesinistre.NS_CODENATURESINISTRE ;
			SqlParameter vppParamNS_LIBELLENATURESINISTRE = new SqlParameter("@NS_LIBELLENATURESINISTRE", SqlDbType.VarChar, 150);
			vppParamNS_LIBELLENATURESINISTRE.Value  = clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE ;
			SqlParameter vppParamNS_ACTIF = new SqlParameter("@NS_ACTIF", SqlDbType.VarChar, 1);
			vppParamNS_ACTIF.Value  = clsCtparnaturesinistre.NS_ACTIF ;
			SqlParameter vppParamNS_NUMEROORDRE = new SqlParameter("@NS_NUMEROORDRE", SqlDbType.Int);
			vppParamNS_NUMEROORDRE.Value  = clsCtparnaturesinistre.NS_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARNATURESINISTRE  @NS_CODENATURESINISTRE1, @NS_LIBELLENATURESINISTRE, @NS_ACTIF, @NS_NUMEROORDRE, @CODECRYPTAGE1, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNS_CODENATURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamNS_LIBELLENATURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamNS_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamNS_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARNATURESINISTRE  @NS_CODENATURESINISTRE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparnaturesinistre </returns>
		///<author>Home Technology</author>
		public List<clsCtparnaturesinistre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NS_CODENATURESINISTRE, NS_LIBELLENATURESINISTRE, NS_ACTIF, NS_NUMEROORDRE FROM dbo.FT_CTPARNATURESINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparnaturesinistre> clsCtparnaturesinistres = new List<clsCtparnaturesinistre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparnaturesinistre clsCtparnaturesinistre = new clsCtparnaturesinistre();
					clsCtparnaturesinistre.NS_CODENATURESINISTRE = clsDonnee.vogDataReader["NS_CODENATURESINISTRE"].ToString();
					clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE = clsDonnee.vogDataReader["NS_LIBELLENATURESINISTRE"].ToString();
					clsCtparnaturesinistre.NS_ACTIF = clsDonnee.vogDataReader["NS_ACTIF"].ToString();
					clsCtparnaturesinistre.NS_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NS_NUMEROORDRE"].ToString());
					clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparnaturesinistres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparnaturesinistre </returns>
		///<author>Home Technology</author>
		public List<clsCtparnaturesinistre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparnaturesinistre> clsCtparnaturesinistres = new List<clsCtparnaturesinistre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NS_CODENATURESINISTRE, NS_LIBELLENATURESINISTRE, NS_ACTIF, NS_NUMEROORDRE FROM dbo.FT_CTPARNATURESINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparnaturesinistre clsCtparnaturesinistre = new clsCtparnaturesinistre();
					clsCtparnaturesinistre.NS_CODENATURESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["NS_CODENATURESINISTRE"].ToString();
					clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["NS_LIBELLENATURESINISTRE"].ToString();
					clsCtparnaturesinistre.NS_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["NS_ACTIF"].ToString();
					clsCtparnaturesinistre.NS_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["NS_NUMEROORDRE"].ToString());
					clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
				}
				Dataset.Dispose();
			}
		return clsCtparnaturesinistres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARNATURESINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NS_CODENATURESINISTRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NS_CODENATURESINISTRE , NS_LIBELLENATURESINISTRE FROM dbo.FT_CTPARNATURESINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NS_CODENATURESINISTRE)</summary>
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
				this.vapCritere ="WHERE NS_CODENATURESINISTRE=@NS_CODENATURESINISTRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NS_CODENATURESINISTRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
