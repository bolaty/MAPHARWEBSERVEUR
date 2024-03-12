using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpartypecontratsanteWSDAL: ITableDAL<clsCtpartypecontratsante>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TA_CODETYPECONTRATSANTE) AS TA_CODETYPECONTRATSANTE  FROM dbo.FT_CTPARTYPECONTRATSANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TA_CODETYPECONTRATSANTE) AS TA_CODETYPECONTRATSANTE  FROM dbo.FT_CTPARTYPECONTRATSANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TA_CODETYPECONTRATSANTE) AS TA_CODETYPECONTRATSANTE  FROM dbo.FT_CTPARTYPECONTRATSANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpartypecontratsante comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpartypecontratsante pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_LIBELLETYPECONTRATSANTE  , TA_ACTIF  , TA_NUMEROORDRE  FROM dbo.FT_CTPARTYPECONTRATSANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpartypecontratsante clsCtpartypecontratsante = new clsCtpartypecontratsante();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE = clsDonnee.vogDataReader["TA_LIBELLETYPECONTRATSANTE"].ToString();
					clsCtpartypecontratsante.TA_ACTIF = clsDonnee.vogDataReader["TA_ACTIF"].ToString();
					clsCtpartypecontratsante.TA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TA_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpartypecontratsante;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypecontratsante>clsCtpartypecontratsante</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpartypecontratsante clsCtpartypecontratsante)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETYPECONTRATSANTE = new SqlParameter("@TA_CODETYPECONTRATSANTE", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPECONTRATSANTE.Value  = clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE ;
			SqlParameter vppParamTA_LIBELLETYPECONTRATSANTE = new SqlParameter("@TA_LIBELLETYPECONTRATSANTE", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLETYPECONTRATSANTE.Value  = clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE ;
			SqlParameter vppParamTA_ACTIF = new SqlParameter("@TA_ACTIF", SqlDbType.VarChar, 1);
			vppParamTA_ACTIF.Value  = clsCtpartypecontratsante.TA_ACTIF ;
			SqlParameter vppParamTA_NUMEROORDRE = new SqlParameter("@TA_NUMEROORDRE", SqlDbType.Int);
			vppParamTA_NUMEROORDRE.Value  = clsCtpartypecontratsante.TA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPECONTRATSANTE  @TA_CODETYPECONTRATSANTE, @TA_LIBELLETYPECONTRATSANTE, @TA_ACTIF, @TA_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPECONTRATSANTE);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLETYPECONTRATSANTE);
			vppSqlCmd.Parameters.Add(vppParamTA_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamTA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypecontratsante>clsCtpartypecontratsante</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpartypecontratsante clsCtpartypecontratsante,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETYPECONTRATSANTE = new SqlParameter("@TA_CODETYPECONTRATSANTE", SqlDbType.VarChar, 2);
			vppParamTA_CODETYPECONTRATSANTE.Value  = clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE ;
			SqlParameter vppParamTA_LIBELLETYPECONTRATSANTE = new SqlParameter("@TA_LIBELLETYPECONTRATSANTE", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLETYPECONTRATSANTE.Value  = clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE ;
			SqlParameter vppParamTA_ACTIF = new SqlParameter("@TA_ACTIF", SqlDbType.VarChar, 1);
			vppParamTA_ACTIF.Value  = clsCtpartypecontratsante.TA_ACTIF ;
			SqlParameter vppParamTA_NUMEROORDRE = new SqlParameter("@TA_NUMEROORDRE", SqlDbType.Int);
			vppParamTA_NUMEROORDRE.Value  = clsCtpartypecontratsante.TA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPECONTRATSANTE  @TA_CODETYPECONTRATSANTE, @TA_LIBELLETYPECONTRATSANTE, @TA_ACTIF, @TA_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETYPECONTRATSANTE);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLETYPECONTRATSANTE);
			vppSqlCmd.Parameters.Add(vppParamTA_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamTA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPECONTRATSANTE  @TA_CODETYPECONTRATSANTE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypecontratsante </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypecontratsante> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPECONTRATSANTE, TA_LIBELLETYPECONTRATSANTE, TA_ACTIF, TA_NUMEROORDRE FROM dbo.FT_CTPARTYPECONTRATSANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<clsCtpartypecontratsante>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypecontratsante clsCtpartypecontratsante = new clsCtpartypecontratsante();
					clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE = clsDonnee.vogDataReader["TA_CODETYPECONTRATSANTE"].ToString();
					clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE = clsDonnee.vogDataReader["TA_LIBELLETYPECONTRATSANTE"].ToString();
					clsCtpartypecontratsante.TA_ACTIF = clsDonnee.vogDataReader["TA_ACTIF"].ToString();
					clsCtpartypecontratsante.TA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TA_NUMEROORDRE"].ToString());
					clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpartypecontratsantes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypecontratsante </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypecontratsante> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<clsCtpartypecontratsante>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETYPECONTRATSANTE, TA_LIBELLETYPECONTRATSANTE, TA_ACTIF, TA_NUMEROORDRE FROM dbo.FT_CTPARTYPECONTRATSANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpartypecontratsante clsCtpartypecontratsante = new clsCtpartypecontratsante();
					clsCtpartypecontratsante.TA_CODETYPECONTRATSANTE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETYPECONTRATSANTE"].ToString();
					clsCtpartypecontratsante.TA_LIBELLETYPECONTRATSANTE = Dataset.Tables["TABLE"].Rows[Idx]["TA_LIBELLETYPECONTRATSANTE"].ToString();
					clsCtpartypecontratsante.TA_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["TA_ACTIF"].ToString();
					clsCtpartypecontratsante.TA_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TA_NUMEROORDRE"].ToString());
					clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
				}
				Dataset.Dispose();
			}
		return clsCtpartypecontratsantes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARTYPECONTRATSANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETYPECONTRATSANTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_CODETYPECONTRATSANTE , TA_LIBELLETYPECONTRATSANTE FROM dbo.FT_CTPARTYPECONTRATSANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETYPECONTRATSANTE)</summary>
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
				this.vapCritere ="WHERE TA_CODETYPECONTRATSANTE=@TA_CODETYPECONTRATSANTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TA_CODETYPECONTRATSANTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
