using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsProfildroitdetailWSDAL: ITableDAL<clsProfildroitdetail>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PO_CODEPROFIL) AS PO_CODEPROFIL  FROM dbo.FT_PROFILDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PO_CODEPROFIL) AS PO_CODEPROFIL  FROM dbo.FT_PROFILDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PO_CODEPROFIL) AS PO_CODEPROFIL  FROM dbo.FT_PROFILDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsProfildroitdetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsProfildroitdetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PD_AUTORISER  , PD_NUMEROORDRE  FROM dbo.FT_PROFILDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsProfildroitdetail clsProfildroitdetail = new clsProfildroitdetail();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsProfildroitdetail.PD_AUTORISER = clsDonnee.vogDataReader["PD_AUTORISER"].ToString();
					clsProfildroitdetail.PD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PD_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsProfildroitdetail;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsProfildroitdetail>clsProfildroitdetail</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsProfildroitdetail clsProfildroitdetail)
		{
			//Préparation des paramètres
			SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL1", SqlDbType.VarChar, 2);
			vppParamPO_CODEPROFIL.Value  = clsProfildroitdetail.PO_CODEPROFIL ;
			SqlParameter vppParamOP_CODEOBJET = new SqlParameter("@OP_CODEOBJET1", SqlDbType.VarChar, 25);
			vppParamOP_CODEOBJET.Value  = clsProfildroitdetail.OP_CODEOBJET ;
			SqlParameter vppParamPD_AUTORISER = new SqlParameter("@PD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamPD_AUTORISER.Value  = clsProfildroitdetail.PD_AUTORISER ;
			SqlParameter vppParamPD_NUMEROORDRE = new SqlParameter("@PD_NUMEROORDRE", SqlDbType.Int);
			vppParamPD_NUMEROORDRE.Value  = clsProfildroitdetail.PD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PROFILDROITDETAIL  @PO_CODEPROFIL1, @OP_CODEOBJET1, @PD_AUTORISER, @PD_NUMEROORDRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamPD_AUTORISER);
			vppSqlCmd.Parameters.Add(vppParamPD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsProfildroitdetail>clsProfildroitdetail</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsProfildroitdetail clsProfildroitdetail,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 2);
			vppParamPO_CODEPROFIL.Value  = clsProfildroitdetail.PO_CODEPROFIL ;
			SqlParameter vppParamOP_CODEOBJET = new SqlParameter("@OP_CODEOBJET", SqlDbType.VarChar, 25);
			vppParamOP_CODEOBJET.Value  = clsProfildroitdetail.OP_CODEOBJET ;
			SqlParameter vppParamPD_AUTORISER = new SqlParameter("@PD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamPD_AUTORISER.Value  = clsProfildroitdetail.PD_AUTORISER ;
			SqlParameter vppParamPD_NUMEROORDRE = new SqlParameter("@PD_NUMEROORDRE", SqlDbType.Int);
			vppParamPD_NUMEROORDRE.Value  = clsProfildroitdetail.PD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PROFILDROITDETAIL  @PO_CODEPROFIL, @OP_CODEOBJET, @PD_AUTORISER, @PD_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamPD_AUTORISER);
			vppSqlCmd.Parameters.Add(vppParamPD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PROFILDROITDETAIL  @PO_CODEPROFIL, @OP_CODEOBJET, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfildroitdetail </returns>
		///<author>Home Technology</author>
		public List<clsProfildroitdetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PO_CODEPROFIL, OP_CODEOBJET, PD_AUTORISER, PD_NUMEROORDRE FROM dbo.FT_PROFILDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsProfildroitdetail> clsProfildroitdetails = new List<clsProfildroitdetail>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsProfildroitdetail clsProfildroitdetail = new clsProfildroitdetail();
					clsProfildroitdetail.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString();
					clsProfildroitdetail.OP_CODEOBJET = clsDonnee.vogDataReader["OP_CODEOBJET"].ToString();
					clsProfildroitdetail.PD_AUTORISER = clsDonnee.vogDataReader["PD_AUTORISER"].ToString();
					clsProfildroitdetail.PD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PD_NUMEROORDRE"].ToString());
					clsProfildroitdetails.Add(clsProfildroitdetail);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsProfildroitdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfildroitdetail </returns>
		///<author>Home Technology</author>
		public List<clsProfildroitdetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsProfildroitdetail> clsProfildroitdetails = new List<clsProfildroitdetail>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PO_CODEPROFIL, OP_CODEOBJET, PD_AUTORISER, PD_NUMEROORDRE FROM dbo.FT_PROFILDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsProfildroitdetail clsProfildroitdetail = new clsProfildroitdetail();
					clsProfildroitdetail.PO_CODEPROFIL = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFIL"].ToString();
					clsProfildroitdetail.OP_CODEOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOBJET"].ToString();
					clsProfildroitdetail.PD_AUTORISER = Dataset.Tables["TABLE"].Rows[Idx]["PD_AUTORISER"].ToString();
					clsProfildroitdetail.PD_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PD_NUMEROORDRE"].ToString());
					clsProfildroitdetails.Add(clsProfildroitdetail);
				}
				Dataset.Dispose();
			}
		return clsProfildroitdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@PO_CODEPROFIL", "@OT_CODETYPEOBJET", "@OB_CODEOBJET" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = "SELECT *  FROM dbo.FC_PROFILDROITDETAIL(@PO_CODEPROFIL,@OT_CODETYPEOBJET,@OB_CODEOBJET) ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPROFIL, OP_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PO_CODEPROFIL , PD_AUTORISER FROM dbo.FT_PROFILDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PO_CODEPROFIL, OP_CODEOBJET)</summary>
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
				this.vapCritere ="WHERE PO_CODEPROFIL=@PO_CODEPROFIL";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PO_CODEPROFIL"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PO_CODEPROFIL=@PO_CODEPROFIL AND OP_CODEOBJET=@OP_CODEOBJET";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PO_CODEPROFIL","@OP_CODEOBJET"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
