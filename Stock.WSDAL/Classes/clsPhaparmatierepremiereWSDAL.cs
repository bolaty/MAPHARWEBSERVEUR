using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparmatierepremiereWSDAL: ITableDAL<clsPhaparmatierepremiere>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.FT_PHAPARMATIEREPREMIERE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.FT_PHAPARMATIEREPREMIERE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.FT_PHAPARMATIEREPREMIERE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparmatierepremiere comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparmatierepremiere pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MP_QUANTITE  FROM dbo.FT_PHAPARMATIEREPREMIERE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparmatierepremiere clsPhaparmatierepremiere = new clsPhaparmatierepremiere();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparmatierepremiere.MP_QUANTITE = int.Parse(clsDonnee.vogDataReader["MP_QUANTITE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparmatierepremiere;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparmatierepremiere>clsPhaparmatierepremiere</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparmatierepremiere clsPhaparmatierepremiere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE0", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparmatierepremiere.AR_CODEARTICLE ;
			SqlParameter vppParamAR_CODEARTICLE1 = new SqlParameter("@AR_CODEARTICLE2", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE1.Value  = clsPhaparmatierepremiere.AR_CODEARTICLE1 ;
			SqlParameter vppParamMP_QUANTITE = new SqlParameter("@MP_QUANTITE", SqlDbType.Int);
			vppParamMP_QUANTITE.Value  = clsPhaparmatierepremiere.MP_QUANTITE ;
            SqlParameter vppParamMP_QUANTITEPERTE = new SqlParameter("@MP_QUANTITEPERTE", SqlDbType.Int);
            vppParamMP_QUANTITEPERTE.Value = clsPhaparmatierepremiere.MP_QUANTITEPERTE;
            SqlParameter vppParamMP_QUANTITEPERTEFICTIF = new SqlParameter("@MP_QUANTITEPERTEFICTIF", SqlDbType.Int);
            vppParamMP_QUANTITEPERTEFICTIF.Value = clsPhaparmatierepremiere.MP_QUANTITEPERTEFICTIF;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARMATIEREPREMIERE  @AR_CODEARTICLE0, @AR_CODEARTICLE2, @MP_QUANTITE,@MP_QUANTITEPERTE,@MP_QUANTITEPERTEFICTIF, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE1);
			vppSqlCmd.Parameters.Add(vppParamMP_QUANTITE);
            vppSqlCmd.Parameters.Add(vppParamMP_QUANTITEPERTE);
            vppSqlCmd.Parameters.Add(vppParamMP_QUANTITEPERTEFICTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparmatierepremiere>clsPhaparmatierepremiere</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparmatierepremiere clsPhaparmatierepremiere,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparmatierepremiere.AR_CODEARTICLE ;
			SqlParameter vppParamAR_CODEARTICLE1 = new SqlParameter("@AR_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE1.Value  = clsPhaparmatierepremiere.AR_CODEARTICLE1 ;
			SqlParameter vppParamMP_QUANTITE = new SqlParameter("@MP_QUANTITE", SqlDbType.Int);
			vppParamMP_QUANTITE.Value  = clsPhaparmatierepremiere.MP_QUANTITE ;
            SqlParameter vppParamMP_QUANTITEPERTE = new SqlParameter("@MP_QUANTITEPERTE", SqlDbType.Int);
            vppParamMP_QUANTITEPERTE.Value = clsPhaparmatierepremiere.MP_QUANTITEPERTE;
            SqlParameter vppParamMP_QUANTITEPERTEFICTIF = new SqlParameter("@MP_QUANTITEPERTEFICTIF", SqlDbType.Int);
            vppParamMP_QUANTITEPERTEFICTIF.Value = clsPhaparmatierepremiere.MP_QUANTITEPERTEFICTIF;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARMATIEREPREMIERE  @AR_CODEARTICLE, @AR_CODEARTICLE1, @MP_QUANTITE,@MP_QUANTITEPERTE,@MP_QUANTITEPERTEFICTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE1);
			vppSqlCmd.Parameters.Add(vppParamMP_QUANTITE);
            vppSqlCmd.Parameters.Add(vppParamMP_QUANTITEPERTE);
            vppSqlCmd.Parameters.Add(vppParamMP_QUANTITEPERTEFICTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARMATIEREPREMIERE  @AR_CODEARTICLE, @AR_CODEARTICLE1, 0 ,0 ,0 , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparmatierepremiere </returns>
		///<author>Home Technology</author>
		public List<clsPhaparmatierepremiere> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE, AR_CODEARTICLE1, MP_QUANTITE FROM dbo.FT_PHAPARMATIEREPREMIERE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparmatierepremiere> clsPhaparmatierepremieres = new List<clsPhaparmatierepremiere>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparmatierepremiere clsPhaparmatierepremiere = new clsPhaparmatierepremiere();
					clsPhaparmatierepremiere.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparmatierepremiere.AR_CODEARTICLE1 = clsDonnee.vogDataReader["AR_CODEARTICLE1"].ToString();
					clsPhaparmatierepremiere.MP_QUANTITE = int.Parse(clsDonnee.vogDataReader["MP_QUANTITE"].ToString());
					clsPhaparmatierepremieres.Add(clsPhaparmatierepremiere);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparmatierepremieres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparmatierepremiere </returns>
		///<author>Home Technology</author>
		public List<clsPhaparmatierepremiere> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparmatierepremiere> clsPhaparmatierepremieres = new List<clsPhaparmatierepremiere>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE, AR_CODEARTICLE1, MP_QUANTITE FROM dbo.FT_PHAPARMATIEREPREMIERE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparmatierepremiere clsPhaparmatierepremiere = new clsPhaparmatierepremiere();
					clsPhaparmatierepremiere.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaparmatierepremiere.AR_CODEARTICLE1 = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE1"].ToString();
					clsPhaparmatierepremiere.MP_QUANTITE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MP_QUANTITE"].ToString());
					clsPhaparmatierepremieres.Add(clsPhaparmatierepremiere);
				}
				Dataset.Dispose();
			}
		return clsPhaparmatierepremieres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARMATIEREPREMIERE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, AR_CODEARTICLE1 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AR_CODEARTICLE , MP_QUANTITE FROM dbo.FT_PHAPARMATIEREPREMIERE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AR_CODEARTICLE, AR_CODEARTICLE1)</summary>
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
				this.vapCritere ="WHERE AR_CODEARTICLE=@AR_CODEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AR_CODEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AR_CODEARTICLE=@AR_CODEARTICLE AND AR_CODEARTICLE1=@AR_CODEARTICLE1";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AR_CODEARTICLE","@AR_CODEARTICLE1"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
