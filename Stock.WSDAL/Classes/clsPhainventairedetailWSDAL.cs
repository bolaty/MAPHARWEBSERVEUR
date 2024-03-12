using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhainventairedetailWSDAL: ITableDAL<clsPhainventairedetail>
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
			this.vapRequete = "SELECT COUNT(INV_CODEINVENTAIRE) AS INV_CODEINVENTAIRE  FROM dbo.PHAINVENTAIREDETAIL " + this.vapCritere;
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
			this.vapRequete = "SELECT MIN(INV_CODEINVENTAIRE) AS INV_CODEINVENTAIRE  FROM dbo.PHAINVENTAIREDETAIL" + this.vapCritere;
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
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(INV_CODEINVENTAIRE) AS INV_CODEINVENTAIRE  FROM dbo.PHAINVENTAIREDETAIL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhainventairedetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhainventairedetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , AR_CODEARTICLE  , INV_QTEPHYSIQUE  , INV_QTELOGIQUE  FROM dbo.FT_PHAINVENTAIREDETAIL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhainventairedetail clsPhainventairedetail = new clsPhainventairedetail();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhainventairedetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhainventairedetail.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhainventairedetail.INV_QTEPHYSIQUE = double.Parse(clsDonnee.vogDataReader["INV_QTEPHYSIQUE"].ToString());
					clsPhainventairedetail.INV_QTELOGIQUE = double.Parse(clsDonnee.vogDataReader["INV_QTELOGIQUE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhainventairedetail;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhainventairedetail>clsPhainventairedetail</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhainventairedetail clsPhainventairedetail)
		{
			//Préparation des paramètres
			SqlParameter vppParamINV_CODEINVENTAIRE = new SqlParameter("@INV_CODEINVENTAIRE", SqlDbType.VarChar, 25);
			vppParamINV_CODEINVENTAIRE.Value  = clsPhainventairedetail.INV_CODEINVENTAIRE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhainventairedetail.AG_CODEAGENCE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhainventairedetail.AR_CODEARTICLE ;

            SqlParameter vppParamMD_NUMSEQUENCE = new SqlParameter("@MD_NUMSEQUENCE", SqlDbType.VarChar, 50);
            vppParamMD_NUMSEQUENCE.Value = clsPhainventairedetail.MD_NUMSEQUENCE;

			SqlParameter vppParamINV_QTEPHYSIQUE = new SqlParameter("@INV_QTEPHYSIQUE", SqlDbType.Money);
			vppParamINV_QTEPHYSIQUE.Value  = clsPhainventairedetail.INV_QTEPHYSIQUE ;
			SqlParameter vppParamINV_QTELOGIQUE = new SqlParameter("@INV_QTELOGIQUE", SqlDbType.Money);
			vppParamINV_QTELOGIQUE.Value  = clsPhainventairedetail.INV_QTELOGIQUE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE2", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAINVENTAIREDETAIL  @INV_CODEINVENTAIRE, @AG_CODEAGENCE, @AR_CODEARTICLE,@MD_NUMSEQUENCE, @INV_QTEPHYSIQUE, @INV_QTELOGIQUE, @CODECRYPTAGE2, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamINV_QTEPHYSIQUE);
			vppSqlCmd.Parameters.Add(vppParamINV_QTELOGIQUE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhainventairedetail>clsPhainventairedetail</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhainventairedetail clsPhainventairedetail,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamINV_CODEINVENTAIRE = new SqlParameter("@INV_CODEINVENTAIRE", SqlDbType.VarChar, 25);
			vppParamINV_CODEINVENTAIRE.Value  = clsPhainventairedetail.INV_CODEINVENTAIRE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhainventairedetail.AG_CODEAGENCE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhainventairedetail.AR_CODEARTICLE ;
            SqlParameter vppParamMD_NUMSEQUENCE = new SqlParameter("@MD_NUMSEQUENCE", SqlDbType.VarChar, 50);
            vppParamMD_NUMSEQUENCE.Value = clsPhainventairedetail.MD_NUMSEQUENCE;

			SqlParameter vppParamINV_QTEPHYSIQUE = new SqlParameter("@INV_QTEPHYSIQUE", SqlDbType.Money);
			vppParamINV_QTEPHYSIQUE.Value  = clsPhainventairedetail.INV_QTEPHYSIQUE ;
			SqlParameter vppParamINV_QTELOGIQUE = new SqlParameter("@INV_QTELOGIQUE", SqlDbType.Money);
			vppParamINV_QTELOGIQUE.Value  = clsPhainventairedetail.INV_QTELOGIQUE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAINVENTAIREDETAIL  @INV_CODEINVENTAIRE, @AG_CODEAGENCE, @AR_CODEARTICLE, @MD_NUMSEQUENCE, @INV_QTEPHYSIQUE, @INV_QTELOGIQUE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamINV_CODEINVENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamINV_QTEPHYSIQUE);
			vppSqlCmd.Parameters.Add(vppParamINV_QTELOGIQUE);
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
			 this.vapRequete = "EXECUTE PC_PHAINVENTAIREDETAIL  @INV_CODEINVENTAIRE, '' , '' , '' ,'' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhainventairedetail </returns>
		///<author>Home Technology</author>
		public List<clsPhainventairedetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  INV_CODEINVENTAIRE, AG_CODEAGENCE, AR_CODEARTICLE, INV_QTEPHYSIQUE, INV_QTELOGIQUE FROM dbo.FT_PHAINVENTAIREDETAIL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhainventairedetail> clsPhainventairedetails = new List<clsPhainventairedetail>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhainventairedetail clsPhainventairedetail = new clsPhainventairedetail();
					clsPhainventairedetail.INV_CODEINVENTAIRE = clsDonnee.vogDataReader["INV_CODEINVENTAIRE"].ToString();
					clsPhainventairedetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhainventairedetail.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhainventairedetail.INV_QTEPHYSIQUE = double.Parse(clsDonnee.vogDataReader["INV_QTEPHYSIQUE"].ToString());
					clsPhainventairedetail.INV_QTELOGIQUE = double.Parse(clsDonnee.vogDataReader["INV_QTELOGIQUE"].ToString());
					clsPhainventairedetails.Add(clsPhainventairedetail);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhainventairedetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhainventairedetail </returns>
		///<author>Home Technology</author>
		public List<clsPhainventairedetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhainventairedetail> clsPhainventairedetails = new List<clsPhainventairedetail>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  INV_CODEINVENTAIRE, AG_CODEAGENCE, AR_CODEARTICLE, INV_QTEPHYSIQUE, INV_QTELOGIQUE FROM dbo.FT_PHAINVENTAIREDETAIL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhainventairedetail clsPhainventairedetail = new clsPhainventairedetail();
					clsPhainventairedetail.INV_CODEINVENTAIRE = Dataset.Tables["TABLE"].Rows[Idx]["INV_CODEINVENTAIRE"].ToString();
					clsPhainventairedetail.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhainventairedetail.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhainventairedetail.INV_QTEPHYSIQUE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["INV_QTEPHYSIQUE"].ToString());
					clsPhainventairedetail.INV_QTELOGIQUE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["INV_QTELOGIQUE"].ToString());
					clsPhainventairedetails.Add(clsPhainventairedetail);
				}
				Dataset.Dispose();
			}
		return clsPhainventairedetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAINVENTAIREDETAIL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetInventaire(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);


            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TA_CODETYPEARTICLE", "@MF_IDFILTRAGEDESTOCK", "@ME_IDFILTRAGEDESTOCKEXPIRATION", "@MF_IDFILTRAGEDESTOCKM1", "@MF_IDFILTRAGEDESTOCKM2", "@DATEINVENTAIRE", "@JF_CODETYPEJOURFACTURATION", "@LF_CODELIEUFACTURATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_INVENTAIRE @AG_CODEAGENCE,@EN_CODEENTREPOT,@TA_CODETYPEARTICLE,@MF_IDFILTRAGEDESTOCK,@ME_IDFILTRAGEDESTOCKEXPIRATION,@MF_IDFILTRAGEDESTOCKM1,@MF_IDFILTRAGEDESTOCKM2,@DATEINVENTAIRE,@JF_CODETYPEJOURFACTURATION,@LF_CODELIEUFACTURATION,@CODECRYPTAGE ";
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
            this.vapRequete = "SELECT INV_CODEINVENTAIRE , AG_CODEAGENCE FROM dbo.FT_PHAINVENTAIREDETAIL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboInventaireAAnnuler(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@ET_TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };

            this.vapRequete = " EXEC PS_COMBOINVENTAIREAANNULER  @ET_TYPEETAT,@CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetInventaireAAnnuler(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" , "@EN_CODEENTREPOT", "@INV_CODEINVENTAIRE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };

            this.vapRequete = " EXEC PS_PHAINVENTAIREANNULATION  @AG_CODEAGENCE,@EN_CODEENTREPOT,@INV_CODEINVENTAIRE,@CODECRYPTAGE ";
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND INV_CODEINVENTAIRE=@INV_CODEINVENTAIRE ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@INV_CODEINVENTAIRE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
