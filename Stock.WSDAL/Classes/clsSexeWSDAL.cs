using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsSexeWSDAL: ITableDAL<clsSexe>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT COUNT(SX_CODESEXE) AS SX_CODESEXE  FROM dbo.SEXE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT MIN(SX_CODESEXE) AS SX_CODESEXE  FROM dbo.SEXE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT MAX(SX_CODESEXE) AS SX_CODESEXE  FROM dbo.SEXE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsSexe comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsSexe pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT SX_LIBELLE  FROM dbo.SEXE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsSexe clsSexe = new clsSexe();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSexe.SX_LIBELLE = clsDonnee.vogDataReader["SX_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsSexe;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSexe>clsSexe</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsSexe clsSexe)
		{
			//Préparation des paramètres
			SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
			vppParamSX_CODESEXE.Value  = clsSexe.SX_CODESEXE ;
			SqlParameter vppParamSX_LIBELLE = new SqlParameter("@SX_LIBELLE", SqlDbType.VarChar, 150);
			vppParamSX_LIBELLE.Value  = clsSexe.SX_LIBELLE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO SEXE (  SX_CODESEXE, SX_LIBELLE) " +
					 "VALUES ( @SX_CODESEXE, @SX_LIBELLE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
			vppSqlCmd.Parameters.Add(vppParamSX_LIBELLE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSexe>clsSexe</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsSexe clsSexe,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamSX_LIBELLE = new SqlParameter("@SX_LIBELLE", SqlDbType.VarChar, 150);
			vppParamSX_LIBELLE.Value  = clsSexe.SX_LIBELLE ;

			//Préparation de la commande
            pvpChoixCritere(clsDonnee, vppCritere); 
			 this.vapRequete = "UPDATE SEXE SET " +
							"SX_LIBELLE = @SX_LIBELLE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSX_LIBELLE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  SEXE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSexe </returns>
		///<author>Home Technology</author>
		public List<clsSexe> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT  SX_CODESEXE, SX_LIBELLE FROM dbo.SEXE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsSexe> clsSexes = new List<clsSexe>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSexe clsSexe = new clsSexe();
					clsSexe.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsSexe.SX_LIBELLE = clsDonnee.vogDataReader["SX_LIBELLE"].ToString();
					clsSexes.Add(clsSexe);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSexes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSexe </returns>
		///<author>Home Technology</author>
		public List<clsSexe> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSexe> clsSexes = new List<clsSexe>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT  SX_CODESEXE, SX_LIBELLE FROM dbo.SEXE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsSexe clsSexe = new clsSexe();
					clsSexe.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
					clsSexe.SX_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["SX_LIBELLE"].ToString();
					clsSexes.Add(clsSexe);
				}
				Dataset.Dispose();
			}
		return clsSexes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_SEXE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SX_CODESEXE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT SX_CODESEXE , SX_LIBELLE FROM dbo.FT_SEXE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        /////<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SX_CODESEXE)</summary>
        /////<param name="vppCritere">Les critères de la requète</param>
        /////<author>Home Technologie</author>
        //public void pvpChoixCritere( params string[] vppCritere)
        //{
        //    switch (vppCritere.Length) 
        //     {
        //        case 0 :
        //        this.vapCritere ="";
        //        vapNomParametre = new string[]{};
        //        vapValeurParametre = new object[]{};
        //        break;
        //        case 1 :
        //        this.vapCritere = "WHERE SX_CODESEXE IN(" + clsDonnee.pvpParametreIN(vppCritere[0], "SX_CODESEXE") + ")";
        //            vapNomParametre = new string[] { "@CODECRYPTAGE", "@SX_CODESEXE" };
        //            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };

        //            vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[0], 1, "SX_CODESEXE");
        //            vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 1, "SX_CODESEXE");
        //            break;
        //    }
        //}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SX_CODESEXE  , )</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param> 
        ///<author>Home Technologie</author> 
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE SX_CODESEXE IN(" + clsDonnee.pvpParametreIN(vppCritere[0], "SX_CODESEXE") + ")";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@SX_CODESEXE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };

                    vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[0], 1, "SX_CODESEXE");
                    vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 1, "SX_CODESEXE");
                    break;
            }
        }
	}
}
