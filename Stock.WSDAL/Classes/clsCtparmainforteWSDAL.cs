using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparmainforteWSDAL: ITableDAL<clsCtparmainforte>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MF_CODEMAINFORTE) AS MF_CODEMAINFORTE  FROM dbo.FT_CTPARMAINFORTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MF_CODEMAINFORTE) AS MF_CODEMAINFORTE  FROM dbo.FT_CTPARMAINFORTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MF_CODEMAINFORTE) AS MF_CODEMAINFORTE  FROM dbo.FT_CTPARMAINFORTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparmainforte comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparmainforte pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MF_LIBLLEMAINFORTE  , MF_NUMEROORDRE  FROM dbo.FT_CTPARMAINFORTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparmainforte clsCtparmainforte = new clsCtparmainforte();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparmainforte.MF_LIBLLEMAINFORTE = clsDonnee.vogDataReader["MF_LIBLLEMAINFORTE"].ToString();
					clsCtparmainforte.MF_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["MF_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparmainforte;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparmainforte>clsCtparmainforte</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparmainforte clsCtparmainforte)
		{
			//Préparation des paramètres
			SqlParameter vppParamMF_CODEMAINFORTE = new SqlParameter("@MF_CODEMAINFORTE", SqlDbType.VarChar, 2);
			vppParamMF_CODEMAINFORTE.Value  = clsCtparmainforte.MF_CODEMAINFORTE ;
			SqlParameter vppParamMF_LIBLLEMAINFORTE = new SqlParameter("@MF_LIBLLEMAINFORTE", SqlDbType.VarChar, 150);
			vppParamMF_LIBLLEMAINFORTE.Value  = clsCtparmainforte.MF_LIBLLEMAINFORTE ;
			SqlParameter vppParamMF_NUMEROORDRE = new SqlParameter("@MF_NUMEROORDRE", SqlDbType.Int);
			vppParamMF_NUMEROORDRE.Value  = clsCtparmainforte.MF_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARMAINFORTE  @MF_CODEMAINFORTE, @MF_LIBLLEMAINFORTE, @MF_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMF_CODEMAINFORTE);
			vppSqlCmd.Parameters.Add(vppParamMF_LIBLLEMAINFORTE);
			vppSqlCmd.Parameters.Add(vppParamMF_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparmainforte>clsCtparmainforte</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparmainforte clsCtparmainforte,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMF_CODEMAINFORTE = new SqlParameter("@MF_CODEMAINFORTE", SqlDbType.VarChar, 2);
			vppParamMF_CODEMAINFORTE.Value  = clsCtparmainforte.MF_CODEMAINFORTE ;
			SqlParameter vppParamMF_LIBLLEMAINFORTE = new SqlParameter("@MF_LIBLLEMAINFORTE", SqlDbType.VarChar, 150);
			vppParamMF_LIBLLEMAINFORTE.Value  = clsCtparmainforte.MF_LIBLLEMAINFORTE ;
			SqlParameter vppParamMF_NUMEROORDRE = new SqlParameter("@MF_NUMEROORDRE", SqlDbType.Int);
			vppParamMF_NUMEROORDRE.Value  = clsCtparmainforte.MF_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARMAINFORTE  @MF_CODEMAINFORTE, @MF_LIBLLEMAINFORTE, @MF_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMF_CODEMAINFORTE);
			vppSqlCmd.Parameters.Add(vppParamMF_LIBLLEMAINFORTE);
			vppSqlCmd.Parameters.Add(vppParamMF_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARMAINFORTE  @MF_CODEMAINFORTE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparmainforte </returns>
		///<author>Home Technology</author>
		public List<clsCtparmainforte> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MF_CODEMAINFORTE, MF_LIBLLEMAINFORTE, MF_NUMEROORDRE FROM dbo.FT_CTPARMAINFORTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparmainforte> clsCtparmainfortes = new List<clsCtparmainforte>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparmainforte clsCtparmainforte = new clsCtparmainforte();
					clsCtparmainforte.MF_CODEMAINFORTE = clsDonnee.vogDataReader["MF_CODEMAINFORTE"].ToString();
					clsCtparmainforte.MF_LIBLLEMAINFORTE = clsDonnee.vogDataReader["MF_LIBLLEMAINFORTE"].ToString();
					clsCtparmainforte.MF_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["MF_NUMEROORDRE"].ToString());
					clsCtparmainfortes.Add(clsCtparmainforte);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparmainfortes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparmainforte </returns>
		///<author>Home Technology</author>
		public List<clsCtparmainforte> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparmainforte> clsCtparmainfortes = new List<clsCtparmainforte>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MF_CODEMAINFORTE, MF_LIBLLEMAINFORTE, MF_NUMEROORDRE FROM dbo.FT_CTPARMAINFORTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparmainforte clsCtparmainforte = new clsCtparmainforte();
					clsCtparmainforte.MF_CODEMAINFORTE = Dataset.Tables["TABLE"].Rows[Idx]["MF_CODEMAINFORTE"].ToString();
					clsCtparmainforte.MF_LIBLLEMAINFORTE = Dataset.Tables["TABLE"].Rows[Idx]["MF_LIBLLEMAINFORTE"].ToString();
					clsCtparmainforte.MF_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MF_NUMEROORDRE"].ToString());
					clsCtparmainfortes.Add(clsCtparmainforte);
				}
				Dataset.Dispose();
			}
		return clsCtparmainfortes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARMAINFORTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MF_CODEMAINFORTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MF_CODEMAINFORTE , MF_LIBLLEMAINFORTE FROM dbo.FT_CTPARMAINFORTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MF_CODEMAINFORTE)</summary>
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
				this.vapCritere ="WHERE MF_CODEMAINFORTE=@MF_CODEMAINFORTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MF_CODEMAINFORTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
