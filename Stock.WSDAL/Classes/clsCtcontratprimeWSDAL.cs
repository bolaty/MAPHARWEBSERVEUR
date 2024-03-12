using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtcontratprimeWSDAL: ITableDAL<clsCtcontratprime>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CA_CODECONTRAT) AS CA_CODECONTRAT  FROM dbo.FT_CTCONTRATPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratprime comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratprime pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , EN_CODEENTREPOT  , CP_VALEUR  FROM dbo.FT_CTCONTRATPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtcontratprime clsCtcontratprime = new clsCtcontratprime();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratprime.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratprime.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratprime.CP_VALEUR = double.Parse(clsDonnee.vogDataReader["CP_VALEUR"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtcontratprime;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratprime>clsCtcontratprime</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtcontratprime clsCtcontratprime)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratprime.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT1", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratprime.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT1", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratprime.CA_CODECONTRAT ;
			SqlParameter vppParamRE_CODERESUME = new SqlParameter("@RE_CODERESUME", SqlDbType.VarChar, 2);
			vppParamRE_CODERESUME.Value  = clsCtcontratprime.RE_CODERESUME ;
			SqlParameter vppParamCP_VALEUR = new SqlParameter("@CP_VALEUR", SqlDbType.Money);
			vppParamCP_VALEUR.Value  = clsCtcontratprime.CP_VALEUR ;

            SqlParameter vppParamCM_DATEPIECE = new SqlParameter("@CM_DATEPIECE", SqlDbType.DateTime);
            vppParamCM_DATEPIECE.Value = clsCtcontratprime.CM_DATEPIECE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsCtcontratprime.OP_CODEOPERATEUR;



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATPRIME  @AG_CODEAGENCE1, @EN_CODEENTREPOT1, @CA_CODECONTRAT1, @RE_CODERESUME, @CP_VALEUR, @CM_DATEPIECE,@OP_CODEOPERATEUR, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamRE_CODERESUME);
			vppSqlCmd.Parameters.Add(vppParamCP_VALEUR);
            vppSqlCmd.Parameters.Add(vppParamCM_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtcontratprime>clsCtcontratprime</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtcontratprime clsCtcontratprime,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCtcontratprime.AG_CODEAGENCE ;
			SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
			vppParamEN_CODEENTREPOT.Value  = clsCtcontratprime.EN_CODEENTREPOT ;
			SqlParameter vppParamCA_CODECONTRAT = new SqlParameter("@CA_CODECONTRAT", SqlDbType.VarChar, 50);
			vppParamCA_CODECONTRAT.Value  = clsCtcontratprime.CA_CODECONTRAT ;
			SqlParameter vppParamRE_CODERESUME = new SqlParameter("@RE_CODERESUME", SqlDbType.VarChar, 2);
			vppParamRE_CODERESUME.Value  = clsCtcontratprime.RE_CODERESUME ;
			SqlParameter vppParamCP_VALEUR = new SqlParameter("@CP_VALEUR", SqlDbType.Money);
			vppParamCP_VALEUR.Value  = clsCtcontratprime.CP_VALEUR ;

            SqlParameter vppParamCM_DATEPIECE = new SqlParameter("@CM_DATEPIECE", SqlDbType.DateTime);
            vppParamCM_DATEPIECE.Value = clsCtcontratprime.CM_DATEPIECE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsCtcontratprime.OP_CODEOPERATEUR;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATPRIME  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT, @RE_CODERESUME, @CP_VALEUR, @CM_DATEPIECE,@OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamCA_CODECONTRAT);
			vppSqlCmd.Parameters.Add(vppParamRE_CODERESUME);
			vppSqlCmd.Parameters.Add(vppParamCP_VALEUR);
			vppSqlCmd.Parameters.Add(vppParamCM_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTCONTRATPRIME  @AG_CODEAGENCE, @EN_CODEENTREPOT, @CA_CODECONTRAT, '', '' ,'' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratprime </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratprime> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME, CP_VALEUR FROM dbo.FT_CTCONTRATPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtcontratprime> clsCtcontratprimes = new List<clsCtcontratprime>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtcontratprime clsCtcontratprime = new clsCtcontratprime();
					clsCtcontratprime.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCtcontratprime.EN_CODEENTREPOT = clsDonnee.vogDataReader["EN_CODEENTREPOT"].ToString();
					clsCtcontratprime.CA_CODECONTRAT = clsDonnee.vogDataReader["CA_CODECONTRAT"].ToString();
					clsCtcontratprime.RE_CODERESUME = clsDonnee.vogDataReader["RE_CODERESUME"].ToString();
					clsCtcontratprime.CP_VALEUR = double.Parse(clsDonnee.vogDataReader["CP_VALEUR"].ToString());
					clsCtcontratprimes.Add(clsCtcontratprime);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtcontratprimes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratprime </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratprime> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtcontratprime> clsCtcontratprimes = new List<clsCtcontratprime>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME, CP_VALEUR FROM dbo.FT_CTCONTRATPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtcontratprime clsCtcontratprime = new clsCtcontratprime();
					clsCtcontratprime.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCtcontratprime.EN_CODEENTREPOT = Dataset.Tables["TABLE"].Rows[Idx]["EN_CODEENTREPOT"].ToString();
					clsCtcontratprime.CA_CODECONTRAT = Dataset.Tables["TABLE"].Rows[Idx]["CA_CODECONTRAT"].ToString();
					clsCtcontratprime.RE_CODERESUME = Dataset.Tables["TABLE"].Rows[Idx]["RE_CODERESUME"].ToString();
					clsCtcontratprime.CP_VALEUR = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CP_VALEUR"].ToString());
					clsCtcontratprimes.Add(clsCtcontratprime);
				}
				Dataset.Dispose();
			}
		return clsCtcontratprimes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTCONTRATPRIME(@CODECRYPTAGE) " + this.vapCritere + " ORDER BY RL_NUMEROORDRE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CA_CODECONTRAT , CP_VALEUR FROM dbo.FT_CTCONTRATPRIME(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, EN_CODEENTREPOT, CA_CODECONTRAT, RE_CODERESUME)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CA_CODECONTRAT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND CA_CODECONTRAT=@CA_CODECONTRAT AND RE_CODERESUME=@RE_CODERESUME";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@EN_CODEENTREPOT","@CA_CODECONTRAT","@RE_CODERESUME"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
