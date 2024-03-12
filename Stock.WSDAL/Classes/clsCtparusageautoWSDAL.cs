using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparusageautoWSDAL: ITableDAL<clsCtparusageauto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(US_CODEUSAGE) AS US_CODEUSAGE  FROM dbo.FT_CTPARUSAGEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(US_CODEUSAGE) AS US_CODEUSAGE  FROM dbo.FT_CTPARUSAGEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(US_CODEUSAGE) AS US_CODEUSAGE  FROM dbo.FT_CTPARUSAGEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparusageauto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparusageauto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT US_LIBELLEUSAGE  , US_ACTIF  , US_NUMEROORDRE  FROM dbo.FT_CTPARUSAGEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparusageauto clsCtparusageauto = new clsCtparusageauto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparusageauto.US_LIBELLEUSAGE = clsDonnee.vogDataReader["US_LIBELLEUSAGE"].ToString();
					clsCtparusageauto.US_ACTIF = clsDonnee.vogDataReader["US_ACTIF"].ToString();
					clsCtparusageauto.US_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["US_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparusageauto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparusageauto>clsCtparusageauto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparusageauto clsCtparusageauto)
		{
			//Préparation des paramètres
			SqlParameter vppParamUS_CODEUSAGE = new SqlParameter("@US_CODEUSAGE", SqlDbType.VarChar, 3);
			vppParamUS_CODEUSAGE.Value  = clsCtparusageauto.US_CODEUSAGE ;
			SqlParameter vppParamUS_LIBELLEUSAGE = new SqlParameter("@US_LIBELLEUSAGE", SqlDbType.VarChar, 150);
			vppParamUS_LIBELLEUSAGE.Value  = clsCtparusageauto.US_LIBELLEUSAGE ;
			SqlParameter vppParamUS_ACTIF = new SqlParameter("@US_ACTIF", SqlDbType.VarChar, 1);
			vppParamUS_ACTIF.Value  = clsCtparusageauto.US_ACTIF ;
			SqlParameter vppParamUS_NUMEROORDRE = new SqlParameter("@US_NUMEROORDRE", SqlDbType.Int);
			vppParamUS_NUMEROORDRE.Value  = clsCtparusageauto.US_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARUSAGEAUTO  @US_CODEUSAGE, @US_LIBELLEUSAGE, @US_ACTIF, @US_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamUS_CODEUSAGE);
			vppSqlCmd.Parameters.Add(vppParamUS_LIBELLEUSAGE);
			vppSqlCmd.Parameters.Add(vppParamUS_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamUS_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparusageauto>clsCtparusageauto</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparusageauto clsCtparusageauto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamUS_CODEUSAGE = new SqlParameter("@US_CODEUSAGE", SqlDbType.VarChar, 3);
			vppParamUS_CODEUSAGE.Value  = clsCtparusageauto.US_CODEUSAGE ;
			SqlParameter vppParamUS_LIBELLEUSAGE = new SqlParameter("@US_LIBELLEUSAGE", SqlDbType.VarChar, 150);
			vppParamUS_LIBELLEUSAGE.Value  = clsCtparusageauto.US_LIBELLEUSAGE ;
			SqlParameter vppParamUS_ACTIF = new SqlParameter("@US_ACTIF", SqlDbType.VarChar, 1);
			vppParamUS_ACTIF.Value  = clsCtparusageauto.US_ACTIF ;
			SqlParameter vppParamUS_NUMEROORDRE = new SqlParameter("@US_NUMEROORDRE", SqlDbType.Int);
			vppParamUS_NUMEROORDRE.Value  = clsCtparusageauto.US_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARUSAGEAUTO  @US_CODEUSAGE, @US_LIBELLEUSAGE, @US_ACTIF, @US_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamUS_CODEUSAGE);
			vppSqlCmd.Parameters.Add(vppParamUS_LIBELLEUSAGE);
			vppSqlCmd.Parameters.Add(vppParamUS_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamUS_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARUSAGEAUTO  @US_CODEUSAGE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparusageauto </returns>
		///<author>Home Technology</author>
		public List<clsCtparusageauto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  US_CODEUSAGE, US_LIBELLEUSAGE, US_ACTIF, US_NUMEROORDRE FROM dbo.FT_CTPARUSAGEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparusageauto> clsCtparusageautos = new List<clsCtparusageauto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparusageauto clsCtparusageauto = new clsCtparusageauto();
					clsCtparusageauto.US_CODEUSAGE = clsDonnee.vogDataReader["US_CODEUSAGE"].ToString();
					clsCtparusageauto.US_LIBELLEUSAGE = clsDonnee.vogDataReader["US_LIBELLEUSAGE"].ToString();
					clsCtparusageauto.US_ACTIF = clsDonnee.vogDataReader["US_ACTIF"].ToString();
					clsCtparusageauto.US_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["US_NUMEROORDRE"].ToString());
					clsCtparusageautos.Add(clsCtparusageauto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparusageautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparusageauto </returns>
		///<author>Home Technology</author>
		public List<clsCtparusageauto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparusageauto> clsCtparusageautos = new List<clsCtparusageauto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  US_CODEUSAGE, US_LIBELLEUSAGE, US_ACTIF, US_NUMEROORDRE FROM dbo.FT_CTPARUSAGEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparusageauto clsCtparusageauto = new clsCtparusageauto();
					clsCtparusageauto.US_CODEUSAGE = Dataset.Tables["TABLE"].Rows[Idx]["US_CODEUSAGE"].ToString();
					clsCtparusageauto.US_LIBELLEUSAGE = Dataset.Tables["TABLE"].Rows[Idx]["US_LIBELLEUSAGE"].ToString();
					clsCtparusageauto.US_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["US_ACTIF"].ToString();
					clsCtparusageauto.US_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["US_NUMEROORDRE"].ToString());
					clsCtparusageautos.Add(clsCtparusageauto);
				}
				Dataset.Dispose();
			}
		return clsCtparusageautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARUSAGEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : US_CODEUSAGE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT US_CODEUSAGE , US_LIBELLEUSAGE FROM dbo.FT_CTPARUSAGEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :US_CODEUSAGE)</summary>
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
				this.vapCritere ="WHERE US_CODEUSAGE=@US_CODEUSAGE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@US_CODEUSAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
