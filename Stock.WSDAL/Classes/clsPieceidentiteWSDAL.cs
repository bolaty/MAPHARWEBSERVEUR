using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPieceidentiteWSDAL: ITableDAL<clsPieceidentite>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PI_CODEPIECE) AS PI_CODEPIECE  FROM dbo.FT_PIECEIDENTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PI_CODEPIECE) AS PI_CODEPIECE  FROM dbo.FT_PIECEIDENTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PI_CODEPIECE) AS PI_CODEPIECE  FROM dbo.FT_PIECEIDENTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPieceidentite comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPieceidentite pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PI_PIECECODE  , PI_LIBELLEPIECE  , PI_DUREEPIECE  FROM dbo.FT_PIECEIDENTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPieceidentite clsPieceidentite = new clsPieceidentite();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPieceidentite.PI_PIECECODE = clsDonnee.vogDataReader["PI_PIECECODE"].ToString();
					clsPieceidentite.PI_LIBELLEPIECE = clsDonnee.vogDataReader["PI_LIBELLEPIECE"].ToString();
					clsPieceidentite.PI_DUREEPIECE = int.Parse(clsDonnee.vogDataReader["PI_DUREEPIECE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPieceidentite;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPieceidentite>clsPieceidentite</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPieceidentite clsPieceidentite)
		{
			//Préparation des paramètres
			SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
			vppParamPI_CODEPIECE.Value  = clsPieceidentite.PI_CODEPIECE ;
			SqlParameter vppParamPI_PIECECODE = new SqlParameter("@PI_PIECECODE", SqlDbType.VarChar, 5);
			vppParamPI_PIECECODE.Value  = clsPieceidentite.PI_PIECECODE ;
			SqlParameter vppParamPI_LIBELLEPIECE = new SqlParameter("@PI_LIBELLEPIECE", SqlDbType.VarChar, 50);
			vppParamPI_LIBELLEPIECE.Value  = clsPieceidentite.PI_LIBELLEPIECE ;
			SqlParameter vppParamPI_DUREEPIECE = new SqlParameter("@PI_DUREEPIECE", SqlDbType.Int);
			vppParamPI_DUREEPIECE.Value  = clsPieceidentite.PI_DUREEPIECE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PIECEIDENTITE  @PI_CODEPIECE, @PI_PIECECODE, @PI_LIBELLEPIECE, @PI_DUREEPIECE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
			vppSqlCmd.Parameters.Add(vppParamPI_PIECECODE);
			vppSqlCmd.Parameters.Add(vppParamPI_LIBELLEPIECE);
			vppSqlCmd.Parameters.Add(vppParamPI_DUREEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPieceidentite>clsPieceidentite</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPieceidentite clsPieceidentite,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
			vppParamPI_CODEPIECE.Value  = clsPieceidentite.PI_CODEPIECE ;
			SqlParameter vppParamPI_PIECECODE = new SqlParameter("@PI_PIECECODE", SqlDbType.VarChar, 5);
			vppParamPI_PIECECODE.Value  = clsPieceidentite.PI_PIECECODE ;
			SqlParameter vppParamPI_LIBELLEPIECE = new SqlParameter("@PI_LIBELLEPIECE", SqlDbType.VarChar, 50);
			vppParamPI_LIBELLEPIECE.Value  = clsPieceidentite.PI_LIBELLEPIECE ;
			SqlParameter vppParamPI_DUREEPIECE = new SqlParameter("@PI_DUREEPIECE", SqlDbType.Int);
			vppParamPI_DUREEPIECE.Value  = clsPieceidentite.PI_DUREEPIECE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PIECEIDENTITE  @PI_CODEPIECE, @PI_PIECECODE, @PI_LIBELLEPIECE, @PI_DUREEPIECE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
			vppSqlCmd.Parameters.Add(vppParamPI_PIECECODE);
			vppSqlCmd.Parameters.Add(vppParamPI_LIBELLEPIECE);
			vppSqlCmd.Parameters.Add(vppParamPI_DUREEPIECE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PIECEIDENTITE  @PI_CODEPIECE, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPieceidentite </returns>
		///<author>Home Technology</author>
		public List<clsPieceidentite> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PI_CODEPIECE, PI_PIECECODE, PI_LIBELLEPIECE, PI_DUREEPIECE FROM dbo.FT_PIECEIDENTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPieceidentite> clsPieceidentites = new List<clsPieceidentite>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPieceidentite clsPieceidentite = new clsPieceidentite();
					clsPieceidentite.PI_CODEPIECE = clsDonnee.vogDataReader["PI_CODEPIECE"].ToString();
					clsPieceidentite.PI_PIECECODE = clsDonnee.vogDataReader["PI_PIECECODE"].ToString();
					clsPieceidentite.PI_LIBELLEPIECE = clsDonnee.vogDataReader["PI_LIBELLEPIECE"].ToString();
					clsPieceidentite.PI_DUREEPIECE = int.Parse(clsDonnee.vogDataReader["PI_DUREEPIECE"].ToString());
					clsPieceidentites.Add(clsPieceidentite);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPieceidentites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPieceidentite </returns>
		///<author>Home Technology</author>
		public List<clsPieceidentite> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPieceidentite> clsPieceidentites = new List<clsPieceidentite>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PI_CODEPIECE, PI_PIECECODE, PI_LIBELLEPIECE, PI_DUREEPIECE FROM dbo.FT_PIECEIDENTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPieceidentite clsPieceidentite = new clsPieceidentite();
					clsPieceidentite.PI_CODEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["PI_CODEPIECE"].ToString();
					clsPieceidentite.PI_PIECECODE = Dataset.Tables["TABLE"].Rows[Idx]["PI_PIECECODE"].ToString();
					clsPieceidentite.PI_LIBELLEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["PI_LIBELLEPIECE"].ToString();
					clsPieceidentite.PI_DUREEPIECE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PI_DUREEPIECE"].ToString());
					clsPieceidentites.Add(clsPieceidentite);
				}
				Dataset.Dispose();
			}
		return clsPieceidentites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PIECEIDENTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT PI_CODEPIECE , PI_LIBELLEPIECE FROM dbo.FT_PIECEIDENTITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PI_CODEPIECE)</summary>
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
				this.vapCritere ="WHERE PI_CODEPIECE=@PI_CODEPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PI_CODEPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
