using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparstatutsocioprofessionnelWSDAL: ITableDAL<clsCtparstatutsocioprofessionnel>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(ST_CODESTATUTSOCIOPROF) AS ST_CODESTATUTSOCIOPROF  FROM dbo.FT_CTPARSTATUTSOCIOPROFESSIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(ST_CODESTATUTSOCIOPROF) AS ST_CODESTATUTSOCIOPROF  FROM dbo.FT_CTPARSTATUTSOCIOPROFESSIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(ST_CODESTATUTSOCIOPROF) AS ST_CODESTATUTSOCIOPROF  FROM dbo.FT_CTPARSTATUTSOCIOPROFESSIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparstatutsocioprofessionnel comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparstatutsocioprofessionnel pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ST_LIBELLESTATUTSOCIOPROF1  , ST_ACTIF  , ST_NUMEROORDRE  FROM dbo.FT_CTPARSTATUTSOCIOPROFESSIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new clsCtparstatutsocioprofessionnel();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 = clsDonnee.vogDataReader["ST_LIBELLESTATUTSOCIOPROF1"].ToString();
					clsCtparstatutsocioprofessionnel.ST_ACTIF = clsDonnee.vogDataReader["ST_ACTIF"].ToString();
					clsCtparstatutsocioprofessionnel.ST_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["ST_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparstatutsocioprofessionnel;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparstatutsocioprofessionnel>clsCtparstatutsocioprofessionnel</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel)
		{
			//Préparation des paramètres
			SqlParameter vppParamST_CODESTATUTSOCIOPROF = new SqlParameter("@ST_CODESTATUTSOCIOPROF", SqlDbType.VarChar, 2);
			vppParamST_CODESTATUTSOCIOPROF.Value  = clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF ;
			SqlParameter vppParamST_LIBELLESTATUTSOCIOPROF1 = new SqlParameter("@ST_LIBELLESTATUTSOCIOPROF1", SqlDbType.VarChar, 150);
			vppParamST_LIBELLESTATUTSOCIOPROF1.Value  = clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 ;
			SqlParameter vppParamST_ACTIF = new SqlParameter("@ST_ACTIF", SqlDbType.VarChar, 1);
			vppParamST_ACTIF.Value  = clsCtparstatutsocioprofessionnel.ST_ACTIF ;
			SqlParameter vppParamST_NUMEROORDRE = new SqlParameter("@ST_NUMEROORDRE", SqlDbType.Int);
			vppParamST_NUMEROORDRE.Value  = clsCtparstatutsocioprofessionnel.ST_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSTATUTSOCIOPROFESSIONNEL  @ST_CODESTATUTSOCIOPROF, @ST_LIBELLESTATUTSOCIOPROF1, @ST_ACTIF, @ST_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamST_CODESTATUTSOCIOPROF);
			vppSqlCmd.Parameters.Add(vppParamST_LIBELLESTATUTSOCIOPROF1);
			vppSqlCmd.Parameters.Add(vppParamST_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamST_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparstatutsocioprofessionnel>clsCtparstatutsocioprofessionnel</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamST_CODESTATUTSOCIOPROF = new SqlParameter("@ST_CODESTATUTSOCIOPROF", SqlDbType.VarChar, 2);
			vppParamST_CODESTATUTSOCIOPROF.Value  = clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF ;
			SqlParameter vppParamST_LIBELLESTATUTSOCIOPROF1 = new SqlParameter("@ST_LIBELLESTATUTSOCIOPROF1", SqlDbType.VarChar, 150);
			vppParamST_LIBELLESTATUTSOCIOPROF1.Value  = clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 ;
			SqlParameter vppParamST_ACTIF = new SqlParameter("@ST_ACTIF", SqlDbType.VarChar, 1);
			vppParamST_ACTIF.Value  = clsCtparstatutsocioprofessionnel.ST_ACTIF ;
			SqlParameter vppParamST_NUMEROORDRE = new SqlParameter("@ST_NUMEROORDRE", SqlDbType.Int);
			vppParamST_NUMEROORDRE.Value  = clsCtparstatutsocioprofessionnel.ST_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSTATUTSOCIOPROFESSIONNEL  @ST_CODESTATUTSOCIOPROF, @ST_LIBELLESTATUTSOCIOPROF1, @ST_ACTIF, @ST_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamST_CODESTATUTSOCIOPROF);
			vppSqlCmd.Parameters.Add(vppParamST_LIBELLESTATUTSOCIOPROF1);
			vppSqlCmd.Parameters.Add(vppParamST_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamST_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARSTATUTSOCIOPROFESSIONNEL  @ST_CODESTATUTSOCIOPROF, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparstatutsocioprofessionnel </returns>
		///<author>Home Technology</author>
		public List<clsCtparstatutsocioprofessionnel> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ST_CODESTATUTSOCIOPROF, ST_LIBELLESTATUTSOCIOPROF1, ST_ACTIF, ST_NUMEROORDRE FROM dbo.FT_CTPARSTATUTSOCIOPROFESSIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<clsCtparstatutsocioprofessionnel>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new clsCtparstatutsocioprofessionnel();
					clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF = clsDonnee.vogDataReader["ST_CODESTATUTSOCIOPROF"].ToString();
					clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 = clsDonnee.vogDataReader["ST_LIBELLESTATUTSOCIOPROF1"].ToString();
					clsCtparstatutsocioprofessionnel.ST_ACTIF = clsDonnee.vogDataReader["ST_ACTIF"].ToString();
					clsCtparstatutsocioprofessionnel.ST_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["ST_NUMEROORDRE"].ToString());
					clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparstatutsocioprofessionnels;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparstatutsocioprofessionnel </returns>
		///<author>Home Technology</author>
		public List<clsCtparstatutsocioprofessionnel> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<clsCtparstatutsocioprofessionnel>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ST_CODESTATUTSOCIOPROF, ST_LIBELLESTATUTSOCIOPROF1, ST_ACTIF, ST_NUMEROORDRE FROM dbo.FT_CTPARSTATUTSOCIOPROFESSIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new clsCtparstatutsocioprofessionnel();
					clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF = Dataset.Tables["TABLE"].Rows[Idx]["ST_CODESTATUTSOCIOPROF"].ToString();
					clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1 = Dataset.Tables["TABLE"].Rows[Idx]["ST_LIBELLESTATUTSOCIOPROF1"].ToString();
					clsCtparstatutsocioprofessionnel.ST_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["ST_ACTIF"].ToString();
					clsCtparstatutsocioprofessionnel.ST_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ST_NUMEROORDRE"].ToString());
					clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
				}
				Dataset.Dispose();
			}
		return clsCtparstatutsocioprofessionnels;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARSTATUTSOCIOPROFESSIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : ST_CODESTATUTSOCIOPROF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ST_CODESTATUTSOCIOPROF , ST_LIBELLESTATUTSOCIOPROF1 FROM dbo.FT_CTPARSTATUTSOCIOPROFESSIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :ST_CODESTATUTSOCIOPROF)</summary>
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
				this.vapCritere ="WHERE ST_CODESTATUTSOCIOPROF=@ST_CODESTATUTSOCIOPROF";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ST_CODESTATUTSOCIOPROF"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
