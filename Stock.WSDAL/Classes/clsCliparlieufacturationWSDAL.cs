using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliparlieufacturationWSDAL: ITableDAL<clsCliparlieufacturation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(LF_CODELIEUFACTURATION) AS LF_CODELIEUFACTURATION  FROM dbo.FT_CLIPARLIEUFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(LF_CODELIEUFACTURATION) AS LF_CODELIEUFACTURATION  FROM dbo.FT_CLIPARLIEUFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(LF_CODELIEUFACTURATION) AS LF_CODELIEUFACTURATION  FROM dbo.FT_CLIPARLIEUFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliparlieufacturation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliparlieufacturation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT LF_LIBELLELIEUFACTURATION  , LF_ACTIF  , LF_NUMEROORDRE  FROM dbo.FT_CLIPARLIEUFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliparlieufacturation clsCliparlieufacturation = new clsCliparlieufacturation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparlieufacturation.LF_LIBELLELIEUFACTURATION = clsDonnee.vogDataReader["LF_LIBELLELIEUFACTURATION"].ToString();
					clsCliparlieufacturation.LF_ACTIF = clsDonnee.vogDataReader["LF_ACTIF"].ToString();
					clsCliparlieufacturation.LF_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["LF_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliparlieufacturation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparlieufacturation>clsCliparlieufacturation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliparlieufacturation clsCliparlieufacturation)
		{
			//Préparation des paramètres
			SqlParameter vppParamLF_CODELIEUFACTURATION = new SqlParameter("@LF_CODELIEUFACTURATION", SqlDbType.VarChar, 2);
			vppParamLF_CODELIEUFACTURATION.Value  = clsCliparlieufacturation.LF_CODELIEUFACTURATION ;
			SqlParameter vppParamLF_LIBELLELIEUFACTURATION = new SqlParameter("@LF_LIBELLELIEUFACTURATION", SqlDbType.VarChar, 150);
			vppParamLF_LIBELLELIEUFACTURATION.Value  = clsCliparlieufacturation.LF_LIBELLELIEUFACTURATION ;
			SqlParameter vppParamLF_ACTIF = new SqlParameter("@LF_ACTIF", SqlDbType.VarChar, 1);
			vppParamLF_ACTIF.Value  = clsCliparlieufacturation.LF_ACTIF ;
			SqlParameter vppParamLF_NUMEROORDRE = new SqlParameter("@LF_NUMEROORDRE", SqlDbType.Int);
			vppParamLF_NUMEROORDRE.Value  = clsCliparlieufacturation.LF_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARLIEUFACTURATION  @LF_CODELIEUFACTURATION, @LF_LIBELLELIEUFACTURATION, @LF_ACTIF, @LF_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLF_CODELIEUFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamLF_LIBELLELIEUFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamLF_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamLF_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliparlieufacturation>clsCliparlieufacturation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliparlieufacturation clsCliparlieufacturation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamLF_CODELIEUFACTURATION = new SqlParameter("@LF_CODELIEUFACTURATION", SqlDbType.VarChar, 2);
			vppParamLF_CODELIEUFACTURATION.Value  = clsCliparlieufacturation.LF_CODELIEUFACTURATION ;
			SqlParameter vppParamLF_LIBELLELIEUFACTURATION = new SqlParameter("@LF_LIBELLELIEUFACTURATION", SqlDbType.VarChar, 150);
			vppParamLF_LIBELLELIEUFACTURATION.Value  = clsCliparlieufacturation.LF_LIBELLELIEUFACTURATION ;
			SqlParameter vppParamLF_ACTIF = new SqlParameter("@LF_ACTIF", SqlDbType.VarChar, 1);
			vppParamLF_ACTIF.Value  = clsCliparlieufacturation.LF_ACTIF ;
			SqlParameter vppParamLF_NUMEROORDRE = new SqlParameter("@LF_NUMEROORDRE", SqlDbType.Int);
			vppParamLF_NUMEROORDRE.Value  = clsCliparlieufacturation.LF_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARLIEUFACTURATION  @LF_CODELIEUFACTURATION, @LF_LIBELLELIEUFACTURATION, @LF_ACTIF, @LF_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLF_CODELIEUFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamLF_LIBELLELIEUFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamLF_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamLF_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARLIEUFACTURATION  @LF_CODELIEUFACTURATION, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparlieufacturation </returns>
		///<author>Home Technology</author>
		public List<clsCliparlieufacturation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  LF_CODELIEUFACTURATION, LF_LIBELLELIEUFACTURATION, LF_ACTIF, LF_NUMEROORDRE FROM dbo.FT_CLIPARLIEUFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliparlieufacturation> clsCliparlieufacturations = new List<clsCliparlieufacturation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliparlieufacturation clsCliparlieufacturation = new clsCliparlieufacturation();
					clsCliparlieufacturation.LF_CODELIEUFACTURATION = clsDonnee.vogDataReader["LF_CODELIEUFACTURATION"].ToString();
					clsCliparlieufacturation.LF_LIBELLELIEUFACTURATION = clsDonnee.vogDataReader["LF_LIBELLELIEUFACTURATION"].ToString();
					clsCliparlieufacturation.LF_ACTIF = clsDonnee.vogDataReader["LF_ACTIF"].ToString();
					clsCliparlieufacturation.LF_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["LF_NUMEROORDRE"].ToString());
					clsCliparlieufacturations.Add(clsCliparlieufacturation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliparlieufacturations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliparlieufacturation </returns>
		///<author>Home Technology</author>
		public List<clsCliparlieufacturation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliparlieufacturation> clsCliparlieufacturations = new List<clsCliparlieufacturation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  LF_CODELIEUFACTURATION, LF_LIBELLELIEUFACTURATION, LF_ACTIF, LF_NUMEROORDRE FROM dbo.FT_CLIPARLIEUFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliparlieufacturation clsCliparlieufacturation = new clsCliparlieufacturation();
					clsCliparlieufacturation.LF_CODELIEUFACTURATION = Dataset.Tables["TABLE"].Rows[Idx]["LF_CODELIEUFACTURATION"].ToString();
					clsCliparlieufacturation.LF_LIBELLELIEUFACTURATION = Dataset.Tables["TABLE"].Rows[Idx]["LF_LIBELLELIEUFACTURATION"].ToString();
					clsCliparlieufacturation.LF_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["LF_ACTIF"].ToString();
					clsCliparlieufacturation.LF_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LF_NUMEROORDRE"].ToString());
					clsCliparlieufacturations.Add(clsCliparlieufacturation);
				}
				Dataset.Dispose();
			}
		return clsCliparlieufacturations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIPARLIEUFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LF_CODELIEUFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT LF_CODELIEUFACTURATION , LF_LIBELLELIEUFACTURATION FROM dbo.FT_CLIPARLIEUFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LF_CODELIEUFACTURATION)</summary>
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
				this.vapCritere ="WHERE LF_CODELIEUFACTURATION=@LF_CODELIEUFACTURATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@LF_CODELIEUFACTURATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
