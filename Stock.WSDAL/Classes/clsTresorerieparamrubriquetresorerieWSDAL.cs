using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsTresorerieparamrubriquetresorerieWSDAL: ITableDAL<clsTresorerieparamrubriquetresorerie>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TR_CODERUBRIQUETRESORERIE) AS TR_CODERUBRIQUETRESORERIE  FROM dbo.FT_TRESORERIEPARAMRUBRIQUETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TR_CODERUBRIQUETRESORERIE) AS TR_CODERUBRIQUETRESORERIE  FROM dbo.FT_TRESORERIEPARAMRUBRIQUETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TR_CODERUBRIQUETRESORERIE) AS TR_CODERUBRIQUETRESORERIE  FROM dbo.FT_TRESORERIEPARAMRUBRIQUETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsTresorerieparamrubriquetresorerie comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsTresorerieparamrubriquetresorerie pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TE_CODEEXPLOITATION  , TR_LIBELLE  , TR_NUMEROORDRE  FROM dbo.FT_TRESORERIEPARAMRUBRIQUETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsTresorerieparamrubriquetresorerie clsTresorerieparamrubriquetresorerie = new clsTresorerieparamrubriquetresorerie();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTresorerieparamrubriquetresorerie.TE_CODEEXPLOITATION = clsDonnee.vogDataReader["TE_CODEEXPLOITATION"].ToString();
					clsTresorerieparamrubriquetresorerie.TR_LIBELLE = clsDonnee.vogDataReader["TR_LIBELLE"].ToString();
					clsTresorerieparamrubriquetresorerie.TR_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TR_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsTresorerieparamrubriquetresorerie;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieparamrubriquetresorerie>clsTresorerieparamrubriquetresorerie</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsTresorerieparamrubriquetresorerie clsTresorerieparamrubriquetresorerie)
		{
			//Préparation des paramètres
			SqlParameter vppParamTR_CODERUBRIQUETRESORERIE = new SqlParameter("@TR_CODERUBRIQUETRESORERIE", SqlDbType.VarChar, 4);
			vppParamTR_CODERUBRIQUETRESORERIE.Value  = clsTresorerieparamrubriquetresorerie.TR_CODERUBRIQUETRESORERIE ;
			SqlParameter vppParamTE_CODEEXPLOITATION = new SqlParameter("@TE_CODEEXPLOITATION", SqlDbType.TinyInt);
			vppParamTE_CODEEXPLOITATION.Value  = clsTresorerieparamrubriquetresorerie.TE_CODEEXPLOITATION ;
			if(clsTresorerieparamrubriquetresorerie.TE_CODEEXPLOITATION== ""  ) vppParamTE_CODEEXPLOITATION.Value  = DBNull.Value;
			SqlParameter vppParamTR_LIBELLE = new SqlParameter("@TR_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTR_LIBELLE.Value  = clsTresorerieparamrubriquetresorerie.TR_LIBELLE ;

            SqlParameter vppParamTF_CODEFORMULE = new SqlParameter("@TF_CODEFORMULE", SqlDbType.VarChar,3);
            vppParamTF_CODEFORMULE.Value  = clsTresorerieparamrubriquetresorerie.TF_CODEFORMULE;

			SqlParameter vppParamTR_NUMEROORDRE = new SqlParameter("@TR_NUMEROORDRE", SqlDbType.Int);
			vppParamTR_NUMEROORDRE.Value  = clsTresorerieparamrubriquetresorerie.TR_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMRUBRIQUETRESORERIE  @TR_CODERUBRIQUETRESORERIE, @TE_CODEEXPLOITATION, @TR_LIBELLE,@TF_CODEFORMULE, @TR_NUMEROORDRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTR_CODERUBRIQUETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTE_CODEEXPLOITATION);
			vppSqlCmd.Parameters.Add(vppParamTR_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamTF_CODEFORMULE);
			vppSqlCmd.Parameters.Add(vppParamTR_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsTresorerieparamrubriquetresorerie>clsTresorerieparamrubriquetresorerie</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsTresorerieparamrubriquetresorerie clsTresorerieparamrubriquetresorerie,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTR_CODERUBRIQUETRESORERIE = new SqlParameter("@TR_CODERUBRIQUETRESORERIE", SqlDbType.VarChar, 4);
			vppParamTR_CODERUBRIQUETRESORERIE.Value  = clsTresorerieparamrubriquetresorerie.TR_CODERUBRIQUETRESORERIE ;
			SqlParameter vppParamTE_CODEEXPLOITATION = new SqlParameter("@TE_CODEEXPLOITATION", SqlDbType.TinyInt);
			vppParamTE_CODEEXPLOITATION.Value  = clsTresorerieparamrubriquetresorerie.TE_CODEEXPLOITATION ;
			if(clsTresorerieparamrubriquetresorerie.TE_CODEEXPLOITATION== ""  ) vppParamTE_CODEEXPLOITATION.Value  = DBNull.Value;
			SqlParameter vppParamTR_LIBELLE = new SqlParameter("@TR_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTR_LIBELLE.Value  = clsTresorerieparamrubriquetresorerie.TR_LIBELLE ;

			SqlParameter vppParamTF_CODEFORMULE = new SqlParameter("@TF_CODEFORMULE", SqlDbType.VarChar, 3);
            vppParamTF_CODEFORMULE.Value  = clsTresorerieparamrubriquetresorerie.TF_CODEFORMULE;

			SqlParameter vppParamTR_NUMEROORDRE = new SqlParameter("@TR_NUMEROORDRE", SqlDbType.Int);
			vppParamTR_NUMEROORDRE.Value  = clsTresorerieparamrubriquetresorerie.TR_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMRUBRIQUETRESORERIE  @TR_CODERUBRIQUETRESORERIE, @TE_CODEEXPLOITATION, @TR_LIBELLE,@TF_CODEFORMULE, @TR_NUMEROORDRE, @CODECRYPTAGE1, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTR_CODERUBRIQUETRESORERIE);
			vppSqlCmd.Parameters.Add(vppParamTE_CODEEXPLOITATION);
			vppSqlCmd.Parameters.Add(vppParamTR_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamTF_CODEFORMULE);
			vppSqlCmd.Parameters.Add(vppParamTR_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_TRESORERIEPARAMRUBRIQUETRESORERIE  @TR_CODERUBRIQUETRESORERIE, '', '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieparamrubriquetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparamrubriquetresorerie> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION, TR_LIBELLE, TR_NUMEROORDRE FROM dbo.FT_TRESORERIEPARAMRUBRIQUETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsTresorerieparamrubriquetresorerie> clsTresorerieparamrubriquetresoreries = new List<clsTresorerieparamrubriquetresorerie>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsTresorerieparamrubriquetresorerie clsTresorerieparamrubriquetresorerie = new clsTresorerieparamrubriquetresorerie();
					clsTresorerieparamrubriquetresorerie.TR_CODERUBRIQUETRESORERIE = clsDonnee.vogDataReader["TR_CODERUBRIQUETRESORERIE"].ToString();
					clsTresorerieparamrubriquetresorerie.TE_CODEEXPLOITATION =clsDonnee.vogDataReader["TE_CODEEXPLOITATION"].ToString();
					clsTresorerieparamrubriquetresorerie.TR_LIBELLE = clsDonnee.vogDataReader["TR_LIBELLE"].ToString();
					clsTresorerieparamrubriquetresorerie.TR_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["TR_NUMEROORDRE"].ToString());
					clsTresorerieparamrubriquetresoreries.Add(clsTresorerieparamrubriquetresorerie);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsTresorerieparamrubriquetresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsTresorerieparamrubriquetresorerie </returns>
		///<author>Home Technology</author>
		public List<clsTresorerieparamrubriquetresorerie> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsTresorerieparamrubriquetresorerie> clsTresorerieparamrubriquetresoreries = new List<clsTresorerieparamrubriquetresorerie>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION, TR_LIBELLE, TR_NUMEROORDRE FROM dbo.FT_TRESORERIEPARAMRUBRIQUETRESORERIE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsTresorerieparamrubriquetresorerie clsTresorerieparamrubriquetresorerie = new clsTresorerieparamrubriquetresorerie();
					clsTresorerieparamrubriquetresorerie.TR_CODERUBRIQUETRESORERIE = Dataset.Tables["TABLE"].Rows[Idx]["TR_CODERUBRIQUETRESORERIE"].ToString();
					clsTresorerieparamrubriquetresorerie.TE_CODEEXPLOITATION = Dataset.Tables["TABLE"].Rows[Idx]["TE_CODEEXPLOITATION"].ToString();
					clsTresorerieparamrubriquetresorerie.TR_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TR_LIBELLE"].ToString();
					clsTresorerieparamrubriquetresorerie.TR_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TR_NUMEROORDRE"].ToString());
					clsTresorerieparamrubriquetresoreries.Add(clsTresorerieparamrubriquetresorerie);
				}
				Dataset.Dispose();
			}
		return clsTresorerieparamrubriquetresoreries;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_TRESORERIEPARAMRUBRIQUETRESORERIE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY TR_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TR_CODERUBRIQUETRESORERIE , TR_LIBELLE FROM dbo.FT_TRESORERIEPARAMRUBRIQUETRESORERIE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY TR_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TR_CODERUBRIQUETRESORERIE, TE_CODEEXPLOITATION)</summary>
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
				this.vapCritere ="WHERE TR_CODERUBRIQUETRESORERIE=@TR_CODERUBRIQUETRESORERIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TR_CODERUBRIQUETRESORERIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TR_CODERUBRIQUETRESORERIE=@TR_CODERUBRIQUETRESORERIE AND TE_CODEEXPLOITATION=@TE_CODEEXPLOITATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TR_CODERUBRIQUETRESORERIE","@TE_CODEEXPLOITATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
