using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparpathologieWSDAL: ITableDAL<clsPhaparpathologie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PA_CODEPATHOLOGIE) AS PA_CODEPATHOLOGIE  FROM dbo.FT_PHAPARPATHOLOGIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PA_CODEPATHOLOGIE) AS PA_CODEPATHOLOGIE  FROM dbo.FT_PHAPARPATHOLOGIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PA_CODEPATHOLOGIE) AS PA_CODEPATHOLOGIE  FROM dbo.FT_PHAPARPATHOLOGIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparpathologie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparpathologie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SR_CODESERVICE  , PA_LIBELLE  FROM dbo.FT_PHAPARPATHOLOGIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparpathologie clsPhaparpathologie = new clsPhaparpathologie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpathologie.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsPhaparpathologie.PA_LIBELLE = clsDonnee.vogDataReader["PA_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparpathologie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpathologie>clsPhaparpathologie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparpathologie clsPhaparpathologie)
		{
			//Préparation des paramètres
			SqlParameter vppParamPA_CODEPATHOLOGIE = new SqlParameter("@PA_CODEPATHOLOGIE", SqlDbType.VarChar, 50);
			vppParamPA_CODEPATHOLOGIE.Value  = clsPhaparpathologie.PA_CODEPATHOLOGIE ;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsPhaparpathologie.SR_CODESERVICE ;
			SqlParameter vppParamPA_LIBELLE = new SqlParameter("@PA_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPA_LIBELLE.Value  = clsPhaparpathologie.PA_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPATHOLOGIE  @PA_CODEPATHOLOGIE, @SR_CODESERVICE, @PA_LIBELLE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPA_CODEPATHOLOGIE);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamPA_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparpathologie>clsPhaparpathologie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparpathologie clsPhaparpathologie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPA_CODEPATHOLOGIE = new SqlParameter("@PA_CODEPATHOLOGIE", SqlDbType.VarChar, 50);
			vppParamPA_CODEPATHOLOGIE.Value  = clsPhaparpathologie.PA_CODEPATHOLOGIE ;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsPhaparpathologie.SR_CODESERVICE ;
			SqlParameter vppParamPA_LIBELLE = new SqlParameter("@PA_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPA_LIBELLE.Value  = clsPhaparpathologie.PA_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPATHOLOGIE  @PA_CODEPATHOLOGIE, @SR_CODESERVICE, @PA_LIBELLE, @CODECRYPTAGE1, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPA_CODEPATHOLOGIE);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamPA_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARPATHOLOGIE  @PA_CODEPATHOLOGIE, '', '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpathologie </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpathologie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PA_CODEPATHOLOGIE, SR_CODESERVICE, PA_LIBELLE FROM dbo.FT_PHAPARPATHOLOGIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparpathologie> clsPhaparpathologies = new List<clsPhaparpathologie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparpathologie clsPhaparpathologie = new clsPhaparpathologie();
					clsPhaparpathologie.PA_CODEPATHOLOGIE = clsDonnee.vogDataReader["PA_CODEPATHOLOGIE"].ToString();
					clsPhaparpathologie.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsPhaparpathologie.PA_LIBELLE = clsDonnee.vogDataReader["PA_LIBELLE"].ToString();
					clsPhaparpathologies.Add(clsPhaparpathologie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparpathologies;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparpathologie </returns>
		///<author>Home Technology</author>
		public List<clsPhaparpathologie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparpathologie> clsPhaparpathologies = new List<clsPhaparpathologie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PA_CODEPATHOLOGIE, SR_CODESERVICE, PA_LIBELLE FROM dbo.FT_PHAPARPATHOLOGIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparpathologie clsPhaparpathologie = new clsPhaparpathologie();
					clsPhaparpathologie.PA_CODEPATHOLOGIE = Dataset.Tables["TABLE"].Rows[Idx]["PA_CODEPATHOLOGIE"].ToString();
					clsPhaparpathologie.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
					clsPhaparpathologie.PA_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PA_LIBELLE"].ToString();
					clsPhaparpathologies.Add(clsPhaparpathologie);
				}
				Dataset.Dispose();
			}
		return clsPhaparpathologies;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARPATHOLOGIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PA_CODEPATHOLOGIE, SR_CODESERVICE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PA_CODEPATHOLOGIE , PA_LIBELLE FROM dbo.FT_PHAPARPATHOLOGIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PA_CODEPATHOLOGIE, SR_CODESERVICE)</summary>
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
				this.vapCritere ="WHERE PA_CODEPATHOLOGIE=@PA_CODEPATHOLOGIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PA_CODEPATHOLOGIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PA_CODEPATHOLOGIE=@PA_CODEPATHOLOGIE AND SR_CODESERVICE=@SR_CODESERVICE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PA_CODEPATHOLOGIE","@SR_CODESERVICE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PA_CODEPATHOLOGIE, SR_CODESERVICE)</summary>
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
		        this.vapCritere = "WHERE SR_CODESERVICE=@SR_CODESERVICE";
		        vapNomParametre = new string[]{"@CODECRYPTAGE", "@SR_CODESERVICE" };
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
		        break;
		        case 2 :
		        this.vapCritere = "WHERE SR_CODESERVICE=@SR_CODESERVICE AND PA_CODEPATHOLOGIE=@PA_CODEPATHOLOGIE";
		        vapNomParametre = new string[]{"@CODECRYPTAGE", "@SR_CODESERVICE", "@PA_CODEPATHOLOGIE" };
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
		        break;
	        }
        }



	}
}
