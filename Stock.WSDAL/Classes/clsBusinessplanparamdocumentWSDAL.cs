using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBusinessplanparamdocumentWSDAL: ITableDAL<clsBusinessplanparamdocument>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PB_CODEDOCUMENT) AS PB_CODEDOCUMENT  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PB_CODEDOCUMENT) AS PB_CODEDOCUMENT  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PB_CODEDOCUMENT) AS PB_CODEDOCUMENT  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBusinessplanparamdocument comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBusinessplanparamdocument pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PB_LIBELLE  , PB_NUMEROORDRE  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBusinessplanparamdocument clsBusinessplanparamdocument = new clsBusinessplanparamdocument();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparamdocument.PB_LIBELLE = clsDonnee.vogDataReader["PB_LIBELLE"].ToString();
					clsBusinessplanparamdocument.PB_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PB_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBusinessplanparamdocument;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparamdocument>clsBusinessplanparamdocument</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBusinessplanparamdocument clsBusinessplanparamdocument)
		{
			//Préparation des paramètres
			SqlParameter vppParamPB_CODEDOCUMENT = new SqlParameter("@PB_CODEDOCUMENT", SqlDbType.VarChar, 3);
			vppParamPB_CODEDOCUMENT.Value  = clsBusinessplanparamdocument.PB_CODEDOCUMENT ;
			SqlParameter vppParamPB_LIBELLE = new SqlParameter("@PB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPB_LIBELLE.Value  = clsBusinessplanparamdocument.PB_LIBELLE ;
			SqlParameter vppParamPB_NUMEROORDRE = new SqlParameter("@PB_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamPB_NUMEROORDRE.Value  = clsBusinessplanparamdocument.PB_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMDOCUMENT  @PB_CODEDOCUMENT, @PB_LIBELLE, @PB_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPB_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamPB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPB_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparamdocument>clsBusinessplanparamdocument</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBusinessplanparamdocument clsBusinessplanparamdocument,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPB_CODEDOCUMENT = new SqlParameter("@PB_CODEDOCUMENT", SqlDbType.VarChar, 3);
			vppParamPB_CODEDOCUMENT.Value  = clsBusinessplanparamdocument.PB_CODEDOCUMENT ;
			SqlParameter vppParamPB_LIBELLE = new SqlParameter("@PB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPB_LIBELLE.Value  = clsBusinessplanparamdocument.PB_LIBELLE ;
			SqlParameter vppParamPB_NUMEROORDRE = new SqlParameter("@PB_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamPB_NUMEROORDRE.Value  = clsBusinessplanparamdocument.PB_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMDOCUMENT  @PB_CODEDOCUMENT, @PB_LIBELLE, @PB_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPB_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamPB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPB_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMDOCUMENT  @PB_CODEDOCUMENT, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamdocument </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamdocument> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PB_CODEDOCUMENT, PB_LIBELLE, PB_NUMEROORDRE FROM dbo.FT_BUSINESSPLANPARAMDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBusinessplanparamdocument> clsBusinessplanparamdocuments = new List<clsBusinessplanparamdocument>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparamdocument clsBusinessplanparamdocument = new clsBusinessplanparamdocument();
					clsBusinessplanparamdocument.PB_CODEDOCUMENT = clsDonnee.vogDataReader["PB_CODEDOCUMENT"].ToString();
					clsBusinessplanparamdocument.PB_LIBELLE = clsDonnee.vogDataReader["PB_LIBELLE"].ToString();
					clsBusinessplanparamdocument.PB_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PB_NUMEROORDRE"].ToString());
					clsBusinessplanparamdocuments.Add(clsBusinessplanparamdocument);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBusinessplanparamdocuments;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamdocument </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamdocument> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBusinessplanparamdocument> clsBusinessplanparamdocuments = new List<clsBusinessplanparamdocument>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PB_CODEDOCUMENT, PB_LIBELLE, PB_NUMEROORDRE FROM dbo.FT_BUSINESSPLANPARAMDOCUMENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBusinessplanparamdocument clsBusinessplanparamdocument = new clsBusinessplanparamdocument();
					clsBusinessplanparamdocument.PB_CODEDOCUMENT = Dataset.Tables["TABLE"].Rows[Idx]["PB_CODEDOCUMENT"].ToString();
					clsBusinessplanparamdocument.PB_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PB_LIBELLE"].ToString();
					clsBusinessplanparamdocument.PB_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PB_NUMEROORDRE"].ToString());
					clsBusinessplanparamdocuments.Add(clsBusinessplanparamdocument);
				}
				Dataset.Dispose();
			}
		return clsBusinessplanparamdocuments;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENT(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY PB_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PB_CODEDOCUMENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PB_CODEDOCUMENT , PB_LIBELLE FROM dbo.FT_BUSINESSPLANPARAMDOCUMENT(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY PB_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PB_CODEDOCUMENT)</summary>
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
				this.vapCritere ="WHERE PB_CODEDOCUMENT=@PB_CODEDOCUMENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PB_CODEDOCUMENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
