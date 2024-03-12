using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsOperateurdroitagenceWSDAL: ITableDAL<clsOperateurdroitagence>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEURDROITAGENCEWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEURDROITAGENCEWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEURDROITAGENCEWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsOperateurdroitagence comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsOperateurdroitagence pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  FROM dbo.OPERATEURDROITAGENCEWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsOperateurdroitagence clsOperateurdroitagence = new clsOperateurdroitagence();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroitagence.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsOperateurdroitagence;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOperateurdroitagence>clsOperateurdroitagence</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsOperateurdroitagence clsOperateurdroitagence)
		{
			//Préparation des paramètres
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsOperateurdroitagence.OP_CODEOPERATEUR ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsOperateurdroitagence.AG_CODEAGENCE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO OPERATEURDROITAGENCEWEB (  OP_CODEOPERATEUR, AG_CODEAGENCE) " +
					 "VALUES ( @OP_CODEOPERATEUR1, @AG_CODEAGENCE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOperateurdroitagence>clsOperateurdroitagence</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsOperateurdroitagence clsOperateurdroitagence,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsOperateurdroitagence.AG_CODEAGENCE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE OPERATEURDROITAGENCEWEB SET " +
							"AG_CODEAGENCE = @AG_CODEAGENCE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  OPERATEURDROITAGENCEWEB " + this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitagence </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitagence> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  OP_CODEOPERATEUR, AG_CODEAGENCE FROM dbo.OPERATEURDROITAGENCEWEB " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsOperateurdroitagence> clsOperateurdroitagences = new List<clsOperateurdroitagence>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroitagence clsOperateurdroitagence = new clsOperateurdroitagence();
					clsOperateurdroitagence.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroitagence.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsOperateurdroitagences.Add(clsOperateurdroitagence);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsOperateurdroitagences;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitagence </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitagence> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsOperateurdroitagence> clsOperateurdroitagences = new List<clsOperateurdroitagence>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  OP_CODEOPERATEUR, AG_CODEAGENCE FROM dbo.OPERATEURDROITAGENCEWEB " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsOperateurdroitagence clsOperateurdroitagence = new clsOperateurdroitagence();
					clsOperateurdroitagence.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroitagence.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsOperateurdroitagences.Add(clsOperateurdroitagence);
				}
				Dataset.Dispose();
			}
		return clsOperateurdroitagences;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { vppCritere[0] };
            this.vapRequete = "SELECT *  FROM dbo.[FC_OPERATEURDROITAGENCEWEB](@OP_CODEOPERATEUR) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT OP_CODEOPERATEUR , AG_CODEAGENCE FROM dbo.OPERATEURDROITAGENCEWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OP_CODEOPERATEUR)</summary>
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
                this.vapCritere = "WHERE OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                vapNomParametre = new string[] { "@OP_CODEOPERATEUR" };
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE = @AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                vapNomParametre = new string[] {"@AG_CODEAGENCE", "@OP_CODEOPERATEUR"  };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
