using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtsinistresuivieWSDAL: ITableDAL<clsCtsinistresuivie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTSINISTRESUIVIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTSINISTRESUIVIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTSINISTRESUIVIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtsinistresuivie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtsinistresuivie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , SI_CODESINISTRE  , SD_DESCRIPTIONEVENEMENT  , OP_CODEOPERATEUR  FROM dbo.FT_CTSINISTRESUIVIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtsinistresuivie clsCtsinistresuivie = new clsCtsinistresuivie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistresuivie.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtsinistresuivie.SI_CODESINISTRE = clsDonnee.vogDataReader["SI_CODESINISTRE"].ToString();
					clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = clsDonnee.vogDataReader["SD_DESCRIPTIONEVENEMENT"].ToString();
					clsCtsinistresuivie.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtsinistresuivie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinistresuivie>clsCtsinistresuivie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtsinistresuivie clsCtsinistresuivie)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtsinistresuivie.AG_CODEAGENCE ;
			SqlParameter vppParamSD_INDEXSUIVIE = new SqlParameter("@SD_INDEXSUIVIE", SqlDbType.VarChar, 25);
			vppParamSD_INDEXSUIVIE.Value  = clsCtsinistresuivie.SD_INDEXSUIVIE ;

			SqlParameter vppParamSD_DATESAISIE = new SqlParameter("@SD_DATESAISIE", SqlDbType.DateTime);
            vppParamSD_DATESAISIE.Value  = clsCtsinistresuivie.SD_DATESAISIE;

			SqlParameter vppParamSD_DATESUIVIE = new SqlParameter("@SD_DATESUIVIE", SqlDbType.DateTime);
			vppParamSD_DATESUIVIE.Value  = clsCtsinistresuivie.SD_DATESUIVIE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtsinistresuivie.EN_CODEENTREPOT ;
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistresuivie.SI_CODESINISTRE ;
			SqlParameter vppParamSD_DESCRIPTIONEVENEMENT = new SqlParameter("@SD_DESCRIPTIONEVENEMENT", SqlDbType.VarChar, 1000);
			vppParamSD_DESCRIPTIONEVENEMENT.Value  = clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinistresuivie.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRESUIVIE  @AG_CODEAGENCE, @SD_INDEXSUIVIE,@SD_DATESAISIE, @SD_DATESUIVIE, @EN_CODEENTREPOT, @SI_CODESINISTRE, @SD_DESCRIPTIONEVENEMENT, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSD_INDEXSUIVIE);
			vppSqlCmd.Parameters.Add(vppParamSD_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamSD_DATESUIVIE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSD_DESCRIPTIONEVENEMENT);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinistresuivie>clsCtsinistresuivie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtsinistresuivie clsCtsinistresuivie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtsinistresuivie.AG_CODEAGENCE ;
			SqlParameter vppParamSD_INDEXSUIVIE = new SqlParameter("@SD_INDEXSUIVIE", SqlDbType.VarChar, 25);
			vppParamSD_INDEXSUIVIE.Value  = clsCtsinistresuivie.SD_INDEXSUIVIE ;
			SqlParameter vppParamSD_DATESAISIE = new SqlParameter("@SD_DATESAISIE", SqlDbType.DateTime);
            vppParamSD_DATESAISIE.Value  = clsCtsinistresuivie.SD_DATESAISIE;

			SqlParameter vppParamSD_DATESUIVIE = new SqlParameter("@SD_DATESUIVIE", SqlDbType.DateTime);
			vppParamSD_DATESUIVIE.Value  = clsCtsinistresuivie.SD_DATESUIVIE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtsinistresuivie.EN_CODEENTREPOT ;
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistresuivie.SI_CODESINISTRE ;
			SqlParameter vppParamSD_DESCRIPTIONEVENEMENT = new SqlParameter("@SD_DESCRIPTIONEVENEMENT", SqlDbType.VarChar, 1000);
			vppParamSD_DESCRIPTIONEVENEMENT.Value  = clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinistresuivie.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRESUIVIE  @AG_CODEAGENCE, @SD_INDEXSUIVIE,@SD_DATESAISIE, @SD_DATESUIVIE, @EN_CODEENTREPOT, @SI_CODESINISTRE, @SD_DESCRIPTIONEVENEMENT, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSD_INDEXSUIVIE);
			vppSqlCmd.Parameters.Add(vppParamSD_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamSD_DATESUIVIE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSD_DESCRIPTIONEVENEMENT);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRESUIVIE  @AG_CODEAGENCE, @SD_INDEXSUIVIE,@SD_DATESAISIE, '', '' , @SI_CODESINISTRE, '' , '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistresuivie </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistresuivie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, EN_CODEENTREPOT, SI_CODESINISTRE, SD_DESCRIPTIONEVENEMENT, OP_CODEOPERATEUR FROM dbo.FT_CTSINISTRESUIVIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtsinistresuivie> clsCtsinistresuivies = new List<clsCtsinistresuivie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistresuivie clsCtsinistresuivie = new clsCtsinistresuivie();
					clsCtsinistresuivie.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtsinistresuivie.SD_INDEXSUIVIE = clsDonnee.vogDataReader["SD_INDEXSUIVIE"].ToString();
					clsCtsinistresuivie.SD_DATESUIVIE = DateTime.Parse(clsDonnee.vogDataReader["SD_DATESUIVIE"].ToString());
					clsCtsinistresuivie.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtsinistresuivie.SI_CODESINISTRE = clsDonnee.vogDataReader["SI_CODESINISTRE"].ToString();
					clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = clsDonnee.vogDataReader["SD_DESCRIPTIONEVENEMENT"].ToString();
					clsCtsinistresuivie.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtsinistresuivies.Add(clsCtsinistresuivie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtsinistresuivies;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistresuivie </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistresuivie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtsinistresuivie> clsCtsinistresuivies = new List<clsCtsinistresuivie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, EN_CODEENTREPOT, SI_CODESINISTRE, SD_DESCRIPTIONEVENEMENT, OP_CODEOPERATEUR FROM dbo.FT_CTSINISTRESUIVIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtsinistresuivie clsCtsinistresuivie = new clsCtsinistresuivie();
					clsCtsinistresuivie.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtsinistresuivie.SD_INDEXSUIVIE = Dataset.Tables["TABLE"].Rows[Idx]["SD_INDEXSUIVIE"].ToString();
					clsCtsinistresuivie.SD_DATESUIVIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SD_DATESUIVIE"].ToString());
					clsCtsinistresuivie.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtsinistresuivie.SI_CODESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_CODESINISTRE"].ToString();
					clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT = Dataset.Tables["TABLE"].Rows[Idx]["SD_DESCRIPTIONEVENEMENT"].ToString();
					clsCtsinistresuivie.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtsinistresuivies.Add(clsCtsinistresuivie);
				}
				Dataset.Dispose();
			}
		return clsCtsinistresuivies;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SI_CODESINISTRE", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN", "@SD_DESCRIPTIONEVENEMENT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4], vppCritere[5], vppCritere[6] };
            this.vapRequete = "EXEC  [dbo].[PS_CTSINISTRESUIVIE] @AG_CODEAGENCE,@SI_CODESINISTRE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@SD_DESCRIPTIONEVENEMENT,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SD_INDEXSUIVIE , SD_DESCRIPTIONEVENEMENT FROM dbo.FT_CTSINISTRESUIVIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SD_INDEXSUIVIE, SD_DATESUIVIE, SI_CODESINISTRE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SD_INDEXSUIVIE=@SD_INDEXSUIVIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SD_INDEXSUIVIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SD_INDEXSUIVIE=@SD_INDEXSUIVIE AND SD_DATESAISIE=@SD_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SD_INDEXSUIVIE", "@SD_DATESAISIE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SD_INDEXSUIVIE=@SD_INDEXSUIVIE AND SD_DATESAISIE=@SD_DATESAISIE AND SI_CODESINISTRE=@SI_CODESINISTRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SD_INDEXSUIVIE", "@SD_DATESAISIE", "@SI_CODESINISTRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SD_INDEXSUIVIE=@SD_INDEXSUIVIE AND SD_DATESAISIE=@SD_DATESAISIE AND SI_CODESINISTRE=@SI_CODESINISTRE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SD_INDEXSUIVIE", "@SD_DATESAISIE", "@SI_CODESINISTRE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}
	}
}
