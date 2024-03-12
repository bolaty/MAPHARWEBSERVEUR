using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPlancomptablenaturecompteWSDAL: ITableDAL<clsPlancomptablenaturecompte>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(NC_CODENATURECOMPTE) AS NC_CODENATURECOMPTE  FROM dbo.FT_PLANCOMPTABLENATURECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(NC_CODENATURECOMPTE) AS NC_CODENATURECOMPTE  FROM dbo.FT_PLANCOMPTABLENATURECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(NC_CODENATURECOMPTE) AS NC_CODENATURECOMPTE  FROM dbo.FT_PLANCOMPTABLENATURECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPlancomptablenaturecompte comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPlancomptablenaturecompte pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NC_LIBELLENATURECOMPTE  , NC_NUMEROORDRE  FROM dbo.FT_PLANCOMPTABLENATURECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPlancomptablenaturecompte clsPlancomptablenaturecompte = new clsPlancomptablenaturecompte();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPlancomptablenaturecompte.NC_LIBELLENATURECOMPTE = clsDonnee.vogDataReader["NC_LIBELLENATURECOMPTE"].ToString();
					clsPlancomptablenaturecompte.NC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NC_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPlancomptablenaturecompte;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlancomptablenaturecompte>clsPlancomptablenaturecompte</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPlancomptablenaturecompte clsPlancomptablenaturecompte)
		{
			//Préparation des paramètres
			SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 2);
			vppParamNC_CODENATURECOMPTE.Value  = clsPlancomptablenaturecompte.NC_CODENATURECOMPTE ;
			SqlParameter vppParamNC_LIBELLENATURECOMPTE = new SqlParameter("@NC_LIBELLENATURECOMPTE", SqlDbType.VarChar, 150);
			vppParamNC_LIBELLENATURECOMPTE.Value  = clsPlancomptablenaturecompte.NC_LIBELLENATURECOMPTE ;
			SqlParameter vppParamNC_NUMEROORDRE = new SqlParameter("@NC_NUMEROORDRE", SqlDbType.Int);
			vppParamNC_NUMEROORDRE.Value  = clsPlancomptablenaturecompte.NC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLENATURECOMPTE  @NC_CODENATURECOMPTE, @NC_LIBELLENATURECOMPTE, @NC_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamNC_LIBELLENATURECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamNC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlancomptablenaturecompte>clsPlancomptablenaturecompte</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPlancomptablenaturecompte clsPlancomptablenaturecompte,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 2);
			vppParamNC_CODENATURECOMPTE.Value  = clsPlancomptablenaturecompte.NC_CODENATURECOMPTE ;
			SqlParameter vppParamNC_LIBELLENATURECOMPTE = new SqlParameter("@NC_LIBELLENATURECOMPTE", SqlDbType.VarChar, 150);
			vppParamNC_LIBELLENATURECOMPTE.Value  = clsPlancomptablenaturecompte.NC_LIBELLENATURECOMPTE ;
			SqlParameter vppParamNC_NUMEROORDRE = new SqlParameter("@NC_NUMEROORDRE", SqlDbType.Int);
			vppParamNC_NUMEROORDRE.Value  = clsPlancomptablenaturecompte.NC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLENATURECOMPTE  @NC_CODENATURECOMPTE, @NC_LIBELLENATURECOMPTE, @NC_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamNC_LIBELLENATURECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamNC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLENATURECOMPTE  @NC_CODENATURECOMPTE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlancomptablenaturecompte </returns>
		///<author>Home Technology</author>
		public List<clsPlancomptablenaturecompte> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NC_CODENATURECOMPTE, NC_LIBELLENATURECOMPTE, NC_NUMEROORDRE FROM dbo.FT_PLANCOMPTABLENATURECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPlancomptablenaturecompte> clsPlancomptablenaturecomptes = new List<clsPlancomptablenaturecompte>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPlancomptablenaturecompte clsPlancomptablenaturecompte = new clsPlancomptablenaturecompte();
					clsPlancomptablenaturecompte.NC_CODENATURECOMPTE = clsDonnee.vogDataReader["NC_CODENATURECOMPTE"].ToString();
					clsPlancomptablenaturecompte.NC_LIBELLENATURECOMPTE = clsDonnee.vogDataReader["NC_LIBELLENATURECOMPTE"].ToString();
					clsPlancomptablenaturecompte.NC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NC_NUMEROORDRE"].ToString());
					clsPlancomptablenaturecomptes.Add(clsPlancomptablenaturecompte);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlancomptablenaturecomptes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlancomptablenaturecompte </returns>
		///<author>Home Technology</author>
		public List<clsPlancomptablenaturecompte> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPlancomptablenaturecompte> clsPlancomptablenaturecomptes = new List<clsPlancomptablenaturecompte>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NC_CODENATURECOMPTE, NC_LIBELLENATURECOMPTE, NC_NUMEROORDRE FROM dbo.FT_PLANCOMPTABLENATURECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPlancomptablenaturecompte clsPlancomptablenaturecompte = new clsPlancomptablenaturecompte();
					clsPlancomptablenaturecompte.NC_CODENATURECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["NC_CODENATURECOMPTE"].ToString();
					clsPlancomptablenaturecompte.NC_LIBELLENATURECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["NC_LIBELLENATURECOMPTE"].ToString();
					clsPlancomptablenaturecompte.NC_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["NC_NUMEROORDRE"].ToString());
					clsPlancomptablenaturecomptes.Add(clsPlancomptablenaturecompte);
				}
				Dataset.Dispose();
			}
		return clsPlancomptablenaturecomptes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PLANCOMPTABLENATURECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NC_CODENATURECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NC_CODENATURECOMPTE , NC_LIBELLENATURECOMPTE FROM dbo.FT_PLANCOMPTABLENATURECOMPTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NC_CODENATURECOMPTE)</summary>
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
				this.vapCritere ="WHERE NC_CODENATURECOMPTE=@NC_CODENATURECOMPTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NC_CODENATURECOMPTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
