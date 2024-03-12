using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBusinessplanparampoliceWSDAL: ITableDAL<clsBusinessplanparampolice>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PP_CODEPOLICE) AS PP_CODEPOLICE  FROM dbo.FT_BUSINESSPLANPARAMPOLICE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PP_CODEPOLICE) AS PP_CODEPOLICE  FROM dbo.FT_BUSINESSPLANPARAMPOLICE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PP_CODEPOLICE) AS PP_CODEPOLICE  FROM dbo.FT_BUSINESSPLANPARAMPOLICE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBusinessplanparampolice comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBusinessplanparampolice pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PP_ABREGE  , PP_LIBELLE  FROM dbo.FT_BUSINESSPLANPARAMPOLICE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBusinessplanparampolice clsBusinessplanparampolice = new clsBusinessplanparampolice();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparampolice.PP_ABREGE = clsDonnee.vogDataReader["PP_ABREGE"].ToString();
					clsBusinessplanparampolice.PP_LIBELLE = clsDonnee.vogDataReader["PP_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBusinessplanparampolice;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparampolice>clsBusinessplanparampolice</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBusinessplanparampolice clsBusinessplanparampolice)
		{
			//Préparation des paramètres
			SqlParameter vppParamPP_CODEPOLICE = new SqlParameter("@PP_CODEPOLICE", SqlDbType.VarChar, 3);
			vppParamPP_CODEPOLICE.Value  = clsBusinessplanparampolice.PP_CODEPOLICE ;
			SqlParameter vppParamPP_ABREGE = new SqlParameter("@PP_ABREGE", SqlDbType.VarChar, 5);
			vppParamPP_ABREGE.Value  = clsBusinessplanparampolice.PP_ABREGE ;
			SqlParameter vppParamPP_LIBELLE = new SqlParameter("@PP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPP_LIBELLE.Value  = clsBusinessplanparampolice.PP_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOLICE  @PP_CODEPOLICE, @PP_ABREGE, @PP_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPOLICE);
			vppSqlCmd.Parameters.Add(vppParamPP_ABREGE);
			vppSqlCmd.Parameters.Add(vppParamPP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparampolice>clsBusinessplanparampolice</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBusinessplanparampolice clsBusinessplanparampolice,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPP_CODEPOLICE = new SqlParameter("@PP_CODEPOLICE", SqlDbType.VarChar, 3);
			vppParamPP_CODEPOLICE.Value  = clsBusinessplanparampolice.PP_CODEPOLICE ;
			SqlParameter vppParamPP_ABREGE = new SqlParameter("@PP_ABREGE", SqlDbType.VarChar, 5);
			vppParamPP_ABREGE.Value  = clsBusinessplanparampolice.PP_ABREGE ;
			SqlParameter vppParamPP_LIBELLE = new SqlParameter("@PP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPP_LIBELLE.Value  = clsBusinessplanparampolice.PP_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOLICE  @PP_CODEPOLICE, @PP_ABREGE, @PP_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPOLICE);
			vppSqlCmd.Parameters.Add(vppParamPP_ABREGE);
			vppSqlCmd.Parameters.Add(vppParamPP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOLICE  @PP_CODEPOLICE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparampolice </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparampolice> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PP_CODEPOLICE, PP_ABREGE, PP_LIBELLE FROM dbo.FT_BUSINESSPLANPARAMPOLICE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBusinessplanparampolice> clsBusinessplanparampolices = new List<clsBusinessplanparampolice>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparampolice clsBusinessplanparampolice = new clsBusinessplanparampolice();
					clsBusinessplanparampolice.PP_CODEPOLICE = clsDonnee.vogDataReader["PP_CODEPOLICE"].ToString();
					clsBusinessplanparampolice.PP_ABREGE = clsDonnee.vogDataReader["PP_ABREGE"].ToString();
					clsBusinessplanparampolice.PP_LIBELLE = clsDonnee.vogDataReader["PP_LIBELLE"].ToString();
					clsBusinessplanparampolices.Add(clsBusinessplanparampolice);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBusinessplanparampolices;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparampolice </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparampolice> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBusinessplanparampolice> clsBusinessplanparampolices = new List<clsBusinessplanparampolice>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PP_CODEPOLICE, PP_ABREGE, PP_LIBELLE FROM dbo.FT_BUSINESSPLANPARAMPOLICE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBusinessplanparampolice clsBusinessplanparampolice = new clsBusinessplanparampolice();
					clsBusinessplanparampolice.PP_CODEPOLICE = Dataset.Tables["TABLE"].Rows[Idx]["PP_CODEPOLICE"].ToString();
					clsBusinessplanparampolice.PP_ABREGE = Dataset.Tables["TABLE"].Rows[Idx]["PP_ABREGE"].ToString();
					clsBusinessplanparampolice.PP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PP_LIBELLE"].ToString();
					clsBusinessplanparampolices.Add(clsBusinessplanparampolice);
				}
				Dataset.Dispose();
			}
		return clsBusinessplanparampolices;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BUSINESSPLANPARAMPOLICE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PP_CODEPOLICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PP_CODEPOLICE , PP_ABREGE FROM dbo.FT_BUSINESSPLANPARAMPOLICE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PP_CODEPOLICE)</summary>
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
				this.vapCritere ="WHERE PP_CODEPOLICE=@PP_CODEPOLICE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PP_CODEPOLICE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
