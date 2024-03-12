using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockreglementnatureoperationtypeWSDAL: ITableDAL<clsPhamouvementstockreglementnatureoperationtype>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RO_CODENATUREOPERATIONTYPE) AS RO_CODENATUREOPERATIONTYPE  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RO_CODENATUREOPERATIONTYPE) AS RO_CODENATUREOPERATIONTYPE  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RO_CODENATUREOPERATIONTYPE) AS RO_CODENATUREOPERATIONTYPE  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglementnatureoperationtype comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglementnatureoperationtype pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RO_LIBELLE  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new clsPhamouvementstockreglementnatureoperationtype();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE = clsDonnee.vogDataReader["RO_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockreglementnatureoperationtype;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementnatureoperationtype>clsPhamouvementstockreglementnatureoperationtype</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype)
		{
			//Préparation des paramètres
			SqlParameter vppParamRO_CODENATUREOPERATIONTYPE = new SqlParameter("@RO_CODENATUREOPERATIONTYPE", SqlDbType.VarChar, 5);
			vppParamRO_CODENATUREOPERATIONTYPE.Value  = clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE ;
			SqlParameter vppParamRO_LIBELLE = new SqlParameter("@RO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamRO_LIBELLE.Value  = clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE  @RO_CODENATUREOPERATIONTYPE, @RO_LIBELLE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRO_CODENATUREOPERATIONTYPE);
			vppSqlCmd.Parameters.Add(vppParamRO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementnatureoperationtype>clsPhamouvementstockreglementnatureoperationtype</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRO_CODENATUREOPERATIONTYPE = new SqlParameter("@RO_CODENATUREOPERATIONTYPE", SqlDbType.VarChar, 5);
			vppParamRO_CODENATUREOPERATIONTYPE.Value  = clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE ;
			SqlParameter vppParamRO_LIBELLE = new SqlParameter("@RO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamRO_LIBELLE.Value  = clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE  @RO_CODENATUREOPERATIONTYPE, @RO_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRO_CODENATUREOPERATIONTYPE);
			vppSqlCmd.Parameters.Add(vppParamRO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE  @RO_CODENATUREOPERATIONTYPE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementnatureoperationtype </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementnatureoperationtype> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RO_CODENATUREOPERATIONTYPE, RO_LIBELLE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<clsPhamouvementstockreglementnatureoperationtype>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new clsPhamouvementstockreglementnatureoperationtype();
					clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE = clsDonnee.vogDataReader["RO_CODENATUREOPERATIONTYPE"].ToString();
					clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE = clsDonnee.vogDataReader["RO_LIBELLE"].ToString();
					clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockreglementnatureoperationtypes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementnatureoperationtype </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementnatureoperationtype> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<clsPhamouvementstockreglementnatureoperationtype>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RO_CODENATUREOPERATIONTYPE, RO_LIBELLE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new clsPhamouvementstockreglementnatureoperationtype();
					clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE = Dataset.Tables["TABLE"].Rows[Idx]["RO_CODENATUREOPERATIONTYPE"].ToString();
					clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["RO_LIBELLE"].ToString();
					clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockreglementnatureoperationtypes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RO_CODENATUREOPERATIONTYPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RO_CODENATUREOPERATIONTYPE , RO_LIBELLE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATIONTYPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RO_CODENATUREOPERATIONTYPE)</summary>
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
				this.vapCritere ="WHERE RO_CODENATUREOPERATIONTYPE=@RO_CODENATUREOPERATIONTYPE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RO_CODENATUREOPERATIONTYPE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
