using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsLogicielobjettypeoperationoperateurWSDAL: ITableDAL<clsLogicielobjettypeoperationoperateur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEUR2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEUR2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEUR2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsLogicielobjettypeoperationoperateur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsLogicielobjettypeoperationoperateur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT LO_ACTIF  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEUR2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new clsLogicielobjettypeoperationoperateur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjettypeoperationoperateur.LO_ACTIF = clsDonnee.vogDataReader["LO_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsLogicielobjettypeoperationoperateur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjettypeoperationoperateur>clsLogicielobjettypeoperationoperateur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsLogicielobjettypeoperationoperateur.AG_CODEAGENCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsLogicielobjettypeoperationoperateur.OP_CODEOPERATEUR ;
			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION ;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION1", SqlDbType.VarChar, 2);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsLogicielobjettypeoperationoperateur.NF_CODENATUREFAMILLEOPERATION;

			SqlParameter vppParamLO_ACTIF = new SqlParameter("@LO_ACTIF", SqlDbType.VarChar, 1);
			vppParamLO_ACTIF.Value  = clsLogicielobjettypeoperationoperateur.LO_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPEOPERATIONOPERATEURWEB  @AG_CODEAGENCE1, @OP_CODEOPERATEUR1, @FO_CODEFAMILLEOPERATION, @LO_ACTIF,  @NF_CODENATUREFAMILLEOPERATION1, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);

			vppSqlCmd.Parameters.Add(vppParamLO_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsLogicielobjettypeoperationoperateur>clsLogicielobjettypeoperationoperateur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsLogicielobjettypeoperationoperateur.AG_CODEAGENCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsLogicielobjettypeoperationoperateur.OP_CODEOPERATEUR ;
			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION ;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 2);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsLogicielobjettypeoperationoperateur.NF_CODENATUREFAMILLEOPERATION;

			SqlParameter vppParamLO_ACTIF = new SqlParameter("@LO_ACTIF", SqlDbType.VarChar, 1);
			vppParamLO_ACTIF.Value  = clsLogicielobjettypeoperationoperateur.LO_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPEOPERATIONOPERATEURWEB2  @AG_CODEAGENCE, @OP_CODEOPERATEUR, @FO_CODEFAMILLEOPERATION, @LO_ACTIF,@NF_CODENATUREFAMILLEOPERATION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamLO_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_LOGICIELOBJETTYPEOPERATIONOPERATEURWEB  @AG_CODEAGENCE, @OP_CODEOPERATEUR,'', '' ,@NF_CODENATUREFAMILLEOPERATION ,@CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeoperationoperateur </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeoperationoperateur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION, LO_ACTIF FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEUR2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<clsLogicielobjettypeoperationoperateur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new clsLogicielobjettypeoperationoperateur();
					clsLogicielobjettypeoperationoperateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsLogicielobjettypeoperationoperateur.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_CODEFAMILLEOPERATION"].ToString();
					clsLogicielobjettypeoperationoperateur.LO_ACTIF = clsDonnee.vogDataReader["LO_ACTIF"].ToString();
					clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsLogicielobjettypeoperationoperateurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsLogicielobjettypeoperationoperateur </returns>
		///<author>Home Technology</author>
		public List<clsLogicielobjettypeoperationoperateur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<clsLogicielobjettypeoperationoperateur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION, LO_ACTIF FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEUR2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new clsLogicielobjettypeoperationoperateur();
					clsLogicielobjettypeoperationoperateur.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsLogicielobjettypeoperationoperateur.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsLogicielobjettypeoperationoperateur.FO_CODEFAMILLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFAMILLEOPERATION"].ToString();
					clsLogicielobjettypeoperationoperateur.LO_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["LO_ACTIF"].ToString();
					clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
				}
				Dataset.Dispose();
			}
		return clsLogicielobjettypeoperationoperateurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEUR2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , LO_ACTIF FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEUR2(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurDroit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);

            vapNomParametre = new string[] {  "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] {  vppCritere[0], vppCritere[1] , vppCritere[2]};
            this.vapRequete = "SELECT * FROM dbo.FT_LOGICIELOBJETTYPEOPERATIONOPERATEURWEBDROIT(@AG_CODEAGENCE,@NF_CODENATUREFAMILLEOPERATION,@OP_CODEOPERATEUR) ORDER BY FO_NUMEROORDRE";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, OP_CODEOPERATEUR, FO_CODEFAMILLEOPERATION)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
                case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION  ";
                vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@OP_CODEOPERATEUR", "@NF_CODENATUREFAMILLEOPERATION" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
                break;

				case 4 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR  AND NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION   AND FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@OP_CODEOPERATEUR","@FO_CODEFAMILLEOPERATION", "@NF_CODENATUREFAMILLEOPERATION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
