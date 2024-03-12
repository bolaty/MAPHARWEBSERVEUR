using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsClipartitreadherantayantsdroitsWSDAL: ITableDAL<clsClipartitreadherantayantsdroits>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TA_CODETITREAYANTDROIT) AS TA_CODETITREAYANTDROIT  FROM dbo.FT_CLIPARTITREADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TA_CODETITREAYANTDROIT) AS TA_CODETITREAYANTDROIT  FROM dbo.FT_CLIPARTITREADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TA_CODETITREAYANTDROIT) AS TA_CODETITREAYANTDROIT  FROM dbo.FT_CLIPARTITREADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsClipartitreadherantayantsdroits comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsClipartitreadherantayantsdroits pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_LIBELLETITREAYANTDROIT  , TA_ACTIF  , TA_NUMEROORDRE  FROM dbo.FT_CLIPARTITREADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new clsClipartitreadherantayantsdroits();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT = clsDonnee.vogDataReader["TA_LIBELLETITREAYANTDROIT"].ToString();
					clsClipartitreadherantayantsdroits.TA_ACTIF = clsDonnee.vogDataReader["TA_ACTIF"].ToString();
					clsClipartitreadherantayantsdroits.TA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TA_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsClipartitreadherantayantsdroits;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClipartitreadherantayantsdroits>clsClipartitreadherantayantsdroits</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETITREAYANTDROIT = new SqlParameter("@TA_CODETITREAYANTDROIT", SqlDbType.VarChar, 2);
			vppParamTA_CODETITREAYANTDROIT.Value  = clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT ;
			SqlParameter vppParamTA_LIBELLETITREAYANTDROIT = new SqlParameter("@TA_LIBELLETITREAYANTDROIT", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLETITREAYANTDROIT.Value  = clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT ;
			SqlParameter vppParamTA_ACTIF = new SqlParameter("@TA_ACTIF", SqlDbType.VarChar, 1);
			vppParamTA_ACTIF.Value  = clsClipartitreadherantayantsdroits.TA_ACTIF ;
			SqlParameter vppParamTA_NUMEROORDRE = new SqlParameter("@TA_NUMEROORDRE", SqlDbType.Int);
			vppParamTA_NUMEROORDRE.Value  = clsClipartitreadherantayantsdroits.TA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTITREADHERANTAYANTSDROITS  @TA_CODETITREAYANTDROIT, @TA_LIBELLETITREAYANTDROIT, @TA_ACTIF, @TA_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETITREAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLETITREAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamTA_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamTA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClipartitreadherantayantsdroits>clsClipartitreadherantayantsdroits</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETITREAYANTDROIT = new SqlParameter("@TA_CODETITREAYANTDROIT", SqlDbType.VarChar, 2);
			vppParamTA_CODETITREAYANTDROIT.Value  = clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT ;
			SqlParameter vppParamTA_LIBELLETITREAYANTDROIT = new SqlParameter("@TA_LIBELLETITREAYANTDROIT", SqlDbType.VarChar, 150);
			vppParamTA_LIBELLETITREAYANTDROIT.Value  = clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT ;
			SqlParameter vppParamTA_ACTIF = new SqlParameter("@TA_ACTIF", SqlDbType.VarChar, 1);
			vppParamTA_ACTIF.Value  = clsClipartitreadherantayantsdroits.TA_ACTIF ;
			SqlParameter vppParamTA_NUMEROORDRE = new SqlParameter("@TA_NUMEROORDRE", SqlDbType.Int);
			vppParamTA_NUMEROORDRE.Value  = clsClipartitreadherantayantsdroits.TA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTITREADHERANTAYANTSDROITS  @TA_CODETITREAYANTDROIT, @TA_LIBELLETITREAYANTDROIT, @TA_ACTIF, @TA_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETITREAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamTA_LIBELLETITREAYANTDROIT);
			vppSqlCmd.Parameters.Add(vppParamTA_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamTA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTITREADHERANTAYANTSDROITS  @TA_CODETITREAYANTDROIT, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClipartitreadherantayantsdroits </returns>
		///<author>Home Technology</author>
		public List<clsClipartitreadherantayantsdroits> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETITREAYANTDROIT, TA_LIBELLETITREAYANTDROIT, TA_ACTIF, TA_NUMEROORDRE FROM dbo.FT_CLIPARTITREADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<clsClipartitreadherantayantsdroits>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new clsClipartitreadherantayantsdroits();
					clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT = clsDonnee.vogDataReader["TA_CODETITREAYANTDROIT"].ToString();
					clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT = clsDonnee.vogDataReader["TA_LIBELLETITREAYANTDROIT"].ToString();
					clsClipartitreadherantayantsdroits.TA_ACTIF = clsDonnee.vogDataReader["TA_ACTIF"].ToString();
					clsClipartitreadherantayantsdroits.TA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TA_NUMEROORDRE"].ToString());
					clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsClipartitreadherantayantsdroitss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClipartitreadherantayantsdroits </returns>
		///<author>Home Technology</author>
		public List<clsClipartitreadherantayantsdroits> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<clsClipartitreadherantayantsdroits>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETITREAYANTDROIT, TA_LIBELLETITREAYANTDROIT, TA_ACTIF, TA_NUMEROORDRE FROM dbo.FT_CLIPARTITREADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new clsClipartitreadherantayantsdroits();
					clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETITREAYANTDROIT"].ToString();
					clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT = Dataset.Tables["TABLE"].Rows[Idx]["TA_LIBELLETITREAYANTDROIT"].ToString();
					clsClipartitreadherantayantsdroits.TA_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["TA_ACTIF"].ToString();
					clsClipartitreadherantayantsdroits.TA_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TA_NUMEROORDRE"].ToString());
					clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
				}
				Dataset.Dispose();
			}
		return clsClipartitreadherantayantsdroitss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARTITREADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETITREAYANTDROIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TA_CODETITREAYANTDROIT , TA_LIBELLETITREAYANTDROIT FROM dbo.FT_CLIPARTITREADHERANTAYANTSDROITS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETITREAYANTDROIT)</summary>
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
				this.vapCritere ="WHERE TA_CODETITREAYANTDROIT=@TA_CODETITREAYANTDROIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TA_CODETITREAYANTDROIT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
