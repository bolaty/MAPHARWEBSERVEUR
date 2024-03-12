using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparsectionWSDAL: ITableDAL<clsPhaparsection>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{}; 
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(SC_CODESECTION) AS SC_CODESECTION  FROM dbo.PHAPARSECTION  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(SC_CODESECTION) AS SC_CODESECTION  FROM dbo.PHAPARSECTION  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(SC_CODESECTION) AS SC_CODESECTION  FROM dbo.PHAPARSECTION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparsection comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparsection pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT SC_DENOMINATION  , SC_ADRESSEPOSTALE  , SC_ADRESSEGEOGRAPHIQUE  , SC_TELEPHONE  , SC_FAX  , SC_SITEWEB  , SC_EMAIL  , SC_GERANT  FROM dbo.FT_PHAPARSECTION(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparsection clsPhaparsection = new clsPhaparsection();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparsection.SC_DENOMINATION = clsDonnee.vogDataReader["SC_DENOMINATION"].ToString();
					clsPhaparsection.SC_ADRESSEPOSTALE = clsDonnee.vogDataReader["SC_ADRESSEPOSTALE"].ToString();
					clsPhaparsection.SC_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["SC_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparsection.SC_TELEPHONE = clsDonnee.vogDataReader["SC_TELEPHONE"].ToString();
					clsPhaparsection.SC_FAX = clsDonnee.vogDataReader["SC_FAX"].ToString();
					clsPhaparsection.SC_SITEWEB = clsDonnee.vogDataReader["SC_SITEWEB"].ToString();
					clsPhaparsection.SC_EMAIL = clsDonnee.vogDataReader["SC_EMAIL"].ToString();
					clsPhaparsection.SC_GERANT = clsDonnee.vogDataReader["SC_GERANT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparsection;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparsection>clsPhaparsection</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparsection clsPhaparsection)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
			vppParamAG_CODEAGENCE.Value  = clsPhaparsection.AG_CODEAGENCE ;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhaparsection.EN_CODEENTREPOT;

			SqlParameter vppParamSC_CODESECTION = new SqlParameter("@SC_CODESECTION", SqlDbType.VarChar, 4);
			vppParamSC_CODESECTION.Value  = clsPhaparsection.SC_CODESECTION ;

            SqlParameter vppParamSC_NUMSECTION = new SqlParameter("@SC_NUMSECTION", SqlDbType.VarChar, 150);
            vppParamSC_NUMSECTION.Value = clsPhaparsection.SC_NUMSECTION;

			SqlParameter vppParamSC_DENOMINATION = new SqlParameter("@SC_DENOMINATION", SqlDbType.VarChar, 150);
			vppParamSC_DENOMINATION.Value  = clsPhaparsection.SC_DENOMINATION ;

			SqlParameter vppParamSC_ADRESSEPOSTALE = new SqlParameter("@SC_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
			vppParamSC_ADRESSEPOSTALE.Value  = clsPhaparsection.SC_ADRESSEPOSTALE ;

			SqlParameter vppParamSC_ADRESSEGEOGRAPHIQUE = new SqlParameter("@SC_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
			vppParamSC_ADRESSEGEOGRAPHIQUE.Value  = clsPhaparsection.SC_ADRESSEGEOGRAPHIQUE ;

			SqlParameter vppParamSC_TELEPHONE = new SqlParameter("@SC_TELEPHONE", SqlDbType.VarChar, 80);
			vppParamSC_TELEPHONE.Value  = clsPhaparsection.SC_TELEPHONE ;

			SqlParameter vppParamSC_FAX = new SqlParameter("@SC_FAX", SqlDbType.VarChar, 80);
			vppParamSC_FAX.Value  = clsPhaparsection.SC_FAX ;

			SqlParameter vppParamSC_SITEWEB = new SqlParameter("@SC_SITEWEB", SqlDbType.VarChar, 150);
			vppParamSC_SITEWEB.Value  = clsPhaparsection.SC_SITEWEB ;

			SqlParameter vppParamSC_EMAIL = new SqlParameter("@SC_EMAIL", SqlDbType.VarChar, 80);
			vppParamSC_EMAIL.Value  = clsPhaparsection.SC_EMAIL ;

			SqlParameter vppParamSC_GERANT = new SqlParameter("@SC_GERANT", SqlDbType.VarChar, 150);
			vppParamSC_GERANT.Value  = clsPhaparsection.SC_GERANT ;

         

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;



            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARSECTION  @AG_CODEAGENCE, @EN_CODEENTREPOT, @SC_CODESECTION,@SC_NUMSECTION, @SC_DENOMINATION, @SC_ADRESSEPOSTALE, @SC_ADRESSEGEOGRAPHIQUE, @SC_TELEPHONE, @SC_FAX, @SC_SITEWEB, @SC_EMAIL, @SC_GERANT, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            ////Préparation de la commande
            // this.vapRequete = "INSERT INTO PHAPARSECTION (  AG_CODEAGENCE, SC_CODESECTION, SC_DENOMINATION, SC_ADRESSEPOSTALE, SC_ADRESSEGEOGRAPHIQUE, SC_TELEPHONE, SC_FAX, SC_SITEWEB, SC_EMAIL, SC_GERANT) " +
            //         "VALUES ( @AG_CODEAGENCE, @SC_CODESECTION, @SC_DENOMINATION, @SC_ADRESSEPOSTALE, @SC_ADRESSEGEOGRAPHIQUE, @SC_TELEPHONE, @SC_FAX, @SC_SITEWEB, @SC_EMAIL, @SC_GERANT) ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamSC_CODESECTION);
            vppSqlCmd.Parameters.Add(vppParamSC_NUMSECTION);
			vppSqlCmd.Parameters.Add(vppParamSC_DENOMINATION);
			vppSqlCmd.Parameters.Add(vppParamSC_ADRESSEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamSC_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamSC_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamSC_FAX);
			vppSqlCmd.Parameters.Add(vppParamSC_SITEWEB);
			vppSqlCmd.Parameters.Add(vppParamSC_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamSC_GERANT);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparsection>clsPhaparsection</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparsection clsPhaparsection,params string[] vppCritere)
		{


            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhaparsection.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhaparsection.EN_CODEENTREPOT;

            SqlParameter vppParamSC_CODESECTION = new SqlParameter("@SC_CODESECTION", SqlDbType.VarChar, 4);
            vppParamSC_CODESECTION.Value = clsPhaparsection.SC_CODESECTION;

            SqlParameter vppParamSC_NUMSECTION = new SqlParameter("@SC_NUMSECTION", SqlDbType.VarChar,150);
            vppParamSC_NUMSECTION.Value = clsPhaparsection.SC_NUMSECTION;

            SqlParameter vppParamSC_DENOMINATION = new SqlParameter("@SC_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamSC_DENOMINATION.Value = clsPhaparsection.SC_DENOMINATION;

            SqlParameter vppParamSC_ADRESSEPOSTALE = new SqlParameter("@SC_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamSC_ADRESSEPOSTALE.Value = clsPhaparsection.SC_ADRESSEPOSTALE;

            SqlParameter vppParamSC_ADRESSEGEOGRAPHIQUE = new SqlParameter("@SC_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamSC_ADRESSEGEOGRAPHIQUE.Value = clsPhaparsection.SC_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamSC_TELEPHONE = new SqlParameter("@SC_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamSC_TELEPHONE.Value = clsPhaparsection.SC_TELEPHONE;

            SqlParameter vppParamSC_FAX = new SqlParameter("@SC_FAX", SqlDbType.VarChar, 80);
            vppParamSC_FAX.Value = clsPhaparsection.SC_FAX;

            SqlParameter vppParamSC_SITEWEB = new SqlParameter("@SC_SITEWEB", SqlDbType.VarChar, 150);
            vppParamSC_SITEWEB.Value = clsPhaparsection.SC_SITEWEB;

            SqlParameter vppParamSC_EMAIL = new SqlParameter("@SC_EMAIL", SqlDbType.VarChar, 80);
            vppParamSC_EMAIL.Value = clsPhaparsection.SC_EMAIL;

            SqlParameter vppParamSC_GERANT = new SqlParameter("@SC_GERANT", SqlDbType.VarChar, 150);
            vppParamSC_GERANT.Value = clsPhaparsection.SC_GERANT;

           

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;



            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARSECTION  @AG_CODEAGENCE,@EN_CODEENTREPOT, @SC_CODESECTION,@SC_NUMSECTION, @SC_DENOMINATION, @SC_ADRESSEPOSTALE, @SC_ADRESSEGEOGRAPHIQUE, @SC_TELEPHONE, @SC_FAX, @SC_SITEWEB, @SC_EMAIL, @SC_GERANT, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            ////Préparation de la commande
            // this.vapRequete = "INSERT INTO PHAPARSECTION (  AG_CODEAGENCE, SC_CODESECTION, SC_DENOMINATION, SC_ADRESSEPOSTALE, SC_ADRESSEGEOGRAPHIQUE, SC_TELEPHONE, SC_FAX, SC_SITEWEB, SC_EMAIL, SC_GERANT) " +
            //         "VALUES ( @AG_CODEAGENCE, @SC_CODESECTION, @SC_DENOMINATION, @SC_ADRESSEPOSTALE, @SC_ADRESSEGEOGRAPHIQUE, @SC_TELEPHONE, @SC_FAX, @SC_SITEWEB, @SC_EMAIL, @SC_GERANT) ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamSC_CODESECTION);
            vppSqlCmd.Parameters.Add(vppParamSC_NUMSECTION);
            vppSqlCmd.Parameters.Add(vppParamSC_DENOMINATION);
            vppSqlCmd.Parameters.Add(vppParamSC_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamSC_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamSC_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamSC_FAX);
            vppSqlCmd.Parameters.Add(vppParamSC_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamSC_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamSC_GERANT);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);








            ////Préparation des paramètres
            //SqlParameter vppParamSC_DENOMINATION = new SqlParameter("@SC_DENOMINATION", SqlDbType.VarChar, 150);
            //vppParamSC_DENOMINATION.Value  = clsPhaparsection.SC_DENOMINATION ;

            //SqlParameter vppParamSC_ADRESSEPOSTALE = new SqlParameter("@SC_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            //vppParamSC_ADRESSEPOSTALE.Value  = clsPhaparsection.SC_ADRESSEPOSTALE ;

            //SqlParameter vppParamSC_ADRESSEGEOGRAPHIQUE = new SqlParameter("@SC_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            //vppParamSC_ADRESSEGEOGRAPHIQUE.Value  = clsPhaparsection.SC_ADRESSEGEOGRAPHIQUE ;

            //SqlParameter vppParamSC_TELEPHONE = new SqlParameter("@SC_TELEPHONE", SqlDbType.VarChar, 80);
            //vppParamSC_TELEPHONE.Value  = clsPhaparsection.SC_TELEPHONE ;

            //SqlParameter vppParamSC_FAX = new SqlParameter("@SC_FAX", SqlDbType.VarChar, 80);
            //vppParamSC_FAX.Value  = clsPhaparsection.SC_FAX ;

            //SqlParameter vppParamSC_SITEWEB = new SqlParameter("@SC_SITEWEB", SqlDbType.VarChar, 150);
            //vppParamSC_SITEWEB.Value  = clsPhaparsection.SC_SITEWEB ;

            //SqlParameter vppParamSC_EMAIL = new SqlParameter("@SC_EMAIL", SqlDbType.VarChar, 80);
            //vppParamSC_EMAIL.Value  = clsPhaparsection.SC_EMAIL ;

            //SqlParameter vppParamSC_GERANT = new SqlParameter("@SC_GERANT", SqlDbType.VarChar, 150);
            //vppParamSC_GERANT.Value  = clsPhaparsection.SC_GERANT ;

            ////Préparation de la commande
            //pvpChoixCritere(clsDonnee, vppCritere); 
            // this.vapRequete = "UPDATE PHAPARSECTION SET " +
            //                "SC_DENOMINATION = @SC_DENOMINATION, "+
            //                "SC_ADRESSEPOSTALE = @SC_ADRESSEPOSTALE, "+
            //                "SC_ADRESSEGEOGRAPHIQUE = @SC_ADRESSEGEOGRAPHIQUE, "+
            //                "SC_TELEPHONE = @SC_TELEPHONE, "+
            //                "SC_FAX = @SC_FAX, "+
            //                "SC_SITEWEB = @SC_SITEWEB, "+
            //                "SC_EMAIL = @SC_EMAIL, "+
            //                "SC_GERANT = @SC_GERANT " + vapCritere;
            //this.vapCritere = "";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            ////Ajout des paramètre à la commande
            //vppSqlCmd.Parameters.Add(vppParamSC_DENOMINATION);
            //vppSqlCmd.Parameters.Add(vppParamSC_ADRESSEPOSTALE);
            //vppSqlCmd.Parameters.Add(vppParamSC_ADRESSEGEOGRAPHIQUE);
            //vppSqlCmd.Parameters.Add(vppParamSC_TELEPHONE);
            //vppSqlCmd.Parameters.Add(vppParamSC_FAX);
            //vppSqlCmd.Parameters.Add(vppParamSC_SITEWEB);
            //vppSqlCmd.Parameters.Add(vppParamSC_EMAIL);
            //vppSqlCmd.Parameters.Add(vppParamSC_GERANT);
            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARSECTION "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparsection </returns>
		///<author>Home Technology</author>
		public List<clsPhaparsection> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, SC_CODESECTION, SC_DENOMINATION, SC_ADRESSEPOSTALE, SC_ADRESSEGEOGRAPHIQUE, SC_TELEPHONE, SC_FAX, SC_SITEWEB, SC_EMAIL, SC_GERANT FROM dbo.FT_PHAPARSECTION(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparsection> clsPhaparsections = new List<clsPhaparsection>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparsection clsPhaparsection = new clsPhaparsection();
					clsPhaparsection.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhaparsection.SC_CODESECTION = clsDonnee.vogDataReader["SC_CODESECTION"].ToString();
					clsPhaparsection.SC_DENOMINATION = clsDonnee.vogDataReader["SC_DENOMINATION"].ToString();
					clsPhaparsection.SC_ADRESSEPOSTALE = clsDonnee.vogDataReader["SC_ADRESSEPOSTALE"].ToString();
					clsPhaparsection.SC_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["SC_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparsection.SC_TELEPHONE = clsDonnee.vogDataReader["SC_TELEPHONE"].ToString();
					clsPhaparsection.SC_FAX = clsDonnee.vogDataReader["SC_FAX"].ToString();
					clsPhaparsection.SC_SITEWEB = clsDonnee.vogDataReader["SC_SITEWEB"].ToString();
					clsPhaparsection.SC_EMAIL = clsDonnee.vogDataReader["SC_EMAIL"].ToString();
					clsPhaparsection.SC_GERANT = clsDonnee.vogDataReader["SC_GERANT"].ToString();
					clsPhaparsections.Add(clsPhaparsection);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparsections;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparsection </returns>
		///<author>Home Technology</author>
		public List<clsPhaparsection> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparsection> clsPhaparsections = new List<clsPhaparsection>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, SC_CODESECTION, SC_DENOMINATION, SC_ADRESSEPOSTALE, SC_ADRESSEGEOGRAPHIQUE, SC_TELEPHONE, SC_FAX, SC_SITEWEB, SC_EMAIL, SC_GERANT FROM dbo.FT_PHAPARSECTION(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparsection clsPhaparsection = new clsPhaparsection();
					clsPhaparsection.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhaparsection.SC_CODESECTION = Dataset.Tables["TABLE"].Rows[Idx]["SC_CODESECTION"].ToString();
					clsPhaparsection.SC_DENOMINATION = Dataset.Tables["TABLE"].Rows[Idx]["SC_DENOMINATION"].ToString();
					clsPhaparsection.SC_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["SC_ADRESSEPOSTALE"].ToString();
					clsPhaparsection.SC_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["SC_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparsection.SC_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["SC_TELEPHONE"].ToString();
					clsPhaparsection.SC_FAX = Dataset.Tables["TABLE"].Rows[Idx]["SC_FAX"].ToString();
					clsPhaparsection.SC_SITEWEB = Dataset.Tables["TABLE"].Rows[Idx]["SC_SITEWEB"].ToString();
					clsPhaparsection.SC_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["SC_EMAIL"].ToString();
					clsPhaparsection.SC_GERANT = Dataset.Tables["TABLE"].Rows[Idx]["SC_GERANT"].ToString();
					clsPhaparsections.Add(clsPhaparsection);
				}
				Dataset.Dispose();
			}
		return clsPhaparsections;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARSECTION(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, SC_CODESECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT SC_CODESECTION,SC_DENOMINATION FROM dbo.FT_PHAPARSECTION(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgChargerDansDataSetPourComboExclusion(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereExclusion(clsDonnee, vppCritere);
            this.vapRequete = "SELECT SC_CODESECTION,SC_DENOMINATION FROM dbo.FT_PHAPARSECTION(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SC_CODESECTION)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
               

				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
                case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND   SC_CODESECTION=@SC_CODESECTION";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@SC_CODESECTION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
                break;



			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SC_CODESECTION)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereExclusion(clsDonnee clsDonnee, params string[] vppCritere)
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SC_CODESECTION<>@SC_CODESECTION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SC_CODESECTION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }


        /////<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SC_CODESECTION)</summary>
        /////<param name="vppCritere">Les critères de la requète</param>
        /////<author>Home Technologie</author>
        //public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    switch (vppCritere.Length)
        //    {
        //        case 0:
        //            this.vapCritere = "";
        //            vapNomParametre = new string[] { "@CODECRYPTAGE" };
        //            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
        //            break;
        //        case 1:
        //            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
        //            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
        //            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
        //            break;
        //        case 2:
        //            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
        //            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE"};
        //            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
        //            break;
        //    }
        //}



	}
}
