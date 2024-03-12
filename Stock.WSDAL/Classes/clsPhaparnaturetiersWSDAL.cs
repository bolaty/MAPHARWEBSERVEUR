using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparnaturetiersWSDAL: ITableDAL<clsPhaparnaturetiers>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(NT_CODENATURETIERS) AS NT_CODENATURETIERS  FROM dbo.FT_PHAPARNATURETIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(NT_CODENATURETIERS) AS NT_CODENATURETIERS  FROM dbo.FT_PHAPARNATURETIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(NT_CODENATURETIERS) AS NT_CODENATURETIERS  FROM dbo.FT_PHAPARNATURETIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparnaturetiers comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparnaturetiers pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TP_CODETYPETIERS  , NT_LIBELLE  , NT_DESCRIPTION  , NT_NUMEROORDRE  FROM dbo.FT_PHAPARNATURETIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparnaturetiers clsPhaparnaturetiers = new clsPhaparnaturetiers();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparnaturetiers.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					clsPhaparnaturetiers.NT_LIBELLE = clsDonnee.vogDataReader["NT_LIBELLE"].ToString();
					clsPhaparnaturetiers.NT_DESCRIPTION = clsDonnee.vogDataReader["NT_DESCRIPTION"].ToString();
					clsPhaparnaturetiers.NT_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NT_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparnaturetiers;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparnaturetiers>clsPhaparnaturetiers</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparnaturetiers clsPhaparnaturetiers)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
			vppParamTP_CODETYPETIERS.Value  = clsPhaparnaturetiers.TP_CODETYPETIERS ;
			SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 3);
			vppParamNT_CODENATURETIERS.Value  = clsPhaparnaturetiers.NT_CODENATURETIERS ;
			SqlParameter vppParamNT_LIBELLE = new SqlParameter("@NT_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNT_LIBELLE.Value  = clsPhaparnaturetiers.NT_LIBELLE ;
			SqlParameter vppParamNT_DESCRIPTION = new SqlParameter("@NT_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamNT_DESCRIPTION.Value  = clsPhaparnaturetiers.NT_DESCRIPTION ;

            SqlParameter vppParamNT_INVENTAIRE = new SqlParameter("@NT_INVENTAIRE", SqlDbType.VarChar, 1);
            vppParamNT_INVENTAIRE.Value = clsPhaparnaturetiers.NT_INVENTAIRE;

			SqlParameter vppParamNT_NUMEROORDRE = new SqlParameter("@NT_NUMEROORDRE", SqlDbType.SmallInt);
			vppParamNT_NUMEROORDRE.Value  = clsPhaparnaturetiers.NT_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARNATURETIERS  @TP_CODETYPETIERS, @NT_CODENATURETIERS, @NT_LIBELLE, @NT_DESCRIPTION,@NT_INVENTAIRE, @NT_NUMEROORDRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
			vppSqlCmd.Parameters.Add(vppParamNT_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamNT_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamNT_INVENTAIRE);
			vppSqlCmd.Parameters.Add(vppParamNT_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparnaturetiers>clsPhaparnaturetiers</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparnaturetiers clsPhaparnaturetiers,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPETIERS.Value = clsPhaparnaturetiers.TP_CODETYPETIERS;
            SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 3);
            vppParamNT_CODENATURETIERS.Value = clsPhaparnaturetiers.NT_CODENATURETIERS;
            SqlParameter vppParamNT_LIBELLE = new SqlParameter("@NT_LIBELLE", SqlDbType.VarChar, 150);
            vppParamNT_LIBELLE.Value = clsPhaparnaturetiers.NT_LIBELLE;
            SqlParameter vppParamNT_DESCRIPTION = new SqlParameter("@NT_DESCRIPTION", SqlDbType.VarChar, 150);
            vppParamNT_DESCRIPTION.Value = clsPhaparnaturetiers.NT_DESCRIPTION;

            SqlParameter vppParamNT_INVENTAIRE = new SqlParameter("@NT_INVENTAIRE", SqlDbType.VarChar, 1);
            vppParamNT_INVENTAIRE.Value = clsPhaparnaturetiers.NT_INVENTAIRE;

            SqlParameter vppParamNT_NUMEROORDRE = new SqlParameter("@NT_NUMEROORDRE", SqlDbType.SmallInt);
            vppParamNT_NUMEROORDRE.Value = clsPhaparnaturetiers.NT_NUMEROORDRE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARNATURETIERS  @TP_CODETYPETIERS, @NT_CODENATURETIERS, @NT_LIBELLE, @NT_DESCRIPTION,@NT_INVENTAIRE, @NT_NUMEROORDRE, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
            vppSqlCmd.Parameters.Add(vppParamNT_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamNT_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamNT_INVENTAIRE);
            vppSqlCmd.Parameters.Add(vppParamNT_NUMEROORDRE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARNATURETIERS  @TP_CODETYPETIERS, @NT_CODENATURETIERS, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparnaturetiers </returns>
		///<author>Home Technology</author>
		public List<clsPhaparnaturetiers> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TP_CODETYPETIERS, NT_CODENATURETIERS, NT_LIBELLE, NT_DESCRIPTION, NT_NUMEROORDRE FROM dbo.FT_PHAPARNATURETIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparnaturetiers> clsPhaparnaturetierss = new List<clsPhaparnaturetiers>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparnaturetiers clsPhaparnaturetiers = new clsPhaparnaturetiers();
					clsPhaparnaturetiers.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					clsPhaparnaturetiers.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
					clsPhaparnaturetiers.NT_LIBELLE = clsDonnee.vogDataReader["NT_LIBELLE"].ToString();
					clsPhaparnaturetiers.NT_DESCRIPTION = clsDonnee.vogDataReader["NT_DESCRIPTION"].ToString();
					clsPhaparnaturetiers.NT_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NT_NUMEROORDRE"].ToString());
					clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparnaturetierss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparnaturetiers </returns>
		///<author>Home Technology</author>
		public List<clsPhaparnaturetiers> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparnaturetiers> clsPhaparnaturetierss = new List<clsPhaparnaturetiers>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TP_CODETYPETIERS, NT_CODENATURETIERS, NT_LIBELLE, NT_DESCRIPTION, NT_NUMEROORDRE FROM dbo.FT_PHAPARNATURETIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparnaturetiers clsPhaparnaturetiers = new clsPhaparnaturetiers();
					clsPhaparnaturetiers.TP_CODETYPETIERS = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPETIERS"].ToString();
					clsPhaparnaturetiers.NT_CODENATURETIERS = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETIERS"].ToString();
					clsPhaparnaturetiers.NT_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["NT_LIBELLE"].ToString();
					clsPhaparnaturetiers.NT_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["NT_DESCRIPTION"].ToString();
					clsPhaparnaturetiers.NT_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["NT_NUMEROORDRE"].ToString());
					clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
				}
				Dataset.Dispose();
			}
		return clsPhaparnaturetierss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARNATURETIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NT_CODENATURETIERS , NT_LIBELLE FROM dbo.FT_PHAPARNATURETIERS(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TP_CODETYPETIERS, NT_CODENATURETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboEdition(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@TP_CODETYPETIERS" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0].Replace("''", "'") };

            this.vapRequete = "EXEC [dbo].[PS_COMBOPHAPARNATURETIERS] @TP_CODETYPETIERS,@CODECRYPTAGE " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }





		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TP_CODETYPETIERS, NT_CODENATURETIERS)</summary>
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
				this.vapCritere ="WHERE TP_CODETYPETIERS=@TP_CODETYPETIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TP_CODETYPETIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TP_CODETYPETIERS=@TP_CODETYPETIERS AND NT_CODENATURETIERS=@NT_CODENATURETIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TP_CODETYPETIERS","@NT_CODENATURETIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
