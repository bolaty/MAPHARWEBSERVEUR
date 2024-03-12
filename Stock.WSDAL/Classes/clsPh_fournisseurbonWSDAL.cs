using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPh_fournisseurbonWSDAL: ITableDAL<clsPh_fournisseurbon>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(FB_IDFOURNISSEUR) AS FB_IDFOURNISSEUR  FROM dbo.PH_FOURNISSEURBON " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(FB_IDFOURNISSEUR) AS FB_IDFOURNISSEUR  FROM dbo.PH_FOURNISSEURBON " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(FB_IDFOURNISSEUR) AS FB_IDFOURNISSEUR  FROM dbo.PH_FOURNISSEURBON " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPh_fournisseurbon comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPh_fournisseurbon pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , SX_CODESEXE  , SM_CODESITUATIONMATRIMONIALE  , OP_CODEOPERATEUR  , FB_NUMFOURNISSEUR  , FB_DATENAISSANCE  , FB_NOMPRENOM  , FB_ADRESSEPOSTALE  , FB_ADRESSEGEOGRAPHIQUE  , FB_TELEPHONE  , FB_EMAIL  , FB_STATUT  , FB_DATESAISIE  FROM dbo.FT_PH_FOURNISSEURBON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPh_fournisseurbon clsPh_fournisseurbon = new clsPh_fournisseurbon();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPh_fournisseurbon.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPh_fournisseurbon.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsPh_fournisseurbon.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPh_fournisseurbon.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPh_fournisseurbon.FB_NUMFOURNISSEUR = clsDonnee.vogDataReader["FB_NUMFOURNISSEUR"].ToString();
					clsPh_fournisseurbon.FB_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["FB_DATENAISSANCE"].ToString());
					clsPh_fournisseurbon.FB_NOMPRENOM = clsDonnee.vogDataReader["FB_NOMPRENOM"].ToString();
					clsPh_fournisseurbon.FB_ADRESSEPOSTALE = clsDonnee.vogDataReader["FB_ADRESSEPOSTALE"].ToString();
					clsPh_fournisseurbon.FB_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["FB_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPh_fournisseurbon.FB_TELEPHONE = clsDonnee.vogDataReader["FB_TELEPHONE"].ToString();
					clsPh_fournisseurbon.FB_EMAIL = clsDonnee.vogDataReader["FB_EMAIL"].ToString();
					clsPh_fournisseurbon.FB_STATUT = clsDonnee.vogDataReader["FB_STATUT"].ToString();
					clsPh_fournisseurbon.FB_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["FB_DATESAISIE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPh_fournisseurbon;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPh_fournisseurbon>clsPh_fournisseurbon</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPh_fournisseurbon clsPh_fournisseurbon)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPh_fournisseurbon.AG_CODEAGENCE ;
			SqlParameter vppParamFB_IDFOURNISSEUR = new SqlParameter("@FB_IDFOURNISSEUR", SqlDbType.VarChar, 50);
			vppParamFB_IDFOURNISSEUR.Value  = clsPh_fournisseurbon.FB_IDFOURNISSEUR ;
			SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
			vppParamSX_CODESEXE.Value  = clsPh_fournisseurbon.SX_CODESEXE ;
			SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
			vppParamSM_CODESITUATIONMATRIMONIALE.Value  = clsPh_fournisseurbon.SM_CODESITUATIONMATRIMONIALE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPh_fournisseurbon.OP_CODEOPERATEUR ;
			SqlParameter vppParamFB_NUMFOURNISSEUR = new SqlParameter("@FB_NUMFOURNISSEUR", SqlDbType.VarChar, 7000);
			vppParamFB_NUMFOURNISSEUR.Value  = clsPh_fournisseurbon.FB_NUMFOURNISSEUR ;
			SqlParameter vppParamFB_DATENAISSANCE = new SqlParameter("@FB_DATENAISSANCE", SqlDbType.DateTime);
			vppParamFB_DATENAISSANCE.Value  = clsPh_fournisseurbon.FB_DATENAISSANCE ;
			SqlParameter vppParamFB_NOMPRENOM = new SqlParameter("@FB_NOMPRENOM", SqlDbType.VarChar, 150);
			vppParamFB_NOMPRENOM.Value  = clsPh_fournisseurbon.FB_NOMPRENOM ;
			SqlParameter vppParamFB_ADRESSEPOSTALE = new SqlParameter("@FB_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
			vppParamFB_ADRESSEPOSTALE.Value  = clsPh_fournisseurbon.FB_ADRESSEPOSTALE ;
			SqlParameter vppParamFB_ADRESSEGEOGRAPHIQUE = new SqlParameter("@FB_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
			vppParamFB_ADRESSEGEOGRAPHIQUE.Value  = clsPh_fournisseurbon.FB_ADRESSEGEOGRAPHIQUE ;
			SqlParameter vppParamFB_TELEPHONE = new SqlParameter("@FB_TELEPHONE", SqlDbType.VarChar, 150);
			vppParamFB_TELEPHONE.Value  = clsPh_fournisseurbon.FB_TELEPHONE ;
			SqlParameter vppParamFB_EMAIL = new SqlParameter("@FB_EMAIL", SqlDbType.VarChar, 80);
			vppParamFB_EMAIL.Value  = clsPh_fournisseurbon.FB_EMAIL ;
			if(clsPh_fournisseurbon.FB_EMAIL== ""  ) vppParamFB_EMAIL.Value  = DBNull.Value;
			SqlParameter vppParamFB_STATUT = new SqlParameter("@FB_STATUT", SqlDbType.VarChar, 1);
			vppParamFB_STATUT.Value  = clsPh_fournisseurbon.FB_STATUT ;
			SqlParameter vppParamFB_DATESAISIE = new SqlParameter("@FB_DATESAISIE", SqlDbType.DateTime);
            vppParamFB_DATESAISIE.Value = clsPh_fournisseurbon.FB_DATESAISIE;
            if (clsPh_fournisseurbon.FB_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamFB_DATESAISIE.Value = DateTime.Parse("01/01/1900");
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PH_FOURNISSEURBON  @AG_CODEAGENCE, @FB_IDFOURNISSEUR, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @OP_CODEOPERATEUR, @FB_NUMFOURNISSEUR, @FB_DATENAISSANCE, @FB_NOMPRENOM, @FB_ADRESSEPOSTALE, @FB_ADRESSEGEOGRAPHIQUE, @FB_TELEPHONE, @FB_EMAIL, @FB_STATUT, @FB_DATESAISIE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamFB_IDFOURNISSEUR);
			vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
			vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamFB_NUMFOURNISSEUR);
			vppSqlCmd.Parameters.Add(vppParamFB_DATENAISSANCE);
			vppSqlCmd.Parameters.Add(vppParamFB_NOMPRENOM);
			vppSqlCmd.Parameters.Add(vppParamFB_ADRESSEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamFB_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamFB_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamFB_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamFB_STATUT);
			vppSqlCmd.Parameters.Add(vppParamFB_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPh_fournisseurbon>clsPh_fournisseurbon</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPh_fournisseurbon clsPh_fournisseurbon,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPh_fournisseurbon.AG_CODEAGENCE ;
			SqlParameter vppParamFB_IDFOURNISSEUR = new SqlParameter("@FB_IDFOURNISSEUR", SqlDbType.VarChar, 50);
			vppParamFB_IDFOURNISSEUR.Value  = clsPh_fournisseurbon.FB_IDFOURNISSEUR ;
			SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
			vppParamSX_CODESEXE.Value  = clsPh_fournisseurbon.SX_CODESEXE ;
			SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
			vppParamSM_CODESITUATIONMATRIMONIALE.Value  = clsPh_fournisseurbon.SM_CODESITUATIONMATRIMONIALE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPh_fournisseurbon.OP_CODEOPERATEUR ;
			SqlParameter vppParamFB_NUMFOURNISSEUR = new SqlParameter("@FB_NUMFOURNISSEUR", SqlDbType.VarChar, 7000);
			vppParamFB_NUMFOURNISSEUR.Value  = clsPh_fournisseurbon.FB_NUMFOURNISSEUR ;
			SqlParameter vppParamFB_DATENAISSANCE = new SqlParameter("@FB_DATENAISSANCE", SqlDbType.DateTime);
			vppParamFB_DATENAISSANCE.Value  = clsPh_fournisseurbon.FB_DATENAISSANCE ;
			SqlParameter vppParamFB_NOMPRENOM = new SqlParameter("@FB_NOMPRENOM", SqlDbType.VarChar, 150);
			vppParamFB_NOMPRENOM.Value  = clsPh_fournisseurbon.FB_NOMPRENOM ;
			SqlParameter vppParamFB_ADRESSEPOSTALE = new SqlParameter("@FB_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
			vppParamFB_ADRESSEPOSTALE.Value  = clsPh_fournisseurbon.FB_ADRESSEPOSTALE ;
			SqlParameter vppParamFB_ADRESSEGEOGRAPHIQUE = new SqlParameter("@FB_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
			vppParamFB_ADRESSEGEOGRAPHIQUE.Value  = clsPh_fournisseurbon.FB_ADRESSEGEOGRAPHIQUE ;
			SqlParameter vppParamFB_TELEPHONE = new SqlParameter("@FB_TELEPHONE", SqlDbType.VarChar, 150);
			vppParamFB_TELEPHONE.Value  = clsPh_fournisseurbon.FB_TELEPHONE ;
			SqlParameter vppParamFB_EMAIL = new SqlParameter("@FB_EMAIL", SqlDbType.VarChar, 80);
			vppParamFB_EMAIL.Value  = clsPh_fournisseurbon.FB_EMAIL ;
			if(clsPh_fournisseurbon.FB_EMAIL== ""  ) vppParamFB_EMAIL.Value  = DBNull.Value;
			SqlParameter vppParamFB_STATUT = new SqlParameter("@FB_STATUT", SqlDbType.VarChar, 1);
			vppParamFB_STATUT.Value  = clsPh_fournisseurbon.FB_STATUT ;
			SqlParameter vppParamFB_DATESAISIE = new SqlParameter("@FB_DATESAISIE", SqlDbType.DateTime);
			vppParamFB_DATESAISIE.Value  = clsPh_fournisseurbon.FB_DATESAISIE ;
            if (clsPh_fournisseurbon.FB_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamFB_DATESAISIE.Value = DateTime.Parse("01/01/1900");
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PH_FOURNISSEURBON  @AG_CODEAGENCE, @FB_IDFOURNISSEUR, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @OP_CODEOPERATEUR, @FB_NUMFOURNISSEUR, @FB_DATENAISSANCE, @FB_NOMPRENOM, @FB_ADRESSEPOSTALE, @FB_ADRESSEGEOGRAPHIQUE, @FB_TELEPHONE, @FB_EMAIL, @FB_STATUT, @FB_DATESAISIE, @CODECRYPTAGE1, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamFB_IDFOURNISSEUR);
			vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
			vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamFB_NUMFOURNISSEUR);
			vppSqlCmd.Parameters.Add(vppParamFB_DATENAISSANCE);
			vppSqlCmd.Parameters.Add(vppParamFB_NOMPRENOM);
			vppSqlCmd.Parameters.Add(vppParamFB_ADRESSEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamFB_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamFB_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamFB_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamFB_STATUT);
			vppSqlCmd.Parameters.Add(vppParamFB_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PH_FOURNISSEURBON  @AG_CODEAGENCE, @FB_IDFOURNISSEUR, '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPh_fournisseurbon </returns>
		///<author>Home Technology</author>
		public List<clsPh_fournisseurbon> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, FB_IDFOURNISSEUR, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, OP_CODEOPERATEUR, FB_NUMFOURNISSEUR, FB_DATENAISSANCE, FB_NOMPRENOM, FB_ADRESSEPOSTALE, FB_ADRESSEGEOGRAPHIQUE, FB_TELEPHONE, FB_EMAIL, FB_STATUT, FB_DATESAISIE FROM dbo.FT_PH_FOURNISSEURBON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPh_fournisseurbon> clsPh_fournisseurbons = new List<clsPh_fournisseurbon>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPh_fournisseurbon clsPh_fournisseurbon = new clsPh_fournisseurbon();
					clsPh_fournisseurbon.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPh_fournisseurbon.FB_IDFOURNISSEUR = clsDonnee.vogDataReader["FB_IDFOURNISSEUR"].ToString();
					clsPh_fournisseurbon.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsPh_fournisseurbon.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPh_fournisseurbon.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPh_fournisseurbon.FB_NUMFOURNISSEUR = clsDonnee.vogDataReader["FB_NUMFOURNISSEUR"].ToString();
					clsPh_fournisseurbon.FB_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["FB_DATENAISSANCE"].ToString());
					clsPh_fournisseurbon.FB_NOMPRENOM = clsDonnee.vogDataReader["FB_NOMPRENOM"].ToString();
					clsPh_fournisseurbon.FB_ADRESSEPOSTALE = clsDonnee.vogDataReader["FB_ADRESSEPOSTALE"].ToString();
					clsPh_fournisseurbon.FB_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["FB_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPh_fournisseurbon.FB_TELEPHONE = clsDonnee.vogDataReader["FB_TELEPHONE"].ToString();
					clsPh_fournisseurbon.FB_EMAIL = clsDonnee.vogDataReader["FB_EMAIL"].ToString();
					clsPh_fournisseurbon.FB_STATUT = clsDonnee.vogDataReader["FB_STATUT"].ToString();
					clsPh_fournisseurbon.FB_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["FB_DATESAISIE"].ToString());
					clsPh_fournisseurbons.Add(clsPh_fournisseurbon);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPh_fournisseurbons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPh_fournisseurbon </returns>
		///<author>Home Technology</author>
		public List<clsPh_fournisseurbon> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPh_fournisseurbon> clsPh_fournisseurbons = new List<clsPh_fournisseurbon>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, FB_IDFOURNISSEUR, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, OP_CODEOPERATEUR, FB_NUMFOURNISSEUR, FB_DATENAISSANCE, FB_NOMPRENOM, FB_ADRESSEPOSTALE, FB_ADRESSEGEOGRAPHIQUE, FB_TELEPHONE, FB_EMAIL, FB_STATUT, FB_DATESAISIE FROM dbo.FT_PH_FOURNISSEURBON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPh_fournisseurbon clsPh_fournisseurbon = new clsPh_fournisseurbon();
					clsPh_fournisseurbon.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPh_fournisseurbon.FB_IDFOURNISSEUR = Dataset.Tables["TABLE"].Rows[Idx]["FB_IDFOURNISSEUR"].ToString();
					clsPh_fournisseurbon.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
					clsPh_fournisseurbon.SM_CODESITUATIONMATRIMONIALE = Dataset.Tables["TABLE"].Rows[Idx]["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPh_fournisseurbon.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPh_fournisseurbon.FB_NUMFOURNISSEUR = Dataset.Tables["TABLE"].Rows[Idx]["FB_NUMFOURNISSEUR"].ToString();
					clsPh_fournisseurbon.FB_DATENAISSANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["FB_DATENAISSANCE"].ToString());
					clsPh_fournisseurbon.FB_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["FB_NOMPRENOM"].ToString();
					clsPh_fournisseurbon.FB_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["FB_ADRESSEPOSTALE"].ToString();
					clsPh_fournisseurbon.FB_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["FB_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPh_fournisseurbon.FB_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["FB_TELEPHONE"].ToString();
					clsPh_fournisseurbon.FB_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["FB_EMAIL"].ToString();
					clsPh_fournisseurbon.FB_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["FB_STATUT"].ToString();
					clsPh_fournisseurbon.FB_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["FB_DATESAISIE"].ToString());
					clsPh_fournisseurbons.Add(clsPh_fournisseurbon);
				}
				Dataset.Dispose();
			}
		return clsPh_fournisseurbons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PH_FOURNISSEURBON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, FB_IDFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT FB_IDFOURNISSEUR , FB_NOMPRENOM FROM dbo.FT_PH_FOURNISSEURBON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, FB_IDFOURNISSEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND FB_IDFOURNISSEUR=@FB_IDFOURNISSEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@FB_IDFOURNISSEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
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
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND FB_NUMFOURNISSEUR LIKE '%'+ @FB_NUMFOURNISSEUR + '%' AND CH_STATUT ='N'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FB_NUMFOURNISSEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND FB_NUMFOURNISSEUR LIKE '%'+ @FB_NUMFOURNISSEUR + '%' AND FB_NOMPRENOM LIKE '%'+ @FB_NOMPRENOM + '%' AND FB_STATUT ='N'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@FB_NUMFOURNISSEUR", "@FB_NOMPRENOM" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }



	}
}
