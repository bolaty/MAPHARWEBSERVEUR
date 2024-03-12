using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBusinessplanparamposteWSDAL: ITableDAL<clsBusinessplanparamposte>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PO_CODEPOSTEBUSINESSPLAN) AS PO_CODEPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PO_CODEPOSTEBUSINESSPLAN) AS PO_CODEPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PO_CODEPOSTEBUSINESSPLAN) AS PO_CODEPOSTEBUSINESSPLAN  FROM dbo.FT_BUSINESSPLANPARAMPOSTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBusinessplanparamposte comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBusinessplanparamposte pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PD_CODEDOCUMENTDETAIL  , PN_CODENATUREPOSTEBUSINESSPLAN  , PP_CODEPOLICE  , PS_CODESIGNE  , PO_TAUX  , PO_LIBELLE  , PO_NUMEROORDRE  FROM dbo.FT_BUSINESSPLANPARAMPOSTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBusinessplanparamposte clsBusinessplanparamposte = new clsBusinessplanparamposte();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparamposte.PD_CODEDOCUMENTDETAIL = clsDonnee.vogDataReader["PD_CODEDOCUMENTDETAIL"].ToString();
					clsBusinessplanparamposte.PN_CODENATUREPOSTEBUSINESSPLAN = clsDonnee.vogDataReader["PN_CODENATUREPOSTEBUSINESSPLAN"].ToString();
					clsBusinessplanparamposte.PP_CODEPOLICE = clsDonnee.vogDataReader["PP_CODEPOLICE"].ToString();
					clsBusinessplanparamposte.PS_CODESIGNE = clsDonnee.vogDataReader["PS_CODESIGNE"].ToString();
					clsBusinessplanparamposte.PO_TAUX = decimal.Parse(clsDonnee.vogDataReader["PO_TAUX"].ToString());
					clsBusinessplanparamposte.PO_LIBELLE = clsDonnee.vogDataReader["PO_LIBELLE"].ToString();
					clsBusinessplanparamposte.PO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PO_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBusinessplanparamposte;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparamposte>clsBusinessplanparamposte</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBusinessplanparamposte clsBusinessplanparamposte)
		{
			//Préparation des paramètres
			SqlParameter vppParamPO_CODEPOSTEBUSINESSPLAN = new SqlParameter("@PO_CODEPOSTEBUSINESSPLAN1", SqlDbType.VarChar, 7);
			vppParamPO_CODEPOSTEBUSINESSPLAN.Value  = clsBusinessplanparamposte.PO_CODEPOSTEBUSINESSPLAN ;
			SqlParameter vppParamPD_CODEDOCUMENTDETAIL = new SqlParameter("@PD_CODEDOCUMENTDETAIL1", SqlDbType.VarChar, 5);
			vppParamPD_CODEDOCUMENTDETAIL.Value  = clsBusinessplanparamposte.PD_CODEDOCUMENTDETAIL ;
			SqlParameter vppParamPN_CODENATUREPOSTEBUSINESSPLAN = new SqlParameter("@PN_CODENATUREPOSTEBUSINESSPLAN1", SqlDbType.VarChar, 3);
			vppParamPN_CODENATUREPOSTEBUSINESSPLAN.Value  = clsBusinessplanparamposte.PN_CODENATUREPOSTEBUSINESSPLAN ;
			SqlParameter vppParamPP_CODEPOLICE = new SqlParameter("@PP_CODEPOLICE", SqlDbType.VarChar, 3);
			vppParamPP_CODEPOLICE.Value  = clsBusinessplanparamposte.PP_CODEPOLICE ;
			SqlParameter vppParamPS_CODESIGNE = new SqlParameter("@PS_CODESIGNE", SqlDbType.VarChar, 3);
			vppParamPS_CODESIGNE.Value  = clsBusinessplanparamposte.PS_CODESIGNE ;
			SqlParameter vppParamPO_TAUX = new SqlParameter("@PO_TAUX", SqlDbType.Decimal, 4);
			vppParamPO_TAUX.Value  = clsBusinessplanparamposte.PO_TAUX ;
			SqlParameter vppParamPO_LIBELLE = new SqlParameter("@PO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPO_LIBELLE.Value  = clsBusinessplanparamposte.PO_LIBELLE ;

            if (clsBusinessplanparamposte.PO_LIBELLE == "") vppParamPO_LIBELLE.Value = DBNull.Value;

            SqlParameter vppParamPO_NUMEROORDRE = new SqlParameter("@PO_NUMEROORDRE", SqlDbType.Int);
			vppParamPO_NUMEROORDRE.Value  = clsBusinessplanparamposte.PO_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTE  @PO_CODEPOSTEBUSINESSPLAN1, @PD_CODEDOCUMENTDETAIL1, @PN_CODENATUREPOSTEBUSINESSPLAN1, @PP_CODEPOLICE, @PS_CODESIGNE, @PO_TAUX, @PO_LIBELLE, @PO_NUMEROORDRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPOSTEBUSINESSPLAN);
			vppSqlCmd.Parameters.Add(vppParamPD_CODEDOCUMENTDETAIL);
			vppSqlCmd.Parameters.Add(vppParamPN_CODENATUREPOSTEBUSINESSPLAN);
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPOLICE);
			vppSqlCmd.Parameters.Add(vppParamPS_CODESIGNE);
			vppSqlCmd.Parameters.Add(vppParamPO_TAUX);
			vppSqlCmd.Parameters.Add(vppParamPO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPO_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparamposte>clsBusinessplanparamposte</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBusinessplanparamposte clsBusinessplanparamposte,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPO_CODEPOSTEBUSINESSPLAN = new SqlParameter("@PO_CODEPOSTEBUSINESSPLAN", SqlDbType.VarChar, 7);
			vppParamPO_CODEPOSTEBUSINESSPLAN.Value  = clsBusinessplanparamposte.PO_CODEPOSTEBUSINESSPLAN ;
			SqlParameter vppParamPD_CODEDOCUMENTDETAIL = new SqlParameter("@PD_CODEDOCUMENTDETAIL", SqlDbType.VarChar, 5);
			vppParamPD_CODEDOCUMENTDETAIL.Value  = clsBusinessplanparamposte.PD_CODEDOCUMENTDETAIL ;
			SqlParameter vppParamPN_CODENATUREPOSTEBUSINESSPLAN = new SqlParameter("@PN_CODENATUREPOSTEBUSINESSPLAN", SqlDbType.VarChar, 3);
			vppParamPN_CODENATUREPOSTEBUSINESSPLAN.Value  = clsBusinessplanparamposte.PN_CODENATUREPOSTEBUSINESSPLAN ;
			SqlParameter vppParamPP_CODEPOLICE = new SqlParameter("@PP_CODEPOLICE", SqlDbType.VarChar, 3);
			vppParamPP_CODEPOLICE.Value  = clsBusinessplanparamposte.PP_CODEPOLICE ;
			SqlParameter vppParamPS_CODESIGNE = new SqlParameter("@PS_CODESIGNE", SqlDbType.VarChar, 3);
			vppParamPS_CODESIGNE.Value  = clsBusinessplanparamposte.PS_CODESIGNE ;
			SqlParameter vppParamPO_TAUX = new SqlParameter("@PO_TAUX", SqlDbType.Decimal, 4);
			vppParamPO_TAUX.Value  = clsBusinessplanparamposte.PO_TAUX ;
			SqlParameter vppParamPO_LIBELLE = new SqlParameter("@PO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPO_LIBELLE.Value  = clsBusinessplanparamposte.PO_LIBELLE ;

            if (clsBusinessplanparamposte.PO_LIBELLE == "") vppParamPO_LIBELLE.Value = DBNull.Value;

            SqlParameter vppParamPO_NUMEROORDRE = new SqlParameter("@PO_NUMEROORDRE", SqlDbType.Int);
			vppParamPO_NUMEROORDRE.Value  = clsBusinessplanparamposte.PO_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTE  @PO_CODEPOSTEBUSINESSPLAN, @PD_CODEDOCUMENTDETAIL, @PN_CODENATUREPOSTEBUSINESSPLAN, @PP_CODEPOLICE, @PS_CODESIGNE, @PO_TAUX, @PO_LIBELLE, @PO_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPOSTEBUSINESSPLAN);
			vppSqlCmd.Parameters.Add(vppParamPD_CODEDOCUMENTDETAIL);
			vppSqlCmd.Parameters.Add(vppParamPN_CODENATUREPOSTEBUSINESSPLAN);
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPOLICE);
			vppSqlCmd.Parameters.Add(vppParamPS_CODESIGNE);
			vppSqlCmd.Parameters.Add(vppParamPO_TAUX);
			vppSqlCmd.Parameters.Add(vppParamPO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPO_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMPOSTE  @PO_CODEPOSTEBUSINESSPLAN, '','', '', '', '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamposte </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamposte> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE, PO_TAUX, PO_LIBELLE, PO_NUMEROORDRE FROM dbo.FT_BUSINESSPLANPARAMPOSTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBusinessplanparamposte> clsBusinessplanparampostes = new List<clsBusinessplanparamposte>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparamposte clsBusinessplanparamposte = new clsBusinessplanparamposte();
					clsBusinessplanparamposte.PO_CODEPOSTEBUSINESSPLAN = clsDonnee.vogDataReader["PO_CODEPOSTEBUSINESSPLAN"].ToString();
					clsBusinessplanparamposte.PD_CODEDOCUMENTDETAIL = clsDonnee.vogDataReader["PD_CODEDOCUMENTDETAIL"].ToString();
					clsBusinessplanparamposte.PN_CODENATUREPOSTEBUSINESSPLAN = clsDonnee.vogDataReader["PN_CODENATUREPOSTEBUSINESSPLAN"].ToString();
					clsBusinessplanparamposte.PP_CODEPOLICE = clsDonnee.vogDataReader["PP_CODEPOLICE"].ToString();
					clsBusinessplanparamposte.PS_CODESIGNE = clsDonnee.vogDataReader["PS_CODESIGNE"].ToString();
					clsBusinessplanparamposte.PO_TAUX = decimal.Parse(clsDonnee.vogDataReader["PO_TAUX"].ToString());
					clsBusinessplanparamposte.PO_LIBELLE = clsDonnee.vogDataReader["PO_LIBELLE"].ToString();
					clsBusinessplanparamposte.PO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PO_NUMEROORDRE"].ToString());
					clsBusinessplanparampostes.Add(clsBusinessplanparamposte);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBusinessplanparampostes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamposte </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamposte> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBusinessplanparamposte> clsBusinessplanparampostes = new List<clsBusinessplanparamposte>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE, PO_TAUX, PO_LIBELLE, PO_NUMEROORDRE FROM dbo.FT_BUSINESSPLANPARAMPOSTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBusinessplanparamposte clsBusinessplanparamposte = new clsBusinessplanparamposte();
					clsBusinessplanparamposte.PO_CODEPOSTEBUSINESSPLAN = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPOSTEBUSINESSPLAN"].ToString();
					clsBusinessplanparamposte.PD_CODEDOCUMENTDETAIL = Dataset.Tables["TABLE"].Rows[Idx]["PD_CODEDOCUMENTDETAIL"].ToString();
					clsBusinessplanparamposte.PN_CODENATUREPOSTEBUSINESSPLAN = Dataset.Tables["TABLE"].Rows[Idx]["PN_CODENATUREPOSTEBUSINESSPLAN"].ToString();
					clsBusinessplanparamposte.PP_CODEPOLICE = Dataset.Tables["TABLE"].Rows[Idx]["PP_CODEPOLICE"].ToString();
					clsBusinessplanparamposte.PS_CODESIGNE = Dataset.Tables["TABLE"].Rows[Idx]["PS_CODESIGNE"].ToString();
					clsBusinessplanparamposte.PO_TAUX = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PO_TAUX"].ToString());
					clsBusinessplanparamposte.PO_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PO_LIBELLE"].ToString();
					clsBusinessplanparamposte.PO_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PO_NUMEROORDRE"].ToString());
					clsBusinessplanparampostes.Add(clsBusinessplanparamposte);
				}
				Dataset.Dispose();
			}
		return clsBusinessplanparampostes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BUSINESSPLANPARAMPOSTE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY PO_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PO_CODEPOSTEBUSINESSPLAN , PO_TAUX FROM dbo.FT_BUSINESSPLANPARAMPOSTE(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY PO_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PO_CODEPOSTEBUSINESSPLAN, PD_CODEDOCUMENTDETAIL, PN_CODENATUREPOSTEBUSINESSPLAN, PP_CODEPOLICE, PS_CODESIGNE)</summary>
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
				this.vapCritere ="WHERE PO_CODEPOSTEBUSINESSPLAN=@PO_CODEPOSTEBUSINESSPLAN";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PO_CODEPOSTEBUSINESSPLAN"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PO_CODEPOSTEBUSINESSPLAN=@PO_CODEPOSTEBUSINESSPLAN AND PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PO_CODEPOSTEBUSINESSPLAN","@PD_CODEDOCUMENTDETAIL"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE PO_CODEPOSTEBUSINESSPLAN=@PO_CODEPOSTEBUSINESSPLAN AND PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL AND PN_CODENATUREPOSTEBUSINESSPLAN=@PN_CODENATUREPOSTEBUSINESSPLAN";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PO_CODEPOSTEBUSINESSPLAN","@PD_CODEDOCUMENTDETAIL","@PN_CODENATUREPOSTEBUSINESSPLAN"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE PO_CODEPOSTEBUSINESSPLAN=@PO_CODEPOSTEBUSINESSPLAN AND PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL AND PN_CODENATUREPOSTEBUSINESSPLAN=@PN_CODENATUREPOSTEBUSINESSPLAN AND PP_CODEPOLICE=@PP_CODEPOLICE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PO_CODEPOSTEBUSINESSPLAN","@PD_CODEDOCUMENTDETAIL","@PN_CODENATUREPOSTEBUSINESSPLAN","@PP_CODEPOLICE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE PO_CODEPOSTEBUSINESSPLAN=@PO_CODEPOSTEBUSINESSPLAN AND PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL AND PN_CODENATUREPOSTEBUSINESSPLAN=@PN_CODENATUREPOSTEBUSINESSPLAN AND PP_CODEPOLICE=@PP_CODEPOLICE AND PS_CODESIGNE=@PS_CODESIGNE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PO_CODEPOSTEBUSINESSPLAN","@PD_CODEDOCUMENTDETAIL","@PN_CODENATUREPOSTEBUSINESSPLAN","@PP_CODEPOLICE","@PS_CODESIGNE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}
	}
}
