using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparcontratstatutdemandeWSDAL: ITableDAL<clsCtparcontratstatutdemande>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(SD_CODEPIECE) AS SD_CODEPIECE  FROM dbo.FT_CTPARCONTRATSTATUTDEMANDE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(SD_CODEPIECE) AS SD_CODEPIECE  FROM dbo.FT_CTPARCONTRATSTATUTDEMANDE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(SD_CODEPIECE) AS SD_CODEPIECE  FROM dbo.FT_CTPARCONTRATSTATUTDEMANDE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparcontratstatutdemande comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparcontratstatutdemande pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SD_LIBELLEPIECE  , SD_QUANTITE  , SD_ACTIF  FROM dbo.FT_CTPARCONTRATSTATUTDEMANDE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new clsCtparcontratstatutdemande();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparcontratstatutdemande.SD_LIBELLEPIECE = clsDonnee.vogDataReader["SD_LIBELLEPIECE"].ToString();
					//clsCtparcontratstatutdemande.SD_QUANTITE = int.Parse(clsDonnee.vogDataReader["SD_QUANTITE"].ToString());
					clsCtparcontratstatutdemande.SD_ACTIF = clsDonnee.vogDataReader["SD_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparcontratstatutdemande;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparcontratstatutdemande>clsCtparcontratstatutdemande</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparcontratstatutdemande clsCtparcontratstatutdemande)
		{
			//Préparation des paramètres
			SqlParameter vppParamSD_CODEPIECE = new SqlParameter("@SD_CODEPIECE", SqlDbType.VarChar, 4);
			vppParamSD_CODEPIECE.Value  = clsCtparcontratstatutdemande.SD_CODEPIECE ;
			SqlParameter vppParamSD_LIBELLEPIECE = new SqlParameter("@SD_LIBELLEPIECE", SqlDbType.VarChar, 150);
			vppParamSD_LIBELLEPIECE.Value  = clsCtparcontratstatutdemande.SD_LIBELLEPIECE ;
			//SqlParameter vppParamSD_QUANTITE = new SqlParameter("@SD_QUANTITE", SqlDbType.Int);
			//vppParamSD_QUANTITE.Value  = clsCtparcontratstatutdemande.SD_QUANTITE ;
			SqlParameter vppParamSD_ACTIF = new SqlParameter("@SD_ACTIF", SqlDbType.VarChar, 1);
			vppParamSD_ACTIF.Value  = clsCtparcontratstatutdemande.SD_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCONTRATSTATUTDEMANDE  @SD_CODEPIECE, @SD_LIBELLEPIECE,  @SD_ACTIF, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSD_CODEPIECE);
			vppSqlCmd.Parameters.Add(vppParamSD_LIBELLEPIECE);
			//vppSqlCmd.Parameters.Add(vppParamSD_QUANTITE);
			vppSqlCmd.Parameters.Add(vppParamSD_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparcontratstatutdemande>clsCtparcontratstatutdemande</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparcontratstatutdemande clsCtparcontratstatutdemande,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamSD_CODEPIECE = new SqlParameter("@SD_CODEPIECE", SqlDbType.VarChar, 4);
			vppParamSD_CODEPIECE.Value  = clsCtparcontratstatutdemande.SD_CODEPIECE ;
			SqlParameter vppParamSD_LIBELLEPIECE = new SqlParameter("@SD_LIBELLEPIECE", SqlDbType.VarChar, 150);
			vppParamSD_LIBELLEPIECE.Value  = clsCtparcontratstatutdemande.SD_LIBELLEPIECE ;
			//SqlParameter vppParamSD_QUANTITE = new SqlParameter("@SD_QUANTITE", SqlDbType.Int);
			//vppParamSD_QUANTITE.Value  = clsCtparcontratstatutdemande.SD_QUANTITE ;
			SqlParameter vppParamSD_ACTIF = new SqlParameter("@SD_ACTIF", SqlDbType.VarChar, 1);
			vppParamSD_ACTIF.Value  = clsCtparcontratstatutdemande.SD_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCONTRATSTATUTDEMANDE  @SD_CODEPIECE, @SD_LIBELLEPIECE, @SD_ACTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSD_CODEPIECE);
			vppSqlCmd.Parameters.Add(vppParamSD_LIBELLEPIECE);
			//vppSqlCmd.Parameters.Add(vppParamSD_QUANTITE);
			vppSqlCmd.Parameters.Add(vppParamSD_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCONTRATSTATUTDEMANDE  @SD_CODEPIECE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparcontratstatutdemande </returns>
		///<author>Home Technology</author>
		public List<clsCtparcontratstatutdemande> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SD_CODEPIECE, SD_LIBELLEPIECE, SD_QUANTITE, SD_ACTIF FROM dbo.FT_CTPARCONTRATSTATUTDEMANDE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<clsCtparcontratstatutdemande>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new clsCtparcontratstatutdemande();
					clsCtparcontratstatutdemande.SD_CODEPIECE = clsDonnee.vogDataReader["SD_CODEPIECE"].ToString();
					clsCtparcontratstatutdemande.SD_LIBELLEPIECE = clsDonnee.vogDataReader["SD_LIBELLEPIECE"].ToString();
					//clsCtparcontratstatutdemande.SD_QUANTITE = int.Parse(clsDonnee.vogDataReader["SD_QUANTITE"].ToString());
					clsCtparcontratstatutdemande.SD_ACTIF = clsDonnee.vogDataReader["SD_ACTIF"].ToString();
					clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparcontratstatutdemandes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparcontratstatutdemande </returns>
		///<author>Home Technology</author>
		public List<clsCtparcontratstatutdemande> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<clsCtparcontratstatutdemande>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SD_CODEPIECE, SD_LIBELLEPIECE, SD_QUANTITE, SD_ACTIF FROM dbo.FT_CTPARCONTRATSTATUTDEMANDE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new clsCtparcontratstatutdemande();
					clsCtparcontratstatutdemande.SD_CODEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["SD_CODEPIECE"].ToString();
					clsCtparcontratstatutdemande.SD_LIBELLEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["SD_LIBELLEPIECE"].ToString();
					//clsCtparcontratstatutdemande.SD_QUANTITE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SD_QUANTITE"].ToString());
					clsCtparcontratstatutdemande.SD_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["SD_ACTIF"].ToString();
					clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
				}
				Dataset.Dispose();
			}
		return clsCtparcontratstatutdemandes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARCONTRATSTATUTDEMANDE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SD_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SD_CODEPIECE , SD_LIBELLEPIECE FROM dbo.FT_CTPARCONTRATSTATUTDEMANDE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SD_CODEPIECE)</summary>
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
				this.vapCritere ="WHERE SD_CODEPIECE=@SD_CODEPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SD_CODEPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
