using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementStockdetailWSDAL: ITableDAL<clsPhamouvementStockdetail>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(MD_NUMSEQUENCE) AS MD_NUMSEQUENCE  FROM dbo.PhamouvementStockDETAIL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(MD_NUMSEQUENCE) AS MD_NUMSEQUENCE  FROM dbo.PhamouvementStockDETAIL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(MD_NUMSEQUENCE) AS MD_NUMSEQUENCE  FROM dbo.PhamouvementStockDETAIL " ;
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
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(MD_NUMEROPIECE) AS MD_NUMEROPIECE  FROM dbo.PhamouvementStockDETAIL " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }





		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockdetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockdetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , AR_CODEARTICLE  , MS_NUMPIECE  , MD_PRIXUNITAIREACHAT  , MD_PRIXUNITAIREVENTE  , MD_STATUTACCESSOIRE  , MD_TAUXCOMMISSION  , MD_MONTANTCOMMISSION  , MD_TAUXREMISE  , MD_MONTANTREMISE  , MD_ASDI  , MD_TVA  , MD_QUANTITESORTIE  , MD_QUANTITEENTREE  , MD_DATEPEREMPTION  , MD_ANNULATIONPIECE  FROM dbo.PhamouvementStockDETAIL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementStockdetail clsPhamouvementStockdetail = new clsPhamouvementStockdetail();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockdetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementStockdetail.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhamouvementStockdetail.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementStockdetail.MD_PRIXUNITAIREACHAT = double.Parse(clsDonnee.vogDataReader["MD_PRIXUNITAIREACHAT"].ToString());
					clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTE = double.Parse(clsDonnee.vogDataReader["MD_PRIXUNITAIREVENTE"].ToString());
					clsPhamouvementStockdetail.MD_STATUTACCESSOIRE = clsDonnee.vogDataReader["MD_STATUTACCESSOIRE"].ToString();
					clsPhamouvementStockdetail.MD_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["MD_TAUXCOMMISSION"].ToString());
					clsPhamouvementStockdetail.MD_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["MD_MONTANTCOMMISSION"].ToString());
					clsPhamouvementStockdetail.MD_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MD_TAUXREMISE"].ToString());
					clsPhamouvementStockdetail.MD_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["MD_MONTANTREMISE"].ToString());
					clsPhamouvementStockdetail.MD_ASDI = float.Parse(clsDonnee.vogDataReader["MD_ASDI"].ToString());
					clsPhamouvementStockdetail.MD_TVA = float.Parse(clsDonnee.vogDataReader["MD_TVA"].ToString());
					clsPhamouvementStockdetail.MD_QUANTITESORTIE = float.Parse(clsDonnee.vogDataReader["MD_QUANTITESORTIE"].ToString());
					clsPhamouvementStockdetail.MD_QUANTITEENTREE = float.Parse(clsDonnee.vogDataReader["MD_QUANTITEENTREE"].ToString());
					clsPhamouvementStockdetail.MD_DATEPEREMPTION = DateTime.Parse(clsDonnee.vogDataReader["MD_DATEPEREMPTION"].ToString());
					clsPhamouvementStockdetail.MD_ANNULATIONPIECE = clsDonnee.vogDataReader["MD_ANNULATIONPIECE"].ToString();
                    //clsPhamouvementStockdetail.CH_IDCHAUFFEUR = clsDonnee.vogDataReader["CH_IDCHAUFFEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementStockdetail;
		}




        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPhamouvementStockdetail comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPhamouvementStockdetail pvgTableLabelDatePeremption(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND AR_CODEARTICLE=@AR_CODEARTICLE AND MD_DATEPEREMPTION<>'01/01/1900' ORDER BY MD_DATEPEREMPTION DESC ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@NO_CODENATUREOPERATION", "@AR_CODEARTICLE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = "SELECT TOP 1 AG_CODEAGENCE  , AR_CODEARTICLE  , MS_NUMPIECE  , MD_PRIXUNITAIREACHAT  , MD_PRIXUNITAIREVENTE  , MD_STATUTACCESSOIRE  , MD_TAUXCOMMISSION  , MD_MONTANTCOMMISSION  , MD_TAUXREMISE  , MD_MONTANTREMISE  , MD_ASDI  , MD_TVA  , MD_QUANTITESORTIE  , MD_QUANTITEENTREE  , MD_DATEPEREMPTION  , MD_ANNULATIONPIECE  FROM dbo.PhamouvementStockDETAIL " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsPhamouvementStockdetail clsPhamouvementStockdetail = new clsPhamouvementStockdetail();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPhamouvementStockdetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsPhamouvementStockdetail.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPhamouvementStockdetail.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
                    clsPhamouvementStockdetail.MD_PRIXUNITAIREACHAT = double.Parse(clsDonnee.vogDataReader["MD_PRIXUNITAIREACHAT"].ToString());
                    clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTE = double.Parse(clsDonnee.vogDataReader["MD_PRIXUNITAIREVENTE"].ToString());
                    clsPhamouvementStockdetail.MD_STATUTACCESSOIRE = clsDonnee.vogDataReader["MD_STATUTACCESSOIRE"].ToString();
                    clsPhamouvementStockdetail.MD_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["MD_TAUXCOMMISSION"].ToString());
                    clsPhamouvementStockdetail.MD_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["MD_MONTANTCOMMISSION"].ToString());
                    clsPhamouvementStockdetail.MD_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MD_TAUXREMISE"].ToString());
                    clsPhamouvementStockdetail.MD_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["MD_MONTANTREMISE"].ToString());
                    clsPhamouvementStockdetail.MD_ASDI = float.Parse(clsDonnee.vogDataReader["MD_ASDI"].ToString());
                    clsPhamouvementStockdetail.MD_TVA = float.Parse(clsDonnee.vogDataReader["MD_TVA"].ToString());
                    clsPhamouvementStockdetail.MD_QUANTITESORTIE = float.Parse(clsDonnee.vogDataReader["MD_QUANTITESORTIE"].ToString());
                    clsPhamouvementStockdetail.MD_QUANTITEENTREE = float.Parse(clsDonnee.vogDataReader["MD_QUANTITEENTREE"].ToString());
                    clsPhamouvementStockdetail.MD_DATEPEREMPTION = DateTime.Parse(clsDonnee.vogDataReader["MD_DATEPEREMPTION"].ToString());
                    clsPhamouvementStockdetail.MD_ANNULATIONPIECE = clsDonnee.vogDataReader["MD_ANNULATIONPIECE"].ToString();
                    //clsPhamouvementStockdetail.CH_IDCHAUFFEUR = clsDonnee.vogDataReader["CH_IDCHAUFFEUR"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPhamouvementStockdetail;
        }




        public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementStockdetail clsPhamouvementStockdetail)
        {

        }


		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockdetail>clsPhamouvementStockdetail</param>
		///<author>Home Technology</author>
        public string  pvgMiseajour(clsDonnee clsDonnee, clsPhamouvementStockdetail clsPhamouvementStockdetail)
		{
			//Préparation des paramètres
            SqlParameter vppParamMD_NUMSEQUENCE = new SqlParameter("@MD_NUMSEQUENCE", SqlDbType.VarChar, 50);
			vppParamMD_NUMSEQUENCE.Value  = clsPhamouvementStockdetail.MD_NUMSEQUENCE ;

			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementStockdetail.AG_CODEAGENCE ;

			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhamouvementStockdetail.AR_CODEARTICLE ;

			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar,50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementStockdetail.MS_NUMPIECE ;

			SqlParameter vppParamMD_PRIXUNITAIREACHAT = new SqlParameter("@MD_PRIXUNITAIREACHAT", SqlDbType.Money);
			vppParamMD_PRIXUNITAIREACHAT.Value  = clsPhamouvementStockdetail.MD_PRIXUNITAIREACHAT ;

			SqlParameter vppParamMD_PRIXUNITAIREVENTE = new SqlParameter("@MD_PRIXUNITAIREVENTE", SqlDbType.Money);
			vppParamMD_PRIXUNITAIREVENTE.Value  = clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTE ;

			SqlParameter vppParamMD_STATUTACCESSOIRE = new SqlParameter("@MD_STATUTACCESSOIRE", SqlDbType.VarChar, 1);
			vppParamMD_STATUTACCESSOIRE.Value  = clsPhamouvementStockdetail.MD_STATUTACCESSOIRE ;

			SqlParameter vppParamMD_TAUXCOMMISSION = new SqlParameter("@MD_TAUXCOMMISSION", SqlDbType.Float);
			vppParamMD_TAUXCOMMISSION.Value  = clsPhamouvementStockdetail.MD_TAUXCOMMISSION ;

			SqlParameter vppParamMD_MONTANTCOMMISSION = new SqlParameter("@MD_MONTANTCOMMISSION", SqlDbType.Money);
			vppParamMD_MONTANTCOMMISSION.Value  = clsPhamouvementStockdetail.MD_MONTANTCOMMISSION ;

			SqlParameter vppParamMD_TAUXREMISE = new SqlParameter("@MD_TAUXREMISE", SqlDbType.Float);
			vppParamMD_TAUXREMISE.Value  = clsPhamouvementStockdetail.MD_TAUXREMISE ;

			SqlParameter vppParamMD_MONTANTREMISE = new SqlParameter("@MD_MONTANTREMISE", SqlDbType.Money);
			vppParamMD_MONTANTREMISE.Value  = clsPhamouvementStockdetail.MD_MONTANTREMISE ;

			SqlParameter vppParamMD_ASDI = new SqlParameter("@MD_ASDI", SqlDbType.Float);
			vppParamMD_ASDI.Value  = clsPhamouvementStockdetail.MD_ASDI ;

			SqlParameter vppParamMD_TVA = new SqlParameter("@MD_TVA", SqlDbType.Float);
			vppParamMD_TVA.Value  = clsPhamouvementStockdetail.MD_TVA ;

			SqlParameter vppParamMD_QUANTITESORTIE = new SqlParameter("@MD_QUANTITESORTIE", SqlDbType.Float);
			vppParamMD_QUANTITESORTIE.Value  = clsPhamouvementStockdetail.MD_QUANTITESORTIE ;

			SqlParameter vppParamMD_QUANTITEENTREE = new SqlParameter("@MD_QUANTITEENTREE", SqlDbType.Float);
			vppParamMD_QUANTITEENTREE.Value  = clsPhamouvementStockdetail.MD_QUANTITEENTREE ;

            SqlParameter vppParamMD_QUANTITEPERDUE = new SqlParameter("@MD_QUANTITEPERDUE", SqlDbType.Float);
            vppParamMD_QUANTITEPERDUE.Value = clsPhamouvementStockdetail.MD_QUANTITEPERDUE;
            SqlParameter vppParamMD_QUANTITEPERTEFICTIF = new SqlParameter("@MD_QUANTITEPERTEFICTIF", SqlDbType.Float);
            vppParamMD_QUANTITEPERTEFICTIF.Value = clsPhamouvementStockdetail.MD_QUANTITEPERTEFICTIF;
            SqlParameter vppParamMD_QUANTITEGAGNEE = new SqlParameter("@MD_QUANTITEGAGNEE", SqlDbType.Float);
            vppParamMD_QUANTITEGAGNEE.Value = clsPhamouvementStockdetail.MD_QUANTITEGAGNEE;

           

			SqlParameter vppParamMD_DATEPEREMPTION = new SqlParameter("@MD_DATEPEREMPTION", SqlDbType.DateTime);
			vppParamMD_DATEPEREMPTION.Value  = clsPhamouvementStockdetail.MD_DATEPEREMPTION ;

			SqlParameter vppParamMD_ANNULATIONPIECE = new SqlParameter("@MD_ANNULATIONPIECE", SqlDbType.VarChar, 1);
			vppParamMD_ANNULATIONPIECE.Value  = clsPhamouvementStockdetail.MD_ANNULATIONPIECE ;

            SqlParameter vppParamMD_DESCRIPTION = new SqlParameter("@MD_DESCRIPTION", SqlDbType.VarChar, 1000);
            vppParamMD_DESCRIPTION.Value = clsPhamouvementStockdetail.MD_DESCRIPTION;

            SqlParameter vppParamMD_NUMEROPIECE = new SqlParameter("@MD_NUMEROPIECE", SqlDbType.VarChar, 50);
            vppParamMD_NUMEROPIECE.Value = clsPhamouvementStockdetail.MD_NUMEROPIECE;


            SqlParameter vppParamMD_MONTANTVERSE = new SqlParameter("@MD_MONTANTVERSE", SqlDbType.Money);
            vppParamMD_MONTANTVERSE.Value = clsPhamouvementStockdetail.MD_MONTANTVERSE;

            SqlParameter vppParamMD_DATERETRAIT = new SqlParameter("@MD_DATERETRAIT", SqlDbType.DateTime);
            vppParamMD_DATERETRAIT.Value = clsPhamouvementStockdetail.MD_DATERETRAIT;
            if (clsPhamouvementStockdetail.MD_DATERETRAIT.ToShortDateString() == "01/01/0001") vppParamMD_DATERETRAIT.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMD_REMETTANT = new SqlParameter("@MD_REMETTANT", SqlDbType.VarChar, 150);
            vppParamMD_REMETTANT.Value = clsPhamouvementStockdetail.MD_REMETTANT;


            //SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.BigInt);
            //vppParamCH_IDCHAUFFEUR.Value = clsPhamouvementStockdetail.CH_IDCHAUFFEUR;
            //if (clsPhamouvementStockdetail.CH_IDCHAUFFEUR == "")
            //    vppParamCH_IDCHAUFFEUR.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementStockdetail.TYPEOPERATION;


            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementStockdetail.NO_CODENATUREOPERATION;
            if (clsPhamouvementStockdetail.NO_CODENATUREOPERATION == "")
                vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementStockdetail.EN_CODEENTREPOT;
            if (clsPhamouvementStockdetail.EN_CODEENTREPOT == "")
                vppParamEN_CODEENTREPOT.Value = DBNull.Value;

            SqlParameter vppParamMD_MONTANTTVA = new SqlParameter("@MD_MONTANTTVA", SqlDbType.Money);
            vppParamMD_MONTANTTVA.Value = clsPhamouvementStockdetail.MD_MONTANTTVA;

            SqlParameter vppParamMD_MONTANTASDI = new SqlParameter("@MD_MONTANTASDI", SqlDbType.Money);
            vppParamMD_MONTANTASDI.Value = clsPhamouvementStockdetail.MD_MONTANTASDI;

            SqlParameter vppParamMD_NOMBRESAC = new SqlParameter("@MD_NOMBRESAC", SqlDbType.Money);
            vppParamMD_NOMBRESAC.Value = clsPhamouvementStockdetail.MD_NOMBRESAC;

            SqlParameter vppParamMD_POIDSNET = new SqlParameter("@MD_POIDSNET", SqlDbType.Money);
            vppParamMD_POIDSNET.Value = clsPhamouvementStockdetail.MD_POIDSNET;

            SqlParameter vppParamMD_NOMBRESACTRANSMIS = new SqlParameter("@MD_NOMBRESACTRANSMIS", SqlDbType.Money);
            vppParamMD_NOMBRESACTRANSMIS.Value = clsPhamouvementStockdetail.MD_NOMBRESACTRANSMIS;

            SqlParameter vppParamMD_NOMBRESACACCEPTE = new SqlParameter("@MD_NOMBRESACACCEPTE", SqlDbType.Money);
            vppParamMD_NOMBRESACACCEPTE.Value = clsPhamouvementStockdetail.MD_NOMBRESACACCEPTE;

            SqlParameter vppParamMD_REFACTION = new SqlParameter("@MD_REFACTION", SqlDbType.Money);
            vppParamMD_REFACTION.Value = clsPhamouvementStockdetail.MD_REFACTION;

            SqlParameter vppParamAR_CODEARTICLE1 = new SqlParameter("@AR_CODEARTICLE1", SqlDbType.VarChar, 7);
            vppParamAR_CODEARTICLE1.Value = clsPhamouvementStockdetail.AR_CODEARTICLE1;
            if (clsPhamouvementStockdetail.AR_CODEARTICLE1 == "")
                vppParamAR_CODEARTICLE1.Value = DBNull.Value;

            SqlParameter vppParamMF_IDFILTRAGEDESTOCK = new SqlParameter("@MF_IDFILTRAGEDESTOCK", SqlDbType.VarChar, 50);
            vppParamMF_IDFILTRAGEDESTOCK.Value = clsPhamouvementStockdetail.MF_IDFILTRAGEDESTOCK;

            SqlParameter vppParamME_IDFILTRAGEDESTOCKEXPIRATION = new SqlParameter("@ME_IDFILTRAGEDESTOCKEXPIRATION", SqlDbType.VarChar, 50);
            vppParamME_IDFILTRAGEDESTOCKEXPIRATION.Value = clsPhamouvementStockdetail.ME_IDFILTRAGEDESTOCKEXPIRATION;

            SqlParameter vppParamMF_IDFILTRAGEDESTOCKM1 = new SqlParameter("@MF_IDFILTRAGEDESTOCKM1", SqlDbType.VarChar, 50);
            vppParamMF_IDFILTRAGEDESTOCKM1.Value = clsPhamouvementStockdetail.MF_IDFILTRAGEDESTOCKM1;

            SqlParameter vppParamMF_IDFILTRAGEDESTOCKM2 = new SqlParameter("@MF_IDFILTRAGEDESTOCKM2", SqlDbType.VarChar, 50);
            vppParamMF_IDFILTRAGEDESTOCKM2.Value = clsPhamouvementStockdetail.MF_IDFILTRAGEDESTOCKM2;

            SqlParameter vppParamTI_IDTIERSPHARMACIE = new SqlParameter("@TI_IDTIERSPHARMACIE", SqlDbType.VarChar, 50);
            vppParamTI_IDTIERSPHARMACIE.Value = clsPhamouvementStockdetail.TI_IDTIERSPHARMACIE;
            if (clsPhamouvementStockdetail.TI_IDTIERSPHARMACIE == "")
                vppParamTI_IDTIERSPHARMACIE.Value = DBNull.Value;

            SqlParameter vppParamMD_MONTANTASSUREUR = new SqlParameter("@MD_MONTANTASSUREUR", SqlDbType.Money);
            vppParamMD_MONTANTASSUREUR.Value = clsPhamouvementStockdetail.MD_MONTANTASSUREUR;

             SqlParameter vppParamMD_MONTANTESCOMPTE = new SqlParameter("@MD_MONTANTESCOMPTE", SqlDbType.Money);
            vppParamMD_MONTANTESCOMPTE.Value = clsPhamouvementStockdetail.MD_MONTANTESCOMPTE;

            SqlParameter vppParamMD_TAUXESCOMPTE = new SqlParameter("@MD_TAUXESCOMPTE", SqlDbType.Money);
            vppParamMD_TAUXESCOMPTE.Value = clsPhamouvementStockdetail.MD_TAUXESCOMPTE;

            SqlParameter vppParamMD_TAUXREMBOURSEMENT = new SqlParameter("@MD_TAUXREMBOURSEMENT", SqlDbType.Money);
            vppParamMD_TAUXREMBOURSEMENT.Value = clsPhamouvementStockdetail.MD_TAUXREMBOURSEMENT;

            SqlParameter vppParamMD_MONTANTREMISEUNITAIRE = new SqlParameter("@MD_MONTANTREMISEUNITAIRE", SqlDbType.Money);
            vppParamMD_MONTANTREMISEUNITAIRE.Value = clsPhamouvementStockdetail.MD_MONTANTREMISEUNITAIRE;

            SqlParameter vppParamMD_MONTANTESCOMPTEUNITAIRE = new SqlParameter("@MD_MONTANTESCOMPTEUNITAIRE", SqlDbType.Money);
            vppParamMD_MONTANTESCOMPTEUNITAIRE.Value = clsPhamouvementStockdetail.MD_MONTANTESCOMPTEUNITAIRE;

            SqlParameter vppParamMD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = new SqlParameter("MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE", SqlDbType.Money);
            vppParamMD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE.Value = clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE;


            SqlParameter vppParamJF_CODETYPEJOURFACTURATION = new SqlParameter("@JF_CODETYPEJOURFACTURATION", SqlDbType.VarChar, 50);
            vppParamJF_CODETYPEJOURFACTURATION.Value = clsPhamouvementStockdetail.JF_CODETYPEJOURFACTURATION;
            if (clsPhamouvementStockdetail.JF_CODETYPEJOURFACTURATION == "")
                vppParamJF_CODETYPEJOURFACTURATION.Value = DBNull.Value;

            SqlParameter vppParamLF_CODELIEUFACTURATION = new SqlParameter("@LF_CODELIEUFACTURATION", SqlDbType.VarChar, 50);
            vppParamLF_CODELIEUFACTURATION.Value = clsPhamouvementStockdetail.LF_CODELIEUFACTURATION;
            if (clsPhamouvementStockdetail.LF_CODELIEUFACTURATION == "")
                vppParamLF_CODELIEUFACTURATION.Value = DBNull.Value;



            SqlParameter vppParamMD_NUMSEQUENCERETOUR = new SqlParameter("@MD_NUMSEQUENCERETOUR", SqlDbType.VarChar, 50);
            vppParamMD_NUMSEQUENCERETOUR.Value = "";



            SqlCommand vppSqlCmd = new SqlCommand("PS_PHAMOUVEMENTSTOCKDETAIL", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Préparation de la commande

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMD_PRIXUNITAIREACHAT);
			vppSqlCmd.Parameters.Add(vppParamMD_PRIXUNITAIREVENTE);
			vppSqlCmd.Parameters.Add(vppParamMD_STATUTACCESSOIRE);
			vppSqlCmd.Parameters.Add(vppParamMD_TAUXCOMMISSION);
			vppSqlCmd.Parameters.Add(vppParamMD_MONTANTCOMMISSION);
			vppSqlCmd.Parameters.Add(vppParamMD_TAUXREMISE);
			vppSqlCmd.Parameters.Add(vppParamMD_MONTANTREMISE);
			vppSqlCmd.Parameters.Add(vppParamMD_ASDI);
			vppSqlCmd.Parameters.Add(vppParamMD_TVA);
			vppSqlCmd.Parameters.Add(vppParamMD_QUANTITESORTIE);
			vppSqlCmd.Parameters.Add(vppParamMD_QUANTITEENTREE);
            vppSqlCmd.Parameters.Add(vppParamMD_QUANTITEPERDUE);
            vppSqlCmd.Parameters.Add(vppParamMD_QUANTITEPERTEFICTIF);
            vppSqlCmd.Parameters.Add(vppParamMD_QUANTITEGAGNEE);

			vppSqlCmd.Parameters.Add(vppParamMD_DATEPEREMPTION);
			vppSqlCmd.Parameters.Add(vppParamMD_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamMD_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamMD_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamMD_MONTANTVERSE);
            vppSqlCmd.Parameters.Add(vppParamMD_DATERETRAIT);
            vppSqlCmd.Parameters.Add(vppParamMD_REMETTANT);
            //vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamMD_MONTANTTVA);
            vppSqlCmd.Parameters.Add(vppParamMD_MONTANTASDI);
            vppSqlCmd.Parameters.Add(vppParamMD_NOMBRESAC);
            vppSqlCmd.Parameters.Add(vppParamMD_POIDSNET);
            vppSqlCmd.Parameters.Add(vppParamMD_NOMBRESACTRANSMIS);
            vppSqlCmd.Parameters.Add(vppParamMD_NOMBRESACACCEPTE);
            vppSqlCmd.Parameters.Add(vppParamMD_REFACTION);
            vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE1);
            vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCK);
            vppSqlCmd.Parameters.Add(vppParamME_IDFILTRAGEDESTOCKEXPIRATION);
            vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCKM1);
            vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCKM2);
            //vppSqlCmd.Parameters.Add(vppParamMF_IDFILTRAGEDESTOCKM2);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSPHARMACIE);
            vppSqlCmd.Parameters.Add(vppParamMD_MONTANTASSUREUR);
            vppSqlCmd.Parameters.Add(vppParamMD_MONTANTESCOMPTE);
             vppSqlCmd.Parameters.Add(vppParamMD_TAUXESCOMPTE);
             vppSqlCmd.Parameters.Add(vppParamMD_TAUXREMBOURSEMENT);                     
             vppSqlCmd.Parameters.Add(vppParamMD_MONTANTREMISEUNITAIRE);  
             vppSqlCmd.Parameters.Add(vppParamMD_MONTANTESCOMPTEUNITAIRE);               
             vppSqlCmd.Parameters.Add(vppParamMD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE);

            vppSqlCmd.Parameters.Add(vppParamJF_CODETYPEJOURFACTURATION);
            vppSqlCmd.Parameters.Add(vppParamLF_CODELIEUFACTURATION);



            vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCERETOUR);

            vppParamMD_NUMSEQUENCERETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MD_NUMSEQUENCERETOUR"].Value.ToString();

        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockdetail>clsPhamouvementStockdetail</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementStockdetail clsPhamouvementStockdetail,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementStockdetail.MS_NUMPIECE;

            SqlParameter vppParamMD_NUMSEQUENCE = new SqlParameter("@MD_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMD_NUMSEQUENCE.Value = clsPhamouvementStockdetail.MD_NUMSEQUENCE;

            SqlParameter vppParamMD_PRIXUNITAIREACHAT = new SqlParameter("@MD_PRIXUNITAIREACHAT", SqlDbType.Money);
            vppParamMD_PRIXUNITAIREACHAT.Value = clsPhamouvementStockdetail.MD_PRIXUNITAIREACHAT;

            SqlParameter vppParamMD_PRIXUNITAIREVENTE = new SqlParameter("@MD_PRIXUNITAIREVENTE", SqlDbType.Money);
            vppParamMD_PRIXUNITAIREVENTE.Value = clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTE;

            SqlParameter vppParamMD_STATUTACCESSOIRE = new SqlParameter("@MD_STATUTACCESSOIRE", SqlDbType.VarChar, 1);
            vppParamMD_STATUTACCESSOIRE.Value = clsPhamouvementStockdetail.MD_STATUTACCESSOIRE;

            SqlParameter vppParamMD_TAUXCOMMISSION = new SqlParameter("@MD_TAUXCOMMISSION", SqlDbType.Float);
            vppParamMD_TAUXCOMMISSION.Value = clsPhamouvementStockdetail.MD_TAUXCOMMISSION;

            SqlParameter vppParamMD_MONTANTCOMMISSION = new SqlParameter("@MD_MONTANTCOMMISSION", SqlDbType.Money);
            vppParamMD_MONTANTCOMMISSION.Value = clsPhamouvementStockdetail.MD_MONTANTCOMMISSION;

            SqlParameter vppParamMD_TAUXREMISE = new SqlParameter("@MD_TAUXREMISE", SqlDbType.Float);
            vppParamMD_TAUXREMISE.Value = clsPhamouvementStockdetail.MD_TAUXREMISE;

            SqlParameter vppParamMD_MONTANTREMISE = new SqlParameter("@MD_MONTANTREMISE", SqlDbType.Money);
            vppParamMD_MONTANTREMISE.Value = clsPhamouvementStockdetail.MD_MONTANTREMISE;

            SqlParameter vppParamMD_ASDI = new SqlParameter("@MD_ASDI", SqlDbType.Money);
            vppParamMD_ASDI.Value = clsPhamouvementStockdetail.MD_ASDI;

            SqlParameter vppParamMD_TVA = new SqlParameter("@MD_TVA", SqlDbType.Money);
            vppParamMD_TVA.Value = clsPhamouvementStockdetail.MD_TVA;

            SqlParameter vppParamMD_QUANTITESORTIE = new SqlParameter("@MD_QUANTITESORTIE", SqlDbType.Money);
            vppParamMD_QUANTITESORTIE.Value = clsPhamouvementStockdetail.MD_QUANTITESORTIE;

            SqlParameter vppParamMD_QUANTITEENTREE = new SqlParameter("@MD_QUANTITEENTREE", SqlDbType.Money);
            vppParamMD_QUANTITEENTREE.Value = clsPhamouvementStockdetail.MD_QUANTITEENTREE;

            SqlParameter vppParamMD_DATEPEREMPTION = new SqlParameter("@MD_DATEPEREMPTION", SqlDbType.DateTime);
            vppParamMD_DATEPEREMPTION.Value = clsPhamouvementStockdetail.MD_DATEPEREMPTION;


			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PhamouvementStockDETAIL SET " +
                        " MS_NUMPIECE=@MS_NUMPIECE," +
                        " MD_NUMSEQUENCE=@MD_NUMSEQUENCE," +
                        " MD_PRIXUNITAIREACHAT=@MD_PRIXUNITAIREACHAT," +
                        " MD_PRIXUNITAIREVENTE=@MD_PRIXUNITAIREVENTE," +
                        " MD_STATUTACCESSOIRE=@MD_STATUTACCESSOIRE," +
                        " MD_TAUXCOMMISSION=@MD_TAUXCOMMISSION," +
                        " MD_MONTANTCOMMISSION=@MD_MONTANTCOMMISSION," +
                        " MD_TAUXREMISE=@MD_TAUXREMISE," +
                        " MD_MONTANTREMISE=@MD_MONTANTREMISE," +
                        " MD_ASDI=@MD_ASDI," +
                        " MD_TVA=@MD_TVA," +
                        " MD_QUANTITESORTIE=@MD_QUANTITESORTIE," +
                        " MD_QUANTITEENTREE=@MD_QUANTITEENTREE," +
                        " MD_DATEPEREMPTION=@MD_DATEPEREMPTION"  + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMD_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamMD_PRIXUNITAIREACHAT);
            vppSqlCmd.Parameters.Add(vppParamMD_PRIXUNITAIREVENTE);
            vppSqlCmd.Parameters.Add(vppParamMD_STATUTACCESSOIRE);
            vppSqlCmd.Parameters.Add(vppParamMD_TAUXCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamMD_MONTANTCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamMD_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamMD_MONTANTREMISE);
            vppSqlCmd.Parameters.Add(vppParamMD_ASDI);
            vppSqlCmd.Parameters.Add(vppParamMD_TVA);
            vppSqlCmd.Parameters.Add(vppParamMD_QUANTITESORTIE);
            vppSqlCmd.Parameters.Add(vppParamMD_QUANTITEENTREE);
            vppSqlCmd.Parameters.Add(vppParamMD_DATEPEREMPTION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhaecheancier>clsPhaecheancier</param>
        ///<author>Home Technology</author>
        public void pvgUPDATE(clsDonnee clsDonnee, clsPhamouvementStockdetail clsPhamouvementStockdetail)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockdetail.AG_CODEAGENCE;

            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE1", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementStockdetail.MS_NUMPIECE;

            SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
            vppParamAR_CODEARTICLE.Value = clsPhamouvementStockdetail.AR_CODEARTICLE;
            if (clsPhamouvementStockdetail.AR_CODEARTICLE == "") vppParamAR_CODEARTICLE.Value = DBNull.Value;


            SqlParameter vppParamMD_DATEPEREMPTION = new SqlParameter("@MD_DATEPEREMPTION", SqlDbType.DateTime);
            vppParamMD_DATEPEREMPTION.Value = clsPhamouvementStockdetail.MD_DATEPEREMPTION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_PHAMOUVEMENTSTOCKDETAILUPDATEDATEPEREMPTION  @AG_CODEAGENCE1,  @MS_NUMPIECE1, @AR_CODEARTICLE, @MD_DATEPEREMPTION,  @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamMD_DATEPEREMPTION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAMOUVEMENTSTOCKDETAIL "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockdetail </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockdetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE, MD_PRIXUNITAIREACHAT, MD_PRIXUNITAIREVENTE, MD_STATUTACCESSOIRE, MD_TAUXCOMMISSION, MD_MONTANTCOMMISSION,"+
                 " MD_TAUXREMISE, MD_MONTANTREMISE, MD_ASDI, MD_TVA, MD_QUANTITESORTIE, MD_QUANTITEENTREE, MD_DATEPEREMPTION, MD_ANNULATIONPIECE FROM dbo.PhamouvementStockDETAIL " + this.vapCritere + " AND MD_ANNULATIONPIECE = 'N' " ;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementStockdetail> clsPhamouvementStockdetails = new List<clsPhamouvementStockdetail>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockdetail clsPhamouvementStockdetail = new clsPhamouvementStockdetail();
					clsPhamouvementStockdetail.MD_NUMSEQUENCE = clsDonnee.vogDataReader["MD_NUMSEQUENCE"].ToString();
					clsPhamouvementStockdetail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementStockdetail.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhamouvementStockdetail.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementStockdetail.MD_PRIXUNITAIREACHAT = double.Parse(clsDonnee.vogDataReader["MD_PRIXUNITAIREACHAT"].ToString());
					clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTE = double.Parse(clsDonnee.vogDataReader["MD_PRIXUNITAIREVENTE"].ToString());
					clsPhamouvementStockdetail.MD_STATUTACCESSOIRE = clsDonnee.vogDataReader["MD_STATUTACCESSOIRE"].ToString();
					clsPhamouvementStockdetail.MD_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["MD_TAUXCOMMISSION"].ToString());
					clsPhamouvementStockdetail.MD_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["MD_MONTANTCOMMISSION"].ToString());
					clsPhamouvementStockdetail.MD_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MD_TAUXREMISE"].ToString());
					clsPhamouvementStockdetail.MD_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["MD_MONTANTREMISE"].ToString());
					clsPhamouvementStockdetail.MD_ASDI = float.Parse(clsDonnee.vogDataReader["MD_ASDI"].ToString());
					clsPhamouvementStockdetail.MD_TVA = float.Parse(clsDonnee.vogDataReader["MD_TVA"].ToString());
					clsPhamouvementStockdetail.MD_QUANTITESORTIE = float.Parse(clsDonnee.vogDataReader["MD_QUANTITESORTIE"].ToString());
					clsPhamouvementStockdetail.MD_QUANTITEENTREE = float.Parse(clsDonnee.vogDataReader["MD_QUANTITEENTREE"].ToString());
					clsPhamouvementStockdetail.MD_DATEPEREMPTION = DateTime.Parse(clsDonnee.vogDataReader["MD_DATEPEREMPTION"].ToString());
					clsPhamouvementStockdetail.MD_ANNULATIONPIECE = clsDonnee.vogDataReader["MD_ANNULATIONPIECE"].ToString();
					clsPhamouvementStockdetails.Add(clsPhamouvementStockdetail);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementStockdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockdetail </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockdetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementStockdetail> clsPhamouvementStockdetails = new List<clsPhamouvementStockdetail>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE, MD_PRIXUNITAIREACHAT, MD_PRIXUNITAIREVENTE, MD_STATUTACCESSOIRE, MD_TAUXCOMMISSION, MD_MONTANTCOMMISSION, MD_TAUXREMISE, MD_MONTANTREMISE, MD_ASDI,"+
                " MD_TVA, MD_QUANTITESORTIE, MD_QUANTITEENTREE, MD_DATEPEREMPTION, MD_ANNULATIONPIECE FROM dbo.PhamouvementStockDETAIL " + this.vapCritere + " AND MD_ANNULATIONPIECE = 'N'  ";
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementStockdetail clsPhamouvementStockdetail = new clsPhamouvementStockdetail();
					clsPhamouvementStockdetail.MD_NUMSEQUENCE =Dataset.Tables["TABLE"].Rows[Idx]["MD_NUMSEQUENCE"].ToString();
					clsPhamouvementStockdetail.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementStockdetail.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhamouvementStockdetail.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhamouvementStockdetail.MD_PRIXUNITAIREACHAT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_PRIXUNITAIREACHAT"].ToString());
					clsPhamouvementStockdetail.MD_PRIXUNITAIREVENTE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_PRIXUNITAIREVENTE"].ToString());
					clsPhamouvementStockdetail.MD_STATUTACCESSOIRE = Dataset.Tables["TABLE"].Rows[Idx]["MD_STATUTACCESSOIRE"].ToString();
					clsPhamouvementStockdetail.MD_TAUXCOMMISSION = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_TAUXCOMMISSION"].ToString());
					clsPhamouvementStockdetail.MD_MONTANTCOMMISSION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_MONTANTCOMMISSION"].ToString());
					clsPhamouvementStockdetail.MD_TAUXREMISE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_TAUXREMISE"].ToString());
					clsPhamouvementStockdetail.MD_MONTANTREMISE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_MONTANTREMISE"].ToString());
					clsPhamouvementStockdetail.MD_ASDI = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_ASDI"].ToString());
					clsPhamouvementStockdetail.MD_TVA = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_TVA"].ToString());
					clsPhamouvementStockdetail.MD_QUANTITESORTIE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_QUANTITESORTIE"].ToString());
					clsPhamouvementStockdetail.MD_QUANTITEENTREE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_QUANTITEENTREE"].ToString());
					clsPhamouvementStockdetail.MD_DATEPEREMPTION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MD_DATEPEREMPTION"].ToString());
					clsPhamouvementStockdetail.MD_ANNULATIONPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MD_ANNULATIONPIECE"].ToString();
					clsPhamouvementStockdetails.Add(clsPhamouvementStockdetail);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementStockdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.VUE_PHAMOUVEMENTSTOCKDETAIL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}
        public DataSet pvgInsertIntoDatasetSortie(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' " : " AND  MK_ANNULATIONPIECE = 'N' ";
            this.vapRequete = "SELECT AR_CODEARTICLE, AR_CODEBARRE, AR_CODECIP,  AR_NOMCOMMERCIALE, MD_QUANTITESORTIE,MD_PRIXUNITAIREACHAT,MD_PRIXUNITAIREVENTE,MD_MONTANTREMISE, MD_TAUXREMISE,   " +
                "  MD_PRIXUNITAIREVENTE AS TOTAL,MD_DATEPEREMPTION,  MD_STATUTACCESSOIRE FROM VUE_PHAMOUVEMENTSTOCKDETAIL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgInsertIntoDatasetInitialiseAppro(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere(vppCritere);
            //this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' " : " AND  MK_ANNULATIONPIECE = 'N' ";
            //this.vapRequete = "SELECT MK_NUMPIECE,AR_CODEARTICLE, AR_CODEBARRE, AR_CODECIP,  AR_NOMCOMMERCIALE,MD_QUANTITEENTREE,MD_QUANTITEENTREE as MD_QUANTITECOMMANDE, MD_QUANTITEECART=0,  " +
            //    " MD_PRIXUNITAIREACHAT, MD_DATEPEREMPTION,  MD_MONTANTREMISE,  MD_MONTANTREMISE, MD_TAUXREMISE,MD_PRIXUNITAIREACHAT AS TOTAL,  MD_STATUTACCESSOIRE  " +
            //    "  FROM VUE_PhamouvementStock " + this.vapCritere ;
            //this.vapCritere = "";

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@CODETYPECLIENT", "@DATE", "@CODECRYPTAGE", "@TYPEOPERATION", "@TA_CODETYPEARTICLE", "@NO_CODENATUREOPERATION", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUREDITION" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3],clsDonnee.vogCleCryptage, vppCritere[4] , vppCritere[5] , vppCritere[6], vppCritere[7] , vppCritere[8] };

            this.vapRequete = "SELECT *,PY_PRIXVENTEHT='', AR_PAOBLIGATOIRE='', AR_PVOBLIGATOIRE='', AR_MONTANTVAUNITAIRE='', AR_MONTANASDIUNITAIRE='', TOTALENTREEHT=0, TOTALENTREETTCPLUSAIRSI=0, TAUXTVA=0, TAUXASDI=0,TP_CODETYPEPRESTATION='',MD_PRIXUNITAIREACHATHT='',MD_NOMBRESAC=0,MD_POIDSNET=0,MD_NOMBRESACTRANSMIS=0,MD_NOMBRESACACCEPTE=0,MD_REFACTION=0,ME_IDFILTRAGEDESTOCKEXPIRATION='',MF_IDFILTRAGEDESTOCK='',MF_IDFILTRAGEDESTOCKM1='',MF_IDFILTRAGEDESTOCKM2='',MF_NUMEROLOTFILTRAGEDESTOCK='',ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION='',MF_DATEFABRICATIONFILTRAGEDESTOCKM1='',MF_NUMEROLOTFILTRAGEDESTOCKM2='' FROM FC_PHAMOUVEMENTSTOCKDETAIL (@AG_CODEAGENCE,@MS_NUMPIECE,@CODETYPECLIENT,@DATE,@CODECRYPTAGE,@TYPEOPERATION,@TA_CODETYPEARTICLE,@NO_CODENATUREOPERATION,@EN_CODEENTREPOT,@OP_CODEOPERATEUREDITION)  WHERE NO_CODENATUREOPERATION LIKE '%'+ @NO_CODENATUREOPERATION +'%' ORDER  BY MD_NUMSEQUENCE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}



        public DataSet pvgInsertIntoDatasetPointLivraison(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(vppCritere);
            //this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' " : " AND  MK_ANNULATIONPIECE = 'N' ";
            //this.vapRequete = "SELECT MK_NUMPIECE,AR_CODEARTICLE, AR_CODEBARRE, AR_CODECIP,  AR_NOMCOMMERCIALE,MD_QUANTITEENTREE,MD_QUANTITEENTREE as MD_QUANTITECOMMANDE, MD_QUANTITEECART=0,  " +
            //    " MD_PRIXUNITAIREACHAT, MD_DATEPEREMPTION,  MD_MONTANTREMISE,  MD_MONTANTREMISE, MD_TAUXREMISE,MD_PRIXUNITAIREACHAT AS TOTAL,  MD_STATUTACCESSOIRE  " +
            //    "  FROM VUE_PhamouvementStock " + this.vapCritere ;
            //this.vapCritere = "";

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@CODETYPECLIENT", "@DATE", "@CODECRYPTAGE", "@TYPEOPERATION", "@TA_CODETYPEARTICLE", "@NO_CODENATUREOPERATION", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUREDITION" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3],clsDonnee.vogCleCryptage, vppCritere[4] , vppCritere[5] , vppCritere[6], vppCritere[7] , vppCritere[8] };

            this.vapRequete = "SELECT *,PY_PRIXVENTEHT='', AR_PAOBLIGATOIRE='', AR_PVOBLIGATOIRE='', AR_MONTANTVAUNITAIRE='', AR_MONTANASDIUNITAIRE='', TOTALENTREEHT=0, TOTALENTREETTCPLUSAIRSI=0, TAUXTVA=0, TAUXASDI=0,TP_CODETYPEPRESTATION='',MD_PRIXUNITAIREACHATHT='',MD_NOMBRESAC=0,MD_POIDSNET=0,MD_NOMBRESACTRANSMIS=0,MD_NOMBRESACACCEPTE=0,MD_REFACTION=0 FROM FC_PHAMOUVEMENTSTOCKDETAIL (@AG_CODEAGENCE,@MS_NUMPIECE,@CODETYPECLIENT,@DATE,@CODECRYPTAGE,@TYPEOPERATION,@TA_CODETYPEARTICLE,@NO_CODENATUREOPERATION,@EN_CODEENTREPOT,@OP_CODEOPERATEUREDITION)  WHERE NO_CODENATUREOPERATION LIKE '%'+ @NO_CODENATUREOPERATION +'%' ";
            this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }




        public DataSet pvgInsertIntoDatasetPourDatePeremption(clsDonnee clsDonnee, params string[] vppCritere)
        {
           
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE",  "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };

            this.vapRequete = "EXEC [dbo].[PS_PHAMOUVEMENTSTOCKDETAILDATASET] @AG_CODEAGENCE,@MS_NUMPIECE,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        public DataSet pvgInsertIntoDatasetInitialiseFabTrans(clsDonnee clsDonnee, params string[] vppCritere)
        {
          

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@DATE", "@CODECRYPTAGE", "@TYPEOPERATION", "@TA_CODETYPEARTICLE", "@NO_CODENATUREOPERATION", "@EN_CODEENTREPOT" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], clsDonnee.vogCleCryptage, vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };

            this.vapRequete = "SELECT * FROM FC_PHAMOUVEMENTSTOCKDETAILEVALUATIONSTOCK (@AG_CODEAGENCE,@MS_NUMPIECE,@DATE,@CODECRYPTAGE,@TYPEOPERATION,@TA_CODETYPEARTICLE,@NO_CODENATUREOPERATION,@EN_CODEENTREPOT) ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetInitialiseVente(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' " : " AND  MK_ANNULATIONPIECE = 'N' ";
            this.vapRequete = "SELECT MK_NUMPIECE,AR_CODEARTICLE, AR_CODEBARRE, AR_CODECIP,  AR_NOMCOMMERCIALE,MD_QUANTITESORTIE, MD_QUANTITECOMMANDE=0, MD_QUANTITEECART=0,  " +
                " MD_PRIXUNITAIREACHAT , MD_PRIXUNITAIREVENTE,MD_PRIXUNITAIREVENTE*MD_QUANTITESORTIE AS TOTAL, MD_DATEPEREMPTION,  MD_MONTANTREMISE,  MD_TAUXREMISE,  MD_STATUTACCESSOIRE, MS_NUMPIECE ,AR_ASDI , AR_TVA " +
                "  FROM VUE_PHAMOUVEMENTSTOCKDETAIL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MD_NUMSEQUENCE , MD_PRIXUNITAIREACHAT FROM dbo.PhamouvementStockDETAIL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        //SELECTION DES ACCESSOIRS OU DES EMBALLAGES
        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgEMBALLAGE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE AR_CODEARTICLE1=@AR_CODEARTICLE";
            vapNomParametre = new string[] { "@AR_CODEARTICLE", "@DATE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT AR_CODEARTICLE2,AR_QUANTITE,AR_MONTANT  FROM [dbo].[FC_EMBALLAGE1](@AR_CODEARTICLE,@DATE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                vapNomParametre = new string[] { "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
                this.vapCritere = "WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE ";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MD_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MS_NUMPIECE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee,params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND AR_CODEARTICLE=@AR_CODEARTICLE";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@AR_CODEARTICLE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }

	}
}
