using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsMicparametrelisteproduitsousproduitvaleurWSDAL: ITableDAL<clsMicparametrelisteproduitsousproduitvaleur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(LP_CODEPARAMETRELISTEVALEUR) AS LP_CODEPARAMETRELISTEVALEUR  FROM dbo.FT_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(LP_CODEPARAMETRELISTEVALEUR) AS LP_CODEPARAMETRELISTEVALEUR  FROM dbo.MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(LP_CODEPARAMETRELISTEVALEUR) AS LP_CODEPARAMETRELISTEVALEUR  FROM dbo.MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMicparametrelisteproduitsousproduitvaleur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMicparametrelisteproduitsousproduitvaleur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AP_CODEPRODUIT  , PL_CODEPARAMETRELISTE  , LP_BORNEMIN  , LP_BORNEMAX  , LP_MONTANTMINI  , LP_MONTANTMAXI  , LP_TAUX  , LP_MONTANT  , LP_VALEUR  FROM dbo.FT_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsMicparametrelisteproduitsousproduitvaleur clsMicparametrelisteproduitsousproduitvaleur = new clsMicparametrelisteproduitsousproduitvaleur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicparametrelisteproduitsousproduitvaleur.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsMicparametrelisteproduitsousproduitvaleur.PL_CODEPARAMETRELISTE = clsDonnee.vogDataReader["PL_CODEPARAMETRELISTE"].ToString();
                    clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMIN = double.Parse(clsDonnee.vogDataReader["LP_BORNEMIN"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMAX = double.Parse(clsDonnee.vogDataReader["LP_BORNEMAX"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMINI = decimal.Parse(clsDonnee.vogDataReader["LP_MONTANTMINI"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMAXI = decimal.Parse(clsDonnee.vogDataReader["LP_MONTANTMAXI"].ToString());
					clsMicparametrelisteproduitsousproduitvaleur.LP_TAUX = decimal.Parse(clsDonnee.vogDataReader["LP_TAUX"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANT = decimal.Parse(clsDonnee.vogDataReader["LP_MONTANT"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_VALEUR = clsDonnee.vogDataReader["LP_VALEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsMicparametrelisteproduitsousproduitvaleur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMicparametrelisteproduitsousproduitvaleur>clsMicparametrelisteproduitsousproduitvaleur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMicparametrelisteproduitsousproduitvaleur clsMicparametrelisteproduitsousproduitvaleur)
		{
			//Préparation des paramètres
			SqlParameter vppParamLP_CODEPARAMETRELISTEVALEUR = new SqlParameter("@LP_CODEPARAMETRELISTEVALEUR1", SqlDbType.BigInt);
			vppParamLP_CODEPARAMETRELISTEVALEUR.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_CODEPARAMETRELISTEVALEUR ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT1", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsMicparametrelisteproduitsousproduitvaleur.AP_CODEPRODUIT ;
			SqlParameter vppParamPL_CODEPARAMETRELISTE = new SqlParameter("@PL_CODEPARAMETRELISTE1", SqlDbType.VarChar, 5);
			vppParamPL_CODEPARAMETRELISTE.Value  = clsMicparametrelisteproduitsousproduitvaleur.PL_CODEPARAMETRELISTE ;
            SqlParameter vppParamLP_BORNEMIN = new SqlParameter("@LP_BORNEMIN", SqlDbType.Money);
			vppParamLP_BORNEMIN.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMIN ;
            SqlParameter vppParamLP_BORNEMAX = new SqlParameter("@LP_BORNEMAX", SqlDbType.Money);
			vppParamLP_BORNEMAX.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMAX ;
            SqlParameter vppParamLP_MONTANTMINI = new SqlParameter("@LP_MONTANTMINI1", SqlDbType.Money);
			vppParamLP_MONTANTMINI.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMINI ;
            SqlParameter vppParamLP_MONTANTMAXI = new SqlParameter("@LP_MONTANTMAXI1", SqlDbType.Money);
			vppParamLP_MONTANTMAXI.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMAXI ;
			SqlParameter vppParamLP_TAUX = new SqlParameter("@LP_TAUX", SqlDbType.Decimal);
			vppParamLP_TAUX.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_TAUX ;
			SqlParameter vppParamLP_MONTANT = new SqlParameter("@LP_MONTANT", SqlDbType.Money);
			vppParamLP_MONTANT.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANT ;

			SqlParameter vppParamLP_TAUXREMUNERATIONCOMMERCIAL = new SqlParameter("@LP_TAUXREMUNERATIONCOMMERCIAL", SqlDbType.Decimal);
            vppParamLP_TAUXREMUNERATIONCOMMERCIAL.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_TAUXREMUNERATIONCOMMERCIAL;
			SqlParameter vppParamLP_MONTANTREMUNERATIONCOMMERCIAL = new SqlParameter("@LP_MONTANTREMUNERATIONCOMMERCIAL", SqlDbType.Money);
            vppParamLP_MONTANTREMUNERATIONCOMMERCIAL.Value = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTREMUNERATIONCOMMERCIAL;

            SqlParameter vppParamLP_VALEUR = new SqlParameter("@LP_VALEUR", SqlDbType.VarChar, 150);
			vppParamLP_VALEUR.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_VALEUR ;
			if(clsMicparametrelisteproduitsousproduitvaleur.LP_VALEUR== ""  ) vppParamLP_VALEUR.Value  = DBNull.Value;
            SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 150);
            vppParamTP_CODETYPETIERS.Value = clsMicparametrelisteproduitsousproduitvaleur.TP_CODETYPETIERS;
            if (clsMicparametrelisteproduitsousproduitvaleur.TP_CODETYPETIERS == "") vppParamTP_CODETYPETIERS.Value = DBNull.Value;

            SqlParameter vppParamFM_CODEFORMEJURIDIQUE = new SqlParameter("@FM_CODEFORMEJURIDIQUE", SqlDbType.VarChar, 150);
            vppParamFM_CODEFORMEJURIDIQUE.Value = clsMicparametrelisteproduitsousproduitvaleur.FM_CODEFORMEJURIDIQUE;
            if (clsMicparametrelisteproduitsousproduitvaleur.FM_CODEFORMEJURIDIQUE == "") vppParamFM_CODEFORMEJURIDIQUE.Value = DBNull.Value;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE1", SqlDbType.VarChar, 150);
            vppParamSX_CODESEXE.Value = clsMicparametrelisteproduitsousproduitvaleur.SX_CODESEXE;
            if (clsMicparametrelisteproduitsousproduitvaleur.SX_CODESEXE == "") vppParamSX_CODESEXE.Value = DBNull.Value;

            //SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 150);
            //vppParamTI_IDTIERS.Value = clsMicparametrelisteproduitsousproduitvaleur.TI_IDTIERS;
            //if (clsMicparametrelisteproduitsousproduitvaleur.TI_IDTIERS == "") vppParamTI_IDTIERS.Value = DBNull.Value;


            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsMicparametrelisteproduitsousproduitvaleur.TYPEOPERATION;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  @LP_CODEPARAMETRELISTEVALEUR1, @AP_CODEPRODUIT1, @PL_CODEPARAMETRELISTE1, @LP_BORNEMIN, @LP_BORNEMAX, @LP_MONTANTMINI1, @LP_MONTANTMAXI1, @LP_TAUX, @LP_MONTANT,@LP_TAUXREMUNERATIONCOMMERCIAL,@LP_MONTANTREMUNERATIONCOMMERCIAL, @LP_VALEUR,@TP_CODETYPETIERS,@FM_CODEFORMEJURIDIQUE, @SX_CODESEXE1,@TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLP_CODEPARAMETRELISTEVALEUR);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamPL_CODEPARAMETRELISTE);
			vppSqlCmd.Parameters.Add(vppParamLP_BORNEMIN);
			vppSqlCmd.Parameters.Add(vppParamLP_BORNEMAX);
			vppSqlCmd.Parameters.Add(vppParamLP_MONTANTMINI);
			vppSqlCmd.Parameters.Add(vppParamLP_MONTANTMAXI);
			vppSqlCmd.Parameters.Add(vppParamLP_TAUX);
			vppSqlCmd.Parameters.Add(vppParamLP_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamLP_TAUXREMUNERATIONCOMMERCIAL);
			vppSqlCmd.Parameters.Add(vppParamLP_MONTANTREMUNERATIONCOMMERCIAL);


			vppSqlCmd.Parameters.Add(vppParamLP_VALEUR);

            vppSqlCmd.Parameters.Add(vppParamFM_CODEFORMEJURIDIQUE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            //vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMicparametrelisteproduitsousproduitvaleur>clsMicparametrelisteproduitsousproduitvaleur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMicparametrelisteproduitsousproduitvaleur clsMicparametrelisteproduitsousproduitvaleur,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamLP_CODEPARAMETRELISTEVALEUR = new SqlParameter("@LP_CODEPARAMETRELISTEVALEUR", SqlDbType.BigInt);
			vppParamLP_CODEPARAMETRELISTEVALEUR.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_CODEPARAMETRELISTEVALEUR ;
			SqlParameter vppParamAP_CODEPRODUIT = new SqlParameter("@AP_CODEPRODUIT", SqlDbType.VarChar, 50);
			vppParamAP_CODEPRODUIT.Value  = clsMicparametrelisteproduitsousproduitvaleur.AP_CODEPRODUIT ;
			SqlParameter vppParamPL_CODEPARAMETRELISTE = new SqlParameter("@PL_CODEPARAMETRELISTE", SqlDbType.VarChar, 5);
			vppParamPL_CODEPARAMETRELISTE.Value  = clsMicparametrelisteproduitsousproduitvaleur.PL_CODEPARAMETRELISTE ;
			SqlParameter vppParamLP_BORNEMIN = new SqlParameter("@LP_BORNEMIN", SqlDbType.Decimal, 4);
			vppParamLP_BORNEMIN.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMIN ;
			SqlParameter vppParamLP_BORNEMAX = new SqlParameter("@LP_BORNEMAX", SqlDbType.Decimal, 4);
			vppParamLP_BORNEMAX.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMAX ;
			SqlParameter vppParamLP_MONTANTMINI = new SqlParameter("@LP_MONTANTMINI", SqlDbType.Decimal, 4);
			vppParamLP_MONTANTMINI.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMINI ;
			SqlParameter vppParamLP_MONTANTMAXI = new SqlParameter("@LP_MONTANTMAXI", SqlDbType.Decimal, 4);
			vppParamLP_MONTANTMAXI.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMAXI ;
			SqlParameter vppParamLP_TAUX = new SqlParameter("@LP_TAUX", SqlDbType.Decimal, 4);
			vppParamLP_TAUX.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_TAUX ;
			SqlParameter vppParamLP_MONTANT = new SqlParameter("@LP_MONTANT", SqlDbType.Decimal, 4);
			vppParamLP_MONTANT.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANT ;
			SqlParameter vppParamLP_VALEUR = new SqlParameter("@LP_VALEUR", SqlDbType.VarChar, 150);
			vppParamLP_VALEUR.Value  = clsMicparametrelisteproduitsousproduitvaleur.LP_VALEUR ;
			if(clsMicparametrelisteproduitsousproduitvaleur.LP_VALEUR== ""  ) vppParamLP_VALEUR.Value  = DBNull.Value;

            SqlParameter vppParamLP_TAUXREMUNERATIONCOMMERCIAL = new SqlParameter("@LP_TAUXREMUNERATIONCOMMERCIAL", SqlDbType.Decimal);
            vppParamLP_TAUXREMUNERATIONCOMMERCIAL.Value = clsMicparametrelisteproduitsousproduitvaleur.LP_TAUXREMUNERATIONCOMMERCIAL;
            SqlParameter vppParamLP_MONTANTREMUNERATIONCOMMERCIAL = new SqlParameter("@LP_MONTANTREMUNERATIONCOMMERCIAL", SqlDbType.Money);
            vppParamLP_MONTANTREMUNERATIONCOMMERCIAL.Value = clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTREMUNERATIONCOMMERCIAL;


            SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 150);
            vppParamTP_CODETYPETIERS.Value = clsMicparametrelisteproduitsousproduitvaleur.TP_CODETYPETIERS;
            if (clsMicparametrelisteproduitsousproduitvaleur.TP_CODETYPETIERS == "") vppParamTP_CODETYPETIERS.Value = DBNull.Value;

            SqlParameter vppParamFM_CODEFORMEJURIDIQUE = new SqlParameter("@FM_CODEFORMEJURIDIQUE", SqlDbType.VarChar, 150);
            vppParamFM_CODEFORMEJURIDIQUE.Value = clsMicparametrelisteproduitsousproduitvaleur.FM_CODEFORMEJURIDIQUE;
            if (clsMicparametrelisteproduitsousproduitvaleur.FM_CODEFORMEJURIDIQUE == "") vppParamFM_CODEFORMEJURIDIQUE.Value = DBNull.Value;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 150);
            vppParamSX_CODESEXE.Value = clsMicparametrelisteproduitsousproduitvaleur.SX_CODESEXE;
            if (clsMicparametrelisteproduitsousproduitvaleur.SX_CODESEXE == "") vppParamSX_CODESEXE.Value = DBNull.Value;

            //SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 150);
            //vppParamTI_IDTIERS.Value = clsMicparametrelisteproduitsousproduitvaleur.TI_IDTIERS;
            //if (clsMicparametrelisteproduitsousproduitvaleur.TI_IDTIERS == "") vppParamTI_IDTIERS.Value = DBNull.Value;

            //SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            //vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  @LP_CODEPARAMETRELISTEVALEUR, @AP_CODEPRODUIT, @PL_CODEPARAMETRELISTE, @LP_BORNEMIN, @LP_BORNEMAX, @LP_MONTANTMINI, @LP_MONTANTMAXI, @LP_TAUX, @LP_MONTANT,@LP_TAUXREMUNERATIONCOMMERCIAL,@LP_MONTANTREMUNERATIONCOMMERCIAL, @LP_VALEUR,@TP_CODETYPETIERS,@FM_CODEFORMEJURIDIQUE, @SX_CODESEXE,  1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLP_CODEPARAMETRELISTEVALEUR);
			vppSqlCmd.Parameters.Add(vppParamAP_CODEPRODUIT);
			vppSqlCmd.Parameters.Add(vppParamPL_CODEPARAMETRELISTE);
			vppSqlCmd.Parameters.Add(vppParamLP_BORNEMIN);
			vppSqlCmd.Parameters.Add(vppParamLP_BORNEMAX);
			vppSqlCmd.Parameters.Add(vppParamLP_MONTANTMINI);
			vppSqlCmd.Parameters.Add(vppParamLP_MONTANTMAXI);
			vppSqlCmd.Parameters.Add(vppParamLP_TAUX);
			vppSqlCmd.Parameters.Add(vppParamLP_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamLP_VALEUR);


            vppSqlCmd.Parameters.Add(vppParamLP_TAUXREMUNERATIONCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamLP_MONTANTREMUNERATIONCOMMERCIAL);

            vppSqlCmd.Parameters.Add(vppParamFM_CODEFORMEJURIDIQUE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            //vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  '', '' , '' , '' , '' , '' , '' , '' , '' , '' ,'', '' ,'','','','', 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDeleteParametrageModel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  '0', @AP_CODEPRODUIT, @PL_CODEPARAMETRELISTE, '0','0', @LP_MONTANTMINI, @LP_MONTANTMAXI, '0', '0', '0','0','0','','', '', 3  ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDeleteParametrageSpecifique(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  '0', @AP_CODEPRODUIT, @PL_CODEPARAMETRELISTE, '0','0', @LP_MONTANTMINI, @LP_MONTANTMAXI, '0', '0', '0','0','0','','',  @SX_CODESEXE, 4  ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDeleteParametrageSpecifiqueAdherant(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR  '0', @AP_CODEPRODUIT, @PL_CODEPARAMETRELISTE, '0','0', @LP_MONTANTMINI, @LP_MONTANTMAXI, '0', '0', '0','0','0','','',  @SX_CODESEXE, 6  ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicparametrelisteproduitsousproduitvaleur </returns>
		///<author>Home Technology</author>
		public List<clsMicparametrelisteproduitsousproduitvaleur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  LP_CODEPARAMETRELISTEVALEUR, AP_CODEPRODUIT, PL_CODEPARAMETRELISTE, LP_BORNEMIN, LP_BORNEMAX, LP_MONTANTMINI, LP_MONTANTMAXI, LP_TAUX, LP_MONTANT, LP_VALEUR FROM dbo.FT_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsMicparametrelisteproduitsousproduitvaleur> clsMicparametrelisteproduitsousproduitvaleurs = new List<clsMicparametrelisteproduitsousproduitvaleur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMicparametrelisteproduitsousproduitvaleur clsMicparametrelisteproduitsousproduitvaleur = new clsMicparametrelisteproduitsousproduitvaleur();
					clsMicparametrelisteproduitsousproduitvaleur.LP_CODEPARAMETRELISTEVALEUR = double.Parse(clsDonnee.vogDataReader["LP_CODEPARAMETRELISTEVALEUR"].ToString());
					clsMicparametrelisteproduitsousproduitvaleur.AP_CODEPRODUIT = clsDonnee.vogDataReader["AP_CODEPRODUIT"].ToString();
					clsMicparametrelisteproduitsousproduitvaleur.PL_CODEPARAMETRELISTE = clsDonnee.vogDataReader["PL_CODEPARAMETRELISTE"].ToString();
                    clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMIN = double.Parse(clsDonnee.vogDataReader["LP_BORNEMIN"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMAX = double.Parse(clsDonnee.vogDataReader["LP_BORNEMAX"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMINI = decimal.Parse(clsDonnee.vogDataReader["LP_MONTANTMINI"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMAXI = decimal.Parse(clsDonnee.vogDataReader["LP_MONTANTMAXI"].ToString());
					clsMicparametrelisteproduitsousproduitvaleur.LP_TAUX = decimal.Parse(clsDonnee.vogDataReader["LP_TAUX"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANT = decimal.Parse(clsDonnee.vogDataReader["LP_MONTANT"].ToString());
					clsMicparametrelisteproduitsousproduitvaleur.LP_VALEUR = clsDonnee.vogDataReader["LP_VALEUR"].ToString();
					clsMicparametrelisteproduitsousproduitvaleurs.Add(clsMicparametrelisteproduitsousproduitvaleur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsMicparametrelisteproduitsousproduitvaleurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMicparametrelisteproduitsousproduitvaleur </returns>
		///<author>Home Technology</author>
		public List<clsMicparametrelisteproduitsousproduitvaleur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsMicparametrelisteproduitsousproduitvaleur> clsMicparametrelisteproduitsousproduitvaleurs = new List<clsMicparametrelisteproduitsousproduitvaleur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  LP_CODEPARAMETRELISTEVALEUR, AP_CODEPRODUIT, PL_CODEPARAMETRELISTE, LP_BORNEMIN, LP_BORNEMAX, LP_MONTANTMINI, LP_MONTANTMAXI, LP_TAUX, LP_MONTANT, LP_VALEUR FROM dbo.FT_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsMicparametrelisteproduitsousproduitvaleur clsMicparametrelisteproduitsousproduitvaleur = new clsMicparametrelisteproduitsousproduitvaleur();
					clsMicparametrelisteproduitsousproduitvaleur.LP_CODEPARAMETRELISTEVALEUR = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LP_CODEPARAMETRELISTEVALEUR"].ToString());
					clsMicparametrelisteproduitsousproduitvaleur.AP_CODEPRODUIT = Dataset.Tables["TABLE"].Rows[Idx]["AP_CODEPRODUIT"].ToString();
					clsMicparametrelisteproduitsousproduitvaleur.PL_CODEPARAMETRELISTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODEPARAMETRELISTE"].ToString();
                    clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMIN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LP_BORNEMIN"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_BORNEMAX = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LP_BORNEMAX"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMINI = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LP_MONTANTMINI"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANTMAXI = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LP_MONTANTMAXI"].ToString());
					clsMicparametrelisteproduitsousproduitvaleur.LP_TAUX = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LP_TAUX"].ToString());
                    clsMicparametrelisteproduitsousproduitvaleur.LP_MONTANT = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LP_MONTANT"].ToString());
					clsMicparametrelisteproduitsousproduitvaleur.LP_VALEUR = Dataset.Tables["TABLE"].Rows[Idx]["LP_VALEUR"].ToString();
					clsMicparametrelisteproduitsousproduitvaleurs.Add(clsMicparametrelisteproduitsousproduitvaleur);
				}
				Dataset.Dispose();
			}
		return clsMicparametrelisteproduitsousproduitvaleurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere3(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetParametrage(clsDonnee clsDonnee, params string[] vppCritere)
        {
           // pvpChoixCritere2(clsDonnee, vppCritere);

            this.vapCritere = "WHERE PS_CODESOUSPRODUIT=@PS_CODESOUSPRODUIT AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE AND LP_MONTANTMINI=@LP_MONTANTMINI AND LP_MONTANTMAXI=@LP_MONTANTMAXI AND SX_CODESEXE=@SX_CODESEXE ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@PS_CODESOUSPRODUIT", "@PL_CODEPARAMETRELISTE", "@LP_MONTANTMINI", "@LP_MONTANTMAXI", "@SX_CODESEXE",  "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };

            this.vapRequete = "SELECT *  FROM dbo.FT_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR(@PS_CODESOUSPRODUIT,@PL_CODEPARAMETRELISTE,@LP_MONTANTMINI,@LP_MONTANTMAXI,@SX_CODESEXE,@TYPEOPERATION, @CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT LP_CODEPARAMETRELISTEVALEUR , AP_CODEPRODUIT FROM dbo.FT_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LP_CODEPARAMETRELISTEVALEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboMontantMinMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(clsDonnee, vppCritere);
            this.vapRequete = "SELECT DISTINCT LP_LIBELLEPLAGE , LP_LIBELLEPLAGE FROM dbo.FT_MICPARAMETRELISTEPRODUITSOUSPRODUITVALEUR(@PS_CODESOUSPRODUIT,@PL_CODEPARAMETRELISTE,@LP_MONTANTMINI,@LP_MONTANTMAXI,@SX_CODESEXE,@TYPEOPERATION, @CODECRYPTAGE) ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        



		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LP_CODEPARAMETRELISTEVALEUR)</summary>
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
				this.vapCritere ="WHERE LP_CODEPARAMETRELISTEVALEUR=@LP_CODEPARAMETRELISTEVALEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@LP_CODEPARAMETRELISTEVALEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LP_CODEPARAMETRELISTEVALEUR)</summary>
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
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

                case 2:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PL_CODEPARAMETRELISTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE AND LP_MONTANTMINI=@LP_MONTANTMINI";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PL_CODEPARAMETRELISTE", "@LP_MONTANTMINI" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE AND LP_MONTANTMINI=@LP_MONTANTMINI AND LP_MONTANTMAXI=@LP_MONTANTMAXI";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PL_CODEPARAMETRELISTE", "@LP_MONTANTMINI","@LP_MONTANTMAXI" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

                     case 5:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE AND LP_MONTANTMINI=@LP_MONTANTMINI AND LP_MONTANTMAXI=@LP_MONTANTMAXI AND SX_CODESEXE=@SX_CODESEXE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PL_CODEPARAMETRELISTE", "@LP_MONTANTMINI","@LP_MONTANTMAXI","@SX_CODESEXE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;

                    case 6:
                    this.vapCritere = "WHERE PS_CODESOUSPRODUIT=@PS_CODESOUSPRODUIT AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE AND LP_MONTANTMINI=@LP_MONTANTMINI AND LP_MONTANTMAXI=@LP_MONTANTMAXI AND SX_CODESEXE=@SX_CODESEXE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@PS_CODESOUSPRODUIT", "@PL_CODEPARAMETRELISTE", "@LP_MONTANTMINI","@LP_MONTANTMAXI","@SX_CODESEXE", "@TYPEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] , vppCritere[5] };
                    break;
                    case 7:
                    this.vapCritere = "WHERE PS_CODESOUSPRODUIT=@PS_CODESOUSPRODUIT AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE AND LP_MONTANTMINI=@LP_MONTANTMINI AND LP_MONTANTMAXI=@LP_MONTANTMAXI AND SX_CODESEXE=@SX_CODESEXE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@PS_CODESOUSPRODUIT", "@PL_CODEPARAMETRELISTE", "@LP_MONTANTMINI","@LP_MONTANTMAXI","@SX_CODESEXE",  "@TYPEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] , vppCritere[5]};
                    break;

            }



        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LP_CODEPARAMETRELISTEVALEUR)</summary>
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
                    this.vapCritere = "WHERE SX_CODESEXE=@SX_CODESEXE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@SX_CODESEXE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

                case 3:
                    this.vapCritere = "WHERE AP_CODEPRODUIT=@AP_CODEPRODUIT AND PL_CODEPARAMETRELISTE=@PL_CODEPARAMETRELISTE AND SX_CODESEXE=@SX_CODESEXE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AP_CODEPRODUIT", "@PL_CODEPARAMETRELISTE", "@SX_CODESEXE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }



       


	}
}
