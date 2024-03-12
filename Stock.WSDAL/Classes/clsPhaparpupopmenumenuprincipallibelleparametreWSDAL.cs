using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpupopmenumenuprincipallibelleparametreWSDAL: ITableDAL<clsPhaparpupopmenumenuprincipallibelleparametre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpupopmenumenuprincipallibelleparametre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpupopmenumenuprincipallibelleparametre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MP_CODEMENU,MP_LIBELLE,LP_LIBELLE  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE(@MG_CODEMODEGESTION,@MP_NOMPUPOPMENU,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpupopmenumenuprincipallibelleparametre clsPhaparpupopmenumenuprincipallibelleparametre = new clsPhaparpupopmenumenuprincipallibelleparametre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenumenuprincipallibelleparametre.MP_CODEMENU = int.Parse(clsDonnee.vogDataReader["MP_CODEMENU"].ToString());
                    clsPhaparpupopmenumenuprincipallibelleparametre.MP_LIBELLE = clsDonnee.vogDataReader["MP_LIBELLE"].ToString();
                    clsPhaparpupopmenumenuprincipallibelleparametre.LP_LIBELLE = clsDonnee.vogDataReader["LP_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpupopmenumenuprincipallibelleparametre;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenumenuprincipallibelleparametre>clsPhaparpupopmenumenuprincipallibelleparametre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpupopmenumenuprincipallibelleparametre clsPhaparpupopmenumenuprincipallibelleparametre)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparpupopmenumenuprincipallibelleparametre.MG_CODEMODEGESTION ;
			SqlParameter vppParamLP_CODELIBELLE = new SqlParameter("@LP_CODELIBELLE", SqlDbType.VarChar, 5);
			vppParamLP_CODELIBELLE.Value  = clsPhaparpupopmenumenuprincipallibelleparametre.LP_CODELIBELLE ;
			SqlParameter vppParamMP_CODEMENU = new SqlParameter("@MP_CODEMENU", SqlDbType.Int);
			vppParamMP_CODEMENU.Value  = clsPhaparpupopmenumenuprincipallibelleparametre.MP_CODEMENU ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE  @MG_CODEMODEGESTION, @LP_CODELIBELLE, @MP_CODEMENU, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamLP_CODELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamMP_CODEMENU);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenumenuprincipallibelleparametre>clsPhaparpupopmenumenuprincipallibelleparametre</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpupopmenumenuprincipallibelleparametre clsPhaparpupopmenumenuprincipallibelleparametre,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparpupopmenumenuprincipallibelleparametre.MG_CODEMODEGESTION ;
			SqlParameter vppParamLP_CODELIBELLE = new SqlParameter("@LP_CODELIBELLE", SqlDbType.VarChar, 5);
			vppParamLP_CODELIBELLE.Value  = clsPhaparpupopmenumenuprincipallibelleparametre.LP_CODELIBELLE ;
			SqlParameter vppParamMP_CODEMENU = new SqlParameter("@MP_CODEMENU", SqlDbType.Int);
			vppParamMP_CODEMENU.Value  = clsPhaparpupopmenumenuprincipallibelleparametre.MP_CODEMENU ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE  @MG_CODEMODEGESTION, @LP_CODELIBELLE, @MP_CODEMENU, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamLP_CODELIBELLE);
			vppSqlCmd.Parameters.Add(vppParamMP_CODEMENU);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE  @MG_CODEMODEGESTION, @LP_CODELIBELLE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenumenuprincipallibelleparametre </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenumenuprincipallibelleparametre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, LP_CODELIBELLE, MP_CODEMENU FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpupopmenumenuprincipallibelleparametre> clsPhaparpupopmenumenuprincipallibelleparametres = new List<clsPhaparpupopmenumenuprincipallibelleparametre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenumenuprincipallibelleparametre clsPhaparpupopmenumenuprincipallibelleparametre = new clsPhaparpupopmenumenuprincipallibelleparametre();
					clsPhaparpupopmenumenuprincipallibelleparametre.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumenuprincipallibelleparametre.LP_CODELIBELLE = clsDonnee.vogDataReader["LP_CODELIBELLE"].ToString();
					clsPhaparpupopmenumenuprincipallibelleparametre.MP_CODEMENU = int.Parse(clsDonnee.vogDataReader["MP_CODEMENU"].ToString());
					clsPhaparpupopmenumenuprincipallibelleparametres.Add(clsPhaparpupopmenumenuprincipallibelleparametre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpupopmenumenuprincipallibelleparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenumenuprincipallibelleparametre </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenumenuprincipallibelleparametre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpupopmenumenuprincipallibelleparametre> clsPhaparpupopmenumenuprincipallibelleparametres = new List<clsPhaparpupopmenumenuprincipallibelleparametre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, LP_CODELIBELLE, MP_CODEMENU FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpupopmenumenuprincipallibelleparametre clsPhaparpupopmenumenuprincipallibelleparametre = new clsPhaparpupopmenumenuprincipallibelleparametre();
					clsPhaparpupopmenumenuprincipallibelleparametre.MG_CODEMODEGESTION = Dataset.Tables["TABLE"].Rows[Idx]["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumenuprincipallibelleparametre.LP_CODELIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["LP_CODELIBELLE"].ToString();
					clsPhaparpupopmenumenuprincipallibelleparametre.MP_CODEMENU = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MP_CODEMENU"].ToString());
					clsPhaparpupopmenumenuprincipallibelleparametres.Add(clsPhaparpupopmenumenuprincipallibelleparametre);
				}
				Dataset.Dispose();
			}
		return clsPhaparpupopmenumenuprincipallibelleparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMenu(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.VUE_PHAPARPUPOPMENUMENUPRINCIPALDETAILLIBELLEMODEL " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MG_CODEMODEGESTION, LP_CODELIBELLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MG_CODEMODEGESTION , MP_CODEMENU FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALLIBELLEPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MG_CODEMODEGESTION, LP_CODELIBELLE)</summary>
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
				this.vapCritere ="WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MG_CODEMODEGESTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND MP_NOMPUPOPMENU=@MP_NOMPUPOPMENU";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@MG_CODEMODEGESTION", "@MP_NOMPUPOPMENU" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
