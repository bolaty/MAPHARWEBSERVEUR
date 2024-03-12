using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsLogicielobjetdetailWSDAL: ITableDAL<clsLogicielobjetdetail>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(OP_CODEOBJET) AS OP_CODEOBJET  FROM dbo.FT_LOGICIELOBJETDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(OP_CODEOBJET) AS OP_CODEOBJET  FROM dbo.FT_LOGICIELOBJETDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(OP_CODEOBJET) AS OP_CODEOBJET  FROM dbo.FT_LOGICIELOBJETDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsLogicielobjetdetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsLogicielobjetdetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT OB_CODEOBJET  , OP_NOMOBJET  , LO_CODELOGICIEL  , OT_CODETYPEOBJET  , OP_LIBELLE  , OP_STATUT  , OP_RATTACHEA  FROM dbo.FT_LOGICIELOBJETDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsLogicielobjetdetail clsLogicielobjetdetail = new clsLogicielobjetdetail();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjetdetail.OB_CODEOBJET = clsDonnee.vogDataReader["OB_CODEOBJET"].ToString();
					clsLogicielobjetdetail.OP_NOMOBJET = clsDonnee.vogDataReader["OP_NOMOBJET"].ToString();
					clsLogicielobjetdetail.LO_CODELOGICIEL = clsDonnee.vogDataReader["LO_CODELOGICIEL"].ToString();
					clsLogicielobjetdetail.OT_CODETYPEOBJET = clsDonnee.vogDataReader["OT_CODETYPEOBJET"].ToString();
					clsLogicielobjetdetail.OP_LIBELLE = clsDonnee.vogDataReader["OP_LIBELLE"].ToString();
					clsLogicielobjetdetail.OP_STATUT = clsDonnee.vogDataReader["OP_STATUT"].ToString();
					clsLogicielobjetdetail.OP_RATTACHEA = clsDonnee.vogDataReader["OP_RATTACHEA"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsLogicielobjetdetail;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjetdetail>clsLogicielobjetdetail</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsLogicielobjetdetail clsLogicielobjetdetail)
		{
			//Préparation des paramètres
			SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.VarChar, 25);
			vppParamOB_CODEOBJET.Value  = clsLogicielobjetdetail.OB_CODEOBJET ;
			SqlParameter vppParamOP_CODEOBJET = new SqlParameter("@OP_CODEOBJET", SqlDbType.VarChar, 25);
			vppParamOP_CODEOBJET.Value  = clsLogicielobjetdetail.OP_CODEOBJET ;
			SqlParameter vppParamOP_NOMOBJET = new SqlParameter("@OP_NOMOBJET", SqlDbType.VarChar, 150);
			vppParamOP_NOMOBJET.Value  = clsLogicielobjetdetail.OP_NOMOBJET ;
			SqlParameter vppParamLO_CODELOGICIEL = new SqlParameter("@LO_CODELOGICIEL", SqlDbType.VarChar, 25);
			vppParamLO_CODELOGICIEL.Value  = clsLogicielobjetdetail.LO_CODELOGICIEL ;
			SqlParameter vppParamOT_CODETYPEOBJET = new SqlParameter("@OT_CODETYPEOBJET", SqlDbType.VarChar, 25);
			vppParamOT_CODETYPEOBJET.Value  = clsLogicielobjetdetail.OT_CODETYPEOBJET ;
			SqlParameter vppParamOP_LIBELLE = new SqlParameter("@OP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamOP_LIBELLE.Value  = clsLogicielobjetdetail.OP_LIBELLE ;
			SqlParameter vppParamOP_STATUT = new SqlParameter("@OP_STATUT", SqlDbType.VarChar, 1);
			vppParamOP_STATUT.Value  = clsLogicielobjetdetail.OP_STATUT ;
			SqlParameter vppParamOP_RATTACHEA = new SqlParameter("@OP_RATTACHEA", SqlDbType.VarChar, 25);
			vppParamOP_RATTACHEA.Value  = clsLogicielobjetdetail.OP_RATTACHEA ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETDETAIL  @OB_CODEOBJET, @OP_CODEOBJET, @OP_NOMOBJET, @LO_CODELOGICIEL, @OT_CODETYPEOBJET, @OP_LIBELLE, @OP_STATUT, @OP_RATTACHEA, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOP_NOMOBJET);
			vppSqlCmd.Parameters.Add(vppParamLO_CODELOGICIEL);
			vppSqlCmd.Parameters.Add(vppParamOT_CODETYPEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamOP_STATUT);
			vppSqlCmd.Parameters.Add(vppParamOP_RATTACHEA);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjetdetail>clsLogicielobjetdetail</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsLogicielobjetdetail clsLogicielobjetdetail,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.VarChar, 25);
			vppParamOB_CODEOBJET.Value  = clsLogicielobjetdetail.OB_CODEOBJET ;
			SqlParameter vppParamOP_CODEOBJET = new SqlParameter("@OP_CODEOBJET", SqlDbType.VarChar, 25);
			vppParamOP_CODEOBJET.Value  = clsLogicielobjetdetail.OP_CODEOBJET ;
			SqlParameter vppParamOP_NOMOBJET = new SqlParameter("@OP_NOMOBJET", SqlDbType.VarChar, 150);
			vppParamOP_NOMOBJET.Value  = clsLogicielobjetdetail.OP_NOMOBJET ;
			SqlParameter vppParamLO_CODELOGICIEL = new SqlParameter("@LO_CODELOGICIEL", SqlDbType.VarChar, 25);
			vppParamLO_CODELOGICIEL.Value  = clsLogicielobjetdetail.LO_CODELOGICIEL ;
			SqlParameter vppParamOT_CODETYPEOBJET = new SqlParameter("@OT_CODETYPEOBJET", SqlDbType.VarChar, 25);
			vppParamOT_CODETYPEOBJET.Value  = clsLogicielobjetdetail.OT_CODETYPEOBJET ;
			SqlParameter vppParamOP_LIBELLE = new SqlParameter("@OP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamOP_LIBELLE.Value  = clsLogicielobjetdetail.OP_LIBELLE ;
			SqlParameter vppParamOP_STATUT = new SqlParameter("@OP_STATUT", SqlDbType.VarChar, 1);
			vppParamOP_STATUT.Value  = clsLogicielobjetdetail.OP_STATUT ;
			SqlParameter vppParamOP_RATTACHEA = new SqlParameter("@OP_RATTACHEA", SqlDbType.VarChar, 25);
			vppParamOP_RATTACHEA.Value  = clsLogicielobjetdetail.OP_RATTACHEA ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETDETAIL  @OB_CODEOBJET, @OP_CODEOBJET, @OP_NOMOBJET, @LO_CODELOGICIEL, @OT_CODETYPEOBJET, @OP_LIBELLE, @OP_STATUT, @OP_RATTACHEA, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOP_NOMOBJET);
			vppSqlCmd.Parameters.Add(vppParamLO_CODELOGICIEL);
			vppSqlCmd.Parameters.Add(vppParamOT_CODETYPEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamOP_STATUT);
			vppSqlCmd.Parameters.Add(vppParamOP_RATTACHEA);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETDETAIL  @OB_CODEOBJET, @OP_CODEOBJET, '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjetdetail </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjetdetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  OB_CODEOBJET, OP_CODEOBJET, OP_NOMOBJET, LO_CODELOGICIEL, OT_CODETYPEOBJET, OP_LIBELLE, OP_STATUT, OP_RATTACHEA FROM dbo.FT_LOGICIELOBJETDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsLogicielobjetdetail> clsLogicielobjetdetails = new List<clsLogicielobjetdetail>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjetdetail clsLogicielobjetdetail = new clsLogicielobjetdetail();
					clsLogicielobjetdetail.OB_CODEOBJET = clsDonnee.vogDataReader["OB_CODEOBJET"].ToString();
					clsLogicielobjetdetail.OP_CODEOBJET = clsDonnee.vogDataReader["OP_CODEOBJET"].ToString();
					clsLogicielobjetdetail.OP_NOMOBJET = clsDonnee.vogDataReader["OP_NOMOBJET"].ToString();
					clsLogicielobjetdetail.LO_CODELOGICIEL = clsDonnee.vogDataReader["LO_CODELOGICIEL"].ToString();
					clsLogicielobjetdetail.OT_CODETYPEOBJET = clsDonnee.vogDataReader["OT_CODETYPEOBJET"].ToString();
					clsLogicielobjetdetail.OP_LIBELLE = clsDonnee.vogDataReader["OP_LIBELLE"].ToString();
					clsLogicielobjetdetail.OP_STATUT = clsDonnee.vogDataReader["OP_STATUT"].ToString();
					clsLogicielobjetdetail.OP_RATTACHEA = clsDonnee.vogDataReader["OP_RATTACHEA"].ToString();
					clsLogicielobjetdetails.Add(clsLogicielobjetdetail);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsLogicielobjetdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjetdetail </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjetdetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsLogicielobjetdetail> clsLogicielobjetdetails = new List<clsLogicielobjetdetail>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  OB_CODEOBJET, OP_CODEOBJET, OP_NOMOBJET, LO_CODELOGICIEL, OT_CODETYPEOBJET, OP_LIBELLE, OP_STATUT, OP_RATTACHEA FROM dbo.FT_LOGICIELOBJETDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsLogicielobjetdetail clsLogicielobjetdetail = new clsLogicielobjetdetail();
					clsLogicielobjetdetail.OB_CODEOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OB_CODEOBJET"].ToString();
					clsLogicielobjetdetail.OP_CODEOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOBJET"].ToString();
					clsLogicielobjetdetail.OP_NOMOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OP_NOMOBJET"].ToString();
					clsLogicielobjetdetail.LO_CODELOGICIEL = Dataset.Tables["TABLE"].Rows[Idx]["LO_CODELOGICIEL"].ToString();
					clsLogicielobjetdetail.OT_CODETYPEOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OT_CODETYPEOBJET"].ToString();
					clsLogicielobjetdetail.OP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["OP_LIBELLE"].ToString();
					clsLogicielobjetdetail.OP_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["OP_STATUT"].ToString();
					clsLogicielobjetdetail.OP_RATTACHEA = Dataset.Tables["TABLE"].Rows[Idx]["OP_RATTACHEA"].ToString();
					clsLogicielobjetdetails.Add(clsLogicielobjetdetail);
				}
				Dataset.Dispose();
			}
		return clsLogicielobjetdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_LOGICIELOBJETDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgInsertIntoDatasetGrille(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT * FROM dbo.VUE_ECRANPOPUMENU " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OB_CODEOBJET, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT OP_CODEOBJET , OP_NOMOBJET FROM dbo.FT_LOGICIELOBJETDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OB_CODEOBJET, OP_CODEOBJET)</summary>
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
				this.vapCritere ="WHERE OB_CODEOBJET=@OB_CODEOBJET";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@OB_CODEOBJET"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE OB_CODEOBJET=@OB_CODEOBJET AND OP_CODEOBJET=@OP_CODEOBJET";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@OB_CODEOBJET","@OP_CODEOBJET"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
