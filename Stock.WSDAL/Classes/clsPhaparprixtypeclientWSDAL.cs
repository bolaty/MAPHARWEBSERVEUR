using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparprixtypeclientWSDAL: ITableDAL<clsPhaparprixtypeclient>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{}; 

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(AR_CODEARTICLE) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(NT_CODENATURETIERS) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(NT_CODENATURETIERS) AS AR_CODEARTICLE  FROM dbo.PHAPARPRIXTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparprixtypeclient comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparprixtypeclient pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapCritere = "WHERE AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS AND PY_DATETARIFICATION<=@PY_DATETARIFICATION  ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_DATETARIFICATION", "@TYPEMONTANT", "@JF_CODETYPEJOURFACTURATION", "@LF_CODELIEUFACTURATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4] , vppCritere[5], vppCritere[6] , vppCritere[7] };
            this.vapRequete = "SELECT PY_PRIXVENTE  , PY_PRIXVENTEHT  ,PY_TAUXREMISE  , PY_MONTANTREMISE  , PY_TAUXCOMMISSION  , PY_MONTANTCOMMISSION  , PY_DATEREMISE1  , PY_DATEREMISE2  , PY_DATETARIFICATION  FROM dbo.FT_PHAPARPRIXTYPECLIENT(@AG_CODEAGENCE,@EN_CODEENTREPOT,@TYPEMONTANT,@PY_DATETARIFICATION,@JF_CODETYPEJOURFACTURATION,@LF_CODELIEUFACTURATION,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparprixtypeclient clsPhaparprixtypeclient = new clsPhaparprixtypeclient();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprixtypeclient.PY_PRIXVENTE = double.Parse(clsDonnee.vogDataReader["PY_PRIXVENTE"].ToString());
                    clsPhaparprixtypeclient.PY_PRIXVENTEHT = double.Parse(clsDonnee.vogDataReader["PY_PRIXVENTEHT"].ToString());
					clsPhaparprixtypeclient.PY_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["PY_TAUXREMISE"].ToString());
					clsPhaparprixtypeclient.PY_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["PY_MONTANTREMISE"].ToString());
					clsPhaparprixtypeclient.PY_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["PY_TAUXCOMMISSION"].ToString());
					clsPhaparprixtypeclient.PY_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["PY_MONTANTCOMMISSION"].ToString());
                    if (clsDonnee.vogDataReader["PY_DATEREMISE1"].ToString()!="")
					clsPhaparprixtypeclient.PY_DATEREMISE1 = DateTime.Parse(clsDonnee.vogDataReader["PY_DATEREMISE1"].ToString());
                    else
                        clsPhaparprixtypeclient.PY_DATEREMISE1 = DateTime.Parse("01/01/1900");
                    if (clsDonnee.vogDataReader["PY_DATEREMISE2"].ToString() != "")
					clsPhaparprixtypeclient.PY_DATEREMISE2 = DateTime.Parse(clsDonnee.vogDataReader["PY_DATEREMISE2"].ToString());
                    else
                        clsPhaparprixtypeclient.PY_DATEREMISE2 = DateTime.Parse("01/01/1900");
					clsPhaparprixtypeclient.PY_DATETARIFICATION = DateTime.Parse(clsDonnee.vogDataReader["PY_DATETARIFICATION"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparprixtypeclient;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprixtypeclient>clsPhaparprixtypeclient</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparprixtypeclient clsPhaparprixtypeclient)
		{
			//Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparprixtypeclient.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsPhaparprixtypeclient.EN_CODEENTREPOT;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparprixtypeclient.AR_CODEARTICLE ;

            SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 3);
            vppParamNT_CODENATURETIERS.Value = clsPhaparprixtypeclient.NT_CODENATURETIERS;

            SqlParameter vppParamPY_DATETARIFICATION = new SqlParameter("@PY_DATETARIFICATION", SqlDbType.DateTime);
            vppParamPY_DATETARIFICATION.Value = clsPhaparprixtypeclient.PY_DATETARIFICATION;
            if (clsPhaparprixtypeclient.PY_DATETARIFICATION < DateTime.Parse("01/01/1900")) vppParamPY_DATETARIFICATION.Value = "01/01/1900";

			SqlParameter vppParamPY_PRIXVENTE = new SqlParameter("@PY_PRIXVENTE", SqlDbType.Money);
			vppParamPY_PRIXVENTE.Value  = clsPhaparprixtypeclient.PY_PRIXVENTE ;

			SqlParameter vppParamPY_TAUXCOMMISSION = new SqlParameter("@PY_TAUXCOMMISSION", SqlDbType.Float);
			vppParamPY_TAUXCOMMISSION.Value  = clsPhaparprixtypeclient.PY_TAUXCOMMISSION ;

			SqlParameter vppParamPY_MONTANTCOMMISSION = new SqlParameter("@PY_MONTANTCOMMISSION", SqlDbType.Money);
			vppParamPY_MONTANTCOMMISSION.Value  = clsPhaparprixtypeclient.PY_MONTANTCOMMISSION ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar,25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparprixtypeclient.OP_CODEOPERATEUR;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;
            SqlParameter vppParamPY_TYPEECRAN = new SqlParameter("@PY_TYPEECRAN", SqlDbType.VarChar, 1);
            vppParamPY_TYPEECRAN.Value = clsPhaparprixtypeclient.PY_TYPEECRAN;

            SqlParameter vppParamJF_CODETYPEJOURFACTURATION = new SqlParameter("@JF_CODETYPEJOURFACTURATION", SqlDbType.VarChar, 25);
            vppParamJF_CODETYPEJOURFACTURATION.Value = clsPhaparprixtypeclient.JF_CODETYPEJOURFACTURATION;
            if (clsPhaparprixtypeclient.JF_CODETYPEJOURFACTURATION == "") vppParamJF_CODETYPEJOURFACTURATION.Value = DBNull.Value;

            SqlParameter vppParamLF_CODELIEUFACTURATION = new SqlParameter("@LF_CODELIEUFACTURATION", SqlDbType.VarChar, 25);
            vppParamLF_CODELIEUFACTURATION.Value = clsPhaparprixtypeclient.LF_CODELIEUFACTURATION;
            if (clsPhaparprixtypeclient.LF_CODELIEUFACTURATION == "") vppParamLF_CODELIEUFACTURATION.Value = DBNull.Value;


            SqlParameter vppParamPY_VALEURCOEFICIENT = new SqlParameter("@PY_VALEURCOEFICIENT", SqlDbType.Money);
            vppParamPY_VALEURCOEFICIENT.Value = clsPhaparprixtypeclient.PY_VALEURCOEFICIENT;

            SqlParameter vppParamPY_COUTCOEFICIENT = new SqlParameter("@PY_COUTCOEFICIENT", SqlDbType.Money);
            vppParamPY_COUTCOEFICIENT.Value = clsPhaparprixtypeclient.PY_COUTCOEFICIENT;


            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARPRIXTYPECLIENT  @AG_CODEAGENCE,@EN_CODEENTREPOT,@AR_CODEARTICLE, @NT_CODENATURETIERS, @PY_DATETARIFICATION, @PY_PRIXVENTE,  @PY_TAUXCOMMISSION, @PY_MONTANTCOMMISSION,@PY_TYPEECRAN,@JF_CODETYPEJOURFACTURATION,@LF_CODELIEUFACTURATION,@PY_VALEURCOEFICIENT,@PY_COUTCOEFICIENT, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
            vppSqlCmd.Parameters.Add(vppParamPY_DATETARIFICATION);
			vppSqlCmd.Parameters.Add(vppParamPY_PRIXVENTE);
			vppSqlCmd.Parameters.Add(vppParamPY_TAUXCOMMISSION);
			vppSqlCmd.Parameters.Add(vppParamPY_MONTANTCOMMISSION);
            vppSqlCmd.Parameters.Add(vppParamPY_TYPEECRAN);
            vppSqlCmd.Parameters.Add(vppParamJF_CODETYPEJOURFACTURATION);
            vppSqlCmd.Parameters.Add(vppParamLF_CODELIEUFACTURATION);
            vppSqlCmd.Parameters.Add(vppParamPY_VALEURCOEFICIENT);
            vppSqlCmd.Parameters.Add(vppParamPY_COUTCOEFICIENT);

            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			
			//Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprixtypeclient>clsPhaparprixtypeclient</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparprixtypeclient clsPhaparprixtypeclient,params string[] vppCritere)
		{
            vapNomParametre = new string[] {"@AR_CODEARTICLE", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_PRIXVENTE", "@PY_DATETARIFICATION" };
            vapValeurParametre = new object[] { clsPhaparprixtypeclient.AG_CODEAGENCE, clsPhaparprixtypeclient.EN_CODEENTREPOT, clsPhaparprixtypeclient.AR_CODEARTICLE, clsPhaparprixtypeclient.NT_CODENATURETIERS, clsPhaparprixtypeclient.PY_PRIXVENTE, clsPhaparprixtypeclient.PY_DATETARIFICATION };

			//Préparation des paramètres
            this.vapRequete = " EXEC DBO.PS_MAJPRIXTYPECLIENT @AG_CODEAGENCE,@EN_CODEENTREPOT, @AR_CODEARTICLE, @NT_CODENATURETIERS, @PY_PRIXVENTE, @PY_DATETARIFICATION ";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        public void pvgUpdatePromotion(clsDonnee clsDonnee, clsPhaparprixtypeclient clsPhaparprixtypeclient)
        {

            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_TAUXREMISE", "@PY_MONTANTREMISE", "@PY_DATEREMISE1", "@PY_DATEREMISE2", "@PY_DATETARIFICATION" };
            vapValeurParametre = new object[] {clsPhaparprixtypeclient.AG_CODEAGENCE, clsPhaparprixtypeclient.EN_CODEENTREPOT, clsPhaparprixtypeclient.AR_CODEARTICLE, clsPhaparprixtypeclient.NT_CODENATURETIERS, clsPhaparprixtypeclient.PY_TAUXREMISE, clsPhaparprixtypeclient.PY_MONTANTREMISE,
             clsPhaparprixtypeclient.PY_DATEREMISE1.ToShortDateString(), clsPhaparprixtypeclient.PY_DATEREMISE2.ToShortDateString(),clsPhaparprixtypeclient.PY_DATETARIFICATION.ToShortDateString()};

            //Préparation des paramètres
            this.vapRequete = " EXEC DBO.PS_PROMOTION @AG_CODEAGENCE, @EN_CODEENTREPOT,@AR_CODEARTICLE, @NT_CODENATURETIERS, @PY_TAUXREMISE, @PY_MONTANTREMISE, @PY_DATEREMISE1, @PY_DATEREMISE2, @PY_DATETARIFICATION ";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARPRIXTYPECLIENT "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}



		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprixtypeclient </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprixtypeclient> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE, NT_CODENATURETIERS, PY_PRIXVENTE, PY_TAUXREMISE, PY_MONTANTREMISE, PY_TAUXCOMMISSION, PY_MONTANTCOMMISSION, PY_DATEREMISE1, PY_DATEREMISE2, PY_DATETARIFICATION, JF_CODETYPEJOURFACTURATION, LF_CODELIEUFACTURATION FROM dbo.PHAPARPRIXTYPECLIENT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparprixtypeclient> clsPhaparprixtypeclients = new List<clsPhaparprixtypeclient>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprixtypeclient clsPhaparprixtypeclient = new clsPhaparprixtypeclient();
					clsPhaparprixtypeclient.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparprixtypeclient.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
					clsPhaparprixtypeclient.PY_PRIXVENTE = double.Parse(clsDonnee.vogDataReader["PY_PRIXVENTE"].ToString());
					clsPhaparprixtypeclient.PY_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["PY_TAUXREMISE"].ToString());
					clsPhaparprixtypeclient.PY_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["PY_MONTANTREMISE"].ToString());
					clsPhaparprixtypeclient.PY_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["PY_TAUXCOMMISSION"].ToString());
					clsPhaparprixtypeclient.PY_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["PY_MONTANTCOMMISSION"].ToString());
					clsPhaparprixtypeclient.PY_DATEREMISE1 = DateTime.Parse(clsDonnee.vogDataReader["PY_DATEREMISE1"].ToString());
					clsPhaparprixtypeclient.PY_DATEREMISE2 = DateTime.Parse(clsDonnee.vogDataReader["PY_DATEREMISE2"].ToString());
					clsPhaparprixtypeclient.PY_DATETARIFICATION = DateTime.Parse(clsDonnee.vogDataReader["PY_DATETARIFICATION"].ToString());
					clsPhaparprixtypeclient.JF_CODETYPEJOURFACTURATION =clsDonnee.vogDataReader["JF_CODETYPEJOURFACTURATION"].ToString();
					clsPhaparprixtypeclient.LF_CODELIEUFACTURATION = clsDonnee.vogDataReader["LF_CODELIEUFACTURATION"].ToString();
					clsPhaparprixtypeclients.Add(clsPhaparprixtypeclient);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparprixtypeclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprixtypeclient </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprixtypeclient> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparprixtypeclient> clsPhaparprixtypeclients = new List<clsPhaparprixtypeclient>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  AR_CODEARTICLE, NT_CODENATURETIERS, PY_PRIXVENTE, PY_TAUXREMISE, PY_MONTANTREMISE, PY_TAUXCOMMISSION, PY_MONTANTCOMMISSION, PY_DATEREMISE1, PY_DATEREMISE2, PY_DATETARIFICATION, JF_CODETYPEJOURFACTURATION , LF_CODELIEUFACTURATION FROM dbo.PHAPARPRIXTYPECLIENT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparprixtypeclient clsPhaparprixtypeclient = new clsPhaparprixtypeclient();
					clsPhaparprixtypeclient.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaparprixtypeclient.NT_CODENATURETIERS = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETIERS"].ToString();
					clsPhaparprixtypeclient.PY_PRIXVENTE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_PRIXVENTE"].ToString());
					clsPhaparprixtypeclient.PY_TAUXREMISE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_TAUXREMISE"].ToString());
					clsPhaparprixtypeclient.PY_MONTANTREMISE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_MONTANTREMISE"].ToString());
					clsPhaparprixtypeclient.PY_TAUXCOMMISSION = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_TAUXCOMMISSION"].ToString());
					clsPhaparprixtypeclient.PY_MONTANTCOMMISSION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_MONTANTCOMMISSION"].ToString());
					clsPhaparprixtypeclient.PY_DATEREMISE1 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_DATEREMISE1"].ToString());
					clsPhaparprixtypeclient.PY_DATEREMISE2 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_DATEREMISE2"].ToString());
					clsPhaparprixtypeclient.PY_DATETARIFICATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PY_DATETARIFICATION"].ToString());
					clsPhaparprixtypeclient.JF_CODETYPEJOURFACTURATION =Dataset.Tables["TABLE"].Rows[Idx]["JF_CODETYPEJOURFACTURATION"].ToString();
					clsPhaparprixtypeclient.LF_CODELIEUFACTURATION = Dataset.Tables["TABLE"].Rows[Idx]["LF_CODELIEUFACTURATION"].ToString();
					clsPhaparprixtypeclients.Add(clsPhaparprixtypeclient);
				}
				Dataset.Dispose();
			}
		return clsPhaparprixtypeclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARPRIXTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgInsertIntoDatasetArticlePrixTypeClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CODETYPECLIENT",  "@TA_CODETYPEARTICLE","@JF_CODETYPEJOURFACTURATION", "@LF_CODELIEUFACTURATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5], clsDonnee.vogCleCryptage };

            this.vapRequete = "SELECT * ,TA_MARGEBENEFICIAIRE='0' FROM dbo.FC_STOCKARTICLEPRIXTYPECLIENT1(@AG_CODEAGENCE,@EN_CODEENTREPOT, @CODETYPECLIENT,  @TA_CODETYPEARTICLE,@JF_CODETYPEJOURFACTURATION,@LF_CODELIEUFACTURATION,@CODECRYPTAGE ) ORDER BY AR_NOMCOMMERCIALE" + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, NT_CODENATURETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AR_CODEARTICLE , PY_PRIXVENTE FROM dbo.PHAPARPRIXTYPECLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AR_CODEARTICLE, NT_CODENATURETIERS)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;


				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                vapNomParametre = new string[] { "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{vppCritere[0]};
				break;

                case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
                vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
                break;

				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  EN_CODEENTREPOT=@EN_CODEENTREPOT  AND AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2]};
				break;

				case 4 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  EN_CODEENTREPOT=@EN_CODEENTREPOT AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS" };
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;

                case 5 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  EN_CODEENTREPOT=@EN_CODEENTREPOT AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS AND PY_DATETARIFICATION=@PY_DATETARIFICATION  ";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_DATETARIFICATION" };
                vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
                break;


                case 6:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  EN_CODEENTREPOT=@EN_CODEENTREPOT AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS AND JF_CODETYPEJOURFACTURATION=@JF_CODETYPEJOURFACTURATION AND LF_CODELIEUFACTURATION=@LF_CODELIEUFACTURATION";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@JF_CODETYPEJOURFACTURATION", "@LF_CODELIEUFACTURATION" };
                vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
                break;


               

                case 7 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  EN_CODEENTREPOT=@EN_CODEENTREPOT AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS AND PY_DATETARIFICATION=@PY_DATETARIFICATION AND JF_CODETYPEJOURFACTURATION=@JF_CODETYPEJOURFACTURATION AND LF_CODELIEUFACTURATION=@LF_CODELIEUFACTURATION  ";
                vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_DATETARIFICATION", "@JF_CODETYPEJOURFACTURATION", "@LF_CODELIEUFACTURATION" };
                vapValeurParametre = new object[]{vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
                break;


			}



		}




        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AR_CODEARTICLE, NT_CODENATURETIERS)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
                    break;


                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  EN_CODEENTREPOT=@EN_CODEENTREPOT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE and EN_CODEENTREPOT=@EN_CODEENTREPOT and AR_CODEARTICLE=@AR_CODEARTICLE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1] ,vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND  AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;


                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS AND PY_DATETARIFICATION=@PY_DATETARIFICATION  ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_DATETARIFICATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] , vppCritere[4] };
                    break;

                case 6:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND AR_CODEARTICLE=@AR_CODEARTICLE AND NT_CODENATURETIERS=@NT_CODENATURETIERS AND PY_DATETARIFICATION=@PY_DATETARIFICATION  AND JF_CODETYPEJOURFACTURATION=@JF_CODETYPEJOURFACTURATION   AND LF_CODELIEUFACTURATION=@LF_CODELIEUFACTURATION ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@AR_CODEARTICLE", "@NT_CODENATURETIERS", "@PY_DATETARIFICATION", "@JF_CODETYPEJOURFACTURATION", "@LF_CODELIEUFACTURATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] , vppCritere[4], vppCritere[5] , vppCritere[6] };
                break;



            }



        }




	}
}
