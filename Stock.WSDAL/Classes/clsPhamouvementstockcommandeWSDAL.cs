using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementStockcommandeWSDAL: ITableDAL<clsPhamouvementStockcommande>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(MK_NUMPIECE) AS MK_NUMPIECE  FROM dbo.PhamouvementStockCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(MK_NUMPIECE) AS MK_NUMPIECE  FROM dbo.PhamouvementStockCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(MK_NUMPIECE) AS MK_NUMPIECE  FROM dbo.PhamouvementStockCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">ORDRE DE CRITERE AG_CODEAGENCE,MK_DATEPIECE</param>
        /// <returns></returns>
        public string pvgNumsequenceMaxValue(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MK_DATEPIECE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
            this.vapRequete = " SELECT MAX(MK_NUMSEQUENCE) AS MK_NUMSEQUENCE FROM PhamouvementStockCOMMANDE WHERE AG_CODEAGENCE = @AG_CODEAGENCE AND CONVERT(DATETIME , MK_DATEPIECE,103)= @MK_DATEPIECE  ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockcommande comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockcommande pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , CH_IDCHAUFFEUR  , MK_DATEPIECE  , MK_NUMSEQUENCE  , FR_CODEFOURNISSEUR  , TI_IDTIERS  , CO_IDCOMMERCIAL  , MK_REFPIECE  , MK_LIBOPERA  , NO_CODENATUREOPERATION  , MK_TAUXREMISE  , MK_MONTANTTOTALREMISE  , MK_MONTANTTRANSPORT   , MK_DELAILIVRAISON  , MK_DATELIVRAISON  , MK_ANNULATIONPIECE  , MK_DATESAISIE  , MK_MONTANTECHEANCE  , MK_DATEDEBUTREGLEMENT  , MK_DUREEVALIDITE  , MK_CONDITIONREGLEMENT  , MK_SITUATIONFACTURE  , OP_CODEOPERATEUR  , MK_TAUXTVA  , MK_TAUXASDI  FROM dbo.PhamouvementStockCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementStockcommande clsPhamouvementStockcommande = new clsPhamouvementStockcommande();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockcommande.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsPhamouvementStockcommande.CH_IDCHAUFFEUR = clsDonnee.vogDataReader["CH_IDCHAUFFEUR"].ToString();
					clsPhamouvementStockcommande.MK_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MK_DATEPIECE"].ToString());
					clsPhamouvementStockcommande.MK_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["MK_NUMSEQUENCE"].ToString());
                    //clsPhamouvementStockcommande.FR_CODEFOURNISSEUR = clsDonnee.vogDataReader["FR_CODEFOURNISSEUR"].ToString();
                    //clsPhamouvementStockcommande.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhamouvementStockcommande.CO_IDCOMMERCIAL = clsDonnee.vogDataReader["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementStockcommande.MK_REFPIECE = clsDonnee.vogDataReader["MK_REFPIECE"].ToString();
					clsPhamouvementStockcommande.MK_LIBOPERA = clsDonnee.vogDataReader["MK_LIBOPERA"].ToString();
					clsPhamouvementStockcommande.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementStockcommande.MK_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MK_TAUXREMISE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTTOTALREMISE = double.Parse(clsDonnee.vogDataReader["MK_MONTANTTOTALREMISE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTTRANSPORT = double.Parse(clsDonnee.vogDataReader["MK_MONTANTTRANSPORT"].ToString());
					clsPhamouvementStockcommande.MK_DELAILIVRAISON = int.Parse(clsDonnee.vogDataReader["MK_DELAILIVRAISON"].ToString());
					clsPhamouvementStockcommande.MK_DATELIVRAISON = DateTime.Parse(clsDonnee.vogDataReader["MK_DATELIVRAISON"].ToString());
					clsPhamouvementStockcommande.MK_ANNULATIONPIECE = clsDonnee.vogDataReader["MK_ANNULATIONPIECE"].ToString();
					clsPhamouvementStockcommande.MK_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["MK_DATESAISIE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTECHEANCE = double.Parse(clsDonnee.vogDataReader["MK_MONTANTECHEANCE"].ToString());
					clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT = DateTime.Parse(clsDonnee.vogDataReader["MK_DATEDEBUTREGLEMENT"].ToString());
					clsPhamouvementStockcommande.MK_DUREEVALIDITE = clsDonnee.vogDataReader["MK_DUREEVALIDITE"].ToString();
					clsPhamouvementStockcommande.MK_CONDITIONREGLEMENT = clsDonnee.vogDataReader["MK_CONDITIONREGLEMENT"].ToString();
					clsPhamouvementStockcommande.MK_SITUATIONFACTURE = clsDonnee.vogDataReader["MK_SITUATIONFACTURE"].ToString();
					clsPhamouvementStockcommande.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementStockcommande.MK_TAUXTVA = float.Parse(clsDonnee.vogDataReader["MK_TAUXTVA"].ToString());
					clsPhamouvementStockcommande.MK_TAUXASDI = float.Parse(clsDonnee.vogDataReader["MK_TAUXASDI"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementStockcommande;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockcommande>clsPhamouvementStockcommande</param>
		///<author>Home Technology</author>
        public void pvgExecuterMouvementstockcommande(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockcommande.AG_CODEAGENCE;

            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStockcommande.MK_NUMPIECE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementStockcommande.EN_CODEENTREPOT;
            if (clsPhamouvementStockcommande.EN_CODEENTREPOT == "")
                vppParamEN_CODEENTREPOT.Value = DBNull.Value;

            SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.VarChar,25);
            vppParamCH_IDCHAUFFEUR.Value = clsPhamouvementStockcommande.CH_IDCHAUFFEUR;
            if (clsPhamouvementStockcommande.CH_IDCHAUFFEUR == "")
                vppParamCH_IDCHAUFFEUR.Value = DBNull.Value;

            //SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar,25);
            //vppParamTI_IDTIERS.Value = clsPhamouvementStockcommande.TI_IDTIERS;
            //if (clsPhamouvementStockcommande.TI_IDTIERS == "")
            //    vppParamTI_IDTIERS.Value = DBNull.Value;


            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar,25);
            vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementStockcommande.CO_IDCOMMERCIAL;
            if (clsPhamouvementStockcommande.CO_IDCOMMERCIAL == "")
                vppParamCO_IDCOMMERCIAL.Value = DBNull.Value;

            SqlParameter vppParamMK_DATEPIECE = new SqlParameter("@MK_DATEPIECE", SqlDbType.DateTime);
            vppParamMK_DATEPIECE.Value = clsPhamouvementStockcommande.MK_DATEPIECE;
            if (clsPhamouvementStockcommande.MK_DATEPIECE < DateTime.Parse("01/01/1900"))
                vppParamMK_DATEPIECE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_NUMSEQUENCE = new SqlParameter("@MK_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMK_NUMSEQUENCE.Value = clsPhamouvementStockcommande.MK_NUMSEQUENCE;

            //SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 4);
            //vppParamFR_CODEFOURNISSEUR.Value = clsPhamouvementStockcommande.FR_CODEFOURNISSEUR;
            //if (clsPhamouvementStockcommande.FR_CODEFOURNISSEUR == "")
            //    vppParamFR_CODEFOURNISSEUR.Value = DBNull.Value;

            SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 150);
            vppParamTI_NUMTIERS.Value = clsPhamouvementStockcommande.TI_NUMTIERS;
            if (clsPhamouvementStockcommande.TI_NUMTIERS == "")
                vppParamTI_NUMTIERS.Value = DBNull.Value;

            SqlParameter vppParamMK_TAUXASDI = new SqlParameter("@MK_TAUXASDI", SqlDbType.Float);
            vppParamMK_TAUXASDI.Value = clsPhamouvementStockcommande.MK_TAUXASDI;

            SqlParameter vppParamMK_TAUXTVA = new SqlParameter("@MK_TAUXTVA", SqlDbType.Float);
            vppParamMK_TAUXTVA.Value = clsPhamouvementStockcommande.MK_TAUXTVA;


            SqlParameter vppParamMK_REFPIECE = new SqlParameter("@MK_REFPIECE", SqlDbType.VarChar, 150);
            vppParamMK_REFPIECE.Value = clsPhamouvementStockcommande.MK_REFPIECE;

            SqlParameter vppParamMK_LIBOPERA = new SqlParameter("@MK_LIBOPERA", SqlDbType.VarChar, 150);
            vppParamMK_LIBOPERA.Value = clsPhamouvementStockcommande.MK_LIBOPERA;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementStockcommande.NO_CODENATUREOPERATION;

            SqlParameter vppParamMK_TAUXREMISE = new SqlParameter("@MK_TAUXREMISE", SqlDbType.Float);
            vppParamMK_TAUXREMISE.Value = clsPhamouvementStockcommande.MK_TAUXREMISE;

            SqlParameter vppParamMK_MONTANTTOTALREMISE = new SqlParameter("@MK_MONTANTTOTALREMISE", SqlDbType.Money);
            vppParamMK_MONTANTTOTALREMISE.Value = clsPhamouvementStockcommande.MK_MONTANTTOTALREMISE;

            SqlParameter vppParamMK_MONTANTTRANSPORT = new SqlParameter("@MK_MONTANTTRANSPORT", SqlDbType.Money);
            vppParamMK_MONTANTTRANSPORT.Value = clsPhamouvementStockcommande.MK_MONTANTTRANSPORT;

            SqlParameter vppParamMK_DELAILIVRAISON = new SqlParameter("@MK_DELAILIVRAISON", SqlDbType.TinyInt);
            vppParamMK_DELAILIVRAISON.Value = clsPhamouvementStockcommande.MK_DELAILIVRAISON;

            SqlParameter vppParamMK_DATELIVRAISON = new SqlParameter("@MK_DATELIVRAISON", SqlDbType.DateTime);
            vppParamMK_DATELIVRAISON.Value = clsPhamouvementStockcommande.MK_DATELIVRAISON;
            if (clsPhamouvementStockcommande.MK_DATELIVRAISON < DateTime.Parse("01/01/1900"))
                vppParamMK_DATELIVRAISON.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_ANNULATIONPIECE = new SqlParameter("@MK_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMK_ANNULATIONPIECE.Value = clsPhamouvementStockcommande.MK_ANNULATIONPIECE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 5);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStockcommande.OP_CODEOPERATEUR;

            SqlParameter vppParamMK_DATESAISIE = new SqlParameter("@MK_DATESAISIE", SqlDbType.DateTime);
            vppParamMK_DATESAISIE.Value = clsPhamouvementStockcommande.MK_DATESAISIE;
            if (clsPhamouvementStockcommande.MK_DATESAISIE < DateTime.Parse("01/01/1900"))
                vppParamMK_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_MONTANTECHEANCE = new SqlParameter("@MK_MONTANTECHEANCE", SqlDbType.Money);
            vppParamMK_MONTANTECHEANCE.Value = clsPhamouvementStockcommande.MK_MONTANTECHEANCE;

            SqlParameter vppParamMK_DATEDEBUTREGLEMENT = new SqlParameter("@MK_DATEDEBUTREGLEMENT", SqlDbType.DateTime);
            vppParamMK_DATEDEBUTREGLEMENT.Value = clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT;
            if (clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT < DateTime.Parse("01/01/1900"))
                vppParamMK_DATEDEBUTREGLEMENT.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_DUREEVALIDITE = new SqlParameter("@MK_DUREEVALIDITE", SqlDbType.VarChar, 150);
            vppParamMK_DUREEVALIDITE.Value = clsPhamouvementStockcommande.MK_DUREEVALIDITE;

            SqlParameter vppParamMK_CONDITIONREGLEMENT = new SqlParameter("@MK_CONDITIONREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMK_CONDITIONREGLEMENT.Value = clsPhamouvementStockcommande.MK_CONDITIONREGLEMENT;

            SqlParameter vppParamMK_SITUATIONFACTURE = new SqlParameter("@MK_SITUATIONFACTURE", SqlDbType.VarChar, 1);
            vppParamMK_SITUATIONFACTURE.Value = clsPhamouvementStockcommande.MK_SITUATIONFACTURE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 1);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsPhamouvementStockcommande.TYPEOPERATION;

			//Préparation de la commande
            this.vapRequete = " EXECUTE dbo.PS_PHAMOUVEMENTSTOCKCOMMANDE @AG_CODEAGENCE,@MK_NUMPIECE,@EN_CODEENTREPOT,@CH_IDCHAUFFEUR,@MK_DATEPIECE,@MK_NUMSEQUENCE,@TI_NUMTIERS,@CO_IDCOMMERCIAL,@MK_REFPIECE,@MK_LIBOPERA,@NO_CODENATUREOPERATION,@MK_TAUXREMISE,@MK_MONTANTTOTALREMISE,@MK_MONTANTTRANSPORT,0,@MK_DELAILIVRAISON,@MK_DATELIVRAISON,@MK_ANNULATIONPIECE,@MK_DATESAISIE,@MK_MONTANTECHEANCE,@MK_DATEDEBUTREGLEMENT,@MK_DUREEVALIDITE,@MK_CONDITIONREGLEMENT,@MK_SITUATIONFACTURE,@OP_CODEOPERATEUR,@MK_TAUXTVA,@MK_TAUXASDI,@CODECRYPTAGE,@TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
			vppSqlCmd.Parameters.Add(vppParamMK_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMK_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
            //vppSqlCmd.Parameters.Add(vppParamFR_CODEFOURNISSEUR);
            //vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
			vppSqlCmd.Parameters.Add(vppParamMK_REFPIECE);
			vppSqlCmd.Parameters.Add(vppParamMK_LIBOPERA);
			vppSqlCmd.Parameters.Add(vppParamMK_TAUXASDI);
			vppSqlCmd.Parameters.Add(vppParamMK_TAUXTVA);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMK_TAUXREMISE);
			vppSqlCmd.Parameters.Add(vppParamMK_MONTANTTOTALREMISE);
			vppSqlCmd.Parameters.Add(vppParamMK_MONTANTTRANSPORT);
			vppSqlCmd.Parameters.Add(vppParamMK_DELAILIVRAISON);
			vppSqlCmd.Parameters.Add(vppParamMK_DATELIVRAISON);
			vppSqlCmd.Parameters.Add(vppParamMK_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamMK_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamMK_MONTANTECHEANCE);
			vppSqlCmd.Parameters.Add(vppParamMK_DATEDEBUTREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamMK_DUREEVALIDITE);
			vppSqlCmd.Parameters.Add(vppParamMK_CONDITIONREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamMK_SITUATIONFACTURE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}
		
        
        public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockcommande.AG_CODEAGENCE;

            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStockcommande.MK_NUMPIECE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementStockcommande.EN_CODEENTREPOT;
            if (clsPhamouvementStockcommande.EN_CODEENTREPOT == "")
                vppParamEN_CODEENTREPOT.Value = DBNull.Value;

            SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.VarChar,25);
            vppParamCH_IDCHAUFFEUR.Value = clsPhamouvementStockcommande.CH_IDCHAUFFEUR;
            if (clsPhamouvementStockcommande.CH_IDCHAUFFEUR == "")
                vppParamCH_IDCHAUFFEUR.Value = DBNull.Value;

            //SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar,25);
            //vppParamTI_IDTIERS.Value = clsPhamouvementStockcommande.TI_IDTIERS;
            //if (clsPhamouvementStockcommande.TI_IDTIERS == "")
            //    vppParamTI_IDTIERS.Value = DBNull.Value;

            SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 8);
            vppParamTI_NUMTIERS.Value = clsPhamouvementStockcommande.TI_NUMTIERS;
            if (clsPhamouvementStockcommande.TI_NUMTIERS == "")
                vppParamTI_NUMTIERS.Value = DBNull.Value;

            //SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar,25);
            //vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementStockcommande.CO_IDCOMMERCIAL;
            //if (clsPhamouvementStockcommande.CO_IDCOMMERCIAL == "")
            //    vppParamCO_IDCOMMERCIAL.Value = DBNull.Value;

            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar, 25);
            vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementStockcommande.CO_IDCOMMERCIAL;
            if (clsPhamouvementStockcommande.CO_IDCOMMERCIAL == "")
                vppParamCO_IDCOMMERCIAL.Value = DBNull.Value;

            SqlParameter vppParamMK_DATEPIECE = new SqlParameter("@MK_DATEPIECE", SqlDbType.DateTime);
            vppParamMK_DATEPIECE.Value = clsPhamouvementStockcommande.MK_DATEPIECE;
            if (clsPhamouvementStockcommande.MK_DATEPIECE < DateTime.Parse("01/01/1900"))
                vppParamMK_DATEPIECE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_NUMSEQUENCE = new SqlParameter("@MK_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMK_NUMSEQUENCE.Value = clsPhamouvementStockcommande.MK_NUMSEQUENCE;

            //SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 4);
            //vppParamFR_CODEFOURNISSEUR.Value = clsPhamouvementStockcommande.FR_CODEFOURNISSEUR;
            //if (clsPhamouvementStockcommande.FR_CODEFOURNISSEUR == "")
            //    vppParamFR_CODEFOURNISSEUR.Value = DBNull.Value;


            //SqlParameter vppParamFR_MATRICULE = new SqlParameter("@FR_MATRICULE", SqlDbType.VarChar, 8);
            //vppParamFR_MATRICULE.Value = clsPhamouvementStockcommande.FR_MATRICULE;
            //if (clsPhamouvementStockcommande.FR_MATRICULE == "")
            //    vppParamFR_MATRICULE.Value = DBNull.Value;



            SqlParameter vppParamMK_TAUXASDI = new SqlParameter("@MK_TAUXASDI", SqlDbType.Float);
            vppParamMK_TAUXASDI.Value = clsPhamouvementStockcommande.MK_TAUXASDI;

            SqlParameter vppParamMK_TAUXTVA = new SqlParameter("@MK_TAUXTVA", SqlDbType.Float);
            vppParamMK_TAUXTVA.Value = clsPhamouvementStockcommande.MK_TAUXTVA;


            SqlParameter vppParamMK_REFPIECE = new SqlParameter("@MK_REFPIECE", SqlDbType.VarChar, 150);
            vppParamMK_REFPIECE.Value = clsPhamouvementStockcommande.MK_REFPIECE;

            SqlParameter vppParamMK_LIBOPERA = new SqlParameter("@MK_LIBOPERA", SqlDbType.VarChar, 150);
            vppParamMK_LIBOPERA.Value = clsPhamouvementStockcommande.MK_LIBOPERA;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementStockcommande.NO_CODENATUREOPERATION;

            SqlParameter vppParamMK_TAUXREMISE = new SqlParameter("@MK_TAUXREMISE", SqlDbType.Float);
            vppParamMK_TAUXREMISE.Value = clsPhamouvementStockcommande.MK_TAUXREMISE;

            SqlParameter vppParamMK_MONTANTTOTALREMISE = new SqlParameter("@MK_MONTANTTOTALREMISE", SqlDbType.Money);
            vppParamMK_MONTANTTOTALREMISE.Value = clsPhamouvementStockcommande.MK_MONTANTTOTALREMISE;

            SqlParameter vppParamMK_MONTANTTRANSPORT = new SqlParameter("@MK_MONTANTTRANSPORT", SqlDbType.Money);
            vppParamMK_MONTANTTRANSPORT.Value = clsPhamouvementStockcommande.MK_MONTANTTRANSPORT;

            SqlParameter vppParamMK_DELAILIVRAISON = new SqlParameter("@MK_DELAILIVRAISON", SqlDbType.TinyInt);
            vppParamMK_DELAILIVRAISON.Value = clsPhamouvementStockcommande.MK_DELAILIVRAISON;

            SqlParameter vppParamMK_DATELIVRAISON = new SqlParameter("@MK_DATELIVRAISON", SqlDbType.DateTime);
            vppParamMK_DATELIVRAISON.Value = clsPhamouvementStockcommande.MK_DATELIVRAISON;
            if (clsPhamouvementStockcommande.MK_DATELIVRAISON < DateTime.Parse("01/01/1900"))
                vppParamMK_DATELIVRAISON.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_ANNULATIONPIECE = new SqlParameter("@MK_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMK_ANNULATIONPIECE.Value = clsPhamouvementStockcommande.MK_ANNULATIONPIECE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStockcommande.OP_CODEOPERATEUR;

            SqlParameter vppParamMK_DATESAISIE = new SqlParameter("@MK_DATESAISIE", SqlDbType.DateTime);
            vppParamMK_DATESAISIE.Value = clsPhamouvementStockcommande.MK_DATESAISIE;
            if (clsPhamouvementStockcommande.MK_DATESAISIE < DateTime.Parse("01/01/1900"))
                vppParamMK_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_MONTANTECHEANCE = new SqlParameter("@MK_MONTANTECHEANCE", SqlDbType.Money);
            vppParamMK_MONTANTECHEANCE.Value = clsPhamouvementStockcommande.MK_MONTANTECHEANCE;

            SqlParameter vppParamMK_DATEDEBUTREGLEMENT = new SqlParameter("@MK_DATEDEBUTREGLEMENT", SqlDbType.DateTime);
            vppParamMK_DATEDEBUTREGLEMENT.Value = clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT;
            if (clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT < DateTime.Parse("01/01/1900"))
                vppParamMK_DATEDEBUTREGLEMENT.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_DUREEVALIDITE = new SqlParameter("@MK_DUREEVALIDITE", SqlDbType.VarChar, 150);
            vppParamMK_DUREEVALIDITE.Value = clsPhamouvementStockcommande.MK_DUREEVALIDITE;

            SqlParameter vppParamMK_CONDITIONREGLEMENT = new SqlParameter("@MK_CONDITIONREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMK_CONDITIONREGLEMENT.Value = clsPhamouvementStockcommande.MK_CONDITIONREGLEMENT;

            SqlParameter vppParamMK_SITUATIONFACTURE = new SqlParameter("@MK_SITUATIONFACTURE", SqlDbType.VarChar, 1);
            vppParamMK_SITUATIONFACTURE.Value = clsPhamouvementStockcommande.MK_SITUATIONFACTURE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;


            //SqlParameter vppParamMK_NUMPIECERETOUR = new SqlParameter("@MK_NUMPIECERETOUR", SqlDbType.VarChar, 50);

			//Préparation de la commande
            this.vapRequete = " EXECUTE dbo.PS_PHAMOUVEMENTSTOCKCOMMANDE @AG_CODEAGENCE,@MK_NUMPIECE,@EN_CODEENTREPOT,@CH_IDCHAUFFEUR,@MK_DATEPIECE,@MK_NUMSEQUENCE,@TI_NUMTIERS,@CO_IDCOMMERCIAL,@MK_REFPIECE,@MK_LIBOPERA,@NO_CODENATUREOPERATION,@MK_TAUXREMISE,@MK_MONTANTTOTALREMISE,@MK_MONTANTTRANSPORT,0,@MK_DELAILIVRAISON,@MK_DATELIVRAISON,@MK_ANNULATIONPIECE,@MK_DATESAISIE,@MK_MONTANTECHEANCE,@MK_DATEDEBUTREGLEMENT,@MK_DUREEVALIDITE,@MK_CONDITIONREGLEMENT,@MK_SITUATIONFACTURE,@OP_CODEOPERATEUR,@MK_TAUXTVA,@MK_TAUXASDI,@CODECRYPTAGE,0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //SqlCommand vppSqlCmd = new SqlCommand("PS_PHAMOUVEMENTSTOCKCOMMANDE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //vppSqlCmd.CommandType = CommandType.StoredProcedure;

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
			vppSqlCmd.Parameters.Add(vppParamMK_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMK_NUMSEQUENCE);
            //vppSqlCmd.Parameters.Add(vppParamFR_MATRICULE);
            //vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
            //vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
			vppSqlCmd.Parameters.Add(vppParamMK_REFPIECE);
			vppSqlCmd.Parameters.Add(vppParamMK_LIBOPERA);
			vppSqlCmd.Parameters.Add(vppParamMK_TAUXASDI);
			vppSqlCmd.Parameters.Add(vppParamMK_TAUXTVA);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMK_TAUXREMISE);
			vppSqlCmd.Parameters.Add(vppParamMK_MONTANTTOTALREMISE);
			vppSqlCmd.Parameters.Add(vppParamMK_MONTANTTRANSPORT);
			vppSqlCmd.Parameters.Add(vppParamMK_DELAILIVRAISON);
			vppSqlCmd.Parameters.Add(vppParamMK_DATELIVRAISON);
			vppSqlCmd.Parameters.Add(vppParamMK_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamMK_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamMK_MONTANTECHEANCE);
			vppSqlCmd.Parameters.Add(vppParamMK_DATEDEBUTREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamMK_DUREEVALIDITE);
			vppSqlCmd.Parameters.Add(vppParamMK_CONDITIONREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamMK_SITUATIONFACTURE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}



        public string pvgInsert1(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockcommande.AG_CODEAGENCE;

            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStockcommande.MK_NUMPIECE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementStockcommande.EN_CODEENTREPOT;
            if (clsPhamouvementStockcommande.EN_CODEENTREPOT == "")
                vppParamEN_CODEENTREPOT.Value = DBNull.Value;

            SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.VarChar, 25);
            vppParamCH_IDCHAUFFEUR.Value = clsPhamouvementStockcommande.CH_IDCHAUFFEUR;
            if (clsPhamouvementStockcommande.CH_IDCHAUFFEUR == "")
                vppParamCH_IDCHAUFFEUR.Value = DBNull.Value;

            //SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar,25);
            //vppParamTI_IDTIERS.Value = clsPhamouvementStockcommande.TI_IDTIERS;
            //if (clsPhamouvementStockcommande.TI_IDTIERS == "")
            //    vppParamTI_IDTIERS.Value = DBNull.Value;




            SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 8);
            vppParamTI_NUMTIERS.Value = clsPhamouvementStockcommande.TI_NUMTIERS;
            if (clsPhamouvementStockcommande.TI_NUMTIERS == "")
                vppParamTI_NUMTIERS.Value = DBNull.Value;

            SqlParameter vppParamPR_IDTIERS = new SqlParameter("@PR_IDTIERS", SqlDbType.VarChar, 25);
            vppParamPR_IDTIERS.Value = clsPhamouvementStockcommande.PR_IDTIERS;
            if (clsPhamouvementStockcommande.PR_IDTIERS == "")
                vppParamPR_IDTIERS.Value = DBNull.Value;

            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar, 25);
            vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementStockcommande.CO_IDCOMMERCIAL;
            if (clsPhamouvementStockcommande.CO_IDCOMMERCIAL == "")
                vppParamCO_IDCOMMERCIAL.Value = DBNull.Value;

            SqlParameter vppParamMK_DATEPIECE = new SqlParameter("@MK_DATEPIECE", SqlDbType.DateTime);
            vppParamMK_DATEPIECE.Value = clsPhamouvementStockcommande.MK_DATEPIECE;
            if (clsPhamouvementStockcommande.MK_DATEPIECE < DateTime.Parse("01/01/1900"))
                vppParamMK_DATEPIECE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_NUMSEQUENCE = new SqlParameter("@MK_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMK_NUMSEQUENCE.Value = clsPhamouvementStockcommande.MK_NUMSEQUENCE;

            //SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 4);
            //vppParamFR_CODEFOURNISSEUR.Value = clsPhamouvementStockcommande.FR_CODEFOURNISSEUR;
            //if (clsPhamouvementStockcommande.FR_CODEFOURNISSEUR == "")
            //    vppParamFR_CODEFOURNISSEUR.Value = DBNull.Value;


            //SqlParameter vppParamFR_MATRICULE = new SqlParameter("@FR_MATRICULE", SqlDbType.VarChar, 8);
            //vppParamFR_MATRICULE.Value = clsPhamouvementStockcommande.FR_MATRICULE;
            //if (clsPhamouvementStockcommande.FR_MATRICULE == "")
            //    vppParamFR_MATRICULE.Value = DBNull.Value;



            SqlParameter vppParamMK_TAUXASDI = new SqlParameter("@MK_TAUXASDI", SqlDbType.Float);
            vppParamMK_TAUXASDI.Value = clsPhamouvementStockcommande.MK_TAUXASDI;

            SqlParameter vppParamMK_TAUXTVA = new SqlParameter("@MK_TAUXTVA", SqlDbType.Float);
            vppParamMK_TAUXTVA.Value = clsPhamouvementStockcommande.MK_TAUXTVA;


            SqlParameter vppParamMK_REFPIECE = new SqlParameter("@MK_REFPIECE", SqlDbType.VarChar, 150);
            vppParamMK_REFPIECE.Value = clsPhamouvementStockcommande.MK_REFPIECE;

            SqlParameter vppParamMK_LIBOPERA = new SqlParameter("@MK_LIBOPERA", SqlDbType.VarChar, 150);
            vppParamMK_LIBOPERA.Value = clsPhamouvementStockcommande.MK_LIBOPERA;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementStockcommande.NO_CODENATUREOPERATION;

            SqlParameter vppParamMK_TAUXREMISE = new SqlParameter("@MK_TAUXREMISE", SqlDbType.Float);
            vppParamMK_TAUXREMISE.Value = clsPhamouvementStockcommande.MK_TAUXREMISE;

            SqlParameter vppParamMK_MONTANTTOTALREMISE = new SqlParameter("@MK_MONTANTTOTALREMISE", SqlDbType.Money);
            vppParamMK_MONTANTTOTALREMISE.Value = clsPhamouvementStockcommande.MK_MONTANTTOTALREMISE;

            SqlParameter vppParamMK_MONTANTTRANSPORT = new SqlParameter("@MK_MONTANTTRANSPORT", SqlDbType.Money);
            vppParamMK_MONTANTTRANSPORT.Value = clsPhamouvementStockcommande.MK_MONTANTTRANSPORT;

            SqlParameter vppParamMK_MONTANTVERSE = new SqlParameter("@MK_MONTANTVERSE", SqlDbType.Money);
            vppParamMK_MONTANTVERSE.Value = clsPhamouvementStockcommande.MK_MONTANTVERSE;

            SqlParameter vppParamMK_DELAILIVRAISON = new SqlParameter("@MK_DELAILIVRAISON", SqlDbType.TinyInt);
            vppParamMK_DELAILIVRAISON.Value = clsPhamouvementStockcommande.MK_DELAILIVRAISON;

            SqlParameter vppParamMK_DATELIVRAISON = new SqlParameter("@MK_DATELIVRAISON", SqlDbType.DateTime);
            vppParamMK_DATELIVRAISON.Value = clsPhamouvementStockcommande.MK_DATELIVRAISON;
            if (clsPhamouvementStockcommande.MK_DATELIVRAISON < DateTime.Parse("01/01/1900"))
                vppParamMK_DATELIVRAISON.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_ANNULATIONPIECE = new SqlParameter("@MK_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMK_ANNULATIONPIECE.Value = clsPhamouvementStockcommande.MK_ANNULATIONPIECE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStockcommande.OP_CODEOPERATEUR;

            SqlParameter vppParamMK_DATESAISIE = new SqlParameter("@MK_DATESAISIE", SqlDbType.DateTime);
            vppParamMK_DATESAISIE.Value = clsPhamouvementStockcommande.MK_DATESAISIE;
            if (clsPhamouvementStockcommande.MK_DATESAISIE < DateTime.Parse("01/01/1900"))
                vppParamMK_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_MONTANTECHEANCE = new SqlParameter("@MK_MONTANTECHEANCE", SqlDbType.Money);
            vppParamMK_MONTANTECHEANCE.Value = clsPhamouvementStockcommande.MK_MONTANTECHEANCE;

            SqlParameter vppParamMK_DATEDEBUTREGLEMENT = new SqlParameter("@MK_DATEDEBUTREGLEMENT", SqlDbType.DateTime);
            vppParamMK_DATEDEBUTREGLEMENT.Value = clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT;
            if (clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT < DateTime.Parse("01/01/1900"))
                vppParamMK_DATEDEBUTREGLEMENT.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_DUREEVALIDITE = new SqlParameter("@MK_DUREEVALIDITE", SqlDbType.VarChar, 150);
            vppParamMK_DUREEVALIDITE.Value = clsPhamouvementStockcommande.MK_DUREEVALIDITE;

            SqlParameter vppParamMK_CONDITIONREGLEMENT = new SqlParameter("@MK_CONDITIONREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMK_CONDITIONREGLEMENT.Value = clsPhamouvementStockcommande.MK_CONDITIONREGLEMENT;

            SqlParameter vppParamMK_SITUATIONFACTURE = new SqlParameter("@MK_SITUATIONFACTURE", SqlDbType.VarChar, 1);
            vppParamMK_SITUATIONFACTURE.Value = clsPhamouvementStockcommande.MK_SITUATIONFACTURE;

            SqlParameter vppParamMK_VOSREFERENCES = new SqlParameter("@MK_VOSREFERENCES", SqlDbType.VarChar, 150);
            vppParamMK_VOSREFERENCES.Value = clsPhamouvementStockcommande.MK_VOSREFERENCES;
            if (clsPhamouvementStockcommande.MK_VOSREFERENCES == "")
                vppParamMK_VOSREFERENCES.Value = DBNull.Value;

            SqlParameter vppParamMK_CONDITIONDEREGLEMENT = new SqlParameter("@MK_CONDITIONDEREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMK_CONDITIONDEREGLEMENT.Value = clsPhamouvementStockcommande.MK_CONDITIONDEREGLEMENT;
            if (clsPhamouvementStockcommande.MK_CONDITIONDEREGLEMENT == "")
                vppParamMK_CONDITIONDEREGLEMENT.Value = DBNull.Value;

            SqlParameter vppParamMK_REMETTANT = new SqlParameter("@MK_REMETTANT", SqlDbType.VarChar, 150);
            vppParamMK_REMETTANT.Value = clsPhamouvementStockcommande.MK_REMETTANT;
            if (clsPhamouvementStockcommande.MK_REMETTANT == "")
                vppParamMK_REMETTANT.Value = DBNull.Value;


            SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMR_CODEMODEREGLEMENT.Value = clsPhamouvementStockcommande.MR_CODEMODEREGLEMENT;
            if (clsPhamouvementStockcommande.MR_CODEMODEREGLEMENT == "")
                vppParamMR_CODEMODEREGLEMENT.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEURRESPONSABLECMD = new SqlParameter("@OP_CODEOPERATEURRESPONSABLECMD", SqlDbType.VarChar, 150);
            vppParamOP_CODEOPERATEURRESPONSABLECMD.Value = clsPhamouvementStockcommande.OP_CODEOPERATEURRESPONSABLECMD;
            if (clsPhamouvementStockcommande.OP_CODEOPERATEURRESPONSABLECMD == "")
                vppParamOP_CODEOPERATEURRESPONSABLECMD.Value = DBNull.Value;

            SqlParameter vppParamMK_MOTIFCMD = new SqlParameter("@MK_MOTIFCMD", SqlDbType.VarChar, 150);
            vppParamMK_MOTIFCMD.Value = clsPhamouvementStockcommande.MK_MOTIFCMD;
            if (clsPhamouvementStockcommande.MK_MOTIFCMD == "")
                vppParamMK_MOTIFCMD.Value = DBNull.Value;

            SqlParameter vppParamMK_LIEULIVRAISON = new SqlParameter("@MK_LIEULIVRAISON", SqlDbType.VarChar, 150);
            vppParamMK_LIEULIVRAISON.Value = clsPhamouvementStockcommande.MK_LIEULIVRAISON;
            if (clsPhamouvementStockcommande.MK_LIEULIVRAISON == "")
                vppParamMK_LIEULIVRAISON.Value = DBNull.Value;

            SqlParameter vppParamMK_PERSONNEACONTACTER = new SqlParameter("@MK_PERSONNEACONTACTER", SqlDbType.VarChar, 150);
            vppParamMK_PERSONNEACONTACTER.Value = clsPhamouvementStockcommande.MK_PERSONNEACONTACTER;
            if (clsPhamouvementStockcommande.MK_PERSONNEACONTACTER == "")
                vppParamMK_PERSONNEACONTACTER.Value = DBNull.Value;


            SqlParameter vppParamMK_CONTACTPERSONNEACONTACTER = new SqlParameter("@MK_CONTACTPERSONNEACONTACTER", SqlDbType.VarChar, 150);
            vppParamMK_CONTACTPERSONNEACONTACTER.Value = clsPhamouvementStockcommande.MK_CONTACTPERSONNEACONTACTER;
            if (clsPhamouvementStockcommande.MK_CONTACTPERSONNEACONTACTER == "")
                vppParamMK_CONTACTPERSONNEACONTACTER.Value = DBNull.Value;

            SqlParameter vppParamMK_NOTERBIEN = new SqlParameter("@MK_NOTERBIEN", SqlDbType.VarChar, 150);
            vppParamMK_NOTERBIEN.Value = clsPhamouvementStockcommande.MK_NOTERBIEN;
            if (clsPhamouvementStockcommande.MK_NOTERBIEN == "")
                vppParamMK_NOTERBIEN.Value = DBNull.Value;



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = "0";

            SqlParameter vppParamMK_NUMPIECERETOUR = new SqlParameter("@MK_NUMPIECERETOUR", SqlDbType.VarChar, 50);

            //Préparation de la commande
            //this.vapRequete = " EXECUTE dbo.PS_PHAMOUVEMENTSTOCKCOMMANDE @AG_CODEAGENCE,@MK_NUMPIECE,@EN_CODEENTREPOT,@CH_IDCHAUFFEUR,@MK_DATEPIECE,@MK_NUMSEQUENCE,@FR_MATRICULE,@TI_NUMTIERS,@CO_IDCOMMERCIAL,@MK_REFPIECE,@MK_LIBOPERA,@NO_CODENATUREOPERATION,@MK_TAUXREMISE,@MK_MONTANTTOTALREMISE,@MK_MONTANTTRANSPORT,0,@MK_DELAILIVRAISON,@MK_DATELIVRAISON,@MK_ANNULATIONPIECE,@MK_DATESAISIE,@MK_MONTANTECHEANCE,@MK_DATEDEBUTREGLEMENT,@MK_DUREEVALIDITE,@MK_CONDITIONREGLEMENT,@MK_SITUATIONFACTURE,@OP_CODEOPERATEUR,@MK_TAUXTVA,@MK_TAUXASDI,@CODECRYPTAGE,0 ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            SqlCommand vppSqlCmd = new SqlCommand("PS_PHAMOUVEMENTSTOCKCOMMANDE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamMK_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMK_NUMSEQUENCE);
            //vppSqlCmd.Parameters.Add(vppParamFR_MATRICULE);
            //vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamMK_REFPIECE);
            vppSqlCmd.Parameters.Add(vppParamMK_LIBOPERA);
            vppSqlCmd.Parameters.Add(vppParamMK_TAUXASDI);
            vppSqlCmd.Parameters.Add(vppParamMK_TAUXTVA);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMK_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamMK_MONTANTTOTALREMISE);
            vppSqlCmd.Parameters.Add(vppParamMK_MONTANTTRANSPORT);
            vppSqlCmd.Parameters.Add(vppParamMK_MONTANTVERSE);
            vppSqlCmd.Parameters.Add(vppParamMK_DELAILIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMK_DATELIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMK_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamMK_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamMK_MONTANTECHEANCE);
            vppSqlCmd.Parameters.Add(vppParamMK_DATEDEBUTREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMK_DUREEVALIDITE);
            vppSqlCmd.Parameters.Add(vppParamMK_CONDITIONREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMK_SITUATIONFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMK_VOSREFERENCES);
            vppSqlCmd.Parameters.Add(vppParamMK_CONDITIONDEREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMK_REMETTANT);


            vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURRESPONSABLECMD);
            vppSqlCmd.Parameters.Add(vppParamMK_MOTIFCMD);
            vppSqlCmd.Parameters.Add(vppParamMK_LIEULIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMK_PERSONNEACONTACTER);
            vppSqlCmd.Parameters.Add(vppParamMK_CONTACTPERSONNEACONTACTER);
            vppSqlCmd.Parameters.Add(vppParamMK_NOTERBIEN);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECERETOUR);
            vppParamMK_NUMPIECERETOUR.Direction = ParameterDirection.Output;
            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MK_NUMPIECERETOUR"].Value.ToString();
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockcommande>clsPhamouvementStockcommande</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockcommande.AG_CODEAGENCE;

            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStockcommande.MK_NUMPIECE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementStockcommande.EN_CODEENTREPOT;
            if (clsPhamouvementStockcommande.EN_CODEENTREPOT == "")
                vppParamEN_CODEENTREPOT.Value = DBNull.Value;

            SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.VarChar, 25);
            vppParamCH_IDCHAUFFEUR.Value = clsPhamouvementStockcommande.CH_IDCHAUFFEUR;
            if (clsPhamouvementStockcommande.CH_IDCHAUFFEUR == "")
                vppParamCH_IDCHAUFFEUR.Value = DBNull.Value;

            //SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar,25);
            //vppParamTI_IDTIERS.Value = clsPhamouvementStockcommande.TI_IDTIERS;
            //if (clsPhamouvementStockcommande.TI_IDTIERS == "")
            //    vppParamTI_IDTIERS.Value = DBNull.Value;

            SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 8);
            vppParamTI_NUMTIERS.Value = clsPhamouvementStockcommande.TI_NUMTIERS;
            if (clsPhamouvementStockcommande.TI_NUMTIERS == "")
                vppParamTI_NUMTIERS.Value = DBNull.Value;

            SqlParameter vppParamPR_IDTIERS = new SqlParameter("@PR_IDTIERS", SqlDbType.VarChar, 25);
            vppParamPR_IDTIERS.Value = clsPhamouvementStockcommande.PR_IDTIERS;
            if (clsPhamouvementStockcommande.PR_IDTIERS == "")
                vppParamPR_IDTIERS.Value = DBNull.Value;

            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar, 25);
            vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementStockcommande.CO_IDCOMMERCIAL;
            if (clsPhamouvementStockcommande.CO_IDCOMMERCIAL == "")
                vppParamCO_IDCOMMERCIAL.Value = DBNull.Value;

            SqlParameter vppParamMK_DATEPIECE = new SqlParameter("@MK_DATEPIECE", SqlDbType.DateTime);
            vppParamMK_DATEPIECE.Value = clsPhamouvementStockcommande.MK_DATEPIECE;
            if (clsPhamouvementStockcommande.MK_DATEPIECE < DateTime.Parse("01/01/1900"))
                vppParamMK_DATEPIECE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_NUMSEQUENCE = new SqlParameter("@MK_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMK_NUMSEQUENCE.Value = clsPhamouvementStockcommande.MK_NUMSEQUENCE;

            //SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 4);
            //vppParamFR_CODEFOURNISSEUR.Value = clsPhamouvementStockcommande.FR_CODEFOURNISSEUR;
            //if (clsPhamouvementStockcommande.FR_CODEFOURNISSEUR == "")
            //    vppParamFR_CODEFOURNISSEUR.Value = DBNull.Value;


            //SqlParameter vppParamFR_MATRICULE = new SqlParameter("@FR_MATRICULE", SqlDbType.VarChar, 8);
            //vppParamFR_MATRICULE.Value = clsPhamouvementStockcommande.FR_MATRICULE;
            //if (clsPhamouvementStockcommande.FR_MATRICULE == "")
            //    vppParamFR_MATRICULE.Value = DBNull.Value;



            SqlParameter vppParamMK_TAUXASDI = new SqlParameter("@MK_TAUXASDI", SqlDbType.Float);
            vppParamMK_TAUXASDI.Value = clsPhamouvementStockcommande.MK_TAUXASDI;

            SqlParameter vppParamMK_TAUXTVA = new SqlParameter("@MK_TAUXTVA", SqlDbType.Float);
            vppParamMK_TAUXTVA.Value = clsPhamouvementStockcommande.MK_TAUXTVA;


            SqlParameter vppParamMK_REFPIECE = new SqlParameter("@MK_REFPIECE", SqlDbType.VarChar, 150);
            vppParamMK_REFPIECE.Value = clsPhamouvementStockcommande.MK_REFPIECE;

            SqlParameter vppParamMK_LIBOPERA = new SqlParameter("@MK_LIBOPERA", SqlDbType.VarChar, 150);
            vppParamMK_LIBOPERA.Value = clsPhamouvementStockcommande.MK_LIBOPERA;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementStockcommande.NO_CODENATUREOPERATION;

            SqlParameter vppParamMK_TAUXREMISE = new SqlParameter("@MK_TAUXREMISE", SqlDbType.Float);
            vppParamMK_TAUXREMISE.Value = clsPhamouvementStockcommande.MK_TAUXREMISE;

            SqlParameter vppParamMK_MONTANTTOTALREMISE = new SqlParameter("@MK_MONTANTTOTALREMISE", SqlDbType.Money);
            vppParamMK_MONTANTTOTALREMISE.Value = clsPhamouvementStockcommande.MK_MONTANTTOTALREMISE;

            SqlParameter vppParamMK_MONTANTTRANSPORT = new SqlParameter("@MK_MONTANTTRANSPORT", SqlDbType.Money);
            vppParamMK_MONTANTTRANSPORT.Value = clsPhamouvementStockcommande.MK_MONTANTTRANSPORT;

            SqlParameter vppParamMK_MONTANTVERSE = new SqlParameter("@MK_MONTANTVERSE", SqlDbType.Money);
            vppParamMK_MONTANTVERSE.Value = clsPhamouvementStockcommande.MK_MONTANTVERSE;

            SqlParameter vppParamMK_DELAILIVRAISON = new SqlParameter("@MK_DELAILIVRAISON", SqlDbType.TinyInt);
            vppParamMK_DELAILIVRAISON.Value = clsPhamouvementStockcommande.MK_DELAILIVRAISON;

            SqlParameter vppParamMK_DATELIVRAISON = new SqlParameter("@MK_DATELIVRAISON", SqlDbType.DateTime);
            vppParamMK_DATELIVRAISON.Value = clsPhamouvementStockcommande.MK_DATELIVRAISON;
            if (clsPhamouvementStockcommande.MK_DATELIVRAISON < DateTime.Parse("01/01/1900"))
                vppParamMK_DATELIVRAISON.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_ANNULATIONPIECE = new SqlParameter("@MK_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMK_ANNULATIONPIECE.Value = clsPhamouvementStockcommande.MK_ANNULATIONPIECE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStockcommande.OP_CODEOPERATEUR;

            SqlParameter vppParamMK_DATESAISIE = new SqlParameter("@MK_DATESAISIE", SqlDbType.DateTime);
            vppParamMK_DATESAISIE.Value = clsPhamouvementStockcommande.MK_DATESAISIE;
            if (clsPhamouvementStockcommande.MK_DATESAISIE < DateTime.Parse("01/01/1900"))
                vppParamMK_DATESAISIE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_MONTANTECHEANCE = new SqlParameter("@MK_MONTANTECHEANCE", SqlDbType.Money);
            vppParamMK_MONTANTECHEANCE.Value = clsPhamouvementStockcommande.MK_MONTANTECHEANCE;

            SqlParameter vppParamMK_DATEDEBUTREGLEMENT = new SqlParameter("@MK_DATEDEBUTREGLEMENT", SqlDbType.DateTime);
            vppParamMK_DATEDEBUTREGLEMENT.Value = clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT;
            if (clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT < DateTime.Parse("01/01/1900"))
                vppParamMK_DATEDEBUTREGLEMENT.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMK_DUREEVALIDITE = new SqlParameter("@MK_DUREEVALIDITE", SqlDbType.VarChar, 150);
            vppParamMK_DUREEVALIDITE.Value = clsPhamouvementStockcommande.MK_DUREEVALIDITE;

            SqlParameter vppParamMK_CONDITIONREGLEMENT = new SqlParameter("@MK_CONDITIONREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMK_CONDITIONREGLEMENT.Value = clsPhamouvementStockcommande.MK_CONDITIONREGLEMENT;

            SqlParameter vppParamMK_SITUATIONFACTURE = new SqlParameter("@MK_SITUATIONFACTURE", SqlDbType.VarChar, 1);
            vppParamMK_SITUATIONFACTURE.Value = clsPhamouvementStockcommande.MK_SITUATIONFACTURE;



            SqlParameter vppParamMK_VOSREFERENCES = new SqlParameter("@MK_VOSREFERENCES", SqlDbType.VarChar, 150);
            vppParamMK_VOSREFERENCES.Value = clsPhamouvementStockcommande.MK_VOSREFERENCES;
            if (clsPhamouvementStockcommande.MK_VOSREFERENCES == "")
                vppParamMK_VOSREFERENCES.Value = DBNull.Value;

            SqlParameter vppParamMK_CONDITIONDEREGLEMENT = new SqlParameter("@MK_CONDITIONDEREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMK_CONDITIONDEREGLEMENT.Value = clsPhamouvementStockcommande.MK_CONDITIONDEREGLEMENT;
            if (clsPhamouvementStockcommande.MK_CONDITIONDEREGLEMENT == "")
                vppParamMK_CONDITIONDEREGLEMENT.Value = DBNull.Value;

            SqlParameter vppParamMK_REMETTANT = new SqlParameter("@MK_REMETTANT", SqlDbType.VarChar, 150);
            vppParamMK_REMETTANT.Value = clsPhamouvementStockcommande.MK_REMETTANT;
            if (clsPhamouvementStockcommande.MK_REMETTANT == "")
                vppParamMK_REMETTANT.Value = DBNull.Value;

            SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMR_CODEMODEREGLEMENT.Value = clsPhamouvementStockcommande.MR_CODEMODEREGLEMENT;
            if (clsPhamouvementStockcommande.MR_CODEMODEREGLEMENT == "")
                vppParamMR_CODEMODEREGLEMENT.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEURRESPONSABLECMD = new SqlParameter("@OP_CODEOPERATEURRESPONSABLECMD", SqlDbType.VarChar, 150);
            vppParamOP_CODEOPERATEURRESPONSABLECMD.Value = clsPhamouvementStockcommande.OP_CODEOPERATEURRESPONSABLECMD;
            if (clsPhamouvementStockcommande.OP_CODEOPERATEURRESPONSABLECMD == "")
                vppParamOP_CODEOPERATEURRESPONSABLECMD.Value = DBNull.Value;

            SqlParameter vppParamMK_MOTIFCMD = new SqlParameter("@MK_MOTIFCMD", SqlDbType.VarChar, 150);
            vppParamMK_MOTIFCMD.Value = clsPhamouvementStockcommande.MK_MOTIFCMD;
            if (clsPhamouvementStockcommande.MK_MOTIFCMD == "")
                vppParamMK_MOTIFCMD.Value = DBNull.Value;

            SqlParameter vppParamMK_LIEULIVRAISON = new SqlParameter("@MK_LIEULIVRAISON", SqlDbType.VarChar, 150);
            vppParamMK_LIEULIVRAISON.Value = clsPhamouvementStockcommande.MK_LIEULIVRAISON;
            if (clsPhamouvementStockcommande.MK_LIEULIVRAISON == "")
                vppParamMK_LIEULIVRAISON.Value = DBNull.Value;

            SqlParameter vppParamMK_PERSONNEACONTACTER = new SqlParameter("@MK_PERSONNEACONTACTER", SqlDbType.VarChar, 150);
            vppParamMK_PERSONNEACONTACTER.Value = clsPhamouvementStockcommande.MK_PERSONNEACONTACTER;
            if (clsPhamouvementStockcommande.MK_PERSONNEACONTACTER == "")
                vppParamMK_PERSONNEACONTACTER.Value = DBNull.Value;


            SqlParameter vppParamMK_CONTACTPERSONNEACONTACTER = new SqlParameter("@MK_CONTACTPERSONNEACONTACTER", SqlDbType.VarChar, 150);
            vppParamMK_CONTACTPERSONNEACONTACTER.Value = clsPhamouvementStockcommande.MK_CONTACTPERSONNEACONTACTER;
            if (clsPhamouvementStockcommande.MK_CONTACTPERSONNEACONTACTER == "")
                vppParamMK_CONTACTPERSONNEACONTACTER.Value = DBNull.Value;

            SqlParameter vppParamMK_NOTERBIEN = new SqlParameter("@MK_NOTERBIEN", SqlDbType.VarChar, 150);
            vppParamMK_NOTERBIEN.Value = clsPhamouvementStockcommande.MK_NOTERBIEN;
            if (clsPhamouvementStockcommande.MK_NOTERBIEN == "")
                vppParamMK_NOTERBIEN.Value = DBNull.Value;






            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            //vppParamTYPEOPERATION.Value = "1";

            //Préparation de la commande
            this.vapRequete = " EXECUTE [dbo].[PS_PHAMOUVEMENTSTOCKCOMMANDE] @AG_CODEAGENCE, @MK_NUMPIECE , @EN_CODEENTREPOT , @CH_IDCHAUFFEUR, @MK_DATEPIECE,@MK_NUMSEQUENCE, @TI_NUMTIERS,@PR_IDTIERS,@CO_IDCOMMERCIAL, @MK_REFPIECE, @MK_LIBOPERA , @NO_CODENATUREOPERATION, @MK_TAUXREMISE, @MK_MONTANTTOTALREMISE, @MK_MONTANTTRANSPORT,@MK_MONTANTVERSE,@MK_DELAILIVRAISON, @MK_DATELIVRAISON, @MK_ANNULATIONPIECE, @MK_DATESAISIE, @MK_MONTANTECHEANCE,@MK_DATEDEBUTREGLEMENT, @MK_DUREEVALIDITE , @MK_CONDITIONREGLEMENT, @MK_SITUATIONFACTURE, @OP_CODEOPERATEUR, @MK_TAUXTVA, @MK_TAUXASDI, @MK_VOSREFERENCES,@MK_CONDITIONDEREGLEMENT,@MK_REMETTANT,@MR_CODEMODEREGLEMENT,@OP_CODEOPERATEURRESPONSABLECMD,@MK_MOTIFCMD,@MK_LIEULIVRAISON,@MK_PERSONNEACONTACTER,@MK_CONTACTPERSONNEACONTACTER,@MK_NOTERBIEN, @CODECRYPTAGE,1,'' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamMK_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMK_NUMSEQUENCE);
            //vppSqlCmd.Parameters.Add(vppParamFR_MATRICULE);
            //vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamMK_REFPIECE);
            vppSqlCmd.Parameters.Add(vppParamMK_LIBOPERA);
            vppSqlCmd.Parameters.Add(vppParamMK_TAUXASDI);
            vppSqlCmd.Parameters.Add(vppParamMK_TAUXTVA);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMK_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamMK_MONTANTTOTALREMISE);
            vppSqlCmd.Parameters.Add(vppParamMK_MONTANTTRANSPORT);
            vppSqlCmd.Parameters.Add(vppParamMK_MONTANTVERSE);
            vppSqlCmd.Parameters.Add(vppParamMK_DELAILIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMK_DATELIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMK_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamMK_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamMK_MONTANTECHEANCE);
            vppSqlCmd.Parameters.Add(vppParamMK_DATEDEBUTREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMK_DUREEVALIDITE);
            vppSqlCmd.Parameters.Add(vppParamMK_CONDITIONREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMK_SITUATIONFACTURE);

            vppSqlCmd.Parameters.Add(vppParamMK_VOSREFERENCES);
            vppSqlCmd.Parameters.Add(vppParamMK_CONDITIONDEREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMK_REMETTANT);

            vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURRESPONSABLECMD);
            vppSqlCmd.Parameters.Add(vppParamMK_MOTIFCMD);
            vppSqlCmd.Parameters.Add(vppParamMK_LIEULIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMK_PERSONNEACONTACTER);
            vppSqlCmd.Parameters.Add(vppParamMK_CONTACTPERSONNEACONTACTER);
            vppSqlCmd.Parameters.Add(vppParamMK_NOTERBIEN);
            //            MR_CODEMODEREGLEMENT varchar(2)  Checked
            //OP_CODEOPERATEURRESPONSABLECMD  bigint  Checked
            //MK_MOTIFCMD varchar(1000)   Checked
            //MK_LIEULIVRAISON    varchar(1000)   Checked
            //MK_PERSONNEACONTACTER   varchar(1000)   Checked
            //MK_CONTACTPERSONNEACONTACTER    varchar(1000)   Checked


            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}

        public void pvgAnnulerCommande(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MK_NUMPIECE" };
            vapValeurParametre = new object[] { clsPhamouvementStockcommande.AG_CODEAGENCE, clsPhamouvementStockcommande.MK_NUMPIECE };
            this.vapRequete = "EXEC PS_PHAMOUVEMENTSTOCKCOMMANDESUPPRESSION @AG_CODEAGENCE,@MK_NUMPIECE ";
            this.vapCritere = "";
            //
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //Ajout des paramètre à la commande


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }
        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PhamouvementStockCOMMANDE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockcommande </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockcommande> pvgSelectCommande(clsDonnee clsDonnee, params string[] vppCritere)
		{

			this.vapRequete = "SELECT  AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, MK_DATEPIECE, MK_NUMSEQUENCE, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, MK_REFPIECE, MK_LIBOPERA, NO_CODENATUREOPERATION, MK_TAUXREMISE,"+
                " MK_MONTANTTOTALREMISE, MK_MONTANTTRANSPORT, MK_DELAILIVRAISON, MK_DATELIVRAISON, MK_ANNULATIONPIECE, MK_DATESAISIE, MK_MONTANTECHEANCE, MK_DATEDEBUTREGLEMENT, MK_DUREEVALIDITE, MK_CONDITIONREGLEMENT, MK_SITUATIONFACTURE, OP_CODEOPERATEUR, MK_TAUXTVA, MK_TAUXASDI FROM dbo.PhamouvementStockCOMMANDE " + this.vapCritere;
			this.vapCritere="";			
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementStockcommande> clsPhamouvementStockcommandes = new List<clsPhamouvementStockcommande>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockcommande clsPhamouvementStockcommande = new clsPhamouvementStockcommande();
					clsPhamouvementStockcommande.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementStockcommande.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
					clsPhamouvementStockcommande.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsPhamouvementStockcommande.CH_IDCHAUFFEUR = clsDonnee.vogDataReader["CH_IDCHAUFFEUR"].ToString();
					clsPhamouvementStockcommande.MK_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MK_DATEPIECE"].ToString());
					clsPhamouvementStockcommande.MK_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["MK_NUMSEQUENCE"].ToString());
                    //clsPhamouvementStockcommande.FR_CODEFOURNISSEUR = clsDonnee.vogDataReader["FR_CODEFOURNISSEUR"].ToString();
					clsPhamouvementStockcommande.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhamouvementStockcommande.CO_IDCOMMERCIAL = clsDonnee.vogDataReader["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementStockcommande.MK_REFPIECE = clsDonnee.vogDataReader["MK_REFPIECE"].ToString();
					clsPhamouvementStockcommande.MK_LIBOPERA = clsDonnee.vogDataReader["MK_LIBOPERA"].ToString();
					clsPhamouvementStockcommande.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementStockcommande.MK_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MK_TAUXREMISE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTTOTALREMISE = double.Parse(clsDonnee.vogDataReader["MK_MONTANTTOTALREMISE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTTRANSPORT = double.Parse(clsDonnee.vogDataReader["MK_MONTANTTRANSPORT"].ToString());
					clsPhamouvementStockcommande.MK_DELAILIVRAISON = int.Parse(clsDonnee.vogDataReader["MK_DELAILIVRAISON"].ToString());
					clsPhamouvementStockcommande.MK_DATELIVRAISON = DateTime.Parse(clsDonnee.vogDataReader["MK_DATELIVRAISON"].ToString());
					clsPhamouvementStockcommande.MK_ANNULATIONPIECE = clsDonnee.vogDataReader["MK_ANNULATIONPIECE"].ToString();
					clsPhamouvementStockcommande.MK_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["MK_DATESAISIE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTECHEANCE = double.Parse(clsDonnee.vogDataReader["MK_MONTANTECHEANCE"].ToString());
					clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT = DateTime.Parse(clsDonnee.vogDataReader["MK_DATEDEBUTREGLEMENT"].ToString());
					clsPhamouvementStockcommande.MK_DUREEVALIDITE = clsDonnee.vogDataReader["MK_DUREEVALIDITE"].ToString();
					clsPhamouvementStockcommande.MK_CONDITIONREGLEMENT = clsDonnee.vogDataReader["MK_CONDITIONREGLEMENT"].ToString();
					clsPhamouvementStockcommande.MK_SITUATIONFACTURE = clsDonnee.vogDataReader["MK_SITUATIONFACTURE"].ToString();
					clsPhamouvementStockcommande.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementStockcommande.MK_TAUXTVA = float.Parse(clsDonnee.vogDataReader["MK_TAUXTVA"].ToString());
					clsPhamouvementStockcommande.MK_TAUXASDI = float.Parse(clsDonnee.vogDataReader["MK_TAUXASDI"].ToString());
					clsPhamouvementStockcommandes.Add(clsPhamouvementStockcommande);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementStockcommandes;
		}

        public List<clsPhamouvementStockcommande> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' " : " AND  MK_ANNULATIONPIECE = 'N' ";
            return pvgSelectCommande(clsDonnee, vppCritere);
        }
        public List<clsPhamouvementStockcommande> pvgSelectCommandeClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' AND TI_IDTIERS IS NOT NULL AND TI_IDTIERS<>'' " : " AND  MK_ANNULATIONPIECE = 'N' AND TI_IDTIERS IS NOT NULL AND TI_IDTIERS<>'' ";
            return pvgSelectCommande(clsDonnee, vppCritere);
        }
        public List<clsPhamouvementStockcommande> pvgSelectCommandeFournisseur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' AND FR_CODEFOURNISSEUR IS NOT NULL AND FR_CODEFOURNISSEUR<>'' " : " AND  MK_ANNULATIONPIECE = 'N' AND FR_CODEFOURNISSEUR IS NOT NULL AND FR_CODEFOURNISSEUR<>'' ";
            return pvgSelectCommande(clsDonnee, vppCritere);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockcommande </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockcommande> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementStockcommande> clsPhamouvementStockcommandes = new List<clsPhamouvementStockcommande>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
            if (this.vapCritere != "") this.vapCritere += " AND MK_ANNULATIONPIECE = 'N'";
			this.vapRequete = "SELECT  AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, MK_DATEPIECE, MK_NUMSEQUENCE, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, MK_REFPIECE, MK_LIBOPERA, NO_CODENATUREOPERATION, MK_TAUXREMISE, MK_MONTANTTOTALREMISE,"+
                " MK_MONTANTTRANSPORT, MK_DELAILIVRAISON, MK_DATELIVRAISON, MK_ANNULATIONPIECE, MK_DATESAISIE, MK_MONTANTECHEANCE, MK_DATEDEBUTREGLEMENT, MK_DUREEVALIDITE, MK_CONDITIONREGLEMENT, MK_SITUATIONFACTURE, OP_CODEOPERATEUR, MK_TAUXTVA, MK_TAUXASDI FROM dbo.PhamouvementStockCOMMANDE " + this.vapCritere ;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementStockcommande clsPhamouvementStockcommande = new clsPhamouvementStockcommande();
					clsPhamouvementStockcommande.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementStockcommande.MK_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MK_NUMPIECE"].ToString();
					clsPhamouvementStockcommande.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsPhamouvementStockcommande.CH_IDCHAUFFEUR = Dataset.Tables["TABLE"].Rows[Idx]["CH_IDCHAUFFEUR"].ToString();
					clsPhamouvementStockcommande.MK_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_DATEPIECE"].ToString());
					clsPhamouvementStockcommande.MK_NUMSEQUENCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_NUMSEQUENCE"].ToString());
                    //clsPhamouvementStockcommande.FR_CODEFOURNISSEUR = Dataset.Tables["TABLE"].Rows[Idx]["FR_CODEFOURNISSEUR"].ToString();
					clsPhamouvementStockcommande.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsPhamouvementStockcommande.CO_IDCOMMERCIAL = Dataset.Tables["TABLE"].Rows[Idx]["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementStockcommande.MK_REFPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MK_REFPIECE"].ToString();
					clsPhamouvementStockcommande.MK_LIBOPERA = Dataset.Tables["TABLE"].Rows[Idx]["MK_LIBOPERA"].ToString();
					clsPhamouvementStockcommande.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementStockcommande.MK_TAUXREMISE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_TAUXREMISE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTTOTALREMISE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_MONTANTTOTALREMISE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTTRANSPORT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_MONTANTTRANSPORT"].ToString());
					clsPhamouvementStockcommande.MK_DELAILIVRAISON = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_DELAILIVRAISON"].ToString());
					clsPhamouvementStockcommande.MK_DATELIVRAISON = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_DATELIVRAISON"].ToString());
					clsPhamouvementStockcommande.MK_ANNULATIONPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MK_ANNULATIONPIECE"].ToString();
					clsPhamouvementStockcommande.MK_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_DATESAISIE"].ToString());
					clsPhamouvementStockcommande.MK_MONTANTECHEANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_MONTANTECHEANCE"].ToString());
					clsPhamouvementStockcommande.MK_DATEDEBUTREGLEMENT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_DATEDEBUTREGLEMENT"].ToString());
					clsPhamouvementStockcommande.MK_DUREEVALIDITE = Dataset.Tables["TABLE"].Rows[Idx]["MK_DUREEVALIDITE"].ToString();
					clsPhamouvementStockcommande.MK_CONDITIONREGLEMENT = Dataset.Tables["TABLE"].Rows[Idx]["MK_CONDITIONREGLEMENT"].ToString();
					clsPhamouvementStockcommande.MK_SITUATIONFACTURE = Dataset.Tables["TABLE"].Rows[Idx]["MK_SITUATIONFACTURE"].ToString();
					clsPhamouvementStockcommande.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementStockcommande.MK_TAUXTVA = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_TAUXTVA"].ToString());
					clsPhamouvementStockcommande.MK_TAUXASDI = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MK_TAUXASDI"].ToString());
					clsPhamouvementStockcommandes.Add(clsPhamouvementStockcommande);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementStockcommandes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            if (this.vapCritere != "") this.vapCritere += " AND MK_ANNULATIONPIECE = 'N'";
            this.vapRequete = "SELECT *  FROM dbo.PhamouvementStockCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere"> ordre de criteres @AG_CODEAGENCE, @MK_DATEPIECE1, @MK_DATEPIECE2, @TI_NUMTIERS, @TP_CODETYPECLIENT,@CL_DENOMINATION, @CO_IDCOMMERCIAL, @CO_NOMPRENOM, @MK_NUMPIECE, @MK_ANNULATIONPIECE</param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetCommandeClient(clsDonnee clsDonnee, params string[] vppCritere)
		{

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MK_NUMPIECE", "@MK_DATEPIECEDEBUT", "@MK_DATEPIECEFIN", "@TI_NUMTIERS", "@CL_DENOMINATION", "@CO_IDCOMMERCIAL", "@CO_NOMPRENOM", "@MK_ANNULATIONPIECE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], clsDonnee.vogCleCryptage };

            this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTECOMMANDECLIENT ( @AG_CODEAGENCE,@MK_NUMPIECE,@MK_DATEPIECEDEBUT,@MK_DATEPIECEFIN,@TI_NUMTIERS,@CL_DENOMINATION,@CO_IDCOMMERCIAL,@CO_NOMPRENOM,@MK_ANNULATIONPIECE,@CODECRYPTAGE ) WHERE NUMEROBORDEREAU LIKE '%'+@MK_NUMPIECE+'%' AND   CAST(ISNULL(TI_NUMTIERS,'') AS VARCHAR(50))  LIKE '%'+@TI_NUMTIERS+'%' AND CAST(ISNULL(CO_NUMCOMMERCIAL,'') AS VARCHAR(50))  LIKE '%'+@CO_NUMCOMMERCIAL+'%'  AND CAST(ISNULL(CO_NOMPRENOM,'') AS VARCHAR(150))  LIKE '%'+@CO_NOMPRENOM+'%'       AND CL_DENOMINATION LIKE '%'+@CL_DENOMINATION+'%'  ";	

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">ordre de critere "@AG_CODEAGENCE", "@MK_DATEPIECE1", "@MK_DATEPIECE2", "@FR_CODEFOURNISSEUR", "@FR_DENOMINATION", "@MK_NUMPIECE", "@MK_ANNULATIONPIECE" </param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetCommandeFournisseur(clsDonnee clsDonnee, params string[] vppCritere)
		{

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MK_NUMPIECE", "@MK_DATEPIECEDEBUT", "@MK_DATEPIECEFIN", "@TI_IDTIERS", "@TI_DENOMINATION", "@TP_CODETYPETIERS", "@MK_ANNULATIONPIECE", "@NUMEROBORDEREAU", "@TYPEOPERATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9],clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAMOUVEMENTSTOCKLISTECOMMANDEFOURNISSEUR @AG_CODEAGENCE,@MK_NUMPIECE,@MK_DATEPIECEDEBUT,@MK_DATEPIECEFIN,@TI_IDTIERS,@TI_DENOMINATION,@TP_CODETYPETIERS,@MK_ANNULATIONPIECE,@NUMEROBORDEREAU,@TYPEOPERATION,@CODECRYPTAGE  ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , MK_DATEPIECE FROM dbo.PhamouvementStockCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, TI_IDTIERS, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND CAST(MK_NUMPIECE AS VARCHAR(50))=@MK_NUMPIECE";
				vapNomParametre = new string[]{"@AG_CODEAGENCE","@MK_NUMPIECE"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
                //case 3 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
                //vapNomParametre = new string[]{"@AG_CODEAGENCE","@MK_NUMPIECE","@EN_CODEENTREPOT"};
                //vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
                //break;
                //case 4 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR";
                //vapNomParametre = new string[]{"@AG_CODEAGENCE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR"};
                //vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
                //break;
                //case 5 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR";
                //vapNomParametre = new string[]{"@AG_CODEAGENCE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR"};
                //vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
                //break;
                //case 6 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND TI_IDTIERS=@TI_IDTIERS";
                //vapNomParametre = new string[]{"@AG_CODEAGENCE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@TI_IDTIERS"};
                //vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
                //break;
                case 7://CE CAS CONCERNE RECHERCHE COMMANDE fournisseur   
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CONVERT( DATETIME , MK_DATEPIECE, 103) BETWEEN @MK_DATEPIECE1 AND @MK_DATEPIECE2  AND FR_CODEFOURNISSEUR LIKE '%'+@FR_CODEFOURNISSEUR+'%' AND FR_DENOMINATION LIKE '%'+@FR_DENOMINATION+'%' " +
                    " AND  MK_NUMPIECE LIKE '%'+@MK_NUMPIECE+'%' AND MK_ANNULATIONPIECE LIKE '%'+@MK_ANNULATIONPIECE+'%' ";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MK_DATEPIECE1", "@MK_DATEPIECE2", "@FR_CODEFOURNISSEUR", "@FR_DENOMINATION", "@MK_NUMPIECE", "@MK_ANNULATIONPIECE" };
                vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6]};
                break;
                case 10://CE CAS CONCERNE RECHERCHE COMMANDE CLIENT
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CONVERT( DATETIME , MK_DATEPIECE, 103) BETWEEN @MK_DATEPIECE1 AND @MK_DATEPIECE2  AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TP_CODETYPECLIENT LIKE '%'+@TP_CODETYPECLIENT+'%' "+
                    " AND CL_DENOMINATION LIKE '%'+@CL_DENOMINATION+'%' AND CO_NUMCOMMERCIAL LIKE '%'+@CO_NUMCOMMERCIAL+'%' AND CO_NOMPRENOM LIKE '%'+@CO_NOMPRENOM+'%' AND MK_NUMPIECE LIKE '%'+@MK_NUMPIECE+'%' AND MK_ANNULATIONPIECE LIKE '%'+@MK_ANNULATIONPIECE+'%' ";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MK_DATEPIECE1", "@MK_DATEPIECE2", "@TI_NUMTIERS", "@TP_CODETYPECLIENT", "@CL_DENOMINATION", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM", "@MK_NUMPIECE", "@MK_ANNULATIONPIECE" };
                vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] , vppCritere[8], vppCritere[9]};
                break;
             }
		}
	}
}
