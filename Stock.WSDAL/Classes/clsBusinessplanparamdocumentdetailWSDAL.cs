using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsBusinessplanparamdocumentdetailWSDAL: ITableDAL<clsBusinessplanparamdocumentdetail>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PD_CODEDOCUMENTDETAIL) AS PD_CODEDOCUMENTDETAIL  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENTDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PD_CODEDOCUMENTDETAIL) AS PD_CODEDOCUMENTDETAIL  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENTDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PD_CODEDOCUMENTDETAIL) AS PD_CODEDOCUMENTDETAIL  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENTDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsBusinessplanparamdocumentdetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsBusinessplanparamdocumentdetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PB_CODEDOCUMENT  , PP_CODEPOLICE  , PC_CODECOULEUR  , PF_CODEFORMULE  , PA_CODEDOCUMENTDETAILFAMILLE  , PD_LIBELLE  , PD_NUMEROORDRE  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENTDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsBusinessplanparamdocumentdetail clsBusinessplanparamdocumentdetail = new clsBusinessplanparamdocumentdetail();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparamdocumentdetail.PB_CODEDOCUMENT = clsDonnee.vogDataReader["PB_CODEDOCUMENT"].ToString();
					clsBusinessplanparamdocumentdetail.PP_CODEPOLICE = clsDonnee.vogDataReader["PP_CODEPOLICE"].ToString();
					clsBusinessplanparamdocumentdetail.PC_CODECOULEUR = clsDonnee.vogDataReader["PC_CODECOULEUR"].ToString();
					clsBusinessplanparamdocumentdetail.PF_CODEFORMULE = clsDonnee.vogDataReader["PF_CODEFORMULE"].ToString();
					clsBusinessplanparamdocumentdetail.PA_CODEDOCUMENTDETAILFAMILLE = clsDonnee.vogDataReader["PA_CODEDOCUMENTDETAILFAMILLE"].ToString();
					clsBusinessplanparamdocumentdetail.PD_LIBELLE = clsDonnee.vogDataReader["PD_LIBELLE"].ToString();
					clsBusinessplanparamdocumentdetail.PD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PD_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsBusinessplanparamdocumentdetail;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparamdocumentdetail>clsBusinessplanparamdocumentdetail</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsBusinessplanparamdocumentdetail clsBusinessplanparamdocumentdetail)
		{
			//Préparation des paramètres
			SqlParameter vppParamPD_CODEDOCUMENTDETAIL = new SqlParameter("@PD_CODEDOCUMENTDETAIL", SqlDbType.VarChar, 5);
			vppParamPD_CODEDOCUMENTDETAIL.Value  = clsBusinessplanparamdocumentdetail.PD_CODEDOCUMENTDETAIL ;
			SqlParameter vppParamPB_CODEDOCUMENT = new SqlParameter("@PB_CODEDOCUMENT", SqlDbType.VarChar, 3);
			vppParamPB_CODEDOCUMENT.Value  = clsBusinessplanparamdocumentdetail.PB_CODEDOCUMENT ;
			SqlParameter vppParamPP_CODEPOLICE = new SqlParameter("@PP_CODEPOLICE", SqlDbType.VarChar, 3);
			vppParamPP_CODEPOLICE.Value  = clsBusinessplanparamdocumentdetail.PP_CODEPOLICE ;
			SqlParameter vppParamPC_CODECOULEUR = new SqlParameter("@PC_CODECOULEUR", SqlDbType.VarChar, 3);
			vppParamPC_CODECOULEUR.Value  = clsBusinessplanparamdocumentdetail.PC_CODECOULEUR ;
			SqlParameter vppParamPF_CODEFORMULE = new SqlParameter("@PF_CODEFORMULE", SqlDbType.VarChar, 3);
			vppParamPF_CODEFORMULE.Value  = clsBusinessplanparamdocumentdetail.PF_CODEFORMULE ;
			SqlParameter vppParamPA_CODEDOCUMENTDETAILFAMILLE = new SqlParameter("@PA_CODEDOCUMENTDETAILFAMILLE", SqlDbType.VarChar, 4);
			vppParamPA_CODEDOCUMENTDETAILFAMILLE.Value  = clsBusinessplanparamdocumentdetail.PA_CODEDOCUMENTDETAILFAMILLE ;
			SqlParameter vppParamPD_LIBELLE = new SqlParameter("@PD_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPD_LIBELLE.Value  = clsBusinessplanparamdocumentdetail.PD_LIBELLE ;
			SqlParameter vppParamPD_NUMEROORDRE = new SqlParameter("@PD_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamPD_NUMEROORDRE.Value  = clsBusinessplanparamdocumentdetail.PD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMDOCUMENTDETAIL  @PD_CODEDOCUMENTDETAIL, @PB_CODEDOCUMENT, @PP_CODEPOLICE, @PC_CODECOULEUR, @PF_CODEFORMULE, @PA_CODEDOCUMENTDETAILFAMILLE, @PD_LIBELLE, @PD_NUMEROORDRE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPD_CODEDOCUMENTDETAIL);
			vppSqlCmd.Parameters.Add(vppParamPB_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPOLICE);
			vppSqlCmd.Parameters.Add(vppParamPC_CODECOULEUR);
			vppSqlCmd.Parameters.Add(vppParamPF_CODEFORMULE);
			vppSqlCmd.Parameters.Add(vppParamPA_CODEDOCUMENTDETAILFAMILLE);
			vppSqlCmd.Parameters.Add(vppParamPD_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsBusinessplanparamdocumentdetail>clsBusinessplanparamdocumentdetail</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsBusinessplanparamdocumentdetail clsBusinessplanparamdocumentdetail,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPD_CODEDOCUMENTDETAIL = new SqlParameter("@PD_CODEDOCUMENTDETAIL", SqlDbType.VarChar, 5);
			vppParamPD_CODEDOCUMENTDETAIL.Value  = clsBusinessplanparamdocumentdetail.PD_CODEDOCUMENTDETAIL ;
			SqlParameter vppParamPB_CODEDOCUMENT = new SqlParameter("@PB_CODEDOCUMENT", SqlDbType.VarChar, 3);
			vppParamPB_CODEDOCUMENT.Value  = clsBusinessplanparamdocumentdetail.PB_CODEDOCUMENT ;
			SqlParameter vppParamPP_CODEPOLICE = new SqlParameter("@PP_CODEPOLICE", SqlDbType.VarChar, 3);
			vppParamPP_CODEPOLICE.Value  = clsBusinessplanparamdocumentdetail.PP_CODEPOLICE ;
			SqlParameter vppParamPC_CODECOULEUR = new SqlParameter("@PC_CODECOULEUR", SqlDbType.VarChar, 3);
			vppParamPC_CODECOULEUR.Value  = clsBusinessplanparamdocumentdetail.PC_CODECOULEUR ;
			SqlParameter vppParamPF_CODEFORMULE = new SqlParameter("@PF_CODEFORMULE", SqlDbType.VarChar, 3);
			vppParamPF_CODEFORMULE.Value  = clsBusinessplanparamdocumentdetail.PF_CODEFORMULE ;
			SqlParameter vppParamPA_CODEDOCUMENTDETAILFAMILLE = new SqlParameter("@PA_CODEDOCUMENTDETAILFAMILLE", SqlDbType.VarChar, 4);
			vppParamPA_CODEDOCUMENTDETAILFAMILLE.Value  = clsBusinessplanparamdocumentdetail.PA_CODEDOCUMENTDETAILFAMILLE ;
			SqlParameter vppParamPD_LIBELLE = new SqlParameter("@PD_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPD_LIBELLE.Value  = clsBusinessplanparamdocumentdetail.PD_LIBELLE ;
			SqlParameter vppParamPD_NUMEROORDRE = new SqlParameter("@PD_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamPD_NUMEROORDRE.Value  = clsBusinessplanparamdocumentdetail.PD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMDOCUMENTDETAIL  @PD_CODEDOCUMENTDETAIL, @PB_CODEDOCUMENT, @PP_CODEPOLICE, @PC_CODECOULEUR, @PF_CODEFORMULE, @PA_CODEDOCUMENTDETAILFAMILLE, @PD_LIBELLE, @PD_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPD_CODEDOCUMENTDETAIL);
			vppSqlCmd.Parameters.Add(vppParamPB_CODEDOCUMENT);
			vppSqlCmd.Parameters.Add(vppParamPP_CODEPOLICE);
			vppSqlCmd.Parameters.Add(vppParamPC_CODECOULEUR);
			vppSqlCmd.Parameters.Add(vppParamPF_CODEFORMULE);
			vppSqlCmd.Parameters.Add(vppParamPA_CODEDOCUMENTDETAILFAMILLE);
			vppSqlCmd.Parameters.Add(vppParamPD_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_BUSINESSPLANPARAMDOCUMENTDETAIL  @PD_CODEDOCUMENTDETAIL, '', '', '', '', '', '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamdocumentdetail </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamdocumentdetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE, PD_LIBELLE, PD_NUMEROORDRE FROM dbo.FT_BUSINESSPLANPARAMDOCUMENTDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsBusinessplanparamdocumentdetail> clsBusinessplanparamdocumentdetails = new List<clsBusinessplanparamdocumentdetail>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsBusinessplanparamdocumentdetail clsBusinessplanparamdocumentdetail = new clsBusinessplanparamdocumentdetail();
					clsBusinessplanparamdocumentdetail.PD_CODEDOCUMENTDETAIL = clsDonnee.vogDataReader["PD_CODEDOCUMENTDETAIL"].ToString();
					clsBusinessplanparamdocumentdetail.PB_CODEDOCUMENT = clsDonnee.vogDataReader["PB_CODEDOCUMENT"].ToString();
					clsBusinessplanparamdocumentdetail.PP_CODEPOLICE = clsDonnee.vogDataReader["PP_CODEPOLICE"].ToString();
					clsBusinessplanparamdocumentdetail.PC_CODECOULEUR = clsDonnee.vogDataReader["PC_CODECOULEUR"].ToString();
					clsBusinessplanparamdocumentdetail.PF_CODEFORMULE = clsDonnee.vogDataReader["PF_CODEFORMULE"].ToString();
					clsBusinessplanparamdocumentdetail.PA_CODEDOCUMENTDETAILFAMILLE = clsDonnee.vogDataReader["PA_CODEDOCUMENTDETAILFAMILLE"].ToString();
					clsBusinessplanparamdocumentdetail.PD_LIBELLE = clsDonnee.vogDataReader["PD_LIBELLE"].ToString();
					clsBusinessplanparamdocumentdetail.PD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PD_NUMEROORDRE"].ToString());
					clsBusinessplanparamdocumentdetails.Add(clsBusinessplanparamdocumentdetail);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBusinessplanparamdocumentdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsBusinessplanparamdocumentdetail </returns>
		///<author>Home Technology</author>
		public List<clsBusinessplanparamdocumentdetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBusinessplanparamdocumentdetail> clsBusinessplanparamdocumentdetails = new List<clsBusinessplanparamdocumentdetail>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE, PD_LIBELLE, PD_NUMEROORDRE FROM dbo.FT_BUSINESSPLANPARAMDOCUMENTDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBusinessplanparamdocumentdetail clsBusinessplanparamdocumentdetail = new clsBusinessplanparamdocumentdetail();
					clsBusinessplanparamdocumentdetail.PD_CODEDOCUMENTDETAIL = Dataset.Tables["TABLE"].Rows[Idx]["PD_CODEDOCUMENTDETAIL"].ToString();
					clsBusinessplanparamdocumentdetail.PB_CODEDOCUMENT = Dataset.Tables["TABLE"].Rows[Idx]["PB_CODEDOCUMENT"].ToString();
					clsBusinessplanparamdocumentdetail.PP_CODEPOLICE = Dataset.Tables["TABLE"].Rows[Idx]["PP_CODEPOLICE"].ToString();
					clsBusinessplanparamdocumentdetail.PC_CODECOULEUR = Dataset.Tables["TABLE"].Rows[Idx]["PC_CODECOULEUR"].ToString();
					clsBusinessplanparamdocumentdetail.PF_CODEFORMULE = Dataset.Tables["TABLE"].Rows[Idx]["PF_CODEFORMULE"].ToString();
					clsBusinessplanparamdocumentdetail.PA_CODEDOCUMENTDETAILFAMILLE = Dataset.Tables["TABLE"].Rows[Idx]["PA_CODEDOCUMENTDETAILFAMILLE"].ToString();
					clsBusinessplanparamdocumentdetail.PD_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PD_LIBELLE"].ToString();
					clsBusinessplanparamdocumentdetail.PD_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PD_NUMEROORDRE"].ToString());
					clsBusinessplanparamdocumentdetails.Add(clsBusinessplanparamdocumentdetail);
				}
				Dataset.Dispose();
			}
		return clsBusinessplanparamdocumentdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_BUSINESSPLANPARAMDOCUMENTDETAIL(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY PD_NUMEROORDRE"; 
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PD_CODEDOCUMENTDETAIL , PD_LIBELLE FROM dbo.FT_BUSINESSPLANPARAMDOCUMENTDETAIL(@CODECRYPTAGE) " + this.vapCritere +  " ORDER BY PD_NUMEROORDRE";
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PD_CODEDOCUMENTDETAIL, PB_CODEDOCUMENT, PP_CODEPOLICE, PC_CODECOULEUR, PF_CODEFORMULE, PA_CODEDOCUMENTDETAILFAMILLE)</summary>
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
				this.vapCritere = "WHERE PB_CODEDOCUMENT=@PB_CODEDOCUMENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@PB_CODEDOCUMENT" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere = "WHERE PB_CODEDOCUMENT=@PB_CODEDOCUMENT AND PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL";
				vapNomParametre = new string[]{"@CODECRYPTAGE", "@PB_CODEDOCUMENT", "@PD_CODEDOCUMENTDETAIL" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL AND PB_CODEDOCUMENT=@PB_CODEDOCUMENT AND PP_CODEPOLICE=@PP_CODEPOLICE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PD_CODEDOCUMENTDETAIL","@PB_CODEDOCUMENT","@PP_CODEPOLICE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL AND PB_CODEDOCUMENT=@PB_CODEDOCUMENT AND PP_CODEPOLICE=@PP_CODEPOLICE AND PC_CODECOULEUR=@PC_CODECOULEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PD_CODEDOCUMENTDETAIL","@PB_CODEDOCUMENT","@PP_CODEPOLICE","@PC_CODECOULEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL AND PB_CODEDOCUMENT=@PB_CODEDOCUMENT AND PP_CODEPOLICE=@PP_CODEPOLICE AND PC_CODECOULEUR=@PC_CODECOULEUR AND PF_CODEFORMULE=@PF_CODEFORMULE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PD_CODEDOCUMENTDETAIL","@PB_CODEDOCUMENT","@PP_CODEPOLICE","@PC_CODECOULEUR","@PF_CODEFORMULE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE PD_CODEDOCUMENTDETAIL=@PD_CODEDOCUMENTDETAIL AND PB_CODEDOCUMENT=@PB_CODEDOCUMENT AND PP_CODEPOLICE=@PP_CODEPOLICE AND PC_CODECOULEUR=@PC_CODECOULEUR AND PF_CODEFORMULE=@PF_CODEFORMULE AND PA_CODEDOCUMENTDETAILFAMILLE=@PA_CODEDOCUMENTDETAILFAMILLE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PD_CODEDOCUMENTDETAIL","@PB_CODEDOCUMENT","@PP_CODEPOLICE","@PC_CODECOULEUR","@PF_CODEFORMULE","@PA_CODEDOCUMENTDETAILFAMILLE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}
	}
}
