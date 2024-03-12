using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparcasutilisationtiersWSDAL: ITableDAL<clsPhaparcasutilisationtiers>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CU_CODECASUTILISATION) AS CU_CODECASUTILISATION  FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CU_CODECASUTILISATION) AS CU_CODECASUTILISATION  FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CU_CODECASUTILISATION) AS CU_CODECASUTILISATION  FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparcasutilisationtiers comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparcasutilisationtiers pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CU_LIBELLE  FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new clsPhaparcasutilisationtiers();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparcasutilisationtiers.CU_LIBELLE = clsDonnee.vogDataReader["CU_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparcasutilisationtiers;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparcasutilisationtiers>clsPhaparcasutilisationtiers</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers)
		{
			//Préparation des paramètres
			SqlParameter vppParamCU_CODECASUTILISATION = new SqlParameter("@CU_CODECASUTILISATION", SqlDbType.VarChar, 3);
			vppParamCU_CODECASUTILISATION.Value  = clsPhaparcasutilisationtiers.CU_CODECASUTILISATION ;
			SqlParameter vppParamCU_LIBELLE = new SqlParameter("@CU_LIBELLE", SqlDbType.VarChar, 150);
			vppParamCU_LIBELLE.Value  = clsPhaparcasutilisationtiers.CU_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARCASUTILISATIONTIERS  @CU_CODECASUTILISATION, @CU_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCU_CODECASUTILISATION);
			vppSqlCmd.Parameters.Add(vppParamCU_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparcasutilisationtiers>clsPhaparcasutilisationtiers</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCU_CODECASUTILISATION = new SqlParameter("@CU_CODECASUTILISATION", SqlDbType.VarChar, 3);
			vppParamCU_CODECASUTILISATION.Value  = clsPhaparcasutilisationtiers.CU_CODECASUTILISATION ;
			SqlParameter vppParamCU_LIBELLE = new SqlParameter("@CU_LIBELLE", SqlDbType.VarChar, 150);
			vppParamCU_LIBELLE.Value  = clsPhaparcasutilisationtiers.CU_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARCASUTILISATIONTIERS  @CU_CODECASUTILISATION, @CU_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCU_CODECASUTILISATION);
			vppSqlCmd.Parameters.Add(vppParamCU_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARCASUTILISATIONTIERS  @CU_CODECASUTILISATION, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparcasutilisationtiers </returns>
		///<author>Home Technology</author>
		public List<clsPhaparcasutilisationtiers> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CU_CODECASUTILISATION, CU_LIBELLE FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<clsPhaparcasutilisationtiers>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new clsPhaparcasutilisationtiers();
					clsPhaparcasutilisationtiers.CU_CODECASUTILISATION = clsDonnee.vogDataReader["CU_CODECASUTILISATION"].ToString();
					clsPhaparcasutilisationtiers.CU_LIBELLE = clsDonnee.vogDataReader["CU_LIBELLE"].ToString();
					clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparcasutilisationtierss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparcasutilisationtiers </returns>
		///<author>Home Technology</author>
		public List<clsPhaparcasutilisationtiers> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<clsPhaparcasutilisationtiers>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CU_CODECASUTILISATION, CU_LIBELLE FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new clsPhaparcasutilisationtiers();
					clsPhaparcasutilisationtiers.CU_CODECASUTILISATION = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECASUTILISATION"].ToString();
					clsPhaparcasutilisationtiers.CU_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["CU_LIBELLE"].ToString();
					clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
				}
				Dataset.Dispose();
			}
		return clsPhaparcasutilisationtierss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CU_CODECASUTILISATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CU_CODECASUTILISATION , CU_LIBELLE FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CU_CODECASUTILISATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboFiltre(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        pvpChoixCritere1(clsDonnee ,vppCritere);
	        this.vapRequete = "SELECT CU_CODECASUTILISATION , CU_LIBELLE FROM dbo.FT_PHAPARCASUTILISATIONTIERS(@CODECRYPTAGE) " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CU_CODECASUTILISATION)</summary>
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
				this.vapCritere ="WHERE CU_CODECASUTILISATION=@CU_CODECASUTILISATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CU_CODECASUTILISATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CU_CODECASUTILISATION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        switch (vppCritere.Length) 
		        {
		        case 0 :
		        this.vapCritere ="";
		        vapNomParametre = new string[]{"@CODECRYPTAGE"};
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
		        break;
		        case 1 :
                this.vapCritere = "WHERE CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[0], "CU_CODECASUTILISATION") + ")";
		        vapNomParametre = new string[]{"@CODECRYPTAGE","@CU_CODECASUTILISATION"};
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[0], 1, "CU_CODECASUTILISATION");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 1, "CU_CODECASUTILISATION");


		        break;
	        }
        }



	}
}
