using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparsectiontiersWSDAL: ITableDAL<clsPhaparsectiontiers>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(SC_CODESECTION) AS SC_CODESECTION  FROM dbo.PHARPARSECTIONTIERS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(SC_CODESECTION) AS SC_CODESECTION  FROM dbo.PHARPARSECTIONTIERS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(SC_CODESECTION) AS SC_CODESECTION  FROM dbo.PHARPARSECTIONTIERS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparsectiontiers comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparsectiontiers pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT ST_DATESAISIE  , ST_DATEDEPART  FROM dbo.FT_PHARPARSECTIONTIERS(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparsectiontiers clsPhaparsectiontiers = new clsPhaparsectiontiers();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparsectiontiers.ST_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["ST_DATESAISIE"].ToString());
					clsPhaparsectiontiers.ST_DATEDEPART = DateTime.Parse(clsDonnee.vogDataReader["ST_DATEDEPART"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparsectiontiers;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparsectiontiers>clsPhaparsectiontiers</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparsectiontiers clsPhaparsectiontiers)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 1000);
            vppParamAG_CODEAGENCE.Value = clsPhaparsectiontiers.AG_CODEAGENCE;

			SqlParameter vppParamSC_CODESECTION = new SqlParameter("@SC_CODESECTION", SqlDbType.VarChar, 4);
			vppParamSC_CODESECTION.Value  = clsPhaparsectiontiers.SC_CODESECTION ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS1", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERS.Value  = clsPhaparsectiontiers.TI_IDTIERS ;
			SqlParameter vppParamST_DATESAISIE = new SqlParameter("@ST_DATESAISIE", SqlDbType.DateTime);
			vppParamST_DATESAISIE.Value  = clsPhaparsectiontiers.ST_DATESAISIE ;
            if (clsPhaparsectiontiers.ST_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamST_DATESAISIE.Value = DateTime.Parse("01/01/1900");
			SqlParameter vppParamST_DATEDEPART = new SqlParameter("@ST_DATEDEPART", SqlDbType.DateTime);
			vppParamST_DATEDEPART.Value  = clsPhaparsectiontiers.ST_DATEDEPART ;
            if (clsPhaparsectiontiers.ST_DATEDEPART < DateTime.Parse("01/01/1900")) vppParamST_DATEDEPART.Value = DateTime.Parse("01/01/1900");

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparsectiontiers.OP_CODEOPERATEUR;


			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHARPARSECTIONTIERS  @AG_CODEAGENCE1,@SC_CODESECTION, @TI_IDTIERS1, @ST_DATESAISIE, @ST_DATEDEPART,@OP_CODEOPERATEUR, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSC_CODESECTION);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamST_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamST_DATEDEPART);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);

			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparsectiontiers>clsPhaparsectiontiers</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparsectiontiers clsPhaparsectiontiers,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 1000);
            vppParamAG_CODEAGENCE.Value = clsPhaparsectiontiers.AG_CODEAGENCE;
			SqlParameter vppParamSC_CODESECTION = new SqlParameter("@SC_CODESECTION", SqlDbType.VarChar, 4);
			vppParamSC_CODESECTION.Value  = clsPhaparsectiontiers.SC_CODESECTION ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
			vppParamTI_IDTIERS.Value  = clsPhaparsectiontiers.TI_IDTIERS ;
			SqlParameter vppParamST_DATESAISIE = new SqlParameter("@ST_DATESAISIE", SqlDbType.DateTime);
			vppParamST_DATESAISIE.Value  = clsPhaparsectiontiers.ST_DATESAISIE ;
			SqlParameter vppParamST_DATEDEPART = new SqlParameter("@ST_DATEDEPART", SqlDbType.DateTime);
			vppParamST_DATEDEPART.Value  = clsPhaparsectiontiers.ST_DATEDEPART ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparsectiontiers.OP_CODEOPERATEUR;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHARPARSECTIONTIERS  @AG_CODEAGENCE,@SC_CODESECTION, @TI_IDTIERS, @ST_DATESAISIE, @ST_DATEDEPART, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSC_CODESECTION);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamST_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamST_DATEDEPART);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHARPARSECTIONTIERS  @AG_CODEAGENCE,'', @TI_IDTIERS, '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparsectiontiers </returns>
		///<author>Home Technology</author>
		public List<clsPhaparsectiontiers> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  SC_CODESECTION, TI_IDTIERS, ST_DATESAISIE, ST_DATEDEPART FROM dbo.FT_PHARPARSECTIONTIERS(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparsectiontiers> clsPhaparsectiontierss = new List<clsPhaparsectiontiers>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparsectiontiers clsPhaparsectiontiers = new clsPhaparsectiontiers();
					clsPhaparsectiontiers.SC_CODESECTION = clsDonnee.vogDataReader["SC_CODESECTION"].ToString();
					clsPhaparsectiontiers.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhaparsectiontiers.ST_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["ST_DATESAISIE"].ToString());
					clsPhaparsectiontiers.ST_DATEDEPART = DateTime.Parse(clsDonnee.vogDataReader["ST_DATEDEPART"].ToString());
					clsPhaparsectiontierss.Add(clsPhaparsectiontiers);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparsectiontierss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparsectiontiers </returns>
		///<author>Home Technology</author>
		public List<clsPhaparsectiontiers> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparsectiontiers> clsPhaparsectiontierss = new List<clsPhaparsectiontiers>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  SC_CODESECTION, TI_IDTIERS, ST_DATESAISIE, ST_DATEDEPART FROM dbo.FT_PHARPARSECTIONTIERS(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparsectiontiers clsPhaparsectiontiers = new clsPhaparsectiontiers();
					clsPhaparsectiontiers.SC_CODESECTION = Dataset.Tables["TABLE"].Rows[Idx]["SC_CODESECTION"].ToString();
					clsPhaparsectiontiers.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsPhaparsectiontiers.ST_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ST_DATESAISIE"].ToString());
					clsPhaparsectiontiers.ST_DATEDEPART = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ST_DATEDEPART"].ToString());
					clsPhaparsectiontierss.Add(clsPhaparsectiontiers);
				}
				Dataset.Dispose();
			}
		return clsPhaparsectiontierss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHARPARSECTIONTIERS(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetSectionTiers(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHARPARSECTIONTIERS1(@AG_CODEAGENCE,@TI_IDTIERS,@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SC_CODESECTION, TI_IDTIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT SC_CODESECTION , ST_DATESAISIE FROM dbo.FT_PHARPARSECTIONTIERS(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SC_CODESECTION, TI_IDTIERS)</summary>
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
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

				case 2 :
                this.vapCritere = "WHERE  AG_CODEAGENCE=@AG_CODEAGENCE   AND  TI_IDTIERS=@TI_IDTIERS";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDTIERS" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND     SC_CODESECTION=@SC_CODESECTION AND TI_IDTIERS=@TI_IDTIERS";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SC_CODESECTION", "@TI_IDTIERS" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SC_CODESECTION, TI_IDTIERS)</summary>
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
                case 2:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDTIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] , vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE SC_CODESECTION=@SC_CODESECTION AND TI_IDTIERS=@TI_IDTIERS";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SC_CODESECTION", "@TI_IDTIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] , vppCritere[2] };
                    break;
            }
        }
	}
}
