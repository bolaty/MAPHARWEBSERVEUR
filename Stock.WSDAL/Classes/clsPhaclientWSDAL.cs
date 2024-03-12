using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaclientWSDAL: ITableDAL<clsPhaclient>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(CL_NUMCLIENT) AS CL_NUMCLIENT  FROM dbo.PHACLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(CL_IDCLIENT) AS CL_IDCLIENT  FROM dbo.PHACLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(CL_IDCLIENT) AS CL_IDCLIENT  FROM dbo.PHACLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		public string pvgValueScalarRequeteMax1(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(CL_NUMCLIENT) AS CL_NUMCLIENT  FROM dbo.PHACLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaclient comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaclient pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            this.vapRequete = "SELECT CL_IDCLIENT,CL_NUMCLIENT, SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE,PF_CODEPROFESSION,AC_CODEACTIVITE,TP_CODETYPECLIENT,CL_DATENAISSANCE,CL_DENOMINATION,CL_DESCRIPTIONCLIENT,CL_ADRESSEPOSTALE,CL_ADRESSEGEOGRAPHIQUE,CL_TELEPHONE,CL_FAX,CL_SITEWEB,CL_EMAIL,CL_GERANT,CL_STATUT,CL_DATESAISIE,CL_ASDI,CL_TVA,CL_STATUTDOUTEUX,CL_PLAFONDCREDIT,CL_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR FROM dbo.FT_PHACLIENT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaclient clsPhaclient = new clsPhaclient();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaclient.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    clsPhaclient.CL_IDCLIENT = clsDonnee.vogDataReader["CL_IDCLIENT"].ToString();
					clsPhaclient.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhaclient.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
					clsPhaclient.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
					clsPhaclient.TP_CODETYPECLIENT = clsDonnee.vogDataReader["TP_CODETYPECLIENT"].ToString();
					clsPhaclient.CL_NUMCLIENT = clsDonnee.vogDataReader["CL_NUMCLIENT"].ToString();
					clsPhaclient.CL_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["CL_DATENAISSANCE"].ToString());
					clsPhaclient.CL_DENOMINATION = clsDonnee.vogDataReader["CL_DENOMINATION"].ToString();
					clsPhaclient.CL_DESCRIPTIONCLIENT = clsDonnee.vogDataReader["CL_DESCRIPTIONCLIENT"].ToString();
					clsPhaclient.CL_ADRESSEPOSTALE = clsDonnee.vogDataReader["CL_ADRESSEPOSTALE"].ToString();
					clsPhaclient.CL_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["CL_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaclient.CL_TELEPHONE = clsDonnee.vogDataReader["CL_TELEPHONE"].ToString();
					clsPhaclient.CL_FAX = clsDonnee.vogDataReader["CL_FAX"].ToString();
					clsPhaclient.CL_SITEWEB = clsDonnee.vogDataReader["CL_SITEWEB"].ToString();
					clsPhaclient.CL_EMAIL = clsDonnee.vogDataReader["CL_EMAIL"].ToString();
					clsPhaclient.CL_GERANT = clsDonnee.vogDataReader["CL_GERANT"].ToString();
					clsPhaclient.CL_STATUT = clsDonnee.vogDataReader["CL_STATUT"].ToString();
					clsPhaclient.CL_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CL_DATESAISIE"].ToString());
					clsPhaclient.CL_ASDI = clsDonnee.vogDataReader["CL_ASDI"].ToString();
					clsPhaclient.CL_TVA = clsDonnee.vogDataReader["CL_TVA"].ToString();
                    //clsPhaclient.CL_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["CL_STATUTDOUTEUX"].ToString());
					clsPhaclient.CL_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["CL_PLAFONDCREDIT"].ToString());
					clsPhaclient.CL_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["CL_NUMCPTECONTIBUABLE"].ToString();
					clsPhaclient.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaclient;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaclient>clsPhaclient</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaclient clsPhaclient)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
            vppParamAG_CODEAGENCE.Value = clsPhaclient.AG_CODEAGENCE;

            SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.BigInt);
            vppParamCL_IDCLIENT.Value = clsPhaclient.CL_IDCLIENT;


            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhaclient.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhaclient.SM_CODESITUATIONMATRIMONIALE;
            if (clsPhaclient.SM_CODESITUATIONMATRIMONIALE == "")
                vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;


            SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            vppParamPF_CODEPROFESSION.Value = clsPhaclient.PF_CODEPROFESSION;
            if (clsPhaclient.PF_CODEPROFESSION == "")
                vppParamPF_CODEPROFESSION.Value = DBNull.Value;


            SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
            vppParamAC_CODEACTIVITE.Value = clsPhaclient.AC_CODEACTIVITE;
            if (clsPhaclient.AC_CODEACTIVITE == "")
                vppParamAC_CODEACTIVITE.Value = DBNull.Value;


            SqlParameter vppParamTP_CODETYPECLIENT = new SqlParameter("@TP_CODETYPECLIENT", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPECLIENT.Value = clsPhaclient.TP_CODETYPECLIENT;

            SqlParameter vppParamCL_NUMCLIENT = new SqlParameter("@CL_NUMCLIENT", SqlDbType.VarChar, 7);
            vppParamCL_NUMCLIENT.Value = clsPhaclient.CL_NUMCLIENT;

            SqlParameter vppParamCL_DATENAISSANCE = new SqlParameter("@CL_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCL_DATENAISSANCE.Value = clsPhaclient.CL_DATENAISSANCE;
            if (clsPhaclient.CL_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamCL_DATENAISSANCE.Value = "01/01/1900";

            SqlParameter vppParamCL_DENOMINATION = new SqlParameter("@CL_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamCL_DENOMINATION.Value = clsPhaclient.CL_DENOMINATION;

            SqlParameter vppParamCL_DESCRIPTIONCLIENT = new SqlParameter("@CL_DESCRIPTIONCLIENT", SqlDbType.VarChar, 150);
            vppParamCL_DESCRIPTIONCLIENT.Value = clsPhaclient.CL_DESCRIPTIONCLIENT;

            SqlParameter vppParamCL_ADRESSEPOSTALE = new SqlParameter("@CL_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamCL_ADRESSEPOSTALE.Value = clsPhaclient.CL_ADRESSEPOSTALE;

            SqlParameter vppParamCL_ADRESSEGEOGRAPHIQUE = new SqlParameter("@CL_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamCL_ADRESSEGEOGRAPHIQUE.Value = clsPhaclient.CL_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamCL_TELEPHONE = new SqlParameter("@CL_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamCL_TELEPHONE.Value = clsPhaclient.CL_TELEPHONE;

            SqlParameter vppParamCL_FAX = new SqlParameter("@CL_FAX", SqlDbType.VarChar, 80);
            vppParamCL_FAX.Value = clsPhaclient.CL_FAX;

            SqlParameter vppParamCL_SITEWEB = new SqlParameter("@CL_SITEWEB", SqlDbType.VarChar, 150);
            vppParamCL_SITEWEB.Value = clsPhaclient.CL_SITEWEB;

            SqlParameter vppParamCL_EMAIL = new SqlParameter("@CL_EMAIL", SqlDbType.VarChar, 80);
            vppParamCL_EMAIL.Value = clsPhaclient.CL_EMAIL;

            SqlParameter vppParamCL_GERANT = new SqlParameter("@CL_GERANT", SqlDbType.VarChar, 150);
            vppParamCL_GERANT.Value = clsPhaclient.CL_GERANT;

            //SqlParameter vppParamCL_STATUT = new SqlParameter("@CL_STATUT", SqlDbType.VarChar, 1);
            //vppParamCL_STATUT.Value = clsPhaclient.CL_STATUT;

            SqlParameter vppParamCL_DATESAISIE = new SqlParameter("@CL_DATESAISIE", SqlDbType.DateTime);
            vppParamCL_DATESAISIE.Value = clsPhaclient.CL_DATESAISIE;
            if (clsPhaclient.CL_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamCL_DATESAISIE.Value = "01/01/1900";

            SqlParameter vppParamCL_ASDI = new SqlParameter("@CL_ASDI", SqlDbType.VarChar, 1);
            vppParamCL_ASDI.Value = clsPhaclient.CL_ASDI;

            SqlParameter vppParamCL_TVA = new SqlParameter("@CL_TVA", SqlDbType.VarChar, 1);
            vppParamCL_TVA.Value = clsPhaclient.CL_TVA;

            SqlParameter vppParamCL_STATUTDOUTEUX = new SqlParameter("@CL_STATUTDOUTEUX", SqlDbType.Int);
            vppParamCL_STATUTDOUTEUX.Value = clsPhaclient.CL_STATUTDOUTEUX;

            SqlParameter vppParamCL_PLAFONDCREDIT = new SqlParameter("@CL_PLAFONDCREDIT", SqlDbType.Money);
            vppParamCL_PLAFONDCREDIT.Value = clsPhaclient.CL_PLAFONDCREDIT;

            SqlParameter vppParamCL_NUMCPTECONTIBUABLE = new SqlParameter("@CL_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
            vppParamCL_NUMCPTECONTIBUABLE.Value = clsPhaclient.CL_NUMCPTECONTIBUABLE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhaclient.OP_CODEOPERATEUR;
            SqlParameter vppParamCL_TAUXREMISE = new SqlParameter("@CL_TAUXREMISE", SqlDbType.Float);
            vppParamCL_TAUXREMISE.Value = clsPhaclient.CL_TAUXREMISE;

			//Préparation de la commande
            this.vapRequete = "INSERT INTO PHACLIENT (  AG_CODEAGENCE, CL_IDCLIENT, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, PF_CODEPROFESSION, AC_CODEACTIVITE, TP_CODETYPECLIENT, CL_NUMCLIENT, CL_DATENAISSANCE, CL_DENOMINATION, CL_DESCRIPTIONCLIENT, CL_ADRESSEPOSTALE, CL_ADRESSEGEOGRAPHIQUE, CL_TELEPHONE, CL_FAX, CL_SITEWEB, CL_EMAIL, CL_GERANT, CL_DATESAISIE, CL_ASDI, CL_TVA, CL_STATUTDOUTEUX, CL_PLAFONDCREDIT, CL_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR, CL_TAUXREMISE) " +
                     "VALUES ( @AG_CODEAGENCE, @CL_IDCLIENT, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @PF_CODEPROFESSION, @AC_CODEACTIVITE, @TP_CODETYPECLIENT, @CL_NUMCLIENT, @CL_DATENAISSANCE, @CL_DENOMINATION, @CL_DESCRIPTIONCLIENT, @CL_ADRESSEPOSTALE, @CL_ADRESSEGEOGRAPHIQUE, @CL_TELEPHONE, @CL_FAX, @CL_SITEWEB, @CL_EMAIL, @CL_GERANT, @CL_DATESAISIE, @CL_ASDI, @CL_TVA, @CL_STATUTDOUTEUX, @CL_PLAFONDCREDIT, @CL_NUMCPTECONTIBUABLE, @OP_CODEOPERATEUR, @CL_TAUXREMISE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCL_IDCLIENT);
			vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
			vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
			vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
			vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPECLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_NUMCLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_DATENAISSANCE);
			vppSqlCmd.Parameters.Add(vppParamCL_DENOMINATION);
			vppSqlCmd.Parameters.Add(vppParamCL_DESCRIPTIONCLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_ADRESSEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamCL_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamCL_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamCL_FAX);
			vppSqlCmd.Parameters.Add(vppParamCL_SITEWEB);
			vppSqlCmd.Parameters.Add(vppParamCL_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamCL_GERANT);
			vppSqlCmd.Parameters.Add(vppParamCL_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCL_ASDI);
			vppSqlCmd.Parameters.Add(vppParamCL_TVA);
			vppSqlCmd.Parameters.Add(vppParamCL_STATUTDOUTEUX);
			vppSqlCmd.Parameters.Add(vppParamCL_PLAFONDCREDIT);
			vppSqlCmd.Parameters.Add(vppParamCL_NUMCPTECONTIBUABLE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCL_TAUXREMISE);
			//Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhaclient>clsPhaclient</param>
        ///<author>Home Technology</author>
        public void pvgMiseajour(clsDonnee clsDonnee, clsPhaclient clsPhaclient)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaclient.AG_CODEAGENCE;

            SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.VarChar, 25);
            vppParamCL_IDCLIENT.Value = clsPhaclient.CL_IDCLIENT;


            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhaclient.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhaclient.SM_CODESITUATIONMATRIMONIALE;
            if (clsPhaclient.SM_CODESITUATIONMATRIMONIALE == "")
                vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;


            SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            vppParamPF_CODEPROFESSION.Value = clsPhaclient.PF_CODEPROFESSION;
            if (clsPhaclient.PF_CODEPROFESSION == "")
                vppParamPF_CODEPROFESSION.Value = DBNull.Value;


            SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
            vppParamAC_CODEACTIVITE.Value = clsPhaclient.AC_CODEACTIVITE;
            if (clsPhaclient.AC_CODEACTIVITE == "")
                vppParamAC_CODEACTIVITE.Value = DBNull.Value;


            SqlParameter vppParamTP_CODETYPECLIENT = new SqlParameter("@TP_CODETYPECLIENT", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPECLIENT.Value = clsPhaclient.TP_CODETYPECLIENT;

            SqlParameter vppParamCL_NUMCLIENT = new SqlParameter("@CL_NUMCLIENT", SqlDbType.VarChar, 50);
            vppParamCL_NUMCLIENT.Value = clsPhaclient.CL_NUMCLIENT;

            SqlParameter vppParamCL_DATENAISSANCE = new SqlParameter("@CL_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCL_DATENAISSANCE.Value = clsPhaclient.CL_DATENAISSANCE;
            if (clsPhaclient.CL_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamCL_DATENAISSANCE.Value = "01/01/1900";


            SqlParameter vppParamCL_DENOMINATION = new SqlParameter("@CL_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamCL_DENOMINATION.Value = clsPhaclient.CL_DENOMINATION;

            SqlParameter vppParamCL_DESCRIPTIONCLIENT = new SqlParameter("@CL_DESCRIPTIONCLIENT", SqlDbType.VarChar, 150);
            vppParamCL_DESCRIPTIONCLIENT.Value = clsPhaclient.CL_DESCRIPTIONCLIENT;

            SqlParameter vppParamCL_ADRESSEPOSTALE = new SqlParameter("@CL_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamCL_ADRESSEPOSTALE.Value = clsPhaclient.CL_ADRESSEPOSTALE;

            SqlParameter vppParamCL_ADRESSEGEOGRAPHIQUE = new SqlParameter("@CL_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamCL_ADRESSEGEOGRAPHIQUE.Value = clsPhaclient.CL_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamCL_TELEPHONE = new SqlParameter("@CL_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamCL_TELEPHONE.Value = clsPhaclient.CL_TELEPHONE;

            SqlParameter vppParamCL_FAX = new SqlParameter("@CL_FAX", SqlDbType.VarChar, 80);
            vppParamCL_FAX.Value = clsPhaclient.CL_FAX;

            SqlParameter vppParamCL_SITEWEB = new SqlParameter("@CL_SITEWEB", SqlDbType.VarChar, 150);
            vppParamCL_SITEWEB.Value = clsPhaclient.CL_SITEWEB;

            SqlParameter vppParamCL_EMAIL = new SqlParameter("@CL_EMAIL", SqlDbType.VarChar, 80);
            vppParamCL_EMAIL.Value = clsPhaclient.CL_EMAIL;

            SqlParameter vppParamCL_GERANT = new SqlParameter("@CL_GERANT", SqlDbType.VarChar, 150);
            vppParamCL_GERANT.Value = clsPhaclient.CL_GERANT;

            SqlParameter vppParamCL_STATUT = new SqlParameter("@CL_STATUT", SqlDbType.VarChar, 1);
            vppParamCL_STATUT.Value = clsPhaclient.CL_STATUT;

            SqlParameter vppParamCL_DATESAISIE = new SqlParameter("@CL_DATESAISIE", SqlDbType.DateTime);
            vppParamCL_DATESAISIE.Value = clsPhaclient.CL_DATESAISIE;
            if (clsPhaclient.CL_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamCL_DATESAISIE.Value = "01/01/1900";

            SqlParameter vppParamCL_DATEDEPART = new SqlParameter("@CL_DATEDEPART", SqlDbType.DateTime);
            vppParamCL_DATEDEPART.Value = clsPhaclient.CL_DATEDEPART;
            if (clsPhaclient.CL_DATEDEPART < DateTime.Parse("01/01/1900")) vppParamCL_DATEDEPART.Value = "01/01/1900";

            SqlParameter vppParamCL_ASDI = new SqlParameter("@CL_ASDI", SqlDbType.VarChar, 1);
            vppParamCL_ASDI.Value = clsPhaclient.CL_ASDI;

            SqlParameter vppParamCL_TVA = new SqlParameter("@CL_TVA", SqlDbType.VarChar, 1);
            vppParamCL_TVA.Value = clsPhaclient.CL_TVA;

            SqlParameter vppParamCL_STATUTDOUTEUX = new SqlParameter("@CL_STATUTDOUTEUX", SqlDbType.Int);
            vppParamCL_STATUTDOUTEUX.Value = clsPhaclient.CL_STATUTDOUTEUX;

            SqlParameter vppParamCL_PLAFONDCREDIT = new SqlParameter("@CL_PLAFONDCREDIT", SqlDbType.Money);
            vppParamCL_PLAFONDCREDIT.Value = clsPhaclient.CL_PLAFONDCREDIT;

            SqlParameter vppParamCL_NUMCPTECONTIBUABLE = new SqlParameter("@CL_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
            vppParamCL_NUMCPTECONTIBUABLE.Value = clsPhaclient.CL_NUMCPTECONTIBUABLE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhaclient.OP_CODEOPERATEUR;

            SqlParameter vppParamPH_PHOTO = new SqlParameter("@PH_PHOTO", SqlDbType.VarBinary);
            vppParamPH_PHOTO.Value = clsPhaclient.PH_PHOTO;
            if (clsPhaclient.PH_PHOTO == null) vppParamPH_PHOTO.Value = DBNull.Value;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPhaclient.PL_NUMCOMPTE;
            SqlParameter vppParamCL_TAUXREMISE = new SqlParameter("@CL_TAUXREMISE", SqlDbType.Float);
            vppParamCL_TAUXREMISE.Value = clsPhaclient.CL_TAUXREMISE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;



            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhaclient.TYPEOPERATION;



            //Préparation de la commande
            this.vapRequete = " EXECUTE [dbo].[PC_PHACLIENT]   @AG_CODEAGENCE, @CL_IDCLIENT, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @PF_CODEPROFESSION ,@AC_CODEACTIVITE, @TP_CODETYPECLIENT, @CL_NUMCLIENT,  @CL_DATENAISSANCE, @CL_DENOMINATION, @CL_DESCRIPTIONCLIENT, @CL_ADRESSEPOSTALE, @CL_ADRESSEGEOGRAPHIQUE, @CL_TELEPHONE, @CL_FAX, @CL_SITEWEB, @CL_EMAIL, @CL_GERANT, @CL_STATUT,  @CL_DATESAISIE, @CL_ASDI, @CL_TVA , @CL_STATUTDOUTEUX,  @CL_PLAFONDCREDIT,@CL_NUMCPTECONTIBUABLE,@OP_CODEOPERATEUR,@CL_DATEDEPART,@PH_PHOTO,@PL_NUMCOMPTE,@CL_TAUXREMISE,@CODECRYPTAGE,@TYPEOPERATION";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamCL_IDCLIENT);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
            vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPECLIENT);
            vppSqlCmd.Parameters.Add(vppParamCL_NUMCLIENT);
            vppSqlCmd.Parameters.Add(vppParamCL_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamCL_DENOMINATION);
            vppSqlCmd.Parameters.Add(vppParamCL_DESCRIPTIONCLIENT);
            vppSqlCmd.Parameters.Add(vppParamCL_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamCL_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamCL_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamCL_FAX);
            vppSqlCmd.Parameters.Add(vppParamCL_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamCL_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCL_GERANT);
            vppSqlCmd.Parameters.Add(vppParamCL_STATUT);
            vppSqlCmd.Parameters.Add(vppParamCL_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamCL_ASDI);
            vppSqlCmd.Parameters.Add(vppParamCL_TVA);
            vppSqlCmd.Parameters.Add(vppParamCL_STATUTDOUTEUX);
            vppSqlCmd.Parameters.Add(vppParamCL_PLAFONDCREDIT);
            vppSqlCmd.Parameters.Add(vppParamCL_NUMCPTECONTIBUABLE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCL_DATEDEPART);
            vppSqlCmd.Parameters.Add(vppParamPH_PHOTO);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCL_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }



		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaclient>clsPhaclient</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaclient clsPhaclient,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhaclient.SX_CODESEXE;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhaclient.SM_CODESITUATIONMATRIMONIALE;
            if (clsPhaclient.SM_CODESITUATIONMATRIMONIALE == "")
                vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;

            SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            vppParamPF_CODEPROFESSION.Value = clsPhaclient.PF_CODEPROFESSION;
            if (clsPhaclient.PF_CODEPROFESSION == "")
                vppParamPF_CODEPROFESSION.Value = DBNull.Value;

            SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
            vppParamAC_CODEACTIVITE.Value = clsPhaclient.AC_CODEACTIVITE;
            if (clsPhaclient.AC_CODEACTIVITE == "")
                vppParamAC_CODEACTIVITE.Value = DBNull.Value;

            SqlParameter vppParamTP_CODETYPECLIENT = new SqlParameter("@TP_CODETYPECLIENT", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPECLIENT.Value = clsPhaclient.TP_CODETYPECLIENT;

            SqlParameter vppParamCL_NUMCLIENT = new SqlParameter("@CL_NUMCLIENT", SqlDbType.VarChar, 7);
            vppParamCL_NUMCLIENT.Value = clsPhaclient.CL_NUMCLIENT;

            SqlParameter vppParamCL_DATENAISSANCE = new SqlParameter("@CL_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCL_DATENAISSANCE.Value = clsPhaclient.CL_DATENAISSANCE;
            if(clsPhaclient.CL_DATENAISSANCE<DateTime.Parse("01/01/1900")) vppParamCL_DATENAISSANCE.Value ="01/01/1900";

            SqlParameter vppParamCL_DENOMINATION = new SqlParameter("@CL_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamCL_DENOMINATION.Value = clsPhaclient.CL_DENOMINATION;

            SqlParameter vppParamCL_DESCRIPTIONCLIENT = new SqlParameter("@CL_DESCRIPTIONCLIENT", SqlDbType.VarChar, 150);
            vppParamCL_DESCRIPTIONCLIENT.Value = clsPhaclient.CL_DESCRIPTIONCLIENT;

            SqlParameter vppParamCL_ADRESSEPOSTALE = new SqlParameter("@CL_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamCL_ADRESSEPOSTALE.Value = clsPhaclient.CL_ADRESSEPOSTALE;

            SqlParameter vppParamCL_ADRESSEGEOGRAPHIQUE = new SqlParameter("@CL_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamCL_ADRESSEGEOGRAPHIQUE.Value = clsPhaclient.CL_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamCL_TELEPHONE = new SqlParameter("@CL_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamCL_TELEPHONE.Value = clsPhaclient.CL_TELEPHONE;

            SqlParameter vppParamCL_FAX = new SqlParameter("@CL_FAX", SqlDbType.VarChar, 80);
            vppParamCL_FAX.Value = clsPhaclient.CL_FAX;

            SqlParameter vppParamCL_SITEWEB = new SqlParameter("@CL_SITEWEB", SqlDbType.VarChar, 150);
            vppParamCL_SITEWEB.Value = clsPhaclient.CL_SITEWEB;

            SqlParameter vppParamCL_EMAIL = new SqlParameter("@CL_EMAIL", SqlDbType.VarChar, 80);
            vppParamCL_EMAIL.Value = clsPhaclient.CL_EMAIL;

            SqlParameter vppParamCL_GERANT = new SqlParameter("@CL_GERANT", SqlDbType.VarChar, 150);
            vppParamCL_GERANT.Value = clsPhaclient.CL_GERANT;

            //SqlParameter vppParamCL_STATUT = new SqlParameter("@CL_STATUT", SqlDbType.VarChar, 1);
            //vppParamCL_STATUT.Value = clsPhaclient.CL_STATUT;

            SqlParameter vppParamCL_DATESAISIE = new SqlParameter("@CL_DATESAISIE", SqlDbType.DateTime);
            vppParamCL_DATESAISIE.Value = clsPhaclient.CL_DATESAISIE;
            if (clsPhaclient.CL_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamCL_DATESAISIE.Value = "01/01/1900";


            SqlParameter vppParamCL_ASDI = new SqlParameter("@CL_ASDI", SqlDbType.VarChar, 1);
            vppParamCL_ASDI.Value = clsPhaclient.CL_ASDI;

            SqlParameter vppParamCL_TVA = new SqlParameter("@CL_TVA", SqlDbType.VarChar, 1);
            vppParamCL_TVA.Value = clsPhaclient.CL_TVA;

            SqlParameter vppParamCL_STATUTDOUTEUX = new SqlParameter("@CL_STATUTDOUTEUX", SqlDbType.Int);
            vppParamCL_STATUTDOUTEUX.Value = clsPhaclient.CL_STATUTDOUTEUX;

            SqlParameter vppParamCL_PLAFONDCREDIT = new SqlParameter("@CL_PLAFONDCREDIT", SqlDbType.Money);
            vppParamCL_PLAFONDCREDIT.Value = clsPhaclient.CL_PLAFONDCREDIT;

            SqlParameter vppParamCL_NUMCPTECONTIBUABLE = new SqlParameter("@CL_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
            vppParamCL_NUMCPTECONTIBUABLE.Value = clsPhaclient.CL_NUMCPTECONTIBUABLE;

			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
			vppParamOP_CODEOPERATEUR.Value  = clsPhaclient.OP_CODEOPERATEUR ;

			//Préparation de la commande
            pvpChoixCritere(clsDonnee, vppCritere); 
			 this.vapRequete = "UPDATE PHACLIENT SET " +
							"SX_CODESEXE = @SX_CODESEXE, "+
							"SM_CODESITUATIONMATRIMONIALE = @SM_CODESITUATIONMATRIMONIALE, "+
							"PF_CODEPROFESSION = @PF_CODEPROFESSION, "+
							"AC_CODEACTIVITE = @AC_CODEACTIVITE, "+
							"TP_CODETYPECLIENT = @TP_CODETYPECLIENT, "+
							"CL_NUMCLIENT = @CL_NUMCLIENT, "+
							"CL_DATENAISSANCE = @CL_DATENAISSANCE, "+
							"CL_DENOMINATION = @CL_DENOMINATION, "+
							"CL_DESCRIPTIONCLIENT = @CL_DESCRIPTIONCLIENT, "+
							"CL_ADRESSEPOSTALE = @CL_ADRESSEPOSTALE, "+
							"CL_ADRESSEGEOGRAPHIQUE = @CL_ADRESSEGEOGRAPHIQUE, "+
							"CL_TELEPHONE = @CL_TELEPHONE, "+
							"CL_FAX = @CL_FAX, "+
							"CL_SITEWEB = @CL_SITEWEB, "+
							"CL_EMAIL = @CL_EMAIL, "+
							"CL_GERANT = @CL_GERANT, "+
							"CL_DATESAISIE = @CL_DATESAISIE, "+
							"CL_ASDI = @CL_ASDI, "+
							"CL_TVA = @CL_TVA, "+
							"CL_STATUTDOUTEUX = @CL_STATUTDOUTEUX, "+
							"CL_PLAFONDCREDIT = @CL_PLAFONDCREDIT, "+
							"CL_NUMCPTECONTIBUABLE = @CL_NUMCPTECONTIBUABLE, "+
							"OP_CODEOPERATEUR = @OP_CODEOPERATEUR " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
			vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
			vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
			vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPECLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_NUMCLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_DATENAISSANCE);
			vppSqlCmd.Parameters.Add(vppParamCL_DENOMINATION);
			vppSqlCmd.Parameters.Add(vppParamCL_DESCRIPTIONCLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_ADRESSEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamCL_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamCL_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamCL_FAX);
			vppSqlCmd.Parameters.Add(vppParamCL_SITEWEB);
			vppSqlCmd.Parameters.Add(vppParamCL_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamCL_GERANT);
			vppSqlCmd.Parameters.Add(vppParamCL_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCL_ASDI);
			vppSqlCmd.Parameters.Add(vppParamCL_TVA);
			vppSqlCmd.Parameters.Add(vppParamCL_STATUTDOUTEUX);
			vppSqlCmd.Parameters.Add(vppParamCL_PLAFONDCREDIT);
			vppSqlCmd.Parameters.Add(vppParamCL_NUMCPTECONTIBUABLE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhaclient>clsPhaclient</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgMiseajourNumero(clsDonnee clsDonnee, clsPhaclient clsPhaclient)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaclient.AG_CODEAGENCE;

            SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.VarChar, 25);
            vppParamCL_IDCLIENT.Value = clsPhaclient.CL_IDCLIENT;


            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsPhaclient.SX_CODESEXE;
            if (clsPhaclient.SX_CODESEXE == "")
                vppParamSX_CODESEXE.Value = DBNull.Value;

            SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsPhaclient.SM_CODESITUATIONMATRIMONIALE;
            if (clsPhaclient.SM_CODESITUATIONMATRIMONIALE == "")
                vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;


            SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            vppParamPF_CODEPROFESSION.Value = clsPhaclient.PF_CODEPROFESSION;
            if (clsPhaclient.PF_CODEPROFESSION == "")
                vppParamPF_CODEPROFESSION.Value = DBNull.Value;


            SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
            vppParamAC_CODEACTIVITE.Value = clsPhaclient.AC_CODEACTIVITE;
            if (clsPhaclient.AC_CODEACTIVITE == "")
                vppParamAC_CODEACTIVITE.Value = DBNull.Value;


            SqlParameter vppParamTP_CODETYPECLIENT = new SqlParameter("@TP_CODETYPECLIENT", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPECLIENT.Value = clsPhaclient.TP_CODETYPECLIENT;
            if (clsPhaclient.TP_CODETYPECLIENT == "")
                vppParamTP_CODETYPECLIENT.Value = DBNull.Value;

            SqlParameter vppParamCL_NUMCLIENT = new SqlParameter("@CL_NUMCLIENT", SqlDbType.VarChar, 50);
            vppParamCL_NUMCLIENT.Value = clsPhaclient.CL_NUMCLIENT;

            SqlParameter vppParamCL_DATENAISSANCE = new SqlParameter("@CL_DATENAISSANCE", SqlDbType.DateTime);
            vppParamCL_DATENAISSANCE.Value = clsPhaclient.CL_DATENAISSANCE;
            if (clsPhaclient.CL_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamCL_DATENAISSANCE.Value = "01/01/1900";


            SqlParameter vppParamCL_DENOMINATION = new SqlParameter("@CL_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamCL_DENOMINATION.Value = clsPhaclient.CL_DENOMINATION;
            if (clsPhaclient.CL_DENOMINATION == "")
                vppParamCL_DENOMINATION.Value = DBNull.Value;

            SqlParameter vppParamCL_DESCRIPTIONCLIENT = new SqlParameter("@CL_DESCRIPTIONCLIENT", SqlDbType.VarChar, 150);
            vppParamCL_DESCRIPTIONCLIENT.Value = clsPhaclient.CL_DESCRIPTIONCLIENT;
            if (clsPhaclient.CL_DESCRIPTIONCLIENT == "")
                vppParamCL_DESCRIPTIONCLIENT.Value = DBNull.Value;

            SqlParameter vppParamCL_ADRESSEPOSTALE = new SqlParameter("@CL_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamCL_ADRESSEPOSTALE.Value = clsPhaclient.CL_ADRESSEPOSTALE;
            if (clsPhaclient.CL_ADRESSEPOSTALE == "")
                vppParamCL_ADRESSEPOSTALE.Value = DBNull.Value;

            SqlParameter vppParamCL_ADRESSEGEOGRAPHIQUE = new SqlParameter("@CL_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamCL_ADRESSEGEOGRAPHIQUE.Value = clsPhaclient.CL_ADRESSEGEOGRAPHIQUE;
            if (clsPhaclient.CL_ADRESSEGEOGRAPHIQUE == "")
                vppParamCL_ADRESSEGEOGRAPHIQUE.Value = DBNull.Value;

            SqlParameter vppParamCL_TELEPHONE = new SqlParameter("@CL_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamCL_TELEPHONE.Value = clsPhaclient.CL_TELEPHONE;
            if (clsPhaclient.CL_TELEPHONE == "")
                vppParamCL_TELEPHONE.Value = DBNull.Value;

            SqlParameter vppParamCL_FAX = new SqlParameter("@CL_FAX", SqlDbType.VarChar, 80);
            vppParamCL_FAX.Value = clsPhaclient.CL_FAX;
            if (clsPhaclient.CL_FAX == "")
                vppParamCL_FAX.Value = DBNull.Value;

            SqlParameter vppParamCL_SITEWEB = new SqlParameter("@CL_SITEWEB", SqlDbType.VarChar, 150);
            vppParamCL_SITEWEB.Value = clsPhaclient.CL_SITEWEB;
            if (clsPhaclient.CL_SITEWEB == "")
                vppParamCL_SITEWEB.Value = DBNull.Value;

            SqlParameter vppParamCL_EMAIL = new SqlParameter("@CL_EMAIL", SqlDbType.VarChar, 80);
            vppParamCL_EMAIL.Value = clsPhaclient.CL_EMAIL;
            if (clsPhaclient.CL_EMAIL == "")
                vppParamCL_EMAIL.Value = DBNull.Value;

            SqlParameter vppParamCL_GERANT = new SqlParameter("@CL_GERANT", SqlDbType.VarChar, 150);
            vppParamCL_GERANT.Value = clsPhaclient.CL_GERANT;
            if (clsPhaclient.CL_GERANT == "")
                vppParamCL_GERANT.Value = DBNull.Value;

            SqlParameter vppParamCL_STATUT = new SqlParameter("@CL_STATUT", SqlDbType.VarChar, 1);
            vppParamCL_STATUT.Value = clsPhaclient.CL_STATUT;
            if (clsPhaclient.CL_STATUT == "")
                vppParamCL_STATUT.Value = DBNull.Value;

            SqlParameter vppParamCL_DATESAISIE = new SqlParameter("@CL_DATESAISIE", SqlDbType.DateTime);
            vppParamCL_DATESAISIE.Value = clsPhaclient.CL_DATESAISIE;
            if (clsPhaclient.CL_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamCL_DATESAISIE.Value = "01/01/1900";

            SqlParameter vppParamCL_DATEDEPART = new SqlParameter("@CL_DATEDEPART", SqlDbType.DateTime);
            vppParamCL_DATEDEPART.Value = clsPhaclient.CL_DATEDEPART;
            if (clsPhaclient.CL_DATEDEPART < DateTime.Parse("01/01/1900")) vppParamCL_DATEDEPART.Value = "01/01/1900";

            SqlParameter vppParamCL_ASDI = new SqlParameter("@CL_ASDI", SqlDbType.VarChar, 1);
            vppParamCL_ASDI.Value = clsPhaclient.CL_ASDI;
            if (clsPhaclient.CL_ASDI == "")
                vppParamCL_ASDI.Value = DBNull.Value;

            SqlParameter vppParamCL_TVA = new SqlParameter("@CL_TVA", SqlDbType.VarChar, 1);
            vppParamCL_TVA.Value = clsPhaclient.CL_TVA;
            if (clsPhaclient.CL_TVA == "")
                vppParamCL_TVA.Value = DBNull.Value;

            SqlParameter vppParamCL_STATUTDOUTEUX = new SqlParameter("@CL_STATUTDOUTEUX", SqlDbType.Int);
            vppParamCL_STATUTDOUTEUX.Value = clsPhaclient.CL_STATUTDOUTEUX;
           

            SqlParameter vppParamCL_PLAFONDCREDIT = new SqlParameter("@CL_PLAFONDCREDIT", SqlDbType.Money);
            vppParamCL_PLAFONDCREDIT.Value = clsPhaclient.CL_PLAFONDCREDIT;

            SqlParameter vppParamCL_NUMCPTECONTIBUABLE = new SqlParameter("@CL_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
            vppParamCL_NUMCPTECONTIBUABLE.Value = clsPhaclient.CL_NUMCPTECONTIBUABLE;
            if (clsPhaclient.CL_NUMCPTECONTIBUABLE == "")
                vppParamCL_NUMCPTECONTIBUABLE.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsPhaclient.OP_CODEOPERATEUR;
            if (clsPhaclient.OP_CODEOPERATEUR == "")
                vppParamOP_CODEOPERATEUR.Value = DBNull.Value;

            SqlParameter vppParamPH_PHOTO = new SqlParameter("@PH_PHOTO", SqlDbType.VarBinary);
            vppParamPH_PHOTO.Value = clsPhaclient.PH_PHOTO;
            if (clsPhaclient.PH_PHOTO == null) vppParamPH_PHOTO.Value = DBNull.Value;
            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPhaclient.PL_NUMCOMPTE;

            SqlParameter vppParamCL_TAUXREMISE = new SqlParameter("@CL_TAUXREMISE", SqlDbType.Float);
            vppParamCL_TAUXREMISE.Value = clsPhaclient.CL_TAUXREMISE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;



            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhaclient.TYPEOPERATION;



            //Préparation de la commande
            this.vapRequete = " EXECUTE [dbo].[PC_PHACLIENT]   @AG_CODEAGENCE, @CL_IDCLIENT, @SX_CODESEXE, @SM_CODESITUATIONMATRIMONIALE, @PF_CODEPROFESSION ,@AC_CODEACTIVITE, @TP_CODETYPECLIENT, @CL_NUMCLIENT,  @CL_DATENAISSANCE, @CL_DENOMINATION, @CL_DESCRIPTIONCLIENT, @CL_ADRESSEPOSTALE, @CL_ADRESSEGEOGRAPHIQUE, @CL_TELEPHONE, @CL_FAX, @CL_SITEWEB, @CL_EMAIL, @CL_GERANT, @CL_STATUT,  @CL_DATESAISIE, @CL_ASDI, @CL_TVA , @CL_STATUTDOUTEUX,  @CL_PLAFONDCREDIT,@CL_NUMCPTECONTIBUABLE,@OP_CODEOPERATEUR,@CL_DATEDEPART,@PH_PHOTO,@PL_NUMCOMPTE,@CL_TAUXREMISE,@CODECRYPTAGE,@TYPEOPERATION";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamCL_IDCLIENT);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
            vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPECLIENT);
            vppSqlCmd.Parameters.Add(vppParamCL_NUMCLIENT);
            vppSqlCmd.Parameters.Add(vppParamCL_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamCL_DENOMINATION);
            vppSqlCmd.Parameters.Add(vppParamCL_DESCRIPTIONCLIENT);
            vppSqlCmd.Parameters.Add(vppParamCL_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamCL_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamCL_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamCL_FAX);
            vppSqlCmd.Parameters.Add(vppParamCL_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamCL_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCL_GERANT);
            vppSqlCmd.Parameters.Add(vppParamCL_STATUT);
            vppSqlCmd.Parameters.Add(vppParamCL_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamCL_ASDI);
            vppSqlCmd.Parameters.Add(vppParamCL_TVA);
            vppSqlCmd.Parameters.Add(vppParamCL_STATUTDOUTEUX);
            vppSqlCmd.Parameters.Add(vppParamCL_PLAFONDCREDIT);
            vppSqlCmd.Parameters.Add(vppParamCL_NUMCPTECONTIBUABLE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCL_DATEDEPART);
            vppSqlCmd.Parameters.Add(vppParamPH_PHOTO);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCL_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHACLIENT "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaclient </returns>
		///<author>Home Technology</author>
		public List<clsPhaclient> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, CL_IDCLIENT, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, PF_CODEPROFESSION, AC_CODEACTIVITE, TP_CODETYPECLIENT, CL_NUMCLIENT, CL_DATENAISSANCE, CL_DENOMINATION, CL_DESCRIPTIONCLIENT, CL_ADRESSEPOSTALE, CL_ADRESSEGEOGRAPHIQUE, CL_TELEPHONE, CL_FAX, CL_SITEWEB, CL_EMAIL, CL_GERANT, CL_STATUT, CL_DATESAISIE, CL_ASDI, CL_TVA, CL_STATUTDOUTEUX, CL_PLAFONDCREDIT, CL_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR FROM dbo.FT_PHACLIENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaclient> clsPhaclients = new List<clsPhaclient>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaclient clsPhaclient = new clsPhaclient();
					clsPhaclient.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhaclient.CL_IDCLIENT = clsDonnee.vogDataReader["CL_IDCLIENT"].ToString();
					clsPhaclient.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsPhaclient.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhaclient.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
					clsPhaclient.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
					clsPhaclient.TP_CODETYPECLIENT = clsDonnee.vogDataReader["TP_CODETYPECLIENT"].ToString();
					clsPhaclient.CL_NUMCLIENT = clsDonnee.vogDataReader["CL_NUMCLIENT"].ToString();
					clsPhaclient.CL_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["CL_DATENAISSANCE"].ToString());
					clsPhaclient.CL_DENOMINATION = clsDonnee.vogDataReader["CL_DENOMINATION"].ToString();
					clsPhaclient.CL_DESCRIPTIONCLIENT = clsDonnee.vogDataReader["CL_DESCRIPTIONCLIENT"].ToString();
					clsPhaclient.CL_ADRESSEPOSTALE = clsDonnee.vogDataReader["CL_ADRESSEPOSTALE"].ToString();
					clsPhaclient.CL_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["CL_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaclient.CL_TELEPHONE = clsDonnee.vogDataReader["CL_TELEPHONE"].ToString();
					clsPhaclient.CL_FAX = clsDonnee.vogDataReader["CL_FAX"].ToString();
					clsPhaclient.CL_SITEWEB = clsDonnee.vogDataReader["CL_SITEWEB"].ToString();
					clsPhaclient.CL_EMAIL = clsDonnee.vogDataReader["CL_EMAIL"].ToString();
					clsPhaclient.CL_GERANT = clsDonnee.vogDataReader["CL_GERANT"].ToString();
					clsPhaclient.CL_STATUT = clsDonnee.vogDataReader["CL_STATUT"].ToString();
					clsPhaclient.CL_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CL_DATESAISIE"].ToString());
					clsPhaclient.CL_ASDI = clsDonnee.vogDataReader["CL_ASDI"].ToString();
					clsPhaclient.CL_TVA = clsDonnee.vogDataReader["CL_TVA"].ToString();
                    //clsPhaclient.CL_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["CL_STATUTDOUTEUX"].ToString());
					clsPhaclient.CL_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["CL_PLAFONDCREDIT"].ToString());
					clsPhaclient.CL_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["CL_NUMCPTECONTIBUABLE"].ToString();
					clsPhaclient.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhaclients.Add(clsPhaclient);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaclient </returns>
		///<author>Home Technology</author>
		public List<clsPhaclient> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaclient> clsPhaclients = new List<clsPhaclient>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, CL_IDCLIENT, SX_CODESEXE, SM_CODESITUATIONMATRIMONIALE, PF_CODEPROFESSION, AC_CODEACTIVITE, TP_CODETYPECLIENT, CL_NUMCLIENT, CL_DATENAISSANCE, CL_DENOMINATION, CL_DESCRIPTIONCLIENT, CL_ADRESSEPOSTALE, CL_ADRESSEGEOGRAPHIQUE, CL_TELEPHONE, CL_FAX, CL_SITEWEB, CL_EMAIL, CL_GERANT, CL_STATUT, CL_DATESAISIE, CL_ASDI, CL_TVA, CL_STATUTDOUTEUX, CL_PLAFONDCREDIT, CL_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR FROM dbo.FT_PHACLIENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaclient clsPhaclient = new clsPhaclient();
					clsPhaclient.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhaclient.CL_IDCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
					clsPhaclient.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
					clsPhaclient.SM_CODESITUATIONMATRIMONIALE = Dataset.Tables["TABLE"].Rows[Idx]["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsPhaclient.PF_CODEPROFESSION = Dataset.Tables["TABLE"].Rows[Idx]["PF_CODEPROFESSION"].ToString();
					clsPhaclient.AC_CODEACTIVITE = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEACTIVITE"].ToString();
					clsPhaclient.TP_CODETYPECLIENT = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPECLIENT"].ToString();
					clsPhaclient.CL_NUMCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_NUMCLIENT"].ToString();
					clsPhaclient.CL_DATENAISSANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CL_DATENAISSANCE"].ToString());
					clsPhaclient.CL_DENOMINATION = Dataset.Tables["TABLE"].Rows[Idx]["CL_DENOMINATION"].ToString();
					clsPhaclient.CL_DESCRIPTIONCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_DESCRIPTIONCLIENT"].ToString();
					clsPhaclient.CL_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["CL_ADRESSEPOSTALE"].ToString();
					clsPhaclient.CL_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["CL_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaclient.CL_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["CL_TELEPHONE"].ToString();
					clsPhaclient.CL_FAX = Dataset.Tables["TABLE"].Rows[Idx]["CL_FAX"].ToString();
					clsPhaclient.CL_SITEWEB = Dataset.Tables["TABLE"].Rows[Idx]["CL_SITEWEB"].ToString();
					clsPhaclient.CL_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["CL_EMAIL"].ToString();
					clsPhaclient.CL_GERANT = Dataset.Tables["TABLE"].Rows[Idx]["CL_GERANT"].ToString();
					clsPhaclient.CL_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["CL_STATUT"].ToString();
					clsPhaclient.CL_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CL_DATESAISIE"].ToString());
					clsPhaclient.CL_ASDI = Dataset.Tables["TABLE"].Rows[Idx]["CL_ASDI"].ToString();
					clsPhaclient.CL_TVA = Dataset.Tables["TABLE"].Rows[Idx]["CL_TVA"].ToString();
					clsPhaclient.CL_STATUTDOUTEUX = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CL_STATUTDOUTEUX"].ToString());
					clsPhaclient.CL_PLAFONDCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CL_PLAFONDCREDIT"].ToString());
					clsPhaclient.CL_NUMCPTECONTIBUABLE = Dataset.Tables["TABLE"].Rows[Idx]["CL_NUMCPTECONTIBUABLE"].ToString();
					clsPhaclient.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhaclients.Add(clsPhaclient);
				}
				Dataset.Dispose();
			}
		return clsPhaclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            //this.vapRequete = "SELECT *  FROM dbo.PHACLIENT " + this.vapCritere;
            this.vapRequete = "SELECT *  FROM dbo.FT_PHACLIENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgChargerRechercheClientparNom(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            //vapNomParametre = new string[] { "@CODECRYPTAGE" };
            //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT *  FROM dbo.FT_PHACLIENT(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
		

		public DataSet pvgChargerDansDataSetRecherche(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHACLIENT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		public DataSet pvgChargerDansDataSetParSexe(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere2(clsDonnee,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHACLIENT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet vlpDataset = new DataSet();
            vlpDataset =clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
            return vlpDataset;
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , SX_CODESEXE FROM dbo.FT_PHACLIENT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage};
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT = 'N'";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_IDCLIENT=@CL_IDCLIENT AND CL_STATUT = 'N'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CL_IDCLIENT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_IDCLIENT=@CL_IDCLIENT AND TP_CODETYPECLIENT=@TP_CODETYPECLIENT AND CL_STATUT = 'N'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CL_IDCLIENT", "@TP_CODETYPECLIENT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
				break;
			}
		}

        public void pvpChoixCritereRecherche(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT = 'N'";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_NUMCLIENT=@CL_NUMCLIENT AND CL_STATUT = 'N'";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@CL_NUMCLIENT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_NUMCLIENT like '%'+ @CL_NUMCLIENT +'%' AND CL_DENOMINATION like '%'+ @CL_DENOMINATION +'%' AND CL_STATUT = 'N'";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@CL_NUMCLIENT", "@CL_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT = 'N'";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_IDCLIENT=@CL_IDCLIENT AND CL_STATUT = 'N'";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@CL_IDCLIENT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_NUMCLIENT LIKE '%'+@CL_NUMCLIENT+'%' AND CL_DENOMINATION LIKE '%'+@CL_DENOMINATION+'%' AND CL_STATUT = 'N'";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@CL_NUMCLIENT", "@CL_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
				break;
			}
		}

		public void pvpChoixCritere2( clsDonnee clsDonnee,params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, };
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CL_STATUT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT AND SX_CODESEXE IN ( " + clsDonnee.pvpParametreIN(vppCritere[2], "SX_CODESEXE") + " ) ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CL_STATUT", "@SX_CODESEXE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[2], 3, "SX_CODESEXE");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 3, "SX_CODESEXE");
				break;

                case 4:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT AND SX_CODESEXE IN ( " + clsDonnee.pvpParametreIN(vppCritere[2], "SX_CODESEXE") + " ) AND CL_NUMCLIENT LIKE @CL_NUMCLIENT'%' ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CL_STATUT", "@SX_CODESEXE", "@CL_NUMCLIENT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[2], 3, "SX_CODESEXE");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 3, "SX_CODESEXE");
                break;

                case 5:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT AND SX_CODESEXE IN ( " + clsDonnee.pvpParametreIN(vppCritere[2], "SX_CODESEXE") + " ) AND CL_NUMCLIENT LIKE @CL_NUMCLIENT'%'AND CL_DENOMINATION LIKE @CL_DENOMINATION'%' ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CL_STATUT", "@SX_CODESEXE", "@CL_NUMCLIENT", "@CL_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[2], 3, "SX_CODESEXE");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 3, "SX_CODESEXE");
                break;


                case 7:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT AND CL_NUMCLIENT LIKE '%'+@CL_NUMCLIENT+'%' AND CL_DENOMINATION LIKE '%'+@CL_DENOMINATION+'%' AND CL_DATESAISIE BETWEEN @DATE1 AND @DATE2 AND SX_CODESEXE IN ( " + clsDonnee.pvpParametreIN(vppCritere[6], "SX_CODESEXE") + " )  ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CL_STATUT=@CL_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CL_STATUT", "@CL_NUMCLIENT", "@CL_DENOMINATION", "@DATE1", "@DATE2", "@SX_CODESEXE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] , vppCritere[6] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                break;

			}
		}


	}
}
