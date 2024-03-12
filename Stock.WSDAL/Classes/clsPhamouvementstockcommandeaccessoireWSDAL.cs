using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementStockcommandeaccessoireWSDAL: ITableDAL<clsPhamouvementStockcommandeaccessoire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(CC_NUMSEQUENCE) AS CC_NUMSEQUENCE  FROM dbo.PhamouvementStockCOMMANDEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(CC_NUMSEQUENCE) AS CC_NUMSEQUENCE  FROM dbo.PhamouvementStockCOMMANDEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(CC_NUMSEQUENCE) AS CC_NUMSEQUENCE  FROM dbo.PhamouvementStockCOMMANDEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockcommandeaccessoire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockcommandeaccessoire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MM_NUMSEQUENCE  , CC_CODEARTICLE1  , CC_CODEARTICLE2  , CC_UNITE  , CC_QUANTITEENTREE  , CC_QUANTITESORTIE  , CC_PRIXUNITAIRE  FROM dbo.PhamouvementStockCOMMANDEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementStockcommandeaccessoire clsPhamouvementStockcommandeaccessoire = new clsPhamouvementStockcommandeaccessoire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockcommandeaccessoire.MM_NUMSEQUENCE = clsDonnee.vogDataReader["MM_NUMSEQUENCE"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE1 = clsDonnee.vogDataReader["CC_CODEARTICLE1"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE2 = clsDonnee.vogDataReader["CC_CODEARTICLE2"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_UNITE = double.Parse(clsDonnee.vogDataReader["CC_UNITE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_QUANTITEENTREE = double.Parse(clsDonnee.vogDataReader["CC_QUANTITEENTREE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_QUANTITESORTIE = double.Parse(clsDonnee.vogDataReader["CC_QUANTITESORTIE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_PRIXUNITAIRE = double.Parse(clsDonnee.vogDataReader["CC_PRIXUNITAIRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementStockcommandeaccessoire;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockcommandeaccessoire>clsPhamouvementStockcommandeaccessoire</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementStockcommandeaccessoire clsPhamouvementStockcommandeaccessoire)
		{
			//Préparation des paramètres
			SqlParameter vppParamCC_NUMSEQUENCE = new SqlParameter("@CC_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamCC_NUMSEQUENCE.Value  = clsPhamouvementStockcommandeaccessoire.CC_NUMSEQUENCE ;

			SqlParameter vppParamMM_NUMSEQUENCE = new SqlParameter("@MM_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamMM_NUMSEQUENCE.Value  = clsPhamouvementStockcommandeaccessoire.MM_NUMSEQUENCE ;

			SqlParameter vppParamCC_CODEARTICLE1 = new SqlParameter("@CC_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamCC_CODEARTICLE1.Value  = clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE1 ;

			SqlParameter vppParamCC_CODEARTICLE2 = new SqlParameter("@CC_CODEARTICLE2", SqlDbType.VarChar, 7);
			vppParamCC_CODEARTICLE2.Value  = clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE2 ;

			SqlParameter vppParamCC_UNITE = new SqlParameter("@CC_UNITE", SqlDbType.BigInt);
			vppParamCC_UNITE.Value  = clsPhamouvementStockcommandeaccessoire.CC_UNITE ;

			SqlParameter vppParamCC_QUANTITEENTREE = new SqlParameter("@CC_QUANTITEENTREE", SqlDbType.BigInt);
			vppParamCC_QUANTITEENTREE.Value  = clsPhamouvementStockcommandeaccessoire.CC_QUANTITEENTREE ;

			SqlParameter vppParamCC_QUANTITESORTIE = new SqlParameter("@CC_QUANTITESORTIE", SqlDbType.BigInt);
			vppParamCC_QUANTITESORTIE.Value  = clsPhamouvementStockcommandeaccessoire.CC_QUANTITESORTIE ;

			SqlParameter vppParamCC_PRIXUNITAIRE = new SqlParameter("@CC_PRIXUNITAIRE", SqlDbType.Money);
			vppParamCC_PRIXUNITAIRE.Value  = clsPhamouvementStockcommandeaccessoire.CC_PRIXUNITAIRE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PhamouvementStockCOMMANDEACCESSOIRE (  CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2, CC_UNITE, CC_QUANTITEENTREE, CC_QUANTITESORTIE, CC_PRIXUNITAIRE) " +
					 "VALUES ( @CC_NUMSEQUENCE, @MM_NUMSEQUENCE, @CC_CODEARTICLE1, @CC_CODEARTICLE2, @CC_UNITE, @CC_QUANTITEENTREE, @CC_QUANTITESORTIE, @CC_PRIXUNITAIRE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCC_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamMM_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCC_CODEARTICLE1);
			vppSqlCmd.Parameters.Add(vppParamCC_CODEARTICLE2);
			vppSqlCmd.Parameters.Add(vppParamCC_UNITE);
			vppSqlCmd.Parameters.Add(vppParamCC_QUANTITEENTREE);
			vppSqlCmd.Parameters.Add(vppParamCC_QUANTITESORTIE);
			vppSqlCmd.Parameters.Add(vppParamCC_PRIXUNITAIRE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockcommandeaccessoire>clsPhamouvementStockcommandeaccessoire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementStockcommandeaccessoire clsPhamouvementStockcommandeaccessoire,params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamCC_CODEARTICLE1 = new SqlParameter("@CC_CODEARTICLE1", SqlDbType.VarChar, 7);
			vppParamCC_CODEARTICLE1.Value  = clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE1 ;

			SqlParameter vppParamCC_CODEARTICLE2 = new SqlParameter("@CC_CODEARTICLE2", SqlDbType.VarChar, 7);
			vppParamCC_CODEARTICLE2.Value  = clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE2 ;

			SqlParameter vppParamCC_UNITE = new SqlParameter("@CC_UNITE", SqlDbType.BigInt);
			vppParamCC_UNITE.Value  = clsPhamouvementStockcommandeaccessoire.CC_UNITE ;

			SqlParameter vppParamCC_QUANTITEENTREE = new SqlParameter("@CC_QUANTITEENTREE", SqlDbType.BigInt);
			vppParamCC_QUANTITEENTREE.Value  = clsPhamouvementStockcommandeaccessoire.CC_QUANTITEENTREE ;

			SqlParameter vppParamCC_QUANTITESORTIE = new SqlParameter("@CC_QUANTITESORTIE", SqlDbType.BigInt);
			vppParamCC_QUANTITESORTIE.Value  = clsPhamouvementStockcommandeaccessoire.CC_QUANTITESORTIE ;

			SqlParameter vppParamCC_PRIXUNITAIRE = new SqlParameter("@CC_PRIXUNITAIRE", SqlDbType.Money);
			vppParamCC_PRIXUNITAIRE.Value  = clsPhamouvementStockcommandeaccessoire.CC_PRIXUNITAIRE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PhamouvementStockCOMMANDEACCESSOIRE SET " +
							"CC_CODEARTICLE1 = @CC_CODEARTICLE1, "+
							"CC_CODEARTICLE2 = @CC_CODEARTICLE2, "+
							"CC_UNITE = @CC_UNITE, "+
							"CC_QUANTITEENTREE = @CC_QUANTITEENTREE, "+
							"CC_QUANTITESORTIE = @CC_QUANTITESORTIE, "+
							"CC_PRIXUNITAIRE = @CC_PRIXUNITAIRE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCC_CODEARTICLE1);
			vppSqlCmd.Parameters.Add(vppParamCC_CODEARTICLE2);
			vppSqlCmd.Parameters.Add(vppParamCC_UNITE);
			vppSqlCmd.Parameters.Add(vppParamCC_QUANTITEENTREE);
			vppSqlCmd.Parameters.Add(vppParamCC_QUANTITESORTIE);
			vppSqlCmd.Parameters.Add(vppParamCC_PRIXUNITAIRE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PhamouvementStockCOMMANDEACCESSOIRE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockcommandeaccessoire </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockcommandeaccessoire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2, CC_UNITE, CC_QUANTITEENTREE, CC_QUANTITESORTIE, CC_PRIXUNITAIRE FROM dbo.PhamouvementStockCOMMANDEACCESSOIRE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementStockcommandeaccessoire> clsPhamouvementStockcommandeaccessoires = new List<clsPhamouvementStockcommandeaccessoire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockcommandeaccessoire clsPhamouvementStockcommandeaccessoire = new clsPhamouvementStockcommandeaccessoire();
					clsPhamouvementStockcommandeaccessoire.CC_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["CC_NUMSEQUENCE"].ToString());
					clsPhamouvementStockcommandeaccessoire.MM_NUMSEQUENCE = clsDonnee.vogDataReader["MM_NUMSEQUENCE"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE1 = clsDonnee.vogDataReader["CC_CODEARTICLE1"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE2 = clsDonnee.vogDataReader["CC_CODEARTICLE2"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_UNITE = double.Parse(clsDonnee.vogDataReader["CC_UNITE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_QUANTITEENTREE = double.Parse(clsDonnee.vogDataReader["CC_QUANTITEENTREE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_QUANTITESORTIE = double.Parse(clsDonnee.vogDataReader["CC_QUANTITESORTIE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_PRIXUNITAIRE = double.Parse(clsDonnee.vogDataReader["CC_PRIXUNITAIRE"].ToString());
					clsPhamouvementStockcommandeaccessoires.Add(clsPhamouvementStockcommandeaccessoire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementStockcommandeaccessoires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockcommandeaccessoire </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockcommandeaccessoire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementStockcommandeaccessoire> clsPhamouvementStockcommandeaccessoires = new List<clsPhamouvementStockcommandeaccessoire>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2, CC_UNITE, CC_QUANTITEENTREE, CC_QUANTITESORTIE, CC_PRIXUNITAIRE FROM dbo.PhamouvementStockCOMMANDEACCESSOIRE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementStockcommandeaccessoire clsPhamouvementStockcommandeaccessoire = new clsPhamouvementStockcommandeaccessoire();
					clsPhamouvementStockcommandeaccessoire.CC_NUMSEQUENCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_NUMSEQUENCE"].ToString());
                    clsPhamouvementStockcommandeaccessoire.MM_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["MM_NUMSEQUENCE"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE1 = Dataset.Tables["TABLE"].Rows[Idx]["CC_CODEARTICLE1"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE2 = Dataset.Tables["TABLE"].Rows[Idx]["CC_CODEARTICLE2"].ToString();
					clsPhamouvementStockcommandeaccessoire.CC_UNITE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_UNITE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_QUANTITEENTREE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_QUANTITEENTREE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_QUANTITESORTIE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_QUANTITESORTIE"].ToString());
					clsPhamouvementStockcommandeaccessoire.CC_PRIXUNITAIRE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_PRIXUNITAIRE"].ToString());
					clsPhamouvementStockcommandeaccessoires.Add(clsPhamouvementStockcommandeaccessoire);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementStockcommandeaccessoires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PhamouvementStockCOMMANDEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2 ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT CC_NUMSEQUENCE , CC_UNITE FROM dbo.PhamouvementStockCOMMANDEACCESSOIRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        public List<clsPhamouvementStockcommandeaccessoire> pvgSelectAccessoire(clsDonnee clsDonnee ,params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AC_CODEARTICLE", "@CODETYPECLIENT", "@DATEENCOURS", "@NUMSEQUENCE", "@QUANTITE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4]};

            this.vapRequete = "SELECT * FROM dbo.FC_MOUVEMENTStockCOMMANDEACCESSOIRESCLIENT (@AC_CODEARTICLE,@CODETYPECLIENT,@DATEENCOURS,@NUMSEQUENCE,@QUANTITE) ";
            this.vapCritere = ""; 
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsPhamouvementStockcommandeaccessoire> clsPhamouvementStockcommandeaccessoires = new List<clsPhamouvementStockcommandeaccessoire>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPhamouvementStockcommandeaccessoire clsPhamouvementStockcommandeaccessoire = new clsPhamouvementStockcommandeaccessoire();
                    clsPhamouvementStockcommandeaccessoire.CC_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["CC_NUMSEQUENCE"].ToString());
                    clsPhamouvementStockcommandeaccessoire.MM_NUMSEQUENCE = clsDonnee.vogDataReader["MM_NUMSEQUENCE"].ToString();
                    clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE1 = clsDonnee.vogDataReader["CC_CODEARTICLE1"].ToString();
                    clsPhamouvementStockcommandeaccessoire.CC_CODEARTICLE2 = clsDonnee.vogDataReader["CC_CODEARTICLE2"].ToString();
                    clsPhamouvementStockcommandeaccessoire.CC_UNITE = double.Parse(clsDonnee.vogDataReader["CC_UNITE"].ToString());
                    clsPhamouvementStockcommandeaccessoire.CC_QUANTITEENTREE = double.Parse(clsDonnee.vogDataReader["CC_QUANTITEENTREE"].ToString());
                    clsPhamouvementStockcommandeaccessoire.CC_QUANTITESORTIE = double.Parse(clsDonnee.vogDataReader["CC_QUANTITESORTIE"].ToString());
                    clsPhamouvementStockcommandeaccessoire.CC_PRIXUNITAIRE = double.Parse(clsDonnee.vogDataReader["CC_PRIXUNITAIRE"].ToString());
                    clsPhamouvementStockcommandeaccessoires.Add(clsPhamouvementStockcommandeaccessoire);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPhamouvementStockcommandeaccessoires;
        }


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CC_NUMSEQUENCE, MM_NUMSEQUENCE, CC_CODEARTICLE1, CC_CODEARTICLE2)</summary>
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
				this.vapCritere ="WHERE CC_NUMSEQUENCE=@CC_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CC_NUMSEQUENCE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE CC_NUMSEQUENCE=@CC_NUMSEQUENCE AND MM_NUMSEQUENCE=@MM_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CC_NUMSEQUENCE","@MM_NUMSEQUENCE"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE CC_NUMSEQUENCE=@CC_NUMSEQUENCE AND MM_NUMSEQUENCE=@MM_NUMSEQUENCE AND CC_CODEARTICLE1=@CC_CODEARTICLE1";
				vapNomParametre = new string[]{"@CC_NUMSEQUENCE","@MM_NUMSEQUENCE","@CC_CODEARTICLE1"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE CC_NUMSEQUENCE=@CC_NUMSEQUENCE AND MM_NUMSEQUENCE=@MM_NUMSEQUENCE AND CC_CODEARTICLE1=@CC_CODEARTICLE1 AND CC_CODEARTICLE2=@CC_CODEARTICLE2";
				vapNomParametre = new string[]{"@CC_NUMSEQUENCE","@MM_NUMSEQUENCE","@CC_CODEARTICLE1","@CC_CODEARTICLE2"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
