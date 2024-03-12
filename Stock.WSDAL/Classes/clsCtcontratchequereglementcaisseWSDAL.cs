using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratchequereglementcaisseWSDAL: ITableDAL<clsCtcontratchequereglementcaisse>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratchequereglementcaisse comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratchequereglementcaisse pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , AB_CODEAGENCEBANCAIRE  , CA_CODECONTRAT  , CHC_REFCHEQUE  , CHC_VALEURCHEQUE  , CHC_DATEANNULATIONCHEQUE  , CHC_DATEEMISSIONCHEQUE  , CHC_NOMTIREUR  , CHC_NOMTIRE  , CHC_DATERECEPTIONCHEQUE  , CHC_NOMDUDEPOSANT  , CHC_TELEPHONEDEPOSANT  , CHC_DATEEFFET  , OP_CODEOPERATEUR  , CHC_DATEVALIDATIONCHEQUE  , CHC_PRIMEAENCAISSER  FROM dbo.FT_CTCONTRATCHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse = new clsCtcontratchequereglementcaisse();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratchequereglementcaisse.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE = clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString();
					clsCtcontratchequereglementcaisse.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_REFCHEQUE = clsDonnee.vogDataReader["CHC_REFCHEQUE"].ToString();
					clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE = double.Parse(clsDonnee.vogDataReader["CHC_VALEURCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATEANNULATIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATEEMISSIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_NOMTIREUR = clsDonnee.vogDataReader["CHC_NOMTIREUR"].ToString();
					clsCtcontratchequereglementcaisse.CHC_NOMTIRE = clsDonnee.vogDataReader["CHC_NOMTIRE"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATERECEPTIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT = clsDonnee.vogDataReader["CHC_NOMDUDEPOSANT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT = clsDonnee.vogDataReader["CHC_TELEPHONEDEPOSANT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATEEFFET = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATEEFFET"].ToString());
					clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATEVALIDATIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER = double.Parse(clsDonnee.vogDataReader["CHC_PRIMEAENCAISSER"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratchequereglementcaisse;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratchequereglementcaisse>clsCtcontratchequereglementcaisse</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratchequereglementcaisse.AG_CODEAGENCE ;
			SqlParameter vppParamCHC_DATESAISIECHEQUE = new SqlParameter("@CHC_DATESAISIECHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATESAISIECHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE ;
			SqlParameter vppParamCHC_IDEXCHEQUE = new SqlParameter("@CHC_IDEXCHEQUE", SqlDbType.VarChar, 25);
			vppParamCHC_IDEXCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratchequereglementcaisse.EN_CODEENTREPOT ;
			SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.VarChar, 25);
			vppParamAB_CODEAGENCEBANCAIRE.Value  = clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratchequereglementcaisse.CA_CODECONTRAT ;
			SqlParameter vppParamCHC_REFCHEQUE = new SqlParameter("@CHC_REFCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCHC_REFCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_REFCHEQUE ;
			SqlParameter vppParamCHC_VALEURCHEQUE = new SqlParameter("@CHC_VALEURCHEQUE", SqlDbType.Money);
			vppParamCHC_VALEURCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE ;
			SqlParameter vppParamCHC_DATEANNULATIONCHEQUE = new SqlParameter("@CHC_DATEANNULATIONCHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATEANNULATIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE ;
			SqlParameter vppParamCHC_DATEEMISSIONCHEQUE = new SqlParameter("@CHC_DATEEMISSIONCHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATEEMISSIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE ;
			SqlParameter vppParamCHC_NOMTIREUR = new SqlParameter("@CHC_NOMTIREUR", SqlDbType.VarChar, 1000);
			vppParamCHC_NOMTIREUR.Value  = clsCtcontratchequereglementcaisse.CHC_NOMTIREUR ;
			SqlParameter vppParamCHC_NOMTIRE = new SqlParameter("@CHC_NOMTIRE", SqlDbType.VarChar, 1000);
			vppParamCHC_NOMTIRE.Value  = clsCtcontratchequereglementcaisse.CHC_NOMTIRE ;
			SqlParameter vppParamCHC_DATERECEPTIONCHEQUE = new SqlParameter("@CHC_DATERECEPTIONCHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATERECEPTIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE ;
			SqlParameter vppParamCHC_NOMDUDEPOSANT = new SqlParameter("@CHC_NOMDUDEPOSANT", SqlDbType.VarChar, 1000);
			vppParamCHC_NOMDUDEPOSANT.Value  = clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT ;
			SqlParameter vppParamCHC_TELEPHONEDEPOSANT = new SqlParameter("@CHC_TELEPHONEDEPOSANT", SqlDbType.VarChar, 1000);
			vppParamCHC_TELEPHONEDEPOSANT.Value  = clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT ;
			SqlParameter vppParamCHC_DATEEFFET = new SqlParameter("@CHC_DATEEFFET", SqlDbType.DateTime);
			vppParamCHC_DATEEFFET.Value  = clsCtcontratchequereglementcaisse.CHC_DATEEFFET ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR ;

			SqlParameter vppParamCHC_DATEVALIDATIONCHEQUE = new SqlParameter("@CHC_DATEVALIDATIONCHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATEVALIDATIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE ;
			SqlParameter vppParamCHC_PRIMEAENCAISSER = new SqlParameter("@CHC_PRIMEAENCAISSER", SqlDbType.Money);
			vppParamCHC_PRIMEAENCAISSER.Value  = clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER ;


            SqlParameter vppParamAB_CODEAGENCEBANCAIREASSUREUR = new SqlParameter("@AB_CODEAGENCEBANCAIREASSUREUR", SqlDbType.VarChar, 25);
            vppParamAB_CODEAGENCEBANCAIREASSUREUR.Value = clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIREASSUREUR;



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUE  @AG_CODEAGENCE, @CHC_DATESAISIECHEQUE, @CHC_IDEXCHEQUE, @EN_CODEENTREPOT, @AB_CODEAGENCEBANCAIRE, @CA_CODECONTRAT, @CHC_REFCHEQUE, @CHC_VALEURCHEQUE, @CHC_DATEANNULATIONCHEQUE, @CHC_DATEEMISSIONCHEQUE, @CHC_NOMTIREUR, @CHC_NOMTIRE, @CHC_DATERECEPTIONCHEQUE, @CHC_NOMDUDEPOSANT, @CHC_TELEPHONEDEPOSANT, @CHC_DATEEFFET, @OP_CODEOPERATEUR,  @CHC_DATEVALIDATIONCHEQUE, @CHC_PRIMEAENCAISSER,@AB_CODEAGENCEBANCAIREASSUREUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATESAISIECHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_IDEXCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamCHC_REFCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_VALEURCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATEANNULATIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATEEMISSIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_NOMTIREUR);
			vppSqlCmd.Parameters.Add(vppParamCHC_NOMTIRE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATERECEPTIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_NOMDUDEPOSANT);
			vppSqlCmd.Parameters.Add(vppParamCHC_TELEPHONEDEPOSANT);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATEEFFET);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATEVALIDATIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_PRIMEAENCAISSER);
			vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIREASSUREUR);

			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsCtcontratchequereglementcaisse>clsCtcontratchequereglementcaisse</param>
        ///<author>Home Technology</author>
        public string pvgMiseAJour(clsDonnee clsDonnee, clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse)
        {
	        //Préparation des paramètres
	        SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
	        vppParamAG_CODEAGENCE.Value  = clsCtcontratchequereglementcaisse.AG_CODEAGENCE ;
	        SqlParameter vppParamCHC_DATESAISIECHEQUE = new SqlParameter("@CHC_DATESAISIECHEQUE", SqlDbType.DateTime);
	        vppParamCHC_DATESAISIECHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE ;
	        SqlParameter vppParamCHC_IDEXCHEQUE = new SqlParameter("@CHC_IDEXCHEQUE", SqlDbType.VarChar, 25);
	        vppParamCHC_IDEXCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE ;
	        SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
	        vppParamEN_CODEENTREPOT.Value  = clsCtcontratchequereglementcaisse.EN_CODEENTREPOT ;

	        SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.VarChar, 25);
	        vppParamAB_CODEAGENCEBANCAIRE.Value  = clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE ;

	     

	        SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMPIECE.Value  = clsCtcontratchequereglementcaisse.MV_NUMPIECE;
	        SqlParameter vppParamCHC_REFCHEQUE = new SqlParameter("@CHC_REFCHEQUE", SqlDbType.VarChar, 1000);
	        vppParamCHC_REFCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_REFCHEQUE ;
	        SqlParameter vppParamCHC_VALEURCHEQUE = new SqlParameter("@CHC_VALEURCHEQUE", SqlDbType.Money);
	        vppParamCHC_VALEURCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE ;
	        SqlParameter vppParamCHC_DATEANNULATIONCHEQUE = new SqlParameter("@CHC_DATEANNULATIONCHEQUE", SqlDbType.DateTime);
	        vppParamCHC_DATEANNULATIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE ;
	        SqlParameter vppParamCHC_DATEEMISSIONCHEQUE = new SqlParameter("@CHC_DATEEMISSIONCHEQUE", SqlDbType.DateTime);
	        vppParamCHC_DATEEMISSIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE ;
	        SqlParameter vppParamCHC_NOMTIREUR = new SqlParameter("@CHC_NOMTIREUR", SqlDbType.VarChar, 1000);
	        vppParamCHC_NOMTIREUR.Value  = clsCtcontratchequereglementcaisse.CHC_NOMTIREUR ;
	        SqlParameter vppParamCHC_NOMTIRE = new SqlParameter("@CHC_NOMTIRE", SqlDbType.VarChar, 1000);
	        vppParamCHC_NOMTIRE.Value  = clsCtcontratchequereglementcaisse.CHC_NOMTIRE ;
	        SqlParameter vppParamCHC_DATERECEPTIONCHEQUE = new SqlParameter("@CHC_DATERECEPTIONCHEQUE", SqlDbType.DateTime);
	        vppParamCHC_DATERECEPTIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE ;
	        SqlParameter vppParamCHC_NOMDUDEPOSANT = new SqlParameter("@CHC_NOMDUDEPOSANT", SqlDbType.VarChar, 1000);
	        vppParamCHC_NOMDUDEPOSANT.Value  = clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT ;
	        SqlParameter vppParamCHC_TELEPHONEDEPOSANT = new SqlParameter("@CHC_TELEPHONEDEPOSANT", SqlDbType.VarChar, 1000);
	        vppParamCHC_TELEPHONEDEPOSANT.Value  = clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT ;
	        SqlParameter vppParamCHC_DATEEFFET = new SqlParameter("@CHC_DATEEFFET", SqlDbType.DateTime);
	        vppParamCHC_DATEEFFET.Value  = clsCtcontratchequereglementcaisse.CHC_DATEEFFET ;
	        SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
	        vppParamOP_CODEOPERATEUR.Value  = clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR ;

	        SqlParameter vppParamCHC_DATEVALIDATIONCHEQUE = new SqlParameter("@CHC_DATEVALIDATIONCHEQUE", SqlDbType.DateTime);
	        vppParamCHC_DATEVALIDATIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE ;

            SqlParameter vppParamCHC_DATEDEBUTCOUVERTURE = new SqlParameter("@CHC_DATEDEBUTCOUVERTURE", SqlDbType.DateTime);
            vppParamCHC_DATEDEBUTCOUVERTURE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEDEBUTCOUVERTURE;

            SqlParameter vppParamCHC_DATEFINCOUVERTURE = new SqlParameter("@CHC_DATEFINCOUVERTURE", SqlDbType.DateTime);
            vppParamCHC_DATEFINCOUVERTURE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEFINCOUVERTURE;

	        SqlParameter vppParamCHC_PRIMEAENCAISSER = new SqlParameter("@CHC_PRIMEAENCAISSER", SqlDbType.Money);
	        vppParamCHC_PRIMEAENCAISSER.Value  = clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER ;

            SqlParameter vppParamAB_CODEAGENCEBANCAIREASSUREUR = new SqlParameter("@AB_CODEAGENCEBANCAIREASSUREUR", SqlDbType.VarChar, 25);
            vppParamAB_CODEAGENCEBANCAIREASSUREUR.Value = clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIREASSUREUR;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
	        vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsCtcontratchequereglementcaisse.TYPEOPERATION;

            SqlParameter vppParamCHC_IDEXCHEQUERETOUR = new SqlParameter("@CHC_IDEXCHEQUERETOUR", SqlDbType.VarChar, 50);

            //Préparation de la commande

            SqlCommand vppSqlCmd = new SqlCommand("PC_CTCONTRATCHEQUEREGLEMENTCAISSE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATESAISIECHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_IDEXCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
	        vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
	        vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_REFCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_VALEURCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATEANNULATIONCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATEEMISSIONCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_NOMTIREUR);
	        vppSqlCmd.Parameters.Add(vppParamCHC_NOMTIRE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATERECEPTIONCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_NOMDUDEPOSANT);
	        vppSqlCmd.Parameters.Add(vppParamCHC_TELEPHONEDEPOSANT);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATEEFFET);
	        vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATEVALIDATIONCHEQUE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATEDEBUTCOUVERTURE);
	        vppSqlCmd.Parameters.Add(vppParamCHC_DATEFINCOUVERTURE);

	        vppSqlCmd.Parameters.Add(vppParamCHC_PRIMEAENCAISSER);
	        vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIREASSUREUR);
	        vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCHC_IDEXCHEQUERETOUR);
            vppParamCHC_IDEXCHEQUERETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@CHC_IDEXCHEQUERETOUR"].Value.ToString();
        }




		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratchequereglementcaisse>clsCtcontratchequereglementcaisse</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratchequereglementcaisse.AG_CODEAGENCE ;
			SqlParameter vppParamCHC_DATESAISIECHEQUE = new SqlParameter("@CHC_DATESAISIECHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATESAISIECHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE ;
			SqlParameter vppParamCHC_IDEXCHEQUE = new SqlParameter("@CHC_IDEXCHEQUE", SqlDbType.VarChar, 25);
			vppParamCHC_IDEXCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratchequereglementcaisse.EN_CODEENTREPOT ;

			SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.VarChar, 25);
			vppParamAB_CODEAGENCEBANCAIRE.Value  = clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE ;

			SqlParameter vppParamAB_CODEAGENCEBANCAIREASSUREUR = new SqlParameter("@AB_CODEAGENCEBANCAIREASSUREUR", SqlDbType.VarChar, 25);
            vppParamAB_CODEAGENCEBANCAIREASSUREUR.Value  = clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIREASSUREUR;

			SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMPIECE.Value  = clsCtcontratchequereglementcaisse.MV_NUMPIECE;
			SqlParameter vppParamCHC_REFCHEQUE = new SqlParameter("@CHC_REFCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCHC_REFCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_REFCHEQUE ;
			SqlParameter vppParamCHC_VALEURCHEQUE = new SqlParameter("@CHC_VALEURCHEQUE", SqlDbType.Money);
			vppParamCHC_VALEURCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE ;
			SqlParameter vppParamCHC_DATEANNULATIONCHEQUE = new SqlParameter("@CHC_DATEANNULATIONCHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATEANNULATIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE ;
			SqlParameter vppParamCHC_DATEEMISSIONCHEQUE = new SqlParameter("@CHC_DATEEMISSIONCHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATEEMISSIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE ;
			SqlParameter vppParamCHC_NOMTIREUR = new SqlParameter("@CHC_NOMTIREUR", SqlDbType.VarChar, 1000);
			vppParamCHC_NOMTIREUR.Value  = clsCtcontratchequereglementcaisse.CHC_NOMTIREUR ;
			SqlParameter vppParamCHC_NOMTIRE = new SqlParameter("@CHC_NOMTIRE", SqlDbType.VarChar, 1000);
			vppParamCHC_NOMTIRE.Value  = clsCtcontratchequereglementcaisse.CHC_NOMTIRE ;
			SqlParameter vppParamCHC_DATERECEPTIONCHEQUE = new SqlParameter("@CHC_DATERECEPTIONCHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATERECEPTIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE ;
			SqlParameter vppParamCHC_NOMDUDEPOSANT = new SqlParameter("@CHC_NOMDUDEPOSANT", SqlDbType.VarChar, 1000);
			vppParamCHC_NOMDUDEPOSANT.Value  = clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT ;
			SqlParameter vppParamCHC_TELEPHONEDEPOSANT = new SqlParameter("@CHC_TELEPHONEDEPOSANT", SqlDbType.VarChar, 1000);
			vppParamCHC_TELEPHONEDEPOSANT.Value  = clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT ;
			SqlParameter vppParamCHC_DATEEFFET = new SqlParameter("@CHC_DATEEFFET", SqlDbType.DateTime);
			vppParamCHC_DATEEFFET.Value  = clsCtcontratchequereglementcaisse.CHC_DATEEFFET ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR ;
			SqlParameter vppParamCHC_DATEVALIDATIONCHEQUE = new SqlParameter("@CHC_DATEVALIDATIONCHEQUE", SqlDbType.DateTime);
			vppParamCHC_DATEVALIDATIONCHEQUE.Value  = clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE ;

            SqlParameter vppParamCHC_DATEDEBUTCOUVERTURE = new SqlParameter("@CHC_DATEDEBUTCOUVERTURE", SqlDbType.DateTime);
            vppParamCHC_DATEDEBUTCOUVERTURE.Value = clsCtcontratchequereglementcaisse.CHC_DATEDEBUTCOUVERTURE;

            SqlParameter vppParamCHC_DATEFINCOUVERTURE = new SqlParameter("@CHC_DATEFINCOUVERTURE", SqlDbType.DateTime);
            vppParamCHC_DATEFINCOUVERTURE.Value = clsCtcontratchequereglementcaisse.CHC_DATEFINCOUVERTURE;



            SqlParameter vppParamCHC_PRIMEAENCAISSER = new SqlParameter("@CHC_PRIMEAENCAISSER", SqlDbType.Money);
			vppParamCHC_PRIMEAENCAISSER.Value  = clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER ;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value  = clsCtcontratchequereglementcaisse.TYPEOPERATION;


			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUE  @AG_CODEAGENCE, @CHC_DATESAISIECHEQUE, @CHC_IDEXCHEQUE, @EN_CODEENTREPOT, @AB_CODEAGENCEBANCAIRE, @CA_CODECONTRAT, @CHC_REFCHEQUE, @CHC_VALEURCHEQUE, @CHC_DATEANNULATIONCHEQUE, @CHC_DATEEMISSIONCHEQUE, @CHC_NOMTIREUR, @CHC_NOMTIRE, @CHC_DATERECEPTIONCHEQUE, @CHC_NOMDUDEPOSANT, @CHC_TELEPHONEDEPOSANT, @CHC_DATEEFFET, @OP_CODEOPERATEUR, @CHC_DATEVALIDATIONCHEQUE,@CHC_DATEDEBUTCOUVERTURE,@CHC_DATEFINCOUVERTURE, @CHC_PRIMEAENCAISSER,@AB_CODEAGENCEBANCAIREASSUREUR, @CODECRYPTAGE, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATESAISIECHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_IDEXCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIREASSUREUR);
			vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamCHC_REFCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_VALEURCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATEANNULATIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATEEMISSIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_NOMTIREUR);
			vppSqlCmd.Parameters.Add(vppParamCHC_NOMTIRE);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATERECEPTIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCHC_NOMDUDEPOSANT);
			vppSqlCmd.Parameters.Add(vppParamCHC_TELEPHONEDEPOSANT);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATEEFFET);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCHC_DATEVALIDATIONCHEQUE);

            vppSqlCmd.Parameters.Add(vppParamCHC_DATEDEBUTCOUVERTURE);
            vppSqlCmd.Parameters.Add(vppParamCHC_PRIMEAENCAISSER);


            vppSqlCmd.Parameters.Add(vppParamCHC_PRIMEAENCAISSER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCHEQUE  @AG_CODEAGENCE, @CHC_DATESAISIECHEQUE, @CHC_IDEXCHEQUE, '' , '', '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '', '' ,'', '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratchequereglementcaisse </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequereglementcaisse> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, EN_CODEENTREPOT, AB_CODEAGENCEBANCAIRE, CA_CODECONTRAT, CHC_REFCHEQUE, CHC_VALEURCHEQUE, CHC_DATEANNULATIONCHEQUE, CHC_DATEEMISSIONCHEQUE, CHC_NOMTIREUR, CHC_NOMTIRE, CHC_DATERECEPTIONCHEQUE, CHC_NOMDUDEPOSANT, CHC_TELEPHONEDEPOSANT, CHC_DATEEFFET, OP_CODEOPERATEUR, CHC_DATEVALIDATIONCHEQUE, CHC_PRIMEAENCAISSER FROM dbo.FT_CTCONTRATCHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratchequereglementcaisse> clsCtcontratchequereglementcaisses = new List<clsCtcontratchequereglementcaisse>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse = new clsCtcontratchequereglementcaisse();
					clsCtcontratchequereglementcaisse.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATESAISIECHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE = clsDonnee.vogDataReader["CHC_IDEXCHEQUE"].ToString();
					clsCtcontratchequereglementcaisse.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE = clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString();
					clsCtcontratchequereglementcaisse.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_REFCHEQUE = clsDonnee.vogDataReader["CHC_REFCHEQUE"].ToString();
					clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE = double.Parse(clsDonnee.vogDataReader["CHC_VALEURCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATEANNULATIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATEEMISSIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_NOMTIREUR = clsDonnee.vogDataReader["CHC_NOMTIREUR"].ToString();
					clsCtcontratchequereglementcaisse.CHC_NOMTIRE = clsDonnee.vogDataReader["CHC_NOMTIRE"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATERECEPTIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT = clsDonnee.vogDataReader["CHC_NOMDUDEPOSANT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT = clsDonnee.vogDataReader["CHC_TELEPHONEDEPOSANT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATEEFFET = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATEEFFET"].ToString());
					clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CHC_DATEVALIDATIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER = double.Parse(clsDonnee.vogDataReader["CHC_PRIMEAENCAISSER"].ToString());
					clsCtcontratchequereglementcaisses.Add(clsCtcontratchequereglementcaisse);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratchequereglementcaisses;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratchequereglementcaisse </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequereglementcaisse> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratchequereglementcaisse> clsCtcontratchequereglementcaisses = new List<clsCtcontratchequereglementcaisse>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, EN_CODEENTREPOT, AB_CODEAGENCEBANCAIRE, CA_CODECONTRAT, CHC_REFCHEQUE, CHC_VALEURCHEQUE, CHC_DATEANNULATIONCHEQUE, CHC_DATEEMISSIONCHEQUE, CHC_NOMTIREUR, CHC_NOMTIRE, CHC_DATERECEPTIONCHEQUE, CHC_NOMDUDEPOSANT, CHC_TELEPHONEDEPOSANT, CHC_DATEEFFET, OP_CODEOPERATEUR,  CHC_DATEVALIDATIONCHEQUE, CHC_PRIMEAENCAISSER FROM dbo.FT_CTCONTRATCHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse = new clsCtcontratchequereglementcaisse();
					clsCtcontratchequereglementcaisse.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATESAISIECHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_DATESAISIECHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_IDEXCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CHC_IDEXCHEQUE"].ToString();
					clsCtcontratchequereglementcaisse.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratchequereglementcaisse.AB_CODEAGENCEBANCAIRE = Dataset.Tables["TABLE"].Rows[Idx]["AB_CODEAGENCEBANCAIRE"].ToString();
					clsCtcontratchequereglementcaisse.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_REFCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CHC_REFCHEQUE"].ToString();
					clsCtcontratchequereglementcaisse.CHC_VALEURCHEQUE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_VALEURCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_DATEANNULATIONCHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_DATEANNULATIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_DATEEMISSIONCHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_DATEEMISSIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_NOMTIREUR = Dataset.Tables["TABLE"].Rows[Idx]["CHC_NOMTIREUR"].ToString();
					clsCtcontratchequereglementcaisse.CHC_NOMTIRE = Dataset.Tables["TABLE"].Rows[Idx]["CHC_NOMTIRE"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATERECEPTIONCHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_DATERECEPTIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_NOMDUDEPOSANT = Dataset.Tables["TABLE"].Rows[Idx]["CHC_NOMDUDEPOSANT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_TELEPHONEDEPOSANT = Dataset.Tables["TABLE"].Rows[Idx]["CHC_TELEPHONEDEPOSANT"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATEEFFET = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_DATEEFFET"].ToString());
					clsCtcontratchequereglementcaisse.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtcontratchequereglementcaisse.CHC_DATEVALIDATIONCHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_DATEVALIDATIONCHEQUE"].ToString());
					clsCtcontratchequereglementcaisse.CHC_PRIMEAENCAISSER = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CHC_PRIMEAENCAISSER"].ToString());
					clsCtcontratchequereglementcaisses.Add(clsCtcontratchequereglementcaisse);
				}
				Dataset.Dispose();
			}
		return clsCtcontratchequereglementcaisses;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTCONTRATCHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CHC_IDEXCHEQUE , CHC_REFCHEQUE FROM dbo.FT_CTCONTRATCHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CHC_DATESAISIECHEQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE AND CHC_IDEXCHEQUE=@CHC_IDEXCHEQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CHC_DATESAISIECHEQUE","@CHC_IDEXCHEQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE AND CHC_IDEXCHEQUE=@CHC_IDEXCHEQUE AND AB_CODEAGENCEBANCAIRE=@AB_CODEAGENCEBANCAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CHC_DATESAISIECHEQUE","@CHC_IDEXCHEQUE","@AB_CODEAGENCEBANCAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE AND CHC_IDEXCHEQUE=@CHC_IDEXCHEQUE AND AB_CODEAGENCEBANCAIRE=@AB_CODEAGENCEBANCAIRE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CHC_DATESAISIECHEQUE","@CHC_IDEXCHEQUE","@AB_CODEAGENCEBANCAIRE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CHC_DATESAISIECHEQUE, CHC_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE CA_CODECONTRAT=@CA_CODECONTRAT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CA_CODECONTRAT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CA_CODECONTRAT=@CA_CODECONTRAT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CA_CODECONTRAT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE AND CHC_IDEXCHEQUE=@CHC_IDEXCHEQUE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CHC_DATESAISIECHEQUE", "@CHC_IDEXCHEQUE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CA_CODECONTRAT=@CA_CODECONTRAT AND CHC_DATESAISIECHEQUE BETWEEN @CHC_DATESAISIECHEQUE1 AND @CHC_DATESAISIECHEQUE2";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CA_CODECONTRAT", "@CHC_DATESAISIECHEQUE1", "@CHC_DATESAISIECHEQUE2" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CHC_DATESAISIECHEQUE=@CHC_DATESAISIECHEQUE AND CHC_IDEXCHEQUE=@CHC_IDEXCHEQUE AND AB_CODEAGENCEBANCAIRE=@AB_CODEAGENCEBANCAIRE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CHC_DATESAISIECHEQUE", "@CHC_IDEXCHEQUE", "@AB_CODEAGENCEBANCAIRE", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
            }
        }
    }
}
