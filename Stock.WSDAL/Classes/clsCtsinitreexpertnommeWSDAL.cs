using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtsinitreexpertnommeWSDAL: ITableDAL<clsCtsinitreexpertnomme>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(EP_CODEEXPERTNOMME) AS EP_CODEEXPERTNOMME  FROM dbo.FT_CTSINITREEXPERTNOMME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(EP_CODEEXPERTNOMME) AS EP_CODEEXPERTNOMME  FROM dbo.FT_CTSINITREEXPERTNOMME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(EP_CODEEXPERTNOMME) AS EP_CODEEXPERTNOMME  FROM dbo.FT_CTSINITREEXPERTNOMME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtsinitreexpertnomme comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtsinitreexpertnomme pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EP_DENOMMINATIONEXPERTNOMME  , EP_CONTACTEXPERTNOMME  , EP_DATESAISIE  , OP_CODEOPERATEUR  FROM dbo.FT_CTSINITREEXPERTNOMME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new clsCtsinitreexpertnomme();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME = clsDonnee.vogDataReader["EP_DENOMMINATIONEXPERTNOMME"].ToString();
					clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME = clsDonnee.vogDataReader["EP_CONTACTEXPERTNOMME"].ToString();
					clsCtsinitreexpertnomme.EP_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["EP_DATESAISIE"].ToString());
					clsCtsinitreexpertnomme.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtsinitreexpertnomme;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinitreexpertnomme>clsCtsinitreexpertnomme</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtsinitreexpertnomme clsCtsinitreexpertnomme)
		{
			//Préparation des paramètres
			SqlParameter vppParamEP_CODEEXPERTNOMME = new SqlParameter("@EP_CODEEXPERTNOMME", SqlDbType.VarChar, 50);
			vppParamEP_CODEEXPERTNOMME.Value  = clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME ;
			SqlParameter vppParamEP_DENOMMINATIONEXPERTNOMME = new SqlParameter("@EP_DENOMMINATIONEXPERTNOMME", SqlDbType.VarChar, 1000);
			vppParamEP_DENOMMINATIONEXPERTNOMME.Value  = clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME ;
			SqlParameter vppParamEP_CONTACTEXPERTNOMME = new SqlParameter("@EP_CONTACTEXPERTNOMME", SqlDbType.VarChar, 1000);
			vppParamEP_CONTACTEXPERTNOMME.Value  = clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME ;
			SqlParameter vppParamEP_DATESAISIE = new SqlParameter("@EP_DATESAISIE", SqlDbType.DateTime);
			vppParamEP_DATESAISIE.Value  = clsCtsinitreexpertnomme.EP_DATESAISIE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinitreexpertnomme.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINITREEXPERTNOMME  @EP_CODEEXPERTNOMME, @EP_DENOMMINATIONEXPERTNOMME, @EP_CONTACTEXPERTNOMME, @EP_DATESAISIE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEP_CODEEXPERTNOMME);
			vppSqlCmd.Parameters.Add(vppParamEP_DENOMMINATIONEXPERTNOMME);
			vppSqlCmd.Parameters.Add(vppParamEP_CONTACTEXPERTNOMME);
			vppSqlCmd.Parameters.Add(vppParamEP_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinitreexpertnomme>clsCtsinitreexpertnomme</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtsinitreexpertnomme clsCtsinitreexpertnomme,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamEP_CODEEXPERTNOMME = new SqlParameter("@EP_CODEEXPERTNOMME", SqlDbType.VarChar, 50);
			vppParamEP_CODEEXPERTNOMME.Value  = clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME ;
			SqlParameter vppParamEP_DENOMMINATIONEXPERTNOMME = new SqlParameter("@EP_DENOMMINATIONEXPERTNOMME", SqlDbType.VarChar, 1000);
			vppParamEP_DENOMMINATIONEXPERTNOMME.Value  = clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME ;
			SqlParameter vppParamEP_CONTACTEXPERTNOMME = new SqlParameter("@EP_CONTACTEXPERTNOMME", SqlDbType.VarChar, 1000);
			vppParamEP_CONTACTEXPERTNOMME.Value  = clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME ;
			SqlParameter vppParamEP_DATESAISIE = new SqlParameter("@EP_DATESAISIE", SqlDbType.DateTime);
			vppParamEP_DATESAISIE.Value  = clsCtsinitreexpertnomme.EP_DATESAISIE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinitreexpertnomme.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINITREEXPERTNOMME  @EP_CODEEXPERTNOMME, @EP_DENOMMINATIONEXPERTNOMME, @EP_CONTACTEXPERTNOMME, @EP_DATESAISIE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEP_CODEEXPERTNOMME);
			vppSqlCmd.Parameters.Add(vppParamEP_DENOMMINATIONEXPERTNOMME);
			vppSqlCmd.Parameters.Add(vppParamEP_CONTACTEXPERTNOMME);
			vppSqlCmd.Parameters.Add(vppParamEP_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINITREEXPERTNOMME  @EP_CODEEXPERTNOMME, '' , '' , '' , '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinitreexpertnomme </returns>
		///<author>Home Technology</author>
		public List<clsCtsinitreexpertnomme> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EP_CODEEXPERTNOMME, EP_DENOMMINATIONEXPERTNOMME, EP_CONTACTEXPERTNOMME, EP_DATESAISIE, OP_CODEOPERATEUR FROM dbo.FT_CTSINITREEXPERTNOMME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<clsCtsinitreexpertnomme>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new clsCtsinitreexpertnomme();
					clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME = clsDonnee.vogDataReader["EP_CODEEXPERTNOMME"].ToString();
					clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME = clsDonnee.vogDataReader["EP_DENOMMINATIONEXPERTNOMME"].ToString();
					clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME = clsDonnee.vogDataReader["EP_CONTACTEXPERTNOMME"].ToString();
					clsCtsinitreexpertnomme.EP_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["EP_DATESAISIE"].ToString());
					clsCtsinitreexpertnomme.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtsinitreexpertnommes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinitreexpertnomme </returns>
		///<author>Home Technology</author>
		public List<clsCtsinitreexpertnomme> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<clsCtsinitreexpertnomme>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EP_CODEEXPERTNOMME, EP_DENOMMINATIONEXPERTNOMME, EP_CONTACTEXPERTNOMME, EP_DATESAISIE, OP_CODEOPERATEUR FROM dbo.FT_CTSINITREEXPERTNOMME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new clsCtsinitreexpertnomme();
					clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME = Dataset.Tables["TABLE"].Rows[Idx]["EP_CODEEXPERTNOMME"].ToString();
					clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME = Dataset.Tables["TABLE"].Rows[Idx]["EP_DENOMMINATIONEXPERTNOMME"].ToString();
					clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME = Dataset.Tables["TABLE"].Rows[Idx]["EP_CONTACTEXPERTNOMME"].ToString();
					clsCtsinitreexpertnomme.EP_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EP_DATESAISIE"].ToString());
					clsCtsinitreexpertnomme.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
				}
				Dataset.Dispose();
			}
		return clsCtsinitreexpertnommes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTSINITREEXPERTNOMME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EP_CODEEXPERTNOMME, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EP_CODEEXPERTNOMME , EP_DENOMMINATIONEXPERTNOMME FROM dbo.FT_CTSINITREEXPERTNOMME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :EP_CODEEXPERTNOMME, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE EP_CODEEXPERTNOMME=@EP_CODEEXPERTNOMME";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@EP_CODEEXPERTNOMME"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE EP_CODEEXPERTNOMME=@EP_CODEEXPERTNOMME AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@EP_CODEEXPERTNOMME","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
