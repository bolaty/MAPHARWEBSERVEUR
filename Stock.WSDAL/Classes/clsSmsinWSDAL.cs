using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsSmsinWSDAL: ITableDAL<clsSmsin>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere(clsDonnee ,vppCritere);

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@COMPTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };

            this.vapRequete = "SELECT  dbo.[FC_SOLDECOMPTEPRECEDENTSMS](@COMPTE,@CODECRYPTAGE) ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere(clsDonnee ,vppCritere);
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@COMPTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
            this.vapRequete = "SELECT MIN(SOLDE) AS SOLDE FROM  dbo.[FC_SOLDECOMPTEPRECEDENTSMS](@COMPTE,@CODECRYPTAGE)  " ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(ST_DATEPIECE) AS ST_DATEPIECE  FROM dbo.FT_SMSIN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsSmsin comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsSmsin pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TE_CODESMSTYPEOPERATION  , ST_LOGIN  , ST_MOTPASSE  FROM dbo.FT_SMSIN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsSmsin clsSmsin = new clsSmsin();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSmsin.TE_CODESMSTYPEOPERATION = clsDonnee.vogDataReader["TE_CODESMSTYPEOPERATION"].ToString();
					clsSmsin.ST_LOGIN = clsDonnee.vogDataReader["ST_LOGIN"].ToString();
					clsSmsin.ST_MOTPASSE = clsDonnee.vogDataReader["ST_MOTPASSE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsSmsin;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSmsin>clsSmsin</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsSmsin clsSmsin)
		{
			//Préparation des paramètres
			SqlParameter vppParamST_DATEPIECE = new SqlParameter("@ST_DATEPIECE", SqlDbType.DateTime);
			vppParamST_DATEPIECE.Value  = clsSmsin.ST_DATEPIECE ;
			SqlParameter vppParamST_NUMPIECE = new SqlParameter("@ST_NUMPIECE", SqlDbType.VarChar, 20);
			vppParamST_NUMPIECE.Value  = clsSmsin.ST_NUMPIECE ;
			SqlParameter vppParamST_NUMSEQUENCE = new SqlParameter("@ST_NUMSEQUENCE", SqlDbType.VarChar, 20);
			vppParamST_NUMSEQUENCE.Value  = clsSmsin.ST_NUMSEQUENCE ;
			SqlParameter vppParamNUMEROCOMPTE = new SqlParameter("@NUMEROCOMPTE", SqlDbType.VarChar, 20);
			vppParamNUMEROCOMPTE.Value  = clsSmsin.NUMEROCOMPTE ;
			SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
			vppParamTE_CODESMSTYPEOPERATION.Value  = clsSmsin.TE_CODESMSTYPEOPERATION ;
			SqlParameter vppParamST_LOGIN = new SqlParameter("@ST_LOGIN", SqlDbType.VarChar, 1000);
			vppParamST_LOGIN.Value  = clsSmsin.ST_LOGIN ;
			SqlParameter vppParamST_MOTPASSE = new SqlParameter("@ST_MOTPASSE", SqlDbType.VarChar, 1000);
			vppParamST_MOTPASSE.Value  = clsSmsin.ST_MOTPASSE ;
            SqlParameter vppParamST_EMETTEUR = new SqlParameter("@ST_EMETTEUR", SqlDbType.VarChar, 1000);
            vppParamST_EMETTEUR.Value = clsSmsin.ST_EMETTEUR;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_SMSIN  @ST_DATEPIECE, @ST_NUMPIECE, @ST_NUMSEQUENCE, @NUMEROCOMPTE, @TE_CODESMSTYPEOPERATION, @ST_LOGIN, @ST_MOTPASSE, @ST_EMETTEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamST_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamST_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamST_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamNUMEROCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamST_LOGIN);
			vppSqlCmd.Parameters.Add(vppParamST_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamST_EMETTEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsSmsin>clsSmsin</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsSmsin clsSmsin,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamST_DATEPIECE = new SqlParameter("@ST_DATEPIECE", SqlDbType.DateTime);
			vppParamST_DATEPIECE.Value  = clsSmsin.ST_DATEPIECE ;
			SqlParameter vppParamST_NUMPIECE = new SqlParameter("@ST_NUMPIECE", SqlDbType.VarChar, 20);
			vppParamST_NUMPIECE.Value  = clsSmsin.ST_NUMPIECE ;
			SqlParameter vppParamST_NUMSEQUENCE = new SqlParameter("@ST_NUMSEQUENCE", SqlDbType.VarChar, 20);
			vppParamST_NUMSEQUENCE.Value  = clsSmsin.ST_NUMSEQUENCE ;
			SqlParameter vppParamNUMEROCOMPTE = new SqlParameter("@NUMEROCOMPTE", SqlDbType.VarChar, 20);
			vppParamNUMEROCOMPTE.Value  = clsSmsin.NUMEROCOMPTE ;
			SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
			vppParamTE_CODESMSTYPEOPERATION.Value  = clsSmsin.TE_CODESMSTYPEOPERATION ;
			SqlParameter vppParamST_LOGIN = new SqlParameter("@ST_LOGIN", SqlDbType.VarChar, 1000);
			vppParamST_LOGIN.Value  = clsSmsin.ST_LOGIN ;
			SqlParameter vppParamST_MOTPASSE = new SqlParameter("@ST_MOTPASSE", SqlDbType.VarChar, 1000);
			vppParamST_MOTPASSE.Value  = clsSmsin.ST_MOTPASSE ;
            SqlParameter vppParamST_EMETTEUR = new SqlParameter("@ST_EMETTEUR", SqlDbType.VarChar, 1000);
            vppParamST_EMETTEUR.Value = clsSmsin.ST_EMETTEUR;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_SMSIN  @ST_DATEPIECE, @ST_NUMPIECE, @ST_NUMSEQUENCE, @NUMEROCOMPTE, @TE_CODESMSTYPEOPERATION, @ST_LOGIN, @ST_MOTPASSE,@ST_EMETTEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamST_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamST_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamST_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamNUMEROCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamST_LOGIN);
			vppSqlCmd.Parameters.Add(vppParamST_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamST_EMETTEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_SMSIN  @ST_DATEPIECE, @ST_NUMPIECE, @ST_NUMSEQUENCE, @NUMEROCOMPTE, '' , '' , '', '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsin </returns>
		///<author>Home Technology</author>
		public List<clsSmsin> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE, TE_CODESMSTYPEOPERATION, ST_LOGIN, ST_MOTPASSE,ST_EMETTEUR FROM dbo.FT_SMSIN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsSmsin> clsSmsins = new List<clsSmsin>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsSmsin clsSmsin = new clsSmsin();
					clsSmsin.ST_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["ST_DATEPIECE"].ToString());
					clsSmsin.ST_NUMPIECE = clsDonnee.vogDataReader["ST_NUMPIECE"].ToString();
					clsSmsin.ST_NUMSEQUENCE = clsDonnee.vogDataReader["ST_NUMSEQUENCE"].ToString();
					clsSmsin.NUMEROCOMPTE = clsDonnee.vogDataReader["NUMEROCOMPTE"].ToString();
					clsSmsin.TE_CODESMSTYPEOPERATION = clsDonnee.vogDataReader["TE_CODESMSTYPEOPERATION"].ToString();
					clsSmsin.ST_LOGIN = clsDonnee.vogDataReader["ST_LOGIN"].ToString();
					clsSmsin.ST_MOTPASSE = clsDonnee.vogDataReader["ST_MOTPASSE"].ToString();
                    clsSmsin.ST_EMETTEUR = clsDonnee.vogDataReader["ST_EMETTEUR"].ToString();
					clsSmsins.Add(clsSmsin);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSmsins;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsin </returns>
		///<author>Home Technology</author>
		public List<clsSmsin> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSmsin> clsSmsins = new List<clsSmsin>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE, TE_CODESMSTYPEOPERATION, ST_LOGIN, ST_MOTPASSE,ST_EMETTEUR FROM dbo.FT_SMSIN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsSmsin clsSmsin = new clsSmsin();
					clsSmsin.ST_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ST_DATEPIECE"].ToString());
					clsSmsin.ST_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["ST_NUMPIECE"].ToString();
					clsSmsin.ST_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["ST_NUMSEQUENCE"].ToString();
					clsSmsin.NUMEROCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["NUMEROCOMPTE"].ToString();
					clsSmsin.TE_CODESMSTYPEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["TE_CODESMSTYPEOPERATION"].ToString();
					clsSmsin.ST_LOGIN = Dataset.Tables["TABLE"].Rows[Idx]["ST_LOGIN"].ToString();
					clsSmsin.ST_MOTPASSE = Dataset.Tables["TABLE"].Rows[Idx]["ST_MOTPASSE"].ToString();
                    clsSmsin.ST_EMETTEUR = Dataset.Tables["TABLE"].Rows[Idx]["ST_EMETTEUR"].ToString();
					clsSmsins.Add(clsSmsin);
				}
				Dataset.Dispose();
			}
		return clsSmsins;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_SMSIN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT ST_DATEPIECE , TE_CODESMSTYPEOPERATION FROM dbo.FT_SMSIN(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :ST_DATEPIECE, ST_NUMPIECE, ST_NUMSEQUENCE, NUMEROCOMPTE)</summary>
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
				this.vapCritere ="WHERE ST_DATEPIECE=@ST_DATEPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ST_DATEPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE ST_DATEPIECE=@ST_DATEPIECE AND ST_NUMPIECE=@ST_NUMPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ST_DATEPIECE","@ST_NUMPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE ST_DATEPIECE=@ST_DATEPIECE AND ST_NUMPIECE=@ST_NUMPIECE AND ST_NUMSEQUENCE=@ST_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ST_DATEPIECE","@ST_NUMPIECE","@ST_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE ST_DATEPIECE=@ST_DATEPIECE AND ST_NUMPIECE=@ST_NUMPIECE AND ST_NUMSEQUENCE=@ST_NUMSEQUENCE AND NUMEROCOMPTE=@NUMEROCOMPTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@ST_DATEPIECE","@ST_NUMPIECE","@ST_NUMSEQUENCE","@NUMEROCOMPTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
