using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpartypeoccupantWSDAL: ITableDAL<clsCtpartypeoccupant>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(OC_CODETYPEOCCUPANT) AS OC_CODETYPEOCCUPANT  FROM dbo.FT_CTPARTYPEOCCUPANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(OC_CODETYPEOCCUPANT) AS OC_CODETYPEOCCUPANT  FROM dbo.FT_CTPARTYPEOCCUPANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(OC_CODETYPEOCCUPANT) AS OC_CODETYPEOCCUPANT  FROM dbo.FT_CTPARTYPEOCCUPANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpartypeoccupant comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpartypeoccupant pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT OC_LIBLLETYPEOCCUPANT  , OC_ACTIF  , OC_NUMEROORDRE  FROM dbo.FT_CTPARTYPEOCCUPANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpartypeoccupant clsCtpartypeoccupant = new clsCtpartypeoccupant();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT = clsDonnee.vogDataReader["OC_LIBLLETYPEOCCUPANT"].ToString();
					clsCtpartypeoccupant.OC_ACTIF = clsDonnee.vogDataReader["OC_ACTIF"].ToString();
					clsCtpartypeoccupant.OC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["OC_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpartypeoccupant;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypeoccupant>clsCtpartypeoccupant</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpartypeoccupant clsCtpartypeoccupant)
		{
			//Préparation des paramètres
			SqlParameter vppParamOC_CODETYPEOCCUPANT = new SqlParameter("@OC_CODETYPEOCCUPANT", SqlDbType.VarChar, 2);
			vppParamOC_CODETYPEOCCUPANT.Value  = clsCtpartypeoccupant.OC_CODETYPEOCCUPANT ;
			SqlParameter vppParamOC_LIBLLETYPEOCCUPANT = new SqlParameter("@OC_LIBLLETYPEOCCUPANT", SqlDbType.VarChar, 150);
			vppParamOC_LIBLLETYPEOCCUPANT.Value  = clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT ;
			SqlParameter vppParamOC_ACTIF = new SqlParameter("@OC_ACTIF", SqlDbType.VarChar, 1);
			vppParamOC_ACTIF.Value  = clsCtpartypeoccupant.OC_ACTIF ;
			SqlParameter vppParamOC_NUMEROORDRE = new SqlParameter("@OC_NUMEROORDRE", SqlDbType.Int);
			vppParamOC_NUMEROORDRE.Value  = clsCtpartypeoccupant.OC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEOCCUPANT  @OC_CODETYPEOCCUPANT, @OC_LIBLLETYPEOCCUPANT, @OC_ACTIF, @OC_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOC_CODETYPEOCCUPANT);
			vppSqlCmd.Parameters.Add(vppParamOC_LIBLLETYPEOCCUPANT);
			vppSqlCmd.Parameters.Add(vppParamOC_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamOC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartypeoccupant>clsCtpartypeoccupant</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpartypeoccupant clsCtpartypeoccupant,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamOC_CODETYPEOCCUPANT = new SqlParameter("@OC_CODETYPEOCCUPANT", SqlDbType.VarChar, 2);
			vppParamOC_CODETYPEOCCUPANT.Value  = clsCtpartypeoccupant.OC_CODETYPEOCCUPANT ;
			SqlParameter vppParamOC_LIBLLETYPEOCCUPANT = new SqlParameter("@OC_LIBLLETYPEOCCUPANT", SqlDbType.VarChar, 150);
			vppParamOC_LIBLLETYPEOCCUPANT.Value  = clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT ;
			SqlParameter vppParamOC_ACTIF = new SqlParameter("@OC_ACTIF", SqlDbType.VarChar, 1);
			vppParamOC_ACTIF.Value  = clsCtpartypeoccupant.OC_ACTIF ;
			SqlParameter vppParamOC_NUMEROORDRE = new SqlParameter("@OC_NUMEROORDRE", SqlDbType.Int);
			vppParamOC_NUMEROORDRE.Value  = clsCtpartypeoccupant.OC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEOCCUPANT  @OC_CODETYPEOCCUPANT, @OC_LIBLLETYPEOCCUPANT, @OC_ACTIF, @OC_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOC_CODETYPEOCCUPANT);
			vppSqlCmd.Parameters.Add(vppParamOC_LIBLLETYPEOCCUPANT);
			vppSqlCmd.Parameters.Add(vppParamOC_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamOC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTYPEOCCUPANT  @OC_CODETYPEOCCUPANT, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypeoccupant </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypeoccupant> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  OC_CODETYPEOCCUPANT, OC_LIBLLETYPEOCCUPANT, OC_ACTIF, OC_NUMEROORDRE FROM dbo.FT_CTPARTYPEOCCUPANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpartypeoccupant> clsCtpartypeoccupants = new List<clsCtpartypeoccupant>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartypeoccupant clsCtpartypeoccupant = new clsCtpartypeoccupant();
					clsCtpartypeoccupant.OC_CODETYPEOCCUPANT = clsDonnee.vogDataReader["OC_CODETYPEOCCUPANT"].ToString();
					clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT = clsDonnee.vogDataReader["OC_LIBLLETYPEOCCUPANT"].ToString();
					clsCtpartypeoccupant.OC_ACTIF = clsDonnee.vogDataReader["OC_ACTIF"].ToString();
					clsCtpartypeoccupant.OC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["OC_NUMEROORDRE"].ToString());
					clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpartypeoccupants;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartypeoccupant </returns>
		///<author>Home Technology</author>
		public List<clsCtpartypeoccupant> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpartypeoccupant> clsCtpartypeoccupants = new List<clsCtpartypeoccupant>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  OC_CODETYPEOCCUPANT, OC_LIBLLETYPEOCCUPANT, OC_ACTIF, OC_NUMEROORDRE FROM dbo.FT_CTPARTYPEOCCUPANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpartypeoccupant clsCtpartypeoccupant = new clsCtpartypeoccupant();
					clsCtpartypeoccupant.OC_CODETYPEOCCUPANT = Dataset.Tables["TABLE"].Rows[Idx]["OC_CODETYPEOCCUPANT"].ToString();
					clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT = Dataset.Tables["TABLE"].Rows[Idx]["OC_LIBLLETYPEOCCUPANT"].ToString();
					clsCtpartypeoccupant.OC_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["OC_ACTIF"].ToString();
					clsCtpartypeoccupant.OC_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OC_NUMEROORDRE"].ToString());
					clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
				}
				Dataset.Dispose();
			}
		return clsCtpartypeoccupants;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARTYPEOCCUPANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OC_CODETYPEOCCUPANT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT OC_CODETYPEOCCUPANT , OC_LIBLLETYPEOCCUPANT FROM dbo.FT_CTPARTYPEOCCUPANT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OC_CODETYPEOCCUPANT)</summary>
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
				this.vapCritere ="WHERE OC_CODETYPEOCCUPANT=@OC_CODETYPEOCCUPANT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@OC_CODETYPEOCCUPANT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
