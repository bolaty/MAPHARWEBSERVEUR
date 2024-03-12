using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhacommercialWSDAL: ITableDAL<clsPhacommercial>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee,vppCritere);
            this.vapRequete = "SELECT COUNT(CO_IDCOMMERCIAL) AS CO_IDCOMMERCIAL  FROM dbo.PHACOMMERCIAL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(CO_IDCOMMERCIAL) AS CO_IDCOMMERCIAL  FROM dbo.PHACOMMERCIAL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(CO_IDCOMMERCIAL) AS CO_IDCOMMERCIAL  FROM dbo.PHACOMMERCIAL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhacommercial comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhacommercial pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT SX_CODESEXE  , SM_CODESITUATIONMATRIMONIALE  , CO_NUMCOMMERCIAL  , CO_DATENAISSANCE  , CO_NOMPRENOM  , CO_ADRESSEPOSTALE  , CO_ADRESSEGEOGRAPHIQUE  , CO_TELEPHONE  , CO_EMAIL  , CO_STATUT  , CO_TAUXCOMMISSION  , CO_MONTANTCOMMISSION  , CO_DATESAISIE  , OP_CODEOPERATEUR  FROM dbo.FT_PHACOMMERCIAL(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhacommercial clsPhacommercial = new clsPhacommercial();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhacommercial.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsPhacommercial.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhacommercial.CO_NUMCOMMERCIAL = clsDonnee.vogDataReader["CO_NUMCOMMERCIAL"].ToString();
					clsPhacommercial.CO_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["CO_DATENAISSANCE"].ToString());
					clsPhacommercial.CO_NOMPRENOM = clsDonnee.vogDataReader["CO_NOMPRENOM"].ToString();
					clsPhacommercial.CO_ADRESSEPOSTALE = clsDonnee.vogDataReader["CO_ADRESSEPOSTALE"].ToString();
					clsPhacommercial.CO_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["CO_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhacommercial.CO_TELEPHONE = clsDonnee.vogDataReader["CO_TELEPHONE"].ToString();
					clsPhacommercial.CO_EMAIL = clsDonnee.vogDataReader["CO_EMAIL"].ToString();
					clsPhacommercial.CO_STATUT = clsDonnee.vogDataReader["CO_STATUT"].ToString();
                    clsPhacommercial.CO_TAUXCOMMISSION = double.Parse(clsDonnee.vogDataReader["CO_TAUXCOMMISSION"].ToString());
					clsPhacommercial.CO_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["CO_MONTANTCOMMISSION"].ToString());
					clsPhacommercial.CO_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CO_DATESAISIE"].ToString());
					clsPhacommercial.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhacommercial;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhacommercial>clsPhacommercial</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhacommercial clsPhacommercial)
		{
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhacommercial.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhacommercial.EN_CODEENTREPOT;

            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.BigInt);
            vppParamCO_IDCOMMERCIAL.Value = clsPhacommercial.CO_IDCOMMERCIAL;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhacommercial.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhacommercial.SM_CODESITUATIONMATRIMONIALE;

            SqlParameter vppParamCO_NUMCOMMERCIAL = new SqlParameter("@CO_NUMCOMMERCIAL", SqlDbType.VarChar, 8);
            vppParamCO_NUMCOMMERCIAL.Value = clsPhacommercial.CO_NUMCOMMERCIAL;

            SqlParameter vppParamCO_DATENAISSANCE = new SqlParameter("@CO_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCO_DATENAISSANCE.Value = clsPhacommercial.CO_DATENAISSANCE;
            if (clsPhacommercial.CO_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamCO_DATENAISSANCE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamCO_NOMPRENOM = new SqlParameter("@CO_NOMPRENOM", SqlDbType.VarChar, 150);
            vppParamCO_NOMPRENOM.Value = clsPhacommercial.CO_NOMPRENOM;

            SqlParameter vppParamCO_ADRESSEPOSTALE = new SqlParameter("@CO_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamCO_ADRESSEPOSTALE.Value = clsPhacommercial.CO_ADRESSEPOSTALE;

            SqlParameter vppParamCO_ADRESSEGEOGRAPHIQUE = new SqlParameter("@CO_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamCO_ADRESSEGEOGRAPHIQUE.Value = clsPhacommercial.CO_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamCO_TELEPHONE = new SqlParameter("@CO_TELEPHONE", SqlDbType.VarChar, 150);
            vppParamCO_TELEPHONE.Value = clsPhacommercial.CO_TELEPHONE;

            SqlParameter vppParamCO_EMAIL = new SqlParameter("@CO_EMAIL", SqlDbType.VarChar, 150);
            vppParamCO_EMAIL.Value = clsPhacommercial.CO_EMAIL;

            SqlParameter vppParamCO_STATUT = new SqlParameter("@CO_STATUT", SqlDbType.VarChar, 1);
            vppParamCO_STATUT.Value = clsPhacommercial.CO_STATUT;

            SqlParameter vppParamCO_TAUXCOMMISSION = new SqlParameter("@CO_TAUXCOMMISSION", SqlDbType.Float);
            vppParamCO_TAUXCOMMISSION.Value = clsPhacommercial.CO_TAUXCOMMISSION;

            SqlParameter vppParamCO_MONTANTCOMMISSION = new SqlParameter("@CO_MONTANTCOMMISSION", SqlDbType.Money);
            vppParamCO_MONTANTCOMMISSION.Value = clsPhacommercial.CO_MONTANTCOMMISSION;

            SqlParameter vppParamCO_DATESAISIE = new SqlParameter("@CO_DATESAISIE", SqlDbType.DateTime);
            vppParamCO_DATESAISIE.Value = clsPhacommercial.CO_DATESAISIE;
            if (clsPhacommercial.CO_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamCO_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhacommercial.OP_CODEOPERATEUR;

            SqlParameter vppParamCO_MODECALCULECOMMISSION = new SqlParameter("@CO_MODECALCULECOMMISSION", SqlDbType.VarChar, 3);
            vppParamCO_MODECALCULECOMMISSION.Value = clsPhacommercial.CO_MODECALCULECOMMISSION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHACOMMERCIAL  @AG_CODEAGENCE,@EN_CODEENTREPOT, @CO_IDCOMMERCIAL, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @CO_NUMCOMMERCIAL, @CO_DATENAISSANCE, @CO_NOMPRENOM, @CO_ADRESSEPOSTALE, @CO_ADRESSEGEOGRAPHIQUE, @CO_TELEPHONE, @CO_EMAIL, @CO_STATUT, @CO_TAUXCOMMISSION, @CO_MONTANTCOMMISSION, @CO_DATESAISIE, @OP_CODEOPERATEUR,@CO_MODECALCULECOMMISSION, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            vppSqlCmd.Parameters.Add(vppParamCO_NUMCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamCO_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamCO_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamCO_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamCO_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamCO_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamCO_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCO_STATUT);
            vppSqlCmd.Parameters.Add(vppParamCO_TAUXCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamCO_MONTANTCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamCO_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCO_MODECALCULECOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhacommercial>clsPhacommercial</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhacommercial clsPhacommercial,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhacommercial.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhacommercial.EN_CODEENTREPOT;

            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.BigInt);
            vppParamCO_IDCOMMERCIAL.Value = clsPhacommercial.CO_IDCOMMERCIAL;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhacommercial.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhacommercial.SM_CODESITUATIONMATRIMONIALE;

            SqlParameter vppParamCO_NUMCOMMERCIAL = new SqlParameter("@CO_NUMCOMMERCIAL", SqlDbType.VarChar, 8);
            vppParamCO_NUMCOMMERCIAL.Value = clsPhacommercial.CO_NUMCOMMERCIAL;

            SqlParameter vppParamCO_DATENAISSANCE = new SqlParameter("@CO_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCO_DATENAISSANCE.Value = clsPhacommercial.CO_DATENAISSANCE;
            if (clsPhacommercial.CO_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamCO_DATENAISSANCE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamCO_NOMPRENOM = new SqlParameter("@CO_NOMPRENOM", SqlDbType.VarChar, 150);
            vppParamCO_NOMPRENOM.Value = clsPhacommercial.CO_NOMPRENOM;

            SqlParameter vppParamCO_ADRESSEPOSTALE = new SqlParameter("@CO_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamCO_ADRESSEPOSTALE.Value = clsPhacommercial.CO_ADRESSEPOSTALE;

            SqlParameter vppParamCO_ADRESSEGEOGRAPHIQUE = new SqlParameter("@CO_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamCO_ADRESSEGEOGRAPHIQUE.Value = clsPhacommercial.CO_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamCO_TELEPHONE = new SqlParameter("@CO_TELEPHONE", SqlDbType.VarChar, 150);
            vppParamCO_TELEPHONE.Value = clsPhacommercial.CO_TELEPHONE;

            SqlParameter vppParamCO_EMAIL = new SqlParameter("@CO_EMAIL", SqlDbType.VarChar, 150);
            vppParamCO_EMAIL.Value = clsPhacommercial.CO_EMAIL;

            SqlParameter vppParamCO_STATUT = new SqlParameter("@CO_STATUT", SqlDbType.VarChar, 1);
            vppParamCO_STATUT.Value = clsPhacommercial.CO_STATUT;

            SqlParameter vppParamCO_TAUXCOMMISSION = new SqlParameter("@CO_TAUXCOMMISSION", SqlDbType.Float);
            vppParamCO_TAUXCOMMISSION.Value = clsPhacommercial.CO_TAUXCOMMISSION;

            SqlParameter vppParamCO_MONTANTCOMMISSION = new SqlParameter("@CO_MONTANTCOMMISSION", SqlDbType.Money);
            vppParamCO_MONTANTCOMMISSION.Value = clsPhacommercial.CO_MONTANTCOMMISSION;

            SqlParameter vppParamCO_DATESAISIE = new SqlParameter("@CO_DATESAISIE", SqlDbType.DateTime);
            vppParamCO_DATESAISIE.Value = clsPhacommercial.CO_DATESAISIE;
            if (clsPhacommercial.CO_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamCO_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhacommercial.OP_CODEOPERATEUR;
            SqlParameter vppParamCO_MODECALCULECOMMISSION = new SqlParameter("@CO_MODECALCULECOMMISSION", SqlDbType.VarChar, 3);
            vppParamCO_MODECALCULECOMMISSION.Value = clsPhacommercial.CO_MODECALCULECOMMISSION;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHACOMMERCIAL  @AG_CODEAGENCE,  @EN_CODEENTREPOT, @CO_IDCOMMERCIAL, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @CO_NUMCOMMERCIAL, @CO_DATENAISSANCE, @CO_NOMPRENOM, @CO_ADRESSEPOSTALE, @CO_ADRESSEGEOGRAPHIQUE, @CO_TELEPHONE, @CO_EMAIL, @CO_STATUT, @CO_TAUXCOMMISSION, @CO_MONTANTCOMMISSION, @CO_DATESAISIE, @OP_CODEOPERATEUR, @CO_MODECALCULECOMMISSION,@CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            vppSqlCmd.Parameters.Add(vppParamCO_NUMCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamCO_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamCO_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamCO_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamCO_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamCO_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamCO_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCO_STATUT);
            vppSqlCmd.Parameters.Add(vppParamCO_TAUXCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamCO_MONTANTCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamCO_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCO_MODECALCULECOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere2(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHACOMMERCIAL "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhacommercial </returns>
		///<author>Home Technology</author>
		public List<clsPhacommercial> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_IDCOMMERCIAL, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, CO_NUMCOMMERCIAL, CO_DATENAISSANCE, CO_NOMPRENOM, CO_ADRESSEPOSTALE, CO_ADRESSEGEOGRAPHIQUE, CO_TELEPHONE, CO_EMAIL, CO_STATUT, CO_TAUXCOMMISSION, CO_MONTANTCOMMISSION, CO_DATESAISIE, OP_CODEOPERATEUR FROM dbo.PHACOMMERCIAL " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhacommercial> clsPhacommercials = new List<clsPhacommercial>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhacommercial clsPhacommercial = new clsPhacommercial();
					clsPhacommercial.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhacommercial.CO_IDCOMMERCIAL = clsDonnee.vogDataReader["CO_IDCOMMERCIAL"].ToString();
					clsPhacommercial.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsPhacommercial.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhacommercial.CO_NUMCOMMERCIAL = clsDonnee.vogDataReader["CO_NUMCOMMERCIAL"].ToString();
					clsPhacommercial.CO_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["CO_DATENAISSANCE"].ToString());
					clsPhacommercial.CO_NOMPRENOM = clsDonnee.vogDataReader["CO_NOMPRENOM"].ToString();
					clsPhacommercial.CO_ADRESSEPOSTALE = clsDonnee.vogDataReader["CO_ADRESSEPOSTALE"].ToString();
					clsPhacommercial.CO_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["CO_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhacommercial.CO_TELEPHONE = clsDonnee.vogDataReader["CO_TELEPHONE"].ToString();
					clsPhacommercial.CO_EMAIL = clsDonnee.vogDataReader["CO_EMAIL"].ToString();
					clsPhacommercial.CO_STATUT = clsDonnee.vogDataReader["CO_STATUT"].ToString();
					clsPhacommercial.CO_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["CO_TAUXCOMMISSION"].ToString());
					clsPhacommercial.CO_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["CO_MONTANTCOMMISSION"].ToString());
					clsPhacommercial.CO_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CO_DATESAISIE"].ToString());
					clsPhacommercial.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhacommercials.Add(clsPhacommercial);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhacommercials;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhacommercial </returns>
		///<author>Home Technology</author>
		public List<clsPhacommercial> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhacommercial> clsPhacommercials = new List<clsPhacommercial>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere1(clsDonnee,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_IDCOMMERCIAL, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, CO_NUMCOMMERCIAL, CO_DATENAISSANCE, CO_NOMPRENOM, CO_ADRESSEPOSTALE, CO_ADRESSEGEOGRAPHIQUE, CO_TELEPHONE, CO_EMAIL, CO_STATUT, CO_TAUXCOMMISSION, CO_MONTANTCOMMISSION, CO_DATESAISIE, OP_CODEOPERATEUR FROM dbo.PHACOMMERCIAL " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhacommercial clsPhacommercial = new clsPhacommercial();
					clsPhacommercial.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhacommercial.CO_IDCOMMERCIAL = Dataset.Tables["TABLE"].Rows[Idx]["CO_IDCOMMERCIAL"].ToString();
					clsPhacommercial.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
					clsPhacommercial.SM_CODESITUATIONMATRIMONIALE = Dataset.Tables["TABLE"].Rows[Idx]["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhacommercial.CO_NUMCOMMERCIAL = Dataset.Tables["TABLE"].Rows[Idx]["CO_NUMCOMMERCIAL"].ToString();
					clsPhacommercial.CO_DATENAISSANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_DATENAISSANCE"].ToString());
					clsPhacommercial.CO_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["CO_NOMPRENOM"].ToString();
					clsPhacommercial.CO_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["CO_ADRESSEPOSTALE"].ToString();
					clsPhacommercial.CO_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["CO_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhacommercial.CO_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["CO_TELEPHONE"].ToString();
					clsPhacommercial.CO_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["CO_EMAIL"].ToString();
					clsPhacommercial.CO_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["CO_STATUT"].ToString();
					clsPhacommercial.CO_TAUXCOMMISSION = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_TAUXCOMMISSION"].ToString());
					clsPhacommercial.CO_MONTANTCOMMISSION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_MONTANTCOMMISSION"].ToString());
					clsPhacommercial.CO_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_DATESAISIE"].ToString());
					clsPhacommercial.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhacommercials.Add(clsPhacommercial);
				}
				Dataset.Dispose();
			}
		return clsPhacommercials;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHACOMMERCIAL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CO_IDCOMMERCIAL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee,vppCritere);
            this.vapRequete = "SELECT CO_IDCOMMERCIAL , CO_NOMPRENOM FROM dbo.FT_PHACOMMERCIAL(@CODECRYPTAGE)" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CO_IDCOMMERCIAL)</summary>
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
				case 1 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE" ,"@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage ,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_NUMCOMMERCIAL=@CO_NUMCOMMERCIAL";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_NUMCOMMERCIAL" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage ,vppCritere[0],vppCritere[1]};
				break;
			}
		}

        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
				break;
				case 1 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_NUMCOMMERCIAL=@CO_NUMCOMMERCIAL";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_NUMCOMMERCIAL" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_NUMCOMMERCIAL LIKE '%'+@CO_NUMCOMMERCIAL+'%' AND CO_NOMPRENOM LIKE '%'+@CO_NOMPRENOM+'%' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
				break;
			}

		}

        public void pvpChoixCritere2(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
				break;
				case 1 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_IDCOMMERCIAL" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;
				
			}

		}



	}
}
