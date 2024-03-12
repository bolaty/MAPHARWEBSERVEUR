using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpartypecontratautoWSDAL: ITableDAL<clsCtpartypecontratauto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AU_CODETYPECONTRATAUTO) AS AU_CODETYPECONTRATAUTO  FROM dbo.FT_CTPARTYPECONTRATAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AU_CODETYPECONTRATAUTO) AS AU_CODETYPECONTRATAUTO  FROM dbo.FT_CTPARTYPECONTRATAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AU_CODETYPECONTRATAUTO) AS AU_CODETYPECONTRATAUTO  FROM dbo.FT_CTPARTYPECONTRATAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpartypecontratauto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpartypecontratauto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AU_LIBELLETYPECONTRATAUTO  , AU_ACTIF  , AU_NUMEROORDRE  FROM dbo.FT_CTPARTYPECONTRATAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpartypecontratauto clsCtpartypecontratauto = new clsCtpartypecontratauto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypecontratauto.AU_LIBELLETYPECONTRATAUTO = clsDonnee.vogDataReader["AU_LIBELLETYPECONTRATAUTO"].ToString();
					clsCtpartypecontratauto.AU_ACTIF = clsDonnee.vogDataReader["AU_ACTIF"].ToString();
					clsCtpartypecontratauto.AU_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["AU_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpartypecontratauto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypecontratauto>clsCtpartypecontratauto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpartypecontratauto clsCtpartypecontratauto)
		{
			//Préparation des paramètres
			SqlParameter vppParamAU_CODETYPECONTRATAUTO = new SqlParameter("@AU_CODETYPECONTRATAUTO", SqlDbType.VarChar, 2);
			vppParamAU_CODETYPECONTRATAUTO.Value  = clsCtpartypecontratauto.AU_CODETYPECONTRATAUTO ;
			SqlParameter vppParamAU_LIBELLETYPECONTRATAUTO = new SqlParameter("@AU_LIBELLETYPECONTRATAUTO", SqlDbType.VarChar, 150);
			vppParamAU_LIBELLETYPECONTRATAUTO.Value  = clsCtpartypecontratauto.AU_LIBELLETYPECONTRATAUTO ;
			SqlParameter vppParamAU_ACTIF = new SqlParameter("@AU_ACTIF", SqlDbType.VarChar, 1);
			vppParamAU_ACTIF.Value  = clsCtpartypecontratauto.AU_ACTIF ;
			SqlParameter vppParamAU_NUMEROORDRE = new SqlParameter("@AU_NUMEROORDRE", SqlDbType.Int);
			vppParamAU_NUMEROORDRE.Value  = clsCtpartypecontratauto.AU_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPECONTRATAUTO  @AU_CODETYPECONTRATAUTO, @AU_LIBELLETYPECONTRATAUTO, @AU_ACTIF, @AU_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAU_CODETYPECONTRATAUTO);
			vppSqlCmd.Parameters.Add(vppParamAU_LIBELLETYPECONTRATAUTO);
			vppSqlCmd.Parameters.Add(vppParamAU_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamAU_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypecontratauto>clsCtpartypecontratauto</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpartypecontratauto clsCtpartypecontratauto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAU_CODETYPECONTRATAUTO = new SqlParameter("@AU_CODETYPECONTRATAUTO", SqlDbType.VarChar, 2);
			vppParamAU_CODETYPECONTRATAUTO.Value  = clsCtpartypecontratauto.AU_CODETYPECONTRATAUTO ;
			SqlParameter vppParamAU_LIBELLETYPECONTRATAUTO = new SqlParameter("@AU_LIBELLETYPECONTRATAUTO", SqlDbType.VarChar, 150);
			vppParamAU_LIBELLETYPECONTRATAUTO.Value  = clsCtpartypecontratauto.AU_LIBELLETYPECONTRATAUTO ;
			SqlParameter vppParamAU_ACTIF = new SqlParameter("@AU_ACTIF", SqlDbType.VarChar, 1);
			vppParamAU_ACTIF.Value  = clsCtpartypecontratauto.AU_ACTIF ;
			SqlParameter vppParamAU_NUMEROORDRE = new SqlParameter("@AU_NUMEROORDRE", SqlDbType.Int);
			vppParamAU_NUMEROORDRE.Value  = clsCtpartypecontratauto.AU_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPECONTRATAUTO  @AU_CODETYPECONTRATAUTO, @AU_LIBELLETYPECONTRATAUTO, @AU_ACTIF, @AU_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAU_CODETYPECONTRATAUTO);
			vppSqlCmd.Parameters.Add(vppParamAU_LIBELLETYPECONTRATAUTO);
			vppSqlCmd.Parameters.Add(vppParamAU_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamAU_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPECONTRATAUTO  @AU_CODETYPECONTRATAUTO, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypecontratauto </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypecontratauto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AU_CODETYPECONTRATAUTO, AU_LIBELLETYPECONTRATAUTO, AU_ACTIF, AU_NUMEROORDRE FROM dbo.FT_CTPARTYPECONTRATAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpartypecontratauto> clsCtpartypecontratautos = new List<clsCtpartypecontratauto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypecontratauto clsCtpartypecontratauto = new clsCtpartypecontratauto();
					clsCtpartypecontratauto.AU_CODETYPECONTRATAUTO = clsDonnee.vogDataReader["AU_CODETYPECONTRATAUTO"].ToString();
					clsCtpartypecontratauto.AU_LIBELLETYPECONTRATAUTO = clsDonnee.vogDataReader["AU_LIBELLETYPECONTRATAUTO"].ToString();
					clsCtpartypecontratauto.AU_ACTIF = clsDonnee.vogDataReader["AU_ACTIF"].ToString();
					clsCtpartypecontratauto.AU_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["AU_NUMEROORDRE"].ToString());
					clsCtpartypecontratautos.Add(clsCtpartypecontratauto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpartypecontratautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypecontratauto </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypecontratauto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpartypecontratauto> clsCtpartypecontratautos = new List<clsCtpartypecontratauto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AU_CODETYPECONTRATAUTO, AU_LIBELLETYPECONTRATAUTO, AU_ACTIF, AU_NUMEROORDRE FROM dbo.FT_CTPARTYPECONTRATAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpartypecontratauto clsCtpartypecontratauto = new clsCtpartypecontratauto();
					clsCtpartypecontratauto.AU_CODETYPECONTRATAUTO = Dataset.Tables["TABLE"].Rows[Idx]["AU_CODETYPECONTRATAUTO"].ToString();
					clsCtpartypecontratauto.AU_LIBELLETYPECONTRATAUTO = Dataset.Tables["TABLE"].Rows[Idx]["AU_LIBELLETYPECONTRATAUTO"].ToString();
					clsCtpartypecontratauto.AU_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["AU_ACTIF"].ToString();
					clsCtpartypecontratauto.AU_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AU_NUMEROORDRE"].ToString());
					clsCtpartypecontratautos.Add(clsCtpartypecontratauto);
				}
				Dataset.Dispose();
			}
		return clsCtpartypecontratautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARTYPECONTRATAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AU_CODETYPECONTRATAUTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AU_CODETYPECONTRATAUTO , AU_LIBELLETYPECONTRATAUTO FROM dbo.FT_CTPARTYPECONTRATAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AU_CODETYPECONTRATAUTO)</summary>
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
				this.vapCritere ="WHERE AU_CODETYPECONTRATAUTO=@AU_CODETYPECONTRATAUTO";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AU_CODETYPECONTRATAUTO"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
