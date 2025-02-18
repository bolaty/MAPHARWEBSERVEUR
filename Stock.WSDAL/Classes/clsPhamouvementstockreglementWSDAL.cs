using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockreglementWSDAL: ITableDAL<clsPhamouvementstockreglement>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MV_NUMPIECE) AS MV_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MV_NUMPIECE) AS MV_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
            vapNomParametre = new string[] { "@AG_CODEAGENCE" };
            vapValeurParametre = new object[] {vppCritere[0] };
            this.vapRequete = "SELECT MAX(MV_NUMEROPIECE) AS MV_NUMEROPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMaxNumPiece(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(MV_NUMEROPIECE) AS MV_NUMEROPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENT " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        /////<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        /////<param name=clsDonnee>Classe d'acces aux donnees</param>
        /////<param name="vppCritere">critères de la requête scalaire</param>
        /////<returns>Un string comme valeur du résultat de la requete</returns>
        /////<author>Home Technology</author>
        //public string pvgValueScalarRequeteMaxNumSequence(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    pvpChoixCritere(clsDonnee, vppCritere);
        //    this.vapRequete = "SELECT MAX(MV_NUMPIECE) AS MV_NUMPIECE  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENT(@CODECRYPTAGE) " + this.vapCritere;
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        //}
        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
       

        public string pvgValueScalarRequeteMaxTestContreinte(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(MV_NUMPIECE) AS MV_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENT " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }
        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueCodeModeReglement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  MR_CODEMODEREGLEMENT FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


		public string pvgSoldeReglement(clsDonnee clsDonnee, params string[] vppCritere)
		{
            this.vapRequete = "SELECT  dbo.FC_SOLDEMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE) " ;
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE" };
            vapValeurParametre = new object[] {  vppCritere[0], vppCritere[1], vppCritere[2] };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        //public string pvgMontantFacture(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    this.vapRequete = "SELECT  dbo.FC_MONTANTFACTURE(@AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE) ";
        //    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE" };
        //    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        //}


        public string pvgMontantFacture(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT  dbo.FC_MONTANTFACTURE(@AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        public string pvgMontantFactureTTC(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT  dbo.FC_MONTANTTTC(@AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        public string pvgMontantReglementSurFacture(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT  dbo.FC_MONTANTREGLEMENT(@AG_CODEAGENCE,@MS_NUMPIECE,@DATEJOURNEE) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATEJOURNEE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        public string pvgGenererTableauAmortissement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "EXEC PS_IMMOBILISATIONTABLEAUAMORTISSEMENT  @AG_CODEAGENCE,@TI_IDTIERS,@CODECRYPTAGE ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TI_IDTIERS", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
            return "";
        }

        public string pvgSoldeGlobalReglement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT SOLDE FROM dbo.FC_SOLDEGLOBALMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@CL_IDCLIENT,@DATEJOURNEE,@OP_CODEOPERATEUREDITION) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CL_IDCLIENT", "@DATEJOURNEE", "@OP_CODEOPERATEUREDITION" };
            vapValeurParametre = new object[] {  vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        public string pvgSoldeCompteOperateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT dbo.FC_SOLDECOMPTEGRANDLIVREPRECEDENT (@AG_CODEAGENCE,@PL_CODENUMCOMPTE,@DATEJOURNEE) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@PL_CODENUMCOMPTE", "@DATEJOURNEE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }





        public string pvgTauxRemiseAppliquee(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT  dbo.FC_TAUXREDUCTIONAPPLIQUE(@AG_CODEAGENCE,@AR_CODEARTICLE,@TP_CODETYPECLIENT,@CL_IDCLIENT,@DATEJOURNEE) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@AR_CODEARTICLE", "@TP_CODETYPECLIENT", "@CL_IDCLIENT", "@DATEJOURNEE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MV_DATEPIECE, MS_NUMPIECE, MV_NUMSEQUENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetListeReferencePiece(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
            //this.vapRequete = "SELECT *  FROM EC_INSCRIPTIONSCOLARITEREGLEMENT " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglement comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglement pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , MR_CODEMODEREGLEMENT  , MS_NUMPIECE  , MV_MONTANTDEBIT  , MV_MONTANTCREDIT  , MV_DATEPIECE  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockreglement clsPhamouvementstockreglement = new clsPhamouvementstockreglement();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglement.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsDonnee.vogDataReader["MR_CODEMODEREGLEMENT"].ToString();
					clsPhamouvementstockreglement.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementstockreglement.MV_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["MV_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["MV_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MV_DATEPIECE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockreglement;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement)
		{
			//Préparation des paramètres
			SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 30);
			vppParamMV_NUMPIECE.Value  = clsPhamouvementstockreglement.MV_NUMPIECE ;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstockreglement.AG_CODEAGENCE ;

            SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
			vppParamMR_CODEMODEREGLEMENT.Value  = clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT ;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstockreglement.MS_NUMPIECE ;

            SqlParameter vppParamMV_MONTANTDEBIT = new SqlParameter("@MV_MONTANTDEBIT", SqlDbType.Money);
			vppParamMV_MONTANTDEBIT.Value  = clsPhamouvementstockreglement.MV_MONTANTDEBIT ;
			
            SqlParameter vppParamMV_MONTANTCREDIT = new SqlParameter("@MV_MONTANTCREDIT", SqlDbType.Money);
			vppParamMV_MONTANTCREDIT.Value  = clsPhamouvementstockreglement.MV_MONTANTCREDIT ;

            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
			vppParamMV_DATEPIECE.Value  = clsPhamouvementstockreglement.MV_DATEPIECE ;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENT  @MV_NUMPIECE, @AG_CODEAGENCE, @MR_CODEMODEREGLEMENT, @MS_NUMPIECE, @MV_MONTANTDEBIT, @MV_MONTANTCREDIT, @MV_DATEPIECE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMV_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamMV_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
		///<author>Home Technology</author>
        public string pvgMiseajour(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement)
		{
			//Préparation des paramètres
			SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 30);
			vppParamMV_NUMPIECE.Value  = clsPhamouvementstockreglement.MV_NUMPIECE ;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstockreglement.AG_CODEAGENCE ;
            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementstockreglement.EN_CODEENTREPOT;

            SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
			vppParamMR_CODEMODEREGLEMENT.Value  = clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT ;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstockreglement.MS_NUMPIECE ;



            if (clsPhamouvementstockreglement.MS_NUMPIECE == "0") vppParamMS_NUMPIECE.Value = DBNull.Value;

            SqlParameter vppParamMV_MONTANTDEBIT = new SqlParameter("@MV_MONTANTDEBIT", SqlDbType.Money);
			vppParamMV_MONTANTDEBIT.Value  = clsPhamouvementstockreglement.MV_MONTANTDEBIT ;
			
            SqlParameter vppParamMV_MONTANTCREDIT = new SqlParameter("@MV_MONTANTCREDIT", SqlDbType.Money);
			vppParamMV_MONTANTCREDIT.Value  = clsPhamouvementstockreglement.MV_MONTANTCREDIT ;


            SqlParameter vppParamRESTEMONTANTFACTURE = new SqlParameter("@RESTEMONTANTFACTURE", SqlDbType.Money);
            vppParamRESTEMONTANTFACTURE.Value = clsPhamouvementstockreglement.RESTEMONTANTFACTURE;

            //if (clsPhamouvementstockreglement.RESTEMONTANTFACTURE == 0) vppParamRESTEMONTANTFACTURE.Value = DBNull.Value;

            SqlParameter vppParamMONTANTFACTURE = new SqlParameter("@MONTANTFACTURE", SqlDbType.Money);
            vppParamMONTANTFACTURE.Value = clsPhamouvementstockreglement.MONTANTFACTURE;

            //if (clsPhamouvementstockreglement.MONTANTFACTURE == 0) vppParamMONTANTFACTURE.Value = DBNull.Value;


            SqlParameter vppParamMONTANTIMPAYER = new SqlParameter("@MONTANTIMPAYER", SqlDbType.Money);
            vppParamMONTANTIMPAYER.Value = clsPhamouvementstockreglement.MONTANTIMPAYER;

            //if (clsPhamouvementstockreglement.MONTANTIMPAYER == 0) vppParamMONTANTIMPAYER.Value = DBNull.Value;

            SqlParameter vppParamMONTANTVERSEMENT = new SqlParameter("@MONTANTVERSEMENT", SqlDbType.Money);
            vppParamMONTANTVERSEMENT.Value = clsPhamouvementstockreglement.MONTANTVERSEMENT;

            SqlParameter vppParamMS_UTILISERSUPLUS = new SqlParameter("@MS_UTILISERSUPLUS", SqlDbType.Int);
            vppParamMS_UTILISERSUPLUS.Value = clsPhamouvementstockreglement.MS_UTILISERSUPLUS;

            //if (clsPhamouvementstockreglement.MONTANTVERSEMENT == 0) vppParamMONTANTVERSEMENT.Value = DBNull.Value;


            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
			vppParamMV_DATEPIECE.Value  = clsPhamouvementstockreglement.MV_DATEPIECE ;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockreglement.TYPEOPERATION;

            SqlParameter vppParamMV_ANNULATIONPIECE = new SqlParameter("@MV_ANNULATIONPIECE", SqlDbType.VarChar,2);
            vppParamMV_ANNULATIONPIECE.Value = clsPhamouvementstockreglement.MV_ANNULATIONPIECE;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementstockreglement.NO_CODENATUREOPERATION;
            if (clsPhamouvementstockreglement.NO_CODENATUREOPERATION == "")
                vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamMV_LIBELLEOPERATION = new SqlParameter("@MV_LIBELLEOPERATION", SqlDbType.VarChar, 150);
            vppParamMV_LIBELLEOPERATION.Value = clsPhamouvementstockreglement.MV_LIBELLEOPERATION;

            SqlParameter vppParamMV_REFERENCEPIECE = new SqlParameter("@MV_REFERENCEPIECE", SqlDbType.VarChar, 150);
            vppParamMV_REFERENCEPIECE.Value = clsPhamouvementstockreglement.MV_REFERENCEPIECE;

            SqlParameter vppParamMV_NOMTIERS = new SqlParameter("@MV_NOMTIERS", SqlDbType.VarChar, 150);
            vppParamMV_NOMTIERS.Value = clsPhamouvementstockreglement.MV_NOMTIERS;




            //SqlParameter vppParamCL_NUMCLIENT = new SqlParameter("@CL_NUMCLIENT", SqlDbType.VarChar, 150);
            //vppParamCL_NUMCLIENT.Value = clsPhamouvementstockreglement.CL_NUMCLIENT;

            SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 150);
            vppParamTI_NUMTIERS.Value = clsPhamouvementstockreglement.TI_NUMTIERS;

            //SqlParameter vppParamFR_MATRICULE = new SqlParameter("@FR_MATRICULE", SqlDbType.VarChar, 150);
            //vppParamFR_MATRICULE.Value = clsPhamouvementstockreglement.FR_MATRICULE;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 150);
            vppParamPL_NUMCOMPTE.Value = clsPhamouvementstockreglement.PL_NUMCOMPTE;

            SqlParameter vppParamMV_NUMEROPIECE = new SqlParameter("@MV_NUMEROPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMEROPIECE.Value = clsPhamouvementstockreglement.MV_NUMEROPIECE;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockreglement.OP_CODEOPERATEUR;



            SqlParameter vppParamFB_IDFOURNISSEUR = new SqlParameter("@FB_IDFOURNISSEUR", SqlDbType.VarChar, 50);
            vppParamFB_IDFOURNISSEUR.Value = clsPhamouvementstockreglement.FB_IDFOURNISSEUR;
            if (clsPhamouvementstockreglement.FB_IDFOURNISSEUR == "")
                vppParamFB_IDFOURNISSEUR.Value = DBNull.Value;

            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERS.Value = clsPhamouvementstockreglement.TI_IDTIERS;
            if (clsPhamouvementstockreglement.TI_IDTIERS == "")
                vppParamTI_IDTIERS.Value = DBNull.Value;

            SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.Int);
            vppParamJO_CODEJOURNAL.Value = clsPhamouvementstockreglement.JO_CODEJOURNAL;

            //SqlParameter vppParamMV_ABREVIATION = new SqlParameter("@MV_ABREVIATION", SqlDbType.VarChar, 5);
            //vppParamMV_ABREVIATION.Value = clsPhamouvementstockreglement.MV_ABREVIATION;


            SqlParameter vppParamNA_CODENATUREOPERATION = new SqlParameter("@NA_CODENATUREOPERATION", SqlDbType.VarChar, 50);
            vppParamNA_CODENATUREOPERATION.Value = clsPhamouvementstockreglement.NA_CODENATUREOPERATION;
            if (clsPhamouvementstockreglement.NA_CODENATUREOPERATION == "")
                vppParamNA_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 50);
            vppParamTA_CODETYPEARTICLE.Value = clsPhamouvementstockreglement.TA_CODETYPEARTICLE;
            if (clsPhamouvementstockreglement.TA_CODETYPEARTICLE == "")
                vppParamTA_CODETYPEARTICLE.Value = DBNull.Value;

            SqlParameter vppParamMV_REGLEMENTGROUPE = new SqlParameter("@MV_REGLEMENTGROUPE", SqlDbType.VarChar, 50);
            vppParamMV_REGLEMENTGROUPE.Value = clsPhamouvementstockreglement.MV_REGLEMENTGROUPE;
            if (clsPhamouvementstockreglement.MV_REGLEMENTGROUPE == "")
                vppParamMV_REGLEMENTGROUPE.Value = DBNull.Value;

            SqlParameter vppParamTI_IDTIERSIMMOBILISATION = new SqlParameter("@TI_IDTIERSIMMOBILISATION", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERSIMMOBILISATION.Value = clsPhamouvementstockreglement.TI_IDTIERSIMMOBILISATION;
            if (clsPhamouvementstockreglement.TI_IDTIERSIMMOBILISATION == "")
                vppParamTI_IDTIERSIMMOBILISATION.Value = DBNull.Value;

            SqlParameter vppParamSOURCE_OPERATION = new SqlParameter("@SOURCE_OPERATION", SqlDbType.VarChar, 50);
            vppParamSOURCE_OPERATION.Value = "";



            SqlParameter vppParamMV_NUMPIECERETOUR = new SqlParameter("@MV_NUMPIECERETOUR", SqlDbType.VarChar, 25);
            vppParamMV_NUMPIECERETOUR.Value = "";

			//Préparation de la commande
            SqlCommand vppSqlCmd = new SqlCommand("PC_PHAMOUVEMENTSTOCKREGLEMENT", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;
            
            //Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMV_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamMV_MONTANTCREDIT);

            vppSqlCmd.Parameters.Add(vppParamRESTEMONTANTFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMONTANTFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMONTANTIMPAYER);
            vppSqlCmd.Parameters.Add(vppParamMONTANTVERSEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_UTILISERSUPLUS);

			vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMV_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMV_LIBELLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMV_REFERENCEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_NOMTIERS);
            //vppSqlCmd.Parameters.Add(vppParamCL_NUMCLIENT);
            //vppSqlCmd.Parameters.Add(vppParamFR_MATRICULE);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamFB_IDFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamNA_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamMV_REGLEMENTGROUPE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSIMMOBILISATION);
            vppSqlCmd.Parameters.Add(vppParamSOURCE_OPERATION);

            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECERETOUR);
			//Ouverture de la connection et exécution de la commande
            vppParamMV_NUMPIECERETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MV_NUMPIECERETOUR"].Value.ToString();

		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<author>Home Technology</author>
        public void pvgLettrage(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement)
        {
            //Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementstockreglement.EN_CODEENTREPOT;

            SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 30);
	        vppParamMV_NUMPIECE.Value  = clsPhamouvementstockreglement.MV_NUMPIECE ;

            SqlParameter vppParamLT_CODELETTRAGE = new SqlParameter("@LT_CODELETTRAGE", SqlDbType.Int);
            vppParamLT_CODELETTRAGE.Value = clsPhamouvementstockreglement.LT_CODELETTRAGE;
            if(clsPhamouvementstockreglement.LT_CODELETTRAGE==0) vppParamLT_CODELETTRAGE.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 30);
            vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockreglement.OP_CODEOPERATEUR;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockreglement.TYPEOPERATION;
            
            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_LETTRAGE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @MV_NUMPIECE, @LT_CODELETTRAGE, @OP_CODEOPERATEUR, @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);

            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);

            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);

            vppSqlCmd.Parameters.Add(vppParamLT_CODELETTRAGE);

            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
	        
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
		///<author>Home Technology</author>
        public string pvgMiseajourTemp(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement)
        {
            //Préparation des paramètres
            SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 30);
            vppParamMV_NUMPIECE.Value = clsPhamouvementstockreglement.MV_NUMPIECE;

            if (clsPhamouvementstockreglement.MV_NUMPIECE == "0" || clsPhamouvementstockreglement.MV_NUMPIECE == "") vppParamMV_NUMPIECE.Value = DBNull.Value;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;
            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementstockreglement.EN_CODEENTREPOT;

            SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
            vppParamMR_CODEMODEREGLEMENT.Value = clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementstockreglement.MS_NUMPIECE;



            if (clsPhamouvementstockreglement.MS_NUMPIECE == "0") vppParamMS_NUMPIECE.Value = DBNull.Value;

            SqlParameter vppParamMV_MONTANTDEBIT = new SqlParameter("@MV_MONTANTDEBIT", SqlDbType.Money);
            vppParamMV_MONTANTDEBIT.Value = clsPhamouvementstockreglement.MV_MONTANTDEBIT;

            SqlParameter vppParamMV_MONTANTCREDIT = new SqlParameter("@MV_MONTANTCREDIT", SqlDbType.Money);
            vppParamMV_MONTANTCREDIT.Value = clsPhamouvementstockreglement.MV_MONTANTCREDIT;


            SqlParameter vppParamRESTEMONTANTFACTURE = new SqlParameter("@RESTEMONTANTFACTURE", SqlDbType.Money);
            vppParamRESTEMONTANTFACTURE.Value = clsPhamouvementstockreglement.RESTEMONTANTFACTURE;

            //if (clsPhamouvementstockreglement.RESTEMONTANTFACTURE == 0) vppParamRESTEMONTANTFACTURE.Value = DBNull.Value;

            SqlParameter vppParamMONTANTFACTURE = new SqlParameter("@MONTANTFACTURE", SqlDbType.Money);
            vppParamMONTANTFACTURE.Value = clsPhamouvementstockreglement.MONTANTFACTURE;

            //if (clsPhamouvementstockreglement.MONTANTFACTURE == 0) vppParamMONTANTFACTURE.Value = DBNull.Value;


            SqlParameter vppParamMONTANTIMPAYER = new SqlParameter("@MONTANTIMPAYER", SqlDbType.Money);
            vppParamMONTANTIMPAYER.Value = clsPhamouvementstockreglement.MONTANTIMPAYER;

            //if (clsPhamouvementstockreglement.MONTANTIMPAYER == 0) vppParamMONTANTIMPAYER.Value = DBNull.Value;

            SqlParameter vppParamMONTANTVERSEMENT = new SqlParameter("@MONTANTVERSEMENT", SqlDbType.Money);
            vppParamMONTANTVERSEMENT.Value = clsPhamouvementstockreglement.MONTANTVERSEMENT;

            SqlParameter vppParamMS_UTILISERSUPLUS = new SqlParameter("@MS_UTILISERSUPLUS", SqlDbType.Int);
            vppParamMS_UTILISERSUPLUS.Value = clsPhamouvementstockreglement.MS_UTILISERSUPLUS;

            //if (clsPhamouvementstockreglement.MONTANTVERSEMENT == 0) vppParamMONTANTVERSEMENT.Value = DBNull.Value;


            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
            vppParamMV_DATEPIECE.Value = clsPhamouvementstockreglement.MV_DATEPIECE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockreglement.TYPEOPERATION;

            SqlParameter vppParamMV_ANNULATIONPIECE = new SqlParameter("@MV_ANNULATIONPIECE", SqlDbType.VarChar, 2);
            vppParamMV_ANNULATIONPIECE.Value = clsPhamouvementstockreglement.MV_ANNULATIONPIECE;

            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementstockreglement.NO_CODENATUREOPERATION;
            if (clsPhamouvementstockreglement.NO_CODENATUREOPERATION == "")
                vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamMV_LIBELLEOPERATION = new SqlParameter("@MV_LIBELLEOPERATION", SqlDbType.VarChar, 150);
            vppParamMV_LIBELLEOPERATION.Value = clsPhamouvementstockreglement.MV_LIBELLEOPERATION;

            SqlParameter vppParamMV_REFERENCEPIECE = new SqlParameter("@MV_REFERENCEPIECE", SqlDbType.VarChar, 150);
            vppParamMV_REFERENCEPIECE.Value = clsPhamouvementstockreglement.MV_REFERENCEPIECE;

            SqlParameter vppParamMV_NOMTIERS = new SqlParameter("@MV_NOMTIERS", SqlDbType.VarChar, 150);
            vppParamMV_NOMTIERS.Value = clsPhamouvementstockreglement.MV_NOMTIERS;




            //SqlParameter vppParamCL_NUMCLIENT = new SqlParameter("@CL_NUMCLIENT", SqlDbType.VarChar, 150);
            //vppParamCL_NUMCLIENT.Value = clsPhamouvementstockreglement.CL_NUMCLIENT;

            SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 150);
            vppParamTI_NUMTIERS.Value = clsPhamouvementstockreglement.TI_NUMTIERS;

            //SqlParameter vppParamFR_MATRICULE = new SqlParameter("@FR_MATRICULE", SqlDbType.VarChar, 150);
            //vppParamFR_MATRICULE.Value = clsPhamouvementstockreglement.FR_MATRICULE;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 150);
            vppParamPL_NUMCOMPTE.Value = clsPhamouvementstockreglement.PL_NUMCOMPTE;

            SqlParameter vppParamMV_NUMEROPIECE = new SqlParameter("@MV_NUMEROPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMEROPIECE.Value = clsPhamouvementstockreglement.MV_NUMEROPIECE;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockreglement.OP_CODEOPERATEUR;



            SqlParameter vppParamFB_IDFOURNISSEUR = new SqlParameter("@FB_IDFOURNISSEUR", SqlDbType.VarChar, 50);
            vppParamFB_IDFOURNISSEUR.Value = clsPhamouvementstockreglement.FB_IDFOURNISSEUR;
            if (clsPhamouvementstockreglement.FB_IDFOURNISSEUR == "")
                vppParamFB_IDFOURNISSEUR.Value = DBNull.Value;

            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERS.Value = clsPhamouvementstockreglement.TI_IDTIERS;
            if (clsPhamouvementstockreglement.TI_IDTIERS == "")
                vppParamTI_IDTIERS.Value = DBNull.Value;

            SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.Int);
            vppParamJO_CODEJOURNAL.Value = clsPhamouvementstockreglement.JO_CODEJOURNAL;

            //SqlParameter vppParamMV_ABREVIATION = new SqlParameter("@MV_ABREVIATION", SqlDbType.VarChar, 5);
            //vppParamMV_ABREVIATION.Value = clsPhamouvementstockreglement.MV_ABREVIATION;


            SqlParameter vppParamNA_CODENATUREOPERATION = new SqlParameter("@NA_CODENATUREOPERATION", SqlDbType.VarChar, 50);
            vppParamNA_CODENATUREOPERATION.Value = clsPhamouvementstockreglement.NA_CODENATUREOPERATION;
            if (clsPhamouvementstockreglement.NA_CODENATUREOPERATION == "")
                vppParamNA_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 50);
            vppParamTA_CODETYPEARTICLE.Value = clsPhamouvementstockreglement.TA_CODETYPEARTICLE;
            if (clsPhamouvementstockreglement.TA_CODETYPEARTICLE == "")
                vppParamTA_CODETYPEARTICLE.Value = DBNull.Value;

            SqlParameter vppParamMV_REGLEMENTGROUPE = new SqlParameter("@MV_REGLEMENTGROUPE", SqlDbType.VarChar, 50);
            vppParamMV_REGLEMENTGROUPE.Value = clsPhamouvementstockreglement.MV_REGLEMENTGROUPE;
            if (clsPhamouvementstockreglement.MV_REGLEMENTGROUPE == "")
                vppParamMV_REGLEMENTGROUPE.Value = DBNull.Value;

            SqlParameter vppParamTI_IDTIERSIMMOBILISATION = new SqlParameter("@TI_IDTIERSIMMOBILISATION", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERSIMMOBILISATION.Value = clsPhamouvementstockreglement.TI_IDTIERSIMMOBILISATION;
            if (clsPhamouvementstockreglement.TI_IDTIERSIMMOBILISATION == "")
                vppParamTI_IDTIERSIMMOBILISATION.Value = DBNull.Value;


            SqlParameter vppParamMV_NUMPIECERETOUR = new SqlParameter("@MV_NUMPIECERETOUR", SqlDbType.VarChar, 25);
            vppParamMV_NUMPIECERETOUR.Value = "";

            //Préparation de la commande
            SqlCommand vppSqlCmd = new SqlCommand("PC_PHAMOUVEMENTSTOCKREGLEMENTTEMPTEMP", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_MONTANTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamMV_MONTANTCREDIT);

            vppSqlCmd.Parameters.Add(vppParamRESTEMONTANTFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMONTANTFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMONTANTIMPAYER);
            vppSqlCmd.Parameters.Add(vppParamMONTANTVERSEMENT);
            vppSqlCmd.Parameters.Add(vppParamMS_UTILISERSUPLUS);

            vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMV_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMV_LIBELLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMV_REFERENCEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_NOMTIERS);
            //vppSqlCmd.Parameters.Add(vppParamCL_NUMCLIENT);
            //vppSqlCmd.Parameters.Add(vppParamFR_MATRICULE);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamFB_IDFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamNA_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamMV_REGLEMENTGROUPE);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSIMMOBILISATION);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECERETOUR);
            //Ouverture de la connection et exécution de la commande
            vppParamMV_NUMPIECERETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MV_NUMPIECERETOUR"].Value.ToString();

        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpduteTemp(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] {  "@AG_CODEAGENCE", "@MV_NUMPIECETEMP", "@MV_NUMPIECE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            //Préparation de la commande
            this.vapRequete = "EXEC PS_MAJPHAMOUVEMENTSTOCKREGLEMENTTEMP  @AG_CODEAGENCE, @MV_NUMPIECETEMP, @MV_NUMPIECE ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }





        public clsMiccomptewebResultat pvgCreationDetailFacture(clsDonnee clsDonnee, string AG_CODEAGENCE, string DT_NUMEROTRANSACTION, string DT_NUMEROFACTURE, string DT_REFERENCE, string DT_DESIGNATION, string DT_QUANTITE, string DT_PU, string DT_TOTALARTICLE, string DT_TOTALFACTURE, string PY_CODESTATUT, string TI_IDTIERS, string NO_CODENATUREVIREMENT, string DT_DATEVALIDATION, string PI_CODEPIECE,  string DT_NOMTIERS, string DT_NUMPIECETIERS, string SO_CODESOUSCRIPTION, string TK_TOKEN, string OP_CODEOPERATEUR,string MS_NUMPIECE,string MONTANTFACTURETTC,  string TYPEOPERATION)
        {
            clsMiccomptewebResultat clsMiccomptewebResultats = new clsMiccomptewebResultat();
            DataSet Dataset = new DataSet();
            //string[] vapNomParametre = new string[] { };
            //object[] vapValeurParametre = new object[] { };
            //string vapCritere = "";
            //string vapRequete = "";

            //pvpChoixCritere(clsDonnee, vppCritere);

            //if (TYPEOPERATION == "7")
            //    TYPEOPERATION = "0";

            //this.vapCritere = "WHERE SL_LOGIN=@SL_LOGIN AND SL_MOTPASSE=@SL_MOTPASSE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "AG_CODEAGENCE", "DT_NUMEROTRANSACTION", "DT_NUMEROFACTURE", "DT_REFERENCE", "DT_DESIGNATION", "DT_QUANTITE", "DT_PU", "DT_TOTALARTICLE", "DT_TOTALFACTURE", "PY_CODESTATUT", "TI_IDTIERS", "NO_CODENATUREVIREMENT", "DT_DATEVALIDATION", "PI_CODEPIECE",  "DT_NOMTIERS", "DT_NUMPIECETIERS", "SO_CODESOUSCRIPTION", "TK_TOKEN", "OP_CODEOPERATEUR", "MS_NUMPIECE", "MONTANTFACTURETTC", "TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, AG_CODEAGENCE, DT_NUMEROTRANSACTION, DT_NUMEROFACTURE, DT_REFERENCE, DT_DESIGNATION, DT_QUANTITE, DT_PU, DT_TOTALARTICLE, DT_TOTALFACTURE, PY_CODESTATUT, TI_IDTIERS, NO_CODENATUREVIREMENT, DT_DATEVALIDATION, PI_CODEPIECE,  DT_NOMTIERS, DT_NUMPIECETIERS, SO_CODESOUSCRIPTION, TK_TOKEN, OP_CODEOPERATEUR, MS_NUMPIECE, MONTANTFACTURETTC, TYPEOPERATION };

            this.vapRequete = "EXEC PC_MOBILEDETAILOPERATION  @AG_CODEAGENCE, @DT_NUMEROTRANSACTION,@DT_NUMEROFACTURE, @DT_REFERENCE, @DT_DESIGNATION, @DT_QUANTITE, @DT_PU, @DT_TOTALARTICLE, @DT_TOTALFACTURE ,  @PY_CODESTATUT,  @TI_IDTIERS,  @NO_CODENATUREVIREMENT,  @DT_DATEVALIDATION,  @PI_CODEPIECE,   @DT_NOMTIERS,  @DT_NUMPIECETIERS, @SO_CODESOUSCRIPTION,@TK_TOKEN,@OP_CODEOPERATEUR,@MS_NUMPIECE,@MONTANTFACTURETTC, @CODECRYPTAGE,@TYPEOPERATION "; //+ this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMiccomptewebResultat clsMiccomptewebResultat = new clsMiccomptewebResultat();

                    DataSet DataSet1 = new DataSet();
                    //EJ_IDEPARGNANTJOURNALIER = string.Format("{0:00000000}", double.Parse(EJ_IDEPARGNANTJOURNALIER));
                    //string[] vppCritere = new string[] { AG_CODEAGENCE, EJ_IDEPARGNANTJOURNALIER };

                    //DataSet1 = pvgChargerDansDataSetEPARGNANTJOURNALIER(clsDonnee, vppCritere);
                    //foreach (DataRow row in DataSet1.Tables[0].Rows)
                    //{
                    //    clsMiccomptewebResultat.CO_CODECOMPTE = row["CO_CODECOMPTE"].ToString();
                    //    clsMiccomptewebResultat.CL_IDCLIENT = row["EJ_IDEPARGNANTJOURNALIER"].ToString();
                    //    clsMiccomptewebResultat.PV_CODEPOINTVENTE = row["PV_CODEPOINTVENTE"].ToString();
                    //}

                    clsMiccomptewebResultat.SL_CODEMESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_CODEMESSAGE"].ToString();
                    clsMiccomptewebResultat.SL_RESULTAT = Dataset.Tables["TABLE"].Rows[Idx]["SL_RESULTAT"].ToString();
                    clsMiccomptewebResultat.SL_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGE"].ToString();
                    clsMiccomptewebResultat.SL_NUMEROTRANSACTION = Dataset.Tables["TABLE"].Rows[Idx]["DT_NUMEROTRANSACTION"].ToString();
                    clsMiccomptewebResultat.TK_TOKEN = Dataset.Tables["TABLE"].Rows[Idx]["DT_TOKEN"].ToString();
                    clsMiccomptewebResultat.SL_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["SL_TELEPHONE"].ToString();
                    clsMiccomptewebResultat.SL_INDICATIF = Dataset.Tables["TABLE"].Rows[Idx]["SL_INDICATIF"].ToString();
                    clsMiccomptewebResultat.SL_MONTANTOPERATION = Double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SL_MONTANTOPERATION"].ToString()).ToString();
                    clsMiccomptewebResultat.SL_URLNOTIFICATION = Dataset.Tables["TABLE"].Rows[Idx]["SL_URLNOTIFICATION"].ToString();
                    clsMiccomptewebResultat.OB_NOMOBJET = "FrmEditionEtatGuichetCaisseTontine";
                    clsMiccomptewebResultats = clsMiccomptewebResultat;
                    //clsMiccomptewebResultats.Add(clsMiccomptewebResultat);
                }
                Dataset.Dispose();
            }
            return clsMiccomptewebResultats;
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetMOBILEDETAILOPERATION(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND DT_NUMEROTRANSACTION=@DT_NUMEROTRANSACTION AND DT_DATEVALIDATION='01/01/1900'";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@DT_NUMEROTRANSACTION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT AG_CODEAGENCE,EN_CODEENTREPOT,DT_DATEOPERATION,DT_NUMSEQUENCE,DT_NUMEROTRANSACTION,DT_REFERENCE, DT_DESIGNATION, DT_QUANTITE,DT_PU,DT_TOTALARTICLE, DT_TOTALFACTURE,DT_DATESAISIE,TI_IDTIERS,PY_CODESTATUT,MS_NUMPIECE,DT_DATEVALIDATION,PI_CODEPIECE,DT_NOMTIERS,DT_NUMPIECETIERS, CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',TI_NUMTIERS) AS varchar(150)) AS TI_NUMTIERS,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',TI_DENOMINATION) AS varchar(150)) AS TI_DENOMINATION,OP_CODEOPERATEUR,PL_NUMCOMPTE FROM VUE_MOBILEDETAILOPERATION " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MV_DATEPIECE, MS_NUMPIECE, MV_NUMSEQUENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgVerificatioSoldeCompteAvecChequeDiffere(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;
            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT1", SqlDbType.VarChar, 25);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementstockreglement.EN_CODEENTREPOT;
            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE1", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementstockreglement.MS_NUMPIECE;
            SqlParameter vppParamMV_DATESAISIE = new SqlParameter("@MV_DATESAISIE1", SqlDbType.DateTime);
            vppParamMV_DATESAISIE.Value = clsPhamouvementstockreglement.MV_DATESAISIE;
            SqlParameter vppParamMONTANTREGLEMENTDUJOUR = new SqlParameter("@MONTANTREGLEMENTDUJOUR", SqlDbType.Money);
            vppParamMONTANTREGLEMENTDUJOUR.Value = clsPhamouvementstockreglement.MONTANTVERSEMENT;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockreglement.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXEC  [dbo].[PS_VERIFICATIONSOLDEAVECLESCHEQUESNONENCORECOMPTABILISER] @AG_CODEAGENCE1,@EN_CODEENTREPOT1,@MS_NUMPIECE1, @MV_DATESAISIE1,@MONTANTREGLEMENTDUJOUR,@OP_CODEOPERATEUR1,'01',@CODECRYPTAGE1";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamMONTANTREGLEMENTDUJOUR);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        public void pvgUpdateStatutOperation(clsDonnee clsDonnee, clsMobiledetailoperationtontine clsMobiledetailoperationtontine, params string[] vppCritere)
        {
            //Préparation des paramètres

            SqlParameter vppParamDT_DATEVALIDATION = new SqlParameter("@DT_DATEVALIDATION", SqlDbType.DateTime);
            vppParamDT_DATEVALIDATION.Value = clsMobiledetailoperationtontine.DT_DATEVALIDATION;
            pvpChoixCritere4(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE MOBILEDETAILOPERATION SET " +
            " DT_DATEVALIDATION = @DT_DATEVALIDATION" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamDT_DATEVALIDATION);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDeleteTemp(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MV_DATEPIECE=@MV_DATEPIECE   AND MV_NUMEROPIECE=@MV_NUMEROPIECE ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_DATEPIECE", "@MV_NUMEROPIECE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
            //Préparation de la commande
            this.vapRequete = "DELETE FROM PHAMOUVEMENTSTOCKREGLEMENTTEMP "+ this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<author>Home Technology</author>
        public string pvgComptabilisation(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement)
        {
            //Préparation des paramètres
          
            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementstockreglement.NO_CODENATUREOPERATION;
            if (clsPhamouvementstockreglement.NO_CODENATUREOPERATION == "")
                vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 5);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementstockreglement.EN_CODEENTREPOT;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementstockreglement.MS_NUMPIECE;


            SqlParameter vppParamMV_NUMEROPIECE1 = new SqlParameter("@MV_NUMEROPIECE1", SqlDbType.VarChar, 30);
            vppParamMV_NUMEROPIECE1.Value = clsPhamouvementstockreglement.MV_NUMEROPIECE;






            SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
            vppParamMR_CODEMODEREGLEMENT.Value = clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT;



            if (clsPhamouvementstockreglement.MS_NUMPIECE == "0") vppParamMS_NUMPIECE.Value = DBNull.Value;


            SqlParameter vppParamRESTEMONTANTFACTURE = new SqlParameter("@RESTEMONTANTFACTURE", SqlDbType.Money);
            vppParamRESTEMONTANTFACTURE.Value = clsPhamouvementstockreglement.RESTEMONTANTFACTURE;

            //if (clsPhamouvementstockreglement.RESTEMONTANTFACTURE == 0) vppParamRESTEMONTANTFACTURE.Value = DBNull.Value;

            SqlParameter vppParamMONTANTFACTURE = new SqlParameter("@MONTANTFACTURE", SqlDbType.Money);
            vppParamMONTANTFACTURE.Value = clsPhamouvementstockreglement.MONTANTFACTURE;

            SqlParameter vppParamMONTANTREMISE = new SqlParameter("@MONTANTREMISE", SqlDbType.Money);
            vppParamMONTANTREMISE.Value = clsPhamouvementstockreglement.MONTANTREMISE;

            SqlParameter vppParamMONTANTTVA = new SqlParameter("@MONTANTTVA", SqlDbType.Money);
            vppParamMONTANTTVA.Value = clsPhamouvementstockreglement.MONTANTTVA;

            SqlParameter vppParamMONTANTAIRSI = new SqlParameter("@MONTANTAIRSI ", SqlDbType.Money);
            vppParamMONTANTAIRSI.Value = clsPhamouvementstockreglement.MONTANTAIRSI;

            //if (clsPhamouvementstockreglement.MONTANTFACTURE == 0) vppParamMONTANTFACTURE.Value = DBNull.Value;


            SqlParameter vppParamMONTANTIMPAYER = new SqlParameter("@MONTANTIMPAYER", SqlDbType.Money);
            vppParamMONTANTIMPAYER.Value = clsPhamouvementstockreglement.MONTANTIMPAYER;

            SqlParameter vppParamMONTANTTRANSPORT = new SqlParameter("@MONTANTTRANSPORT", SqlDbType.Money);
            vppParamMONTANTTRANSPORT.Value = clsPhamouvementstockreglement.MONTANTTRANSPORT;
            SqlParameter vppParamMONTANTFACTURETTC = new SqlParameter("@MONTANTFACTURETTC", SqlDbType.Money);
            vppParamMONTANTFACTURETTC.Value = clsPhamouvementstockreglement.MONTANTFACTURETTC;

            SqlParameter vppParamMONTANTASSUREUR = new SqlParameter("@MONTANTASSUREUR", SqlDbType.Money);
            vppParamMONTANTASSUREUR.Value = clsPhamouvementstockreglement.MONTANTASSUREUR;

            //if (clsPhamouvementstockreglement.MONTANTIMPAYER == 0) vppParamMONTANTIMPAYER.Value = DBNull.Value;

            SqlParameter vppParamMONTANTVERSEMENT = new SqlParameter("@MONTANTVERSEMENT", SqlDbType.Money);
            vppParamMONTANTVERSEMENT.Value = clsPhamouvementstockreglement.MONTANTVERSEMENT;

            SqlParameter vppParamMS_UTILISERSUPLUS = new SqlParameter("@MS_UTILISERSUPLUS", SqlDbType.Int);
            vppParamMS_UTILISERSUPLUS.Value = clsPhamouvementstockreglement.MS_UTILISERSUPLUS;



            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
            vppParamMV_DATEPIECE.Value = clsPhamouvementstockreglement.MV_DATEPIECE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockreglement.TYPEOPERATION;

            SqlParameter vppParamNO_SENS = new SqlParameter("@NO_SENS", SqlDbType.VarChar, 1);
            vppParamNO_SENS.Value = clsPhamouvementstockreglement.NO_SENS;
            if (clsPhamouvementstockreglement.NO_SENS == "")
                vppParamNO_SENS.Value = DBNull.Value;

            SqlParameter vppParamTO_CODEOPERATION = new SqlParameter("@TO_CODEOPERATION", SqlDbType.VarChar, 2);
            vppParamTO_CODEOPERATION.Value = clsPhamouvementstockreglement.TO_CODEOPERATION;
            if (clsPhamouvementstockreglement.TO_CODEOPERATION == "")
                vppParamTO_CODEOPERATION.Value = DBNull.Value;



            SqlParameter vppParamMV_ANNULATIONPIECE = new SqlParameter("@MV_ANNULATIONPIECE", SqlDbType.VarChar, 2);
            vppParamMV_ANNULATIONPIECE.Value = clsPhamouvementstockreglement.MV_ANNULATIONPIECE;




            SqlParameter vppParamMV_LIBELLEOPERATION = new SqlParameter("@MV_LIBELLEOPERATION", SqlDbType.VarChar, 150);
            vppParamMV_LIBELLEOPERATION.Value = clsPhamouvementstockreglement.MV_LIBELLEOPERATION;

            SqlParameter vppParamMV_REFERENCEPIECE = new SqlParameter("@MV_REFERENCEPIECE", SqlDbType.VarChar, 150);
            vppParamMV_REFERENCEPIECE.Value = clsPhamouvementstockreglement.MV_REFERENCEPIECE;

            SqlParameter vppParamMV_NOMTIERS = new SqlParameter("@MV_NOMTIERS", SqlDbType.VarChar, 150);
            vppParamMV_NOMTIERS.Value = clsPhamouvementstockreglement.MV_NOMTIERS;






            SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 150);
            vppParamTI_NUMTIERS.Value = clsPhamouvementstockreglement.TI_NUMTIERS;



            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 150);
            vppParamPL_NUMCOMPTE.Value = clsPhamouvementstockreglement.PL_NUMCOMPTE;

            SqlParameter vppParamPL_NUMCOMPTEBANQUE = new SqlParameter("@PL_NUMCOMPTEBANQUE", SqlDbType.VarChar, 150);
            vppParamPL_NUMCOMPTEBANQUE.Value = clsPhamouvementstockreglement.PL_NUMCOMPTEBANQUE;



            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockreglement.OP_CODEOPERATEUR;



            SqlParameter vppParamFB_IDFOURNISSEUR = new SqlParameter("@FB_IDFOURNISSEUR", SqlDbType.VarChar, 50);
            vppParamFB_IDFOURNISSEUR.Value = clsPhamouvementstockreglement.FB_IDFOURNISSEUR;
            if (clsPhamouvementstockreglement.FB_IDFOURNISSEUR == "")
                vppParamFB_IDFOURNISSEUR.Value = DBNull.Value;

            SqlParameter vppParamMV_MTSURPLUS = new SqlParameter("@MV_MTSURPLUS", SqlDbType.VarChar, 1);
            vppParamMV_MTSURPLUS.Value = clsPhamouvementstockreglement.MV_MTSURPLUS;
            if (clsPhamouvementstockreglement.MV_MTSURPLUS == "")
                vppParamMV_MTSURPLUS.Value = DBNull.Value;

            SqlParameter vppParamMS_NUMPIECEANNULER = new SqlParameter("@MS_NUMPIECEANNULER", SqlDbType.VarChar, 150);
            vppParamMS_NUMPIECEANNULER.Value = clsPhamouvementstockreglement.MS_NUMPIECEANNULER;
            if (clsPhamouvementstockreglement.MS_NUMPIECEANNULER == "")
                vppParamMS_NUMPIECEANNULER.Value = DBNull.Value;


            SqlParameter vppParamNA_CODENATUREOPERATION = new SqlParameter("@NA_CODENATUREOPERATION", SqlDbType.VarChar, 50);
            vppParamNA_CODENATUREOPERATION.Value = clsPhamouvementstockreglement.NA_CODENATUREOPERATION;
            if (clsPhamouvementstockreglement.NA_CODENATUREOPERATION == "")
                vppParamNA_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamTA_CODETYPEARTICLE = new SqlParameter("@TA_CODETYPEARTICLE", SqlDbType.VarChar, 50);
            vppParamTA_CODETYPEARTICLE.Value = clsPhamouvementstockreglement.TA_CODETYPEARTICLE;
            if (clsPhamouvementstockreglement.TA_CODETYPEARTICLE == "")
                vppParamTA_CODETYPEARTICLE.Value = DBNull.Value;

            SqlParameter vppParamMV_REGLEMENTGROUPE = new SqlParameter("@MV_REGLEMENTGROUPE", SqlDbType.VarChar, 50);
            vppParamMV_REGLEMENTGROUPE.Value = clsPhamouvementstockreglement.MV_REGLEMENTGROUPE;
            if (clsPhamouvementstockreglement.MV_REGLEMENTGROUPE == "")
                vppParamMV_REGLEMENTGROUPE.Value = DBNull.Value;


            SqlParameter vppParamCH_DATEDEBUTCOUVERTURE = new SqlParameter("@CH_DATEDEBUTCOUVERTURE", SqlDbType.DateTime);
            vppParamCH_DATEDEBUTCOUVERTURE.Value = clsPhamouvementstockreglement.CH_DATEDEBUTCOUVERTURE;

            SqlParameter vppParamCH_DATEFINCOUVERTURE = new SqlParameter("@CH_DATEFINCOUVERTURE", SqlDbType.DateTime);
            vppParamCH_DATEFINCOUVERTURE.Value = clsPhamouvementstockreglement.CH_DATEFINCOUVERTURE;


            SqlParameter vppParamMV_NUMPIECERETOUR1 = new SqlParameter("@MV_NUMPIECERETOUR1", SqlDbType.VarChar, 25);
            vppParamMV_NUMPIECERETOUR1.Value = "";

            //Préparation de la commande

            SqlCommand vppSqlCmd = new SqlCommand("PS_COMPTABILISATIONAVECCOMPTEECLATE", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMEROPIECE1);


            vppSqlCmd.Parameters.Add(vppParamMV_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_NOMTIERS);
            vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
            vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTEBANQUE);
            vppSqlCmd.Parameters.Add(vppParamMV_LIBELLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamMONTANTFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMONTANTREMISE);
            vppSqlCmd.Parameters.Add(vppParamMONTANTTVA);
            vppSqlCmd.Parameters.Add(vppParamMONTANTAIRSI);
            vppSqlCmd.Parameters.Add(vppParamMONTANTVERSEMENT);
            vppSqlCmd.Parameters.Add(vppParamRESTEMONTANTFACTURE);
            vppSqlCmd.Parameters.Add(vppParamMONTANTIMPAYER);
            vppSqlCmd.Parameters.Add(vppParamMONTANTTRANSPORT);
            vppSqlCmd.Parameters.Add(vppParamMONTANTFACTURETTC);
            vppSqlCmd.Parameters.Add(vppParamMONTANTASSUREUR);
            vppSqlCmd.Parameters.Add(vppParamMS_UTILISERSUPLUS);
            vppSqlCmd.Parameters.Add(vppParamMV_REFERENCEPIECE);
            vppSqlCmd.Parameters.Add(vppParamFB_IDFOURNISSEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNO_SENS);
            vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMV_MTSURPLUS);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECEANNULER);

            vppSqlCmd.Parameters.Add(vppParamNA_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamTA_CODETYPEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamMV_REGLEMENTGROUPE);
             vppSqlCmd.Parameters.Add(vppParamCH_DATEDEBUTCOUVERTURE); 
            vppSqlCmd.Parameters.Add(vppParamCH_DATEFINCOUVERTURE);          
            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECERETOUR1);
            //Ouverture de la connection et exécution de la commande
            vppParamMV_NUMPIECERETOUR1.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MV_NUMPIECERETOUR1"].Value.ToString();

        }





        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<author>Home Technology</author>
        public string pvgIncrementmvtstockreglement(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement)
        {
            //Préparation des paramètres
           
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;

            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
            vppParamMV_DATEPIECE.Value = clsPhamouvementstockreglement.MV_DATESAISIE;

            SqlParameter vppParamTABLE_NAME = new SqlParameter("@TABLE_NAME", SqlDbType.VarChar, 150);
            vppParamTABLE_NAME.Value = "PHAMOUVEMENTSTOCKREGLEMENT";

            SqlParameter vppParamIN_VALEURID = new SqlParameter("@IN_VALEURID", SqlDbType.VarChar, 150);
            vppParamIN_VALEURID.Value = "";

            SqlParameter vppParamNB_ID = new SqlParameter("@NB_ID ", SqlDbType.Int);
            vppParamNB_ID.Value = 0;

            SqlParameter vppParamMC_REFERENCEPIECE = new SqlParameter("@MC_REFERENCEPIECE", SqlDbType.VarChar, 25);
            vppParamMC_REFERENCEPIECE.Value = "";

            SqlParameter vppParamMV_NUMEROPIECE = new SqlParameter("@MV_NUMEROPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMEROPIECE.Value = "";

            //Préparation de la commande
            SqlCommand vppSqlCmd = new SqlCommand("PS_INCREMENTPHAMOUVEMENTSTOCKREGLEMENT", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamTABLE_NAME);
            vppSqlCmd.Parameters.Add(vppParamIN_VALEURID);
            vppSqlCmd.Parameters.Add(vppParamNB_ID);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_REFERENCEPIECE);
            //Ouverture de la connection et exécution de la commande
            vppParamMC_REFERENCEPIECE.Direction = ParameterDirection.Output;
            vppParamMV_NUMEROPIECE.Direction = ParameterDirection.Output;

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MV_NUMEROPIECE"].Value.ToString();
            //return vppSqlCmd.Parameters["@MV_NUMEROPIECE"].Value.ToString();
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<author>Home Technology</author>
        public string pvgIncrementmvtstockreglementTEMP(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement)
        {
            //Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;

            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
            vppParamMV_DATEPIECE.Value = clsPhamouvementstockreglement.MV_DATEPIECE;

            SqlParameter vppParamTABLE_NAME = new SqlParameter("@TABLE_NAME", SqlDbType.VarChar, 150);
            vppParamTABLE_NAME.Value = "PHAMOUVEMENTSTOCKREGLEMENTTEMP";

            SqlParameter vppParamIN_VALEURID = new SqlParameter("@IN_VALEURID", SqlDbType.VarChar, 150);
            vppParamIN_VALEURID.Value = "";

            SqlParameter vppParamNB_ID = new SqlParameter("@NB_ID ", SqlDbType.Int);
            vppParamNB_ID.Value = 0;

            SqlParameter vppParamMC_REFERENCEPIECE = new SqlParameter("@MC_REFERENCEPIECE", SqlDbType.VarChar, 25);
            vppParamMC_REFERENCEPIECE.Value = "";

            SqlParameter vppParamMV_NUMEROPIECE = new SqlParameter("@MV_NUMEROPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMEROPIECE.Value = "";

            //Préparation de la commande
            SqlCommand vppSqlCmd = new SqlCommand("PS_INCREMENTPHAMOUVEMENTSTOCKREGLEMENTTEMP", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamTABLE_NAME);
            vppSqlCmd.Parameters.Add(vppParamIN_VALEURID);
            vppSqlCmd.Parameters.Add(vppParamNB_ID);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_REFERENCEPIECE);
            //Ouverture de la connection et exécution de la commande
            vppParamMC_REFERENCEPIECE.Direction = ParameterDirection.Output;
            vppParamMV_NUMEROPIECE.Direction = ParameterDirection.Output;

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MV_NUMEROPIECE"].Value.ToString();
            //return vppSqlCmd.Parameters["@MV_NUMEROPIECE"].Value.ToString();
        }




        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 30);
			vppParamMV_NUMPIECE.Value  = clsPhamouvementstockreglement.MV_NUMPIECE ;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstockreglement.AG_CODEAGENCE ;

            SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
			vppParamMR_CODEMODEREGLEMENT.Value  = clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT ;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstockreglement.MS_NUMPIECE ;

            SqlParameter vppParamMV_MONTANTDEBIT = new SqlParameter("@MV_MONTANTDEBIT", SqlDbType.Money);
			vppParamMV_MONTANTDEBIT.Value  = clsPhamouvementstockreglement.MV_MONTANTDEBIT ;

            SqlParameter vppParamMV_MONTANTCREDIT = new SqlParameter("@MV_MONTANTCREDIT", SqlDbType.Money);
			vppParamMV_MONTANTCREDIT.Value  = clsPhamouvementstockreglement.MV_MONTANTCREDIT ;

            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
			vppParamMV_DATEPIECE.Value  = clsPhamouvementstockreglement.MV_DATEPIECE ;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENT  @MV_NUMPIECE, @AG_CODEAGENCE, @MR_CODEMODEREGLEMENT, @MS_NUMPIECE, @MV_MONTANTDEBIT, @MV_MONTANTCREDIT, @MV_DATEPIECE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMV_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamMV_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);


		}



        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MV_DATEPIECE, MS_NUMPIECE, MV_NUMSEQUENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgExtourne(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;
            SqlParameter vppParamMV_DATESAISIE = new SqlParameter("@MV_DATESAISIE", SqlDbType.DateTime);
            vppParamMV_DATESAISIE.Value = clsPhamouvementstockreglement.MV_DATESAISIE;
            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
            vppParamMV_DATEPIECE.Value = clsPhamouvementstockreglement.MV_DATEPIECE;
            SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMPIECE.Value = clsPhamouvementstockreglement.MV_NUMPIECE;
            SqlParameter vppParamMV_NUMPIECE1 = new SqlParameter("@MV_NUMPIECE1", SqlDbType.VarChar, 50);
            vppParamMV_NUMPIECE1.Value = clsPhamouvementstockreglement.MV_NUMPIECE1;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockreglement.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_EXTOURNEOPERATION1  @AG_CODEAGENCE1, @MV_DATESAISIE, @MV_DATEPIECE, @MV_NUMPIECE,@MV_NUMPIECE1,@OP_CODEOPERATEUR,0,@CODECRYPTAGE1";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMV_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE1);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


     


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglement>clsPhamouvementstockreglement</param>
        ///<author>Home Technology</author>
        public void pvgMajReferencePiece(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementstockreglement.EN_CODEENTREPOT;

            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
            vppParamMV_DATEPIECE.Value = clsPhamouvementstockreglement.MV_DATEPIECE;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MV_NUMEROPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementstockreglement.MV_NUMEROPIECE;

            SqlParameter vppParamMV_NUMSEQUENCE = new SqlParameter("@MV_NUMSEQUENCE", SqlDbType.VarChar, 50);
            vppParamMV_NUMSEQUENCE.Value = clsPhamouvementstockreglement.MV_NUMSEQUENCE;

            SqlParameter vppParamMV_REFERENCEPIECE = new SqlParameter("@MV_REFERENCEPIECE", SqlDbType.VarChar, 50);
            vppParamMV_REFERENCEPIECE.Value = clsPhamouvementstockreglement.MV_REFERENCEPIECE;

            SqlParameter vppParamMV_LIBELLEOPERATION = new SqlParameter("@MV_LIBELLEOPERATION", SqlDbType.VarChar, 50);
            vppParamMV_LIBELLEOPERATION.Value = clsPhamouvementstockreglement.MV_LIBELLEOPERATION;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTE.Value = clsPhamouvementstockreglement.PL_NUMCOMPTE;

            SqlParameter vppParamMV_MONTANTDEBIT = new SqlParameter("@MV_MONTANTDEBIT", SqlDbType.Money);
            vppParamMV_MONTANTDEBIT.Value = clsPhamouvementstockreglement.MV_MONTANTDEBIT;

            SqlParameter vppParamMV_MONTANTCREDIT = new SqlParameter("@MV_MONTANTCREDIT", SqlDbType.Money);
            vppParamMV_MONTANTCREDIT.Value = clsPhamouvementstockreglement.MV_MONTANTCREDIT;

            //SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.VarChar, 50);
            //vppParamJO_CODEJOURNAL.Value = clsPhamouvementstockreglement.JO_CODEJOURNAL;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 50);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockreglement.TYPEOPERATION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_MAJREFERENCEPIECE  @AG_CODEAGENCE,@EN_CODEENTREPOT, @MV_DATEPIECE,  @MV_NUMEROPIECE,@MV_NUMSEQUENCE,@MV_REFERENCEPIECE,@MV_LIBELLEOPERATION,@PL_NUMCOMPTE,@MV_MONTANTDEBIT,@MV_MONTANTCREDIT,@TYPEOPERATION,@CODECRYPTAGE";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamMV_REFERENCEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_LIBELLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamMV_MONTANTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamMV_MONTANTCREDIT);
            //vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }




		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENT  @MV_NUMPIECE, @AG_CODEAGENCE, @MR_CODEMODEREGLEMENT, @MS_NUMPIECE, '' , '' , '' ,'' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglement </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglement> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE, MV_MONTANTDEBIT, MV_MONTANTCREDIT, MV_DATEPIECE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<clsPhamouvementstockreglement>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglement clsPhamouvementstockreglement = new clsPhamouvementstockreglement();
					clsPhamouvementstockreglement.MV_NUMPIECE = clsDonnee.vogDataReader["MV_NUMPIECE"].ToString();
					clsPhamouvementstockreglement.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = clsDonnee.vogDataReader["MR_CODEMODEREGLEMENT"].ToString();
					clsPhamouvementstockreglement.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementstockreglement.MV_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["MV_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["MV_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MV_DATEPIECE"].ToString());
					clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockreglements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglement </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglement> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<clsPhamouvementstockreglement>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE, MV_MONTANTDEBIT, MV_MONTANTCREDIT, MV_DATEPIECE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockreglement clsPhamouvementstockreglement = new clsPhamouvementstockreglement();
					clsPhamouvementstockreglement.MV_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MV_NUMPIECE"].ToString();
					clsPhamouvementstockreglement.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockreglement.MR_CODEMODEREGLEMENT = Dataset.Tables["TABLE"].Rows[Idx]["MR_CODEMODEREGLEMENT"].ToString();
					clsPhamouvementstockreglement.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhamouvementstockreglement.MV_MONTANTDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MV_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglement.MV_MONTANTCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MV_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglement.MV_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MV_DATEPIECE"].ToString());
					clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockreglements;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetSoldeCompteEcranOD(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);

            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MR_CODEMODEREGLEMENT=@MR_CODEMODEREGLEMENT ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PL_NUMCOMPTEGENERAL", "@TI_NUMTIERS", "@NC_CODENATURECOMPTE", "@DATEJOURNEE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] , vppCritere[4]};

            this.vapRequete = "SELECT [dbo].[FC_SOLDECOMPTEECRANOD](@AG_CODEAGENCE,@PL_NUMCOMPTEGENERAL,@TI_NUMTIERS,@NC_CODENATURECOMPTE,@DATEJOURNEE,@CODECRYPTAGE)";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


        public DataSet pvgMouvementResumeReglement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT *  FROM  dbo.FT_PHAMOUVEMENTSTOCKRESUMERREGLEMENT(@AG_CODEAGENCE,@MS_NUMPIECE,@TR_MATRICULE,@DATEJOURNEE,@TYPEOPERATION,@OP_CODEOPERATEUREDITION,@CODECRYPTAGE) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@TR_MATRICULE", "@DATEJOURNEE", "@TYPEOPERATION", "@OP_CODEOPERATEUREDITION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4],vppCritere[5], clsDonnee.vogCleCryptage };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgEtatMouvementStockReglementTemp(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglement.AG_CODEAGENCE;
            SqlParameter vppParamMV_DATEPIECE = new SqlParameter("@MV_DATEPIECE", SqlDbType.DateTime);
            vppParamMV_DATEPIECE.Value = clsPhamouvementstockreglement.MV_DATEPIECE;

            SqlParameter vppParamMV_DATEPIECE1 = new SqlParameter("@MV_DATEPIECE1", SqlDbType.DateTime);
            vppParamMV_DATEPIECE1.Value = clsPhamouvementstockreglement.MV_DATESAISIE;

            SqlParameter vppParamMV_NUMPIECE = new SqlParameter("@MV_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMV_NUMPIECE.Value = clsPhamouvementstockreglement.MV_NUMPIECE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockreglement.OP_CODEOPERATEUR;

            SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.VarChar, 50);
            vppParamJO_CODEJOURNAL.Value = clsPhamouvementstockreglement.JO_CODEJOURNAL;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_ETATPHAMOUVEMENTSTOCKREGLEMENTTEMP  @AG_CODEAGENCE1,  @MV_DATEPIECE,@MV_DATEPIECE1, @MV_NUMPIECE,@OP_CODEOPERATEUR,@JO_CODEJOURNAL,0,@CODECRYPTAGE1";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMV_DATEPIECE1);
            vppSqlCmd.Parameters.Add(vppParamMV_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande

            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        public DataSet pvgMouvementResumeReglementGeneral(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT *  FROM  dbo.FT_PHAMOUVEMENTSTOCKRESUMERREGLEMENTGENERAL(@AG_CODEAGENCE,@TI_IDTIERS,@DATEJOURNEE,@TYPEOPERATION,@CODECRYPTAGE) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TI_IDTIERS", "@DATEJOURNEE", "@TYPEOPERATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3],  clsDonnee.vogCleCryptage };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MV_DATEPIECE, MS_NUMPIECE, MV_NUMSEQUENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgNumeroBordereau(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_DATEPIECE", "@MV_NUMPIECE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = "SELECT  [dbo].[FC_PHAFORMATNUMEROBORDEREAU](@AG_CODEAGENCE,@MV_DATEPIECE,@MV_NUMPIECE,@CODECRYPTAGE) ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetRecudeCaisse(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_NUMPIECE", "@MV_NUMBORDEREAU" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] , vppCritere[1] , vppCritere[2] };
            this.vapRequete = "	EXEC [dbo].[PS_ETATRECU] @AG_CODEAGENCE,@MV_NUMPIECE,@MV_NUMBORDEREAU,@CODECRYPTAGE ";// + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRecudeCaisseTemp(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_NUMPIECE", "@MV_NUMBORDEREAU" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] , vppCritere[1] , vppCritere[2] };
            this.vapRequete = "	EXEC [dbo].[PS_ETATRECUTEMP] @AG_CODEAGENCE,@MV_NUMPIECE,@MV_NUMBORDEREAU,@CODECRYPTAGE ";// + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRegmentGroupeListe(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@NUMEROBORDEREAU", "@MS_DATEPIECEDEBUT", "@MS_DATEPIECEFIN", "@TI_NUMTIERS", "@TI_DENOMINATION", "@MS_ANNULATIONPIECE", "@TP_CODETYPETIERS", "@OP_CODEOPERATEUREDITION", "@AR_CODEARTICLE1", "@GP_CODEGROUPE", "@MR_CODEMODEREGLEMENT", "@CO_NUMCOMMERCIAL", "@CO_NOMPRENOM" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10] , vppCritere[11], vppCritere[12], vppCritere[13] };
            this.vapRequete = "	EXEC [dbo].[PS_REGLEMENTGROUPELISTE] @AG_CODEAGENCE,@NUMEROBORDEREAU,@MS_DATEPIECEDEBUT,@MS_DATEPIECEFIN,@TI_NUMTIERS,@TI_DENOMINATION,@MS_ANNULATIONPIECE,@TP_CODETYPETIERS,@OP_CODEOPERATEUREDITION,@AR_CODEARTICLE1,@GP_CODEGROUPE,@MR_CODEMODEREGLEMENT,@CO_NUMCOMMERCIAL,@CO_NOMPRENOM,@CODECRYPTAGE ";// + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MV_NUMPIECE , MV_MONTANTDEBIT FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }





        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, MR_CODEMODEREGLEMENT, JO_CODEJOURNAL, CO_CODECOMPTE, PL_CODENUMCOMPTE, PI_CODEPIECE, TS_CODETYPESCHEMACOMPTABLE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRecherche(clsDonnee clsDonnee, params string[] vppCritere)
        {



            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@NUMEROBORDEREAU", "@MC_REFERENCEPIECE", "@MC_LIBELLEOPERATION", "@MC_NUMPIECETIERS", "@MC_NOMTIERS", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@MC_MONTANTDEBIT1", "@MC_MONTANTDEBIT2", "@MC_CREDIT", "@MC_DEBIT", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] {  vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11], vppCritere[12], vppCritere[13],vppCritere[14],clsDonnee.vogCleCryptage };

            this.vapRequete = "EXEC [dbo].[PS_MOUVEMENTCOMPTABLE] @AG_CODEAGENCE,@EN_CODEENTREPOT,@NUMEROBORDEREAU,@MC_REFERENCEPIECE,@MC_LIBELLEOPERATION,@MC_NUMPIECETIERS,@MC_NOMTIERS,@MC_DATEPIECE1,@MC_DATEPIECE2,@MC_MONTANTDEBIT1,@MC_MONTANTDEBIT2,@MC_CREDIT,@MC_DEBIT,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE)</summary>
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
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND MR_CODEMODEREGLEMENT=@MR_CODEMODEREGLEMENT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@MS_NUMPIECE", "@AG_CODEAGENCE", "@MR_CODEMODEREGLEMENT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE MV_NUMPIECE=@MV_NUMPIECE AND AG_CODEAGENCE=@AG_CODEAGENCE AND MR_CODEMODEREGLEMENT=@MR_CODEMODEREGLEMENT AND MS_NUMPIECE=@MS_NUMPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@MV_NUMPIECE","@AG_CODEAGENCE","@MR_CODEMODEREGLEMENT","@MS_NUMPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE)</summary>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@NO_CODENATUREOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                
            }
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere2(clsDonnee clsDonnee, params string[] vppCritere)
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MV_DATEPIECE=@MV_DATEPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_DATEPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MV_DATEPIECE=@MV_DATEPIECE  AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_DATEPIECE", "@NO_CODENATUREOPERATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                break;

                

            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere3(clsDonnee clsDonnee, params string[] vppCritere)
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MV_DATEPIECE=@MV_DATEPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_DATEPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MV_DATEPIECE=@MV_DATEPIECE  AND MV_NUMEROPIECE=@MV_NUMEROPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MV_DATEPIECE", "@MV_NUMEROPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;



            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
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
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  DT_NUMEROTRANSACTION=@DT_NUMEROTRANSACTION";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@DT_NUMEROTRANSACTION" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;


            }
        }


    }
}
