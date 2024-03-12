using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCtpartauxautoWSDAL: ITableDAL<clsCtpartauxauto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TX_CODETAUX) AS TX_CODETAUX  FROM dbo.FT_CTPARTAUXAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TX_CODETAUX) AS TX_CODETAUX  FROM dbo.FT_CTPARTAUXAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TX_CODETAUX) AS TX_CODETAUX  FROM dbo.FT_CTPARTAUXAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtpartauxauto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtpartauxauto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TX_DUREEMINIMUM  , TX_DUREEMAXIMUM  , TX_TAUX  FROM dbo.FT_CTPARTAUXAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtpartauxauto clsCtpartauxauto = new clsCtpartauxauto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartauxauto.TX_DUREEMINIMUM = int.Parse(clsDonnee.vogDataReader["TX_DUREEMINIMUM"].ToString());
					clsCtpartauxauto.TX_DUREEMAXIMUM = int.Parse(clsDonnee.vogDataReader["TX_DUREEMAXIMUM"].ToString());
					clsCtpartauxauto.TX_TAUX = decimal.Parse(clsDonnee.vogDataReader["TX_TAUX"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtpartauxauto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartauxauto>clsCtpartauxauto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtpartauxauto clsCtpartauxauto)
		{
			//Préparation des paramètres
			SqlParameter vppParamTX_CODETAUX = new SqlParameter("@TX_CODETAUX", SqlDbType.BigInt);
			vppParamTX_CODETAUX.Value  = clsCtpartauxauto.TX_CODETAUX ;
			SqlParameter vppParamTX_DUREEMINIMUM = new SqlParameter("@TX_DUREEMINIMUM", SqlDbType.Int);
			vppParamTX_DUREEMINIMUM.Value  = clsCtpartauxauto.TX_DUREEMINIMUM ;
			SqlParameter vppParamTX_DUREEMAXIMUM = new SqlParameter("@TX_DUREEMAXIMUM", SqlDbType.Int);
			vppParamTX_DUREEMAXIMUM.Value  = clsCtpartauxauto.TX_DUREEMAXIMUM ;
			SqlParameter vppParamTX_TAUX = new SqlParameter("@TX_TAUX", SqlDbType.Decimal, 4);
			vppParamTX_TAUX.Value  = clsCtpartauxauto.TX_TAUX ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTAUXAUTO  @TX_CODETAUX, @TX_DUREEMINIMUM, @TX_DUREEMAXIMUM, @TX_TAUX, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTX_CODETAUX);
			vppSqlCmd.Parameters.Add(vppParamTX_DUREEMINIMUM);
			vppSqlCmd.Parameters.Add(vppParamTX_DUREEMAXIMUM);
			vppSqlCmd.Parameters.Add(vppParamTX_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtpartauxauto>clsCtpartauxauto</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCtpartauxauto clsCtpartauxauto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTX_CODETAUX = new SqlParameter("@TX_CODETAUX", SqlDbType.BigInt);
			vppParamTX_CODETAUX.Value  = clsCtpartauxauto.TX_CODETAUX ;
			SqlParameter vppParamTX_DUREEMINIMUM = new SqlParameter("@TX_DUREEMINIMUM", SqlDbType.Int);
			vppParamTX_DUREEMINIMUM.Value  = clsCtpartauxauto.TX_DUREEMINIMUM ;
			SqlParameter vppParamTX_DUREEMAXIMUM = new SqlParameter("@TX_DUREEMAXIMUM", SqlDbType.Int);
			vppParamTX_DUREEMAXIMUM.Value  = clsCtpartauxauto.TX_DUREEMAXIMUM ;
			SqlParameter vppParamTX_TAUX = new SqlParameter("@TX_TAUX", SqlDbType.Decimal, 4);
			vppParamTX_TAUX.Value  = clsCtpartauxauto.TX_TAUX ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTAUXAUTO  @TX_CODETAUX, @TX_DUREEMINIMUM, @TX_DUREEMAXIMUM, @TX_TAUX, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTX_CODETAUX);
			vppSqlCmd.Parameters.Add(vppParamTX_DUREEMINIMUM);
			vppSqlCmd.Parameters.Add(vppParamTX_DUREEMAXIMUM);
			vppSqlCmd.Parameters.Add(vppParamTX_TAUX);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTPARTAUXAUTO  @TX_CODETAUX, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartauxauto </returns>
		///<author>Home Technology</author>
		public List<clsCtpartauxauto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TX_CODETAUX, TX_DUREEMINIMUM, TX_DUREEMAXIMUM, TX_TAUX FROM dbo.FT_CTPARTAUXAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtpartauxauto> clsCtpartauxautos = new List<clsCtpartauxauto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtpartauxauto clsCtpartauxauto = new clsCtpartauxauto();
					clsCtpartauxauto.TX_CODETAUX = double.Parse(clsDonnee.vogDataReader["TX_CODETAUX"].ToString());
					clsCtpartauxauto.TX_DUREEMINIMUM = int.Parse(clsDonnee.vogDataReader["TX_DUREEMINIMUM"].ToString());
					clsCtpartauxauto.TX_DUREEMAXIMUM = int.Parse(clsDonnee.vogDataReader["TX_DUREEMAXIMUM"].ToString());
					clsCtpartauxauto.TX_TAUX = decimal.Parse(clsDonnee.vogDataReader["TX_TAUX"].ToString());
					clsCtpartauxautos.Add(clsCtpartauxauto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtpartauxautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtpartauxauto </returns>
		///<author>Home Technology</author>
		public List<clsCtpartauxauto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtpartauxauto> clsCtpartauxautos = new List<clsCtpartauxauto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TX_CODETAUX, TX_DUREEMINIMUM, TX_DUREEMAXIMUM, TX_TAUX FROM dbo.FT_CTPARTAUXAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtpartauxauto clsCtpartauxauto = new clsCtpartauxauto();
					clsCtpartauxauto.TX_CODETAUX = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TX_CODETAUX"].ToString());
					clsCtpartauxauto.TX_DUREEMINIMUM = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TX_DUREEMINIMUM"].ToString());
					clsCtpartauxauto.TX_DUREEMAXIMUM = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TX_DUREEMAXIMUM"].ToString());
					clsCtpartauxauto.TX_TAUX = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TX_TAUX"].ToString());
					clsCtpartauxautos.Add(clsCtpartauxauto);
				}
				Dataset.Dispose();
			}
		return clsCtpartauxautos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CTPARTAUXAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TX_CODETAUX , TX_DUREEMINIMUM FROM dbo.FT_CTPARTAUXAUTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TX_CODETAUX ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetSelonDuree(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE" , "@CA_DATEEFFET", "@CA_DATEECHEANCE" , "@TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] , vppCritere[2]};
            this.vapRequete = "EXEC [dbo].[PS_CTPARTAUXAUTO] @CA_DATEEFFET	,@CA_DATEECHEANCE,@TYPEETAT,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }





        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TX_CODETAUX)</summary>
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
				this.vapCritere ="WHERE TX_CODETAUX=@TX_CODETAUX";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TX_CODETAUX"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
