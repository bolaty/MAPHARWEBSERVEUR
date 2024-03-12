using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartypetierscompterattacheadditionnelWSDAL: ITableDAL<clsPhapartypetierscompterattacheadditionnel>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TC_CODECOMPTETYPETIERS) AS TC_CODECOMPTETYPETIERS  FROM dbo.FT_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TC_CODECOMPTETYPETIERS) AS TC_CODECOMPTETYPETIERS  FROM dbo.FT_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TC_CODECOMPTETYPETIERS) AS TC_CODECOMPTETYPETIERS  FROM dbo.FT_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartypetierscompterattacheadditionnel comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartypetierscompterattacheadditionnel pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TP_CODETYPETIERS  , PL_CODENUMCOMPTE  , TC_LIBELLE  , TC_NUMEROORDRE  FROM dbo.FT_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new clsPhapartypetierscompterattacheadditionnel();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypetierscompterattacheadditionnel.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					clsPhapartypetierscompterattacheadditionnel.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE = clsDonnee.vogDataReader["TC_LIBELLE"].ToString();
					clsPhapartypetierscompterattacheadditionnel.TC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TC_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartypetierscompterattacheadditionnel;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypetierscompterattacheadditionnel>clsPhapartypetierscompterattacheadditionnel</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel)
		{
			//Préparation des paramètres
			SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
			vppParamTC_CODECOMPTETYPETIERS.Value  = clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS ;
			SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
			vppParamTP_CODETYPETIERS.Value  = clsPhapartypetierscompterattacheadditionnel.TP_CODETYPETIERS ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhapartypetierscompterattacheadditionnel.PL_CODENUMCOMPTE ;
			SqlParameter vppParamTC_LIBELLE = new SqlParameter("@TC_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTC_LIBELLE.Value  = clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE ;
			SqlParameter vppParamTC_NUMEROORDRE = new SqlParameter("@TC_NUMEROORDRE", SqlDbType.Int);
			vppParamTC_NUMEROORDRE.Value  = clsPhapartypetierscompterattacheadditionnel.TC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL  @TC_CODECOMPTETYPETIERS, @TP_CODETYPETIERS, @PL_CODENUMCOMPTE, @TC_LIBELLE, @TC_NUMEROORDRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamTC_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartypetierscompterattacheadditionnel>clsPhapartypetierscompterattacheadditionnel</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
			vppParamTC_CODECOMPTETYPETIERS.Value  = clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS ;
			SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
			vppParamTP_CODETYPETIERS.Value  = clsPhapartypetierscompterattacheadditionnel.TP_CODETYPETIERS ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhapartypetierscompterattacheadditionnel.PL_CODENUMCOMPTE ;
			SqlParameter vppParamTC_LIBELLE = new SqlParameter("@TC_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTC_LIBELLE.Value  = clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE ;
			SqlParameter vppParamTC_NUMEROORDRE = new SqlParameter("@TC_NUMEROORDRE", SqlDbType.Int);
			vppParamTC_NUMEROORDRE.Value  = clsPhapartypetierscompterattacheadditionnel.TC_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL  @TC_CODECOMPTETYPETIERS, @TP_CODETYPETIERS, @PL_CODENUMCOMPTE, @TC_LIBELLE, @TC_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamTC_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTC_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL  @TC_CODECOMPTETYPETIERS, '' , '', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypetierscompterattacheadditionnel </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypetierscompterattacheadditionnel> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TC_CODECOMPTETYPETIERS, TP_CODETYPETIERS, PL_CODENUMCOMPTE, TC_LIBELLE, TC_NUMEROORDRE FROM dbo.FT_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<clsPhapartypetierscompterattacheadditionnel>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new clsPhapartypetierscompterattacheadditionnel();
					clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS = clsDonnee.vogDataReader["TC_CODECOMPTETYPETIERS"].ToString();
					clsPhapartypetierscompterattacheadditionnel.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					clsPhapartypetierscompterattacheadditionnel.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE = clsDonnee.vogDataReader["TC_LIBELLE"].ToString();
					clsPhapartypetierscompterattacheadditionnel.TC_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TC_NUMEROORDRE"].ToString());
					clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartypetierscompterattacheadditionnels;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartypetierscompterattacheadditionnel </returns>
		///<author>Home Technology</author>
		public List<clsPhapartypetierscompterattacheadditionnel> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<clsPhapartypetierscompterattacheadditionnel>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TC_CODECOMPTETYPETIERS, TP_CODETYPETIERS, PL_CODENUMCOMPTE, TC_LIBELLE, TC_NUMEROORDRE FROM dbo.FT_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new clsPhapartypetierscompterattacheadditionnel();
					clsPhapartypetierscompterattacheadditionnel.TC_CODECOMPTETYPETIERS = Dataset.Tables["TABLE"].Rows[Idx]["TC_CODECOMPTETYPETIERS"].ToString();
					clsPhapartypetierscompterattacheadditionnel.TP_CODETYPETIERS = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPETIERS"].ToString();
					clsPhapartypetierscompterattacheadditionnel.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsPhapartypetierscompterattacheadditionnel.TC_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TC_LIBELLE"].ToString();
					clsPhapartypetierscompterattacheadditionnel.TC_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TC_NUMEROORDRE"].ToString());
					clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
				}
				Dataset.Dispose();
			}
		return clsPhapartypetierscompterattacheadditionnels;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.VUE_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TC_CODECOMPTETYPETIERS , TC_LIBELLE FROM dbo.FT_PHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboEdition(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@TC_CODECOMPTETYPETIERS" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0].Replace("''", "'") };
            this.vapRequete = "EXEC  PS_CHARGEMENTCOMBOPHAPARTYPETIERSCOMPTERATTACHEADDITIONNEL @TC_CODECOMPTETYPETIERS,@CODECRYPTAGE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TC_CODECOMPTETYPETIERS, PL_CODENUMCOMPTE)</summary>
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
				this.vapCritere ="WHERE TC_CODECOMPTETYPETIERS=@TC_CODECOMPTETYPETIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TC_CODECOMPTETYPETIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TC_CODECOMPTETYPETIERS=@TC_CODECOMPTETYPETIERS AND PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TC_CODECOMPTETYPETIERS","@PL_CODENUMCOMPTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
