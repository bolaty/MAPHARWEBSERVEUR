using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparchassisWSDAL: ITableDAL<clsPhaparchassis>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CH_CODECHASSIS) AS CH_CODECHASSIS  FROM dbo.FT_PHAPARCHASSIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CH_CODECHASSIS) AS CH_CODECHASSIS  FROM dbo.FT_PHAPARCHASSIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CH_CODECHASSIS) AS CH_CODECHASSIS  FROM dbo.FT_PHAPARCHASSIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparchassis comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparchassis pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE  , CH_HAUTEUR  , CH_LARGEUR  , CH_LONGEUR  , CH_POIDSENSERVICE  , CH_POIDSAVIDE  , CH_POIDSTOTALROULANT  , CH_NUMEROSERIE  , CH_EMPLACEMENTVEHICULE  , CH_EMPREINTEAUSOL  , CH_NOMBREDEVOLUME  , CH_NOMBREDEPORTE  , CH_NOMBREDEPLACEASSISE  , CH_EMPLACEMENT  , CH_VOIEESSIEUAVANT  , CH_VOIEESSIEUARRIERE  , CH_PROPULSEURAVAR  , CH_DATEDERNIERECARTEGRISE  , CH_NOMBREDEMAINSVEHICULE, CH_DATEAVANTDERNIERECARTEGRISE  FROM dbo.FT_PHAPARCHASSIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparchassis clsPhaparchassis = new clsPhaparchassis();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparchassis.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparchassis.CH_HAUTEUR = int.Parse(clsDonnee.vogDataReader["CH_HAUTEUR"].ToString());
					clsPhaparchassis.CH_LARGEUR = int.Parse(clsDonnee.vogDataReader["CH_LARGEUR"].ToString());
					clsPhaparchassis.CH_LONGEUR = int.Parse(clsDonnee.vogDataReader["CH_LONGEUR"].ToString());
					clsPhaparchassis.CH_POIDSENSERVICE = int.Parse(clsDonnee.vogDataReader["CH_POIDSENSERVICE"].ToString());
					clsPhaparchassis.CH_POIDSAVIDE = int.Parse(clsDonnee.vogDataReader["CH_POIDSAVIDE"].ToString());
					clsPhaparchassis.CH_POIDSTOTALROULANT = int.Parse(clsDonnee.vogDataReader["CH_POIDSTOTALROULANT"].ToString());
					clsPhaparchassis.CH_NUMEROSERIE = clsDonnee.vogDataReader["CH_NUMEROSERIE"].ToString();
					clsPhaparchassis.CH_EMPLACEMENTVEHICULE = int.Parse(clsDonnee.vogDataReader["CH_EMPLACEMENTVEHICULE"].ToString());
					clsPhaparchassis.CH_EMPREINTEAUSOL = int.Parse(clsDonnee.vogDataReader["CH_EMPREINTEAUSOL"].ToString());
					clsPhaparchassis.CH_NOMBREDEVOLUME = int.Parse(clsDonnee.vogDataReader["CH_NOMBREDEVOLUME"].ToString());
					clsPhaparchassis.CH_NOMBREDEPORTE = int.Parse(clsDonnee.vogDataReader["CH_NOMBREDEPORTE"].ToString());
					clsPhaparchassis.CH_NOMBREDEPLACEASSISE = int.Parse(clsDonnee.vogDataReader["CH_NOMBREDEPLACEASSISE"].ToString());
					clsPhaparchassis.CH_EMPLACEMENT = int.Parse(clsDonnee.vogDataReader["CH_EMPLACEMENT"].ToString());
					clsPhaparchassis.CH_VOIEESSIEUAVANT = int.Parse(clsDonnee.vogDataReader["CH_VOIEESSIEUAVANT"].ToString());
					clsPhaparchassis.CH_VOIEESSIEUARRIERE = int.Parse(clsDonnee.vogDataReader["CH_VOIEESSIEUARRIERE"].ToString());
					clsPhaparchassis.CH_PROPULSEURAVAR = int.Parse(clsDonnee.vogDataReader["CH_PROPULSEURAVAR"].ToString());
					clsPhaparchassis.CH_DATEDERNIERECARTEGRISE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEDERNIERECARTEGRISE"].ToString());
                    clsPhaparchassis.CH_DATEAVANTDERNIERECARTEGRISE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEAVANTDERNIERECARTEGRISE"].ToString());
					clsPhaparchassis.CH_NOMBREDEMAINSVEHICULE = int.Parse(clsDonnee.vogDataReader["CH_NOMBREDEMAINSVEHICULE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparchassis;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparchassis>clsPhaparchassis</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparchassis clsPhaparchassis)
		{
			//Préparation des paramètres
			SqlParameter vppParamCH_CODECHASSIS = new SqlParameter("@CH_CODECHASSIS", SqlDbType.VarChar, 25);
			vppParamCH_CODECHASSIS.Value  = clsPhaparchassis.CH_CODECHASSIS ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparchassis.AR_CODEARTICLE ;
			SqlParameter vppParamCH_HAUTEUR = new SqlParameter("@CH_HAUTEUR", SqlDbType.Int);
			vppParamCH_HAUTEUR.Value  = clsPhaparchassis.CH_HAUTEUR ;
			SqlParameter vppParamCH_LARGEUR = new SqlParameter("@CH_LARGEUR", SqlDbType.Int);
			vppParamCH_LARGEUR.Value  = clsPhaparchassis.CH_LARGEUR ;
			SqlParameter vppParamCH_LONGEUR = new SqlParameter("@CH_LONGEUR", SqlDbType.Int);
			vppParamCH_LONGEUR.Value  = clsPhaparchassis.CH_LONGEUR ;
			SqlParameter vppParamCH_POIDSENSERVICE = new SqlParameter("@CH_POIDSENSERVICE", SqlDbType.Int);
			vppParamCH_POIDSENSERVICE.Value  = clsPhaparchassis.CH_POIDSENSERVICE ;
			SqlParameter vppParamCH_POIDSAVIDE = new SqlParameter("@CH_POIDSAVIDE", SqlDbType.Int);
			vppParamCH_POIDSAVIDE.Value  = clsPhaparchassis.CH_POIDSAVIDE ;
			SqlParameter vppParamCH_POIDSTOTALROULANT = new SqlParameter("@CH_POIDSTOTALROULANT", SqlDbType.Int);
			vppParamCH_POIDSTOTALROULANT.Value  = clsPhaparchassis.CH_POIDSTOTALROULANT ;
			SqlParameter vppParamCH_NUMEROSERIE = new SqlParameter("@CH_NUMEROSERIE", SqlDbType.VarChar, 1000);
			vppParamCH_NUMEROSERIE.Value  = clsPhaparchassis.CH_NUMEROSERIE ;
			SqlParameter vppParamCH_EMPLACEMENTVEHICULE = new SqlParameter("@CH_EMPLACEMENTVEHICULE", SqlDbType.Int);
			vppParamCH_EMPLACEMENTVEHICULE.Value  = clsPhaparchassis.CH_EMPLACEMENTVEHICULE ;
			SqlParameter vppParamCH_EMPREINTEAUSOL = new SqlParameter("@CH_EMPREINTEAUSOL", SqlDbType.Int);
			vppParamCH_EMPREINTEAUSOL.Value  = clsPhaparchassis.CH_EMPREINTEAUSOL ;
			SqlParameter vppParamCH_NOMBREDEVOLUME = new SqlParameter("@CH_NOMBREDEVOLUME", SqlDbType.Int);
			vppParamCH_NOMBREDEVOLUME.Value  = clsPhaparchassis.CH_NOMBREDEVOLUME ;
			SqlParameter vppParamCH_NOMBREDEPORTE = new SqlParameter("@CH_NOMBREDEPORTE", SqlDbType.Int);
			vppParamCH_NOMBREDEPORTE.Value  = clsPhaparchassis.CH_NOMBREDEPORTE ;
			SqlParameter vppParamCH_NOMBREDEPLACEASSISE = new SqlParameter("@CH_NOMBREDEPLACEASSISE", SqlDbType.Int);
			vppParamCH_NOMBREDEPLACEASSISE.Value  = clsPhaparchassis.CH_NOMBREDEPLACEASSISE ;
			SqlParameter vppParamCH_EMPLACEMENT = new SqlParameter("@CH_EMPLACEMENT", SqlDbType.Int);
			vppParamCH_EMPLACEMENT.Value  = clsPhaparchassis.CH_EMPLACEMENT ;
			SqlParameter vppParamCH_VOIEESSIEUAVANT = new SqlParameter("@CH_VOIEESSIEUAVANT", SqlDbType.Int);
			vppParamCH_VOIEESSIEUAVANT.Value  = clsPhaparchassis.CH_VOIEESSIEUAVANT ;
			SqlParameter vppParamCH_VOIEESSIEUARRIERE = new SqlParameter("@CH_VOIEESSIEUARRIERE", SqlDbType.Int);
			vppParamCH_VOIEESSIEUARRIERE.Value  = clsPhaparchassis.CH_VOIEESSIEUARRIERE ;
			SqlParameter vppParamCH_PROPULSEURAVAR = new SqlParameter("@CH_PROPULSEURAVAR", SqlDbType.Int);
			vppParamCH_PROPULSEURAVAR.Value  = clsPhaparchassis.CH_PROPULSEURAVAR ;

			SqlParameter vppParamCH_DATEDERNIERECARTEGRISE = new SqlParameter("@CH_DATEDERNIERECARTEGRISE", SqlDbType.DateTime);
			vppParamCH_DATEDERNIERECARTEGRISE.Value  = clsPhaparchassis.CH_DATEDERNIERECARTEGRISE ;

            SqlParameter vppParamCH_DATEAVANTDERNIERECARTEGRISE = new SqlParameter("@CH_DATEAVANTDERNIERECARTEGRISE", SqlDbType.DateTime);
            vppParamCH_DATEAVANTDERNIERECARTEGRISE.Value = clsPhaparchassis.CH_DATEAVANTDERNIERECARTEGRISE;

			SqlParameter vppParamCH_NOMBREDEMAINSVEHICULE = new SqlParameter("@CH_NOMBREDEMAINSVEHICULE", SqlDbType.Int);
			vppParamCH_NOMBREDEMAINSVEHICULE.Value  = clsPhaparchassis.CH_NOMBREDEMAINSVEHICULE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARCHASSIS  @CH_CODECHASSIS, @AR_CODEARTICLE, @CH_HAUTEUR, @CH_LARGEUR, @CH_LONGEUR, @CH_POIDSENSERVICE, @CH_POIDSAVIDE, @CH_POIDSTOTALROULANT, @CH_NUMEROSERIE, @CH_EMPLACEMENTVEHICULE, @CH_EMPREINTEAUSOL, @CH_NOMBREDEVOLUME, @CH_NOMBREDEPORTE, @CH_NOMBREDEPLACEASSISE, @CH_EMPLACEMENT, @CH_VOIEESSIEUAVANT, @CH_VOIEESSIEUARRIERE, @CH_PROPULSEURAVAR, @CH_DATEDERNIERECARTEGRISE, @CH_DATEAVANTDERNIERECARTEGRISE, @CH_NOMBREDEMAINSVEHICULE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCH_CODECHASSIS);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamCH_HAUTEUR);
			vppSqlCmd.Parameters.Add(vppParamCH_LARGEUR);
			vppSqlCmd.Parameters.Add(vppParamCH_LONGEUR);
			vppSqlCmd.Parameters.Add(vppParamCH_POIDSENSERVICE);
			vppSqlCmd.Parameters.Add(vppParamCH_POIDSAVIDE);
			vppSqlCmd.Parameters.Add(vppParamCH_POIDSTOTALROULANT);
			vppSqlCmd.Parameters.Add(vppParamCH_NUMEROSERIE);
			vppSqlCmd.Parameters.Add(vppParamCH_EMPLACEMENTVEHICULE);
			vppSqlCmd.Parameters.Add(vppParamCH_EMPREINTEAUSOL);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMBREDEVOLUME);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMBREDEPORTE);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMBREDEPLACEASSISE);
			vppSqlCmd.Parameters.Add(vppParamCH_EMPLACEMENT);
			vppSqlCmd.Parameters.Add(vppParamCH_VOIEESSIEUAVANT);
			vppSqlCmd.Parameters.Add(vppParamCH_VOIEESSIEUARRIERE);
			vppSqlCmd.Parameters.Add(vppParamCH_PROPULSEURAVAR);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEDERNIERECARTEGRISE);
            vppSqlCmd.Parameters.Add(vppParamCH_DATEAVANTDERNIERECARTEGRISE);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMBREDEMAINSVEHICULE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparchassis>clsPhaparchassis</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparchassis clsPhaparchassis,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCH_CODECHASSIS = new SqlParameter("@CH_CODECHASSIS", SqlDbType.VarChar, 25);
			vppParamCH_CODECHASSIS.Value  = clsPhaparchassis.CH_CODECHASSIS ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparchassis.AR_CODEARTICLE ;
			SqlParameter vppParamCH_HAUTEUR = new SqlParameter("@CH_HAUTEUR", SqlDbType.Int);
			vppParamCH_HAUTEUR.Value  = clsPhaparchassis.CH_HAUTEUR ;
			SqlParameter vppParamCH_LARGEUR = new SqlParameter("@CH_LARGEUR", SqlDbType.Int);
			vppParamCH_LARGEUR.Value  = clsPhaparchassis.CH_LARGEUR ;
			SqlParameter vppParamCH_LONGEUR = new SqlParameter("@CH_LONGEUR", SqlDbType.Int);
			vppParamCH_LONGEUR.Value  = clsPhaparchassis.CH_LONGEUR ;
			SqlParameter vppParamCH_POIDSENSERVICE = new SqlParameter("@CH_POIDSENSERVICE", SqlDbType.Int);
			vppParamCH_POIDSENSERVICE.Value  = clsPhaparchassis.CH_POIDSENSERVICE ;
			SqlParameter vppParamCH_POIDSAVIDE = new SqlParameter("@CH_POIDSAVIDE", SqlDbType.Int);
			vppParamCH_POIDSAVIDE.Value  = clsPhaparchassis.CH_POIDSAVIDE ;
			SqlParameter vppParamCH_POIDSTOTALROULANT = new SqlParameter("@CH_POIDSTOTALROULANT", SqlDbType.Int);
			vppParamCH_POIDSTOTALROULANT.Value  = clsPhaparchassis.CH_POIDSTOTALROULANT ;
			SqlParameter vppParamCH_NUMEROSERIE = new SqlParameter("@CH_NUMEROSERIE", SqlDbType.VarChar, 1000);
			vppParamCH_NUMEROSERIE.Value  = clsPhaparchassis.CH_NUMEROSERIE ;
			SqlParameter vppParamCH_EMPLACEMENTVEHICULE = new SqlParameter("@CH_EMPLACEMENTVEHICULE", SqlDbType.Int);
			vppParamCH_EMPLACEMENTVEHICULE.Value  = clsPhaparchassis.CH_EMPLACEMENTVEHICULE ;
			SqlParameter vppParamCH_EMPREINTEAUSOL = new SqlParameter("@CH_EMPREINTEAUSOL", SqlDbType.Int);
			vppParamCH_EMPREINTEAUSOL.Value  = clsPhaparchassis.CH_EMPREINTEAUSOL ;
			SqlParameter vppParamCH_NOMBREDEVOLUME = new SqlParameter("@CH_NOMBREDEVOLUME", SqlDbType.Int);
			vppParamCH_NOMBREDEVOLUME.Value  = clsPhaparchassis.CH_NOMBREDEVOLUME ;
			SqlParameter vppParamCH_NOMBREDEPORTE = new SqlParameter("@CH_NOMBREDEPORTE", SqlDbType.Int);
			vppParamCH_NOMBREDEPORTE.Value  = clsPhaparchassis.CH_NOMBREDEPORTE ;
			SqlParameter vppParamCH_NOMBREDEPLACEASSISE = new SqlParameter("@CH_NOMBREDEPLACEASSISE", SqlDbType.Int);
			vppParamCH_NOMBREDEPLACEASSISE.Value  = clsPhaparchassis.CH_NOMBREDEPLACEASSISE ;
			SqlParameter vppParamCH_EMPLACEMENT = new SqlParameter("@CH_EMPLACEMENT", SqlDbType.Int);
			vppParamCH_EMPLACEMENT.Value  = clsPhaparchassis.CH_EMPLACEMENT ;
			SqlParameter vppParamCH_VOIEESSIEUAVANT = new SqlParameter("@CH_VOIEESSIEUAVANT", SqlDbType.Int);
			vppParamCH_VOIEESSIEUAVANT.Value  = clsPhaparchassis.CH_VOIEESSIEUAVANT ;
			SqlParameter vppParamCH_VOIEESSIEUARRIERE = new SqlParameter("@CH_VOIEESSIEUARRIERE", SqlDbType.Int);
			vppParamCH_VOIEESSIEUARRIERE.Value  = clsPhaparchassis.CH_VOIEESSIEUARRIERE ;
			SqlParameter vppParamCH_PROPULSEURAVAR = new SqlParameter("@CH_PROPULSEURAVAR", SqlDbType.Int);
			vppParamCH_PROPULSEURAVAR.Value  = clsPhaparchassis.CH_PROPULSEURAVAR ;

			SqlParameter vppParamCH_DATEDERNIERECARTEGRISE = new SqlParameter("@CH_DATEDERNIERECARTEGRISE", SqlDbType.DateTime);
			vppParamCH_DATEDERNIERECARTEGRISE.Value  = clsPhaparchassis.CH_DATEDERNIERECARTEGRISE ;

            SqlParameter vppParamCH_DATEAVANTDERNIERECARTEGRISE = new SqlParameter("@CH_DATEAVANTDERNIERECARTEGRISE", SqlDbType.DateTime);
            vppParamCH_DATEAVANTDERNIERECARTEGRISE.Value = clsPhaparchassis.CH_DATEAVANTDERNIERECARTEGRISE;

			SqlParameter vppParamCH_NOMBREDEMAINSVEHICULE = new SqlParameter("@CH_NOMBREDEMAINSVEHICULE", SqlDbType.Int);
			vppParamCH_NOMBREDEMAINSVEHICULE.Value  = clsPhaparchassis.CH_NOMBREDEMAINSVEHICULE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARCHASSIS  @CH_CODECHASSIS, @AR_CODEARTICLE, @CH_HAUTEUR, @CH_LARGEUR, @CH_LONGEUR, @CH_POIDSENSERVICE, @CH_POIDSAVIDE, @CH_POIDSTOTALROULANT, @CH_NUMEROSERIE, @CH_EMPLACEMENTVEHICULE, @CH_EMPREINTEAUSOL, @CH_NOMBREDEVOLUME, @CH_NOMBREDEPORTE, @CH_NOMBREDEPLACEASSISE, @CH_EMPLACEMENT, @CH_VOIEESSIEUAVANT, @CH_VOIEESSIEUARRIERE, @CH_PROPULSEURAVAR, @CH_DATEDERNIERECARTEGRISE, @CH_DATEAVANTDERNIERECARTEGRISE, @CH_NOMBREDEMAINSVEHICULE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCH_CODECHASSIS);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamCH_HAUTEUR);
			vppSqlCmd.Parameters.Add(vppParamCH_LARGEUR);
			vppSqlCmd.Parameters.Add(vppParamCH_LONGEUR);
			vppSqlCmd.Parameters.Add(vppParamCH_POIDSENSERVICE);
			vppSqlCmd.Parameters.Add(vppParamCH_POIDSAVIDE);
			vppSqlCmd.Parameters.Add(vppParamCH_POIDSTOTALROULANT);
			vppSqlCmd.Parameters.Add(vppParamCH_NUMEROSERIE);
			vppSqlCmd.Parameters.Add(vppParamCH_EMPLACEMENTVEHICULE);
			vppSqlCmd.Parameters.Add(vppParamCH_EMPREINTEAUSOL);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMBREDEVOLUME);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMBREDEPORTE);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMBREDEPLACEASSISE);
			vppSqlCmd.Parameters.Add(vppParamCH_EMPLACEMENT);
			vppSqlCmd.Parameters.Add(vppParamCH_VOIEESSIEUAVANT);
			vppSqlCmd.Parameters.Add(vppParamCH_VOIEESSIEUARRIERE);
			vppSqlCmd.Parameters.Add(vppParamCH_PROPULSEURAVAR);
			vppSqlCmd.Parameters.Add(vppParamCH_DATEDERNIERECARTEGRISE);
            vppSqlCmd.Parameters.Add(vppParamCH_DATEAVANTDERNIERECARTEGRISE);
			vppSqlCmd.Parameters.Add(vppParamCH_NOMBREDEMAINSVEHICULE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARCHASSIS  @CH_CODECHASSIS, '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparchassis </returns>
		///<author>Home Technology</author>
		public List<clsPhaparchassis> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  CH_CODECHASSIS, AR_CODEARTICLE, CH_HAUTEUR, CH_LARGEUR, CH_LONGEUR, CH_POIDSENSERVICE, CH_POIDSAVIDE, CH_POIDSTOTALROULANT, CH_NUMEROSERIE, CH_EMPLACEMENTVEHICULE, CH_EMPREINTEAUSOL, CH_NOMBREDEVOLUME, CH_NOMBREDEPORTE, CH_NOMBREDEPLACEASSISE, CH_EMPLACEMENT, CH_VOIEESSIEUAVANT, CH_VOIEESSIEUARRIERE, CH_PROPULSEURAVAR, CH_DATEDERNIERECARTEGRISE, CH_DATEAVANTDERNIERECARTEGRISE, CH_NOMBREDEMAINSVEHICULE FROM dbo.FT_PHAPARCHASSIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparchassis> clsPhaparchassiss = new List<clsPhaparchassis>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparchassis clsPhaparchassis = new clsPhaparchassis();
					clsPhaparchassis.CH_CODECHASSIS = clsDonnee.vogDataReader["CH_CODECHASSIS"].ToString();
					clsPhaparchassis.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparchassis.CH_HAUTEUR = int.Parse(clsDonnee.vogDataReader["CH_HAUTEUR"].ToString());
					clsPhaparchassis.CH_LARGEUR = int.Parse(clsDonnee.vogDataReader["CH_LARGEUR"].ToString());
					clsPhaparchassis.CH_LONGEUR = int.Parse(clsDonnee.vogDataReader["CH_LONGEUR"].ToString());
					clsPhaparchassis.CH_POIDSENSERVICE = int.Parse(clsDonnee.vogDataReader["CH_POIDSENSERVICE"].ToString());
					clsPhaparchassis.CH_POIDSAVIDE = int.Parse(clsDonnee.vogDataReader["CH_POIDSAVIDE"].ToString());
					clsPhaparchassis.CH_POIDSTOTALROULANT = int.Parse(clsDonnee.vogDataReader["CH_POIDSTOTALROULANT"].ToString());
					clsPhaparchassis.CH_NUMEROSERIE = clsDonnee.vogDataReader["CH_NUMEROSERIE"].ToString();
					clsPhaparchassis.CH_EMPLACEMENTVEHICULE = int.Parse(clsDonnee.vogDataReader["CH_EMPLACEMENTVEHICULE"].ToString());
					clsPhaparchassis.CH_EMPREINTEAUSOL = int.Parse(clsDonnee.vogDataReader["CH_EMPREINTEAUSOL"].ToString());
					clsPhaparchassis.CH_NOMBREDEVOLUME = int.Parse(clsDonnee.vogDataReader["CH_NOMBREDEVOLUME"].ToString());
					clsPhaparchassis.CH_NOMBREDEPORTE = int.Parse(clsDonnee.vogDataReader["CH_NOMBREDEPORTE"].ToString());
					clsPhaparchassis.CH_NOMBREDEPLACEASSISE = int.Parse(clsDonnee.vogDataReader["CH_NOMBREDEPLACEASSISE"].ToString());
					clsPhaparchassis.CH_EMPLACEMENT = int.Parse(clsDonnee.vogDataReader["CH_EMPLACEMENT"].ToString());
					clsPhaparchassis.CH_VOIEESSIEUAVANT = int.Parse(clsDonnee.vogDataReader["CH_VOIEESSIEUAVANT"].ToString());
					clsPhaparchassis.CH_VOIEESSIEUARRIERE = int.Parse(clsDonnee.vogDataReader["CH_VOIEESSIEUARRIERE"].ToString());
					clsPhaparchassis.CH_PROPULSEURAVAR = int.Parse(clsDonnee.vogDataReader["CH_PROPULSEURAVAR"].ToString());
					clsPhaparchassis.CH_DATEDERNIERECARTEGRISE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEDERNIERECARTEGRISE"].ToString());
                    clsPhaparchassis.CH_DATEAVANTDERNIERECARTEGRISE = DateTime.Parse(clsDonnee.vogDataReader["CH_DATEAVANTDERNIERECARTEGRISE"].ToString());
					clsPhaparchassis.CH_NOMBREDEMAINSVEHICULE = int.Parse(clsDonnee.vogDataReader["CH_NOMBREDEMAINSVEHICULE"].ToString());
					clsPhaparchassiss.Add(clsPhaparchassis);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparchassiss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparchassis </returns>
		///<author>Home Technology</author>
		public List<clsPhaparchassis> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparchassis> clsPhaparchassiss = new List<clsPhaparchassis>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  CH_CODECHASSIS, AR_CODEARTICLE, CH_HAUTEUR, CH_LARGEUR, CH_LONGEUR, CH_POIDSENSERVICE, CH_POIDSAVIDE, CH_POIDSTOTALROULANT, CH_NUMEROSERIE, CH_EMPLACEMENTVEHICULE, CH_EMPREINTEAUSOL, CH_NOMBREDEVOLUME, CH_NOMBREDEPORTE, CH_NOMBREDEPLACEASSISE, CH_EMPLACEMENT, CH_VOIEESSIEUAVANT, CH_VOIEESSIEUARRIERE, CH_PROPULSEURAVAR, CH_DATEDERNIERECARTEGRISE, CH_DATEAVANTDERNIERECARTEGRISE, CH_NOMBREDEMAINSVEHICULE FROM dbo.FT_PHAPARCHASSIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparchassis clsPhaparchassis = new clsPhaparchassis();
					clsPhaparchassis.CH_CODECHASSIS = Dataset.Tables["TABLE"].Rows[Idx]["CH_CODECHASSIS"].ToString();
					clsPhaparchassis.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaparchassis.CH_HAUTEUR = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_HAUTEUR"].ToString());
					clsPhaparchassis.CH_LARGEUR = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_LARGEUR"].ToString());
					clsPhaparchassis.CH_LONGEUR = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_LONGEUR"].ToString());
					clsPhaparchassis.CH_POIDSENSERVICE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_POIDSENSERVICE"].ToString());
					clsPhaparchassis.CH_POIDSAVIDE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_POIDSAVIDE"].ToString());
					clsPhaparchassis.CH_POIDSTOTALROULANT = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_POIDSTOTALROULANT"].ToString());
					clsPhaparchassis.CH_NUMEROSERIE = Dataset.Tables["TABLE"].Rows[Idx]["CH_NUMEROSERIE"].ToString();
					clsPhaparchassis.CH_EMPLACEMENTVEHICULE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_EMPLACEMENTVEHICULE"].ToString());
					clsPhaparchassis.CH_EMPREINTEAUSOL = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_EMPREINTEAUSOL"].ToString());
					clsPhaparchassis.CH_NOMBREDEVOLUME = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_NOMBREDEVOLUME"].ToString());
					clsPhaparchassis.CH_NOMBREDEPORTE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_NOMBREDEPORTE"].ToString());
					clsPhaparchassis.CH_NOMBREDEPLACEASSISE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_NOMBREDEPLACEASSISE"].ToString());
					clsPhaparchassis.CH_EMPLACEMENT = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_EMPLACEMENT"].ToString());
					clsPhaparchassis.CH_VOIEESSIEUAVANT = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_VOIEESSIEUAVANT"].ToString());
					clsPhaparchassis.CH_VOIEESSIEUARRIERE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_VOIEESSIEUARRIERE"].ToString());
					clsPhaparchassis.CH_PROPULSEURAVAR = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_PROPULSEURAVAR"].ToString());
					clsPhaparchassis.CH_DATEDERNIERECARTEGRISE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATEDERNIERECARTEGRISE"].ToString());
                    clsPhaparchassis.CH_DATEAVANTDERNIERECARTEGRISE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_DATEAVANTDERNIERECARTEGRISE"].ToString());
					clsPhaparchassis.CH_NOMBREDEMAINSVEHICULE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CH_NOMBREDEMAINSVEHICULE"].ToString());
					clsPhaparchassiss.Add(clsPhaparchassis);
				}
				Dataset.Dispose();
			}
		return clsPhaparchassiss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARCHASSIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CH_CODECHASSIS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CH_CODECHASSIS , AR_CODEARTICLE FROM dbo.FT_PHAPARCHASSIS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CH_CODECHASSIS)</summary>
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
				this.vapCritere ="WHERE CH_CODECHASSIS=@CH_CODECHASSIS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CH_CODECHASSIS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
