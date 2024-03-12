using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparprixprestationWSDAL: ITableDAL<clsPhaparprixprestation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PS_CODEPRESTATION) AS PS_CODEPRESTATION  FROM dbo.PHAPARPRIXPRESTATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PS_CODEPRESTATION) AS PS_CODEPRESTATION  FROM dbo.PHAPARPRIXPRESTATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PS_CODEPRESTATION) AS PS_CODEPRESTATION  FROM dbo.PHAPARPRIXPRESTATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparprixprestation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparprixprestation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PP_MONTANTPRESATION  , PP_TAUXREMISE  , PP_MONTANTREMISE  , PP_TAUXCOMMISSION  , PP_MONTANTCOMMISSION  , PP_DATEREMISE1  , PP_DATEREMISE2  , PP_DATETARIFICATION  FROM dbo.PHAPARPRIXPRESTATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparprixprestation clsPhaparprixprestation = new clsPhaparprixprestation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprixprestation.PP_MONTANTPRESATION = double.Parse(clsDonnee.vogDataReader["PP_MONTANTPRESATION"].ToString());
					clsPhaparprixprestation.PP_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["PP_TAUXREMISE"].ToString());
					clsPhaparprixprestation.PP_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["PP_MONTANTREMISE"].ToString());
					clsPhaparprixprestation.PP_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["PP_TAUXCOMMISSION"].ToString());
					clsPhaparprixprestation.PP_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["PP_MONTANTCOMMISSION"].ToString());
					clsPhaparprixprestation.PP_DATEREMISE1 = DateTime.Parse(clsDonnee.vogDataReader["PP_DATEREMISE1"].ToString());
					clsPhaparprixprestation.PP_DATEREMISE2 = DateTime.Parse(clsDonnee.vogDataReader["PP_DATEREMISE2"].ToString());
					clsPhaparprixprestation.PP_DATETARIFICATION = DateTime.Parse(clsDonnee.vogDataReader["PP_DATETARIFICATION"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparprixprestation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprixprestation>clsPhaparprixprestation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparprixprestation clsPhaparprixprestation)
		{
			//Préparation des paramètres
			SqlParameter vppParamPS_CODEPRESTATION = new SqlParameter("@PS_CODEPRESTATION", SqlDbType.VarChar, 7);
			vppParamPS_CODEPRESTATION.Value  = clsPhaparprixprestation.PS_CODEPRESTATION ;

			SqlParameter vppParamTP_CODETYPECLIENT = new SqlParameter("@TP_CODETYPECLIENT", SqlDbType.VarChar, 3);
			vppParamTP_CODETYPECLIENT.Value  = clsPhaparprixprestation.TP_CODETYPECLIENT ;

			SqlParameter vppParamPP_MONTANTPRESATION = new SqlParameter("@PP_MONTANTPRESATION", SqlDbType.Money);
			vppParamPP_MONTANTPRESATION.Value  = clsPhaparprixprestation.PP_MONTANTPRESATION ;

			SqlParameter vppParamPP_TAUXREMISE = new SqlParameter("@PP_TAUXREMISE", SqlDbType.Float);
			vppParamPP_TAUXREMISE.Value  = clsPhaparprixprestation.PP_TAUXREMISE ;

			SqlParameter vppParamPP_MONTANTREMISE = new SqlParameter("@PP_MONTANTREMISE", SqlDbType.Money);
			vppParamPP_MONTANTREMISE.Value  = clsPhaparprixprestation.PP_MONTANTREMISE ;

			SqlParameter vppParamPP_TAUXCOMMISSION = new SqlParameter("@PP_TAUXCOMMISSION", SqlDbType.Float);
			vppParamPP_TAUXCOMMISSION.Value  = clsPhaparprixprestation.PP_TAUXCOMMISSION ;

			SqlParameter vppParamPP_MONTANTCOMMISSION = new SqlParameter("@PP_MONTANTCOMMISSION", SqlDbType.Money);
			vppParamPP_MONTANTCOMMISSION.Value  = clsPhaparprixprestation.PP_MONTANTCOMMISSION ;

			SqlParameter vppParamPP_DATEREMISE1 = new SqlParameter("@PP_DATEREMISE1", SqlDbType.DateTime);
			vppParamPP_DATEREMISE1.Value  = clsPhaparprixprestation.PP_DATEREMISE1 ;

			SqlParameter vppParamPP_DATEREMISE2 = new SqlParameter("@PP_DATEREMISE2", SqlDbType.DateTime);
			vppParamPP_DATEREMISE2.Value  = clsPhaparprixprestation.PP_DATEREMISE2 ;

			SqlParameter vppParamPP_DATETARIFICATION = new SqlParameter("@PP_DATETARIFICATION", SqlDbType.DateTime);
			vppParamPP_DATETARIFICATION.Value  = clsPhaparprixprestation.PP_DATETARIFICATION ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PHAPARPRIXPRESTATION (  PS_CODEPRESTATION, TP_CODETYPECLIENT, PP_MONTANTPRESATION, PP_TAUXREMISE, PP_MONTANTREMISE, PP_TAUXCOMMISSION, PP_MONTANTCOMMISSION, PP_DATEREMISE1, PP_DATEREMISE2, PP_DATETARIFICATION) " +
					 "VALUES ( @PS_CODEPRESTATION, @TP_CODETYPECLIENT, @PP_MONTANTPRESATION, @PP_TAUXREMISE, @PP_MONTANTREMISE, @PP_TAUXCOMMISSION, @PP_MONTANTCOMMISSION, @PP_DATEREMISE1, @PP_DATEREMISE2, @PP_DATETARIFICATION) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPS_CODEPRESTATION);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPECLIENT);
			vppSqlCmd.Parameters.Add(vppParamPP_MONTANTPRESATION);
			vppSqlCmd.Parameters.Add(vppParamPP_TAUXREMISE);
			vppSqlCmd.Parameters.Add(vppParamPP_MONTANTREMISE);
			vppSqlCmd.Parameters.Add(vppParamPP_TAUXCOMMISSION);
			vppSqlCmd.Parameters.Add(vppParamPP_MONTANTCOMMISSION);
			vppSqlCmd.Parameters.Add(vppParamPP_DATEREMISE1);
			vppSqlCmd.Parameters.Add(vppParamPP_DATEREMISE2);
			vppSqlCmd.Parameters.Add(vppParamPP_DATETARIFICATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparprixprestation>clsPhaparprixprestation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>

        public void pvgUpdate(clsDonnee clsDonnee, clsPhaparprixprestation clsPhaparprixprestation, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@PS_CODEPRESTATION", "@TP_CODETYPECLIENT", "@PP_MONTANTPRESATION", "@PP_DATETARIFICATION" };
            vapValeurParametre = new object[] { clsPhaparprixprestation.PS_CODEPRESTATION, clsPhaparprixprestation.TP_CODETYPECLIENT, clsPhaparprixprestation.PP_MONTANTPRESATION, clsPhaparprixprestation.PP_DATETARIFICATION };

            //Préparation des paramètres
            this.vapRequete = " EXEC DBO.PS_MAJPRIXPRESTATION  @PS_CODEPRESTATION, @TP_CODETYPECLIENT, @PP_MONTANTPRESATION, @PP_DATETARIFICATION ";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PHAPARPRIXPRESTATION "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprixprestation </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprixprestation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PS_CODEPRESTATION, TP_CODETYPECLIENT, PP_MONTANTPRESATION, PP_TAUXREMISE, PP_MONTANTREMISE, PP_TAUXCOMMISSION, PP_MONTANTCOMMISSION, PP_DATEREMISE1, PP_DATEREMISE2, PP_DATETARIFICATION FROM dbo.PHAPARPRIXPRESTATION " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparprixprestation> clsPhaparprixprestations = new List<clsPhaparprixprestation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparprixprestation clsPhaparprixprestation = new clsPhaparprixprestation();
					clsPhaparprixprestation.PS_CODEPRESTATION = clsDonnee.vogDataReader["PS_CODEPRESTATION"].ToString();
					clsPhaparprixprestation.TP_CODETYPECLIENT = clsDonnee.vogDataReader["TP_CODETYPECLIENT"].ToString();
					clsPhaparprixprestation.PP_MONTANTPRESATION = double.Parse(clsDonnee.vogDataReader["PP_MONTANTPRESATION"].ToString());
					clsPhaparprixprestation.PP_TAUXREMISE = float.Parse(clsDonnee.vogDataReader["PP_TAUXREMISE"].ToString());
					clsPhaparprixprestation.PP_MONTANTREMISE = double.Parse(clsDonnee.vogDataReader["PP_MONTANTREMISE"].ToString());
					clsPhaparprixprestation.PP_TAUXCOMMISSION = float.Parse(clsDonnee.vogDataReader["PP_TAUXCOMMISSION"].ToString());
					clsPhaparprixprestation.PP_MONTANTCOMMISSION = double.Parse(clsDonnee.vogDataReader["PP_MONTANTCOMMISSION"].ToString());
					clsPhaparprixprestation.PP_DATEREMISE1 = DateTime.Parse(clsDonnee.vogDataReader["PP_DATEREMISE1"].ToString());
					clsPhaparprixprestation.PP_DATEREMISE2 = DateTime.Parse(clsDonnee.vogDataReader["PP_DATEREMISE2"].ToString());
					clsPhaparprixprestation.PP_DATETARIFICATION = DateTime.Parse(clsDonnee.vogDataReader["PP_DATETARIFICATION"].ToString());
					clsPhaparprixprestations.Add(clsPhaparprixprestation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparprixprestations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparprixprestation </returns>
		///<author>Home Technology</author>
		public List<clsPhaparprixprestation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparprixprestation> clsPhaparprixprestations = new List<clsPhaparprixprestation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PS_CODEPRESTATION, TP_CODETYPECLIENT, PP_MONTANTPRESATION, PP_TAUXREMISE, PP_MONTANTREMISE, PP_TAUXCOMMISSION, PP_MONTANTCOMMISSION, PP_DATEREMISE1, PP_DATEREMISE2, PP_DATETARIFICATION FROM dbo.PHAPARPRIXPRESTATION " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparprixprestation clsPhaparprixprestation = new clsPhaparprixprestation();
					clsPhaparprixprestation.PS_CODEPRESTATION = Dataset.Tables["TABLE"].Rows[Idx]["PS_CODEPRESTATION"].ToString();
					clsPhaparprixprestation.TP_CODETYPECLIENT = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPECLIENT"].ToString();
					clsPhaparprixprestation.PP_MONTANTPRESATION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_MONTANTPRESATION"].ToString());
					clsPhaparprixprestation.PP_TAUXREMISE = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_TAUXREMISE"].ToString());
					clsPhaparprixprestation.PP_MONTANTREMISE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_MONTANTREMISE"].ToString());
					clsPhaparprixprestation.PP_TAUXCOMMISSION = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_TAUXCOMMISSION"].ToString());
					clsPhaparprixprestation.PP_MONTANTCOMMISSION = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_MONTANTCOMMISSION"].ToString());
					clsPhaparprixprestation.PP_DATEREMISE1 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_DATEREMISE1"].ToString());
					clsPhaparprixprestation.PP_DATEREMISE2 = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_DATEREMISE2"].ToString());
					clsPhaparprixprestation.PP_DATETARIFICATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_DATETARIFICATION"].ToString());
					clsPhaparprixprestations.Add(clsPhaparprixprestation);
				}
				Dataset.Dispose();
			}
		return clsPhaparprixprestations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.PHAPARPRIXPRESTATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsDonnee"></param>
        /// <param name="vppCritere">UN SEUL CRITERE OBLIGATOIRE @CODETYPECLIENT</param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetPrixPrestationTypeClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODETYPECLIENT" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };

            this.vapRequete = "SELECT *  FROM dbo.FC_PRESTATIONPRIXTYPECLIENT( @CODETYPECLIENT  ) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PS_CODEPRESTATION, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PS_CODEPRESTATION , PP_MONTANTPRESATION FROM dbo.PHAPARPRIXPRESTATION " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PS_CODEPRESTATION, TP_CODETYPECLIENT)</summary>
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
				this.vapCritere ="WHERE PS_CODEPRESTATION=@PS_CODEPRESTATION";
				vapNomParametre = new string[]{"@PS_CODEPRESTATION"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PS_CODEPRESTATION=@PS_CODEPRESTATION AND TP_CODETYPECLIENT=@TP_CODETYPECLIENT";
				vapNomParametre = new string[]{"@PS_CODEPRESTATION","@TP_CODETYPECLIENT"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
