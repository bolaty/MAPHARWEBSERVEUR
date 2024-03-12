using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypequantitedetailWSDAL: ITableDAL<clsPhapartypequantitedetail>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TQ_CODETYPEQUANTITE) AS TQ_CODETYPEQUANTITE  FROM dbo.FT_PHAPARTYPEQUANTITEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TQ_CODETYPEQUANTITE) AS TQ_CODETYPEQUANTITE  FROM dbo.FT_PHAPARTYPEQUANTITEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TQ_CODETYPEQUANTITE) AS TQ_CODETYPEQUANTITE  FROM dbo.FT_PHAPARTYPEQUANTITEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypequantitedetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypequantitedetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TQ_QUANTITE  , TQ_PERSONNECONCERNEE  FROM dbo.FT_PHAPARTYPEQUANTITEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypequantitedetail clsPhapartypequantitedetail = new clsPhapartypequantitedetail();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypequantitedetail.TQ_QUANTITE = int.Parse(clsDonnee.vogDataReader["TQ_QUANTITE"].ToString());
					clsPhapartypequantitedetail.TQ_PERSONNECONCERNEE = clsDonnee.vogDataReader["TQ_PERSONNECONCERNEE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypequantitedetail;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypequantitedetail>clsPhapartypequantitedetail</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypequantitedetail clsPhapartypequantitedetail)
		{
			//Préparation des paramètres
			SqlParameter vppParamTQ_CODETYPEQUANTITE = new SqlParameter("@TQ_CODETYPEQUANTITE1", SqlDbType.VarChar, 2);
			vppParamTQ_CODETYPEQUANTITE.Value  = clsPhapartypequantitedetail.TQ_CODETYPEQUANTITE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhapartypequantitedetail.AR_CODEARTICLE ;
			SqlParameter vppParamTQ_QUANTITE = new SqlParameter("@TQ_QUANTITE", SqlDbType.Int);
			vppParamTQ_QUANTITE.Value  = clsPhapartypequantitedetail.TQ_QUANTITE ;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEQUANTITEDETAIL  @TQ_CODETYPEQUANTITE1, @AR_CODEARTICLE1, @TQ_QUANTITE,  @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTQ_CODETYPEQUANTITE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamTQ_QUANTITE);
			
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypequantitedetail>clsPhapartypequantitedetail</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypequantitedetail clsPhapartypequantitedetail,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTQ_CODETYPEQUANTITE = new SqlParameter("@TQ_CODETYPEQUANTITE1", SqlDbType.VarChar, 2);
			vppParamTQ_CODETYPEQUANTITE.Value  = clsPhapartypequantitedetail.TQ_CODETYPEQUANTITE ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhapartypequantitedetail.AR_CODEARTICLE ;
			SqlParameter vppParamTQ_QUANTITE = new SqlParameter("@TQ_QUANTITE", SqlDbType.Int);
			vppParamTQ_QUANTITE.Value  = clsPhapartypequantitedetail.TQ_QUANTITE ;
			
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEQUANTITEDETAIL  @TQ_CODETYPEQUANTITE1, @AR_CODEARTICLE1, @TQ_QUANTITE, @CODECRYPTAGE1, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTQ_CODETYPEQUANTITE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamTQ_QUANTITE);
			
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEQUANTITEDETAIL  @TQ_CODETYPEQUANTITE, @AR_CODEARTICLE, '' ,  @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AR_CODEARTICLE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARTYPEQUANTITEDETAIL  '', @AR_CODEARTICLE, '' ,  @CODECRYPTAGE, 3 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypequantitedetail </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypequantitedetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TQ_CODETYPEQUANTITE, AR_CODEARTICLE, TQ_QUANTITE FROM dbo.FT_PHAPARTYPEQUANTITEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypequantitedetail> clsPhapartypequantitedetails = new List<clsPhapartypequantitedetail>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypequantitedetail clsPhapartypequantitedetail = new clsPhapartypequantitedetail();
					clsPhapartypequantitedetail.TQ_CODETYPEQUANTITE = clsDonnee.vogDataReader["TQ_CODETYPEQUANTITE"].ToString();
					clsPhapartypequantitedetail.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhapartypequantitedetail.TQ_QUANTITE = int.Parse(clsDonnee.vogDataReader["TQ_QUANTITE"].ToString());
					
					clsPhapartypequantitedetails.Add(clsPhapartypequantitedetail);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypequantitedetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypequantitedetail </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypequantitedetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypequantitedetail> clsPhapartypequantitedetails = new List<clsPhapartypequantitedetail>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TQ_CODETYPEQUANTITE, AR_CODEARTICLE, TQ_QUANTITE FROM dbo.FT_PHAPARTYPEQUANTITEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypequantitedetail clsPhapartypequantitedetail = new clsPhapartypequantitedetail();
					clsPhapartypequantitedetail.TQ_CODETYPEQUANTITE = Dataset.Tables["TABLE"].Rows[Idx]["TQ_CODETYPEQUANTITE"].ToString();
					clsPhapartypequantitedetail.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhapartypequantitedetail.TQ_QUANTITE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TQ_QUANTITE"].ToString());
					
					clsPhapartypequantitedetails.Add(clsPhapartypequantitedetail);
				}
				Dataset.Dispose();
			}
		return clsPhapartypequantitedetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARTYPEQUANTITEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TQ_CODETYPEQUANTITE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TQ_CODETYPEQUANTITE , TQ_QUANTITE FROM dbo.FT_PHAPARTYPEQUANTITEDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TQ_CODETYPEQUANTITE, AR_CODEARTICLE)</summary>
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
				this.vapCritere ="WHERE TQ_CODETYPEQUANTITE=@TQ_CODETYPEQUANTITE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TQ_CODETYPEQUANTITE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TQ_CODETYPEQUANTITE=@TQ_CODETYPEQUANTITE AND AR_CODEARTICLE=@AR_CODEARTICLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TQ_CODETYPEQUANTITE","@AR_CODEARTICLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
