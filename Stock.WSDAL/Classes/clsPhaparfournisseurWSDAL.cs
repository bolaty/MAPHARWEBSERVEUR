using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparfournisseurWSDAL: ITableDAL<clsPhaparfournisseur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(FR_CODEFOURNISSEUR) AS FR_CODEFOURNISSEUR  FROM dbo.PHAPARFOURNISSEUR  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(FR_CODEFOURNISSEUR) AS FR_CODEFOURNISSEUR  FROM dbo.PHAPARFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(FR_CODEFOURNISSEUR) AS FR_CODEFOURNISSEUR  FROM dbo.PHAPARFOURNISSEUR  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparfournisseur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparfournisseur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT FR_MATRICULE,FR_DENOMINATION  , FR_SIEGE  , FR_ADRESSEPOSTALE  , FR_ADRESSEGEOGRAPHIQUE  , FR_TELEPHONE  , FR_SITEWEB  , FR_EMAIL  , FR_GERANT  , FR_STATUT  FROM dbo.FT_PHAPARFOURNISSEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparfournisseur clsPhaparfournisseur = new clsPhaparfournisseur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    clsPhaparfournisseur.FR_MATRICULE = clsDonnee.vogDataReader["FR_MATRICULE"].ToString();
					clsPhaparfournisseur.FR_DENOMINATION = clsDonnee.vogDataReader["FR_DENOMINATION"].ToString();
					clsPhaparfournisseur.FR_SIEGE = clsDonnee.vogDataReader["FR_SIEGE"].ToString();
					clsPhaparfournisseur.FR_ADRESSEPOSTALE = clsDonnee.vogDataReader["FR_ADRESSEPOSTALE"].ToString();
					clsPhaparfournisseur.FR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["FR_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparfournisseur.FR_TELEPHONE = clsDonnee.vogDataReader["FR_TELEPHONE"].ToString();
					clsPhaparfournisseur.FR_SITEWEB = clsDonnee.vogDataReader["FR_SITEWEB"].ToString();
					clsPhaparfournisseur.FR_EMAIL = clsDonnee.vogDataReader["FR_EMAIL"].ToString();
					clsPhaparfournisseur.FR_GERANT = clsDonnee.vogDataReader["FR_GERANT"].ToString();
					clsPhaparfournisseur.FR_STATUT = clsDonnee.vogDataReader["FR_STATUT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparfournisseur;
		}

        public void pvgInsert(clsDonnee clsDonnee, clsPhaparfournisseur clsPhaparfournisseur)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparfournisseur.AG_CODEAGENCE;
            SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 25);
            vppParamFR_CODEFOURNISSEUR.Value = clsPhaparfournisseur.FR_CODEFOURNISSEUR;
            SqlParameter vppParamFR_DENOMINATION = new SqlParameter("@FR_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamFR_DENOMINATION.Value = clsPhaparfournisseur.FR_DENOMINATION;
            SqlParameter vppParamFR_SIEGE = new SqlParameter("@FR_SIEGE", SqlDbType.VarChar, 150);
            vppParamFR_SIEGE.Value = clsPhaparfournisseur.FR_SIEGE;
            SqlParameter vppParamFR_ADRESSEPOSTALE = new SqlParameter("@FR_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamFR_ADRESSEPOSTALE.Value = clsPhaparfournisseur.FR_ADRESSEPOSTALE;
            SqlParameter vppParamFR_ADRESSEGEOGRAPHIQUE = new SqlParameter("@FR_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamFR_ADRESSEGEOGRAPHIQUE.Value = clsPhaparfournisseur.FR_ADRESSEGEOGRAPHIQUE;
            SqlParameter vppParamFR_TELEPHONE = new SqlParameter("@FR_TELEPHONE", SqlDbType.VarChar, 150);
            vppParamFR_TELEPHONE.Value = clsPhaparfournisseur.FR_TELEPHONE;
            SqlParameter vppParamFR_SITEWEB = new SqlParameter("@FR_SITEWEB", SqlDbType.VarChar, 150);
            vppParamFR_SITEWEB.Value = clsPhaparfournisseur.FR_SITEWEB;
            if (clsPhaparfournisseur.FR_SITEWEB == "") vppParamFR_SITEWEB.Value = DBNull.Value;
            SqlParameter vppParamFR_EMAIL = new SqlParameter("@FR_EMAIL", SqlDbType.VarChar, 80);
            vppParamFR_EMAIL.Value = clsPhaparfournisseur.FR_EMAIL;
            if (clsPhaparfournisseur.FR_EMAIL == "") vppParamFR_EMAIL.Value = DBNull.Value;
            SqlParameter vppParamFR_GERANT = new SqlParameter("@FR_GERANT", SqlDbType.VarChar, 150);
            vppParamFR_GERANT.Value = clsPhaparfournisseur.FR_GERANT;
            SqlParameter vppParamFR_STATUT = new SqlParameter("@FR_STATUT", SqlDbType.VarChar, 1);
            vppParamFR_STATUT.Value = clsPhaparfournisseur.FR_STATUT;
            SqlParameter vppParamFR_MATRICULE = new SqlParameter("@FR_MATRICULE", SqlDbType.VarChar, 150);
            vppParamFR_MATRICULE.Value = clsPhaparfournisseur.FR_MATRICULE;

            SqlParameter vppParamTF_CODETYPEFOURNISSEUR = new SqlParameter("@TF_CODETYPEFOURNISSEUR", SqlDbType.VarChar, 3);
            vppParamTF_CODETYPEFOURNISSEUR.Value = clsPhaparfournisseur.TF_CODETYPEFOURNISSEUR;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPhaparfournisseur.PL_NUMCOMPTE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARFOURNISSEUR  @AG_CODEAGENCE,@FR_CODEFOURNISSEUR, @FR_DENOMINATION, @FR_SIEGE, @FR_ADRESSEPOSTALE, @FR_ADRESSEGEOGRAPHIQUE, @FR_TELEPHONE, @FR_SITEWEB, @FR_EMAIL, @FR_GERANT, @FR_STATUT,  @FR_MATRICULE,@TF_CODETYPEFOURNISSEUR,@PL_NUMCOMPTE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamFR_CODEFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamFR_DENOMINATION);
            vppSqlCmd.Parameters.Add(vppParamFR_SIEGE);
            vppSqlCmd.Parameters.Add(vppParamFR_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamFR_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamFR_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamFR_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamFR_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamFR_GERANT);
            vppSqlCmd.Parameters.Add(vppParamFR_STATUT);
            vppSqlCmd.Parameters.Add(vppParamFR_MATRICULE);
            vppSqlCmd.Parameters.Add(vppParamTF_CODETYPEFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparfournisseur>clsPhaparfournisseur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparfournisseur clsPhaparfournisseur,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparfournisseur.AG_CODEAGENCE;
            SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 25);
            vppParamFR_CODEFOURNISSEUR.Value = clsPhaparfournisseur.FR_CODEFOURNISSEUR;
            SqlParameter vppParamFR_DENOMINATION = new SqlParameter("@FR_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamFR_DENOMINATION.Value = clsPhaparfournisseur.FR_DENOMINATION;
            SqlParameter vppParamFR_SIEGE = new SqlParameter("@FR_SIEGE", SqlDbType.VarChar, 150);
            vppParamFR_SIEGE.Value = clsPhaparfournisseur.FR_SIEGE;
            SqlParameter vppParamFR_ADRESSEPOSTALE = new SqlParameter("@FR_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamFR_ADRESSEPOSTALE.Value = clsPhaparfournisseur.FR_ADRESSEPOSTALE;
            SqlParameter vppParamFR_ADRESSEGEOGRAPHIQUE = new SqlParameter("@FR_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamFR_ADRESSEGEOGRAPHIQUE.Value = clsPhaparfournisseur.FR_ADRESSEGEOGRAPHIQUE;
            SqlParameter vppParamFR_TELEPHONE = new SqlParameter("@FR_TELEPHONE", SqlDbType.VarChar, 150);
            vppParamFR_TELEPHONE.Value = clsPhaparfournisseur.FR_TELEPHONE;
            SqlParameter vppParamFR_SITEWEB = new SqlParameter("@FR_SITEWEB", SqlDbType.VarChar, 150);
            vppParamFR_SITEWEB.Value = clsPhaparfournisseur.FR_SITEWEB;
            if (clsPhaparfournisseur.FR_SITEWEB == "") vppParamFR_SITEWEB.Value = DBNull.Value;
            SqlParameter vppParamFR_EMAIL = new SqlParameter("@FR_EMAIL", SqlDbType.VarChar, 80);
            vppParamFR_EMAIL.Value = clsPhaparfournisseur.FR_EMAIL;
            if (clsPhaparfournisseur.FR_EMAIL == "") vppParamFR_EMAIL.Value = DBNull.Value;
            SqlParameter vppParamFR_GERANT = new SqlParameter("@FR_GERANT", SqlDbType.VarChar, 150);
            vppParamFR_GERANT.Value = clsPhaparfournisseur.FR_GERANT;
            SqlParameter vppParamFR_STATUT = new SqlParameter("@FR_STATUT", SqlDbType.VarChar, 1);
            vppParamFR_STATUT.Value = clsPhaparfournisseur.FR_STATUT;
            SqlParameter vppParamFR_MATRICULE = new SqlParameter("@FR_MATRICULE", SqlDbType.VarChar, 150);
            vppParamFR_MATRICULE.Value = clsPhaparfournisseur.FR_MATRICULE;

            SqlParameter vppParamTF_CODETYPEFOURNISSEUR = new SqlParameter("@TF_CODETYPEFOURNISSEUR", SqlDbType.VarChar, 3);
            vppParamTF_CODETYPEFOURNISSEUR.Value = clsPhaparfournisseur.TF_CODETYPEFOURNISSEUR;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPhaparfournisseur.PL_NUMCOMPTE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARFOURNISSEUR  @AG_CODEAGENCE,@FR_CODEFOURNISSEUR, @FR_DENOMINATION, @FR_SIEGE, @FR_ADRESSEPOSTALE, @FR_ADRESSEGEOGRAPHIQUE, @FR_TELEPHONE, @FR_SITEWEB, @FR_EMAIL, @FR_GERANT, @FR_STATUT,  @FR_MATRICULE,@TF_CODETYPEFOURNISSEUR,@PL_NUMCOMPTE, @CODECRYPTAGE1, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamFR_CODEFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamFR_DENOMINATION);
            vppSqlCmd.Parameters.Add(vppParamFR_SIEGE);
            vppSqlCmd.Parameters.Add(vppParamFR_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamFR_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamFR_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamFR_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamFR_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamFR_GERANT);
            vppSqlCmd.Parameters.Add(vppParamFR_STATUT);
            vppSqlCmd.Parameters.Add(vppParamFR_MATRICULE);
            vppSqlCmd.Parameters.Add(vppParamTF_CODETYPEFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : FR_CODEFOURNISSEUR, FR_MATRICULE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARFOURNISSEUR  @AG_CODEAGENCE,@FR_CODEFOURNISSEUR, '' , '' , '' , '' , '' , '' , '' , '' , '' , '','','', @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparfournisseur </returns>
		///<author>Home Technology</author>
		public List<clsPhaparfournisseur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  FR_CODEFOURNISSEUR, FR_DENOMINATION, FR_SIEGE, FR_ADRESSEPOSTALE, FR_ADRESSEGEOGRAPHIQUE, FR_TELEPHONE, FR_SITEWEB, FR_EMAIL, FR_GERANT, FR_STATUT FROM dbo.PHAPARFOURNISSEUR " + this.vapCritere + " AND FR_STATUT = 'N' ";
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparfournisseur> clsPhaparfournisseurs = new List<clsPhaparfournisseur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparfournisseur clsPhaparfournisseur = new clsPhaparfournisseur();
					clsPhaparfournisseur.FR_CODEFOURNISSEUR = clsDonnee.vogDataReader["FR_CODEFOURNISSEUR"].ToString();
					clsPhaparfournisseur.FR_DENOMINATION = clsDonnee.vogDataReader["FR_DENOMINATION"].ToString();
					clsPhaparfournisseur.FR_SIEGE = clsDonnee.vogDataReader["FR_SIEGE"].ToString();
					clsPhaparfournisseur.FR_ADRESSEPOSTALE = clsDonnee.vogDataReader["FR_ADRESSEPOSTALE"].ToString();
					clsPhaparfournisseur.FR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["FR_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparfournisseur.FR_TELEPHONE = clsDonnee.vogDataReader["FR_TELEPHONE"].ToString();
					clsPhaparfournisseur.FR_SITEWEB = clsDonnee.vogDataReader["FR_SITEWEB"].ToString();
					clsPhaparfournisseur.FR_EMAIL = clsDonnee.vogDataReader["FR_EMAIL"].ToString();
					clsPhaparfournisseur.FR_GERANT = clsDonnee.vogDataReader["FR_GERANT"].ToString();
					clsPhaparfournisseur.FR_STATUT = clsDonnee.vogDataReader["FR_STATUT"].ToString();
					clsPhaparfournisseurs.Add(clsPhaparfournisseur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparfournisseurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparfournisseur </returns>
		///<author>Home Technology</author>
		public List<clsPhaparfournisseur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparfournisseur> clsPhaparfournisseurs = new List<clsPhaparfournisseur>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  FR_CODEFOURNISSEUR, FR_DENOMINATION, FR_SIEGE, FR_ADRESSEPOSTALE, FR_ADRESSEGEOGRAPHIQUE, FR_TELEPHONE, FR_SITEWEB, FR_EMAIL, FR_GERANT, FR_STATUT FROM dbo.PHAPARFOURNISSEUR " + this.vapCritere + " AND FR_STATUT = 'N' ";
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparfournisseur clsPhaparfournisseur = new clsPhaparfournisseur();
					clsPhaparfournisseur.FR_CODEFOURNISSEUR = Dataset.Tables["TABLE"].Rows[Idx]["FR_CODEFOURNISSEUR"].ToString();
					clsPhaparfournisseur.FR_DENOMINATION = Dataset.Tables["TABLE"].Rows[Idx]["FR_DENOMINATION"].ToString();
					clsPhaparfournisseur.FR_SIEGE = Dataset.Tables["TABLE"].Rows[Idx]["FR_SIEGE"].ToString();
					clsPhaparfournisseur.FR_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["FR_ADRESSEPOSTALE"].ToString();
					clsPhaparfournisseur.FR_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["FR_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparfournisseur.FR_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["FR_TELEPHONE"].ToString();
					clsPhaparfournisseur.FR_SITEWEB = Dataset.Tables["TABLE"].Rows[Idx]["FR_SITEWEB"].ToString();
					clsPhaparfournisseur.FR_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["FR_EMAIL"].ToString();
					clsPhaparfournisseur.FR_GERANT = Dataset.Tables["TABLE"].Rows[Idx]["FR_GERANT"].ToString();
					clsPhaparfournisseur.FR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["FR_STATUT"].ToString();
					clsPhaparfournisseurs.Add(clsPhaparfournisseur);
				}
				Dataset.Dispose();
			}
		return clsPhaparfournisseurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereDataset(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARFOURNISSEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : FR_CODEFOURNISSEUR, FR_MATRICULE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRecherche(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARFOURNISSEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : FR_CODEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT FR_CODEFOURNISSEUR , FR_DENOMINATION FROM dbo.PHAPARFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :FR_CODEFOURNISSEUR)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
				break;
                case 1:
                this.vapCritere = " WHERE  AG_CODEAGENCE =@AG_CODEAGENCE  ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
                break;

                case 2:
                this.vapCritere = " WHERE  AG_CODEAGENCE =@AG_CODEAGENCE  AND  FR_CODEFOURNISSEUR LIKE '%'+@FR_CODEFOURNISSEUR+'%'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FR_CODEFOURNISSEUR" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] ,vppCritere[1] };
                break;

                case 3:
                this.vapCritere = " WHERE  AG_CODEAGENCE =@AG_CODEAGENCE  AND  FR_CODEFOURNISSEUR LIKE '%'+@FR_CODEFOURNISSEUR+'%' AND  FR_DENOMINATION LIKE '%'+@FR_DENOMINATION+'%' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FR_CODEFOURNISSEUR", "@FR_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] ,vppCritere[1],vppCritere[2] };
                break;


                
             }
		}

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
                    this.vapCritere = "WHERE AG_CODEAGENCE =@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE =@AG_CODEAGENCE AND FR_MATRICULE=@FR_MATRICULE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FR_MATRICULE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                break;
                case 3:
                this.vapCritere = "WHERE AG_CODEAGENCE =@AG_CODEAGENCE AND FR_MATRICULE LIKE '%'+@FR_MATRICULE+'%'  AND FR_DENOMINATION LIKE '%'+ @FR_DENOMINATION +'%'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FR_MATRICULE", "@FR_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                break;

               
            }
        }
        public void pvpChoixCritereDataset(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
				break;

				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;

                case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND FR_STATUT LIKE '%'+@FR_STATUT+'%'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FR_STATUT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] ,vppCritere[1] };
                break;

                case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND FR_STATUT LIKE '%'+@FR_STATUT+'%' AND FR_CODEFOURNISSEUR LIKE '%'+@FR_CODEFOURNISSEUR+'%'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FR_STATUT", "@FR_CODEFOURNISSEUR" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] ,vppCritere[1],vppCritere[2] };
                break;
                case 4 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND FR_STATUT LIKE '%'+@FR_STATUT+'%' AND FR_CODEFOURNISSEUR LIKE '%'+@FR_CODEFOURNISSEUR+'%' AND  FR_DENOMINATION LIKE '%'+@FR_DENOMINATION+'%'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FR_STATUT", "@FR_CODEFOURNISSEUR", "@FR_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] ,vppCritere[1],vppCritere[2],vppCritere[3] };
                break;
				
			
			}
		}
	}
}
