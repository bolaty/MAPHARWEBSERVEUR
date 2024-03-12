using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparprestationserviceWSDAL: ITableDAL<clsPhaparprestationservice>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PS_CODEPRESTATION) AS PS_CODEPRESTATION  FROM dbo.PHAPARPRESTATIONSERVICE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PS_CODEPRESTATION) AS PS_CODEPRESTATION  FROM dbo.PHAPARPRESTATIONSERVICE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PS_CODEPRESTATION) AS PS_CODEPRESTATION  FROM dbo.PHAPARPRESTATIONSERVICE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparprestationservice comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparprestationservice pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT TP_CODETYPEPRESTATION  , PS_NOMPRESATION  , PS_DESCRIPTION  , PS_STATUT  , PS_ASDI  , PS_TVA  , PS_DATECLOTURE  FROM dbo.PHAPARPRESTATIONSERVICE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparprestationservice clsPhaparprestationservice = new clsPhaparprestationservice();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprestationservice.TP_CODETYPEPRESTATION = clsDonnee.vogDataReader["TP_CODETYPEPRESTATION"].ToString();
					clsPhaparprestationservice.PS_NOMPRESATION = clsDonnee.vogDataReader["PS_NOMPRESATION"].ToString();
					clsPhaparprestationservice.PS_DESCRIPTION = clsDonnee.vogDataReader["PS_DESCRIPTION"].ToString();
					clsPhaparprestationservice.PS_STATUT = clsDonnee.vogDataReader["PS_STATUT"].ToString();
					clsPhaparprestationservice.PS_ASDI = clsDonnee.vogDataReader["PS_ASDI"].ToString();
					clsPhaparprestationservice.PS_TVA = clsDonnee.vogDataReader["PS_TVA"].ToString();
					clsPhaparprestationservice.PS_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["PS_DATECLOTURE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparprestationservice;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprestationservice>clsPhaparprestationservice</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparprestationservice clsPhaparprestationservice)
		{
			//Préparation des paramètres
			SqlParameter vppParamPS_CODEPRESTATION = new SqlParameter("@PS_CODEPRESTATION", SqlDbType.VarChar, 7);
			vppParamPS_CODEPRESTATION.Value  = clsPhaparprestationservice.PS_CODEPRESTATION ;

			SqlParameter vppParamTP_CODETYPEPRESTATION = new SqlParameter("@TP_CODETYPEPRESTATION", SqlDbType.VarChar, 3);
			vppParamTP_CODETYPEPRESTATION.Value  = clsPhaparprestationservice.TP_CODETYPEPRESTATION ;

			SqlParameter vppParamPS_NOMPRESATION = new SqlParameter("@PS_NOMPRESATION", SqlDbType.VarChar, 150);
			vppParamPS_NOMPRESATION.Value  = clsPhaparprestationservice.PS_NOMPRESATION ;

			SqlParameter vppParamPS_DESCRIPTION = new SqlParameter("@PS_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamPS_DESCRIPTION.Value  = clsPhaparprestationservice.PS_DESCRIPTION ;

			SqlParameter vppParamPS_STATUT = new SqlParameter("@PS_STATUT", SqlDbType.VarChar, 2);
			vppParamPS_STATUT.Value  = clsPhaparprestationservice.PS_STATUT ;

			SqlParameter vppParamPS_ASDI = new SqlParameter("@PS_ASDI", SqlDbType.VarChar, 1);
			vppParamPS_ASDI.Value  = clsPhaparprestationservice.PS_ASDI ;

			SqlParameter vppParamPS_TVA = new SqlParameter("@PS_TVA", SqlDbType.VarChar, 1);
			vppParamPS_TVA.Value  = clsPhaparprestationservice.PS_TVA ;

			SqlParameter vppParamPS_DATECLOTURE = new SqlParameter("@PS_DATECLOTURE", SqlDbType.DateTime);
			vppParamPS_DATECLOTURE.Value  = clsPhaparprestationservice.PS_DATECLOTURE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARPRESTATIONSERVICE (  PS_CODEPRESTATION, TP_CODETYPEPRESTATION, PS_NOMPRESATION, PS_DESCRIPTION, PS_STATUT, PS_ASDI, PS_TVA, PS_DATECLOTURE) " +
					 "VALUES ( @PS_CODEPRESTATION, @TP_CODETYPEPRESTATION, @PS_NOMPRESATION, @PS_DESCRIPTION, @PS_STATUT, @PS_ASDI, @PS_TVA, @PS_DATECLOTURE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPS_CODEPRESTATION);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPRESTATION);
			vppSqlCmd.Parameters.Add(vppParamPS_NOMPRESATION);
			vppSqlCmd.Parameters.Add(vppParamPS_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamPS_STATUT);
			vppSqlCmd.Parameters.Add(vppParamPS_ASDI);
			vppSqlCmd.Parameters.Add(vppParamPS_TVA);
			vppSqlCmd.Parameters.Add(vppParamPS_DATECLOTURE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprestationservice>clsPhaparprestationservice</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparprestationservice clsPhaparprestationservice,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_CODETYPEPRESTATION = new SqlParameter("@TP_CODETYPEPRESTATION", SqlDbType.VarChar, 3);
			vppParamTP_CODETYPEPRESTATION.Value  = clsPhaparprestationservice.TP_CODETYPEPRESTATION ;

			SqlParameter vppParamPS_NOMPRESATION = new SqlParameter("@PS_NOMPRESATION", SqlDbType.VarChar, 150);
			vppParamPS_NOMPRESATION.Value  = clsPhaparprestationservice.PS_NOMPRESATION ;

			SqlParameter vppParamPS_DESCRIPTION = new SqlParameter("@PS_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamPS_DESCRIPTION.Value  = clsPhaparprestationservice.PS_DESCRIPTION ;

			SqlParameter vppParamPS_STATUT = new SqlParameter("@PS_STATUT", SqlDbType.VarChar, 2);
			vppParamPS_STATUT.Value  = clsPhaparprestationservice.PS_STATUT ;

			SqlParameter vppParamPS_ASDI = new SqlParameter("@PS_ASDI", SqlDbType.VarChar, 1);
			vppParamPS_ASDI.Value  = clsPhaparprestationservice.PS_ASDI ;

			SqlParameter vppParamPS_TVA = new SqlParameter("@PS_TVA", SqlDbType.VarChar, 1);
			vppParamPS_TVA.Value  = clsPhaparprestationservice.PS_TVA ;

			SqlParameter vppParamPS_DATECLOTURE = new SqlParameter("@PS_DATECLOTURE", SqlDbType.DateTime);
			vppParamPS_DATECLOTURE.Value  = clsPhaparprestationservice.PS_DATECLOTURE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PHAPARPRESTATIONSERVICE SET " +
							"TP_CODETYPEPRESTATION = @TP_CODETYPEPRESTATION, "+
							"PS_NOMPRESATION = @PS_NOMPRESATION, "+
							"PS_DESCRIPTION = @PS_DESCRIPTION, "+
							"PS_STATUT = @PS_STATUT, "+
							"PS_ASDI = @PS_ASDI, "+
							"PS_TVA = @PS_TVA, "+
							"PS_DATECLOTURE = @PS_DATECLOTURE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPRESTATION);
			vppSqlCmd.Parameters.Add(vppParamPS_NOMPRESATION);
			vppSqlCmd.Parameters.Add(vppParamPS_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamPS_STATUT);
			vppSqlCmd.Parameters.Add(vppParamPS_ASDI);
			vppSqlCmd.Parameters.Add(vppParamPS_TVA);
			vppSqlCmd.Parameters.Add(vppParamPS_DATECLOTURE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARPRESTATIONSERVICE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprestationservice </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprestationservice> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PS_CODEPRESTATION, TP_CODETYPEPRESTATION, PS_NOMPRESATION, PS_DESCRIPTION, PS_STATUT, PS_ASDI, PS_TVA, PS_DATECLOTURE FROM dbo.PHAPARPRESTATIONSERVICE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparprestationservice> clsPhaparprestationservices = new List<clsPhaparprestationservice>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprestationservice clsPhaparprestationservice = new clsPhaparprestationservice();
					clsPhaparprestationservice.PS_CODEPRESTATION = clsDonnee.vogDataReader["PS_CODEPRESTATION"].ToString();
					clsPhaparprestationservice.TP_CODETYPEPRESTATION = clsDonnee.vogDataReader["TP_CODETYPEPRESTATION"].ToString();
					clsPhaparprestationservice.PS_NOMPRESATION = clsDonnee.vogDataReader["PS_NOMPRESATION"].ToString();
					clsPhaparprestationservice.PS_DESCRIPTION = clsDonnee.vogDataReader["PS_DESCRIPTION"].ToString();
					clsPhaparprestationservice.PS_STATUT = clsDonnee.vogDataReader["PS_STATUT"].ToString();
					clsPhaparprestationservice.PS_ASDI = clsDonnee.vogDataReader["PS_ASDI"].ToString();
					clsPhaparprestationservice.PS_TVA = clsDonnee.vogDataReader["PS_TVA"].ToString();
					clsPhaparprestationservice.PS_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["PS_DATECLOTURE"].ToString());
					clsPhaparprestationservices.Add(clsPhaparprestationservice);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparprestationservices;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprestationservice </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprestationservice> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparprestationservice> clsPhaparprestationservices = new List<clsPhaparprestationservice>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PS_CODEPRESTATION, TP_CODETYPEPRESTATION, PS_NOMPRESATION, PS_DESCRIPTION, PS_STATUT, PS_ASDI, PS_TVA, PS_DATECLOTURE FROM dbo.PHAPARPRESTATIONSERVICE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparprestationservice clsPhaparprestationservice = new clsPhaparprestationservice();
					clsPhaparprestationservice.PS_CODEPRESTATION = Dataset.Tables["TABLE"].Rows[Idx]["PS_CODEPRESTATION"].ToString();
					clsPhaparprestationservice.TP_CODETYPEPRESTATION = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPEPRESTATION"].ToString();
					clsPhaparprestationservice.PS_NOMPRESATION = Dataset.Tables["TABLE"].Rows[Idx]["PS_NOMPRESATION"].ToString();
					clsPhaparprestationservice.PS_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["PS_DESCRIPTION"].ToString();
					clsPhaparprestationservice.PS_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["PS_STATUT"].ToString();
					clsPhaparprestationservice.PS_ASDI = Dataset.Tables["TABLE"].Rows[Idx]["PS_ASDI"].ToString();
					clsPhaparprestationservice.PS_TVA = Dataset.Tables["TABLE"].Rows[Idx]["PS_TVA"].ToString();
					clsPhaparprestationservice.PS_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PS_DATECLOTURE"].ToString());
					clsPhaparprestationservices.Add(clsPhaparprestationservice);
				}
				Dataset.Dispose();
			}
		return clsPhaparprestationservices;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARPRESTATIONSERVICE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PS_CODEPRESTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PS_CODEPRESTATION , TP_CODETYPEPRESTATION FROM dbo.PHAPARPRESTATIONSERVICE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PS_CODEPRESTATION)</summary>
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
				this.vapCritere ="WHERE PS_CODEPRESTATION=@PS_CODEPRESTATION";
				vapNomParametre = new string[]{"@PS_CODEPRESTATION"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
