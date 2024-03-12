using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliparcoeficientcoutsupplementaireWSDAL: ITableDAL<clsCliparcoeficientcoutsupplementaire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(JF_CODETYPEJOURFACTURATION) AS JF_CODETYPEJOURFACTURATION  FROM dbo.FT_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(JF_CODETYPEJOURFACTURATION) AS JF_CODETYPEJOURFACTURATION  FROM dbo.FT_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(JF_CODETYPEJOURFACTURATION) AS JF_CODETYPEJOURFACTURATION  FROM dbo.FT_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliparcoeficientcoutsupplementaire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliparcoeficientcoutsupplementaire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NT_CODENATURETIERS  , CF_TAUXSUPLEMENTAIRE  FROM dbo.FT_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliparcoeficientcoutsupplementaire clsCliparcoeficientcoutsupplementaire = new clsCliparcoeficientcoutsupplementaire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparcoeficientcoutsupplementaire.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
					clsCliparcoeficientcoutsupplementaire.CF_TAUXSUPLEMENTAIRE = float.Parse(clsDonnee.vogDataReader["CF_TAUXSUPLEMENTAIRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliparcoeficientcoutsupplementaire;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparcoeficientcoutsupplementaire>clsCliparcoeficientcoutsupplementaire</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliparcoeficientcoutsupplementaire clsCliparcoeficientcoutsupplementaire)
		{
			//Préparation des paramètres
			SqlParameter vppParamJF_CODETYPEJOURFACTURATION = new SqlParameter("@JF_CODETYPEJOURFACTURATION", SqlDbType.VarChar, 2);
			vppParamJF_CODETYPEJOURFACTURATION.Value  = clsCliparcoeficientcoutsupplementaire.JF_CODETYPEJOURFACTURATION ;
			SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 3);
			vppParamNT_CODENATURETIERS.Value  = clsCliparcoeficientcoutsupplementaire.NT_CODENATURETIERS ;
			SqlParameter vppParamCF_CODECOEFICIENT = new SqlParameter("@CF_CODECOEFICIENT", SqlDbType.VarChar, 50);
            vppParamCF_CODECOEFICIENT.Value  = clsCliparcoeficientcoutsupplementaire.CF_CODECOEFICIENT;
			SqlParameter vppParamCF_TAUXSUPLEMENTAIRE = new SqlParameter("@CF_TAUXSUPLEMENTAIRE", SqlDbType.Float);
			vppParamCF_TAUXSUPLEMENTAIRE.Value  = clsCliparcoeficientcoutsupplementaire.CF_TAUXSUPLEMENTAIRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE  @JF_CODETYPEJOURFACTURATION, @NT_CODENATURETIERS, @CF_CODECOEFICIENT, @CF_TAUXSUPLEMENTAIRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamJF_CODETYPEJOURFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
			vppSqlCmd.Parameters.Add(vppParamCF_CODECOEFICIENT);
			vppSqlCmd.Parameters.Add(vppParamCF_TAUXSUPLEMENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparcoeficientcoutsupplementaire>clsCliparcoeficientcoutsupplementaire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliparcoeficientcoutsupplementaire clsCliparcoeficientcoutsupplementaire,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamJF_CODETYPEJOURFACTURATION = new SqlParameter("@JF_CODETYPEJOURFACTURATION", SqlDbType.VarChar, 2);
			vppParamJF_CODETYPEJOURFACTURATION.Value  = clsCliparcoeficientcoutsupplementaire.JF_CODETYPEJOURFACTURATION ;
			SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 3);
			vppParamNT_CODENATURETIERS.Value  = clsCliparcoeficientcoutsupplementaire.NT_CODENATURETIERS ;

            SqlParameter vppParamCF_CODECOEFICIENT = new SqlParameter("@CF_CODECOEFICIENT", SqlDbType.VarChar, 50);
            vppParamCF_CODECOEFICIENT.Value  = clsCliparcoeficientcoutsupplementaire.CF_CODECOEFICIENT;

			SqlParameter vppParamCF_TAUXSUPLEMENTAIRE = new SqlParameter("@CF_TAUXSUPLEMENTAIRE", SqlDbType.Float);
			vppParamCF_TAUXSUPLEMENTAIRE.Value  = clsCliparcoeficientcoutsupplementaire.CF_TAUXSUPLEMENTAIRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE  @JF_CODETYPEJOURFACTURATION, @NT_CODENATURETIERS,@CF_CODECOEFICIENT, @CF_TAUXSUPLEMENTAIRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamJF_CODETYPEJOURFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
			vppSqlCmd.Parameters.Add(vppParamCF_CODECOEFICIENT);

			vppSqlCmd.Parameters.Add(vppParamCF_TAUXSUPLEMENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE  @JF_CODETYPEJOURFACTURATION, @NT_CODENATURETIERS,@CF_CODECOEFICIENT, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparcoeficientcoutsupplementaire </returns>
		///<author>Home Technology</author>
		public List<clsCliparcoeficientcoutsupplementaire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS,CF_CODECOEFICIENT, CF_TAUXSUPLEMENTAIRE FROM dbo.FT_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliparcoeficientcoutsupplementaire> clsCliparcoeficientcoutsupplementaires = new List<clsCliparcoeficientcoutsupplementaire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparcoeficientcoutsupplementaire clsCliparcoeficientcoutsupplementaire = new clsCliparcoeficientcoutsupplementaire();
					clsCliparcoeficientcoutsupplementaire.JF_CODETYPEJOURFACTURATION = clsDonnee.vogDataReader["JF_CODETYPEJOURFACTURATION"].ToString();
					clsCliparcoeficientcoutsupplementaire.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
					clsCliparcoeficientcoutsupplementaire.CF_CODECOEFICIENT = clsDonnee.vogDataReader["CF_CODECOEFICIENT"].ToString();
					clsCliparcoeficientcoutsupplementaire.CF_TAUXSUPLEMENTAIRE = float.Parse(clsDonnee.vogDataReader["CF_TAUXSUPLEMENTAIRE"].ToString());
					clsCliparcoeficientcoutsupplementaires.Add(clsCliparcoeficientcoutsupplementaire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliparcoeficientcoutsupplementaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparcoeficientcoutsupplementaire </returns>
		///<author>Home Technology</author>
		public List<clsCliparcoeficientcoutsupplementaire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliparcoeficientcoutsupplementaire> clsCliparcoeficientcoutsupplementaires = new List<clsCliparcoeficientcoutsupplementaire>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS,CF_CODECOEFICIENT, CF_TAUXSUPLEMENTAIRE FROM dbo.FT_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliparcoeficientcoutsupplementaire clsCliparcoeficientcoutsupplementaire = new clsCliparcoeficientcoutsupplementaire();
					clsCliparcoeficientcoutsupplementaire.JF_CODETYPEJOURFACTURATION = Dataset.Tables["TABLE"].Rows[Idx]["JF_CODETYPEJOURFACTURATION"].ToString();
					clsCliparcoeficientcoutsupplementaire.NT_CODENATURETIERS = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETIERS"].ToString();
					clsCliparcoeficientcoutsupplementaire.CF_CODECOEFICIENT = Dataset.Tables["TABLE"].Rows[Idx]["CF_CODECOEFICIENT"].ToString();
					clsCliparcoeficientcoutsupplementaire.CF_TAUXSUPLEMENTAIRE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CF_TAUXSUPLEMENTAIRE"].ToString());
					clsCliparcoeficientcoutsupplementaires.Add(clsCliparcoeficientcoutsupplementaire);
				}
				Dataset.Dispose();
			}
		return clsCliparcoeficientcoutsupplementaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT JF_CODETYPEJOURFACTURATION , CF_TAUXSUPLEMENTAIRE FROM dbo.FT_CLIPARCOEFICIENTCOUTSUPPLEMENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :JF_CODETYPEJOURFACTURATION, NT_CODENATURETIERS)</summary>
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
				this.vapCritere ="WHERE JF_CODETYPEJOURFACTURATION=@JF_CODETYPEJOURFACTURATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@JF_CODETYPEJOURFACTURATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE JF_CODETYPEJOURFACTURATION=@JF_CODETYPEJOURFACTURATION AND NT_CODENATURETIERS=@NT_CODENATURETIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@JF_CODETYPEJOURFACTURATION","@NT_CODENATURETIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
                case 3 :
                this.vapCritere = "WHERE JF_CODETYPEJOURFACTURATION=@JF_CODETYPEJOURFACTURATION AND NT_CODENATURETIERS=@NT_CODENATURETIERS  AND CF_CODECOEFICIENT=@CF_CODECOEFICIENT  ";
                vapNomParametre = new string[]{"@CODECRYPTAGE","@JF_CODETYPEJOURFACTURATION","@NT_CODENATURETIERS", "@CF_CODECOEFICIENT" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
                break;


			}
		}
	}
}
