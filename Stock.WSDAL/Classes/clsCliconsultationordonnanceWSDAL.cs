using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliconsultationordonnanceWSDAL: ITableDAL<clsCliconsultationordonnance>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultationordonnance comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultationordonnance pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CT_CODECATEGORIEORDONNANCE  , OR_PRESCRIPTION  , TI_IDTIERSMEDECIN  , OP_CODEOPERATEUR  FROM dbo.FT_CLICONSULTATIONORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliconsultationordonnance clsCliconsultationordonnance = new clsCliconsultationordonnance();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationordonnance.CT_CODECATEGORIEORDONNANCE = clsDonnee.vogDataReader["CT_CODECATEGORIEORDONNANCE"].ToString();
					clsCliconsultationordonnance.OR_PRESCRIPTION = clsDonnee.vogDataReader["OR_PRESCRIPTION"].ToString();
					clsCliconsultationordonnance.TI_IDTIERSMEDECIN = clsDonnee.vogDataReader["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultationordonnance.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliconsultationordonnance;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationordonnance>clsCliconsultationordonnance</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliconsultationordonnance clsCliconsultationordonnance)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationordonnance.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationordonnance.CO_CODECONSULTATION ;
			SqlParameter vppParamOR_NUMSEQUENCE = new SqlParameter("@OR_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamOR_NUMSEQUENCE.Value  = clsCliconsultationordonnance.OR_NUMSEQUENCE ;
			SqlParameter vppParamOR_DATESAISIE = new SqlParameter("@OR_DATESAISIE", SqlDbType.DateTime);
			vppParamOR_DATESAISIE.Value  = clsCliconsultationordonnance.OR_DATESAISIE ;
			SqlParameter vppParamCT_CODECATEGORIEORDONNANCE = new SqlParameter("@CT_CODECATEGORIEORDONNANCE", SqlDbType.VarChar, 3);
			vppParamCT_CODECATEGORIEORDONNANCE.Value  = clsCliconsultationordonnance.CT_CODECATEGORIEORDONNANCE ;
			SqlParameter vppParamOR_PRESCRIPTION = new SqlParameter("@OR_PRESCRIPTION", SqlDbType.VarChar, 1000);
			vppParamOR_PRESCRIPTION.Value  = clsCliconsultationordonnance.OR_PRESCRIPTION ;
			SqlParameter vppParamTI_IDTIERSMEDECIN = new SqlParameter("@TI_IDTIERSMEDECIN", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECIN.Value  = clsCliconsultationordonnance.TI_IDTIERSMEDECIN ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationordonnance.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONORDONNANCE  @AG_CODEAGENCE, @CO_CODECONSULTATION, @OR_NUMSEQUENCE, @OR_DATESAISIE, @CT_CODECATEGORIEORDONNANCE, @OR_PRESCRIPTION, @TI_IDTIERSMEDECIN, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamOR_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamOR_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCT_CODECATEGORIEORDONNANCE);
			vppSqlCmd.Parameters.Add(vppParamOR_PRESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationordonnance>clsCliconsultationordonnance</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliconsultationordonnance clsCliconsultationordonnance,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationordonnance.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationordonnance.CO_CODECONSULTATION ;
			SqlParameter vppParamOR_NUMSEQUENCE = new SqlParameter("@OR_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamOR_NUMSEQUENCE.Value  = clsCliconsultationordonnance.OR_NUMSEQUENCE ;
			SqlParameter vppParamOR_DATESAISIE = new SqlParameter("@OR_DATESAISIE", SqlDbType.DateTime);
			vppParamOR_DATESAISIE.Value  = clsCliconsultationordonnance.OR_DATESAISIE ;
			SqlParameter vppParamCT_CODECATEGORIEORDONNANCE = new SqlParameter("@CT_CODECATEGORIEORDONNANCE", SqlDbType.VarChar, 3);
			vppParamCT_CODECATEGORIEORDONNANCE.Value  = clsCliconsultationordonnance.CT_CODECATEGORIEORDONNANCE ;
			SqlParameter vppParamOR_PRESCRIPTION = new SqlParameter("@OR_PRESCRIPTION", SqlDbType.VarChar, 1000);
			vppParamOR_PRESCRIPTION.Value  = clsCliconsultationordonnance.OR_PRESCRIPTION ;
			SqlParameter vppParamTI_IDTIERSMEDECIN = new SqlParameter("@TI_IDTIERSMEDECIN", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECIN.Value  = clsCliconsultationordonnance.TI_IDTIERSMEDECIN ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationordonnance.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONORDONNANCE  @AG_CODEAGENCE, @CO_CODECONSULTATION, @OR_NUMSEQUENCE, @OR_DATESAISIE, @CT_CODECATEGORIEORDONNANCE, @OR_PRESCRIPTION, @TI_IDTIERSMEDECIN, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamOR_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamOR_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCT_CODECATEGORIEORDONNANCE);
			vppSqlCmd.Parameters.Add(vppParamOR_PRESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONORDONNANCE  @AG_CODEAGENCE, @CO_CODECONSULTATION, @OR_NUMSEQUENCE, @OR_DATESAISIE,'', '' , '' , '', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationordonnance </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationordonnance> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OR_PRESCRIPTION, TI_IDTIERSMEDECIN, OP_CODEOPERATEUR FROM dbo.FT_CLICONSULTATIONORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliconsultationordonnance> clsCliconsultationordonnances = new List<clsCliconsultationordonnance>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationordonnance clsCliconsultationordonnance = new clsCliconsultationordonnance();
					clsCliconsultationordonnance.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultationordonnance.CO_CODECONSULTATION = clsDonnee.vogDataReader["CO_CODECONSULTATION"].ToString();
					clsCliconsultationordonnance.OR_NUMSEQUENCE = clsDonnee.vogDataReader["OR_NUMSEQUENCE"].ToString();
					clsCliconsultationordonnance.OR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["OR_DATESAISIE"].ToString());
					clsCliconsultationordonnance.CT_CODECATEGORIEORDONNANCE = clsDonnee.vogDataReader["CT_CODECATEGORIEORDONNANCE"].ToString();
					clsCliconsultationordonnance.OR_PRESCRIPTION = clsDonnee.vogDataReader["OR_PRESCRIPTION"].ToString();
					clsCliconsultationordonnance.TI_IDTIERSMEDECIN = clsDonnee.vogDataReader["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultationordonnance.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationordonnances.Add(clsCliconsultationordonnance);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliconsultationordonnances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationordonnance </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationordonnance> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliconsultationordonnance> clsCliconsultationordonnances = new List<clsCliconsultationordonnance>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OR_PRESCRIPTION, TI_IDTIERSMEDECIN, OP_CODEOPERATEUR FROM dbo.FT_CLICONSULTATIONORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliconsultationordonnance clsCliconsultationordonnance = new clsCliconsultationordonnance();
					clsCliconsultationordonnance.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliconsultationordonnance.CO_CODECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECONSULTATION"].ToString();
					clsCliconsultationordonnance.OR_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["OR_NUMSEQUENCE"].ToString();
					clsCliconsultationordonnance.OR_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OR_DATESAISIE"].ToString());
					clsCliconsultationordonnance.CT_CODECATEGORIEORDONNANCE = Dataset.Tables["TABLE"].Rows[Idx]["CT_CODECATEGORIEORDONNANCE"].ToString();
					clsCliconsultationordonnance.OR_PRESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["OR_PRESCRIPTION"].ToString();
					clsCliconsultationordonnance.TI_IDTIERSMEDECIN = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultationordonnance.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationordonnances.Add(clsCliconsultationordonnance);
				}
				Dataset.Dispose();
			}
		return clsCliconsultationordonnances;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICONSULTATIONORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , OR_PRESCRIPTION FROM dbo.FT_CLICONSULTATIONORDONNANCE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CO_CODECONSULTATION, OR_NUMSEQUENCE, OR_DATESAISIE, CT_CODECATEGORIEORDONNANCE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND OR_NUMSEQUENCE=@OR_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@OR_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND OR_NUMSEQUENCE=@OR_NUMSEQUENCE AND OR_DATESAISIE=@OR_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@OR_NUMSEQUENCE","@OR_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND OR_NUMSEQUENCE=@OR_NUMSEQUENCE AND OR_DATESAISIE=@OR_DATESAISIE AND CT_CODECATEGORIEORDONNANCE=@CT_CODECATEGORIEORDONNANCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@OR_NUMSEQUENCE","@OR_DATESAISIE","@CT_CODECATEGORIEORDONNANCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND OR_NUMSEQUENCE=@OR_NUMSEQUENCE AND OR_DATESAISIE=@OR_DATESAISIE AND CT_CODECATEGORIEORDONNANCE=@CT_CODECATEGORIEORDONNANCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@OR_NUMSEQUENCE","@OR_DATESAISIE","@CT_CODECATEGORIEORDONNANCE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
