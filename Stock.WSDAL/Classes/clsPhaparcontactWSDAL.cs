using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparcontactWSDAL: ITableDAL<clsPhaparcontact>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(CT_CODECONTACT) AS CT_CODECONTACT  FROM dbo.FT_COMPTAPAR_CONTACT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(CT_CODECONTACT) AS CT_CODECONTACT  FROM dbo.FT_COMPTAPAR_CONTACT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(CT_CODECONTACT) AS CT_CODECONTACT  FROM dbo.FT_COMPTAPAR_CONTACT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparcontact comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparcontact pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT CT_NOM  , CT_PRENOM  , SR_CODESERVICE  , CT_FONCTION  , TC_CODETYPECONTACT  , CT_TELEPHONE  , CT_PORTABLE  , CT_FAX  , CT_EMAIL  , TP_CODETYPEPERSONNE, AB_CODEAGENCEBANCAIRE  FROM dbo.FT_COMPTAPAR_CONTACT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparcontact clsPhaparcontact = new clsPhaparcontact();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparcontact.CT_NOM = clsDonnee.vogDataReader["CT_NOM"].ToString();
					clsPhaparcontact.CT_PRENOM = clsDonnee.vogDataReader["CT_PRENOM"].ToString();
					clsPhaparcontact.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsPhaparcontact.CT_FONCTION = clsDonnee.vogDataReader["CT_FONCTION"].ToString();
					clsPhaparcontact.TC_CODETYPECONTACT = clsDonnee.vogDataReader["TC_CODETYPECONTACT"].ToString();
					clsPhaparcontact.CT_TELEPHONE = clsDonnee.vogDataReader["CT_TELEPHONE"].ToString();
					clsPhaparcontact.CT_PORTABLE = clsDonnee.vogDataReader["CT_PORTABLE"].ToString();
					clsPhaparcontact.CT_FAX = clsDonnee.vogDataReader["CT_FAX"].ToString();
					clsPhaparcontact.CT_EMAIL = clsDonnee.vogDataReader["CT_EMAIL"].ToString();
					clsPhaparcontact.TP_CODETYPEPERSONNE = clsDonnee.vogDataReader["TP_CODETYPEPERSONNE"].ToString();
                    clsPhaparcontact.AB_CODEAGENCEBANCAIRE = clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparcontact;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparcontact>clsPhaparcontact</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparcontact clsPhaparcontact)
		{
			//Préparation des paramètres
			SqlParameter vppParamCT_CODECONTACT = new SqlParameter("@CT_CODECONTACT", SqlDbType.VarChar, 7);
			vppParamCT_CODECONTACT.Value  = clsPhaparcontact.CT_CODECONTACT ;
			SqlParameter vppParamCT_NOM = new SqlParameter("@CT_NOM", SqlDbType.VarChar, 150);
			vppParamCT_NOM.Value  = clsPhaparcontact.CT_NOM ;
			if(clsPhaparcontact.CT_NOM== ""  ) vppParamCT_NOM.Value  = DBNull.Value;
			SqlParameter vppParamCT_PRENOM = new SqlParameter("@CT_PRENOM", SqlDbType.VarChar, 150);
			vppParamCT_PRENOM.Value  = clsPhaparcontact.CT_PRENOM ;
			if(clsPhaparcontact.CT_PRENOM== ""  ) vppParamCT_PRENOM.Value  = DBNull.Value;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsPhaparcontact.SR_CODESERVICE ;
			if(clsPhaparcontact.SR_CODESERVICE== ""  ) vppParamSR_CODESERVICE.Value  = DBNull.Value;
			SqlParameter vppParamCT_FONCTION = new SqlParameter("@CT_FONCTION", SqlDbType.VarChar, 150);
			vppParamCT_FONCTION.Value  = clsPhaparcontact.CT_FONCTION ;
			if(clsPhaparcontact.CT_FONCTION== ""  ) vppParamCT_FONCTION.Value  = DBNull.Value;
			SqlParameter vppParamTC_CODETYPECONTACT = new SqlParameter("@TC_CODETYPECONTACT", SqlDbType.VarChar, 2);
			vppParamTC_CODETYPECONTACT.Value  = clsPhaparcontact.TC_CODETYPECONTACT ;
			if(clsPhaparcontact.TC_CODETYPECONTACT== ""  ) vppParamTC_CODETYPECONTACT.Value  = DBNull.Value;
			SqlParameter vppParamCT_TELEPHONE = new SqlParameter("@CT_TELEPHONE", SqlDbType.VarChar, 50);
			vppParamCT_TELEPHONE.Value  = clsPhaparcontact.CT_TELEPHONE ;
			if(clsPhaparcontact.CT_TELEPHONE== ""  ) vppParamCT_TELEPHONE.Value  = DBNull.Value;
			SqlParameter vppParamCT_PORTABLE = new SqlParameter("@CT_PORTABLE", SqlDbType.VarChar, 50);
			vppParamCT_PORTABLE.Value  = clsPhaparcontact.CT_PORTABLE ;
			if(clsPhaparcontact.CT_PORTABLE== ""  ) vppParamCT_PORTABLE.Value  = DBNull.Value;
			SqlParameter vppParamCT_FAX = new SqlParameter("@CT_FAX", SqlDbType.VarChar, 50);
			vppParamCT_FAX.Value  = clsPhaparcontact.CT_FAX ;
			if(clsPhaparcontact.CT_FAX== ""  ) vppParamCT_FAX.Value  = DBNull.Value;
			SqlParameter vppParamCT_EMAIL = new SqlParameter("@CT_EMAIL", SqlDbType.VarChar, 150);
			vppParamCT_EMAIL.Value  = clsPhaparcontact.CT_EMAIL ;
			if(clsPhaparcontact.CT_EMAIL== ""  ) vppParamCT_EMAIL.Value  = DBNull.Value;

			SqlParameter vppParamTP_CODETYPEPERSONNE = new SqlParameter("@TP_CODETYPEPERSONNE", SqlDbType.VarChar, 2);
			vppParamTP_CODETYPEPERSONNE.Value  = clsPhaparcontact.TP_CODETYPEPERSONNE ;
			if(clsPhaparcontact.TP_CODETYPEPERSONNE== ""  ) vppParamTP_CODETYPEPERSONNE.Value  = DBNull.Value;

            SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.Int);
            vppParamAB_CODEAGENCEBANCAIRE.Value = clsPhaparcontact.AB_CODEAGENCEBANCAIRE;
            if (clsPhaparcontact.AB_CODEAGENCEBANCAIRE == "") vppParamAB_CODEAGENCEBANCAIRE.Value = DBNull.Value;


			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_CONTACT  @CT_CODECONTACT, @CT_NOM, @CT_PRENOM, @SR_CODESERVICE, @CT_FONCTION, @TC_CODETYPECONTACT, @CT_TELEPHONE, @CT_PORTABLE, @CT_FAX, @CT_EMAIL, @TP_CODETYPEPERSONNE, @AB_CODEAGENCEBANCAIRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCT_CODECONTACT);
			vppSqlCmd.Parameters.Add(vppParamCT_NOM);
			vppSqlCmd.Parameters.Add(vppParamCT_PRENOM);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamCT_FONCTION);
			vppSqlCmd.Parameters.Add(vppParamTC_CODETYPECONTACT);
			vppSqlCmd.Parameters.Add(vppParamCT_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamCT_PORTABLE);
			vppSqlCmd.Parameters.Add(vppParamCT_FAX);
			vppSqlCmd.Parameters.Add(vppParamCT_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPERSONNE);
            vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparcontact>clsPhaparcontact</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparcontact clsPhaparcontact,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCT_CODECONTACT = new SqlParameter("@CT_CODECONTACT", SqlDbType.VarChar, 7);
			vppParamCT_CODECONTACT.Value  = clsPhaparcontact.CT_CODECONTACT ;
			SqlParameter vppParamCT_NOM = new SqlParameter("@CT_NOM", SqlDbType.VarChar, 150);
			vppParamCT_NOM.Value  = clsPhaparcontact.CT_NOM ;
			if(clsPhaparcontact.CT_NOM== ""  ) vppParamCT_NOM.Value  = DBNull.Value;
			SqlParameter vppParamCT_PRENOM = new SqlParameter("@CT_PRENOM", SqlDbType.VarChar, 150);
			vppParamCT_PRENOM.Value  = clsPhaparcontact.CT_PRENOM ;
			if(clsPhaparcontact.CT_PRENOM== ""  ) vppParamCT_PRENOM.Value  = DBNull.Value;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsPhaparcontact.SR_CODESERVICE ;
			if(clsPhaparcontact.SR_CODESERVICE== ""  ) vppParamSR_CODESERVICE.Value  = DBNull.Value;
			SqlParameter vppParamCT_FONCTION = new SqlParameter("@CT_FONCTION", SqlDbType.VarChar, 150);
			vppParamCT_FONCTION.Value  = clsPhaparcontact.CT_FONCTION ;
			if(clsPhaparcontact.CT_FONCTION== ""  ) vppParamCT_FONCTION.Value  = DBNull.Value;
			SqlParameter vppParamTC_CODETYPECONTACT = new SqlParameter("@TC_CODETYPECONTACT", SqlDbType.VarChar, 2);
			vppParamTC_CODETYPECONTACT.Value  = clsPhaparcontact.TC_CODETYPECONTACT ;
			if(clsPhaparcontact.TC_CODETYPECONTACT== ""  ) vppParamTC_CODETYPECONTACT.Value  = DBNull.Value;
			SqlParameter vppParamCT_TELEPHONE = new SqlParameter("@CT_TELEPHONE", SqlDbType.VarChar, 50);
			vppParamCT_TELEPHONE.Value  = clsPhaparcontact.CT_TELEPHONE ;
			if(clsPhaparcontact.CT_TELEPHONE== ""  ) vppParamCT_TELEPHONE.Value  = DBNull.Value;
			SqlParameter vppParamCT_PORTABLE = new SqlParameter("@CT_PORTABLE", SqlDbType.VarChar, 50);
			vppParamCT_PORTABLE.Value  = clsPhaparcontact.CT_PORTABLE ;
			if(clsPhaparcontact.CT_PORTABLE== ""  ) vppParamCT_PORTABLE.Value  = DBNull.Value;
			SqlParameter vppParamCT_FAX = new SqlParameter("@CT_FAX", SqlDbType.VarChar, 50);
			vppParamCT_FAX.Value  = clsPhaparcontact.CT_FAX ;
			if(clsPhaparcontact.CT_FAX== ""  ) vppParamCT_FAX.Value  = DBNull.Value;
			SqlParameter vppParamCT_EMAIL = new SqlParameter("@CT_EMAIL", SqlDbType.VarChar, 150);
			vppParamCT_EMAIL.Value  = clsPhaparcontact.CT_EMAIL ;
			if(clsPhaparcontact.CT_EMAIL== ""  ) vppParamCT_EMAIL.Value  = DBNull.Value;

			SqlParameter vppParamTP_CODETYPEPERSONNE = new SqlParameter("@TP_CODETYPEPERSONNE", SqlDbType.VarChar, 2);
			vppParamTP_CODETYPEPERSONNE.Value  = clsPhaparcontact.TP_CODETYPEPERSONNE ;
			if(clsPhaparcontact.TP_CODETYPEPERSONNE== ""  ) vppParamTP_CODETYPEPERSONNE.Value  = DBNull.Value;

            SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.Int);
            vppParamAB_CODEAGENCEBANCAIRE.Value = clsPhaparcontact.AB_CODEAGENCEBANCAIRE;
            if (clsPhaparcontact.AB_CODEAGENCEBANCAIRE == "") vppParamAB_CODEAGENCEBANCAIRE.Value = DBNull.Value;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_CONTACT  @CT_CODECONTACT, @CT_NOM, @CT_PRENOM, @SR_CODESERVICE, @CT_FONCTION, @TC_CODETYPECONTACT, @CT_TELEPHONE, @CT_PORTABLE, @CT_FAX, @CT_EMAIL, @TP_CODETYPEPERSONNE, @AB_CODEAGENCEBANCAIRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCT_CODECONTACT);
			vppSqlCmd.Parameters.Add(vppParamCT_NOM);
			vppSqlCmd.Parameters.Add(vppParamCT_PRENOM);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamCT_FONCTION);
			vppSqlCmd.Parameters.Add(vppParamTC_CODETYPECONTACT);
			vppSqlCmd.Parameters.Add(vppParamCT_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamCT_PORTABLE);
			vppSqlCmd.Parameters.Add(vppParamCT_FAX);
			vppSqlCmd.Parameters.Add(vppParamCT_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPERSONNE);
            vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_COMPTAPAR_CONTACT  @CT_CODECONTACT, '' , '' , '' , '' , '' , '' , '' , '' , '' , '', '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparcontact </returns>
		///<author>Home Technology</author>
		public List<clsPhaparcontact> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  CT_CODECONTACT, CT_NOM, CT_PRENOM, SR_CODESERVICE, CT_FONCTION, TC_CODETYPECONTACT, CT_TELEPHONE, CT_PORTABLE, CT_FAX, CT_EMAIL, TP_CODETYPEPERSONNE, AB_CODEAGENCEBANCAIRE FROM dbo.FT_COMPTAPAR_CONTACT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparcontact> clsPhaparcontacts = new List<clsPhaparcontact>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparcontact clsPhaparcontact = new clsPhaparcontact();
					clsPhaparcontact.CT_CODECONTACT = clsDonnee.vogDataReader["CT_CODECONTACT"].ToString();
					clsPhaparcontact.CT_NOM = clsDonnee.vogDataReader["CT_NOM"].ToString();
					clsPhaparcontact.CT_PRENOM = clsDonnee.vogDataReader["CT_PRENOM"].ToString();
					clsPhaparcontact.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsPhaparcontact.CT_FONCTION = clsDonnee.vogDataReader["CT_FONCTION"].ToString();
					clsPhaparcontact.TC_CODETYPECONTACT = clsDonnee.vogDataReader["TC_CODETYPECONTACT"].ToString();
					clsPhaparcontact.CT_TELEPHONE = clsDonnee.vogDataReader["CT_TELEPHONE"].ToString();
					clsPhaparcontact.CT_PORTABLE = clsDonnee.vogDataReader["CT_PORTABLE"].ToString();
					clsPhaparcontact.CT_FAX = clsDonnee.vogDataReader["CT_FAX"].ToString();
					clsPhaparcontact.CT_EMAIL = clsDonnee.vogDataReader["CT_EMAIL"].ToString();
					clsPhaparcontact.TP_CODETYPEPERSONNE = clsDonnee.vogDataReader["TP_CODETYPEPERSONNE"].ToString();
                    clsPhaparcontact.AB_CODEAGENCEBANCAIRE = clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString();
					clsPhaparcontacts.Add(clsPhaparcontact);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparcontacts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparcontact </returns>
		///<author>Home Technology</author>
		public List<clsPhaparcontact> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparcontact> clsPhaparcontacts = new List<clsPhaparcontact>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  CT_CODECONTACT, CT_NOM, CT_PRENOM, SR_CODESERVICE, CT_FONCTION, TC_CODETYPECONTACT, CT_TELEPHONE, CT_PORTABLE, CT_FAX, CT_EMAIL, TP_CODETYPEPERSONNE, AB_CODEAGENCEBANCAIRE FROM dbo.FT_COMPTAPAR_CONTACT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparcontact clsPhaparcontact = new clsPhaparcontact();
					clsPhaparcontact.CT_CODECONTACT = Dataset.Tables["TABLE"].Rows[Idx]["CT_CODECONTACT"].ToString();
					clsPhaparcontact.CT_NOM = Dataset.Tables["TABLE"].Rows[Idx]["CT_NOM"].ToString();
					clsPhaparcontact.CT_PRENOM = Dataset.Tables["TABLE"].Rows[Idx]["CT_PRENOM"].ToString();
					clsPhaparcontact.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
					clsPhaparcontact.CT_FONCTION = Dataset.Tables["TABLE"].Rows[Idx]["CT_FONCTION"].ToString();
					clsPhaparcontact.TC_CODETYPECONTACT = Dataset.Tables["TABLE"].Rows[Idx]["TC_CODETYPECONTACT"].ToString();
					clsPhaparcontact.CT_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["CT_TELEPHONE"].ToString();
					clsPhaparcontact.CT_PORTABLE = Dataset.Tables["TABLE"].Rows[Idx]["CT_PORTABLE"].ToString();
					clsPhaparcontact.CT_FAX = Dataset.Tables["TABLE"].Rows[Idx]["CT_FAX"].ToString();
					clsPhaparcontact.CT_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["CT_EMAIL"].ToString();
					clsPhaparcontact.TP_CODETYPEPERSONNE = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPEPERSONNE"].ToString();
                    clsPhaparcontact.AB_CODEAGENCEBANCAIRE = Dataset.Tables["TABLE"].Rows[Idx]["AB_CODEAGENCEBANCAIRE"].ToString();
					clsPhaparcontacts.Add(clsPhaparcontact);
				}
				Dataset.Dispose();
			}
		return clsPhaparcontacts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_COMPTAPAR_CONTACT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CT_CODECONTACT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT CT_CODECONTACT , CT_NOM FROM dbo.FT_COMPTAPAR_CONTACT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CT_CODECONTACT)</summary>
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
				this.vapCritere ="WHERE CT_CODECONTACT=@CT_CODECONTACT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CT_CODECONTACT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
