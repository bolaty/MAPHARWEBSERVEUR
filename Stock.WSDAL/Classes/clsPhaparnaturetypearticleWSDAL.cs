using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparnaturetypearticleWSDAL: ITableDAL<clsPhaparnaturetypearticle>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(NT_CODENATURETYPEARTICLE) AS NT_CODENATURETYPEARTICLE  FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(NT_CODENATURETYPEARTICLE) AS NT_CODENATURETYPEARTICLE  FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(NT_CODENATURETYPEARTICLE) AS NT_CODENATURETYPEARTICLE  FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparnaturetypearticle comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparnaturetypearticle pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_CODETYPEARTICLE  , PS_CODEPRESTATION  , AR_CODEARTICLE  , NT_LIBELLE  FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new clsPhaparnaturetypearticle();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparnaturetypearticle.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
					clsPhaparnaturetypearticle.PS_CODEPRESTATION = clsDonnee.vogDataReader["PS_CODEPRESTATION"].ToString();
					clsPhaparnaturetypearticle.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparnaturetypearticle.NT_LIBELLE = clsDonnee.vogDataReader["NT_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparnaturetypearticle;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparnaturetypearticle>clsPhaparnaturetypearticle</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparnaturetypearticle clsPhaparnaturetypearticle)
		{
			//Préparation des paramètres
			SqlParameter vppParamNT_CODENATURETYPEARTICLE = new SqlParameter("@NT_CODENATURETYPEARTICLE", SqlDbType.VarChar, 7);
			vppParamNT_CODENATURETYPEARTICLE.Value  = clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE ;
			SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 3);
			vppParamTA_CODETYPEARTICLE.Value  = clsPhaparnaturetypearticle.TA_CODETYPEARTICLE ;
			SqlParameter vppParamPS_CODEPRESTATION = new SqlParameter("@PS_CODEPRESTATION", SqlDbType.VarChar, 7);
			vppParamPS_CODEPRESTATION.Value  = clsPhaparnaturetypearticle.PS_CODEPRESTATION ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparnaturetypearticle.AR_CODEARTICLE ;
			SqlParameter vppParamNT_LIBELLE = new SqlParameter("@NT_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNT_LIBELLE.Value  = clsPhaparnaturetypearticle.NT_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARNATURETYPEARTICLE  @NT_CODENATURETYPEARTICLE, @TA_CODETYPEARTICLE, @PS_CODEPRESTATION, @AR_CODEARTICLE, @NT_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamPS_CODEPRESTATION);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamNT_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparnaturetypearticle>clsPhaparnaturetypearticle</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparnaturetypearticle clsPhaparnaturetypearticle,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamNT_CODENATURETYPEARTICLE = new SqlParameter("@NT_CODENATURETYPEARTICLE", SqlDbType.VarChar, 7);
			vppParamNT_CODENATURETYPEARTICLE.Value  = clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE ;
			SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 3);
			vppParamTA_CODETYPEARTICLE.Value  = clsPhaparnaturetypearticle.TA_CODETYPEARTICLE ;
			SqlParameter vppParamPS_CODEPRESTATION = new SqlParameter("@PS_CODEPRESTATION", SqlDbType.VarChar, 7);
			vppParamPS_CODEPRESTATION.Value  = clsPhaparnaturetypearticle.PS_CODEPRESTATION ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparnaturetypearticle.AR_CODEARTICLE ;
			SqlParameter vppParamNT_LIBELLE = new SqlParameter("@NT_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNT_LIBELLE.Value  = clsPhaparnaturetypearticle.NT_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARNATURETYPEARTICLE  @NT_CODENATURETYPEARTICLE, @TA_CODETYPEARTICLE, @PS_CODEPRESTATION, @AR_CODEARTICLE, @NT_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamPS_CODEPRESTATION);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamNT_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARNATURETYPEARTICLE  @NT_CODENATURETYPEARTICLE, @TA_CODETYPEARTICLE, @PS_CODEPRESTATION, @AR_CODEARTICLE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparnaturetypearticle </returns>
		///<author>Home Technology</author>
		public List<clsPhaparnaturetypearticle> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE, NT_LIBELLE FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<clsPhaparnaturetypearticle>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new clsPhaparnaturetypearticle();
					clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE = clsDonnee.vogDataReader["NT_CODENATURETYPEARTICLE"].ToString();
					clsPhaparnaturetypearticle.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
					clsPhaparnaturetypearticle.PS_CODEPRESTATION = clsDonnee.vogDataReader["PS_CODEPRESTATION"].ToString();
					clsPhaparnaturetypearticle.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparnaturetypearticle.NT_LIBELLE = clsDonnee.vogDataReader["NT_LIBELLE"].ToString();
					clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparnaturetypearticles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparnaturetypearticle </returns>
		///<author>Home Technology</author>
		public List<clsPhaparnaturetypearticle> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<clsPhaparnaturetypearticle>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE, NT_LIBELLE FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new clsPhaparnaturetypearticle();
					clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETYPEARTICLE"].ToString();
					clsPhaparnaturetypearticle.TA_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEARTICLE"].ToString();
					clsPhaparnaturetypearticle.PS_CODEPRESTATION = Dataset.Tables["TABLE"].Rows[Idx]["PS_CODEPRESTATION"].ToString();
					clsPhaparnaturetypearticle.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaparnaturetypearticle.NT_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["NT_LIBELLE"].ToString();
					clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
				}
				Dataset.Dispose();
			}
		return clsPhaparnaturetypearticles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NT_CODENATURETYPEARTICLE , NT_LIBELLE FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}
        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboModeGestion(clsDonnee clsDonnee, params string[] vppCritere)
        {
            if (vppCritere[0] == "07")
            {
                this.vapCritere = " ";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
            }
            else 
            {
                this.vapCritere = "WHERE NT_CODENATURETYPEARTICLE<>'03'";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
            }
            this.vapRequete = "SELECT NT_CODENATURETYPEARTICLE , NT_LIBELLE FROM dbo.FT_PHAPARNATURETYPEARTICLE(@CODECRYPTAGE) " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }
		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NT_CODENATURETYPEARTICLE, TA_CODETYPEARTICLE, PS_CODEPRESTATION, AR_CODEARTICLE)</summary>
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
				this.vapCritere ="WHERE NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NT_CODENATURETYPEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE AND TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NT_CODENATURETYPEARTICLE","@TA_CODETYPEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE AND TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE AND PS_CODEPRESTATION=@PS_CODEPRESTATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NT_CODENATURETYPEARTICLE","@TA_CODETYPEARTICLE","@PS_CODEPRESTATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE AND TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE AND PS_CODEPRESTATION=@PS_CODEPRESTATION AND AR_CODEARTICLE=@AR_CODEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NT_CODENATURETYPEARTICLE","@TA_CODETYPEARTICLE","@PS_CODEPRESTATION","@AR_CODEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
