using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBusinessplanparampostenatureWSDAL: ITableDAL<clsBusinessplanparampostenature>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PN_CODENATUREPOSTEBUSINESSPLAN) AS PN_CODENATUREPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PN_CODENATUREPOSTEBUSINESSPLAN) AS PN_CODENATUREPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PN_CODENATUREPOSTEBUSINESSPLAN) AS PN_CODENATUREPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBusinessplanparampostenature comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBusinessplanparampostenature pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PN_LIBELLE  , PN_NUMEROORDRE  FROM dbo.FT_BUSINESSPLANPARAMPOSTENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBusinessplanparampostenature clsBusinessplanparampostenature = new clsBusinessplanparampostenature();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparampostenature.PN_LIBELLE = clsDonnee.vogDataReader["PN_LIBELLE"].ToString();
					clsBusinessplanparampostenature.PN_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PN_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBusinessplanparampostenature;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparampostenature>clsBusinessplanparampostenature</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBusinessplanparampostenature clsBusinessplanparampostenature)
		{
			//Préparation des paramètres
			SqlParameter vppParamPN_CODENATUREPOSTEBUSINESSPLAN = new SqlParameter("@PN_CODENATUREPOSTEBUSINESSPLAN", SqlDbType.VarChar, 3);
			vppParamPN_CODENATUREPOSTEBUSINESSPLAN.Value  = clsBusinessplanparampostenature.PN_CODENATUREPOSTEBUSINESSPLAN ;
			SqlParameter vppParamPN_LIBELLE = new SqlParameter("@PN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPN_LIBELLE.Value  = clsBusinessplanparampostenature.PN_LIBELLE ;
			SqlParameter vppParamPN_NUMEROORDRE = new SqlParameter("@PN_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamPN_NUMEROORDRE.Value  = clsBusinessplanparampostenature.PN_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTENATURE  @PN_CODENATUREPOSTEBUSINESSPLAN, @PN_LIBELLE, @PN_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPN_CODENATUREPOSTEBUSINESSPLAN);
			vppSqlCmd.Parameters.Add(vppParamPN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPN_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparampostenature>clsBusinessplanparampostenature</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBusinessplanparampostenature clsBusinessplanparampostenature,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPN_CODENATUREPOSTEBUSINESSPLAN = new SqlParameter("@PN_CODENATUREPOSTEBUSINESSPLAN", SqlDbType.VarChar, 3);
			vppParamPN_CODENATUREPOSTEBUSINESSPLAN.Value  = clsBusinessplanparampostenature.PN_CODENATUREPOSTEBUSINESSPLAN ;
			SqlParameter vppParamPN_LIBELLE = new SqlParameter("@PN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPN_LIBELLE.Value  = clsBusinessplanparampostenature.PN_LIBELLE ;
			SqlParameter vppParamPN_NUMEROORDRE = new SqlParameter("@PN_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamPN_NUMEROORDRE.Value  = clsBusinessplanparampostenature.PN_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTENATURE  @PN_CODENATUREPOSTEBUSINESSPLAN, @PN_LIBELLE, @PN_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPN_CODENATUREPOSTEBUSINESSPLAN);
			vppSqlCmd.Parameters.Add(vppParamPN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPN_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTENATURE  @PN_CODENATUREPOSTEBUSINESSPLAN, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparampostenature </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparampostenature> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PN_CODENATUREPOSTEBUSINESSPLAN, PN_LIBELLE, PN_NUMEROORDRE FROM dbo.FT_BUSINESSPLANPARAMPOSTENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBusinessplanparampostenature> clsBusinessplanparampostenatures = new List<clsBusinessplanparampostenature>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparampostenature clsBusinessplanparampostenature = new clsBusinessplanparampostenature();
					clsBusinessplanparampostenature.PN_CODENATUREPOSTEBUSINESSPLAN = clsDonnee.vogDataReader["PN_CODENATUREPOSTEBUSINESSPLAN"].ToString();
					clsBusinessplanparampostenature.PN_LIBELLE = clsDonnee.vogDataReader["PN_LIBELLE"].ToString();
					clsBusinessplanparampostenature.PN_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PN_NUMEROORDRE"].ToString());
					clsBusinessplanparampostenatures.Add(clsBusinessplanparampostenature);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBusinessplanparampostenatures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparampostenature </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparampostenature> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBusinessplanparampostenature> clsBusinessplanparampostenatures = new List<clsBusinessplanparampostenature>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PN_CODENATUREPOSTEBUSINESSPLAN, PN_LIBELLE, PN_NUMEROORDRE FROM dbo.FT_BUSINESSPLANPARAMPOSTENATURE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBusinessplanparampostenature clsBusinessplanparampostenature = new clsBusinessplanparampostenature();
					clsBusinessplanparampostenature.PN_CODENATUREPOSTEBUSINESSPLAN = Dataset.Tables["TABLE"].Rows[Idx]["PN_CODENATUREPOSTEBUSINESSPLAN"].ToString();
					clsBusinessplanparampostenature.PN_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PN_LIBELLE"].ToString();
					clsBusinessplanparampostenature.PN_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PN_NUMEROORDRE"].ToString());
					clsBusinessplanparampostenatures.Add(clsBusinessplanparampostenature);
				}
				Dataset.Dispose();
			}
		return clsBusinessplanparampostenatures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BUSINESSPLANPARAMPOSTENATURE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY PN_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PN_CODENATUREPOSTEBUSINESSPLAN ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PN_CODENATUREPOSTEBUSINESSPLAN , PN_LIBELLE FROM dbo.FT_BUSINESSPLANPARAMPOSTENATURE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY PN_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PN_CODENATUREPOSTEBUSINESSPLAN)</summary>
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
				this.vapCritere ="WHERE PN_CODENATUREPOSTEBUSINESSPLAN=@PN_CODENATUREPOSTEBUSINESSPLAN";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PN_CODENATUREPOSTEBUSINESSPLAN"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
