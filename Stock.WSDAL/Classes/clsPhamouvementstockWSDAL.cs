using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementStockWSDAL: ITableDAL<clsPhamouvementStock>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(MS_NUMPIECE) AS MS_NUMPIECE  FROM dbo.PhamouvementStock " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(MS_NUMPIECE) AS MS_NUMPIECE  FROM dbo.PhamouvementStock " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = " SELECT MAX(MS_NUMPIECE) AS MS_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCK " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        public string pvgNumsequenceMaxValue(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_DATEPIECE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
            this.vapRequete = " SELECT MAX(MS_NUMSEQUENCE) AS MS_NUMSEQUENCE FROM PhamouvementStock WHERE AG_CODEAGENCE = @AG_CODEAGENCE AND CONVERT(DATETIME , MS_DATEPIECE,103)= @MS_DATEPIECE  ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">critere : MK_NUMPIECE</param>
        /// <returns></returns>
        public string pvgValueScalarRequeteCountCommande(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MK_NUMPIECE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
            this.vapRequete = " SELECT COUNT(MS_NUMPIECE) FROM PhamouvementStock WHERE AG_CODEAGENCE = @AG_CODEAGENCE AND CAST(MK_NUMPIECE AS VARCHAR(50)) = @MK_NUMPIECE  ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">critere : MS_NUMPIECE</param>
        /// <returns></returns>
        public string pvgValeurScalaireRequeteCountLivraison(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
            this.vapRequete = " SELECT COUNT(MS_NUMPIECE) FROM PhamouvementStock WHERE AG_CODEAGENCE = @AG_CODEAGENCE AND MS_NUMPIECE= @MS_NUMPIECE AND MS_DATELIVRAISON <> '01/01/1900' ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStock comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStock pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MS_NUMPIECE,MK_NUMPIECE,MS_NUMFACTURE,ISNULL(MS_DATEFACTURE,'01/01/1900') AS MS_DATEFACTURE,EN_CODEENTREPOT,CH_IDCHAUFFEUR,MS_DATEPIECE,MS_NUMSEQUENCE,TI_IDTIERS,CO_IDCOMMERCIAL,MS_REFPIECE, " +
                            " MS_LIBOPERA,MS_TAUXREMISE,MS_MONTANTTOTALREMISE,MS_MONTANTTRANSPORT,MS_DELAILIVRAISON,MS_DATELIVRAISON,MS_ANNULATIONPIECE,OP_CODEOPERATEUR,MS_DATESAISIE,MS_MONTANTECHEANCE,MS_DUREEPRET, " +
                            " MS_DATEDEBUTREGLEMENT,MS_DUREEVALIDITE,MS_CONDITIONREGLEMENT, ISNULL(MS_TAUXTVA,0) AS MS_TAUXTVA , ISNULL(MS_TAUXASDI,0) AS MS_TAUXASDI  , MS_SITUATIONFACTURE, MS_MONTANTVERSE FROM PHAMOUVEMENTSTOCK " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementStock clsPhamouvementStock = new clsPhamouvementStock();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStock.MS_NUMFACTURE = clsDonnee.vogDataReader["MS_NUMFACTURE"].ToString();
					clsPhamouvementStock.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
					clsPhamouvementStock.MS_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["MS_NUMSEQUENCE"].ToString());
                    //clsPhamouvementStock.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					
					clsPhamouvementStock.MS_DATEFACTURE = DateTime.Parse(clsDonnee.vogDataReader["MS_DATEFACTURE"].ToString());
					clsPhamouvementStock.MS_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MS_DATEPIECE"].ToString());
                    clsPhamouvementStock.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhamouvementStock.CO_IDCOMMERCIAL = clsDonnee.vogDataReader["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementStock.MS_REFPIECE = clsDonnee.vogDataReader["MS_REFPIECE"].ToString();
                    //clsPhamouvementStock.MS_LIBOPERA = clsDonnee.vogDataReader["MS_LIBOPERA"].ToString();
                    //clsPhamouvementStock.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementStock.MS_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MS_TAUXREMISE"].ToString());
					clsPhamouvementStock.MS_MONTANTTOTALREMISE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTTOTALREMISE"].ToString());
					clsPhamouvementStock.MS_MONTANTTRANSPORT = double.Parse(clsDonnee.vogDataReader["MS_MONTANTTRANSPORT"].ToString());
                    clsPhamouvementStock.MS_MONTANTVERSE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTVERSE"].ToString());
					clsPhamouvementStock.MS_DELAILIVRAISON = int.Parse(clsDonnee.vogDataReader["MS_DELAILIVRAISON"].ToString());
					clsPhamouvementStock.MS_DATELIVRAISON = DateTime.Parse(clsDonnee.vogDataReader["MS_DATELIVRAISON"].ToString());
					clsPhamouvementStock.MS_ANNULATIONPIECE = clsDonnee.vogDataReader["MS_ANNULATIONPIECE"].ToString();
					clsPhamouvementStock.MS_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["MS_DATESAISIE"].ToString());
					clsPhamouvementStock.MS_MONTANTECHEANCE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTECHEANCE"].ToString());
					clsPhamouvementStock.MS_DUREEPRET = int.Parse(clsDonnee.vogDataReader["MS_DUREEPRET"].ToString());
					clsPhamouvementStock.MS_DATEDEBUTREGLEMENT = DateTime.Parse(clsDonnee.vogDataReader["MS_DATEDEBUTREGLEMENT"].ToString());
					clsPhamouvementStock.MS_DUREEVALIDITE = clsDonnee.vogDataReader["MS_DUREEVALIDITE"].ToString();
                    //clsPhamouvementStock.MS_CONDITIONREGLEMENT = clsDonnee.vogDataReader["MS_CONDITIONREGLEMENT"].ToString();
					clsPhamouvementStock.MS_SITUATIONFACTURE = clsDonnee.vogDataReader["MS_SITUATIONFACTURE"].ToString();
					clsPhamouvementStock.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementStock.MS_TAUXTVA = float.Parse(clsDonnee.vogDataReader["MS_TAUXTVA"].ToString());
					clsPhamouvementStock.MS_TAUXASDI = float.Parse(clsDonnee.vogDataReader["MS_TAUXASDI"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementStock;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStock>clsPhamouvementStock</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStock.AG_CODEAGENCE;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementStock.MS_NUMPIECE;

            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStock.MK_NUMPIECE;
            if (clsPhamouvementStock.MK_NUMPIECE == "")
                vppParamMK_NUMPIECE.Value = DBNull.Value;

          


            SqlParameter vppParamMS_DATEPIECE = new SqlParameter("@MS_DATEPIECE", SqlDbType.DateTime);
            vppParamMS_DATEPIECE.Value = clsPhamouvementStock.MS_DATEPIECE;
            if (clsPhamouvementStock.MS_DATEPIECE.Year < 1900) vppParamMS_DATEPIECE.Value = "01/01/1900"; 

            SqlParameter vppParamMS_NUMSEQUENCE = new SqlParameter("@MS_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMS_NUMSEQUENCE.Value = clsPhamouvementStock.MS_NUMSEQUENCE;


            SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.BigInt);
            vppParamCL_IDCLIENT.Value = clsPhamouvementStock.CL_IDCLIENT;
            if (clsPhamouvementStock.CL_IDCLIENT == "")
                vppParamCL_IDCLIENT.Value = DBNull.Value;


            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.BigInt);
            vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementStock.CO_IDCOMMERCIAL;
            if (clsPhamouvementStock.CO_IDCOMMERCIAL == "")
                vppParamCO_IDCOMMERCIAL.Value = DBNull.Value;

            SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 4);
            vppParamFR_CODEFOURNISSEUR.Value = clsPhamouvementStock.FR_CODEFOURNISSEUR;
            if (clsPhamouvementStock.FR_CODEFOURNISSEUR == "")
                vppParamFR_CODEFOURNISSEUR.Value = DBNull.Value;



            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementStock.NO_CODENATUREOPERATION;
            if (clsPhamouvementStock.NO_CODENATUREOPERATION == "")
                vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStock.OP_CODEOPERATEUR;

            SqlParameter vppParamMS_REFPIECE = new SqlParameter("@MS_REFPIECE", SqlDbType.VarChar, 150);
            vppParamMS_REFPIECE.Value = clsPhamouvementStock.MS_REFPIECE;

            SqlParameter vppParamMS_LIBOPERA = new SqlParameter("@MS_LIBOPERA", SqlDbType.VarChar, 150);
            vppParamMS_LIBOPERA.Value = clsPhamouvementStock.MS_LIBOPERA;

            SqlParameter vppParamMS_TAUXREMISE = new SqlParameter("@MS_TAUXREMISE", SqlDbType.Float);
            vppParamMS_TAUXREMISE.Value = clsPhamouvementStock.MS_TAUXREMISE;

            SqlParameter vppParamMS_MONTANTTOTALREMISE = new SqlParameter("@MS_MONTANTTOTALREMISE", SqlDbType.Money);
            vppParamMS_MONTANTTOTALREMISE.Value = clsPhamouvementStock.MS_MONTANTTOTALREMISE;

            SqlParameter vppParamMS_MONTANTTRANSPORT = new SqlParameter("@MS_MONTANTTRANSPORT", SqlDbType.Money);
            vppParamMS_MONTANTTRANSPORT.Value = clsPhamouvementStock.MS_MONTANTTRANSPORT;

            SqlParameter vppParamMS_NUMFACTURE = new SqlParameter("@MS_NUMFACTURE", SqlDbType.VarChar, 50);
            vppParamMS_NUMFACTURE.Value = clsPhamouvementStock.MS_NUMFACTURE;

            SqlParameter vppParamMS_DATEFACTURE = new SqlParameter("@MS_DATEFACTURE", SqlDbType.DateTime);
            vppParamMS_DATEFACTURE.Value = clsPhamouvementStock.MS_DATEFACTURE;
            if (clsPhamouvementStock.MS_DATEFACTURE.Year < 1900) vppParamMS_DATEFACTURE.Value = "01/01/1900"; 

            SqlParameter vppParamMS_DELAILIVRAISON = new SqlParameter("@MS_DELAILIVRAISON", SqlDbType.TinyInt);
            vppParamMS_DELAILIVRAISON.Value = clsPhamouvementStock.MS_DELAILIVRAISON;

            SqlParameter vppParamMS_DATELIVRAISON = new SqlParameter("@MS_DATELIVRAISON", SqlDbType.DateTime);
            vppParamMS_DATELIVRAISON.Value = clsPhamouvementStock.MS_DATELIVRAISON;
            if (clsPhamouvementStock.MS_DATELIVRAISON.Year < 1900) vppParamMS_DATELIVRAISON.Value = "01/01/1900"; 

            SqlParameter vppParamMS_ANNULATIONPIECE = new SqlParameter("@MS_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMS_ANNULATIONPIECE.Value = clsPhamouvementStock.MS_ANNULATIONPIECE;

            SqlParameter vppParamMS_DATESAISIE = new SqlParameter("@MS_DATESAISIE", SqlDbType.DateTime);
            vppParamMS_DATESAISIE.Value = clsPhamouvementStock.MS_DATESAISIE;
            if (clsPhamouvementStock.MS_DATESAISIE.Year < 1900) vppParamMS_DATESAISIE.Value = "01/01/1900"; 


            SqlParameter vppParamMS_MONTANTECHEANCE = new SqlParameter("@MS_MONTANTECHEANCE", SqlDbType.Money);
            vppParamMS_MONTANTECHEANCE.Value = clsPhamouvementStock.MS_MONTANTECHEANCE;

            SqlParameter vppParamMS_MONTANTVERSE = new SqlParameter("@MS_MONTANTVERSE", SqlDbType.Money);
            vppParamMS_MONTANTVERSE.Value = clsPhamouvementStock.MS_MONTANTVERSE;

            SqlParameter vppParamMS_DUREEPRET = new SqlParameter("@MS_DUREEPRET", SqlDbType.SmallInt);
            vppParamMS_DUREEPRET.Value = clsPhamouvementStock.MS_DUREEPRET;

            SqlParameter vppParamMS_DATEDEBUTREGLEMENT = new SqlParameter("@MS_DATEDEBUTREGLEMENT", SqlDbType.DateTime);
            vppParamMS_DATEDEBUTREGLEMENT.Value = clsPhamouvementStock.MS_DATEDEBUTREGLEMENT;
            if (clsPhamouvementStock.MS_DATEDEBUTREGLEMENT.Year < 1900) vppParamMS_DATEDEBUTREGLEMENT.Value = "01/01/1900"; 

            SqlParameter vppParamMS_DUREEVALIDITE = new SqlParameter("@MS_DUREEVALIDITE", SqlDbType.VarChar, 150);
            vppParamMS_DUREEVALIDITE.Value = clsPhamouvementStock.MS_DUREEVALIDITE;

            SqlParameter vppParamMS_CONDITIONREGLEMENT = new SqlParameter("@MS_CONDITIONREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMS_CONDITIONREGLEMENT.Value = clsPhamouvementStock.MS_CONDITIONREGLEMENT;

            SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 150);
            vppParamCA_CODECONTRAT.Value = clsPhamouvementStock.CA_CODECONTRAT;

            SqlParameter vppParamMS_SITUATIONFACTURE = new SqlParameter("@MS_SITUATIONFACTURE", SqlDbType.VarChar, 1);
            vppParamMS_SITUATIONFACTURE.Value = clsPhamouvementStock.MS_SITUATIONFACTURE;

            SqlParameter vppParamMS_TAUXASDI = new SqlParameter("@MS_TAUXASDI", SqlDbType.Float);
            vppParamMS_TAUXASDI.Value = clsPhamouvementStock.MS_TAUXASDI;

            SqlParameter vppParamMS_TAUXTVA = new SqlParameter("@MS_TAUXTVA", SqlDbType.Float);
            vppParamMS_TAUXTVA.Value = clsPhamouvementStock.MS_TAUXTVA;
            SqlParameter vppParamMS_DATERENDEZVOUS = new SqlParameter("@MS_DATERENDEZVOUS", SqlDbType.DateTime);
            vppParamMS_DATERENDEZVOUS.Value = clsPhamouvementStock.MS_DATERENDEZVOUS;
            if (clsPhamouvementStock.MS_DATERENDEZVOUS.Year < 1900) vppParamMS_DATERENDEZVOUS.Value = "01/01/1900"; 

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementStock.TYPEOPERATION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 150);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = " EXECUTE dbo.PS_PHAMOUVEMENTSTOCK @AG_CODEAGENCE,@MS_NUMPIECE,@MS_NUMFACTURE,@MK_NUMPIECE,@MS_NUMSEQUENCE,@MS_DATEFACTURE,@MS_DATEPIECE,@FR_CODEFOURNISSEUR,@CL_IDCLIENT,@CO_IDCOMMERCIAL,@MS_REFPIECE,@MS_LIBOPERA,@NO_CODENATUREOPERATION,@MS_TAUXREMISE,@MS_MONTANTTOTALREMISE,@MS_MONTANTTRANSPORT,@MS_MONTANTVERSE,@MS_DELAILIVRAISON,@MS_DATELIVRAISON,@MS_ANNULATIONPIECE,@MS_DATESAISIE,@MS_MONTANTECHEANCE,@MS_DUREEPRET,@MS_DATEDEBUTREGLEMENT,@MS_DUREEVALIDITE,@MS_CONDITIONREGLEMENT,@CA_CODECONTRAT,@MS_SITUATIONFACTURE,@OP_CODEOPERATEUR,@MS_TAUXTVA,@MS_TAUXASDI,@MS_DATERENDEZVOUS,@CODECRYPTAGE,@TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
           

            vppSqlCmd.Parameters.Add(vppParamMS_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamFR_CODEFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamCL_IDCLIENT);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamMS_REFPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_LIBOPERA);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTTRANSPORT);
            vppSqlCmd.Parameters.Add(vppParamMS_DELAILIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMS_DATELIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMS_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamMS_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamMS_DUREEPRET);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTECHEANCE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTTOTALREMISE);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEDEBUTREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_DUREEVALIDITE);
            vppSqlCmd.Parameters.Add(vppParamMS_CONDITIONREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
            vppSqlCmd.Parameters.Add(vppParamMS_SITUATIONFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXTVA);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXASDI);
            vppSqlCmd.Parameters.Add(vppParamMS_DATERENDEZVOUS);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTVERSE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null , null);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStock>clsPhamouvementStock</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStock.MK_NUMPIECE;
            if (clsPhamouvementStock.MK_NUMPIECE == "")
                vppParamMK_NUMPIECE.Value = DBNull.Value;

            //SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            //vppParamEN_CODEENTREPOT.Value = clsPhamouvementStock.EN_CODEENTREPOT;
            //if (clsPhamouvementStock.EN_CODEENTREPOT == "")
            //    vppParamEN_CODEENTREPOT.Value = DBNull.Value;



            SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.BigInt);
            vppParamCL_IDCLIENT.Value = clsPhamouvementStock.CL_IDCLIENT;
            if (clsPhamouvementStock.CL_IDCLIENT == "")
                vppParamCL_IDCLIENT.Value = DBNull.Value;


            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.BigInt);
            vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementStock.CO_IDCOMMERCIAL;
            if (clsPhamouvementStock.CO_IDCOMMERCIAL == "")
                vppParamCO_IDCOMMERCIAL.Value = DBNull.Value;

            SqlParameter vppParamMS_DATEPIECE = new SqlParameter("@MS_DATEPIECE", SqlDbType.DateTime);
            vppParamMS_DATEPIECE.Value = clsPhamouvementStock.MS_DATEPIECE;
            if (clsPhamouvementStock.MS_DATEPIECE.Year < 1900) vppParamMS_DATEPIECE.Value = "01/01/1900"; 

            SqlParameter vppParamMS_NUMSEQUENCE = new SqlParameter("@MS_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMS_NUMSEQUENCE.Value = clsPhamouvementStock.MS_NUMSEQUENCE;

            SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 4);
            vppParamFR_CODEFOURNISSEUR.Value = clsPhamouvementStock.FR_CODEFOURNISSEUR;
            if (clsPhamouvementStock.FR_CODEFOURNISSEUR == "")
                vppParamFR_CODEFOURNISSEUR.Value = DBNull.Value;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementStock.NO_CODENATUREOPERATION;
            if (clsPhamouvementStock.NO_CODENATUREOPERATION == "")
                vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStock.OP_CODEOPERATEUR;

            SqlParameter vppParamMS_REFPIECE = new SqlParameter("@MS_REFPIECE", SqlDbType.VarChar, 150);
            vppParamMS_REFPIECE.Value = clsPhamouvementStock.MS_REFPIECE;

            SqlParameter vppParamMS_LIBOPERA = new SqlParameter("@MS_LIBOPERA", SqlDbType.VarChar, 150);
            vppParamMS_LIBOPERA.Value = clsPhamouvementStock.MS_LIBOPERA;


            SqlParameter vppParamMS_TAUXREMISE = new SqlParameter("@MS_TAUXREMISE", SqlDbType.Float);
            vppParamMS_TAUXREMISE.Value = clsPhamouvementStock.MS_TAUXREMISE;

            SqlParameter vppParamMS_MONTANTTOTALREMISE = new SqlParameter("@MS_MONTANTTOTALREMISE", SqlDbType.Money);
            vppParamMS_MONTANTTOTALREMISE.Value = clsPhamouvementStock.MS_MONTANTTOTALREMISE;

            SqlParameter vppParamMS_MONTANTTRANSPORT = new SqlParameter("@MS_MONTANTTRANSPORT", SqlDbType.Money);
            vppParamMS_MONTANTTRANSPORT.Value = clsPhamouvementStock.MS_MONTANTTRANSPORT;

            SqlParameter vppParamMS_DELAILIVRAISON = new SqlParameter("@MS_DELAILIVRAISON", SqlDbType.TinyInt);
            vppParamMS_DELAILIVRAISON.Value = clsPhamouvementStock.MS_DELAILIVRAISON;

            SqlParameter vppParamMS_DATELIVRAISON = new SqlParameter("@MS_DATELIVRAISON", SqlDbType.DateTime);
            vppParamMS_DATELIVRAISON.Value = clsPhamouvementStock.MS_DATELIVRAISON;
            if (clsPhamouvementStock.MS_DATELIVRAISON.Year < 1900) vppParamMS_DATELIVRAISON.Value = "01/01/1900"; 

            SqlParameter vppParamMS_ANNULATIONPIECE = new SqlParameter("@MS_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMS_ANNULATIONPIECE.Value = clsPhamouvementStock.MS_ANNULATIONPIECE;


            SqlParameter vppParamMS_DATESAISIE = new SqlParameter("@MS_DATESAISIE", SqlDbType.DateTime);
            vppParamMS_DATESAISIE.Value = clsPhamouvementStock.MS_DATESAISIE;
            if (clsPhamouvementStock.MS_DATESAISIE.Year < 1900) vppParamMS_DATESAISIE.Value = "01/01/1900"; 

            SqlParameter vppParamMS_MONTANTECHEANCE = new SqlParameter("@MS_MONTANTECHEANCE", SqlDbType.Money);
            vppParamMS_MONTANTECHEANCE.Value = clsPhamouvementStock.MS_MONTANTECHEANCE;

            SqlParameter vppParamMS_DUREEPRET = new SqlParameter("@MS_DUREEPRET", SqlDbType.SmallInt);
            vppParamMS_DUREEPRET.Value = clsPhamouvementStock.MS_DUREEPRET;

            SqlParameter vppParamMS_DATEDEBUTREGLEMENT = new SqlParameter("@MS_DATEDEBUTREGLEMENT", SqlDbType.DateTime);
            vppParamMS_DATEDEBUTREGLEMENT.Value = clsPhamouvementStock.MS_DATEDEBUTREGLEMENT;

            SqlParameter vppParamMS_DUREEVALIDITE = new SqlParameter("@MS_DUREEVALIDITE", SqlDbType.VarChar, 150);
            vppParamMS_DUREEVALIDITE.Value = clsPhamouvementStock.MS_DUREEVALIDITE;

            SqlParameter vppParamMS_CONDITIONREGLEMENT = new SqlParameter("@MS_CONDITIONREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMS_CONDITIONREGLEMENT.Value = clsPhamouvementStock.MS_CONDITIONREGLEMENT;

            SqlParameter vppParamMS_SITUATIONFACTURE = new SqlParameter("@MS_SITUATIONFACTURE", SqlDbType.VarChar, 1);
            vppParamMS_SITUATIONFACTURE.Value = clsPhamouvementStock.MS_SITUATIONFACTURE;

            SqlParameter vppParamMS_TAUXASDI = new SqlParameter("@MS_TAUXASDI", SqlDbType.Float);
            vppParamMS_TAUXASDI.Value = clsPhamouvementStock.MS_TAUXASDI;

            SqlParameter vppParamMS_TAUXTVA = new SqlParameter("@MS_TAUXTVA", SqlDbType.Float);
            vppParamMS_TAUXTVA.Value = clsPhamouvementStock.MS_TAUXTVA;
            SqlParameter vppParamMS_DATERENDEZVOUS = new SqlParameter("@MS_DATERENDEZVOUS", SqlDbType.DateTime);
            vppParamMS_DATERENDEZVOUS.Value = clsPhamouvementStock.MS_DATERENDEZVOUS;
            if (clsPhamouvementStock.MS_DATERENDEZVOUS.Year < 1900) vppParamMS_DATERENDEZVOUS.Value = "01/01/1900"; 
			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PhamouvementStock SET " +
            " MK_NUMPIECE=@MK_NUMPIECE," +
            " CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR," +
            " MS_DATEPIECE=@MS_DATEPIECE," +
            " MS_NUMSEQUENCE=@MS_NUMSEQUENCE," +
            " FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR," +
            " CL_IDCLIENT=@CL_IDCLIENT," +
            " CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL," +
            " MS_REFPIECE=@MS_REFPIECE," +
            " MS_LIBOPERA=@MS_LIBOPERA," +
            " NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION," +
            " MS_TAUXREMISE=@MS_TAUXREMISE," +
            " MS_MONTANTTOTALREMISE=@MS_MONTANTTOTALREMISE," +
            " MS_MONTANTTRANSPORT=@MS_MONTANTTRANSPORT," +
            " MS_DELAILIVRAISON=@MS_DELAILIVRAISON," +
            " MS_DATELIVRAISON=@MS_DATELIVRAISON," +
            " MS_ANNULATIONPIECE=@MS_ANNULATIONPIECE," +
            " OP_CODEOPERATEUR=@OP_CODEOPERATEUR," +
            " MS_DATESAISIE=@MS_DATESAISIE," +
            " MS_MONTANTECHEANCE=@MS_MONTANTECHEANCE," +
            " MS_DUREEPRET=@MS_DUREEPRET," +
            " MS_DATEDEBUTREGLEMENT=@MS_DATEDEBUTREGLEMENT," +
            " MS_DUREEVALIDITE=@MS_DUREEVALIDITE," +
            " MS_CONDITIONREGLEMENT=@MS_CONDITIONREGLEMENT," +
            " MS_TAUXASDI=@MS_TAUXASDI," +
            " MS_TAUXTVA=@MS_TAUXTVA," +
            " MS_SITUATIONFACTURE=@MS_SITUATIONFACTURE," +
            " MS_DATERENDEZVOUS=@MS_DATERENDEZVOUS" + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamFR_CODEFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamCL_IDCLIENT);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamMS_REFPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_LIBOPERA);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTTOTALREMISE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTTRANSPORT);
            vppSqlCmd.Parameters.Add(vppParamMS_DELAILIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMS_DATELIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMS_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamMS_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTECHEANCE);
            vppSqlCmd.Parameters.Add(vppParamMS_DUREEPRET);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEDEBUTREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_DUREEVALIDITE);
            vppSqlCmd.Parameters.Add(vppParamMS_CONDITIONREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_SITUATIONFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXTVA);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXASDI);
            vppSqlCmd.Parameters.Add(vppParamMS_DATERENDEZVOUS);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}




        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<author>Home Technology</author>
        public void pvgLiaisonFactureConsultation(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStock.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementStock.EN_CODEENTREPOT;


            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementStock.MS_NUMPIECE;

            SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
            vppParamCO_CODECONSULTATION.Value = clsPhamouvementStock.CO_CODECONSULTATION;

            SqlParameter vppParamMS_DATEJOURNEE = new SqlParameter("@MS_DATEJOURNEE", SqlDbType.DateTime);
            vppParamMS_DATEJOURNEE.Value = clsPhamouvementStock.MS_DATESAISIE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStock.OP_CODEOPERATEUR;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 50);
            vppParamTYPEOPERATION.Value = clsPhamouvementStock.TYPEOPERATION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_CLICONSULTATIONRATTACHEMENTFACTURE  @AG_CODEAGENCE,@EN_CODEENTREPOT, @MS_NUMPIECE,  @CO_CODECONSULTATION,@MS_DATEJOURNEE,@OP_CODEOPERATEUR,@TYPEOPERATION,@CODECRYPTAGE";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEJOURNEE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }



        public void pvgFacturer(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamMS_NUMFACTURE = new SqlParameter("@MS_NUMFACTURE", SqlDbType.VarChar, 50);
            vppParamMS_NUMFACTURE.Value = clsPhamouvementStock.MS_NUMFACTURE;

            SqlParameter vppParamMS_SITUATIONFACTURE = new SqlParameter("@MS_NUMFACTURE", SqlDbType.VarChar, 1);
            vppParamMS_SITUATIONFACTURE.Value = clsPhamouvementStock.MS_SITUATIONFACTURE;

            SqlParameter vppParamMS_DATEFACTURE = new SqlParameter("@MS_DATEFACTURE", SqlDbType.DateTime);
            vppParamMS_DATEFACTURE.Value = clsPhamouvementStock.MS_DATEFACTURE;

            SqlParameter vppParamMS_MONTANTECHEANCE = new SqlParameter("@MS_MONTANTECHEANCE", SqlDbType.Money);
            vppParamMS_MONTANTECHEANCE.Value = clsPhamouvementStock.MS_MONTANTECHEANCE;

            SqlParameter vppParamMS_MONTANTTOTALREMISE = new SqlParameter("@MS_MONTANTTOTALREMISE", SqlDbType.Money);
            vppParamMS_MONTANTTOTALREMISE.Value = clsPhamouvementStock.MS_MONTANTTOTALREMISE;

            SqlParameter vppParamMS_DUREEPRET = new SqlParameter("@MS_DUREEPRET", SqlDbType.SmallInt);
            vppParamMS_DUREEPRET.Value = clsPhamouvementStock.MS_DUREEPRET;

            SqlParameter vppParamMS_DATEDEBUTREGLEMENT = new SqlParameter("@MS_DATEDEBUTREGLEMENT", SqlDbType.DateTime);
            vppParamMS_DATEDEBUTREGLEMENT.Value = clsPhamouvementStock.MS_DATEDEBUTREGLEMENT;

            SqlParameter vppParamMS_DUREEVALIDITE = new SqlParameter("@MS_DUREEVALIDITE", SqlDbType.VarChar, 150);
            vppParamMS_DUREEVALIDITE.Value = clsPhamouvementStock.MS_DUREEVALIDITE;

            SqlParameter vppParamMS_CONDITIONREGLEMENT = new SqlParameter("@MS_CONDITIONREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMS_CONDITIONREGLEMENT.Value = clsPhamouvementStock.MS_CONDITIONREGLEMENT;


            //Préparation de la commande
            pvpChoixCritere(vppCritere);
            this.vapRequete = " UPDATE PhamouvementStock SET " +
            " MS_DATEFACTURE=@MS_DATEFACTURE," +
            " MS_NUMFACTURE=@MS_NUMFACTURE," +
            " MS_SITUATIONFACTURE=@MS_SITUATIONFACTURE" + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande

            vppSqlCmd.Parameters.Add(vppParamMS_DATEFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_SITUATIONFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_DUREEPRET);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTECHEANCE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTTOTALREMISE);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEDEBUTREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_DUREEVALIDITE);
            vppSqlCmd.Parameters.Add(vppParamMS_CONDITIONREGLEMENT);
            //Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementStock>clsPhamouvementStock</param>
        ///<author>Home Technology</author>
        public string pvgMiseajour(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStock.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementStock.EN_CODEENTREPOT;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementStock.MS_NUMPIECE;

            SqlParameter vppParamMS_NUMPIECE1 = new SqlParameter("@MS_NUMPIECE1", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE1.Value = clsPhamouvementStock.MS_NUMPIECE1;
            if (clsPhamouvementStock.MS_NUMPIECE1 == "")
                vppParamMS_NUMPIECE1.Value = DBNull.Value;

            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStock.MK_NUMPIECE;
            if (clsPhamouvementStock.MK_NUMPIECE == "")
                vppParamMK_NUMPIECE.Value = DBNull.Value;

            //SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            //vppParamEN_CODEENTREPOT.Value = clsPhamouvementStock.EN_CODEENTREPOT;
            //if (clsPhamouvementStock.EN_CODEENTREPOT == "")
            //    vppParamEN_CODEENTREPOT.Value = DBNull.Value;

          


            SqlParameter vppParamMS_DATEPIECE = new SqlParameter("@MS_DATEPIECE", SqlDbType.DateTime);
            vppParamMS_DATEPIECE.Value = clsPhamouvementStock.MS_DATEPIECE;
            if (clsPhamouvementStock.MS_DATEPIECE.Year < 1900) vppParamMS_DATEPIECE.Value = "01/01/1900";

            SqlParameter vppParamMS_NUMSEQUENCE = new SqlParameter("@MS_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMS_NUMSEQUENCE.Value = clsPhamouvementStock.MS_NUMSEQUENCE;


            //SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.VarChar, 25);
            //vppParamCL_IDCLIENT.Value = clsPhamouvementStock.CL_IDCLIENT;
            //if (clsPhamouvementStock.CL_IDCLIENT == "")
            //    vppParamCL_IDCLIENT.Value = DBNull.Value;

            //SqlParameter vppParamCL_NUMCLIENT = new SqlParameter("@CL_NUMCLIENT", SqlDbType.VarChar, 8);
            //vppParamCL_NUMCLIENT.Value = clsPhamouvementStock.CL_NUMCLIENT;
            //if (clsPhamouvementStock.CL_NUMCLIENT == "")
            //    vppParamCL_NUMCLIENT.Value = DBNull.Value;

            SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 150);
            vppParamTI_NUMTIERS.Value = clsPhamouvementStock.TI_NUMTIERS;
            if (clsPhamouvementStock.TI_NUMTIERS == "")
                vppParamTI_NUMTIERS.Value = DBNull.Value;


            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar, 25);
            vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementStock.CO_IDCOMMERCIAL;
            if (clsPhamouvementStock.CO_IDCOMMERCIAL == "")
                vppParamCO_IDCOMMERCIAL.Value = DBNull.Value;

            //SqlParameter vppParamFR_CODEFOURNISSEUR = new SqlParameter("@FR_CODEFOURNISSEUR", SqlDbType.VarChar, 4);
            //vppParamFR_CODEFOURNISSEUR.Value = clsPhamouvementStock.FR_CODEFOURNISSEUR;
            //if (clsPhamouvementStock.FR_CODEFOURNISSEUR == "")
            //    vppParamFR_CODEFOURNISSEUR.Value = DBNull.Value;


            //SqlParameter vppParamFR_MATRICULE = new SqlParameter("@FR_MATRICULE", SqlDbType.VarChar, 8);
            //vppParamFR_MATRICULE.Value = clsPhamouvementStock.FR_MATRICULE;
            //if (clsPhamouvementStock.FR_MATRICULE == "")
            //    vppParamFR_MATRICULE.Value = DBNull.Value;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementStock.NO_CODENATUREOPERATION;
            if (clsPhamouvementStock.NO_CODENATUREOPERATION == "")
                vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementStock.OP_CODEOPERATEUR;

            SqlParameter vppParamMS_REFPIECE = new SqlParameter("@MS_REFPIECE", SqlDbType.VarChar, 150);
            vppParamMS_REFPIECE.Value = clsPhamouvementStock.MS_REFPIECE;

            SqlParameter vppParamMS_LIBOPERA = new SqlParameter("@MS_LIBOPERA", SqlDbType.VarChar, 150);
            vppParamMS_LIBOPERA.Value = clsPhamouvementStock.MS_LIBOPERA;

            SqlParameter vppParamMS_TAUXREMISE = new SqlParameter("@MS_TAUXREMISE", SqlDbType.Float);
            vppParamMS_TAUXREMISE.Value = clsPhamouvementStock.MS_TAUXREMISE;

            SqlParameter vppParamMS_MONTANTTOTALREMISE = new SqlParameter("@MS_MONTANTTOTALREMISE", SqlDbType.Money);
            vppParamMS_MONTANTTOTALREMISE.Value = clsPhamouvementStock.MS_MONTANTTOTALREMISE;

            SqlParameter vppParamMS_MONTANTTRANSPORT = new SqlParameter("@MS_MONTANTTRANSPORT", SqlDbType.Money);
            vppParamMS_MONTANTTRANSPORT.Value = clsPhamouvementStock.MS_MONTANTTRANSPORT;

            SqlParameter vppParamMS_NUMFACTURE = new SqlParameter("@MS_NUMFACTURE", SqlDbType.VarChar, 50);
            vppParamMS_NUMFACTURE.Value = clsPhamouvementStock.MS_NUMFACTURE;

            SqlParameter vppParamMS_DATEFACTURE = new SqlParameter("@MS_DATEFACTURE", SqlDbType.DateTime);
            vppParamMS_DATEFACTURE.Value = clsPhamouvementStock.MS_DATEFACTURE;
            if (clsPhamouvementStock.MS_DATEFACTURE.Year < 1900) vppParamMS_DATEFACTURE.Value = "01/01/1900";

            SqlParameter vppParamMS_DELAILIVRAISON = new SqlParameter("@MS_DELAILIVRAISON", SqlDbType.TinyInt);
            vppParamMS_DELAILIVRAISON.Value = clsPhamouvementStock.MS_DELAILIVRAISON;

            SqlParameter vppParamMS_DATELIVRAISON = new SqlParameter("@MS_DATELIVRAISON", SqlDbType.DateTime);
            vppParamMS_DATELIVRAISON.Value = clsPhamouvementStock.MS_DATELIVRAISON;
            if (clsPhamouvementStock.MS_DATELIVRAISON.Year < 1900) vppParamMS_DATELIVRAISON.Value = "01/01/1900";

            SqlParameter vppParamMS_ANNULATIONPIECE = new SqlParameter("@MS_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMS_ANNULATIONPIECE.Value = clsPhamouvementStock.MS_ANNULATIONPIECE;

            SqlParameter vppParamMS_DATESAISIE = new SqlParameter("@MS_DATESAISIE", SqlDbType.DateTime);
            vppParamMS_DATESAISIE.Value = clsPhamouvementStock.MS_DATESAISIE;
            if (clsPhamouvementStock.MS_DATESAISIE.Year < 1900) vppParamMS_DATESAISIE.Value = "01/01/1900";


            SqlParameter vppParamMS_MONTANTECHEANCE = new SqlParameter("@MS_MONTANTECHEANCE", SqlDbType.Money);
            vppParamMS_MONTANTECHEANCE.Value = clsPhamouvementStock.MS_MONTANTECHEANCE;

            SqlParameter vppParamMS_MONTANTVERSE = new SqlParameter("@MS_MONTANTVERSE", SqlDbType.Money);
            vppParamMS_MONTANTVERSE.Value = clsPhamouvementStock.MS_MONTANTVERSE;

            SqlParameter vppParamMS_DUREEPRET = new SqlParameter("@MS_DUREEPRET", SqlDbType.SmallInt);
            vppParamMS_DUREEPRET.Value = clsPhamouvementStock.MS_DUREEPRET;

            SqlParameter vppParamMS_DATEDEBUTREGLEMENT = new SqlParameter("@MS_DATEDEBUTREGLEMENT", SqlDbType.DateTime);
            vppParamMS_DATEDEBUTREGLEMENT.Value = clsPhamouvementStock.MS_DATEDEBUTREGLEMENT;
            if (clsPhamouvementStock.MS_DATEDEBUTREGLEMENT.Year < 1900) vppParamMS_DATEDEBUTREGLEMENT.Value = "01/01/1900";

            SqlParameter vppParamMS_DUREEVALIDITE = new SqlParameter("@MS_DUREEVALIDITE", SqlDbType.VarChar, 150);
            vppParamMS_DUREEVALIDITE.Value = clsPhamouvementStock.MS_DUREEVALIDITE;

            SqlParameter vppParamMS_CONDITIONREGLEMENT = new SqlParameter("@MS_CONDITIONREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMS_CONDITIONREGLEMENT.Value = clsPhamouvementStock.MS_CONDITIONREGLEMENT;

            SqlParameter vppParamMS_SITUATIONFACTURE = new SqlParameter("@MS_SITUATIONFACTURE", SqlDbType.VarChar, 1);
            vppParamMS_SITUATIONFACTURE.Value = clsPhamouvementStock.MS_SITUATIONFACTURE;

            SqlParameter vppParamMS_TAUXASDI = new SqlParameter("@MS_TAUXASDI", SqlDbType.Float);
            vppParamMS_TAUXASDI.Value = clsPhamouvementStock.MS_TAUXASDI;

            SqlParameter vppParamMS_TAUXTVA = new SqlParameter("@MS_TAUXTVA", SqlDbType.Float);
            vppParamMS_TAUXTVA.Value = clsPhamouvementStock.MS_TAUXTVA;


            SqlParameter vppParamMS_MONTANTREMISE1 = new SqlParameter("@MS_MONTANTREMISE1", SqlDbType.Money);
            vppParamMS_MONTANTREMISE1.Value = clsPhamouvementStock.MS_MONTANTREMISE1;


            SqlParameter vppParamMS_MONTANTREMISE2 = new SqlParameter("@MS_MONTANTREMISE2", SqlDbType.Money);
            vppParamMS_MONTANTREMISE2.Value = clsPhamouvementStock.MS_MONTANTREMISE2;



            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementStock.TYPEOPERATION;


            SqlParameter vppParamMS_DATERENDEZVOUS = new SqlParameter("@MS_DATERENDEZVOUS", SqlDbType.DateTime);
            vppParamMS_DATERENDEZVOUS.Value = clsPhamouvementStock.MS_DATERENDEZVOUS;
            if (clsPhamouvementStock.MS_DATERENDEZVOUS.Year < 1900) vppParamMS_DATERENDEZVOUS.Value = "01/01/1900";


            SqlParameter vppParamFB_IDFOURNISSEUR = new SqlParameter("@FB_IDFOURNISSEUR", SqlDbType.VarChar, 50);
            vppParamFB_IDFOURNISSEUR.Value = clsPhamouvementStock.FB_IDFOURNISSEUR;
            if (clsPhamouvementStock.FB_IDFOURNISSEUR == "")
                vppParamFB_IDFOURNISSEUR.Value = DBNull.Value;


            SqlParameter vppParamMS_MONTANTFOURNISSEURBON = new SqlParameter("@MS_MONTANTFOURNISSEURBON", SqlDbType.Money);
            vppParamMS_MONTANTFOURNISSEURBON.Value = clsPhamouvementStock.MS_MONTANTFOURNISSEURBON;

            SqlParameter vppParamMS_NUMBON = new SqlParameter("@MS_NUMBON", SqlDbType.VarChar, 150);
            vppParamMS_NUMBON.Value = clsPhamouvementStock.MS_NUMBON;
            if (clsPhamouvementStock.MS_NUMBON == "")
                vppParamMS_NUMBON.Value = DBNull.Value;


            SqlParameter vppParamMS_DATEDEBUTFABRICATION = new SqlParameter("@MS_DATEDEBUTFABRICATION", SqlDbType.DateTime);
            vppParamMS_DATEDEBUTFABRICATION.Value = clsPhamouvementStock.MS_DATEDEBUTFABRICATION;
            if (clsPhamouvementStock.MS_DATEDEBUTFABRICATION.Year < 1900) vppParamMS_DATEDEBUTFABRICATION.Value = "01/01/1900";


            SqlParameter vppParamMS_HEUREDEBUTFABRICATION = new SqlParameter("@MS_HEUREDEBUTFABRICATION", SqlDbType.DateTime);
            vppParamMS_HEUREDEBUTFABRICATION.Value = clsPhamouvementStock.MS_HEUREDEBUTFABRICATION;
            if (clsPhamouvementStock.MS_HEUREDEBUTFABRICATION.Year < 1900) vppParamMS_HEUREDEBUTFABRICATION.Value = "01/01/1900";

            SqlParameter vppParamMS_DATEFINFABRICATION = new SqlParameter("@MS_DATEFINFABRICATION", SqlDbType.DateTime);
            vppParamMS_DATEFINFABRICATION.Value = clsPhamouvementStock.MS_DATEFINFABRICATION;
            if (clsPhamouvementStock.MS_DATEFINFABRICATION.Year < 1900) vppParamMS_DATEFINFABRICATION.Value = "01/01/1900";

            SqlParameter vppParamMS_HEUREFINFABRICATION = new SqlParameter("@MS_HEUREFINFABRICATION", SqlDbType.DateTime);
            vppParamMS_HEUREFINFABRICATION.Value = clsPhamouvementStock.MS_HEUREFINFABRICATION;
            if (clsPhamouvementStock.MS_HEUREFINFABRICATION.Year < 1900) vppParamMS_HEUREFINFABRICATION.Value = "01/01/1900";



            SqlParameter vppParamMS_DATEDEPART = new SqlParameter("@MS_DATEDEPART", SqlDbType.DateTime);
            vppParamMS_DATEDEPART.Value = clsPhamouvementStock.MS_DATEDEPART;
            if (clsPhamouvementStock.MS_DATEDEPART.Year < 1900) vppParamMS_DATEDEPART.Value = "01/01/1900";

            SqlParameter vppParamMS_HEUREDEBUT = new SqlParameter("@MS_HEUREDEBUT", SqlDbType.DateTime);
            vppParamMS_HEUREDEBUT.Value = clsPhamouvementStock.MS_HEUREDEBUT;
            if (clsPhamouvementStock.MS_HEUREDEBUT.Year < 1900) vppParamMS_HEUREDEBUT.Value = "01/01/1900";

            SqlParameter vppParamMS_HEUREFIN = new SqlParameter("@MS_HEUREFIN", SqlDbType.DateTime);
            vppParamMS_HEUREFIN.Value = clsPhamouvementStock.MS_HEUREFIN;
            if (clsPhamouvementStock.MS_HEUREFIN.Year < 1900) vppParamMS_HEUREFIN.Value = "01/01/1900";

            SqlParameter vppParamEM_CODEEMBALLAGE = new SqlParameter("@EM_CODEEMBALLAGE", SqlDbType.VarChar, 3);
            vppParamEM_CODEEMBALLAGE.Value = clsPhamouvementStock.EM_CODEEMBALLAGE;
            if (clsPhamouvementStock.EM_CODEEMBALLAGE == "")
                vppParamEM_CODEEMBALLAGE.Value = DBNull.Value;

            SqlParameter vppParamMS_TAUXHUMIDITE = new SqlParameter("@MS_TAUXHUMIDITE", SqlDbType.Float);
            vppParamMS_TAUXHUMIDITE.Value = clsPhamouvementStock.MS_TAUXHUMIDITE;

            SqlParameter vppParamMS_REMARQUE = new SqlParameter("@MS_REMARQUE", SqlDbType.VarChar, 1000);
            vppParamMS_REMARQUE.Value = clsPhamouvementStock.MS_REMARQUE;
            if (clsPhamouvementStock.MS_REMARQUE == "")
                vppParamMS_REMARQUE.Value = DBNull.Value;

            SqlParameter vppParamTR_IDTRANSPORTEUR = new SqlParameter("@TR_IDTRANSPORTEUR", SqlDbType.VarChar, 25);
            vppParamTR_IDTRANSPORTEUR.Value = clsPhamouvementStock.TR_IDTRANSPORTEUR;
            if (clsPhamouvementStock.TR_IDTRANSPORTEUR == "")
                vppParamTR_IDTRANSPORTEUR.Value = DBNull.Value;

            SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.VarChar, 25);
            vppParamCH_IDCHAUFFEUR.Value = clsPhamouvementStock.CH_IDCHAUFFEUR;
            if (clsPhamouvementStock.CH_IDCHAUFFEUR == "")
                vppParamCH_IDCHAUFFEUR.Value = DBNull.Value;

            //SqlParameter vppParamSC_CODESECTION = new SqlParameter("@SC_CODESECTION", SqlDbType.VarChar, 4);
            //vppParamSC_CODESECTION.Value = clsPhamouvementStock.SC_CODESECTION;
            //if (clsPhamouvementStock.SC_CODESECTION == "")
            //    vppParamSC_CODESECTION.Value = DBNull.Value;

            SqlParameter vppParamVH_CODEVEHICULE = new SqlParameter("@VH_CODEVEHICULE", SqlDbType.VarChar, 150);
            vppParamVH_CODEVEHICULE.Value = clsPhamouvementStock.VH_CODEVEHICULE;
            if (clsPhamouvementStock.VH_CODEVEHICULE == "")
                vppParamVH_CODEVEHICULE.Value = DBNull.Value;

            SqlParameter vppParamRM_CODEREMORQUE = new SqlParameter("@RM_CODEREMORQUE", SqlDbType.VarChar, 150);
            vppParamRM_CODEREMORQUE.Value = clsPhamouvementStock.RM_CODEREMORQUE;
            if (clsPhamouvementStock.RM_CODEREMORQUE == "")
                vppParamRM_CODEREMORQUE.Value = DBNull.Value;


            SqlParameter vppParamCA_CODECAMPAGNE = new SqlParameter("@CA_CODECAMPAGNE", SqlDbType.VarChar, 25);
            vppParamCA_CODECAMPAGNE.Value = clsPhamouvementStock.CA_CODECAMPAGNE;
            if (clsPhamouvementStock.CA_CODECAMPAGNE == "")
                vppParamCA_CODECAMPAGNE.Value = DBNull.Value;


            SqlParameter vppParamMS_MONTANTTIMBRE = new SqlParameter("@MS_MONTANTTIMBRE", SqlDbType.Money);
            vppParamMS_MONTANTTIMBRE.Value = clsPhamouvementStock.MS_MONTANTTIMBRE;



            SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 150);
            vppParamCO_CODECONSULTATION.Value = clsPhamouvementStock.CO_CODECONSULTATION;
            if (clsPhamouvementStock.CO_CODECONSULTATION == "")
                vppParamCO_CODECONSULTATION.Value = DBNull.Value;


            SqlParameter vppParamMS_VOSREFERENCES = new SqlParameter("@MS_VOSREFERENCES", SqlDbType.VarChar, 150);
            vppParamMS_VOSREFERENCES.Value = clsPhamouvementStock.MS_VOSREFERENCES;
            if (clsPhamouvementStock.MS_VOSREFERENCES == "")
                vppParamMS_VOSREFERENCES.Value = DBNull.Value;

        SqlParameter vppParamMS_NUMPIECECALCULAVOIR = new SqlParameter("@MS_NUMPIECECALCULAVOIR", SqlDbType.VarChar, 150);
            vppParamMS_NUMPIECECALCULAVOIR.Value = clsPhamouvementStock.MS_NUMPIECECALCULAVOIR;
        if (clsPhamouvementStock.MS_NUMPIECECALCULAVOIR == "")
                vppParamMS_NUMPIECECALCULAVOIR.Value = DBNull.Value;

        SqlParameter vppParamMS_CONDITIONDEREGLEMENT = new SqlParameter("@MS_CONDITIONDEREGLEMENT", SqlDbType.VarChar, 150);
            vppParamMS_CONDITIONDEREGLEMENT.Value = clsPhamouvementStock.MS_CONDITIONDEREGLEMENT;
        if (clsPhamouvementStock.MS_CONDITIONDEREGLEMENT == "")
                vppParamMS_CONDITIONDEREGLEMENT.Value = DBNull.Value;



            SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
            vppParamCA_CODECONTRAT.Value = clsPhamouvementStock.CA_CODECONTRAT;
            if (clsPhamouvementStock.CA_CODECONTRAT == "")
                vppParamCA_CODECONTRAT.Value = DBNull.Value;

            //SqlParameter vppParamMS_MONTANTASDI = new SqlParameter("@MS_MONTANTASDI", SqlDbType.Money);
            //vppParamMS_MONTANTASDI.Value = clsPhamouvementStock.MS_MONTANTASDI;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamMS_NUMPIECERETOUR = new SqlParameter("@MS_NUMPIECERETOUR", SqlDbType.VarChar, 50);
            





            SqlCommand vppSqlCmd = new SqlCommand("PS_PHAMOUVEMENTSTOCK", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE1);
            vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
            //vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMSEQUENCE);
            //vppSqlCmd.Parameters.Add(vppParamFR_MATRICULE);
            //vppSqlCmd.Parameters.Add(vppParamCL_NUMCLIENT);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamMS_REFPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_LIBOPERA);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTTRANSPORT);
            vppSqlCmd.Parameters.Add(vppParamMS_DELAILIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMS_DATELIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamMS_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamMS_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamMS_DUREEPRET);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTECHEANCE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTTOTALREMISE);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEDEBUTREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_DUREEVALIDITE);
            vppSqlCmd.Parameters.Add(vppParamMS_CONDITIONREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_SITUATIONFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXTVA);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTREMISE1);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTREMISE2);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXASDI);
           
            vppSqlCmd.Parameters.Add(vppParamMS_NUMFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTVERSE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMS_DATERENDEZVOUS);

            vppSqlCmd.Parameters.Add(vppParamFB_IDFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTFOURNISSEURBON);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMBON);

            vppSqlCmd.Parameters.Add(vppParamMS_DATEDEBUTFABRICATION);
            vppSqlCmd.Parameters.Add(vppParamMS_HEUREDEBUTFABRICATION);
            vppSqlCmd.Parameters.Add(vppParamMS_DATEFINFABRICATION);
            vppSqlCmd.Parameters.Add(vppParamMS_HEUREFINFABRICATION);



            vppSqlCmd.Parameters.Add(vppParamMS_DATEDEPART);
            vppSqlCmd.Parameters.Add(vppParamMS_HEUREDEBUT);
            vppSqlCmd.Parameters.Add(vppParamMS_HEUREFIN);
            vppSqlCmd.Parameters.Add(vppParamEM_CODEEMBALLAGE);
            vppSqlCmd.Parameters.Add(vppParamMS_TAUXHUMIDITE);
            vppSqlCmd.Parameters.Add(vppParamMS_REMARQUE);
            vppSqlCmd.Parameters.Add(vppParamTR_IDTRANSPORTEUR);
            vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
            //vppSqlCmd.Parameters.Add(vppParamSC_CODESECTION);
            vppSqlCmd.Parameters.Add(vppParamVH_CODEVEHICULE);
            vppSqlCmd.Parameters.Add(vppParamRM_CODEREMORQUE);
            vppSqlCmd.Parameters.Add(vppParamCA_CODECAMPAGNE);
            vppSqlCmd.Parameters.Add(vppParamMS_MONTANTTIMBRE);
            //vppSqlCmd.Parameters.Add(vppParamMS_MONTANTASDI);
            vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
            vppSqlCmd.Parameters.Add(vppParamMS_VOSREFERENCES);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECECALCULAVOIR);
            vppSqlCmd.Parameters.Add(vppParamMS_CONDITIONDEREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECERETOUR);
            vppParamMS_NUMPIECERETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
            
            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MS_NUMPIECERETOUR"].Value.ToString();

            //
        }

        public void pvgUpdateAnnulationVente(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MS_ANNULATIONPIECE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };

            //Préparation de la commande
            this.vapRequete = " UPDATE PhamouvementStock SET " +
            " MS_ANNULATIONPIECE=@MS_ANNULATIONPIECE WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }




        public void pvgAnnulationApprovisionnementVente(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MC_DATEJOURNEE", "@MC_DATEPIECE", "@TYPEOPERATION", "@OP_CODEOPERATEUR ", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3],vppCritere[4],vppCritere[5], clsDonnee.vogCleCryptage };

            //Préparation de la commande
            this.vapRequete = " EXECUTE dbo.PS_ANNULATIONAPPROVISIONNEMENTETVENTE @AG_CODEAGENCE,@MS_NUMPIECE,@MC_DATEJOURNEE,@MC_DATEPIECE,@TYPEOPERATION,@OP_CODEOPERATEUR,@CODECRYPTAGE ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }

        public void pvgClotureFactureApprovisionnementVente(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE", "@TYPEOPERATION", "@OP_CODEOPERATEUR ", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3],vppCritere[4], clsDonnee.vogCleCryptage };

            //Préparation de la commande
            this.vapRequete = " EXECUTE dbo.PS_CLOTUREFACTURE @AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE,@TYPEOPERATION,@OP_CODEOPERATEUR,@CODECRYPTAGE ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }


        public void pvgClotureExecice(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@DATEJOURNEE", "@MV_LIBELLEOPERATION", "@OP_CODEOPERATEUR ", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], clsDonnee.vogCleCryptage };

            //Préparation de la commande
            this.vapRequete = " EXECUTE dbo.PS_CLOTUREEXERCICE @AG_CODEAGENCE,@EN_CODEENTREPOT,@DATEJOURNEE,@MV_LIBELLEOPERATION,@OP_CODEOPERATEUR,@CODECRYPTAGE ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }


        /// <summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:MS_NUMPIECE)/// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="vppCritere"></param>
        public void pvgLivrer(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, params string[] vppCritere)
        {

           

            SqlParameter vppParamMS_DATELIVRAISON = new SqlParameter("@MS_DATELIVRAISON", SqlDbType.DateTime);
            vppParamMS_DATELIVRAISON.Value = clsPhamouvementStock.MS_DATELIVRAISON;

            //Préparation de la commande
            pvpChoixCritere(vppCritere);
            this.vapRequete = " UPDATE PhamouvementStock SET " +
            " MS_DATELIVRAISON=@MS_DATELIVRAISON" +this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMS_DATELIVRAISON);
            //Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PhamouvementStock "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStock </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStock> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, MS_NUMPIECE, MS_NUMFACTURE, MK_NUMPIECE, MS_NUMSEQUENCE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, MS_DATEFACTURE, MS_DATEPIECE, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, MS_REFPIECE, MS_LIBOPERA, NO_CODENATUREOPERATION, MS_TAUXREMISE, MS_MONTANTTOTALREMISE, MS_MONTANTTRANSPORT, MS_MONTANTVERSE, MS_DELAILIVRAISON, MS_DATELIVRAISON, MS_ANNULATIONPIECE, MS_DATESAISIE, MS_MONTANTECHEANCE, MS_DUREEPRET, MS_DATEDEBUTREGLEMENT, MS_DUREEVALIDITE, MS_CONDITIONREGLEMENT, MS_SITUATIONFACTURE, OP_CODEOPERATEUR, MS_TAUXTVA, MS_TAUXASDI FROM dbo.PhamouvementStock " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementStock> clsPhamouvementStocks = new List<clsPhamouvementStock>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStock clsPhamouvementStock = new clsPhamouvementStock();
					clsPhamouvementStock.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementStock.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementStock.MS_NUMFACTURE = clsDonnee.vogDataReader["MS_NUMFACTURE"].ToString();
					clsPhamouvementStock.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
					clsPhamouvementStock.MS_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["MS_NUMSEQUENCE"].ToString());
                    //clsPhamouvementStock.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsPhamouvementStock.FR_CODEFOURNISSEUR = clsDonnee.vogDataReader["FR_CODEFOURNISSEUR"].ToString();
					clsPhamouvementStock.CL_IDCLIENT = clsDonnee.vogDataReader["CL_IDCLIENT"].ToString();
					clsPhamouvementStock.CO_IDCOMMERCIAL = clsDonnee.vogDataReader["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementStock.MS_REFPIECE = clsDonnee.vogDataReader["MS_REFPIECE"].ToString();
					clsPhamouvementStock.MS_LIBOPERA = clsDonnee.vogDataReader["MS_LIBOPERA"].ToString();
					clsPhamouvementStock.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementStock.MS_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MS_TAUXREMISE"].ToString());
					clsPhamouvementStock.MS_MONTANTTOTALREMISE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTTOTALREMISE"].ToString());
					clsPhamouvementStock.MS_MONTANTTRANSPORT = double.Parse(clsDonnee.vogDataReader["MS_MONTANTTRANSPORT"].ToString());
					clsPhamouvementStock.MS_MONTANTVERSE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTVERSE"].ToString());
					clsPhamouvementStock.MS_DELAILIVRAISON = int.Parse(clsDonnee.vogDataReader["MS_DELAILIVRAISON"].ToString());
					clsPhamouvementStock.MS_DATELIVRAISON = DateTime.Parse(clsDonnee.vogDataReader["MS_DATELIVRAISON"].ToString());
					clsPhamouvementStock.MS_ANNULATIONPIECE = clsDonnee.vogDataReader["MS_ANNULATIONPIECE"].ToString();
					clsPhamouvementStock.MS_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["MS_DATESAISIE"].ToString());
					clsPhamouvementStock.MS_MONTANTECHEANCE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTECHEANCE"].ToString());
					clsPhamouvementStock.MS_DUREEPRET = int.Parse(clsDonnee.vogDataReader["MS_DUREEPRET"].ToString());
					clsPhamouvementStock.MS_DATEDEBUTREGLEMENT = DateTime.Parse(clsDonnee.vogDataReader["MS_DATEDEBUTREGLEMENT"].ToString());
					clsPhamouvementStock.MS_DUREEVALIDITE = clsDonnee.vogDataReader["MS_DUREEVALIDITE"].ToString();
					clsPhamouvementStock.MS_CONDITIONREGLEMENT = clsDonnee.vogDataReader["MS_CONDITIONREGLEMENT"].ToString();
					clsPhamouvementStock.MS_SITUATIONFACTURE = clsDonnee.vogDataReader["MS_SITUATIONFACTURE"].ToString();
					clsPhamouvementStock.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementStock.MS_TAUXTVA = float.Parse(clsDonnee.vogDataReader["MS_TAUXTVA"].ToString());
					clsPhamouvementStock.MS_TAUXASDI = float.Parse(clsDonnee.vogDataReader["MS_TAUXASDI"].ToString());
					clsPhamouvementStocks.Add(clsPhamouvementStock);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementStocks;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStock </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStock> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementStock> clsPhamouvementStocks = new List<clsPhamouvementStock>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, MS_NUMPIECE, MS_NUMFACTURE, MK_NUMPIECE, MS_NUMSEQUENCE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, MS_DATEFACTURE, MS_DATEPIECE, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, MS_REFPIECE, MS_LIBOPERA, NO_CODENATUREOPERATION, MS_TAUXREMISE, MS_MONTANTTOTALREMISE, MS_MONTANTTRANSPORT, MS_MONTANTVERSE, MS_DELAILIVRAISON, MS_DATELIVRAISON, MS_ANNULATIONPIECE, MS_DATESAISIE, MS_MONTANTECHEANCE, MS_DUREEPRET, MS_DATEDEBUTREGLEMENT, MS_DUREEVALIDITE, MS_CONDITIONREGLEMENT, MS_SITUATIONFACTURE, OP_CODEOPERATEUR, MS_TAUXTVA, MS_TAUXASDI FROM dbo.PhamouvementStock " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementStock clsPhamouvementStock = new clsPhamouvementStock();
					clsPhamouvementStock.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementStock.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhamouvementStock.MS_NUMFACTURE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMFACTURE"].ToString();
					clsPhamouvementStock.MK_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MK_NUMPIECE"].ToString();
					clsPhamouvementStock.MS_NUMSEQUENCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMSEQUENCE"].ToString());
                    //clsPhamouvementStock.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsPhamouvementStock.MS_DATEFACTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_DATEFACTURE"].ToString());
					clsPhamouvementStock.MS_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_DATEPIECE"].ToString());
					clsPhamouvementStock.FR_CODEFOURNISSEUR = Dataset.Tables["TABLE"].Rows[Idx]["FR_CODEFOURNISSEUR"].ToString();
					clsPhamouvementStock.CL_IDCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
					clsPhamouvementStock.CO_IDCOMMERCIAL = Dataset.Tables["TABLE"].Rows[Idx]["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementStock.MS_REFPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_REFPIECE"].ToString();
					clsPhamouvementStock.MS_LIBOPERA = Dataset.Tables["TABLE"].Rows[Idx]["MS_LIBOPERA"].ToString();
					clsPhamouvementStock.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementStock.MS_TAUXREMISE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_TAUXREMISE"].ToString());
					clsPhamouvementStock.MS_MONTANTTOTALREMISE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_MONTANTTOTALREMISE"].ToString());
					clsPhamouvementStock.MS_MONTANTTRANSPORT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_MONTANTTRANSPORT"].ToString());
					clsPhamouvementStock.MS_MONTANTVERSE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_MONTANTVERSE"].ToString());
					clsPhamouvementStock.MS_DELAILIVRAISON = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_DELAILIVRAISON"].ToString());
					clsPhamouvementStock.MS_DATELIVRAISON = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_DATELIVRAISON"].ToString());
					clsPhamouvementStock.MS_ANNULATIONPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_ANNULATIONPIECE"].ToString();
					clsPhamouvementStock.MS_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_DATESAISIE"].ToString());
					clsPhamouvementStock.MS_MONTANTECHEANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_MONTANTECHEANCE"].ToString());
					clsPhamouvementStock.MS_DUREEPRET = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_DUREEPRET"].ToString());
					clsPhamouvementStock.MS_DATEDEBUTREGLEMENT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_DATEDEBUTREGLEMENT"].ToString());
					clsPhamouvementStock.MS_DUREEVALIDITE = Dataset.Tables["TABLE"].Rows[Idx]["MS_DUREEVALIDITE"].ToString();
					clsPhamouvementStock.MS_CONDITIONREGLEMENT = Dataset.Tables["TABLE"].Rows[Idx]["MS_CONDITIONREGLEMENT"].ToString();
					clsPhamouvementStock.MS_SITUATIONFACTURE = Dataset.Tables["TABLE"].Rows[Idx]["MS_SITUATIONFACTURE"].ToString();
					clsPhamouvementStock.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementStock.MS_TAUXTVA = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_TAUXTVA"].ToString());
					clsPhamouvementStock.MS_TAUXASDI = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MS_TAUXASDI"].ToString());
					clsPhamouvementStocks.Add(clsPhamouvementStock);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementStocks;
		}

        public List<clsPhamouvementStock> pvgSelectVentesEnCours(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  ( MS_NUMFACTURE ='' OR MS_NUMFACTURE IS NULL ) " : " AND  ( MS_NUMFACTURE ='' OR MS_NUMFACTURE IS NULL ) ";
            this.vapRequete = "SELECT  AG_CODEAGENCE, MS_NUMPIECE, MS_NUMFACTURE, MK_NUMPIECE, MS_NUMSEQUENCE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, MS_DATEFACTURE, MS_DATEPIECE, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, MS_REFPIECE, MS_LIBOPERA, NO_CODENATUREOPERATION, MS_TAUXREMISE, MS_MONTANTTOTALREMISE, MS_MONTANTTRANSPORT, MS_MONTANTVERSE, MS_DELAILIVRAISON, MS_DATELIVRAISON, MS_ANNULATIONPIECE, MS_DATESAISIE, MS_MONTANTECHEANCE, MS_DUREEPRET, MS_DATEDEBUTREGLEMENT, MS_DUREEVALIDITE, MS_CONDITIONREGLEMENT, MS_SITUATIONFACTURE, OP_CODEOPERATEUR, MS_TAUXTVA, MS_TAUXASDI FROM dbo.PhamouvementStock " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsPhamouvementStock> clsPhamouvementStocks = new List<clsPhamouvementStock>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPhamouvementStock clsPhamouvementStock = new clsPhamouvementStock();
                    clsPhamouvementStock.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsPhamouvementStock.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
                    clsPhamouvementStock.MS_NUMFACTURE = clsDonnee.vogDataReader["MS_NUMFACTURE"].ToString();
                    clsPhamouvementStock.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
                    clsPhamouvementStock.MS_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["MS_NUMSEQUENCE"].ToString());
                    //clsPhamouvementStock.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
                    clsPhamouvementStock.MS_DATEFACTURE = DateTime.Parse(clsDonnee.vogDataReader["MS_DATEFACTURE"].ToString());
                    clsPhamouvementStock.MS_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MS_DATEPIECE"].ToString());
                    clsPhamouvementStock.FR_CODEFOURNISSEUR = clsDonnee.vogDataReader["FR_CODEFOURNISSEUR"].ToString();
                    clsPhamouvementStock.CL_IDCLIENT = clsDonnee.vogDataReader["CL_IDCLIENT"].ToString();
                    clsPhamouvementStock.CO_IDCOMMERCIAL = clsDonnee.vogDataReader["CO_IDCOMMERCIAL"].ToString();
                    clsPhamouvementStock.MS_REFPIECE = clsDonnee.vogDataReader["MS_REFPIECE"].ToString();
                    clsPhamouvementStock.MS_LIBOPERA = clsDonnee.vogDataReader["MS_LIBOPERA"].ToString();
                    clsPhamouvementStock.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
                    clsPhamouvementStock.MS_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MS_TAUXREMISE"].ToString());
                    clsPhamouvementStock.MS_MONTANTTOTALREMISE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTTOTALREMISE"].ToString());
                    clsPhamouvementStock.MS_MONTANTTRANSPORT = double.Parse(clsDonnee.vogDataReader["MS_MONTANTTRANSPORT"].ToString());
                    clsPhamouvementStock.MS_MONTANTVERSE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTVERSE"].ToString());
                    clsPhamouvementStock.MS_DELAILIVRAISON = int.Parse(clsDonnee.vogDataReader["MS_DELAILIVRAISON"].ToString());
                    clsPhamouvementStock.MS_DATELIVRAISON = DateTime.Parse(clsDonnee.vogDataReader["MS_DATELIVRAISON"].ToString());
                    clsPhamouvementStock.MS_ANNULATIONPIECE = clsDonnee.vogDataReader["MS_ANNULATIONPIECE"].ToString();
                    clsPhamouvementStock.MS_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["MS_DATESAISIE"].ToString());
                    clsPhamouvementStock.MS_MONTANTECHEANCE = double.Parse(clsDonnee.vogDataReader["MS_MONTANTECHEANCE"].ToString());
                    clsPhamouvementStock.MS_DUREEPRET = int.Parse(clsDonnee.vogDataReader["MS_DUREEPRET"].ToString());
                    clsPhamouvementStock.MS_DATEDEBUTREGLEMENT = DateTime.Parse(clsDonnee.vogDataReader["MS_DATEDEBUTREGLEMENT"].ToString());
                    clsPhamouvementStock.MS_DUREEVALIDITE = clsDonnee.vogDataReader["MS_DUREEVALIDITE"].ToString();
                    clsPhamouvementStock.MS_CONDITIONREGLEMENT = clsDonnee.vogDataReader["MS_CONDITIONREGLEMENT"].ToString();
                    clsPhamouvementStock.MS_SITUATIONFACTURE = clsDonnee.vogDataReader["MS_SITUATIONFACTURE"].ToString();
                    clsPhamouvementStock.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsPhamouvementStock.MS_TAUXTVA = float.Parse(clsDonnee.vogDataReader["MS_TAUXTVA"].ToString());
                    clsPhamouvementStock.MS_TAUXASDI = float.Parse(clsDonnee.vogDataReader["MS_TAUXASDI"].ToString());
                    clsPhamouvementStocks.Add(clsPhamouvementStock);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPhamouvementStocks;
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee,vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  MS_ANNULATIONPIECE = 'N' " : " AND  MS_ANNULATIONPIECE = 'N' ";
            this.vapRequete = "SELECT *  FROM dbo.[FT_PHAMOUVEMENTSTOCK](@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMvt1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE"};
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT *  FROM dbo.[FT_PHAMOUVEMENTSTOCK2](@AG_CODEAGENCE,@MS_NUMPIECE,@CODECRYPTAGE) ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMVT(clsDonnee clsDonnee, params string[] vppCritere)
        {
        //pvpChoixCritere(clsDonnee,vppCritere);

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE", "@OP_CODEOPERATEUREDITION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            this.vapRequete = "SELECT *  FROM dbo.[FT_PHAMOUVEMENTSTOCK1](@AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE,@OP_CODEOPERATEUREDITION,@CODECRYPTAGE) ";
        this.vapCritere = "";
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMVTReedition(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee,vppCritere);

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE", "@OP_CODEOPERATEUREDITION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            this.vapRequete = "SELECT *  FROM dbo.[FT_PHAMOUVEMENTSTOCK1](@AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE,@OP_CODEOPERATEUREDITION,@CODECRYPTAGE) ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }








        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMouvementStock(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere1(clsDonnee, vppCritere);
            //this.vapCritere += this.vapCritere == "" ? "WHERE  MS_ANNULATIONPIECE = 'N' " : " AND  MS_ANNULATIONPIECE = 'N' ";

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE", "@OP_CODEOPERATEUREDITION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT *  FROM dbo.[FT_PHAMOUVEMENTSTOCK1](@AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE,@OP_CODEOPERATEUREDITION,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetVentes(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TP_CODETYPETIERS", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM", "@MS_ANNULATIONPIECE", "@MS_DATECLOTURE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8],vppCritere[9],vppCritere[10], clsDonnee.vogCleCryptage };
            if (vppCritere[10] == "01/01/1900")//LISTE DES FACTURES NON CLOTUREE
            {
                this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTECLIENT (@AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@TP_CODETYPETIERS,@CO_NUMCOMMERCIAL,@CO_NOMPRENOM,@MS_ANNULATIONPIECE,@CODECRYPTAGE) WHERE MS_DATEFACTURE ='01/01/1900' AND MS_DATECLOTURE =@MS_DATECLOTURE AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%' ";
            }

            else//LISTE DES FACTURES CLOTUREE
            {
                this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTECLIENT (@AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@TP_CODETYPETIERS,@CO_NUMCOMMERCIAL,@CO_NOMPRENOM,@MS_ANNULATIONPIECE,@CODECRYPTAGE) WHERE MS_DATEFACTURE ='01/01/1900' AND MS_DATECLOTURE <>'01/01/1900' AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%' ";
            }

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

		}

        public DataSet pvgInsertIntoDatasetAppro(clsDonnee clsDonnee, params string[] vppCritere)
        {

            string vlpCO_CODECONSULTATION = "";

            if(vppCritere.Length==19)
                vlpCO_CODECONSULTATION = vppCritere[18];

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN", "@TI_NUMTIERS", "@TI_DENOMINATION", "@MS_ANNULATIONPIECE", "@TYPEOPERATION", "@TP_CODETYPETIERS", "@OP_CODEOPERATEUREDITION", "@NT_CODENATURETYPEARTICLE", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM", "@NT_CODENATURETIERS", "@NO_CODENATUREOPERATION", "@AR_CODEARTICLE1", "@GP_CODEGROUPE", "@TYPELISTE", "@CO_CODECONSULTATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11], vppCritere[12], vppCritere[13], vppCritere[14].Replace("''", "'"), vppCritere[15], vppCritere[16], vppCritere[17], vlpCO_CODECONSULTATION, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC PS_PHAMOUVEMENTSTOCKLISTEFOURNISSEUR @AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@MS_ANNULATIONPIECE,@TYPEOPERATION,@TP_CODETYPETIERS,@OP_CODEOPERATEUREDITION,@NT_CODENATURETYPEARTICLE,@CO_NUMCOMMERCIAL,@CO_NOMPRENOM,@NT_CODENATURETIERS,@NO_CODENATUREOPERATION,@AR_CODEARTICLE1,@GP_CODEGROUPE,@TYPELISTE,@CO_CODECONSULTATION,@CODECRYPTAGE";//WHERE  MS_DATEFACTURE ='01/01/1900' AND MS_DATECLOTURE  NOT BETWEEN @MS_DATEPIECEDEBUT AND @MS_DATEPIECEFIN AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%'  AND NT_CODENATURETYPEARTICLE LIKE '%'+@NT_CODENATURETYPEARTICLE+'%' AND ISNULL(CO_NUMCOMMERCIAL,'') LIKE '%'+@CO_NUMCOMMERCIAL+'%' AND ISNULL(CO_NOMPRENOM,'') LIKE '%'+@CO_NOMPRENOM+'%' AND ISNULL(NT_CODENATURETIERS,'') LIKE '%'+@NT_CODENATURETIERS+'%'  AND ISNULL(NO_CODENATUREOPERATION,'') LIKE '%'+@NO_CODENATUREOPERATION+'%' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }




        //public DataSet pvgInsertIntoDatasetAppro(clsDonnee clsDonnee, params string[] vppCritere)
        //{

        //    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN", "@TI_NUMTIERS", "@TI_DENOMINATION", "@MS_ANNULATIONPIECE", "@MS_DATECLOTURE", "@TP_CODETYPETIERS", "@OP_CODEOPERATEUREDITION", "@NT_CODENATURETYPEARTICLE", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM", "@NT_CODENATURETIERS", "@NO_CODENATUREOPERATION", "@AR_CODEARTICLE1", "@GP_CODEGROUPE", "@TYPELISTE", "@CODECRYPTAGE" };
        //    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6],  vppCritere[7],vppCritere[8],vppCritere[9],vppCritere[10],vppCritere[11],vppCritere[12],vppCritere[13],vppCritere[14],vppCritere[15],vppCritere[16],vppCritere[17], clsDonnee.vogCleCryptage };

        //    if (vppCritere[7] == "01/01/1900" )//LISTE DES FACTURES NON CLOTUREE
        //    {
        //        //this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTECLIENT (@AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@TP_CODETYPETIERS,@CO_NUMCOMMERCIAL,@CO_NOMPRENOM,@MS_ANNULATIONPIECE,@CODECRYPTAGE) WHERE MS_DATEFACTURE ='01/01/1900' AND MS_DATECLOTURE =@MS_DATECLOTURE AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%' ";


        //        this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTEFOURNISSEUR ( @AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@MS_ANNULATIONPIECE,@TP_CODETYPETIERS,@OP_CODEOPERATEUREDITION,@AR_CODEARTICLE1,@GP_CODEGROUPE,@TYPELISTE,@CODECRYPTAGE ) WHERE  MS_DATEFACTURE ='01/01/1900' AND MS_DATECLOTURE  NOT BETWEEN @MS_DATEPIECEDEBUT AND @MS_DATEPIECEFIN AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%'  AND NT_CODENATURETYPEARTICLE LIKE '%'+@NT_CODENATURETYPEARTICLE+'%' AND ISNULL(CO_NUMCOMMERCIAL,'') LIKE '%'+@CO_NUMCOMMERCIAL+'%' AND ISNULL(CO_NOMPRENOM,'') LIKE '%'+@CO_NOMPRENOM+'%' AND ISNULL(NT_CODENATURETIERS,'') LIKE '%'+@NT_CODENATURETIERS+'%'  AND ISNULL(NO_CODENATUREOPERATION,'') LIKE '%'+@NO_CODENATUREOPERATION+'%' ";

        //    }
        //     //else
        //     //   if (vppCritere[7] == "01/01/1900" && vppCritere[17] == "SOLDNONNULL") 
        //     //   {
        //     //       this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTEFOURNISSEUR ( @AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@MS_ANNULATIONPIECE,@TP_CODETYPETIERS,@OP_CODEOPERATEUREDITION,@AR_CODEARTICLE1,@GP_CODEGROUPE,@CODECRYPTAGE ) WHERE  MS_DATEFACTURE ='01/01/1900' AND MS_DATECLOTURE  NOT BETWEEN @MS_DATEPIECEDEBUT AND @MS_DATEPIECEFIN AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%'  AND NT_CODENATURETYPEARTICLE LIKE '%'+@NT_CODENATURETYPEARTICLE+'%' AND ISNULL(CO_NUMCOMMERCIAL,'') LIKE '%'+@CO_NUMCOMMERCIAL+'%' AND ISNULL(CO_NOMPRENOM,'') LIKE '%'+@CO_NOMPRENOM+'%' AND ISNULL(NT_CODENATURETIERS,'') LIKE '%'+@NT_CODENATURETIERS+'%'  AND ISNULL(NO_CODENATUREOPERATION,'') LIKE '%'+@NO_CODENATUREOPERATION+'%'  AND MS_RESTAMONTANTVERSE > 0 AND GP_CODEGROUPE=@GP_CODEGROUPE";
        //     //   }

        //    else//LISTE DES FACTURES CLOTUREE
        //    {
        //        //this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTECLIENT (@AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@TP_CODETYPETIERS,@CO_NUMCOMMERCIAL,@CO_NOMPRENOM,@MS_ANNULATIONPIECE,@CODECRYPTAGE) WHERE MS_DATEFACTURE ='01/01/1900' AND MS_DATECLOTURE <>'01/01/1900' AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%' ";


        //        this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTEFOURNISSEUR ( @AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@MS_ANNULATIONPIECE,@TP_CODETYPETIERS,@OP_CODEOPERATEUREDITION,@AR_CODEARTICLE1,@GP_CODEGROUPE,@TYPELISTE,@CODECRYPTAGE ) WHERE  MS_DATEFACTURE ='01/01/1900' AND MS_DATECLOTURE  BETWEEN @MS_DATEPIECEDEBUT AND @MS_DATEPIECEFIN AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%'  AND NT_CODENATURETYPEARTICLE LIKE '%'+@NT_CODENATURETYPEARTICLE+'%' AND ISNULL(CO_NUMCOMMERCIAL,'') LIKE '%'+@CO_NUMCOMMERCIAL+'%' AND ISNULL(CO_NOMPRENOM,'') LIKE '%'+@CO_NOMPRENOM+'%' AND ISNULL(NT_CODENATURETIERS,'') LIKE '%'+@NT_CODENATURETIERS+'%'  AND ISNULL(NO_CODENATUREOPERATION,'') LIKE '%'+@NO_CODENATUREOPERATION+'%'  ";
        //    }


        //    //this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTEFOURNISSEUR ( @AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@FR_MATRICULE,@FR_DENOMINATION,@MS_ANNULATIONPIECE,@CODECRYPTAGE ) WHERE NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%' AND FR_MATRICULE LIKE '%'+@FR_MATRICULE+'%' AND FR_DENOMINATION LIKE '%'+@FR_DENOMINATION+'%' ";
        //    //this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKLISTEFOURNISSEUR ( @AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@MS_ANNULATIONPIECE,@TP_CODETYPETIERS,@CODECRYPTAGE ) WHERE NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%' AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%'  ";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        //}


        public DataSet pvgInsertIntoDatasetTransfertFabrication(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE",  "@MS_NUMPIECE", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN", "@MS_ANNULATIONPIECE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKFABRICATIONTRANSFERT ( @AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@MS_ANNULATIONPIECE,@CODECRYPTAGE ) WHERE  MS_DATEFACTURE ='01/01/1900'  AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%'   ";//AND NO_CODENATUREOPERATION NOT IN ('TRAN','TRAD')
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

        public DataSet pvgInsertIntoDatasetTransfert(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN", "@MS_ANNULATIONPIECE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT * FROM dbo.FC_PHAMOUVEMENTSTOCKTRANSFERT ( @AG_CODEAGENCE,@MS_NUMPIECE,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@MS_ANNULATIONPIECE,@CODECRYPTAGE ) WHERE  MS_DATEFACTURE ='01/01/1900' AND NO_CODENATUREOPERATION  IN ('TRAN','TRAD') AND NUMEROBORDEREAU LIKE '%'+@MS_NUMPIECE+'%'   ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , MS_NUMFACTURE FROM dbo.PhamouvementStock " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTiersPourReglement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@NT_CODENATURETYPETIERS", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" , "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4] , clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC  [dbo].[PS_PS_CLIPHATIERSFACTURE] @AG_CODEAGENCE,@MS_NUMPIECE,@NT_CODENATURETYPETIERS,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE";
				vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MK_NUMPIECE=@MK_NUMPIECE";
				vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR";
				vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR";
				vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
                //case 7 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT";
                //vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT"};
                //vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
                //break;
                //case 8 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL";
                //vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL"};
                //vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7]};
                //break;
                //case 9 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
                //vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL","@NO_CODENATUREOPERATION"};
                //vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8]};
                //break;
                //case 10 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                //vapNomParametre = new string[]{"@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL","@NO_CODENATUREOPERATION","@OP_CODEOPERATEUR"};
                //vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9]};
                //break;
                case 7://CE CAS CONCERNE RECHERCHE APPROVISIONNEMENT   
                vapCritere = "WHERE AG_CODEAGENCE = AG_CODEAGENCE AND CONVERT( DATETIME , MS_DATEPIECE, 103) BETWEEN @MS_DATEPIECE1 AND @MS_DATEPIECE2 AND MS_ANNULATIONPIECE LIKE '%'+ @MS_ANNULATIONPIECE +'%' AND NUMEROBORDEREAU LIKE '%'+ @NUMEROBORDEREAU +'%' " +
                                 " AND FR_CODEFOURNISSEUR LIKE '%'+ @FR_CODEFOURNISSEUR +'%'  AND FR_DENOMINATION LIKE '%'+ @FR_DENOMINATION +'%'   AND NO_CODENATUREOPERATION = 'APPS' ";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_DATEPIECE1", "@MS_DATEPIECE2", "@MS_ANNULATIONPIECE", "@NUMEROBORDEREAU", "@FR_CODEFOURNISSEUR", "@FR_DENOMINATION" };
                vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                break;

                case 10://CE CAS CONCERNE RECHERCHE VENTE
                    vapCritere = "WHERE AG_CODEAGENCE = AG_CODEAGENCE AND CONVERT( DATETIME , MS_DATEPIECE, 103) BETWEEN @MS_DATEPIECE1 AND @MS_DATEPIECE2 AND MS_ANNULATIONPIECE LIKE '%'+ @MS_ANNULATIONPIECE +'%'  AND CL_NUMCLIENT LIKE '%'+ @CL_NUMCLIENT +'%' AND TP_CODETYPECLIENT LIKE '%'+ @TP_CODETYPECLIENT +'%' AND CL_DENOMINATION  LIKE '%'+ @CL_DENOMINATION +'%' " +
                                 " AND CO_NUMCOMMERCIAL LIKE '%'+ @CO_NUMCOMMERCIAL +'%'  AND CO_NOMPRENOM LIKE '%'+ @CO_NOMPRENOM +'%' AND NUMEROBORDEREAU LIKE '%'+ @NUMEROBORDEREAU +'%' AND  NO_CODENATUREOPERATION = 'VENT' ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_DATEPIECE1", "@MS_DATEPIECE2", "@MS_ANNULATIONPIECE", "@CL_NUMCLIENT", "@TP_CODETYPECLIENT", "@CL_DENOMINATION", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM", "@NUMEROBORDEREAU" };
                vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9] };
                break;
             }
		}
		public void pvpChoixCritere( clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
				break;
				case 1 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%' " ;
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MK_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT", "@CH_IDCHAUFFEUR" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT", "@CH_IDCHAUFFEUR", "@FR_CODEFOURNISSEUR" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
                //case 7 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
                //break;
                //case 8 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7]};
                //break;
                //case 9 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL","@NO_CODENATUREOPERATION"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8]};
                //break;
                //case 10 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL","@NO_CODENATUREOPERATION","@OP_CODEOPERATEUR"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9]};
                //break;
                case 7://CE CAS CONCERNE RECHERCHE APPROVISIONNEMENT   
                vapCritere = "WHERE AG_CODEAGENCE = AG_CODEAGENCE AND CONVERT( DATETIME , MS_DATEPIECE, 103) BETWEEN @MS_DATEPIECE1 AND @MS_DATEPIECE2 AND MS_ANNULATIONPIECE LIKE '%'+ @MS_ANNULATIONPIECE +'%' AND NUMEROBORDEREAU LIKE '%'+ @NUMEROBORDEREAU +'%' " +
                                 " AND FR_CODEFOURNISSEUR LIKE '%'+ @FR_CODEFOURNISSEUR +'%'  AND FR_DENOMINATION LIKE '%'+ @FR_DENOMINATION +'%'   AND NO_CODENATUREOPERATION = 'APPS' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_DATEPIECE1", "@MS_DATEPIECE2", "@MS_ANNULATIONPIECE", "@NUMEROBORDEREAU", "@FR_CODEFOURNISSEUR", "@FR_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                break;

                case 10://CE CAS CONCERNE RECHERCHE VENTE
                    vapCritere = "WHERE AG_CODEAGENCE = AG_CODEAGENCE AND CONVERT( DATETIME , MS_DATEPIECE, 103) BETWEEN @MS_DATEPIECE1 AND @MS_DATEPIECE2 AND MS_ANNULATIONPIECE LIKE '%'+ @MS_ANNULATIONPIECE +'%'  AND CL_NUMCLIENT LIKE '%'+ @CL_NUMCLIENT +'%' AND TP_CODETYPECLIENT LIKE '%'+ @TP_CODETYPECLIENT +'%' AND CL_DENOMINATION  LIKE '%'+ @CL_DENOMINATION +'%' " +
                                 " AND CO_NUMCOMMERCIAL LIKE '%'+ @CO_NUMCOMMERCIAL +'%'  AND CO_NOMPRENOM LIKE '%'+ @CO_NOMPRENOM +'%' AND NUMEROBORDEREAU LIKE '%'+ @NUMEROBORDEREAU +'%' AND  NO_CODENATUREOPERATION = 'VENT' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_DATEPIECE1", "@MS_DATEPIECE2", "@MS_ANNULATIONPIECE", "@CL_NUMCLIENT", "@TP_CODETYPECLIENT", "@CL_DENOMINATION", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM", "@NUMEROBORDEREAU" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9] };
                break;
             }
		}



        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DATEJOURNEE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DATEJOURNEE", "@MS_NUMPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DATEJOURNEE", "@MS_NUMPIECE", "@MK_NUMPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DATEJOURNEE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
                case 6:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DATEJOURNEE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT", "@CH_IDCHAUFFEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
                    break;
                case 7:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DATEJOURNEE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT", "@CH_IDCHAUFFEUR", "@FR_CODEFOURNISSEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                    break;
                //case 7 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
                //break;
                //case 8 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7]};
                //break;
                //case 9 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL","@NO_CODENATUREOPERATION"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8]};
                //break;
                //case 10 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL","@NO_CODENATUREOPERATION","@OP_CODEOPERATEUR"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9]};
                //break;
                case 8://CE CAS CONCERNE RECHERCHE APPROVISIONNEMENT   
                    vapCritere = "WHERE AG_CODEAGENCE = AG_CODEAGENCE AND CONVERT( DATETIME , MS_DATEPIECE, 103) BETWEEN @MS_DATEPIECE1 AND @MS_DATEPIECE2 AND MS_ANNULATIONPIECE LIKE '%'+ @MS_ANNULATIONPIECE +'%' AND NUMEROBORDEREAU LIKE '%'+ @NUMEROBORDEREAU +'%' " +
                                     " AND FR_CODEFOURNISSEUR LIKE '%'+ @FR_CODEFOURNISSEUR +'%'  AND FR_DENOMINATION LIKE '%'+ @FR_DENOMINATION +'%'   AND NO_CODENATUREOPERATION = 'APPS' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DATEJOURNEE", "@MS_DATEPIECE1", "@MS_DATEPIECE2", "@MS_ANNULATIONPIECE", "@NUMEROBORDEREAU", "@FR_CODEFOURNISSEUR", "@FR_DENOMINATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] };
                    break;

                case 10://CE CAS CONCERNE RECHERCHE VENTE
                    vapCritere = "WHERE AG_CODEAGENCE = AG_CODEAGENCE AND CONVERT( DATETIME , MS_DATEPIECE, 103) BETWEEN @MS_DATEPIECE1 AND @MS_DATEPIECE2 AND MS_ANNULATIONPIECE LIKE '%'+ @MS_ANNULATIONPIECE +'%'  AND CL_NUMCLIENT LIKE '%'+ @CL_NUMCLIENT +'%' AND TP_CODETYPECLIENT LIKE '%'+ @TP_CODETYPECLIENT +'%' AND CL_DENOMINATION  LIKE '%'+ @CL_DENOMINATION +'%' " +
                                 " AND CO_NUMCOMMERCIAL LIKE '%'+ @CO_NUMCOMMERCIAL +'%'  AND CO_NOMPRENOM LIKE '%'+ @CO_NOMPRENOM +'%' AND NUMEROBORDEREAU LIKE '%'+ @NUMEROBORDEREAU +'%' AND  NO_CODENATUREOPERATION = 'VENT' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_DATEPIECE1", "@MS_DATEPIECE2", "@MS_ANNULATIONPIECE", "@CL_NUMCLIENT", "@TP_CODETYPECLIENT", "@CL_DENOMINATION", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM", "@NUMEROBORDEREAU" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9] };
                    break;
            }
        }




        public void pvpChoixCritereGestionFacture(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MK_NUMPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT", "@CH_IDCHAUFFEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
                case 6:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(50)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MK_NUMPIECE", "@EN_CODEENTREPOT", "@CH_IDCHAUFFEUR", "@FR_CODEFOURNISSEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
                    break;
                //case 7 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
                //break;
                //case 8 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7]};
                //break;
                //case 9 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL","@NO_CODENATUREOPERATION"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8]};
                //break;
                //case 10 :
                //this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CAST(MS_NUMPIECE AS VARCHAR(30)) LIKE '%'+@MS_NUMPIECE+'%'  AND MK_NUMPIECE=@MK_NUMPIECE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CH_IDCHAUFFEUR=@CH_IDCHAUFFEUR AND FR_CODEFOURNISSEUR=@FR_CODEFOURNISSEUR AND CL_IDCLIENT=@CL_IDCLIENT AND CO_IDCOMMERCIAL=@CO_IDCOMMERCIAL AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                //vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@MK_NUMPIECE","@EN_CODEENTREPOT","@CH_IDCHAUFFEUR","@FR_CODEFOURNISSEUR","@CL_IDCLIENT","@CO_IDCOMMERCIAL","@NO_CODENATUREOPERATION","@OP_CODEOPERATEUR"};
                //vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7],vppCritere[8],vppCritere[9]};
                //break;
                case 7://CE CAS CONCERNE RECHERCHE APPROVISIONNEMENT   
                    vapCritere = "WHERE AG_CODEAGENCE = AG_CODEAGENCE AND CONVERT( DATETIME , MS_DATEPIECE, 103) BETWEEN @MS_DATEPIECE1 AND @MS_DATEPIECE2 AND MS_ANNULATIONPIECE LIKE '%'+ @MS_ANNULATIONPIECE +'%' AND NUMEROBORDEREAU LIKE '%'+ @NUMEROBORDEREAU +'%' " +
                                     " AND FR_CODEFOURNISSEUR LIKE '%'+ @FR_CODEFOURNISSEUR +'%'  AND FR_DENOMINATION LIKE '%'+ @FR_DENOMINATION +'%'   AND NO_CODENATUREOPERATION = 'APPS' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_DATEPIECE1", "@MS_DATEPIECE2", "@MS_ANNULATIONPIECE", "@NUMEROBORDEREAU", "@FR_CODEFOURNISSEUR", "@FR_DENOMINATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                    break;

                case 10://CE CAS CONCERNE RECHERCHE VENTE
                    vapCritere = "WHERE AG_CODEAGENCE = AG_CODEAGENCE AND CONVERT( DATETIME , MS_DATEPIECE, 103) BETWEEN @MS_DATEPIECE1 AND @MS_DATEPIECE2 AND MS_ANNULATIONPIECE LIKE '%'+ @MS_ANNULATIONPIECE +'%'  AND CL_NUMCLIENT LIKE '%'+ @CL_NUMCLIENT +'%' AND TP_CODETYPECLIENT LIKE '%'+ @TP_CODETYPECLIENT +'%' AND CL_DENOMINATION  LIKE '%'+ @CL_DENOMINATION +'%' " +
                                 " AND CO_NUMCOMMERCIAL LIKE '%'+ @CO_NUMCOMMERCIAL +'%'  AND CO_NOMPRENOM LIKE '%'+ @CO_NOMPRENOM +'%' AND NUMEROBORDEREAU LIKE '%'+ @NUMEROBORDEREAU +'%' AND  NO_CODENATUREOPERATION = 'VENT' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_DATEPIECE1", "@MS_DATEPIECE2", "@MS_ANNULATIONPIECE", "@CL_NUMCLIENT", "@TP_CODETYPECLIENT", "@CL_DENOMINATION", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM", "@NUMEROBORDEREAU" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9] };
                    break;
            }
        }

    }
}
