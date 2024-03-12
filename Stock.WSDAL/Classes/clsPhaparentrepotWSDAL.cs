using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparentrepotWSDAL: ITableDAL<clsPhaparentrepot>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{}; 
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(EN_CODEENTREPOT) AS EN_CODEENTREPOT  FROM dbo.PHAPARENTREPOT  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(EN_CODEENTREPOT) AS EN_CODEENTREPOT  FROM dbo.PHAPARENTREPOT  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(EN_CODEENTREPOT) AS EN_CODEENTREPOT  FROM dbo.PHAPARENTREPOT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparentrepot comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparentrepot pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT EN_DENOMINATION  , EN_ADRESSEPOSTALE  , EN_ADRESSEGEOGRAPHIQUE  , EN_TELEPHONE  , EN_FAX  , EN_SITEWEB  , EN_EMAIL  , EN_GERANT  FROM dbo.FT_PHAPARENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparentrepot clsPhaparentrepot = new clsPhaparentrepot();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparentrepot.EN_DENOMINATION = clsDonnee.vogDataReader["EN_DENOMINATION"].ToString();
					clsPhaparentrepot.EN_ADRESSEPOSTALE = clsDonnee.vogDataReader["EN_ADRESSEPOSTALE"].ToString();
					clsPhaparentrepot.EN_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["EN_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparentrepot.EN_TELEPHONE = clsDonnee.vogDataReader["EN_TELEPHONE"].ToString();
					clsPhaparentrepot.EN_FAX = clsDonnee.vogDataReader["EN_FAX"].ToString();
					clsPhaparentrepot.EN_SITEWEB = clsDonnee.vogDataReader["EN_SITEWEB"].ToString();
					clsPhaparentrepot.EN_EMAIL = clsDonnee.vogDataReader["EN_EMAIL"].ToString();
					clsPhaparentrepot.EN_GERANT = clsDonnee.vogDataReader["EN_GERANT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparentrepot;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparentrepot>clsPhaparentrepot</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparentrepot clsPhaparentrepot)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
			vppParamAG_CODEAGENCE.Value  = clsPhaparentrepot.AG_CODEAGENCE ;

			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsPhaparentrepot.EN_CODEENTREPOT ;

            SqlParameter vppParamEN_NUMENTREPOT = new SqlParameter("@EN_NUMENTREPOT", SqlDbType.VarChar, 150);
            vppParamEN_NUMENTREPOT.Value = clsPhaparentrepot.EN_NUMENTREPOT;

			SqlParameter vppParamEN_DENOMINATION = new SqlParameter("@EN_DENOMINATION", SqlDbType.VarChar, 150);
			vppParamEN_DENOMINATION.Value  = clsPhaparentrepot.EN_DENOMINATION ;

			SqlParameter vppParamEN_ADRESSEPOSTALE = new SqlParameter("@EN_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
			vppParamEN_ADRESSEPOSTALE.Value  = clsPhaparentrepot.EN_ADRESSEPOSTALE ;

			SqlParameter vppParamEN_ADRESSEGEOGRAPHIQUE = new SqlParameter("@EN_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
			vppParamEN_ADRESSEGEOGRAPHIQUE.Value  = clsPhaparentrepot.EN_ADRESSEGEOGRAPHIQUE ;

			SqlParameter vppParamEN_TELEPHONE = new SqlParameter("@EN_TELEPHONE", SqlDbType.VarChar, 80);
			vppParamEN_TELEPHONE.Value  = clsPhaparentrepot.EN_TELEPHONE ;

			SqlParameter vppParamEN_FAX = new SqlParameter("@EN_FAX", SqlDbType.VarChar, 80);
			vppParamEN_FAX.Value  = clsPhaparentrepot.EN_FAX ;

			SqlParameter vppParamEN_SITEWEB = new SqlParameter("@EN_SITEWEB", SqlDbType.VarChar, 150);
			vppParamEN_SITEWEB.Value  = clsPhaparentrepot.EN_SITEWEB ;

			SqlParameter vppParamEN_EMAIL = new SqlParameter("@EN_EMAIL", SqlDbType.VarChar, 80);
			vppParamEN_EMAIL.Value  = clsPhaparentrepot.EN_EMAIL ;

			SqlParameter vppParamEN_GERANT = new SqlParameter("@EN_GERANT", SqlDbType.VarChar, 150);
			vppParamEN_GERANT.Value  = clsPhaparentrepot.EN_GERANT ;

            SqlParameter vppParamEN_ENTREPOTPARDEFAUT = new SqlParameter("@EN_ENTREPOTPARDEFAUT", SqlDbType.VarChar, 1);
            vppParamEN_ENTREPOTPARDEFAUT.Value = clsPhaparentrepot.EN_ENTREPOTPARDEFAUT;

            SqlParameter vppParamEN_REFERENCE = new SqlParameter("@EN_REFERENCE", SqlDbType.VarChar, 1);
            vppParamEN_REFERENCE.Value = clsPhaparentrepot.EN_REFERENCE;


            SqlParameter vppParamEN_STOCKMINI = new SqlParameter("@EN_STOCKMINI", SqlDbType.Money);
            vppParamEN_STOCKMINI.Value = clsPhaparentrepot.EN_STOCKMINI;

            SqlParameter vppParamEN_STOCKMAXI = new SqlParameter("@EN_STOCKMAXI", SqlDbType.Money);
            vppParamEN_STOCKMAXI.Value = clsPhaparentrepot.EN_STOCKMAXI;

            SqlParameter vppParamEN_ACTIF = new SqlParameter("@EN_ACTIF", SqlDbType.VarChar, 1);
            vppParamEN_ACTIF.Value = clsPhaparentrepot.EN_ACTIF;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;



            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARENTREPOT  @AG_CODEAGENCE, @EN_CODEENTREPOT,@EN_NUMENTREPOT, @EN_DENOMINATION, @EN_ADRESSEPOSTALE, @EN_ADRESSEGEOGRAPHIQUE, @EN_TELEPHONE, @EN_FAX, @EN_SITEWEB, @EN_EMAIL, @EN_GERANT,@EN_ENTREPOTPARDEFAUT,@EN_REFERENCE,@EN_STOCKMINI,@EN_STOCKMAXI,@EN_ACTIF, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            ////Préparation de la commande
            // this.vapRequete = "INSERT INTO PHAPARENTREPOT (  AG_CODEAGENCE, EN_CODEENTREPOT, EN_DENOMINATION, EN_ADRESSEPOSTALE, EN_ADRESSEGEOGRAPHIQUE, EN_TELEPHONE, EN_FAX, EN_SITEWEB, EN_EMAIL, EN_GERANT) " +
            //         "VALUES ( @AG_CODEAGENCE, @EN_CODEENTREPOT, @EN_DENOMINATION, @EN_ADRESSEPOSTALE, @EN_ADRESSEGEOGRAPHIQUE, @EN_TELEPHONE, @EN_FAX, @EN_SITEWEB, @EN_EMAIL, @EN_GERANT) ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamEN_NUMENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamEN_DENOMINATION);
			vppSqlCmd.Parameters.Add(vppParamEN_ADRESSEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamEN_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamEN_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamEN_FAX);
			vppSqlCmd.Parameters.Add(vppParamEN_SITEWEB);
			vppSqlCmd.Parameters.Add(vppParamEN_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamEN_GERANT);
            vppSqlCmd.Parameters.Add(vppParamEN_ENTREPOTPARDEFAUT);
            vppSqlCmd.Parameters.Add(vppParamEN_REFERENCE);

            vppSqlCmd.Parameters.Add(vppParamEN_STOCKMINI);
            vppSqlCmd.Parameters.Add(vppParamEN_STOCKMAXI);
            vppSqlCmd.Parameters.Add(vppParamEN_ACTIF);
            
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparentrepot>clsPhaparentrepot</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparentrepot clsPhaparentrepot,params string[] vppCritere)
		{


            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 5);
            vppParamAG_CODEAGENCE.Value = clsPhaparentrepot.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsPhaparentrepot.EN_CODEENTREPOT;

            SqlParameter vppParamEN_NUMENTREPOT = new SqlParameter("@EN_NUMENTREPOT", SqlDbType.VarChar,150);
            vppParamEN_NUMENTREPOT.Value = clsPhaparentrepot.EN_NUMENTREPOT;

            SqlParameter vppParamEN_DENOMINATION = new SqlParameter("@EN_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamEN_DENOMINATION.Value = clsPhaparentrepot.EN_DENOMINATION;

            SqlParameter vppParamEN_ADRESSEPOSTALE = new SqlParameter("@EN_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamEN_ADRESSEPOSTALE.Value = clsPhaparentrepot.EN_ADRESSEPOSTALE;

            SqlParameter vppParamEN_ADRESSEGEOGRAPHIQUE = new SqlParameter("@EN_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamEN_ADRESSEGEOGRAPHIQUE.Value = clsPhaparentrepot.EN_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamEN_TELEPHONE = new SqlParameter("@EN_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamEN_TELEPHONE.Value = clsPhaparentrepot.EN_TELEPHONE;

            SqlParameter vppParamEN_FAX = new SqlParameter("@EN_FAX", SqlDbType.VarChar, 80);
            vppParamEN_FAX.Value = clsPhaparentrepot.EN_FAX;

            SqlParameter vppParamEN_SITEWEB = new SqlParameter("@EN_SITEWEB", SqlDbType.VarChar, 150);
            vppParamEN_SITEWEB.Value = clsPhaparentrepot.EN_SITEWEB;

            SqlParameter vppParamEN_EMAIL = new SqlParameter("@EN_EMAIL", SqlDbType.VarChar, 80);
            vppParamEN_EMAIL.Value = clsPhaparentrepot.EN_EMAIL;

            SqlParameter vppParamEN_GERANT = new SqlParameter("@EN_GERANT", SqlDbType.VarChar, 150);
            vppParamEN_GERANT.Value = clsPhaparentrepot.EN_GERANT;

            SqlParameter vppParamEN_ENTREPOTPARDEFAUT = new SqlParameter("@EN_ENTREPOTPARDEFAUT", SqlDbType.VarChar, 1);
            vppParamEN_ENTREPOTPARDEFAUT.Value = clsPhaparentrepot.EN_ENTREPOTPARDEFAUT;

            SqlParameter vppParamEN_REFERENCE = new SqlParameter("@EN_REFERENCE", SqlDbType.VarChar, 1);
            vppParamEN_REFERENCE.Value = clsPhaparentrepot.EN_REFERENCE;

            SqlParameter vppParamEN_STOCKMINI = new SqlParameter("@EN_STOCKMINI", SqlDbType.Money);
            vppParamEN_STOCKMINI.Value = clsPhaparentrepot.EN_STOCKMINI;

            SqlParameter vppParamEN_STOCKMAXI = new SqlParameter("@EN_STOCKMAXI", SqlDbType.Money);
            vppParamEN_STOCKMAXI.Value = clsPhaparentrepot.EN_STOCKMAXI;

            SqlParameter vppParamEN_ACTIF= new SqlParameter("@EN_ACTIF", SqlDbType.VarChar, 1);
            vppParamEN_ACTIF.Value = clsPhaparentrepot.EN_ACTIF;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;



            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARENTREPOT  @AG_CODEAGENCE, @EN_CODEENTREPOT,@EN_NUMENTREPOT, @EN_DENOMINATION, @EN_ADRESSEPOSTALE, @EN_ADRESSEGEOGRAPHIQUE, @EN_TELEPHONE, @EN_FAX, @EN_SITEWEB, @EN_EMAIL, @EN_GERANT,@EN_ENTREPOTPARDEFAUT,@EN_REFERENCE,@EN_STOCKMINI,@EN_STOCKMAXI,@EN_ACTIF, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            ////Préparation de la commande
            // this.vapRequete = "INSERT INTO PHAPARENTREPOT (  AG_CODEAGENCE, EN_CODEENTREPOT, EN_DENOMINATION, EN_ADRESSEPOSTALE, EN_ADRESSEGEOGRAPHIQUE, EN_TELEPHONE, EN_FAX, EN_SITEWEB, EN_EMAIL, EN_GERANT) " +
            //         "VALUES ( @AG_CODEAGENCE, @EN_CODEENTREPOT, @EN_DENOMINATION, @EN_ADRESSEPOSTALE, @EN_ADRESSEGEOGRAPHIQUE, @EN_TELEPHONE, @EN_FAX, @EN_SITEWEB, @EN_EMAIL, @EN_GERANT) ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamEN_NUMENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamEN_DENOMINATION);
            vppSqlCmd.Parameters.Add(vppParamEN_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamEN_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamEN_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamEN_FAX);
            vppSqlCmd.Parameters.Add(vppParamEN_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamEN_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamEN_GERANT);
            vppSqlCmd.Parameters.Add(vppParamEN_ENTREPOTPARDEFAUT);
            vppSqlCmd.Parameters.Add(vppParamEN_REFERENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_STOCKMINI);
            vppSqlCmd.Parameters.Add(vppParamEN_STOCKMAXI);
            vppSqlCmd.Parameters.Add(vppParamEN_ACTIF);
            
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);








            ////Préparation des paramètres
            //SqlParameter vppParamEN_DENOMINATION = new SqlParameter("@EN_DENOMINATION", SqlDbType.VarChar, 150);
            //vppParamEN_DENOMINATION.Value  = clsPhaparentrepot.EN_DENOMINATION ;

            //SqlParameter vppParamEN_ADRESSEPOSTALE = new SqlParameter("@EN_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            //vppParamEN_ADRESSEPOSTALE.Value  = clsPhaparentrepot.EN_ADRESSEPOSTALE ;

            //SqlParameter vppParamEN_ADRESSEGEOGRAPHIQUE = new SqlParameter("@EN_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            //vppParamEN_ADRESSEGEOGRAPHIQUE.Value  = clsPhaparentrepot.EN_ADRESSEGEOGRAPHIQUE ;

            //SqlParameter vppParamEN_TELEPHONE = new SqlParameter("@EN_TELEPHONE", SqlDbType.VarChar, 80);
            //vppParamEN_TELEPHONE.Value  = clsPhaparentrepot.EN_TELEPHONE ;

            //SqlParameter vppParamEN_FAX = new SqlParameter("@EN_FAX", SqlDbType.VarChar, 80);
            //vppParamEN_FAX.Value  = clsPhaparentrepot.EN_FAX ;

            //SqlParameter vppParamEN_SITEWEB = new SqlParameter("@EN_SITEWEB", SqlDbType.VarChar, 150);
            //vppParamEN_SITEWEB.Value  = clsPhaparentrepot.EN_SITEWEB ;

            //SqlParameter vppParamEN_EMAIL = new SqlParameter("@EN_EMAIL", SqlDbType.VarChar, 80);
            //vppParamEN_EMAIL.Value  = clsPhaparentrepot.EN_EMAIL ;

            //SqlParameter vppParamEN_GERANT = new SqlParameter("@EN_GERANT", SqlDbType.VarChar, 150);
            //vppParamEN_GERANT.Value  = clsPhaparentrepot.EN_GERANT ;

            ////Préparation de la commande
            //pvpChoixCritere(clsDonnee, vppCritere); 
            // this.vapRequete = "UPDATE PHAPARENTREPOT SET " +
            //                "EN_DENOMINATION = @EN_DENOMINATION, "+
            //                "EN_ADRESSEPOSTALE = @EN_ADRESSEPOSTALE, "+
            //                "EN_ADRESSEGEOGRAPHIQUE = @EN_ADRESSEGEOGRAPHIQUE, "+
            //                "EN_TELEPHONE = @EN_TELEPHONE, "+
            //                "EN_FAX = @EN_FAX, "+
            //                "EN_SITEWEB = @EN_SITEWEB, "+
            //                "EN_EMAIL = @EN_EMAIL, "+
            //                "EN_GERANT = @EN_GERANT " + vapCritere;
            //this.vapCritere = "";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            ////Ajout des paramètre à la commande
            //vppSqlCmd.Parameters.Add(vppParamEN_DENOMINATION);
            //vppSqlCmd.Parameters.Add(vppParamEN_ADRESSEPOSTALE);
            //vppSqlCmd.Parameters.Add(vppParamEN_ADRESSEGEOGRAPHIQUE);
            //vppSqlCmd.Parameters.Add(vppParamEN_TELEPHONE);
            //vppSqlCmd.Parameters.Add(vppParamEN_FAX);
            //vppSqlCmd.Parameters.Add(vppParamEN_SITEWEB);
            //vppSqlCmd.Parameters.Add(vppParamEN_EMAIL);
            //vppSqlCmd.Parameters.Add(vppParamEN_GERANT);
            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARENTREPOT "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparentrepot </returns>
		///<author>Home Technology</author>
		public List<clsPhaparentrepot> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, EN_DENOMINATION, EN_ADRESSEPOSTALE, EN_ADRESSEGEOGRAPHIQUE, EN_TELEPHONE, EN_FAX, EN_SITEWEB, EN_EMAIL, EN_GERANT FROM dbo.FT_PHAPARENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparentrepot> clsPhaparentrepots = new List<clsPhaparentrepot>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparentrepot clsPhaparentrepot = new clsPhaparentrepot();
					clsPhaparentrepot.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhaparentrepot.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsPhaparentrepot.EN_DENOMINATION = clsDonnee.vogDataReader["EN_DENOMINATION"].ToString();
					clsPhaparentrepot.EN_ADRESSEPOSTALE = clsDonnee.vogDataReader["EN_ADRESSEPOSTALE"].ToString();
					clsPhaparentrepot.EN_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["EN_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparentrepot.EN_TELEPHONE = clsDonnee.vogDataReader["EN_TELEPHONE"].ToString();
					clsPhaparentrepot.EN_FAX = clsDonnee.vogDataReader["EN_FAX"].ToString();
					clsPhaparentrepot.EN_SITEWEB = clsDonnee.vogDataReader["EN_SITEWEB"].ToString();
					clsPhaparentrepot.EN_EMAIL = clsDonnee.vogDataReader["EN_EMAIL"].ToString();
					clsPhaparentrepot.EN_GERANT = clsDonnee.vogDataReader["EN_GERANT"].ToString();
					clsPhaparentrepots.Add(clsPhaparentrepot);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparentrepots;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparentrepot </returns>
		///<author>Home Technology</author>
		public List<clsPhaparentrepot> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparentrepot> clsPhaparentrepots = new List<clsPhaparentrepot>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, EN_DENOMINATION, EN_ADRESSEPOSTALE, EN_ADRESSEGEOGRAPHIQUE, EN_TELEPHONE, EN_FAX, EN_SITEWEB, EN_EMAIL, EN_GERANT FROM dbo.FT_PHAPARENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparentrepot clsPhaparentrepot = new clsPhaparentrepot();
					clsPhaparentrepot.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhaparentrepot.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsPhaparentrepot.EN_DENOMINATION = Dataset.Tables["TABLE"].Rows[Idx]["EN_DENOMINATION"].ToString();
					clsPhaparentrepot.EN_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["EN_ADRESSEPOSTALE"].ToString();
					clsPhaparentrepot.EN_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["EN_ADRESSEGEOGRAPHIQUE"].ToString();
					clsPhaparentrepot.EN_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["EN_TELEPHONE"].ToString();
					clsPhaparentrepot.EN_FAX = Dataset.Tables["TABLE"].Rows[Idx]["EN_FAX"].ToString();
					clsPhaparentrepot.EN_SITEWEB = Dataset.Tables["TABLE"].Rows[Idx]["EN_SITEWEB"].ToString();
					clsPhaparentrepot.EN_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["EN_EMAIL"].ToString();
					clsPhaparentrepot.EN_GERANT = Dataset.Tables["TABLE"].Rows[Idx]["EN_GERANT"].ToString();
					clsPhaparentrepots.Add(clsPhaparentrepot);
				}
				Dataset.Dispose();
			}
		return clsPhaparentrepots;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND EN_ACTIF='O'";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE"};
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0]};
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT EN_CODEENTREPOT,EN_DENOMINATION FROM dbo.FT_PHAPARENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboEdition(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0].Replace("''", "'") , vppCritere[1], vppCritere[2]};
            this.vapRequete = "EXEC PS_COMBOPHAPARENTREPOTCHARGEMENT @AG_CODEAGENCE,@EN_CODEENTREPOT,@OP_CODEOPERATEUR,@CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboDroitSaisie(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@EN_CODEENTREPOTAEXCLURE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0].Replace("''", "'") , vppCritere[1], vppCritere[2], vppCritere[3]};
            this.vapRequete = "EXEC PS_COMBOPHAPARENTREPOTSAISIECHARGEMENT @AG_CODEAGENCE,@EN_CODEENTREPOT,@EN_CODEENTREPOTAEXCLURE,@OP_CODEOPERATEUR,@CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }



        public DataSet pvgChargerDansDataSetPourComboExclusion(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereExclusion(clsDonnee, vppCritere);
            this.vapRequete = "SELECT EN_CODEENTREPOT,EN_DENOMINATION FROM dbo.FT_PHAPARENTREPOT(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereExclusion(clsDonnee clsDonnee, params string[] vppCritere)
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT<>@EN_CODEENTREPOT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT)</summary>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_ENTREPOTPARDEFAUT=@EN_ENTREPOTPARDEFAUT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_ENTREPOTPARDEFAUT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }



	}
}
