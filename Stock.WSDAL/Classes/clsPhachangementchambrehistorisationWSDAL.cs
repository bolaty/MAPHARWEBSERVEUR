using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhachangementchambrehistorisationWSDAL: ITableDAL<clsPhachangementchambrehistorisation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MD_NUMSEQUENCE) AS MD_NUMSEQUENCE  FROM dbo.PHACHANGEMENTCHAMBREHISTORISATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MD_NUMSEQUENCE) AS MD_NUMSEQUENCE  FROM dbo.PHACHANGEMENTCHAMBREHISTORISATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MD_NUMSEQUENCE) AS MD_NUMSEQUENCE  FROM dbo.PHACHANGEMENTCHAMBREHISTORISATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhachangementchambrehistorisation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhachangementchambrehistorisation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLEDEPART  , AR_CODEARTICLEDESTINATION  , CH_DATECHANGEMENT  FROM dbo.FT_PHACHANGEMENTCHAMBREHISTORISATION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhachangementchambrehistorisation clsPhachangementchambrehistorisation = new clsPhachangementchambrehistorisation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhachangementchambrehistorisation.AR_CODEARTICLEDEPART = clsDonnee.vogDataReader["AR_CODEARTICLEDEPART"].ToString();
					clsPhachangementchambrehistorisation.AR_CODEARTICLEDESTINATION = clsDonnee.vogDataReader["AR_CODEARTICLEDESTINATION"].ToString();
					clsPhachangementchambrehistorisation.CH_DATECHANGEMENT = DateTime.Parse(clsDonnee.vogDataReader["CH_DATECHANGEMENT"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhachangementchambrehistorisation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhachangementchambrehistorisation>clsPhachangementchambrehistorisation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhachangementchambrehistorisation clsPhachangementchambrehistorisation)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 50);
            vppParamAG_CODEAGENCE.Value = clsPhachangementchambrehistorisation.AG_CODEAGENCE;
			SqlParameter vppParamMD_NUMSEQUENCE = new SqlParameter("@MD_NUMSEQUENCE", SqlDbType.VarChar, 50);
			vppParamMD_NUMSEQUENCE.Value  = clsPhachangementchambrehistorisation.MD_NUMSEQUENCE ;
			SqlParameter vppParamAR_CODEARTICLEDEPART = new SqlParameter("@AR_CODEARTICLEDEPART", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLEDEPART.Value  = clsPhachangementchambrehistorisation.AR_CODEARTICLEDEPART ;
			SqlParameter vppParamAR_CODEARTICLEDESTINATION = new SqlParameter("@AR_CODEARTICLEDESTINATION", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLEDESTINATION.Value  = clsPhachangementchambrehistorisation.AR_CODEARTICLEDESTINATION ;
			SqlParameter vppParamCH_DATECHANGEMENT = new SqlParameter("@CH_DATECHANGEMENT", SqlDbType.DateTime);
			vppParamCH_DATECHANGEMENT.Value  = clsPhachangementchambrehistorisation.CH_DATECHANGEMENT ;



            SqlParameter vppParamCH_MOTIF = new SqlParameter("@CH_MOTIF", SqlDbType.VarChar, 1000);
            vppParamCH_MOTIF.Value = clsPhachangementchambrehistorisation.CH_MOTIF;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhachangementchambrehistorisation.OP_CODEOPERATEUR;

            SqlParameter vppParamTI_IDATTRIBUTION = new SqlParameter("@TI_IDATTRIBUTION", SqlDbType.VarChar, 50);
            vppParamTI_IDATTRIBUTION.Value = clsPhachangementchambrehistorisation.TI_IDATTRIBUTION;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHACHANGEMENTCHAMBREHISTORISATION  @AG_CODEAGENCE,@MD_NUMSEQUENCE, @AR_CODEARTICLEDEPART, @AR_CODEARTICLEDESTINATION, @CH_DATECHANGEMENT,@CH_MOTIF,@OP_CODEOPERATEUR,@TI_IDATTRIBUTION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLEDEPART);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLEDESTINATION);
			vppSqlCmd.Parameters.Add(vppParamCH_DATECHANGEMENT);
            vppSqlCmd.Parameters.Add(vppParamCH_MOTIF);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamTI_IDATTRIBUTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhachangementchambrehistorisation>clsPhachangementchambrehistorisation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhachangementchambrehistorisation clsPhachangementchambrehistorisation,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 50);
            vppParamAG_CODEAGENCE.Value = clsPhachangementchambrehistorisation.AG_CODEAGENCE;

			SqlParameter vppParamMD_NUMSEQUENCE = new SqlParameter("@MD_NUMSEQUENCE", SqlDbType.VarChar, 50);
			vppParamMD_NUMSEQUENCE.Value  = clsPhachangementchambrehistorisation.MD_NUMSEQUENCE ;
			SqlParameter vppParamAR_CODEARTICLEDEPART = new SqlParameter("@AR_CODEARTICLEDEPART", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLEDEPART.Value  = clsPhachangementchambrehistorisation.AR_CODEARTICLEDEPART ;
			SqlParameter vppParamAR_CODEARTICLEDESTINATION = new SqlParameter("@AR_CODEARTICLEDESTINATION", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLEDESTINATION.Value  = clsPhachangementchambrehistorisation.AR_CODEARTICLEDESTINATION ;
			SqlParameter vppParamCH_DATECHANGEMENT = new SqlParameter("@CH_DATECHANGEMENT", SqlDbType.DateTime);
			vppParamCH_DATECHANGEMENT.Value  = clsPhachangementchambrehistorisation.CH_DATECHANGEMENT ;

            SqlParameter vppParamCH_MOTIF = new SqlParameter("@CH_MOTIF", SqlDbType.VarChar, 1000);
            vppParamCH_MOTIF.Value = clsPhachangementchambrehistorisation.CH_MOTIF;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhachangementchambrehistorisation.OP_CODEOPERATEUR;

            SqlParameter vppParamTI_IDATTRIBUTION = new SqlParameter("@TI_IDATTRIBUTION", SqlDbType.VarChar, 50);
            vppParamTI_IDATTRIBUTION.Value = clsPhachangementchambrehistorisation.TI_IDATTRIBUTION;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHACHANGEMENTCHAMBREHISTORISATION  @AG_CODEAGENCE,@MD_NUMSEQUENCE, @AR_CODEARTICLEDEPART, @AR_CODEARTICLEDESTINATION, @CH_DATECHANGEMENT,@CH_MOTIF,@OP_CODEOPERATEUR,@TI_IDATTRIBUTION, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLEDEPART);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLEDESTINATION);
			vppSqlCmd.Parameters.Add(vppParamCH_DATECHANGEMENT);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamTI_IDATTRIBUTION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHACHANGEMENTCHAMBREHISTORISATION  @AG_CODEAGENCE,@MD_NUMSEQUENCE, @AR_CODEARTICLEDEPART, '' , '' ,'' , '' ,'' ,@CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhachangementchambrehistorisation </returns>
		///<author>Home Technology</author>
		public List<clsPhachangementchambrehistorisation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MD_NUMSEQUENCE, AR_CODEARTICLEDEPART, AR_CODEARTICLEDESTINATION, CH_DATECHANGEMENT FROM dbo.FT_PHACHANGEMENTCHAMBREHISTORISATION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhachangementchambrehistorisation> clsPhachangementchambrehistorisations = new List<clsPhachangementchambrehistorisation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhachangementchambrehistorisation clsPhachangementchambrehistorisation = new clsPhachangementchambrehistorisation();
					clsPhachangementchambrehistorisation.MD_NUMSEQUENCE = clsDonnee.vogDataReader["MD_NUMSEQUENCE"].ToString();
					clsPhachangementchambrehistorisation.AR_CODEARTICLEDEPART = clsDonnee.vogDataReader["AR_CODEARTICLEDEPART"].ToString();
					clsPhachangementchambrehistorisation.AR_CODEARTICLEDESTINATION = clsDonnee.vogDataReader["AR_CODEARTICLEDESTINATION"].ToString();
					clsPhachangementchambrehistorisation.CH_DATECHANGEMENT = DateTime.Parse(clsDonnee.vogDataReader["CH_DATECHANGEMENT"].ToString());
					clsPhachangementchambrehistorisations.Add(clsPhachangementchambrehistorisation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhachangementchambrehistorisations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhachangementchambrehistorisation </returns>
		///<author>Home Technology</author>
		public List<clsPhachangementchambrehistorisation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhachangementchambrehistorisation> clsPhachangementchambrehistorisations = new List<clsPhachangementchambrehistorisation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MD_NUMSEQUENCE, AR_CODEARTICLEDEPART, AR_CODEARTICLEDESTINATION, CH_DATECHANGEMENT FROM dbo.FT_PHACHANGEMENTCHAMBREHISTORISATION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhachangementchambrehistorisation clsPhachangementchambrehistorisation = new clsPhachangementchambrehistorisation();
					clsPhachangementchambrehistorisation.MD_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["MD_NUMSEQUENCE"].ToString();
					clsPhachangementchambrehistorisation.AR_CODEARTICLEDEPART = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLEDEPART"].ToString();
					clsPhachangementchambrehistorisation.AR_CODEARTICLEDESTINATION = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLEDESTINATION"].ToString();
					clsPhachangementchambrehistorisation.CH_DATECHANGEMENT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATECHANGEMENT"].ToString());
					clsPhachangementchambrehistorisations.Add(clsPhachangementchambrehistorisation);
				}
				Dataset.Dispose();
			}
		return clsPhachangementchambrehistorisations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHACHANGEMENTCHAMBREHISTORISATION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MD_NUMSEQUENCE, AR_CODEARTICLEDEPART ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MD_NUMSEQUENCE , AR_CODEARTICLEDESTINATION FROM dbo.FT_PHACHANGEMENTCHAMBREHISTORISATION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MD_NUMSEQUENCE, AR_CODEARTICLEDEPART)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MD_NUMSEQUENCE=@MD_NUMSEQUENCE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MD_NUMSEQUENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MD_NUMSEQUENCE=@MD_NUMSEQUENCE AND AR_CODEARTICLEDEPART=@AR_CODEARTICLEDEPART";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MD_NUMSEQUENCE", "@AR_CODEARTICLEDEPART" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
