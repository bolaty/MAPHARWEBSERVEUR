using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhazdecaisseWSDAL: ITableDAL<clsPhazdecaisse>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(ZC_CODE) AS ZC_CODE  FROM dbo.FT_PHAZDECAISSE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(ZC_CODE) AS ZC_CODE  FROM dbo.FT_PHAZDECAISSE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(ZC_CODE) AS ZC_CODE  FROM dbo.FT_PHAZDECAISSE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhazdecaisse comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhazdecaisse pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ZC_LIBELLE  , ZC_ACTIF  , ZC_NUMEROORDRE  FROM dbo.FT_PHAZDECAISSE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhazdecaisse clsPhazdecaisse = new clsPhazdecaisse();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhazdecaisse.ZC_LIBELLE = clsDonnee.vogDataReader["ZC_LIBELLE"].ToString();
					clsPhazdecaisse.ZC_ACTIF = clsDonnee.vogDataReader["ZC_ACTIF"].ToString();
					clsPhazdecaisse.ZC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["ZC_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhazdecaisse;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhazdecaisse>clsPhazdecaisse</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhazdecaisse clsPhazdecaisse)
		{
			//Préparation des paramètres
			SqlParameter vppParamZC_CODE = new SqlParameter("@ZC_CODE", SqlDbType.VarChar, 10);
			vppParamZC_CODE.Value  = clsPhazdecaisse.ZC_CODE ;
			SqlParameter vppParamZC_LIBELLE = new SqlParameter("@ZC_LIBELLE", SqlDbType.VarChar, 150);
			vppParamZC_LIBELLE.Value  = clsPhazdecaisse.ZC_LIBELLE ;
			SqlParameter vppParamZC_ACTIF = new SqlParameter("@ZC_ACTIF", SqlDbType.VarChar, 1);
			vppParamZC_ACTIF.Value  = clsPhazdecaisse.ZC_ACTIF ;
			SqlParameter vppParamZC_NUMEROORDRE = new SqlParameter("@ZC_NUMEROORDRE", SqlDbType.Int);
			vppParamZC_NUMEROORDRE.Value  = clsPhazdecaisse.ZC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAZDECAISSE  @ZC_CODE, @ZC_LIBELLE, @ZC_ACTIF, @ZC_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZC_CODE);
			vppSqlCmd.Parameters.Add(vppParamZC_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamZC_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamZC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhazdecaisse>clsPhazdecaisse</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhazdecaisse clsPhazdecaisse,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamZC_CODE = new SqlParameter("@ZC_CODE", SqlDbType.VarChar, 10);
			vppParamZC_CODE.Value  = clsPhazdecaisse.ZC_CODE ;
			SqlParameter vppParamZC_LIBELLE = new SqlParameter("@ZC_LIBELLE", SqlDbType.VarChar, 150);
			vppParamZC_LIBELLE.Value  = clsPhazdecaisse.ZC_LIBELLE ;
			SqlParameter vppParamZC_ACTIF = new SqlParameter("@ZC_ACTIF", SqlDbType.VarChar, 1);
			vppParamZC_ACTIF.Value  = clsPhazdecaisse.ZC_ACTIF ;
			SqlParameter vppParamZC_NUMEROORDRE = new SqlParameter("@ZC_NUMEROORDRE", SqlDbType.Int);
			vppParamZC_NUMEROORDRE.Value  = clsPhazdecaisse.ZC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAZDECAISSE  @ZC_CODE, @ZC_LIBELLE, @ZC_ACTIF, @ZC_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZC_CODE);
			vppSqlCmd.Parameters.Add(vppParamZC_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamZC_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamZC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAZDECAISSE  @ZC_CODE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhazdecaisse </returns>
		///<author>Home Technology</author>
		public List<clsPhazdecaisse> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ZC_CODE, ZC_LIBELLE, ZC_ACTIF, ZC_NUMEROORDRE FROM dbo.FT_PHAZDECAISSE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhazdecaisse> clsPhazdecaisses = new List<clsPhazdecaisse>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhazdecaisse clsPhazdecaisse = new clsPhazdecaisse();
					clsPhazdecaisse.ZC_CODE = clsDonnee.vogDataReader["ZC_CODE"].ToString();
					clsPhazdecaisse.ZC_LIBELLE = clsDonnee.vogDataReader["ZC_LIBELLE"].ToString();
					clsPhazdecaisse.ZC_ACTIF = clsDonnee.vogDataReader["ZC_ACTIF"].ToString();
					clsPhazdecaisse.ZC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["ZC_NUMEROORDRE"].ToString());
					clsPhazdecaisses.Add(clsPhazdecaisse);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhazdecaisses;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhazdecaisse </returns>
		///<author>Home Technology</author>
		public List<clsPhazdecaisse> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhazdecaisse> clsPhazdecaisses = new List<clsPhazdecaisse>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  ZC_CODE, ZC_LIBELLE, ZC_ACTIF, ZC_NUMEROORDRE FROM dbo.FT_PHAZDECAISSE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhazdecaisse clsPhazdecaisse = new clsPhazdecaisse();
					clsPhazdecaisse.ZC_CODE = Dataset.Tables["TABLE"].Rows[Idx]["ZC_CODE"].ToString();
					clsPhazdecaisse.ZC_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["ZC_LIBELLE"].ToString();
					clsPhazdecaisse.ZC_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["ZC_ACTIF"].ToString();
					clsPhazdecaisse.ZC_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ZC_NUMEROORDRE"].ToString());
					clsPhazdecaisses.Add(clsPhazdecaisse);
				}
				Dataset.Dispose();
			}
		return clsPhazdecaisses;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAZDECAISSE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : ZC_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ZC_CODE , ZC_LIBELLE FROM dbo.FT_PHAZDECAISSE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :ZC_CODE)</summary>
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
				this.vapCritere ="WHERE ZC_CODE=@ZC_CODE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ZC_CODE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
