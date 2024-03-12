using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsTresorerieparampostetresorerieWSDAL: ITableDAL<clsTresorerieparampostetresorerie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TP_CODEPOSTETRESORERIE) AS TP_CODEPOSTETRESORERIE  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsTresorerieparampostetresorerie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsTresorerieparampostetresorerie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TR_CODERUBRIQUETRESORERIE  , TN_CODENATUREPOSTETRESORERIE  , TV_CODETVA  , TP_LIBELLE  , TP_TAUX  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsTresorerieparampostetresorerie clsTresorerieparampostetresorerie = new clsTresorerieparampostetresorerie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTresorerieparampostetresorerie.TR_CODERUBRIQUETRESORERIE = clsDonnee.vogDataReader["TR_CODERUBRIQUETRESORERIE"].ToString();
					clsTresorerieparampostetresorerie.TN_CODENATUREPOSTETRESORERIE = clsDonnee.vogDataReader["TN_CODENATUREPOSTETRESORERIE"].ToString();
					clsTresorerieparampostetresorerie.TV_CODETVA = clsDonnee.vogDataReader["TV_CODETVA"].ToString();
					clsTresorerieparampostetresorerie.TP_LIBELLE = clsDonnee.vogDataReader["TP_LIBELLE"].ToString();
					clsTresorerieparampostetresorerie.TP_TAUX = decimal.Parse(clsDonnee.vogDataReader["TP_TAUX"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsTresorerieparampostetresorerie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieparampostetresorerie>clsTresorerieparampostetresorerie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsTresorerieparampostetresorerie clsTresorerieparampostetresorerie)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_CODEPOSTETRESORERIE = new SqlParameter("@TP_CODEPOSTETRESORERIE", SqlDbType.VarChar, 7);
			vppParamTP_CODEPOSTETRESORERIE.Value  = clsTresorerieparampostetresorerie.TP_CODEPOSTETRESORERIE ;
			SqlParameter vppParamTR_CODERUBRIQUETRESORERIE = new SqlParameter("@TR_CODERUBRIQUETRESORERIE", SqlDbType.VarChar, 4);
			vppParamTR_CODERUBRIQUETRESORERIE.Value  = clsTresorerieparampostetresorerie.TR_CODERUBRIQUETRESORERIE ;
			SqlParameter vppParamTN_CODENATUREPOSTETRESORERIE = new SqlParameter("@TN_CODENATUREPOSTETRESORERIE", SqlDbType.VarChar, 3);
			vppParamTN_CODENATUREPOSTETRESORERIE.Value  = clsTresorerieparampostetresorerie.TN_CODENATUREPOSTETRESORERIE ;
			SqlParameter vppParamTV_CODETVA = new SqlParameter("@TV_CODETVA", SqlDbType.VarChar, 25);
			vppParamTV_CODETVA.Value  = clsTresorerieparampostetresorerie.TV_CODETVA ;
			if(clsTresorerieparampostetresorerie.TV_CODETVA== ""  ) vppParamTV_CODETVA.Value  = DBNull.Value;
			SqlParameter vppParamTP_LIBELLE = new SqlParameter("@TP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTP_LIBELLE.Value  = clsTresorerieparampostetresorerie.TP_LIBELLE ;
            if(clsTresorerieparampostetresorerie.TP_LIBELLE == ""  ) vppParamTP_LIBELLE.Value  = DBNull.Value;


			SqlParameter vppParamTP_TAUX = new SqlParameter("@TP_TAUX", SqlDbType.Decimal, 4);
			vppParamTP_TAUX.Value  = clsTresorerieparampostetresorerie.TP_TAUX ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMPOSTETRESORERIE  @TP_CODEPOSTETRESORERIE, @TR_CODERUBRIQUETRESORERIE, @TN_CODENATUREPOSTETRESORERIE, @TV_CODETVA, @TP_LIBELLE, @TP_TAUX, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_CODEPOSTETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTR_CODERUBRIQUETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTN_CODENATUREPOSTETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTV_CODETVA);
			vppSqlCmd.Parameters.Add(vppParamTP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTP_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieparampostetresorerie>clsTresorerieparampostetresorerie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsTresorerieparampostetresorerie clsTresorerieparampostetresorerie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTP_CODEPOSTETRESORERIE = new SqlParameter("@TP_CODEPOSTETRESORERIE", SqlDbType.VarChar, 7);
			vppParamTP_CODEPOSTETRESORERIE.Value  = clsTresorerieparampostetresorerie.TP_CODEPOSTETRESORERIE ;
			SqlParameter vppParamTR_CODERUBRIQUETRESORERIE = new SqlParameter("@TR_CODERUBRIQUETRESORERIE", SqlDbType.VarChar, 4);
			vppParamTR_CODERUBRIQUETRESORERIE.Value  = clsTresorerieparampostetresorerie.TR_CODERUBRIQUETRESORERIE ;
			SqlParameter vppParamTN_CODENATUREPOSTETRESORERIE = new SqlParameter("@TN_CODENATUREPOSTETRESORERIE", SqlDbType.VarChar, 3);
			vppParamTN_CODENATUREPOSTETRESORERIE.Value  = clsTresorerieparampostetresorerie.TN_CODENATUREPOSTETRESORERIE ;
			SqlParameter vppParamTV_CODETVA = new SqlParameter("@TV_CODETVA", SqlDbType.VarChar, 25);
			vppParamTV_CODETVA.Value  = clsTresorerieparampostetresorerie.TV_CODETVA ;
			if(clsTresorerieparampostetresorerie.TV_CODETVA== ""  ) vppParamTV_CODETVA.Value  = DBNull.Value;
			SqlParameter vppParamTP_LIBELLE = new SqlParameter("@TP_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTP_LIBELLE.Value  = clsTresorerieparampostetresorerie.TP_LIBELLE ;
            if (clsTresorerieparampostetresorerie.TP_LIBELLE == "") vppParamTP_LIBELLE.Value = DBNull.Value;
            SqlParameter vppParamTP_TAUX = new SqlParameter("@TP_TAUX", SqlDbType.Decimal, 4);
			vppParamTP_TAUX.Value  = clsTresorerieparampostetresorerie.TP_TAUX ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMPOSTETRESORERIE  @TP_CODEPOSTETRESORERIE, @TR_CODERUBRIQUETRESORERIE, @TN_CODENATUREPOSTETRESORERIE, @TV_CODETVA, @TP_LIBELLE, @TP_TAUX, @CODECRYPTAGE1, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTP_CODEPOSTETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTR_CODERUBRIQUETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTN_CODENATUREPOSTETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTV_CODETVA);
			vppSqlCmd.Parameters.Add(vppParamTP_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTP_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMPOSTETRESORERIE  @TP_CODEPOSTETRESORERIE, '', '', 0, '' , '0' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieparampostetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparampostetresorerie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA, TP_LIBELLE, TP_TAUX FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsTresorerieparampostetresorerie> clsTresorerieparampostetresoreries = new List<clsTresorerieparampostetresorerie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTresorerieparampostetresorerie clsTresorerieparampostetresorerie = new clsTresorerieparampostetresorerie();
					clsTresorerieparampostetresorerie.TP_CODEPOSTETRESORERIE = clsDonnee.vogDataReader["TP_CODEPOSTETRESORERIE"].ToString();
					clsTresorerieparampostetresorerie.TR_CODERUBRIQUETRESORERIE = clsDonnee.vogDataReader["TR_CODERUBRIQUETRESORERIE"].ToString();
					clsTresorerieparampostetresorerie.TN_CODENATUREPOSTETRESORERIE = clsDonnee.vogDataReader["TN_CODENATUREPOSTETRESORERIE"].ToString();
					clsTresorerieparampostetresorerie.TV_CODETVA = clsDonnee.vogDataReader["TV_CODETVA"].ToString();
					clsTresorerieparampostetresorerie.TP_LIBELLE = clsDonnee.vogDataReader["TP_LIBELLE"].ToString();
					clsTresorerieparampostetresorerie.TP_TAUX = decimal.Parse(clsDonnee.vogDataReader["TP_TAUX"].ToString());
					clsTresorerieparampostetresoreries.Add(clsTresorerieparampostetresorerie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsTresorerieparampostetresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieparampostetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparampostetresorerie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsTresorerieparampostetresorerie> clsTresorerieparampostetresoreries = new List<clsTresorerieparampostetresorerie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA, TP_LIBELLE, TP_TAUX FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsTresorerieparampostetresorerie clsTresorerieparampostetresorerie = new clsTresorerieparampostetresorerie();
					clsTresorerieparampostetresorerie.TP_CODEPOSTETRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODEPOSTETRESORERIE"].ToString();
					clsTresorerieparampostetresorerie.TR_CODERUBRIQUETRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TR_CODERUBRIQUETRESORERIE"].ToString();
					clsTresorerieparampostetresorerie.TN_CODENATUREPOSTETRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TN_CODENATUREPOSTETRESORERIE"].ToString();
					clsTresorerieparampostetresorerie.TV_CODETVA = Dataset.Tables["TABLE"].Rows[Idx]["TV_CODETVA"].ToString();
					clsTresorerieparampostetresorerie.TP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TP_LIBELLE"].ToString();
					clsTresorerieparampostetresorerie.TP_TAUX = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TP_TAUX"].ToString());
					clsTresorerieparampostetresoreries.Add(clsTresorerieparampostetresorerie);
				}
				Dataset.Dispose();
			}
		return clsTresorerieparampostetresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY TR_LIBELLE ,TP_LIBELLE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TP_CODEPOSTETRESORERIE , TP_LIBELLE FROM dbo.FT_TRESORERIEPARAMPOSTETRESORERIE(@CODECRYPTAGE) " + this.vapCritere+ " ORDER BY TP_LIBELLE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TP_CODEPOSTETRESORERIE, TR_CODERUBRIQUETRESORERIE, TN_CODENATUREPOSTETRESORERIE, TV_CODETVA)</summary>
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
				this.vapCritere ="WHERE TP_CODEPOSTETRESORERIE=@TP_CODEPOSTETRESORERIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TP_CODEPOSTETRESORERIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TP_CODEPOSTETRESORERIE=@TP_CODEPOSTETRESORERIE AND TR_CODERUBRIQUETRESORERIE=@TR_CODERUBRIQUETRESORERIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TP_CODEPOSTETRESORERIE","@TR_CODERUBRIQUETRESORERIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE TP_CODEPOSTETRESORERIE=@TP_CODEPOSTETRESORERIE AND TR_CODERUBRIQUETRESORERIE=@TR_CODERUBRIQUETRESORERIE AND TN_CODENATUREPOSTETRESORERIE=@TN_CODENATUREPOSTETRESORERIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TP_CODEPOSTETRESORERIE","@TR_CODERUBRIQUETRESORERIE","@TN_CODENATUREPOSTETRESORERIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE TP_CODEPOSTETRESORERIE=@TP_CODEPOSTETRESORERIE AND TR_CODERUBRIQUETRESORERIE=@TR_CODERUBRIQUETRESORERIE AND TN_CODENATUREPOSTETRESORERIE=@TN_CODENATUREPOSTETRESORERIE AND TV_CODETVA=@TV_CODETVA";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TP_CODEPOSTETRESORERIE","@TR_CODERUBRIQUETRESORERIE","@TN_CODENATUREPOSTETRESORERIE","@TV_CODETVA"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
