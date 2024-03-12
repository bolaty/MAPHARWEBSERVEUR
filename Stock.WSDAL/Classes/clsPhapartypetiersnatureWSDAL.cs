using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypetiersnatureWSDAL: ITableDAL<clsPhapartypetiersnature>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(NT_CODENATURETYPETIERS) AS NT_CODENATURETYPETIERS  FROM dbo.FT_PHAPARTYPETIERSNATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(NT_CODENATURETYPETIERS) AS NT_CODENATURETYPETIERS  FROM dbo.FT_PHAPARTYPETIERSNATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(NT_CODENATURETYPETIERS) AS NT_CODENATURETYPETIERS  FROM dbo.FT_PHAPARTYPETIERSNATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypetiersnature comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypetiersnature pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NT_LIBELLE  FROM dbo.FT_PHAPARTYPETIERSNATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypetiersnature clsPhapartypetiersnature = new clsPhapartypetiersnature();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypetiersnature.NT_LIBELLE = clsDonnee.vogDataReader["NT_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypetiersnature;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypetiersnature>clsPhapartypetiersnature</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypetiersnature clsPhapartypetiersnature)
		{
			//Préparation des paramètres
			SqlParameter vppParamNT_CODENATURETYPETIERS = new SqlParameter("@NT_CODENATURETYPETIERS", SqlDbType.VarChar, 2);
			vppParamNT_CODENATURETYPETIERS.Value  = clsPhapartypetiersnature.NT_CODENATURETYPETIERS ;
			SqlParameter vppParamNT_LIBELLE = new SqlParameter("@NT_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNT_LIBELLE.Value  = clsPhapartypetiersnature.NT_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPETIERSNATURE  @NT_CODENATURETYPETIERS, @NT_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamNT_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypetiersnature>clsPhapartypetiersnature</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypetiersnature clsPhapartypetiersnature,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamNT_CODENATURETYPETIERS = new SqlParameter("@NT_CODENATURETYPETIERS", SqlDbType.VarChar, 2);
			vppParamNT_CODENATURETYPETIERS.Value  = clsPhapartypetiersnature.NT_CODENATURETYPETIERS ;
			SqlParameter vppParamNT_LIBELLE = new SqlParameter("@NT_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNT_LIBELLE.Value  = clsPhapartypetiersnature.NT_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPETIERSNATURE  @NT_CODENATURETYPETIERS, @NT_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamNT_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPETIERSNATURE  @NT_CODENATURETYPETIERS, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypetiersnature </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypetiersnature> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NT_CODENATURETYPETIERS, NT_LIBELLE FROM dbo.FT_PHAPARTYPETIERSNATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypetiersnature> clsPhapartypetiersnatures = new List<clsPhapartypetiersnature>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypetiersnature clsPhapartypetiersnature = new clsPhapartypetiersnature();
					clsPhapartypetiersnature.NT_CODENATURETYPETIERS = clsDonnee.vogDataReader["NT_CODENATURETYPETIERS"].ToString();
					clsPhapartypetiersnature.NT_LIBELLE = clsDonnee.vogDataReader["NT_LIBELLE"].ToString();
					clsPhapartypetiersnatures.Add(clsPhapartypetiersnature);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypetiersnatures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypetiersnature </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypetiersnature> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypetiersnature> clsPhapartypetiersnatures = new List<clsPhapartypetiersnature>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NT_CODENATURETYPETIERS, NT_LIBELLE FROM dbo.FT_PHAPARTYPETIERSNATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypetiersnature clsPhapartypetiersnature = new clsPhapartypetiersnature();
					clsPhapartypetiersnature.NT_CODENATURETYPETIERS = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETYPETIERS"].ToString();
					clsPhapartypetiersnature.NT_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["NT_LIBELLE"].ToString();
					clsPhapartypetiersnatures.Add(clsPhapartypetiersnature);
				}
				Dataset.Dispose();
			}
		return clsPhapartypetiersnatures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARTYPETIERSNATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NT_CODENATURETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NT_CODENATURETYPETIERS , NT_LIBELLE FROM dbo.FT_PHAPARTYPETIERSNATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NT_CODENATURETYPETIERS)</summary>
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
				this.vapCritere ="WHERE NT_CODENATURETYPETIERS=@NT_CODENATURETYPETIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NT_CODENATURETYPETIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
