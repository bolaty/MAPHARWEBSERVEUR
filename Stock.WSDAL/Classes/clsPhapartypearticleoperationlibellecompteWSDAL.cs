using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypearticleoperationlibellecompteWSDAL: ITableDAL<clsPhapartypearticleoperationlibellecompte>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CP_CODEOPERATIONLIBELLECPTE) AS CP_CODEOPERATIONLIBELLECPTE  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CP_CODEOPERATIONLIBELLECPTE) AS CP_CODEOPERATIONLIBELLECPTE  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CP_CODEOPERATIONLIBELLECPTE) AS CP_CODEOPERATIONLIBELLECPTE  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypearticleoperationlibellecompte comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypearticleoperationlibellecompte pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CP_LIBELLE  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypearticleoperationlibellecompte clsPhapartypearticleoperationlibellecompte = new clsPhapartypearticleoperationlibellecompte();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticleoperationlibellecompte.CP_LIBELLE = clsDonnee.vogDataReader["CP_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypearticleoperationlibellecompte;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticleoperationlibellecompte>clsPhapartypearticleoperationlibellecompte</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypearticleoperationlibellecompte clsPhapartypearticleoperationlibellecompte)
		{
			//Préparation des paramètres
			SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 3);
			vppParamCP_CODEOPERATIONLIBELLECPTE.Value  = clsPhapartypearticleoperationlibellecompte.CP_CODEOPERATIONLIBELLECPTE ;
			SqlParameter vppParamCP_LIBELLE = new SqlParameter("@CP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamCP_LIBELLE.Value  = clsPhapartypearticleoperationlibellecompte.CP_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE  @CP_CODEOPERATIONLIBELLECPTE, @CP_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
			vppSqlCmd.Parameters.Add(vppParamCP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticleoperationlibellecompte>clsPhapartypearticleoperationlibellecompte</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypearticleoperationlibellecompte clsPhapartypearticleoperationlibellecompte,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 3);
			vppParamCP_CODEOPERATIONLIBELLECPTE.Value  = clsPhapartypearticleoperationlibellecompte.CP_CODEOPERATIONLIBELLECPTE ;
			SqlParameter vppParamCP_LIBELLE = new SqlParameter("@CP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamCP_LIBELLE.Value  = clsPhapartypearticleoperationlibellecompte.CP_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE  @CP_CODEOPERATIONLIBELLECPTE, @CP_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
			vppSqlCmd.Parameters.Add(vppParamCP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE  @CP_CODEOPERATIONLIBELLECPTE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticleoperationlibellecompte </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticleoperationlibellecompte> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CP_CODEOPERATIONLIBELLECPTE, CP_LIBELLE FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypearticleoperationlibellecompte> clsPhapartypearticleoperationlibellecomptes = new List<clsPhapartypearticleoperationlibellecompte>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticleoperationlibellecompte clsPhapartypearticleoperationlibellecompte = new clsPhapartypearticleoperationlibellecompte();
					clsPhapartypearticleoperationlibellecompte.CP_CODEOPERATIONLIBELLECPTE = clsDonnee.vogDataReader["CP_CODEOPERATIONLIBELLECPTE"].ToString();
					clsPhapartypearticleoperationlibellecompte.CP_LIBELLE = clsDonnee.vogDataReader["CP_LIBELLE"].ToString();
					clsPhapartypearticleoperationlibellecomptes.Add(clsPhapartypearticleoperationlibellecompte);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypearticleoperationlibellecomptes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticleoperationlibellecompte </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticleoperationlibellecompte> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypearticleoperationlibellecompte> clsPhapartypearticleoperationlibellecomptes = new List<clsPhapartypearticleoperationlibellecompte>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CP_CODEOPERATIONLIBELLECPTE, CP_LIBELLE FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypearticleoperationlibellecompte clsPhapartypearticleoperationlibellecompte = new clsPhapartypearticleoperationlibellecompte();
					clsPhapartypearticleoperationlibellecompte.CP_CODEOPERATIONLIBELLECPTE = Dataset.Tables["TABLE"].Rows[Idx]["CP_CODEOPERATIONLIBELLECPTE"].ToString();
					clsPhapartypearticleoperationlibellecompte.CP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["CP_LIBELLE"].ToString();
					clsPhapartypearticleoperationlibellecomptes.Add(clsPhapartypearticleoperationlibellecompte);
				}
				Dataset.Dispose();
			}
		return clsPhapartypearticleoperationlibellecomptes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CP_CODEOPERATIONLIBELLECPTE , CP_LIBELLE FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONLIBELLECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CP_CODEOPERATIONLIBELLECPTE)</summary>
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
				this.vapCritere ="WHERE CP_CODEOPERATIONLIBELLECPTE=@CP_CODEOPERATIONLIBELLECPTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CP_CODEOPERATIONLIBELLECPTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
