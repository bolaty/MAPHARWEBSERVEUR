using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparenergieautoWSDAL: ITableDAL<clsCtparenergieauto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(EN_CODEENERGIE) AS EN_CODEENERGIE  FROM dbo.FT_CTPARENERGIEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(EN_CODEENERGIE) AS EN_CODEENERGIE  FROM dbo.FT_CTPARENERGIEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(EN_CODEENERGIE) AS EN_CODEENERGIE  FROM dbo.FT_CTPARENERGIEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparenergieauto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparenergieauto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_LIBELLEENERGIE  , EN_ACTIF  , EN_NUMEROORDRE  FROM dbo.FT_CTPARENERGIEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparenergieauto clsCtparenergieauto = new clsCtparenergieauto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparenergieauto.EN_LIBELLEENERGIE = clsDonnee.vogDataReader["EN_LIBELLEENERGIE"].ToString();
					clsCtparenergieauto.EN_ACTIF = clsDonnee.vogDataReader["EN_ACTIF"].ToString();
					clsCtparenergieauto.EN_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["EN_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparenergieauto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparenergieauto>clsCtparenergieauto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparenergieauto clsCtparenergieauto)
		{
			//Préparation des paramètres
			SqlParameter vppParamEN_CODEENERGIE = new SqlParameter("@EN_CODEENERGIE", SqlDbType.VarChar, 25);
			vppParamEN_CODEENERGIE.Value  = clsCtparenergieauto.EN_CODEENERGIE ;
			SqlParameter vppParamEN_LIBELLEENERGIE = new SqlParameter("@EN_LIBELLEENERGIE", SqlDbType.VarChar, 150);
			vppParamEN_LIBELLEENERGIE.Value  = clsCtparenergieauto.EN_LIBELLEENERGIE ;
			SqlParameter vppParamEN_ACTIF = new SqlParameter("@EN_ACTIF", SqlDbType.VarChar, 1);
			vppParamEN_ACTIF.Value  = clsCtparenergieauto.EN_ACTIF ;
			SqlParameter vppParamEN_NUMEROORDRE = new SqlParameter("@EN_NUMEROORDRE", SqlDbType.Int);
			vppParamEN_NUMEROORDRE.Value  = clsCtparenergieauto.EN_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARENERGIEAUTO  @EN_CODEENERGIE, @EN_LIBELLEENERGIE, @EN_ACTIF, @EN_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENERGIE);
			vppSqlCmd.Parameters.Add(vppParamEN_LIBELLEENERGIE);
			vppSqlCmd.Parameters.Add(vppParamEN_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamEN_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparenergieauto>clsCtparenergieauto</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparenergieauto clsCtparenergieauto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamEN_CODEENERGIE = new SqlParameter("@EN_CODEENERGIE", SqlDbType.VarChar, 25);
			vppParamEN_CODEENERGIE.Value  = clsCtparenergieauto.EN_CODEENERGIE ;
			SqlParameter vppParamEN_LIBELLEENERGIE = new SqlParameter("@EN_LIBELLEENERGIE", SqlDbType.VarChar, 150);
			vppParamEN_LIBELLEENERGIE.Value  = clsCtparenergieauto.EN_LIBELLEENERGIE ;
			SqlParameter vppParamEN_ACTIF = new SqlParameter("@EN_ACTIF", SqlDbType.VarChar, 1);
			vppParamEN_ACTIF.Value  = clsCtparenergieauto.EN_ACTIF ;
			SqlParameter vppParamEN_NUMEROORDRE = new SqlParameter("@EN_NUMEROORDRE", SqlDbType.Int);
			vppParamEN_NUMEROORDRE.Value  = clsCtparenergieauto.EN_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARENERGIEAUTO  @EN_CODEENERGIE, @EN_LIBELLEENERGIE, @EN_ACTIF, @EN_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENERGIE);
			vppSqlCmd.Parameters.Add(vppParamEN_LIBELLEENERGIE);
			vppSqlCmd.Parameters.Add(vppParamEN_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamEN_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARENERGIEAUTO  @EN_CODEENERGIE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparenergieauto </returns>
		///<author>Home Technology</author>
		public List<clsCtparenergieauto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EN_CODEENERGIE, EN_LIBELLEENERGIE, EN_ACTIF, EN_NUMEROORDRE FROM dbo.FT_CTPARENERGIEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparenergieauto> clsCtparenergieautos = new List<clsCtparenergieauto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparenergieauto clsCtparenergieauto = new clsCtparenergieauto();
					clsCtparenergieauto.EN_CODEENERGIE = clsDonnee.vogDataReader["EN_CODEENERGIE"].ToString();
					clsCtparenergieauto.EN_LIBELLEENERGIE = clsDonnee.vogDataReader["EN_LIBELLEENERGIE"].ToString();
					clsCtparenergieauto.EN_ACTIF = clsDonnee.vogDataReader["EN_ACTIF"].ToString();
					clsCtparenergieauto.EN_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["EN_NUMEROORDRE"].ToString());
					clsCtparenergieautos.Add(clsCtparenergieauto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparenergieautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparenergieauto </returns>
		///<author>Home Technology</author>
		public List<clsCtparenergieauto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparenergieauto> clsCtparenergieautos = new List<clsCtparenergieauto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EN_CODEENERGIE, EN_LIBELLEENERGIE, EN_ACTIF, EN_NUMEROORDRE FROM dbo.FT_CTPARENERGIEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparenergieauto clsCtparenergieauto = new clsCtparenergieauto();
					clsCtparenergieauto.EN_CODEENERGIE = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENERGIE"].ToString();
					clsCtparenergieauto.EN_LIBELLEENERGIE = Dataset.Tables["TABLE"].Rows[Idx]["EN_LIBELLEENERGIE"].ToString();
					clsCtparenergieauto.EN_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["EN_ACTIF"].ToString();
					clsCtparenergieauto.EN_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EN_NUMEROORDRE"].ToString());
					clsCtparenergieautos.Add(clsCtparenergieauto);
				}
				Dataset.Dispose();
			}
		return clsCtparenergieautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARENERGIEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EN_CODEENERGIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENERGIE , EN_LIBELLEENERGIE FROM dbo.FT_CTPARENERGIEAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :EN_CODEENERGIE)</summary>
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
				this.vapCritere ="WHERE EN_CODEENERGIE=@EN_CODEENERGIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@EN_CODEENERGIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
