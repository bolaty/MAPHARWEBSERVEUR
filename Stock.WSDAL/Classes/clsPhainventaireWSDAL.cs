using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhainventaireWSDAL: ITableDAL<clsPhainventaire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(INV_CODEINVENTAIRE) AS INV_CODEINVENTAIRE  FROM dbo.PHAINVENTAIRE" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(INV_CODEINVENTAIRE) AS INV_CODEINVENTAIRE  FROM dbo.PHAINVENTAIRE" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            ////pvpChoixCritere(clsDonnee, vppCritere);
            //case 1 :
            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE3";
                vapNomParametre = new string[] { "@AG_CODEAGENCE3" };
				vapValeurParametre = new object[]{vppCritere[0]};
                //break;
            this.vapRequete = "SELECT MAX(INV_CODEINVENTAIRE) AS INV_CODEINVENTAIRE  FROM dbo.PHAINVENTAIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhainventaire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhainventaire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , INV_DATEINVENTAIRE  , OP_CODEOPERATEUR  FROM dbo.FT_PHAINVENTAIRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhainventaire clsPhainventaire = new clsPhainventaire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhainventaire.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhainventaire.INV_DATEINVENTAIRE = DateTime.Parse(clsDonnee.vogDataReader["INV_DATEINVENTAIRE"].ToString());
					clsPhainventaire.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhainventaire;
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhainventaire>clsPhainventaire</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsPhainventaire clsPhainventaire)
        {
            //Préparation des paramètres
            SqlParameter vppParamINV_CODEINVENTAIRE = new SqlParameter("@INV_CODEINVENTAIRE", SqlDbType.VarChar, 25);
            vppParamINV_CODEINVENTAIRE.Value = clsPhainventaire.INV_CODEINVENTAIRE;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhainventaire.AG_CODEAGENCE;
            SqlParameter vppParamINV_DATEINVENTAIRE = new SqlParameter("@INV_DATEINVENTAIRE", SqlDbType.DateTime);
            vppParamINV_DATEINVENTAIRE.Value = clsPhainventaire.INV_DATEINVENTAIRE;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
            vppParamOP_CODEOPERATEUR.Value = clsPhainventaire.OP_CODEOPERATEUR;
            SqlParameter vppParamINVR_CODERAISONINVENTAIRE = new SqlParameter("@INVR_CODERAISONINVENTAIRE", SqlDbType.VarChar, 25);
            vppParamINVR_CODERAISONINVENTAIRE.Value = clsPhainventaire.INVR_CODERAISONINVENTAIRE;

            SqlParameter vppParamINV_DATEINVENTAIRECLOTURE = new SqlParameter("@INV_DATEINVENTAIRECLOTURE", SqlDbType.DateTime);
            vppParamINV_DATEINVENTAIRECLOTURE.Value = clsPhainventaire.INV_DATEINVENTAIRECLOTURE;
            if (clsPhainventaire.INV_DATEINVENTAIRECLOTURE.ToShortDateString() == "01/01/0001") vppParamINV_DATEINVENTAIRECLOTURE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //SqlParameter vppParamINV_CODEINVENTAIRERETOURS = new SqlParameter("@MS_NUMPIECERETOUR", SqlDbType.VarChar, 50);

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAINVENTAIRE  @INV_CODEINVENTAIRE, @AG_CODEAGENCE, @INV_DATEINVENTAIRE, @OP_CODEOPERATEUR,@INVR_CODERAISONINVENTAIRE,@INV_DATEINVENTAIRECLOTURE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);


            //SqlCommand vppSqlCmd = new SqlCommand("PC_PHAINVENTAIRE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIRE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamINV_DATEINVENTAIRE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamINVR_CODERAISONINVENTAIRE);
            vppSqlCmd.Parameters.Add(vppParamINV_DATEINVENTAIRECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIRERETOURS);
            //vppParamINV_CODEINVENTAIRERETOURS.Direction = ParameterDirection.Output;
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            //// valeurs de retour de la procedure stockée
            //return vppSqlCmd.Parameters["@INV_CODEINVENTAIRERETOURS"].Value.ToString();
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhainventaire>clsPhainventaire</param>
		///<author>Home Technology</author>
        public string pvgInsert1(clsDonnee clsDonnee, clsPhainventaire clsPhainventaire)
		{
			//Préparation des paramètres
            SqlParameter vppParamINV_CODEINVENTAIRE = new SqlParameter("@INV_CODEINVENTAIRE", SqlDbType.VarChar, 25);
			vppParamINV_CODEINVENTAIRE.Value  = clsPhainventaire.INV_CODEINVENTAIRE ;

			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhainventaire.AG_CODEAGENCE ;
			SqlParameter vppParamINV_DATEINVENTAIRE = new SqlParameter("@INV_DATEINVENTAIRE", SqlDbType.DateTime);
			vppParamINV_DATEINVENTAIRE.Value  = clsPhainventaire.INV_DATEINVENTAIRE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
			vppParamOP_CODEOPERATEUR.Value  = clsPhainventaire.OP_CODEOPERATEUR ;

            SqlParameter vppParamINVR_CODERAISONINVENTAIRE = new SqlParameter("@INVR_CODERAISONINVENTAIRE", SqlDbType.VarChar, 25);
            vppParamINVR_CODERAISONINVENTAIRE.Value = clsPhainventaire.INVR_CODERAISONINVENTAIRE;

            SqlParameter vppParamINV_DATEINVENTAIRECLOTURE = new SqlParameter("@INV_DATEINVENTAIRECLOTURE", SqlDbType.DateTime);
            vppParamINV_DATEINVENTAIRECLOTURE.Value = clsPhainventaire.INV_DATEINVENTAIRECLOTURE;
            if (clsPhainventaire.INV_DATEINVENTAIRECLOTURE.ToShortDateString() == "01/01/0001") vppParamINV_DATEINVENTAIRECLOTURE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamINV_CODEINVENTAIREACLOTURER = new SqlParameter("@INV_CODEINVENTAIREACLOTURER", SqlDbType.VarChar, 25);
            vppParamINV_CODEINVENTAIREACLOTURER.Value  = clsPhainventaire.INV_CODEINVENTAIREACLOTURER;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = "0";

            SqlParameter vppParamINV_CODEINVENTAIRERETOURS = new SqlParameter("@INV_CODEINVENTAIRERETOURS", SqlDbType.VarChar, 50);

			//Préparation de la commande
            // this.vapRequete = "EXECUTE PC_PHAINVENTAIRE  @INV_CODEINVENTAIRE, @AG_CODEAGENCE, @INV_DATEINVENTAIRE, @OP_CODEOPERATEUR, @CODECRYPTAGE1, 0 ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);


            SqlCommand vppSqlCmd = new SqlCommand("PC_PHAINVENTAIRE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamINV_DATEINVENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);

            vppSqlCmd.Parameters.Add(vppParamINVR_CODERAISONINVENTAIRE);
            vppSqlCmd.Parameters.Add(vppParamINV_DATEINVENTAIRECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIREACLOTURER);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIRERETOURS);
            vppParamINV_CODEINVENTAIRERETOURS.Direction = ParameterDirection.Output;
            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@INV_CODEINVENTAIRERETOURS"].Value.ToString();
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhainventaire>clsPhainventaire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhainventaire clsPhainventaire,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamINV_CODEINVENTAIRE = new SqlParameter("@INV_CODEINVENTAIRE", SqlDbType.Money);
			vppParamINV_CODEINVENTAIRE.Value  = clsPhainventaire.INV_CODEINVENTAIRE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhainventaire.AG_CODEAGENCE ;
			SqlParameter vppParamINV_DATEINVENTAIRE = new SqlParameter("@INV_DATEINVENTAIRE", SqlDbType.DateTime);
			vppParamINV_DATEINVENTAIRE.Value  = clsPhainventaire.INV_DATEINVENTAIRE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
			vppParamOP_CODEOPERATEUR.Value  = clsPhainventaire.OP_CODEOPERATEUR ;


            SqlParameter vppParamINVR_CODERAISONINVENTAIRE = new SqlParameter("@INVR_CODERAISONINVENTAIRE", SqlDbType.VarChar, 25);
            vppParamINVR_CODERAISONINVENTAIRE.Value = clsPhainventaire.INVR_CODERAISONINVENTAIRE;

            SqlParameter vppParamINV_DATEINVENTAIRECLOTURE = new SqlParameter("@INV_DATEINVENTAIRECLOTURE", SqlDbType.DateTime);
            vppParamINV_DATEINVENTAIRECLOTURE.Value = clsPhainventaire.INV_DATEINVENTAIRECLOTURE;
            if (clsPhainventaire.INV_DATEINVENTAIRECLOTURE.ToShortDateString() == "01/01/0001") vppParamINV_DATEINVENTAIRECLOTURE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamINV_CODEINVENTAIREACLOTURER = new SqlParameter("@INV_CODEINVENTAIREACLOTURER", SqlDbType.VarChar, 25);
            vppParamINV_CODEINVENTAIREACLOTURER.Value = clsPhainventaire.INV_CODEINVENTAIREACLOTURER;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAINVENTAIRE  @INV_CODEINVENTAIRE, @AG_CODEAGENCE, @INV_DATEINVENTAIRE, @OP_CODEOPERATEUR,@INVR_CODERAISONINVENTAIRE,@INV_DATEINVENTAIRECLOTURE,@INV_CODEINVENTAIREACLOTURER, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamINV_DATEINVENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIREACLOTURER);
            vppSqlCmd.Parameters.Add(vppParamINVR_CODERAISONINVENTAIRE);
            vppSqlCmd.Parameters.Add(vppParamINV_DATEINVENTAIRECLOTURE);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAINVENTAIRE  @INV_CODEINVENTAIRE, @AG_CODEAGENCE,'' , '' ,'' ,'' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhainventaire </returns>
		///<author>Home Technology</author>
		public List<clsPhainventaire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  INV_CODEINVENTAIRE, AG_CODEAGENCE, INV_DATEINVENTAIRE, OP_CODEOPERATEUR FROM dbo.FT_PHAINVENTAIRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhainventaire> clsPhainventaires = new List<clsPhainventaire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhainventaire clsPhainventaire = new clsPhainventaire();
					clsPhainventaire.INV_CODEINVENTAIRE =int.Parse(clsDonnee.vogDataReader["INV_CODEINVENTAIRE"].ToString());
					clsPhainventaire.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhainventaire.INV_DATEINVENTAIRE = DateTime.Parse(clsDonnee.vogDataReader["INV_DATEINVENTAIRE"].ToString());
					clsPhainventaire.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhainventaires.Add(clsPhainventaire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhainventaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhainventaire </returns>
		///<author>Home Technology</author>
		public List<clsPhainventaire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhainventaire> clsPhainventaires = new List<clsPhainventaire>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  INV_CODEINVENTAIRE, AG_CODEAGENCE, INV_DATEINVENTAIRE, OP_CODEOPERATEUR FROM dbo.FT_PHAINVENTAIRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhainventaire clsPhainventaire = new clsPhainventaire();
					clsPhainventaire.INV_CODEINVENTAIRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["INV_CODEINVENTAIRE"].ToString());
					clsPhainventaire.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhainventaire.INV_DATEINVENTAIRE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["INV_DATEINVENTAIRE"].ToString());
					clsPhainventaire.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhainventaires.Add(clsPhainventaire);
				}
				Dataset.Dispose();
			}
		return clsPhainventaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAINVENTAIRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT INV_CODEINVENTAIRE , AG_CODEAGENCE FROM dbo.FT_PHAINVENTAIRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :INV_CODEINVENTAIRE)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND INV_CODEINVENTAIRE=@INV_CODEINVENTAIRE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@INV_CODEINVENTAIRE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
