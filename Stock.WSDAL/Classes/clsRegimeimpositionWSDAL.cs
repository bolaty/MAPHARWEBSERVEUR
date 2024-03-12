using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsRegimeimpositionWSDAL: ITableDAL<clsRegimeimposition>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RE_CODEREGIMEIMPOSITION) AS RE_CODEREGIMEIMPOSITION  FROM dbo.FT_REGIMEIMPOSITION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RE_CODEREGIMEIMPOSITION) AS RE_CODEREGIMEIMPOSITION  FROM dbo.FT_REGIMEIMPOSITION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RE_CODEREGIMEIMPOSITION) AS RE_CODEREGIMEIMPOSITION  FROM dbo.FT_REGIMEIMPOSITION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsRegimeimposition comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsRegimeimposition pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RE_LIBELLEREGIMEIMPOSITION  , RE_NUMEROORDRE  FROM dbo.FT_REGIMEIMPOSITION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsRegimeimposition clsRegimeimposition = new clsRegimeimposition();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION = clsDonnee.vogDataReader["RE_LIBELLEREGIMEIMPOSITION"].ToString();
					clsRegimeimposition.RE_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RE_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsRegimeimposition;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRegimeimposition>clsRegimeimposition</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsRegimeimposition clsRegimeimposition)
		{
			//Préparation des paramètres
			SqlParameter vppParamRE_CODEREGIMEIMPOSITION = new SqlParameter("@RE_CODEREGIMEIMPOSITION", SqlDbType.VarChar, 3);
			vppParamRE_CODEREGIMEIMPOSITION.Value  = clsRegimeimposition.RE_CODEREGIMEIMPOSITION ;
			SqlParameter vppParamRE_LIBELLEREGIMEIMPOSITION = new SqlParameter("@RE_LIBELLEREGIMEIMPOSITION", SqlDbType.VarChar, 150);
			vppParamRE_LIBELLEREGIMEIMPOSITION.Value  = clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION ;
			SqlParameter vppParamRE_NUMEROORDRE = new SqlParameter("@RE_NUMEROORDRE", SqlDbType.Int);
			vppParamRE_NUMEROORDRE.Value  = clsRegimeimposition.RE_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REGIMEIMPOSITION  @RE_CODEREGIMEIMPOSITION, @RE_LIBELLEREGIMEIMPOSITION, @RE_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRE_CODEREGIMEIMPOSITION);
			vppSqlCmd.Parameters.Add(vppParamRE_LIBELLEREGIMEIMPOSITION);
			vppSqlCmd.Parameters.Add(vppParamRE_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRegimeimposition>clsRegimeimposition</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsRegimeimposition clsRegimeimposition,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRE_CODEREGIMEIMPOSITION = new SqlParameter("@RE_CODEREGIMEIMPOSITION", SqlDbType.VarChar, 3);
			vppParamRE_CODEREGIMEIMPOSITION.Value  = clsRegimeimposition.RE_CODEREGIMEIMPOSITION ;
			SqlParameter vppParamRE_LIBELLEREGIMEIMPOSITION = new SqlParameter("@RE_LIBELLEREGIMEIMPOSITION", SqlDbType.VarChar, 150);
			vppParamRE_LIBELLEREGIMEIMPOSITION.Value  = clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION ;
			SqlParameter vppParamRE_NUMEROORDRE = new SqlParameter("@RE_NUMEROORDRE", SqlDbType.Int);
			vppParamRE_NUMEROORDRE.Value  = clsRegimeimposition.RE_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REGIMEIMPOSITION  @RE_CODEREGIMEIMPOSITION, @RE_LIBELLEREGIMEIMPOSITION, @RE_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRE_CODEREGIMEIMPOSITION);
			vppSqlCmd.Parameters.Add(vppParamRE_LIBELLEREGIMEIMPOSITION);
			vppSqlCmd.Parameters.Add(vppParamRE_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REGIMEIMPOSITION  @RE_CODEREGIMEIMPOSITION, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRegimeimposition </returns>
		///<author>Home Technology</author>
		public List<clsRegimeimposition> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RE_CODEREGIMEIMPOSITION, RE_LIBELLEREGIMEIMPOSITION, RE_NUMEROORDRE FROM dbo.FT_REGIMEIMPOSITION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsRegimeimposition> clsRegimeimpositions = new List<clsRegimeimposition>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRegimeimposition clsRegimeimposition = new clsRegimeimposition();
					clsRegimeimposition.RE_CODEREGIMEIMPOSITION = clsDonnee.vogDataReader["RE_CODEREGIMEIMPOSITION"].ToString();
					clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION = clsDonnee.vogDataReader["RE_LIBELLEREGIMEIMPOSITION"].ToString();
					clsRegimeimposition.RE_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["RE_NUMEROORDRE"].ToString());
					clsRegimeimpositions.Add(clsRegimeimposition);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsRegimeimpositions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRegimeimposition </returns>
		///<author>Home Technology</author>
		public List<clsRegimeimposition> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsRegimeimposition> clsRegimeimpositions = new List<clsRegimeimposition>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RE_CODEREGIMEIMPOSITION, RE_LIBELLEREGIMEIMPOSITION, RE_NUMEROORDRE FROM dbo.FT_REGIMEIMPOSITION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsRegimeimposition clsRegimeimposition = new clsRegimeimposition();
					clsRegimeimposition.RE_CODEREGIMEIMPOSITION = Dataset.Tables["TABLE"].Rows[Idx]["RE_CODEREGIMEIMPOSITION"].ToString();
					clsRegimeimposition.RE_LIBELLEREGIMEIMPOSITION = Dataset.Tables["TABLE"].Rows[Idx]["RE_LIBELLEREGIMEIMPOSITION"].ToString();
					clsRegimeimposition.RE_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RE_NUMEROORDRE"].ToString());
					clsRegimeimpositions.Add(clsRegimeimposition);
				}
				Dataset.Dispose();
			}
		return clsRegimeimpositions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REGIMEIMPOSITION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RE_CODEREGIMEIMPOSITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RE_CODEREGIMEIMPOSITION , RE_LIBELLEREGIMEIMPOSITION FROM dbo.FT_REGIMEIMPOSITION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RE_CODEREGIMEIMPOSITION)</summary>
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
				this.vapCritere ="WHERE RE_CODEREGIMEIMPOSITION=@RE_CODEREGIMEIMPOSITION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RE_CODEREGIMEIMPOSITION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
