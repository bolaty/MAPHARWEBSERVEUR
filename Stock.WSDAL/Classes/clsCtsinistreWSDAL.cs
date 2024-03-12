using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;
using System.IO;

namespace Stock.WSDAL
{
	public class clsCtsinistreWSDAL: ITableDAL<clsCtsinistre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtsinistre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtsinistre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , NS_CODENATURESINISTRE  , CA_CODECONTRAT  , SI_NUMSINISTRE  , SI_DATESAISIE  , SI_DATESINISTRE  , SI_HEURESINISTRE  , SI_NOMPRENOMSCONDUCTEURSINISTRE  , CO_CODECOMMUNE  , SI_ADRESSEGEOGRPHIQUESINISTRE  , SI_DESCRIPTIONSINISTRE  , SI_DATETRANSMISSIONSINISTRE  , SI_DATEVALIDATIONSINISTRE  , SI_DATESUSPENSIONSINISTRE  , SI_DATECLOTURESINISTRE  , OP_CODEOPERATEUR  , SI_DOCUMENTTRANSMIS  , SI_MONTANTPREJUDICE  , EP_CODEEXPERTNOMME  , SI_DATEEXPERTNOMMESINISTRE  FROM dbo.FT_CTSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtsinistre clsCtsinistre = new clsCtsinistre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistre.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtsinistre.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtsinistre.NS_CODENATURESINISTRE = clsDonnee.vogDataReader["NS_CODENATURESINISTRE"].ToString();
					clsCtsinistre.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtsinistre.SI_NUMSINISTRE = clsDonnee.vogDataReader["SI_NUMSINISTRE"].ToString();
					clsCtsinistre.SI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATESAISIE"].ToString());
					clsCtsinistre.SI_DATESINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATESINISTRE"].ToString());
					clsCtsinistre.SI_HEURESINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_HEURESINISTRE"].ToString());
					clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = clsDonnee.vogDataReader["SI_NOMPRENOMSCONDUCTEURSINISTRE"].ToString();
					clsCtsinistre.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();
					clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = clsDonnee.vogDataReader["SI_ADRESSEGEOGRPHIQUESINISTRE"].ToString();
					clsCtsinistre.SI_DESCRIPTIONSINISTRE = clsDonnee.vogDataReader["SI_DESCRIPTIONSINISTRE"].ToString();
					clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATETRANSMISSIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATEVALIDATIONSINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATEVALIDATIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATESUSPENSIONSINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATESUSPENSIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATECLOTURESINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATECLOTURESINISTRE"].ToString());
					clsCtsinistre.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtsinistre.SI_DOCUMENTTRANSMIS = clsDonnee.vogDataReader["SI_DOCUMENTTRANSMIS"].ToString();
					clsCtsinistre.SI_MONTANTPREJUDICE = double.Parse(clsDonnee.vogDataReader["SI_MONTANTPREJUDICE"].ToString());
					clsCtsinistre.EP_CODEEXPERTNOMME = clsDonnee.vogDataReader["EP_CODEEXPERTNOMME"].ToString();
					clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATEEXPERTNOMMESINISTRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtsinistre;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinistre>clsCtsinistre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtsinistre clsCtsinistre)
		{
			//Préparation des paramètres
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistre.SI_CODESINISTRE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtsinistre.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtsinistre.EN_CODEENTREPOT ;
			SqlParameter vppParamNS_CODENATURESINISTRE = new SqlParameter("@NS_CODENATURESINISTRE", SqlDbType.VarChar, 4);
			vppParamNS_CODENATURESINISTRE.Value  = clsCtsinistre.NS_CODENATURESINISTRE ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtsinistre.CA_CODECONTRAT ;
			SqlParameter vppParamSI_NUMSINISTRE = new SqlParameter("@SI_NUMSINISTRE", SqlDbType.VarChar, 1000);
			vppParamSI_NUMSINISTRE.Value  = clsCtsinistre.SI_NUMSINISTRE ;
			SqlParameter vppParamSI_DATESAISIE = new SqlParameter("@SI_DATESAISIE", SqlDbType.DateTime);
			vppParamSI_DATESAISIE.Value  = clsCtsinistre.SI_DATESAISIE ;
			SqlParameter vppParamSI_DATESINISTRE = new SqlParameter("@SI_DATESINISTRE", SqlDbType.DateTime);
			vppParamSI_DATESINISTRE.Value  = clsCtsinistre.SI_DATESINISTRE ;
			SqlParameter vppParamSI_HEURESINISTRE = new SqlParameter("@SI_HEURESINISTRE", SqlDbType.DateTime);
			vppParamSI_HEURESINISTRE.Value  = clsCtsinistre.SI_HEURESINISTRE ;
			SqlParameter vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE = new SqlParameter("@SI_NOMPRENOMSCONDUCTEURSINISTRE", SqlDbType.VarChar, 1000);
			vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE.Value  = clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE ;
			if(clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE== ""  ) vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE.Value  = DBNull.Value;
			SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
			vppParamCO_CODECOMMUNE.Value  = clsCtsinistre.CO_CODECOMMUNE ;
			SqlParameter vppParamSI_ADRESSEGEOGRPHIQUESINISTRE = new SqlParameter("@SI_ADRESSEGEOGRPHIQUESINISTRE", SqlDbType.VarChar, 1000);
			vppParamSI_ADRESSEGEOGRPHIQUESINISTRE.Value  = clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE ;
			SqlParameter vppParamSI_DESCRIPTIONSINISTRE = new SqlParameter("@SI_DESCRIPTIONSINISTRE", SqlDbType.VarChar, 1000);
			vppParamSI_DESCRIPTIONSINISTRE.Value  = clsCtsinistre.SI_DESCRIPTIONSINISTRE ;
			SqlParameter vppParamSI_DATETRANSMISSIONSINISTRE = new SqlParameter("@SI_DATETRANSMISSIONSINISTRE", SqlDbType.DateTime);
			vppParamSI_DATETRANSMISSIONSINISTRE.Value  = clsCtsinistre.SI_DATETRANSMISSIONSINISTRE ;
			SqlParameter vppParamSI_DATEVALIDATIONSINISTRE = new SqlParameter("@SI_DATEVALIDATIONSINISTRE", SqlDbType.DateTime);
			vppParamSI_DATEVALIDATIONSINISTRE.Value  = clsCtsinistre.SI_DATEVALIDATIONSINISTRE ;
			SqlParameter vppParamSI_DATESUSPENSIONSINISTRE = new SqlParameter("@SI_DATESUSPENSIONSINISTRE", SqlDbType.DateTime);
			vppParamSI_DATESUSPENSIONSINISTRE.Value  = clsCtsinistre.SI_DATESUSPENSIONSINISTRE ;
			SqlParameter vppParamSI_DATECLOTURESINISTRE = new SqlParameter("@SI_DATECLOTURESINISTRE", SqlDbType.DateTime);
			vppParamSI_DATECLOTURESINISTRE.Value  = clsCtsinistre.SI_DATECLOTURESINISTRE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinistre.OP_CODEOPERATEUR ;
			SqlParameter vppParamSI_DOCUMENTTRANSMIS = new SqlParameter("@SI_DOCUMENTTRANSMIS", SqlDbType.VarChar, 1000);
			vppParamSI_DOCUMENTTRANSMIS.Value  = clsCtsinistre.SI_DOCUMENTTRANSMIS ;
			if(clsCtsinistre.SI_DOCUMENTTRANSMIS== ""  ) vppParamSI_DOCUMENTTRANSMIS.Value  = DBNull.Value;
			SqlParameter vppParamSI_MONTANTPREJUDICE = new SqlParameter("@SI_MONTANTPREJUDICE", SqlDbType.Money);
			vppParamSI_MONTANTPREJUDICE.Value  = clsCtsinistre.SI_MONTANTPREJUDICE ;
			SqlParameter vppParamEP_CODEEXPERTNOMME = new SqlParameter("@EP_CODEEXPERTNOMME", SqlDbType.VarChar, 50);
			vppParamEP_CODEEXPERTNOMME.Value  = clsCtsinistre.EP_CODEEXPERTNOMME ;
			if(clsCtsinistre.EP_CODEEXPERTNOMME== ""  ) vppParamEP_CODEEXPERTNOMME.Value  = DBNull.Value;
			SqlParameter vppParamSI_DATEEXPERTNOMMESINISTRE = new SqlParameter("@SI_DATEEXPERTNOMMESINISTRE", SqlDbType.DateTime);
			vppParamSI_DATEEXPERTNOMMESINISTRE.Value  = clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE ;
			if(clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE.Year < 1900 ) vppParamSI_DATEEXPERTNOMMESINISTRE.Value  = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_MONTANTPREJUDICEVALIDER = new SqlParameter("@SI_MONTANTPREJUDICEVALIDER", SqlDbType.Money);
            vppParamSI_MONTANTPREJUDICEVALIDER.Value = clsCtsinistre.SI_MONTANTPREJUDICEVALIDER;

			SqlParameter vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER = new SqlParameter("@OP_CODEOPERATEURSAISIEMONTANTVALIDER", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER.Value  = clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER;
			if(clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER == ""  ) vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER.Value  = DBNull.Value;

            SqlParameter vppParamSI_DATESAISIEMONTANTVALIDER = new SqlParameter("@SI_DATESAISIEMONTANTVALIDER", SqlDbType.DateTime);
            vppParamSI_DATESAISIEMONTANTVALIDER.Value  = clsCtsinistre.SI_DATESAISIEMONTANTVALIDER;
            if(clsCtsinistre.SI_DATESAISIEMONTANTVALIDER.Year < 1900 ) vppParamSI_DATESAISIEMONTANTVALIDER.Value  = DateTime.Parse("01/01/1900");

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRE  @SI_CODESINISTRE, @AG_CODEAGENCE, @EN_CODEENTREPOT, @NS_CODENATURESINISTRE, @CA_CODECONTRAT, @SI_NUMSINISTRE, @SI_DATESAISIE, @SI_DATESINISTRE, @SI_HEURESINISTRE, @SI_NOMPRENOMSCONDUCTEURSINISTRE, @CO_CODECOMMUNE, @SI_ADRESSEGEOGRPHIQUESINISTRE, @SI_DESCRIPTIONSINISTRE, @SI_DATETRANSMISSIONSINISTRE, @SI_DATEVALIDATIONSINISTRE, @SI_DATESUSPENSIONSINISTRE, @SI_DATECLOTURESINISTRE, @OP_CODEOPERATEUR, @SI_DOCUMENTTRANSMIS, @SI_MONTANTPREJUDICE, @EP_CODEEXPERTNOMME, @SI_DATEEXPERTNOMMESINISTRE,@SI_MONTANTPREJUDICEVALIDER,@OP_CODEOPERATEURSAISIEMONTANTVALIDER,@SI_DATESAISIEMONTANTVALIDER, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamNS_CODENATURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamSI_NUMSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_HEURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
			vppSqlCmd.Parameters.Add(vppParamSI_ADRESSEGEOGRPHIQUESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DESCRIPTIONSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATETRANSMISSIONSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATEVALIDATIONSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESUSPENSIONSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATECLOTURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamSI_DOCUMENTTRANSMIS);
			vppSqlCmd.Parameters.Add(vppParamSI_MONTANTPREJUDICE);
			vppSqlCmd.Parameters.Add(vppParamEP_CODEEXPERTNOMME);
			vppSqlCmd.Parameters.Add(vppParamSI_DATEEXPERTNOMMESINISTRE);

			vppSqlCmd.Parameters.Add(vppParamSI_MONTANTPREJUDICEVALIDER);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESAISIEMONTANTVALIDER);

			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontrat>clsCtcontrat</param>
		///<author>Home Technology</author>
		public string pvgMiseAjour(clsDonnee clsDonnee, clsCtsinistre clsCtsinistre)
        {
            //Préparation des paramètres
            SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
            vppParamSI_CODESINISTRE.Value = clsCtsinistre.SI_CODESINISTRE;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsCtsinistre.AG_CODEAGENCE;
            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsCtsinistre.EN_CODEENTREPOT;
            SqlParameter vppParamNS_CODENATURESINISTRE = new SqlParameter("@NS_CODENATURESINISTRE", SqlDbType.VarChar, 4);
            vppParamNS_CODENATURESINISTRE.Value = clsCtsinistre.NS_CODENATURESINISTRE;
            SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
            vppParamCA_CODECONTRAT.Value = clsCtsinistre.CA_CODECONTRAT;
            SqlParameter vppParamSI_NUMSINISTRE = new SqlParameter("@SI_NUMSINISTRE", SqlDbType.VarChar, 1000);
            vppParamSI_NUMSINISTRE.Value = clsCtsinistre.SI_NUMSINISTRE;
            SqlParameter vppParamSI_DATESAISIE = new SqlParameter("@SI_DATESAISIE", SqlDbType.DateTime);
            vppParamSI_DATESAISIE.Value = clsCtsinistre.SI_DATESAISIE;
            SqlParameter vppParamSI_DATESINISTRE = new SqlParameter("@SI_DATESINISTRE", SqlDbType.DateTime);
            vppParamSI_DATESINISTRE.Value = clsCtsinistre.SI_DATESINISTRE;
            SqlParameter vppParamSI_HEURESINISTRE = new SqlParameter("@SI_HEURESINISTRE", SqlDbType.DateTime);
            vppParamSI_HEURESINISTRE.Value = clsCtsinistre.SI_HEURESINISTRE;
            SqlParameter vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE = new SqlParameter("@SI_NOMPRENOMSCONDUCTEURSINISTRE", SqlDbType.VarChar, 1000);
            vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE == "") vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE.Value = DBNull.Value;
            SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
            vppParamCO_CODECOMMUNE.Value = clsCtsinistre.CO_CODECOMMUNE;
            SqlParameter vppParamSI_ADRESSEGEOGRPHIQUESINISTRE = new SqlParameter("@SI_ADRESSEGEOGRPHIQUESINISTRE", SqlDbType.VarChar, 1000);
            vppParamSI_ADRESSEGEOGRPHIQUESINISTRE.Value = clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE;
            SqlParameter vppParamSI_DESCRIPTIONSINISTRE = new SqlParameter("@SI_DESCRIPTIONSINISTRE", SqlDbType.VarChar, 1000);
            vppParamSI_DESCRIPTIONSINISTRE.Value = clsCtsinistre.SI_DESCRIPTIONSINISTRE;
            SqlParameter vppParamSI_DATETRANSMISSIONSINISTRE = new SqlParameter("@SI_DATETRANSMISSIONSINISTRE", SqlDbType.DateTime);
            vppParamSI_DATETRANSMISSIONSINISTRE.Value = clsCtsinistre.SI_DATETRANSMISSIONSINISTRE;
            SqlParameter vppParamSI_DATEVALIDATIONSINISTRE = new SqlParameter("@SI_DATEVALIDATIONSINISTRE", SqlDbType.DateTime);
            vppParamSI_DATEVALIDATIONSINISTRE.Value = clsCtsinistre.SI_DATEVALIDATIONSINISTRE;
            SqlParameter vppParamSI_DATESUSPENSIONSINISTRE = new SqlParameter("@SI_DATESUSPENSIONSINISTRE", SqlDbType.DateTime);
            vppParamSI_DATESUSPENSIONSINISTRE.Value = clsCtsinistre.SI_DATESUSPENSIONSINISTRE;
            SqlParameter vppParamSI_DATECLOTURESINISTRE = new SqlParameter("@SI_DATECLOTURESINISTRE", SqlDbType.DateTime);
            vppParamSI_DATECLOTURESINISTRE.Value = clsCtsinistre.SI_DATECLOTURESINISTRE;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsCtsinistre.OP_CODEOPERATEUR;
            SqlParameter vppParamSI_DOCUMENTTRANSMIS = new SqlParameter("@SI_DOCUMENTTRANSMIS", SqlDbType.VarChar, 1000);
            vppParamSI_DOCUMENTTRANSMIS.Value = clsCtsinistre.SI_DOCUMENTTRANSMIS;
            if (clsCtsinistre.SI_DOCUMENTTRANSMIS == "") vppParamSI_DOCUMENTTRANSMIS.Value = DBNull.Value;
            SqlParameter vppParamSI_MONTANTPREJUDICE = new SqlParameter("@SI_MONTANTPREJUDICE", SqlDbType.Money);
            vppParamSI_MONTANTPREJUDICE.Value = clsCtsinistre.SI_MONTANTPREJUDICE;
            SqlParameter vppParamEP_CODEEXPERTNOMME = new SqlParameter("@EP_CODEEXPERTNOMME", SqlDbType.VarChar, 50);
            vppParamEP_CODEEXPERTNOMME.Value = clsCtsinistre.EP_CODEEXPERTNOMME;
            if (clsCtsinistre.EP_CODEEXPERTNOMME == "") vppParamEP_CODEEXPERTNOMME.Value = DBNull.Value;
            SqlParameter vppParamSI_DATEEXPERTNOMMESINISTRE = new SqlParameter("@SI_DATEEXPERTNOMMESINISTRE", SqlDbType.DateTime);
            vppParamSI_DATEEXPERTNOMMESINISTRE.Value = clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE;
            if (clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE.Year < 1900) vppParamSI_DATEEXPERTNOMMESINISTRE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_MONTANTPREJUDICEVALIDER = new SqlParameter("@SI_MONTANTPREJUDICEVALIDER", SqlDbType.Money);
            vppParamSI_MONTANTPREJUDICEVALIDER.Value = clsCtsinistre.SI_MONTANTPREJUDICEVALIDER;

            SqlParameter vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER = new SqlParameter("@OP_CODEOPERATEURSAISIEMONTANTVALIDER", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER.Value = clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER;
            if (clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER == "") vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER.Value = DBNull.Value;

            SqlParameter vppParamSI_DATESAISIEMONTANTVALIDER = new SqlParameter("@SI_DATESAISIEMONTANTVALIDER", SqlDbType.DateTime);
            vppParamSI_DATESAISIEMONTANTVALIDER.Value = clsCtsinistre.SI_DATESAISIEMONTANTVALIDER;
            if (clsCtsinistre.SI_DATESAISIEMONTANTVALIDER.Year < 1900) vppParamSI_DATESAISIEMONTANTVALIDER.Value = DateTime.Parse("01/01/1900");



            SqlParameter vppParamSI_TELEPHONECONDUCTEURSINISTRE = new SqlParameter("@SI_TELEPHONECONDUCTEURSINISTRE", SqlDbType.VarChar, 150);
            vppParamSI_TELEPHONECONDUCTEURSINISTRE.Value = clsCtsinistre.SI_TELEPHONECONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_TELEPHONECONDUCTEURSINISTRE == "") vppParamSI_TELEPHONECONDUCTEURSINISTRE.Value = DBNull.Value;

            SqlParameter vppParamSI_NUMWHATSAPPCONDUCTEURSINISTRE = new SqlParameter("@SI_NUMWHATSAPPCONDUCTEURSINISTRE", SqlDbType.VarChar, 150);
            vppParamSI_NUMWHATSAPPCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_NUMWHATSAPPCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_NUMWHATSAPPCONDUCTEURSINISTRE == "") vppParamSI_NUMWHATSAPPCONDUCTEURSINISTRE.Value = DBNull.Value;

            SqlParameter vppParamSI_DATENAISSANCECONDUCTEURSINISTRE = new SqlParameter("@SI_DATENAISSANCECONDUCTEURSINISTRE", SqlDbType.DateTime);
            vppParamSI_DATENAISSANCECONDUCTEURSINISTRE.Value = clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE.Year < 1900) vppParamSI_DATENAISSANCECONDUCTEURSINISTRE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_NUMPERMISCONDUCTEURSINISTRE = new SqlParameter("@SI_NUMPERMISCONDUCTEURSINISTRE", SqlDbType.VarChar, 150);
            vppParamSI_NUMPERMISCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_NUMPERMISCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_NUMPERMISCONDUCTEURSINISTRE == "") vppParamSI_NUMPERMISCONDUCTEURSINISTRE.Value = DBNull.Value;

            SqlParameter vppParamSI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = new SqlParameter("@SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE", SqlDbType.DateTime);
            vppParamSI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE.Year < 1900) vppParamSI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = new SqlParameter("@SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE", SqlDbType.DateTime);
            vppParamSI_DATEVALIDITEPERMISCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE.Year < 1900) vppParamSI_DATEVALIDITEPERMISCONDUCTEURSINISTRE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_IMMATRICULATIONVEHICULE = new SqlParameter("@SI_IMMATRICULATIONVEHICULE", SqlDbType.VarChar, 150);
            vppParamSI_IMMATRICULATIONVEHICULE.Value = clsCtsinistre.SI_IMMATRICULATIONVEHICULE;
            if (clsCtsinistre.SI_IMMATRICULATIONVEHICULE == "") vppParamSI_IMMATRICULATIONVEHICULE.Value = DBNull.Value;


            SqlParameter vppParamSI_MARQUEVEHICULE = new SqlParameter("@SI_MARQUEVEHICULE", SqlDbType.VarChar, 150);
            vppParamSI_MARQUEVEHICULE.Value = clsCtsinistre.SI_MARQUEVEHICULE;
            if (clsCtsinistre.SI_MARQUEVEHICULE == "") vppParamSI_MARQUEVEHICULE.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMETCONTACTSVICTIMES = new SqlParameter("@SI_NOMETCONTACTSVICTIMES", SqlDbType.VarChar, 1000);
            vppParamSI_NOMETCONTACTSVICTIMES.Value = clsCtsinistre.SI_NOMETCONTACTSVICTIMES;
            if (clsCtsinistre.SI_NOMETCONTACTSVICTIMES == "") vppParamSI_NOMETCONTACTSVICTIMES.Value = DBNull.Value;

            SqlParameter vppParamSI_AILEARRIEREDROIT = new SqlParameter("@SI_AILEARRIEREDROIT", SqlDbType.VarChar, 50);
            vppParamSI_AILEARRIEREDROIT.Value = clsCtsinistre.SI_AILEARRIEREDROIT;
            if (clsCtsinistre.SI_AILEARRIEREDROIT == "") vppParamSI_AILEARRIEREDROIT.Value = DBNull.Value;

            SqlParameter vppParamSI_AILEARRIEREGAUCHE = new SqlParameter("@SI_AILEARRIEREGAUCHE", SqlDbType.VarChar, 50);
            vppParamSI_AILEARRIEREGAUCHE.Value = clsCtsinistre.SI_AILEARRIEREGAUCHE;
            if (clsCtsinistre.SI_AILEARRIEREGAUCHE == "") vppParamSI_AILEARRIEREGAUCHE.Value = DBNull.Value;

            SqlParameter vppParamSI_PARCHOCAVANT = new SqlParameter("@SI_PARCHOCAVANT", SqlDbType.VarChar, 50);
            vppParamSI_PARCHOCAVANT.Value = clsCtsinistre.SI_PARCHOCAVANT;
            if (clsCtsinistre.SI_PARCHOCAVANT == "") vppParamSI_PARCHOCAVANT.Value = DBNull.Value;

            SqlParameter vppParamSI_PARCHOCARRIERE = new SqlParameter("@SI_PARCHOCARRIERE", SqlDbType.VarChar, 50);
            vppParamSI_PARCHOCARRIERE.Value = clsCtsinistre.SI_PARCHOCARRIERE;
            if (clsCtsinistre.SI_PARCHOCARRIERE == "") vppParamSI_PARCHOCARRIERE.Value = DBNull.Value;

            SqlParameter vppParamSI_LATERALGAUCHE = new SqlParameter("@SI_LATERALGAUCHE", SqlDbType.VarChar, 50);
            vppParamSI_LATERALGAUCHE.Value = clsCtsinistre.SI_LATERALGAUCHE;
            if (clsCtsinistre.SI_LATERALGAUCHE == "") vppParamSI_LATERALGAUCHE.Value = DBNull.Value;

            SqlParameter vppParamSI_LATERALDROIT = new SqlParameter("@SI_LATERALDROIT", SqlDbType.VarChar, 50);
            vppParamSI_LATERALDROIT.Value = clsCtsinistre.SI_LATERALDROIT;
            if (clsCtsinistre.SI_LATERALDROIT == "") vppParamSI_LATERALDROIT.Value = DBNull.Value;

            SqlParameter vppParamSI_CAPOTMOTEUR = new SqlParameter("@SI_CAPOTMOTEUR", SqlDbType.VarChar, 50);
            vppParamSI_CAPOTMOTEUR.Value = clsCtsinistre.SI_CAPOTMOTEUR;
            if (clsCtsinistre.SI_CAPOTMOTEUR == "") vppParamSI_CAPOTMOTEUR.Value = DBNull.Value;

            SqlParameter vppParamSI_AUTRES = new SqlParameter("@SI_AUTRES", SqlDbType.VarChar, 1000);
            vppParamSI_AUTRES.Value = clsCtsinistre.SI_AUTRES;
            if (clsCtsinistre.SI_AUTRES == "") vppParamSI_AUTRES.Value = DBNull.Value;

            SqlParameter vppParamSI_REPARATEUR = new SqlParameter("@SI_REPARATEUR", SqlDbType.VarChar, 150);
            vppParamSI_REPARATEUR.Value = clsCtsinistre.SI_REPARATEUR;
            if (clsCtsinistre.SI_REPARATEUR == "") vppParamSI_REPARATEUR.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMBREBLESSESVEHICULEASSURE = new SqlParameter("@SI_NOMBREBLESSESVEHICULEASSURE", SqlDbType.VarChar, 50);
            vppParamSI_NOMBREBLESSESVEHICULEASSURE.Value = clsCtsinistre.SI_NOMBREBLESSESVEHICULEASSURE;
            if (clsCtsinistre.SI_NOMBREBLESSESVEHICULEASSURE == "") vppParamSI_NOMBREBLESSESVEHICULEASSURE.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMBREDECESVEHICULEASSURE = new SqlParameter("@SI_NOMBREDECESVEHICULEASSURE", SqlDbType.VarChar, 50);
            vppParamSI_NOMBREDECESVEHICULEASSURE.Value = clsCtsinistre.SI_NOMBREDECESVEHICULEASSURE;
            if (clsCtsinistre.SI_NOMBREDECESVEHICULEASSURE == "") vppParamSI_NOMBREDECESVEHICULEASSURE.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMBREBLESSESVEHICULETIERS = new SqlParameter("@SI_NOMBREBLESSESVEHICULETIERS", SqlDbType.VarChar, 50);
            vppParamSI_NOMBREBLESSESVEHICULETIERS.Value = clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS;
            if (clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS == "") vppParamSI_NOMBREBLESSESVEHICULETIERS.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMBREDECESVEHICULETIERS = new SqlParameter("@SI_NOMBREDECESVEHICULETIERS", SqlDbType.VarChar, 50);
            vppParamSI_NOMBREDECESVEHICULETIERS.Value = clsCtsinistre.SI_NOMBREDECESVEHICULETIERS;
            if (clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS == "") vppParamSI_NOMBREDECESVEHICULETIERS.Value = DBNull.Value;

            SqlParameter vppParamSI_PVCONSTATPOLICE = new SqlParameter("@SI_PVCONSTATPOLICE", SqlDbType.VarChar, 50);
            vppParamSI_PVCONSTATPOLICE.Value = clsCtsinistre.SI_PVCONSTATPOLICE;
            if (clsCtsinistre.SI_PVCONSTATPOLICE == "") vppParamSI_PVCONSTATPOLICE.Value = DBNull.Value;

            SqlParameter vppParamSI_PVGENDARMERIE = new SqlParameter("@SI_PVGENDARMERIE", SqlDbType.VarChar, 50);
            vppParamSI_PVGENDARMERIE.Value = clsCtsinistre.SI_PVGENDARMERIE;
            if (clsCtsinistre.SI_PVGENDARMERIE == "") vppParamSI_PVGENDARMERIE.Value = DBNull.Value;

            SqlParameter vppParamSI_PVAMIABLE = new SqlParameter("@SI_PVAMIABLE", SqlDbType.VarChar, 50);
            vppParamSI_PVAMIABLE.Value = clsCtsinistre.SI_PVAMIABLE;
            if (clsCtsinistre.SI_PVAMIABLE == "") vppParamSI_PVAMIABLE.Value = DBNull.Value;

            SqlParameter vppParamSI_UNITE = new SqlParameter("@SI_UNITE", SqlDbType.VarChar, 50);
            vppParamSI_UNITE.Value = clsCtsinistre.SI_UNITE;
            if (clsCtsinistre.SI_UNITE == "") vppParamSI_UNITE.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMAGENT = new SqlParameter("@SI_NOMAGENT", SqlDbType.VarChar, 150);
            vppParamSI_NOMAGENT.Value = clsCtsinistre.SI_NOMAGENT;
            if (clsCtsinistre.SI_UNITE == "") vppParamSI_NOMAGENT.Value = DBNull.Value;

            SqlParameter vppParamSI_TELPHONEAGENT = new SqlParameter("@SI_TELPHONEAGENT", SqlDbType.VarChar, 150);
            vppParamSI_TELPHONEAGENT.Value = clsCtsinistre.SI_TELPHONEAGENT;
            if (clsCtsinistre.SI_TELPHONEAGENT == "") vppParamSI_TELPHONEAGENT.Value = DBNull.Value;

            SqlParameter vppParamSI_HUSSIER = new SqlParameter("@SI_HUSSIER", SqlDbType.VarChar, 150);
            vppParamSI_HUSSIER.Value = clsCtsinistre.SI_HUSSIER;
            if (clsCtsinistre.SI_HUSSIER == "") vppParamSI_HUSSIER.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsCtsinistre.TYPEOPERATION;

            SqlParameter vppParamSI_CODESINISTRERETOUR = new SqlParameter("@SI_CODESINISTRERETOUR", SqlDbType.VarChar, 50);

            //Préparation de la commande

            SqlCommand vppSqlCmd = new SqlCommand("PC_CTSINISTRE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //this.vapRequete = "EXECUTE PC_CTCONTRAT  @CA_CODECONTRAT, @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_NUMPOLICE, @CA_DATESAISIE, @TI_IDTIERS, @IT_CODEINTERMEDIAIRE, @AP_CODETYPEAPPARTEMENT, @OC_CODETYPEOCCUPANT,  @ZA_CODEZONEAUTO, @CB_IDBRANCHE, @CA_DATEEFFET, @CA_DATEECHEANCE, @OP_CODEOPERATEUR, @CA_AVENANT, @CA_SITUATIONGEOGRAPHIQUE, @CA_CONDITIONHABITUEL, @ST_CODESTATUTSOCIOPROF, @AU_CODECATEGORIE, @TA_CODETARIF, @US_CODEUSAGE, @GE_CODEGENRE, @TVH_CODETYPE, @EN_CODEENERGIE, @CA_TAUX, @CA_TYPE, @CA_NUMSERIE, @CA_IMMATRICULATION, @CA_PUISSANCEADMISE, @CA_CHARGEUTILE, @CA_NBREPLACE, @CA_VALNEUVE, @CA_VALVENALE, @CA_DATEMISECIRCULATION, @CA_CLIENTEXONERETAXE, @TI_IDTIERSCOMMERCIAL, @TI_IDTIERSASSUREUR, @CA_DATETRANSMISSIONAASSUREUR, @CA_DATEVALIDATIONASSUREUR,   @CA_DATESUSPENSION, @CA_DATECLOTURE, @CA_DATERESILIATION, @CA_NOMINTERLOCUTEUR, @CA_CONTACTINTERLOCUTEUR, @DI_CODEDESIGNATION, @TA_CODETYPECONTRATSANTE, @CA_CODECONTRATSECONDAIRE,  @CO_CODECOMMUNE, @RQ_CODERISQUE, @CODECRYPTAGE, @TYPEOPERATION ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamNS_CODENATURESINISTRE);
            vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
            vppSqlCmd.Parameters.Add(vppParamSI_NUMSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATESINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_HEURESINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
            vppSqlCmd.Parameters.Add(vppParamSI_ADRESSEGEOGRPHIQUESINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DESCRIPTIONSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATETRANSMISSIONSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATEVALIDATIONSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATESUSPENSIONSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATECLOTURESINISTRE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamSI_DOCUMENTTRANSMIS);
            vppSqlCmd.Parameters.Add(vppParamSI_MONTANTPREJUDICE);
            vppSqlCmd.Parameters.Add(vppParamEP_CODEEXPERTNOMME);
            vppSqlCmd.Parameters.Add(vppParamSI_DATEEXPERTNOMMESINISTRE);

            vppSqlCmd.Parameters.Add(vppParamSI_MONTANTPREJUDICEVALIDER);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER);
            vppSqlCmd.Parameters.Add(vppParamSI_DATESAISIEMONTANTVALIDER);


            vppSqlCmd.Parameters.Add(vppParamSI_TELEPHONECONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_NUMWHATSAPPCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATENAISSANCECONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_NUMPERMISCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATEVALIDITEPERMISCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_IMMATRICULATIONVEHICULE);




            vppSqlCmd.Parameters.Add(vppParamSI_MARQUEVEHICULE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMETCONTACTSVICTIMES);
            vppSqlCmd.Parameters.Add(vppParamSI_AILEARRIEREDROIT);
            vppSqlCmd.Parameters.Add(vppParamSI_AILEARRIEREGAUCHE);
            vppSqlCmd.Parameters.Add(vppParamSI_PARCHOCAVANT);
            vppSqlCmd.Parameters.Add(vppParamSI_PARCHOCARRIERE);
            vppSqlCmd.Parameters.Add(vppParamSI_LATERALGAUCHE);
            vppSqlCmd.Parameters.Add(vppParamSI_LATERALDROIT);



            vppSqlCmd.Parameters.Add(vppParamSI_CAPOTMOTEUR);
            vppSqlCmd.Parameters.Add(vppParamSI_AUTRES);
            vppSqlCmd.Parameters.Add(vppParamSI_REPARATEUR);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMBREBLESSESVEHICULEASSURE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMBREDECESVEHICULEASSURE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMBREBLESSESVEHICULETIERS);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMBREDECESVEHICULETIERS);
            vppSqlCmd.Parameters.Add(vppParamSI_PVCONSTATPOLICE);
            vppSqlCmd.Parameters.Add(vppParamSI_PVGENDARMERIE);
            vppSqlCmd.Parameters.Add(vppParamSI_PVAMIABLE);
            vppSqlCmd.Parameters.Add(vppParamSI_UNITE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMAGENT);
            vppSqlCmd.Parameters.Add(vppParamSI_TELPHONEAGENT);
            vppSqlCmd.Parameters.Add(vppParamSI_HUSSIER);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRERETOUR);
            vppParamSI_CODESINISTRERETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@SI_CODESINISTRERETOUR"].Value.ToString();


            //vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            //vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRATRETOUR);
            //vppParamCA_CODECONTRATRETOUR.Direction = ParameterDirection.Output;


            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            //// valeurs de retour de la procedure stockée
            //return vppSqlCmd.Parameters["@CA_CODECONTRATRETOUR"].Value.ToString();



            //Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }




        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsCtsinistre>clsCtsinistre</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsCtsinistre clsCtsinistre,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistre.SI_CODESINISTRE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtsinistre.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtsinistre.EN_CODEENTREPOT ;
			SqlParameter vppParamNS_CODENATURESINISTRE = new SqlParameter("@NS_CODENATURESINISTRE", SqlDbType.VarChar, 4);
			vppParamNS_CODENATURESINISTRE.Value  = clsCtsinistre.NS_CODENATURESINISTRE ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtsinistre.CA_CODECONTRAT ;
			SqlParameter vppParamSI_NUMSINISTRE = new SqlParameter("@SI_NUMSINISTRE", SqlDbType.VarChar, 1000);
			vppParamSI_NUMSINISTRE.Value  = clsCtsinistre.SI_NUMSINISTRE ;
			SqlParameter vppParamSI_DATESAISIE = new SqlParameter("@SI_DATESAISIE", SqlDbType.DateTime);
			vppParamSI_DATESAISIE.Value  = clsCtsinistre.SI_DATESAISIE ;
			SqlParameter vppParamSI_DATESINISTRE = new SqlParameter("@SI_DATESINISTRE", SqlDbType.DateTime);
			vppParamSI_DATESINISTRE.Value  = clsCtsinistre.SI_DATESINISTRE ;
			SqlParameter vppParamSI_HEURESINISTRE = new SqlParameter("@SI_HEURESINISTRE", SqlDbType.DateTime);
			vppParamSI_HEURESINISTRE.Value  = clsCtsinistre.SI_HEURESINISTRE ;
			SqlParameter vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE = new SqlParameter("@SI_NOMPRENOMSCONDUCTEURSINISTRE", SqlDbType.VarChar, 1000);
			vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE.Value  = clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE ;
			if(clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE== ""  ) vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE.Value  = DBNull.Value;
			SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
			vppParamCO_CODECOMMUNE.Value  = clsCtsinistre.CO_CODECOMMUNE ;
			SqlParameter vppParamSI_ADRESSEGEOGRPHIQUESINISTRE = new SqlParameter("@SI_ADRESSEGEOGRPHIQUESINISTRE", SqlDbType.VarChar, 1000);
			vppParamSI_ADRESSEGEOGRPHIQUESINISTRE.Value  = clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE ;
			SqlParameter vppParamSI_DESCRIPTIONSINISTRE = new SqlParameter("@SI_DESCRIPTIONSINISTRE", SqlDbType.VarChar, 1000);
			vppParamSI_DESCRIPTIONSINISTRE.Value  = clsCtsinistre.SI_DESCRIPTIONSINISTRE ;
			SqlParameter vppParamSI_DATETRANSMISSIONSINISTRE = new SqlParameter("@SI_DATETRANSMISSIONSINISTRE", SqlDbType.DateTime);
			vppParamSI_DATETRANSMISSIONSINISTRE.Value  = clsCtsinistre.SI_DATETRANSMISSIONSINISTRE ;
			SqlParameter vppParamSI_DATEVALIDATIONSINISTRE = new SqlParameter("@SI_DATEVALIDATIONSINISTRE", SqlDbType.DateTime);
			vppParamSI_DATEVALIDATIONSINISTRE.Value  = clsCtsinistre.SI_DATEVALIDATIONSINISTRE ;
			SqlParameter vppParamSI_DATESUSPENSIONSINISTRE = new SqlParameter("@SI_DATESUSPENSIONSINISTRE", SqlDbType.DateTime);
			vppParamSI_DATESUSPENSIONSINISTRE.Value  = clsCtsinistre.SI_DATESUSPENSIONSINISTRE ;
			SqlParameter vppParamSI_DATECLOTURESINISTRE = new SqlParameter("@SI_DATECLOTURESINISTRE", SqlDbType.DateTime);
			vppParamSI_DATECLOTURESINISTRE.Value  = clsCtsinistre.SI_DATECLOTURESINISTRE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinistre.OP_CODEOPERATEUR ;
			SqlParameter vppParamSI_DOCUMENTTRANSMIS = new SqlParameter("@SI_DOCUMENTTRANSMIS", SqlDbType.VarChar, 1000);
			vppParamSI_DOCUMENTTRANSMIS.Value  = clsCtsinistre.SI_DOCUMENTTRANSMIS ;
			if(clsCtsinistre.SI_DOCUMENTTRANSMIS== ""  ) vppParamSI_DOCUMENTTRANSMIS.Value  = DBNull.Value;
			SqlParameter vppParamSI_MONTANTPREJUDICE = new SqlParameter("@SI_MONTANTPREJUDICE", SqlDbType.Money);
			vppParamSI_MONTANTPREJUDICE.Value  = clsCtsinistre.SI_MONTANTPREJUDICE ;
			SqlParameter vppParamEP_CODEEXPERTNOMME = new SqlParameter("@EP_CODEEXPERTNOMME", SqlDbType.VarChar, 50);
			vppParamEP_CODEEXPERTNOMME.Value  = clsCtsinistre.EP_CODEEXPERTNOMME ;
			if(clsCtsinistre.EP_CODEEXPERTNOMME== ""  ) vppParamEP_CODEEXPERTNOMME.Value  = DBNull.Value;
			SqlParameter vppParamSI_DATEEXPERTNOMMESINISTRE = new SqlParameter("@SI_DATEEXPERTNOMMESINISTRE", SqlDbType.DateTime);
			vppParamSI_DATEEXPERTNOMMESINISTRE.Value  = clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE ;
			if(clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE.Year < 1900 ) vppParamSI_DATEEXPERTNOMMESINISTRE.Value  = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_MONTANTPREJUDICEVALIDER = new SqlParameter("@SI_MONTANTPREJUDICEVALIDER", SqlDbType.Money);
            vppParamSI_MONTANTPREJUDICEVALIDER.Value = clsCtsinistre.SI_MONTANTPREJUDICEVALIDER;

            SqlParameter vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER = new SqlParameter("@OP_CODEOPERATEURSAISIEMONTANTVALIDER", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER.Value = clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER;
            if (clsCtsinistre.OP_CODEOPERATEURSAISIEMONTANTVALIDER == "") vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER.Value = DBNull.Value;

            SqlParameter vppParamSI_DATESAISIEMONTANTVALIDER = new SqlParameter("@SI_DATESAISIEMONTANTVALIDER", SqlDbType.DateTime);
            vppParamSI_DATESAISIEMONTANTVALIDER.Value = clsCtsinistre.SI_DATESAISIEMONTANTVALIDER;
            if (clsCtsinistre.SI_DATESAISIEMONTANTVALIDER.Year < 1900) vppParamSI_DATESAISIEMONTANTVALIDER.Value = DateTime.Parse("01/01/1900");




            SqlParameter vppParamSI_TELEPHONECONDUCTEURSINISTRE = new SqlParameter("@SI_TELEPHONECONDUCTEURSINISTRE", SqlDbType.VarChar, 150);
            vppParamSI_TELEPHONECONDUCTEURSINISTRE.Value = clsCtsinistre.SI_TELEPHONECONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_TELEPHONECONDUCTEURSINISTRE == "") vppParamSI_TELEPHONECONDUCTEURSINISTRE.Value = DBNull.Value;

            SqlParameter vppParamSI_NUMWHATSAPPCONDUCTEURSINISTRE = new SqlParameter("@SI_NUMWHATSAPPCONDUCTEURSINISTRE", SqlDbType.VarChar, 150);
            vppParamSI_NUMWHATSAPPCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_NUMWHATSAPPCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_NUMWHATSAPPCONDUCTEURSINISTRE == "") vppParamSI_NUMWHATSAPPCONDUCTEURSINISTRE.Value = DBNull.Value;

            SqlParameter vppParamSI_DATENAISSANCECONDUCTEURSINISTRE = new SqlParameter("@SI_DATENAISSANCECONDUCTEURSINISTRE", SqlDbType.DateTime);
            vppParamSI_DATENAISSANCECONDUCTEURSINISTRE.Value = clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_DATENAISSANCECONDUCTEURSINISTRE.Year < 1900) vppParamSI_DATENAISSANCECONDUCTEURSINISTRE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_NUMPERMISCONDUCTEURSINISTRE = new SqlParameter("@SI_NUMPERMISCONDUCTEURSINISTRE", SqlDbType.VarChar, 150);
            vppParamSI_NUMPERMISCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_NUMPERMISCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_NUMPERMISCONDUCTEURSINISTRE == "") vppParamSI_NUMPERMISCONDUCTEURSINISTRE.Value = DBNull.Value;

            SqlParameter vppParamSI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE = new SqlParameter("@SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE",  SqlDbType.DateTime);
            vppParamSI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE.Year < 1900) vppParamSI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_DATEVALIDITEPERMISCONDUCTEURSINISTRE = new SqlParameter("@SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE", SqlDbType.DateTime);
            vppParamSI_DATEVALIDITEPERMISCONDUCTEURSINISTRE.Value = clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE;
            if (clsCtsinistre.SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE.Year < 1900) vppParamSI_DATEVALIDITEPERMISCONDUCTEURSINISTRE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamSI_IMMATRICULATIONVEHICULE = new SqlParameter("@SI_IMMATRICULATIONVEHICULE", SqlDbType.VarChar, 150);
            vppParamSI_IMMATRICULATIONVEHICULE.Value = clsCtsinistre.SI_IMMATRICULATIONVEHICULE;
            if (clsCtsinistre.SI_IMMATRICULATIONVEHICULE == "") vppParamSI_IMMATRICULATIONVEHICULE.Value = DBNull.Value;


            SqlParameter vppParamSI_MARQUEVEHICULE = new SqlParameter("@SI_MARQUEVEHICULE", SqlDbType.VarChar, 150);
            vppParamSI_MARQUEVEHICULE.Value = clsCtsinistre.SI_MARQUEVEHICULE;
            if (clsCtsinistre.SI_MARQUEVEHICULE == "") vppParamSI_MARQUEVEHICULE.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMETCONTACTSVICTIMES = new SqlParameter("@SI_NOMETCONTACTSVICTIMES", SqlDbType.VarChar, 1000);
            vppParamSI_NOMETCONTACTSVICTIMES.Value = clsCtsinistre.SI_NOMETCONTACTSVICTIMES;
            if (clsCtsinistre.SI_NOMETCONTACTSVICTIMES == "") vppParamSI_NOMETCONTACTSVICTIMES.Value = DBNull.Value;

            SqlParameter vppParamSI_AILEARRIEREDROIT = new SqlParameter("@SI_AILEARRIEREDROIT", SqlDbType.VarChar, 50);
            vppParamSI_AILEARRIEREDROIT.Value = clsCtsinistre.SI_AILEARRIEREDROIT;
            if (clsCtsinistre.SI_AILEARRIEREDROIT == "") vppParamSI_AILEARRIEREDROIT.Value = DBNull.Value;

            SqlParameter vppParamSI_AILEARRIEREGAUCHE = new SqlParameter("@SI_AILEARRIEREGAUCHE", SqlDbType.VarChar, 50);
            vppParamSI_AILEARRIEREGAUCHE.Value = clsCtsinistre.SI_AILEARRIEREGAUCHE;
            if (clsCtsinistre.SI_AILEARRIEREGAUCHE == "") vppParamSI_AILEARRIEREGAUCHE.Value = DBNull.Value;

            SqlParameter vppParamSI_PARCHOCAVANT = new SqlParameter("@SI_PARCHOCAVANT", SqlDbType.VarChar, 50);
            vppParamSI_PARCHOCAVANT.Value = clsCtsinistre.SI_PARCHOCAVANT;
            if (clsCtsinistre.SI_PARCHOCAVANT == "") vppParamSI_PARCHOCAVANT.Value = DBNull.Value;

            SqlParameter vppParamSI_PARCHOCARRIERE = new SqlParameter("@SI_PARCHOCARRIERE", SqlDbType.VarChar, 50);
            vppParamSI_PARCHOCARRIERE.Value = clsCtsinistre.SI_PARCHOCARRIERE;
            if (clsCtsinistre.SI_PARCHOCARRIERE == "") vppParamSI_PARCHOCARRIERE.Value = DBNull.Value;

            SqlParameter vppParamSI_LATERALGAUCHE = new SqlParameter("@SI_LATERALGAUCHE", SqlDbType.VarChar, 50);
            vppParamSI_LATERALGAUCHE.Value = clsCtsinistre.SI_LATERALGAUCHE;
            if (clsCtsinistre.SI_LATERALGAUCHE == "") vppParamSI_LATERALGAUCHE.Value = DBNull.Value;

            SqlParameter vppParamSI_LATERALDROIT = new SqlParameter("@SI_LATERALDROIT", SqlDbType.VarChar, 50);
            vppParamSI_LATERALDROIT.Value = clsCtsinistre.SI_LATERALDROIT;
            if (clsCtsinistre.SI_LATERALDROIT == "") vppParamSI_LATERALDROIT.Value = DBNull.Value;

            SqlParameter vppParamSI_CAPOTMOTEUR = new SqlParameter("@SI_CAPOTMOTEUR", SqlDbType.VarChar, 50);
            vppParamSI_CAPOTMOTEUR.Value = clsCtsinistre.SI_CAPOTMOTEUR;
            if (clsCtsinistre.SI_CAPOTMOTEUR == "") vppParamSI_CAPOTMOTEUR.Value = DBNull.Value;

            SqlParameter vppParamSI_AUTRES = new SqlParameter("@SI_AUTRES", SqlDbType.VarChar, 1000);
            vppParamSI_AUTRES.Value = clsCtsinistre.SI_AUTRES;
            if (clsCtsinistre.SI_AUTRES == "") vppParamSI_AUTRES.Value = DBNull.Value;

            SqlParameter vppParamSI_REPARATEUR = new SqlParameter("@SI_REPARATEUR", SqlDbType.VarChar, 150);
            vppParamSI_REPARATEUR.Value = clsCtsinistre.SI_REPARATEUR;
            if (clsCtsinistre.SI_REPARATEUR == "") vppParamSI_REPARATEUR.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMBREBLESSESVEHICULEASSURE = new SqlParameter("@SI_NOMBREBLESSESVEHICULEASSURE", SqlDbType.VarChar, 50);
            vppParamSI_NOMBREBLESSESVEHICULEASSURE.Value = clsCtsinistre.SI_NOMBREBLESSESVEHICULEASSURE;
            if (clsCtsinistre.SI_NOMBREBLESSESVEHICULEASSURE == "") vppParamSI_NOMBREBLESSESVEHICULEASSURE.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMBREDECESVEHICULEASSURE = new SqlParameter("@SI_NOMBREDECESVEHICULEASSURE", SqlDbType.VarChar, 50);
            vppParamSI_NOMBREDECESVEHICULEASSURE.Value = clsCtsinistre.SI_NOMBREDECESVEHICULEASSURE;
            if (clsCtsinistre.SI_NOMBREDECESVEHICULEASSURE == "") vppParamSI_NOMBREDECESVEHICULEASSURE.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMBREBLESSESVEHICULETIERS = new SqlParameter("@SI_NOMBREBLESSESVEHICULETIERS", SqlDbType.VarChar, 50);
            vppParamSI_NOMBREBLESSESVEHICULETIERS.Value = clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS;
            if (clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS == "") vppParamSI_NOMBREBLESSESVEHICULETIERS.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMBREDECESVEHICULETIERS = new SqlParameter("@SI_NOMBREDECESVEHICULETIERS", SqlDbType.VarChar, 50);
            vppParamSI_NOMBREDECESVEHICULETIERS.Value = clsCtsinistre.SI_NOMBREDECESVEHICULETIERS;
            if (clsCtsinistre.SI_NOMBREBLESSESVEHICULETIERS == "") vppParamSI_NOMBREDECESVEHICULETIERS.Value = DBNull.Value;

            SqlParameter vppParamSI_PVCONSTATPOLICE = new SqlParameter("@SI_PVCONSTATPOLICE", SqlDbType.VarChar, 50);
            vppParamSI_PVCONSTATPOLICE.Value = clsCtsinistre.SI_PVCONSTATPOLICE;
            if (clsCtsinistre.SI_PVCONSTATPOLICE == "") vppParamSI_PVCONSTATPOLICE.Value = DBNull.Value;

            SqlParameter vppParamSI_PVGENDARMERIE = new SqlParameter("@SI_PVGENDARMERIE", SqlDbType.VarChar, 50);
            vppParamSI_PVGENDARMERIE.Value = clsCtsinistre.SI_PVGENDARMERIE;
            if (clsCtsinistre.SI_PVGENDARMERIE == "") vppParamSI_PVGENDARMERIE.Value = DBNull.Value;

            SqlParameter vppParamSI_PVAMIABLE = new SqlParameter("@SI_PVAMIABLE", SqlDbType.VarChar, 50);
            vppParamSI_PVAMIABLE.Value = clsCtsinistre.SI_PVAMIABLE;
            if (clsCtsinistre.SI_PVAMIABLE == "") vppParamSI_PVAMIABLE.Value = DBNull.Value;

            SqlParameter vppParamSI_UNITE = new SqlParameter("@SI_UNITE", SqlDbType.VarChar, 50);
            vppParamSI_UNITE.Value = clsCtsinistre.SI_UNITE;
            if (clsCtsinistre.SI_UNITE == "") vppParamSI_UNITE.Value = DBNull.Value;

            SqlParameter vppParamSI_NOMAGENT = new SqlParameter("@SI_NOMAGENT", SqlDbType.VarChar, 150);
            vppParamSI_NOMAGENT.Value = clsCtsinistre.SI_NOMAGENT;
            if (clsCtsinistre.SI_UNITE == "") vppParamSI_NOMAGENT.Value = DBNull.Value;

            SqlParameter vppParamSI_TELPHONEAGENT = new SqlParameter("@SI_TELPHONEAGENT", SqlDbType.VarChar, 150);
            vppParamSI_TELPHONEAGENT.Value = clsCtsinistre.SI_TELPHONEAGENT;
            if (clsCtsinistre.SI_TELPHONEAGENT == "") vppParamSI_TELPHONEAGENT.Value = DBNull.Value;

            SqlParameter vppParamSI_HUSSIER = new SqlParameter("@SI_HUSSIER", SqlDbType.VarChar, 150);
            vppParamSI_HUSSIER.Value = clsCtsinistre.SI_HUSSIER;
            if (clsCtsinistre.SI_HUSSIER == "") vppParamSI_HUSSIER.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsCtsinistre.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_CTSINISTRE  @SI_CODESINISTRE, @AG_CODEAGENCE, @EN_CODEENTREPOT, @NS_CODENATURESINISTRE, @CA_CODECONTRAT, @SI_NUMSINISTRE, @SI_DATESAISIE, @SI_DATESINISTRE, @SI_HEURESINISTRE, @SI_NOMPRENOMSCONDUCTEURSINISTRE, @CO_CODECOMMUNE, @SI_ADRESSEGEOGRPHIQUESINISTRE, @SI_DESCRIPTIONSINISTRE, @SI_DATETRANSMISSIONSINISTRE, @SI_DATEVALIDATIONSINISTRE, @SI_DATESUSPENSIONSINISTRE, @SI_DATECLOTURESINISTRE, @OP_CODEOPERATEUR, @SI_DOCUMENTTRANSMIS, @SI_MONTANTPREJUDICE, @EP_CODEEXPERTNOMME, @SI_DATEEXPERTNOMMESINISTRE,@SI_MONTANTPREJUDICEVALIDER,@OP_CODEOPERATEURSAISIEMONTANTVALIDER,@SI_DATESAISIEMONTANTVALIDER,@SI_TELEPHONECONDUCTEURSINISTRE,@SI_NUMWHATSAPPCONDUCTEURSINISTRE,@SI_DATENAISSANCECONDUCTEURSINISTRE,@SI_NUMPERMISCONDUCTEURSINISTRE	,@SI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE,@SI_DATEVALIDITEPERMISCONDUCTEURSINISTRE,@SI_IMMATRICULATIONVEHICULE,@SI_MARQUEVEHICULE,@SI_NOMETCONTACTSVICTIMES,@SI_AILEARRIEREDROIT,@SI_AILEARRIEREGAUCHE,@SI_PARCHOCAVANT,@SI_PARCHOCARRIERE,@SI_LATERALGAUCHE,@SI_LATERALDROIT,@SI_CAPOTMOTEUR,@SI_AUTRES,@SI_REPARATEUR,@SI_NOMBREBLESSESVEHICULEASSURE	,@SI_NOMBREDECESVEHICULEASSURE,@SI_NOMBREBLESSESVEHICULETIERS,@SI_NOMBREDECESVEHICULETIERS	,@SI_PVCONSTATPOLICE,@SI_PVGENDARMERIE,@SI_PVAMIABLE,@SI_UNITE,@SI_NOMAGENT,@SI_TELPHONEAGENT,@SI_HUSSIER, @CODECRYPTAGE, @TYPEOPERATION,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamNS_CODENATURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamSI_NUMSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_HEURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_NOMPRENOMSCONDUCTEURSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
			vppSqlCmd.Parameters.Add(vppParamSI_ADRESSEGEOGRPHIQUESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DESCRIPTIONSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATETRANSMISSIONSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATEVALIDATIONSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATESUSPENSIONSINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_DATECLOTURESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamSI_DOCUMENTTRANSMIS);
			vppSqlCmd.Parameters.Add(vppParamSI_MONTANTPREJUDICE);
			vppSqlCmd.Parameters.Add(vppParamEP_CODEEXPERTNOMME);
			vppSqlCmd.Parameters.Add(vppParamSI_DATEEXPERTNOMMESINISTRE);

            vppSqlCmd.Parameters.Add(vppParamSI_MONTANTPREJUDICEVALIDER);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURSAISIEMONTANTVALIDER);
            vppSqlCmd.Parameters.Add(vppParamSI_DATESAISIEMONTANTVALIDER);



            vppSqlCmd.Parameters.Add(vppParamSI_TELEPHONECONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_NUMWHATSAPPCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATENAISSANCECONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_NUMPERMISCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATEDELIVRANCEPERMISCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_DATEVALIDITEPERMISCONDUCTEURSINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_IMMATRICULATIONVEHICULE);




            vppSqlCmd.Parameters.Add(vppParamSI_MARQUEVEHICULE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMETCONTACTSVICTIMES);
            vppSqlCmd.Parameters.Add(vppParamSI_AILEARRIEREDROIT);
            vppSqlCmd.Parameters.Add(vppParamSI_AILEARRIEREGAUCHE);
            vppSqlCmd.Parameters.Add(vppParamSI_PARCHOCAVANT);
            vppSqlCmd.Parameters.Add(vppParamSI_PARCHOCARRIERE);
            vppSqlCmd.Parameters.Add(vppParamSI_LATERALGAUCHE);
            vppSqlCmd.Parameters.Add(vppParamSI_LATERALDROIT);



            vppSqlCmd.Parameters.Add(vppParamSI_CAPOTMOTEUR);
            vppSqlCmd.Parameters.Add(vppParamSI_AUTRES);
            vppSqlCmd.Parameters.Add(vppParamSI_REPARATEUR);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMBREBLESSESVEHICULEASSURE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMBREDECESVEHICULEASSURE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMBREBLESSESVEHICULETIERS);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMBREDECESVEHICULETIERS);
            vppSqlCmd.Parameters.Add(vppParamSI_PVCONSTATPOLICE);
            vppSqlCmd.Parameters.Add(vppParamSI_PVGENDARMERIE);
            vppSqlCmd.Parameters.Add(vppParamSI_PVAMIABLE);
            vppSqlCmd.Parameters.Add(vppParamSI_UNITE);
            vppSqlCmd.Parameters.Add(vppParamSI_NOMAGENT);
            vppSqlCmd.Parameters.Add(vppParamSI_TELPHONEAGENT);
            vppSqlCmd.Parameters.Add(vppParamSI_HUSSIER);



            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRE  @SI_CODESINISTRE, '', '' , '' , '' , '' , '' , '' , '' , '' , '', '' , '' , '' , '' , '' , '' , '', '' , '' , '' , '' ,'','','','','','',''	,'','','','','','','','','','','','','','',''	,'','',''	,'','','','','','','', @CODECRYPTAGE, 2,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}



        public void pvgDeletePhoto(clsDonnee clsDonnee, DataSet DataSet)
        {

            string pathImage = "";
            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            pathImage = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT3").PP_VALEUR;

            for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
            {
                //---Test de l'exitance du chemin de sauvegarde
                if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["SI_CHEMINPHOTO"].ToString() + ".jpg"))
                {
                    pvgSupprimerPhotoSignature(pathImage + DataSet.Tables[0].Rows[Idx]["SI_CHEMINPHOTO"].ToString() + ".jpg");
                    //DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
                }

            }

        }


        public bool pvgSupprimerPhotoSignature(string chemin)
        {
            bool vlpResultat = false;
            if (File.Exists(chemin))
            {
                File.Delete(chemin);
                if (!File.Exists(chemin))
                    vlpResultat = true;
            }


            return vlpResultat;
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsCtsinistre </returns>
        ///<author>Home Technology</author>
        public List<clsCtsinistre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SI_CODESINISTRE, AG_CODEAGENCE, EN_CODEENTREPOT, NS_CODENATURESINISTRE, CA_CODECONTRAT, SI_NUMSINISTRE, SI_DATESAISIE, SI_DATESINISTRE, SI_HEURESINISTRE, SI_NOMPRENOMSCONDUCTEURSINISTRE, CO_CODECOMMUNE, SI_ADRESSEGEOGRPHIQUESINISTRE, SI_DESCRIPTIONSINISTRE, SI_DATETRANSMISSIONSINISTRE, SI_DATEVALIDATIONSINISTRE, SI_DATESUSPENSIONSINISTRE, SI_DATECLOTURESINISTRE, OP_CODEOPERATEUR, SI_DOCUMENTTRANSMIS, SI_MONTANTPREJUDICE, EP_CODEEXPERTNOMME, SI_DATEEXPERTNOMMESINISTRE FROM dbo.FT_CTSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtsinistre> clsCtsinistres = new List<clsCtsinistre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistre clsCtsinistre = new clsCtsinistre();
					clsCtsinistre.SI_CODESINISTRE = clsDonnee.vogDataReader["SI_CODESINISTRE"].ToString();
					clsCtsinistre.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtsinistre.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtsinistre.NS_CODENATURESINISTRE = clsDonnee.vogDataReader["NS_CODENATURESINISTRE"].ToString();
					clsCtsinistre.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtsinistre.SI_NUMSINISTRE = clsDonnee.vogDataReader["SI_NUMSINISTRE"].ToString();
					clsCtsinistre.SI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATESAISIE"].ToString());
					clsCtsinistre.SI_DATESINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATESINISTRE"].ToString());
					clsCtsinistre.SI_HEURESINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_HEURESINISTRE"].ToString());
					clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = clsDonnee.vogDataReader["SI_NOMPRENOMSCONDUCTEURSINISTRE"].ToString();
					clsCtsinistre.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();
					clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = clsDonnee.vogDataReader["SI_ADRESSEGEOGRPHIQUESINISTRE"].ToString();
					clsCtsinistre.SI_DESCRIPTIONSINISTRE = clsDonnee.vogDataReader["SI_DESCRIPTIONSINISTRE"].ToString();
					clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATETRANSMISSIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATEVALIDATIONSINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATEVALIDATIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATESUSPENSIONSINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATESUSPENSIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATECLOTURESINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATECLOTURESINISTRE"].ToString());
					clsCtsinistre.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtsinistre.SI_DOCUMENTTRANSMIS = clsDonnee.vogDataReader["SI_DOCUMENTTRANSMIS"].ToString();
					clsCtsinistre.SI_MONTANTPREJUDICE = double.Parse(clsDonnee.vogDataReader["SI_MONTANTPREJUDICE"].ToString());
					clsCtsinistre.EP_CODEEXPERTNOMME = clsDonnee.vogDataReader["EP_CODEEXPERTNOMME"].ToString();
					clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = DateTime.Parse(clsDonnee.vogDataReader["SI_DATEEXPERTNOMMESINISTRE"].ToString());
					clsCtsinistres.Add(clsCtsinistre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtsinistres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistre </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtsinistre> clsCtsinistres = new List<clsCtsinistre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SI_CODESINISTRE, AG_CODEAGENCE, EN_CODEENTREPOT, NS_CODENATURESINISTRE, CA_CODECONTRAT, SI_NUMSINISTRE, SI_DATESAISIE, SI_DATESINISTRE, SI_HEURESINISTRE, SI_NOMPRENOMSCONDUCTEURSINISTRE, CO_CODECOMMUNE, SI_ADRESSEGEOGRPHIQUESINISTRE, SI_DESCRIPTIONSINISTRE, SI_DATETRANSMISSIONSINISTRE, SI_DATEVALIDATIONSINISTRE, SI_DATESUSPENSIONSINISTRE, SI_DATECLOTURESINISTRE, OP_CODEOPERATEUR, SI_DOCUMENTTRANSMIS, SI_MONTANTPREJUDICE, EP_CODEEXPERTNOMME, SI_DATEEXPERTNOMMESINISTRE FROM dbo.FT_CTSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtsinistre clsCtsinistre = new clsCtsinistre();
					clsCtsinistre.SI_CODESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_CODESINISTRE"].ToString();
					clsCtsinistre.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtsinistre.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtsinistre.NS_CODENATURESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["NS_CODENATURESINISTRE"].ToString();
					clsCtsinistre.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtsinistre.SI_NUMSINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_NUMSINISTRE"].ToString();
					clsCtsinistre.SI_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_DATESAISIE"].ToString());
					clsCtsinistre.SI_DATESINISTRE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_DATESINISTRE"].ToString());
					clsCtsinistre.SI_HEURESINISTRE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_HEURESINISTRE"].ToString());
					clsCtsinistre.SI_NOMPRENOMSCONDUCTEURSINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_NOMPRENOMSCONDUCTEURSINISTRE"].ToString();
					clsCtsinistre.CO_CODECOMMUNE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMMUNE"].ToString();
					clsCtsinistre.SI_ADRESSEGEOGRPHIQUESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_ADRESSEGEOGRPHIQUESINISTRE"].ToString();
					clsCtsinistre.SI_DESCRIPTIONSINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_DESCRIPTIONSINISTRE"].ToString();
					clsCtsinistre.SI_DATETRANSMISSIONSINISTRE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_DATETRANSMISSIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATEVALIDATIONSINISTRE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_DATEVALIDATIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATESUSPENSIONSINISTRE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_DATESUSPENSIONSINISTRE"].ToString());
					clsCtsinistre.SI_DATECLOTURESINISTRE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_DATECLOTURESINISTRE"].ToString());
					clsCtsinistre.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtsinistre.SI_DOCUMENTTRANSMIS = Dataset.Tables["TABLE"].Rows[Idx]["SI_DOCUMENTTRANSMIS"].ToString();
					clsCtsinistre.SI_MONTANTPREJUDICE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_MONTANTPREJUDICE"].ToString());
					clsCtsinistre.EP_CODEEXPERTNOMME = Dataset.Tables["TABLE"].Rows[Idx]["EP_CODEEXPERTNOMME"].ToString();
					clsCtsinistre.SI_DATEEXPERTNOMMESINISTRE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SI_DATEEXPERTNOMMESINISTRE"].ToString());
					clsCtsinistres.Add(clsCtsinistre);
				}
				Dataset.Dispose();
			}
		return clsCtsinistres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CA_NUMPOLICE", "@CA_CODECONTRAT" , "@NS_CODENATURESINISTRE", "@SI_NUMSINISTRE", "@TI_NUMTIERS", "@TI_DENOMINATION" , "@MS_DATEPIECEDEBUT" , "@MS_DATEPIECEFIN", "@OP_CODEOPERATEUREDITION" , "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] , vppCritere[5], vppCritere[6] , vppCritere[7] , vppCritere[8], vppCritere[9] , vppCritere[10], vppCritere[11] };
            this.vapRequete = "EXEC  [dbo].[PS_CTSINISTRE] @AG_CODEAGENCE,@EN_CODEENTREPOT,@CA_NUMPOLICE,@CA_CODECONTRAT,@NS_CODENATURESINISTRE,@SI_NUMSINISTRE,@TI_NUMTIERS,@TI_DENOMINATION,@MS_DATEPIECEDEBUT  ,@MS_DATEPIECEFIN  ,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SI_CODESINISTRE , SI_NUMSINISTRE FROM dbo.FT_CTSINISTRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SI_CODESINISTRE, AG_CODEAGENCE, CO_CODECOMMUNE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE SI_CODESINISTRE=@SI_CODESINISTRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SI_CODESINISTRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE SI_CODESINISTRE=@SI_CODESINISTRE AND AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@SI_CODESINISTRE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE SI_CODESINISTRE=@SI_CODESINISTRE AND AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECOMMUNE=@CO_CODECOMMUNE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SI_CODESINISTRE","@AG_CODEAGENCE","@CO_CODECOMMUNE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE SI_CODESINISTRE=@SI_CODESINISTRE AND AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECOMMUNE=@CO_CODECOMMUNE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SI_CODESINISTRE","@AG_CODEAGENCE","@CO_CODECOMMUNE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
