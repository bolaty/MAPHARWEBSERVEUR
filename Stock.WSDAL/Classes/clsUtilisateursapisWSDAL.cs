using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.Common;
using System;

namespace Stock.WSDAL
{

	public class clsUtilisateursapisWSDAL: ITableDAL<clsUtilisateursapis>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire (sur un champs de la base) avec ou sans critères (Ordre Critères :  ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsUtilisateursapis">clsUtilisateursapis</param>
		///<returns>Une collection de clsUtilisateursapis valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public List<clsUtilisateursapis> pvgValueScalarRequete(clsDonnee clsDonnee, clsUtilisateursapis clsUtilisateursapis)
		{
			List<clsUtilisateursapis> clsUtilisateursapiss=new List<clsUtilisateursapis>();
			DataSet Dataset = new DataSet();
			vapNomParametre = new string[] {"@UT_IDUTILISATEUR", "@UT_LOGIN", "@UT_MOTDEPASSE", "@UT_TOKEN", "@UT_STATUT", "@UT_DATESAISIE", "@UT_UTILISATEURSAPIS1", "@UT_UTILISATEURSAPIS2", "@LG_CODELANGUE", "@CODECRYPTAGE", "@TYPEOPERATION"};
			vapValeurParametre = new object[] {clsUtilisateursapis.UT_IDUTILISATEUR, clsUtilisateursapis.UT_LOGIN, clsUtilisateursapis.UT_MOTDEPASSE, clsUtilisateursapis.UT_TOKEN, clsUtilisateursapis.UT_STATUT, clsUtilisateursapis.UT_DATESAISIE, clsUtilisateursapis.UT_UTILISATEURSAPIS1, clsUtilisateursapis.UT_UTILISATEURSAPIS2, clsUtilisateursapis.LG_CODELANGUE, clsDonnee.vogCleCryptage,clsUtilisateursapis.TYPEOPERATION};
			this.vapRequete = "EXEC PR_UTILISATEURSAPIS @UT_IDUTILISATEUR, @UT_LOGIN, @UT_MOTDEPASSE, @UT_TOKEN, @UT_STATUT, @UT_DATESAISIE, @UT_UTILISATEURSAPIS1, @UT_UTILISATEURSAPIS2, @LG_CODELANGUE, @CODECRYPTAGE, @TYPEOPERATION ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			 clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if (double.Parse(clsDonnee.vagNombreLigneRequete) > 0)
			{
				foreach (DataRow row in Dataset.Tables[0].Rows)
				{
					clsUtilisateursapis = new clsUtilisateursapis();
					clsUtilisateursapis.clsObjetRetour.SL_VALEURRETOURS = row["SL_VALEURRETOURS"].ToString();
					clsUtilisateursapis.clsObjetRetour.SL_CODEMESSAGE = row["SL_CODEMESSAGE"].ToString();
					clsUtilisateursapis.clsObjetRetour.SL_RESULTAT = row["SL_RESULTAT"].ToString();
					clsUtilisateursapis.clsObjetRetour.SL_MESSAGE = row["SL_MESSAGE"].ToString(); 
					clsUtilisateursapiss.Add(clsUtilisateursapis);
				}
			}
			Dataset.Dispose();
			return clsUtilisateursapiss;
		}

		///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsUtilisateursapis">clsUtilisateursapis</param>
		///<author>Home Technology</author>
		public List<clsUtilisateursapis> pvgMiseAjour(clsDonnee clsDonnee, clsUtilisateursapis clsUtilisateursapis)
		{
			List<clsUtilisateursapis> clsUtilisateursapiss = new List<clsUtilisateursapis> ();
			DataSet Dataset = new DataSet();
			vapNomParametre = new string[] {"@UT_IDUTILISATEUR","@UT_LOGIN","@UT_MOTDEPASSE","@UT_TOKEN","@UT_STATUT","@UT_DATESAISIE" ,"@UT_UTILISATEURSAPIS1", "@UT_UTILISATEURSAPIS2", "@LG_CODELANGUE", "@CODECRYPTAGE", "@TYPEOPERATION"};
			vapValeurParametre = new object[] {clsUtilisateursapis.UT_IDUTILISATEUR,clsUtilisateursapis.UT_LOGIN,clsUtilisateursapis.UT_MOTDEPASSE,clsUtilisateursapis.UT_TOKEN,clsUtilisateursapis.UT_STATUT,clsUtilisateursapis.UT_DATESAISIE, clsUtilisateursapis.UT_UTILISATEURSAPIS1, clsUtilisateursapis.UT_UTILISATEURSAPIS2, clsUtilisateursapis.LG_CODELANGUE, clsDonnee.vogCleCryptage, clsUtilisateursapis.TYPEOPERATION};
			this.vapRequete = "EXEC PC_UTILISATEURSAPIS @UT_IDUTILISATEUR,@UT_LOGIN,@UT_MOTDEPASSE,@UT_TOKEN,@UT_STATUT,@UT_DATESAISIE, @UT_UTILISATEURSAPIS1, @UT_UTILISATEURSAPIS2, @LG_CODELANGUE, @CODECRYPTAGE, @TYPEOPERATION ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if (double.Parse(clsDonnee.vagNombreLigneRequete) > 0)
 			{
				foreach (DataRow row in Dataset.Tables[0].Rows) 
 				{ 
					clsUtilisateursapis = new clsUtilisateursapis();
					clsUtilisateursapis.clsObjetRetour.SL_CODEMESSAGE = row["SL_CODEMESSAGE"].ToString();
					clsUtilisateursapis.clsObjetRetour.SL_RESULTAT = row["SL_RESULTAT"].ToString();
					clsUtilisateursapis.clsObjetRetour.SL_MESSAGE = row["SL_MESSAGE"].ToString(); 
					clsUtilisateursapiss.Add(clsUtilisateursapis);
				}
			}
			Dataset.Dispose();
			return clsUtilisateursapiss;
		}

		///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees via la procédure Stockée PE_ACTIVITE </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsUtilisateursapis">clsUtilisateursapis</param>
		///<returns>Une collection de clsUtilisateursapis valeur du résultat de la requete </returns>
		///<author>Home Technology</author>
		public List<clsUtilisateursapis> pvgSelectListe(clsDonnee clsDonnee, clsUtilisateursapis clsUtilisateursapis)
		{
			List<clsUtilisateursapis> clsUtilisateursapiss = new List<clsUtilisateursapis>();
			DataSet Dataset = new DataSet();

			vapNomParametre = new string[] {"@UT_IDUTILISATEUR", "@UT_LOGIN", "@UT_MOTDEPASSE", "@UT_TOKEN", "@UT_STATUT", "@UT_DATESAISIE", "@UT_UTILISATEURSAPIS1", "@UT_UTILISATEURSAPIS2", "@LG_CODELANGUE", "@CODECRYPTAGE", "@TYPEOPERATION"};
			vapValeurParametre = new object[] {clsUtilisateursapis.UT_IDUTILISATEUR, clsUtilisateursapis.UT_LOGIN, clsUtilisateursapis.UT_MOTDEPASSE, clsUtilisateursapis.UT_TOKEN, clsUtilisateursapis.UT_STATUT, clsUtilisateursapis.UT_DATESAISIE, clsUtilisateursapis.UT_UTILISATEURSAPIS1, clsUtilisateursapis.UT_UTILISATEURSAPIS2, clsUtilisateursapis.LG_CODELANGUE, clsDonnee.vogCleCryptage, clsUtilisateursapis.TYPEOPERATION};
			this.vapRequete = "EXEC  PE_UTILISATEURSAPIS @UT_IDUTILISATEUR, @UT_LOGIN, @UT_MOTDEPASSE, @UT_TOKEN, @UT_STATUT, @UT_DATESAISIE, @UT_UTILISATEURSAPIS1, @UT_UTILISATEURSAPIS2, @LG_CODELANGUE, @CODECRYPTAGE, @TYPEOPERATION";
			this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
				if (double.Parse(clsDonnee.vagNombreLigneRequete) > 0)
				{
					foreach (DataRow row in Dataset.Tables[0].Rows)
                    {
                       Stock.Common.clsObjetRetour clsObjetRetour = new Stock.Common.clsObjetRetour();
                        clsUtilisateursapis = new clsUtilisateursapis();
                        clsUtilisateursapis.clsObjetRetour = new Stock.Common.clsObjetRetour();
                        clsUtilisateursapis.UT_IDUTILISATEUR = row["UT_IDUTILISATEUR"].ToString();
                        clsUtilisateursapis.UT_LOGIN = row["UT_LOGIN"].ToString();
                        clsUtilisateursapis.UT_MOTDEPASSE = row["UT_MOTDEPASSE"].ToString();
                        clsUtilisateursapis.UT_TOKEN = row["UT_TOKEN"].ToString();
                        clsUtilisateursapis.UT_STATUT = row["UT_STATUT"].ToString();
                        clsUtilisateursapis.UT_DATESAISIE = (row["UT_DATESAISIE"].ToString() == "") ? "" : DateTime.Parse(row["UT_DATESAISIE"].ToString()).ToShortDateString().Replace("/", "-");
                        if (clsUtilisateursapis.UT_DATESAISIE == "01-01-1900") clsUtilisateursapis.UT_DATESAISIE = "";
                        clsUtilisateursapis.clsObjetRetour.SL_CODEMESSAGE = row["SL_CODEMESSAGE"].ToString();
                        clsUtilisateursapis.clsObjetRetour.SL_RESULTAT = row["SL_RESULTAT"].ToString();
                        clsUtilisateursapis.clsObjetRetour.SL_MESSAGE = row["SL_MESSAGE"].ToString();
                        clsUtilisateursapiss.Add(clsUtilisateursapis);
					}
				}
			Dataset.Dispose();
			return clsUtilisateursapiss;
		}

        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }

        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }

        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }

        public clsUtilisateursapis pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }

        public void pvgInsert(clsDonnee clsDonnee, clsUtilisateursapis vppCritere)
        {
            throw new NotImplementedException();
        }

        public void pvgUpdate(clsDonnee clsDonnee, clsUtilisateursapis vppCritere, params string[] vppCritere1)
        {
            throw new NotImplementedException();
        }

        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }

        public List<clsUtilisateursapis> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }

        public List<clsUtilisateursapis> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }

        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }

        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, clsUtilisateursapis clsUtilisateursapis)
        {
            vapNomParametre = new string[] { "@UT_IDUTILISATEUR", "@UT_LOGIN", "@UT_MOTDEPASSE", "@UT_TOKEN", "@UT_STATUT", "@UT_DATESAISIE", "@UT_UTILISATEURSAPIS1", "@UT_UTILISATEURSAPIS2", "@LG_CODELANGUE", "@CODECRYPTAGE", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsUtilisateursapis.UT_IDUTILISATEUR, clsUtilisateursapis.UT_LOGIN, clsUtilisateursapis.UT_MOTDEPASSE, clsUtilisateursapis.UT_TOKEN, clsUtilisateursapis.UT_STATUT, clsUtilisateursapis.UT_DATESAISIE, clsUtilisateursapis.UT_UTILISATEURSAPIS1, clsUtilisateursapis.UT_UTILISATEURSAPIS2, clsUtilisateursapis.LG_CODELANGUE, clsDonnee.vogCleCryptage, clsUtilisateursapis.TYPEOPERATION };
            this.vapRequete = "EXEC  PE_UTILISATEURSAPIS @UT_IDUTILISATEUR, @UT_LOGIN, @UT_MOTDEPASSE, @UT_TOKEN, @UT_STATUT, @UT_DATESAISIE, @UT_UTILISATEURSAPIS1, @UT_UTILISATEURSAPIS2, @LG_CODELANGUE, @CODECRYPTAGE, @TYPEOPERATION";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            throw new NotImplementedException();
        }
    }
}