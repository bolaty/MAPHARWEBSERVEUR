using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliconsultationWSDAL: ITableDAL<clsCliconsultation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CO_CODECONSULTATION) AS CO_CODECONSULTATION  FROM dbo.FT_CLICONSULTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CO_CODECONSULTATION) AS CO_CODECONSULTATION  FROM dbo.FT_CLICONSULTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CO_CODECONSULTATION) AS CO_CODECONSULTATION  FROM dbo.FT_CLICONSULTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , SR_CODESERVICE  , TY_CODETYPECONSULTATION  , MD_CODEMODEADMISSION  , MS_CODEMODESORTIE  , TI_IDTIERSPATIENT  , TI_IDTIERSMEDECIN  , CO_CODECONSULTATION1  , OP_CODEOPERATEUR  , CO_NUMERODOSSIER  , CO_DATEDECONSULTATION  , CO_DATEEXPIRATIONCONSULTATION  , CO_MOTIFCONSULTATION  , CO_AUTRESINFORMATIONS  , CO_TAUXASSURANCE  , CO_MONTANTASSURANCE  , CO_DATESAISIE  , CO_DESCRIPTIONREPRESENTANT  , CO_CONTACTREPRESENTANT  , CO_DATESORTIE  , CO_TAUXMEDECIN  , CO_MONTANTMEDECIN  FROM dbo.FT_CLICONSULTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliconsultation clsCliconsultation = new clsCliconsultation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultation.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultation.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsCliconsultation.TY_CODETYPECONSULTATION = clsDonnee.vogDataReader["TY_CODETYPECONSULTATION"].ToString();
					clsCliconsultation.MD_CODEMODEADMISSION = clsDonnee.vogDataReader["MD_CODEMODEADMISSION"].ToString();
					clsCliconsultation.MS_CODEMODESORTIE = clsDonnee.vogDataReader["MS_CODEMODESORTIE"].ToString();
					clsCliconsultation.TI_IDTIERSPATIENT = clsDonnee.vogDataReader["TI_IDTIERSPATIENT"].ToString();
					clsCliconsultation.TI_IDTIERSMEDECIN = clsDonnee.vogDataReader["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultation.CO_CODECONSULTATION1 = clsDonnee.vogDataReader["CO_CODECONSULTATION1"].ToString();
					clsCliconsultation.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultation.CO_NUMERODOSSIER = clsDonnee.vogDataReader["CO_NUMERODOSSIER"].ToString();
					clsCliconsultation.CO_DATEDECONSULTATION = DateTime.Parse(clsDonnee.vogDataReader["CO_DATEDECONSULTATION"].ToString());
					clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION = DateTime.Parse(clsDonnee.vogDataReader["CO_DATEEXPIRATIONCONSULTATION"].ToString());
					clsCliconsultation.CO_MOTIFCONSULTATION = clsDonnee.vogDataReader["CO_MOTIFCONSULTATION"].ToString();
					clsCliconsultation.CO_AUTRESINFORMATIONS = clsDonnee.vogDataReader["CO_AUTRESINFORMATIONS"].ToString();
					clsCliconsultation.CO_TAUXASSURANCE = double.Parse(clsDonnee.vogDataReader["CO_TAUXASSURANCE"].ToString());
					clsCliconsultation.CO_MONTANTASSURANCE = double.Parse(clsDonnee.vogDataReader["CO_MONTANTASSURANCE"].ToString());
					clsCliconsultation.CO_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CO_DATESAISIE"].ToString());
					clsCliconsultation.CO_DESCRIPTIONREPRESENTANT = clsDonnee.vogDataReader["CO_DESCRIPTIONREPRESENTANT"].ToString();
					clsCliconsultation.CO_CONTACTREPRESENTANT = clsDonnee.vogDataReader["CO_CONTACTREPRESENTANT"].ToString();
					clsCliconsultation.CO_DATESORTIE = DateTime.Parse(clsDonnee.vogDataReader["CO_DATESORTIE"].ToString());
					clsCliconsultation.CO_TAUXMEDECIN = double.Parse(clsDonnee.vogDataReader["CO_TAUXMEDECIN"].ToString());
					clsCliconsultation.CO_MONTANTMEDECIN = double.Parse(clsDonnee.vogDataReader["CO_MONTANTMEDECIN"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliconsultation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultation>clsCliconsultation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliconsultation clsCliconsultation)
		{
			//Préparation des paramètres
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultation.CO_CODECONSULTATION ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultation.AG_CODEAGENCE ;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsCliconsultation.SR_CODESERVICE ;
			SqlParameter vppParamTY_CODETYPECONSULTATION = new SqlParameter("@TY_CODETYPECONSULTATION", SqlDbType.VarChar, 2);
			vppParamTY_CODETYPECONSULTATION.Value  = clsCliconsultation.TY_CODETYPECONSULTATION ;
			SqlParameter vppParamMD_CODEMODEADMISSION = new SqlParameter("@MD_CODEMODEADMISSION", SqlDbType.VarChar, 2);
			vppParamMD_CODEMODEADMISSION.Value  = clsCliconsultation.MD_CODEMODEADMISSION ;
			SqlParameter vppParamMS_CODEMODESORTIE = new SqlParameter("@MS_CODEMODESORTIE", SqlDbType.VarChar, 2);
			vppParamMS_CODEMODESORTIE.Value  = clsCliconsultation.MS_CODEMODESORTIE ;
			if(clsCliconsultation.MS_CODEMODESORTIE== ""  ) vppParamMS_CODEMODESORTIE.Value  = DBNull.Value;
			SqlParameter vppParamTI_IDTIERSPATIENT = new SqlParameter("@TI_IDTIERSPATIENT", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSPATIENT.Value  = clsCliconsultation.TI_IDTIERSPATIENT ;
			SqlParameter vppParamTI_IDTIERSMEDECIN = new SqlParameter("@TI_IDTIERSMEDECIN", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECIN.Value  = clsCliconsultation.TI_IDTIERSMEDECIN ;
			SqlParameter vppParamCO_CODECONSULTATION1 = new SqlParameter("@CO_CODECONSULTATION1", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION1.Value  = clsCliconsultation.CO_CODECONSULTATION1 ;
			if(clsCliconsultation.CO_CODECONSULTATION1== ""  ) vppParamCO_CODECONSULTATION1.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultation.OP_CODEOPERATEUR ;
			SqlParameter vppParamCO_NUMERODOSSIER = new SqlParameter("@CO_NUMERODOSSIER", SqlDbType.VarChar, 1000);
			vppParamCO_NUMERODOSSIER.Value  = clsCliconsultation.CO_NUMERODOSSIER ;
			SqlParameter vppParamCO_DATEDECONSULTATION = new SqlParameter("@CO_DATEDECONSULTATION", SqlDbType.DateTime);
			vppParamCO_DATEDECONSULTATION.Value  = clsCliconsultation.CO_DATEDECONSULTATION ;
			SqlParameter vppParamCO_DATEEXPIRATIONCONSULTATION = new SqlParameter("@CO_DATEEXPIRATIONCONSULTATION", SqlDbType.DateTime);
			vppParamCO_DATEEXPIRATIONCONSULTATION.Value  = clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION ;
            if (clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION < DateTime.Parse("01/01/1900")) vppParamCO_DATEEXPIRATIONCONSULTATION.Value = "01/01/1900";
            SqlParameter vppParamCO_MOTIFCONSULTATION = new SqlParameter("@CO_MOTIFCONSULTATION", SqlDbType.VarChar, 1000);
			vppParamCO_MOTIFCONSULTATION.Value  = clsCliconsultation.CO_MOTIFCONSULTATION ;
			SqlParameter vppParamCO_AUTRESINFORMATIONS = new SqlParameter("@CO_AUTRESINFORMATIONS", SqlDbType.VarChar, 1000);
			vppParamCO_AUTRESINFORMATIONS.Value  = clsCliconsultation.CO_AUTRESINFORMATIONS ;
			if(clsCliconsultation.CO_AUTRESINFORMATIONS== ""  ) vppParamCO_AUTRESINFORMATIONS.Value  = DBNull.Value;
			SqlParameter vppParamCO_TAUXASSURANCE = new SqlParameter("@CO_TAUXASSURANCE", SqlDbType.Decimal, 4);
			vppParamCO_TAUXASSURANCE.Value  = clsCliconsultation.CO_TAUXASSURANCE ;
			SqlParameter vppParamCO_MONTANTASSURANCE = new SqlParameter("@CO_MONTANTASSURANCE", SqlDbType.Money);
			vppParamCO_MONTANTASSURANCE.Value  = clsCliconsultation.CO_MONTANTASSURANCE ;
			SqlParameter vppParamCO_DATESAISIE = new SqlParameter("@CO_DATESAISIE", SqlDbType.DateTime);
			vppParamCO_DATESAISIE.Value  = clsCliconsultation.CO_DATESAISIE ;
			SqlParameter vppParamCO_DESCRIPTIONREPRESENTANT = new SqlParameter("@CO_DESCRIPTIONREPRESENTANT", SqlDbType.VarChar, 1000);
			vppParamCO_DESCRIPTIONREPRESENTANT.Value  = clsCliconsultation.CO_DESCRIPTIONREPRESENTANT ;
			if(clsCliconsultation.CO_DESCRIPTIONREPRESENTANT== ""  ) vppParamCO_DESCRIPTIONREPRESENTANT.Value  = DBNull.Value;
			SqlParameter vppParamCO_CONTACTREPRESENTANT = new SqlParameter("@CO_CONTACTREPRESENTANT", SqlDbType.VarChar, 1000);
			vppParamCO_CONTACTREPRESENTANT.Value  = clsCliconsultation.CO_CONTACTREPRESENTANT ;
			if(clsCliconsultation.CO_CONTACTREPRESENTANT== ""  ) vppParamCO_CONTACTREPRESENTANT.Value  = DBNull.Value;
			SqlParameter vppParamCO_DATESORTIE = new SqlParameter("@CO_DATESORTIE", SqlDbType.DateTime);
			vppParamCO_DATESORTIE.Value  = clsCliconsultation.CO_DATESORTIE ;
            if (clsCliconsultation.CO_DATESORTIE < DateTime.Parse("01/01/1900")) vppParamCO_DATESORTIE.Value = "01/01/1900";

            SqlParameter vppParamCO_TAUXMEDECIN = new SqlParameter("@CO_TAUXMEDECIN", SqlDbType.Decimal, 4);
			vppParamCO_TAUXMEDECIN.Value  = clsCliconsultation.CO_TAUXMEDECIN ;
			SqlParameter vppParamCO_MONTANTMEDECIN = new SqlParameter("@CO_MONTANTMEDECIN", SqlDbType.Money);
			vppParamCO_MONTANTMEDECIN.Value  = clsCliconsultation.CO_MONTANTMEDECIN ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATION  @CO_CODECONSULTATION, @AG_CODEAGENCE, @SR_CODESERVICE, @TY_CODETYPECONSULTATION, @MD_CODEMODEADMISSION, @MS_CODEMODESORTIE, @TI_IDTIERSPATIENT, @TI_IDTIERSMEDECIN, @CO_CODECONSULTATION1, @OP_CODEOPERATEUR,  @CO_NUMERODOSSIER, @CO_DATEDECONSULTATION, @CO_DATEEXPIRATIONCONSULTATION, @CO_MOTIFCONSULTATION, @CO_AUTRESINFORMATIONS, @CO_TAUXASSURANCE, @CO_MONTANTASSURANCE, @CO_DATESAISIE, @CO_DESCRIPTIONREPRESENTANT, @CO_CONTACTREPRESENTANT, @CO_DATESORTIE, @CO_TAUXMEDECIN, @CO_MONTANTMEDECIN, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamTY_CODETYPECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamMD_CODEMODEADMISSION);
			vppSqlCmd.Parameters.Add(vppParamMS_CODEMODESORTIE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSPATIENT);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION1);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCO_NUMERODOSSIER);
			vppSqlCmd.Parameters.Add(vppParamCO_DATEDECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCO_DATEEXPIRATIONCONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCO_MOTIFCONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCO_AUTRESINFORMATIONS);
			vppSqlCmd.Parameters.Add(vppParamCO_TAUXASSURANCE);
			vppSqlCmd.Parameters.Add(vppParamCO_MONTANTASSURANCE);
			vppSqlCmd.Parameters.Add(vppParamCO_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCO_DESCRIPTIONREPRESENTANT);
			vppSqlCmd.Parameters.Add(vppParamCO_CONTACTREPRESENTANT);
			vppSqlCmd.Parameters.Add(vppParamCO_DATESORTIE);
			vppSqlCmd.Parameters.Add(vppParamCO_TAUXMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamCO_MONTANTMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultation>clsCliconsultation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliconsultation clsCliconsultation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultation.CO_CODECONSULTATION ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultation.AG_CODEAGENCE ;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsCliconsultation.SR_CODESERVICE ;
			SqlParameter vppParamTY_CODETYPECONSULTATION = new SqlParameter("@TY_CODETYPECONSULTATION", SqlDbType.VarChar, 2);
			vppParamTY_CODETYPECONSULTATION.Value  = clsCliconsultation.TY_CODETYPECONSULTATION ;
			SqlParameter vppParamMD_CODEMODEADMISSION = new SqlParameter("@MD_CODEMODEADMISSION", SqlDbType.VarChar, 2);
			vppParamMD_CODEMODEADMISSION.Value  = clsCliconsultation.MD_CODEMODEADMISSION ;
			SqlParameter vppParamMS_CODEMODESORTIE = new SqlParameter("@MS_CODEMODESORTIE", SqlDbType.VarChar, 2);
			vppParamMS_CODEMODESORTIE.Value  = clsCliconsultation.MS_CODEMODESORTIE ;
			if(clsCliconsultation.MS_CODEMODESORTIE== ""  ) vppParamMS_CODEMODESORTIE.Value  = DBNull.Value;
			SqlParameter vppParamTI_IDTIERSPATIENT = new SqlParameter("@TI_IDTIERSPATIENT", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSPATIENT.Value  = clsCliconsultation.TI_IDTIERSPATIENT ;
			SqlParameter vppParamTI_IDTIERSMEDECIN = new SqlParameter("@TI_IDTIERSMEDECIN", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERSMEDECIN.Value  = clsCliconsultation.TI_IDTIERSMEDECIN ;
			SqlParameter vppParamCO_CODECONSULTATION1 = new SqlParameter("@CO_CODECONSULTATION1", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION1.Value  = clsCliconsultation.CO_CODECONSULTATION1 ;
			if(clsCliconsultation.CO_CODECONSULTATION1== ""  ) vppParamCO_CODECONSULTATION1.Value  = DBNull.Value;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultation.OP_CODEOPERATEUR ;


			


			SqlParameter vppParamCO_NUMERODOSSIER = new SqlParameter("@CO_NUMERODOSSIER", SqlDbType.VarChar, 1000);
			vppParamCO_NUMERODOSSIER.Value  = clsCliconsultation.CO_NUMERODOSSIER ;
			SqlParameter vppParamCO_DATEDECONSULTATION = new SqlParameter("@CO_DATEDECONSULTATION", SqlDbType.DateTime);
			vppParamCO_DATEDECONSULTATION.Value  = clsCliconsultation.CO_DATEDECONSULTATION ;
			SqlParameter vppParamCO_DATEEXPIRATIONCONSULTATION = new SqlParameter("@CO_DATEEXPIRATIONCONSULTATION", SqlDbType.DateTime);
			vppParamCO_DATEEXPIRATIONCONSULTATION.Value  = clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION ;
            if (clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION < DateTime.Parse("01/01/1900")) vppParamCO_DATEEXPIRATIONCONSULTATION.Value = "01/01/1900";

            SqlParameter vppParamCO_MOTIFCONSULTATION = new SqlParameter("@CO_MOTIFCONSULTATION", SqlDbType.VarChar, 1000);
			vppParamCO_MOTIFCONSULTATION.Value  = clsCliconsultation.CO_MOTIFCONSULTATION ;
			SqlParameter vppParamCO_AUTRESINFORMATIONS = new SqlParameter("@CO_AUTRESINFORMATIONS", SqlDbType.VarChar, 1000);
			vppParamCO_AUTRESINFORMATIONS.Value  = clsCliconsultation.CO_AUTRESINFORMATIONS ;
			if(clsCliconsultation.CO_AUTRESINFORMATIONS== ""  ) vppParamCO_AUTRESINFORMATIONS.Value  = DBNull.Value;
			SqlParameter vppParamCO_TAUXASSURANCE = new SqlParameter("@CO_TAUXASSURANCE", SqlDbType.Float);
			vppParamCO_TAUXASSURANCE.Value  = clsCliconsultation.CO_TAUXASSURANCE ;
			SqlParameter vppParamCO_MONTANTASSURANCE = new SqlParameter("@CO_MONTANTASSURANCE", SqlDbType.Money);
			vppParamCO_MONTANTASSURANCE.Value  = clsCliconsultation.CO_MONTANTASSURANCE ;
			SqlParameter vppParamCO_DATESAISIE = new SqlParameter("@CO_DATESAISIE", SqlDbType.DateTime);
			vppParamCO_DATESAISIE.Value  = clsCliconsultation.CO_DATESAISIE ;
			SqlParameter vppParamCO_DESCRIPTIONREPRESENTANT = new SqlParameter("@CO_DESCRIPTIONREPRESENTANT", SqlDbType.VarChar, 1000);
			vppParamCO_DESCRIPTIONREPRESENTANT.Value  = clsCliconsultation.CO_DESCRIPTIONREPRESENTANT ;
			if(clsCliconsultation.CO_DESCRIPTIONREPRESENTANT== ""  ) vppParamCO_DESCRIPTIONREPRESENTANT.Value  = DBNull.Value;
			SqlParameter vppParamCO_CONTACTREPRESENTANT = new SqlParameter("@CO_CONTACTREPRESENTANT", SqlDbType.VarChar, 1000);
			vppParamCO_CONTACTREPRESENTANT.Value  = clsCliconsultation.CO_CONTACTREPRESENTANT ;
			if(clsCliconsultation.CO_CONTACTREPRESENTANT== ""  ) vppParamCO_CONTACTREPRESENTANT.Value  = DBNull.Value;
			SqlParameter vppParamCO_DATESORTIE = new SqlParameter("@CO_DATESORTIE", SqlDbType.DateTime);
			vppParamCO_DATESORTIE.Value  = clsCliconsultation.CO_DATESORTIE ;
            if (clsCliconsultation.CO_DATESORTIE < DateTime.Parse("01/01/1900")) vppParamCO_DATESORTIE.Value = "01/01/1900";
            SqlParameter vppParamCO_TAUXMEDECIN = new SqlParameter("@CO_TAUXMEDECIN", SqlDbType.Float);
			vppParamCO_TAUXMEDECIN.Value  = clsCliconsultation.CO_TAUXMEDECIN ;
			SqlParameter vppParamCO_MONTANTMEDECIN = new SqlParameter("@CO_MONTANTMEDECIN", SqlDbType.Money);
			vppParamCO_MONTANTMEDECIN.Value  = clsCliconsultation.CO_MONTANTMEDECIN ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATION  @CO_CODECONSULTATION, @AG_CODEAGENCE, @SR_CODESERVICE, @TY_CODETYPECONSULTATION, @MD_CODEMODEADMISSION, @MS_CODEMODESORTIE, @TI_IDTIERSPATIENT, @TI_IDTIERSMEDECIN, @CO_CODECONSULTATION1, @OP_CODEOPERATEUR,  @CO_NUMERODOSSIER, @CO_DATEDECONSULTATION, @CO_DATEEXPIRATIONCONSULTATION, @CO_MOTIFCONSULTATION, @CO_AUTRESINFORMATIONS, @CO_TAUXASSURANCE, @CO_MONTANTASSURANCE, @CO_DATESAISIE, @CO_DESCRIPTIONREPRESENTANT, @CO_CONTACTREPRESENTANT, @CO_DATESORTIE, @CO_TAUXMEDECIN, @CO_MONTANTMEDECIN, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamTY_CODETYPECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamMD_CODEMODEADMISSION);
			vppSqlCmd.Parameters.Add(vppParamMS_CODEMODESORTIE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSPATIENT);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION1);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCO_NUMERODOSSIER);
			vppSqlCmd.Parameters.Add(vppParamCO_DATEDECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCO_DATEEXPIRATIONCONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCO_MOTIFCONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCO_AUTRESINFORMATIONS);
			vppSqlCmd.Parameters.Add(vppParamCO_TAUXASSURANCE);
			vppSqlCmd.Parameters.Add(vppParamCO_MONTANTASSURANCE);
			vppSqlCmd.Parameters.Add(vppParamCO_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCO_DESCRIPTIONREPRESENTANT);
			vppSqlCmd.Parameters.Add(vppParamCO_CONTACTREPRESENTANT);
			vppSqlCmd.Parameters.Add(vppParamCO_DATESORTIE);
			vppSqlCmd.Parameters.Add(vppParamCO_TAUXMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamCO_MONTANTMEDECIN);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATION  @CO_CODECONSULTATION, @AG_CODEAGENCE, '', '','', '','', '' , '' , '', '', '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' ,  @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultation </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, TI_IDTIERSPATIENT, TI_IDTIERSMEDECIN, CO_CODECONSULTATION1, OP_CODEOPERATEUR, CO_NUMERODOSSIER, CO_DATEDECONSULTATION, CO_DATEEXPIRATIONCONSULTATION, CO_MOTIFCONSULTATION, CO_AUTRESINFORMATIONS, CO_TAUXASSURANCE, CO_MONTANTASSURANCE, CO_DATESAISIE, CO_DESCRIPTIONREPRESENTANT, CO_CONTACTREPRESENTANT, CO_DATESORTIE, CO_TAUXMEDECIN, CO_MONTANTMEDECIN FROM dbo.FT_CLICONSULTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliconsultation> clsCliconsultations = new List<clsCliconsultation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultation clsCliconsultation = new clsCliconsultation();
					clsCliconsultation.CO_CODECONSULTATION = clsDonnee.vogDataReader["CO_CODECONSULTATION"].ToString();
					clsCliconsultation.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultation.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsCliconsultation.TY_CODETYPECONSULTATION = clsDonnee.vogDataReader["TY_CODETYPECONSULTATION"].ToString();
					clsCliconsultation.MD_CODEMODEADMISSION = clsDonnee.vogDataReader["MD_CODEMODEADMISSION"].ToString();
					clsCliconsultation.MS_CODEMODESORTIE = clsDonnee.vogDataReader["MS_CODEMODESORTIE"].ToString();
					clsCliconsultation.TI_IDTIERSPATIENT = clsDonnee.vogDataReader["TI_IDTIERSPATIENT"].ToString();
					clsCliconsultation.TI_IDTIERSMEDECIN = clsDonnee.vogDataReader["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultation.CO_CODECONSULTATION1 = clsDonnee.vogDataReader["CO_CODECONSULTATION1"].ToString();
					clsCliconsultation.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultation.CO_NUMERODOSSIER = clsDonnee.vogDataReader["CO_NUMERODOSSIER"].ToString();
					clsCliconsultation.CO_DATEDECONSULTATION = DateTime.Parse(clsDonnee.vogDataReader["CO_DATEDECONSULTATION"].ToString());
					clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION = DateTime.Parse(clsDonnee.vogDataReader["CO_DATEEXPIRATIONCONSULTATION"].ToString());
					clsCliconsultation.CO_MOTIFCONSULTATION = clsDonnee.vogDataReader["CO_MOTIFCONSULTATION"].ToString();
					clsCliconsultation.CO_AUTRESINFORMATIONS = clsDonnee.vogDataReader["CO_AUTRESINFORMATIONS"].ToString();
					clsCliconsultation.CO_TAUXASSURANCE = double.Parse(clsDonnee.vogDataReader["CO_TAUXASSURANCE"].ToString());
					clsCliconsultation.CO_MONTANTASSURANCE = double.Parse(clsDonnee.vogDataReader["CO_MONTANTASSURANCE"].ToString());
					clsCliconsultation.CO_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CO_DATESAISIE"].ToString());
					clsCliconsultation.CO_DESCRIPTIONREPRESENTANT = clsDonnee.vogDataReader["CO_DESCRIPTIONREPRESENTANT"].ToString();
					clsCliconsultation.CO_CONTACTREPRESENTANT = clsDonnee.vogDataReader["CO_CONTACTREPRESENTANT"].ToString();
					clsCliconsultation.CO_DATESORTIE = DateTime.Parse(clsDonnee.vogDataReader["CO_DATESORTIE"].ToString());
					clsCliconsultation.CO_TAUXMEDECIN = double.Parse(clsDonnee.vogDataReader["CO_TAUXMEDECIN"].ToString());
					clsCliconsultation.CO_MONTANTMEDECIN = double.Parse(clsDonnee.vogDataReader["CO_MONTANTMEDECIN"].ToString());
					clsCliconsultations.Add(clsCliconsultation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliconsultations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultation </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliconsultation> clsCliconsultations = new List<clsCliconsultation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, TI_IDTIERSPATIENT, TI_IDTIERSMEDECIN, CO_CODECONSULTATION1, OP_CODEOPERATEUR,  CO_NUMERODOSSIER, CO_DATEDECONSULTATION, CO_DATEEXPIRATIONCONSULTATION, CO_MOTIFCONSULTATION, CO_AUTRESINFORMATIONS, CO_TAUXASSURANCE, CO_MONTANTASSURANCE, CO_DATESAISIE, CO_DESCRIPTIONREPRESENTANT, CO_CONTACTREPRESENTANT, CO_DATESORTIE, CO_TAUXMEDECIN, CO_MONTANTMEDECIN FROM dbo.FT_CLICONSULTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliconsultation clsCliconsultation = new clsCliconsultation();
					clsCliconsultation.CO_CODECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECONSULTATION"].ToString();
					clsCliconsultation.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliconsultation.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
					clsCliconsultation.TY_CODETYPECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["TY_CODETYPECONSULTATION"].ToString();
					clsCliconsultation.MD_CODEMODEADMISSION = Dataset.Tables["TABLE"].Rows[Idx]["MD_CODEMODEADMISSION"].ToString();
					clsCliconsultation.MS_CODEMODESORTIE = Dataset.Tables["TABLE"].Rows[Idx]["MS_CODEMODESORTIE"].ToString();
					clsCliconsultation.TI_IDTIERSPATIENT = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSPATIENT"].ToString();
					clsCliconsultation.TI_IDTIERSMEDECIN = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSMEDECIN"].ToString();
					clsCliconsultation.CO_CODECONSULTATION1 = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECONSULTATION1"].ToString();
					clsCliconsultation.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliconsultation.CO_NUMERODOSSIER = Dataset.Tables["TABLE"].Rows[Idx]["CO_NUMERODOSSIER"].ToString();
					clsCliconsultation.CO_DATEDECONSULTATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_DATEDECONSULTATION"].ToString());
					clsCliconsultation.CO_DATEEXPIRATIONCONSULTATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_DATEEXPIRATIONCONSULTATION"].ToString());
					clsCliconsultation.CO_MOTIFCONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["CO_MOTIFCONSULTATION"].ToString();
					clsCliconsultation.CO_AUTRESINFORMATIONS = Dataset.Tables["TABLE"].Rows[Idx]["CO_AUTRESINFORMATIONS"].ToString();
					clsCliconsultation.CO_TAUXASSURANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_TAUXASSURANCE"].ToString());
					clsCliconsultation.CO_MONTANTASSURANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_MONTANTASSURANCE"].ToString());
					clsCliconsultation.CO_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_DATESAISIE"].ToString());
					clsCliconsultation.CO_DESCRIPTIONREPRESENTANT = Dataset.Tables["TABLE"].Rows[Idx]["CO_DESCRIPTIONREPRESENTANT"].ToString();
					clsCliconsultation.CO_CONTACTREPRESENTANT = Dataset.Tables["TABLE"].Rows[Idx]["CO_CONTACTREPRESENTANT"].ToString();
					clsCliconsultation.CO_DATESORTIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_DATESORTIE"].ToString());
					clsCliconsultation.CO_TAUXMEDECIN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_TAUXMEDECIN"].ToString());
					clsCliconsultation.CO_MONTANTMEDECIN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CO_MONTANTMEDECIN"].ToString());
					clsCliconsultations.Add(clsCliconsultation);
				}
				Dataset.Dispose();
			}
		return clsCliconsultations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICONSULTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetConsultation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERSPATIENT", "@TI_DENOMINATIONPATIENT", "@TI_NUMTIERSMEDECIN", "@TI_DENOMINATIONMEDECIN", "@CO_NUMERODOSSIER", "@CO_DATESAISIE1", "@CO_DATESAISIE2" , "@CO_CODECONSULTATION", "@CO_CODECONSULTATION1", "@CO_TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10]};
            this.vapRequete = "EXEC [dbo].[PS_CLICONSULTATION] @AG_CODEAGENCE,	@TI_NUMTIERSPATIENT ,@TI_DENOMINATIONPATIENT, @TI_NUMTIERSMEDECIN,@TI_DENOMINATIONMEDECIN, @CO_NUMERODOSSIER,@CO_DATESAISIE1,@CO_DATESAISIE2 ,@CO_CODECONSULTATION,@CO_CODECONSULTATION1,@CO_TYPEOPERATION, @CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


    ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
    ///<param name=clsDonnee>Classe d'acces aux donnees</param>
    ///<param name="vppCritere">critères de la requête scalaire</param>
    ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    public DataSet pvgChargerDansDataSetConsultationLiaison(clsDonnee clsDonnee, params string[] vppCritere)
    {
        vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERSPATIENT", "@TI_DENOMINATIONPATIENT", "@TI_NUMTIERSMEDECIN", "@TI_DENOMINATIONMEDECIN", "@CO_NUMERODOSSIER", "@MS_NUMPIECE", "@CO_DATESAISIE1", "@CO_DATESAISIE2" , "@CO_TYPEOPERATION" };
        vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9]};
        this.vapRequete = "EXEC [dbo].[PS_CLICONSULTATIONFACTURELIAISON] @AG_CODEAGENCE,	@TI_NUMTIERSPATIENT ,@TI_DENOMINATIONPATIENT, @TI_NUMTIERSMEDECIN,@TI_DENOMINATIONMEDECIN, @CO_NUMERODOSSIER,@MS_NUMPIECE,@CO_DATESAISIE1,@CO_DATESAISIE2 ,@CO_TYPEOPERATION, @CODECRYPTAGE ";
	    this.vapCritere = "";
	    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	    return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
    }


		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CO_CODECONSULTATION , TI_IDTIERSPATIENT FROM dbo.FT_CLICONSULTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CO_CODECONSULTATION, AG_CODEAGENCE, SR_CODESERVICE, TY_CODETYPECONSULTATION, MD_CODEMODEADMISSION, MS_CODEMODESORTIE, CO_CODECONSULTATION1, OP_CODEOPERATEUR)</summary>
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
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_CODECONSULTATION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND SR_CODESERVICE=@SR_CODESERVICE";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_CODECONSULTATION", "@SR_CODESERVICE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND SR_CODESERVICE=@SR_CODESERVICE AND TY_CODETYPECONSULTATION=@TY_CODETYPECONSULTATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_CODECONSULTATION", "@SR_CODESERVICE","@TY_CODETYPECONSULTATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND SR_CODESERVICE=@SR_CODESERVICE AND TY_CODETYPECONSULTATION=@TY_CODETYPECONSULTATION AND MD_CODEMODEADMISSION=@MD_CODEMODEADMISSION";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_CODECONSULTATION", "@SR_CODESERVICE","@TY_CODETYPECONSULTATION","@MD_CODEMODEADMISSION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND SR_CODESERVICE=@SR_CODESERVICE AND TY_CODETYPECONSULTATION=@TY_CODETYPECONSULTATION AND MD_CODEMODEADMISSION=@MD_CODEMODEADMISSION AND MS_CODEMODESORTIE=@MS_CODEMODESORTIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_CODECONSULTATION", "@SR_CODESERVICE","@TY_CODETYPECONSULTATION","@MD_CODEMODEADMISSION","@MS_CODEMODESORTIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
				case 7 :
				this.vapCritere ="WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND CO_CODECONSULTATION=@CO_CODECONSULTATION  AND SR_CODESERVICE=@SR_CODESERVICE AND TY_CODETYPECONSULTATION=@TY_CODETYPECONSULTATION AND MD_CODEMODEADMISSION=@MD_CODEMODEADMISSION AND MS_CODEMODESORTIE=@MS_CODEMODESORTIE AND CO_CODECONSULTATION1=@CO_CODECONSULTATION1";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_CODECONSULTATION", "@SR_CODESERVICE","@TY_CODETYPECONSULTATION","@MD_CODEMODEADMISSION","@MS_CODEMODESORTIE","@CO_CODECONSULTATION1"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
				break;
				case 8 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE   AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND SR_CODESERVICE=@SR_CODESERVICE AND TY_CODETYPECONSULTATION=@TY_CODETYPECONSULTATION AND MD_CODEMODEADMISSION=@MD_CODEMODEADMISSION AND MS_CODEMODESORTIE=@MS_CODEMODESORTIE AND CO_CODECONSULTATION1=@CO_CODECONSULTATION1 AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@CO_CODECONSULTATION", "@SR_CODESERVICE","@TY_CODETYPECONSULTATION","@MD_CODEMODEADMISSION","@MS_CODEMODESORTIE","@CO_CODECONSULTATION1","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7]};
				break;
			}
		}
	}
}
