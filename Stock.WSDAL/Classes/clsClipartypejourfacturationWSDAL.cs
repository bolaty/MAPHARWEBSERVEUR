using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsClipartypejourfacturationWSDAL: ITableDAL<clsClipartypejourfacturation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(JF_CODETYPEJOURFACTURATION) AS JF_CODETYPEJOURFACTURATION  FROM dbo.FT_CLIPARTYPEJOURFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(JF_CODETYPEJOURFACTURATION) AS JF_CODETYPEJOURFACTURATION  FROM dbo.FT_CLIPARTYPEJOURFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(JF_CODETYPEJOURFACTURATION) AS JF_CODETYPEJOURFACTURATION  FROM dbo.FT_CLIPARTYPEJOURFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsClipartypejourfacturation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsClipartypejourfacturation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT JF_LIBELLETYPEJOURFACTURATION  , JF_ACTIF  , JF_NUMEROORDRE  FROM dbo.FT_CLIPARTYPEJOURFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsClipartypejourfacturation clsClipartypejourfacturation = new clsClipartypejourfacturation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClipartypejourfacturation.JF_LIBELLETYPEJOURFACTURATION = clsDonnee.vogDataReader["JF_LIBELLETYPEJOURFACTURATION"].ToString();
					clsClipartypejourfacturation.JF_ACTIF = clsDonnee.vogDataReader["JF_ACTIF"].ToString();
					clsClipartypejourfacturation.JF_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["JF_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsClipartypejourfacturation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClipartypejourfacturation>clsClipartypejourfacturation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsClipartypejourfacturation clsClipartypejourfacturation)
		{
			//Préparation des paramètres
			SqlParameter vppParamJF_CODETYPEJOURFACTURATION = new SqlParameter("@JF_CODETYPEJOURFACTURATION", SqlDbType.VarChar, 2);
			vppParamJF_CODETYPEJOURFACTURATION.Value  = clsClipartypejourfacturation.JF_CODETYPEJOURFACTURATION ;
			SqlParameter vppParamJF_LIBELLETYPEJOURFACTURATION = new SqlParameter("@JF_LIBELLETYPEJOURFACTURATION", SqlDbType.VarChar, 150);
			vppParamJF_LIBELLETYPEJOURFACTURATION.Value  = clsClipartypejourfacturation.JF_LIBELLETYPEJOURFACTURATION ;
			SqlParameter vppParamJF_ACTIF = new SqlParameter("@JF_ACTIF", SqlDbType.VarChar, 1);
			vppParamJF_ACTIF.Value  = clsClipartypejourfacturation.JF_ACTIF ;
			SqlParameter vppParamJF_NUMEROORDRE = new SqlParameter("@JF_NUMEROORDRE", SqlDbType.Int);
			vppParamJF_NUMEROORDRE.Value  = clsClipartypejourfacturation.JF_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPEJOURFACTURATION  @JF_CODETYPEJOURFACTURATION, @JF_LIBELLETYPEJOURFACTURATION, @JF_ACTIF, @JF_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamJF_CODETYPEJOURFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamJF_LIBELLETYPEJOURFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamJF_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamJF_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsClipartypejourfacturation>clsClipartypejourfacturation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsClipartypejourfacturation clsClipartypejourfacturation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamJF_CODETYPEJOURFACTURATION = new SqlParameter("@JF_CODETYPEJOURFACTURATION", SqlDbType.VarChar, 2);
			vppParamJF_CODETYPEJOURFACTURATION.Value  = clsClipartypejourfacturation.JF_CODETYPEJOURFACTURATION ;
			SqlParameter vppParamJF_LIBELLETYPEJOURFACTURATION = new SqlParameter("@JF_LIBELLETYPEJOURFACTURATION", SqlDbType.VarChar, 150);
			vppParamJF_LIBELLETYPEJOURFACTURATION.Value  = clsClipartypejourfacturation.JF_LIBELLETYPEJOURFACTURATION ;
			SqlParameter vppParamJF_ACTIF = new SqlParameter("@JF_ACTIF", SqlDbType.VarChar, 1);
			vppParamJF_ACTIF.Value  = clsClipartypejourfacturation.JF_ACTIF ;
			SqlParameter vppParamJF_NUMEROORDRE = new SqlParameter("@JF_NUMEROORDRE", SqlDbType.Int);
			vppParamJF_NUMEROORDRE.Value  = clsClipartypejourfacturation.JF_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPEJOURFACTURATION  @JF_CODETYPEJOURFACTURATION, @JF_LIBELLETYPEJOURFACTURATION, @JF_ACTIF, @JF_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamJF_CODETYPEJOURFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamJF_LIBELLETYPEJOURFACTURATION);
			vppSqlCmd.Parameters.Add(vppParamJF_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamJF_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIPARTYPEJOURFACTURATION  @JF_CODETYPEJOURFACTURATION, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCLIPARTYPEJOURFACTURATION </returns>
		///<author>Home Technology</author>
		public List<clsClipartypejourfacturation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  JF_CODETYPEJOURFACTURATION, JF_LIBELLETYPEJOURFACTURATION, JF_ACTIF, JF_NUMEROORDRE FROM dbo.FT_CLIPARTYPEJOURFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsClipartypejourfacturation> clsClipartypejourfacturations = new List<clsClipartypejourfacturation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsClipartypejourfacturation clsClipartypejourfacturation = new clsClipartypejourfacturation();
					clsClipartypejourfacturation.JF_CODETYPEJOURFACTURATION = clsDonnee.vogDataReader["JF_CODETYPEJOURFACTURATION"].ToString();
					clsClipartypejourfacturation.JF_LIBELLETYPEJOURFACTURATION = clsDonnee.vogDataReader["JF_LIBELLETYPEJOURFACTURATION"].ToString();
					clsClipartypejourfacturation.JF_ACTIF = clsDonnee.vogDataReader["JF_ACTIF"].ToString();
					clsClipartypejourfacturation.JF_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["JF_NUMEROORDRE"].ToString());
					clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsClipartypejourfacturations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClipartypejourfacturation </returns>
		///<author>Home Technology</author>
		public List<clsClipartypejourfacturation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsClipartypejourfacturation> clsClipartypejourfacturations = new List<clsClipartypejourfacturation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  JF_CODETYPEJOURFACTURATION, JF_LIBELLETYPEJOURFACTURATION, JF_ACTIF, JF_NUMEROORDRE FROM dbo.FT_CLIPARTYPEJOURFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsClipartypejourfacturation clsClipartypejourfacturation = new clsClipartypejourfacturation();
					clsClipartypejourfacturation.JF_CODETYPEJOURFACTURATION = Dataset.Tables["TABLE"].Rows[Idx]["JF_CODETYPEJOURFACTURATION"].ToString();
					clsClipartypejourfacturation.JF_LIBELLETYPEJOURFACTURATION = Dataset.Tables["TABLE"].Rows[Idx]["JF_LIBELLETYPEJOURFACTURATION"].ToString();
					clsClipartypejourfacturation.JF_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["JF_ACTIF"].ToString();
					clsClipartypejourfacturation.JF_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["JF_NUMEROORDRE"].ToString());
					clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
				}
				Dataset.Dispose();
			}
		return clsClipartypejourfacturations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_Clipartypejourfacturation(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : JF_CODETYPEJOURFACTURATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT JF_CODETYPEJOURFACTURATION , JF_LIBELLETYPEJOURFACTURATION FROM dbo.FT_CLIPARTYPEJOURFACTURATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :JF_CODETYPEJOURFACTURATION)</summary>
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
				this.vapCritere ="WHERE JF_CODETYPEJOURFACTURATION=@JF_CODETYPEJOURFACTURATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@JF_CODETYPEJOURFACTURATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
