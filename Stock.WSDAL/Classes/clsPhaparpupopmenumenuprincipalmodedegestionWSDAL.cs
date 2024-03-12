using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpupopmenumenuprincipalmodedegestionWSDAL: ITableDAL<clsPhaparpupopmenumenuprincipalmodedegestion>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MG_CODEMODEGESTION) AS MG_CODEMODEGESTION  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpupopmenumenuprincipalmodedegestion comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpupopmenumenuprincipalmodedegestion pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT OG_ACTIF  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpupopmenumenuprincipalmodedegestion clsPhaparpupopmenumenuprincipalmodedegestion = new clsPhaparpupopmenumenuprincipalmodedegestion();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenumenuprincipalmodedegestion.OG_ACTIF = clsDonnee.vogDataReader["OG_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpupopmenumenuprincipalmodedegestion;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenumenuprincipalmodedegestion>clsPhaparpupopmenumenuprincipalmodedegestion</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpupopmenumenuprincipalmodedegestion clsPhaparpupopmenumenuprincipalmodedegestion)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparpupopmenumenuprincipalmodedegestion.MG_CODEMODEGESTION ;
			SqlParameter vppParamMP_CODEMENU = new SqlParameter("@MP_CODEMENU", SqlDbType.Int);
			vppParamMP_CODEMENU.Value  = clsPhaparpupopmenumenuprincipalmodedegestion.MP_CODEMENU ;
			SqlParameter vppParamOG_ACTIF = new SqlParameter("@OG_ACTIF", SqlDbType.VarChar, 1);
			vppParamOG_ACTIF.Value  = clsPhaparpupopmenumenuprincipalmodedegestion.OG_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION  @MG_CODEMODEGESTION, @MP_CODEMENU, @OG_ACTIF, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamMP_CODEMENU);
			vppSqlCmd.Parameters.Add(vppParamOG_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpupopmenumenuprincipalmodedegestion>clsPhaparpupopmenumenuprincipalmodedegestion</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpupopmenumenuprincipalmodedegestion clsPhaparpupopmenumenuprincipalmodedegestion,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMG_CODEMODEGESTION = new SqlParameter("@MG_CODEMODEGESTION", SqlDbType.VarChar, 2);
			vppParamMG_CODEMODEGESTION.Value  = clsPhaparpupopmenumenuprincipalmodedegestion.MG_CODEMODEGESTION ;
			SqlParameter vppParamMP_CODEMENU = new SqlParameter("@MP_CODEMENU", SqlDbType.Int);
			vppParamMP_CODEMENU.Value  = clsPhaparpupopmenumenuprincipalmodedegestion.MP_CODEMENU ;
			SqlParameter vppParamOG_ACTIF = new SqlParameter("@OG_ACTIF", SqlDbType.VarChar, 1);
			vppParamOG_ACTIF.Value  = clsPhaparpupopmenumenuprincipalmodedegestion.OG_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION  @MG_CODEMODEGESTION, @MP_CODEMENU, @OG_ACTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMG_CODEMODEGESTION);
			vppSqlCmd.Parameters.Add(vppParamMP_CODEMENU);
			vppSqlCmd.Parameters.Add(vppParamOG_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION  @MG_CODEMODEGESTION, @MP_CODEMENU, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenumenuprincipalmodedegestion </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenumenuprincipalmodedegestion> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, MP_CODEMENU, OG_ACTIF FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpupopmenumenuprincipalmodedegestion> clsPhaparpupopmenumenuprincipalmodedegestions = new List<clsPhaparpupopmenumenuprincipalmodedegestion>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpupopmenumenuprincipalmodedegestion clsPhaparpupopmenumenuprincipalmodedegestion = new clsPhaparpupopmenumenuprincipalmodedegestion();
					clsPhaparpupopmenumenuprincipalmodedegestion.MG_CODEMODEGESTION = clsDonnee.vogDataReader["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumenuprincipalmodedegestion.MP_CODEMENU = int.Parse(clsDonnee.vogDataReader["MP_CODEMENU"].ToString());
					clsPhaparpupopmenumenuprincipalmodedegestion.OG_ACTIF = clsDonnee.vogDataReader["OG_ACTIF"].ToString();
					clsPhaparpupopmenumenuprincipalmodedegestions.Add(clsPhaparpupopmenumenuprincipalmodedegestion);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpupopmenumenuprincipalmodedegestions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpupopmenumenuprincipalmodedegestion </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpupopmenumenuprincipalmodedegestion> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpupopmenumenuprincipalmodedegestion> clsPhaparpupopmenumenuprincipalmodedegestions = new List<clsPhaparpupopmenumenuprincipalmodedegestion>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MG_CODEMODEGESTION, MP_CODEMENU, OG_ACTIF FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpupopmenumenuprincipalmodedegestion clsPhaparpupopmenumenuprincipalmodedegestion = new clsPhaparpupopmenumenuprincipalmodedegestion();
					clsPhaparpupopmenumenuprincipalmodedegestion.MG_CODEMODEGESTION = Dataset.Tables["TABLE"].Rows[Idx]["MG_CODEMODEGESTION"].ToString();
					clsPhaparpupopmenumenuprincipalmodedegestion.MP_CODEMENU = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MP_CODEMENU"].ToString());
					clsPhaparpupopmenumenuprincipalmodedegestion.OG_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["OG_ACTIF"].ToString();
					clsPhaparpupopmenumenuprincipalmodedegestions.Add(clsPhaparpupopmenumenuprincipalmodedegestion);
				}
				Dataset.Dispose();
			}
		return clsPhaparpupopmenumenuprincipalmodedegestions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MG_CODEMODEGESTION, MP_CODEMENU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MG_CODEMODEGESTION , OG_ACTIF FROM dbo.FT_PHAPARPUPOPMENUMENUPRINCIPALMODEDEGESTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MG_CODEMODEGESTION, MP_CODEMENU)</summary>
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
				this.vapCritere ="WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MG_CODEMODEGESTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE MG_CODEMODEGESTION=@MG_CODEMODEGESTION AND MP_CODEMENU=@MP_CODEMENU";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MG_CODEMODEGESTION","@MP_CODEMENU"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
