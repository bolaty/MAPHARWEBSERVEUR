using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparbranchecategorietarifWSDAL: ITableDAL<clsCtparbranchecategorietarif>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CB_IDBRANCHE) AS CB_IDBRANCHE  FROM dbo.FT_CTPARBRANCHECATEGORIETARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CB_IDBRANCHE) AS CB_IDBRANCHE  FROM dbo.FT_CTPARBRANCHECATEGORIETARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CB_IDBRANCHE) AS CB_IDBRANCHE  FROM dbo.FT_CTPARBRANCHECATEGORIETARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparbranchecategorietarif comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparbranchecategorietarif pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT BC_NUMEROORDRE  FROM dbo.FT_CTPARBRANCHECATEGORIETARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new clsCtparbranchecategorietarif();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparbranchecategorietarif.BC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["BC_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparbranchecategorietarif;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparbranchecategorietarif>clsCtparbranchecategorietarif</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparbranchecategorietarif clsCtparbranchecategorietarif)
		{
			//Préparation des paramètres
			SqlParameter vppParamCB_IDBRANCHE = new SqlParameter("@CB_IDBRANCHE", SqlDbType.Int);
			vppParamCB_IDBRANCHE.Value  = clsCtparbranchecategorietarif.CB_IDBRANCHE ;
			SqlParameter vppParamAU_CODECATEGORIE = new SqlParameter("@AU_CODECATEGORIE", SqlDbType.Int);
			vppParamAU_CODECATEGORIE.Value  = clsCtparbranchecategorietarif.AU_CODECATEGORIE ;
			SqlParameter vppParamTA_CODETARIF = new SqlParameter("@TA_CODETARIF", SqlDbType.Int);
			vppParamTA_CODETARIF.Value  = clsCtparbranchecategorietarif.TA_CODETARIF ;
			SqlParameter vppParamBC_NUMEROORDRE = new SqlParameter("@BC_NUMEROORDRE", SqlDbType.Int);
			vppParamBC_NUMEROORDRE.Value  = clsCtparbranchecategorietarif.BC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARBRANCHECATEGORIETARIF  @CB_IDBRANCHE, @AU_CODECATEGORIE, @TA_CODETARIF, @BC_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCB_IDBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamAU_CODECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETARIF);
			vppSqlCmd.Parameters.Add(vppParamBC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparbranchecategorietarif>clsCtparbranchecategorietarif</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparbranchecategorietarif clsCtparbranchecategorietarif,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCB_IDBRANCHE = new SqlParameter("@CB_IDBRANCHE", SqlDbType.Int);
			vppParamCB_IDBRANCHE.Value  = clsCtparbranchecategorietarif.CB_IDBRANCHE ;
			SqlParameter vppParamAU_CODECATEGORIE = new SqlParameter("@AU_CODECATEGORIE", SqlDbType.Int);
			vppParamAU_CODECATEGORIE.Value  = clsCtparbranchecategorietarif.AU_CODECATEGORIE ;
			SqlParameter vppParamTA_CODETARIF = new SqlParameter("@TA_CODETARIF", SqlDbType.Int);
			vppParamTA_CODETARIF.Value  = clsCtparbranchecategorietarif.TA_CODETARIF ;
			SqlParameter vppParamBC_NUMEROORDRE = new SqlParameter("@BC_NUMEROORDRE", SqlDbType.Int);
			vppParamBC_NUMEROORDRE.Value  = clsCtparbranchecategorietarif.BC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARBRANCHECATEGORIETARIF  @CB_IDBRANCHE, @AU_CODECATEGORIE, @TA_CODETARIF, @BC_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCB_IDBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamAU_CODECATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETARIF);
			vppSqlCmd.Parameters.Add(vppParamBC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARBRANCHECATEGORIETARIF  @CB_IDBRANCHE, @AU_CODECATEGORIE, @TA_CODETARIF, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparbranchecategorietarif </returns>
		///<author>Home Technology</author>
		public List<clsCtparbranchecategorietarif> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF, BC_NUMEROORDRE FROM dbo.FT_CTPARBRANCHECATEGORIETARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<clsCtparbranchecategorietarif>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new clsCtparbranchecategorietarif();
					clsCtparbranchecategorietarif.CB_IDBRANCHE = int.Parse(clsDonnee.vogDataReader["CB_IDBRANCHE"].ToString());
					clsCtparbranchecategorietarif.AU_CODECATEGORIE = int.Parse(clsDonnee.vogDataReader["AU_CODECATEGORIE"].ToString());
					clsCtparbranchecategorietarif.TA_CODETARIF = int.Parse(clsDonnee.vogDataReader["TA_CODETARIF"].ToString());
					clsCtparbranchecategorietarif.BC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["BC_NUMEROORDRE"].ToString());
					clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparbranchecategorietarifs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparbranchecategorietarif </returns>
		///<author>Home Technology</author>
		public List<clsCtparbranchecategorietarif> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<clsCtparbranchecategorietarif>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF, BC_NUMEROORDRE FROM dbo.FT_CTPARBRANCHECATEGORIETARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new clsCtparbranchecategorietarif();
					clsCtparbranchecategorietarif.CB_IDBRANCHE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CB_IDBRANCHE"].ToString());
					clsCtparbranchecategorietarif.AU_CODECATEGORIE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AU_CODECATEGORIE"].ToString());
					clsCtparbranchecategorietarif.TA_CODETARIF = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETARIF"].ToString());
					clsCtparbranchecategorietarif.BC_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BC_NUMEROORDRE"].ToString());
					clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
				}
				Dataset.Dispose();
			}
		return clsCtparbranchecategorietarifs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARBRANCHECATEGORIETARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CB_IDBRANCHE , BC_NUMEROORDRE FROM dbo.FT_CTPARBRANCHECATEGORIETARIF(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		public DataSet pvgChargerDansDataSetSelonBranche(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE" , "@CB_IDBRANCHE", "@TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] , vppCritere[1] };
            this.vapRequete = "EXEC [dbo].[PS_CTPARBRANCHECATEGORIETARIF] @CB_IDBRANCHE,@TYPEETAT,@CODECRYPTAGE" ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CB_IDBRANCHE, AU_CODECATEGORIE, TA_CODETARIF)</summary>
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
				this.vapCritere ="WHERE CB_IDBRANCHE=@CB_IDBRANCHE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CB_IDBRANCHE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE CB_IDBRANCHE=@CB_IDBRANCHE AND AU_CODECATEGORIE=@AU_CODECATEGORIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CB_IDBRANCHE","@AU_CODECATEGORIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE CB_IDBRANCHE=@CB_IDBRANCHE AND AU_CODECATEGORIE=@AU_CODECATEGORIE AND TA_CODETARIF=@TA_CODETARIF";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CB_IDBRANCHE","@AU_CODECATEGORIE","@TA_CODETARIF"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
