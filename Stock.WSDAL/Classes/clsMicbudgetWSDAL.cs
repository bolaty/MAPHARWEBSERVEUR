using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsMicbudgetWSDAL: ITableDAL<clsMicbudget>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT COUNT(BU_CODEBUDGET) AS BU_CODEBUDGET  FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT MIN(BU_CODEBUDGET) AS BU_CODEBUDGET  FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT MAX(BU_CODEBUDGET) AS BU_CODEBUDGET  FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMicbudget comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMicbudget pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , BU_LIBELLE  , BU_DATEDEBUT  , BU_DATEFIN,BU_DATESAISIE,OP_CODEOPERATEUR  FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsMicbudget clsMicbudget = new clsMicbudget();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicbudget.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsMicbudget.BU_LIBELLE = clsDonnee.vogDataReader["BU_LIBELLE"].ToString();
					clsMicbudget.BU_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["BU_DATEDEBUT"].ToString());
					clsMicbudget.BU_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["BU_DATEFIN"].ToString());
                    clsMicbudget.BU_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["BU_DATESAISIE"].ToString());
                    clsMicbudget.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsMicbudget;
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudget>clsMicbudget</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsMicbudget clsMicbudget)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMicbudget.AG_CODEAGENCE;
            SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGET.Value = clsMicbudget.BU_CODEBUDGET;
            SqlParameter vppParamBU_LIBELLE = new SqlParameter("@BU_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBU_LIBELLE.Value = clsMicbudget.BU_LIBELLE;
            SqlParameter vppParamBU_DATEDEBUT = new SqlParameter("@BU_DATEDEBUT", SqlDbType.DateTime);
            vppParamBU_DATEDEBUT.Value = clsMicbudget.BU_DATEDEBUT;
            SqlParameter vppParamBU_DATEFIN = new SqlParameter("@BU_DATEFIN", SqlDbType.DateTime);
            vppParamBU_DATEFIN.Value = clsMicbudget.BU_DATEFIN;
            SqlParameter vppParamBU_DATESAISIE = new SqlParameter("@BU_DATESAISIE", SqlDbType.DateTime);
            vppParamBU_DATESAISIE.Value = clsMicbudget.BU_DATESAISIE;

            SqlParameter vppParamBU_CODEBUDGETLIAISON = new SqlParameter("@BU_CODEBUDGETLIAISON", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGETLIAISON.Value = clsMicbudget.BU_CODEBUDGETLIAISON;
            if (clsMicbudget.BU_CODEBUDGETLIAISON == "") vppParamBU_CODEBUDGETLIAISON.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsMicbudget.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGET  @AG_CODEAGENCE, @BU_CODEBUDGET, @BU_LIBELLE, @BU_DATEDEBUT, @BU_DATEFIN, @BU_DATESAISIE, @BU_CODEBUDGETLIAISON, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBU_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamBU_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBU_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamBU_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGETLIAISON);

            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudget>clsMicbudget</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsMicbudget clsMicbudget, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMicbudget.AG_CODEAGENCE;
            SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGET.Value = clsMicbudget.BU_CODEBUDGET;
            SqlParameter vppParamBU_LIBELLE = new SqlParameter("@BU_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBU_LIBELLE.Value = clsMicbudget.BU_LIBELLE;
            SqlParameter vppParamBU_DATEDEBUT = new SqlParameter("@BU_DATEDEBUT", SqlDbType.DateTime);
            vppParamBU_DATEDEBUT.Value = clsMicbudget.BU_DATEDEBUT;
            SqlParameter vppParamBU_DATEFIN = new SqlParameter("@BU_DATEFIN", SqlDbType.DateTime);
            vppParamBU_DATEFIN.Value = clsMicbudget.BU_DATEFIN;
            SqlParameter vppParamBU_DATESAISIE = new SqlParameter("@BU_DATESAISIE", SqlDbType.DateTime);
            vppParamBU_DATESAISIE.Value = clsMicbudget.BU_DATESAISIE;

            SqlParameter vppParamBU_CODEBUDGETLIAISON = new SqlParameter("@BU_CODEBUDGETLIAISON", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGETLIAISON.Value = clsMicbudget.BU_CODEBUDGETLIAISON;
            if (clsMicbudget.BU_CODEBUDGETLIAISON == "") vppParamBU_CODEBUDGETLIAISON.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsMicbudget.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGET  @AG_CODEAGENCE, @BU_CODEBUDGET, @BU_LIBELLE, @BU_DATEDEBUT, @BU_DATEFIN, @BU_DATESAISIE,@BU_CODEBUDGETLIAISON, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBU_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamBU_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBU_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamBU_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGETLIAISON);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudget>clsMicbudget</param>
        ///<author>Home Technology</author>
        public void pvgInsertComplement(clsDonnee clsDonnee, clsMicbudget clsMicbudget)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMicbudget.AG_CODEAGENCE;
            SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGET.Value = clsMicbudget.BU_CODEBUDGET;
            SqlParameter vppParamBU_LIBELLE = new SqlParameter("@BU_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBU_LIBELLE.Value = clsMicbudget.BU_LIBELLE;
            SqlParameter vppParamBU_DATEDEBUT = new SqlParameter("@BU_DATEDEBUT", SqlDbType.DateTime);
            vppParamBU_DATEDEBUT.Value = clsMicbudget.BU_DATEDEBUT;
            SqlParameter vppParamBU_DATEFIN = new SqlParameter("@BU_DATEFIN", SqlDbType.DateTime);
            vppParamBU_DATEFIN.Value = clsMicbudget.BU_DATEFIN;
            SqlParameter vppParamBU_DATESAISIE = new SqlParameter("@BU_DATESAISIE", SqlDbType.DateTime);
            vppParamBU_DATESAISIE.Value = clsMicbudget.BU_DATESAISIE;

            SqlParameter vppParamBU_CODEBUDGETLIAISON = new SqlParameter("@BU_CODEBUDGETLIAISON", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGETLIAISON.Value = clsMicbudget.BU_CODEBUDGETLIAISON;
            if (clsMicbudget.BU_CODEBUDGETLIAISON == "") vppParamBU_CODEBUDGETLIAISON.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsMicbudget.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGET  @AG_CODEAGENCE, @BU_CODEBUDGET, @BU_LIBELLE, @BU_DATEDEBUT, @BU_DATEFIN, @BU_DATESAISIE, @BU_CODEBUDGETLIAISON, @OP_CODEOPERATEUR, @CODECRYPTAGE, 3 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBU_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamBU_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBU_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamBU_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGETLIAISON);

            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMicbudget>clsMicbudget</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdateComplement(clsDonnee clsDonnee, clsMicbudget clsMicbudget, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMicbudget.AG_CODEAGENCE;
            SqlParameter vppParamBU_CODEBUDGET = new SqlParameter("@BU_CODEBUDGET", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGET.Value = clsMicbudget.BU_CODEBUDGET;
            SqlParameter vppParamBU_LIBELLE = new SqlParameter("@BU_LIBELLE", SqlDbType.VarChar, 150);
            vppParamBU_LIBELLE.Value = clsMicbudget.BU_LIBELLE;
            SqlParameter vppParamBU_DATEDEBUT = new SqlParameter("@BU_DATEDEBUT", SqlDbType.DateTime);
            vppParamBU_DATEDEBUT.Value = clsMicbudget.BU_DATEDEBUT;
            SqlParameter vppParamBU_DATEFIN = new SqlParameter("@BU_DATEFIN", SqlDbType.DateTime);
            vppParamBU_DATEFIN.Value = clsMicbudget.BU_DATEFIN;
            SqlParameter vppParamBU_DATESAISIE = new SqlParameter("@BU_DATESAISIE", SqlDbType.DateTime);
            vppParamBU_DATESAISIE.Value = clsMicbudget.BU_DATESAISIE;

            SqlParameter vppParamBU_CODEBUDGETLIAISON = new SqlParameter("@BU_CODEBUDGETLIAISON", SqlDbType.VarChar, 25);
            vppParamBU_CODEBUDGETLIAISON.Value = clsMicbudget.BU_CODEBUDGETLIAISON;
            if (clsMicbudget.BU_CODEBUDGETLIAISON == "") vppParamBU_CODEBUDGETLIAISON.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsMicbudget.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGET  @AG_CODEAGENCE, @BU_CODEBUDGET, @BU_LIBELLE, @BU_DATEDEBUT, @BU_DATEFIN, @BU_DATESAISIE,@BU_CODEBUDGETLIAISON, @OP_CODEOPERATEUR, @CODECRYPTAGE,4 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGET);
            vppSqlCmd.Parameters.Add(vppParamBU_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamBU_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBU_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamBU_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamBU_CODEBUDGETLIAISON);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, BU_CODEBUDGET, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICBUDGET  @AG_CODEAGENCE, @BU_CODEBUDGET, '' , '' , '' , '' , '', '','', 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicbudget </returns>
		///<author>Home Technology</author>
		public List<clsMicbudget> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BU_CODEBUDGET, AG_CODEAGENCE, BU_LIBELLE, BU_DATEDEBUT, BU_DATEFIN,BU_DATESAISIE,OP_CODEOPERATEUR FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsMicbudget> clsMicbudgets = new List<clsMicbudget>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicbudget clsMicbudget = new clsMicbudget();
					clsMicbudget.BU_CODEBUDGET = clsDonnee.vogDataReader["BU_CODEBUDGET"].ToString();
					clsMicbudget.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsMicbudget.BU_LIBELLE = clsDonnee.vogDataReader["BU_LIBELLE"].ToString();
					clsMicbudget.BU_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["BU_DATEDEBUT"].ToString());
					clsMicbudget.BU_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["BU_DATEFIN"].ToString());
	                clsMicbudget.BU_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["BU_DATESAISIE"].ToString());
					clsMicbudget.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsMicbudgets.Add(clsMicbudget);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsMicbudgets;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicbudget </returns>
		///<author>Home Technology</author>
		public List<clsMicbudget> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsMicbudget> clsMicbudgets = new List<clsMicbudget>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  BU_CODEBUDGET, AG_CODEAGENCE, BU_LIBELLE, BU_DATEDEBUT, BU_DATEFIN,BU_DATESAISIE,OP_CODEOPERATEUR,BU_DATESAISIE,OP_CODEOPERATEUR FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsMicbudget clsMicbudget = new clsMicbudget();
					clsMicbudget.BU_CODEBUDGET = Dataset.Tables["TABLE"].Rows[Idx]["BU_CODEBUDGET"].ToString();
					clsMicbudget.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsMicbudget.BU_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["BU_LIBELLE"].ToString();
					clsMicbudget.BU_DATEDEBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BU_DATEDEBUT"].ToString());
					clsMicbudget.BU_DATEFIN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BU_DATEFIN"].ToString());
                    clsMicbudget.BU_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BU_DATESAISIE"].ToString());
					clsMicbudget.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsMicbudgets.Add(clsMicbudget);
				}
				Dataset.Dispose();
			}
		return clsMicbudgets;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + " AND BU_CODEBUDGETLIAISON IS NULL";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BU_CODEBUDGET ,CAST(DECRYPTBYPASSPHRASE(@CODECRYPTAGE,BU_LIBELLE) AS varchar(150)) AS  BU_LIBELLE FROM dbo.MICBUDGET " + this.vapCritere + " AND BU_CODEBUDGETLIAISON IS NULL";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BU_CODEBUDGET ,CAST(DECRYPTBYPASSPHRASE(@CODECRYPTAGE,BU_LIBELLE) AS varchar(150)) AS  BU_LIBELLE FROM dbo.MICBUDGET " + this.vapCritere ;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetComplement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + " AND BU_CODEBUDGETLIAISON IS NOT NULL";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BU_CODEBUDGET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboComplement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT BU_CODEBUDGET , BU_LIBELLE FROM dbo.FT_MICBUDGET(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + " AND BU_CODEBUDGETLIAISON IS NOT NULL";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, BU_CODEBUDGET, OP_CODEOPERATEUR)</summary>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND BU_CODEBUDGET=@BU_CODEBUDGET";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@BU_CODEBUDGET" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }
	}
}
