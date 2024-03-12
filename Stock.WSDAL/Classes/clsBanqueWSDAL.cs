using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBanqueWSDAL: ITableDAL<clsBanque>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(BQ_CODEBANQUE) AS BQ_CODEBANQUE  FROM dbo.FT_BANQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(BQ_CODEBANQUE) AS BQ_CODEBANQUE  FROM dbo.FT_BANQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(BQ_CODEBANQUE) AS BQ_CODEBANQUE  FROM dbo.BANQUE" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBanque comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBanque pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT BQ_BANQUECODE  , BQ_RAISONSOCIAL  , BQ_SIGLE  FROM dbo.FT_BANQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBanque clsBanque = new clsBanque();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBanque.BQ_BANQUECODE = clsDonnee.vogDataReader["BQ_BANQUECODE"].ToString();
					clsBanque.BQ_RAISONSOCIAL = clsDonnee.vogDataReader["BQ_RAISONSOCIAL"].ToString();
					clsBanque.BQ_SIGLE = clsDonnee.vogDataReader["BQ_SIGLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBanque;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBanque>clsBanque</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBanque clsBanque)
		{
			//Préparation des paramètres
			SqlParameter vppParamBQ_CODEBANQUE = new SqlParameter("@BQ_CODEBANQUE1", SqlDbType.Int);
			vppParamBQ_CODEBANQUE.Value  = clsBanque.BQ_CODEBANQUE ;
			SqlParameter vppParamBQ_BANQUECODE = new SqlParameter("@BQ_BANQUECODE", SqlDbType.VarChar, 10);
			vppParamBQ_BANQUECODE.Value  = clsBanque.BQ_BANQUECODE ;
			if(clsBanque.BQ_BANQUECODE== ""  ) vppParamBQ_BANQUECODE.Value  = DBNull.Value;
			SqlParameter vppParamBQ_RAISONSOCIAL = new SqlParameter("@BQ_RAISONSOCIAL", SqlDbType.VarChar, 150);
			vppParamBQ_RAISONSOCIAL.Value  = clsBanque.BQ_RAISONSOCIAL ;
			SqlParameter vppParamBQ_SIGLE = new SqlParameter("@BQ_SIGLE", SqlDbType.VarChar, 150);
			vppParamBQ_SIGLE.Value  = clsBanque.BQ_SIGLE ;
			if(clsBanque.BQ_SIGLE== ""  ) vppParamBQ_SIGLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BANQUE  @BQ_CODEBANQUE1, @BQ_BANQUECODE, @BQ_RAISONSOCIAL, @BQ_SIGLE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamBQ_CODEBANQUE);
			vppSqlCmd.Parameters.Add(vppParamBQ_BANQUECODE);
			vppSqlCmd.Parameters.Add(vppParamBQ_RAISONSOCIAL);
			vppSqlCmd.Parameters.Add(vppParamBQ_SIGLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBanque>clsBanque</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBanque clsBanque,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamBQ_CODEBANQUE = new SqlParameter("@BQ_CODEBANQUE", SqlDbType.Int);
			vppParamBQ_CODEBANQUE.Value  = clsBanque.BQ_CODEBANQUE ;
			SqlParameter vppParamBQ_BANQUECODE = new SqlParameter("@BQ_BANQUECODE", SqlDbType.VarChar, 10);
			vppParamBQ_BANQUECODE.Value  = clsBanque.BQ_BANQUECODE ;
			if(clsBanque.BQ_BANQUECODE== ""  ) vppParamBQ_BANQUECODE.Value  = DBNull.Value;
			SqlParameter vppParamBQ_RAISONSOCIAL = new SqlParameter("@BQ_RAISONSOCIAL", SqlDbType.VarChar, 150);
			vppParamBQ_RAISONSOCIAL.Value  = clsBanque.BQ_RAISONSOCIAL ;
			SqlParameter vppParamBQ_SIGLE = new SqlParameter("@BQ_SIGLE", SqlDbType.VarChar, 150);
			vppParamBQ_SIGLE.Value  = clsBanque.BQ_SIGLE ;
			if(clsBanque.BQ_SIGLE== ""  ) vppParamBQ_SIGLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BANQUE  @BQ_CODEBANQUE, @BQ_BANQUECODE, @BQ_RAISONSOCIAL, @BQ_SIGLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamBQ_CODEBANQUE);
			vppSqlCmd.Parameters.Add(vppParamBQ_BANQUECODE);
			vppSqlCmd.Parameters.Add(vppParamBQ_RAISONSOCIAL);
			vppSqlCmd.Parameters.Add(vppParamBQ_SIGLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BANQUE  @BQ_CODEBANQUE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBanque </returns>
		///<author>Home Technology</author>
		public List<clsBanque> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  BQ_CODEBANQUE, BQ_BANQUECODE, BQ_RAISONSOCIAL, BQ_SIGLE FROM dbo.FT_BANQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBanque> clsBanques = new List<clsBanque>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBanque clsBanque = new clsBanque();
					clsBanque.BQ_CODEBANQUE = clsDonnee.vogDataReader["BQ_CODEBANQUE"].ToString();
					clsBanque.BQ_BANQUECODE = clsDonnee.vogDataReader["BQ_BANQUECODE"].ToString();
					clsBanque.BQ_RAISONSOCIAL = clsDonnee.vogDataReader["BQ_RAISONSOCIAL"].ToString();
					clsBanque.BQ_SIGLE = clsDonnee.vogDataReader["BQ_SIGLE"].ToString();
					clsBanques.Add(clsBanque);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBanques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBanque </returns>
		///<author>Home Technology</author>
		public List<clsBanque> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBanque> clsBanques = new List<clsBanque>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  BQ_CODEBANQUE, BQ_BANQUECODE, BQ_RAISONSOCIAL, BQ_SIGLE FROM dbo.FT_BANQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBanque clsBanque = new clsBanque();
					clsBanque.BQ_CODEBANQUE = Dataset.Tables["TABLE"].Rows[Idx]["BQ_CODEBANQUE"].ToString();
					clsBanque.BQ_BANQUECODE = Dataset.Tables["TABLE"].Rows[Idx]["BQ_BANQUECODE"].ToString();
					clsBanque.BQ_RAISONSOCIAL = Dataset.Tables["TABLE"].Rows[Idx]["BQ_RAISONSOCIAL"].ToString();
					clsBanque.BQ_SIGLE = Dataset.Tables["TABLE"].Rows[Idx]["BQ_SIGLE"].ToString();
					clsBanques.Add(clsBanque);
				}
				Dataset.Dispose();
			}
		return clsBanques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BANQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : BQ_CODEBANQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT BQ_CODEBANQUE , BQ_RAISONSOCIAL FROM dbo.FT_BANQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :BQ_CODEBANQUE)</summary>
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
				this.vapCritere ="WHERE BQ_CODEBANQUE=@BQ_CODEBANQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@BQ_CODEBANQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
