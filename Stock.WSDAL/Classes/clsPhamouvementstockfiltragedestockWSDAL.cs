using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockfiltragedestockWSDAL: ITableDAL<clsPhamouvementstockfiltragedestock>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MF_IDFILTRAGEDESTOCK) AS MF_IDFILTRAGEDESTOCK  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCK " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MF_IDFILTRAGEDESTOCK) AS MF_IDFILTRAGEDESTOCK  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCK" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MF_IDFILTRAGEDESTOCK) AS MF_IDFILTRAGEDESTOCK  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCK " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockfiltragedestock comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockfiltragedestock pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MF_NUMEROLOTFILTRAGEDESTOCK  , MF_DESCRIPTIONFILTRAGEDESTOCK  , OP_CODEOPERATEUR  , MF_DATESAISIEFILTRAGEDESTOCK  , MF_DATECLOTUREFILTRAGEDESTOCK  FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCK(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new clsPhamouvementstockfiltragedestock();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockfiltragedestock.MF_NUMEROLOTFILTRAGEDESTOCK = clsDonnee.vogDataReader["MF_NUMEROLOTFILTRAGEDESTOCK"].ToString();
					clsPhamouvementstockfiltragedestock.MF_DESCRIPTIONFILTRAGEDESTOCK = clsDonnee.vogDataReader["MF_DESCRIPTIONFILTRAGEDESTOCK"].ToString();
					clsPhamouvementstockfiltragedestock.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestock.MF_DATESAISIEFILTRAGEDESTOCK = DateTime.Parse(clsDonnee.vogDataReader["MF_DATESAISIEFILTRAGEDESTOCK"].ToString());
					clsPhamouvementstockfiltragedestock.MF_DATECLOTUREFILTRAGEDESTOCK = DateTime.Parse(clsDonnee.vogDataReader["MF_DATECLOTUREFILTRAGEDESTOCK"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockfiltragedestock;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockfiltragedestock>clsPhamouvementstockfiltragedestock</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock)
		{
			//Préparation des paramètres
			SqlParameter vppParamMF_IDFILTRAGEDESTOCK = new SqlParameter("@MF_IDFILTRAGEDESTOCK1", SqlDbType.VarChar, 50);
			vppParamMF_IDFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_IDFILTRAGEDESTOCK ;
			SqlParameter vppParamMF_NUMEROLOTFILTRAGEDESTOCK = new SqlParameter("@MF_NUMEROLOTFILTRAGEDESTOCK", SqlDbType.VarChar, 1000);
			vppParamMF_NUMEROLOTFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_NUMEROLOTFILTRAGEDESTOCK ;
			SqlParameter vppParamMF_DESCRIPTIONFILTRAGEDESTOCK = new SqlParameter("@MF_DESCRIPTIONFILTRAGEDESTOCK", SqlDbType.VarChar, 1000);
			vppParamMF_DESCRIPTIONFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_DESCRIPTIONFILTRAGEDESTOCK ;
            if (clsPhamouvementstockfiltragedestock.MF_DESCRIPTIONFILTRAGEDESTOCK == "") vppParamMF_DESCRIPTIONFILTRAGEDESTOCK.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockfiltragedestock.OP_CODEOPERATEUR ;
			SqlParameter vppParamMF_DATESAISIEFILTRAGEDESTOCK = new SqlParameter("@MF_DATESAISIEFILTRAGEDESTOCK", SqlDbType.DateTime);
			vppParamMF_DATESAISIEFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_DATESAISIEFILTRAGEDESTOCK ;
			SqlParameter vppParamMF_DATECLOTUREFILTRAGEDESTOCK = new SqlParameter("@MF_DATECLOTUREFILTRAGEDESTOCK", SqlDbType.DateTime);
			vppParamMF_DATECLOTUREFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_DATECLOTUREFILTRAGEDESTOCK ;
            if (clsPhamouvementstockfiltragedestock.MF_DATECLOTUREFILTRAGEDESTOCK.Year < 1900) vppParamMF_DATECLOTUREFILTRAGEDESTOCK.Value = "01/01/1900";



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCK  @MF_IDFILTRAGEDESTOCK1, @MF_NUMEROLOTFILTRAGEDESTOCK, @MF_DESCRIPTIONFILTRAGEDESTOCK, @OP_CODEOPERATEUR, @MF_DATESAISIEFILTRAGEDESTOCK, @MF_DATECLOTUREFILTRAGEDESTOCK, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamMF_NUMEROLOTFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamMF_DESCRIPTIONFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamMF_DATESAISIEFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamMF_DATECLOTUREFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockfiltragedestock>clsPhamouvementstockfiltragedestock</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMF_IDFILTRAGEDESTOCK = new SqlParameter("@MF_IDFILTRAGEDESTOCK1", SqlDbType.VarChar, 50);
			vppParamMF_IDFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_IDFILTRAGEDESTOCK ;
			SqlParameter vppParamMF_NUMEROLOTFILTRAGEDESTOCK = new SqlParameter("@MF_NUMEROLOTFILTRAGEDESTOCK", SqlDbType.VarChar, 1000);
			vppParamMF_NUMEROLOTFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_NUMEROLOTFILTRAGEDESTOCK ;
			SqlParameter vppParamMF_DESCRIPTIONFILTRAGEDESTOCK = new SqlParameter("@MF_DESCRIPTIONFILTRAGEDESTOCK", SqlDbType.VarChar, 1000);
			vppParamMF_DESCRIPTIONFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_DESCRIPTIONFILTRAGEDESTOCK ;
            if (clsPhamouvementstockfiltragedestock.MF_DESCRIPTIONFILTRAGEDESTOCK == "") vppParamMF_DESCRIPTIONFILTRAGEDESTOCK.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockfiltragedestock.OP_CODEOPERATEUR ;
			SqlParameter vppParamMF_DATESAISIEFILTRAGEDESTOCK = new SqlParameter("@MF_DATESAISIEFILTRAGEDESTOCK", SqlDbType.DateTime);
			vppParamMF_DATESAISIEFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_DATESAISIEFILTRAGEDESTOCK ;
			SqlParameter vppParamMF_DATECLOTUREFILTRAGEDESTOCK = new SqlParameter("@MF_DATECLOTUREFILTRAGEDESTOCK", SqlDbType.DateTime);
			vppParamMF_DATECLOTUREFILTRAGEDESTOCK.Value  = clsPhamouvementstockfiltragedestock.MF_DATECLOTUREFILTRAGEDESTOCK ;
            if (clsPhamouvementstockfiltragedestock.MF_DATECLOTUREFILTRAGEDESTOCK.Year < 1900) vppParamMF_DATECLOTUREFILTRAGEDESTOCK.Value = "01/01/1900";
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 25);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockfiltragedestock.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCK  @MF_IDFILTRAGEDESTOCK1, @MF_NUMEROLOTFILTRAGEDESTOCK, @MF_DESCRIPTIONFILTRAGEDESTOCK, @OP_CODEOPERATEUR, @MF_DATESAISIEFILTRAGEDESTOCK, @MF_DATECLOTUREFILTRAGEDESTOCK, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamMF_NUMEROLOTFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamMF_DESCRIPTIONFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamMF_DATESAISIEFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamMF_DATECLOTUREFILTRAGEDESTOCK);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCK  @MF_IDFILTRAGEDESTOCK, '' , '' , '', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestock </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestock> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MF_IDFILTRAGEDESTOCK, MF_NUMEROLOTFILTRAGEDESTOCK, MF_DESCRIPTIONFILTRAGEDESTOCK, OP_CODEOPERATEUR, MF_DATESAISIEFILTRAGEDESTOCK, MF_DATECLOTUREFILTRAGEDESTOCK FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCK(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<clsPhamouvementstockfiltragedestock>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new clsPhamouvementstockfiltragedestock();
					clsPhamouvementstockfiltragedestock.MF_IDFILTRAGEDESTOCK = clsDonnee.vogDataReader["MF_IDFILTRAGEDESTOCK"].ToString();
					clsPhamouvementstockfiltragedestock.MF_NUMEROLOTFILTRAGEDESTOCK = clsDonnee.vogDataReader["MF_NUMEROLOTFILTRAGEDESTOCK"].ToString();
					clsPhamouvementstockfiltragedestock.MF_DESCRIPTIONFILTRAGEDESTOCK = clsDonnee.vogDataReader["MF_DESCRIPTIONFILTRAGEDESTOCK"].ToString();
					clsPhamouvementstockfiltragedestock.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestock.MF_DATESAISIEFILTRAGEDESTOCK = DateTime.Parse(clsDonnee.vogDataReader["MF_DATESAISIEFILTRAGEDESTOCK"].ToString());
					clsPhamouvementstockfiltragedestock.MF_DATECLOTUREFILTRAGEDESTOCK = DateTime.Parse(clsDonnee.vogDataReader["MF_DATECLOTUREFILTRAGEDESTOCK"].ToString());
					clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockfiltragedestocks;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestock </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestock> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<clsPhamouvementstockfiltragedestock>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MF_IDFILTRAGEDESTOCK, MF_NUMEROLOTFILTRAGEDESTOCK, MF_DESCRIPTIONFILTRAGEDESTOCK, OP_CODEOPERATEUR, MF_DATESAISIEFILTRAGEDESTOCK, MF_DATECLOTUREFILTRAGEDESTOCK FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCK(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new clsPhamouvementstockfiltragedestock();
					clsPhamouvementstockfiltragedestock.MF_IDFILTRAGEDESTOCK = Dataset.Tables["TABLE"].Rows[Idx]["MF_IDFILTRAGEDESTOCK"].ToString();
					clsPhamouvementstockfiltragedestock.MF_NUMEROLOTFILTRAGEDESTOCK = Dataset.Tables["TABLE"].Rows[Idx]["MF_NUMEROLOTFILTRAGEDESTOCK"].ToString();
					clsPhamouvementstockfiltragedestock.MF_DESCRIPTIONFILTRAGEDESTOCK = Dataset.Tables["TABLE"].Rows[Idx]["MF_DESCRIPTIONFILTRAGEDESTOCK"].ToString();
					clsPhamouvementstockfiltragedestock.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestock.MF_DATESAISIEFILTRAGEDESTOCK = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MF_DATESAISIEFILTRAGEDESTOCK"].ToString());
					clsPhamouvementstockfiltragedestock.MF_DATECLOTUREFILTRAGEDESTOCK = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MF_DATECLOTUREFILTRAGEDESTOCK"].ToString());
					clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockfiltragedestocks;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCK(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MF_IDFILTRAGEDESTOCK , MF_NUMEROLOTFILTRAGEDESTOCK FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCK(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MF_IDFILTRAGEDESTOCK, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE MF_IDFILTRAGEDESTOCK=@MF_IDFILTRAGEDESTOCK";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MF_IDFILTRAGEDESTOCK"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE MF_IDFILTRAGEDESTOCK=@MF_IDFILTRAGEDESTOCK AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MF_IDFILTRAGEDESTOCK","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
