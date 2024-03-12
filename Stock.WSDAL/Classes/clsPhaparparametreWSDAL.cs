using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparparametreWSDAL: ITableDAL<clsPhaparparametre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{}; 

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PA_CODEPARAMETRE) AS PA_CODEPARAMETRE  FROM dbo.PHAPARPARAMETRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PA_CODEPARAMETRE) AS PA_CODEPARAMETRE  FROM dbo.PHAPARPARAMETRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PA_CODEPARAMETRE) AS PA_CODEPARAMETRE  FROM dbo.PHAPARPARAMETRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparparametre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparparametre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PA_LIBELLE  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparparametre clsPhaparparametre = new clsPhaparparametre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparparametre.PA_LIBELLE = clsDonnee.vogDataReader["PA_LIBELLE"].ToString();
                    //clsPhaparparametre.PA_MONTANTMINI = double.Parse(clsDonnee.vogDataReader["PA_MONTANTMINI"].ToString());
                    //clsPhaparparametre.PA_MONTANTMAXI = double.Parse(clsDonnee.vogDataReader["PA_MONTANTMAXI"].ToString());
                    //clsPhaparparametre.PA_TAUX = float.Parse(clsDonnee.vogDataReader["PA_TAUX"].ToString());
                    //clsPhaparparametre.PA_MONTANT = double.Parse(clsDonnee.vogDataReader["PA_MONTANT"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparparametre;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparparametre>clsPhaparparametre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparparametre clsPhaparparametre)
		{
			//Préparation des paramètres
			SqlParameter vppParamPA_CODEPARAMETRE = new SqlParameter("@PA_CODEPARAMETRE", SqlDbType.VarChar, 5);
			vppParamPA_CODEPARAMETRE.Value  = clsPhaparparametre.PA_CODEPARAMETRE ;

			SqlParameter vppParamPA_LIBELLE = new SqlParameter("@PA_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPA_LIBELLE.Value  = clsPhaparparametre.PA_LIBELLE ;

			

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARPARAMETRE (  PA_CODEPARAMETRE, PA_LIBELLE) " +
					 "VALUES ( @PA_CODEPARAMETRE, @PA_LIBELLE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPA_CODEPARAMETRE);
			vppSqlCmd.Parameters.Add(vppParamPA_LIBELLE);
			
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparparametre>clsPhaparparametre</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparparametre clsPhaparparametre,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPA_LIBELLE = new SqlParameter("@PA_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPA_LIBELLE.Value  = clsPhaparparametre.PA_LIBELLE ;

			

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARPARAMETRE SET " +
							"PA_LIBELLE = @PA_LIBELLE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPA_LIBELLE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARPARAMETRE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparparametre </returns>
		///<author>Home Technology</author>
		public List<clsPhaparparametre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PA_CODEPARAMETRE, PA_LIBELLE FROM dbo.PHAPARPARAMETRE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparparametre> clsPhaparparametres = new List<clsPhaparparametre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparparametre clsPhaparparametre = new clsPhaparparametre();
					clsPhaparparametre.PA_CODEPARAMETRE = clsDonnee.vogDataReader["PA_CODEPARAMETRE"].ToString();
					clsPhaparparametre.PA_LIBELLE = clsDonnee.vogDataReader["PA_LIBELLE"].ToString();
					clsPhaparparametres.Add(clsPhaparparametre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparparametre </returns>
		///<author>Home Technology</author>
		public List<clsPhaparparametre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparparametre> clsPhaparparametres = new List<clsPhaparparametre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PA_CODEPARAMETRE, PA_LIBELLE FROM dbo.PHAPARPARAMETRE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparparametre clsPhaparparametre = new clsPhaparparametre();
					clsPhaparparametre.PA_CODEPARAMETRE = Dataset.Tables["TABLE"].Rows[Idx]["PA_CODEPARAMETRE"].ToString();
					clsPhaparparametre.PA_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PA_LIBELLE"].ToString();
					clsPhaparparametres.Add(clsPhaparparametre);
				}
				Dataset.Dispose();
			}
		return clsPhaparparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARPARAMETRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PA_CODEPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PA_CODEPARAMETRE , PA_LIBELLE FROM dbo.PHAPARPARAMETRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PA_CODEPARAMETRE)</summary>
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
				this.vapCritere ="WHERE PA_CODEPARAMETRE=@PA_CODEPARAMETRE";
				vapNomParametre = new string[]{"@PA_CODEPARAMETRE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
