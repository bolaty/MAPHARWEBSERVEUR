using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapararticleaccessoireWSDAL: ITableDAL<clsPhapararticleaccessoire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT COUNT(AR_CODEARTICLE1) AS AR_CODEARTICLE1  FROM dbo.PHAPARARTICLEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT MIN(AR_CODEARTICLE1) AS AR_CODEARTICLE1  FROM dbo.PHAPARARTICLEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT MAX(AR_CODEARTICLE1) AS AR_CODEARTICLE1  FROM dbo.PHAPARARTICLEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapararticleaccessoire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapararticleaccessoire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT AR_QUANTITE  FROM dbo.PHAPARARTICLEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapararticleaccessoire clsPhapararticleaccessoire = new clsPhapararticleaccessoire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapararticleaccessoire.AR_QUANTITE = double.Parse(clsDonnee.vogDataReader["AR_QUANTITE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapararticleaccessoire;
		}


		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapararticleaccessoire>clsPhapararticleaccessoire</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapararticleaccessoire clsPhapararticleaccessoire)
		{
			//Préparation des paramètres
			SqlParameter vppParamAR_CODEARTICLE1 = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE1.Value  = clsPhapararticleaccessoire.AR_CODEARTICLE1 ;

			SqlParameter vppParamAR_CODEARTICLE2 = new SqlParameter("@AR_CODEARTICLE2", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE2.Value  = clsPhapararticleaccessoire.AR_CODEARTICLE2 ;

			SqlParameter vppParamAR_QUANTITE = new SqlParameter("@AR_QUANTITE", SqlDbType.BigInt);
			vppParamAR_QUANTITE.Value  = clsPhapararticleaccessoire.AR_QUANTITE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARARTICLEACCESSOIRE (  AR_CODEARTICLE1, AR_CODEARTICLE2, AR_QUANTITE) " +
					 "VALUES ( @AR_CODEARTICLE, @AR_CODEARTICLE2, @AR_QUANTITE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE1);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE2);
			vppSqlCmd.Parameters.Add(vppParamAR_QUANTITE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapararticleaccessoire>clsPhapararticleaccessoire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapararticleaccessoire clsPhapararticleaccessoire,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAR_QUANTITE = new SqlParameter("@AR_QUANTITE", SqlDbType.BigInt);
			vppParamAR_QUANTITE.Value  = clsPhapararticleaccessoire.AR_QUANTITE ;

			//Préparation de la commande
            pvpChoixCritere(clsDonnee, vppCritere); 
			 this.vapRequete = "UPDATE PHAPARARTICLEACCESSOIRE SET " +
							"AR_QUANTITE = @AR_QUANTITE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAR_QUANTITE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARARTICLEACCESSOIRE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapararticleaccessoire </returns>
		///<author>Home Technology</author>
		public List<clsPhapararticleaccessoire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE1, AR_CODEARTICLE2, AR_QUANTITE FROM dbo.PHAPARARTICLEACCESSOIRE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapararticleaccessoire> clsPhapararticleaccessoires = new List<clsPhapararticleaccessoire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapararticleaccessoire clsPhapararticleaccessoire = new clsPhapararticleaccessoire();
					clsPhapararticleaccessoire.AR_CODEARTICLE1 = clsDonnee.vogDataReader["AR_CODEARTICLE1"].ToString();
					clsPhapararticleaccessoire.AR_CODEARTICLE2 = clsDonnee.vogDataReader["AR_CODEARTICLE2"].ToString();
					clsPhapararticleaccessoire.AR_QUANTITE = double.Parse(clsDonnee.vogDataReader["AR_QUANTITE"].ToString());
					clsPhapararticleaccessoires.Add(clsPhapararticleaccessoire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapararticleaccessoires;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere"></param>
        /// <returns></returns>
        public List<clsPhapararticleaccessoire> pvgSelectEmballage(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT * FROM dbo.FC_EMBALLAGE (@AR_CODEARTICLE1) ";
			this.vapCritere="";			
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapararticleaccessoire> clsPhapararticleaccessoires = new List<clsPhapararticleaccessoire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapararticleaccessoire clsPhapararticleaccessoire = new clsPhapararticleaccessoire();
					clsPhapararticleaccessoire.AR_CODEARTICLE1 = clsDonnee.vogDataReader["AR_CODEARTICLE1"].ToString();
					clsPhapararticleaccessoire.AR_CODEARTICLE2 = clsDonnee.vogDataReader["AR_CODEARTICLE2"].ToString();
					clsPhapararticleaccessoire.AR_QUANTITE = double.Parse(clsDonnee.vogDataReader["AR_QUANTITE"].ToString());
					clsPhapararticleaccessoires.Add(clsPhapararticleaccessoire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapararticleaccessoires;
		}

        /// <summary>
        /// Cette fonction permet de selectionnner une liste de code d'articles accessoires
        /// </summary>
        /// <param name="vppCritere"></param>
        /// <returns>Liste de codes articles des accessoires</returns>
        public List<string> pvgGetListeAccessoire(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE2 FROM PHAPARARTICLEACCESSOIRE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<string> vlpPhapararticleaccessoires = new List<string>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    vlpPhapararticleaccessoires.Add(clsDonnee.vogDataReader["AR_CODEARTICLE2"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return vlpPhapararticleaccessoires;
        }


		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapararticleaccessoire </returns>
		///<author>Home Technology</author>
		public List<clsPhapararticleaccessoire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapararticleaccessoire> clsPhapararticleaccessoires = new List<clsPhapararticleaccessoire>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE1, AR_CODEARTICLE2, AR_QUANTITE FROM dbo.PHAPARARTICLEACCESSOIRE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapararticleaccessoire clsPhapararticleaccessoire = new clsPhapararticleaccessoire();
					clsPhapararticleaccessoire.AR_CODEARTICLE1 = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE1"].ToString();
					clsPhapararticleaccessoire.AR_CODEARTICLE2 = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE2"].ToString();
					clsPhapararticleaccessoire.AR_QUANTITE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AR_QUANTITE"].ToString());
					clsPhapararticleaccessoires.Add(clsPhapararticleaccessoire);
				}
				Dataset.Dispose();
			}
		return clsPhapararticleaccessoires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  AR_STATUT= 'N' " : " AND  AR_STATUT = 'N' ";
            this.vapRequete = "SELECT AR_CODEARTICLE,AR_CODECIP,AR_NOMCOMMERCIALE,AR_NOMSCIENTIFIQUE,AR_DESCRIPTION,TA_CODETYPEARTICLE, AR_QUANTITE FROM FT_PHAPARARTICLEACCESSOIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE1, AR_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE1 , AR_CODEARTICLE2 FROM dbo.PHAPARARTICLEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AR_CODEARTICLE1, AR_CODEARTICLE2)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage};
				break;
				case 1 :
				this.vapCritere ="WHERE AR_CODEARTICLE1=@AR_CODEARTICLE1";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE1" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
				this.vapCritere ="WHERE AR_CODEARTICLE1=@AR_CODEARTICLE1 AND AR_CODEARTICLE2=@AR_CODEARTICLE2";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AR_CODEARTICLE1","@AR_CODEARTICLE2"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
			}
		}
	}
}
