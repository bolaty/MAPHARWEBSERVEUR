using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparprixtypefournisseurWSDAL: ITableDAL<clsPhaparprixtypefournisseur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{}; 

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(TF_CODETYPEFOURNISSEUR) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(TF_CODETYPEFOURNISSEUR) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparprixtypefournisseur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparprixtypefournisseur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PT_PRIXCESSION  , PT_TAUXREMISE  , PT_MONTANTREMISE  , PT_TAUXCOMMISSION  , PT_MONTANTCOMMISSION  , PT_DATEREMISE1  , PT_DATEREMISE2  , PT_DATETARIFICATION  FROM dbo.PHAPARPRIXTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparprixtypefournisseur clsPhaparprixtypefournisseur = new clsPhaparprixtypefournisseur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprixtypefournisseur.PT_PRIXCESSION = double.Parse(clsDonnee.vogDataReader["PT_PRIXCESSION"].ToString());
					clsPhaparprixtypefournisseur.PT_DATETARIFICATION = DateTime.Parse(clsDonnee.vogDataReader["PT_DATETARIFICATION"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparprixtypefournisseur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprixtypefournisseur>clsPhaparprixtypefournisseur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparprixtypefournisseur clsPhaparprixtypefournisseur)
		{
			//Préparation des paramètres
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparprixtypefournisseur.AR_CODEARTICLE ;

			SqlParameter vppParamPT_PRIXCESSION = new SqlParameter("@PT_PRIXCESSION", SqlDbType.Money);
			vppParamPT_PRIXCESSION.Value  = clsPhaparprixtypefournisseur.PT_PRIXCESSION ;

			SqlParameter vppParamPT_DATETARIFICATION = new SqlParameter("@PT_DATETARIFICATION", SqlDbType.DateTime);
			vppParamPT_DATETARIFICATION.Value  = clsPhaparprixtypefournisseur.PT_DATETARIFICATION ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARPRIXTYPEFOURNISSEUR (  AR_CODEARTICLE,  PT_PRIXCESSION,   PT_DATETARIFICATION) " +
					 "VALUES ( @AR_CODEARTICLE,  @PT_PRIXCESSION , @PT_DATETARIFICATION) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamPT_PRIXCESSION);
			vppSqlCmd.Parameters.Add(vppParamPT_DATETARIFICATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null );
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprixtypefournisseur>clsPhaparprixtypefournisseur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparprixtypefournisseur clsPhaparprixtypefournisseur,params string[] vppCritere)
		{

            vapNomParametre = new string[] { "@AR_CODEARTICLE",  "@PT_PRIXCESSION", "@PT_DATETARIFICATION" };
            vapValeurParametre = new object[] { clsPhaparprixtypefournisseur.AR_CODEARTICLE,  clsPhaparprixtypefournisseur.PT_PRIXCESSION, clsPhaparprixtypefournisseur.PT_DATETARIFICATION };

            //Préparation des paramètres
            this.vapRequete = " EXEC DBO.PS_MAJPRIXTYPEFOURNISSEUR  @AR_CODEARTICLE,  @PT_PRIXCESSION, @PT_DATETARIFICATION ";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARPRIXTYPEFOURNISSEUR "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprixtypefournisseur </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprixtypefournisseur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE,  PT_PRIXCESSION, PT_DATETARIFICATION FROM dbo.PHAPARPRIXTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparprixtypefournisseur> clsPhaparprixtypefournisseurs = new List<clsPhaparprixtypefournisseur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprixtypefournisseur clsPhaparprixtypefournisseur = new clsPhaparprixtypefournisseur();
					clsPhaparprixtypefournisseur.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					
					clsPhaparprixtypefournisseur.PT_PRIXCESSION = double.Parse(clsDonnee.vogDataReader["PT_PRIXCESSION"].ToString());
					clsPhaparprixtypefournisseur.PT_DATETARIFICATION = DateTime.Parse(clsDonnee.vogDataReader["PT_DATETARIFICATION"].ToString());
					clsPhaparprixtypefournisseurs.Add(clsPhaparprixtypefournisseur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparprixtypefournisseurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprixtypefournisseur </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprixtypefournisseur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparprixtypefournisseur> clsPhaparprixtypefournisseurs = new List<clsPhaparprixtypefournisseur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE,  PT_PRIXCESSION, PT_DATETARIFICATION FROM dbo.PHAPARPRIXTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparprixtypefournisseur clsPhaparprixtypefournisseur = new clsPhaparprixtypefournisseur();
					clsPhaparprixtypefournisseur.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					
					clsPhaparprixtypefournisseur.PT_PRIXCESSION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PT_PRIXCESSION"].ToString());
					clsPhaparprixtypefournisseur.PT_DATETARIFICATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PT_DATETARIFICATION"].ToString());
					clsPhaparprixtypefournisseurs.Add(clsPhaparprixtypefournisseur);
				}
				Dataset.Dispose();
			}
		return clsPhaparprixtypefournisseurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARPRIXTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere"></param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetArticlePrixTypeFournisseur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] {  "@TA_CODETYPEARTICLE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0],  clsDonnee.vogCleCryptage };

            this.vapRequete = "SELECT *  FROM dbo.FC_ARTICLEPRIXTYPEFOURNISSEUR( @TA_CODETYPEARTICLE,@CODECRYPTAGE ) ORDER BY AR_NOMCOMMERCIALE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AR_CODEARTICLE , PT_PRIXCESSION FROM dbo.PHAPARPRIXTYPEFOURNISSEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AR_CODEARTICLE, TF_CODETYPEFOURNISSEUR)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
				this.vapCritere =" WHERE AR_CODEARTICLE=@AR_CODEARTICLE ";
				vapNomParametre = new string[]{"@AR_CODEARTICLE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
				this.vapCritere =" WHERE AR_CODEARTICLE=@AR_CODEARTICLE AND TF_CODETYPEFOURNISSEUR=@TF_CODETYPEFOURNISSEUR";
				vapNomParametre = new string[]{"@AR_CODEARTICLE","@TF_CODETYPEFOURNISSEUR"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
