using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliconsultationrendevousWSDAL: ITableDAL<clsCliconsultationrendevous>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONRENDEVOUS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONRENDEVOUS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONRENDEVOUS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultationrendevous comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultationrendevous pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_IDTIERSMEDECIN  , OP_CODEOPERATEUR  , SR_CODESERVICE  , RD_DATERDV  , RD_HEURERDV  , RD_MOTIFRDV  , RD_DATEPRESENCERDV  , RD_HEUREPRESENCERDV  FROM dbo.FT_CLICONSULTATIONRENDEVOUS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliconsultationrendevous clsCliconsultationrendevous = new clsCliconsultationrendevous();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationrendevous.TI_IDTIERSMEDECIN = clsDonnee.vogDataReader["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultationrendevous.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationrendevous.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsCliconsultationrendevous.RD_DATERDV = DateTime.Parse(clsDonnee.vogDataReader["RD_DATERDV"].ToString());
					clsCliconsultationrendevous.RD_HEURERDV = DateTime.Parse(clsDonnee.vogDataReader["RD_HEURERDV"].ToString());
					clsCliconsultationrendevous.RD_MOTIFRDV = clsDonnee.vogDataReader["RD_MOTIFRDV"].ToString();
					clsCliconsultationrendevous.RD_DATEPRESENCERDV = DateTime.Parse(clsDonnee.vogDataReader["RD_DATEPRESENCERDV"].ToString());
					clsCliconsultationrendevous.RD_HEUREPRESENCERDV = DateTime.Parse(clsDonnee.vogDataReader["RD_HEUREPRESENCERDV"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliconsultationrendevous;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationrendevous>clsCliconsultationrendevous</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliconsultationrendevous clsCliconsultationrendevous)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationrendevous.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationrendevous.CO_CODECONSULTATION ;
			SqlParameter vppParamRD_NUMSEQUENCE = new SqlParameter("@RD_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamRD_NUMSEQUENCE.Value  = clsCliconsultationrendevous.RD_NUMSEQUENCE ;
			SqlParameter vppParamRD_DATESAISIE = new SqlParameter("@RD_DATESAISIE", SqlDbType.DateTime);
			vppParamRD_DATESAISIE.Value  = clsCliconsultationrendevous.RD_DATESAISIE ;
			SqlParameter vppParamTI_IDTIERSMEDECIN = new SqlParameter("@TI_IDTIERSMEDECIN", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECIN.Value  = clsCliconsultationrendevous.TI_IDTIERSMEDECIN ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationrendevous.OP_CODEOPERATEUR ;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsCliconsultationrendevous.SR_CODESERVICE ;
			SqlParameter vppParamRD_DATERDV = new SqlParameter("@RD_DATERDV", SqlDbType.DateTime);
			vppParamRD_DATERDV.Value  = clsCliconsultationrendevous.RD_DATERDV ;
			SqlParameter vppParamRD_HEURERDV = new SqlParameter("@RD_HEURERDV", SqlDbType.DateTime);
			vppParamRD_HEURERDV.Value  = clsCliconsultationrendevous.RD_HEURERDV ;
			SqlParameter vppParamRD_MOTIFRDV = new SqlParameter("@RD_MOTIFRDV", SqlDbType.VarChar, 1000);
			vppParamRD_MOTIFRDV.Value  = clsCliconsultationrendevous.RD_MOTIFRDV ;
			SqlParameter vppParamRD_DATEPRESENCERDV = new SqlParameter("@RD_DATEPRESENCERDV", SqlDbType.DateTime);
			vppParamRD_DATEPRESENCERDV.Value  = clsCliconsultationrendevous.RD_DATEPRESENCERDV ;
            if (clsCliconsultationrendevous.RD_DATEPRESENCERDV < DateTime.Parse("01/01/1900")) vppParamRD_DATEPRESENCERDV.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamRD_HEUREPRESENCERDV = new SqlParameter("@RD_HEUREPRESENCERDV", SqlDbType.DateTime);
			vppParamRD_HEUREPRESENCERDV.Value  = clsCliconsultationrendevous.RD_HEUREPRESENCERDV ;
            if (clsCliconsultationrendevous.RD_HEUREPRESENCERDV < DateTime.Parse("01/01/1900")) vppParamRD_HEUREPRESENCERDV.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONRENDEVOUS  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RD_NUMSEQUENCE, @RD_DATESAISIE, @TI_IDTIERSMEDECIN, @OP_CODEOPERATEUR, @SR_CODESERVICE, @RD_DATERDV, @RD_HEURERDV, @RD_MOTIFRDV, @RD_DATEPRESENCERDV, @RD_HEUREPRESENCERDV, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamRD_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamRD_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamRD_DATERDV);
			vppSqlCmd.Parameters.Add(vppParamRD_HEURERDV);
			vppSqlCmd.Parameters.Add(vppParamRD_MOTIFRDV);
			vppSqlCmd.Parameters.Add(vppParamRD_DATEPRESENCERDV);
			vppSqlCmd.Parameters.Add(vppParamRD_HEUREPRESENCERDV);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationrendevous>clsCliconsultationrendevous</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliconsultationrendevous clsCliconsultationrendevous,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationrendevous.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationrendevous.CO_CODECONSULTATION ;
			SqlParameter vppParamRD_NUMSEQUENCE = new SqlParameter("@RD_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamRD_NUMSEQUENCE.Value  = clsCliconsultationrendevous.RD_NUMSEQUENCE ;
			SqlParameter vppParamRD_DATESAISIE = new SqlParameter("@RD_DATESAISIE", SqlDbType.DateTime);
			vppParamRD_DATESAISIE.Value  = clsCliconsultationrendevous.RD_DATESAISIE ;
			SqlParameter vppParamTI_IDTIERSMEDECIN = new SqlParameter("@TI_IDTIERSMEDECIN", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECIN.Value  = clsCliconsultationrendevous.TI_IDTIERSMEDECIN ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationrendevous.OP_CODEOPERATEUR ;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsCliconsultationrendevous.SR_CODESERVICE ;
			SqlParameter vppParamRD_DATERDV = new SqlParameter("@RD_DATERDV", SqlDbType.DateTime);
			vppParamRD_DATERDV.Value  = clsCliconsultationrendevous.RD_DATERDV ;
			SqlParameter vppParamRD_HEURERDV = new SqlParameter("@RD_HEURERDV", SqlDbType.DateTime);
			vppParamRD_HEURERDV.Value  = clsCliconsultationrendevous.RD_HEURERDV ;
			SqlParameter vppParamRD_MOTIFRDV = new SqlParameter("@RD_MOTIFRDV", SqlDbType.VarChar, 1000);
			vppParamRD_MOTIFRDV.Value  = clsCliconsultationrendevous.RD_MOTIFRDV ;
			SqlParameter vppParamRD_DATEPRESENCERDV = new SqlParameter("@RD_DATEPRESENCERDV", SqlDbType.DateTime);
			vppParamRD_DATEPRESENCERDV.Value  = clsCliconsultationrendevous.RD_DATEPRESENCERDV ;
            if (clsCliconsultationrendevous.RD_DATEPRESENCERDV < DateTime.Parse("01/01/1900")) vppParamRD_DATEPRESENCERDV.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamRD_HEUREPRESENCERDV = new SqlParameter("@RD_HEUREPRESENCERDV", SqlDbType.DateTime);
			vppParamRD_HEUREPRESENCERDV.Value  = clsCliconsultationrendevous.RD_HEUREPRESENCERDV ;
            if (clsCliconsultationrendevous.RD_HEUREPRESENCERDV < DateTime.Parse("01/01/1900")) vppParamRD_HEUREPRESENCERDV.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONRENDEVOUS  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RD_NUMSEQUENCE, @RD_DATESAISIE, @TI_IDTIERSMEDECIN, @OP_CODEOPERATEUR, @SR_CODESERVICE, @RD_DATERDV, @RD_HEURERDV, @RD_MOTIFRDV, @RD_DATEPRESENCERDV, @RD_HEUREPRESENCERDV, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamRD_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamRD_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamRD_DATERDV);
			vppSqlCmd.Parameters.Add(vppParamRD_HEURERDV);
			vppSqlCmd.Parameters.Add(vppParamRD_MOTIFRDV);
			vppSqlCmd.Parameters.Add(vppParamRD_DATEPRESENCERDV);
			vppSqlCmd.Parameters.Add(vppParamRD_HEUREPRESENCERDV);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONRENDEVOUS  @AG_CODEAGENCE, @CO_CODECONSULTATION, @RD_NUMSEQUENCE, @RD_DATESAISIE, '' , '', '', '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationrendevous </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationrendevous> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, TI_IDTIERSMEDECIN, OP_CODEOPERATEUR, SR_CODESERVICE, RD_DATERDV, RD_HEURERDV, RD_MOTIFRDV, RD_DATEPRESENCERDV, RD_HEUREPRESENCERDV FROM dbo.FT_CLICONSULTATIONRENDEVOUS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliconsultationrendevous> clsCliconsultationrendevouss = new List<clsCliconsultationrendevous>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationrendevous clsCliconsultationrendevous = new clsCliconsultationrendevous();
					clsCliconsultationrendevous.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultationrendevous.CO_CODECONSULTATION = clsDonnee.vogDataReader["CO_CODECONSULTATION"].ToString();
					clsCliconsultationrendevous.RD_NUMSEQUENCE = clsDonnee.vogDataReader["RD_NUMSEQUENCE"].ToString();
					clsCliconsultationrendevous.RD_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["RD_DATESAISIE"].ToString());
					clsCliconsultationrendevous.TI_IDTIERSMEDECIN = clsDonnee.vogDataReader["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultationrendevous.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationrendevous.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsCliconsultationrendevous.RD_DATERDV = DateTime.Parse(clsDonnee.vogDataReader["RD_DATERDV"].ToString());
					clsCliconsultationrendevous.RD_HEURERDV = DateTime.Parse(clsDonnee.vogDataReader["RD_HEURERDV"].ToString());
					clsCliconsultationrendevous.RD_MOTIFRDV = clsDonnee.vogDataReader["RD_MOTIFRDV"].ToString();
					clsCliconsultationrendevous.RD_DATEPRESENCERDV = DateTime.Parse(clsDonnee.vogDataReader["RD_DATEPRESENCERDV"].ToString());
					clsCliconsultationrendevous.RD_HEUREPRESENCERDV = DateTime.Parse(clsDonnee.vogDataReader["RD_HEUREPRESENCERDV"].ToString());
					clsCliconsultationrendevouss.Add(clsCliconsultationrendevous);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliconsultationrendevouss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationrendevous </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationrendevous> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliconsultationrendevous> clsCliconsultationrendevouss = new List<clsCliconsultationrendevous>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, TI_IDTIERSMEDECIN, OP_CODEOPERATEUR, SR_CODESERVICE, RD_DATERDV, RD_HEURERDV, RD_MOTIFRDV, RD_DATEPRESENCERDV, RD_HEUREPRESENCERDV FROM dbo.FT_CLICONSULTATIONRENDEVOUS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliconsultationrendevous clsCliconsultationrendevous = new clsCliconsultationrendevous();
					clsCliconsultationrendevous.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliconsultationrendevous.CO_CODECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECONSULTATION"].ToString();
					clsCliconsultationrendevous.RD_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["RD_NUMSEQUENCE"].ToString();
					clsCliconsultationrendevous.RD_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_DATESAISIE"].ToString());
					clsCliconsultationrendevous.TI_IDTIERSMEDECIN = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultationrendevous.OP_CODEOPERATEUR =Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationrendevous.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
					clsCliconsultationrendevous.RD_DATERDV = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_DATERDV"].ToString());
					clsCliconsultationrendevous.RD_HEURERDV = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_HEURERDV"].ToString());
					clsCliconsultationrendevous.RD_MOTIFRDV = Dataset.Tables["TABLE"].Rows[Idx]["RD_MOTIFRDV"].ToString();
					clsCliconsultationrendevous.RD_DATEPRESENCERDV = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_DATEPRESENCERDV"].ToString());
					clsCliconsultationrendevous.RD_HEUREPRESENCERDV = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RD_HEUREPRESENCERDV"].ToString());
					clsCliconsultationrendevouss.Add(clsCliconsultationrendevous);
				}
				Dataset.Dispose();
			}
		return clsCliconsultationrendevouss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICONSULTATIONRENDEVOUS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , TI_IDTIERSMEDECIN FROM dbo.FT_CLICONSULTATIONRENDEVOUS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CO_CODECONSULTATION, RD_NUMSEQUENCE, RD_DATESAISIE, OP_CODEOPERATEUR, SR_CODESERVICE)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND RD_NUMSEQUENCE=@RD_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@RD_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND RD_NUMSEQUENCE=@RD_NUMSEQUENCE AND RD_DATESAISIE=@RD_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@RD_NUMSEQUENCE","@RD_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND RD_NUMSEQUENCE=@RD_NUMSEQUENCE AND RD_DATESAISIE=@RD_DATESAISIE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@RD_NUMSEQUENCE","@RD_DATESAISIE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND RD_NUMSEQUENCE=@RD_NUMSEQUENCE AND RD_DATESAISIE=@RD_DATESAISIE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND SR_CODESERVICE=@SR_CODESERVICE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@RD_NUMSEQUENCE","@RD_DATESAISIE","@OP_CODEOPERATEUR","@SR_CODESERVICE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
