using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypearticleoperationparametreWSDAL: ITableDAL<clsPhapartypearticleoperationparametre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TO_CODEOPERATIONPARAMETRE) AS TO_CODEOPERATIONPARAMETRE  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TO_CODEOPERATIONPARAMETRE) AS TO_CODEOPERATIONPARAMETRE  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TO_CODEOPERATIONPARAMETRE) AS TO_CODEOPERATIONPARAMETRE  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypearticleoperationparametre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypearticleoperationparametre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TO_CODEOPERATION  , CP_CODEOPERATIONLIBELLECPTE  FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new clsPhapartypearticleoperationparametre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticleoperationparametre.TO_CODEOPERATION = clsDonnee.vogDataReader["TO_CODEOPERATION"].ToString();
					clsPhapartypearticleoperationparametre.CP_CODEOPERATIONLIBELLECPTE = clsDonnee.vogDataReader["CP_CODEOPERATIONLIBELLECPTE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypearticleoperationparametre;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticleoperationparametre>clsPhapartypearticleoperationparametre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre)
		{
			//Préparation des paramètres
			SqlParameter vppParamTO_CODEOPERATIONPARAMETRE = new SqlParameter("@TO_CODEOPERATIONPARAMETRE", SqlDbType.VarChar, 4);
			vppParamTO_CODEOPERATIONPARAMETRE.Value  = clsPhapartypearticleoperationparametre.TO_CODEOPERATIONPARAMETRE ;
			SqlParameter vppParamTO_CODEOPERATION = new SqlParameter("@TO_CODEOPERATION", SqlDbType.VarChar, 2);
			vppParamTO_CODEOPERATION.Value  = clsPhapartypearticleoperationparametre.TO_CODEOPERATION ;
			SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 3);
			vppParamCP_CODEOPERATIONLIBELLECPTE.Value  = clsPhapartypearticleoperationparametre.CP_CODEOPERATIONLIBELLECPTE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLEOPERATIONPARAMETRE  @TO_CODEOPERATIONPARAMETRE, @TO_CODEOPERATION, @CP_CODEOPERATIONLIBELLECPTE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATIONPARAMETRE);
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypearticleoperationparametre>clsPhapartypearticleoperationparametre</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTO_CODEOPERATIONPARAMETRE = new SqlParameter("@TO_CODEOPERATIONPARAMETRE", SqlDbType.VarChar, 4);
			vppParamTO_CODEOPERATIONPARAMETRE.Value  = clsPhapartypearticleoperationparametre.TO_CODEOPERATIONPARAMETRE ;
			SqlParameter vppParamTO_CODEOPERATION = new SqlParameter("@TO_CODEOPERATION", SqlDbType.VarChar, 2);
			vppParamTO_CODEOPERATION.Value  = clsPhapartypearticleoperationparametre.TO_CODEOPERATION ;
			SqlParameter vppParamCP_CODEOPERATIONLIBELLECPTE = new SqlParameter("@CP_CODEOPERATIONLIBELLECPTE", SqlDbType.VarChar, 3);
			vppParamCP_CODEOPERATIONLIBELLECPTE.Value  = clsPhapartypearticleoperationparametre.CP_CODEOPERATIONLIBELLECPTE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLEOPERATIONPARAMETRE  @TO_CODEOPERATIONPARAMETRE, @TO_CODEOPERATION, @CP_CODEOPERATIONLIBELLECPTE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATIONPARAMETRE);
			vppSqlCmd.Parameters.Add(vppParamTO_CODEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamCP_CODEOPERATIONLIBELLECPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPEARTICLEOPERATIONPARAMETRE  @TO_CODEOPERATIONPARAMETRE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticleoperationparametre </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticleoperationparametre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TO_CODEOPERATIONPARAMETRE, TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<clsPhapartypearticleoperationparametre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new clsPhapartypearticleoperationparametre();
					clsPhapartypearticleoperationparametre.TO_CODEOPERATIONPARAMETRE = clsDonnee.vogDataReader["TO_CODEOPERATIONPARAMETRE"].ToString();
					clsPhapartypearticleoperationparametre.TO_CODEOPERATION = clsDonnee.vogDataReader["TO_CODEOPERATION"].ToString();
					clsPhapartypearticleoperationparametre.CP_CODEOPERATIONLIBELLECPTE = clsDonnee.vogDataReader["CP_CODEOPERATIONLIBELLECPTE"].ToString();
					clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypearticleoperationparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypearticleoperationparametre </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypearticleoperationparametre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<clsPhapartypearticleoperationparametre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TO_CODEOPERATIONPARAMETRE, TO_CODEOPERATION, CP_CODEOPERATIONLIBELLECPTE FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new clsPhapartypearticleoperationparametre();
					clsPhapartypearticleoperationparametre.TO_CODEOPERATIONPARAMETRE = Dataset.Tables["TABLE"].Rows[Idx]["TO_CODEOPERATIONPARAMETRE"].ToString();
					clsPhapartypearticleoperationparametre.TO_CODEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["TO_CODEOPERATION"].ToString();
					clsPhapartypearticleoperationparametre.CP_CODEOPERATIONLIBELLECPTE = Dataset.Tables["TABLE"].Rows[Idx]["CP_CODEOPERATIONLIBELLECPTE"].ToString();
					clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
				}
				Dataset.Dispose();
			}
		return clsPhapartypearticleoperationparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@TA_CODETYPEARTICLE", "@TO_CODEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "EXEC PS_PHAPARTYPEARTICLEOPERATIONPARAMETRE @TA_CODETYPEARTICLE,@TO_CODEOPERATION,@CODECRYPTAGE ";// +this.vapCritere;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetModel(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@TO_CODEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0]};
            this.vapRequete = "EXEC PS_PHAPARTYPEARTICLECOMPTEPLANCOMPTABLEMODEL @TO_CODEOPERATION,@CODECRYPTAGE ";// +this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TO_CODEOPERATIONPARAMETRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TO_CODEOPERATIONPARAMETRE , TO_CODEOPERATION FROM dbo.FT_PHAPARTYPEARTICLEOPERATIONPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TO_CODEOPERATIONPARAMETRE)</summary>
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
				this.vapCritere ="WHERE TO_CODEOPERATIONPARAMETRE=@TO_CODEOPERATIONPARAMETRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TO_CODEOPERATIONPARAMETRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TO_CODEOPERATIONPARAMETRE)</summary>
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
                    this.vapCritere = "WHERE TA_CODETYPEARTICLE=@TA_CODETYPEARTICLE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TA_CODETYPEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                    case 2:
                    this.vapCritere = "WHERE TO_CODEOPERATION=@TO_CODEOPERATION ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TA_CODETYPEARTICLE", "@TO_CODEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;

            }
        }
	}
}
