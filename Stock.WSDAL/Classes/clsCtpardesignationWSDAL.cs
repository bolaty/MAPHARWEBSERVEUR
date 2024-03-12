using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpardesignationWSDAL: ITableDAL<clsCtpardesignation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(DI_CODEDESIGNATION) AS DI_CODEDESIGNATION  FROM dbo.FT_CTPARDESIGNATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(DI_CODEDESIGNATION) AS DI_CODEDESIGNATION  FROM dbo.FT_CTPARDESIGNATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(DI_CODEDESIGNATION) AS DI_CODEDESIGNATION  FROM dbo.FT_CTPARDESIGNATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpardesignation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpardesignation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DI_LIBELLEDESIGNATION  , DI_NUMEROORDRE  FROM dbo.FT_CTPARDESIGNATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpardesignation clsCtpardesignation = new clsCtpardesignation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpardesignation.DI_LIBELLEDESIGNATION = clsDonnee.vogDataReader["DI_LIBELLEDESIGNATION"].ToString();
					clsCtpardesignation.DI_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["DI_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpardesignation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpardesignation>clsCtpardesignation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpardesignation clsCtpardesignation)
		{
			//Préparation des paramètres
			SqlParameter vppParamDI_CODEDESIGNATION = new SqlParameter("@DI_CODEDESIGNATION", SqlDbType.VarChar, 2);
			vppParamDI_CODEDESIGNATION.Value  = clsCtpardesignation.DI_CODEDESIGNATION ;
			SqlParameter vppParamDI_LIBELLEDESIGNATION = new SqlParameter("@DI_LIBELLEDESIGNATION", SqlDbType.VarChar, 150);
			vppParamDI_LIBELLEDESIGNATION.Value  = clsCtpardesignation.DI_LIBELLEDESIGNATION ;
			SqlParameter vppParamDI_NUMEROORDRE = new SqlParameter("@DI_NUMEROORDRE", SqlDbType.Int);
			vppParamDI_NUMEROORDRE.Value  = clsCtpardesignation.DI_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARDESIGNATION  @DI_CODEDESIGNATION, @DI_LIBELLEDESIGNATION, @DI_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDI_CODEDESIGNATION);
			vppSqlCmd.Parameters.Add(vppParamDI_LIBELLEDESIGNATION);
			vppSqlCmd.Parameters.Add(vppParamDI_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpardesignation>clsCtpardesignation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpardesignation clsCtpardesignation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDI_CODEDESIGNATION = new SqlParameter("@DI_CODEDESIGNATION", SqlDbType.VarChar, 2);
			vppParamDI_CODEDESIGNATION.Value  = clsCtpardesignation.DI_CODEDESIGNATION ;
			SqlParameter vppParamDI_LIBELLEDESIGNATION = new SqlParameter("@DI_LIBELLEDESIGNATION", SqlDbType.VarChar, 150);
			vppParamDI_LIBELLEDESIGNATION.Value  = clsCtpardesignation.DI_LIBELLEDESIGNATION ;
			SqlParameter vppParamDI_NUMEROORDRE = new SqlParameter("@DI_NUMEROORDRE", SqlDbType.Int);
			vppParamDI_NUMEROORDRE.Value  = clsCtpardesignation.DI_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARDESIGNATION  @DI_CODEDESIGNATION, @DI_LIBELLEDESIGNATION, @DI_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDI_CODEDESIGNATION);
			vppSqlCmd.Parameters.Add(vppParamDI_LIBELLEDESIGNATION);
			vppSqlCmd.Parameters.Add(vppParamDI_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARDESIGNATION  @DI_CODEDESIGNATION, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpardesignation </returns>
		///<author>Home Technology</author>
		public List<clsCtpardesignation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DI_CODEDESIGNATION, DI_LIBELLEDESIGNATION, DI_NUMEROORDRE FROM dbo.FT_CTPARDESIGNATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpardesignation> clsCtpardesignations = new List<clsCtpardesignation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpardesignation clsCtpardesignation = new clsCtpardesignation();
					clsCtpardesignation.DI_CODEDESIGNATION = clsDonnee.vogDataReader["DI_CODEDESIGNATION"].ToString();
					clsCtpardesignation.DI_LIBELLEDESIGNATION = clsDonnee.vogDataReader["DI_LIBELLEDESIGNATION"].ToString();
					clsCtpardesignation.DI_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["DI_NUMEROORDRE"].ToString());
					clsCtpardesignations.Add(clsCtpardesignation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpardesignations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpardesignation </returns>
		///<author>Home Technology</author>
		public List<clsCtpardesignation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpardesignation> clsCtpardesignations = new List<clsCtpardesignation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DI_CODEDESIGNATION, DI_LIBELLEDESIGNATION, DI_NUMEROORDRE FROM dbo.FT_CTPARDESIGNATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpardesignation clsCtpardesignation = new clsCtpardesignation();
					clsCtpardesignation.DI_CODEDESIGNATION = Dataset.Tables["TABLE"].Rows[Idx]["DI_CODEDESIGNATION"].ToString();
					clsCtpardesignation.DI_LIBELLEDESIGNATION = Dataset.Tables["TABLE"].Rows[Idx]["DI_LIBELLEDESIGNATION"].ToString();
					clsCtpardesignation.DI_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["DI_NUMEROORDRE"].ToString());
					clsCtpardesignations.Add(clsCtpardesignation);
				}
				Dataset.Dispose();
			}
		return clsCtpardesignations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARDESIGNATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : DI_CODEDESIGNATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DI_CODEDESIGNATION , DI_LIBELLEDESIGNATION FROM dbo.FT_CTPARDESIGNATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :DI_CODEDESIGNATION)</summary>
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
				this.vapCritere ="WHERE DI_CODEDESIGNATION=@DI_CODEDESIGNATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DI_CODEDESIGNATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
