using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpupopmenumodegestionlibelleparametreWSDAL: ITableDAL<clsPhaparpupopmenumodegestionlibelleparametre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpupopmenumodegestionlibelleparametre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpupopmenumodegestionlibelleparametre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT LB_CODELIBELLE,LB_MOTUTILISE,LB_MOTAREMPLACER,MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpupopmenumodegestionlibelleparametre clsPhaparpupopmenumodegestionlibelleparametre = new clsPhaparpupopmenumodegestionlibelleparametre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenumodegestionlibelleparametre.LB_CODELIBELLE = clsDonnee.vogDataReader["LB_CODELIBELLE"].ToString();
                    clsPhaparpupopmenumodegestionlibelleparametre.LB_MOTUTILISE = clsDonnee.vogDataReader["LB_MOTUTILISE"].ToString();
                    clsPhaparpupopmenumodegestionlibelleparametre.LB_MOTAREMPLACER = clsDonnee.vogDataReader["LB_MOTAREMPLACER"].ToString();
                    clsPhaparpupopmenumodegestionlibelleparametre.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpupopmenumodegestionlibelleparametre;
		}







		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenumodegestionlibelleparametre>clsPhaparpupopmenumodegestionlibelleparametre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpupopmenumodegestionlibelleparametre clsPhaparpupopmenumodegestionlibelleparametre)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparpupopmenumodegestionlibelleparametre.MG_CODEMODEGESTION ;
			SqlParameter vppParamLB_CODELIBELLE = new SqlParameter("@LB_CODELIBELLE", SqlDbType.VarChar, 5);
			vppParamLB_CODELIBELLE.Value  = clsPhaparpupopmenumodegestionlibelleparametre.LB_CODELIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE  @MG_CODEMODEGESTION, @LB_CODELIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamLB_CODELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenumodegestionlibelleparametre>clsPhaparpupopmenumodegestionlibelleparametre</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpupopmenumodegestionlibelleparametre clsPhaparpupopmenumodegestionlibelleparametre,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparpupopmenumodegestionlibelleparametre.MG_CODEMODEGESTION ;
			SqlParameter vppParamLB_CODELIBELLE = new SqlParameter("@LB_CODELIBELLE", SqlDbType.VarChar, 5);
			vppParamLB_CODELIBELLE.Value  = clsPhaparpupopmenumodegestionlibelleparametre.LB_CODELIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE  @MG_CODEMODEGESTION, @LB_CODELIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamLB_CODELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE  @MG_CODEMODEGESTION, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenumodegestionlibelleparametre </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenumodegestionlibelleparametre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, LB_CODELIBELLE FROM dbo.FT_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpupopmenumodegestionlibelleparametre> clsPhaparpupopmenumodegestionlibelleparametres = new List<clsPhaparpupopmenumodegestionlibelleparametre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenumodegestionlibelleparametre clsPhaparpupopmenumodegestionlibelleparametre = new clsPhaparpupopmenumodegestionlibelleparametre();
					clsPhaparpupopmenumodegestionlibelleparametre.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumodegestionlibelleparametre.LB_CODELIBELLE = clsDonnee.vogDataReader["LB_CODELIBELLE"].ToString();
					clsPhaparpupopmenumodegestionlibelleparametres.Add(clsPhaparpupopmenumodegestionlibelleparametre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpupopmenumodegestionlibelleparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenumodegestionlibelleparametre </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenumodegestionlibelleparametre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpupopmenumodegestionlibelleparametre> clsPhaparpupopmenumodegestionlibelleparametres = new List<clsPhaparpupopmenumodegestionlibelleparametre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, LB_CODELIBELLE FROM dbo.FT_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpupopmenumodegestionlibelleparametre clsPhaparpupopmenumodegestionlibelleparametre = new clsPhaparpupopmenumodegestionlibelleparametre();
					clsPhaparpupopmenumodegestionlibelleparametre.MG_CODEMODEGESTION = Dataset.Tables["TABLE"].Rows[Idx]["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumodegestionlibelleparametre.LB_CODELIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["LB_CODELIBELLE"].ToString();
					clsPhaparpupopmenumodegestionlibelleparametres.Add(clsPhaparpupopmenumodegestionlibelleparametre);
				}
				Dataset.Dispose();
			}
		return clsPhaparpupopmenumodegestionlibelleparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MG_CODEMODEGESTION , LB_CODELIBELLE FROM dbo.FT_PHAPARPUPOPMENUMODEGESTIONLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MG_CODEMODEGESTION)</summary>
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
                this.vapCritere = "WHERE LB_MOTAREMPLACER=@LB_MOTAREMPLACER";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@LB_MOTAREMPLACER" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
