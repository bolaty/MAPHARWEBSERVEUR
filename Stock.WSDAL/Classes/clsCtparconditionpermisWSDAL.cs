using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparconditionpermisWSDAL: ITableDAL<clsCtparconditionpermis>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CD_CODECONDITION) AS CD_CODECONDITION  FROM dbo.FT_CTPARCONDITIONPERMIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CD_CODECONDITION) AS CD_CODECONDITION  FROM dbo.FT_CTPARCONDITIONPERMIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CD_CODECONDITION) AS CD_CODECONDITION  FROM dbo.FT_CTPARCONDITIONPERMIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparconditionpermis comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparconditionpermis pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CD_LIBELLECONDITION  , CD_ACTIF  , CD_NUMEROORDRE  FROM dbo.FT_CTPARCONDITIONPERMIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparconditionpermis clsCtparconditionpermis = new clsCtparconditionpermis();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparconditionpermis.CD_LIBELLECONDITION = clsDonnee.vogDataReader["CD_LIBELLECONDITION"].ToString();
					clsCtparconditionpermis.CD_ACTIF = clsDonnee.vogDataReader["CD_ACTIF"].ToString();
					clsCtparconditionpermis.CD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CD_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparconditionpermis;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparconditionpermis>clsCtparconditionpermis</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparconditionpermis clsCtparconditionpermis)
		{
			//Préparation des paramètres
			SqlParameter vppParamCD_CODECONDITION = new SqlParameter("@CD_CODECONDITION", SqlDbType.VarChar, 2);
			vppParamCD_CODECONDITION.Value  = clsCtparconditionpermis.CD_CODECONDITION ;
			SqlParameter vppParamCD_LIBELLECONDITION = new SqlParameter("@CD_LIBELLECONDITION", SqlDbType.VarChar, 150);
			vppParamCD_LIBELLECONDITION.Value  = clsCtparconditionpermis.CD_LIBELLECONDITION ;
			SqlParameter vppParamCD_ACTIF = new SqlParameter("@CD_ACTIF", SqlDbType.VarChar, 1);
			vppParamCD_ACTIF.Value  = clsCtparconditionpermis.CD_ACTIF ;
			SqlParameter vppParamCD_NUMEROORDRE = new SqlParameter("@CD_NUMEROORDRE", SqlDbType.Int);
			vppParamCD_NUMEROORDRE.Value  = clsCtparconditionpermis.CD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCONDITIONPERMIS  @CD_CODECONDITION, @CD_LIBELLECONDITION, @CD_ACTIF, @CD_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCD_CODECONDITION);
			vppSqlCmd.Parameters.Add(vppParamCD_LIBELLECONDITION);
			vppSqlCmd.Parameters.Add(vppParamCD_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparconditionpermis>clsCtparconditionpermis</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparconditionpermis clsCtparconditionpermis,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCD_CODECONDITION = new SqlParameter("@CD_CODECONDITION", SqlDbType.VarChar, 2);
			vppParamCD_CODECONDITION.Value  = clsCtparconditionpermis.CD_CODECONDITION ;
			SqlParameter vppParamCD_LIBELLECONDITION = new SqlParameter("@CD_LIBELLECONDITION", SqlDbType.VarChar, 150);
			vppParamCD_LIBELLECONDITION.Value  = clsCtparconditionpermis.CD_LIBELLECONDITION ;
			SqlParameter vppParamCD_ACTIF = new SqlParameter("@CD_ACTIF", SqlDbType.VarChar, 1);
			vppParamCD_ACTIF.Value  = clsCtparconditionpermis.CD_ACTIF ;
			SqlParameter vppParamCD_NUMEROORDRE = new SqlParameter("@CD_NUMEROORDRE", SqlDbType.Int);
			vppParamCD_NUMEROORDRE.Value  = clsCtparconditionpermis.CD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCONDITIONPERMIS  @CD_CODECONDITION, @CD_LIBELLECONDITION, @CD_ACTIF, @CD_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCD_CODECONDITION);
			vppSqlCmd.Parameters.Add(vppParamCD_LIBELLECONDITION);
			vppSqlCmd.Parameters.Add(vppParamCD_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCONDITIONPERMIS  @CD_CODECONDITION, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparconditionpermis </returns>
		///<author>Home Technology</author>
		public List<clsCtparconditionpermis> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CD_CODECONDITION, CD_LIBELLECONDITION, CD_ACTIF, CD_NUMEROORDRE FROM dbo.FT_CTPARCONDITIONPERMIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparconditionpermis> clsCtparconditionpermiss = new List<clsCtparconditionpermis>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparconditionpermis clsCtparconditionpermis = new clsCtparconditionpermis();
					clsCtparconditionpermis.CD_CODECONDITION = clsDonnee.vogDataReader["CD_CODECONDITION"].ToString();
					clsCtparconditionpermis.CD_LIBELLECONDITION = clsDonnee.vogDataReader["CD_LIBELLECONDITION"].ToString();
					clsCtparconditionpermis.CD_ACTIF = clsDonnee.vogDataReader["CD_ACTIF"].ToString();
					clsCtparconditionpermis.CD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CD_NUMEROORDRE"].ToString());
					clsCtparconditionpermiss.Add(clsCtparconditionpermis);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparconditionpermiss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparconditionpermis </returns>
		///<author>Home Technology</author>
		public List<clsCtparconditionpermis> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparconditionpermis> clsCtparconditionpermiss = new List<clsCtparconditionpermis>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CD_CODECONDITION, CD_LIBELLECONDITION, CD_ACTIF, CD_NUMEROORDRE FROM dbo.FT_CTPARCONDITIONPERMIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparconditionpermis clsCtparconditionpermis = new clsCtparconditionpermis();
					clsCtparconditionpermis.CD_CODECONDITION = Dataset.Tables["TABLE"].Rows[Idx]["CD_CODECONDITION"].ToString();
					clsCtparconditionpermis.CD_LIBELLECONDITION = Dataset.Tables["TABLE"].Rows[Idx]["CD_LIBELLECONDITION"].ToString();
					clsCtparconditionpermis.CD_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["CD_ACTIF"].ToString();
					clsCtparconditionpermis.CD_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CD_NUMEROORDRE"].ToString());
					clsCtparconditionpermiss.Add(clsCtparconditionpermis);
				}
				Dataset.Dispose();
			}
		return clsCtparconditionpermiss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARCONDITIONPERMIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CD_CODECONDITION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CD_CODECONDITION , CD_LIBELLECONDITION FROM dbo.FT_CTPARCONDITIONPERMIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CD_CODECONDITION)</summary>
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
				this.vapCritere ="WHERE CD_CODECONDITION=@CD_CODECONDITION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CD_CODECONDITION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
