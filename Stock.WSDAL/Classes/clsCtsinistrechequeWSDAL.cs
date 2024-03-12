using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtsinistrechequeWSDAL: ITableDAL<clsCtsinistrecheque>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTSINISTRECHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTSINISTRECHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTSINISTRECHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtsinistrecheque comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtsinistrecheque pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , AB_CODEAGENCEBANCAIRE  , SI_CODESINISTRE  , CH_REFCHEQUE  , CH_VALEURCHEQUE  , CH_DATEANNULATIONCHEQUE  , CH_DATEEMISSIONCHEQUE  , CH_NOMTIREUR  , CH_NOMTIRE  , CH_DATERECEPTIONCHEQUE  , CH_NOMDUDEPOSANT  , CH_TELEPHONEDEPOSANT  , CH_DATEEFFET  , OP_CODEOPERATEUR  , CH_DATEVALIDATIONCHEQUE  , CH_PRIMEAENCAISSER  FROM dbo.FT_CTSINISTRECHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtsinistrecheque clsCtsinistrecheque = new clsCtsinistrecheque();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistrecheque.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE = clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString();
					clsCtsinistrecheque.SI_CODESINISTRE = clsDonnee.vogDataReader["SI_CODESINISTRE"].ToString();
					clsCtsinistrecheque.CH_REFCHEQUE = clsDonnee.vogDataReader["CH_REFCHEQUE"].ToString();
					clsCtsinistrecheque.CH_VALEURCHEQUE = double.Parse(clsDonnee.vogDataReader["CH_VALEURCHEQUE"].ToString());
					clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEANNULATIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEEMISSIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_NOMTIREUR = clsDonnee.vogDataReader["CH_NOMTIREUR"].ToString();
					clsCtsinistrecheque.CH_NOMTIRE = clsDonnee.vogDataReader["CH_NOMTIRE"].ToString();
					clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATERECEPTIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_NOMDUDEPOSANT = clsDonnee.vogDataReader["CH_NOMDUDEPOSANT"].ToString();
					clsCtsinistrecheque.CH_TELEPHONEDEPOSANT = clsDonnee.vogDataReader["CH_TELEPHONEDEPOSANT"].ToString();
					clsCtsinistrecheque.CH_DATEEFFET = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEEFFET"].ToString());
					clsCtsinistrecheque.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEVALIDATIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_PRIMEAENCAISSER = double.Parse(clsDonnee.vogDataReader["CH_PRIMEAENCAISSER"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtsinistrecheque;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinistrecheque>clsCtsinistrecheque</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtsinistrecheque clsCtsinistrecheque)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtsinistrecheque.AG_CODEAGENCE ;
			SqlParameter vppParamCH_DATESAISIECHEQUE = new SqlParameter("@CH_DATESAISIECHEQUE", SqlDbType.DateTime);
			vppParamCH_DATESAISIECHEQUE.Value  = clsCtsinistrecheque.CH_DATESAISIECHEQUE ;
			SqlParameter vppParamCH_IDEXCHEQUE = new SqlParameter("@CH_IDEXCHEQUE", SqlDbType.VarChar, 25);
			vppParamCH_IDEXCHEQUE.Value  = clsCtsinistrecheque.CH_IDEXCHEQUE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtsinistrecheque.EN_CODEENTREPOT ;
			SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.VarChar, 25);
			vppParamAB_CODEAGENCEBANCAIRE.Value  = clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE ;
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistrecheque.SI_CODESINISTRE;
			SqlParameter vppParamCH_REFCHEQUE = new SqlParameter("@CH_REFCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCH_REFCHEQUE.Value  = clsCtsinistrecheque.CH_REFCHEQUE ;
			SqlParameter vppParamCH_VALEURCHEQUE = new SqlParameter("@CH_VALEURCHEQUE", SqlDbType.Money);
			vppParamCH_VALEURCHEQUE.Value  = clsCtsinistrecheque.CH_VALEURCHEQUE ;
			SqlParameter vppParamCH_DATEANNULATIONCHEQUE = new SqlParameter("@CH_DATEANNULATIONCHEQUE", SqlDbType.DateTime);
			vppParamCH_DATEANNULATIONCHEQUE.Value  = clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE ;
			SqlParameter vppParamCH_DATEEMISSIONCHEQUE = new SqlParameter("@CH_DATEEMISSIONCHEQUE", SqlDbType.DateTime);
			vppParamCH_DATEEMISSIONCHEQUE.Value  = clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE ;
			SqlParameter vppParamCH_NOMTIREUR = new SqlParameter("@CH_NOMTIREUR", SqlDbType.VarChar, 1000);
			vppParamCH_NOMTIREUR.Value  = clsCtsinistrecheque.CH_NOMTIREUR ;
			SqlParameter vppParamCH_NOMTIRE = new SqlParameter("@CH_NOMTIRE", SqlDbType.VarChar, 1000);
			vppParamCH_NOMTIRE.Value  = clsCtsinistrecheque.CH_NOMTIRE ;
			SqlParameter vppParamCH_DATERECEPTIONCHEQUE = new SqlParameter("@CH_DATERECEPTIONCHEQUE", SqlDbType.DateTime);
			vppParamCH_DATERECEPTIONCHEQUE.Value  = clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE ;
			SqlParameter vppParamCH_NOMDUDEPOSANT = new SqlParameter("@CH_NOMDUDEPOSANT", SqlDbType.VarChar, 1000);
			vppParamCH_NOMDUDEPOSANT.Value  = clsCtsinistrecheque.CH_NOMDUDEPOSANT ;
			SqlParameter vppParamCH_TELEPHONEDEPOSANT = new SqlParameter("@CH_TELEPHONEDEPOSANT", SqlDbType.VarChar, 1000);
			vppParamCH_TELEPHONEDEPOSANT.Value  = clsCtsinistrecheque.CH_TELEPHONEDEPOSANT ;
			SqlParameter vppParamCH_DATEEFFET = new SqlParameter("@CH_DATEEFFET", SqlDbType.DateTime);
			vppParamCH_DATEEFFET.Value  = clsCtsinistrecheque.CH_DATEEFFET ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinistrecheque.OP_CODEOPERATEUR ;

			SqlParameter vppParamCH_DATEVALIDATIONCHEQUE = new SqlParameter("@CH_DATEVALIDATIONCHEQUE", SqlDbType.DateTime);
			vppParamCH_DATEVALIDATIONCHEQUE.Value  = clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE ;
			SqlParameter vppParamCH_PRIMEAENCAISSER = new SqlParameter("@CH_PRIMEAENCAISSER", SqlDbType.Money);
			vppParamCH_PRIMEAENCAISSER.Value  = clsCtsinistrecheque.CH_PRIMEAENCAISSER ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRECHEQUE  @AG_CODEAGENCE, @CH_DATESAISIECHEQUE, @CH_IDEXCHEQUE, @EN_CODEENTREPOT, @AB_CODEAGENCEBANCAIRE, @SI_CODESINISTRE, @CH_REFCHEQUE, @CH_VALEURCHEQUE, @CH_DATEANNULATIONCHEQUE, @CH_DATEEMISSIONCHEQUE, @CH_NOMTIREUR, @CH_NOMTIRE, @CH_DATERECEPTIONCHEQUE, @CH_NOMDUDEPOSANT, @CH_TELEPHONEDEPOSANT, @CH_DATEEFFET, @OP_CODEOPERATEUR,  @CH_DATEVALIDATIONCHEQUE, @CH_PRIMEAENCAISSER, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATESAISIECHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_IDEXCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamCH_REFCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_VALEURCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEANNULATIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEEMISSIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMTIREUR);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMTIRE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATERECEPTIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMDUDEPOSANT);
			vppSqlCmd.Parameters.Add(vppParamCH_TELEPHONEDEPOSANT);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEEFFET);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEVALIDATIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_PRIMEAENCAISSER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinistrecheque>clsCtsinistrecheque</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtsinistrecheque clsCtsinistrecheque,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtsinistrecheque.AG_CODEAGENCE ;
			SqlParameter vppParamCH_DATESAISIECHEQUE = new SqlParameter("@CH_DATESAISIECHEQUE", SqlDbType.DateTime);
			vppParamCH_DATESAISIECHEQUE.Value  = clsCtsinistrecheque.CH_DATESAISIECHEQUE ;
			SqlParameter vppParamCH_IDEXCHEQUE = new SqlParameter("@CH_IDEXCHEQUE", SqlDbType.VarChar, 25);
			vppParamCH_IDEXCHEQUE.Value  = clsCtsinistrecheque.CH_IDEXCHEQUE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtsinistrecheque.EN_CODEENTREPOT ;
			SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.VarChar, 25);
			vppParamAB_CODEAGENCEBANCAIRE.Value  = clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE ;
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistrecheque.SI_CODESINISTRE ;
			SqlParameter vppParamCH_REFCHEQUE = new SqlParameter("@CH_REFCHEQUE", SqlDbType.VarChar, 1000);
			vppParamCH_REFCHEQUE.Value  = clsCtsinistrecheque.CH_REFCHEQUE ;
			SqlParameter vppParamCH_VALEURCHEQUE = new SqlParameter("@CH_VALEURCHEQUE", SqlDbType.Money);
			vppParamCH_VALEURCHEQUE.Value  = clsCtsinistrecheque.CH_VALEURCHEQUE ;
			SqlParameter vppParamCH_DATEANNULATIONCHEQUE = new SqlParameter("@CH_DATEANNULATIONCHEQUE", SqlDbType.DateTime);
			vppParamCH_DATEANNULATIONCHEQUE.Value  = clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE ;
			SqlParameter vppParamCH_DATEEMISSIONCHEQUE = new SqlParameter("@CH_DATEEMISSIONCHEQUE", SqlDbType.DateTime);
			vppParamCH_DATEEMISSIONCHEQUE.Value  = clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE ;
			SqlParameter vppParamCH_NOMTIREUR = new SqlParameter("@CH_NOMTIREUR", SqlDbType.VarChar, 1000);
			vppParamCH_NOMTIREUR.Value  = clsCtsinistrecheque.CH_NOMTIREUR ;
			SqlParameter vppParamCH_NOMTIRE = new SqlParameter("@CH_NOMTIRE", SqlDbType.VarChar, 1000);
			vppParamCH_NOMTIRE.Value  = clsCtsinistrecheque.CH_NOMTIRE ;
			SqlParameter vppParamCH_DATERECEPTIONCHEQUE = new SqlParameter("@CH_DATERECEPTIONCHEQUE", SqlDbType.DateTime);
			vppParamCH_DATERECEPTIONCHEQUE.Value  = clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE ;
			SqlParameter vppParamCH_NOMDUDEPOSANT = new SqlParameter("@CH_NOMDUDEPOSANT", SqlDbType.VarChar, 1000);
			vppParamCH_NOMDUDEPOSANT.Value  = clsCtsinistrecheque.CH_NOMDUDEPOSANT ;
			SqlParameter vppParamCH_TELEPHONEDEPOSANT = new SqlParameter("@CH_TELEPHONEDEPOSANT", SqlDbType.VarChar, 1000);
			vppParamCH_TELEPHONEDEPOSANT.Value  = clsCtsinistrecheque.CH_TELEPHONEDEPOSANT ;
			SqlParameter vppParamCH_DATEEFFET = new SqlParameter("@CH_DATEEFFET", SqlDbType.DateTime);
			vppParamCH_DATEEFFET.Value  = clsCtsinistrecheque.CH_DATEEFFET ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
			vppParamOP_CODEOPERATEUR.Value  = clsCtsinistrecheque.OP_CODEOPERATEUR ;
			SqlParameter vppParamCH_DATEVALIDATIONCHEQUE = new SqlParameter("@CH_DATEVALIDATIONCHEQUE", SqlDbType.DateTime);
			vppParamCH_DATEVALIDATIONCHEQUE.Value  = clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE ;
			SqlParameter vppParamCH_PRIMEAENCAISSER = new SqlParameter("@CH_PRIMEAENCAISSER", SqlDbType.Money);
			vppParamCH_PRIMEAENCAISSER.Value  = clsCtsinistrecheque.CH_PRIMEAENCAISSER ;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value  = clsCtsinistrecheque.TYPEOPERATION;


			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRECHEQUE  @AG_CODEAGENCE, @CH_DATESAISIECHEQUE, @CH_IDEXCHEQUE, @EN_CODEENTREPOT, @AB_CODEAGENCEBANCAIRE, @SI_CODESINISTRE, @CH_REFCHEQUE, @CH_VALEURCHEQUE, @CH_DATEANNULATIONCHEQUE, @CH_DATEEMISSIONCHEQUE, @CH_NOMTIREUR, @CH_NOMTIRE, @CH_DATERECEPTIONCHEQUE, @CH_NOMDUDEPOSANT, @CH_TELEPHONEDEPOSANT, @CH_DATEEFFET, @OP_CODEOPERATEUR, @CH_DATEVALIDATIONCHEQUE, @CH_PRIMEAENCAISSER, @CODECRYPTAGE, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATESAISIECHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_IDEXCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamCH_REFCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_VALEURCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEANNULATIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEEMISSIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMTIREUR);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMTIRE);
			vppSqlCmd.Parameters.Add(vppParamCH_DATERECEPTIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMDUDEPOSANT);
			vppSqlCmd.Parameters.Add(vppParamCH_TELEPHONEDEPOSANT);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEEFFET);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEVALIDATIONCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCH_PRIMEAENCAISSER);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTRECHEQUE  @AG_CODEAGENCE, @CH_DATESAISIECHEQUE, @CH_IDEXCHEQUE, '' , '', '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistrecheque </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistrecheque> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, EN_CODEENTREPOT, AB_CODEAGENCEBANCAIRE, SI_CODESINISTRE, CH_REFCHEQUE, CH_VALEURCHEQUE, CH_DATEANNULATIONCHEQUE, CH_DATEEMISSIONCHEQUE, CH_NOMTIREUR, CH_NOMTIRE, CH_DATERECEPTIONCHEQUE, CH_NOMDUDEPOSANT, CH_TELEPHONEDEPOSANT, CH_DATEEFFET, OP_CODEOPERATEUR, CH_DATEVALIDATIONCHEQUE, CH_PRIMEAENCAISSER FROM dbo.FT_CTSINISTRECHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtsinistrecheque> clsCtsinistrecheques = new List<clsCtsinistrecheque>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistrecheque clsCtsinistrecheque = new clsCtsinistrecheque();
					clsCtsinistrecheque.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtsinistrecheque.CH_DATESAISIECHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATESAISIECHEQUE"].ToString());
					clsCtsinistrecheque.CH_IDEXCHEQUE = clsDonnee.vogDataReader["CH_IDEXCHEQUE"].ToString();
					clsCtsinistrecheque.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE = clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString();
					clsCtsinistrecheque.SI_CODESINISTRE = clsDonnee.vogDataReader["SI_CODESINISTRE"].ToString();
					clsCtsinistrecheque.CH_REFCHEQUE = clsDonnee.vogDataReader["CH_REFCHEQUE"].ToString();
					clsCtsinistrecheque.CH_VALEURCHEQUE = double.Parse(clsDonnee.vogDataReader["CH_VALEURCHEQUE"].ToString());
					clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEANNULATIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEEMISSIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_NOMTIREUR = clsDonnee.vogDataReader["CH_NOMTIREUR"].ToString();
					clsCtsinistrecheque.CH_NOMTIRE = clsDonnee.vogDataReader["CH_NOMTIRE"].ToString();
					clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATERECEPTIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_NOMDUDEPOSANT = clsDonnee.vogDataReader["CH_NOMDUDEPOSANT"].ToString();
					clsCtsinistrecheque.CH_TELEPHONEDEPOSANT = clsDonnee.vogDataReader["CH_TELEPHONEDEPOSANT"].ToString();
					clsCtsinistrecheque.CH_DATEEFFET = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEEFFET"].ToString());
					clsCtsinistrecheque.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEVALIDATIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_PRIMEAENCAISSER = double.Parse(clsDonnee.vogDataReader["CH_PRIMEAENCAISSER"].ToString());
					clsCtsinistrecheques.Add(clsCtsinistrecheque);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtsinistrecheques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistrecheque </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistrecheque> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtsinistrecheque> clsCtsinistrecheques = new List<clsCtsinistrecheque>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, EN_CODEENTREPOT, AB_CODEAGENCEBANCAIRE, SI_CODESINISTRE, CH_REFCHEQUE, CH_VALEURCHEQUE, CH_DATEANNULATIONCHEQUE, CH_DATEEMISSIONCHEQUE, CH_NOMTIREUR, CH_NOMTIRE, CH_DATERECEPTIONCHEQUE, CH_NOMDUDEPOSANT, CH_TELEPHONEDEPOSANT, CH_DATEEFFET, OP_CODEOPERATEUR,  CH_DATEVALIDATIONCHEQUE, CH_PRIMEAENCAISSER FROM dbo.FT_CTSINISTRECHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtsinistrecheque clsCtsinistrecheque = new clsCtsinistrecheque();
					clsCtsinistrecheque.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtsinistrecheque.CH_DATESAISIECHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATESAISIECHEQUE"].ToString());
					clsCtsinistrecheque.CH_IDEXCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CH_IDEXCHEQUE"].ToString();
					clsCtsinistrecheque.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtsinistrecheque.AB_CODEAGENCEBANCAIRE = Dataset.Tables["TABLE"].Rows[Idx]["AB_CODEAGENCEBANCAIRE"].ToString();
					clsCtsinistrecheque.SI_CODESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_CODESINISTRE"].ToString();
					clsCtsinistrecheque.CH_REFCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["CH_REFCHEQUE"].ToString();
					clsCtsinistrecheque.CH_VALEURCHEQUE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_VALEURCHEQUE"].ToString());
					clsCtsinistrecheque.CH_DATEANNULATIONCHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATEANNULATIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_DATEEMISSIONCHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATEEMISSIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_NOMTIREUR = Dataset.Tables["TABLE"].Rows[Idx]["CH_NOMTIREUR"].ToString();
					clsCtsinistrecheque.CH_NOMTIRE = Dataset.Tables["TABLE"].Rows[Idx]["CH_NOMTIRE"].ToString();
					clsCtsinistrecheque.CH_DATERECEPTIONCHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATERECEPTIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_NOMDUDEPOSANT = Dataset.Tables["TABLE"].Rows[Idx]["CH_NOMDUDEPOSANT"].ToString();
					clsCtsinistrecheque.CH_TELEPHONEDEPOSANT = Dataset.Tables["TABLE"].Rows[Idx]["CH_TELEPHONEDEPOSANT"].ToString();
					clsCtsinistrecheque.CH_DATEEFFET = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATEEFFET"].ToString());
					clsCtsinistrecheque.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCtsinistrecheque.CH_DATEVALIDATIONCHEQUE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATEVALIDATIONCHEQUE"].ToString());
					clsCtsinistrecheque.CH_PRIMEAENCAISSER = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_PRIMEAENCAISSER"].ToString());
					clsCtsinistrecheques.Add(clsCtsinistrecheque);
				}
				Dataset.Dispose();
			}
		return clsCtsinistrecheques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //Objet[0].SI_CODESINISTRE, Objet[0].CH_REFCHEQUE , Objet[0].AB_CODEAGENCEBANCAIRE, Objet[0].MONTANT1, Objet[0].MONTANT2
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SI_CODESINISTRE" , "@CH_REFCHEQUE" , "@AB_CODEAGENCEBANCAIRE" , "@MONTANT1", "@MONTANT2", "@CH_DATESAISIECHEQUE1","@CH_DATESAISIECHEQUE2", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9] };
            this.vapRequete = "EXEC PS_CTSINISTRECHEQUE @AG_CODEAGENCE,@SI_CODESINISTRE,@CH_REFCHEQUE,@AB_CODEAGENCEBANCAIRE,@MONTANT1,@MONTANT2,@CH_DATESAISIECHEQUE1,@CH_DATESAISIECHEQUE2,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CH_IDEXCHEQUE , CH_REFCHEQUE FROM dbo.FT_CTSINISTRECHEQUE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CH_DATESAISIECHEQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE AND CH_IDEXCHEQUE=@CH_IDEXCHEQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CH_DATESAISIECHEQUE","@CH_IDEXCHEQUE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE AND CH_IDEXCHEQUE=@CH_IDEXCHEQUE AND AB_CODEAGENCEBANCAIRE=@AB_CODEAGENCEBANCAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CH_DATESAISIECHEQUE","@CH_IDEXCHEQUE","@AB_CODEAGENCEBANCAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE AND CH_IDEXCHEQUE=@CH_IDEXCHEQUE AND AB_CODEAGENCEBANCAIRE=@AB_CODEAGENCEBANCAIRE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CH_DATESAISIECHEQUE","@CH_IDEXCHEQUE","@AB_CODEAGENCEBANCAIRE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, AB_CODEAGENCEBANCAIRE, OP_CODEOPERATEUR)</summary>
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
                    this.vapCritere = "WHERE SI_CODESINISTRE=@SI_CODESINISTRE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@SI_CODESINISTRE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SI_CODESINISTRE=@SI_CODESINISTRE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SI_CODESINISTRE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE AND CH_IDEXCHEQUE=@CH_IDEXCHEQUE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CH_DATESAISIECHEQUE", "@CH_IDEXCHEQUE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SI_CODESINISTRE=@SI_CODESINISTRE AND CH_DATESAISIECHEQUE BETWEEN @CH_DATESAISIECHEQUE1 AND @CH_DATESAISIECHEQUE2";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SI_CODESINISTRE", "@CH_DATESAISIECHEQUE1", "@CH_DATESAISIECHEQUE2" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CH_DATESAISIECHEQUE=@CH_DATESAISIECHEQUE AND CH_IDEXCHEQUE=@CH_IDEXCHEQUE AND AB_CODEAGENCEBANCAIRE=@AB_CODEAGENCEBANCAIRE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CH_DATESAISIECHEQUE", "@CH_IDEXCHEQUE", "@AB_CODEAGENCEBANCAIRE", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
            }
        }
    }
}
