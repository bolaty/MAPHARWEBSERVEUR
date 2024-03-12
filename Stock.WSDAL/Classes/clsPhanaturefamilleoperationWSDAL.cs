using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhanaturefamilleoperationWSDAL: ITableDAL<clsPhanaturefamilleoperation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(NF_CODENATUREFAMILLEOPERATION) AS NF_CODENATUREFAMILLEOPERATION  FROM dbo.FT_PHANATUREFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(NF_CODENATUREFAMILLEOPERATION) AS NF_CODENATUREFAMILLEOPERATION  FROM dbo.FT_PHANATUREFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(NF_CODENATUREFAMILLEOPERATION) AS NF_CODENATUREFAMILLEOPERATION  FROM dbo.FT_PHANATUREFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhanaturefamilleoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhanaturefamilleoperation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NF_LIBELLENATUREFAMILLEOPERATION1  FROM dbo.FT_PHANATUREFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new clsPhanaturefamilleoperation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 = clsDonnee.vogDataReader["NF_LIBELLENATUREFAMILLEOPERATION1"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhanaturefamilleoperation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhanaturefamilleoperation>clsPhanaturefamilleoperation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhanaturefamilleoperation clsPhanaturefamilleoperation)
		{
			//Préparation des paramètres
			SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION ;
			SqlParameter vppParamNF_LIBELLENATUREFAMILLEOPERATION1 = new SqlParameter("@NF_LIBELLENATUREFAMILLEOPERATION1", SqlDbType.VarChar, 150);
			vppParamNF_LIBELLENATUREFAMILLEOPERATION1.Value  = clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHANATUREFAMILLEOPERATION  @NF_CODENATUREFAMILLEOPERATION, @NF_LIBELLENATUREFAMILLEOPERATION1, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamNF_LIBELLENATUREFAMILLEOPERATION1);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhanaturefamilleoperation>clsPhanaturefamilleoperation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhanaturefamilleoperation clsPhanaturefamilleoperation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION ;
			SqlParameter vppParamNF_LIBELLENATUREFAMILLEOPERATION1 = new SqlParameter("@NF_LIBELLENATUREFAMILLEOPERATION1", SqlDbType.VarChar, 150);
			vppParamNF_LIBELLENATUREFAMILLEOPERATION1.Value  = clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHANATUREFAMILLEOPERATION  @NF_CODENATUREFAMILLEOPERATION, @NF_LIBELLENATUREFAMILLEOPERATION1, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamNF_LIBELLENATUREFAMILLEOPERATION1);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHANATUREFAMILLEOPERATION  @NF_CODENATUREFAMILLEOPERATION, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhanaturefamilleoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhanaturefamilleoperation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NF_CODENATUREFAMILLEOPERATION, NF_LIBELLENATUREFAMILLEOPERATION1 FROM dbo.FT_PHANATUREFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<clsPhanaturefamilleoperation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new clsPhanaturefamilleoperation();
					clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION = clsDonnee.vogDataReader["NF_CODENATUREFAMILLEOPERATION"].ToString();
					clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 = clsDonnee.vogDataReader["NF_LIBELLENATUREFAMILLEOPERATION1"].ToString();
					clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhanaturefamilleoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhanaturefamilleoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhanaturefamilleoperation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<clsPhanaturefamilleoperation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NF_CODENATUREFAMILLEOPERATION, NF_LIBELLENATUREFAMILLEOPERATION1 FROM dbo.FT_PHANATUREFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new clsPhanaturefamilleoperation();
					clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NF_CODENATUREFAMILLEOPERATION"].ToString();
					clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1 = Dataset.Tables["TABLE"].Rows[Idx]["NF_LIBELLENATUREFAMILLEOPERATION1"].ToString();
					clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
				}
				Dataset.Dispose();
			}
		return clsPhanaturefamilleoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHANATUREFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NF_CODENATUREFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NF_CODENATUREFAMILLEOPERATION , NF_LIBELLENATUREFAMILLEOPERATION1 FROM dbo.FT_PHANATUREFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY NF_LIBELLENATUREFAMILLEOPERATION1";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NF_CODENATUREFAMILLEOPERATION)</summary>
		///<param name="clsDonnee"> clsDonnee</param>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				//this.vapCritere = " WHERE NF_CODENATUREFAMILLEOPERATION";
                //this.vapCritere = " WHERE NF_CODENATUREFAMILLEOPERATION NOT IN ('02','04')";
                vapNomParametre = new string[]{"@CODECRYPTAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
				break;
				case 1 :
				this.vapCritere ="WHERE NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NF_CODENATUREFAMILLEOPERATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NF_CODENATUREFAMILLEOPERATION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        switch (vppCritere.Length) 
		        {
		        case 0 :
		        //this.vapCritere = " WHERE NF_CODENATUREFAMILLEOPERATION";
                //this.vapCritere = " WHERE NF_CODENATUREFAMILLEOPERATION NOT IN ('02','04')";
                vapNomParametre = new string[]{"@CODECRYPTAGE"};
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
		        break;
		        case 1 :
                if(vppCritere[0]=="01")
		        this.vapCritere = " WHERE NF_CODENATUREFAMILLEOPERATION NOT IN ('02','04')";

                if(vppCritere[0]=="02")
		        this.vapCritere = " WHERE NF_CODENATUREFAMILLEOPERATION  IN ('02')";
                if(vppCritere[0]=="03")
		        this.vapCritere = " WHERE NF_CODENATUREFAMILLEOPERATION  IN ('04')";
		        vapNomParametre = new string[]{"@CODECRYPTAGE"};
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
		        break;
	        }
        }

	}
}
