using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparresumeWSDAL: ITableDAL<clsCtparresume>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RE_CODERESUME) AS RE_CODERESUME  FROM dbo.FT_CTPARRESUME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RE_CODERESUME) AS RE_CODERESUME  FROM dbo.FT_CTPARRESUME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RE_CODERESUME) AS RE_CODERESUME  FROM dbo.FT_CTPARRESUME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparresume comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparresume pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RE_LIBELLERESUME  , RE_ACTIF  , RE_NUMEROORDRE  FROM dbo.FT_CTPARRESUME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparresume clsCtparresume = new clsCtparresume();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparresume.RE_LIBELLERESUME = clsDonnee.vogDataReader["RE_LIBELLERESUME"].ToString();
					clsCtparresume.RE_ACTIF = clsDonnee.vogDataReader["RE_ACTIF"].ToString();
					clsCtparresume.RE_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RE_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparresume;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparresume>clsCtparresume</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparresume clsCtparresume)
		{
			//Préparation des paramètres
			SqlParameter vppParamRE_CODERESUME = new SqlParameter("@RE_CODERESUME", SqlDbType.VarChar, 2);
			vppParamRE_CODERESUME.Value  = clsCtparresume.RE_CODERESUME ;
			SqlParameter vppParamRE_LIBELLERESUME = new SqlParameter("@RE_LIBELLERESUME", SqlDbType.VarChar, 150);
			vppParamRE_LIBELLERESUME.Value  = clsCtparresume.RE_LIBELLERESUME ;
			SqlParameter vppParamRE_ACTIF = new SqlParameter("@RE_ACTIF", SqlDbType.VarChar, 1);
			vppParamRE_ACTIF.Value  = clsCtparresume.RE_ACTIF ;
			SqlParameter vppParamRE_NUMEROORDRE = new SqlParameter("@RE_NUMEROORDRE", SqlDbType.Int);
			vppParamRE_NUMEROORDRE.Value  = clsCtparresume.RE_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARRESUME  @RE_CODERESUME, @RE_LIBELLERESUME, @RE_ACTIF, @RE_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRE_CODERESUME);
			vppSqlCmd.Parameters.Add(vppParamRE_LIBELLERESUME);
			vppSqlCmd.Parameters.Add(vppParamRE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamRE_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparresume>clsCtparresume</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparresume clsCtparresume,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRE_CODERESUME = new SqlParameter("@RE_CODERESUME", SqlDbType.VarChar, 2);
			vppParamRE_CODERESUME.Value  = clsCtparresume.RE_CODERESUME ;
			SqlParameter vppParamRE_LIBELLERESUME = new SqlParameter("@RE_LIBELLERESUME", SqlDbType.VarChar, 150);
			vppParamRE_LIBELLERESUME.Value  = clsCtparresume.RE_LIBELLERESUME ;
			SqlParameter vppParamRE_ACTIF = new SqlParameter("@RE_ACTIF", SqlDbType.VarChar, 1);
			vppParamRE_ACTIF.Value  = clsCtparresume.RE_ACTIF ;
			SqlParameter vppParamRE_NUMEROORDRE = new SqlParameter("@RE_NUMEROORDRE", SqlDbType.Int);
			vppParamRE_NUMEROORDRE.Value  = clsCtparresume.RE_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARRESUME  @RE_CODERESUME, @RE_LIBELLERESUME, @RE_ACTIF, @RE_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRE_CODERESUME);
			vppSqlCmd.Parameters.Add(vppParamRE_LIBELLERESUME);
			vppSqlCmd.Parameters.Add(vppParamRE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamRE_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARRESUME  @RE_CODERESUME, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparresume </returns>
		///<author>Home Technology</author>
		public List<clsCtparresume> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RE_CODERESUME, RE_LIBELLERESUME, RE_ACTIF, RE_NUMEROORDRE FROM dbo.FT_CTPARRESUME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparresume> clsCtparresumes = new List<clsCtparresume>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparresume clsCtparresume = new clsCtparresume();
					clsCtparresume.RE_CODERESUME = clsDonnee.vogDataReader["RE_CODERESUME"].ToString();
					clsCtparresume.RE_LIBELLERESUME = clsDonnee.vogDataReader["RE_LIBELLERESUME"].ToString();
					clsCtparresume.RE_ACTIF = clsDonnee.vogDataReader["RE_ACTIF"].ToString();
					clsCtparresume.RE_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RE_NUMEROORDRE"].ToString());
					clsCtparresumes.Add(clsCtparresume);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparresumes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparresume </returns>
		///<author>Home Technology</author>
		public List<clsCtparresume> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparresume> clsCtparresumes = new List<clsCtparresume>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RE_CODERESUME, RE_LIBELLERESUME, RE_ACTIF, RE_NUMEROORDRE FROM dbo.FT_CTPARRESUME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparresume clsCtparresume = new clsCtparresume();
					clsCtparresume.RE_CODERESUME = Dataset.Tables["TABLE"].Rows[Idx]["RE_CODERESUME"].ToString();
					clsCtparresume.RE_LIBELLERESUME = Dataset.Tables["TABLE"].Rows[Idx]["RE_LIBELLERESUME"].ToString();
					clsCtparresume.RE_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["RE_ACTIF"].ToString();
					clsCtparresume.RE_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RE_NUMEROORDRE"].ToString());
					clsCtparresumes.Add(clsCtparresume);
				}
				Dataset.Dispose();
			}
		return clsCtparresumes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARRESUME(@CODECRYPTAGE) " + this.vapCritere+ " ORDER BY RE_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RE_CODERESUME , RE_LIBELLERESUME FROM dbo.FT_CTPARRESUME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RE_CODERESUME)</summary>
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
				this.vapCritere ="WHERE RE_CODERESUME=@RE_CODERESUME";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RE_CODERESUME"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
