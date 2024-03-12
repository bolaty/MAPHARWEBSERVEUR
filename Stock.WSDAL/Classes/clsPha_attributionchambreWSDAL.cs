using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPha_attributionchambreWSDAL: ITableDAL<clsPha_attributionchambre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(TI_IDATTRIBUTION) AS TI_IDATTRIBUTION  FROM dbo.PHA_ATTRIBUTIONCHAMBRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCountVerificationOccupationChambre(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(TI_IDATTRIBUTION) AS TI_IDATTRIBUTION  FROM PHA_ATTRIBUTIONCHAMBRE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(TI_IDATTRIBUTION) AS TI_IDATTRIBUTION  FROM dbo.PHA_ATTRIBUTIONCHAMBRE" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(TI_IDATTRIBUTION) AS TI_IDATTRIBUTION  FROM dbo.PHA_ATTRIBUTIONCHAMBRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPha_attributionchambre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPha_attributionchambre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT TI_IDATTRIBUTION  , TI_IDTIERS  , AR_CODEARTICLE  , PI_CODEPIECE  , PY_CODEPAYS  , AT_NUMPIECE  , AT_DATEETABLISSEMENTPIECE  , AT_LIEUETABLISSEMENTPIECE  , AT_EMETTEURPIECE  , AT_DATEENTREENATIONALE  , AT_DATEDEPARTNATIONALE  , AT_DATEDEBUT  , AT_DATEFIN  , AT_DATECLOTURE  FROM dbo.FT_PHA_ATTRIBUTIONCHAMBRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPha_attributionchambre clsPha_attributionchambre = new clsPha_attributionchambre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
                {
                    clsPha_attributionchambre.TI_IDATTRIBUTION = clsDonnee.vogDataReader["TI_IDATTRIBUTION"].ToString();
					clsPha_attributionchambre.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPha_attributionchambre.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPha_attributionchambre.PI_CODEPIECE = clsDonnee.vogDataReader["PI_CODEPIECE"].ToString();
					clsPha_attributionchambre.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
					clsPha_attributionchambre.AT_NUMPIECE = clsDonnee.vogDataReader["AT_NUMPIECE"].ToString();
					clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEETABLISSEMENTPIECE"].ToString());
					clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE = clsDonnee.vogDataReader["AT_LIEUETABLISSEMENTPIECE"].ToString();
					clsPha_attributionchambre.AT_EMETTEURPIECE = clsDonnee.vogDataReader["AT_EMETTEURPIECE"].ToString();
					clsPha_attributionchambre.AT_DATEENTREENATIONALE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEENTREENATIONALE"].ToString());
					clsPha_attributionchambre.AT_DATEDEPARTNATIONALE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEDEPARTNATIONALE"].ToString());
					clsPha_attributionchambre.AT_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEDEBUT"].ToString());
					clsPha_attributionchambre.AT_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEFIN"].ToString());
                    //clsPha_attributionchambre.AT_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATECLOTURE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPha_attributionchambre;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPha_attributionchambre comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<clsPha_attributionchambre> pvgTableLabelListe(clsDonnee clsDonnee, params string[] vppCritere)
        {
        pvpChoixCritere(clsDonnee ,vppCritere);


        List<clsPha_attributionchambre> clsPha_attributionchambres = new List<clsPha_attributionchambre>();
        DataSet Dataset = new DataSet();

        this.vapRequete = "SELECT TI_IDATTRIBUTION  , TI_IDTIERS  , AR_CODEARTICLE  , PI_CODEPIECE  , PY_CODEPAYS  , AT_NUMPIECE  , AT_DATEETABLISSEMENTPIECE  , AT_LIEUETABLISSEMENTPIECE  , AT_EMETTEURPIECE  , AT_DATEENTREENATIONALE  , AT_DATEDEPARTNATIONALE  , AT_DATEDEBUT  , AT_DATEFIN  , AT_DATECLOTURE  FROM dbo.FT_PHA_ATTRIBUTIONCHAMBRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
        this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
        

 if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
    {

        for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
        {
            clsPha_attributionchambre clsPha_attributionchambre = new clsPha_attributionchambre();


            clsPha_attributionchambre.TI_IDATTRIBUTION = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDATTRIBUTION"].ToString();
            clsPha_attributionchambre.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
            clsPha_attributionchambre.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
            clsPha_attributionchambre.PI_CODEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["PI_CODEPIECE"].ToString();
            clsPha_attributionchambre.PY_CODEPAYS = Dataset.Tables["TABLE"].Rows[Idx]["PY_CODEPAYS"].ToString();
            clsPha_attributionchambre.AT_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["AT_NUMPIECE"].ToString();
            clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEETABLISSEMENTPIECE"].ToString());
            clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE = Dataset.Tables["TABLE"].Rows[Idx]["AT_LIEUETABLISSEMENTPIECE"].ToString();
            clsPha_attributionchambre.AT_EMETTEURPIECE = Dataset.Tables["TABLE"].Rows[Idx]["AT_EMETTEURPIECE"].ToString();
            clsPha_attributionchambre.AT_DATEENTREENATIONALE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEENTREENATIONALE"].ToString());
            clsPha_attributionchambre.AT_DATEDEPARTNATIONALE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEDEPARTNATIONALE"].ToString());
            clsPha_attributionchambre.AT_DATEDEBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEDEBUT"].ToString());
            clsPha_attributionchambre.AT_DATEFIN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEFIN"].ToString());
            clsPha_attributionchambres.Add(clsPha_attributionchambre);
        }

        Dataset.Dispose();

    }

 return clsPha_attributionchambres;
    }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPha_attributionchambre comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPha_attributionchambre pvgTableLabelPeriodeDerniereOccupation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TOP 1 TI_IDATTRIBUTION  , TI_IDTIERS  , AR_CODEARTICLE  , PI_CODEPIECE  , PY_CODEPAYS  ,  AT_DATEETABLISSEMENTPIECE    , AT_DATEENTREENATIONALE  , AT_DATEDEPARTNATIONALE  , AT_DATEDEBUT  , AT_DATEFIN  , AT_DATECLOTURE  FROM dbo.PHA_ATTRIBUTIONCHAMBRE " + this.vapCritere + " ORDER BY TI_IDATTRIBUTION DESC";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsPha_attributionchambre clsPha_attributionchambre = new clsPha_attributionchambre();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPha_attributionchambre.TI_IDATTRIBUTION = clsDonnee.vogDataReader["TI_IDATTRIBUTION"].ToString();
                    clsPha_attributionchambre.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
                    clsPha_attributionchambre.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPha_attributionchambre.PI_CODEPIECE = clsDonnee.vogDataReader["PI_CODEPIECE"].ToString();
                    clsPha_attributionchambre.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
                    //clsPha_attributionchambre.AT_NUMPIECE = clsDonnee.vogDataReader["AT_NUMPIECE"].ToString();
                    clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEETABLISSEMENTPIECE"].ToString());
                    //clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE = clsDonnee.vogDataReader["AT_LIEUETABLISSEMENTPIECE"].ToString();
                    //clsPha_attributionchambre.AT_EMETTEURPIECE = clsDonnee.vogDataReader["AT_EMETTEURPIECE"].ToString();
                    clsPha_attributionchambre.AT_DATEENTREENATIONALE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEENTREENATIONALE"].ToString());
                    clsPha_attributionchambre.AT_DATEDEPARTNATIONALE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEDEPARTNATIONALE"].ToString());
                    clsPha_attributionchambre.AT_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEDEBUT"].ToString());
                    clsPha_attributionchambre.AT_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEFIN"].ToString());
                    clsPha_attributionchambre.AT_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATECLOTURE"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPha_attributionchambre;
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPha_attributionchambre>clsPha_attributionchambre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPha_attributionchambre clsPha_attributionchambre)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPha_attributionchambre.AG_CODEAGENCE;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPha_attributionchambre.MS_NUMPIECE;
			SqlParameter vppParamTI_IDATTRIBUTION = new SqlParameter("@TI_IDATTRIBUTION", SqlDbType.VarChar, 25);
			vppParamTI_IDATTRIBUTION.Value  = clsPha_attributionchambre.TI_IDATTRIBUTION ;
			SqlParameter vppParamAT_DATESAISIE = new SqlParameter("@AT_DATESAISIE", SqlDbType.DateTime);
			vppParamAT_DATESAISIE.Value  = clsPha_attributionchambre.AT_DATESAISIE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERS.Value  = clsPha_attributionchambre.TI_IDTIERS ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPha_attributionchambre.AR_CODEARTICLE ;
			SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
			vppParamPI_CODEPIECE.Value  = clsPha_attributionchambre.PI_CODEPIECE ;
			SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 4);
			vppParamPY_CODEPAYS.Value  = clsPha_attributionchambre.PY_CODEPAYS ;
            if (clsPha_attributionchambre.PY_CODEPAYS == "")
                vppParamPY_CODEPAYS.Value = DBNull.Value;
			SqlParameter vppParamAT_NUMPIECE = new SqlParameter("@AT_NUMPIECE", SqlDbType.VarChar, 7000);
			vppParamAT_NUMPIECE.Value  = clsPha_attributionchambre.AT_NUMPIECE ;
			SqlParameter vppParamAT_DATEETABLISSEMENTPIECE = new SqlParameter("@AT_DATEETABLISSEMENTPIECE", SqlDbType.DateTime);
			vppParamAT_DATEETABLISSEMENTPIECE.Value  = clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE ;
			SqlParameter vppParamAT_LIEUETABLISSEMENTPIECE = new SqlParameter("@AT_LIEUETABLISSEMENTPIECE", SqlDbType.VarChar, 7000);
			vppParamAT_LIEUETABLISSEMENTPIECE.Value  = clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE ;
			SqlParameter vppParamAT_EMETTEURPIECE = new SqlParameter("@AT_EMETTEURPIECE", SqlDbType.VarChar, 7000);
			vppParamAT_EMETTEURPIECE.Value  = clsPha_attributionchambre.AT_EMETTEURPIECE ;
			SqlParameter vppParamAT_DATEENTREENATIONALE = new SqlParameter("@AT_DATEENTREENATIONALE", SqlDbType.DateTime);
			vppParamAT_DATEENTREENATIONALE.Value  = clsPha_attributionchambre.AT_DATEENTREENATIONALE ;
            if (clsPha_attributionchambre.AT_DATEENTREENATIONALE.ToShortDateString() == "01/01/0001") vppParamAT_DATEENTREENATIONALE.Value = DateTime.Parse("01/01/1900");

			SqlParameter vppParamAT_DATEDEPARTNATIONALE = new SqlParameter("@AT_DATEDEPARTNATIONALE", SqlDbType.DateTime);
			vppParamAT_DATEDEPARTNATIONALE.Value  = clsPha_attributionchambre.AT_DATEDEPARTNATIONALE ;
            if (clsPha_attributionchambre.AT_DATEDEPARTNATIONALE.ToShortDateString() == "01/01/0001") vppParamAT_DATEDEPARTNATIONALE.Value = DateTime.Parse("01/01/1900");

			SqlParameter vppParamAT_DATEDEBUT = new SqlParameter("@AT_DATEDEBUT", SqlDbType.DateTime);
			vppParamAT_DATEDEBUT.Value  = clsPha_attributionchambre.AT_DATEDEBUT ;
			SqlParameter vppParamAT_DATEFIN = new SqlParameter("@AT_DATEFIN", SqlDbType.DateTime);
			vppParamAT_DATEFIN.Value  = clsPha_attributionchambre.AT_DATEFIN ;
			SqlParameter vppParamAT_DATECLOTURE = new SqlParameter("@AT_DATECLOTURE", SqlDbType.DateTime);
			vppParamAT_DATECLOTURE.Value  = clsPha_attributionchambre.AT_DATECLOTURE ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPha_attributionchambre.OP_CODEOPERATEUR;

			if(clsPha_attributionchambre.AT_DATECLOTURE.Year < 1900 ) vppParamAT_DATECLOTURE.Value  = DateTime.Parse("01/01/1900");
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHA_ATTRIBUTIONCHAMBRE  @AG_CODEAGENCE,@MS_NUMPIECE,@TI_IDATTRIBUTION, @AT_DATESAISIE, @TI_IDTIERS, @AR_CODEARTICLE, @PI_CODEPIECE, @PY_CODEPAYS, @AT_NUMPIECE, @AT_DATEETABLISSEMENTPIECE, @AT_LIEUETABLISSEMENTPIECE, @AT_EMETTEURPIECE, @AT_DATEENTREENATIONALE, @AT_DATEDEPARTNATIONALE, @AT_DATEDEBUT, @AT_DATEFIN, @AT_DATECLOTURE,@OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDATTRIBUTION);
			vppSqlCmd.Parameters.Add(vppParamAT_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
			vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
			vppSqlCmd.Parameters.Add(vppParamAT_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATEETABLISSEMENTPIECE);
			vppSqlCmd.Parameters.Add(vppParamAT_LIEUETABLISSEMENTPIECE);
			vppSqlCmd.Parameters.Add(vppParamAT_EMETTEURPIECE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATEENTREENATIONALE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATEDEPARTNATIONALE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATEDEBUT);
			vppSqlCmd.Parameters.Add(vppParamAT_DATEFIN);
			vppSqlCmd.Parameters.Add(vppParamAT_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}























        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPha_attributionchambre>clsPha_attributionchambre</param>
        ///<author>Home Technology</author>
        public string pvgMiseAjours(clsDonnee clsDonnee, clsPha_attributionchambre clsPha_attributionchambre)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPha_attributionchambre.AG_CODEAGENCE;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPha_attributionchambre.MS_NUMPIECE;
            SqlParameter vppParamTI_IDATTRIBUTION = new SqlParameter("@TI_IDATTRIBUTION", SqlDbType.VarChar, 25);
            vppParamTI_IDATTRIBUTION.Value = clsPha_attributionchambre.TI_IDATTRIBUTION;
            SqlParameter vppParamAT_DATESAISIE = new SqlParameter("@AT_DATESAISIE", SqlDbType.DateTime);
            vppParamAT_DATESAISIE.Value = clsPha_attributionchambre.AT_DATESAISIE;
            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
            vppParamTI_IDTIERS.Value = clsPha_attributionchambre.TI_IDTIERS;
            SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
            vppParamAR_CODEARTICLE.Value = clsPha_attributionchambre.AR_CODEARTICLE;
            SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
            vppParamPI_CODEPIECE.Value = clsPha_attributionchambre.PI_CODEPIECE;
            if (clsPha_attributionchambre.PI_CODEPIECE == "")
                vppParamPI_CODEPIECE.Value = DBNull.Value;

            SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 4);

            vppParamPY_CODEPAYS.Value = clsPha_attributionchambre.PY_CODEPAYS;
            if (clsPha_attributionchambre.PY_CODEPAYS == "")
                vppParamPY_CODEPAYS.Value = DBNull.Value;
            SqlParameter vppParamAT_NUMPIECE = new SqlParameter("@AT_NUMPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_NUMPIECE.Value = clsPha_attributionchambre.AT_NUMPIECE;
            SqlParameter vppParamAT_DATEETABLISSEMENTPIECE = new SqlParameter("@AT_DATEETABLISSEMENTPIECE", SqlDbType.DateTime);
            vppParamAT_DATEETABLISSEMENTPIECE.Value = clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE;
            SqlParameter vppParamAT_LIEUETABLISSEMENTPIECE = new SqlParameter("@AT_LIEUETABLISSEMENTPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_LIEUETABLISSEMENTPIECE.Value = clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE;
            SqlParameter vppParamAT_EMETTEURPIECE = new SqlParameter("@AT_EMETTEURPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_EMETTEURPIECE.Value = clsPha_attributionchambre.AT_EMETTEURPIECE;
            SqlParameter vppParamAT_DATEENTREENATIONALE = new SqlParameter("@AT_DATEENTREENATIONALE", SqlDbType.DateTime);
            vppParamAT_DATEENTREENATIONALE.Value = clsPha_attributionchambre.AT_DATEENTREENATIONALE;
            if (clsPha_attributionchambre.AT_DATEENTREENATIONALE.ToShortDateString() == "01/01/0001") vppParamAT_DATEENTREENATIONALE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAT_DATEDEPARTNATIONALE = new SqlParameter("@AT_DATEDEPARTNATIONALE", SqlDbType.DateTime);
            vppParamAT_DATEDEPARTNATIONALE.Value = clsPha_attributionchambre.AT_DATEDEPARTNATIONALE;
            if (clsPha_attributionchambre.AT_DATEDEPARTNATIONALE.ToShortDateString() == "01/01/0001") vppParamAT_DATEDEPARTNATIONALE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAT_DATEDEBUT = new SqlParameter("@AT_DATEDEBUT", SqlDbType.DateTime);
            vppParamAT_DATEDEBUT.Value = clsPha_attributionchambre.AT_DATEDEBUT;
            SqlParameter vppParamAT_DATEFIN = new SqlParameter("@AT_DATEFIN", SqlDbType.DateTime);
            vppParamAT_DATEFIN.Value = clsPha_attributionchambre.AT_DATEFIN;
            SqlParameter vppParamAT_DATECLOTURE = new SqlParameter("@AT_DATECLOTURE", SqlDbType.DateTime);
            vppParamAT_DATECLOTURE.Value = clsPha_attributionchambre.AT_DATECLOTURE;


            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPha_attributionchambre.OP_CODEOPERATEUR;

            if (clsPha_attributionchambre.AT_DATECLOTURE.Year < 1900) vppParamAT_DATECLOTURE.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPha_attributionchambre.TYPEOPERATION;


            SqlParameter vppParamTI_IDATTRIBUTIONRETOUR = new SqlParameter("@TI_IDATTRIBUTIONRETOUR", SqlDbType.VarChar, 50);

            SqlCommand vppSqlCmd = new SqlCommand("PC_PHA_ATTRIBUTIONCHAMBRE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            ////Préparation de la commande
            //this.vapRequete = "EXECUTE PC_PHA_ATTRIBUTIONCHAMBRE  @AG_CODEAGENCE,@MS_NUMPIECE,@TI_IDATTRIBUTION, @AT_DATESAISIE, @TI_IDTIERS, @AR_CODEARTICLE, @PI_CODEPIECE, @PY_CODEPAYS, @AT_NUMPIECE, @AT_DATEETABLISSEMENTPIECE, @AT_LIEUETABLISSEMENTPIECE, @AT_EMETTEURPIECE, @AT_DATEENTREENATIONALE, @AT_DATEDEPARTNATIONALE, @AT_DATEDEBUT, @AT_DATEFIN, @AT_DATECLOTURE, @CODECRYPTAGE, 0 ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDATTRIBUTION);
            vppSqlCmd.Parameters.Add(vppParamAT_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
            vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
            vppSqlCmd.Parameters.Add(vppParamAT_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEETABLISSEMENTPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_LIEUETABLISSEMENTPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_EMETTEURPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEENTREENATIONALE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEDEPARTNATIONALE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamAT_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);

            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            vppSqlCmd.Parameters.Add(vppParamTI_IDATTRIBUTIONRETOUR);
            vppParamTI_IDATTRIBUTIONRETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@TI_IDATTRIBUTIONRETOUR"].Value.ToString();


            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }













		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPha_attributionchambre>clsPha_attributionchambre</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPha_attributionchambre clsPha_attributionchambre,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPha_attributionchambre.AG_CODEAGENCE;
            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE1", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPha_attributionchambre.MS_NUMPIECE;
            SqlParameter vppParamTI_IDATTRIBUTION = new SqlParameter("@TI_IDATTRIBUTION1", SqlDbType.VarChar, 25);
            vppParamTI_IDATTRIBUTION.Value = clsPha_attributionchambre.TI_IDATTRIBUTION;
            SqlParameter vppParamAT_DATESAISIE = new SqlParameter("@AT_DATESAISIE", SqlDbType.DateTime);
            vppParamAT_DATESAISIE.Value = clsPha_attributionchambre.AT_DATESAISIE;
            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
            vppParamTI_IDTIERS.Value = clsPha_attributionchambre.TI_IDTIERS;
            SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
            vppParamAR_CODEARTICLE.Value = clsPha_attributionchambre.AR_CODEARTICLE;
            SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
            vppParamPI_CODEPIECE.Value = clsPha_attributionchambre.PI_CODEPIECE;
            SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 4);
            vppParamPY_CODEPAYS.Value = clsPha_attributionchambre.PY_CODEPAYS;
            if (clsPha_attributionchambre.PY_CODEPAYS == "")
                vppParamPY_CODEPAYS.Value = DBNull.Value;
            SqlParameter vppParamAT_NUMPIECE = new SqlParameter("@AT_NUMPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_NUMPIECE.Value = clsPha_attributionchambre.AT_NUMPIECE;
            SqlParameter vppParamAT_DATEETABLISSEMENTPIECE = new SqlParameter("@AT_DATEETABLISSEMENTPIECE", SqlDbType.DateTime);
            vppParamAT_DATEETABLISSEMENTPIECE.Value = clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE;
            SqlParameter vppParamAT_LIEUETABLISSEMENTPIECE = new SqlParameter("@AT_LIEUETABLISSEMENTPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_LIEUETABLISSEMENTPIECE.Value = clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE;
            SqlParameter vppParamAT_EMETTEURPIECE = new SqlParameter("@AT_EMETTEURPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_EMETTEURPIECE.Value = clsPha_attributionchambre.AT_EMETTEURPIECE;
            SqlParameter vppParamAT_DATEENTREENATIONALE = new SqlParameter("@AT_DATEENTREENATIONALE", SqlDbType.DateTime);
            vppParamAT_DATEENTREENATIONALE.Value = clsPha_attributionchambre.AT_DATEENTREENATIONALE;
            if (clsPha_attributionchambre.AT_DATEENTREENATIONALE.ToShortDateString() == "01/01/0001") vppParamAT_DATEENTREENATIONALE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAT_DATEDEPARTNATIONALE = new SqlParameter("@AT_DATEDEPARTNATIONALE", SqlDbType.DateTime);
            vppParamAT_DATEDEPARTNATIONALE.Value = clsPha_attributionchambre.AT_DATEDEPARTNATIONALE;
            if (clsPha_attributionchambre.AT_DATEDEPARTNATIONALE.ToShortDateString() == "01/01/0001") vppParamAT_DATEDEPARTNATIONALE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAT_DATEDEBUT = new SqlParameter("@AT_DATEDEBUT", SqlDbType.DateTime);
            vppParamAT_DATEDEBUT.Value = clsPha_attributionchambre.AT_DATEDEBUT;
            SqlParameter vppParamAT_DATEFIN = new SqlParameter("@AT_DATEFIN", SqlDbType.DateTime);
            vppParamAT_DATEFIN.Value = clsPha_attributionchambre.AT_DATEFIN;
            SqlParameter vppParamAT_DATECLOTURE = new SqlParameter("@AT_DATECLOTURE", SqlDbType.DateTime);
            vppParamAT_DATECLOTURE.Value = clsPha_attributionchambre.AT_DATECLOTURE;


            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPha_attributionchambre.OP_CODEOPERATEUR;


            if (clsPha_attributionchambre.AT_DATECLOTURE.Year < 1900) vppParamAT_DATECLOTURE.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHA_ATTRIBUTIONCHAMBRE  @AG_CODEAGENCE1,@MS_NUMPIECE1,@TI_IDATTRIBUTION1, @AT_DATESAISIE, @TI_IDTIERS, @AR_CODEARTICLE, @PI_CODEPIECE, @PY_CODEPAYS, @AT_NUMPIECE, @AT_DATEETABLISSEMENTPIECE, @AT_LIEUETABLISSEMENTPIECE, @AT_EMETTEURPIECE, @AT_DATEENTREENATIONALE, @AT_DATEDEPARTNATIONALE, @AT_DATEDEBUT, @AT_DATEFIN, @AT_DATECLOTURE,@OP_CODEOPERATEUR, @CODECRYPTAGE1, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDATTRIBUTION);
            vppSqlCmd.Parameters.Add(vppParamAT_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
            vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
            vppSqlCmd.Parameters.Add(vppParamAT_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEETABLISSEMENTPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_LIEUETABLISSEMENTPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_EMETTEURPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEENTREENATIONALE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEDEPARTNATIONALE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamAT_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}




        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPha_attributionchambre>clsPha_attributionchambre</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate1(clsDonnee clsDonnee, clsPha_attributionchambre clsPha_attributionchambre, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPha_attributionchambre.AG_CODEAGENCE;
            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE1", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPha_attributionchambre.MS_NUMPIECE;
            SqlParameter vppParamTI_IDATTRIBUTION = new SqlParameter("@TI_IDATTRIBUTION1", SqlDbType.VarChar, 25);
            vppParamTI_IDATTRIBUTION.Value = clsPha_attributionchambre.TI_IDATTRIBUTION;
            SqlParameter vppParamAT_DATESAISIE = new SqlParameter("@AT_DATESAISIE", SqlDbType.DateTime);
            vppParamAT_DATESAISIE.Value = clsPha_attributionchambre.AT_DATESAISIE;
            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
            vppParamTI_IDTIERS.Value = clsPha_attributionchambre.TI_IDTIERS;
            SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
            vppParamAR_CODEARTICLE.Value = clsPha_attributionchambre.AR_CODEARTICLE;
            SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
            vppParamPI_CODEPIECE.Value = clsPha_attributionchambre.PI_CODEPIECE;
            SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 4);
            vppParamPY_CODEPAYS.Value = clsPha_attributionchambre.PY_CODEPAYS;
            if (clsPha_attributionchambre.PY_CODEPAYS == "")
                vppParamPY_CODEPAYS.Value = DBNull.Value;
            SqlParameter vppParamAT_NUMPIECE = new SqlParameter("@AT_NUMPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_NUMPIECE.Value = clsPha_attributionchambre.AT_NUMPIECE;
            SqlParameter vppParamAT_DATEETABLISSEMENTPIECE = new SqlParameter("@AT_DATEETABLISSEMENTPIECE", SqlDbType.DateTime);
            vppParamAT_DATEETABLISSEMENTPIECE.Value = clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE;
            SqlParameter vppParamAT_LIEUETABLISSEMENTPIECE = new SqlParameter("@AT_LIEUETABLISSEMENTPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_LIEUETABLISSEMENTPIECE.Value = clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE;
            SqlParameter vppParamAT_EMETTEURPIECE = new SqlParameter("@AT_EMETTEURPIECE", SqlDbType.VarChar, 7000);
            vppParamAT_EMETTEURPIECE.Value = clsPha_attributionchambre.AT_EMETTEURPIECE;
            SqlParameter vppParamAT_DATEENTREENATIONALE = new SqlParameter("@AT_DATEENTREENATIONALE", SqlDbType.DateTime);
            vppParamAT_DATEENTREENATIONALE.Value = clsPha_attributionchambre.AT_DATEENTREENATIONALE;
            if (clsPha_attributionchambre.AT_DATEENTREENATIONALE.ToShortDateString() == "01/01/0001") vppParamAT_DATEENTREENATIONALE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAT_DATEDEPARTNATIONALE = new SqlParameter("@AT_DATEDEPARTNATIONALE", SqlDbType.DateTime);
            vppParamAT_DATEDEPARTNATIONALE.Value = clsPha_attributionchambre.AT_DATEDEPARTNATIONALE;
            if (clsPha_attributionchambre.AT_DATEDEPARTNATIONALE.ToShortDateString() == "01/01/0001") vppParamAT_DATEDEPARTNATIONALE.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamAT_DATEDEBUT = new SqlParameter("@AT_DATEDEBUT", SqlDbType.DateTime);
            vppParamAT_DATEDEBUT.Value = clsPha_attributionchambre.AT_DATEDEBUT;
            SqlParameter vppParamAT_DATEFIN = new SqlParameter("@AT_DATEFIN", SqlDbType.DateTime);
            vppParamAT_DATEFIN.Value = clsPha_attributionchambre.AT_DATEFIN;
            SqlParameter vppParamAT_DATECLOTURE = new SqlParameter("@AT_DATECLOTURE", SqlDbType.DateTime);
            vppParamAT_DATECLOTURE.Value = clsPha_attributionchambre.AT_DATECLOTURE;


            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPha_attributionchambre.OP_CODEOPERATEUR;


            if (clsPha_attributionchambre.AT_DATECLOTURE.Year < 1900) vppParamAT_DATECLOTURE.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHA_ATTRIBUTIONCHAMBRE  @AG_CODEAGENCE1,@MS_NUMPIECE1,@TI_IDATTRIBUTION1, @AT_DATESAISIE, @TI_IDTIERS, @AR_CODEARTICLE, @PI_CODEPIECE, @PY_CODEPAYS, @AT_NUMPIECE, @AT_DATEETABLISSEMENTPIECE, @AT_LIEUETABLISSEMENTPIECE, @AT_EMETTEURPIECE, @AT_DATEENTREENATIONALE, @AT_DATEDEPARTNATIONALE, @AT_DATEDEBUT, @AT_DATEFIN, @AT_DATECLOTURE,@OP_CODEOPERATEUR, @CODECRYPTAGE1, 3 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDATTRIBUTION);
            vppSqlCmd.Parameters.Add(vppParamAT_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
            vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
            vppSqlCmd.Parameters.Add(vppParamAT_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEETABLISSEMENTPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_LIEUETABLISSEMENTPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_EMETTEURPIECE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEENTREENATIONALE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEDEPARTNATIONALE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamAT_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }




		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHA_ATTRIBUTIONCHAMBRE  @AG_CODEAGENCE,@MS_NUMPIECE,@TI_IDATTRIBUTION, @AT_DATESAISIE, '' , '' , @PI_CODEPIECE, @PY_CODEPAYS, '' , '' , '' , '' , '' , '' , '' , '' , '' , '' ,@CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPha_attributionchambre </returns>
		///<author>Home Technology</author>
		public List<clsPha_attributionchambre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  TI_IDATTRIBUTION, AT_DATESAISIE, TI_IDTIERS, AR_CODEARTICLE, PI_CODEPIECE, PY_CODEPAYS, AT_NUMPIECE, AT_DATEETABLISSEMENTPIECE, AT_LIEUETABLISSEMENTPIECE, AT_EMETTEURPIECE, AT_DATEENTREENATIONALE, AT_DATEDEPARTNATIONALE, AT_DATEDEBUT, AT_DATEFIN, AT_DATECLOTURE FROM dbo.FT_PHA_ATTRIBUTIONCHAMBRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPha_attributionchambre> clsPha_attributionchambres = new List<clsPha_attributionchambre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPha_attributionchambre clsPha_attributionchambre = new clsPha_attributionchambre();
					clsPha_attributionchambre.TI_IDATTRIBUTION = clsDonnee.vogDataReader["TI_IDATTRIBUTION"].ToString();
					clsPha_attributionchambre.AT_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATESAISIE"].ToString());
					clsPha_attributionchambre.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPha_attributionchambre.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPha_attributionchambre.PI_CODEPIECE = clsDonnee.vogDataReader["PI_CODEPIECE"].ToString();
					clsPha_attributionchambre.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
					clsPha_attributionchambre.AT_NUMPIECE = clsDonnee.vogDataReader["AT_NUMPIECE"].ToString();
					clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEETABLISSEMENTPIECE"].ToString());
					clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE = clsDonnee.vogDataReader["AT_LIEUETABLISSEMENTPIECE"].ToString();
					clsPha_attributionchambre.AT_EMETTEURPIECE = clsDonnee.vogDataReader["AT_EMETTEURPIECE"].ToString();
					clsPha_attributionchambre.AT_DATEENTREENATIONALE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEENTREENATIONALE"].ToString());
					clsPha_attributionchambre.AT_DATEDEPARTNATIONALE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEDEPARTNATIONALE"].ToString());
					clsPha_attributionchambre.AT_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEDEBUT"].ToString());
					clsPha_attributionchambre.AT_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEFIN"].ToString());
					clsPha_attributionchambre.AT_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATECLOTURE"].ToString());
					clsPha_attributionchambres.Add(clsPha_attributionchambre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPha_attributionchambres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPha_attributionchambre </returns>
		///<author>Home Technology</author>
		public List<clsPha_attributionchambre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPha_attributionchambre> clsPha_attributionchambres = new List<clsPha_attributionchambre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  TI_IDATTRIBUTION, AT_DATESAISIE, TI_IDTIERS, AR_CODEARTICLE, PI_CODEPIECE, PY_CODEPAYS, AT_NUMPIECE, AT_DATEETABLISSEMENTPIECE, AT_LIEUETABLISSEMENTPIECE, AT_EMETTEURPIECE, AT_DATEENTREENATIONALE, AT_DATEDEPARTNATIONALE, AT_DATEDEBUT, AT_DATEFIN, AT_DATECLOTURE FROM dbo.FT_PHA_ATTRIBUTIONCHAMBRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPha_attributionchambre clsPha_attributionchambre = new clsPha_attributionchambre();
					clsPha_attributionchambre.TI_IDATTRIBUTION = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDATTRIBUTION"].ToString();
					clsPha_attributionchambre.AT_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATESAISIE"].ToString());
					clsPha_attributionchambre.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsPha_attributionchambre.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPha_attributionchambre.PI_CODEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["PI_CODEPIECE"].ToString();
					clsPha_attributionchambre.PY_CODEPAYS = Dataset.Tables["TABLE"].Rows[Idx]["PY_CODEPAYS"].ToString();
					clsPha_attributionchambre.AT_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["AT_NUMPIECE"].ToString();
					clsPha_attributionchambre.AT_DATEETABLISSEMENTPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEETABLISSEMENTPIECE"].ToString());
					clsPha_attributionchambre.AT_LIEUETABLISSEMENTPIECE = Dataset.Tables["TABLE"].Rows[Idx]["AT_LIEUETABLISSEMENTPIECE"].ToString();
					clsPha_attributionchambre.AT_EMETTEURPIECE = Dataset.Tables["TABLE"].Rows[Idx]["AT_EMETTEURPIECE"].ToString();
					clsPha_attributionchambre.AT_DATEENTREENATIONALE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEENTREENATIONALE"].ToString());
					clsPha_attributionchambre.AT_DATEDEPARTNATIONALE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEDEPARTNATIONALE"].ToString());
					clsPha_attributionchambre.AT_DATEDEBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEDEBUT"].ToString());
					clsPha_attributionchambre.AT_DATEFIN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEFIN"].ToString());
					clsPha_attributionchambre.AT_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATECLOTURE"].ToString());
					clsPha_attributionchambres.Add(clsPha_attributionchambre);
				}
				Dataset.Dispose();
			}
		return clsPha_attributionchambres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHA_ATTRIBUTIONCHAMBRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetReservation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.PHA_ATTRIBUTIONCHAMBRE " + this.vapCritere + " ORDER BY AT_DATEDEBUT,AT_DATEFIN";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetChambreLibere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND MS_NUMPIECE=@MS_NUMPIECE AND AT_DATECLOTURE<>'01/01/1900'";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT AR_CODEARTICLE,AT_DATEDEBUT,AT_DATEFIN,AT_DATECLOTURE  FROM dbo.VUE_PHA_ATTRIBUTIONCHAMBRE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT TI_IDATTRIBUTION , TI_IDTIERS FROM dbo.FT_PHA_ATTRIBUTIONCHAMBRE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS)</summary>
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
                this.vapCritere = " ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE MS_NUMPIECE=@MS_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;

				case 3 :
				this.vapCritere ="WHERE TI_IDATTRIBUTION=@TI_IDATTRIBUTION AND AT_DATESAISIE=@AT_DATESAISIE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDATTRIBUTION", "@AT_DATESAISIE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE TI_IDATTRIBUTION=@TI_IDATTRIBUTION AND AT_DATESAISIE=@AT_DATESAISIE AND PI_CODEPIECE=@PI_CODEPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDATTRIBUTION", "@AT_DATESAISIE", "@PI_CODEPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE TI_IDATTRIBUTION=@TI_IDATTRIBUTION AND AT_DATESAISIE=@AT_DATESAISIE AND PI_CODEPIECE=@PI_CODEPIECE AND PY_CODEPAYS=@PY_CODEPAYS";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDATTRIBUTION", "@AT_DATESAISIE", "@PI_CODEPIECE", "@PY_CODEPAYS" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TI_IDATTRIBUTION, AT_DATESAISIE, PI_CODEPIECE, PY_CODEPAYS)</summary>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

                case 2:
                    this.vapCritere = "WHERE   AG_CODEAGENCE=@AG_CODEAGENCE AND   AR_CODEARTICLE=@AR_CODEARTICLE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AR_CODEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] , vppCritere[1]};
                    break;

                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  AR_CODEARTICLE=@AR_CODEARTICLE AND AT_DATECLOTURE=@AT_DATECLOTURE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AR_CODEARTICLE", "@AT_DATECLOTURE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] , vppCritere[2]};
                    break;
                
            }
        }




	}
}
