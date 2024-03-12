using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhachauffeurWSDAL: ITableDAL<clsPhachauffeur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(CH_IDCHAUFFEUR) AS CH_IDCHAUFFEUR  FROM dbo.PHACHAUFFEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(CH_IDCHAUFFEUR) AS CH_IDCHAUFFEUR  FROM dbo.PHACHAUFFEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(CH_IDCHAUFFEUR) AS CH_IDCHAUFFEUR  FROM dbo.PHACHAUFFEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhachauffeur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhachauffeur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT CH_IDCHAUFFEUR, SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE,CH_NUMCHAUFFEUR,CH_DATENAISSANCE,CH_NOMPRENOM,CH_ADRESSEPOSTALE,CH_ADRESSEGEOGRAPHIQUE,CH_TELEPHONE,CH_EMAIL,CH_STATUT,CH_DATESAISIE,OP_CODEOPERATEUR FROM " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhachauffeur clsPhachauffeur = new clsPhachauffeur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    clsPhachauffeur.CH_IDCHAUFFEUR = clsDonnee.vogDataReader["CH_IDCHAUFFEUR"].ToString();
                    clsPhachauffeur.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    clsPhachauffeur.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    clsPhachauffeur.CH_NUMCHAUFFEUR = clsDonnee.vogDataReader["CH_NUMCHAUFFEUR"].ToString();
                    clsPhachauffeur.CH_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATENAISSANCE"].ToString());
                    clsPhachauffeur.CH_NOMPRENOM = clsDonnee.vogDataReader["CH_NOMPRENOM"].ToString();
                    clsPhachauffeur.CH_ADRESSEPOSTALE = clsDonnee.vogDataReader["CH_ADRESSEPOSTALE"].ToString();
                    clsPhachauffeur.CH_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["CH_ADRESSEGEOGRAPHIQUE"].ToString();
                    clsPhachauffeur.CH_TELEPHONE = clsDonnee.vogDataReader["CH_TELEPHONE"].ToString();
                    clsPhachauffeur.CH_EMAIL = clsDonnee.vogDataReader["CH_EMAIL"].ToString();
                    clsPhachauffeur.CH_STATUT = clsDonnee.vogDataReader["CH_STATUT"].ToString();
                    clsPhachauffeur.CH_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATESAISIE"].ToString());
                    clsPhachauffeur.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                }
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhachauffeur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhachauffeur>clsPhachauffeur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhachauffeur clsPhachauffeur)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
            vppParamAG_CODEAGENCE.Value = clsPhachauffeur.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhachauffeur.EN_CODEENTREPOT;

            SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.BigInt);
            vppParamCH_IDCHAUFFEUR.Value = clsPhachauffeur.CH_IDCHAUFFEUR;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhachauffeur.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhachauffeur.SM_CODESITUATIONMATRIMONIALE;

            SqlParameter vppParamCH_NUMCHAUFFEUR = new SqlParameter("@CH_NUMCHAUFFEUR", SqlDbType.VarChar, 7);
            vppParamCH_NUMCHAUFFEUR.Value = clsPhachauffeur.CH_NUMCHAUFFEUR;

            SqlParameter vppParamCH_NUMPERMIS = new SqlParameter("@CH_NUMPERMIS", SqlDbType.VarChar, 150);
            vppParamCH_NUMPERMIS.Value = clsPhachauffeur.CH_NUMPERMIS;

            SqlParameter vppParamCH_DATENAISSANCE = new SqlParameter("@CH_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCH_DATENAISSANCE.Value = clsPhachauffeur.CH_DATENAISSANCE;
            if (clsPhachauffeur.CH_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamCH_DATENAISSANCE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamCH_NOMPRENOM = new SqlParameter("@CH_NOMPRENOM", SqlDbType.VarChar, 150);
            vppParamCH_NOMPRENOM.Value = clsPhachauffeur.CH_NOMPRENOM;

            SqlParameter vppParamCH_ADRESSEPOSTALE = new SqlParameter("@CH_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamCH_ADRESSEPOSTALE.Value = clsPhachauffeur.CH_ADRESSEPOSTALE;

            SqlParameter vppParamCH_ADRESSEGEOGRAPHIQUE = new SqlParameter("@CH_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamCH_ADRESSEGEOGRAPHIQUE.Value = clsPhachauffeur.CH_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamCH_TELEPHONE = new SqlParameter("@CH_TELEPHONE", SqlDbType.VarChar, 150);
            vppParamCH_TELEPHONE.Value = clsPhachauffeur.CH_TELEPHONE;

            SqlParameter vppParamCH_EMAIL = new SqlParameter("@CH_EMAIL", SqlDbType.VarChar, 80);
            vppParamCH_EMAIL.Value = clsPhachauffeur.CH_EMAIL;

            SqlParameter vppParamCH_STATUT = new SqlParameter("@CH_STATUT", SqlDbType.VarChar, 1);
            vppParamCH_STATUT.Value = clsPhachauffeur.CH_STATUT;


            SqlParameter vppParamCH_DATESAISIE = new SqlParameter("@CH_DATESAISIE", SqlDbType.DateTime);
            vppParamCH_DATESAISIE.Value = clsPhachauffeur.CH_DATESAISIE;
            if (clsPhachauffeur.CH_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamCH_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhachauffeur.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHACHAUFFEUR  @AG_CODEAGENCE,@EN_CODEENTREPOT, @CH_IDCHAUFFEUR, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @CH_NUMCHAUFFEUR,@CH_NUMPERMIS, @CH_DATENAISSANCE, @CH_NOMPRENOM, @CH_ADRESSEPOSTALE, @CH_ADRESSEGEOGRAPHIQUE, @CH_TELEPHONE, @CH_EMAIL, @CH_STATUT, @CH_DATESAISIE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            vppSqlCmd.Parameters.Add(vppParamCH_NUMCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamCH_NUMPERMIS);
            vppSqlCmd.Parameters.Add(vppParamCH_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamCH_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamCH_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamCH_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamCH_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamCH_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCH_STATUT);
            vppSqlCmd.Parameters.Add(vppParamCH_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhachauffeur>clsPhachauffeur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhachauffeur clsPhachauffeur,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhachauffeur.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhachauffeur.EN_CODEENTREPOT;
            SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.BigInt);
            vppParamCH_IDCHAUFFEUR.Value = clsPhachauffeur.CH_IDCHAUFFEUR;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhachauffeur.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhachauffeur.SM_CODESITUATIONMATRIMONIALE;

            SqlParameter vppParamCH_NUMCHAUFFEUR = new SqlParameter("@CH_NUMCHAUFFEUR", SqlDbType.VarChar, 7);
            vppParamCH_NUMCHAUFFEUR.Value = clsPhachauffeur.CH_NUMCHAUFFEUR;

            SqlParameter vppParamCH_NUMPERMIS = new SqlParameter("@CH_NUMPERMIS", SqlDbType.VarChar,150);
            vppParamCH_NUMPERMIS.Value = clsPhachauffeur.CH_NUMPERMIS;

            SqlParameter vppParamCH_DATENAISSANCE = new SqlParameter("@CH_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCH_DATENAISSANCE.Value = clsPhachauffeur.CH_DATENAISSANCE;
            if (clsPhachauffeur.CH_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamCH_DATENAISSANCE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamCH_NOMPRENOM = new SqlParameter("@CH_NOMPRENOM", SqlDbType.VarChar, 150);
            vppParamCH_NOMPRENOM.Value = clsPhachauffeur.CH_NOMPRENOM;

            SqlParameter vppParamCH_ADRESSEPOSTALE = new SqlParameter("@CH_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamCH_ADRESSEPOSTALE.Value = clsPhachauffeur.CH_ADRESSEPOSTALE;

            SqlParameter vppParamCH_ADRESSEGEOGRAPHIQUE = new SqlParameter("@CH_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamCH_ADRESSEGEOGRAPHIQUE.Value = clsPhachauffeur.CH_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamCH_TELEPHONE = new SqlParameter("@CH_TELEPHONE", SqlDbType.VarChar, 150);
            vppParamCH_TELEPHONE.Value = clsPhachauffeur.CH_TELEPHONE;

            SqlParameter vppParamCH_EMAIL = new SqlParameter("@CH_EMAIL", SqlDbType.VarChar, 80);
            vppParamCH_EMAIL.Value = clsPhachauffeur.CH_EMAIL;

            SqlParameter vppParamCH_STATUT = new SqlParameter("@CH_STATUT", SqlDbType.VarChar, 1);
            vppParamCH_STATUT.Value = clsPhachauffeur.CH_STATUT;


            SqlParameter vppParamCH_DATESAISIE = new SqlParameter("@CH_DATESAISIE", SqlDbType.DateTime);
            vppParamCH_DATESAISIE.Value = clsPhachauffeur.CH_DATESAISIE;
            if (clsPhachauffeur.CH_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamCH_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhachauffeur.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHACHAUFFEUR  @AG_CODEAGENCE,@EN_CODEENTREPOT, @CH_IDCHAUFFEUR, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @CH_NUMCHAUFFEUR,@CH_NUMPERMIS, @CH_DATENAISSANCE, @CH_NOMPRENOM, @CH_ADRESSEPOSTALE, @CH_ADRESSEGEOGRAPHIQUE, @CH_TELEPHONE, @CH_EMAIL, @CH_STATUT, @CH_DATESAISIE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            vppSqlCmd.Parameters.Add(vppParamCH_NUMCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamCH_NUMPERMIS);
            vppSqlCmd.Parameters.Add(vppParamCH_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamCH_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamCH_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamCH_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamCH_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamCH_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCH_STATUT);
            vppSqlCmd.Parameters.Add(vppParamCH_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHACHAUFFEUR "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhachauffeur </returns>
		///<author>Home Technology</author>
		public List<clsPhachauffeur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CH_IDCHAUFFEUR, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, CH_NUMCHAUFFEUR, CH_DATENAISSANCE, CH_NOMPRENOM, CH_ADRESSEPOSTALE, CH_ADRESSEGEOGRAPHIQUE, CH_TELEPHONE, CH_EMAIL, CH_STATUT, CH_DATESAISIE, OP_CODEOPERATEUR FROM dbo.PHACHAUFFEUR " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhachauffeur> clsPhachauffeurs = new List<clsPhachauffeur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhachauffeur clsPhachauffeur = new clsPhachauffeur();
					clsPhachauffeur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhachauffeur.CH_IDCHAUFFEUR = clsDonnee.vogDataReader["CH_IDCHAUFFEUR"].ToString();
					clsPhachauffeur.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsPhachauffeur.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhachauffeur.CH_NUMCHAUFFEUR = clsDonnee.vogDataReader["CH_NUMCHAUFFEUR"].ToString();
					clsPhachauffeur.CH_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATENAISSANCE"].ToString());
					clsPhachauffeur.CH_NOMPRENOM = clsDonnee.vogDataReader["CH_NOMPRENOM"].ToString();
					clsPhachauffeur.CH_ADRESSEPOSTALE = clsDonnee.vogDataReader["CH_ADRESSEPOSTALE"].ToString();
					clsPhachauffeur.CH_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["CH_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhachauffeur.CH_TELEPHONE = clsDonnee.vogDataReader["CH_TELEPHONE"].ToString();
					clsPhachauffeur.CH_EMAIL = clsDonnee.vogDataReader["CH_EMAIL"].ToString();
					clsPhachauffeur.CH_STATUT = clsDonnee.vogDataReader["CH_STATUT"].ToString();
					clsPhachauffeur.CH_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATESAISIE"].ToString());
					clsPhachauffeur.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhachauffeurs.Add(clsPhachauffeur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhachauffeurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhachauffeur </returns>
		///<author>Home Technology</author>
		public List<clsPhachauffeur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhachauffeur> clsPhachauffeurs = new List<clsPhachauffeur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CH_IDCHAUFFEUR, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, CH_NUMCHAUFFEUR, CH_DATENAISSANCE, CH_NOMPRENOM, CH_ADRESSEPOSTALE, CH_ADRESSEGEOGRAPHIQUE, CH_TELEPHONE, CH_EMAIL, CH_STATUT, CH_DATESAISIE, OP_CODEOPERATEUR FROM dbo.PHACHAUFFEUR " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhachauffeur clsPhachauffeur = new clsPhachauffeur();
					clsPhachauffeur.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhachauffeur.CH_IDCHAUFFEUR = Dataset.Tables["TABLE"].Rows[Idx]["CH_IDCHAUFFEUR"].ToString();
					clsPhachauffeur.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
					clsPhachauffeur.SM_CODESITUATIONMATRIMONIALE = Dataset.Tables["TABLE"].Rows[Idx]["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhachauffeur.CH_NUMCHAUFFEUR = Dataset.Tables["TABLE"].Rows[Idx]["CH_NUMCHAUFFEUR"].ToString();
					clsPhachauffeur.CH_DATENAISSANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATENAISSANCE"].ToString());
					clsPhachauffeur.CH_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["CH_NOMPRENOM"].ToString();
					clsPhachauffeur.CH_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["CH_ADRESSEPOSTALE"].ToString();
					clsPhachauffeur.CH_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["CH_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhachauffeur.CH_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["CH_TELEPHONE"].ToString();
					clsPhachauffeur.CH_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["CH_EMAIL"].ToString();
					clsPhachauffeur.CH_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["CH_STATUT"].ToString();
					clsPhachauffeur.CH_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATESAISIE"].ToString());
					clsPhachauffeur.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhachauffeurs.Add(clsPhachauffeur);
				}
				Dataset.Dispose();
			}
		return clsPhachauffeurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHACHAUFFEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CH_IDCHAUFFEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , CH_NOMPRENOM FROM dbo.PHACHAUFFEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CH_IDCHAUFFEUR)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
        public void pvpChoixCritere(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CH_IDCHAUFFEUR" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] {"@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] {clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_NUMCHAUFFEUR LIKE '%'+ @CH_NUMCHAUFFEUR + '%' AND CH_STATUT ='N'";
                    vapNomParametre = new string[] {"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CH_NUMCHAUFFEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_NUMCHAUFFEUR LIKE '%'+ @CH_NUMCHAUFFEUR + '%' AND CH_NOMPRENOM LIKE '%'+ @CH_NOMPRENOM + '%' AND CH_STATUT ='N'";
                    vapNomParametre = new string[] {"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CH_NUMCHAUFFEUR", "@CH_NOMPRENOM" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }
    }
}
