using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsMicparametrelisteWSDAL: ITableDAL<clsMicparametreliste>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PL_CODEPARAMETRELISTE) AS PL_CODEPARAMETRELISTE  FROM dbo.MICPARAMETRELISTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PL_CODEPARAMETRELISTE) AS PL_CODEPARAMETRELISTE  FROM dbo.MICPARAMETRELISTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PL_CODEPARAMETRELISTE) AS PL_CODEPARAMETRELISTE  FROM dbo.MICPARAMETRELISTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMicparametreliste comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMicparametreliste pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT LG_CODEPARAMETRELIBELLEGROUPE  , LP_CODEPARAMETRELIBELLE  , PL_TYPECHAMP  , PL_CHAMPOBLIGATOIRE  , PL_AFFICHER  , CP_NUMEROORDRE  FROM dbo.MICPARAMETRELISTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsMicparametreliste clsMicparametreliste = new clsMicparametreliste();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicparametreliste.LG_CODEPARAMETRELIBELLEGROUPE = clsDonnee.vogDataReader["LG_CODEPARAMETRELIBELLEGROUPE"].ToString();
					clsMicparametreliste.LP_CODEPARAMETRELIBELLE = clsDonnee.vogDataReader["LP_CODEPARAMETRELIBELLE"].ToString();
					clsMicparametreliste.PL_TYPECHAMP = clsDonnee.vogDataReader["PL_TYPECHAMP"].ToString();
					clsMicparametreliste.PL_CHAMPOBLIGATOIRE = clsDonnee.vogDataReader["PL_CHAMPOBLIGATOIRE"].ToString();
					clsMicparametreliste.PL_AFFICHER = clsDonnee.vogDataReader["PL_AFFICHER"].ToString();
					clsMicparametreliste.CP_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CP_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsMicparametreliste;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMicparametreliste>clsMicparametreliste</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMicparametreliste clsMicparametreliste)
		{
			//Préparation des paramètres
			SqlParameter vppParamLG_CODEPARAMETRELIBELLEGROUPE = new SqlParameter("@LG_CODEPARAMETRELIBELLEGROUPE", SqlDbType.VarChar, 2);
			vppParamLG_CODEPARAMETRELIBELLEGROUPE.Value  = clsMicparametreliste.LG_CODEPARAMETRELIBELLEGROUPE ;

			SqlParameter vppParamLP_CODEPARAMETRELIBELLE = new SqlParameter("@LP_CODEPARAMETRELIBELLE", SqlDbType.VarChar, 4);
			vppParamLP_CODEPARAMETRELIBELLE.Value  = clsMicparametreliste.LP_CODEPARAMETRELIBELLE ;

			SqlParameter vppParamPL_CODEPARAMETRELISTE = new SqlParameter("@PL_CODEPARAMETRELISTE", SqlDbType.VarChar, 5);
			vppParamPL_CODEPARAMETRELISTE.Value  = clsMicparametreliste.PL_CODEPARAMETRELISTE ;

			SqlParameter vppParamPL_TYPECHAMP = new SqlParameter("@PL_TYPECHAMP", SqlDbType.VarChar, 150);
			vppParamPL_TYPECHAMP.Value  = clsMicparametreliste.PL_TYPECHAMP ;

			SqlParameter vppParamCP_CHAMPOBLIGATOIRE = new SqlParameter("@PL_CHAMPOBLIGATOIRE", SqlDbType.VarChar, 1);
			vppParamCP_CHAMPOBLIGATOIRE.Value  = clsMicparametreliste.PL_CHAMPOBLIGATOIRE ;

			SqlParameter vppParamPL_AFFICHER = new SqlParameter("@PL_AFFICHER", SqlDbType.VarChar, 1);
			vppParamPL_AFFICHER.Value  = clsMicparametreliste.PL_AFFICHER ;

			SqlParameter vppParamCP_NUMEROORDRE = new SqlParameter("@CP_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamCP_NUMEROORDRE.Value  = clsMicparametreliste.CP_NUMEROORDRE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO MICPARAMETRELISTE (  LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE, PL_TYPECHAMP, PL_CHAMPOBLIGATOIRE, PL_AFFICHER, CP_NUMEROORDRE) " +
					 "VALUES ( @LG_CODEPARAMETRELIBELLEGROUPE, @LP_CODEPARAMETRELIBELLE, @PL_CODEPARAMETRELISTE, @PL_TYPECHAMP, @PL_CHAMPOBLIGATOIRE, @PL_AFFICHER, @CP_NUMEROORDRE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLG_CODEPARAMETRELIBELLEGROUPE);
			vppSqlCmd.Parameters.Add(vppParamLP_CODEPARAMETRELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPL_CODEPARAMETRELISTE);
			vppSqlCmd.Parameters.Add(vppParamPL_TYPECHAMP);
			vppSqlCmd.Parameters.Add(vppParamCP_CHAMPOBLIGATOIRE);
			vppSqlCmd.Parameters.Add(vppParamPL_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamCP_NUMEROORDRE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMicparametreliste>clsMicparametreliste</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMicparametreliste clsMicparametreliste,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamLG_CODEPARAMETRELIBELLEGROUPE = new SqlParameter("@LG_CODEPARAMETRELIBELLEGROUPE", SqlDbType.VarChar, 2);
			vppParamLG_CODEPARAMETRELIBELLEGROUPE.Value  = clsMicparametreliste.LG_CODEPARAMETRELIBELLEGROUPE ;

			SqlParameter vppParamLP_CODEPARAMETRELIBELLE = new SqlParameter("@LP_CODEPARAMETRELIBELLE", SqlDbType.VarChar, 4);
			vppParamLP_CODEPARAMETRELIBELLE.Value  = clsMicparametreliste.LP_CODEPARAMETRELIBELLE ;

			SqlParameter vppParamPL_TYPECHAMP = new SqlParameter("@PL_TYPECHAMP", SqlDbType.VarChar, 150);
			vppParamPL_TYPECHAMP.Value  = clsMicparametreliste.PL_TYPECHAMP ;

			SqlParameter vppParamCP_CHAMPOBLIGATOIRE = new SqlParameter("@PL_CHAMPOBLIGATOIRE", SqlDbType.VarChar, 1);
			vppParamCP_CHAMPOBLIGATOIRE.Value  = clsMicparametreliste.PL_CHAMPOBLIGATOIRE ;

			SqlParameter vppParamPL_AFFICHER = new SqlParameter("@PL_AFFICHER", SqlDbType.VarChar, 1);
			vppParamPL_AFFICHER.Value  = clsMicparametreliste.PL_AFFICHER ;

			SqlParameter vppParamCP_NUMEROORDRE = new SqlParameter("@CP_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamCP_NUMEROORDRE.Value  = clsMicparametreliste.CP_NUMEROORDRE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE MICPARAMETRELISTE SET " +
							"LG_CODEPARAMETRELIBELLEGROUPE = @LG_CODEPARAMETRELIBELLEGROUPE, "+
							"LP_CODEPARAMETRELIBELLE = @LP_CODEPARAMETRELIBELLE, "+
							"PL_TYPECHAMP = @PL_TYPECHAMP, "+
							"PL_CHAMPOBLIGATOIRE = @PL_CHAMPOBLIGATOIRE, "+
							"PL_AFFICHER = @PL_AFFICHER, "+
							"CP_NUMEROORDRE = @CP_NUMEROORDRE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLG_CODEPARAMETRELIBELLEGROUPE);
			vppSqlCmd.Parameters.Add(vppParamLP_CODEPARAMETRELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPL_TYPECHAMP);
			vppSqlCmd.Parameters.Add(vppParamCP_CHAMPOBLIGATOIRE);
			vppSqlCmd.Parameters.Add(vppParamPL_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamCP_NUMEROORDRE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  MICPARAMETRELISTE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicparametreliste </returns>
		///<author>Home Technology</author>
		public List<clsMicparametreliste> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE, PL_TYPECHAMP, PL_CHAMPOBLIGATOIRE, PL_AFFICHER, CP_NUMEROORDRE FROM dbo.MICPARAMETRELISTE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsMicparametreliste> clsMicparametrelistes = new List<clsMicparametreliste>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicparametreliste clsMicparametreliste = new clsMicparametreliste();
					clsMicparametreliste.LG_CODEPARAMETRELIBELLEGROUPE = clsDonnee.vogDataReader["LG_CODEPARAMETRELIBELLEGROUPE"].ToString();
					clsMicparametreliste.LP_CODEPARAMETRELIBELLE = clsDonnee.vogDataReader["LP_CODEPARAMETRELIBELLE"].ToString();
					clsMicparametreliste.PL_CODEPARAMETRELISTE = clsDonnee.vogDataReader["PL_CODEPARAMETRELISTE"].ToString();
					clsMicparametreliste.PL_TYPECHAMP = clsDonnee.vogDataReader["PL_TYPECHAMP"].ToString();
					clsMicparametreliste.PL_CHAMPOBLIGATOIRE = clsDonnee.vogDataReader["PL_CHAMPOBLIGATOIRE"].ToString();
					clsMicparametreliste.PL_AFFICHER = clsDonnee.vogDataReader["PL_AFFICHER"].ToString();
					clsMicparametreliste.CP_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CP_NUMEROORDRE"].ToString());
					clsMicparametrelistes.Add(clsMicparametreliste);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsMicparametrelistes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicparametreliste </returns>
		///<author>Home Technology</author>
		public List<clsMicparametreliste> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsMicparametreliste> clsMicparametrelistes = new List<clsMicparametreliste>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE, PL_TYPECHAMP, PL_CHAMPOBLIGATOIRE, PL_AFFICHER, CP_NUMEROORDRE FROM dbo.MICPARAMETRELISTE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsMicparametreliste clsMicparametreliste = new clsMicparametreliste();
					clsMicparametreliste.LG_CODEPARAMETRELIBELLEGROUPE = Dataset.Tables["TABLE"].Rows[Idx]["LG_CODEPARAMETRELIBELLEGROUPE"].ToString();
					clsMicparametreliste.LP_CODEPARAMETRELIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["LP_CODEPARAMETRELIBELLE"].ToString();
					clsMicparametreliste.PL_CODEPARAMETRELISTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODEPARAMETRELISTE"].ToString();
					clsMicparametreliste.PL_TYPECHAMP = Dataset.Tables["TABLE"].Rows[Idx]["PL_TYPECHAMP"].ToString();
					clsMicparametreliste.PL_CHAMPOBLIGATOIRE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CHAMPOBLIGATOIRE"].ToString();
					clsMicparametreliste.PL_AFFICHER = Dataset.Tables["TABLE"].Rows[Idx]["PL_AFFICHER"].ToString();
					clsMicparametreliste.CP_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CP_NUMEROORDRE"].ToString());
					clsMicparametrelistes.Add(clsMicparametreliste);
				}
				Dataset.Dispose();
			}
		return clsMicparametrelistes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.MICPARAMETRELISTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetProduitSousProduit(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereProduitSousProduit(clsDonnee, vppCritere);
            this.vapRequete = "SELECT DISTINCT *  FROM dbo.FC_PARAMETRELISTEAVECVALEUR(@TP_CODETYPETIERS,@FM_CODEFORMEJURIDIQUE,@SX_CODESEXE) " + this.vapCritere + " AND PL_AFFICHER='O' ORDER BY PL_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetProduitSousProduitSimulation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereProduitSousProduit(clsDonnee, vppCritere);
            this.vapRequete = "SELECT DISTINCT *  FROM dbo.FC_PARAMETRELISTEAVECVALEUR(@TP_CODETYPETIERS,@FM_CODEFORMEJURIDIQUE,@SX_CODESEXE) " + this.vapCritere + " AND PL_AFFICHER='O' AND LP_CODEPARAMETRELIBELLE NOT IN('08','10')  ORDER BY PL_NUMEROORDRE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereProduitSousProduit(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PL_CODEPARAMETRELISTE , LP_LIBELLE FROM dbo.VUE_PARAMETRELISTE " + this.vapCritere + " AND PL_AFFICHER='O' ORDER BY PL_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboFrais(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereProduitSousProduitFrais(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PL_CODEPARAMETRELISTE , LP_LIBELLE FROM dbo.VUE_PARAMETRELISTE " + this.vapCritere + " AND PL_AFFICHER='O' ORDER BY PL_NUMEROORDRE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
				this.vapCritere ="WHERE LG_CODEPARAMETRELIBELLEGROUPE=@LG_CODEPARAMETRELIBELLEGROUPE";
				vapNomParametre = new string[]{"@LG_CODEPARAMETRELIBELLEGROUPE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE LG_CODEPARAMETRELIBELLEGROUPE=@LG_CODEPARAMETRELIBELLEGROUPE AND LP_CODEPARAMETRELIBELLE=@LP_CODEPARAMETRELIBELLE";
				vapNomParametre = new string[]{"@LG_CODEPARAMETRELIBELLEGROUPE","@LP_CODEPARAMETRELIBELLE"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE LG_CODEPARAMETRELIBELLEGROUPE=@LG_CODEPARAMETRELIBELLEGROUPE AND LP_CODEPARAMETRELIBELLE=@LP_CODEPARAMETRELIBELLE AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE";
				vapNomParametre = new string[]{"@LG_CODEPARAMETRELIBELLEGROUPE","@LP_CODEPARAMETRELIBELLE","@PL_CODEPARAMETRELISTE"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereProduitSousProduit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PR_TYPEPARAMETRE=@PR_TYPEPARAMETRE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PR_TYPEPARAMETRE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PR_TYPEPARAMETRE=@PR_TYPEPARAMETRE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PR_TYPEPARAMETRE", "@TP_CODETYPETIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PR_TYPEPARAMETRE=@PR_TYPEPARAMETRE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PR_TYPEPARAMETRE", "@TP_CODETYPETIERS", "@FM_CODEFORMEJURIDIQUE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PR_TYPEPARAMETRE=@PR_TYPEPARAMETRE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PR_TYPEPARAMETRE", "@TP_CODETYPETIERS", "@FM_CODEFORMEJURIDIQUE", "@SX_CODESEXE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;

            }
        }

            ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LG_CODEPARAMETRELIBELLEGROUPE, LP_CODEPARAMETRELIBELLE, PL_CODEPARAMETRELISTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereProduitSousProduitFrais(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT  AND PR_TYPEPARAMETRE IN(" + clsDonnee.pvpParametreIN(vppCritere[1], "PR_TYPEPARAMETRE") + ")";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PR_TYPEPARAMETRE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[1], 2, "PR_TYPEPARAMETRE");
                    vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 2, "PR_TYPEPARAMETRE");
                    break;



                    //this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND  CL_CODECLIENT LIKE '%'+@CL_CODECLIENT+'%'   AND  CL_NOMCLIENT LIKE '%'+@CL_NOMCLIENT+'%' AND  CL_PRENOMCLIENT LIKE '%'+@CL_PRENOMCLIENT+'%'  AND  TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND CL_DATECREATION BETWEEN @CL_DATECREATION1 AND @CL_DATECREATION2 AND CL_DATEDEPART='01/01/1900' AND SX_CODESEXE IN(" + clsDonnee.pvpParametreIN(vppCritere[7], "SX_CODESEXE") + ")";
                    //vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CL_CODECLIENT", "@CL_NOMCLIENT", "@CL_PRENOMCLIENT", "@TP_CODETYPETIERS", "@CL_DATECREATION1", "@CL_DATECREATION2", "@SX_CODESEXE" };
                    //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] };

                    //vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[7], 8, "SX_CODESEXE");
                    //vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 8, "SX_CODESEXE");
                    //break;
               

            }
        }
	}
}
