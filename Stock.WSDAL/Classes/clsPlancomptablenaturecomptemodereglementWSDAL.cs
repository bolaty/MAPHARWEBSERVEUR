using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPlancomptablenaturecomptemodereglementWSDAL: ITableDAL<clsPlancomptablenaturecomptemodereglement>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MR_CODEMODEREGLEMENT) AS MR_CODEMODEREGLEMENT  FROM dbo.FT_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MR_CODEMODEREGLEMENT) AS MR_CODEMODEREGLEMENT  FROM dbo.FT_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MR_CODEMODEREGLEMENT) AS MR_CODEMODEREGLEMENT  FROM dbo.FT_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPlancomptablenaturecomptemodereglement comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPlancomptablenaturecomptemodereglement pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NC_CODENATURECOMPTE  FROM dbo.FT_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new clsPlancomptablenaturecomptemodereglement();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE = clsDonnee.vogDataReader["NC_CODENATURECOMPTE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPlancomptablenaturecomptemodereglement;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlancomptablenaturecomptemodereglement>clsPlancomptablenaturecomptemodereglement</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement)
		{
			//Préparation des paramètres
			SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
			vppParamMR_CODEMODEREGLEMENT.Value  = clsPlancomptablenaturecomptemodereglement.MR_CODEMODEREGLEMENT ;
			SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 2);
			vppParamNC_CODENATURECOMPTE.Value  = clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT  @MR_CODEMODEREGLEMENT, @NC_CODENATURECOMPTE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlancomptablenaturecomptemodereglement>clsPlancomptablenaturecomptemodereglement</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
			vppParamMR_CODEMODEREGLEMENT.Value  = clsPlancomptablenaturecomptemodereglement.MR_CODEMODEREGLEMENT ;
			SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 2);
			vppParamNC_CODENATURECOMPTE.Value  = clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT  @MR_CODEMODEREGLEMENT, @NC_CODENATURECOMPTE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT  @MR_CODEMODEREGLEMENT, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlancomptablenaturecomptemodereglement </returns>
		///<author>Home Technology</author>
		public List<clsPlancomptablenaturecomptemodereglement> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MR_CODEMODEREGLEMENT, NC_CODENATURECOMPTE FROM dbo.FT_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<clsPlancomptablenaturecomptemodereglement>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new clsPlancomptablenaturecomptemodereglement();
					clsPlancomptablenaturecomptemodereglement.MR_CODEMODEREGLEMENT = clsDonnee.vogDataReader["MR_CODEMODEREGLEMENT"].ToString();
					clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE = clsDonnee.vogDataReader["NC_CODENATURECOMPTE"].ToString();
					clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlancomptablenaturecomptemodereglements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlancomptablenaturecomptemodereglement </returns>
		///<author>Home Technology</author>
		public List<clsPlancomptablenaturecomptemodereglement> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<clsPlancomptablenaturecomptemodereglement>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MR_CODEMODEREGLEMENT, NC_CODENATURECOMPTE FROM dbo.FT_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new clsPlancomptablenaturecomptemodereglement();
					clsPlancomptablenaturecomptemodereglement.MR_CODEMODEREGLEMENT = Dataset.Tables["TABLE"].Rows[Idx]["MR_CODEMODEREGLEMENT"].ToString();
					clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["NC_CODENATURECOMPTE"].ToString();
					clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
				}
				Dataset.Dispose();
			}
		return clsPlancomptablenaturecomptemodereglements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MR_CODEMODEREGLEMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  NC_CODENATURECOMPTE,NC_LIBELLENATURECOMPTE FROM dbo.FT_PLANCOMPTABLENATURECOMPTEMODEREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MR_CODEMODEREGLEMENT)</summary>
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
				this.vapCritere ="WHERE MR_CODEMODEREGLEMENT=@MR_CODEMODEREGLEMENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MR_CODEMODEREGLEMENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
