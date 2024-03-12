using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtsinistresituationdossierWSDAL: ITableDAL<clsCtsinistresituationdossier>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTRESITUATIONDOSSIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTRESITUATIONDOSSIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTRESITUATIONDOSSIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtsinistresituationdossier comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtsinistresituationdossier pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SD_CODESITUATIONDOSSIER  , SI_DATESAISIE  , OP_CODEOPERATEUR  FROM dbo.FT_CTSINISTRESITUATIONDOSSIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtsinistresituationdossier clsCtsinistresituationdossier = new clsCtsinistresituationdossier();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER = clsDonnee.vogDataReader["SD_CODESITUATIONDOSSIER"].ToString();
					clsCtsinistresituationdossier.SI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATESAISIE"].ToString());
					clsCtsinistresituationdossier.OP_CODEOPERATEUR =clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtsinistresituationdossier;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinistresituationdossier>clsCtsinistresituationdossier</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtsinistresituationdossier clsCtsinistresituationdossier)
		{
			//Préparation des paramètres
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE1", SqlDbType.Decimal, 4);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistresituationdossier.SI_CODESINISTRE ;
			SqlParameter vppParamSD_CODESITUATIONDOSSIER = new SqlParameter("@SD_CODESITUATIONDOSSIER", SqlDbType.VarChar, 2);
			vppParamSD_CODESITUATIONDOSSIER.Value  = clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER ;
			SqlParameter vppParamSI_DATESAISIE = new SqlParameter("@SI_DATESAISIE", SqlDbType.DateTime);
			vppParamSI_DATESAISIE.Value  = clsCtsinistresituationdossier.SI_DATESAISIE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinistresituationdossier.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRESITUATIONDOSSIER  @SI_CODESINISTRE1, @SD_CODESITUATIONDOSSIER, @SI_DATESAISIE, @OP_CODEOPERATEUR, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSD_CODESITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinistresituationdossier>clsCtsinistresituationdossier</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtsinistresituationdossier clsCtsinistresituationdossier,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.Decimal, 4);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistresituationdossier.SI_CODESINISTRE ;
			SqlParameter vppParamSD_CODESITUATIONDOSSIER = new SqlParameter("@SD_CODESITUATIONDOSSIER", SqlDbType.VarChar, 2);
			vppParamSD_CODESITUATIONDOSSIER.Value  = clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER ;
			SqlParameter vppParamSI_DATESAISIE = new SqlParameter("@SI_DATESAISIE", SqlDbType.DateTime);
			vppParamSI_DATESAISIE.Value  = clsCtsinistresituationdossier.SI_DATESAISIE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinistresituationdossier.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRESITUATIONDOSSIER  @SI_CODESINISTRE, @SD_CODESITUATIONDOSSIER, @SI_DATESAISIE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSD_CODESITUATIONDOSSIER);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRESITUATIONDOSSIER  @SI_CODESINISTRE, '', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistresituationdossier </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistresituationdossier> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SI_CODESINISTRE, SD_CODESITUATIONDOSSIER, SI_DATESAISIE, OP_CODEOPERATEUR FROM dbo.FT_CTSINISTRESITUATIONDOSSIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<clsCtsinistresituationdossier>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistresituationdossier clsCtsinistresituationdossier = new clsCtsinistresituationdossier();
					clsCtsinistresituationdossier.SI_CODESINISTRE = clsDonnee.vogDataReader["SI_CODESINISTRE"].ToString();
					clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER = clsDonnee.vogDataReader["SD_CODESITUATIONDOSSIER"].ToString();
					clsCtsinistresituationdossier.SI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATESAISIE"].ToString());
					clsCtsinistresituationdossier.OP_CODEOPERATEUR =clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtsinistresituationdossiers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistresituationdossier </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistresituationdossier> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<clsCtsinistresituationdossier>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SI_CODESINISTRE, SD_CODESITUATIONDOSSIER, SI_DATESAISIE, OP_CODEOPERATEUR FROM dbo.FT_CTSINISTRESITUATIONDOSSIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtsinistresituationdossier clsCtsinistresituationdossier = new clsCtsinistresituationdossier();
					clsCtsinistresituationdossier.SI_CODESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_CODESINISTRE"].ToString();
					clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER = Dataset.Tables["TABLE"].Rows[Idx]["SD_CODESITUATIONDOSSIER"].ToString();
					clsCtsinistresituationdossier.SI_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_DATESAISIE"].ToString());
					clsCtsinistresituationdossier.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
				}
				Dataset.Dispose();
			}
		return clsCtsinistresituationdossiers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            this.vapCritere = "WHERE SI_CODESINISTRE=@SI_CODESINISTRE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@SI_CODESINISTRE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
            this.vapRequete = "EXEC PS_CTSINISTRESITUATIONDOSSIER @SI_CODESINISTRE,@CODECRYPTAGE" ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SI_CODESINISTRE, SD_CODESITUATIONDOSSIER ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SI_CODESINISTRE , SI_DATESAISIE FROM dbo.FT_CTSINISTRESITUATIONDOSSIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SI_CODESINISTRE, SD_CODESITUATIONDOSSIER)</summary>
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
				this.vapCritere ="WHERE SI_CODESINISTRE=@SI_CODESINISTRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SI_CODESINISTRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE SI_CODESINISTRE=@SI_CODESINISTRE AND SD_CODESITUATIONDOSSIER=@SD_CODESITUATIONDOSSIER";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SI_CODESINISTRE","@SD_CODESITUATIONDOSSIER"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
