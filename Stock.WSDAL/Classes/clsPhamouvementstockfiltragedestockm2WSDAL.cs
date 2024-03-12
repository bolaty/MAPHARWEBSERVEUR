using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockfiltragedestockm2WSDAL: ITableDAL<clsPhamouvementstockfiltragedestockm2>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MF_IDFILTRAGEDESTOCKM2) AS MF_IDFILTRAGEDESTOCKM2  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2 " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MF_IDFILTRAGEDESTOCKM2) AS MF_IDFILTRAGEDESTOCKM2  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2 " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MF_IDFILTRAGEDESTOCKM2) AS MF_IDFILTRAGEDESTOCKM2  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2 " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockfiltragedestockm2 comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockfiltragedestockm2 pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MF_NUMEROLOTFILTRAGEDESTOCKM2  , MF_DESCRIPTIONFILTRAGEDESTOCKM2  , OP_CODEOPERATEUR  , MF_DATESAISIEFILTRAGEDESTOCKM2  , MF_DATECLOTUREFILTRAGEDESTOCKM2  FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockfiltragedestockm2 clsPhamouvementstockfiltragedestockm2 = new clsPhamouvementstockfiltragedestockm2();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockfiltragedestockm2.MF_NUMEROLOTFILTRAGEDESTOCKM2 = clsDonnee.vogDataReader["MF_NUMEROLOTFILTRAGEDESTOCKM2"].ToString();
					clsPhamouvementstockfiltragedestockm2.MF_DESCRIPTIONFILTRAGEDESTOCKM2 = clsDonnee.vogDataReader["MF_DESCRIPTIONFILTRAGEDESTOCKM2"].ToString();
					clsPhamouvementstockfiltragedestockm2.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockm2.MF_DATESAISIEFILTRAGEDESTOCKM2 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATESAISIEFILTRAGEDESTOCKM2"].ToString());
					clsPhamouvementstockfiltragedestockm2.MF_DATECLOTUREFILTRAGEDESTOCKM2 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATECLOTUREFILTRAGEDESTOCKM2"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockfiltragedestockm2;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockfiltragedestockm2>clsPhamouvementstockfiltragedestockm2</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestockm2 clsPhamouvementstockfiltragedestockm2)
		{
			//Préparation des paramètres
			SqlParameter vppParamMF_IDFILTRAGEDESTOCKM2 = new SqlParameter("@MF_IDFILTRAGEDESTOCKM21", SqlDbType.VarChar, 50);
			vppParamMF_IDFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_IDFILTRAGEDESTOCKM2 ;
			SqlParameter vppParamMF_NUMEROLOTFILTRAGEDESTOCKM2 = new SqlParameter("@MF_NUMEROLOTFILTRAGEDESTOCKM2", SqlDbType.VarChar, 1000);
			vppParamMF_NUMEROLOTFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_NUMEROLOTFILTRAGEDESTOCKM2 ;
			SqlParameter vppParamMF_DESCRIPTIONFILTRAGEDESTOCKM2 = new SqlParameter("@MF_DESCRIPTIONFILTRAGEDESTOCKM2", SqlDbType.VarChar, 1000);
			vppParamMF_DESCRIPTIONFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_DESCRIPTIONFILTRAGEDESTOCKM2 ;
            if (clsPhamouvementstockfiltragedestockm2.MF_DESCRIPTIONFILTRAGEDESTOCKM2 == "") vppParamMF_DESCRIPTIONFILTRAGEDESTOCKM2.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockfiltragedestockm2.OP_CODEOPERATEUR ;
			SqlParameter vppParamMF_DATESAISIEFILTRAGEDESTOCKM2 = new SqlParameter("@MF_DATESAISIEFILTRAGEDESTOCKM2", SqlDbType.DateTime);
			vppParamMF_DATESAISIEFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_DATESAISIEFILTRAGEDESTOCKM2 ;
			SqlParameter vppParamMF_DATECLOTUREFILTRAGEDESTOCKM2 = new SqlParameter("@MF_DATECLOTUREFILTRAGEDESTOCKM2", SqlDbType.DateTime);
			vppParamMF_DATECLOTUREFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_DATECLOTUREFILTRAGEDESTOCKM2 ;

            if (clsPhamouvementstockfiltragedestockm2.MF_DATECLOTUREFILTRAGEDESTOCKM2.Year < 1900) vppParamMF_DATECLOTUREFILTRAGEDESTOCKM2.Value = "01/01/1900";


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2  @MF_IDFILTRAGEDESTOCKM21, @MF_NUMEROLOTFILTRAGEDESTOCKM2, @MF_DESCRIPTIONFILTRAGEDESTOCKM2, @OP_CODEOPERATEUR, @MF_DATESAISIEFILTRAGEDESTOCKM2, @MF_DATECLOTUREFILTRAGEDESTOCKM2, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamMF_NUMEROLOTFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamMF_DESCRIPTIONFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamMF_DATESAISIEFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamMF_DATECLOTUREFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockfiltragedestockm2>clsPhamouvementstockfiltragedestockm2</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestockm2 clsPhamouvementstockfiltragedestockm2,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMF_IDFILTRAGEDESTOCKM2 = new SqlParameter("@MF_IDFILTRAGEDESTOCKM21", SqlDbType.VarChar, 50);
			vppParamMF_IDFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_IDFILTRAGEDESTOCKM2 ;
			SqlParameter vppParamMF_NUMEROLOTFILTRAGEDESTOCKM2 = new SqlParameter("@MF_NUMEROLOTFILTRAGEDESTOCKM2", SqlDbType.VarChar, 1000);
			vppParamMF_NUMEROLOTFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_NUMEROLOTFILTRAGEDESTOCKM2 ;
			SqlParameter vppParamMF_DESCRIPTIONFILTRAGEDESTOCKM2 = new SqlParameter("@MF_DESCRIPTIONFILTRAGEDESTOCKM2", SqlDbType.VarChar, 1000);
			vppParamMF_DESCRIPTIONFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_DESCRIPTIONFILTRAGEDESTOCKM2 ;
            if (clsPhamouvementstockfiltragedestockm2.MF_DESCRIPTIONFILTRAGEDESTOCKM2 == "") vppParamMF_DESCRIPTIONFILTRAGEDESTOCKM2.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockfiltragedestockm2.OP_CODEOPERATEUR ;
			SqlParameter vppParamMF_DATESAISIEFILTRAGEDESTOCKM2 = new SqlParameter("@MF_DATESAISIEFILTRAGEDESTOCKM2", SqlDbType.DateTime);
			vppParamMF_DATESAISIEFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_DATESAISIEFILTRAGEDESTOCKM2 ;
			SqlParameter vppParamMF_DATECLOTUREFILTRAGEDESTOCKM2 = new SqlParameter("@MF_DATECLOTUREFILTRAGEDESTOCKM2", SqlDbType.DateTime);
			vppParamMF_DATECLOTUREFILTRAGEDESTOCKM2.Value  = clsPhamouvementstockfiltragedestockm2.MF_DATECLOTUREFILTRAGEDESTOCKM2 ;
            if (clsPhamouvementstockfiltragedestockm2.MF_DATECLOTUREFILTRAGEDESTOCKM2.Year < 1900) vppParamMF_DATECLOTUREFILTRAGEDESTOCKM2.Value = "01/01/1900";
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 25);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockfiltragedestockm2.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2  @MF_IDFILTRAGEDESTOCKM21, @MF_NUMEROLOTFILTRAGEDESTOCKM2, @MF_DESCRIPTIONFILTRAGEDESTOCKM2, @OP_CODEOPERATEUR, @MF_DATESAISIEFILTRAGEDESTOCKM2, @MF_DATECLOTUREFILTRAGEDESTOCKM2, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamMF_NUMEROLOTFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamMF_DESCRIPTIONFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamMF_DATESAISIEFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamMF_DATECLOTUREFILTRAGEDESTOCKM2);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2  @MF_IDFILTRAGEDESTOCKM2, '' , '' , '', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestockm2 </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestockm2> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MF_IDFILTRAGEDESTOCKM2, MF_NUMEROLOTFILTRAGEDESTOCKM2, MF_DESCRIPTIONFILTRAGEDESTOCKM2, OP_CODEOPERATEUR, MF_DATESAISIEFILTRAGEDESTOCKM2, MF_DATECLOTUREFILTRAGEDESTOCKM2 FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockfiltragedestockm2> clsPhamouvementstockfiltragedestockm2s = new List<clsPhamouvementstockfiltragedestockm2>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockfiltragedestockm2 clsPhamouvementstockfiltragedestockm2 = new clsPhamouvementstockfiltragedestockm2();
					clsPhamouvementstockfiltragedestockm2.MF_IDFILTRAGEDESTOCKM2 = clsDonnee.vogDataReader["MF_IDFILTRAGEDESTOCKM2"].ToString();
					clsPhamouvementstockfiltragedestockm2.MF_NUMEROLOTFILTRAGEDESTOCKM2 = clsDonnee.vogDataReader["MF_NUMEROLOTFILTRAGEDESTOCKM2"].ToString();
					clsPhamouvementstockfiltragedestockm2.MF_DESCRIPTIONFILTRAGEDESTOCKM2 = clsDonnee.vogDataReader["MF_DESCRIPTIONFILTRAGEDESTOCKM2"].ToString();
					clsPhamouvementstockfiltragedestockm2.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockm2.MF_DATESAISIEFILTRAGEDESTOCKM2 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATESAISIEFILTRAGEDESTOCKM2"].ToString());
					clsPhamouvementstockfiltragedestockm2.MF_DATECLOTUREFILTRAGEDESTOCKM2 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATECLOTUREFILTRAGEDESTOCKM2"].ToString());
					clsPhamouvementstockfiltragedestockm2s.Add(clsPhamouvementstockfiltragedestockm2);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockfiltragedestockm2s;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestockm2 </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestockm2> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockfiltragedestockm2> clsPhamouvementstockfiltragedestockm2s = new List<clsPhamouvementstockfiltragedestockm2>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MF_IDFILTRAGEDESTOCKM2, MF_NUMEROLOTFILTRAGEDESTOCKM2, MF_DESCRIPTIONFILTRAGEDESTOCKM2, OP_CODEOPERATEUR, MF_DATESAISIEFILTRAGEDESTOCKM2, MF_DATECLOTUREFILTRAGEDESTOCKM2 FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockfiltragedestockm2 clsPhamouvementstockfiltragedestockm2 = new clsPhamouvementstockfiltragedestockm2();
					clsPhamouvementstockfiltragedestockm2.MF_IDFILTRAGEDESTOCKM2 = Dataset.Tables["TABLE"].Rows[Idx]["MF_IDFILTRAGEDESTOCKM2"].ToString();
					clsPhamouvementstockfiltragedestockm2.MF_NUMEROLOTFILTRAGEDESTOCKM2 = Dataset.Tables["TABLE"].Rows[Idx]["MF_NUMEROLOTFILTRAGEDESTOCKM2"].ToString();
					clsPhamouvementstockfiltragedestockm2.MF_DESCRIPTIONFILTRAGEDESTOCKM2 = Dataset.Tables["TABLE"].Rows[Idx]["MF_DESCRIPTIONFILTRAGEDESTOCKM2"].ToString();
					clsPhamouvementstockfiltragedestockm2.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockm2.MF_DATESAISIEFILTRAGEDESTOCKM2 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MF_DATESAISIEFILTRAGEDESTOCKM2"].ToString());
					clsPhamouvementstockfiltragedestockm2.MF_DATECLOTUREFILTRAGEDESTOCKM2 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MF_DATECLOTUREFILTRAGEDESTOCKM2"].ToString());
					clsPhamouvementstockfiltragedestockm2s.Add(clsPhamouvementstockfiltragedestockm2);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockfiltragedestockm2s;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MF_IDFILTRAGEDESTOCKM2 , MF_NUMEROLOTFILTRAGEDESTOCKM2 FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MF_IDFILTRAGEDESTOCKM2, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE MF_IDFILTRAGEDESTOCKM2=@MF_IDFILTRAGEDESTOCKM2";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MF_IDFILTRAGEDESTOCKM2"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE MF_IDFILTRAGEDESTOCKM2=@MF_IDFILTRAGEDESTOCKM2 AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MF_IDFILTRAGEDESTOCKM2","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
