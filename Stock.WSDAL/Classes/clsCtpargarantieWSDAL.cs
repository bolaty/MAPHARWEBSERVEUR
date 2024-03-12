using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpargarantieWSDAL: ITableDAL<clsCtpargarantie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(GA_CODEGARANTIE) AS GA_CODEGARANTIE  FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(GA_CODEGARANTIE) AS GA_CODEGARANTIE  FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(GA_CODEGARANTIE) AS GA_CODEGARANTIE  FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpargarantie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpargarantie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TG_CODETYPEGARANTIE  , SC_CODESOUSCATEGORIE  , GA_LIBELLEGARANTIE  , GA_ACTIF  , GA_NUMEROORDRE  FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpargarantie clsCtpargarantie = new clsCtpargarantie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpargarantie.TG_CODETYPEGARANTIE = clsDonnee.vogDataReader["TG_CODETYPEGARANTIE"].ToString();
					clsCtpargarantie.SC_CODESOUSCATEGORIE = clsDonnee.vogDataReader["SC_CODESOUSCATEGORIE"].ToString();
					clsCtpargarantie.GA_LIBELLEGARANTIE = clsDonnee.vogDataReader["GA_LIBELLEGARANTIE"].ToString();
					clsCtpargarantie.GA_ACTIF = clsDonnee.vogDataReader["GA_ACTIF"].ToString();
					clsCtpargarantie.GA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["GA_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpargarantie;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsCtpargarantie comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsCtpargarantie pvgTableLabelParDefaut(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //this.vapCritere = "WHERE GA_GARANTIEPARDEFAUT=@GA_GARANTIEPARDEFAUT";
            //vapNomParametre = new string[] { "@GA_GARANTIEPARDEFAUT" };
            //vapValeurParametre = new object[] { vppCritere[0] };
            this.vapRequete = "SELECT GA_CODEGARANTIE,TG_CODETYPEGARANTIE  , SC_CODESOUSCATEGORIE  , GA_LIBELLEGARANTIE  , GA_ACTIF  , GA_NUMEROORDRE  FROM dbo.CTPARGARANTIE WHERE GA_GARANTIEPARDEFAUT='O' ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsCtpargarantie clsCtpargarantie = new clsCtpargarantie();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsCtpargarantie.GA_CODEGARANTIE = clsDonnee.vogDataReader["GA_CODEGARANTIE"].ToString();
                    clsCtpargarantie.TG_CODETYPEGARANTIE = clsDonnee.vogDataReader["TG_CODETYPEGARANTIE"].ToString();
                    clsCtpargarantie.SC_CODESOUSCATEGORIE = clsDonnee.vogDataReader["SC_CODESOUSCATEGORIE"].ToString();
                    clsCtpargarantie.GA_LIBELLEGARANTIE = clsDonnee.vogDataReader["GA_LIBELLEGARANTIE"].ToString();
                    clsCtpargarantie.GA_ACTIF = clsDonnee.vogDataReader["GA_ACTIF"].ToString();
                    clsCtpargarantie.GA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["GA_NUMEROORDRE"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsCtpargarantie;
        }



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsCtpargarantie>clsCtpargarantie</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsCtpargarantie clsCtpargarantie)
		{
			//Préparation des paramètres
			SqlParameter vppParamGA_CODEGARANTIE = new SqlParameter("@GA_CODEGARANTIE", SqlDbType.VarChar, 5);
			vppParamGA_CODEGARANTIE.Value  = clsCtpargarantie.GA_CODEGARANTIE ;
			SqlParameter vppParamTG_CODETYPEGARANTIE = new SqlParameter("@TG_CODETYPEGARANTIE", SqlDbType.VarChar, 2);
			vppParamTG_CODETYPEGARANTIE.Value  = clsCtpargarantie.TG_CODETYPEGARANTIE ;
			SqlParameter vppParamSC_CODESOUSCATEGORIE = new SqlParameter("@SC_CODESOUSCATEGORIE", SqlDbType.VarChar, 2);
			vppParamSC_CODESOUSCATEGORIE.Value  = clsCtpargarantie.SC_CODESOUSCATEGORIE ;
			if(clsCtpargarantie.SC_CODESOUSCATEGORIE== ""  ) vppParamSC_CODESOUSCATEGORIE.Value  = DBNull.Value;
			SqlParameter vppParamGA_LIBELLEGARANTIE = new SqlParameter("@GA_LIBELLEGARANTIE", SqlDbType.VarChar, 150);
			vppParamGA_LIBELLEGARANTIE.Value  = clsCtpargarantie.GA_LIBELLEGARANTIE ;
			SqlParameter vppParamGA_ACTIF = new SqlParameter("@GA_ACTIF", SqlDbType.VarChar, 1);
			vppParamGA_ACTIF.Value  = clsCtpargarantie.GA_ACTIF ;
			SqlParameter vppParamGA_NUMEROORDRE = new SqlParameter("@GA_NUMEROORDRE", SqlDbType.Int);
			vppParamGA_NUMEROORDRE.Value  = clsCtpargarantie.GA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGARANTIE  @GA_CODEGARANTIE, @TG_CODETYPEGARANTIE, @SC_CODESOUSCATEGORIE, @GA_LIBELLEGARANTIE, @GA_ACTIF, @GA_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamGA_CODEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamTG_CODETYPEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamSC_CODESOUSCATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamGA_LIBELLEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamGA_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamGA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpargarantie>clsCtpargarantie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpargarantie clsCtpargarantie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamGA_CODEGARANTIE = new SqlParameter("@GA_CODEGARANTIE", SqlDbType.VarChar, 5);
			vppParamGA_CODEGARANTIE.Value  = clsCtpargarantie.GA_CODEGARANTIE ;
			SqlParameter vppParamTG_CODETYPEGARANTIE = new SqlParameter("@TG_CODETYPEGARANTIE", SqlDbType.VarChar, 2);
			vppParamTG_CODETYPEGARANTIE.Value  = clsCtpargarantie.TG_CODETYPEGARANTIE ;
			SqlParameter vppParamSC_CODESOUSCATEGORIE = new SqlParameter("@SC_CODESOUSCATEGORIE", SqlDbType.VarChar, 2);
			vppParamSC_CODESOUSCATEGORIE.Value  = clsCtpargarantie.SC_CODESOUSCATEGORIE ;
			if(clsCtpargarantie.SC_CODESOUSCATEGORIE== ""  ) vppParamSC_CODESOUSCATEGORIE.Value  = DBNull.Value;
			SqlParameter vppParamGA_LIBELLEGARANTIE = new SqlParameter("@GA_LIBELLEGARANTIE", SqlDbType.VarChar, 150);
			vppParamGA_LIBELLEGARANTIE.Value  = clsCtpargarantie.GA_LIBELLEGARANTIE ;
			SqlParameter vppParamGA_ACTIF = new SqlParameter("@GA_ACTIF", SqlDbType.VarChar, 1);
			vppParamGA_ACTIF.Value  = clsCtpargarantie.GA_ACTIF ;
			SqlParameter vppParamGA_NUMEROORDRE = new SqlParameter("@GA_NUMEROORDRE", SqlDbType.Int);
			vppParamGA_NUMEROORDRE.Value  = clsCtpargarantie.GA_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGARANTIE  @GA_CODEGARANTIE, @TG_CODETYPEGARANTIE, @SC_CODESOUSCATEGORIE, @GA_LIBELLEGARANTIE, @GA_ACTIF, @GA_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamGA_CODEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamTG_CODETYPEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamSC_CODESOUSCATEGORIE);
			vppSqlCmd.Parameters.Add(vppParamGA_LIBELLEGARANTIE);
			vppSqlCmd.Parameters.Add(vppParamGA_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamGA_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARGARANTIE  @GA_CODEGARANTIE, @TG_CODETYPEGARANTIE, @SC_CODESOUSCATEGORIE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpargarantie </returns>
		///<author>Home Technology</author>
		public List<clsCtpargarantie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE, GA_LIBELLEGARANTIE, GA_ACTIF, GA_NUMEROORDRE FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpargarantie> clsCtpargaranties = new List<clsCtpargarantie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpargarantie clsCtpargarantie = new clsCtpargarantie();
					clsCtpargarantie.GA_CODEGARANTIE = clsDonnee.vogDataReader["GA_CODEGARANTIE"].ToString();
					clsCtpargarantie.TG_CODETYPEGARANTIE = clsDonnee.vogDataReader["TG_CODETYPEGARANTIE"].ToString();
					clsCtpargarantie.SC_CODESOUSCATEGORIE = clsDonnee.vogDataReader["SC_CODESOUSCATEGORIE"].ToString();
					clsCtpargarantie.GA_LIBELLEGARANTIE = clsDonnee.vogDataReader["GA_LIBELLEGARANTIE"].ToString();
					clsCtpargarantie.GA_ACTIF = clsDonnee.vogDataReader["GA_ACTIF"].ToString();
					clsCtpargarantie.GA_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["GA_NUMEROORDRE"].ToString());
					clsCtpargaranties.Add(clsCtpargarantie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpargaranties;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpargarantie </returns>
		///<author>Home Technology</author>
		public List<clsCtpargarantie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpargarantie> clsCtpargaranties = new List<clsCtpargarantie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE, GA_LIBELLEGARANTIE, GA_ACTIF, GA_NUMEROORDRE FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpargarantie clsCtpargarantie = new clsCtpargarantie();
					clsCtpargarantie.GA_CODEGARANTIE = Dataset.Tables["TABLE"].Rows[Idx]["GA_CODEGARANTIE"].ToString();
					clsCtpargarantie.TG_CODETYPEGARANTIE = Dataset.Tables["TABLE"].Rows[Idx]["TG_CODETYPEGARANTIE"].ToString();
					clsCtpargarantie.SC_CODESOUSCATEGORIE = Dataset.Tables["TABLE"].Rows[Idx]["SC_CODESOUSCATEGORIE"].ToString();
					clsCtpargarantie.GA_LIBELLEGARANTIE = Dataset.Tables["TABLE"].Rows[Idx]["GA_LIBELLEGARANTIE"].ToString();
					clsCtpargarantie.GA_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["GA_ACTIF"].ToString();
					clsCtpargarantie.GA_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["GA_NUMEROORDRE"].ToString());
					clsCtpargaranties.Add(clsCtpargarantie);
				}
				Dataset.Dispose();
			}
		return clsCtpargaranties;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT GA_CODEGARANTIE , GA_LIBELLEGARANTIE FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetParDefaut(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE GA_GARANTIEPARDEFAUT=@GA_GARANTIEPARDEFAUT";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@GA_GARANTIEPARDEFAUT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
            this.vapRequete = "SELECT GA_CODEGARANTIE , GA_LIBELLEGARANTIE FROM dbo.FT_CTPARGARANTIE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :GA_CODEGARANTIE, TG_CODETYPEGARANTIE, SC_CODESOUSCATEGORIE)</summary>
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
				this.vapCritere ="WHERE GA_CODEGARANTIE=@GA_CODEGARANTIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@GA_CODEGARANTIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE GA_CODEGARANTIE=@GA_CODEGARANTIE AND TG_CODETYPEGARANTIE=@TG_CODETYPEGARANTIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@GA_CODEGARANTIE","@TG_CODETYPEGARANTIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE GA_CODEGARANTIE=@GA_CODEGARANTIE AND TG_CODETYPEGARANTIE=@TG_CODETYPEGARANTIE AND SC_CODESOUSCATEGORIE=@SC_CODESOUSCATEGORIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@GA_CODEGARANTIE","@TG_CODETYPEGARANTIE","@SC_CODESOUSCATEGORIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
