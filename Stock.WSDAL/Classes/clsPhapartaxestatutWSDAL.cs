using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhapartaxestatutWSDAL: ITableDAL<clsPhapartaxestatut>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TA_CODETAXE) AS TA_CODETAXE  FROM dbo.FT_PHAPARTAXESTATUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TA_CODETAXE) AS TA_CODETAXE  FROM dbo.FT_PHAPARTAXESTATUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TA_CODETAXE) AS TA_CODETAXE  FROM dbo.FT_PHAPARTAXESTATUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapartaxestatut comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapartaxestatut pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ST_STATUT  , ST_LIBELLE  , ST_NUMEROORDRE  FROM dbo.FT_PHAPARTAXESTATUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhapartaxestatut clsPhapartaxestatut = new clsPhapartaxestatut();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartaxestatut.ST_STATUT = clsDonnee.vogDataReader["ST_STATUT"].ToString();
					clsPhapartaxestatut.ST_LIBELLE = clsDonnee.vogDataReader["ST_LIBELLE"].ToString();
					clsPhapartaxestatut.ST_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["ST_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhapartaxestatut;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartaxestatut>clsPhapartaxestatut</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhapartaxestatut clsPhapartaxestatut)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETAXE = new SqlParameter("@TA_CODETAXE", SqlDbType.VarChar, 3);
			vppParamTA_CODETAXE.Value  = clsPhapartaxestatut.TA_CODETAXE ;
			SqlParameter vppParamST_STATUT = new SqlParameter("@ST_STATUT", SqlDbType.VarChar, 1);
			vppParamST_STATUT.Value  = clsPhapartaxestatut.ST_STATUT ;
			SqlParameter vppParamST_LIBELLE = new SqlParameter("@ST_LIBELLE", SqlDbType.VarChar, 150);
			vppParamST_LIBELLE.Value  = clsPhapartaxestatut.ST_LIBELLE ;
			SqlParameter vppParamST_NUMEROORDRE = new SqlParameter("@ST_NUMEROORDRE", SqlDbType.Int);
			vppParamST_NUMEROORDRE.Value  = clsPhapartaxestatut.ST_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTAXESTATUT  @TA_CODETAXE, @ST_STATUT, @ST_LIBELLE, @ST_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETAXE);
			vppSqlCmd.Parameters.Add(vppParamST_STATUT);
			vppSqlCmd.Parameters.Add(vppParamST_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamST_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhapartaxestatut>clsPhapartaxestatut</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhapartaxestatut clsPhapartaxestatut,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTA_CODETAXE = new SqlParameter("@TA_CODETAXE", SqlDbType.VarChar, 3);
			vppParamTA_CODETAXE.Value  = clsPhapartaxestatut.TA_CODETAXE ;
			SqlParameter vppParamST_STATUT = new SqlParameter("@ST_STATUT", SqlDbType.VarChar, 1);
			vppParamST_STATUT.Value  = clsPhapartaxestatut.ST_STATUT ;
			SqlParameter vppParamST_LIBELLE = new SqlParameter("@ST_LIBELLE", SqlDbType.VarChar, 150);
			vppParamST_LIBELLE.Value  = clsPhapartaxestatut.ST_LIBELLE ;
			SqlParameter vppParamST_NUMEROORDRE = new SqlParameter("@ST_NUMEROORDRE", SqlDbType.Int);
			vppParamST_NUMEROORDRE.Value  = clsPhapartaxestatut.ST_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTAXESTATUT  @TA_CODETAXE, @ST_STATUT, @ST_LIBELLE, @ST_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTA_CODETAXE);
			vppSqlCmd.Parameters.Add(vppParamST_STATUT);
			vppSqlCmd.Parameters.Add(vppParamST_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamST_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARTAXESTATUT  @TA_CODETAXE, @ST_STATUT, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartaxestatut </returns>
		///<author>Home Technology</author>
		public List<clsPhapartaxestatut> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETAXE, ST_STATUT, ST_LIBELLE, ST_NUMEROORDRE FROM dbo.FT_PHAPARTAXESTATUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhapartaxestatut> clsPhapartaxestatuts = new List<clsPhapartaxestatut>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhapartaxestatut clsPhapartaxestatut = new clsPhapartaxestatut();
					clsPhapartaxestatut.TA_CODETAXE = clsDonnee.vogDataReader["TA_CODETAXE"].ToString();
					clsPhapartaxestatut.ST_STATUT = clsDonnee.vogDataReader["ST_STATUT"].ToString();
					clsPhapartaxestatut.ST_LIBELLE = clsDonnee.vogDataReader["ST_LIBELLE"].ToString();
					clsPhapartaxestatut.ST_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["ST_NUMEROORDRE"].ToString());
					clsPhapartaxestatuts.Add(clsPhapartaxestatut);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhapartaxestatuts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapartaxestatut </returns>
		///<author>Home Technology</author>
		public List<clsPhapartaxestatut> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhapartaxestatut> clsPhapartaxestatuts = new List<clsPhapartaxestatut>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TA_CODETAXE, ST_STATUT, ST_LIBELLE, ST_NUMEROORDRE FROM dbo.FT_PHAPARTAXESTATUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhapartaxestatut clsPhapartaxestatut = new clsPhapartaxestatut();
					clsPhapartaxestatut.TA_CODETAXE = Dataset.Tables["TABLE"].Rows[Idx]["TA_CODETAXE"].ToString();
					clsPhapartaxestatut.ST_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["ST_STATUT"].ToString();
					clsPhapartaxestatut.ST_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["ST_LIBELLE"].ToString();
					clsPhapartaxestatut.ST_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ST_NUMEROORDRE"].ToString());
					clsPhapartaxestatuts.Add(clsPhapartaxestatut);
				}
				Dataset.Dispose();
			}
		return clsPhapartaxestatuts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARTAXESTATUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TA_CODETAXE, ST_STATUT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT ST_STATUT , ST_LIBELLE FROM dbo.FT_PHAPARTAXESTATUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TA_CODETAXE, ST_STATUT)</summary>
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
				this.vapCritere ="WHERE TA_CODETAXE=@TA_CODETAXE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TA_CODETAXE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TA_CODETAXE=@TA_CODETAXE AND ST_STATUT=@ST_STATUT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TA_CODETAXE","@ST_STATUT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
