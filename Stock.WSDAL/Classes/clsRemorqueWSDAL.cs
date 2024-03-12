using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsRemorqueWSDAL: ITableDAL<clsRemorque>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RM_CODEREMORQUE) AS RM_CODEREMORQUE  FROM dbo.REMORQUE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RM_CODEREMORQUE) AS RM_CODEREMORQUE  FROM dbo.REMORQUE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RM_CODEREMORQUE) AS RM_CODEREMORQUE  FROM dbo.REMORQUE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsRemorque comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsRemorque pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , RM_IMMATRICULATION  FROM dbo.FT_REMORQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsRemorque clsRemorque = new clsRemorque();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRemorque.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsRemorque.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsRemorque.RM_IMMATRICULATION = clsDonnee.vogDataReader["RM_IMMATRICULATION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsRemorque;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRemorque>clsRemorque</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsRemorque clsRemorque)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsRemorque.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsRemorque.EN_CODEENTREPOT ;
			SqlParameter vppParamRM_CODEREMORQUE = new SqlParameter("@RM_CODEREMORQUE1", SqlDbType.VarChar, 25);
			vppParamRM_CODEREMORQUE.Value  = clsRemorque.RM_CODEREMORQUE ;
			SqlParameter vppParamRM_IMMATRICULATION = new SqlParameter("@RM_IMMATRICULATION", SqlDbType.VarChar, 1000);
			vppParamRM_IMMATRICULATION.Value  = clsRemorque.RM_IMMATRICULATION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REMORQUE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @RM_CODEREMORQUE1, @RM_IMMATRICULATION, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamRM_CODEREMORQUE);
			vppSqlCmd.Parameters.Add(vppParamRM_IMMATRICULATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRemorque>clsRemorque</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsRemorque clsRemorque,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsRemorque.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsRemorque.EN_CODEENTREPOT ;
			SqlParameter vppParamRM_CODEREMORQUE = new SqlParameter("@RM_CODEREMORQUE1", SqlDbType.VarChar, 25);
			vppParamRM_CODEREMORQUE.Value  = clsRemorque.RM_CODEREMORQUE ;
			SqlParameter vppParamRM_IMMATRICULATION = new SqlParameter("@RM_IMMATRICULATION", SqlDbType.VarChar, 1000);
			vppParamRM_IMMATRICULATION.Value  = clsRemorque.RM_IMMATRICULATION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REMORQUE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @RM_CODEREMORQUE1, @RM_IMMATRICULATION, @CODECRYPTAGE1, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamRM_CODEREMORQUE);
			vppSqlCmd.Parameters.Add(vppParamRM_IMMATRICULATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REMORQUE  @AG_CODEAGENCE, '', @RM_CODEREMORQUE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRemorque </returns>
		///<author>Home Technology</author>
		public List<clsRemorque> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE, RM_IMMATRICULATION FROM dbo.FT_REMORQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsRemorque> clsRemorques = new List<clsRemorque>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRemorque clsRemorque = new clsRemorque();
					clsRemorque.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsRemorque.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsRemorque.RM_CODEREMORQUE = clsDonnee.vogDataReader["RM_CODEREMORQUE"].ToString();
					clsRemorque.RM_IMMATRICULATION = clsDonnee.vogDataReader["RM_IMMATRICULATION"].ToString();
					clsRemorques.Add(clsRemorque);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsRemorques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRemorque </returns>
		///<author>Home Technology</author>
		public List<clsRemorque> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsRemorque> clsRemorques = new List<clsRemorque>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE, RM_IMMATRICULATION FROM dbo.FT_REMORQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsRemorque clsRemorque = new clsRemorque();
					clsRemorque.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsRemorque.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsRemorque.RM_CODEREMORQUE = Dataset.Tables["TABLE"].Rows[Idx]["RM_CODEREMORQUE"].ToString();
					clsRemorque.RM_IMMATRICULATION = Dataset.Tables["TABLE"].Rows[Idx]["RM_IMMATRICULATION"].ToString();
					clsRemorques.Add(clsRemorque);
				}
				Dataset.Dispose();
			}
		return clsRemorques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REMORQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT RM_CODEREMORQUE , RM_IMMATRICULATION FROM dbo.FT_REMORQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT, RM_CODEREMORQUE)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND RM_CODEREMORQUE=@RM_CODEREMORQUE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RM_CODEREMORQUE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
                case 3:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND ISNULL( RM_CODEREMORQUE,'')  LIKE '%'+ @RM_CODEREMORQUE + '%'  AND ISNULL( RM_IMMATRICULATION,'')  LIKE '%'+ @RM_IMMATRICULATION + '%'    ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RM_CODEREMORQUE", "@RM_IMMATRICULATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                break;
			}
		}
	}
}
