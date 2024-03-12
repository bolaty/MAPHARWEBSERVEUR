using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsOperateurdroitCompteTresorerieWSDAL: ITableDAL<clsOperateurdroitCompteTresorerie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEDROIT2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEDROIT2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEDROIT2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsOperateurdroitCompteTresorerie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsOperateurdroitCompteTresorerie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT LO_ACTIF  FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEDROIT2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new clsOperateurdroitCompteTresorerie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroitCompteTresorerie.LO_ACTIF = clsDonnee.vogDataReader["LO_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsOperateurdroitCompteTresorerie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOperateurdroitCompteTresorerie>clsOperateurdroitCompteTresorerie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsOperateurdroitCompteTresorerie.AG_CODEAGENCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR ;


            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION1", SqlDbType.VarChar, 50);
            vppParamNO_CODENATUREOPERATION.Value  = clsOperateurdroitCompteTresorerie.NO_CODENATUREOPERATION;

            SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET1", SqlDbType.VarChar, 50);
            vppParamOB_CODEOBJET.Value  = clsOperateurdroitCompteTresorerie.OB_CODEOBJET;


			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE1", SqlDbType.VarChar, 50);
			vppParamPL_CODENUMCOMPTE.Value  = clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE ;
			SqlParameter vppParamLO_ACTIF = new SqlParameter("@LO_ACTIF", SqlDbType.VarChar, 1);
			vppParamLO_ACTIF.Value  = clsOperateurdroitCompteTresorerie.LO_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_OPERATEURDROITCOMPTETRESOREIEWEB  @AG_CODEAGENCE1, @OP_CODEOPERATEUR1, @NO_CODENATUREOPERATION1, @OB_CODEOBJET1, @PL_CODENUMCOMPTE1, @LO_ACTIF, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamLO_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOperateurdroitCompteTresorerie>clsOperateurdroitCompteTresorerie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsOperateurdroitCompteTresorerie.AG_CODEAGENCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR ;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 50);
            vppParamNO_CODENATUREOPERATION.Value  = clsOperateurdroitCompteTresorerie.NO_CODENATUREOPERATION;

            SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.VarChar, 50);
            vppParamOB_CODEOBJET.Value  = clsOperateurdroitCompteTresorerie.OB_CODEOBJET;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 50);
			vppParamPL_CODENUMCOMPTE.Value  = clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE ;
			SqlParameter vppParamLO_ACTIF = new SqlParameter("@LO_ACTIF", SqlDbType.VarChar, 1);
			vppParamLO_ACTIF.Value  = clsOperateurdroitCompteTresorerie.LO_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_OPERATEURDROITCOMPTETRESOREIEWEB2  @AG_CODEAGENCE, @OP_CODEOPERATEUR, @NO_CODENATUREOPERATION,@OB_CODEOBJET, @PL_CODENUMCOMPTE, @LO_ACTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamLO_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_OPERATEURDROITCOMPTETRESOREIEWEB  @AG_CODEAGENCE, @OP_CODEOPERATEUR, @NO_CODENATUREOPERATION, @OB_CODEOBJET,'', '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete1(clsDonnee clsDonnee,params string[] vppCritere)
        {
	        pvpChoixCritere(clsDonnee ,vppCritere);
	        //Préparation de la commande
            this.vapRequete = "EXECUTE PC_OPERATEURDROITCOMPTETRESOREIEWEB  @AG_CODEAGENCE, @OP_CODEOPERATEUR,@NO_CODENATUREOPERATION,@PL_CODENUMCOMPTE,@OB_CODEOBJET, '' , @CODECRYPTAGE, 3 ";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

	        //Ouverture de la connection et exécution de la commande
	        clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }
		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitCompteTresorerie </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitCompteTresorerie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE, LO_ACTIF FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEDROIT2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<clsOperateurdroitCompteTresorerie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new clsOperateurdroitCompteTresorerie();
					clsOperateurdroitCompteTresorerie.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsOperateurdroitCompteTresorerie.LO_ACTIF = clsDonnee.vogDataReader["LO_ACTIF"].ToString();
					clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsOperateurdroitCompteTresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitCompteTresorerie </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitCompteTresorerie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<clsOperateurdroitCompteTresorerie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE, LO_ACTIF FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEDROIT2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new clsOperateurdroitCompteTresorerie();
					clsOperateurdroitCompteTresorerie.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsOperateurdroitCompteTresorerie.LO_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["LO_ACTIF"].ToString();
					clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
				}
				Dataset.Dispose();
			}
		return clsOperateurdroitCompteTresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEDROIT2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , LO_ACTIF FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEDROIT2(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurDroit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);

            vapNomParametre = new string[] {  "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" , "@NO_CODENATUREOPERATION", "@OB_CODEOBJET" };
            vapValeurParametre = new object[] {  vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] };
            this.vapRequete = "SELECT * FROM dbo.FT_OPERATEURDROITCOMPTETRESOREIEWEBDROIT(@AG_CODEAGENCE,@OP_CODEOPERATEUR,@NO_CODENATUREOPERATION,@OB_CODEOBJET)  ORDER BY PL_NUMCOMPTE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurDroitListe(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);

            //vapNomParametre = new string[] {  "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
            //vapValeurParametre = new object[] {  vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT DISTINCT * FROM dbo.VUE_OPERATEURDROITCOMPTETRESOREIE " + this.vapCritere + " ORDER BY PL_NUMCOMPTE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@NO_CODENATUREOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND OB_CODEOBJET=@OB_CODEOBJET";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@NO_CODENATUREOPERATION", "@OB_CODEOBJET" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND OB_CODEOBJET=@OB_CODEOBJET AND PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@NO_CODENATUREOPERATION", "@OB_CODEOBJET", "@PL_CODENUMCOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
            }
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, OP_CODEOPERATEUR, PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@PL_NUMCOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;

                case 6:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE  AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
                    break;

                case 7:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE  AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%' AND OB_NOMOBJET=@OB_NOMOBJET ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE", "@OB_NOMOBJET" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                    break;
                case 8:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE  AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%' AND OB_NOMOBJET=@OB_NOMOBJET AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE", "@OB_NOMOBJET", "@NO_CODENATUREOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] };
                    break;




            }
        }


    }
}
