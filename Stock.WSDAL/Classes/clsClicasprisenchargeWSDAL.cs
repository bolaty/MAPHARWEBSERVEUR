using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsClicasprisenchargeWSDAL: ITableDAL<clsClicasprisencharge>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICASPRISENCHARGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICASPRISENCHARGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICASPRISENCHARGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsClicasprisencharge comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsClicasprisencharge pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AR_CODEARTICLE  , AP_CODEPRODUIT  FROM dbo.FT_CLICASPRISENCHARGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsClicasprisencharge clsClicasprisencharge = new clsClicasprisencharge();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClicasprisencharge.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsClicasprisencharge.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsClicasprisencharge;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClicasprisencharge>clsClicasprisencharge</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsClicasprisencharge clsClicasprisencharge)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsClicasprisencharge.AG_CODEAGENCE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsClicasprisencharge.AR_CODEARTICLE ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT1", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsClicasprisencharge.AP_CODEPRODUIT ;


            SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE", SqlDbType.VarChar, 50);
            vppParamPE_CODEPERIODICITE.Value = clsClicasprisencharge.PE_CODEPERIODICITE;

            SqlParameter vppParamCP_TAUXREMBOURSEMENT = new SqlParameter("@CP_TAUXREMBOURSEMENT", SqlDbType.Float);
            vppParamCP_TAUXREMBOURSEMENT.Value = clsClicasprisencharge.CP_TAUXREMBOURSEMENT;

            SqlParameter vppParamCP_MONTANT = new SqlParameter("@CP_MONTANT", SqlDbType.Money);
            vppParamCP_MONTANT.Value = clsClicasprisencharge.CP_MONTANT;

            SqlParameter vppParamCP_PLAFOND = new SqlParameter("@CP_PLAFOND", SqlDbType.Money);
            vppParamCP_PLAFOND.Value = clsClicasprisencharge.CP_PLAFOND;

            SqlParameter vppParamCP_NOMBRE = new SqlParameter("@CP_NOMBRE", SqlDbType.Int);
            vppParamCP_NOMBRE.Value = clsClicasprisencharge.CP_NOMBRE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICASPRISENCHARGE  @AG_CODEAGENCE1, @AR_CODEARTICLE1, @AP_CODEPRODUIT1,@PE_CODEPERIODICITE,@CP_TAUXREMBOURSEMENT,@CP_MONTANT,@CP_PLAFOND,@CP_NOMBRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
            vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);
            vppSqlCmd.Parameters.Add(vppParamCP_TAUXREMBOURSEMENT);
            vppSqlCmd.Parameters.Add(vppParamCP_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamCP_PLAFOND);
            vppSqlCmd.Parameters.Add(vppParamCP_NOMBRE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClicasprisencharge>clsClicasprisencharge</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsClicasprisencharge clsClicasprisencharge,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsClicasprisencharge.AG_CODEAGENCE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsClicasprisencharge.AR_CODEARTICLE ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar,50);
			vppParamAP_CODEPRODUIT.Value  = clsClicasprisencharge.AP_CODEPRODUIT ;

			SqlParameter vppParamPE_CODEPERIODICITE = new SqlParameter("@PE_CODEPERIODICITE", SqlDbType.VarChar,50);
            vppParamPE_CODEPERIODICITE.Value  = clsClicasprisencharge.PE_CODEPERIODICITE;

            SqlParameter vppParamCP_TAUXREMBOURSEMENT = new SqlParameter("@CP_TAUXREMBOURSEMENT", SqlDbType.Float);
            vppParamCP_TAUXREMBOURSEMENT.Value = clsClicasprisencharge.CP_TAUXREMBOURSEMENT;

            SqlParameter vppParamCP_MONTANT = new SqlParameter("@CP_MONTANT", SqlDbType.Money);
            vppParamCP_MONTANT.Value = clsClicasprisencharge.CP_MONTANT;

            SqlParameter vppParamCP_PLAFOND = new SqlParameter("@CP_PLAFOND", SqlDbType.Money);
            vppParamCP_PLAFOND.Value = clsClicasprisencharge.CP_PLAFOND;

            SqlParameter vppParamCP_NOMBRE = new SqlParameter("@CP_NOMBRE", SqlDbType.Int);
            vppParamCP_NOMBRE.Value = clsClicasprisencharge.CP_NOMBRE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICASPRISENCHARGE  @AG_CODEAGENCE, @AR_CODEARTICLE, @AP_CODEPRODUIT,@PE_CODEPERIODICITE,@CP_TAUXREMBOURSEMENT,@CP_MONTANT,@CP_PLAFOND,@CP_NOMBRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamPE_CODEPERIODICITE);
			vppSqlCmd.Parameters.Add(vppParamCP_TAUXREMBOURSEMENT);
			vppSqlCmd.Parameters.Add(vppParamCP_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCP_PLAFOND);
			vppSqlCmd.Parameters.Add(vppParamCP_NOMBRE);

			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICASPRISENCHARGE  @AG_CODEAGENCE, @AR_CODEARTICLE, @AP_CODEPRODUIT ,'',0,0,0,0, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClicasprisencharge </returns>
		///<author>Home Technology</author>
		public List<clsClicasprisencharge> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT FROM dbo.FT_CLICASPRISENCHARGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsClicasprisencharge> clsClicasprisencharges = new List<clsClicasprisencharge>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClicasprisencharge clsClicasprisencharge = new clsClicasprisencharge();
					clsClicasprisencharge.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsClicasprisencharge.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsClicasprisencharge.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsClicasprisencharges.Add(clsClicasprisencharge);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsClicasprisencharges;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClicasprisencharge </returns>
		///<author>Home Technology</author>
		public List<clsClicasprisencharge> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsClicasprisencharge> clsClicasprisencharges = new List<clsClicasprisencharge>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, AR_CODEARTICLE, AP_CODEPRODUIT FROM dbo.FT_CLICASPRISENCHARGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsClicasprisencharge clsClicasprisencharge = new clsClicasprisencharge();
					clsClicasprisencharge.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsClicasprisencharge.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsClicasprisencharge.AP_CODEPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["AP_CODEPRODUIT"].ToString();
					clsClicasprisencharges.Add(clsClicasprisencharge);
				}
				Dataset.Dispose();
			}
		return clsClicasprisencharges;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICASPRISENCHARGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetConfiguration(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AP_CODEPRODUIT" , "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };

            this.vapRequete = "EXEC [dbo].[PS_CLICASPRISENCHARGE] @AG_CODEAGENCE,@AP_CODEPRODUIT,@TYPEOPERATION, @CODECRYPTAGE" ;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }



		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , AP_CODEPRODUIT FROM dbo.FT_CLICASPRISENCHARGE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, AR_CODEARTICLE)</summary>
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
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AP_CODEPRODUIT=@AP_CODEPRODUIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@AP_CODEPRODUIT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AP_CODEPRODUIT=@AP_CODEPRODUIT  AND AR_CODEARTICLE=@AR_CODEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@AP_CODEPRODUIT", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;

			}
		}
	}
}
