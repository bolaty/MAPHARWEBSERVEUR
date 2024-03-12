using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementStockdetailcommandeWSDAL: ITableDAL<clsPhamouvementStockdetailcommande>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT COUNT(MM_NUMSEQUENCE) AS MM_NUMSEQUENCE  FROM dbo.PhamouvementStockDETAILCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT ISNULL(MAX(MM_NUMSEQUENCE),0) AS MM_NUMSEQUENCE  FROM dbo.PhamouvementStockDETAILCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT ISNULL(MAX(MM_NUMSEQUENCE),0) AS MM_NUMSEQUENCE  FROM dbo.PhamouvementStockDETAILCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockdetailcommande comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockdetailcommande pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , AR_CODEARTICLE  , MK_NUMPIECE  , MM_PRIXUNITAIREACHAT  , MM_PRIXUNITAIREVENTE  , MM_STATUTACCESSOIRE  , MM_TAUXCOMMISSION  , MM_MONTANTCOMMISSION  , MM_TAUXREMISE  , MM_MONTANTREMISE  , MM_ASDI  , MM_TVA  , MM_QUANTITESORTIE  , MM_QUANTITEENTREE  , MM_DATEPEREMPTION  , MM_ANNULATIONPIECE  FROM dbo.PhamouvementStockDETAILCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande = new clsPhamouvementStockdetailcommande();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockdetailcommande.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementStockdetailcommande.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhamouvementStockdetailcommande.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
					clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREACHAT = double.Parse(clsDonnee.vogDataReader["MM_PRIXUNITAIREACHAT"].ToString());
					clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTE = double.Parse(clsDonnee.vogDataReader["MM_PRIXUNITAIREVENTE"].ToString());
					clsPhamouvementStockdetailcommande.MM_STATUTACCESSOIRE = clsDonnee.vogDataReader["MM_STATUTACCESSOIRE"].ToString();
					clsPhamouvementStockdetailcommande.MM_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["MM_TAUXCOMMISSION"].ToString());
					clsPhamouvementStockdetailcommande.MM_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["MM_MONTANTCOMMISSION"].ToString());
					clsPhamouvementStockdetailcommande.MM_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MM_TAUXREMISE"].ToString());
					clsPhamouvementStockdetailcommande.MM_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["MM_MONTANTREMISE"].ToString());
					clsPhamouvementStockdetailcommande.MM_ASDI = float.Parse(clsDonnee.vogDataReader["MM_ASDI"].ToString());
					clsPhamouvementStockdetailcommande.MM_TVA = float.Parse(clsDonnee.vogDataReader["MM_TVA"].ToString());
					clsPhamouvementStockdetailcommande.MM_QUANTITESORTIE = double.Parse(clsDonnee.vogDataReader["MM_QUANTITESORTIE"].ToString());
					clsPhamouvementStockdetailcommande.MM_QUANTITEENTREE = double.Parse(clsDonnee.vogDataReader["MM_QUANTITEENTREE"].ToString());
					clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION = DateTime.Parse(clsDonnee.vogDataReader["MM_DATEPEREMPTION"].ToString());
					clsPhamouvementStockdetailcommande.MM_ANNULATIONPIECE = clsDonnee.vogDataReader["MM_ANNULATIONPIECE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementStockdetailcommande;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockdetailcommande>clsPhamouvementStockdetailcommande</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementStockdetailcommande.AG_CODEAGENCE;

            SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
            vppParamAR_CODEARTICLE.Value = clsPhamouvementStockdetailcommande.AR_CODEARTICLE;

            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStockdetailcommande.MK_NUMPIECE;

            SqlParameter vppParamMM_NUMSEQUENCE = new SqlParameter("@MM_NUMSEQUENCE", SqlDbType.VarChar, 50);
            vppParamMM_NUMSEQUENCE.Value = clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE;

            SqlParameter vppParamMM_PRIXUNITAIREACHAT = new SqlParameter("@MM_PRIXUNITAIREACHAT", SqlDbType.Money);
            vppParamMM_PRIXUNITAIREACHAT.Value = clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREACHAT;

            SqlParameter vppParamMM_PRIXUNITAIREVENTE = new SqlParameter("@MM_PRIXUNITAIREVENTE", SqlDbType.Money);
            vppParamMM_PRIXUNITAIREVENTE.Value = clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTE;

            SqlParameter vppParamMM_STATUTACCESSOIRE = new SqlParameter("@MM_STATUTACCESSOIRE", SqlDbType.VarChar, 1);
            vppParamMM_STATUTACCESSOIRE.Value = clsPhamouvementStockdetailcommande.MM_STATUTACCESSOIRE;

            SqlParameter vppParamMM_TAUXCOMMISSION = new SqlParameter("@MM_TAUXCOMMISSION", SqlDbType.Float);
            vppParamMM_TAUXCOMMISSION.Value = clsPhamouvementStockdetailcommande.MM_TAUXCOMMISSION;

            SqlParameter vppParamMM_MONTANTCOMMISSION = new SqlParameter("@MM_MONTANTCOMMISSION", SqlDbType.Money);
            vppParamMM_MONTANTCOMMISSION.Value = clsPhamouvementStockdetailcommande.MM_MONTANTCOMMISSION;

            SqlParameter vppParamMM_TAUXREMISE = new SqlParameter("@MM_TAUXREMISE", SqlDbType.Float);
            vppParamMM_TAUXREMISE.Value = clsPhamouvementStockdetailcommande.MM_TAUXREMISE;

            SqlParameter vppParamMM_MONTANTREMISE = new SqlParameter("@MM_MONTANTREMISE", SqlDbType.Money);
            vppParamMM_MONTANTREMISE.Value = clsPhamouvementStockdetailcommande.MM_MONTANTREMISE;

            SqlParameter vppParamMM_ASDI = new SqlParameter("@MM_ASDI", SqlDbType.Float);
            vppParamMM_ASDI.Value = clsPhamouvementStockdetailcommande.MM_ASDI;

            SqlParameter vppParamMM_TVA = new SqlParameter("@MM_TVA", SqlDbType.Float);
            vppParamMM_TVA.Value = clsPhamouvementStockdetailcommande.MM_TVA;

            SqlParameter vppParamMM_QUANTITESORTIE = new SqlParameter("@MM_QUANTITESORTIE", SqlDbType.Money);
            vppParamMM_QUANTITESORTIE.Value = clsPhamouvementStockdetailcommande.MM_QUANTITESORTIE;

            SqlParameter vppParamMM_QUANTITEENTREE = new SqlParameter("@MM_QUANTITEENTREE", SqlDbType.Money);
            vppParamMM_QUANTITEENTREE.Value = clsPhamouvementStockdetailcommande.MM_QUANTITEENTREE;

            SqlParameter vppParamMM_DATEPEREMPTION = new SqlParameter("@MM_DATEPEREMPTION", SqlDbType.DateTime);
            vppParamMM_DATEPEREMPTION.Value = clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION;
            if (clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION < DateTime.Parse("01/01/1900"))
                vppParamMM_DATEPEREMPTION.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMM_ANNULATIONPIECE = new SqlParameter("@MM_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMM_ANNULATIONPIECE.Value = clsPhamouvementStockdetailcommande.MM_ANNULATIONPIECE;

            SqlParameter vppParamMM_MONTANTTVA = new SqlParameter("@MM_MONTANTTVA", SqlDbType.Money);
            vppParamMM_MONTANTTVA.Value = clsPhamouvementStockdetailcommande.MM_MONTANTTVA;
            SqlParameter vppParamMM_MONTANTASDI = new SqlParameter("@MM_MONTANTASDI", SqlDbType.Money);
            vppParamMM_MONTANTASDI.Value = clsPhamouvementStockdetailcommande.MM_MONTANTASDI;


            SqlParameter vppParamMM_MONTANTESCOMPTE = new SqlParameter("@MM_MONTANTESCOMPTE", SqlDbType.Money);
            vppParamMM_MONTANTESCOMPTE.Value = clsPhamouvementStockdetailcommande.MM_MONTANTESCOMPTE;

            SqlParameter vppParamMM_TAUXESCOMPTE = new SqlParameter("@MM_TAUXESCOMPTE", SqlDbType.Money);
            vppParamMM_TAUXESCOMPTE.Value = clsPhamouvementStockdetailcommande.MM_TAUXESCOMPTE;

            SqlParameter vppParamMM_MONTANTREMISEUNITAIRE = new SqlParameter("@MM_MONTANTREMISEUNITAIRE", SqlDbType.Money);
            vppParamMM_MONTANTREMISEUNITAIRE.Value = clsPhamouvementStockdetailcommande.MM_MONTANTREMISEUNITAIRE;

            SqlParameter vppParamMM_MONTANTESCOMPTEUNITAIRE = new SqlParameter("@MM_MONTANTESCOMPTEUNITAIRE", SqlDbType.Money);
            vppParamMM_MONTANTESCOMPTEUNITAIRE.Value = clsPhamouvementStockdetailcommande.MM_MONTANTESCOMPTEUNITAIRE;

            SqlParameter vppParamMM_DESCRIPTION = new SqlParameter("@MM_DESCRIPTION", SqlDbType.VarChar, 150);
            vppParamMM_DESCRIPTION.Value = clsPhamouvementStockdetailcommande.MM_DESCRIPTION;
            if (clsPhamouvementStockdetailcommande.MM_DESCRIPTION == "")
                vppParamMM_DESCRIPTION.Value = DBNull.Value;

            SqlParameter vppParamMM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = new SqlParameter("@MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE", SqlDbType.Money);
            vppParamMM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE.Value = clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE;
            

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE dbo.PS_PHAMOUVEMENTSTOCKDETAILCOMMANDE @MM_NUMSEQUENCE,@AG_CODEAGENCE,@AR_CODEARTICLE,@MK_NUMPIECE,@MM_PRIXUNITAIREACHAT,@MM_PRIXUNITAIREVENTE,@MM_STATUTACCESSOIRE,@MM_TAUXCOMMISSION,@MM_MONTANTCOMMISSION,@MM_TAUXREMISE,@MM_MONTANTREMISE,@MM_ASDI,@MM_TVA,@MM_QUANTITESORTIE,@MM_QUANTITEENTREE,@MM_DATEPEREMPTION,@MM_ANNULATIONPIECE,@MM_MONTANTTVA,@MM_MONTANTASDI,@MM_MONTANTESCOMPTE,@MM_TAUXESCOMPTE,@MM_MONTANTREMISEUNITAIRE,@MM_MONTANTESCOMPTEUNITAIRE,@MM_DESCRIPTION,@MM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE,@CODECRYPTAGE,0 ";
           // this.vapRequete = "INSERT INTO PhamouvementStockDETAILCOMMANDE " +
           //" (AG_CODEAGENCE,AR_CODEARTICLE,MK_NUMPIECE,MM_NUMSEQUENCE,MM_PRIXUNITAIREACHAT,MM_PRIXUNITAIREVENTE,MM_STATUTACCESSOIRE,MM_TAUXCOMMISSION,MM_MONTANTCOMMISSION,MM_TAUXREMISE,MM_MONTANTREMISE,MM_ASDI,MM_TVA,MM_QUANTITESORTIE,MM_QUANTITEENTREE,MM_DATEPEREMPTION,MM_ANNULATIONPIECE)" +
           //" VALUES(@AG_CODEAGENCE,@AR_CODEARTICLE,@MK_NUMPIECE,@MM_NUMSEQUENCE,@MM_PRIXUNITAIREACHAT,@MM_PRIXUNITAIREVENTE,@MM_STATUTACCESSOIRE,@MM_TAUXCOMMISSION,@MM_MONTANTCOMMISSION,@MM_TAUXREMISE,@MM_MONTANTREMISE,@MM_ASDI,@MM_TVA,@MM_QUANTITESORTIE,@MM_QUANTITEENTREE,@MM_DATEPEREMPTION,@MM_ANNULATIONPIECE)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMM_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamMM_PRIXUNITAIREACHAT);
            vppSqlCmd.Parameters.Add(vppParamMM_PRIXUNITAIREVENTE);
            vppSqlCmd.Parameters.Add(vppParamMM_STATUTACCESSOIRE);
            vppSqlCmd.Parameters.Add(vppParamMM_TAUXCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamMM_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTREMISE);
            vppSqlCmd.Parameters.Add(vppParamMM_ASDI);
            vppSqlCmd.Parameters.Add(vppParamMM_TVA);
            vppSqlCmd.Parameters.Add(vppParamMM_QUANTITESORTIE);
            vppSqlCmd.Parameters.Add(vppParamMM_QUANTITEENTREE);
            vppSqlCmd.Parameters.Add(vppParamMM_DATEPEREMPTION);
            vppSqlCmd.Parameters.Add(vppParamMM_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTTVA);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTASDI);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTESCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamMM_TAUXESCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTREMISEUNITAIRE);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTESCOMPTEUNITAIRE);
            vppSqlCmd.Parameters.Add(vppParamMM_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamMM_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}





		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementStockdetailcommande>clsPhamouvementStockdetailcommande</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMK_NUMPIECE.Value = clsPhamouvementStockdetailcommande.MK_NUMPIECE;

            SqlParameter vppParamMM_NUMSEQUENCE = new SqlParameter("@MM_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMM_NUMSEQUENCE.Value = clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE;

            SqlParameter vppParamMM_PRIXUNITAIREACHAT = new SqlParameter("@MM_PRIXUNITAIREACHAT", SqlDbType.Money);
            vppParamMM_PRIXUNITAIREACHAT.Value = clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREACHAT;

            SqlParameter vppParamMM_PRIXUNITAIREVENTE = new SqlParameter("@MM_PRIXUNITAIREVENTE", SqlDbType.Money);
            vppParamMM_PRIXUNITAIREVENTE.Value = clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTE;

            SqlParameter vppParamMM_STATUTACCESSOIRE = new SqlParameter("@MM_STATUTACCESSOIRE", SqlDbType.VarChar, 1);
            vppParamMM_STATUTACCESSOIRE.Value = clsPhamouvementStockdetailcommande.MM_STATUTACCESSOIRE;

            SqlParameter vppParamMM_TAUXCOMMISSION = new SqlParameter("@MM_TAUXCOMMISSION", SqlDbType.Float);
            vppParamMM_TAUXCOMMISSION.Value = clsPhamouvementStockdetailcommande.MM_TAUXCOMMISSION;

            SqlParameter vppParamMM_MONTANTCOMMISSION = new SqlParameter("@MM_MONTANTCOMMISSION", SqlDbType.Money);
            vppParamMM_MONTANTCOMMISSION.Value = clsPhamouvementStockdetailcommande.MM_MONTANTCOMMISSION;

            SqlParameter vppParamMM_TAUXREMISE = new SqlParameter("@MM_TAUXREMISE", SqlDbType.Float);
            vppParamMM_TAUXREMISE.Value = clsPhamouvementStockdetailcommande.MM_TAUXREMISE;

            SqlParameter vppParamMM_MONTANTREMISE = new SqlParameter("@MM_MONTANTREMISE", SqlDbType.Money);
            vppParamMM_MONTANTREMISE.Value = clsPhamouvementStockdetailcommande.MM_MONTANTREMISE;

            SqlParameter vppParamMM_ASDI = new SqlParameter("@MM_ASDI", SqlDbType.VarChar, 1);
            vppParamMM_ASDI.Value = clsPhamouvementStockdetailcommande.MM_ASDI;

            SqlParameter vppParamMM_TVA = new SqlParameter("@MM_TVA", SqlDbType.VarChar, 1);
            vppParamMM_TVA.Value = clsPhamouvementStockdetailcommande.MM_TVA;

            SqlParameter vppParamMM_QUANTITESORTIE = new SqlParameter("@MM_QUANTITESORTIE", SqlDbType.Money);
            vppParamMM_QUANTITESORTIE.Value = clsPhamouvementStockdetailcommande.MM_QUANTITESORTIE;

            SqlParameter vppParamMM_QUANTITEENTREE = new SqlParameter("@MM_QUANTITEENTREE", SqlDbType.Money);
            vppParamMM_QUANTITEENTREE.Value = clsPhamouvementStockdetailcommande.MM_QUANTITEENTREE;

            SqlParameter vppParamMM_DATEPEREMPTION = new SqlParameter("@MM_DATEPEREMPTION", SqlDbType.DateTime);
            vppParamMM_DATEPEREMPTION.Value = clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION;
            if (clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION < DateTime.Parse("01/01/1900"))
                vppParamMM_DATEPEREMPTION.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamMM_ANNULATIONPIECE = new SqlParameter("@MM_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMM_ANNULATIONPIECE.Value = clsPhamouvementStockdetailcommande.MM_ANNULATIONPIECE;

			//Préparation de la commande
            pvpChoixCritere(clsDonnee, vppCritere); 
			 this.vapRequete = "UPDATE PhamouvementStockDETAILCOMMANDE SET " +
            " MK_NUMPIECE=@MK_NUMPIECE," +
            " MM_NUMSEQUENCE=@MM_NUMSEQUENCE," +
            " MM_PRIXUNITAIREACHAT=@MM_PRIXUNITAIREACHAT," +
            " MM_PRIXUNITAIREVENTE=@MM_PRIXUNITAIREVENTE," +
            " MM_STATUTACCESSOIRE=@MM_STATUTACCESSOIRE," +
            " MM_TAUXCOMMISSION=@MM_TAUXCOMMISSION," +
            " MM_MONTANTCOMMISSION=@MM_MONTANTCOMMISSION," +
            " MM_TAUXREMISE=@MM_TAUXREMISE," +
            " MM_MONTANTREMISE=@MM_MONTANTREMISE," +
            " MM_ASDI=@MM_ASDI," +
            " MM_TVA=@MM_TVA," +
            " MM_QUANTITESORTIE=@MM_QUANTITESORTIE," +
            " MM_QUANTITEENTREE=@MM_QUANTITEENTREE," +
            " MM_DATEPEREMPTION=@MM_DATEPEREMPTION," +
            " MM_ANNULATIONPIECE=@MM_ANNULATIONPIECE" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMM_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamMM_PRIXUNITAIREACHAT);
            vppSqlCmd.Parameters.Add(vppParamMM_PRIXUNITAIREVENTE);
            vppSqlCmd.Parameters.Add(vppParamMM_STATUTACCESSOIRE);
            vppSqlCmd.Parameters.Add(vppParamMM_TAUXCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamMM_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamMM_MONTANTREMISE);
            vppSqlCmd.Parameters.Add(vppParamMM_ASDI);
            vppSqlCmd.Parameters.Add(vppParamMM_TVA);
            vppSqlCmd.Parameters.Add(vppParamMM_QUANTITESORTIE);
            vppSqlCmd.Parameters.Add(vppParamMM_QUANTITEENTREE);
            vppSqlCmd.Parameters.Add(vppParamMM_DATEPEREMPTION);
            vppSqlCmd.Parameters.Add(vppParamMM_ANNULATIONPIECE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        public void pvgAnnulerCommandeDetail(clsDonnee clsDonnee, params string[] vppCritere)
        {
            if (vppCritere.Length > 3)
            {
                SqlParameter vppParamMM_ANNULATIONPIECE = new SqlParameter("@MM_ANNULATIONPIECE", SqlDbType.VarChar, 1);
                vppParamMM_ANNULATIONPIECE.Value = vppCritere[2];

                //Préparation de la commande
                pvpChoixCritere(clsDonnee, vppCritere);
                this.vapRequete = "UPDATE PhamouvementStockDETAILCOMMANDE SET " +
                                  " MM_ANNULATIONPIECE=@MM_ANNULATIONPIECE" + this.vapCritere;
                this.vapCritere = "";
                SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

                //Ajout des paramètre à la commande
                vppSqlCmd.Parameters.Add(vppParamMM_ANNULATIONPIECE);

                //Ouverture de la connection et exécution de la commande
                clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
            }
        }


		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PhamouvementStockDETAILCOMMANDE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockdetailcommande </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockdetailcommande> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT  MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE, MM_PRIXUNITAIREACHAT, MM_PRIXUNITAIREVENTE, MM_STATUTACCESSOIRE, MM_TAUXCOMMISSION, MM_MONTANTCOMMISSION, MM_TAUXREMISE, MM_MONTANTREMISE, MM_ASDI, MM_TVA, MM_QUANTITESORTIE, MM_QUANTITEENTREE, MM_DATEPEREMPTION, MM_ANNULATIONPIECE FROM dbo.PhamouvementStockDETAILCOMMANDE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes = new List<clsPhamouvementStockdetailcommande>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande = new clsPhamouvementStockdetailcommande();
					clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE = clsDonnee.vogDataReader["MM_NUMSEQUENCE"].ToString();
					clsPhamouvementStockdetailcommande.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementStockdetailcommande.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhamouvementStockdetailcommande.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
					clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREACHAT = double.Parse(clsDonnee.vogDataReader["MM_PRIXUNITAIREACHAT"].ToString());
					clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTE = double.Parse(clsDonnee.vogDataReader["MM_PRIXUNITAIREVENTE"].ToString());
					clsPhamouvementStockdetailcommande.MM_STATUTACCESSOIRE = clsDonnee.vogDataReader["MM_STATUTACCESSOIRE"].ToString();
					clsPhamouvementStockdetailcommande.MM_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["MM_TAUXCOMMISSION"].ToString());
					clsPhamouvementStockdetailcommande.MM_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["MM_MONTANTCOMMISSION"].ToString());
					clsPhamouvementStockdetailcommande.MM_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MM_TAUXREMISE"].ToString());
					clsPhamouvementStockdetailcommande.MM_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["MM_MONTANTREMISE"].ToString());
					clsPhamouvementStockdetailcommande.MM_ASDI = float.Parse(clsDonnee.vogDataReader["MM_ASDI"].ToString());
					clsPhamouvementStockdetailcommande.MM_TVA = float.Parse(clsDonnee.vogDataReader["MM_TVA"].ToString());
					clsPhamouvementStockdetailcommande.MM_QUANTITESORTIE = double.Parse(clsDonnee.vogDataReader["MM_QUANTITESORTIE"].ToString());
					clsPhamouvementStockdetailcommande.MM_QUANTITEENTREE = double.Parse(clsDonnee.vogDataReader["MM_QUANTITEENTREE"].ToString());
					clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION = DateTime.Parse(clsDonnee.vogDataReader["MM_DATEPEREMPTION"].ToString());
					clsPhamouvementStockdetailcommande.MM_ANNULATIONPIECE = clsDonnee.vogDataReader["MM_ANNULATIONPIECE"].ToString();
					clsPhamouvementStockdetailcommandes.Add(clsPhamouvementStockdetailcommande);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementStockdetailcommandes;
		}

        public List<clsPhamouvementStockdetailcommande> pvgSelectCommande(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT * FROM VUE_PhamouvementStockCOMMANDEFOURNISSEUR " + this.vapCritere;
            this.vapCritere = ""; 
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes = new List<clsPhamouvementStockdetailcommande>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande = new clsPhamouvementStockdetailcommande();
                    clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE = clsDonnee.vogDataReader["MM_NUMSEQUENCE"].ToString();
                    clsPhamouvementStockdetailcommande.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsPhamouvementStockdetailcommande.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
                    clsPhamouvementStockdetailcommande.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
                    clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREACHAT = double.Parse(clsDonnee.vogDataReader["MM_PRIXUNITAIREACHAT"].ToString());
                    clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTE = double.Parse(clsDonnee.vogDataReader["MM_PRIXUNITAIREVENTE"].ToString());
                    clsPhamouvementStockdetailcommande.MM_STATUTACCESSOIRE = clsDonnee.vogDataReader["MM_STATUTACCESSOIRE"].ToString();
                    clsPhamouvementStockdetailcommande.MM_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["MM_TAUXCOMMISSION"].ToString());
                    clsPhamouvementStockdetailcommande.MM_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["MM_MONTANTCOMMISSION"].ToString());
                    clsPhamouvementStockdetailcommande.MM_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["MM_TAUXREMISE"].ToString());
                    clsPhamouvementStockdetailcommande.MM_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["MM_MONTANTREMISE"].ToString());
                    clsPhamouvementStockdetailcommande.MM_ASDI = float.Parse(clsDonnee.vogDataReader["MM_ASDI"].ToString());
                    clsPhamouvementStockdetailcommande.MM_TVA = float.Parse(clsDonnee.vogDataReader["MM_TVA"].ToString());
                    clsPhamouvementStockdetailcommande.MM_QUANTITESORTIE = double.Parse(clsDonnee.vogDataReader["MM_QUANTITESORTIE"].ToString());
                    clsPhamouvementStockdetailcommande.MM_QUANTITEENTREE = double.Parse(clsDonnee.vogDataReader["MM_QUANTITEENTREE"].ToString());
                    clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION = DateTime.Parse(clsDonnee.vogDataReader["MM_DATEPEREMPTION"].ToString());
                    clsPhamouvementStockdetailcommande.MM_ANNULATIONPIECE = clsDonnee.vogDataReader["MM_ANNULATIONPIECE"].ToString();
                    clsPhamouvementStockdetailcommandes.Add(clsPhamouvementStockdetailcommande);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPhamouvementStockdetailcommandes;
        }
        public List<clsPhamouvementStockdetailcommande> pvgSelectCommandeClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' AND CL_IDCLIENT IS NOT NULL AND CL_IDCLIENT<>'' " : " AND  MK_ANNULATIONPIECE = 'N' AND CL_IDCLIENT IS NOT NULL AND CL_IDCLIENT<>'' ";
            return pvgSelectCommande(clsDonnee, vppCritere);
        }
        public List<clsPhamouvementStockdetailcommande> pvgSelectCommandeFournisseur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapCritere += this.vapCritere == "" ? "WHERE  MK_ANNULATIONPIECE = 'N' AND FR_CODEFOURNISSEUR IS NOT NULL AND FR_CODEFOURNISSEUR<>'' " : " AND  MK_ANNULATIONPIECE = 'N' AND FR_CODEFOURNISSEUR IS NOT NULL AND FR_CODEFOURNISSEUR<>'' ";
            return pvgSelectCommande(clsDonnee, vppCritere);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockdetailcommande </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockdetailcommande> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes = new List<clsPhamouvementStockdetailcommande>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT  MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE, MM_PRIXUNITAIREACHAT, MM_PRIXUNITAIREVENTE, MM_STATUTACCESSOIRE, MM_TAUXCOMMISSION, MM_MONTANTCOMMISSION, MM_TAUXREMISE, MM_MONTANTREMISE, MM_ASDI, MM_TVA, MM_QUANTITESORTIE, MM_QUANTITEENTREE, MM_DATEPEREMPTION, MM_ANNULATIONPIECE FROM dbo.PhamouvementStockDETAILCOMMANDE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande = new clsPhamouvementStockdetailcommande();
					clsPhamouvementStockdetailcommande.MM_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["MM_NUMSEQUENCE"].ToString();
					clsPhamouvementStockdetailcommande.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementStockdetailcommande.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhamouvementStockdetailcommande.MK_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MK_NUMPIECE"].ToString();
					clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREACHAT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_PRIXUNITAIREACHAT"].ToString());
					clsPhamouvementStockdetailcommande.MM_PRIXUNITAIREVENTE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_PRIXUNITAIREVENTE"].ToString());
					clsPhamouvementStockdetailcommande.MM_STATUTACCESSOIRE = Dataset.Tables["TABLE"].Rows[Idx]["MM_STATUTACCESSOIRE"].ToString();
					clsPhamouvementStockdetailcommande.MM_TAUXCOMMISSION = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_TAUXCOMMISSION"].ToString());
					clsPhamouvementStockdetailcommande.MM_MONTANTCOMMISSION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_MONTANTCOMMISSION"].ToString());
					clsPhamouvementStockdetailcommande.MM_TAUXREMISE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_TAUXREMISE"].ToString());
					clsPhamouvementStockdetailcommande.MM_MONTANTREMISE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_MONTANTREMISE"].ToString());
					clsPhamouvementStockdetailcommande.MM_ASDI = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_ASDI"].ToString());
					clsPhamouvementStockdetailcommande.MM_TVA = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_TVA"].ToString());
					clsPhamouvementStockdetailcommande.MM_QUANTITESORTIE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_QUANTITESORTIE"].ToString());
					clsPhamouvementStockdetailcommande.MM_QUANTITEENTREE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_QUANTITEENTREE"].ToString());
					clsPhamouvementStockdetailcommande.MM_DATEPEREMPTION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MM_DATEPEREMPTION"].ToString());
					clsPhamouvementStockdetailcommande.MM_ANNULATIONPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MM_ANNULATIONPIECE"].ToString();
					clsPhamouvementStockdetailcommandes.Add(clsPhamouvementStockdetailcommande);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementStockdetailcommandes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE, AR_CODEBARRE, AR_CODECIP,  AR_NOMCOMMERCIALE,MM_QUANTITEENTREE, MM_QUANTITESORTIE,MM_PRIXUNITAIREVENTE,MM_MONTANTREMISE,MM_PRIXUNITAIREACHAT, MM_TAUXREMISE,   " +
                "  MM_PRIXUNITAIREVENTE AS TOTAL,MM_DATEPEREMPTION,  MM_STATUTACCESSOIRE FROM VUE_PHAMOUVEMENTSTOCKCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgInsertIntoDatasetcommandeFournisseur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE, AR_CODEBARRE, AR_CODECIP,  AR_NOMCOMMERCIALE,MM_QUANTITEENTREE,MM_PRIXUNITAIREACHAT,  " +
                "  MM_QUANTITEENTREE*MM_PRIXUNITAIREACHAT AS TOTAL,  MM_STATUTACCESSOIRE,MM_MONTANTREMISE,MM_MONTANTESCOMPTE,MM_TAUXESCOMPTE,MM_MONTANTREMISEUNITAIRE,MM_MONTANTESCOMPTEUNITAIRE FROM  dbo.FT_PHAMOUVEMENTSTOCKCOMMANDEFOURNISSEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetcommandeClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE, AR_CODEBARRE, AR_CODECIP,  AR_NOMCOMMERCIALE,MM_QUANTITESORTIE,MM_PRIXUNITAIREACHAT,MM_PRIXUNITAIREVENTE,  " +
                "  MM_QUANTITESORTIE*MM_PRIXUNITAIREVENTE AS TOTAL,  MM_STATUTACCESSOIRE,AR_MONTANTVA=0,AR_MONTANASDI=0,AR_ASDI='N',AR_TVA='N', PY_PRIXVENTEHT='', AR_PAOBLIGATOIRE='O', AR_PVOBLIGATOIRE='O', AR_MONTANTVAUNITAIRE='', AR_MONTANASDIUNITAIRE='', TOTALENTREEHT=0, TOTALENTREETTCPLUSAIRSI=0, TAUXTVA=0, TAUXASDI=0,MM_MONTANTREMISE,MM_MONTANTESCOMPTE,MM_TAUXESCOMPTE,MM_MONTANTREMISEUNITAIRE,MM_MONTANTESCOMPTEUNITAIRE FROM FT_PHAMOUVEMENTSTOCKCOMMANDECLIENT(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			this.vapRequete = "SELECT MM_NUMSEQUENCE , MM_PRIXUNITAIREACHAT FROM dbo.PhamouvementStockDETAILCOMMANDE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MM_NUMSEQUENCE, AG_CODEAGENCE, AR_CODEARTICLE, MK_NUMPIECE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage};
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                vapNomParametre = new string[] {"@CODECRYPTAGE", "@AG_CODEAGENCE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MK_NUMPIECE=@MK_NUMPIECE AND MM_ANNULATIONPIECE = 'N' ";
                vapNomParametre = new string[] {"@CODECRYPTAGE", "@AG_CODEAGENCE", "@MK_NUMPIECE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MK_NUMPIECE=@MK_NUMPIECE AND  AR_CODEARTICLE=@AR_CODEARTICLE AND MM_ANNULATIONPIECE = 'N'";
                vapNomParametre = new string[] {"@CODECRYPTAGE", "@AG_CODEAGENCE", "@MK_NUMPIECE", "@AR_CODEARTICLE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
				break;
				case 4 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MK_NUMPIECE=@MK_NUMPIECE AND  AR_CODEARTICLE=@AR_CODEARTICLE AND MM_NUMSEQUENCE=@MM_NUMSEQUENCE AND MM_ANNULATIONPIECE = 'N' ";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MK_NUMPIECE","@AR_CODEARTICLE","@MM_NUMSEQUENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
				break;
			}
		}
		public void pvpChoixCritere1( params string[] vppCritere)
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
