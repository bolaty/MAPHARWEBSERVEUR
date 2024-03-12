using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparprixpromotionWSDAL: ITableDAL<clsPhaparprixpromotion>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXPROMOTION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXPROMOTION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXPROMOTION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparprixpromotion comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparprixpromotion pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT NT_CODENATURETIERS  , PY_DATEREMISE1  , PY_DATEREMISE2  , PY_TAUXREMISE  , PY_MONTANTREMISE  FROM dbo.FT_PHAPARPRIXPROMOTION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparprixpromotion clsPhaparprixpromotion = new clsPhaparprixpromotion();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprixpromotion.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
					clsPhaparprixpromotion.PY_DATEREMISE1 = DateTime.Parse(clsDonnee.vogDataReader["PY_DATEREMISE1"].ToString());
					clsPhaparprixpromotion.PY_DATEREMISE2 = DateTime.Parse(clsDonnee.vogDataReader["PY_DATEREMISE2"].ToString());
					clsPhaparprixpromotion.PY_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["PY_TAUXREMISE"].ToString());
					clsPhaparprixpromotion.PY_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["PY_MONTANTREMISE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparprixpromotion;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprixpromotion>clsPhaparprixpromotion</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparprixpromotion clsPhaparprixpromotion)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparprixpromotion.AG_CODEAGENCE;

			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparprixpromotion.AR_CODEARTICLE ;
			SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS1", SqlDbType.VarChar, 3);
			vppParamNT_CODENATURETIERS.Value  = clsPhaparprixpromotion.NT_CODENATURETIERS ;
			SqlParameter vppParamPY_DATEREMISE1 = new SqlParameter("@PY_DATEREMISE3", SqlDbType.DateTime);
			vppParamPY_DATEREMISE1.Value  = clsPhaparprixpromotion.PY_DATEREMISE1 ;
			SqlParameter vppParamPY_DATEREMISE2 = new SqlParameter("@PY_DATEREMISE4", SqlDbType.DateTime);
			vppParamPY_DATEREMISE2.Value  = clsPhaparprixpromotion.PY_DATEREMISE2 ;

            SqlParameter vppParamPY_DATECLOTURE = new SqlParameter("@PY_DATECLOTURE", SqlDbType.DateTime);
            vppParamPY_DATECLOTURE.Value = clsPhaparprixpromotion.PY_DATECLOTURE;
            if (clsPhaparprixpromotion.PY_DATECLOTURE < DateTime.Parse("01/01/1900")) vppParamPY_DATECLOTURE.Value = DateTime.Parse("01/01/1900");

			SqlParameter vppParamPY_TAUXREMISE = new SqlParameter("@PY_TAUXREMISE", SqlDbType.Float);
			vppParamPY_TAUXREMISE.Value  = clsPhaparprixpromotion.PY_TAUXREMISE ;
			SqlParameter vppParamPY_MONTANTREMISE = new SqlParameter("@PY_MONTANTREMISE", SqlDbType.Money);
			vppParamPY_MONTANTREMISE.Value  = clsPhaparprixpromotion.PY_MONTANTREMISE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparprixpromotion.OP_CODEOPERATEUR;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhaparprixpromotion.TYPEOPERATION;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARPRIXPROMOTION  @AG_CODEAGENCE1, @AR_CODEARTICLE1, @NT_CODENATURETIERS1, @PY_DATEREMISE3, @PY_DATEREMISE4,@PY_DATECLOTURE, @PY_TAUXREMISE, @PY_MONTANTREMISE, @OP_CODEOPERATEUR, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
			vppSqlCmd.Parameters.Add(vppParamPY_DATEREMISE1);
			vppSqlCmd.Parameters.Add(vppParamPY_DATEREMISE2);
            vppSqlCmd.Parameters.Add(vppParamPY_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamPY_TAUXREMISE);
			vppSqlCmd.Parameters.Add(vppParamPY_MONTANTREMISE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprixpromotion>clsPhaparprixpromotion</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparprixpromotion clsPhaparprixpromotion,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparprixpromotion.AG_CODEAGENCE;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparprixpromotion.AR_CODEARTICLE ;
			SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 3);
			vppParamNT_CODENATURETIERS.Value  = clsPhaparprixpromotion.NT_CODENATURETIERS ;
			SqlParameter vppParamPY_DATEREMISE1 = new SqlParameter("@PY_DATEREMISE1", SqlDbType.DateTime);
			vppParamPY_DATEREMISE1.Value  = clsPhaparprixpromotion.PY_DATEREMISE1 ;

			SqlParameter vppParamPY_DATEREMISE2 = new SqlParameter("@PY_DATEREMISE2", SqlDbType.DateTime);
			vppParamPY_DATEREMISE2.Value  = clsPhaparprixpromotion.PY_DATEREMISE2 ;

            SqlParameter vppParamPY_DATECLOTURE = new SqlParameter("@PY_DATECLOTURE", SqlDbType.DateTime);
            vppParamPY_DATECLOTURE.Value = clsPhaparprixpromotion.PY_DATECLOTURE;
            if (clsPhaparprixpromotion.PY_DATECLOTURE < DateTime.Parse("01/01/1900")) vppParamPY_DATECLOTURE.Value = DateTime.Parse("01/01/1900");

			SqlParameter vppParamPY_TAUXREMISE = new SqlParameter("@PY_TAUXREMISE", SqlDbType.Float);
			vppParamPY_TAUXREMISE.Value  = clsPhaparprixpromotion.PY_TAUXREMISE ;
			SqlParameter vppParamPY_MONTANTREMISE = new SqlParameter("@PY_MONTANTREMISE", SqlDbType.Money);
			vppParamPY_MONTANTREMISE.Value  = clsPhaparprixpromotion.PY_MONTANTREMISE ;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar,25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparprixpromotion.OP_CODEOPERATEUR;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhaparprixpromotion.TYPEOPERATION;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARPRIXPROMOTION @AG_CODEAGENCE,  @AR_CODEARTICLE, @NT_CODENATURETIERS, @PY_DATEREMISE1, @PY_DATEREMISE2, @PY_DATECLOTURE, @PY_TAUXREMISE, @PY_MONTANTREMISE, @OP_CODEOPERATEUR, @CODECRYPTAGE, @TYPEOPERATION";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
			vppSqlCmd.Parameters.Add(vppParamPY_DATEREMISE1);
			vppSqlCmd.Parameters.Add(vppParamPY_DATEREMISE2);
            vppSqlCmd.Parameters.Add(vppParamPY_DATECLOTURE);
			vppSqlCmd.Parameters.Add(vppParamPY_TAUXREMISE);
			vppSqlCmd.Parameters.Add(vppParamPY_MONTANTREMISE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARPRIXPROMOTION  @AG_CODEAGENCE, @AR_CODEARTICLE, @NT_CODENATURETIERS, @PY_DATEREMISE1, @PY_DATEREMISE2,'', '' ,'' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprixpromotion </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprixpromotion> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2, PY_TAUXREMISE, PY_MONTANTREMISE FROM dbo.FT_PHAPARPRIXPROMOTION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparprixpromotion> clsPhaparprixpromotions = new List<clsPhaparprixpromotion>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprixpromotion clsPhaparprixpromotion = new clsPhaparprixpromotion();
					clsPhaparprixpromotion.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparprixpromotion.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
					clsPhaparprixpromotion.PY_DATEREMISE1 = DateTime.Parse(clsDonnee.vogDataReader["PY_DATEREMISE1"].ToString());
					clsPhaparprixpromotion.PY_DATEREMISE2 = DateTime.Parse(clsDonnee.vogDataReader["PY_DATEREMISE2"].ToString());
					clsPhaparprixpromotion.PY_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["PY_TAUXREMISE"].ToString());
					clsPhaparprixpromotion.PY_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["PY_MONTANTREMISE"].ToString());
					clsPhaparprixpromotions.Add(clsPhaparprixpromotion);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparprixpromotions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprixpromotion </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprixpromotion> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparprixpromotion> clsPhaparprixpromotions = new List<clsPhaparprixpromotion>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2, PY_TAUXREMISE, PY_MONTANTREMISE FROM dbo.FT_PHAPARPRIXPROMOTION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparprixpromotion clsPhaparprixpromotion = new clsPhaparprixpromotion();
					clsPhaparprixpromotion.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaparprixpromotion.NT_CODENATURETIERS = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETIERS"].ToString();
					clsPhaparprixpromotion.PY_DATEREMISE1 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_DATEREMISE1"].ToString());
					clsPhaparprixpromotion.PY_DATEREMISE2 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_DATEREMISE2"].ToString());
					clsPhaparprixpromotion.PY_TAUXREMISE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_TAUXREMISE"].ToString());
					clsPhaparprixpromotion.PY_MONTANTREMISE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_MONTANTREMISE"].ToString());
					clsPhaparprixpromotions.Add(clsPhaparprixpromotion);
				}
				Dataset.Dispose();
			}
		return clsPhaparprixpromotions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPRIXPROMOTION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE , PY_TAUXREMISE FROM dbo.FT_PHAPARPRIXPROMOTION(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AR_CODEARTICLE, NT_CODENATURETIERS, PY_DATEREMISE1, PY_DATEREMISE2)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;


				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AR_CODEARTICLE", "@NT_CODENATURETIERS" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS AND PY_DATEREMISE1=@PY_DATEREMISE1";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_DATEREMISE1" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS AND PY_DATEREMISE1=@PY_DATEREMISE1 AND PY_DATEREMISE2=@PY_DATEREMISE2";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_DATEREMISE1", "@PY_DATEREMISE2" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}
	}
}
