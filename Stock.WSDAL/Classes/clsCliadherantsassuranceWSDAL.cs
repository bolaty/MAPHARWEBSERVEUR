using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliadherantsassuranceWSDAL: ITableDAL<clsCliadherantsassurance>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AS_DATESAISIE) AS AS_DATESAISIE  FROM dbo.FT_CLIADHERANTSASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AS_DATESAISIE) AS AS_DATESAISIE  FROM dbo.FT_CLIADHERANTSASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AS_DATESAISIE) AS AS_DATESAISIE  FROM dbo.FT_CLIADHERANTSASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliadherantsassurance comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliadherantsassurance pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , TI_IDTIERSADHERANT  , AP_CODEPRODUIT  , AS_DATEADHESION  , AS_DATERESILIATION  , AS_TAUX  , AS_MONTANT  , AS_PLAFOND  , OP_CODEOPERATEUR  FROM dbo.FT_CLIADHERANTSASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliadherantsassurance clsCliadherantsassurance = new clsCliadherantsassurance();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliadherantsassurance.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliadherantsassurance.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCliadherantsassurance.TI_IDTIERSADHERANT = clsDonnee.vogDataReader["TI_IDTIERSADHERANT"].ToString();
					clsCliadherantsassurance.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsCliadherantsassurance.AS_DATEADHESION = DateTime.Parse(clsDonnee.vogDataReader["AS_DATEADHESION"].ToString());
					clsCliadherantsassurance.AS_DATERESILIATION = DateTime.Parse(clsDonnee.vogDataReader["AS_DATERESILIATION"].ToString());
					clsCliadherantsassurance.AS_TAUX = double.Parse(clsDonnee.vogDataReader["AS_TAUX"].ToString());
					clsCliadherantsassurance.AS_MONTANT = double.Parse(clsDonnee.vogDataReader["AS_MONTANT"].ToString());
					clsCliadherantsassurance.AS_PLAFOND = double.Parse(clsDonnee.vogDataReader["AS_PLAFOND"].ToString());
					clsCliadherantsassurance.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliadherantsassurance;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliadherantsassurance>clsCliadherantsassurance</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliadherantsassurance clsCliadherantsassurance)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliadherantsassurance.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCliadherantsassurance.EN_CODEENTREPOT ;
			SqlParameter vppParamTI_IDTIERSADHERANT = new SqlParameter("@TI_IDTIERSADHERANT", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSADHERANT.Value  = clsCliadherantsassurance.TI_IDTIERSADHERANT ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsCliadherantsassurance.AP_CODEPRODUIT ;
			SqlParameter vppParamAS_DATESAISIE = new SqlParameter("@AS_DATESAISIE", SqlDbType.DateTime);
			vppParamAS_DATESAISIE.Value  = clsCliadherantsassurance.AS_DATESAISIE ;
			SqlParameter vppParamAS_DATEADHESION = new SqlParameter("@AS_DATEADHESION", SqlDbType.DateTime);
			vppParamAS_DATEADHESION.Value  = clsCliadherantsassurance.AS_DATEADHESION ;
			SqlParameter vppParamAS_DATERESILIATION = new SqlParameter("@AS_DATERESILIATION", SqlDbType.DateTime);
			vppParamAS_DATERESILIATION.Value  = clsCliadherantsassurance.AS_DATERESILIATION ;
			SqlParameter vppParamAS_TAUX = new SqlParameter("@AS_TAUX", SqlDbType.Float);
			vppParamAS_TAUX.Value  = clsCliadherantsassurance.AS_TAUX ;
			SqlParameter vppParamAS_MONTANT = new SqlParameter("@AS_MONTANT", SqlDbType.Money);
			vppParamAS_MONTANT.Value  = clsCliadherantsassurance.AS_MONTANT ;
			SqlParameter vppParamAS_PLAFOND = new SqlParameter("@AS_PLAFOND", SqlDbType.Money);
			vppParamAS_PLAFOND.Value  = clsCliadherantsassurance.AS_PLAFOND ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCliadherantsassurance.OP_CODEOPERATEUR ;

			SqlParameter vppParamAS_MATRICULE = new SqlParameter("@AS_MATRICULE", SqlDbType.VarChar, 150);
            vppParamAS_MATRICULE.Value  = clsCliadherantsassurance.AS_MATRICULE;
            if (clsCliadherantsassurance.AS_MATRICULE == null) vppParamAS_MATRICULE.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIADHERANTSASSURANCE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @TI_IDTIERSADHERANT, @AP_CODEPRODUIT, @AS_DATESAISIE, @AS_DATEADHESION, @AS_DATERESILIATION, @AS_TAUX, @AS_MONTANT, @AS_PLAFOND, @OP_CODEOPERATEUR,@AS_MATRICULE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSADHERANT);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamAS_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAS_DATEADHESION);
			vppSqlCmd.Parameters.Add(vppParamAS_DATERESILIATION);
			vppSqlCmd.Parameters.Add(vppParamAS_TAUX);
			vppSqlCmd.Parameters.Add(vppParamAS_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamAS_PLAFOND);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAS_MATRICULE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliadherantsassurance>clsCliadherantsassurance</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliadherantsassurance clsCliadherantsassurance,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliadherantsassurance.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCliadherantsassurance.EN_CODEENTREPOT ;
			SqlParameter vppParamTI_IDTIERSADHERANT = new SqlParameter("@TI_IDTIERSADHERANT", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERSADHERANT.Value  = clsCliadherantsassurance.TI_IDTIERSADHERANT ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsCliadherantsassurance.AP_CODEPRODUIT ;
			SqlParameter vppParamAS_DATESAISIE = new SqlParameter("@AS_DATESAISIE", SqlDbType.DateTime);
			vppParamAS_DATESAISIE.Value  = clsCliadherantsassurance.AS_DATESAISIE ;
			SqlParameter vppParamAS_DATEADHESION = new SqlParameter("@AS_DATEADHESION", SqlDbType.DateTime);
			vppParamAS_DATEADHESION.Value  = clsCliadherantsassurance.AS_DATEADHESION ;
			SqlParameter vppParamAS_DATERESILIATION = new SqlParameter("@AS_DATERESILIATION", SqlDbType.DateTime);
			vppParamAS_DATERESILIATION.Value  = clsCliadherantsassurance.AS_DATERESILIATION ;
			SqlParameter vppParamAS_TAUX = new SqlParameter("@AS_TAUX", SqlDbType.Float);
			vppParamAS_TAUX.Value  = clsCliadherantsassurance.AS_TAUX ;
			SqlParameter vppParamAS_MONTANT = new SqlParameter("@AS_MONTANT", SqlDbType.Money);
			vppParamAS_MONTANT.Value  = clsCliadherantsassurance.AS_MONTANT ;
			SqlParameter vppParamAS_PLAFOND = new SqlParameter("@AS_PLAFOND", SqlDbType.Money);
			vppParamAS_PLAFOND.Value  = clsCliadherantsassurance.AS_PLAFOND ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCliadherantsassurance.OP_CODEOPERATEUR ;

            SqlParameter vppParamAS_MATRICULE = new SqlParameter("@AS_MATRICULE", SqlDbType.VarChar, 150);
            vppParamAS_MATRICULE.Value = clsCliadherantsassurance.AS_MATRICULE;
            if (clsCliadherantsassurance.AS_MATRICULE == null) vppParamAS_MATRICULE.Value = DBNull.Value;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIADHERANTSASSURANCE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @TI_IDTIERSADHERANT, @AP_CODEPRODUIT, @AS_DATESAISIE, @AS_DATEADHESION, @AS_DATERESILIATION, @AS_TAUX, @AS_MONTANT, @AS_PLAFOND, @OP_CODEOPERATEUR,@AS_MATRICULE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSADHERANT);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamAS_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAS_DATEADHESION);
			vppSqlCmd.Parameters.Add(vppParamAS_DATERESILIATION);
			vppSqlCmd.Parameters.Add(vppParamAS_TAUX);
			vppSqlCmd.Parameters.Add(vppParamAS_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamAS_PLAFOND);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAS_MATRICULE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLIADHERANTSASSURANCE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @TI_IDTIERSADHERANT, @AP_CODEPRODUIT, '', '' , '' , '' , '' , '' , '','', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliadherantsassurance </returns>
		///<author>Home Technology</author>
		public List<clsCliadherantsassurance> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, AS_DATEADHESION, AS_DATERESILIATION, AS_TAUX, AS_MONTANT, AS_PLAFOND, OP_CODEOPERATEUR FROM dbo.FT_CLIADHERANTSASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliadherantsassurance> clsCliadherantsassurances = new List<clsCliadherantsassurance>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliadherantsassurance clsCliadherantsassurance = new clsCliadherantsassurance();
					clsCliadherantsassurance.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliadherantsassurance.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCliadherantsassurance.TI_IDTIERSADHERANT = clsDonnee.vogDataReader["TI_IDTIERSADHERANT"].ToString();
					clsCliadherantsassurance.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsCliadherantsassurance.AS_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["AS_DATESAISIE"].ToString());
					clsCliadherantsassurance.AS_DATEADHESION = DateTime.Parse(clsDonnee.vogDataReader["AS_DATEADHESION"].ToString());
					clsCliadherantsassurance.AS_DATERESILIATION = DateTime.Parse(clsDonnee.vogDataReader["AS_DATERESILIATION"].ToString());
					clsCliadherantsassurance.AS_TAUX = float.Parse(clsDonnee.vogDataReader["AS_TAUX"].ToString());
					clsCliadherantsassurance.AS_MONTANT = double.Parse(clsDonnee.vogDataReader["AS_MONTANT"].ToString());
					clsCliadherantsassurance.AS_PLAFOND = double.Parse(clsDonnee.vogDataReader["AS_PLAFOND"].ToString());
					clsCliadherantsassurance.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliadherantsassurances.Add(clsCliadherantsassurance);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliadherantsassurances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliadherantsassurance </returns>
		///<author>Home Technology</author>
		public List<clsCliadherantsassurance> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliadherantsassurance> clsCliadherantsassurances = new List<clsCliadherantsassurance>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, AS_DATEADHESION, AS_DATERESILIATION, AS_TAUX, AS_MONTANT, AS_PLAFOND, OP_CODEOPERATEUR FROM dbo.FT_CLIADHERANTSASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliadherantsassurance clsCliadherantsassurance = new clsCliadherantsassurance();
					clsCliadherantsassurance.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliadherantsassurance.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCliadherantsassurance.TI_IDTIERSADHERANT = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSADHERANT"].ToString();
					clsCliadherantsassurance.AP_CODEPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["AP_CODEPRODUIT"].ToString();
					clsCliadherantsassurance.AS_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AS_DATESAISIE"].ToString());
					clsCliadherantsassurance.AS_DATEADHESION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AS_DATEADHESION"].ToString());
					clsCliadherantsassurance.AS_DATERESILIATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AS_DATERESILIATION"].ToString());
					clsCliadherantsassurance.AS_TAUX = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AS_TAUX"].ToString());
					clsCliadherantsassurance.AS_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AS_MONTANT"].ToString());
					clsCliadherantsassurance.AS_PLAFOND = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AS_PLAFOND"].ToString());
					clsCliadherantsassurance.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliadherantsassurances.Add(clsCliadherantsassurance);
				}
				Dataset.Dispose();
			}
		return clsCliadherantsassurances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AP_CODEPRODUIT", "@AS_DATESAISIE1", "@AS_DATESAISIE2", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4] , vppCritere[5] };
            this.vapRequete = "EXEC [dbo].[PS_CLIADHERANTSASSURANCE] @AG_CODEAGENCE,@EN_CODEENTREPOT,@AP_CODEPRODUIT,@AS_DATESAISIE1,@AS_DATESAISIE2,@TYPEOPERATION, @CODECRYPTAGE ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetProduitAdherant(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_IDTIERSASSUREUR", "@TI_IDTIERSADHERANT", "@AS_DATESAISIE1", "@AS_DATESAISIE2", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4] , vppCritere[5] , vppCritere[6] };
            this.vapRequete = "EXEC [dbo].[PS_CLIADHERANTSASSURANCEPRODUITS] @AG_CODEAGENCE,@EN_CODEENTREPOT,@TI_IDTIERSASSUREUR,@TI_IDTIERSADHERANT,@AS_DATESAISIE1,@AS_DATESAISIE2,@TYPEOPERATION, @CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetProduitAdherantPlafondArticle(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AP_CODEPRODUIT", "@AR_CODEARTICLE", "@TI_IDTIERSADHERANT", "@AS_DATESAISIE1", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4] , vppCritere[5] , vppCritere[6] };
            this.vapRequete = "EXEC [dbo].[PS_CLIADHERANTSASSURANCEPRODUITSARTICLEPLAFOND] @AG_CODEAGENCE,@EN_CODEENTREPOT,@AP_CODEPRODUIT,@AR_CODEARTICLE,@TI_IDTIERSADHERANT,@AS_DATESAISIE1,@TYPEOPERATION, @CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }




		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AS_DATESAISIE , AS_DATEADHESION FROM dbo.FT_CLIADHERANTSASSURANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetCouvertureAssurance(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDTIERSADHERANT", "@AP_CODEPRODUIT", "@AR_CODEARTICLE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] };
            this.vapRequete = "SELECT * FROM  [dbo].[FC_SITUATIONASSURANCE] (@AG_CODEAGENCE,@TI_IDTIERSADHERANT,@AP_CODEPRODUIT,@AR_CODEARTICLE,@CODECRYPTAGE)" ;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }



		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT, TI_IDTIERSADHERANT, AP_CODEPRODUIT, AS_DATESAISIE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND AP_CODEPRODUIT=@AP_CODEPRODUIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT", "@AP_CODEPRODUIT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND AP_CODEPRODUIT=@AP_CODEPRODUIT AND TI_IDTIERSADHERANT=@TI_IDTIERSADHERANT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT", "@AP_CODEPRODUIT", "@TI_IDTIERSADHERANT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_IDTIERSADHERANT=@TI_IDTIERSADHERANT AND AP_CODEPRODUIT=@AP_CODEPRODUIT AND AS_DATESAISIE=@AS_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@TI_IDTIERSADHERANT","@AP_CODEPRODUIT","@AS_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_IDTIERSADHERANT=@TI_IDTIERSADHERANT AND AP_CODEPRODUIT=@AP_CODEPRODUIT AND AS_DATESAISIE=@AS_DATESAISIE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@TI_IDTIERSADHERANT","@AP_CODEPRODUIT","@AS_DATESAISIE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
