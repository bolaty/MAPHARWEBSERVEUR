using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparcapitauxrisqueassuranceliaisonWSDAL: ITableDAL<clsCtparcapitauxrisqueassuranceliaison>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CP_CODECAPITAUX) AS CP_CODECAPITAUX  FROM dbo.FT_CTPARCAPITAUXRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CP_CODECAPITAUX) AS CP_CODECAPITAUX  FROM dbo.FT_CTPARCAPITAUXRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CP_CODECAPITAUX) AS CP_CODECAPITAUX  FROM dbo.FT_CTPARCAPITAUXRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparcapitauxrisqueassuranceliaison comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparcapitauxrisqueassuranceliaison pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CL_NUMEROORDRE  FROM dbo.FT_CTPARCAPITAUXRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new clsCtparcapitauxrisqueassuranceliaison();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparcapitauxrisqueassuranceliaison.CL_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CL_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparcapitauxrisqueassuranceliaison;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparcapitauxrisqueassuranceliaison>clsCtparcapitauxrisqueassuranceliaison</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison)
		{
			//Préparation des paramètres
			SqlParameter vppParamCP_CODECAPITAUX = new SqlParameter("@CP_CODECAPITAUX", SqlDbType.VarChar, 2);
			vppParamCP_CODECAPITAUX.Value  = clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtparcapitauxrisqueassuranceliaison.RQ_CODERISQUE ;
			SqlParameter vppParamCL_NUMEROORDRE = new SqlParameter("@CL_NUMEROORDRE", SqlDbType.Int);
			vppParamCL_NUMEROORDRE.Value  = clsCtparcapitauxrisqueassuranceliaison.CL_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCAPITAUXRISQUEASSURANCELIAISON  @CP_CODECAPITAUX, @RQ_CODERISQUE, @CL_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCP_CODECAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamCL_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparcapitauxrisqueassuranceliaison>clsCtparcapitauxrisqueassuranceliaison</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCP_CODECAPITAUX = new SqlParameter("@CP_CODECAPITAUX", SqlDbType.VarChar, 2);
			vppParamCP_CODECAPITAUX.Value  = clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX ;
			SqlParameter vppParamRQ_CODERISQUE = new SqlParameter("@RQ_CODERISQUE", SqlDbType.VarChar, 2);
			vppParamRQ_CODERISQUE.Value  = clsCtparcapitauxrisqueassuranceliaison.RQ_CODERISQUE ;
			SqlParameter vppParamCL_NUMEROORDRE = new SqlParameter("@CL_NUMEROORDRE", SqlDbType.Int);
			vppParamCL_NUMEROORDRE.Value  = clsCtparcapitauxrisqueassuranceliaison.CL_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCAPITAUXRISQUEASSURANCELIAISON  @CP_CODECAPITAUX, @RQ_CODERISQUE, @CL_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCP_CODECAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODERISQUE);
			vppSqlCmd.Parameters.Add(vppParamCL_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCAPITAUXRISQUEASSURANCELIAISON  @CP_CODECAPITAUX, @RQ_CODERISQUE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparcapitauxrisqueassuranceliaison </returns>
		///<author>Home Technology</author>
		public List<clsCtparcapitauxrisqueassuranceliaison> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CP_CODECAPITAUX, RQ_CODERISQUE, CL_NUMEROORDRE FROM dbo.FT_CTPARCAPITAUXRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<clsCtparcapitauxrisqueassuranceliaison>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new clsCtparcapitauxrisqueassuranceliaison();
					clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX = clsDonnee.vogDataReader["CP_CODECAPITAUX"].ToString();
					clsCtparcapitauxrisqueassuranceliaison.RQ_CODERISQUE = clsDonnee.vogDataReader["RQ_CODERISQUE"].ToString();
					clsCtparcapitauxrisqueassuranceliaison.CL_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CL_NUMEROORDRE"].ToString());
					clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparcapitauxrisqueassuranceliaisons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparcapitauxrisqueassuranceliaison </returns>
		///<author>Home Technology</author>
		public List<clsCtparcapitauxrisqueassuranceliaison> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<clsCtparcapitauxrisqueassuranceliaison>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CP_CODECAPITAUX, RQ_CODERISQUE, CL_NUMEROORDRE FROM dbo.FT_CTPARCAPITAUXRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new clsCtparcapitauxrisqueassuranceliaison();
					clsCtparcapitauxrisqueassuranceliaison.CP_CODECAPITAUX = Dataset.Tables["TABLE"].Rows[Idx]["CP_CODECAPITAUX"].ToString();
					clsCtparcapitauxrisqueassuranceliaison.RQ_CODERISQUE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODERISQUE"].ToString();
					clsCtparcapitauxrisqueassuranceliaison.CL_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CL_NUMEROORDRE"].ToString());
					clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
				}
				Dataset.Dispose();
			}
		return clsCtparcapitauxrisqueassuranceliaisons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARCAPITAUXRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY CL_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CP_CODECAPITAUX, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CP_CODECAPITAUX , CL_NUMEROORDRE FROM dbo.FT_CTPARCAPITAUXRISQUEASSURANCELIAISON(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CP_CODECAPITAUX, RQ_CODERISQUE)</summary>
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
				this.vapCritere = "WHERE RQ_CODERISQUE=@RQ_CODERISQUE";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@RQ_CODERISQUE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere = "WHERE RQ_CODERISQUE=@RQ_CODERISQUE AND CP_CODECAPITAUX=@CP_CODECAPITAUX";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@RQ_CODERISQUE", "@CP_CODECAPITAUX" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
