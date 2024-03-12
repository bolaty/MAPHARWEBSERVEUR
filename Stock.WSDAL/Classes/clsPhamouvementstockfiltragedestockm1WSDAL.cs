using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockfiltragedestockm1WSDAL: ITableDAL<clsPhamouvementstockfiltragedestockm1>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MF_IDFILTRAGEDESTOCKM1) AS MF_IDFILTRAGEDESTOCKM1  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1 " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MF_IDFILTRAGEDESTOCKM1) AS MF_IDFILTRAGEDESTOCKM1  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1 " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MF_IDFILTRAGEDESTOCKM1) AS MF_IDFILTRAGEDESTOCKM1  FROM dbo.PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1 " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockfiltragedestockm1 comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockfiltragedestockm1 pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MF_DATEFABRICATIONFILTRAGEDESTOCKM1  , MF_LIBELLEFILTRAGEDESTOCKM1  , OP_CODEOPERATEUR  , MF_DATESAISIEFILTRAGEDESTOCKM1  , MF_DATECLOTUREFILTRAGEDESTOCKM1  FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockfiltragedestockm1 clsPhamouvementstockfiltragedestockm1 = new clsPhamouvementstockfiltragedestockm1();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockfiltragedestockm1.MF_LIBELLEFILTRAGEDESTOCKM1 = clsDonnee.vogDataReader["MF_LIBELLEFILTRAGEDESTOCKM1"].ToString();
					clsPhamouvementstockfiltragedestockm1.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockm1.MF_DATEFABRICATIONFILTRAGEDESTOCKM1 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATEFABRICATIONFILTRAGEDESTOCKM1"].ToString());
					clsPhamouvementstockfiltragedestockm1.MF_DATESAISIEFILTRAGEDESTOCKM1 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATESAISIEFILTRAGEDESTOCKM1"].ToString());
					clsPhamouvementstockfiltragedestockm1.MF_DATECLOTUREFILTRAGEDESTOCKM1 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATECLOTUREFILTRAGEDESTOCKM1"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockfiltragedestockm1;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockfiltragedestockm1>clsPhamouvementstockfiltragedestockm1</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestockm1 clsPhamouvementstockfiltragedestockm1)
		{
			//Préparation des paramètres
			SqlParameter vppParamMF_IDFILTRAGEDESTOCKM1 = new SqlParameter("@MF_IDFILTRAGEDESTOCKM11", SqlDbType.VarChar, 50);
			vppParamMF_IDFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_IDFILTRAGEDESTOCKM1 ;
			SqlParameter vppParamMF_LIBELLEFILTRAGEDESTOCKM1 = new SqlParameter("@MF_LIBELLEFILTRAGEDESTOCKM1", SqlDbType.VarChar, 1000);
			vppParamMF_LIBELLEFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_LIBELLEFILTRAGEDESTOCKM1 ;
            if (clsPhamouvementstockfiltragedestockm1.MF_LIBELLEFILTRAGEDESTOCKM1 == "") vppParamMF_LIBELLEFILTRAGEDESTOCKM1.Value = DBNull.Value;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockfiltragedestockm1.OP_CODEOPERATEUR ;

			SqlParameter vppParamMF_DATEFABRICATIONFILTRAGEDESTOCKM1 = new SqlParameter("@MF_DATEFABRICATIONFILTRAGEDESTOCKM1", SqlDbType.DateTime);
            vppParamMF_DATEFABRICATIONFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_DATEFABRICATIONFILTRAGEDESTOCKM1;

			SqlParameter vppParamMF_DATESAISIEFILTRAGEDESTOCKM1 = new SqlParameter("@MF_DATESAISIEFILTRAGEDESTOCKM1", SqlDbType.DateTime);
			vppParamMF_DATESAISIEFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_DATESAISIEFILTRAGEDESTOCKM1 ;
			SqlParameter vppParamMF_DATECLOTUREFILTRAGEDESTOCKM1 = new SqlParameter("@MF_DATECLOTUREFILTRAGEDESTOCKM1", SqlDbType.DateTime);
			vppParamMF_DATECLOTUREFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_DATECLOTUREFILTRAGEDESTOCKM1 ;

            if (clsPhamouvementstockfiltragedestockm1.MF_DATECLOTUREFILTRAGEDESTOCKM1.Year < 1900) vppParamMF_DATECLOTUREFILTRAGEDESTOCKM1.Value = "01/01/1900";

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1  @MF_IDFILTRAGEDESTOCKM11,  @MF_LIBELLEFILTRAGEDESTOCKM1, @OP_CODEOPERATEUR,@MF_DATEFABRICATIONFILTRAGEDESTOCKM1, @MF_DATESAISIEFILTRAGEDESTOCKM1, @MF_DATECLOTUREFILTRAGEDESTOCKM1, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamMF_LIBELLEFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamMF_DATEFABRICATIONFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamMF_DATESAISIEFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamMF_DATECLOTUREFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockfiltragedestockm1>clsPhamouvementstockfiltragedestockm1</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockfiltragedestockm1 clsPhamouvementstockfiltragedestockm1,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMF_IDFILTRAGEDESTOCKM1 = new SqlParameter("@MF_IDFILTRAGEDESTOCKM11", SqlDbType.VarChar, 50);
			vppParamMF_IDFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_IDFILTRAGEDESTOCKM1 ;
			SqlParameter vppParamMF_LIBELLEFILTRAGEDESTOCKM1 = new SqlParameter("@MF_LIBELLEFILTRAGEDESTOCKM1", SqlDbType.VarChar, 1000);
			vppParamMF_LIBELLEFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_LIBELLEFILTRAGEDESTOCKM1 ;
            if (clsPhamouvementstockfiltragedestockm1.MF_LIBELLEFILTRAGEDESTOCKM1 == "") vppParamMF_LIBELLEFILTRAGEDESTOCKM1.Value = DBNull.Value;


            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockfiltragedestockm1.OP_CODEOPERATEUR ;

			SqlParameter vppParamMF_DATEFABRICATIONFILTRAGEDESTOCKM1 = new SqlParameter("@MF_DATEFABRICATIONFILTRAGEDESTOCKM1", SqlDbType.DateTime);
            vppParamMF_DATEFABRICATIONFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_DATEFABRICATIONFILTRAGEDESTOCKM1;

			SqlParameter vppParamMF_DATESAISIEFILTRAGEDESTOCKM1 = new SqlParameter("@MF_DATESAISIEFILTRAGEDESTOCKM1", SqlDbType.DateTime);
			vppParamMF_DATESAISIEFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_DATESAISIEFILTRAGEDESTOCKM1 ;
			SqlParameter vppParamMF_DATECLOTUREFILTRAGEDESTOCKM1 = new SqlParameter("@MF_DATECLOTUREFILTRAGEDESTOCKM1", SqlDbType.DateTime);
			vppParamMF_DATECLOTUREFILTRAGEDESTOCKM1.Value  = clsPhamouvementstockfiltragedestockm1.MF_DATECLOTUREFILTRAGEDESTOCKM1 ;
            if (clsPhamouvementstockfiltragedestockm1.MF_DATECLOTUREFILTRAGEDESTOCKM1.Year < 1900) vppParamMF_DATECLOTUREFILTRAGEDESTOCKM1.Value = "01/01/1900";
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 25);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockfiltragedestockm1.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1  @MF_IDFILTRAGEDESTOCKM11,  @MF_LIBELLEFILTRAGEDESTOCKM1, @OP_CODEOPERATEUR,@MF_DATEFABRICATIONFILTRAGEDESTOCKM1, @MF_DATESAISIEFILTRAGEDESTOCKM1, @MF_DATECLOTUREFILTRAGEDESTOCKM1, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamMF_LIBELLEFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamMF_DATEFABRICATIONFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamMF_DATESAISIEFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamMF_DATECLOTUREFILTRAGEDESTOCKM1);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1  @MF_IDFILTRAGEDESTOCKM1, '' , '' , '', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestockm1 </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestockm1> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MF_IDFILTRAGEDESTOCKM1, MF_LIBELLEFILTRAGEDESTOCKM1, OP_CODEOPERATEUR,MF_DATEFABRICATIONFILTRAGEDESTOCKM1, MF_DATESAISIEFILTRAGEDESTOCKM1, MF_DATECLOTUREFILTRAGEDESTOCKM1 FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockfiltragedestockm1> clsPhamouvementstockfiltragedestockm1s = new List<clsPhamouvementstockfiltragedestockm1>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockfiltragedestockm1 clsPhamouvementstockfiltragedestockm1 = new clsPhamouvementstockfiltragedestockm1();
					clsPhamouvementstockfiltragedestockm1.MF_IDFILTRAGEDESTOCKM1 = clsDonnee.vogDataReader["MF_IDFILTRAGEDESTOCKM1"].ToString();
					clsPhamouvementstockfiltragedestockm1.MF_LIBELLEFILTRAGEDESTOCKM1 = clsDonnee.vogDataReader["MF_LIBELLEFILTRAGEDESTOCKM1"].ToString();
					clsPhamouvementstockfiltragedestockm1.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockm1.MF_DATEFABRICATIONFILTRAGEDESTOCKM1 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATEFABRICATIONFILTRAGEDESTOCKM1"].ToString());
					clsPhamouvementstockfiltragedestockm1.MF_DATESAISIEFILTRAGEDESTOCKM1 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATESAISIEFILTRAGEDESTOCKM1"].ToString());
					clsPhamouvementstockfiltragedestockm1.MF_DATECLOTUREFILTRAGEDESTOCKM1 = DateTime.Parse(clsDonnee.vogDataReader["MF_DATECLOTUREFILTRAGEDESTOCKM1"].ToString());
					clsPhamouvementstockfiltragedestockm1s.Add(clsPhamouvementstockfiltragedestockm1);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockfiltragedestockm1s;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockfiltragedestockm1 </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockfiltragedestockm1> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockfiltragedestockm1> clsPhamouvementstockfiltragedestockm1s = new List<clsPhamouvementstockfiltragedestockm1>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  MF_IDFILTRAGEDESTOCKM1,  MF_LIBELLEFILTRAGEDESTOCKM1, OP_CODEOPERATEUR,MF_DATEFABRICATIONFILTRAGEDESTOCKM1, MF_DATESAISIEFILTRAGEDESTOCKM1, MF_DATECLOTUREFILTRAGEDESTOCKM1 FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockfiltragedestockm1 clsPhamouvementstockfiltragedestockm1 = new clsPhamouvementstockfiltragedestockm1();
					clsPhamouvementstockfiltragedestockm1.MF_IDFILTRAGEDESTOCKM1 = Dataset.Tables["TABLE"].Rows[Idx]["MF_IDFILTRAGEDESTOCKM1"].ToString();
					clsPhamouvementstockfiltragedestockm1.MF_LIBELLEFILTRAGEDESTOCKM1 = Dataset.Tables["TABLE"].Rows[Idx]["MF_LIBELLEFILTRAGEDESTOCKM1"].ToString();
					clsPhamouvementstockfiltragedestockm1.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockfiltragedestockm1.MF_DATEFABRICATIONFILTRAGEDESTOCKM1 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MF_DATEFABRICATIONFILTRAGEDESTOCKM1"].ToString());
					clsPhamouvementstockfiltragedestockm1.MF_DATESAISIEFILTRAGEDESTOCKM1 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MF_DATESAISIEFILTRAGEDESTOCKM1"].ToString());
					clsPhamouvementstockfiltragedestockm1.MF_DATECLOTUREFILTRAGEDESTOCKM1 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MF_DATECLOTUREFILTRAGEDESTOCKM1"].ToString());
					clsPhamouvementstockfiltragedestockm1s.Add(clsPhamouvementstockfiltragedestockm1);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockfiltragedestockm1s;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MF_IDFILTRAGEDESTOCKM1 , MF_DATEFABRICATIONFILTRAGEDESTOCKM1 FROM dbo.FT_PHAMOUVEMENTSTOCKFILTRAGEDESTOCKM1(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MF_IDFILTRAGEDESTOCKM1, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE MF_IDFILTRAGEDESTOCKM1=@MF_IDFILTRAGEDESTOCKM1";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MF_IDFILTRAGEDESTOCKM1"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE MF_IDFILTRAGEDESTOCKM1=@MF_IDFILTRAGEDESTOCKM1 AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MF_IDFILTRAGEDESTOCKM1","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
