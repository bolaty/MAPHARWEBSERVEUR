using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBienimmobiliseWSDAL: ITableDAL<clsBienimmobilise>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBienimmobilise comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBienimmobilise pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_NUMEROTIERS  , AG_CODEAGENCE  , RC_CODERAISONDEPART  , OP_CODEOPERATEUR  , TI_NOMTIERS  , TI_DATECREATION  , TI_DATEDEPART  , TI_DESCRIPTIONRAISONDEPART  , SR_CODESERVICE  , TI_IDTIERSCODEFOURNISSEUR  , SF_CODESOURCEFINANCEMENT  , PS_CODESOUSPRODUIT  , IM_NUMEROSERIE  , IM_DATEACQUISITION  , IM_DATEMISEENSERVICE  , IM_VALEURACQUISITION  ,IM_VALEURTVA  , IM_REFERENCEBONCOMMANDE  , IM_REFERENCEFACTURE  , IM_REFERENCEBONLIVRAISON  , IM_DATEMISEAUREBUT  , IM_DATECESSION  , IM_PRIXCESSION  , IM_DUREE  , IM_QUANTITE  , IM_OBSERVATIONS  , TI_IDTIERSAVANTREPRISE  , TI_IDTIERSAVANTFACTUREAVOIR  , TI_CODETYPEAMORTISSEMENT  FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBienimmobilise clsBienimmobilise = new clsBienimmobilise();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBienimmobilise.TI_NUMEROTIERS = clsDonnee.vogDataReader["TI_NUMEROTIERS"].ToString();
					clsBienimmobilise.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsBienimmobilise.RC_CODERAISONDEPART = clsDonnee.vogDataReader["RC_CODERAISONDEPART"].ToString();
					clsBienimmobilise.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsBienimmobilise.TI_NOMTIERS = clsDonnee.vogDataReader["TI_NOMTIERS"].ToString();
					clsBienimmobilise.TI_DATECREATION = DateTime.Parse(clsDonnee.vogDataReader["TI_DATECREATION"].ToString());
					clsBienimmobilise.TI_DATEDEPART = DateTime.Parse(clsDonnee.vogDataReader["TI_DATEDEPART"].ToString());
					clsBienimmobilise.TI_DESCRIPTIONRAISONDEPART = clsDonnee.vogDataReader["TI_DESCRIPTIONRAISONDEPART"].ToString();
					clsBienimmobilise.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsBienimmobilise.TI_IDTIERSCODEFOURNISSEUR = clsDonnee.vogDataReader["TI_IDTIERSCODEFOURNISSEUR"].ToString();
					clsBienimmobilise.SF_CODESOURCEFINANCEMENT = clsDonnee.vogDataReader["SF_CODESOURCEFINANCEMENT"].ToString();
					clsBienimmobilise.PS_CODESOUSPRODUIT = clsDonnee.vogDataReader["PS_CODESOUSPRODUIT"].ToString();
					clsBienimmobilise.IM_NUMEROSERIE = clsDonnee.vogDataReader["IM_NUMEROSERIE"].ToString();
					clsBienimmobilise.IM_DATEACQUISITION = DateTime.Parse(clsDonnee.vogDataReader["IM_DATEACQUISITION"].ToString());
					clsBienimmobilise.IM_DATEMISEENSERVICE = DateTime.Parse(clsDonnee.vogDataReader["IM_DATEMISEENSERVICE"].ToString());
					clsBienimmobilise.IM_VALEURACQUISITION = double.Parse(clsDonnee.vogDataReader["IM_VALEURACQUISITION"].ToString());
                    clsBienimmobilise.IM_VALEURTVA = double.Parse(clsDonnee.vogDataReader["IM_VALEURTVA"].ToString());
                    clsBienimmobilise.IM_REFERENCEBONCOMMANDE = clsDonnee.vogDataReader["IM_REFERENCEBONCOMMANDE"].ToString();
					clsBienimmobilise.IM_REFERENCEFACTURE = clsDonnee.vogDataReader["IM_REFERENCEFACTURE"].ToString();
					clsBienimmobilise.IM_REFERENCEBONLIVRAISON = clsDonnee.vogDataReader["IM_REFERENCEBONLIVRAISON"].ToString();
					clsBienimmobilise.IM_DATEMISEAUREBUT = DateTime.Parse(clsDonnee.vogDataReader["IM_DATEMISEAUREBUT"].ToString());
					clsBienimmobilise.IM_DATECESSION = DateTime.Parse(clsDonnee.vogDataReader["IM_DATECESSION"].ToString());
					clsBienimmobilise.IM_PRIXCESSION = double.Parse(clsDonnee.vogDataReader["IM_PRIXCESSION"].ToString());
					clsBienimmobilise.IM_DUREE = float.Parse(clsDonnee.vogDataReader["IM_DUREE"].ToString());
					clsBienimmobilise.IM_QUANTITE = int.Parse(clsDonnee.vogDataReader["IM_QUANTITE"].ToString());
					clsBienimmobilise.IM_OBSERVATIONS = clsDonnee.vogDataReader["IM_OBSERVATIONS"].ToString();
					clsBienimmobilise.TI_IDTIERSAVANTREPRISE = clsDonnee.vogDataReader["TI_IDTIERSAVANTREPRISE"].ToString();
					clsBienimmobilise.TI_IDTIERSAVANTFACTUREAVOIR =clsDonnee.vogDataReader["TI_IDTIERSAVANTFACTUREAVOIR"].ToString();
					clsBienimmobilise.TI_CODETYPEAMORTISSEMENT = clsDonnee.vogDataReader["TI_CODETYPEAMORTISSEMENT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBienimmobilise;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBienimmobilise>clsBienimmobilise</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBienimmobilise clsBienimmobilise)
		{
			//Préparation des paramètres
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsBienimmobilise.TI_IDTIERS ;
			SqlParameter vppParamTI_NUMEROTIERS = new SqlParameter("@TI_NUMEROTIERS", SqlDbType.VarChar, 1000);
			vppParamTI_NUMEROTIERS.Value  = clsBienimmobilise.TI_NUMEROTIERS ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsBienimmobilise.AG_CODEAGENCE ;
			SqlParameter vppParamRC_CODERAISONDEPART = new SqlParameter("@RC_CODERAISONDEPART", SqlDbType.VarChar, 2);
			vppParamRC_CODERAISONDEPART.Value  = clsBienimmobilise.RC_CODERAISONDEPART ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsBienimmobilise.OP_CODEOPERATEUR ;
			SqlParameter vppParamTI_NOMTIERS = new SqlParameter("@TI_NOMTIERS", SqlDbType.VarChar, 1000);
			vppParamTI_NOMTIERS.Value  = clsBienimmobilise.TI_NOMTIERS ;
			SqlParameter vppParamTI_DATECREATION = new SqlParameter("@TI_DATECREATION", SqlDbType.DateTime);
			vppParamTI_DATECREATION.Value  = clsBienimmobilise.TI_DATECREATION ;
			SqlParameter vppParamTI_DATEDEPART = new SqlParameter("@TI_DATEDEPART", SqlDbType.DateTime);
			vppParamTI_DATEDEPART.Value  = clsBienimmobilise.TI_DATEDEPART ;

            if (clsBienimmobilise.TI_DATEDEPART < DateTime.Parse("01/01/1900")) vppParamTI_DATEDEPART.Value = "01/01/1900";


			SqlParameter vppParamTI_DESCRIPTIONRAISONDEPART = new SqlParameter("@TI_DESCRIPTIONRAISONDEPART", SqlDbType.VarChar, 8000);
			vppParamTI_DESCRIPTIONRAISONDEPART.Value  = clsBienimmobilise.TI_DESCRIPTIONRAISONDEPART ;
			if(clsBienimmobilise.TI_DESCRIPTIONRAISONDEPART== ""  ) vppParamTI_DESCRIPTIONRAISONDEPART.Value  = DBNull.Value;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsBienimmobilise.SR_CODESERVICE ;
			SqlParameter vppParamTI_IDTIERSCODEFOURNISSEUR = new SqlParameter("@TI_IDTIERSCODEFOURNISSEUR", SqlDbType.BigInt);
			vppParamTI_IDTIERSCODEFOURNISSEUR.Value  = clsBienimmobilise.TI_IDTIERSCODEFOURNISSEUR ;
			SqlParameter vppParamSF_CODESOURCEFINANCEMENT = new SqlParameter("@SF_CODESOURCEFINANCEMENT", SqlDbType.VarChar, 2);
			vppParamSF_CODESOURCEFINANCEMENT.Value  = clsBienimmobilise.SF_CODESOURCEFINANCEMENT ;
			SqlParameter vppParamPS_CODESOUSPRODUIT = new SqlParameter("@PS_CODESOUSPRODUIT", SqlDbType.VarChar, 5);
			vppParamPS_CODESOUSPRODUIT.Value  = clsBienimmobilise.PS_CODESOUSPRODUIT ;
			SqlParameter vppParamIM_NUMEROSERIE = new SqlParameter("@IM_NUMEROSERIE", SqlDbType.VarChar, 1000);
			vppParamIM_NUMEROSERIE.Value  = clsBienimmobilise.IM_NUMEROSERIE ;
			SqlParameter vppParamIM_DATEACQUISITION = new SqlParameter("@IM_DATEACQUISITION", SqlDbType.DateTime);
			vppParamIM_DATEACQUISITION.Value  = clsBienimmobilise.IM_DATEACQUISITION ;
            if (clsBienimmobilise.IM_DATEACQUISITION < DateTime.Parse("01/01/1900")) vppParamIM_DATEACQUISITION.Value = "01/01/1900";

			SqlParameter vppParamIM_DATEMISEENSERVICE = new SqlParameter("@IM_DATEMISEENSERVICE", SqlDbType.DateTime);
			vppParamIM_DATEMISEENSERVICE.Value  = clsBienimmobilise.IM_DATEMISEENSERVICE ;

            if (clsBienimmobilise.IM_DATEMISEENSERVICE < DateTime.Parse("01/01/1900")) vppParamIM_DATEMISEENSERVICE.Value = "01/01/1900";
			SqlParameter vppParamIM_VALEURACQUISITION = new SqlParameter("@IM_VALEURACQUISITION", SqlDbType.Money);
			vppParamIM_VALEURACQUISITION.Value  = clsBienimmobilise.IM_VALEURACQUISITION ;

            SqlParameter vppParamIM_VALEURTVA = new SqlParameter("@IM_VALEURTVA", SqlDbType.Money);
            vppParamIM_VALEURTVA.Value  = clsBienimmobilise.IM_VALEURTVA;

            SqlParameter vppParamIM_REFERENCEBONCOMMANDE = new SqlParameter("@IM_REFERENCEBONCOMMANDE", SqlDbType.VarChar, 1000);
			vppParamIM_REFERENCEBONCOMMANDE.Value  = clsBienimmobilise.IM_REFERENCEBONCOMMANDE ;
			if(clsBienimmobilise.IM_REFERENCEBONCOMMANDE== ""  ) vppParamIM_REFERENCEBONCOMMANDE.Value  = DBNull.Value;
			SqlParameter vppParamIM_REFERENCEFACTURE = new SqlParameter("@IM_REFERENCEFACTURE", SqlDbType.VarChar, 1000);
			vppParamIM_REFERENCEFACTURE.Value  = clsBienimmobilise.IM_REFERENCEFACTURE ;
			SqlParameter vppParamIM_REFERENCEBONLIVRAISON = new SqlParameter("@IM_REFERENCEBONLIVRAISON", SqlDbType.VarChar, 1000);
			vppParamIM_REFERENCEBONLIVRAISON.Value  = clsBienimmobilise.IM_REFERENCEBONLIVRAISON ;
			if(clsBienimmobilise.IM_REFERENCEBONLIVRAISON== ""  ) vppParamIM_REFERENCEBONLIVRAISON.Value  = DBNull.Value;
			SqlParameter vppParamIM_DATEMISEAUREBUT = new SqlParameter("@IM_DATEMISEAUREBUT", SqlDbType.DateTime);
			vppParamIM_DATEMISEAUREBUT.Value  = clsBienimmobilise.IM_DATEMISEAUREBUT ;
            if (clsBienimmobilise.IM_DATEMISEAUREBUT < DateTime.Parse("01/01/1900")) vppParamIM_DATEMISEAUREBUT.Value = "01/01/1900";

			SqlParameter vppParamIM_DATECESSION = new SqlParameter("@IM_DATECESSION", SqlDbType.DateTime);
			vppParamIM_DATECESSION.Value  = clsBienimmobilise.IM_DATECESSION ;
            if (clsBienimmobilise.IM_DATECESSION < DateTime.Parse("01/01/1900")) vppParamIM_DATECESSION.Value = "01/01/1900";

			SqlParameter vppParamIM_PRIXCESSION = new SqlParameter("@IM_PRIXCESSION", SqlDbType.Money);
			vppParamIM_PRIXCESSION.Value  = clsBienimmobilise.IM_PRIXCESSION ;
			SqlParameter vppParamIM_DUREE = new SqlParameter("@IM_DUREE", SqlDbType.Float);
			vppParamIM_DUREE.Value  = clsBienimmobilise.IM_DUREE ;
			SqlParameter vppParamIM_QUANTITE = new SqlParameter("@IM_QUANTITE", SqlDbType.Int);
			vppParamIM_QUANTITE.Value  = clsBienimmobilise.IM_QUANTITE ;
			SqlParameter vppParamIM_OBSERVATIONS = new SqlParameter("@IM_OBSERVATIONS", SqlDbType.VarChar, 8000);
			vppParamIM_OBSERVATIONS.Value  = clsBienimmobilise.IM_OBSERVATIONS ;
			SqlParameter vppParamTI_IDTIERSAVANTREPRISE = new SqlParameter("@TI_IDTIERSAVANTREPRISE", SqlDbType.BigInt);
			vppParamTI_IDTIERSAVANTREPRISE.Value  = clsBienimmobilise.TI_IDTIERSAVANTREPRISE ;
			if(clsBienimmobilise.TI_IDTIERSAVANTREPRISE== "" ) vppParamTI_IDTIERSAVANTREPRISE.Value  = DBNull.Value;
			SqlParameter vppParamTI_IDTIERSAVANTFACTUREAVOIR = new SqlParameter("@TI_IDTIERSAVANTFACTUREAVOIR", SqlDbType.BigInt);
			vppParamTI_IDTIERSAVANTFACTUREAVOIR.Value  = clsBienimmobilise.TI_IDTIERSAVANTFACTUREAVOIR ;
			if(clsBienimmobilise.TI_IDTIERSAVANTFACTUREAVOIR== "" ) vppParamTI_IDTIERSAVANTFACTUREAVOIR.Value  = DBNull.Value;
			SqlParameter vppParamTI_CODETYPEAMORTISSEMENT = new SqlParameter("@TI_CODETYPEAMORTISSEMENT", SqlDbType.VarChar, 2);
			vppParamTI_CODETYPEAMORTISSEMENT.Value  = clsBienimmobilise.TI_CODETYPEAMORTISSEMENT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISE  @TI_IDTIERS, @TI_NUMEROTIERS, @AG_CODEAGENCE, @RC_CODERAISONDEPART, @OP_CODEOPERATEUR, @TI_NOMTIERS, @TI_DATECREATION, @TI_DATEDEPART, @TI_DESCRIPTIONRAISONDEPART, @SR_CODESERVICE, @TI_IDTIERSCODEFOURNISSEUR, @SF_CODESOURCEFINANCEMENT, @PS_CODESOUSPRODUIT, @IM_NUMEROSERIE, @IM_DATEACQUISITION, @IM_DATEMISEENSERVICE, @IM_VALEURACQUISITION, @IM_VALEURTVA, @IM_REFERENCEBONCOMMANDE, @IM_REFERENCEFACTURE, @IM_REFERENCEBONLIVRAISON, @IM_DATEMISEAUREBUT, @IM_DATECESSION, @IM_PRIXCESSION, @IM_DUREE, @IM_QUANTITE, @IM_OBSERVATIONS, @TI_IDTIERSAVANTREPRISE, @TI_IDTIERSAVANTFACTUREAVOIR, @TI_CODETYPEAMORTISSEMENT, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamTI_NUMEROTIERS);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamRC_CODERAISONDEPART);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamTI_NOMTIERS);
			vppSqlCmd.Parameters.Add(vppParamTI_DATECREATION);
			vppSqlCmd.Parameters.Add(vppParamTI_DATEDEPART);
			vppSqlCmd.Parameters.Add(vppParamTI_DESCRIPTIONRAISONDEPART);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSCODEFOURNISSEUR);
			vppSqlCmd.Parameters.Add(vppParamSF_CODESOURCEFINANCEMENT);
			vppSqlCmd.Parameters.Add(vppParamPS_CODESOUSPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamIM_NUMEROSERIE);
			vppSqlCmd.Parameters.Add(vppParamIM_DATEACQUISITION);
			vppSqlCmd.Parameters.Add(vppParamIM_DATEMISEENSERVICE);
			vppSqlCmd.Parameters.Add(vppParamIM_VALEURACQUISITION);
            vppSqlCmd.Parameters.Add(vppParamIM_VALEURTVA);
			vppSqlCmd.Parameters.Add(vppParamIM_REFERENCEBONCOMMANDE);
			vppSqlCmd.Parameters.Add(vppParamIM_REFERENCEFACTURE);
			vppSqlCmd.Parameters.Add(vppParamIM_REFERENCEBONLIVRAISON);
			vppSqlCmd.Parameters.Add(vppParamIM_DATEMISEAUREBUT);
			vppSqlCmd.Parameters.Add(vppParamIM_DATECESSION);
			vppSqlCmd.Parameters.Add(vppParamIM_PRIXCESSION);
			vppSqlCmd.Parameters.Add(vppParamIM_DUREE);
			vppSqlCmd.Parameters.Add(vppParamIM_QUANTITE);
			vppSqlCmd.Parameters.Add(vppParamIM_OBSERVATIONS);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSAVANTREPRISE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSAVANTFACTUREAVOIR);
			vppSqlCmd.Parameters.Add(vppParamTI_CODETYPEAMORTISSEMENT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBienimmobilise>clsBienimmobilise</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBienimmobilise clsBienimmobilise,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERS.Value = clsBienimmobilise.TI_IDTIERS;
            SqlParameter vppParamTI_NUMEROTIERS = new SqlParameter("@TI_NUMEROTIERS", SqlDbType.VarChar, 1000);
            vppParamTI_NUMEROTIERS.Value = clsBienimmobilise.TI_NUMEROTIERS;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsBienimmobilise.AG_CODEAGENCE;
            SqlParameter vppParamRC_CODERAISONDEPART = new SqlParameter("@RC_CODERAISONDEPART", SqlDbType.VarChar, 2);
            vppParamRC_CODERAISONDEPART.Value = clsBienimmobilise.RC_CODERAISONDEPART;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsBienimmobilise.OP_CODEOPERATEUR;
            SqlParameter vppParamTI_NOMTIERS = new SqlParameter("@TI_NOMTIERS", SqlDbType.VarChar, 1000);
            vppParamTI_NOMTIERS.Value = clsBienimmobilise.TI_NOMTIERS;
            SqlParameter vppParamTI_DATECREATION = new SqlParameter("@TI_DATECREATION", SqlDbType.DateTime);
            vppParamTI_DATECREATION.Value = clsBienimmobilise.TI_DATECREATION;
            SqlParameter vppParamTI_DATEDEPART = new SqlParameter("@TI_DATEDEPART", SqlDbType.DateTime);
            vppParamTI_DATEDEPART.Value = clsBienimmobilise.TI_DATEDEPART;

            if (clsBienimmobilise.TI_DATEDEPART < DateTime.Parse("01/01/1900")) vppParamTI_DATEDEPART.Value = "01/01/1900";


            SqlParameter vppParamTI_DESCRIPTIONRAISONDEPART = new SqlParameter("@TI_DESCRIPTIONRAISONDEPART", SqlDbType.VarChar, 8000);
            vppParamTI_DESCRIPTIONRAISONDEPART.Value = clsBienimmobilise.TI_DESCRIPTIONRAISONDEPART;
            if (clsBienimmobilise.TI_DESCRIPTIONRAISONDEPART == "") vppParamTI_DESCRIPTIONRAISONDEPART.Value = DBNull.Value;
            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsBienimmobilise.SR_CODESERVICE;
            SqlParameter vppParamTI_IDTIERSCODEFOURNISSEUR = new SqlParameter("@TI_IDTIERSCODEFOURNISSEUR", SqlDbType.BigInt);
            vppParamTI_IDTIERSCODEFOURNISSEUR.Value = clsBienimmobilise.TI_IDTIERSCODEFOURNISSEUR;
            SqlParameter vppParamSF_CODESOURCEFINANCEMENT = new SqlParameter("@SF_CODESOURCEFINANCEMENT", SqlDbType.VarChar, 2);
            vppParamSF_CODESOURCEFINANCEMENT.Value = clsBienimmobilise.SF_CODESOURCEFINANCEMENT;
            SqlParameter vppParamPS_CODESOUSPRODUIT = new SqlParameter("@PS_CODESOUSPRODUIT", SqlDbType.VarChar, 5);
            vppParamPS_CODESOUSPRODUIT.Value = clsBienimmobilise.PS_CODESOUSPRODUIT;
            SqlParameter vppParamIM_NUMEROSERIE = new SqlParameter("@IM_NUMEROSERIE", SqlDbType.VarChar, 1000);
            vppParamIM_NUMEROSERIE.Value = clsBienimmobilise.IM_NUMEROSERIE;
            SqlParameter vppParamIM_DATEACQUISITION = new SqlParameter("@IM_DATEACQUISITION", SqlDbType.DateTime);
            vppParamIM_DATEACQUISITION.Value = clsBienimmobilise.IM_DATEACQUISITION;
            if (clsBienimmobilise.IM_DATEACQUISITION < DateTime.Parse("01/01/1900")) vppParamIM_DATEACQUISITION.Value = "01/01/1900";

            SqlParameter vppParamIM_DATEMISEENSERVICE = new SqlParameter("@IM_DATEMISEENSERVICE", SqlDbType.DateTime);
            vppParamIM_DATEMISEENSERVICE.Value = clsBienimmobilise.IM_DATEMISEENSERVICE;

            if (clsBienimmobilise.IM_DATEMISEENSERVICE < DateTime.Parse("01/01/1900")) vppParamIM_DATEMISEENSERVICE.Value = "01/01/1900";
            SqlParameter vppParamIM_VALEURACQUISITION = new SqlParameter("@IM_VALEURACQUISITION", SqlDbType.Money);
            vppParamIM_VALEURACQUISITION.Value = clsBienimmobilise.IM_VALEURACQUISITION;

            SqlParameter vppParamIM_VALEURTVA = new SqlParameter("@IM_VALEURTVA", SqlDbType.Money);
            vppParamIM_VALEURTVA.Value = clsBienimmobilise.IM_VALEURTVA;

            SqlParameter vppParamIM_REFERENCEBONCOMMANDE = new SqlParameter("@IM_REFERENCEBONCOMMANDE", SqlDbType.VarChar, 1000);
            vppParamIM_REFERENCEBONCOMMANDE.Value = clsBienimmobilise.IM_REFERENCEBONCOMMANDE;
            if (clsBienimmobilise.IM_REFERENCEBONCOMMANDE == "") vppParamIM_REFERENCEBONCOMMANDE.Value = DBNull.Value;
            SqlParameter vppParamIM_REFERENCEFACTURE = new SqlParameter("@IM_REFERENCEFACTURE", SqlDbType.VarChar, 1000);
            vppParamIM_REFERENCEFACTURE.Value = clsBienimmobilise.IM_REFERENCEFACTURE;
            SqlParameter vppParamIM_REFERENCEBONLIVRAISON = new SqlParameter("@IM_REFERENCEBONLIVRAISON", SqlDbType.VarChar, 1000);
            vppParamIM_REFERENCEBONLIVRAISON.Value = clsBienimmobilise.IM_REFERENCEBONLIVRAISON;
            if (clsBienimmobilise.IM_REFERENCEBONLIVRAISON == "") vppParamIM_REFERENCEBONLIVRAISON.Value = DBNull.Value;
            SqlParameter vppParamIM_DATEMISEAUREBUT = new SqlParameter("@IM_DATEMISEAUREBUT", SqlDbType.DateTime);
            vppParamIM_DATEMISEAUREBUT.Value = clsBienimmobilise.IM_DATEMISEAUREBUT;
            if (clsBienimmobilise.IM_DATEMISEAUREBUT < DateTime.Parse("01/01/1900")) vppParamIM_DATEMISEAUREBUT.Value = "01/01/1900";

            SqlParameter vppParamIM_DATECESSION = new SqlParameter("@IM_DATECESSION", SqlDbType.DateTime);
            vppParamIM_DATECESSION.Value = clsBienimmobilise.IM_DATECESSION;
            if (clsBienimmobilise.IM_DATECESSION < DateTime.Parse("01/01/1900")) vppParamIM_DATECESSION.Value = "01/01/1900";

            SqlParameter vppParamIM_PRIXCESSION = new SqlParameter("@IM_PRIXCESSION", SqlDbType.Money);
            vppParamIM_PRIXCESSION.Value = clsBienimmobilise.IM_PRIXCESSION;
            SqlParameter vppParamIM_DUREE = new SqlParameter("@IM_DUREE", SqlDbType.Float);
            vppParamIM_DUREE.Value = clsBienimmobilise.IM_DUREE;
            SqlParameter vppParamIM_QUANTITE = new SqlParameter("@IM_QUANTITE", SqlDbType.Int);
            vppParamIM_QUANTITE.Value = clsBienimmobilise.IM_QUANTITE;
            SqlParameter vppParamIM_OBSERVATIONS = new SqlParameter("@IM_OBSERVATIONS", SqlDbType.VarChar, 8000);
            vppParamIM_OBSERVATIONS.Value = clsBienimmobilise.IM_OBSERVATIONS;
            SqlParameter vppParamTI_IDTIERSAVANTREPRISE = new SqlParameter("@TI_IDTIERSAVANTREPRISE", SqlDbType.BigInt);
            vppParamTI_IDTIERSAVANTREPRISE.Value = clsBienimmobilise.TI_IDTIERSAVANTREPRISE;
            if (clsBienimmobilise.TI_IDTIERSAVANTREPRISE == "") vppParamTI_IDTIERSAVANTREPRISE.Value = DBNull.Value;
            SqlParameter vppParamTI_IDTIERSAVANTFACTUREAVOIR = new SqlParameter("@TI_IDTIERSAVANTFACTUREAVOIR", SqlDbType.BigInt);
            vppParamTI_IDTIERSAVANTFACTUREAVOIR.Value = clsBienimmobilise.TI_IDTIERSAVANTFACTUREAVOIR;
            if (clsBienimmobilise.TI_IDTIERSAVANTFACTUREAVOIR == "") vppParamTI_IDTIERSAVANTFACTUREAVOIR.Value = DBNull.Value;
            SqlParameter vppParamTI_CODETYPEAMORTISSEMENT = new SqlParameter("@TI_CODETYPEAMORTISSEMENT", SqlDbType.VarChar, 2);
            vppParamTI_CODETYPEAMORTISSEMENT.Value = clsBienimmobilise.TI_CODETYPEAMORTISSEMENT;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_BIENIMMOBILISE  @TI_IDTIERS, @TI_NUMEROTIERS, @AG_CODEAGENCE, @RC_CODERAISONDEPART, @OP_CODEOPERATEUR, @TI_NOMTIERS, @TI_DATECREATION, @TI_DATEDEPART, @TI_DESCRIPTIONRAISONDEPART, @SR_CODESERVICE, @TI_IDTIERSCODEFOURNISSEUR, @SF_CODESOURCEFINANCEMENT, @PS_CODESOUSPRODUIT, @IM_NUMEROSERIE, @IM_DATEACQUISITION, @IM_DATEMISEENSERVICE, @IM_VALEURACQUISITION,@IM_VALEURTVA, @IM_REFERENCEBONCOMMANDE, @IM_REFERENCEFACTURE, @IM_REFERENCEBONLIVRAISON, @IM_DATEMISEAUREBUT, @IM_DATECESSION, @IM_PRIXCESSION, @IM_DUREE, @IM_QUANTITE, @IM_OBSERVATIONS, @TI_IDTIERSAVANTREPRISE, @TI_IDTIERSAVANTFACTUREAVOIR, @TI_CODETYPEAMORTISSEMENT, @CODECRYPTAGE1,1";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMEROTIERS);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamRC_CODERAISONDEPART);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamTI_NOMTIERS);
            vppSqlCmd.Parameters.Add(vppParamTI_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamTI_DATEDEPART);
            vppSqlCmd.Parameters.Add(vppParamTI_DESCRIPTIONRAISONDEPART);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSCODEFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamSF_CODESOURCEFINANCEMENT);
            vppSqlCmd.Parameters.Add(vppParamPS_CODESOUSPRODUIT);
            vppSqlCmd.Parameters.Add(vppParamIM_NUMEROSERIE);
            vppSqlCmd.Parameters.Add(vppParamIM_DATEACQUISITION);
            vppSqlCmd.Parameters.Add(vppParamIM_DATEMISEENSERVICE);
            vppSqlCmd.Parameters.Add(vppParamIM_VALEURACQUISITION);
            vppSqlCmd.Parameters.Add(vppParamIM_VALEURTVA);
            vppSqlCmd.Parameters.Add(vppParamIM_REFERENCEBONCOMMANDE);
            vppSqlCmd.Parameters.Add(vppParamIM_REFERENCEFACTURE);
            vppSqlCmd.Parameters.Add(vppParamIM_REFERENCEBONLIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamIM_DATEMISEAUREBUT);
            vppSqlCmd.Parameters.Add(vppParamIM_DATECESSION);
            vppSqlCmd.Parameters.Add(vppParamIM_PRIXCESSION);
            vppSqlCmd.Parameters.Add(vppParamIM_DUREE);
            vppSqlCmd.Parameters.Add(vppParamIM_QUANTITE);
            vppSqlCmd.Parameters.Add(vppParamIM_OBSERVATIONS);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSAVANTREPRISE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSAVANTFACTUREAVOIR);
            vppSqlCmd.Parameters.Add(vppParamTI_CODETYPEAMORTISSEMENT);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISE  @TI_IDTIERS, '' , @AG_CODEAGENCE, '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBienimmobilise </returns>
		///<author>Home Technology</author>
		public List<clsBienimmobilise> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TI_IDTIERS, TI_NUMEROTIERS, AG_CODEAGENCE, RC_CODERAISONDEPART, OP_CODEOPERATEUR, TI_NOMTIERS, TI_DATECREATION, TI_DATEDEPART, TI_DESCRIPTIONRAISONDEPART, SR_CODESERVICE, TI_IDTIERSCODEFOURNISSEUR, SF_CODESOURCEFINANCEMENT, PS_CODESOUSPRODUIT, IM_NUMEROSERIE, IM_DATEACQUISITION, IM_DATEMISEENSERVICE, IM_VALEURACQUISITION,IM_VALEURTVA, IM_REFERENCEBONCOMMANDE, IM_REFERENCEFACTURE, IM_REFERENCEBONLIVRAISON, IM_DATEMISEAUREBUT, IM_DATECESSION, IM_PRIXCESSION, IM_DUREE, IM_QUANTITE, IM_OBSERVATIONS, TI_IDTIERSAVANTREPRISE, TI_IDTIERSAVANTFACTUREAVOIR, TI_CODETYPEAMORTISSEMENT FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBienimmobilise> clsBienimmobilises = new List<clsBienimmobilise>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBienimmobilise clsBienimmobilise = new clsBienimmobilise();
					clsBienimmobilise.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsBienimmobilise.TI_NUMEROTIERS = clsDonnee.vogDataReader["TI_NUMEROTIERS"].ToString();
					clsBienimmobilise.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsBienimmobilise.RC_CODERAISONDEPART = clsDonnee.vogDataReader["RC_CODERAISONDEPART"].ToString();
					clsBienimmobilise.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsBienimmobilise.TI_NOMTIERS = clsDonnee.vogDataReader["TI_NOMTIERS"].ToString();
					clsBienimmobilise.TI_DATECREATION = DateTime.Parse(clsDonnee.vogDataReader["TI_DATECREATION"].ToString());
					clsBienimmobilise.TI_DATEDEPART = DateTime.Parse(clsDonnee.vogDataReader["TI_DATEDEPART"].ToString());
					clsBienimmobilise.TI_DESCRIPTIONRAISONDEPART = clsDonnee.vogDataReader["TI_DESCRIPTIONRAISONDEPART"].ToString();
					clsBienimmobilise.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsBienimmobilise.TI_IDTIERSCODEFOURNISSEUR =clsDonnee.vogDataReader["TI_IDTIERSCODEFOURNISSEUR"].ToString();
					clsBienimmobilise.SF_CODESOURCEFINANCEMENT = clsDonnee.vogDataReader["SF_CODESOURCEFINANCEMENT"].ToString();
					clsBienimmobilise.PS_CODESOUSPRODUIT = clsDonnee.vogDataReader["PS_CODESOUSPRODUIT"].ToString();
					clsBienimmobilise.IM_NUMEROSERIE = clsDonnee.vogDataReader["IM_NUMEROSERIE"].ToString();
					clsBienimmobilise.IM_DATEACQUISITION = DateTime.Parse(clsDonnee.vogDataReader["IM_DATEACQUISITION"].ToString());
					clsBienimmobilise.IM_DATEMISEENSERVICE = DateTime.Parse(clsDonnee.vogDataReader["IM_DATEMISEENSERVICE"].ToString());
					clsBienimmobilise.IM_VALEURACQUISITION = double.Parse(clsDonnee.vogDataReader["IM_VALEURACQUISITION"].ToString());
                    clsBienimmobilise.IM_VALEURTVA = double.Parse(clsDonnee.vogDataReader["IM_VALEURTVA"].ToString());
					clsBienimmobilise.IM_REFERENCEBONCOMMANDE = clsDonnee.vogDataReader["IM_REFERENCEBONCOMMANDE"].ToString();
					clsBienimmobilise.IM_REFERENCEFACTURE = clsDonnee.vogDataReader["IM_REFERENCEFACTURE"].ToString();
					clsBienimmobilise.IM_REFERENCEBONLIVRAISON = clsDonnee.vogDataReader["IM_REFERENCEBONLIVRAISON"].ToString();
					clsBienimmobilise.IM_DATEMISEAUREBUT = DateTime.Parse(clsDonnee.vogDataReader["IM_DATEMISEAUREBUT"].ToString());
					clsBienimmobilise.IM_DATECESSION = DateTime.Parse(clsDonnee.vogDataReader["IM_DATECESSION"].ToString());
					clsBienimmobilise.IM_PRIXCESSION = double.Parse(clsDonnee.vogDataReader["IM_PRIXCESSION"].ToString());
					clsBienimmobilise.IM_DUREE = float.Parse(clsDonnee.vogDataReader["IM_DUREE"].ToString());
					clsBienimmobilise.IM_QUANTITE = int.Parse(clsDonnee.vogDataReader["IM_QUANTITE"].ToString());
					clsBienimmobilise.IM_OBSERVATIONS = clsDonnee.vogDataReader["IM_OBSERVATIONS"].ToString();
					clsBienimmobilise.TI_IDTIERSAVANTREPRISE =clsDonnee.vogDataReader["TI_IDTIERSAVANTREPRISE"].ToString();
					clsBienimmobilise.TI_IDTIERSAVANTFACTUREAVOIR =clsDonnee.vogDataReader["TI_IDTIERSAVANTFACTUREAVOIR"].ToString();
					clsBienimmobilise.TI_CODETYPEAMORTISSEMENT = clsDonnee.vogDataReader["TI_CODETYPEAMORTISSEMENT"].ToString();
					clsBienimmobilises.Add(clsBienimmobilise);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBienimmobilises;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBienimmobilise </returns>
		///<author>Home Technology</author>
		public List<clsBienimmobilise> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBienimmobilise> clsBienimmobilises = new List<clsBienimmobilise>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TI_IDTIERS, TI_NUMEROTIERS, AG_CODEAGENCE, RC_CODERAISONDEPART, OP_CODEOPERATEUR, TI_NOMTIERS, TI_DATECREATION, TI_DATEDEPART, TI_DESCRIPTIONRAISONDEPART, SR_CODESERVICE, TI_IDTIERSCODEFOURNISSEUR, SF_CODESOURCEFINANCEMENT, PS_CODESOUSPRODUIT, IM_NUMEROSERIE, IM_DATEACQUISITION, IM_DATEMISEENSERVICE, IM_VALEURACQUISITION,IM_VALEURTVA, IM_REFERENCEBONCOMMANDE, IM_REFERENCEFACTURE, IM_REFERENCEBONLIVRAISON, IM_DATEMISEAUREBUT, IM_DATECESSION, IM_PRIXCESSION, IM_DUREE, IM_QUANTITE, IM_OBSERVATIONS, TI_IDTIERSAVANTREPRISE, TI_IDTIERSAVANTFACTUREAVOIR, TI_CODETYPEAMORTISSEMENT FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBienimmobilise clsBienimmobilise = new clsBienimmobilise();
					clsBienimmobilise.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsBienimmobilise.TI_NUMEROTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_NUMEROTIERS"].ToString();
					clsBienimmobilise.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsBienimmobilise.RC_CODERAISONDEPART = Dataset.Tables["TABLE"].Rows[Idx]["RC_CODERAISONDEPART"].ToString();
					clsBienimmobilise.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsBienimmobilise.TI_NOMTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_NOMTIERS"].ToString();
					clsBienimmobilise.TI_DATECREATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TI_DATECREATION"].ToString());
					clsBienimmobilise.TI_DATEDEPART = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TI_DATEDEPART"].ToString());
					clsBienimmobilise.TI_DESCRIPTIONRAISONDEPART = Dataset.Tables["TABLE"].Rows[Idx]["TI_DESCRIPTIONRAISONDEPART"].ToString();
					clsBienimmobilise.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
					clsBienimmobilise.TI_IDTIERSCODEFOURNISSEUR =Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSCODEFOURNISSEUR"].ToString();
					clsBienimmobilise.SF_CODESOURCEFINANCEMENT = Dataset.Tables["TABLE"].Rows[Idx]["SF_CODESOURCEFINANCEMENT"].ToString();
					clsBienimmobilise.PS_CODESOUSPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["PS_CODESOUSPRODUIT"].ToString();
					clsBienimmobilise.IM_NUMEROSERIE = Dataset.Tables["TABLE"].Rows[Idx]["IM_NUMEROSERIE"].ToString();
					clsBienimmobilise.IM_DATEACQUISITION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_DATEACQUISITION"].ToString());
					clsBienimmobilise.IM_DATEMISEENSERVICE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_DATEMISEENSERVICE"].ToString());
					clsBienimmobilise.IM_VALEURACQUISITION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_VALEURACQUISITION"].ToString());
                    clsBienimmobilise.IM_VALEURTVA = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_VALEURTVA"].ToString());

                    clsBienimmobilise.IM_REFERENCEBONCOMMANDE = Dataset.Tables["TABLE"].Rows[Idx]["IM_REFERENCEBONCOMMANDE"].ToString();
					clsBienimmobilise.IM_REFERENCEFACTURE = Dataset.Tables["TABLE"].Rows[Idx]["IM_REFERENCEFACTURE"].ToString();
					clsBienimmobilise.IM_REFERENCEBONLIVRAISON = Dataset.Tables["TABLE"].Rows[Idx]["IM_REFERENCEBONLIVRAISON"].ToString();
					clsBienimmobilise.IM_DATEMISEAUREBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_DATEMISEAUREBUT"].ToString());
					clsBienimmobilise.IM_DATECESSION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_DATECESSION"].ToString());
					clsBienimmobilise.IM_PRIXCESSION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_PRIXCESSION"].ToString());
					clsBienimmobilise.IM_DUREE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_DUREE"].ToString());
					clsBienimmobilise.IM_QUANTITE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["IM_QUANTITE"].ToString());
					clsBienimmobilise.IM_OBSERVATIONS = Dataset.Tables["TABLE"].Rows[Idx]["IM_OBSERVATIONS"].ToString();
					clsBienimmobilise.TI_IDTIERSAVANTREPRISE = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSAVANTREPRISE"].ToString();
					clsBienimmobilise.TI_IDTIERSAVANTFACTUREAVOIR = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERSAVANTFACTUREAVOIR"].ToString();
					clsBienimmobilise.TI_CODETYPEAMORTISSEMENT = Dataset.Tables["TABLE"].Rows[Idx]["TI_CODETYPEAMORTISSEMENT"].ToString();
					clsBienimmobilises.Add(clsBienimmobilise);
				}
				Dataset.Dispose();
			}
		return clsBienimmobilises;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_IDTIERS , TI_NUMEROTIERS FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        public DataSet pvgChargerDansDataSetPourCombo1(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_IDTIERS , TI_NUMEROTIERS FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


   public DataSet pvgChargerDansDataSetImmobilisation(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT * FROM dbo.FT_BIENIMMOBILISE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}




		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TI_IDTIERS, AG_CODEAGENCE)</summary>
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
				this.vapCritere ="WHERE TI_IDTIERS=@TI_IDTIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TI_IDTIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TI_IDTIERS=@TI_IDTIERS AND AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@TI_IDTIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;

                case 8:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PS_CODESOUSPRODUIT LIKE '%'+@PS_CODESOUSPRODUIT+'%' AND SR_CODESERVICE LIKE '%'+@SR_CODESERVICE+'%' AND TI_IDTIERSCODEFOURNISSEUR LIKE '%'+@TI_IDTIERSCODEFOURNISSEUR+'%'  AND TI_NOMTIERS LIKE '%'+@TI_NOMTIERS+'%' AND TI_DATECREATION BETWEEN @TI_DATECREATION1 AND @TI_DATECREATION2 "+ vppCritere[7];
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PS_CODESOUSPRODUIT", "@SR_CODESERVICE", "@TI_IDTIERSCODEFOURNISSEUR", "@TI_NOMTIERS", "@TI_DATECREATION1", "@TI_DATECREATION2" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] , vppCritere[4] , vppCritere[5] , vppCritere[6] };
                break;

                case 9:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PS_CODESOUSPRODUIT LIKE '%'+@PS_CODESOUSPRODUIT+'%' AND SR_CODESERVICE LIKE '%'+@SR_CODESERVICE+'%' AND TI_IDTIERSCODEFOURNISSEUR LIKE '%'+@TI_IDTIERSCODEFOURNISSEUR+'%'  AND TI_NOMTIERS LIKE '%'+@TI_NOMTIERS+'%' AND TI_DATECREATION BETWEEN @TI_DATECREATION1 AND @TI_DATECREATION2" + vppCritere[7];
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PS_CODESOUSPRODUIT", "@SR_CODESERVICE", "@TI_IDTIERSCODEFOURNISSEUR", "@TI_NOMTIERS", "@TI_DATECREATION1", "@TI_DATECREATION2" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] , vppCritere[4] , vppCritere[5] , vppCritere[6] };
                break;
                case 10:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PS_CODESOUSPRODUIT LIKE '%'+@PS_CODESOUSPRODUIT+'%' AND SR_CODESERVICE LIKE '%'+@SR_CODESERVICE+'%' AND TI_IDTIERSCODEFOURNISSEUR LIKE '%'+@TI_IDTIERSCODEFOURNISSEUR+'%'  AND TI_NOMTIERS LIKE '%'+@TI_NOMTIERS+'%' AND TI_DATECREATION BETWEEN @TI_DATECREATION1   AND @TI_DATECREATION2 AND TI_NUMEROTIERS LIKE'%'+@TI_NUMEROTIERS+'%' " + vppCritere[7];
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PS_CODESOUSPRODUIT", "@SR_CODESERVICE", "@TI_IDTIERSCODEFOURNISSEUR", "@TI_NOMTIERS", "@TI_DATECREATION1", "@TI_DATECREATION2", "@TI_NUMEROTIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[8] };
                    break;



            }
		}
	}
}
