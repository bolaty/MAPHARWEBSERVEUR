using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBalanceinventaireWSDAL: ITableDAL<clsBalanceinventaire>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_BALANCEINVENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_BALANCEINVENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_BALANCEINVENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBalanceinventaire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBalanceinventaire pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , EX_EXERCICE  , PL_CODENUMCOMPTE  , MV_LIBELLEOPERATION  , PL_MONTANTPERIODEPRECEDENTDEBIT  , PL_MONTANTPERIODEPRECEDENTCREDIT  , PL_MONTANTPERIODEDEBITENCOURS  , PL_MONTANTPERIODECREDITENCOURS  , PL_MONTANTSOLDEFINALDEBIT  , PL_MONTANTSOLDEFINALCREDIT  , PL_MONTANTPERIODEPRECEDENTDEBITTOTAL  , PL_MONTANTPERIODEPRECEDENTCREDITTOTAL  , PL_MONTANTPERIODEDEBITENCOURSTOTAL  , PL_MONTANTPERIODECREDITENCOURSTOTAL  , PL_MONTANTSOLDEFINALDEBITTOTAL  , PL_MONTANTSOLDEFINALCREDITTOTAL  , PL_MONTANTPERIODEPRECEDENTDEBITGESTION  , PL_MONTANTPERIODEDEBITENCOURSGESTION  , PL_MONTANTPERIODECREDITENCOURSGESTION  , PL_MONTANTSOLDEFINALDEBITGESTION  , PL_MONTANTPERIODEPRECEDENTDEBITBILAN  , PL_MONTANTPERIODEDEBITENCOURSBILAN  , PL_MONTANTPERIODECREDITENCOURSBILAN  , PL_MONTANTSOLDEFINALDEBITBILAN  FROM dbo.FT_BALANCEINVENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBalanceinventaire clsBalanceinventaire = new clsBalanceinventaire();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBalanceinventaire.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsBalanceinventaire.EX_EXERCICE = clsDonnee.vogDataReader["EX_EXERCICE"].ToString();
					clsBalanceinventaire.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsBalanceinventaire.MV_LIBELLEOPERATION = clsDonnee.vogDataReader["MV_LIBELLEOPERATION"].ToString();
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDITTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURSTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURSTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDITTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITGESTION = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBITGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSGESTION = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURSGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSGESTION = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURSGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITGESTION = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBITGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITBILAN = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBITBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSBILAN = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURSBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSBILAN = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURSBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITBILAN = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBITBILAN"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBalanceinventaire;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBalanceinventaire>clsBalanceinventaire</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBalanceinventaire clsBalanceinventaire)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsBalanceinventaire.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT1", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsBalanceinventaire.EN_CODEENTREPOT ;
			SqlParameter vppParamEX_EXERCICE = new SqlParameter("@EX_EXERCICE1", SqlDbType.VarChar, 4);
			vppParamEX_EXERCICE.Value  = clsBalanceinventaire.EX_EXERCICE ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 50);
			vppParamPL_CODENUMCOMPTE.Value  = clsBalanceinventaire.PL_CODENUMCOMPTE ;
			SqlParameter vppParamMV_LIBELLEOPERATION = new SqlParameter("@MV_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
			vppParamMV_LIBELLEOPERATION.Value  = clsBalanceinventaire.MV_LIBELLEOPERATION ;
			SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBIT", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEPRECEDENTDEBIT.Value  = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBIT ;
			SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDIT", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEPRECEDENTCREDIT.Value  = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDIT ;
			SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURS = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURS", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEDEBITENCOURS.Value  = clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURS ;
			SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURS = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURS", SqlDbType.Money);
			vppParamPL_MONTANTPERIODECREDITENCOURS.Value  = clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURS ;
			SqlParameter vppParamPL_MONTANTSOLDEFINALDEBIT = new SqlParameter("@PL_MONTANTSOLDEFINALDEBIT", SqlDbType.Money);
			vppParamPL_MONTANTSOLDEFINALDEBIT.Value  = clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBIT ;
			SqlParameter vppParamPL_MONTANTSOLDEFINALCREDIT = new SqlParameter("@PL_MONTANTSOLDEFINALCREDIT", SqlDbType.Money);
			vppParamPL_MONTANTSOLDEFINALCREDIT.Value  = clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDIT ;
			SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBITTOTAL = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBITTOTAL", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEPRECEDENTDEBITTOTAL.Value  = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITTOTAL ;
			SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDITTOTAL = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDITTOTAL", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEPRECEDENTCREDITTOTAL.Value  = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDITTOTAL ;
			SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURSTOTAL = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURSTOTAL", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEDEBITENCOURSTOTAL.Value  = clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSTOTAL ;
			SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURSTOTAL = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURSTOTAL", SqlDbType.Money);
			vppParamPL_MONTANTPERIODECREDITENCOURSTOTAL.Value  = clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSTOTAL ;
			SqlParameter vppParamPL_MONTANTSOLDEFINALDEBITTOTAL = new SqlParameter("@PL_MONTANTSOLDEFINALDEBITTOTAL", SqlDbType.Money);
			vppParamPL_MONTANTSOLDEFINALDEBITTOTAL.Value  = clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITTOTAL ;
			SqlParameter vppParamPL_MONTANTSOLDEFINALCREDITTOTAL = new SqlParameter("@PL_MONTANTSOLDEFINALCREDITTOTAL", SqlDbType.Money);
			vppParamPL_MONTANTSOLDEFINALCREDITTOTAL.Value  = clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDITTOTAL ;
			SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBITGESTION = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBITGESTION", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEPRECEDENTDEBITGESTION.Value  = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITGESTION ;
			SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURSGESTION = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURSGESTION", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEDEBITENCOURSGESTION.Value  = clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSGESTION ;
			SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURSGESTION = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURSGESTION", SqlDbType.Money);
			vppParamPL_MONTANTPERIODECREDITENCOURSGESTION.Value  = clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSGESTION ;
			SqlParameter vppParamPL_MONTANTSOLDEFINALDEBITGESTION = new SqlParameter("@PL_MONTANTSOLDEFINALDEBITGESTION", SqlDbType.Money);
			vppParamPL_MONTANTSOLDEFINALDEBITGESTION.Value  = clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITGESTION ;
			SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBITBILAN = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBITBILAN", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEPRECEDENTDEBITBILAN.Value  = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITBILAN ;
			SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURSBILAN = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURSBILAN", SqlDbType.Money);
			vppParamPL_MONTANTPERIODEDEBITENCOURSBILAN.Value  = clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSBILAN ;
			SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURSBILAN = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURSBILAN", SqlDbType.Money);
			vppParamPL_MONTANTPERIODECREDITENCOURSBILAN.Value  = clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSBILAN ;
			SqlParameter vppParamPL_MONTANTSOLDEFINALDEBITBILAN = new SqlParameter("@PL_MONTANTSOLDEFINALDEBITBILAN", SqlDbType.Money);
			vppParamPL_MONTANTSOLDEFINALDEBITBILAN.Value  = clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITBILAN ;

            SqlParameter vppParamBI_DATEDEBUT = new SqlParameter("@BI_DATEDEBUT", SqlDbType.DateTime);
            vppParamBI_DATEDEBUT.Value = clsBalanceinventaire.BI_DATEDEBUT;

            SqlParameter vppParamBI_DATEFIN = new SqlParameter("@BI_DATEFIN", SqlDbType.DateTime);
            vppParamBI_DATEFIN.Value = clsBalanceinventaire.BI_DATEFIN;

            SqlParameter vppParamBI_TYPEBALANCE = new SqlParameter("@BI_TYPEBALANCE1", SqlDbType.VarChar, 3);
            vppParamBI_TYPEBALANCE.Value = clsBalanceinventaire.BI_TYPEBALANCE;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BALANCEINVENTAIRE  @AG_CODEAGENCE1, @EN_CODEENTREPOT1, @EX_EXERCICE1, @PL_CODENUMCOMPTE, @MV_LIBELLEOPERATION, @PL_MONTANTPERIODEPRECEDENTDEBIT, @PL_MONTANTPERIODEPRECEDENTCREDIT, @PL_MONTANTPERIODEDEBITENCOURS, @PL_MONTANTPERIODECREDITENCOURS, @PL_MONTANTSOLDEFINALDEBIT, @PL_MONTANTSOLDEFINALCREDIT, @PL_MONTANTPERIODEPRECEDENTDEBITTOTAL, @PL_MONTANTPERIODEPRECEDENTCREDITTOTAL, @PL_MONTANTPERIODEDEBITENCOURSTOTAL, @PL_MONTANTPERIODECREDITENCOURSTOTAL, @PL_MONTANTSOLDEFINALDEBITTOTAL, @PL_MONTANTSOLDEFINALCREDITTOTAL, @PL_MONTANTPERIODEPRECEDENTDEBITGESTION, @PL_MONTANTPERIODEDEBITENCOURSGESTION, @PL_MONTANTPERIODECREDITENCOURSGESTION, @PL_MONTANTSOLDEFINALDEBITGESTION, @PL_MONTANTPERIODEPRECEDENTDEBITBILAN, @PL_MONTANTPERIODEDEBITENCOURSBILAN, @PL_MONTANTPERIODECREDITENCOURSBILAN, @PL_MONTANTSOLDEFINALDEBITBILAN,@BI_DATEDEBUT,@BI_DATEFIN,@BI_TYPEBALANCE1, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamEX_EXERCICE);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamMV_LIBELLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURS);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURS);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBIT);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDIT);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBITTOTAL);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDITTOTAL);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURSTOTAL);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURSTOTAL);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBITTOTAL);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDITTOTAL);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBITGESTION);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURSGESTION);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURSGESTION);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBITGESTION);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBITBILAN);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURSBILAN);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURSBILAN);
			vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBITBILAN);
            vppSqlCmd.Parameters.Add(vppParamBI_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBI_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamBI_TYPEBALANCE);


			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBalanceinventaire>clsBalanceinventaire</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBalanceinventaire clsBalanceinventaire,params string[] vppCritere)
		{
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsBalanceinventaire.AG_CODEAGENCE;
            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsBalanceinventaire.EN_CODEENTREPOT;
            SqlParameter vppParamEX_EXERCICE = new SqlParameter("@EX_EXERCICE", SqlDbType.VarChar, 4);
            vppParamEX_EXERCICE.Value = clsBalanceinventaire.EX_EXERCICE;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 50);
            vppParamPL_CODENUMCOMPTE.Value = clsBalanceinventaire.PL_CODENUMCOMPTE;
            SqlParameter vppParamMV_LIBELLEOPERATION = new SqlParameter("@MV_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
            vppParamMV_LIBELLEOPERATION.Value = clsBalanceinventaire.MV_LIBELLEOPERATION;
            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTDEBIT.Value = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBIT;
            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTCREDIT.Value = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDIT;
            SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURS = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEDEBITENCOURS.Value = clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURS;
            SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURS = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODECREDITENCOURS.Value = clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURS;
            SqlParameter vppParamPL_MONTANTSOLDEFINALDEBIT = new SqlParameter("@PL_MONTANTSOLDEFINALDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALDEBIT.Value = clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBIT;
            SqlParameter vppParamPL_MONTANTSOLDEFINALCREDIT = new SqlParameter("@PL_MONTANTSOLDEFINALCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALCREDIT.Value = clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDIT;
            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBITTOTAL = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBITTOTAL", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTDEBITTOTAL.Value = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITTOTAL;
            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDITTOTAL = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDITTOTAL", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTCREDITTOTAL.Value = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDITTOTAL;
            SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURSTOTAL = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURSTOTAL", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEDEBITENCOURSTOTAL.Value = clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSTOTAL;
            SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURSTOTAL = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURSTOTAL", SqlDbType.Money);
            vppParamPL_MONTANTPERIODECREDITENCOURSTOTAL.Value = clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSTOTAL;
            SqlParameter vppParamPL_MONTANTSOLDEFINALDEBITTOTAL = new SqlParameter("@PL_MONTANTSOLDEFINALDEBITTOTAL", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALDEBITTOTAL.Value = clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITTOTAL;
            SqlParameter vppParamPL_MONTANTSOLDEFINALCREDITTOTAL = new SqlParameter("@PL_MONTANTSOLDEFINALCREDITTOTAL", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALCREDITTOTAL.Value = clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDITTOTAL;
            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBITGESTION = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBITGESTION", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTDEBITGESTION.Value = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITGESTION;
            SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURSGESTION = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURSGESTION", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEDEBITENCOURSGESTION.Value = clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSGESTION;
            SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURSGESTION = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURSGESTION", SqlDbType.Money);
            vppParamPL_MONTANTPERIODECREDITENCOURSGESTION.Value = clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSGESTION;
            SqlParameter vppParamPL_MONTANTSOLDEFINALDEBITGESTION = new SqlParameter("@PL_MONTANTSOLDEFINALDEBITGESTION", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALDEBITGESTION.Value = clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITGESTION;
            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBITBILAN = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBITBILAN", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTDEBITBILAN.Value = clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITBILAN;
            SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURSBILAN = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURSBILAN", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEDEBITENCOURSBILAN.Value = clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSBILAN;
            SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURSBILAN = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURSBILAN", SqlDbType.Money);
            vppParamPL_MONTANTPERIODECREDITENCOURSBILAN.Value = clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSBILAN;
            SqlParameter vppParamPL_MONTANTSOLDEFINALDEBITBILAN = new SqlParameter("@PL_MONTANTSOLDEFINALDEBITBILAN", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALDEBITBILAN.Value = clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITBILAN;

            SqlParameter vppParamBI_DATEDEBUT = new SqlParameter("@BI_DATEDEBUT", SqlDbType.DateTime);
            vppParamBI_DATEDEBUT.Value = clsBalanceinventaire.BI_DATEDEBUT;

            SqlParameter vppParamBI_DATEFIN = new SqlParameter("@BI_DATEFIN", SqlDbType.DateTime);
            vppParamBI_DATEFIN.Value = clsBalanceinventaire.BI_DATEFIN;

            SqlParameter vppParamBI_TYPEBALANCE = new SqlParameter("@BI_TYPEBALANCE", SqlDbType.VarChar, 3);
            vppParamBI_TYPEBALANCE.Value = clsBalanceinventaire.BI_TYPEBALANCE;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_BALANCEINVENTAIRE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @EX_EXERCICE, @PL_CODENUMCOMPTE, @MV_LIBELLEOPERATION, @PL_MONTANTPERIODEPRECEDENTDEBIT, @PL_MONTANTPERIODEPRECEDENTCREDIT, @PL_MONTANTPERIODEDEBITENCOURS, @PL_MONTANTPERIODECREDITENCOURS, @PL_MONTANTSOLDEFINALDEBIT, @PL_MONTANTSOLDEFINALCREDIT, @PL_MONTANTPERIODEPRECEDENTDEBITTOTAL, @PL_MONTANTPERIODEPRECEDENTCREDITTOTAL, @PL_MONTANTPERIODEDEBITENCOURSTOTAL, @PL_MONTANTPERIODECREDITENCOURSTOTAL, @PL_MONTANTSOLDEFINALDEBITTOTAL, @PL_MONTANTSOLDEFINALCREDITTOTAL, @PL_MONTANTPERIODEPRECEDENTDEBITGESTION, @PL_MONTANTPERIODEDEBITENCOURSGESTION, @PL_MONTANTPERIODECREDITENCOURSGESTION, @PL_MONTANTSOLDEFINALDEBITGESTION, @PL_MONTANTPERIODEPRECEDENTDEBITBILAN, @PL_MONTANTPERIODEDEBITENCOURSBILAN, @PL_MONTANTPERIODECREDITENCOURSBILAN, @PL_MONTANTSOLDEFINALDEBITBILAN,@BI_DATEDEBUT,@BI_DATEFIN,@BI_TYPEBALANCE, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamEX_EXERCICE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamMV_LIBELLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBITTOTAL);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDITTOTAL);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURSTOTAL);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURSTOTAL);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBITTOTAL);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDITTOTAL);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBITGESTION);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURSGESTION);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURSGESTION);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBITGESTION);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBITBILAN);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURSBILAN);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURSBILAN);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBITBILAN);
            vppSqlCmd.Parameters.Add(vppParamBI_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamBI_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamBI_TYPEBALANCE);


            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BALANCEINVENTAIRE  @AG_CODEAGENCE, @EN_CODEENTREPOT, @EX_EXERCICE, '', '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' ,'01/01/1900' ,'01/01/1900' ,@BI_TYPEBALANCE , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBalanceinventaire </returns>
		///<author>Home Technology</author>
		public List<clsBalanceinventaire> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE, MV_LIBELLEOPERATION, PL_MONTANTPERIODEPRECEDENTDEBIT, PL_MONTANTPERIODEPRECEDENTCREDIT, PL_MONTANTPERIODEDEBITENCOURS, PL_MONTANTPERIODECREDITENCOURS, PL_MONTANTSOLDEFINALDEBIT, PL_MONTANTSOLDEFINALCREDIT, PL_MONTANTPERIODEPRECEDENTDEBITTOTAL, PL_MONTANTPERIODEPRECEDENTCREDITTOTAL, PL_MONTANTPERIODEDEBITENCOURSTOTAL, PL_MONTANTPERIODECREDITENCOURSTOTAL, PL_MONTANTSOLDEFINALDEBITTOTAL, PL_MONTANTSOLDEFINALCREDITTOTAL, PL_MONTANTPERIODEPRECEDENTDEBITGESTION, PL_MONTANTPERIODEDEBITENCOURSGESTION, PL_MONTANTPERIODECREDITENCOURSGESTION, PL_MONTANTSOLDEFINALDEBITGESTION, PL_MONTANTPERIODEPRECEDENTDEBITBILAN, PL_MONTANTPERIODEDEBITENCOURSBILAN, PL_MONTANTPERIODECREDITENCOURSBILAN, PL_MONTANTSOLDEFINALDEBITBILAN FROM dbo.FT_BALANCEINVENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBalanceinventaire> clsBalanceinventaires = new List<clsBalanceinventaire>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBalanceinventaire clsBalanceinventaire = new clsBalanceinventaire();
					clsBalanceinventaire.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsBalanceinventaire.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsBalanceinventaire.EX_EXERCICE = clsDonnee.vogDataReader["EX_EXERCICE"].ToString();
					clsBalanceinventaire.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsBalanceinventaire.MV_LIBELLEOPERATION = clsDonnee.vogDataReader["MV_LIBELLEOPERATION"].ToString();
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDITTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURSTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURSTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDITTOTAL = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITGESTION = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBITGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSGESTION = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURSGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSGESTION = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURSGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITGESTION = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBITGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITBILAN = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBITBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSBILAN = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURSBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSBILAN = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURSBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITBILAN = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBITBILAN"].ToString());
					clsBalanceinventaires.Add(clsBalanceinventaire);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBalanceinventaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBalanceinventaire </returns>
		///<author>Home Technology</author>
		public List<clsBalanceinventaire> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBalanceinventaire> clsBalanceinventaires = new List<clsBalanceinventaire>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE, MV_LIBELLEOPERATION, PL_MONTANTPERIODEPRECEDENTDEBIT, PL_MONTANTPERIODEPRECEDENTCREDIT, PL_MONTANTPERIODEDEBITENCOURS, PL_MONTANTPERIODECREDITENCOURS, PL_MONTANTSOLDEFINALDEBIT, PL_MONTANTSOLDEFINALCREDIT, PL_MONTANTPERIODEPRECEDENTDEBITTOTAL, PL_MONTANTPERIODEPRECEDENTCREDITTOTAL, PL_MONTANTPERIODEDEBITENCOURSTOTAL, PL_MONTANTPERIODECREDITENCOURSTOTAL, PL_MONTANTSOLDEFINALDEBITTOTAL, PL_MONTANTSOLDEFINALCREDITTOTAL, PL_MONTANTPERIODEPRECEDENTDEBITGESTION, PL_MONTANTPERIODEDEBITENCOURSGESTION, PL_MONTANTPERIODECREDITENCOURSGESTION, PL_MONTANTSOLDEFINALDEBITGESTION, PL_MONTANTPERIODEPRECEDENTDEBITBILAN, PL_MONTANTPERIODEDEBITENCOURSBILAN, PL_MONTANTPERIODECREDITENCOURSBILAN, PL_MONTANTSOLDEFINALDEBITBILAN FROM dbo.FT_BALANCEINVENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBalanceinventaire clsBalanceinventaire = new clsBalanceinventaire();
					clsBalanceinventaire.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsBalanceinventaire.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsBalanceinventaire.EX_EXERCICE = Dataset.Tables["TABLE"].Rows[Idx]["EX_EXERCICE"].ToString();
					clsBalanceinventaire.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsBalanceinventaire.MV_LIBELLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["MV_LIBELLEOPERATION"].ToString();
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURS = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODECREDITENCOURS"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALDEBIT"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALCREDIT"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITTOTAL = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTDEBITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTCREDITTOTAL = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTCREDITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSTOTAL = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEDEBITENCOURSTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSTOTAL = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODECREDITENCOURSTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITTOTAL = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALDEBITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALCREDITTOTAL = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALCREDITTOTAL"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITGESTION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTDEBITGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSGESTION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEDEBITENCOURSGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSGESTION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODECREDITENCOURSGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITGESTION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALDEBITGESTION"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEPRECEDENTDEBITBILAN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTDEBITBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODEDEBITENCOURSBILAN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEDEBITENCOURSBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTPERIODECREDITENCOURSBILAN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODECREDITENCOURSBILAN"].ToString());
					clsBalanceinventaire.PL_MONTANTSOLDEFINALDEBITBILAN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALDEBITBILAN"].ToString());
					clsBalanceinventaires.Add(clsBalanceinventaire);
				}
				Dataset.Dispose();
			}
		return clsBalanceinventaires;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BALANCEINVENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , MV_LIBELLEOPERATION FROM dbo.FT_BALANCEINVENTAIRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT, EX_EXERCICE, PL_CODENUMCOMPTE)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND EX_EXERCICE=@EX_EXERCICE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@EX_EXERCICE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND EX_EXERCICE=@EX_EXERCICE AND BI_TYPEBALANCE=@BI_TYPEBALANCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@EX_EXERCICE", "@BI_TYPEBALANCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
