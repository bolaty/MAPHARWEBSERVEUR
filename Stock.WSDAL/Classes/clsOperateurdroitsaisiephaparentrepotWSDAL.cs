using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsOperateurdroitsaisiephaparentrepotWSDAL: ITableDAL<clsOperateurdroitsaisiephaparentrepot>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEURDROITSAISIEPHAPARENTREPOTWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEURDROITSAISIEPHAPARENTREPOTWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEURDROITSAISIEPHAPARENTREPOTWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsOperateurdroitsaisiephaparentrepot comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsOperateurdroitsaisiephaparentrepot pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  FROM dbo.OPERATEURDROITSAISIEPHAPARENTREPOTWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new clsOperateurdroitsaisiephaparentrepot();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsOperateurdroitsaisiephaparentrepot;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOperateurdroitsaisiephaparentrepot>clsOperateurdroitsaisiephaparentrepot</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot)
		{
			//Préparation des paramètres
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsOperateurdroitsaisiephaparentrepot.OP_CODEOPERATEUR ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
			vppParamEN_CODEENTREPOT.Value  = clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO OPERATEURDROITSAISIEPHAPARENTREPOTWEB (  OP_CODEOPERATEUR, EN_CODEENTREPOT) " +
					 "VALUES ( @OP_CODEOPERATEUR1, @EN_CODEENTREPOT) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOperateurdroitsaisiephaparentrepot>clsOperateurdroitsaisiephaparentrepot</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
			vppParamEN_CODEENTREPOT.Value  = clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE OPERATEURDROITSAISIEPHAPARENTREPOTWEB SET " +
							"EN_CODEENTREPOT = @EN_CODEENTREPOT " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  OPERATEURDROITSAISIEPHAPARENTREPOTWEB " + this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitsaisiephaparentrepot </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitsaisiephaparentrepot> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  OP_CODEOPERATEUR, EN_CODEENTREPOT FROM dbo.OPERATEURDROITSAISIEPHAPARENTREPOT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<clsOperateurdroitsaisiephaparentrepot>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new clsOperateurdroitsaisiephaparentrepot();
					clsOperateurdroitsaisiephaparentrepot.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsOperateurdroitsaisiephaparentrepots;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitsaisiephaparentrepot </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitsaisiephaparentrepot> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<clsOperateurdroitsaisiephaparentrepot>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  OP_CODEOPERATEUR, EN_CODEENTREPOT FROM dbo.OPERATEURDROITSAISIEPHAPARENTREPOTWEB " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new clsOperateurdroitsaisiephaparentrepot();
					clsOperateurdroitsaisiephaparentrepot.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroitsaisiephaparentrepot.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
				}
				Dataset.Dispose();
			}
		return clsOperateurdroitsaisiephaparentrepots;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@OP_CODEOPERATEUR", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT *  FROM dbo.[FC_OPERATEURDROITSAISIEPHAPARENTREPOTWEB](@OP_CODEOPERATEUR,@CODECRYPTAGE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT OP_CODEOPERATEUR , EN_CODEENTREPOT FROM dbo.OPERATEURDROITSAISIEPHAPARENTREPOTWEB " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OP_CODEOPERATEUR)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
                this.vapCritere = "WHERE OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                vapNomParametre = new string[] { "@OP_CODEOPERATEUR" };
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE EN_CODEENTREPOT = @EN_CODEENTREPOT AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                vapNomParametre = new string[] {"@EN_CODEENTREPOT", "@OP_CODEOPERATEUR"  };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
