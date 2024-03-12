using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBienimmobilisefamilleWSDAL: ITableDAL<clsBienimmobilisefamille>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PS_CODESOUSPRODUIT) AS PS_CODESOUSPRODUIT  FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PS_CODESOUSPRODUIT) AS PS_CODESOUSPRODUIT  FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PS_CODESOUSPRODUIT) AS PS_CODESOUSPRODUIT  FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBienimmobilisefamille comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBienimmobilisefamille pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PL_CODENUMCOMPTE  , PS_LIBELLE  , PS_DUREEMINIMUM  , PS_DUREEMAXIMUM  , PS_AMORTISSEMENTDIRECT  , PS_AMORTISSEMENTBIEN  , PS_AMORTISSEMENTVALEURRESIDUELLEZERO  , PS_ACTIF  , PS_NUMEROORDRE  , PS_DATESAISIE  FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBienimmobilisefamille clsBienimmobilisefamille = new clsBienimmobilisefamille();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBienimmobilisefamille.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsBienimmobilisefamille.PS_LIBELLE = clsDonnee.vogDataReader["PS_LIBELLE"].ToString();
					clsBienimmobilisefamille.PS_DUREEMINIMUM = int.Parse(clsDonnee.vogDataReader["PS_DUREEMINIMUM"].ToString());
					clsBienimmobilisefamille.PS_DUREEMAXIMUM = int.Parse(clsDonnee.vogDataReader["PS_DUREEMAXIMUM"].ToString());
					clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT = clsDonnee.vogDataReader["PS_AMORTISSEMENTDIRECT"].ToString();
					clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN = clsDonnee.vogDataReader["PS_AMORTISSEMENTBIEN"].ToString();
					clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO = int.Parse(clsDonnee.vogDataReader["PS_AMORTISSEMENTVALEURRESIDUELLEZERO"].ToString());
					clsBienimmobilisefamille.PS_ACTIF = clsDonnee.vogDataReader["PS_ACTIF"].ToString();
					clsBienimmobilisefamille.PS_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PS_NUMEROORDRE"].ToString());
					clsBienimmobilisefamille.PS_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PS_DATESAISIE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBienimmobilisefamille;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBienimmobilisefamille>clsBienimmobilisefamille</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBienimmobilisefamille clsBienimmobilisefamille)
		{
			//Préparation des paramètres
			SqlParameter vppParamPS_CODESOUSPRODUIT = new SqlParameter("@PS_CODESOUSPRODUIT1", SqlDbType.VarChar, 5);
			vppParamPS_CODESOUSPRODUIT.Value  = clsBienimmobilisefamille.PS_CODESOUSPRODUIT ;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 150);
			vppParamPL_CODENUMCOMPTE.Value  = clsBienimmobilisefamille.PL_CODENUMCOMPTE ;
            SqlParameter vppParamNT_CODENATUREBIEN = new SqlParameter("@NT_CODENATUREBIEN", SqlDbType.VarChar, 2);
            vppParamNT_CODENATUREBIEN.Value  = clsBienimmobilisefamille.NT_CODENATUREBIEN;

            SqlParameter vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = new SqlParameter("@PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT", SqlDbType.VarChar, 5);
            vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT.Value  = clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT;
            if (clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT == "") vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT.Value = DBNull.Value;
			SqlParameter vppParamPS_LIBELLE = new SqlParameter("@PS_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPS_LIBELLE.Value  = clsBienimmobilisefamille.PS_LIBELLE ;
			SqlParameter vppParamPS_DUREEMINIMUM = new SqlParameter("@PS_DUREEMINIMUM", SqlDbType.Int);
			vppParamPS_DUREEMINIMUM.Value  = clsBienimmobilisefamille.PS_DUREEMINIMUM ;
			SqlParameter vppParamPS_DUREEMAXIMUM = new SqlParameter("@PS_DUREEMAXIMUM", SqlDbType.Int);
			vppParamPS_DUREEMAXIMUM.Value  = clsBienimmobilisefamille.PS_DUREEMAXIMUM ;
			SqlParameter vppParamPS_AMORTISSEMENTDIRECT = new SqlParameter("@PS_AMORTISSEMENTDIRECT", SqlDbType.VarChar, 1);
			vppParamPS_AMORTISSEMENTDIRECT.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT ;
			SqlParameter vppParamPS_AMORTISSEMENTBIEN = new SqlParameter("@PS_AMORTISSEMENTBIEN", SqlDbType.VarChar, 1);
			vppParamPS_AMORTISSEMENTBIEN.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN ;
			SqlParameter vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO = new SqlParameter("@PS_AMORTISSEMENTVALEURRESIDUELLEZERO", SqlDbType.TinyInt);
			vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO ;
			SqlParameter vppParamPS_ACTIF = new SqlParameter("@PS_ACTIF", SqlDbType.VarChar, 1);
			vppParamPS_ACTIF.Value  = clsBienimmobilisefamille.PS_ACTIF ;
			SqlParameter vppParamPS_NUMEROORDRE = new SqlParameter("@PS_NUMEROORDRE", SqlDbType.Int);
			vppParamPS_NUMEROORDRE.Value  = clsBienimmobilisefamille.PS_NUMEROORDRE ;
			SqlParameter vppParamPS_DATESAISIE = new SqlParameter("@PS_DATESAISIE", SqlDbType.DateTime);
			vppParamPS_DATESAISIE.Value  = clsBienimmobilisefamille.PS_DATESAISIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEFAMILLE  @PS_CODESOUSPRODUIT1, @PL_CODENUMCOMPTE,@NT_CODENATUREBIEN,@PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT, @PS_LIBELLE, @PS_DUREEMINIMUM, @PS_DUREEMAXIMUM, @PS_AMORTISSEMENTDIRECT, @PS_AMORTISSEMENTBIEN, @PS_AMORTISSEMENTVALEURRESIDUELLEZERO, @PS_ACTIF, @PS_NUMEROORDRE, @PS_DATESAISIE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPS_CODESOUSPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATUREBIEN);
            vppSqlCmd.Parameters.Add(vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT);
			vppSqlCmd.Parameters.Add(vppParamPS_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPS_DUREEMINIMUM);
			vppSqlCmd.Parameters.Add(vppParamPS_DUREEMAXIMUM);
			vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTDIRECT);
			vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTBIEN);
			vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO);
			vppSqlCmd.Parameters.Add(vppParamPS_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamPS_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamPS_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBienimmobilisefamille>clsBienimmobilisefamille</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBienimmobilisefamille clsBienimmobilisefamille,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPS_CODESOUSPRODUIT = new SqlParameter("@PS_CODESOUSPRODUIT", SqlDbType.VarChar, 5);
			vppParamPS_CODESOUSPRODUIT.Value  = clsBienimmobilisefamille.PS_CODESOUSPRODUIT ;
            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 150);
			vppParamPL_CODENUMCOMPTE.Value  = clsBienimmobilisefamille.PL_CODENUMCOMPTE ;

            SqlParameter vppParamNT_CODENATUREBIEN = new SqlParameter("@NT_CODENATUREBIEN", SqlDbType.VarChar, 2);
            vppParamNT_CODENATUREBIEN.Value  = clsBienimmobilisefamille.NT_CODENATUREBIEN;

            SqlParameter vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = new SqlParameter("@PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT", SqlDbType.VarChar, 5);
            vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT.Value  = clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT;
            if (clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT == "") vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT.Value = DBNull.Value;

			SqlParameter vppParamPS_LIBELLE = new SqlParameter("@PS_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPS_LIBELLE.Value  = clsBienimmobilisefamille.PS_LIBELLE ;
			SqlParameter vppParamPS_DUREEMINIMUM = new SqlParameter("@PS_DUREEMINIMUM", SqlDbType.Int);
			vppParamPS_DUREEMINIMUM.Value  = clsBienimmobilisefamille.PS_DUREEMINIMUM ;
			SqlParameter vppParamPS_DUREEMAXIMUM = new SqlParameter("@PS_DUREEMAXIMUM", SqlDbType.Int);
			vppParamPS_DUREEMAXIMUM.Value  = clsBienimmobilisefamille.PS_DUREEMAXIMUM ;
			SqlParameter vppParamPS_AMORTISSEMENTDIRECT = new SqlParameter("@PS_AMORTISSEMENTDIRECT", SqlDbType.VarChar, 1);
			vppParamPS_AMORTISSEMENTDIRECT.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT ;
			SqlParameter vppParamPS_AMORTISSEMENTBIEN = new SqlParameter("@PS_AMORTISSEMENTBIEN", SqlDbType.VarChar, 1);
			vppParamPS_AMORTISSEMENTBIEN.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN ;
			SqlParameter vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO = new SqlParameter("@PS_AMORTISSEMENTVALEURRESIDUELLEZERO", SqlDbType.TinyInt);
			vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO ;
			SqlParameter vppParamPS_ACTIF = new SqlParameter("@PS_ACTIF", SqlDbType.VarChar, 1);
			vppParamPS_ACTIF.Value  = clsBienimmobilisefamille.PS_ACTIF ;
			SqlParameter vppParamPS_NUMEROORDRE = new SqlParameter("@PS_NUMEROORDRE", SqlDbType.Int);
			vppParamPS_NUMEROORDRE.Value  = clsBienimmobilisefamille.PS_NUMEROORDRE ;
			SqlParameter vppParamPS_DATESAISIE = new SqlParameter("@PS_DATESAISIE", SqlDbType.DateTime);
			vppParamPS_DATESAISIE.Value  = clsBienimmobilisefamille.PS_DATESAISIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEFAMILLE  @PS_CODESOUSPRODUIT, @PL_CODENUMCOMPTE,@NT_CODENATUREBIEN,@PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT, @PS_LIBELLE, @PS_DUREEMINIMUM, @PS_DUREEMAXIMUM, @PS_AMORTISSEMENTDIRECT, @PS_AMORTISSEMENTBIEN, @PS_AMORTISSEMENTVALEURRESIDUELLEZERO, @PS_ACTIF, @PS_NUMEROORDRE, @PS_DATESAISIE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPS_CODESOUSPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATUREBIEN);
            vppSqlCmd.Parameters.Add(vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT);
			vppSqlCmd.Parameters.Add(vppParamPS_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPS_DUREEMINIMUM);
			vppSqlCmd.Parameters.Add(vppParamPS_DUREEMAXIMUM);
			vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTDIRECT);
			vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTBIEN);
			vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO);
			vppSqlCmd.Parameters.Add(vppParamPS_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamPS_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamPS_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsBienimmobilisefamille>clsBienimmobilisefamille</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdateCompteAmortissement(clsDonnee clsDonnee, clsBienimmobilisefamille clsBienimmobilisefamille,params string[] vppCritere)
        {
	        //Préparation des paramètres
	        SqlParameter vppParamPS_CODESOUSPRODUIT = new SqlParameter("@PS_CODESOUSPRODUIT", SqlDbType.VarChar, 5);
	        vppParamPS_CODESOUSPRODUIT.Value  = clsBienimmobilisefamille.PS_CODESOUSPRODUIT ;
         //   SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 150);
	        //vppParamPL_CODENUMCOMPTE.Value  = clsBienimmobilisefamille.PL_CODENUMCOMPTE ;

            //SqlParameter vppParamNT_CODENATUREBIEN = new SqlParameter("@NT_CODENATUREBIEN", SqlDbType.VarChar, 2);
            //vppParamNT_CODENATUREBIEN.Value  = clsBienimmobilisefamille.NT_CODENATUREBIEN;

            SqlParameter vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = new SqlParameter("@PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT", SqlDbType.VarChar, 5);
            vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT.Value  = clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT;
            if (clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT == "") vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT.Value = DBNull.Value;

	        //SqlParameter vppParamPS_LIBELLE = new SqlParameter("@PS_LIBELLE", SqlDbType.VarChar, 150);
	        //vppParamPS_LIBELLE.Value  = clsBienimmobilisefamille.PS_LIBELLE ;
	        //SqlParameter vppParamPS_DUREEMINIMUM = new SqlParameter("@PS_DUREEMINIMUM", SqlDbType.Int);
	        //vppParamPS_DUREEMINIMUM.Value  = clsBienimmobilisefamille.PS_DUREEMINIMUM ;
	        //SqlParameter vppParamPS_DUREEMAXIMUM = new SqlParameter("@PS_DUREEMAXIMUM", SqlDbType.Int);
	        //vppParamPS_DUREEMAXIMUM.Value  = clsBienimmobilisefamille.PS_DUREEMAXIMUM ;
	        //SqlParameter vppParamPS_AMORTISSEMENTDIRECT = new SqlParameter("@PS_AMORTISSEMENTDIRECT", SqlDbType.VarChar, 1);
	        //vppParamPS_AMORTISSEMENTDIRECT.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT ;
	        //SqlParameter vppParamPS_AMORTISSEMENTBIEN = new SqlParameter("@PS_AMORTISSEMENTBIEN", SqlDbType.VarChar, 1);
	        //vppParamPS_AMORTISSEMENTBIEN.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN ;
	        //SqlParameter vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO = new SqlParameter("@PS_AMORTISSEMENTVALEURRESIDUELLEZERO", SqlDbType.TinyInt);
	        //vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO.Value  = clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO ;
	        //SqlParameter vppParamPS_ACTIF = new SqlParameter("@PS_ACTIF", SqlDbType.VarChar, 1);
	        //vppParamPS_ACTIF.Value  = clsBienimmobilisefamille.PS_ACTIF ;
	        //SqlParameter vppParamPS_NUMEROORDRE = new SqlParameter("@PS_NUMEROORDRE", SqlDbType.Int);
	        //vppParamPS_NUMEROORDRE.Value  = clsBienimmobilisefamille.PS_NUMEROORDRE ;
	        //SqlParameter vppParamPS_DATESAISIE = new SqlParameter("@PS_DATESAISIE", SqlDbType.DateTime);
	        //vppParamPS_DATESAISIE.Value  = clsBienimmobilisefamille.PS_DATESAISIE ;
	        SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
	        vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

	        //Préparation de la commande
		        this.vapRequete = "EXECUTE PC_BIENIMMOBILISEFAMILLE  @PS_CODESOUSPRODUIT, '','',@PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT, '', '0', '0', '', '', '', '', '', '01/01/1900', @CODECRYPTAGE, 3 ";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

	        //Ajout des paramètre à la commande
	        vppSqlCmd.Parameters.Add(vppParamPS_CODESOUSPRODUIT);
	        //vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
         //   vppSqlCmd.Parameters.Add(vppParamNT_CODENATUREBIEN);
            vppSqlCmd.Parameters.Add(vppParamPS_CODESOUSPRODUITCOMPTEAMORTISSEMENT);
	        //vppSqlCmd.Parameters.Add(vppParamPS_LIBELLE);
	        //vppSqlCmd.Parameters.Add(vppParamPS_DUREEMINIMUM);
	        //vppSqlCmd.Parameters.Add(vppParamPS_DUREEMAXIMUM);
	        //vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTDIRECT);
	        //vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTBIEN);
	        //vppSqlCmd.Parameters.Add(vppParamPS_AMORTISSEMENTVALEURRESIDUELLEZERO);
	        //vppSqlCmd.Parameters.Add(vppParamPS_ACTIF);
	        //vppSqlCmd.Parameters.Add(vppParamPS_NUMEROORDRE);
	        //vppSqlCmd.Parameters.Add(vppParamPS_DATESAISIE);
	        vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
	        //Ouverture de la connection et exécution de la commande
	        clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BIENIMMOBILISEFAMILLE  @PS_CODESOUSPRODUIT, '' ,'' , '' ,'' , '' , '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBienimmobilisefamille </returns>
		///<author>Home Technology</author>
		public List<clsBienimmobilisefamille> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PS_CODESOUSPRODUIT, PL_CODENUMCOMPTE, PS_LIBELLE, PS_DUREEMINIMUM, PS_DUREEMAXIMUM, PS_AMORTISSEMENTDIRECT, PS_AMORTISSEMENTBIEN, PS_AMORTISSEMENTVALEURRESIDUELLEZERO, PS_ACTIF, PS_NUMEROORDRE, PS_DATESAISIE FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<clsBienimmobilisefamille>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBienimmobilisefamille clsBienimmobilisefamille = new clsBienimmobilisefamille();
					clsBienimmobilisefamille.PS_CODESOUSPRODUIT = clsDonnee.vogDataReader["PS_CODESOUSPRODUIT"].ToString();
					clsBienimmobilisefamille.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsBienimmobilisefamille.PS_LIBELLE = clsDonnee.vogDataReader["PS_LIBELLE"].ToString();
					clsBienimmobilisefamille.PS_DUREEMINIMUM = int.Parse(clsDonnee.vogDataReader["PS_DUREEMINIMUM"].ToString());
					clsBienimmobilisefamille.PS_DUREEMAXIMUM = int.Parse(clsDonnee.vogDataReader["PS_DUREEMAXIMUM"].ToString());
					clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT = clsDonnee.vogDataReader["PS_AMORTISSEMENTDIRECT"].ToString();
					clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN = clsDonnee.vogDataReader["PS_AMORTISSEMENTBIEN"].ToString();
					clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO = int.Parse(clsDonnee.vogDataReader["PS_AMORTISSEMENTVALEURRESIDUELLEZERO"].ToString());
					clsBienimmobilisefamille.PS_ACTIF = clsDonnee.vogDataReader["PS_ACTIF"].ToString();
					clsBienimmobilisefamille.PS_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PS_NUMEROORDRE"].ToString());
					clsBienimmobilisefamille.PS_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PS_DATESAISIE"].ToString());
					clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBienimmobilisefamilles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBienimmobilisefamille </returns>
		///<author>Home Technology</author>
		public List<clsBienimmobilisefamille> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<clsBienimmobilisefamille>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PS_CODESOUSPRODUIT, PL_CODENUMCOMPTE, PS_LIBELLE, PS_DUREEMINIMUM, PS_DUREEMAXIMUM, PS_AMORTISSEMENTDIRECT, PS_AMORTISSEMENTBIEN, PS_AMORTISSEMENTVALEURRESIDUELLEZERO, PS_ACTIF, PS_NUMEROORDRE, PS_DATESAISIE FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBienimmobilisefamille clsBienimmobilisefamille = new clsBienimmobilisefamille();
					clsBienimmobilisefamille.PS_CODESOUSPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["PS_CODESOUSPRODUIT"].ToString();
					clsBienimmobilisefamille.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsBienimmobilisefamille.PS_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PS_LIBELLE"].ToString();
					clsBienimmobilisefamille.PS_DUREEMINIMUM = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PS_DUREEMINIMUM"].ToString());
					clsBienimmobilisefamille.PS_DUREEMAXIMUM = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PS_DUREEMAXIMUM"].ToString());
					clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT = Dataset.Tables["TABLE"].Rows[Idx]["PS_AMORTISSEMENTDIRECT"].ToString();
					clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN = Dataset.Tables["TABLE"].Rows[Idx]["PS_AMORTISSEMENTBIEN"].ToString();
					clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PS_AMORTISSEMENTVALEURRESIDUELLEZERO"].ToString());
					clsBienimmobilisefamille.PS_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["PS_ACTIF"].ToString();
					clsBienimmobilisefamille.PS_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PS_NUMEROORDRE"].ToString());
					clsBienimmobilisefamille.PS_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PS_DATESAISIE"].ToString());
					clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
				}
				Dataset.Dispose();
			}
		return clsBienimmobilisefamilles;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            this.vapCritere = "WHERE NT_CODENATUREBIEN=@NT_CODENATUREBIEN";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@NT_CODENATUREBIEN" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
            this.vapRequete = "SELECT *  FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetFamilleBiens(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@NT_CODENATUREBIEN", "@PS_CODESOUSPRODUIT" };
            vapValeurParametre = new object[] {vppCritere[0],vppCritere[1] };
            this.vapRequete = "EXEC PS_BIENIMMOBILISEFAMILLE @NT_CODENATUREBIEN,@PS_CODESOUSPRODUIT ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }





		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PS_CODESOUSPRODUIT , PS_LIBELLE,PS_DUREEMINIMUM FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboCompteAmortissement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE NT_CODENATUREBIEN=@NT_CODENATUREBIEN";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@NT_CODENATUREBIEN" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
            this.vapRequete = "SELECT PS_CODESOUSPRODUIT , PS_LIBELLE,PS_DUREEMINIMUM FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PS_CODESOUSPRODUIT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboCreationCompte(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        pvpChoixCritere(clsDonnee ,vppCritere);
	        this.vapRequete = "SELECT PS_CODESOUSPRODUIT , PL_CODENUMCOMPTE FROM dbo.FT_BIENIMMOBILISEFAMILLE(@CODECRYPTAGE) " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PS_CODESOUSPRODUIT)</summary>
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
				this.vapCritere ="WHERE PS_CODESOUSPRODUIT=@PS_CODESOUSPRODUIT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PS_CODESOUSPRODUIT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

                case 2 :
                this.vapCritere = "WHERE NT_CODENATUREBIEN=@NT_CODENATUREBIEN";
                vapNomParametre = new string[]{"@CODECRYPTAGE", "@NT_CODENATUREBIEN" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
                break;

			}
		}
	}
}
