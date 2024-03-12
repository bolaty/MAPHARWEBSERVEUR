using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsMouvementcomptableanalytiqueWSDAL: ITableDAL<clsMouvementcomptableanalytique>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_MOUVEMENTCOMPTABLEANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_MOUVEMENTCOMPTABLEANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_MOUVEMENTCOMPTABLEANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMouvementcomptableanalytique comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMouvementcomptableanalytique pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MA_MONTANT  FROM dbo.FT_MOUVEMENTCOMPTABLEANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsMouvementcomptableanalytique clsMouvementcomptableanalytique = new clsMouvementcomptableanalytique();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMouvementcomptableanalytique.MA_MONTANT = double.Parse(clsDonnee.vogDataReader["MA_MONTANT"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsMouvementcomptableanalytique;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMouvementcomptableanalytique>clsMouvementcomptableanalytique</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMouvementcomptableanalytique clsMouvementcomptableanalytique)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsMouvementcomptableanalytique.AG_CODEAGENCE ;
			SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
			vppParamMC_DATEPIECE.Value  = clsMouvementcomptableanalytique.MC_DATEPIECE ;
			SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 25);
			vppParamMC_NUMPIECE.Value  = clsMouvementcomptableanalytique.MC_NUMPIECE ;
			SqlParameter vppParamMC_NUMSEQUENCE = new SqlParameter("@MC_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamMC_NUMSEQUENCE.Value  = clsMouvementcomptableanalytique.MC_NUMSEQUENCE ;
			SqlParameter vppParamAF_CODE = new SqlParameter("@AF_CODE", SqlDbType.VarChar, 25);
			vppParamAF_CODE.Value  = clsMouvementcomptableanalytique.AF_CODE ;
			SqlParameter vppParamPLAN_ANALYTIQUE_CODE = new SqlParameter("@PLAN_ANALYTIQUE_CODE", SqlDbType.Decimal, 4);
			vppParamPLAN_ANALYTIQUE_CODE.Value  = clsMouvementcomptableanalytique.PLAN_ANALYTIQUE_CODE ;
			SqlParameter vppParamMA_MONTANT = new SqlParameter("@MA_MONTANT", SqlDbType.Money);
			vppParamMA_MONTANT.Value  = clsMouvementcomptableanalytique.MA_MONTANT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MOUVEMENTCOMPTABLEANALYTIQUE  @AG_CODEAGENCE, @MC_DATEPIECE, @MC_NUMPIECE, @MC_NUMSEQUENCE, @AF_CODE, @PLAN_ANALYTIQUE_CODE, @MA_MONTANT, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAF_CODE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_CODE);
			vppSqlCmd.Parameters.Add(vppParamMA_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMouvementcomptableanalytique>clsMouvementcomptableanalytique</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMouvementcomptableanalytique clsMouvementcomptableanalytique,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsMouvementcomptableanalytique.AG_CODEAGENCE ;
			SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
			vppParamMC_DATEPIECE.Value  = clsMouvementcomptableanalytique.MC_DATEPIECE ;
			SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 25);
			vppParamMC_NUMPIECE.Value  = clsMouvementcomptableanalytique.MC_NUMPIECE ;
			SqlParameter vppParamMC_NUMSEQUENCE = new SqlParameter("@MC_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamMC_NUMSEQUENCE.Value  = clsMouvementcomptableanalytique.MC_NUMSEQUENCE ;
			SqlParameter vppParamAF_CODE = new SqlParameter("@AF_CODE", SqlDbType.VarChar, 25);
			vppParamAF_CODE.Value  = clsMouvementcomptableanalytique.AF_CODE ;
			SqlParameter vppParamPLAN_ANALYTIQUE_CODE = new SqlParameter("@PLAN_ANALYTIQUE_CODE", SqlDbType.Decimal, 4);
			vppParamPLAN_ANALYTIQUE_CODE.Value  = clsMouvementcomptableanalytique.PLAN_ANALYTIQUE_CODE ;
			SqlParameter vppParamMA_MONTANT = new SqlParameter("@MA_MONTANT", SqlDbType.Money);
			vppParamMA_MONTANT.Value  = clsMouvementcomptableanalytique.MA_MONTANT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MOUVEMENTCOMPTABLEANALYTIQUE  @AG_CODEAGENCE, @MC_DATEPIECE, @MC_NUMPIECE, @MC_NUMSEQUENCE, @AF_CODE, @PLAN_ANALYTIQUE_CODE, @MA_MONTANT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAF_CODE);
			vppSqlCmd.Parameters.Add(vppParamPLAN_ANALYTIQUE_CODE);
			vppSqlCmd.Parameters.Add(vppParamMA_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MOUVEMENTCOMPTABLEANALYTIQUE  @AG_CODEAGENCE, @MC_DATEPIECE, @MC_NUMPIECE, @MC_NUMSEQUENCE, @AF_CODE, @PLAN_ANALYTIQUE_CODE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMouvementcomptableanalytique </returns>
		///<author>Home Technology</author>
		public List<clsMouvementcomptableanalytique> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE, MA_MONTANT FROM dbo.FT_MOUVEMENTCOMPTABLEANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsMouvementcomptableanalytique> clsMouvementcomptableanalytiques = new List<clsMouvementcomptableanalytique>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMouvementcomptableanalytique clsMouvementcomptableanalytique = new clsMouvementcomptableanalytique();
					clsMouvementcomptableanalytique.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsMouvementcomptableanalytique.MC_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MC_DATEPIECE"].ToString());
					clsMouvementcomptableanalytique.MC_NUMPIECE = clsDonnee.vogDataReader["MC_NUMPIECE"].ToString();
					clsMouvementcomptableanalytique.MC_NUMSEQUENCE = clsDonnee.vogDataReader["MC_NUMSEQUENCE"].ToString();
					clsMouvementcomptableanalytique.AF_CODE = clsDonnee.vogDataReader["AF_CODE"].ToString();
					clsMouvementcomptableanalytique.PLAN_ANALYTIQUE_CODE = clsDonnee.vogDataReader["PLAN_ANALYTIQUE_CODE"].ToString();
					clsMouvementcomptableanalytique.MA_MONTANT = double.Parse(clsDonnee.vogDataReader["MA_MONTANT"].ToString());
					clsMouvementcomptableanalytiques.Add(clsMouvementcomptableanalytique);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsMouvementcomptableanalytiques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMouvementcomptableanalytique </returns>
		///<author>Home Technology</author>
		public List<clsMouvementcomptableanalytique> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsMouvementcomptableanalytique> clsMouvementcomptableanalytiques = new List<clsMouvementcomptableanalytique>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE, MA_MONTANT FROM dbo.FT_MOUVEMENTCOMPTABLEANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsMouvementcomptableanalytique clsMouvementcomptableanalytique = new clsMouvementcomptableanalytique();
					clsMouvementcomptableanalytique.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsMouvementcomptableanalytique.MC_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_DATEPIECE"].ToString());
					clsMouvementcomptableanalytique.MC_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MC_NUMPIECE"].ToString();
					clsMouvementcomptableanalytique.MC_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["MC_NUMSEQUENCE"].ToString();
					clsMouvementcomptableanalytique.AF_CODE = Dataset.Tables["TABLE"].Rows[Idx]["AF_CODE"].ToString();
					clsMouvementcomptableanalytique.PLAN_ANALYTIQUE_CODE = Dataset.Tables["TABLE"].Rows[Idx]["PLAN_ANALYTIQUE_CODE"].ToString();
					clsMouvementcomptableanalytique.MA_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MA_MONTANT"].ToString());
					clsMouvementcomptableanalytiques.Add(clsMouvementcomptableanalytique);
				}
				Dataset.Dispose();
			}
		return clsMouvementcomptableanalytiques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_MOUVEMENTCOMPTABLEANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , MA_MONTANT FROM dbo.FT_MOUVEMENTCOMPTABLEANALYTIQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, AF_CODE, PLAN_ANALYTIQUE_CODE)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MC_DATEPIECE=@MC_DATEPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MC_DATEPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MC_DATEPIECE=@MC_DATEPIECE AND MC_NUMPIECE=@MC_NUMPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MC_DATEPIECE","@MC_NUMPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MC_DATEPIECE=@MC_DATEPIECE AND MC_NUMPIECE=@MC_NUMPIECE AND MC_NUMSEQUENCE=@MC_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MC_DATEPIECE","@MC_NUMPIECE","@MC_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MC_DATEPIECE=@MC_DATEPIECE AND MC_NUMPIECE=@MC_NUMPIECE AND MC_NUMSEQUENCE=@MC_NUMSEQUENCE AND AF_CODE=@AF_CODE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MC_DATEPIECE","@MC_NUMPIECE","@MC_NUMSEQUENCE","@AF_CODE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MC_DATEPIECE=@MC_DATEPIECE AND MC_NUMPIECE=@MC_NUMPIECE AND MC_NUMSEQUENCE=@MC_NUMSEQUENCE AND AF_CODE=@AF_CODE AND PLAN_ANALYTIQUE_CODE=@PLAN_ANALYTIQUE_CODE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MC_DATEPIECE","@MC_NUMPIECE","@MC_NUMSEQUENCE","@AF_CODE","@PLAN_ANALYTIQUE_CODE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
