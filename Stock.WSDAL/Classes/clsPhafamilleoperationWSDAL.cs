using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhafamilleoperationWSDAL: ITableDAL<clsPhafamilleoperation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(FO_CODEFAMILLEOPERATION) AS FO_CODEFAMILLEOPERATION  FROM dbo.FT_PHAFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(FO_CODEFAMILLEOPERATION) AS FO_CODEFAMILLEOPERATION  FROM dbo.FT_PHAFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(FO_CODEFAMILLEOPERATION) AS FO_CODEFAMILLEOPERATION  FROM dbo.FT_PHAFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhafamilleoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhafamilleoperation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT FO_LIBELLEFAMILLEOPERATION  , FO_NUMEROORDRE  , FO_STATUT  FROM dbo.FT_PHAFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhafamilleoperation clsPhafamilleoperation = new clsPhafamilleoperation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_LIBELLEFAMILLEOPERATION"].ToString();
					clsPhafamilleoperation.FO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["FO_NUMEROORDRE"].ToString());
					clsPhafamilleoperation.FO_STATUT = clsDonnee.vogDataReader["FO_STATUT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhafamilleoperation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhafamilleoperation>clsPhafamilleoperation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhafamilleoperation clsPhafamilleoperation)
		{
			//Préparation des paramètres
			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION1", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsPhafamilleoperation.FO_CODEFAMILLEOPERATION ;
			SqlParameter vppParamFO_LIBELLEFAMILLEOPERATION = new SqlParameter("@FO_LIBELLEFAMILLEOPERATION", SqlDbType.VarChar, 150);
			vppParamFO_LIBELLEFAMILLEOPERATION.Value  = clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION ;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 150);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsPhafamilleoperation.NF_CODENATUREFAMILLEOPERATION;

			SqlParameter vppParamFO_NUMEROORDRE = new SqlParameter("@FO_NUMEROORDRE", SqlDbType.Int);
			vppParamFO_NUMEROORDRE.Value  = clsPhafamilleoperation.FO_NUMEROORDRE ;
			SqlParameter vppParamFO_STATUT = new SqlParameter("@FO_STATUT", SqlDbType.VarChar, 1);
			vppParamFO_STATUT.Value  = clsPhafamilleoperation.FO_STATUT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAFAMILLEOPERATION  @FO_CODEFAMILLEOPERATION1, @FO_LIBELLEFAMILLEOPERATION, @NF_CODENATUREFAMILLEOPERATION, @FO_NUMEROORDRE, @FO_STATUT, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamFO_LIBELLEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamFO_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamFO_STATUT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhafamilleoperation>clsPhafamilleoperation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhafamilleoperation clsPhafamilleoperation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsPhafamilleoperation.FO_CODEFAMILLEOPERATION ;
			SqlParameter vppParamFO_LIBELLEFAMILLEOPERATION = new SqlParameter("@FO_LIBELLEFAMILLEOPERATION", SqlDbType.VarChar, 150);
			vppParamFO_LIBELLEFAMILLEOPERATION.Value  = clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION ;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 150);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value  = clsPhafamilleoperation.NF_CODENATUREFAMILLEOPERATION;

			SqlParameter vppParamFO_NUMEROORDRE = new SqlParameter("@FO_NUMEROORDRE", SqlDbType.Int);
			vppParamFO_NUMEROORDRE.Value  = clsPhafamilleoperation.FO_NUMEROORDRE ;
			SqlParameter vppParamFO_STATUT = new SqlParameter("@FO_STATUT", SqlDbType.VarChar, 1);
			vppParamFO_STATUT.Value  = clsPhafamilleoperation.FO_STATUT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAFAMILLEOPERATION  @FO_CODEFAMILLEOPERATION, @FO_LIBELLEFAMILLEOPERATION, @NF_CODENATUREFAMILLEOPERATION, @FO_NUMEROORDRE, @FO_STATUT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamFO_LIBELLEFAMILLEOPERATION);
             vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);

			vppSqlCmd.Parameters.Add(vppParamFO_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamFO_STATUT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAFAMILLEOPERATION  @FO_CODEFAMILLEOPERATION, '' , '' ,'' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhafamilleoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhafamilleoperation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  FO_CODEFAMILLEOPERATION, FO_LIBELLEFAMILLEOPERATION, FO_NUMEROORDRE, FO_STATUT FROM dbo.FT_PHAFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhafamilleoperation> clsPhafamilleoperations = new List<clsPhafamilleoperation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhafamilleoperation clsPhafamilleoperation = new clsPhafamilleoperation();
					clsPhafamilleoperation.FO_CODEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_CODEFAMILLEOPERATION"].ToString();
					clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_LIBELLEFAMILLEOPERATION"].ToString();
					clsPhafamilleoperation.FO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["FO_NUMEROORDRE"].ToString());
					clsPhafamilleoperation.FO_STATUT = clsDonnee.vogDataReader["FO_STATUT"].ToString();
					clsPhafamilleoperations.Add(clsPhafamilleoperation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhafamilleoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhafamilleoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhafamilleoperation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhafamilleoperation> clsPhafamilleoperations = new List<clsPhafamilleoperation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  FO_CODEFAMILLEOPERATION, FO_LIBELLEFAMILLEOPERATION, FO_NUMEROORDRE, FO_STATUT FROM dbo.FT_PHAFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhafamilleoperation clsPhafamilleoperation = new clsPhafamilleoperation();
					clsPhafamilleoperation.FO_CODEFAMILLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFAMILLEOPERATION"].ToString();
					clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["FO_LIBELLEFAMILLEOPERATION"].ToString();
					clsPhafamilleoperation.FO_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["FO_NUMEROORDRE"].ToString());
					clsPhafamilleoperation.FO_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["FO_STATUT"].ToString();
					clsPhafamilleoperations.Add(clsPhafamilleoperation);
				}
				Dataset.Dispose();
			}
		return clsPhafamilleoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere(clsDonnee ,vppCritere);
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { vppCritere[0],vppCritere[1],vppCritere[2] };
            this.vapRequete = "EXEC [dbo].[PS_FAMILLEOPERATION] @AG_CODEAGENCE,@NF_CODENATUREFAMILLEOPERATION,@OP_CODEOPERATEUR ";// +this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetFamilleOperation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT FO_CODEFAMILLEOPERATION , FO_LIBELLEFAMILLEOPERATION FROM dbo.FT_PHAFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere + " AND FO_STATUT='O' ORDER BY FO_NUMEROORDRE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);
            //vapNomParametre = new string[] { "@AG_CODEAGENCE", "@NF_CODENATUREFAMILLEOPERATION", "@OP_CODEOPERATEUR" };
            //vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = "SELECT * FROM dbo.PHAFAMILLEOPERATION WHERE FO_STATUT='O' ORDER BY FO_NUMEROORDRE ";// +this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : FO_CODEFAMILLEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT FO_CODEFAMILLEOPERATION , FO_LIBELLEFAMILLEOPERATION FROM dbo.FT_PHAFAMILLEOPERATION(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY FO_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :FO_CODEFAMILLEOPERATION)</summary>
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
				this.vapCritere = "WHERE NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@NF_CODENATUREFAMILLEOPERATION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

                case 2:
                this.vapCritere = "WHERE  NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION AND   FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION";
                vapNomParametre = new string[]{"@CODECRYPTAGE", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION"};
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
                break;

			}
		}

            ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :FO_CODEFAMILLEOPERATION)</summary>
            ///<param name="clsDonnee"> clsDonnee</param>
            ///<param name="vppCritere">Les critères de la requète</param>
            ///<author>Home Technologie</author>
            public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
            {
	            switch (vppCritere.Length) 
		            {
		            case 0 :
		            this.vapCritere ="";
		            vapNomParametre = new string[]{"@CODECRYPTAGE"};
		            vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
		            break;
		            case 1 :
		            this.vapCritere = "WHERE FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION";
		            vapNomParametre = new string[]{"@CODECRYPTAGE", "@FO_CODEFAMILLEOPERATION" };
		            vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
		            break;

                    case 2:
                    this.vapCritere = "WHERE  NF_CODENATUREFAMILLEOPERATION=@NF_CODENATUREFAMILLEOPERATION AND   FO_CODEFAMILLEOPERATION=@FO_CODEFAMILLEOPERATION";
                    vapNomParametre = new string[]{"@CODECRYPTAGE", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION"};
                    vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
                    break;

	            }
            }

	}
}
