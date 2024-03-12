using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliassuranceproduitWSDAL: ITableDAL<clsCliassuranceproduit>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AP_CODEPRODUIT) AS AP_CODEPRODUIT  FROM dbo.FT_CLIASSURANCEPRODUIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AP_CODEPRODUIT) AS AP_CODEPRODUIT  FROM dbo.FT_CLIASSURANCEPRODUIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AP_CODEPRODUIT) AS AP_CODEPRODUIT  FROM dbo.FT_CLIASSURANCEPRODUIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliassuranceproduit comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliassuranceproduit pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , TI_IDTIERS  , AP_LIBELLEPRODUIT  , AP_PLAFONDPRODUIT  FROM dbo.FT_CLIASSURANCEPRODUIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliassuranceproduit clsCliassuranceproduit = new clsCliassuranceproduit();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliassuranceproduit.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliassuranceproduit.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsCliassuranceproduit.AP_LIBELLEPRODUIT = clsDonnee.vogDataReader["AP_LIBELLEPRODUIT"].ToString();
					clsCliassuranceproduit.AP_PLAFONDPRODUIT = double.Parse(clsDonnee.vogDataReader["AP_PLAFONDPRODUIT"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliassuranceproduit;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliassuranceproduit>clsCliassuranceproduit</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliassuranceproduit clsCliassuranceproduit)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliassuranceproduit.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS1", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsCliassuranceproduit.TI_IDTIERS ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT1", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsCliassuranceproduit.AP_CODEPRODUIT ;
			SqlParameter vppParamAP_LIBELLEPRODUIT = new SqlParameter("@AP_LIBELLEPRODUIT", SqlDbType.VarChar, 150);
			vppParamAP_LIBELLEPRODUIT.Value  = clsCliassuranceproduit.AP_LIBELLEPRODUIT ;
			SqlParameter vppParamAP_PLAFONDPRODUIT = new SqlParameter("@AP_PLAFONDPRODUIT", SqlDbType.Money);
			vppParamAP_PLAFONDPRODUIT.Value  = clsCliassuranceproduit.AP_PLAFONDPRODUIT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIASSURANCEPRODUIT  @AG_CODEAGENCE1, @TI_IDTIERS1, @AP_CODEPRODUIT1, @AP_LIBELLEPRODUIT, @AP_PLAFONDPRODUIT, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamAP_LIBELLEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamAP_PLAFONDPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliassuranceproduit>clsCliassuranceproduit</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliassuranceproduit clsCliassuranceproduit,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliassuranceproduit.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsCliassuranceproduit.TI_IDTIERS ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsCliassuranceproduit.AP_CODEPRODUIT ;
			SqlParameter vppParamAP_LIBELLEPRODUIT = new SqlParameter("@AP_LIBELLEPRODUIT", SqlDbType.VarChar, 150);
			vppParamAP_LIBELLEPRODUIT.Value  = clsCliassuranceproduit.AP_LIBELLEPRODUIT ;
			SqlParameter vppParamAP_PLAFONDPRODUIT = new SqlParameter("@AP_PLAFONDPRODUIT", SqlDbType.Money);
			vppParamAP_PLAFONDPRODUIT.Value  = clsCliassuranceproduit.AP_PLAFONDPRODUIT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIASSURANCEPRODUIT  @AG_CODEAGENCE, @TI_IDTIERS, @AP_CODEPRODUIT, @AP_LIBELLEPRODUIT, @AP_PLAFONDPRODUIT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamAP_LIBELLEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamAP_PLAFONDPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIASSURANCEPRODUIT  @AG_CODEAGENCE, '' , @AP_CODEPRODUIT, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliassuranceproduit </returns>
		///<author>Home Technology</author>
		public List<clsCliassuranceproduit> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, AP_CODEPRODUIT, AP_LIBELLEPRODUIT, AP_PLAFONDPRODUIT FROM dbo.FT_CLIASSURANCEPRODUIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliassuranceproduit> clsCliassuranceproduits = new List<clsCliassuranceproduit>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliassuranceproduit clsCliassuranceproduit = new clsCliassuranceproduit();
					clsCliassuranceproduit.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliassuranceproduit.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsCliassuranceproduit.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsCliassuranceproduit.AP_LIBELLEPRODUIT = clsDonnee.vogDataReader["AP_LIBELLEPRODUIT"].ToString();
					clsCliassuranceproduit.AP_PLAFONDPRODUIT = double.Parse(clsDonnee.vogDataReader["AP_PLAFONDPRODUIT"].ToString());
					clsCliassuranceproduits.Add(clsCliassuranceproduit);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliassuranceproduits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliassuranceproduit </returns>
		///<author>Home Technology</author>
		public List<clsCliassuranceproduit> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliassuranceproduit> clsCliassuranceproduits = new List<clsCliassuranceproduit>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, AP_CODEPRODUIT, AP_LIBELLEPRODUIT, AP_PLAFONDPRODUIT FROM dbo.FT_CLIASSURANCEPRODUIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliassuranceproduit clsCliassuranceproduit = new clsCliassuranceproduit();
					clsCliassuranceproduit.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliassuranceproduit.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsCliassuranceproduit.AP_CODEPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["AP_CODEPRODUIT"].ToString();
					clsCliassuranceproduit.AP_LIBELLEPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["AP_LIBELLEPRODUIT"].ToString();
					clsCliassuranceproduit.AP_PLAFONDPRODUIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AP_PLAFONDPRODUIT"].ToString());
					clsCliassuranceproduits.Add(clsCliassuranceproduit);
				}
				Dataset.Dispose();
			}
		return clsCliassuranceproduits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLIASSURANCEPRODUIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, AP_CODEPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AP_CODEPRODUIT ,AP_LIBELLEPRODUIT FROM dbo.FT_CLIASSURANCEPRODUIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, AP_CODEPRODUIT)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AP_CODEPRODUIT=@AP_CODEPRODUIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@AP_CODEPRODUIT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, AP_CODEPRODUIT)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
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
		        this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS";
		        vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@TI_IDTIERS" };
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
		        break;
	        }
        }



	}
}
