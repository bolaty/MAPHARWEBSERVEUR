using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparbrancheWSDAL: ITableDAL<clsCtparbranche>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CB_IDBRANCHE) AS CB_IDBRANCHE  FROM dbo.FT_CTPARBRANCHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CB_IDBRANCHE) AS CB_IDBRANCHE  FROM dbo.FT_CTPARBRANCHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CB_IDBRANCHE) AS CB_IDBRANCHE  FROM dbo.FT_CTPARBRANCHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparbranche comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparbranche pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CB_CODEBRANCHE  , CB_LIBELLEBRANCHE  , CB_ACTIF  , CB_NUMEROORDRE  FROM dbo.FT_CTPARBRANCHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparbranche clsCtparbranche = new clsCtparbranche();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparbranche.CB_CODEBRANCHE = clsDonnee.vogDataReader["CB_CODEBRANCHE"].ToString();
					clsCtparbranche.CB_LIBELLEBRANCHE = clsDonnee.vogDataReader["CB_LIBELLEBRANCHE"].ToString();
					clsCtparbranche.CB_ACTIF = clsDonnee.vogDataReader["CB_ACTIF"].ToString();
					clsCtparbranche.CB_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CB_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparbranche;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparbranche>clsCtparbranche</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparbranche clsCtparbranche)
		{
			//Préparation des paramètres
			SqlParameter vppParamCB_IDBRANCHE = new SqlParameter("@CB_IDBRANCHE", SqlDbType.VarChar, 25);
			vppParamCB_IDBRANCHE.Value  = clsCtparbranche.CB_IDBRANCHE ;
			SqlParameter vppParamCB_CODEBRANCHE = new SqlParameter("@CB_CODEBRANCHE", SqlDbType.VarChar, 4);
			vppParamCB_CODEBRANCHE.Value  = clsCtparbranche.CB_CODEBRANCHE ;
			SqlParameter vppParamCB_LIBELLEBRANCHE = new SqlParameter("@CB_LIBELLEBRANCHE", SqlDbType.VarChar, 150);
			vppParamCB_LIBELLEBRANCHE.Value  = clsCtparbranche.CB_LIBELLEBRANCHE ;
			SqlParameter vppParamCB_ACTIF = new SqlParameter("@CB_ACTIF", SqlDbType.VarChar, 1);
			vppParamCB_ACTIF.Value  = clsCtparbranche.CB_ACTIF ;
			SqlParameter vppParamCB_NUMEROORDRE = new SqlParameter("@CB_NUMEROORDRE", SqlDbType.Int);
			vppParamCB_NUMEROORDRE.Value  = clsCtparbranche.CB_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARBRANCHE  @CB_IDBRANCHE, @CB_CODEBRANCHE, @CB_LIBELLEBRANCHE, @CB_ACTIF, @CB_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCB_IDBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamCB_CODEBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamCB_LIBELLEBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamCB_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCB_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparbranche>clsCtparbranche</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparbranche clsCtparbranche,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCB_IDBRANCHE = new SqlParameter("@CB_IDBRANCHE", SqlDbType.VarChar, 25);
			vppParamCB_IDBRANCHE.Value  = clsCtparbranche.CB_IDBRANCHE ;
			SqlParameter vppParamCB_CODEBRANCHE = new SqlParameter("@CB_CODEBRANCHE", SqlDbType.VarChar, 4);
			vppParamCB_CODEBRANCHE.Value  = clsCtparbranche.CB_CODEBRANCHE ;
			SqlParameter vppParamCB_LIBELLEBRANCHE = new SqlParameter("@CB_LIBELLEBRANCHE", SqlDbType.VarChar, 150);
			vppParamCB_LIBELLEBRANCHE.Value  = clsCtparbranche.CB_LIBELLEBRANCHE ;
			SqlParameter vppParamCB_ACTIF = new SqlParameter("@CB_ACTIF", SqlDbType.VarChar, 1);
			vppParamCB_ACTIF.Value  = clsCtparbranche.CB_ACTIF ;
			SqlParameter vppParamCB_NUMEROORDRE = new SqlParameter("@CB_NUMEROORDRE", SqlDbType.Int);
			vppParamCB_NUMEROORDRE.Value  = clsCtparbranche.CB_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARBRANCHE  @CB_IDBRANCHE, @CB_CODEBRANCHE, @CB_LIBELLEBRANCHE, @CB_ACTIF, @CB_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCB_IDBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamCB_CODEBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamCB_LIBELLEBRANCHE);
			vppSqlCmd.Parameters.Add(vppParamCB_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCB_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARBRANCHE  @CB_IDBRANCHE, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparbranche </returns>
		///<author>Home Technology</author>
		public List<clsCtparbranche> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CB_IDBRANCHE, CB_CODEBRANCHE, CB_LIBELLEBRANCHE, CB_ACTIF, CB_NUMEROORDRE FROM dbo.FT_CTPARBRANCHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparbranche> clsCtparbranches = new List<clsCtparbranche>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparbranche clsCtparbranche = new clsCtparbranche();
					clsCtparbranche.CB_IDBRANCHE = clsDonnee.vogDataReader["CB_IDBRANCHE"].ToString();
					clsCtparbranche.CB_CODEBRANCHE = clsDonnee.vogDataReader["CB_CODEBRANCHE"].ToString();
					clsCtparbranche.CB_LIBELLEBRANCHE = clsDonnee.vogDataReader["CB_LIBELLEBRANCHE"].ToString();
					clsCtparbranche.CB_ACTIF = clsDonnee.vogDataReader["CB_ACTIF"].ToString();
					clsCtparbranche.CB_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CB_NUMEROORDRE"].ToString());
					clsCtparbranches.Add(clsCtparbranche);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparbranches;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparbranche </returns>
		///<author>Home Technology</author>
		public List<clsCtparbranche> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparbranche> clsCtparbranches = new List<clsCtparbranche>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CB_IDBRANCHE, CB_CODEBRANCHE, CB_LIBELLEBRANCHE, CB_ACTIF, CB_NUMEROORDRE FROM dbo.FT_CTPARBRANCHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparbranche clsCtparbranche = new clsCtparbranche();
					clsCtparbranche.CB_IDBRANCHE = Dataset.Tables["TABLE"].Rows[Idx]["CB_IDBRANCHE"].ToString();
					clsCtparbranche.CB_CODEBRANCHE = Dataset.Tables["TABLE"].Rows[Idx]["CB_CODEBRANCHE"].ToString();
					clsCtparbranche.CB_LIBELLEBRANCHE = Dataset.Tables["TABLE"].Rows[Idx]["CB_LIBELLEBRANCHE"].ToString();
					clsCtparbranche.CB_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["CB_ACTIF"].ToString();
					clsCtparbranche.CB_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CB_NUMEROORDRE"].ToString());
					clsCtparbranches.Add(clsCtparbranche);
				}
				Dataset.Dispose();
			}
		return clsCtparbranches;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARBRANCHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CB_IDBRANCHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CB_IDBRANCHE , CB_LIBELLEBRANCHE FROM dbo.FT_CTPARBRANCHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CB_IDBRANCHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboSelonRisque(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODERISQUE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
            this.vapRequete = "SELECT CB_IDBRANCHE , CB_LIBELLEBRANCHE FROM dbo.FT_CTPARBRANCHERISQUEASSURANCE(@RQ_CODERISQUE,@CODECRYPTAGE) ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CB_IDBRANCHE)</summary>
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
				this.vapCritere ="WHERE CB_IDBRANCHE=@CB_IDBRANCHE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CB_IDBRANCHE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
