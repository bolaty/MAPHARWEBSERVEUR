using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsPlancomptableWSDAL : ITableDAL<clsPlancomptable>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        //clsMouvementcomptableWSDAL clsMouvementcomptableWSDAL = new clsMouvementcomptableWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PL_CODENUMCOMPTE) AS PL_CODENUMCOMPTE  FROM PLANCOMPTABLE " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PL_CODENUMCOMPTE) AS PL_CODENUMCOMPTE  FROM PLANCOMPTABLE " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PL_CODENUMCOMPTE) AS PL_CODENUMCOMPTE  FROM PLANCOMPTABLE "+ this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsPlancomptable">clsPlancomptable</param>
		///<author>Home Technologie</author>
		public clsPlancomptable pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT PL_CODENUMCOMPTE,PL_LIBELLE,PL_COMPTECOLLECTIF,PL_REPORTDEBIT,PL_REPORTCREDIT,PL_MONTANTPERIODEPRECEDENTDEBIT,PL_MONTANTPERIODEPRECEDENTCREDIT,PL_MONTANTPERIODEDEBITENCOURS,PL_MONTANTPERIODECREDITENCOURS,PL_MONTANTSOLDEFINALDEBIT,PL_MONTANTSOLDEFINALCREDIT,COMPTAPAR_SENS_CODE,PL_TYPECOMPTE,PL_ACTIF,PL_NUMCOMPTE FROM PLANCOMPTABLE " + this.vapCritere + "  AND PL_ACTIF='O'";
			this.vapCritere = "";

			clsPlancomptable clsPlancomptable = new clsPlancomptable(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
                    clsPlancomptable.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
					clsPlancomptable.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
					clsPlancomptable.PL_COMPTECOLLECTIF = clsDonnee.vogDataReader["PL_COMPTECOLLECTIF"].ToString();
					clsPlancomptable.PL_REPORTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTDEBIT"].ToString());
					clsPlancomptable.PL_REPORTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTCREDIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
					clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
					clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
					clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
					clsPlancomptable.COMPTAPAR_SENS_CODE = clsDonnee.vogDataReader["COMPTAPAR_SENS_CODE"].ToString();
					clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
					clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    //clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlancomptable;
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsPlancomptable">clsPlancomptable</param>
        ///<author>Home Technologie</author>
        public clsPlancomptable pvgTableLabelAvecSolde(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritereAvecSolde(vppCritere);

            //this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE ";
            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_CODEAGENCE", "@PL_NUMCOMPTE", "@JT_DATEJOURNEETRAVAIL" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] , vppCritere[2], vppCritere[3]};
            //
            this.vapRequete = "SELECT PL_CODENUMCOMPTE,PL_LIBELLE,PL_TYPECOMPTE,PL_ACTIF,PL_COMPTETIERS,PL_SOLDECOMPTE FROM " +
            "[dbo].[FC_PLANCOMPTABLEAVECSOLDEUNITAIRE](@SO_CODESOCIETE,	@AG_CODEAGENCE,	@PL_NUMCOMPTE,@JT_DATEJOURNEETRAVAIL) "
            + this.vapCritere + " ";
            this.vapCritere = "";

			clsPlancomptable clsPlancomptable = new clsPlancomptable(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
                    clsPlancomptable.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPlancomptable.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
                    //clsPlancomptable.PL_COMPTECOLLECTIF = clsDonnee.vogDataReader["PL_COMPTECOLLECTIF"].ToString();
                    //clsPlancomptable.PL_REPORTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTDEBIT"].ToString());
                    //clsPlancomptable.PL_REPORTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTCREDIT"].ToString());
                    //clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
                    //clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
                    //clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
                    //clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
                    //clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
                    //clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
                    //clsPlancomptable.COMPTAPAR_SENS_CODE = clsDonnee.vogDataReader["COMPTAPAR_SENS_CODE"].ToString();
                    clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
                    clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    //clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
                    //clsPlancomptable.COMPTAPAR_SENS_CODE = clsDonnee.vogDataReader["COMPTAPAR_SENS_CODE"].ToString();
                    //clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
                    //clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    //clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
                    clsPlancomptable.PL_COMPTETIERS = clsDonnee.vogDataReader["PL_COMPTETIERS"].ToString();
                    clsPlancomptable.PL_SOLDECOMPTE = double.Parse(clsDonnee.vogDataReader["PL_SOLDECOMPTE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlancomptable;
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsPlancomptable">clsPlancomptable</param>
		///<author>Home Technologie</author>
		public clsPlancomptable pvgTableLabel1(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere2(vppCritere);
            this.vapRequete = "SELECT PL_NUMCOMPTE,PL_LIBELLE,PL_COMPTECOLLECTIF,PL_REPORTDEBIT,PL_REPORTCREDIT,PL_MONTANTPERIODEPRECEDENTDEBIT,PL_MONTANTPERIODEPRECEDENTCREDIT,PL_MONTANTPERIODEDEBITENCOURS,PL_MONTANTPERIODECREDITENCOURS,PL_MONTANTSOLDEFINALDEBIT,PL_MONTANTSOLDEFINALCREDIT,COMPTAPAR_SENS_CODE,PL_TYPECOMPTE,PL_ACTIF FROM PLANCOMPTABLE " + this.vapCritere + "  AND PL_ACTIF='O'";
			this.vapCritere = "";

			clsPlancomptable clsPlancomptable = new clsPlancomptable(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
                    clsPlancomptable.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
					clsPlancomptable.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
					clsPlancomptable.PL_COMPTECOLLECTIF = clsDonnee.vogDataReader["PL_COMPTECOLLECTIF"].ToString();
					clsPlancomptable.PL_REPORTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTDEBIT"].ToString());
					clsPlancomptable.PL_REPORTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTCREDIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
					clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
					clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
					clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
					clsPlancomptable.COMPTAPAR_SENS_CODE = clsDonnee.vogDataReader["COMPTAPAR_SENS_CODE"].ToString();
					clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
					clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    //clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlancomptable;
		}

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPlancomptable">clsPlancomptable</param>
        ///<author>Home Technologie</author>
        public void pvgInsert(clsDonnee clsDonnee, clsPlancomptable clsPlancomptable)
        {
            //Préparation des paramètres

            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
            vppParamSO_CODESOCIETE.Value = clsPlancomptable.SO_CODESOCIETE;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsPlancomptable.PL_CODENUMCOMPTE;

            SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 25);
            vppParamNC_CODENATURECOMPTE.Value = clsPlancomptable.NC_CODENATURECOMPTE;

            SqlParameter vppParamPL_FOCUSTIERS = new SqlParameter("@PL_FOCUSTIERS", SqlDbType.VarChar, 1);
            vppParamPL_FOCUSTIERS.Value = clsPlancomptable.PL_FOCUSTIERS;


            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPlancomptable.PL_NUMCOMPTE;

            SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPL_LIBELLE.Value = clsPlancomptable.PL_LIBELLE;

            SqlParameter vppParamPL_COMPTECOLLECTIF = new SqlParameter("@PL_COMPTECOLLECTIF", SqlDbType.VarChar, 25);
            vppParamPL_COMPTECOLLECTIF.Value = clsPlancomptable.PL_COMPTECOLLECTIF;

            SqlParameter vppParamPL_REPORTDEBIT = new SqlParameter("@PL_REPORTDEBIT", SqlDbType.Money);
            vppParamPL_REPORTDEBIT.Value = clsPlancomptable.PL_REPORTDEBIT;

            SqlParameter vppParamPL_REPORTCREDIT = new SqlParameter("@PL_REPORTCREDIT", SqlDbType.Money);
            vppParamPL_REPORTCREDIT.Value = clsPlancomptable.PL_REPORTCREDIT;

            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTDEBIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT;

            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTCREDIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT;

            SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURS = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEDEBITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS;

            SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURS = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODECREDITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS;

            SqlParameter vppParamPL_MONTANTSOLDEFINALDEBIT = new SqlParameter("@PL_MONTANTSOLDEFINALDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALDEBIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT;

            SqlParameter vppParamPL_MONTANTSOLDEFINALCREDIT = new SqlParameter("@PL_MONTANTSOLDEFINALCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALCREDIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT;

            SqlParameter vppParamCOMPTAPAR_SENS_CODE = new SqlParameter("@COMPTAPAR_SENS_CODE", SqlDbType.VarChar, 4);
            vppParamCOMPTAPAR_SENS_CODE.Value = clsPlancomptable.COMPTAPAR_SENS_CODE;

            SqlParameter vppParamPL_TYPECOMPTE = new SqlParameter("@PL_TYPECOMPTE", SqlDbType.VarChar, 1);
            vppParamPL_TYPECOMPTE.Value = clsPlancomptable.PL_TYPECOMPTE;

            SqlParameter vppParamPL_ACTIF = new SqlParameter("@PL_ACTIF", SqlDbType.VarChar, 1);
            vppParamPL_ACTIF.Value = clsPlancomptable.PL_ACTIF;



            SqlParameter vppParamPL_SAISIE_ANALYTIQUE = new SqlParameter("@PL_SAISIE_ANALYTIQUE", SqlDbType.VarChar, 1);
            vppParamPL_SAISIE_ANALYTIQUE.Value = clsPlancomptable.PL_SAISIE_ANALYTIQUE;

            SqlParameter vppParamTS_CODE = new SqlParameter("@TS_CODE", SqlDbType.VarChar, 2);
            vppParamTS_CODE.Value = clsPlancomptable.TS_CODE;

            SqlParameter vppParamPL_NOMBRELIGNE = new SqlParameter("@PL_NOMBRELIGNE", SqlDbType.Int);
            vppParamPL_NOMBRELIGNE.Value = clsPlancomptable.PL_NOMBRELIGNE;


            SqlParameter vppParamPLAN_REPORTING_CODE = new SqlParameter("@PLAN_REPORTING_CODE", SqlDbType.VarChar, 4);
            vppParamPLAN_REPORTING_CODE.Value = clsPlancomptable.PLAN_REPORTING_CODE;
            if (clsPlancomptable.PLAN_REPORTING_CODE == "") vppParamPLAN_REPORTING_CODE.Value = DBNull.Value;

            SqlParameter vppParamPL_COMPTEEXCEDANT = new SqlParameter("@PL_COMPTEEXCEDANT", SqlDbType.VarChar, 1);
            vppParamPL_COMPTEEXCEDANT.Value = clsPlancomptable.PL_COMPTEEXCEDANT;

            SqlParameter vppParamPL_COMPTEDEFICIT = new SqlParameter("@PL_COMPTEDEFICIT", SqlDbType.VarChar, 1);
            vppParamPL_COMPTEDEFICIT.Value = clsPlancomptable.PL_COMPTEDEFICIT;

            SqlParameter vppParamPL_AFFICHERSURECRANDROIT = new SqlParameter("@PL_AFFICHERSURECRANDROIT", SqlDbType.VarChar, 1);
            vppParamPL_AFFICHERSURECRANDROIT.Value = clsPlancomptable.PL_AFFICHERSURECRANDROIT;



            //SqlParameter vppParamPL_COMPTEREFERENTIELCOMPTABLE = new SqlParameter("@PL_COMPTEREFERENTIELCOMPTABLE", SqlDbType.VarChar, 1);
            //vppParamPL_COMPTEREFERENTIELCOMPTABLE.Value = clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE;

            //Préparation de la commande
            //this.vapRequete = "INSERT INTO PLANCOMPTABLE " +
            //" (SO_CODESOCIETE,PL_CODENUMCOMPTE,NC_CODENATURECOMPTE,PL_FOCUSTIERS,PL_NUMCOMPTE,PL_LIBELLE,PL_COMPTECOLLECTIF,PL_REPORTDEBIT,PL_REPORTCREDIT,PL_MONTANTPERIODEPRECEDENTDEBIT,PL_MONTANTPERIODEPRECEDENTCREDIT,PL_MONTANTPERIODEDEBITENCOURS,PL_MONTANTPERIODECREDITENCOURS,PL_MONTANTSOLDEFINALDEBIT,PL_MONTANTSOLDEFINALCREDIT,COMPTAPAR_SENS_CODE,PL_TYPECOMPTE,PL_ACTIF)" +
            //" VALUES(@SO_CODESOCIETE,@PL_CODENUMCOMPTE,@NC_CODENATURECOMPTE,@PL_FOCUSTIERS,@PL_NUMCOMPTE,@PL_LIBELLE,@PL_COMPTECOLLECTIF,@PL_REPORTDEBIT,@PL_REPORTCREDIT,@PL_MONTANTPERIODEPRECEDENTDEBIT,@PL_MONTANTPERIODEPRECEDENTCREDIT,@PL_MONTANTPERIODEDEBITENCOURS,@PL_MONTANTPERIODECREDITENCOURS,@PL_MONTANTSOLDEFINALDEBIT,@PL_MONTANTSOLDEFINALCREDIT,@COMPTAPAR_SENS_CODE,@PL_TYPECOMPTE,@PL_ACTIF)";

            this.vapRequete = "EXECUTE PC_PLANCOMPTABLE  @PL_CODENUMCOMPTE, @SO_CODESOCIETE, @NC_CODENATURECOMPTE, @PL_NUMCOMPTE, @PL_LIBELLE, @PL_COMPTECOLLECTIF, @PL_REPORTDEBIT, @PL_REPORTCREDIT, @PL_MONTANTPERIODEPRECEDENTDEBIT, @PL_MONTANTPERIODEPRECEDENTCREDIT, @PL_MONTANTPERIODEDEBITENCOURS, @PL_MONTANTPERIODECREDITENCOURS, @PL_MONTANTSOLDEFINALDEBIT, @PL_MONTANTSOLDEFINALCREDIT, @COMPTAPAR_SENS_CODE, @PL_TYPECOMPTE, @PL_ACTIF, @PL_FOCUSTIERS, @PL_SAISIE_ANALYTIQUE, @TS_CODE, @PL_NOMBRELIGNE, @PLAN_REPORTING_CODE, @PL_COMPTEEXCEDANT, @PL_COMPTEDEFICIT,@PL_AFFICHERSURECRANDROIT,  0 ";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètres à la commande
            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_FOCUSTIERS);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTECOLLECTIF);
            vppSqlCmd.Parameters.Add(vppParamPL_REPORTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_REPORTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDIT);
            vppSqlCmd.Parameters.Add(vppParamCOMPTAPAR_SENS_CODE);
            vppSqlCmd.Parameters.Add(vppParamPL_TYPECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamPL_SAISIE_ANALYTIQUE);

            vppSqlCmd.Parameters.Add(vppParamTS_CODE);
            vppSqlCmd.Parameters.Add(vppParamPL_NOMBRELIGNE);

            vppSqlCmd.Parameters.Add(vppParamPLAN_REPORTING_CODE);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTEEXCEDANT);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTEDEFICIT);
            vppSqlCmd.Parameters.Add(vppParamPL_AFFICHERSURECRANDROIT);


            //vppSqlCmd.Parameters.Add(vppParamPL_COMPTEREFERENTIELCOMPTABLE);

            //Ouverture de la connection et exécution de la commande
            //vppSqlCmd.ExecuteNonQuery();

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }

        /////<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
        /////<param name="clsDonnee">Classe d'acces aux donnees</param>
        /////<param name="clsPlancomptable">clsPlancomptable</param>
        /////<author>Home Technologie</author>
        //public void pvgInsert(clsDonnee clsDonnee,clsPlancomptable clsPlancomptable)
        //{
        //    //Préparation des paramètres

        //    SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
        //    vppParamSO_CODESOCIETE.Value = clsPlancomptable.SO_CODESOCIETE;

        //    SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
        //    vppParamPL_CODENUMCOMPTE.Value = clsPlancomptable.PL_CODENUMCOMPTE;
        //    SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 25);
        //    vppParamNC_CODENATURECOMPTE.Value = clsPlancomptable.NC_CODENATURECOMPTE;

        //    SqlParameter vppParamPL_FOCUSTIERS = new SqlParameter("@PL_FOCUSTIERS", SqlDbType.VarChar,1);
        //    vppParamPL_FOCUSTIERS.Value = clsPlancomptable.PL_FOCUSTIERS;


        //    SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
        //    vppParamPL_NUMCOMPTE.Value = clsPlancomptable.PL_NUMCOMPTE;

        //    SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
        //    vppParamPL_LIBELLE.Value = clsPlancomptable.PL_LIBELLE;

        //    SqlParameter vppParamPL_COMPTECOLLECTIF = new SqlParameter("@PL_COMPTECOLLECTIF", SqlDbType.VarChar, 25);
        //    vppParamPL_COMPTECOLLECTIF.Value = clsPlancomptable.PL_COMPTECOLLECTIF;

        //    SqlParameter vppParamPL_REPORTDEBIT = new SqlParameter("@PL_REPORTDEBIT", SqlDbType.Money);
        //    vppParamPL_REPORTDEBIT.Value = clsPlancomptable.PL_REPORTDEBIT;

        //    SqlParameter vppParamPL_REPORTCREDIT = new SqlParameter("@PL_REPORTCREDIT", SqlDbType.Money);
        //    vppParamPL_REPORTCREDIT.Value = clsPlancomptable.PL_REPORTCREDIT;

        //    SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBIT", SqlDbType.Money);
        //    vppParamPL_MONTANTPERIODEPRECEDENTDEBIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT;

        //    SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDIT", SqlDbType.Money);
        //    vppParamPL_MONTANTPERIODEPRECEDENTCREDIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT;

        //    SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURS = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURS", SqlDbType.Money);
        //    vppParamPL_MONTANTPERIODEDEBITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS;

        //    SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURS = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURS", SqlDbType.Money);
        //    vppParamPL_MONTANTPERIODECREDITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS;

        //    SqlParameter vppParamPL_MONTANTSOLDEFINALDEBIT = new SqlParameter("@PL_MONTANTSOLDEFINALDEBIT", SqlDbType.Money);
        //    vppParamPL_MONTANTSOLDEFINALDEBIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT;

        //    SqlParameter vppParamPL_MONTANTSOLDEFINALCREDIT = new SqlParameter("@PL_MONTANTSOLDEFINALCREDIT", SqlDbType.Money);
        //    vppParamPL_MONTANTSOLDEFINALCREDIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT;

        //    SqlParameter vppParamCOMPTAPAR_SENS_CODE = new SqlParameter("@COMPTAPAR_SENS_CODE", SqlDbType.VarChar, 2);
        //    vppParamCOMPTAPAR_SENS_CODE.Value = clsPlancomptable.COMPTAPAR_SENS_CODE;

        //    SqlParameter vppParamPL_TYPECOMPTE = new SqlParameter("@PL_TYPECOMPTE", SqlDbType.VarChar, 1);
        //    vppParamPL_TYPECOMPTE.Value = clsPlancomptable.PL_TYPECOMPTE;

        //    SqlParameter vppParamPL_ACTIF = new SqlParameter("@PL_ACTIF", SqlDbType.VarChar, 1);
        //    vppParamPL_ACTIF.Value = clsPlancomptable.PL_ACTIF;

        //    //SqlParameter vppParamPL_COMPTEREFERENTIELCOMPTABLE = new SqlParameter("@PL_COMPTEREFERENTIELCOMPTABLE", SqlDbType.VarChar, 1);
        //    //vppParamPL_COMPTEREFERENTIELCOMPTABLE.Value = clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE;

        //    //Préparation de la commande
        //    this.vapRequete = "INSERT INTO PLANCOMPTABLE " +
        //    " (SO_CODESOCIETE,PL_CODENUMCOMPTE,NC_CODENATURECOMPTE,PL_FOCUSTIERS,PL_NUMCOMPTE,PL_LIBELLE,PL_COMPTECOLLECTIF,PL_REPORTDEBIT,PL_REPORTCREDIT,PL_MONTANTPERIODEPRECEDENTDEBIT,PL_MONTANTPERIODEPRECEDENTCREDIT,PL_MONTANTPERIODEDEBITENCOURS,PL_MONTANTPERIODECREDITENCOURS,PL_MONTANTSOLDEFINALDEBIT,PL_MONTANTSOLDEFINALCREDIT,COMPTAPAR_SENS_CODE,PL_TYPECOMPTE,PL_ACTIF)" +
        //    " VALUES(@SO_CODESOCIETE,@PL_CODENUMCOMPTE,@NC_CODENATURECOMPTE,@PL_FOCUSTIERS,@PL_NUMCOMPTE,@PL_LIBELLE,@PL_COMPTECOLLECTIF,@PL_REPORTDEBIT,@PL_REPORTCREDIT,@PL_MONTANTPERIODEPRECEDENTDEBIT,@PL_MONTANTPERIODEPRECEDENTCREDIT,@PL_MONTANTPERIODEDEBITENCOURS,@PL_MONTANTPERIODECREDITENCOURS,@PL_MONTANTSOLDEFINALDEBIT,@PL_MONTANTSOLDEFINALCREDIT,@COMPTAPAR_SENS_CODE,@PL_TYPECOMPTE,@PL_ACTIF)";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

        //    //Ajout des paramètre à la commande
        //    vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_FOCUSTIERS);
        //    vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_COMPTECOLLECTIF);
        //    vppSqlCmd.Parameters.Add(vppParamPL_REPORTDEBIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_REPORTCREDIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURS);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURS);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDIT);
        //    vppSqlCmd.Parameters.Add(vppParamCOMPTAPAR_SENS_CODE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_TYPECOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_ACTIF);
        //    //vppSqlCmd.Parameters.Add(vppParamPL_COMPTEREFERENTIELCOMPTABLE);

        //    //Ouverture de la connection et exécution de la commande
        //    vppSqlCmd.ExecuteNonQuery();
        //}


        /////<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        /////<param name="clsDonnee">Classe d'acces aux donnees</param>
        /////<param name="clsPlancomptable">clsPlancomptable</param>
        /////<param name="vppCritere">Les critères de modification</param>
        /////<author>Home Technologie</author>
        //public void pvgUpdate(clsDonnee clsDonnee , clsPlancomptable clsPlancomptable, params string[] vppCritere)
        //{
        //    //Préparation des paramètres
        //    //SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
        //    //vppParamSO_CODESOCIETE.Value = clsPlancomptable.SO_CODESOCIETE;

        //    SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
        //    vppParamPL_NUMCOMPTE.Value = clsPlancomptable.PL_NUMCOMPTE;

        //    SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 25);
        //    vppParamNC_CODENATURECOMPTE.Value = clsPlancomptable.NC_CODENATURECOMPTE;

        //    SqlParameter vppParamPL_FOCUSTIERS = new SqlParameter("@PL_FOCUSTIERS", SqlDbType.VarChar, 1);
        //    vppParamPL_FOCUSTIERS.Value = clsPlancomptable.PL_FOCUSTIERS;

        //    SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
        //    vppParamPL_LIBELLE.Value = clsPlancomptable.PL_LIBELLE;

        //    SqlParameter vppParamPL_COMPTECOLLECTIF = new SqlParameter("@PL_COMPTECOLLECTIF", SqlDbType.VarChar, 25);
        //    vppParamPL_COMPTECOLLECTIF.Value = clsPlancomptable.PL_COMPTECOLLECTIF;

        //    SqlParameter vppParamPL_REPORTDEBIT = new SqlParameter("@PL_REPORTDEBIT", SqlDbType.Money);
        //    vppParamPL_REPORTDEBIT.Value = clsPlancomptable.PL_REPORTDEBIT;

        //    SqlParameter vppParamPL_REPORTCREDIT = new SqlParameter("@PL_REPORTCREDIT", SqlDbType.Money);
        //    vppParamPL_REPORTCREDIT.Value = clsPlancomptable.PL_REPORTCREDIT;

        //    SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBIT", SqlDbType.Money);
        //    vppParamPL_MONTANTPERIODEPRECEDENTDEBIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT;

        //    SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDIT", SqlDbType.Money);
        //    vppParamPL_MONTANTPERIODEPRECEDENTCREDIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT;

        //    SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURS = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURS", SqlDbType.Money);
        //    vppParamPL_MONTANTPERIODEDEBITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS;

        //    SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURS = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURS", SqlDbType.Money);
        //    vppParamPL_MONTANTPERIODECREDITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS;

        //    SqlParameter vppParamPL_MONTANTSOLDEFINALDEBIT = new SqlParameter("@PL_MONTANTSOLDEFINALDEBIT", SqlDbType.Money);
        //    vppParamPL_MONTANTSOLDEFINALDEBIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT;

        //    SqlParameter vppParamPL_MONTANTSOLDEFINALCREDIT = new SqlParameter("@PL_MONTANTSOLDEFINALCREDIT", SqlDbType.Money);
        //    vppParamPL_MONTANTSOLDEFINALCREDIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT;

        //    SqlParameter vppParamCOMPTAPAR_SENS_CODE = new SqlParameter("@COMPTAPAR_SENS_CODE", SqlDbType.VarChar, 2);
        //    vppParamCOMPTAPAR_SENS_CODE.Value = clsPlancomptable.COMPTAPAR_SENS_CODE;

        //    SqlParameter vppParamPL_TYPECOMPTE = new SqlParameter("@PL_TYPECOMPTE", SqlDbType.VarChar, 1);
        //    vppParamPL_TYPECOMPTE.Value = clsPlancomptable.PL_TYPECOMPTE;

        //    SqlParameter vppParamPL_ACTIF = new SqlParameter("@PL_ACTIF", SqlDbType.VarChar, 1);
        //    vppParamPL_ACTIF.Value = clsPlancomptable.PL_ACTIF;

        //    //SqlParameter vppParamPL_COMPTEREFERENTIELCOMPTABLE = new SqlParameter("@PL_COMPTEREFERENTIELCOMPTABLE", SqlDbType.VarChar, 1);
        //    //vppParamPL_COMPTEREFERENTIELCOMPTABLE.Value = clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE;

        //     pvpChoixCritere2(vppCritere); 

        //    //Préparation de la commande
        //    this.vapRequete = "UPDATE PLANCOMPTABLE SET " + 
        //    " PL_NUMCOMPTE = @PL_NUMCOMPTE , " +
        //    " NC_CODENATURECOMPTE = @NC_CODENATURECOMPTE , " +
        //    " PL_FOCUSTIERS = @PL_FOCUSTIERS , " + 
        //    " PL_LIBELLE = @PL_LIBELLE , " + 
        //    " PL_COMPTECOLLECTIF = @PL_COMPTECOLLECTIF , " + 
        //    " PL_REPORTDEBIT = @PL_REPORTDEBIT , " + 
        //    " PL_REPORTCREDIT = @PL_REPORTCREDIT , " + 
        //    " PL_MONTANTPERIODEPRECEDENTDEBIT = @PL_MONTANTPERIODEPRECEDENTDEBIT , " + 
        //    " PL_MONTANTPERIODEPRECEDENTCREDIT = @PL_MONTANTPERIODEPRECEDENTCREDIT , " + 
        //    " PL_MONTANTPERIODEDEBITENCOURS = @PL_MONTANTPERIODEDEBITENCOURS , " + 
        //    " PL_MONTANTPERIODECREDITENCOURS = @PL_MONTANTPERIODECREDITENCOURS , " + 
        //    " PL_MONTANTSOLDEFINALDEBIT = @PL_MONTANTSOLDEFINALDEBIT , " + 
        //    " PL_MONTANTSOLDEFINALCREDIT = @PL_MONTANTSOLDEFINALCREDIT , " + 
        //    " COMPTAPAR_SENS_CODE = @COMPTAPAR_SENS_CODE , " + 
        //    " PL_TYPECOMPTE = @PL_TYPECOMPTE , " + 
        //    " PL_ACTIF = @PL_ACTIF  "  + this.vapCritere ;
			
        //    this.vapCritere = "";

        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

        //    //Ajout des paramètre à la commande
        //    //vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_FOCUSTIERS);
        //    vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_COMPTECOLLECTIF);
        //    vppSqlCmd.Parameters.Add(vppParamPL_REPORTDEBIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_REPORTCREDIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURS);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURS);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBIT);
        //    vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDIT);
        //    vppSqlCmd.Parameters.Add(vppParamCOMPTAPAR_SENS_CODE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_TYPECOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_ACTIF);
        //    //vppSqlCmd.Parameters.Add(vppParamPL_COMPTEREFERENTIELCOMPTABLE);
        //    clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        //}



        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPlancomptable">clsPlancomptable</param>
        ///<param name="vppCritere">Les critères de modification</param>
        ///<author>Home Technologie</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsPlancomptable clsPlancomptable, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
            vppParamSO_CODESOCIETE.Value = clsPlancomptable.SO_CODESOCIETE;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsPlancomptable.PL_CODENUMCOMPTE;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPlancomptable.PL_NUMCOMPTE;

            SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 25);
            vppParamNC_CODENATURECOMPTE.Value = clsPlancomptable.NC_CODENATURECOMPTE;

            SqlParameter vppParamPL_FOCUSTIERS = new SqlParameter("@PL_FOCUSTIERS", SqlDbType.VarChar, 1);
            vppParamPL_FOCUSTIERS.Value = clsPlancomptable.PL_FOCUSTIERS;

            SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPL_LIBELLE.Value = clsPlancomptable.PL_LIBELLE;

            SqlParameter vppParamPL_COMPTECOLLECTIF = new SqlParameter("@PL_COMPTECOLLECTIF", SqlDbType.VarChar, 25);
            vppParamPL_COMPTECOLLECTIF.Value = clsPlancomptable.PL_COMPTECOLLECTIF;

            SqlParameter vppParamPL_REPORTDEBIT = new SqlParameter("@PL_REPORTDEBIT", SqlDbType.Money);
            vppParamPL_REPORTDEBIT.Value = clsPlancomptable.PL_REPORTDEBIT;

            SqlParameter vppParamPL_REPORTCREDIT = new SqlParameter("@PL_REPORTCREDIT", SqlDbType.Money);
            vppParamPL_REPORTCREDIT.Value = clsPlancomptable.PL_REPORTCREDIT;

            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTDEBIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT;

            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTCREDIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT;

            SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURS = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEDEBITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS;

            SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURS = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODECREDITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS;

            SqlParameter vppParamPL_MONTANTSOLDEFINALDEBIT = new SqlParameter("@PL_MONTANTSOLDEFINALDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALDEBIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT;

            SqlParameter vppParamPL_MONTANTSOLDEFINALCREDIT = new SqlParameter("@PL_MONTANTSOLDEFINALCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALCREDIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT;

            SqlParameter vppParamCOMPTAPAR_SENS_CODE = new SqlParameter("@COMPTAPAR_SENS_CODE", SqlDbType.VarChar, 4);
            vppParamCOMPTAPAR_SENS_CODE.Value = clsPlancomptable.COMPTAPAR_SENS_CODE;

            SqlParameter vppParamPL_TYPECOMPTE = new SqlParameter("@PL_TYPECOMPTE", SqlDbType.VarChar, 1);
            vppParamPL_TYPECOMPTE.Value = clsPlancomptable.PL_TYPECOMPTE;

            SqlParameter vppParamPL_ACTIF = new SqlParameter("@PL_ACTIF", SqlDbType.VarChar, 1);
            vppParamPL_ACTIF.Value = clsPlancomptable.PL_ACTIF;


            SqlParameter vppParamPL_SAISIE_ANALYTIQUE = new SqlParameter("@PL_SAISIE_ANALYTIQUE", SqlDbType.VarChar, 1);
            vppParamPL_SAISIE_ANALYTIQUE.Value = clsPlancomptable.PL_SAISIE_ANALYTIQUE;

            SqlParameter vppParamTS_CODE = new SqlParameter("@TS_CODE", SqlDbType.VarChar, 2);
            vppParamTS_CODE.Value = clsPlancomptable.TS_CODE;

            SqlParameter vppParamPL_NOMBRELIGNE = new SqlParameter("@PL_NOMBRELIGNE", SqlDbType.Int);
            vppParamPL_NOMBRELIGNE.Value = clsPlancomptable.PL_NOMBRELIGNE;



            SqlParameter vppParamPLAN_REPORTING_CODE = new SqlParameter("@PLAN_REPORTING_CODE", SqlDbType.VarChar, 25);
            vppParamPLAN_REPORTING_CODE.Value = clsPlancomptable.PLAN_REPORTING_CODE;

            if (clsPlancomptable.PLAN_REPORTING_CODE == "")
                vppParamPLAN_REPORTING_CODE.Value = DBNull.Value;

            SqlParameter vppParamPL_COMPTEEXCEDANT = new SqlParameter("@PL_COMPTEEXCEDANT", SqlDbType.VarChar, 1);
            vppParamPL_COMPTEEXCEDANT.Value = clsPlancomptable.PL_COMPTEEXCEDANT;

            SqlParameter vppParamPL_COMPTEDEFICIT = new SqlParameter("@PL_COMPTEDEFICIT", SqlDbType.VarChar, 1);
            vppParamPL_COMPTEDEFICIT.Value = clsPlancomptable.PL_COMPTEDEFICIT;

            SqlParameter vppParamPL_AFFICHERSURECRANDROIT = new SqlParameter("@PL_AFFICHERSURECRANDROIT", SqlDbType.VarChar, 1);
            vppParamPL_AFFICHERSURECRANDROIT.Value = clsPlancomptable.PL_AFFICHERSURECRANDROIT;


            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPlancomptable.TYPEOPERATION;

            //SqlParameter vppParamPL_COMPTEREFERENTIELCOMPTABLE = new SqlParameter("@PL_COMPTEREFERENTIELCOMPTABLE", SqlDbType.VarChar, 1);
            //vppParamPL_COMPTEREFERENTIELCOMPTABLE.Value = clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE;

            //pvpChoixCritere2(vppCritere); 

            ////Préparation de la commande
            //this.vapRequete = "UPDATE PLANCOMPTABLE SET " + 
            //" PL_NUMCOMPTE = @PL_NUMCOMPTE , " +
            //" NC_CODENATURECOMPTE = @NC_CODENATURECOMPTE , " +
            //" PL_FOCUSTIERS = @PL_FOCUSTIERS , " + 
            //" PL_LIBELLE = @PL_LIBELLE , " + 
            //" PL_COMPTECOLLECTIF = @PL_COMPTECOLLECTIF , " + 
            //" PL_REPORTDEBIT = @PL_REPORTDEBIT , " + 
            //" PL_REPORTCREDIT = @PL_REPORTCREDIT , " + 
            //" PL_MONTANTPERIODEPRECEDENTDEBIT = @PL_MONTANTPERIODEPRECEDENTDEBIT , " + 
            //" PL_MONTANTPERIODEPRECEDENTCREDIT = @PL_MONTANTPERIODEPRECEDENTCREDIT , " + 
            //" PL_MONTANTPERIODEDEBITENCOURS = @PL_MONTANTPERIODEDEBITENCOURS , " + 
            //" PL_MONTANTPERIODECREDITENCOURS = @PL_MONTANTPERIODECREDITENCOURS , " + 
            //" PL_MONTANTSOLDEFINALDEBIT = @PL_MONTANTSOLDEFINALDEBIT , " + 
            //" PL_MONTANTSOLDEFINALCREDIT = @PL_MONTANTSOLDEFINALCREDIT , " + 
            //" COMPTAPAR_SENS_CODE = @COMPTAPAR_SENS_CODE , " + 
            //" PL_TYPECOMPTE = @PL_TYPECOMPTE , " +
            //" PL_SAISIE_ANALYTIQUE = @PL_SAISIE_ANALYTIQUE , " +
            //" TS_CODE = @TS_CODE , " +
            //" PL_NOMBRELIGNE = @PL_NOMBRELIGNE , " +
            //" PLAN_REPORTING_CODE = @PLAN_REPORTING_CODE , " +
            //" PL_COMPTEEXCEDANT = @PL_COMPTEEXCEDANT , " +
            //" PL_COMPTEDEFICIT = @PL_COMPTEDEFICIT , " +
            //" PL_ACTIF = @PL_ACTIF  "  + this.vapCritere ;

            this.vapRequete = "EXECUTE PC_PLANCOMPTABLE  @PL_CODENUMCOMPTE, @SO_CODESOCIETE, @NC_CODENATURECOMPTE, @PL_NUMCOMPTE, @PL_LIBELLE, @PL_COMPTECOLLECTIF, @PL_REPORTDEBIT, @PL_REPORTCREDIT, @PL_MONTANTPERIODEPRECEDENTDEBIT, @PL_MONTANTPERIODEPRECEDENTCREDIT, @PL_MONTANTPERIODEDEBITENCOURS, @PL_MONTANTPERIODECREDITENCOURS, @PL_MONTANTSOLDEFINALDEBIT, @PL_MONTANTSOLDEFINALCREDIT, @COMPTAPAR_SENS_CODE, @PL_TYPECOMPTE, @PL_ACTIF, @PL_FOCUSTIERS, @PL_SAISIE_ANALYTIQUE, @TS_CODE, @PL_NOMBRELIGNE, @PLAN_REPORTING_CODE, @PL_COMPTEEXCEDANT, @PL_COMPTEDEFICIT,@PL_AFFICHERSURECRANDROIT, @TYPEOPERATION";

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_FOCUSTIERS);
            vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTECOLLECTIF);
            vppSqlCmd.Parameters.Add(vppParamPL_REPORTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_REPORTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDIT);
            vppSqlCmd.Parameters.Add(vppParamCOMPTAPAR_SENS_CODE);
            vppSqlCmd.Parameters.Add(vppParamPL_TYPECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_ACTIF);

            vppSqlCmd.Parameters.Add(vppParamPL_SAISIE_ANALYTIQUE);
            vppSqlCmd.Parameters.Add(vppParamTS_CODE);
            vppSqlCmd.Parameters.Add(vppParamPL_NOMBRELIGNE);

            vppSqlCmd.Parameters.Add(vppParamPLAN_REPORTING_CODE);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTEEXCEDANT);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTEDEFICIT);
            vppSqlCmd.Parameters.Add(vppParamPL_AFFICHERSURECRANDROIT);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            //vppSqlCmd.Parameters.Add(vppParamPL_COMPTEREFERENTIELCOMPTABLE);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere2(vppCritere); 
			this.vapRequete = "DELETE FROM PLANCOMPTABLE " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public void pvgGenerationCpteCollectif(clsDonnee clsDonnee, params string[] vppCritere)
        {

            this.vapRequete = "EXEC PS_CONFIGURATIONCOMPTES";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsPlancomptable </returns>
		///<author>Home Technologie</author>
		public List<clsPlancomptable> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPlancomptable> clsPlancomptables = new List<clsPlancomptable>();

			pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsPlancomptable clsPlancomptable = new clsPlancomptable();
					clsPlancomptable.SO_CODESOCIETE = clsDonnee.vogDataReader["SO_CODESOCIETE"].ToString();
					clsPlancomptable.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPlancomptable.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
					clsPlancomptable.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
					clsPlancomptable.PL_COMPTECOLLECTIF = clsDonnee.vogDataReader["PL_COMPTECOLLECTIF"].ToString();
					clsPlancomptable.PL_REPORTDEBIT =double.Parse(clsDonnee.vogDataReader["PL_REPORTDEBIT"].ToString());
					clsPlancomptable.PL_REPORTCREDIT =double.Parse(clsDonnee.vogDataReader["PL_REPORTCREDIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT =double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT =double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS =double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
					clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS =double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
					clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT =double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
					clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT =double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
					clsPlancomptable.COMPTAPAR_SENS_CODE = clsDonnee.vogDataReader["COMPTAPAR_SENS_CODE"].ToString();
					clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
					clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    //clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
					clsPlancomptables.Add(clsPlancomptable);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlancomptables;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsPlancomptable </returns>
		///<author>Home Technologie</author>
		public List<clsPlancomptable> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPlancomptable> clsPlancomptables = new List<clsPlancomptable>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPlancomptable clsPlancomptable = new clsPlancomptable();
					clsPlancomptable.SO_CODESOCIETE = Dataset.Tables["TABLE"].Rows[Idx]["SO_CODESOCIETE"].ToString();
					clsPlancomptable.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsPlancomptable.PL_NUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_NUMCOMPTE"].ToString();
					clsPlancomptable.PL_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PL_LIBELLE"].ToString();
					clsPlancomptable.PL_COMPTECOLLECTIF = Dataset.Tables["TABLE"].Rows[Idx]["PL_COMPTECOLLECTIF"].ToString();
					clsPlancomptable.PL_REPORTDEBIT =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_REPORTDEBIT"].ToString());
					clsPlancomptable.PL_REPORTCREDIT =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_REPORTCREDIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
					clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
					clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODECREDITENCOURS"].ToString());
					clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALDEBIT"].ToString());
					clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALCREDIT"].ToString());
					clsPlancomptable.COMPTAPAR_SENS_CODE = Dataset.Tables["TABLE"].Rows[Idx]["COMPTAPAR_SENS_CODE"].ToString();
					clsPlancomptable.PL_TYPECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_TYPECOMPTE"].ToString();
					clsPlancomptable.PL_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["PL_ACTIF"].ToString();
                    //clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = Dataset.Tables["TABLE"].Rows[Idx]["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
					clsPlancomptables.Add(clsPlancomptable);
				}
				Dataset.Dispose();
			}
			return clsPlancomptables;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE ";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetCompteAdditionnel(clsDonnee clsDonnee ,params string[] vppCritere)
        {
            //pvpChoixCritere1(vppCritere);

            this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND TP_CODETYPETIERS LIKE '%' +@TP_CODETYPETIERS+'%'  AND TC_CODECOMPTETYPETIERS LIKE '%' +@TC_CODECOMPTETYPETIERS+'%' ";
            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@TP_CODETYPETIERS", "@TC_CODECOMPTETYPETIERS" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4]};

            this.vapRequete = "SELECT * FROM VUE_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
	        this.vapCritere = ""; 
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetCompteAdditionnelTiers(clsDonnee clsDonnee ,params string[] vppCritere)
        {
            //pvpChoixCritere1(vppCritere);

            //this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND TP_CODETYPETIERS LIKE '%' +@TP_CODETYPETIERS+'%' AND TC_CODECOMPTETYPETIERS LIKE '%' +@TC_CODECOMPTETYPETIERS+'%'  AND TI_IDTIERSPRINCIPAL=@TI_IDTIERSPRINCIPAL ";
            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@TP_CODETYPETIERS", "@TC_CODECOMPTETYPETIERS", "@TI_IDTIERSPRINCIPAL", "@ECRAN", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], clsDonnee.vogCleCryptage };
            //if (vppCritere[6]=="APPRO")
            //{
            //    this.vapRequete = "SELECT DISTINCT  PL_CODENUMCOMPTE, PL_NUMCOMPTE,CAST(DECRYPTBYPASSPHRASE( '" +clsDonnee.vogCleCryptage+"',TI_DENOMINATION) AS varchar(150))   AS PL_LIBELLE, NC_CODENATURECOMPTE, PL_FOCUSTIERS FROM VUE_PHATIERSCOMPTERATTACHEADDITIONNEL " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";  
            //}
            //else
            this.vapRequete = "EXEC PS_COMPTEADDITIONNELTIERS @SO_CODESOCIETE,@PL_NUMCOMPTE,@PL_TYPECOMPTE,@TP_CODETYPETIERS,@TC_CODECOMPTETYPETIERS,@TI_IDTIERSPRINCIPAL,@ECRAN,@CODECRYPTAGE   ";
	        this.vapCritere = ""; 
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee ,params string[] vppCritere)
        {
        pvpChoixCritere1(vppCritere);
        this.vapRequete = "SELECT * FROM VUE_PLANCOMPTABLE " + this.vapCritere + "   ORDER BY PL_NUMCOMPTE";
        this.vapCritere = ""; 
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetTousLesComptes(clsDonnee clsDonnee ,params string[] vppCritere)
        {
        pvpChoixCritere4(vppCritere);
        this.vapRequete = "SELECT   * FROM VUE_PLANCOMPTABLE " + this.vapCritere + "   ORDER BY PL_NUMCOMPTE  ";
        this.vapCritere = ""; 
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetComptesCollectifs(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(vppCritere);
            //this.vapRequete = "SELECT * FROM VUE_PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' AND PL_TYPECOMPTE = 'C' ORDER BY PL_NUMCOMPTE";
            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE"};
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
            this.vapRequete = " EXEC  [dbo].[PS_PLANCOMPTABLECOMPTECOLLECTIF] @SO_CODESOCIETE,@PL_NUMCOMPTE";

            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetComptesAConfigurer(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' AND (ISNULL(PL_COMPTECOLLECTIF,'')='')  ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


       

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetCpteCharge(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_PHAFAMILLEOPERATIONCOMPTEPLANCOMPTABLE ";// + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetOperation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere1(vppCritere);

            //this.vapCritere = " WHERE @FO_CODEFAMILLEOPERATION=@SO_CODESOCIETE ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@FO_CODEFAMILLEOPERATION", "@NF_CODENATUREFAMILLEOPERATION" };
                    vapValeurParametre = new object[] { vppCritere[0],vppCritere[1] ,vppCritere[2] ,vppCritere[3] };

                    this.vapRequete = "EXEC [dbo].[PS_PHAFAMILLEOPERATIONCOMPTEPLANCOMPTABLE]  @AG_CODEAGENCE,@OP_CODEOPERATEUR,@FO_CODEFAMILLEOPERATION,@NF_CODENATUREFAMILLEOPERATION ";// +this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetControlCompte(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere1(vppCritere);

            //this.vapCritere = " WHERE @FO_CODEFAMILLEOPERATION=@SO_CODESOCIETE ";
            vapNomParametre = new string[] { "@PL_NUMCOMPTEGENERAL", "@TI_NUMTIERS", "@NC_CODENATURECOMPTE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2],clsDonnee.vogCleCryptage };

            this.vapRequete = "EXEC [dbo].[PS_CONTROLSELECTIONCOMPTE]  @PL_NUMCOMPTEGENERAL,@TI_NUMTIERS,@NC_CODENATURECOMPTE,@CODECRYPTAGE";// +this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetControlNatureCompte(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere1(vppCritere);
            DataSet DataSet=new DataSet();
            //this.veapCritere = " WHERE @FO_CODEFAMILLEOPERATION=@SO_CODESOCIETE ";
            vapNomParametre = new string[] { "@PL_NUMCOMPTE",  "@NC_CODENATURECOMPTE"};
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };

            this.vapRequete = "EXEC [dbo].[PS_CONTROLENATURECOMPTE]  @PL_NUMCOMPTE,@NC_CODENATURECOMPTE";// +this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

             //return DataSet;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetComptesIndividuels(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(vppCritere);
            this.vapRequete = "SELECT PL_CODENUMCOMPTE, PL_NUMCOMPTE, PL_LIBELLE FROM VUE_PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' AND PL_TYPECOMPTE = 'I' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT PL_CODENUMCOMPTE,PL_NUMCOMPTE,PL_LIBELLE FROM PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourComboComptesCollectif(clsDonnee clsDonnee ,params string[] vppCritere)
        {
        this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  NC_CODENATURECOMPTE= @NC_CODENATURECOMPTE AND PL_TYPECOMPTE=@PL_TYPECOMPTE";
        vapNomParametre = new string[] { "@SO_CODESOCIETE", "@NC_CODENATURECOMPTE", "@PL_TYPECOMPTE" };
        vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
        this.vapRequete = "SELECT PL_CODENUMCOMPTE,PL_NUMCOMPTE,PL_LIBELLE FROM PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
        this.vapCritere = ""; 
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			{
				case 0:
					this.vapCritere ="" ;
					vapNomParametre = new string[]{  };
					vapValeurParametre = new object[]{  };
					break ;				
				case 1:
					this.vapCritere =" WHERE SO_CODESOCIETE=@SO_CODESOCIETE "; 
					vapNomParametre = new string[]{ "@SO_CODESOCIETE" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
				case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
					vapValeurParametre = new object[]{ vppCritere[0], vppCritere[1] };
					break ;
                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE AND PL_TYPECOMPTE=@PL_TYPECOMPTE  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;	
                case 4:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND PL_ACTIF=@PL_ACTIF ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@PL_ACTIF" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3]};
                    break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {

                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND PL_TYPECOMPTE='I' ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%'";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%'  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3]};
                break;

                case 5:
                this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE IN('03','04','08') ";
                vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                break;

                case 6:
                    if(vppCritere[1]=="")
                        this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE IN('01','02') ";
                    else
                        this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere2(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_CODENUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere3(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {

                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    //this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND PL_TYPECOMPTE='I' ";
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%'";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%'  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere4(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {

                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%'";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%'  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

                case 5:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE IN('03','04','08') ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 6:
                    if (vppCritere[1] == "")
                        this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE IN('01','02') ";
                    else
                        this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

            }
        }

        /////<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        /////<param name="vppCritere">Les critères de la requète</param>
        /////<author>Home Technologie</author>
        //public void pvpChoixCritereAvecSolde(params string[] vppCritere)
        //{
        //    switch (vppCritere.Length)
        //    {
        //        case 0:
        //            this.vapCritere = "";
        //            vapNomParametre = new string[] { };
        //            vapValeurParametre = new object[] { };
        //            break;
        //        case 1:
        //            this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
        //            vapNomParametre = new string[] { "@SO_CODESOCIETE" };
        //            vapValeurParametre = new object[] { vppCritere[0] };
        //            break;
        //        case 2:
        //        case 3:
        //        case 4:
        //            this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE ";
        //            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
        //            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
        //            break;
        //    }
        //}


    }
}