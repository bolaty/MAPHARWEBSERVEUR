using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaecheancierWSDAL: ITableDAL<clsPhaecheancier>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.PHAECHEANCIER " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.PHAECHEANCIER" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.PHAECHEANCIER " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaecheancier comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaecheancier pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT TI_IDTIERS  , MS_NUMPIECE  , EC_MONTANTECHEANCE  , EC_DATEECHEANCE  , TEST  FROM dbo.FT_PHAECHEANCIER(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaecheancier clsPhaecheancier = new clsPhaecheancier();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaecheancier.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhaecheancier.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhaecheancier.EC_MONTANTECHEANCE = double.Parse(clsDonnee.vogDataReader["EC_MONTANTECHEANCE"].ToString());
					clsPhaecheancier.EC_DATEECHEANCE = DateTime.Parse(clsDonnee.vogDataReader["EC_DATEECHEANCE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaecheancier;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaecheancier>clsPhaecheancier</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaecheancier clsPhaecheancier)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhaecheancier.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsPhaecheancier.TI_IDTIERS ;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE1", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhaecheancier.MS_NUMPIECE ;
			if(clsPhaecheancier.MS_NUMPIECE== ""  ) vppParamMS_NUMPIECE.Value  = DBNull.Value;
			SqlParameter vppParamEC_MONTANTECHEANCE = new SqlParameter("@EC_MONTANTECHEANCE", SqlDbType.Money);
			vppParamEC_MONTANTECHEANCE.Value  = clsPhaecheancier.EC_MONTANTECHEANCE ;
			SqlParameter vppParamEC_DATEECHEANCE = new SqlParameter("@EC_DATEECHEANCE", SqlDbType.DateTime);
			vppParamEC_DATEECHEANCE.Value  = clsPhaecheancier.EC_DATEECHEANCE ;
		
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAECHEANCIER  @AG_CODEAGENCE1, @TI_IDTIERS, @MS_NUMPIECE1, @EC_MONTANTECHEANCE, @EC_DATEECHEANCE,  @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamEC_MONTANTECHEANCE);
			vppSqlCmd.Parameters.Add(vppParamEC_DATEECHEANCE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaecheancier>clsPhaecheancier</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaecheancier clsPhaecheancier,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhaecheancier.AG_CODEAGENCE ;
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsPhaecheancier.TI_IDTIERS ;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhaecheancier.MS_NUMPIECE ;
			if(clsPhaecheancier.MS_NUMPIECE== ""  ) vppParamMS_NUMPIECE.Value  = DBNull.Value;
			SqlParameter vppParamEC_MONTANTECHEANCE = new SqlParameter("@EC_MONTANTECHEANCE", SqlDbType.Money);
			vppParamEC_MONTANTECHEANCE.Value  = clsPhaecheancier.EC_MONTANTECHEANCE ;
			SqlParameter vppParamEC_DATEECHEANCE = new SqlParameter("@EC_DATEECHEANCE", SqlDbType.DateTime);
			vppParamEC_DATEECHEANCE.Value  = clsPhaecheancier.EC_DATEECHEANCE ;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAECHEANCIER  @AG_CODEAGENCE, @TI_IDTIERS, @MS_NUMPIECE, @EC_MONTANTECHEANCE, @EC_DATEECHEANCE,  @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamEC_MONTANTECHEANCE);
			vppSqlCmd.Parameters.Add(vppParamEC_DATEECHEANCE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAECHEANCIER  @AG_CODEAGENCE, '' , @MS_NUMPIECE , '' , '' ,  @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaecheancier </returns>
		///<author>Home Technology</author>
		public List<clsPhaecheancier> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, MS_NUMPIECE, EC_MONTANTECHEANCE, EC_DATEECHEANCE, TEST FROM dbo.FT_PHAECHEANCIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaecheancier> clsPhaecheanciers = new List<clsPhaecheancier>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaecheancier clsPhaecheancier = new clsPhaecheancier();
					clsPhaecheancier.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhaecheancier.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPhaecheancier.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhaecheancier.EC_MONTANTECHEANCE = double.Parse(clsDonnee.vogDataReader["EC_MONTANTECHEANCE"].ToString());
					clsPhaecheancier.EC_DATEECHEANCE = DateTime.Parse(clsDonnee.vogDataReader["EC_DATEECHEANCE"].ToString());

					clsPhaecheanciers.Add(clsPhaecheancier);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaecheanciers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaecheancier </returns>
		///<author>Home Technology</author>
		public List<clsPhaecheancier> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaecheancier> clsPhaecheanciers = new List<clsPhaecheancier>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, MS_NUMPIECE, EC_MONTANTECHEANCE, EC_DATEECHEANCE, TEST FROM dbo.FT_PHAECHEANCIER(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaecheancier clsPhaecheancier = new clsPhaecheancier();
					clsPhaecheancier.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhaecheancier.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsPhaecheancier.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhaecheancier.EC_MONTANTECHEANCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EC_MONTANTECHEANCE"].ToString());
					clsPhaecheancier.EC_DATEECHEANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EC_DATEECHEANCE"].ToString());
					clsPhaecheanciers.Add(clsPhaecheancier);
				}
				Dataset.Dispose();
			}
		return clsPhaecheanciers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAECHEANCIER(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetECHEANCIER(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MS_NUMPIECE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };

            this.vapRequete = "EXECUTE PS_ECHEANCIER  @AG_CODEAGENCE,@MS_NUMPIECE,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , TI_IDTIERS FROM dbo.FT_PHAECHEANCIER(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE)</summary>
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

                case 2:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE   AND MS_NUMPIECE=@MS_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] , vppCritere[1] };
                break;
			}
		}
	}
}
