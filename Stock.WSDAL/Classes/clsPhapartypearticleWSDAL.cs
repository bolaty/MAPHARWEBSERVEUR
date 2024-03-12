using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypearticleWSDAL: ITableDAL<clsPhapartypearticle>
	{
		private string vapCritere = ""; 
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(TA_CODETYPEARTICLE) AS TA_CODETYPEARTICLE  FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCountNombreLibelle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE TA_LIBELLE=@TA_LIBELLE ";
            vapNomParametre = new string[] { "@TA_LIBELLE" };
            vapValeurParametre = new object[] { vppCritere[0] };
            this.vapRequete = "SELECT COUNT(TA_CODETYPEARTICLE) AS TA_CODETYPEARTICLE  FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCountNombreLibellemODIF(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE TA_LIBELLE=@TA_LIBELLE AND TA_CODETYPEARTICLE<>@TA_CODETYPEARTICLE";
            vapNomParametre = new string[] { "@TA_LIBELLE", "@TA_CODETYPEARTICLE" };
            vapValeurParametre = new object[] { vppCritere[0],vppCritere[1] };
            this.vapRequete = "SELECT COUNT(TA_CODETYPEARTICLE) AS TA_CODETYPEARTICLE  FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(TA_CODETYPEARTICLE) AS TA_CODETYPEARTICLE  FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere4(vppCritere);
			this.vapRequete = "SELECT MAX(TA_CODETYPEARTICLE) AS TA_CODETYPEARTICLE  FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypearticle comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypearticle pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TA_LIBELLE  FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypearticle clsPhapartypearticle = new clsPhapartypearticle();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticle.TA_LIBELLE = clsDonnee.vogDataReader["TA_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypearticle;
		}










		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticle>clsPhapartypearticle</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypearticle clsPhapartypearticle)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 3);
			vppParamTA_CODETYPEARTICLE.Value  = clsPhapartypearticle.TA_CODETYPEARTICLE ;

			SqlParameter vppParamTA_LIBELLE = new SqlParameter("@TA_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLE.Value  = clsPhapartypearticle.TA_LIBELLE ;

            SqlParameter vppParamNT_CODENATURETYPEARTICLE = new SqlParameter("@NT_CODENATURETYPEARTICLE", SqlDbType.VarChar, 2);
            vppParamNT_CODENATURETYPEARTICLE.Value = clsPhapartypearticle.NT_CODENATURETYPEARTICLE;
			//Préparation de la commande
            this.vapRequete = "INSERT INTO PHAPARTYPEARTICLE (  TA_CODETYPEARTICLE, TA_LIBELLE,NT_CODENATURETYPEARTICLE) " +
                     "VALUES ( @TA_CODETYPEARTICLE, @TA_LIBELLE,@NT_CODENATURETYPEARTICLE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPEARTICLE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticle>clsPhapartypearticle</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypearticle clsPhapartypearticle,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_LIBELLE = new SqlParameter("@TA_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLE.Value  = clsPhapartypearticle.TA_LIBELLE ;

            SqlParameter vppParamNT_CODENATURETYPEARTICLE = new SqlParameter("@NT_CODENATURETYPEARTICLE", SqlDbType.VarChar, 2);
            vppParamNT_CODENATURETYPEARTICLE.Value = clsPhapartypearticle.NT_CODENATURETYPEARTICLE;

			//Préparation de la commande
			 pvpChoixCritere4(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARTYPEARTICLE SET " +
                            "TA_LIBELLE = @TA_LIBELLE ,NT_CODENATURETYPEARTICLE = @NT_CODENATURETYPEARTICLE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPEARTICLE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere4(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARTYPEARTICLE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticle </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticle> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPEARTICLE, TA_LIBELLE FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypearticle> clsPhapartypearticles = new List<clsPhapartypearticle>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticle clsPhapartypearticle = new clsPhapartypearticle();
					clsPhapartypearticle.TA_CODETYPEARTICLE = clsDonnee.vogDataReader["TA_CODETYPEARTICLE"].ToString();
					clsPhapartypearticle.TA_LIBELLE = clsDonnee.vogDataReader["TA_LIBELLE"].ToString();
					clsPhapartypearticles.Add(clsPhapartypearticle);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypearticles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticle </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticle> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypearticle> clsPhapartypearticles = new List<clsPhapartypearticle>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPEARTICLE, TA_LIBELLE FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypearticle clsPhapartypearticle = new clsPhapartypearticle();
					clsPhapartypearticle.TA_CODETYPEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPEARTICLE"].ToString();
					clsPhapartypearticle.TA_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TA_LIBELLE"].ToString();
					clsPhapartypearticles.Add(clsPhapartypearticle);
				}
				Dataset.Dispose();
			}
		return clsPhapartypearticles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT *,REP_MONTANT=0 FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRepartition(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@TYPEOPERATION" };
            vapValeurParametre = new object[] { vppCritere[0] };
            this.vapRequete = "EXEC [dbo].[PS_PHAPARTYPEARTICLEREAPARTION] @TYPEOPERATION " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT TA_CODETYPEARTICLE , TA_LIBELLE,NT_CODENATURETYPEARTICLE FROM dbo.PHAPARTYPEARTICLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}
        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboModeGestion(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        pvpChoixCritere3(vppCritere);
            this.vapRequete = "SELECT TA_CODETYPEARTICLE , TA_LIBELLE,NT_CODENATURETYPEARTICLE FROM dbo.VUE_PHAPARNATURETYPEARTICLEPARAMETRE " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETYPEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboTypeArticleSelonLesNaturesTypeArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@NT_CODENATURETYPEARTICLE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'") };
            this.vapRequete = "EXEC [PS_COMBOTYPEARTICLE] @NT_CODENATURETYPEARTICLE,'' " ;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPEARTICLE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere = " ORDER BY TA_LIBELLE";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
                this.vapCritere = "WHERE NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE ORDER BY TA_LIBELLE";
                vapNomParametre = new string[] { "@NT_CODENATURETYPEARTICLE" };
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
                case 2:
                this.vapCritere = "WHERE NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE AND TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE ORDER BY TA_LIBELLE";
                vapNomParametre = new string[] { "@NT_CODENATURETYPEARTICLE", "@TA_CODETYPEARTICLE" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}


            ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPEARTICLE)</summary>
            ///<param name="vppCritere">Les critères de la requète</param>
            ///<author>Home Technologie</author>
            public void pvpChoixCritere1( params string[] vppCritere)
            {
	            switch (vppCritere.Length) 
		            {
		            case 0 :
		            this.vapCritere = "";
		            vapNomParametre = new string[]{};
		            vapValeurParametre = new object[]{};
		            break;
		            case 1 :
                    this.vapCritere = "WHERE NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE ";
                    vapNomParametre = new string[] { "@NT_CODENATURETYPEARTICLE" };
		            vapValeurParametre = new object[]{vppCritere[0]};
		            break;
                    case 2:
                    this.vapCritere = "WHERE NT_CODENATURETYPEARTICLE=@NT_CODENATURETYPEARTICLE AND TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE";
                    vapNomParametre = new string[] { "@NT_CODENATURETYPEARTICLE", "@TA_CODETYPEARTICLE" };
		            vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
		            break;
	            }
            }







        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPEARTICLE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere4(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = "WHERE TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE";
                    vapNomParametre = new string[] { "@TA_CODETYPEARTICLE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
               
            }
        }





        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPEARTICLE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere3(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = " ORDER BY TA_LIBELLE";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND NT_ACTIF='O' ORDER BY TA_LIBELLE";
                    vapNomParametre = new string[] { "@MG_CODEMODEGESTION" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND EC_CODECRAN=@EC_CODECRAN  AND NT_ACTIF='O' ORDER BY TA_LIBELLE";
                    vapNomParametre = new string[] { "@MG_CODEMODEGESTION", "@EC_CODECRAN" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }
	}
}
