using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypearticlecompteplancomptablemodelWSDAL: ITableDAL<clsPhapartypearticlecompteplancomptablemodel>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CP_CODEOPERATIONLIBELLECPTE) AS CP_CODEOPERATIONLIBELLECPTE  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CP_CODEOPERATIONLIBELLECPTE) AS CP_CODEOPERATIONLIBELLECPTE  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CP_CODEOPERATIONLIBELLECPTE) AS CP_CODEOPERATIONLIBELLECPTE  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypearticlecompteplancomptablemodel comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypearticlecompteplancomptablemodel pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TO_CODEOPERATIONPARAMETRE  , PL_CODENUMCOMPTE  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new clsPhapartypearticlecompteplancomptablemodel();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE = clsDonnee.vogDataReader["TO_CODEOPERATIONPARAMETRE"].ToString();
					clsPhapartypearticlecompteplancomptablemodel.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypearticlecompteplancomptablemodel;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticlecompteplancomptablemodel>clsPhapartypearticlecompteplancomptablemodel</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel)
		{
			//Préparation des paramètres
			SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 3);
			vppParamCP_CODEOPERATIONLIBELLECPTE.Value  = clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE ;
			SqlParameter vppParamTO_CODEOPERATIONPARAMETRE = new SqlParameter("@TO_CODEOPERATIONPARAMETRE", SqlDbType.VarChar, 4);
			vppParamTO_CODEOPERATIONPARAMETRE.Value  = clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhapartypearticlecompteplancomptablemodel.PL_CODENUMCOMPTE ;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTE.Value = clsPhapartypearticlecompteplancomptablemodel.PL_NUMCOMPTE;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL  @CP_CODEOPERATIONLIBELLECPTE, @TO_CODEOPERATIONPARAMETRE, @PL_CODENUMCOMPTE,@PL_NUMCOMPTE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATIONPARAMETRE);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);

			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticlecompteplancomptablemodel>clsPhapartypearticlecompteplancomptablemodel</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 3);
			vppParamCP_CODEOPERATIONLIBELLECPTE.Value  = clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE ;
			SqlParameter vppParamTO_CODEOPERATIONPARAMETRE = new SqlParameter("@TO_CODEOPERATIONPARAMETRE", SqlDbType.VarChar, 4);
			vppParamTO_CODEOPERATIONPARAMETRE.Value  = clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhapartypearticlecompteplancomptablemodel.PL_CODENUMCOMPTE ;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTE.Value = clsPhapartypearticlecompteplancomptablemodel.PL_NUMCOMPTE;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL  @CP_CODEOPERATIONLIBELLECPTE, @TO_CODEOPERATIONPARAMETRE, @PL_CODENUMCOMPTE,@PL_NUMCOMPTE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATIONPARAMETRE);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL  @CP_CODEOPERATIONLIBELLECPTE, @TO_CODEOPERATIONPARAMETRE, '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticlecompteplancomptablemodel </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticlecompteplancomptablemodel> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE, PL_CODENUMCOMPTE FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<clsPhapartypearticlecompteplancomptablemodel>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new clsPhapartypearticlecompteplancomptablemodel();
					clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE = clsDonnee.vogDataReader["CP_CODEOPERATIONLIBELLECPTE"].ToString();
					clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE = clsDonnee.vogDataReader["TO_CODEOPERATIONPARAMETRE"].ToString();
					clsPhapartypearticlecompteplancomptablemodel.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypearticlecompteplancomptablemodels;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticlecompteplancomptablemodel </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticlecompteplancomptablemodel> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<clsPhapartypearticlecompteplancomptablemodel>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE, PL_CODENUMCOMPTE FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new clsPhapartypearticlecompteplancomptablemodel();
					clsPhapartypearticlecompteplancomptablemodel.CP_CODEOPERATIONLIBELLECPTE = Dataset.Tables["TABLE"].Rows[Idx]["CP_CODEOPERATIONLIBELLECPTE"].ToString();
					clsPhapartypearticlecompteplancomptablemodel.TO_CODEOPERATIONPARAMETRE = Dataset.Tables["TABLE"].Rows[Idx]["TO_CODEOPERATIONPARAMETRE"].ToString();
					clsPhapartypearticlecompteplancomptablemodel.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
				}
				Dataset.Dispose();
			}
		return clsPhapartypearticlecompteplancomptablemodels;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CP_CODEOPERATIONLIBELLECPTE , PL_CODENUMCOMPTE FROM dbo.FT_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CP_CODEOPERATIONLIBELLECPTE, TO_CODEOPERATIONPARAMETRE)</summary>
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
				this.vapCritere ="WHERE CP_CODEOPERATIONLIBELLECPTE=@CP_CODEOPERATIONLIBELLECPTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CP_CODEOPERATIONLIBELLECPTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE CP_CODEOPERATIONLIBELLECPTE=@CP_CODEOPERATIONLIBELLECPTE AND TO_CODEOPERATIONPARAMETRE=@TO_CODEOPERATIONPARAMETRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CP_CODEOPERATIONLIBELLECPTE","@TO_CODEOPERATIONPARAMETRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
