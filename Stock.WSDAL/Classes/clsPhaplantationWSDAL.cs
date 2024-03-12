using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaplantationWSDAL: ITableDAL<clsPhaplantation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PL_IDPLANTATION) AS PL_IDPLANTATION  FROM dbo.FT_PHAPLANTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PL_IDPLANTATION) AS PL_IDPLANTATION  FROM dbo.FT_PHAPLANTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PL_IDPLANTATION) AS PL_IDPLANTATION  FROM dbo.FT_PHAPLANTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaplantation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaplantation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_IDTIERS  , AG_CODEAGENCE  , OP_CODEOPERATEUR  , ZN_CODEZONE  , PL_CODEPLANTATION  , QU_CODEQUARTIER  , AR_CODEARTICLE  , PL_SUPERFICIE  , PL_DISTANCEALUSINE  , PL_SECURISATIONFONCIERE  , PL_ASSURANCE  , PL_LONGITUDE  , PL_LATITUDE  , PL_ADRESSEGEOGRAPHIQUE  , PL_DATESAISIE  , PL_DATECREATION  FROM dbo.FT_PHAPLANTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaplantation clsPhaplantation = new clsPhaplantation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaplantation.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhaplantation.AG_CODEAGENCE = int.Parse(clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString());
					clsPhaplantation.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhaplantation.ZN_CODEZONE = clsDonnee.vogDataReader["ZN_CODEZONE"].ToString();
					clsPhaplantation.PL_CODEPLANTATION = clsDonnee.vogDataReader["PL_CODEPLANTATION"].ToString();
					clsPhaplantation.QU_CODEQUARTIER = clsDonnee.vogDataReader["QU_CODEQUARTIER"].ToString();
					clsPhaplantation.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaplantation.PL_SUPERFICIE = decimal.Parse(clsDonnee.vogDataReader["PL_SUPERFICIE"].ToString());
					clsPhaplantation.PL_DISTANCEALUSINE = decimal.Parse(clsDonnee.vogDataReader["PL_DISTANCEALUSINE"].ToString());
					clsPhaplantation.PL_SECURISATIONFONCIERE = clsDonnee.vogDataReader["PL_SECURISATIONFONCIERE"].ToString();
					clsPhaplantation.PL_ASSURANCE = clsDonnee.vogDataReader["PL_ASSURANCE"].ToString();
					clsPhaplantation.PL_LONGITUDE = decimal.Parse(clsDonnee.vogDataReader["PL_LONGITUDE"].ToString());
					clsPhaplantation.PL_LATITUDE = decimal.Parse(clsDonnee.vogDataReader["PL_LATITUDE"].ToString());
					clsPhaplantation.PL_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["PL_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaplantation.PL_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PL_DATESAISIE"].ToString());
					clsPhaplantation.PL_DATECREATION = DateTime.Parse(clsDonnee.vogDataReader["PL_DATECREATION"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaplantation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaplantation>clsPhaplantation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaplantation clsPhaplantation)
		{
			//Préparation des paramètres
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERS.Value  = clsPhaplantation.TI_IDTIERS ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
			vppParamAG_CODEAGENCE.Value  = clsPhaplantation.AG_CODEAGENCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhaplantation.OP_CODEOPERATEUR ;
			SqlParameter vppParamZN_CODEZONE = new SqlParameter("@ZN_CODEZONE", SqlDbType.VarChar, 7);
			vppParamZN_CODEZONE.Value  = clsPhaplantation.ZN_CODEZONE ;
			SqlParameter vppParamPL_IDPLANTATION = new SqlParameter("@PL_IDPLANTATION", SqlDbType.VarChar, 25);
			vppParamPL_IDPLANTATION.Value  = clsPhaplantation.PL_IDPLANTATION ;
			SqlParameter vppParamPL_CODEPLANTATION = new SqlParameter("@PL_CODEPLANTATION", SqlDbType.VarChar, 1000);
			vppParamPL_CODEPLANTATION.Value  = clsPhaplantation.PL_CODEPLANTATION ;
			SqlParameter vppParamQU_CODEQUARTIER = new SqlParameter("@QU_CODEQUARTIER", SqlDbType.VarChar, 10);
			vppParamQU_CODEQUARTIER.Value  = clsPhaplantation.QU_CODEQUARTIER ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaplantation.AR_CODEARTICLE ;
			SqlParameter vppParamPL_SUPERFICIE = new SqlParameter("@PL_SUPERFICIE", SqlDbType.Decimal, 4);
			vppParamPL_SUPERFICIE.Value  = clsPhaplantation.PL_SUPERFICIE ;
			SqlParameter vppParamPL_DISTANCEALUSINE = new SqlParameter("@PL_DISTANCEALUSINE", SqlDbType.Decimal, 4);
			vppParamPL_DISTANCEALUSINE.Value  = clsPhaplantation.PL_DISTANCEALUSINE ;
			SqlParameter vppParamPL_SECURISATIONFONCIERE = new SqlParameter("@PL_SECURISATIONFONCIERE", SqlDbType.VarChar, 1);
			vppParamPL_SECURISATIONFONCIERE.Value  = clsPhaplantation.PL_SECURISATIONFONCIERE ;
			SqlParameter vppParamPL_ASSURANCE = new SqlParameter("@PL_ASSURANCE", SqlDbType.VarChar, 1);
			vppParamPL_ASSURANCE.Value  = clsPhaplantation.PL_ASSURANCE ;
			SqlParameter vppParamPL_LONGITUDE = new SqlParameter("@PL_LONGITUDE", SqlDbType.Decimal, 4);
			vppParamPL_LONGITUDE.Value  = clsPhaplantation.PL_LONGITUDE ;
			SqlParameter vppParamPL_LATITUDE = new SqlParameter("@PL_LATITUDE", SqlDbType.Decimal, 4);
			vppParamPL_LATITUDE.Value  = clsPhaplantation.PL_LATITUDE ;
			SqlParameter vppParamPL_ADRESSEGEOGRAPHIQUE = new SqlParameter("@PL_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 1000);
			vppParamPL_ADRESSEGEOGRAPHIQUE.Value  = clsPhaplantation.PL_ADRESSEGEOGRAPHIQUE ;
			if(clsPhaplantation.PL_ADRESSEGEOGRAPHIQUE== ""  ) vppParamPL_ADRESSEGEOGRAPHIQUE.Value  = DBNull.Value;
			SqlParameter vppParamPL_DATESAISIE = new SqlParameter("@PL_DATESAISIE", SqlDbType.DateTime);
			vppParamPL_DATESAISIE.Value  = clsPhaplantation.PL_DATESAISIE ;
			SqlParameter vppParamPL_DATECREATION = new SqlParameter("@PL_DATECREATION", SqlDbType.DateTime);
			vppParamPL_DATECREATION.Value  = clsPhaplantation.PL_DATECREATION ;

            SqlParameter vppParamPL_PHOTO = new SqlParameter("@PL_PHOTO", SqlDbType.VarBinary);
            vppParamPL_PHOTO.Value = clsPhaplantation.PL_PHOTO;
            if (clsPhaplantation.PL_PHOTO == null) vppParamPL_PHOTO.Value = DBNull.Value;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPLANTATION  @TI_IDTIERS, @AG_CODEAGENCE, @OP_CODEOPERATEUR, @ZN_CODEZONE, @PL_IDPLANTATION, @PL_CODEPLANTATION, @QU_CODEQUARTIER, @AR_CODEARTICLE, @PL_SUPERFICIE, @PL_DISTANCEALUSINE, @PL_SECURISATIONFONCIERE, @PL_ASSURANCE, @PL_LONGITUDE, @PL_LATITUDE, @PL_ADRESSEGEOGRAPHIQUE, @PL_DATESAISIE, @PL_DATECREATION,@PL_PHOTO, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamZN_CODEZONE);
			vppSqlCmd.Parameters.Add(vppParamPL_IDPLANTATION);
			vppSqlCmd.Parameters.Add(vppParamPL_CODEPLANTATION);
			vppSqlCmd.Parameters.Add(vppParamQU_CODEQUARTIER);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamPL_SUPERFICIE);
			vppSqlCmd.Parameters.Add(vppParamPL_DISTANCEALUSINE);
			vppSqlCmd.Parameters.Add(vppParamPL_SECURISATIONFONCIERE);
			vppSqlCmd.Parameters.Add(vppParamPL_ASSURANCE);
			vppSqlCmd.Parameters.Add(vppParamPL_LONGITUDE);
			vppSqlCmd.Parameters.Add(vppParamPL_LATITUDE);
			vppSqlCmd.Parameters.Add(vppParamPL_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamPL_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamPL_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamPL_PHOTO);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaplantation>clsPhaplantation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaplantation clsPhaplantation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERS.Value  = clsPhaplantation.TI_IDTIERS ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
			vppParamAG_CODEAGENCE.Value  = clsPhaplantation.AG_CODEAGENCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhaplantation.OP_CODEOPERATEUR ;
			SqlParameter vppParamZN_CODEZONE = new SqlParameter("@ZN_CODEZONE", SqlDbType.VarChar, 7);
			vppParamZN_CODEZONE.Value  = clsPhaplantation.ZN_CODEZONE ;
			SqlParameter vppParamPL_IDPLANTATION = new SqlParameter("@PL_IDPLANTATION", SqlDbType.VarChar, 25);
			vppParamPL_IDPLANTATION.Value  = clsPhaplantation.PL_IDPLANTATION ;
			SqlParameter vppParamPL_CODEPLANTATION = new SqlParameter("@PL_CODEPLANTATION", SqlDbType.VarChar, 1000);
			vppParamPL_CODEPLANTATION.Value  = clsPhaplantation.PL_CODEPLANTATION ;
			SqlParameter vppParamQU_CODEQUARTIER = new SqlParameter("@QU_CODEQUARTIER", SqlDbType.VarChar, 10);
			vppParamQU_CODEQUARTIER.Value  = clsPhaplantation.QU_CODEQUARTIER ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaplantation.AR_CODEARTICLE ;
			SqlParameter vppParamPL_SUPERFICIE = new SqlParameter("@PL_SUPERFICIE", SqlDbType.Decimal, 4);
			vppParamPL_SUPERFICIE.Value  = clsPhaplantation.PL_SUPERFICIE ;
			SqlParameter vppParamPL_DISTANCEALUSINE = new SqlParameter("@PL_DISTANCEALUSINE", SqlDbType.Decimal, 4);
			vppParamPL_DISTANCEALUSINE.Value  = clsPhaplantation.PL_DISTANCEALUSINE ;
			SqlParameter vppParamPL_SECURISATIONFONCIERE = new SqlParameter("@PL_SECURISATIONFONCIERE", SqlDbType.VarChar, 1);
			vppParamPL_SECURISATIONFONCIERE.Value  = clsPhaplantation.PL_SECURISATIONFONCIERE ;
			SqlParameter vppParamPL_ASSURANCE = new SqlParameter("@PL_ASSURANCE", SqlDbType.VarChar, 1);
			vppParamPL_ASSURANCE.Value  = clsPhaplantation.PL_ASSURANCE ;
			SqlParameter vppParamPL_LONGITUDE = new SqlParameter("@PL_LONGITUDE", SqlDbType.Decimal, 4);
			vppParamPL_LONGITUDE.Value  = clsPhaplantation.PL_LONGITUDE ;
			SqlParameter vppParamPL_LATITUDE = new SqlParameter("@PL_LATITUDE", SqlDbType.Decimal, 4);
			vppParamPL_LATITUDE.Value  = clsPhaplantation.PL_LATITUDE ;
			SqlParameter vppParamPL_ADRESSEGEOGRAPHIQUE = new SqlParameter("@PL_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 1000);
			vppParamPL_ADRESSEGEOGRAPHIQUE.Value  = clsPhaplantation.PL_ADRESSEGEOGRAPHIQUE ;
			if(clsPhaplantation.PL_ADRESSEGEOGRAPHIQUE== ""  ) vppParamPL_ADRESSEGEOGRAPHIQUE.Value  = DBNull.Value;
			SqlParameter vppParamPL_DATESAISIE = new SqlParameter("@PL_DATESAISIE", SqlDbType.DateTime);
			vppParamPL_DATESAISIE.Value  = clsPhaplantation.PL_DATESAISIE ;
			SqlParameter vppParamPL_DATECREATION = new SqlParameter("@PL_DATECREATION", SqlDbType.DateTime);
			vppParamPL_DATECREATION.Value  = clsPhaplantation.PL_DATECREATION ;

            SqlParameter vppParamPL_PHOTO = new SqlParameter("@PL_PHOTO", SqlDbType.VarBinary);
            vppParamPL_PHOTO.Value = clsPhaplantation.PL_PHOTO;
            if (clsPhaplantation.PL_PHOTO == null) vppParamPL_PHOTO.Value = DBNull.Value;



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPLANTATION  @TI_IDTIERS, @AG_CODEAGENCE, @OP_CODEOPERATEUR, @ZN_CODEZONE, @PL_IDPLANTATION, @PL_CODEPLANTATION, @QU_CODEQUARTIER, @AR_CODEARTICLE, @PL_SUPERFICIE, @PL_DISTANCEALUSINE, @PL_SECURISATIONFONCIERE, @PL_ASSURANCE, @PL_LONGITUDE, @PL_LATITUDE, @PL_ADRESSEGEOGRAPHIQUE, @PL_DATESAISIE, @PL_DATECREATION,@PL_PHOTO, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamZN_CODEZONE);
			vppSqlCmd.Parameters.Add(vppParamPL_IDPLANTATION);
			vppSqlCmd.Parameters.Add(vppParamPL_CODEPLANTATION);
			vppSqlCmd.Parameters.Add(vppParamQU_CODEQUARTIER);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamPL_SUPERFICIE);
			vppSqlCmd.Parameters.Add(vppParamPL_DISTANCEALUSINE);
			vppSqlCmd.Parameters.Add(vppParamPL_SECURISATIONFONCIERE);
			vppSqlCmd.Parameters.Add(vppParamPL_ASSURANCE);
			vppSqlCmd.Parameters.Add(vppParamPL_LONGITUDE);
			vppSqlCmd.Parameters.Add(vppParamPL_LATITUDE);
			vppSqlCmd.Parameters.Add(vppParamPL_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamPL_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamPL_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamPL_PHOTO);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPLANTATION  @TI_IDTIERS, @AG_CODEAGENCE, '', '', @PL_IDPLANTATION, '' , '' , '' , '0' , '0' , '0' , '0' , '0' , '0' , '' , '' , '' , NULL , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaplantation </returns>
		///<author>Home Technology</author>
		public List<clsPhaplantation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION, PL_CODEPLANTATION, QU_CODEQUARTIER, AR_CODEARTICLE, PL_SUPERFICIE, PL_DISTANCEALUSINE, PL_SECURISATIONFONCIERE, PL_ASSURANCE, PL_LONGITUDE, PL_LATITUDE, PL_ADRESSEGEOGRAPHIQUE, PL_DATESAISIE, PL_DATECREATION FROM dbo.FT_PHAPLANTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaplantation> clsPhaplantations = new List<clsPhaplantation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaplantation clsPhaplantation = new clsPhaplantation();
					clsPhaplantation.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhaplantation.AG_CODEAGENCE = int.Parse(clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString());
					clsPhaplantation.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhaplantation.ZN_CODEZONE = clsDonnee.vogDataReader["ZN_CODEZONE"].ToString();
					clsPhaplantation.PL_IDPLANTATION = clsDonnee.vogDataReader["PL_IDPLANTATION"].ToString();
					clsPhaplantation.PL_CODEPLANTATION = clsDonnee.vogDataReader["PL_CODEPLANTATION"].ToString();
					clsPhaplantation.QU_CODEQUARTIER = clsDonnee.vogDataReader["QU_CODEQUARTIER"].ToString();
					clsPhaplantation.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaplantation.PL_SUPERFICIE = decimal.Parse(clsDonnee.vogDataReader["PL_SUPERFICIE"].ToString());
					clsPhaplantation.PL_DISTANCEALUSINE = decimal.Parse(clsDonnee.vogDataReader["PL_DISTANCEALUSINE"].ToString());
					clsPhaplantation.PL_SECURISATIONFONCIERE = clsDonnee.vogDataReader["PL_SECURISATIONFONCIERE"].ToString();
					clsPhaplantation.PL_ASSURANCE = clsDonnee.vogDataReader["PL_ASSURANCE"].ToString();
					clsPhaplantation.PL_LONGITUDE = decimal.Parse(clsDonnee.vogDataReader["PL_LONGITUDE"].ToString());
					clsPhaplantation.PL_LATITUDE = decimal.Parse(clsDonnee.vogDataReader["PL_LATITUDE"].ToString());
					clsPhaplantation.PL_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["PL_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaplantation.PL_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PL_DATESAISIE"].ToString());
					clsPhaplantation.PL_DATECREATION = DateTime.Parse(clsDonnee.vogDataReader["PL_DATECREATION"].ToString());
					clsPhaplantations.Add(clsPhaplantation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaplantations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaplantation </returns>
		///<author>Home Technology</author>
		public List<clsPhaplantation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaplantation> clsPhaplantations = new List<clsPhaplantation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION, PL_CODEPLANTATION, QU_CODEQUARTIER, AR_CODEARTICLE, PL_SUPERFICIE, PL_DISTANCEALUSINE, PL_SECURISATIONFONCIERE, PL_ASSURANCE, PL_LONGITUDE, PL_LATITUDE, PL_ADRESSEGEOGRAPHIQUE, PL_DATESAISIE, PL_DATECREATION FROM dbo.FT_PHAPLANTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaplantation clsPhaplantation = new clsPhaplantation();
					clsPhaplantation.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsPhaplantation.AG_CODEAGENCE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString());
					clsPhaplantation.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhaplantation.ZN_CODEZONE = Dataset.Tables["TABLE"].Rows[Idx]["ZN_CODEZONE"].ToString();
					clsPhaplantation.PL_IDPLANTATION = Dataset.Tables["TABLE"].Rows[Idx]["PL_IDPLANTATION"].ToString();
					clsPhaplantation.PL_CODEPLANTATION = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODEPLANTATION"].ToString();
					clsPhaplantation.QU_CODEQUARTIER = Dataset.Tables["TABLE"].Rows[Idx]["QU_CODEQUARTIER"].ToString();
					clsPhaplantation.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaplantation.PL_SUPERFICIE = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_SUPERFICIE"].ToString());
					clsPhaplantation.PL_DISTANCEALUSINE = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_DISTANCEALUSINE"].ToString());
					clsPhaplantation.PL_SECURISATIONFONCIERE = Dataset.Tables["TABLE"].Rows[Idx]["PL_SECURISATIONFONCIERE"].ToString();
					clsPhaplantation.PL_ASSURANCE = Dataset.Tables["TABLE"].Rows[Idx]["PL_ASSURANCE"].ToString();
					clsPhaplantation.PL_LONGITUDE = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_LONGITUDE"].ToString());
					clsPhaplantation.PL_LATITUDE = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_LATITUDE"].ToString());
					clsPhaplantation.PL_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["PL_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaplantation.PL_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_DATESAISIE"].ToString());
					clsPhaplantation.PL_DATECREATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_DATECREATION"].ToString());
					clsPhaplantations.Add(clsPhaplantation);
				}
				Dataset.Dispose();
			}
		return clsPhaplantations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPLANTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PL_IDPLANTATION , PL_CODEPLANTATION FROM dbo.FT_PHAPLANTATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TI_IDTIERS, AG_CODEAGENCE, OP_CODEOPERATEUR, ZN_CODEZONE, PL_IDPLANTATION)</summary>
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
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  TI_IDTIERS=@TI_IDTIERS ";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDTIERS" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;


                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  TI_IDTIERS=@TI_IDTIERS  AND PL_IDPLANTATION=@PL_IDPLANTATION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDTIERS", "@PL_IDPLANTATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
				case 4 :
				this.vapCritere ="WHERE TI_IDTIERS=@TI_IDTIERS AND AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ZN_CODEZONE=@ZN_CODEZONE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TI_IDTIERS","@AG_CODEAGENCE","@OP_CODEOPERATEUR","@ZN_CODEZONE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE TI_IDTIERS=@TI_IDTIERS AND AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ZN_CODEZONE=@ZN_CODEZONE AND PL_IDPLANTATION=@PL_IDPLANTATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TI_IDTIERS","@AG_CODEAGENCE","@OP_CODEOPERATEUR","@ZN_CODEZONE","@PL_IDPLANTATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}
	}
}
