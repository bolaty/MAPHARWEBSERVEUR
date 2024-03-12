using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementStockaccessoireWSDAL: ITableDAL<clsPhamouvementStockaccessoire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(MD_NUMSEQUENCE) AS AC_NUMSEQUENCE  FROM dbo.PhamouvementStockACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(AC_NUMSEQUENCE) AS AC_NUMSEQUENCE  FROM dbo.PhamouvementStockACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(AC_NUMSEQUENCE) AS AC_NUMSEQUENCE  FROM dbo.PhamouvementStockACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockaccessoire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockaccessoire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MD_NUMSEQUENCE,AC_CODEARTICLE1,AC_CODEARTICLE2,AC_UNITE,AC_QUANTITEENTREE,AC_QUANTITESORTIE,AC_PRIXUNITAIRE  FROM dbo.PhamouvementStockACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire = new clsPhamouvementStockaccessoire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockaccessoire.MD_NUMSEQUENCE = clsDonnee.vogDataReader["MD_NUMSEQUENCE"].ToString();
					clsPhamouvementStockaccessoire.AC_CODEARTICLE1 = clsDonnee.vogDataReader["AC_CODEARTICLE1"].ToString();
					clsPhamouvementStockaccessoire.AC_CODEARTICLE2 = clsDonnee.vogDataReader["AC_CODEARTICLE2"].ToString();
					clsPhamouvementStockaccessoire.AC_UNITE = double.Parse(clsDonnee.vogDataReader["AC_UNITE"].ToString());
					clsPhamouvementStockaccessoire.AC_QUANTITEENTREE = double.Parse(clsDonnee.vogDataReader["AC_QUANTITEENTREE"].ToString());
					clsPhamouvementStockaccessoire.AC_QUANTITESORTIE = double.Parse(clsDonnee.vogDataReader["AC_QUANTITESORTIE"].ToString());
					clsPhamouvementStockaccessoire.AC_PRIXUNITAIRE = double.Parse(clsDonnee.vogDataReader["AC_PRIXUNITAIRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementStockaccessoire;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockaccessoire>clsPhamouvementStockaccessoire</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire)
		{
			//Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockaccessoire.AG_CODEAGENCE;

			SqlParameter vppParamAC_NUMSEQUENCE = new SqlParameter("@AC_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamAC_NUMSEQUENCE.Value  = clsPhamouvementStockaccessoire.AC_NUMSEQUENCE ;

			SqlParameter vppParamMD_NUMSEQUENCE = new SqlParameter("@MD_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamMD_NUMSEQUENCE.Value  = clsPhamouvementStockaccessoire.MD_NUMSEQUENCE ;

			SqlParameter vppParamAC_CODEARTICLE1 = new SqlParameter("@AC_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamAC_CODEARTICLE1.Value  = clsPhamouvementStockaccessoire.AC_CODEARTICLE1 ;

			SqlParameter vppParamAC_CODEARTICLE2 = new SqlParameter("@AC_CODEARTICLE2", SqlDbType.VarChar, 7);
			vppParamAC_CODEARTICLE2.Value  = clsPhamouvementStockaccessoire.AC_CODEARTICLE2 ;

			SqlParameter vppParamAC_UNITE = new SqlParameter("@AC_UNITE", SqlDbType.BigInt);
			vppParamAC_UNITE.Value  = clsPhamouvementStockaccessoire.AC_UNITE ;

			SqlParameter vppParamAC_QUANTITEENTREE = new SqlParameter("@AC_QUANTITEENTREE", SqlDbType.BigInt);
			vppParamAC_QUANTITEENTREE.Value  = clsPhamouvementStockaccessoire.AC_QUANTITEENTREE ;

			SqlParameter vppParamAC_QUANTITESORTIE = new SqlParameter("@AC_QUANTITESORTIE", SqlDbType.BigInt);
			vppParamAC_QUANTITESORTIE.Value  = clsPhamouvementStockaccessoire.AC_QUANTITESORTIE ;



			SqlParameter vppParamAC_PRIXUNITAIRE = new SqlParameter("@AC_PRIXUNITAIRE", SqlDbType.Money);
			vppParamAC_PRIXUNITAIRE.Value  = clsPhamouvementStockaccessoire.AC_PRIXUNITAIRE ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar,25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStockaccessoire.OP_CODEOPERATEUR;

			//Préparation de la commande
            this.vapRequete = "INSERT INTO PhamouvementStockACCESSOIRE ( AG_CODEAGENCE, AC_NUMSEQUENCE, MD_NUMSEQUENCE, AC_CODEARTICLE1, AC_CODEARTICLE2, AC_UNITE, AC_QUANTITEENTREE, AC_QUANTITESORTIE, AC_PRIXUNITAIRE, OP_CODEOPERATEUR) " +
                     "VALUES ( @AG_CODEAGENCE,@AC_NUMSEQUENCE, @MD_NUMSEQUENCE, @AC_CODEARTICLE1, @AC_CODEARTICLE2, @AC_UNITE, @AC_QUANTITEENTREE, @AC_QUANTITESORTIE, @AC_PRIXUNITAIRE, @OP_CODEOPERATEUR) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAC_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAC_CODEARTICLE1);
			vppSqlCmd.Parameters.Add(vppParamAC_CODEARTICLE2);
			vppSqlCmd.Parameters.Add(vppParamAC_UNITE);
			vppSqlCmd.Parameters.Add(vppParamAC_QUANTITEENTREE);
			vppSqlCmd.Parameters.Add(vppParamAC_QUANTITESORTIE);
			vppSqlCmd.Parameters.Add(vppParamAC_PRIXUNITAIRE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}






        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockaccessoire>clsPhamouvementstockaccessoire</param>
        ///<author>Home Technology</author>
        public void pvgMiseAjour(clsDonnee clsDonnee, clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire)
        {
            //Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockaccessoire.AG_CODEAGENCE;
            SqlParameter vppParamAC_NUMSEQUENCE = new SqlParameter("@AC_NUMSEQUENCE", SqlDbType.VarChar, 50);
            vppParamAC_NUMSEQUENCE.Value = clsPhamouvementStockaccessoire.AC_NUMSEQUENCE;
            SqlParameter vppParamAC_CODEARTICLE1 = new SqlParameter("@AC_CODEARTICLE1", SqlDbType.VarChar, 7);
            vppParamAC_CODEARTICLE1.Value = clsPhamouvementStockaccessoire.AC_CODEARTICLE1;
            SqlParameter vppParamAC_CODEARTICLE2 = new SqlParameter("@AC_CODEARTICLE2", SqlDbType.VarChar, 7);
            vppParamAC_CODEARTICLE2.Value = clsPhamouvementStockaccessoire.AC_CODEARTICLE2;
            SqlParameter vppParamMD_NUMSEQUENCE = new SqlParameter("@MD_NUMSEQUENCE", SqlDbType.VarChar, 50);
            vppParamMD_NUMSEQUENCE.Value = clsPhamouvementStockaccessoire.MD_NUMSEQUENCE;
            SqlParameter vppParamAC_UNITE = new SqlParameter("@AC_UNITE", SqlDbType.BigInt);
            vppParamAC_UNITE.Value = clsPhamouvementStockaccessoire.AC_UNITE;
            SqlParameter vppParamAC_QUANTITEENTREE = new SqlParameter("@AC_QUANTITEENTREE", SqlDbType.BigInt);
            vppParamAC_QUANTITEENTREE.Value = clsPhamouvementStockaccessoire.AC_QUANTITEENTREE;
            SqlParameter vppParamAC_QUANTITESORTIE = new SqlParameter("@AC_QUANTITESORTIE", SqlDbType.BigInt);
            vppParamAC_QUANTITESORTIE.Value = clsPhamouvementStockaccessoire.AC_QUANTITESORTIE;
            SqlParameter vppParamAC_PRIXUNITAIRE = new SqlParameter("@AC_PRIXUNITAIRE", SqlDbType.Money);
            vppParamAC_PRIXUNITAIRE.Value = clsPhamouvementStockaccessoire.AC_PRIXUNITAIRE;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@AC_PRIXUNITAIRE", SqlDbType.VarChar);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStockaccessoire.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKACCESSOIRE  @AG_CODEAGENCE,@AC_NUMSEQUENCE, @AC_CODEARTICLE1, @AC_CODEARTICLE2, @MD_NUMSEQUENCE, @AC_UNITE, @AC_QUANTITEENTREE, @AC_QUANTITESORTIE, @AC_PRIXUNITAIRE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamAC_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamAC_CODEARTICLE1);
            vppSqlCmd.Parameters.Add(vppParamAC_CODEARTICLE2);
            vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamAC_UNITE);
            vppSqlCmd.Parameters.Add(vppParamAC_QUANTITEENTREE);
            vppSqlCmd.Parameters.Add(vppParamAC_QUANTITESORTIE);
            vppSqlCmd.Parameters.Add(vppParamAC_PRIXUNITAIRE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }











		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockaccessoire>clsPhamouvementStockaccessoire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockaccessoire.AG_CODEAGENCE;
			SqlParameter vppParamAC_CODEARTICLE1 = new SqlParameter("@AC_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamAC_CODEARTICLE1.Value  = clsPhamouvementStockaccessoire.AC_CODEARTICLE1 ;

			SqlParameter vppParamAC_CODEARTICLE2 = new SqlParameter("@AC_CODEARTICLE2", SqlDbType.VarChar, 7);
			vppParamAC_CODEARTICLE2.Value  = clsPhamouvementStockaccessoire.AC_CODEARTICLE2 ;

			SqlParameter vppParamAC_UNITE = new SqlParameter("@AC_UNITE", SqlDbType.BigInt);
			vppParamAC_UNITE.Value  = clsPhamouvementStockaccessoire.AC_UNITE ;

			SqlParameter vppParamAC_QUANTITEENTREE = new SqlParameter("@AC_QUANTITEENTREE", SqlDbType.BigInt);
			vppParamAC_QUANTITEENTREE.Value  = clsPhamouvementStockaccessoire.AC_QUANTITEENTREE ;

			SqlParameter vppParamAC_QUANTITESORTIE = new SqlParameter("@AC_QUANTITESORTIE", SqlDbType.BigInt);
			vppParamAC_QUANTITESORTIE.Value  = clsPhamouvementStockaccessoire.AC_QUANTITESORTIE ;

			SqlParameter vppParamAC_PRIXUNITAIRE = new SqlParameter("@AC_PRIXUNITAIRE", SqlDbType.Money);
			vppParamAC_PRIXUNITAIRE.Value  = clsPhamouvementStockaccessoire.AC_PRIXUNITAIRE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PhamouvementStockACCESSOIRE SET " +
							"AC_CODEARTICLE1 = @AC_CODEARTICLE1, "+
							"AC_CODEARTICLE2 = @AC_CODEARTICLE2, "+
							"AC_UNITE = @AC_UNITE, "+
							"AC_QUANTITEENTREE = @AC_QUANTITEENTREE, "+
							"AC_QUANTITESORTIE = @AC_QUANTITESORTIE, "+
							"AC_PRIXUNITAIRE = @AC_PRIXUNITAIRE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAC_CODEARTICLE1);
			vppSqlCmd.Parameters.Add(vppParamAC_CODEARTICLE2);
			vppSqlCmd.Parameters.Add(vppParamAC_UNITE);
			vppSqlCmd.Parameters.Add(vppParamAC_QUANTITEENTREE);
			vppSqlCmd.Parameters.Add(vppParamAC_QUANTITESORTIE);
			vppSqlCmd.Parameters.Add(vppParamAC_PRIXUNITAIRE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PhamouvementStockACCESSOIRE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockaccessoire </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockaccessoire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AC_NUMSEQUENCE, MD_NUMSEQUENCE, AC_CODEARTICLE1, AC_CODEARTICLE2, AC_UNITE, AC_QUANTITEENTREE, AC_QUANTITESORTIE, AC_PRIXUNITAIRE FROM dbo.PhamouvementStockACCESSOIRE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementStockaccessoire> clsPhamouvementStockaccessoires = new List<clsPhamouvementStockaccessoire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire = new clsPhamouvementStockaccessoire();
					clsPhamouvementStockaccessoire.AC_NUMSEQUENCE = clsDonnee.vogDataReader["AC_NUMSEQUENCE"].ToString();
					clsPhamouvementStockaccessoire.MD_NUMSEQUENCE =clsDonnee.vogDataReader["MD_NUMSEQUENCE"].ToString();
					clsPhamouvementStockaccessoire.AC_CODEARTICLE1 = clsDonnee.vogDataReader["AC_CODEARTICLE1"].ToString();
					clsPhamouvementStockaccessoire.AC_CODEARTICLE2 = clsDonnee.vogDataReader["AC_CODEARTICLE2"].ToString();
					clsPhamouvementStockaccessoire.AC_UNITE = double.Parse(clsDonnee.vogDataReader["AC_UNITE"].ToString());
					clsPhamouvementStockaccessoire.AC_QUANTITEENTREE = double.Parse(clsDonnee.vogDataReader["AC_QUANTITEENTREE"].ToString());
					clsPhamouvementStockaccessoire.AC_QUANTITESORTIE = double.Parse(clsDonnee.vogDataReader["AC_QUANTITESORTIE"].ToString());
					clsPhamouvementStockaccessoire.AC_PRIXUNITAIRE = double.Parse(clsDonnee.vogDataReader["AC_PRIXUNITAIRE"].ToString());
					clsPhamouvementStockaccessoires.Add(clsPhamouvementStockaccessoire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementStockaccessoires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockaccessoire </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockaccessoire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementStockaccessoire> clsPhamouvementStockaccessoires = new List<clsPhamouvementStockaccessoire>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AC_NUMSEQUENCE, MD_NUMSEQUENCE, AC_CODEARTICLE1, AC_CODEARTICLE2, AC_UNITE, AC_QUANTITEENTREE, AC_QUANTITESORTIE, AC_PRIXUNITAIRE FROM dbo.PhamouvementStockACCESSOIRE " + this.vapCritere;
			this.vapCritere="";			
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire = new clsPhamouvementStockaccessoire();
					clsPhamouvementStockaccessoire.AC_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["AC_NUMSEQUENCE"].ToString();
					clsPhamouvementStockaccessoire.MD_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["MD_NUMSEQUENCE"].ToString();
					clsPhamouvementStockaccessoire.AC_CODEARTICLE1 = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEARTICLE1"].ToString();
					clsPhamouvementStockaccessoire.AC_CODEARTICLE2 = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEARTICLE2"].ToString();
					clsPhamouvementStockaccessoire.AC_UNITE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AC_UNITE"].ToString());
					clsPhamouvementStockaccessoire.AC_QUANTITEENTREE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AC_QUANTITEENTREE"].ToString());
					clsPhamouvementStockaccessoire.AC_QUANTITESORTIE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AC_QUANTITESORTIE"].ToString());
					clsPhamouvementStockaccessoire.AC_PRIXUNITAIRE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AC_PRIXUNITAIRE"].ToString());
					clsPhamouvementStockaccessoires.Add(clsPhamouvementStockaccessoire);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementStockaccessoires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PhamouvementStockACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AC_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AC_NUMSEQUENCE , MD_NUMSEQUENCE FROM dbo.PhamouvementStockACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public List<clsPhamouvementStockaccessoire> pvgChargerAccessoiresVente(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@AC_CODEARTICLE", "@CODETYPECLIENT", "@DATEENCOURS", "@NUMSEQUENCE", "@QUANTITE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };

            this.vapRequete = "SELECT * FROM dbo.FC_MOUVEMENTStockACCESSOIRESVENTE (@AG_CODEAGENCE,@AC_CODEARTICLE,@CODETYPECLIENT,@DATEENCOURS,@NUMSEQUENCE,@QUANTITE) ";
            this.vapCritere = "";

            return pvgChargerAccessoires(clsDonnee, vapRequete);
        }

        public List<clsPhamouvementStockaccessoire> pvgChargerAccessoiresAppro(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@AC_CODEARTICLE", "@CODETYPEFOURNISSEUR", "@DATEENCOURS", "@NUMSEQUENCE", "@QUANTITE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] , vppCritere[5] };

            this.vapRequete = "SELECT * FROM dbo.FC_MOUVEMENTStockACCESSOIRESAPPRO (@AG_CODEAGENCE,@AC_CODEARTICLE,@CODETYPEFOURNISSEUR,@DATEENCOURS,@NUMSEQUENCE,@QUANTITE) ";
            this.vapCritere = "";

            return pvgChargerAccessoires(clsDonnee, vapRequete);
        }

        public List<clsPhamouvementStockaccessoire> pvgChargerAccessoires(clsDonnee clsDonnee,string vppRequete)
        {
            List<clsPhamouvementStockaccessoire> clsPhamouvementStockaccessoires = new List<clsPhamouvementStockaccessoire>();
            DataSet Dataset = new DataSet();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsPhamouvementStockaccessoire clsPhamouvementStockaccessoire = new clsPhamouvementStockaccessoire();
                    clsPhamouvementStockaccessoire.MD_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["MD_NUMSEQUENCE"].ToString();
                    clsPhamouvementStockaccessoire.AC_CODEARTICLE1 = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEARTICLE1"].ToString();
                    clsPhamouvementStockaccessoire.AC_CODEARTICLE2 = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEARTICLE2"].ToString();
                    clsPhamouvementStockaccessoire.AC_UNITE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AC_UNITE"].ToString());
                    clsPhamouvementStockaccessoire.AC_QUANTITEENTREE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AC_QUANTITEENTREE"].ToString());
                    clsPhamouvementStockaccessoire.AC_QUANTITESORTIE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AC_QUANTITESORTIE"].ToString());
                    clsPhamouvementStockaccessoire.AC_PRIXUNITAIRE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AC_PRIXUNITAIRE"].ToString());
                    clsPhamouvementStockaccessoires.Add(clsPhamouvementStockaccessoire);
                }
                Dataset.Dispose();
            }


            return clsPhamouvementStockaccessoires;
        }


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AC_NUMSEQUENCE)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                vapValeurParametre = new object[]{vppCritere[0]};
                break;

				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE and MD_NUMSEQUENCE=@MD_NUMSEQUENCE ";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MD_NUMSEQUENCE" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MD_NUMSEQUENCE=@MD_NUMSEQUENCE AND AC_NUMSEQUENCE=@AC_NUMSEQUENCE";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MD_NUMSEQUENCE", "@AC_NUMSEQUENCE" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
