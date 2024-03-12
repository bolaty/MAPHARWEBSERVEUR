using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsLogicielWSDAL: ITableDAL<clsLogiciel>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(LO_CODELOGICIEL) AS LO_CODELOGICIEL  FROM dbo.FT_LOGICIEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(LO_CODELOGICIEL) AS LO_CODELOGICIEL  FROM dbo.FT_LOGICIEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(LO_CODELOGICIEL) AS LO_CODELOGICIEL  FROM dbo.FT_LOGICIEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsLogiciel comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsLogiciel pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT LO_LIBELLE  , LO_NUMEROORDRE  , LO_STATUTLOGICIEL  FROM dbo.FT_LOGICIEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsLogiciel clsLogiciel = new clsLogiciel();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogiciel.LO_LIBELLE = clsDonnee.vogDataReader["LO_LIBELLE"].ToString();
					clsLogiciel.LO_NUMEROORDRE = double.Parse(clsDonnee.vogDataReader["LO_NUMEROORDRE"].ToString());
					clsLogiciel.LO_STATUTLOGICIEL = clsDonnee.vogDataReader["LO_STATUTLOGICIEL"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsLogiciel;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogiciel>clsLogiciel</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsLogiciel clsLogiciel)
		{
			//Préparation des paramètres
			SqlParameter vppParamLO_CODELOGICIEL = new SqlParameter("@LO_CODELOGICIEL", SqlDbType.VarChar, 25);
			vppParamLO_CODELOGICIEL.Value  = clsLogiciel.LO_CODELOGICIEL ;
			SqlParameter vppParamLO_LIBELLE = new SqlParameter("@LO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamLO_LIBELLE.Value  = clsLogiciel.LO_LIBELLE ;
			SqlParameter vppParamLO_NUMEROORDRE = new SqlParameter("@LO_NUMEROORDRE", SqlDbType.BigInt);
			vppParamLO_NUMEROORDRE.Value  = clsLogiciel.LO_NUMEROORDRE ;
			SqlParameter vppParamLO_STATUTLOGICIEL = new SqlParameter("@LO_STATUTLOGICIEL", SqlDbType.VarChar, 1);
			vppParamLO_STATUTLOGICIEL.Value  = clsLogiciel.LO_STATUTLOGICIEL ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIEL  @LO_CODELOGICIEL, @LO_LIBELLE, @LO_NUMEROORDRE, @LO_STATUTLOGICIEL, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLO_CODELOGICIEL);
			vppSqlCmd.Parameters.Add(vppParamLO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamLO_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamLO_STATUTLOGICIEL);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogiciel>clsLogiciel</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsLogiciel clsLogiciel,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamLO_CODELOGICIEL = new SqlParameter("@LO_CODELOGICIEL", SqlDbType.VarChar, 25);
			vppParamLO_CODELOGICIEL.Value  = clsLogiciel.LO_CODELOGICIEL ;
			SqlParameter vppParamLO_LIBELLE = new SqlParameter("@LO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamLO_LIBELLE.Value  = clsLogiciel.LO_LIBELLE ;
			SqlParameter vppParamLO_NUMEROORDRE = new SqlParameter("@LO_NUMEROORDRE", SqlDbType.BigInt);
			vppParamLO_NUMEROORDRE.Value  = clsLogiciel.LO_NUMEROORDRE ;
			SqlParameter vppParamLO_STATUTLOGICIEL = new SqlParameter("@LO_STATUTLOGICIEL", SqlDbType.VarChar, 1);
			vppParamLO_STATUTLOGICIEL.Value  = clsLogiciel.LO_STATUTLOGICIEL ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIEL  @LO_CODELOGICIEL, @LO_LIBELLE, @LO_NUMEROORDRE, @LO_STATUTLOGICIEL, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLO_CODELOGICIEL);
			vppSqlCmd.Parameters.Add(vppParamLO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamLO_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamLO_STATUTLOGICIEL);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIEL  @LO_CODELOGICIEL, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogiciel </returns>
		///<author>Home Technology</author>
		public List<clsLogiciel> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  LO_CODELOGICIEL, LO_LIBELLE, LO_NUMEROORDRE, LO_STATUTLOGICIEL FROM dbo.FT_LOGICIEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsLogiciel> clsLogiciels = new List<clsLogiciel>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogiciel clsLogiciel = new clsLogiciel();
					clsLogiciel.LO_CODELOGICIEL = clsDonnee.vogDataReader["LO_CODELOGICIEL"].ToString();
					clsLogiciel.LO_LIBELLE = clsDonnee.vogDataReader["LO_LIBELLE"].ToString();
					clsLogiciel.LO_NUMEROORDRE = double.Parse(clsDonnee.vogDataReader["LO_NUMEROORDRE"].ToString());
					clsLogiciel.LO_STATUTLOGICIEL = clsDonnee.vogDataReader["LO_STATUTLOGICIEL"].ToString();
					clsLogiciels.Add(clsLogiciel);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsLogiciels;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogiciel </returns>
		///<author>Home Technology</author>
		public List<clsLogiciel> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsLogiciel> clsLogiciels = new List<clsLogiciel>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  LO_CODELOGICIEL, LO_LIBELLE, LO_NUMEROORDRE, LO_STATUTLOGICIEL FROM dbo.FT_LOGICIEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsLogiciel clsLogiciel = new clsLogiciel();
					clsLogiciel.LO_CODELOGICIEL = Dataset.Tables["TABLE"].Rows[Idx]["LO_CODELOGICIEL"].ToString();
					clsLogiciel.LO_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["LO_LIBELLE"].ToString();
					clsLogiciel.LO_NUMEROORDRE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LO_NUMEROORDRE"].ToString());
					clsLogiciel.LO_STATUTLOGICIEL = Dataset.Tables["TABLE"].Rows[Idx]["LO_STATUTLOGICIEL"].ToString();
					clsLogiciels.Add(clsLogiciel);
				}
				Dataset.Dispose();
			}
		return clsLogiciels;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_LOGICIEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT LO_CODELOGICIEL , LO_LIBELLE FROM dbo.FT_LOGICIEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LO_CODELOGICIEL)</summary>
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
				this.vapCritere ="WHERE LO_CODELOGICIEL=@LO_CODELOGICIEL";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@LO_CODELOGICIEL"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
