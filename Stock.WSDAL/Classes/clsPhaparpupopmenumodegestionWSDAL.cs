using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpupopmenumodegestionWSDAL: ITableDAL<clsPhaparpupopmenumodegestion>
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
			this.vapRequete = "SELECT COUNT(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTION(@CODECRYPTAGE) " + this.vapCritere;
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
			this.vapRequete = "SELECT MIN(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTION(@CODECRYPTAGE) " + this.vapCritere;
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
			this.vapRequete = "SELECT MAX(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpupopmenumodegestion comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpupopmenumodegestion pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MG_CODEMODEGESTION ,MG_LIBELLE  , MG_ACTIF , MG_ENTREPOTOBLIGATOIRE  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpupopmenumodegestion clsPhaparpupopmenumodegestion = new clsPhaparpupopmenumodegestion();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    clsPhaparpupopmenumodegestion.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumodegestion.MG_LIBELLE = clsDonnee.vogDataReader["MG_LIBELLE"].ToString();
					clsPhaparpupopmenumodegestion.MG_ACTIF = clsDonnee.vogDataReader["MG_ACTIF"].ToString();
                    clsPhaparpupopmenumodegestion.MG_ENTREPOTOBLIGATOIRE = clsDonnee.vogDataReader["MG_ENTREPOTOBLIGATOIRE"].ToString();

				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpupopmenumodegestion;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenumodegestion>clsPhaparpupopmenumodegestion</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpupopmenumodegestion clsPhaparpupopmenumodegestion)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparpupopmenumodegestion.MG_CODEMODEGESTION ;
			SqlParameter vppParamMG_LIBELLE = new SqlParameter("@MG_LIBELLE", SqlDbType.VarChar, 150);
			vppParamMG_LIBELLE.Value  = clsPhaparpupopmenumodegestion.MG_LIBELLE ;
			SqlParameter vppParamMG_ACTIF = new SqlParameter("@MG_ACTIF", SqlDbType.VarChar, 1);
			vppParamMG_ACTIF.Value  = clsPhaparpupopmenumodegestion.MG_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMODEGESTION  @MG_CODEMODEGESTION, @MG_LIBELLE, @MG_ACTIF, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamMG_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamMG_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenumodegestion>clsPhaparpupopmenumodegestion</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpupopmenumodegestion clsPhaparpupopmenumodegestion,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparpupopmenumodegestion.MG_CODEMODEGESTION ;
			SqlParameter vppParamMG_LIBELLE = new SqlParameter("@MG_LIBELLE", SqlDbType.VarChar, 150);
			vppParamMG_LIBELLE.Value  = clsPhaparpupopmenumodegestion.MG_LIBELLE ;
			SqlParameter vppParamMG_ACTIF = new SqlParameter("@MG_ACTIF", SqlDbType.VarChar, 1);
			vppParamMG_ACTIF.Value  = clsPhaparpupopmenumodegestion.MG_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMODEGESTION  @MG_CODEMODEGESTION, @MG_LIBELLE, @MG_ACTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamMG_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamMG_ACTIF);
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
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMODEGESTION  @MG_CODEMODEGESTION, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenumodegestion </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenumodegestion> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, MG_LIBELLE, MG_ACTIF FROM dbo.FT_PHAPARPUPOPMENUMODEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpupopmenumodegestion> clsPhaparpupopmenumodegestions = new List<clsPhaparpupopmenumodegestion>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenumodegestion clsPhaparpupopmenumodegestion = new clsPhaparpupopmenumodegestion();
					clsPhaparpupopmenumodegestion.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumodegestion.MG_LIBELLE = clsDonnee.vogDataReader["MG_LIBELLE"].ToString();
					clsPhaparpupopmenumodegestion.MG_ACTIF = clsDonnee.vogDataReader["MG_ACTIF"].ToString();
					clsPhaparpupopmenumodegestions.Add(clsPhaparpupopmenumodegestion);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpupopmenumodegestions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenumodegestion </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenumodegestion> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpupopmenumodegestion> clsPhaparpupopmenumodegestions = new List<clsPhaparpupopmenumodegestion>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, MG_LIBELLE, MG_ACTIF FROM dbo.FT_PHAPARPUPOPMENUMODEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpupopmenumodegestion clsPhaparpupopmenumodegestion = new clsPhaparpupopmenumodegestion();
					clsPhaparpupopmenumodegestion.MG_CODEMODEGESTION = Dataset.Tables["TABLE"].Rows[Idx]["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumodegestion.MG_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["MG_LIBELLE"].ToString();
					clsPhaparpupopmenumodegestion.MG_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["MG_ACTIF"].ToString();
					clsPhaparpupopmenumodegestions.Add(clsPhaparpupopmenumodegestion);
				}
				Dataset.Dispose();
			}
		return clsPhaparpupopmenumodegestions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENUMODEGESTION(@CODECRYPTAGE) " + this.vapCritere;
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
			this.vapRequete = "SELECT MG_CODEMODEGESTION , MG_LIBELLE FROM dbo.FT_PHAPARPUPOPMENUMODEGESTION(@CODECRYPTAGE) " + this.vapCritere;
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
                     this.vapCritere = " WHERE MG_ACTIF='O' ";
				vapNomParametre = new string[]{"@CODECRYPTAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
				break;
				case 1 :
                this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION MG_ACTIF='O' ";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MG_CODEMODEGESTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
