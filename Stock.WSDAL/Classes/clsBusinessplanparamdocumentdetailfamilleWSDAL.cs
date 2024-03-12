using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBusinessplanparamdocumentdetailfamilleWSDAL: ITableDAL<clsBusinessplanparamdocumentdetailfamille>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PA_CODEDOCUMENTDETAILFAMILLE) AS PA_CODEDOCUMENTDETAILFAMILLE  FROM dbo.BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PA_CODEDOCUMENTDETAILFAMILLE) AS PA_CODEDOCUMENTDETAILFAMILLE  FROM dbo.BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PA_CODEDOCUMENTDETAILFAMILLE) AS PA_CODEDOCUMENTDETAILFAMILLE  FROM dbo.BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBusinessplanparamdocumentdetailfamille comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBusinessplanparamdocumentdetailfamille pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PA_LIBELLE  FROM dbo.BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBusinessplanparamdocumentdetailfamille clsBusinessplanparamdocumentdetailfamille = new clsBusinessplanparamdocumentdetailfamille();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparamdocumentdetailfamille.PA_LIBELLE = clsDonnee.vogDataReader["PA_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBusinessplanparamdocumentdetailfamille;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparamdocumentdetailfamille>clsBusinessplanparamdocumentdetailfamille</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBusinessplanparamdocumentdetailfamille clsBusinessplanparamdocumentdetailfamille)
		{
			//Préparation des paramètres
			SqlParameter vppParamPA_CODEDOCUMENTDETAILFAMILLE = new SqlParameter("@PA_CODEDOCUMENTDETAILFAMILLE", SqlDbType.VarChar, 4);
			vppParamPA_CODEDOCUMENTDETAILFAMILLE.Value  = clsBusinessplanparamdocumentdetailfamille.PA_CODEDOCUMENTDETAILFAMILLE ;
			SqlParameter vppParamPA_LIBELLE = new SqlParameter("@PA_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPA_LIBELLE.Value  = clsBusinessplanparamdocumentdetailfamille.PA_LIBELLE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE (  PA_CODEDOCUMENTDETAILFAMILLE, PA_LIBELLE) " +
					 "VALUES ( @PA_CODEDOCUMENTDETAILFAMILLE, @PA_LIBELLE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPA_CODEDOCUMENTDETAILFAMILLE);
			vppSqlCmd.Parameters.Add(vppParamPA_LIBELLE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparamdocumentdetailfamille>clsBusinessplanparamdocumentdetailfamille</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBusinessplanparamdocumentdetailfamille clsBusinessplanparamdocumentdetailfamille,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPA_LIBELLE = new SqlParameter("@PA_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPA_LIBELLE.Value  = clsBusinessplanparamdocumentdetailfamille.PA_LIBELLE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE SET " +
							"PA_LIBELLE = @PA_LIBELLE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPA_LIBELLE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamdocumentdetailfamille </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamdocumentdetailfamille> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PA_CODEDOCUMENTDETAILFAMILLE, PA_LIBELLE FROM dbo.BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBusinessplanparamdocumentdetailfamille> clsBusinessplanparamdocumentdetailfamilles = new List<clsBusinessplanparamdocumentdetailfamille>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparamdocumentdetailfamille clsBusinessplanparamdocumentdetailfamille = new clsBusinessplanparamdocumentdetailfamille();
					clsBusinessplanparamdocumentdetailfamille.PA_CODEDOCUMENTDETAILFAMILLE = clsDonnee.vogDataReader["PA_CODEDOCUMENTDETAILFAMILLE"].ToString();
					clsBusinessplanparamdocumentdetailfamille.PA_LIBELLE = clsDonnee.vogDataReader["PA_LIBELLE"].ToString();
					clsBusinessplanparamdocumentdetailfamilles.Add(clsBusinessplanparamdocumentdetailfamille);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBusinessplanparamdocumentdetailfamilles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamdocumentdetailfamille </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamdocumentdetailfamille> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBusinessplanparamdocumentdetailfamille> clsBusinessplanparamdocumentdetailfamilles = new List<clsBusinessplanparamdocumentdetailfamille>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PA_CODEDOCUMENTDETAILFAMILLE, PA_LIBELLE FROM dbo.BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBusinessplanparamdocumentdetailfamille clsBusinessplanparamdocumentdetailfamille = new clsBusinessplanparamdocumentdetailfamille();
					clsBusinessplanparamdocumentdetailfamille.PA_CODEDOCUMENTDETAILFAMILLE = Dataset.Tables["TABLE"].Rows[Idx]["PA_CODEDOCUMENTDETAILFAMILLE"].ToString();
					clsBusinessplanparamdocumentdetailfamille.PA_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PA_LIBELLE"].ToString();
					clsBusinessplanparamdocumentdetailfamilles.Add(clsBusinessplanparamdocumentdetailfamille);
				}
				Dataset.Dispose();
			}
		return clsBusinessplanparamdocumentdetailfamilles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PA_CODEDOCUMENTDETAILFAMILLE , PA_LIBELLE FROM dbo.BUSINESSPLANPARAMDOCUMENTDETAILFAMILLE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PA_CODEDOCUMENTDETAILFAMILLE)</summary>
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
				this.vapCritere ="WHERE PA_CODEDOCUMENTDETAILFAMILLE=@PA_CODEDOCUMENTDETAILFAMILLE";
				vapNomParametre = new string[]{"@PA_CODEDOCUMENTDETAILFAMILLE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
