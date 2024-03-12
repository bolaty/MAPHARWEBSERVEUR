using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsLogicielobjettypeoperationprofilWSDAL: ITableDAL<clsLogicielobjettypeoperationprofil>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsLogicielobjettypeoperationprofil comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsLogicielobjettypeoperationprofil pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT LO_ACTIF  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsLogicielobjettypeoperationprofil clsLogicielobjettypeoperationprofil = new clsLogicielobjettypeoperationprofil();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjettypeoperationprofil.LO_ACTIF = clsDonnee.vogDataReader["LO_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsLogicielobjettypeoperationprofil;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjettypeoperationprofil>clsLogicielobjettypeoperationprofil</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsLogicielobjettypeoperationprofil clsLogicielobjettypeoperationprofil)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsLogicielobjettypeoperationprofil.AG_CODEAGENCE ;
			SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL1", SqlDbType.VarChar, 50);
			vppParamPO_CODEPROFIL.Value  = clsLogicielobjettypeoperationprofil.PO_CODEPROFIL ;

			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION1", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsLogicielobjettypeoperationprofil.FO_CODEFAMILLEOPERATION ;

			SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION1", SqlDbType.VarChar, 2);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsLogicielobjettypeoperationprofil.NF_CODENATUREFAMILLEOPERATION;

			SqlParameter vppParamLO_ACTIF = new SqlParameter("@LO_ACTIF", SqlDbType.VarChar, 1);
			vppParamLO_ACTIF.Value  = clsLogicielobjettypeoperationprofil.LO_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPEOPERATIONPROFIL  @AG_CODEAGENCE1, @PO_CODEPROFIL1, @FO_CODEFAMILLEOPERATION1, @LO_ACTIF,@NF_CODENATUREFAMILLEOPERATION1, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamLO_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjettypeoperationprofil>clsLogicielobjettypeoperationprofil</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsLogicielobjettypeoperationprofil clsLogicielobjettypeoperationprofil,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsLogicielobjettypeoperationprofil.AG_CODEAGENCE ;
			SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 50);
			vppParamPO_CODEPROFIL.Value  = clsLogicielobjettypeoperationprofil.PO_CODEPROFIL ;
			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsLogicielobjettypeoperationprofil.FO_CODEFAMILLEOPERATION ;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 2);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsLogicielobjettypeoperationprofil.NF_CODENATUREFAMILLEOPERATION;


			SqlParameter vppParamLO_ACTIF = new SqlParameter("@LO_ACTIF", SqlDbType.VarChar, 1);
			vppParamLO_ACTIF.Value  = clsLogicielobjettypeoperationprofil.LO_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPEOPERATIONPROFIL2  @AG_CODEAGENCE, @PO_CODEPROFIL, @FO_CODEFAMILLEOPERATION, @LO_ACTIF,@NF_CODENATUREFAMILLEOPERATION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamLO_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPEOPERATIONPROFIL  @AG_CODEAGENCE, @PO_CODEPROFIL,'', '' ,@NF_CODENATUREFAMILLEOPERATION , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeoperationprofil </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeoperationprofil> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION, LO_ACTIF FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsLogicielobjettypeoperationprofil> clsLogicielobjettypeoperationprofils = new List<clsLogicielobjettypeoperationprofil>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjettypeoperationprofil clsLogicielobjettypeoperationprofil = new clsLogicielobjettypeoperationprofil();
					clsLogicielobjettypeoperationprofil.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsLogicielobjettypeoperationprofil.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString();
					clsLogicielobjettypeoperationprofil.FO_CODEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_CODEFAMILLEOPERATION"].ToString();
					clsLogicielobjettypeoperationprofil.LO_ACTIF = clsDonnee.vogDataReader["LO_ACTIF"].ToString();
					clsLogicielobjettypeoperationprofils.Add(clsLogicielobjettypeoperationprofil);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsLogicielobjettypeoperationprofils;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeoperationprofil </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeoperationprofil> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsLogicielobjettypeoperationprofil> clsLogicielobjettypeoperationprofils = new List<clsLogicielobjettypeoperationprofil>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION, LO_ACTIF FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsLogicielobjettypeoperationprofil clsLogicielobjettypeoperationprofil = new clsLogicielobjettypeoperationprofil();
					clsLogicielobjettypeoperationprofil.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsLogicielobjettypeoperationprofil.PO_CODEPROFIL = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFIL"].ToString();
					clsLogicielobjettypeoperationprofil.FO_CODEFAMILLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFAMILLEOPERATION"].ToString();
					clsLogicielobjettypeoperationprofil.LO_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["LO_ACTIF"].ToString();
					clsLogicielobjettypeoperationprofils.Add(clsLogicielobjettypeoperationprofil);
				}
				Dataset.Dispose();
			}
		return clsLogicielobjettypeoperationprofils;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , LO_ACTIF FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFIL2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurDroit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);

            vapNomParametre = new string[] {  "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@PO_CODEPROFIL" };
            vapValeurParametre = new object[] {  vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = "SELECT * FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONPROFILDROIT(@AG_CODEAGENCE,@NF_CODENATUREFAMILLEOPERATION,@PO_CODEPROFIL) ORDER BY FO_NUMEROORDRE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, PO_CODEPROFIL, FO_CODEFAMILLEOPERATION)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFIL=@PO_CODEPROFIL";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFIL"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;

                case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFIL=@PO_CODEPROFIL  AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION  ";
                vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFIL", "@NF_CODENATUREFAMILLEOPERATION" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
                break;

				case 4 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PO_CODEPROFIL=@PO_CODEPROFIL AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION    AND FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@PO_CODEPROFIL", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
