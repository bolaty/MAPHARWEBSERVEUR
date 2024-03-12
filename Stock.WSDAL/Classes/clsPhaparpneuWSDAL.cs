using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpneuWSDAL: ITableDAL<clsPhaparpneu>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PN_CODEPNEU) AS PN_CODEPNEU  FROM dbo.PHAPARPNEU " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PN_CODEPNEU) AS PN_CODEPNEU  FROM dbo.PHAPARPNEU " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PN_CODEPNEU) AS PN_CODEPNEU  FROM dbo.PHAPARPNEU" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpneu comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpneu pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE  , TP_CODETYPEPNEU  , PN_TAILLE  , PN_DESCRIPTION  FROM dbo.FT_PHAPARPNEU(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpneu clsPhaparpneu = new clsPhaparpneu();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpneu.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPhaparpneu.TP_CODETYPEPNEU = clsDonnee.vogDataReader["TP_CODETYPEPNEU"].ToString();
					clsPhaparpneu.PN_TAILLE = int.Parse(clsDonnee.vogDataReader["PN_TAILLE"].ToString());
					clsPhaparpneu.PN_DESCRIPTION = clsDonnee.vogDataReader["PN_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpneu;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpneu>clsPhaparpneu</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpneu clsPhaparpneu)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparpneu.AG_CODEAGENCE;
			SqlParameter vppParamPN_CODEPNEU = new SqlParameter("@PN_CODEPNEU", SqlDbType.VarChar, 25);
			vppParamPN_CODEPNEU.Value  = clsPhaparpneu.PN_CODEPNEU ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparpneu.AR_CODEARTICLE ;
            SqlParameter vppParamTP_CODETYPEPNEU = new SqlParameter("@TP_CODETYPEPNEU", SqlDbType.VarChar, 150);
            vppParamTP_CODETYPEPNEU.Value = clsPhaparpneu.TP_CODETYPEPNEU;
			SqlParameter vppParamPN_TAILLE = new SqlParameter("@PN_TAILLE", SqlDbType.Int);
			vppParamPN_TAILLE.Value  = clsPhaparpneu.PN_TAILLE ;
			SqlParameter vppParamPN_DESCRIPTION = new SqlParameter("@PN_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamPN_DESCRIPTION.Value  = clsPhaparpneu.PN_DESCRIPTION ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparpneu.OP_CODEOPERATEUR;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARPNEU  @AG_CODEAGENCE1,@PN_CODEPNEU, @AR_CODEARTICLE, @TP_CODETYPEPNEU, @PN_TAILLE, @PN_DESCRIPTION, @OP_CODEOPERATEUR, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPN_CODEPNEU);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPNEU);
			vppSqlCmd.Parameters.Add(vppParamPN_TAILLE);
			vppSqlCmd.Parameters.Add(vppParamPN_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpneu>clsPhaparpneu</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpneu clsPhaparpneu,params string[] vppCritere)
		{
			//Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparpneu.AG_CODEAGENCE;

			SqlParameter vppParamPN_CODEPNEU = new SqlParameter("@PN_CODEPNEU", SqlDbType.VarChar, 25);
			vppParamPN_CODEPNEU.Value  = clsPhaparpneu.PN_CODEPNEU ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparpneu.AR_CODEARTICLE ;
            SqlParameter vppParamTP_CODETYPEPNEU = new SqlParameter("@TP_CODETYPEPNEU", SqlDbType.VarChar, 150);
            vppParamTP_CODETYPEPNEU.Value = clsPhaparpneu.TP_CODETYPEPNEU;
			SqlParameter vppParamPN_TAILLE = new SqlParameter("@PN_TAILLE", SqlDbType.Int);
			vppParamPN_TAILLE.Value  = clsPhaparpneu.PN_TAILLE ;
			SqlParameter vppParamPN_DESCRIPTION = new SqlParameter("@PN_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamPN_DESCRIPTION.Value  = clsPhaparpneu.PN_DESCRIPTION ;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparpneu.OP_CODEOPERATEUR;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARPNEU  @AG_CODEAGENCE,@PN_CODEPNEU, @AR_CODEARTICLE, @TP_CODETYPEPNEU, @PN_TAILLE, @PN_DESCRIPTION, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPN_CODEPNEU);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPEPNEU);
			vppSqlCmd.Parameters.Add(vppParamPN_TAILLE);
			vppSqlCmd.Parameters.Add(vppParamPN_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARPNEU  @AG_CODEAGENCE,@PN_CODEPNEU, '' , '' , '' , '' , '' ,@CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpneu </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpneu> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  PN_CODEPNEU, AR_CODEARTICLE, TP_CODETYPEPNEU, PN_TAILLE, PN_DESCRIPTION FROM dbo.FT_PHAPARPNEU(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpneu> clsPhaparpneus = new List<clsPhaparpneu>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpneu clsPhaparpneu = new clsPhaparpneu();
					clsPhaparpneu.PN_CODEPNEU = clsDonnee.vogDataReader["PN_CODEPNEU"].ToString();
					clsPhaparpneu.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPhaparpneu.TP_CODETYPEPNEU = clsDonnee.vogDataReader["TP_CODETYPEPNEU"].ToString();
					clsPhaparpneu.PN_TAILLE = int.Parse(clsDonnee.vogDataReader["PN_TAILLE"].ToString());
					clsPhaparpneu.PN_DESCRIPTION = clsDonnee.vogDataReader["PN_DESCRIPTION"].ToString();
					clsPhaparpneus.Add(clsPhaparpneu);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpneus;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpneu </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpneu> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpneu> clsPhaparpneus = new List<clsPhaparpneu>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  PN_CODEPNEU, AR_CODEARTICLE, TP_CODETYPEPNEU, PN_TAILLE, PN_DESCRIPTION FROM dbo.FT_PHAPARPNEU(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpneu clsPhaparpneu = new clsPhaparpneu();
					clsPhaparpneu.PN_CODEPNEU = Dataset.Tables["TABLE"].Rows[Idx]["PN_CODEPNEU"].ToString();
					clsPhaparpneu.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
                    clsPhaparpneu.TP_CODETYPEPNEU = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPEPNEU"].ToString();
					clsPhaparpneu.PN_TAILLE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PN_TAILLE"].ToString());
					clsPhaparpneu.PN_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["PN_DESCRIPTION"].ToString();
					clsPhaparpneus.Add(clsPhaparpneu);
				}
				Dataset.Dispose();
			}
		return clsPhaparpneus;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPNEU(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PN_CODEPNEU ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT PN_CODEPNEU , AR_CODEARTICLE FROM dbo.FT_PHAPARPNEU(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PN_CODEPNEU)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PN_CODEPNEU=@PN_CODEPNEU";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PN_CODEPNEU" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
