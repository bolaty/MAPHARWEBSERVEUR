using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaTransporteurWSDAL: ITableDAL<clsPhaTransporteur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(TR_IDTRANSPORTEUR) AS TR_IDTRANSPORTEUR  FROM dbo.PHATRANSPORTEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(TR_IDTRANSPORTEUR) AS TR_IDTRANSPORTEUR  FROM dbo.PHATRANSPORTEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(TR_IDTRANSPORTEUR) AS TR_IDTRANSPORTEUR  FROM dbo.PHATRANSPORTEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaTransporteur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaTransporteur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT TR_IDTRANSPORTEUR, SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE,TR_NUMTRANSPORTEUR,TR_DATENAISSANCE,TR_NOMPRENOM,TR_ADRESSEPOSTALE,TR_ADRESSEGEOGRAPHIQUE,TR_TELEPHONE,TR_EMAIL,TR_STATUT,TR_DATESAISIE,OP_CODEOPERATEUR FROM " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaTransporteur clsPhaTransporteur = new clsPhaTransporteur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    clsPhaTransporteur.TR_IDTRANSPORTEUR = clsDonnee.vogDataReader["TR_IDTRANSPORTEUR"].ToString();
                    clsPhaTransporteur.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    clsPhaTransporteur.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    clsPhaTransporteur.TR_NUMTRANSPORTEUR = clsDonnee.vogDataReader["TR_NUMTRANSPORTEUR"].ToString();
                    clsPhaTransporteur.TR_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["TR_DATENAISSANCE"].ToString());
                    clsPhaTransporteur.TR_NOMPRENOM = clsDonnee.vogDataReader["TR_NOMPRENOM"].ToString();
                    clsPhaTransporteur.TR_ADRESSEPOSTALE = clsDonnee.vogDataReader["TR_ADRESSEPOSTALE"].ToString();
                    clsPhaTransporteur.TR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["TR_ADRESSEGEOGRAPHIQUE"].ToString();
                    clsPhaTransporteur.TR_TELEPHONE = clsDonnee.vogDataReader["TR_TELEPHONE"].ToString();
                    clsPhaTransporteur.TR_EMAIL = clsDonnee.vogDataReader["TR_EMAIL"].ToString();
                    clsPhaTransporteur.TR_STATUT = clsDonnee.vogDataReader["TR_STATUT"].ToString();
                    clsPhaTransporteur.TR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TR_DATESAISIE"].ToString());
                    clsPhaTransporteur.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                }
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaTransporteur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaTransporteur>clsPhaTransporteur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaTransporteur clsPhaTransporteur)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
            vppParamAG_CODEAGENCE.Value = clsPhaTransporteur.AG_CODEAGENCE;

            SqlParameter vppParamTR_IDTRANSPORTEUR = new SqlParameter("@TR_IDTRANSPORTEUR", SqlDbType.BigInt);
            vppParamTR_IDTRANSPORTEUR.Value = clsPhaTransporteur.TR_IDTRANSPORTEUR;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhaTransporteur.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhaTransporteur.SM_CODESITUATIONMATRIMONIALE;

            SqlParameter vppParamTR_NUMTRANSPORTEUR = new SqlParameter("@TR_NUMTRANSPORTEUR", SqlDbType.VarChar, 7);
            vppParamTR_NUMTRANSPORTEUR.Value = clsPhaTransporteur.TR_NUMTRANSPORTEUR;

            SqlParameter vppParamTR_DATENAISSANCE = new SqlParameter("@TR_DATENAISSANCE", SqlDbType.DateTime);
            vppParamTR_DATENAISSANCE.Value = clsPhaTransporteur.TR_DATENAISSANCE;
            if (clsPhaTransporteur.TR_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamTR_DATENAISSANCE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamTR_NOMPRENOM = new SqlParameter("@TR_NOMPRENOM", SqlDbType.VarChar, 150);
            vppParamTR_NOMPRENOM.Value = clsPhaTransporteur.TR_NOMPRENOM;

            SqlParameter vppParamTR_ADRESSEPOSTALE = new SqlParameter("@TR_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamTR_ADRESSEPOSTALE.Value = clsPhaTransporteur.TR_ADRESSEPOSTALE;

            SqlParameter vppParamTR_ADRESSEGEOGRAPHIQUE = new SqlParameter("@TR_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamTR_ADRESSEGEOGRAPHIQUE.Value = clsPhaTransporteur.TR_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamTR_TELEPHONE = new SqlParameter("@TR_TELEPHONE", SqlDbType.VarChar, 150);
            vppParamTR_TELEPHONE.Value = clsPhaTransporteur.TR_TELEPHONE;

            SqlParameter vppParamTR_EMAIL = new SqlParameter("@TR_EMAIL", SqlDbType.VarChar, 80);
            vppParamTR_EMAIL.Value = clsPhaTransporteur.TR_EMAIL;

            SqlParameter vppParamTR_STATUT = new SqlParameter("@TR_STATUT", SqlDbType.VarChar, 1);
            vppParamTR_STATUT.Value = clsPhaTransporteur.TR_STATUT;


            SqlParameter vppParamTR_DATESAISIE = new SqlParameter("@TR_DATESAISIE", SqlDbType.DateTime);
            vppParamTR_DATESAISIE.Value = clsPhaTransporteur.TR_DATESAISIE;
            if (clsPhaTransporteur.TR_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamTR_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhaTransporteur.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHATRANSPORTEUR  @AG_CODEAGENCE, @TR_IDTRANSPORTEUR, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @TR_NUMTRANSPORTEUR, @TR_DATENAISSANCE, @TR_NOMPRENOM, @TR_ADRESSEPOSTALE, @TR_ADRESSEGEOGRAPHIQUE, @TR_TELEPHONE, @TR_EMAIL, @TR_STATUT, @TR_DATESAISIE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTR_IDTRANSPORTEUR);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            vppSqlCmd.Parameters.Add(vppParamTR_NUMTRANSPORTEUR);
            vppSqlCmd.Parameters.Add(vppParamTR_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamTR_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamTR_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamTR_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamTR_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamTR_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamTR_STATUT);
            vppSqlCmd.Parameters.Add(vppParamTR_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaTransporteur>clsPhaTransporteur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaTransporteur clsPhaTransporteur,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhaTransporteur.AG_CODEAGENCE;

            SqlParameter vppParamTR_IDTRANSPORTEUR = new SqlParameter("@TR_IDTRANSPORTEUR", SqlDbType.BigInt);
            vppParamTR_IDTRANSPORTEUR.Value = clsPhaTransporteur.TR_IDTRANSPORTEUR;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhaTransporteur.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhaTransporteur.SM_CODESITUATIONMATRIMONIALE;

            SqlParameter vppParamTR_NUMTRANSPORTEUR = new SqlParameter("@TR_NUMTRANSPORTEUR", SqlDbType.VarChar, 7);
            vppParamTR_NUMTRANSPORTEUR.Value = clsPhaTransporteur.TR_NUMTRANSPORTEUR;

            SqlParameter vppParamTR_DATENAISSANCE = new SqlParameter("@TR_DATENAISSANCE", SqlDbType.DateTime);
            vppParamTR_DATENAISSANCE.Value = clsPhaTransporteur.TR_DATENAISSANCE;
            if (clsPhaTransporteur.TR_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamTR_DATENAISSANCE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamTR_NOMPRENOM = new SqlParameter("@TR_NOMPRENOM", SqlDbType.VarChar, 150);
            vppParamTR_NOMPRENOM.Value = clsPhaTransporteur.TR_NOMPRENOM;

            SqlParameter vppParamTR_ADRESSEPOSTALE = new SqlParameter("@TR_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamTR_ADRESSEPOSTALE.Value = clsPhaTransporteur.TR_ADRESSEPOSTALE;

            SqlParameter vppParamTR_ADRESSEGEOGRAPHIQUE = new SqlParameter("@TR_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamTR_ADRESSEGEOGRAPHIQUE.Value = clsPhaTransporteur.TR_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamTR_TELEPHONE = new SqlParameter("@TR_TELEPHONE", SqlDbType.VarChar, 150);
            vppParamTR_TELEPHONE.Value = clsPhaTransporteur.TR_TELEPHONE;

            SqlParameter vppParamTR_EMAIL = new SqlParameter("@TR_EMAIL", SqlDbType.VarChar, 80);
            vppParamTR_EMAIL.Value = clsPhaTransporteur.TR_EMAIL;

            SqlParameter vppParamTR_STATUT = new SqlParameter("@TR_STATUT", SqlDbType.VarChar, 1);
            vppParamTR_STATUT.Value = clsPhaTransporteur.TR_STATUT;


            SqlParameter vppParamTR_DATESAISIE = new SqlParameter("@TR_DATESAISIE", SqlDbType.DateTime);
            vppParamTR_DATESAISIE.Value = clsPhaTransporteur.TR_DATESAISIE;
            if (clsPhaTransporteur.TR_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamTR_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhaTransporteur.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHATRANSPORTEUR  @AG_CODEAGENCE, @TR_IDTRANSPORTEUR, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @TR_NUMTRANSPORTEUR, @TR_DATENAISSANCE, @TR_NOMPRENOM, @TR_ADRESSEPOSTALE, @TR_ADRESSEGEOGRAPHIQUE, @TR_TELEPHONE, @TR_EMAIL, @TR_STATUT, @TR_DATESAISIE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTR_IDTRANSPORTEUR);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            vppSqlCmd.Parameters.Add(vppParamTR_NUMTRANSPORTEUR);
            vppSqlCmd.Parameters.Add(vppParamTR_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamTR_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamTR_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamTR_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamTR_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamTR_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamTR_STATUT);
            vppSqlCmd.Parameters.Add(vppParamTR_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHATRANSPORTEUR "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaTransporteur </returns>
		///<author>Home Technology</author>
		public List<clsPhaTransporteur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TR_IDTRANSPORTEUR, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, TR_NUMTRANSPORTEUR, TR_DATENAISSANCE, TR_NOMPRENOM, TR_ADRESSEPOSTALE, TR_ADRESSEGEOGRAPHIQUE, TR_TELEPHONE, TR_EMAIL, TR_STATUT, TR_DATESAISIE, OP_CODEOPERATEUR FROM dbo.PHATRANSPORTEUR " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaTransporteur> clsPhaTransporteurs = new List<clsPhaTransporteur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaTransporteur clsPhaTransporteur = new clsPhaTransporteur();
					clsPhaTransporteur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhaTransporteur.TR_IDTRANSPORTEUR = clsDonnee.vogDataReader["TR_IDTRANSPORTEUR"].ToString();
					clsPhaTransporteur.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsPhaTransporteur.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhaTransporteur.TR_NUMTRANSPORTEUR = clsDonnee.vogDataReader["TR_NUMTRANSPORTEUR"].ToString();
					clsPhaTransporteur.TR_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["TR_DATENAISSANCE"].ToString());
					clsPhaTransporteur.TR_NOMPRENOM = clsDonnee.vogDataReader["TR_NOMPRENOM"].ToString();
					clsPhaTransporteur.TR_ADRESSEPOSTALE = clsDonnee.vogDataReader["TR_ADRESSEPOSTALE"].ToString();
					clsPhaTransporteur.TR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["TR_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaTransporteur.TR_TELEPHONE = clsDonnee.vogDataReader["TR_TELEPHONE"].ToString();
					clsPhaTransporteur.TR_EMAIL = clsDonnee.vogDataReader["TR_EMAIL"].ToString();
					clsPhaTransporteur.TR_STATUT = clsDonnee.vogDataReader["TR_STATUT"].ToString();
					clsPhaTransporteur.TR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TR_DATESAISIE"].ToString());
					clsPhaTransporteur.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhaTransporteurs.Add(clsPhaTransporteur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaTransporteurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaTransporteur </returns>
		///<author>Home Technology</author>
		public List<clsPhaTransporteur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaTransporteur> clsPhaTransporteurs = new List<clsPhaTransporteur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TR_IDTRANSPORTEUR, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, TR_NUMTRANSPORTEUR, TR_DATENAISSANCE, TR_NOMPRENOM, TR_ADRESSEPOSTALE, TR_ADRESSEGEOGRAPHIQUE, TR_TELEPHONE, TR_EMAIL, TR_STATUT, TR_DATESAISIE, OP_CODEOPERATEUR FROM dbo.PHATRANSPORTEUR " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaTransporteur clsPhaTransporteur = new clsPhaTransporteur();
					clsPhaTransporteur.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhaTransporteur.TR_IDTRANSPORTEUR = Dataset.Tables["TABLE"].Rows[Idx]["TR_IDTRANSPORTEUR"].ToString();
					clsPhaTransporteur.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
					clsPhaTransporteur.SM_CODESITUATIONMATRIMONIALE = Dataset.Tables["TABLE"].Rows[Idx]["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhaTransporteur.TR_NUMTRANSPORTEUR = Dataset.Tables["TABLE"].Rows[Idx]["TR_NUMTRANSPORTEUR"].ToString();
					clsPhaTransporteur.TR_DATENAISSANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TR_DATENAISSANCE"].ToString());
					clsPhaTransporteur.TR_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["TR_NOMPRENOM"].ToString();
					clsPhaTransporteur.TR_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["TR_ADRESSEPOSTALE"].ToString();
					clsPhaTransporteur.TR_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["TR_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaTransporteur.TR_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["TR_TELEPHONE"].ToString();
					clsPhaTransporteur.TR_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["TR_EMAIL"].ToString();
					clsPhaTransporteur.TR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["TR_STATUT"].ToString();
					clsPhaTransporteur.TR_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TR_DATESAISIE"].ToString());
					clsPhaTransporteur.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhaTransporteurs.Add(clsPhaTransporteur);
				}
				Dataset.Dispose();
			}
		return clsPhaTransporteurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHATRANSPORTEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TR_IDTRANSPORTEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , TR_NOMPRENOM FROM dbo.PHATRANSPORTEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, TR_IDTRANSPORTEUR)</summary>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TR_IDTRANSPORTEUR=@TR_IDTRANSPORTEUR";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TR_IDTRANSPORTEUR" };
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TR_NUMTRANSPORTEUR LIKE '%'+ @TR_NUMTRANSPORTEUR + '%' AND TR_STATUT ='N'";
                    vapNomParametre = new string[] {"@CODECRYPTAGE", "@AG_CODEAGENCE", "@TR_NUMTRANSPORTEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TR_NUMTRANSPORTEUR LIKE '%'+ @TR_NUMTRANSPORTEUR + '%' AND TR_NOMPRENOM LIKE '%'+ @TR_NOMPRENOM + '%' AND TR_STATUT ='N'";
                    vapNomParametre = new string[] {"@CODECRYPTAGE", "@AG_CODEAGENCE", "@TR_NUMTRANSPORTEUR", "@TR_NOMPRENOM" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }
    }
}
