using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratcapitauxWSDAL: ITableDAL<clsCtcontratcapitaux>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CTCONTRATCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratcapitaux comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratcapitaux pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EN_CODEENTREPOT  , CC_CAPITAUX  , CC_PRIMES  , CC_TAUX  , CC_LIBELLE  FROM dbo.FT_CTCONTRATCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratcapitaux clsCtcontratcapitaux = new clsCtcontratcapitaux();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratcapitaux.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratcapitaux.CC_CAPITAUX = double.Parse(clsDonnee.vogDataReader["CC_CAPITAUX"].ToString());
					clsCtcontratcapitaux.CC_PRIMES = double.Parse(clsDonnee.vogDataReader["CC_PRIMES"].ToString());
					clsCtcontratcapitaux.CC_TAUX = float.Parse(clsDonnee.vogDataReader["CC_TAUX"].ToString());
					clsCtcontratcapitaux.CC_LIBELLE = clsDonnee.vogDataReader["CC_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratcapitaux;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratcapitaux>clsCtcontratcapitaux</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratcapitaux clsCtcontratcapitaux)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratcapitaux.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT1", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratcapitaux.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT1", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratcapitaux.CA_CODECONTRAT ;
			SqlParameter vppParamCP_CODECAPITAUX = new SqlParameter("@CP_CODECAPITAUX", SqlDbType.VarChar, 2);
			vppParamCP_CODECAPITAUX.Value  = clsCtcontratcapitaux.CP_CODECAPITAUX ;
			SqlParameter vppParamCC_CAPITAUX = new SqlParameter("@CC_CAPITAUX", SqlDbType.Money);
			vppParamCC_CAPITAUX.Value  = clsCtcontratcapitaux.CC_CAPITAUX ;
			SqlParameter vppParamCC_PRIMES = new SqlParameter("@CC_PRIMES", SqlDbType.Money);
			vppParamCC_PRIMES.Value  = clsCtcontratcapitaux.CC_PRIMES ;
			SqlParameter vppParamCC_TAUX = new SqlParameter("@CC_TAUX", SqlDbType.Float);
			vppParamCC_TAUX.Value  = clsCtcontratcapitaux.CC_TAUX ;
			SqlParameter vppParamCC_LIBELLE = new SqlParameter("@CC_LIBELLE", SqlDbType.VarChar, 1000);
			vppParamCC_LIBELLE.Value  = clsCtcontratcapitaux.CC_LIBELLE ;
			if(clsCtcontratcapitaux.CC_LIBELLE== ""  ) vppParamCC_LIBELLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCAPITAUX  @AG_CODEAGENCE1, @EN_CODEENTREPOT1, @CA_CODECONTRAT1, @CP_CODECAPITAUX, @CC_CAPITAUX, @CC_PRIMES, @CC_TAUX, @CC_LIBELLE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamCP_CODECAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamCC_CAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamCC_PRIMES);
			vppSqlCmd.Parameters.Add(vppParamCC_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCC_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratcapitaux>clsCtcontratcapitaux</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratcapitaux clsCtcontratcapitaux,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratcapitaux.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratcapitaux.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratcapitaux.CA_CODECONTRAT ;
			SqlParameter vppParamCP_CODECAPITAUX = new SqlParameter("@CP_CODECAPITAUX", SqlDbType.VarChar, 2);
			vppParamCP_CODECAPITAUX.Value  = clsCtcontratcapitaux.CP_CODECAPITAUX ;
			SqlParameter vppParamCC_CAPITAUX = new SqlParameter("@CC_CAPITAUX", SqlDbType.Money);
			vppParamCC_CAPITAUX.Value  = clsCtcontratcapitaux.CC_CAPITAUX ;
			SqlParameter vppParamCC_PRIMES = new SqlParameter("@CC_PRIMES", SqlDbType.Money);
			vppParamCC_PRIMES.Value  = clsCtcontratcapitaux.CC_PRIMES ;
			SqlParameter vppParamCC_TAUX = new SqlParameter("@CC_TAUX", SqlDbType.Float);
			vppParamCC_TAUX.Value  = clsCtcontratcapitaux.CC_TAUX ;
			SqlParameter vppParamCC_LIBELLE = new SqlParameter("@CC_LIBELLE", SqlDbType.VarChar, 1000);
			vppParamCC_LIBELLE.Value  = clsCtcontratcapitaux.CC_LIBELLE ;
			if(clsCtcontratcapitaux.CC_LIBELLE== ""  ) vppParamCC_LIBELLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCAPITAUX  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT, @CP_CODECAPITAUX, @CC_CAPITAUX, @CC_PRIMES, @CC_TAUX, @CC_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamCP_CODECAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamCC_CAPITAUX);
			vppSqlCmd.Parameters.Add(vppParamCC_PRIMES);
			vppSqlCmd.Parameters.Add(vppParamCC_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCC_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATCAPITAUX  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT, '', '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratcapitaux </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratcapitaux> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, CP_CODECAPITAUX, CC_CAPITAUX, CC_PRIMES, CC_TAUX, CC_LIBELLE FROM dbo.FT_CTCONTRATCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratcapitaux> clsCtcontratcapitauxs = new List<clsCtcontratcapitaux>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratcapitaux clsCtcontratcapitaux = new clsCtcontratcapitaux();
					clsCtcontratcapitaux.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratcapitaux.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratcapitaux.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratcapitaux.CP_CODECAPITAUX = clsDonnee.vogDataReader["CP_CODECAPITAUX"].ToString();
					clsCtcontratcapitaux.CC_CAPITAUX = double.Parse(clsDonnee.vogDataReader["CC_CAPITAUX"].ToString());
					clsCtcontratcapitaux.CC_PRIMES = double.Parse(clsDonnee.vogDataReader["CC_PRIMES"].ToString());
					clsCtcontratcapitaux.CC_TAUX = float.Parse(clsDonnee.vogDataReader["CC_TAUX"].ToString());
					clsCtcontratcapitaux.CC_LIBELLE = clsDonnee.vogDataReader["CC_LIBELLE"].ToString();
					clsCtcontratcapitauxs.Add(clsCtcontratcapitaux);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratcapitauxs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratcapitaux </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratcapitaux> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratcapitaux> clsCtcontratcapitauxs = new List<clsCtcontratcapitaux>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, CP_CODECAPITAUX, CC_CAPITAUX, CC_PRIMES, CC_TAUX, CC_LIBELLE FROM dbo.FT_CTCONTRATCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratcapitaux clsCtcontratcapitaux = new clsCtcontratcapitaux();
					clsCtcontratcapitaux.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratcapitaux.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratcapitaux.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratcapitaux.CP_CODECAPITAUX = Dataset.Tables["TABLE"].Rows[Idx]["CP_CODECAPITAUX"].ToString();
					clsCtcontratcapitaux.CC_CAPITAUX = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_CAPITAUX"].ToString());
					clsCtcontratcapitaux.CC_PRIMES = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_PRIMES"].ToString());
					clsCtcontratcapitaux.CC_TAUX = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_TAUX"].ToString());
					clsCtcontratcapitaux.CC_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["CC_LIBELLE"].ToString();
					clsCtcontratcapitauxs.Add(clsCtcontratcapitaux);
				}
				Dataset.Dispose();
			}
		return clsCtcontratcapitauxs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTCONTRATCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , EN_CODEENTREPOT FROM dbo.FT_CTCONTRATCAPITAUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CA_CODECONTRAT, CP_CODECAPITAUX)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CA_CODECONTRAT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
                case 4 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT AND CP_CODECAPITAUX=@CP_CODECAPITAUX  ";
                vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CA_CODECONTRAT", "@CP_CODECAPITAUX" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
                break;



			}
		}
	}
}
