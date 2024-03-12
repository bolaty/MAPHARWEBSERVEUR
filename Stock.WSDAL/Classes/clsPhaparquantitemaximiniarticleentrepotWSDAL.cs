using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparquantitemaximiniarticleentrepotWSDAL: ITableDAL<clsPhaparquantitemaximiniarticleentrepot>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(EN_CODEENTREPOT) AS EN_CODEENTREPOT  FROM dbo.PHAPARQUANTITEMAXIMINIARTICLEENTREPOT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(EN_CODEENTREPOT) AS EN_CODEENTREPOT  FROM dbo.PHAPARQUANTITEMAXIMINIARTICLEENTREPOT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(EN_CODEENTREPOT) AS EN_CODEENTREPOT  FROM dbo.PHAPARQUANTITEMAXIMINIARTICLEENTREPOT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparquantitemaximiniarticleentrepot comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparquantitemaximiniarticleentrepot pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT EN_STOCKMINI  , EN_STOCKMAXI  FROM dbo.FT_PHAPARQUANTITEMAXIMINIARTICLEENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparquantitemaximiniarticleentrepot clsPhaparquantitemaximiniarticleentrepot = new clsPhaparquantitemaximiniarticleentrepot();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMINI = double.Parse(clsDonnee.vogDataReader["EN_STOCKMINI"].ToString());
					clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMAXI = double.Parse(clsDonnee.vogDataReader["EN_STOCKMAXI"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparquantitemaximiniarticleentrepot;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparquantitemaximiniarticleentrepot>clsPhaparquantitemaximiniarticleentrepot</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparquantitemaximiniarticleentrepot clsPhaparquantitemaximiniarticleentrepot)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparquantitemaximiniarticleentrepot.AG_CODEAGENCE;

			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsPhaparquantitemaximiniarticleentrepot.EN_CODEENTREPOT ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparquantitemaximiniarticleentrepot.AR_CODEARTICLE ;
			SqlParameter vppParamEN_STOCKMINI = new SqlParameter("@EN_STOCKMINI", SqlDbType.BigInt);
			vppParamEN_STOCKMINI.Value  = clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMINI ;
			SqlParameter vppParamEN_STOCKMAXI = new SqlParameter("@EN_STOCKMAXI", SqlDbType.BigInt);
			vppParamEN_STOCKMAXI.Value  = clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMAXI ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar,25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparquantitemaximiniarticleentrepot.OP_CODEOPERATEUR;


			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARQUANTITEMAXIMINIARTICLEENTREPOT  @AG_CODEAGENCE,@EN_CODEENTREPOT, @AR_CODEARTICLE, @EN_STOCKMINI, @EN_STOCKMAXI, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamEN_STOCKMINI);
			vppSqlCmd.Parameters.Add(vppParamEN_STOCKMAXI);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparquantitemaximiniarticleentrepot>clsPhaparquantitemaximiniarticleentrepot</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparquantitemaximiniarticleentrepot clsPhaparquantitemaximiniarticleentrepot,params string[] vppCritere)
		{
			//Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparquantitemaximiniarticleentrepot.AG_CODEAGENCE;

			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsPhaparquantitemaximiniarticleentrepot.EN_CODEENTREPOT ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparquantitemaximiniarticleentrepot.AR_CODEARTICLE ;
			SqlParameter vppParamEN_STOCKMINI = new SqlParameter("@EN_STOCKMINI", SqlDbType.BigInt);
			vppParamEN_STOCKMINI.Value  = clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMINI ;
			SqlParameter vppParamEN_STOCKMAXI = new SqlParameter("@EN_STOCKMAXI", SqlDbType.BigInt);
			vppParamEN_STOCKMAXI.Value  = clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMAXI ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparquantitemaximiniarticleentrepot.OP_CODEOPERATEUR;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARQUANTITEMAXIMINIARTICLEENTREPOT  @AG_CODEAGENCE,@EN_CODEENTREPOT, @AR_CODEARTICLE, @EN_STOCKMINI, @EN_STOCKMAXI,@OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamEN_STOCKMINI);
			vppSqlCmd.Parameters.Add(vppParamEN_STOCKMAXI);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARQUANTITEMAXIMINIARTICLEENTREPOT  @AG_CODEAGENCE,@EN_CODEENTREPOT, @AR_CODEARTICLE, '' , '' , '' ,@CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparquantitemaximiniarticleentrepot </returns>
		///<author>Home Technology</author>
		public List<clsPhaparquantitemaximiniarticleentrepot> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  EN_CODEENTREPOT, AR_CODEARTICLE, EN_STOCKMINI, EN_STOCKMAXI FROM dbo.FT_PHAPARQUANTITEMAXIMINIARTICLEENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparquantitemaximiniarticleentrepot> clsPhaparquantitemaximiniarticleentrepots = new List<clsPhaparquantitemaximiniarticleentrepot>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparquantitemaximiniarticleentrepot clsPhaparquantitemaximiniarticleentrepot = new clsPhaparquantitemaximiniarticleentrepot();
					clsPhaparquantitemaximiniarticleentrepot.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsPhaparquantitemaximiniarticleentrepot.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMINI = double.Parse(clsDonnee.vogDataReader["EN_STOCKMINI"].ToString());
					clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMAXI = double.Parse(clsDonnee.vogDataReader["EN_STOCKMAXI"].ToString());
					clsPhaparquantitemaximiniarticleentrepots.Add(clsPhaparquantitemaximiniarticleentrepot);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparquantitemaximiniarticleentrepots;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparquantitemaximiniarticleentrepot </returns>
		///<author>Home Technology</author>
		public List<clsPhaparquantitemaximiniarticleentrepot> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparquantitemaximiniarticleentrepot> clsPhaparquantitemaximiniarticleentrepots = new List<clsPhaparquantitemaximiniarticleentrepot>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  EN_CODEENTREPOT, AR_CODEARTICLE, EN_STOCKMINI, EN_STOCKMAXI FROM dbo.FT_PHAPARQUANTITEMAXIMINIARTICLEENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparquantitemaximiniarticleentrepot clsPhaparquantitemaximiniarticleentrepot = new clsPhaparquantitemaximiniarticleentrepot();
					clsPhaparquantitemaximiniarticleentrepot.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsPhaparquantitemaximiniarticleentrepot.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMINI = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EN_STOCKMINI"].ToString());
					clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMAXI = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EN_STOCKMAXI"].ToString());
					clsPhaparquantitemaximiniarticleentrepots.Add(clsPhaparquantitemaximiniarticleentrepot);
				}
				Dataset.Dispose();
			}
		return clsPhaparquantitemaximiniarticleentrepots;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARQUANTITEMAXIMINIARTICLEENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EN_CODEENTREPOT, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT EN_CODEENTREPOT , EN_STOCKMINI FROM dbo.FT_PHAPARQUANTITEMAXIMINIARTICLEENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :EN_CODEENTREPOT, AR_CODEARTICLE)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE   AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE   AG_CODEAGENCE=@AG_CODEAGENCE AND  EN_CODEENTREPOT=@EN_CODEENTREPOT AND AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
