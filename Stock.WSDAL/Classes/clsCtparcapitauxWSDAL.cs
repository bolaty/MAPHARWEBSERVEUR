using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtparcapitauxWSDAL: ITableDAL<clsCtparcapitaux>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CP_CODECAPITAUX) AS CP_CODECAPITAUX  FROM dbo.FT_CTPARCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CP_CODECAPITAUX) AS CP_CODECAPITAUX  FROM dbo.FT_CTPARCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CP_CODECAPITAUX) AS CP_CODECAPITAUX  FROM dbo.FT_CTPARCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtparcapitaux comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtparcapitaux pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CP_LIBELLECAPITAUX  , CP_ACTIF  , CP_NUMEROORDRE  FROM dbo.FT_CTPARCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtparcapitaux clsCtparcapitaux = new clsCtparcapitaux();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparcapitaux.CP_LIBELLECAPITAUX = clsDonnee.vogDataReader["CP_LIBELLECAPITAUX"].ToString();
					clsCtparcapitaux.CP_ACTIF = clsDonnee.vogDataReader["CP_ACTIF"].ToString();
					clsCtparcapitaux.CP_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CP_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtparcapitaux;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparcapitaux>clsCtparcapitaux</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtparcapitaux clsCtparcapitaux)
		{
			//Préparation des paramètres
			SqlParameter vppParamCP_CODECAPITAUX = new SqlParameter("@CP_CODECAPITAUX", SqlDbType.VarChar, 2);
			vppParamCP_CODECAPITAUX.Value  = clsCtparcapitaux.CP_CODECAPITAUX ;
			SqlParameter vppParamCP_LIBELLECAPITAUX = new SqlParameter("@CP_LIBELLECAPITAUX", SqlDbType.VarChar, 150);
			vppParamCP_LIBELLECAPITAUX.Value  = clsCtparcapitaux.CP_LIBELLECAPITAUX ;
			SqlParameter vppParamCP_ACTIF = new SqlParameter("@CP_ACTIF", SqlDbType.VarChar, 1);
			vppParamCP_ACTIF.Value  = clsCtparcapitaux.CP_ACTIF ;
			SqlParameter vppParamCP_NUMEROORDRE = new SqlParameter("@CP_NUMEROORDRE", SqlDbType.Int);
			vppParamCP_NUMEROORDRE.Value  = clsCtparcapitaux.CP_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCAPITAUX  @CP_CODECAPITAUX, @CP_LIBELLECAPITAUX, @CP_ACTIF, @CP_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCP_CODECAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamCP_LIBELLECAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamCP_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCP_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtparcapitaux>clsCtparcapitaux</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtparcapitaux clsCtparcapitaux,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCP_CODECAPITAUX = new SqlParameter("@CP_CODECAPITAUX", SqlDbType.VarChar, 2);
			vppParamCP_CODECAPITAUX.Value  = clsCtparcapitaux.CP_CODECAPITAUX ;
			SqlParameter vppParamCP_LIBELLECAPITAUX = new SqlParameter("@CP_LIBELLECAPITAUX", SqlDbType.VarChar, 150);
			vppParamCP_LIBELLECAPITAUX.Value  = clsCtparcapitaux.CP_LIBELLECAPITAUX ;
			SqlParameter vppParamCP_ACTIF = new SqlParameter("@CP_ACTIF", SqlDbType.VarChar, 1);
			vppParamCP_ACTIF.Value  = clsCtparcapitaux.CP_ACTIF ;
			SqlParameter vppParamCP_NUMEROORDRE = new SqlParameter("@CP_NUMEROORDRE", SqlDbType.Int);
			vppParamCP_NUMEROORDRE.Value  = clsCtparcapitaux.CP_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCAPITAUX  @CP_CODECAPITAUX, @CP_LIBELLECAPITAUX, @CP_ACTIF, @CP_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCP_CODECAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamCP_LIBELLECAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamCP_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCP_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARCAPITAUX  @CP_CODECAPITAUX, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparcapitaux </returns>
		///<author>Home Technology</author>
		public List<clsCtparcapitaux> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CP_CODECAPITAUX, CP_LIBELLECAPITAUX, CP_ACTIF, CP_NUMEROORDRE FROM dbo.FT_CTPARCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtparcapitaux> clsCtparcapitauxs = new List<clsCtparcapitaux>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtparcapitaux clsCtparcapitaux = new clsCtparcapitaux();
					clsCtparcapitaux.CP_CODECAPITAUX = clsDonnee.vogDataReader["CP_CODECAPITAUX"].ToString();
					clsCtparcapitaux.CP_LIBELLECAPITAUX = clsDonnee.vogDataReader["CP_LIBELLECAPITAUX"].ToString();
					clsCtparcapitaux.CP_ACTIF = clsDonnee.vogDataReader["CP_ACTIF"].ToString();
					clsCtparcapitaux.CP_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["CP_NUMEROORDRE"].ToString());
					clsCtparcapitauxs.Add(clsCtparcapitaux);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtparcapitauxs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtparcapitaux </returns>
		///<author>Home Technology</author>
		public List<clsCtparcapitaux> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtparcapitaux> clsCtparcapitauxs = new List<clsCtparcapitaux>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CP_CODECAPITAUX, CP_LIBELLECAPITAUX, CP_ACTIF, CP_NUMEROORDRE FROM dbo.FT_CTPARCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtparcapitaux clsCtparcapitaux = new clsCtparcapitaux();
					clsCtparcapitaux.CP_CODECAPITAUX = Dataset.Tables["TABLE"].Rows[Idx]["CP_CODECAPITAUX"].ToString();
					clsCtparcapitaux.CP_LIBELLECAPITAUX = Dataset.Tables["TABLE"].Rows[Idx]["CP_LIBELLECAPITAUX"].ToString();
					clsCtparcapitaux.CP_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["CP_ACTIF"].ToString();
					clsCtparcapitaux.CP_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CP_NUMEROORDRE"].ToString());
					clsCtparcapitauxs.Add(clsCtparcapitaux);
				}
				Dataset.Dispose();
			}
		return clsCtparcapitauxs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CP_CODECAPITAUX , CP_LIBELLECAPITAUX FROM dbo.FT_CTPARCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CP_CODECAPITAUX)</summary>
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
				this.vapCritere ="WHERE CP_CODECAPITAUX=@CP_CODECAPITAUX";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CP_CODECAPITAUX"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
