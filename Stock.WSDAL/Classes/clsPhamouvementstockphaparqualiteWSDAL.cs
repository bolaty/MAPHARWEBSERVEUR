using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockphaparqualiteWSDAL: ITableDAL<clsPhamouvementstockphaparqualite>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MS_NUMPIECE) AS MS_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKPHAPARQUALITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MS_NUMPIECE) AS MS_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKPHAPARQUALITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MS_NUMPIECE) AS MS_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKPHAPARQUALITE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockphaparqualite comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockphaparqualite pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT QT_MONTANT  , QT_DESCRIPTION  FROM dbo.FT_PHAMOUVEMENTSTOCKPHAPARQUALITE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockphaparqualite clsPhamouvementstockphaparqualite = new clsPhamouvementstockphaparqualite();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockphaparqualite.QT_MONTANT = double.Parse(clsDonnee.vogDataReader["QT_MONTANT"].ToString());
					clsPhamouvementstockphaparqualite.QT_DESCRIPTION = clsDonnee.vogDataReader["QT_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockphaparqualite;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockphaparqualite>clsPhamouvementstockphaparqualite</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockphaparqualite clsPhamouvementstockphaparqualite)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 50);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockphaparqualite.AG_CODEAGENCE;

			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE1", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstockphaparqualite.MS_NUMPIECE ;
			SqlParameter vppParamQT_CODEQUALITE = new SqlParameter("@QT_CODEQUALITE", SqlDbType.VarChar, 4);
			vppParamQT_CODEQUALITE.Value  = clsPhamouvementstockphaparqualite.QT_CODEQUALITE ;
			SqlParameter vppParamQT_MONTANT = new SqlParameter("@QT_MONTANT", SqlDbType.Money);
			vppParamQT_MONTANT.Value  = clsPhamouvementstockphaparqualite.QT_MONTANT ;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockphaparqualite.OP_CODEOPERATEUR;

			SqlParameter vppParamQT_DESCRIPTION = new SqlParameter("@QT_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamQT_DESCRIPTION.Value  = clsPhamouvementstockphaparqualite.QT_DESCRIPTION ;
			if(clsPhamouvementstockphaparqualite.QT_DESCRIPTION== ""  ) vppParamQT_DESCRIPTION.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKPHAPARQUALITE  @AG_CODEAGENCE1,@MS_NUMPIECE1, @QT_CODEQUALITE, @QT_MONTANT, @QT_DESCRIPTION,@OP_CODEOPERATEUR, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamQT_CODEQUALITE);
			vppSqlCmd.Parameters.Add(vppParamQT_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamQT_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockphaparqualite>clsPhamouvementstockphaparqualite</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockphaparqualite clsPhamouvementstockphaparqualite,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 50);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockphaparqualite.AG_CODEAGENCE;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstockphaparqualite.MS_NUMPIECE ;
			SqlParameter vppParamQT_CODEQUALITE = new SqlParameter("@QT_CODEQUALITE", SqlDbType.VarChar, 4);
			vppParamQT_CODEQUALITE.Value  = clsPhamouvementstockphaparqualite.QT_CODEQUALITE ;
			SqlParameter vppParamQT_MONTANT = new SqlParameter("@QT_MONTANT", SqlDbType.Money);
			vppParamQT_MONTANT.Value  = clsPhamouvementstockphaparqualite.QT_MONTANT ;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockphaparqualite.OP_CODEOPERATEUR;
			SqlParameter vppParamQT_DESCRIPTION = new SqlParameter("@QT_DESCRIPTION", SqlDbType.VarChar, 150);
			vppParamQT_DESCRIPTION.Value  = clsPhamouvementstockphaparqualite.QT_DESCRIPTION ;
			if(clsPhamouvementstockphaparqualite.QT_DESCRIPTION== ""  ) vppParamQT_DESCRIPTION.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKPHAPARQUALITE @AG_CODEAGENCE, @MS_NUMPIECE, @QT_CODEQUALITE, @QT_MONTANT, @QT_DESCRIPTION,@OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamQT_CODEQUALITE);
			vppSqlCmd.Parameters.Add(vppParamQT_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamQT_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKPHAPARQUALITE  @AG_CODEAGENCE, @MS_NUMPIECE, '', '' , '' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockphaparqualite </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockphaparqualite> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MS_NUMPIECE, QT_CODEQUALITE, QT_MONTANT, QT_DESCRIPTION FROM dbo.FT_PHAMOUVEMENTSTOCKPHAPARQUALITE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockphaparqualite> clsPhamouvementstockphaparqualites = new List<clsPhamouvementstockphaparqualite>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockphaparqualite clsPhamouvementstockphaparqualite = new clsPhamouvementstockphaparqualite();
					clsPhamouvementstockphaparqualite.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementstockphaparqualite.QT_CODEQUALITE = clsDonnee.vogDataReader["QT_CODEQUALITE"].ToString();
					clsPhamouvementstockphaparqualite.QT_MONTANT = double.Parse(clsDonnee.vogDataReader["QT_MONTANT"].ToString());
					clsPhamouvementstockphaparqualite.QT_DESCRIPTION = clsDonnee.vogDataReader["QT_DESCRIPTION"].ToString();
					clsPhamouvementstockphaparqualites.Add(clsPhamouvementstockphaparqualite);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockphaparqualites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockphaparqualite </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockphaparqualite> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockphaparqualite> clsPhamouvementstockphaparqualites = new List<clsPhamouvementstockphaparqualite>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MS_NUMPIECE, QT_CODEQUALITE, QT_MONTANT, QT_DESCRIPTION FROM dbo.FT_PHAMOUVEMENTSTOCKPHAPARQUALITE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockphaparqualite clsPhamouvementstockphaparqualite = new clsPhamouvementstockphaparqualite();
					clsPhamouvementstockphaparqualite.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhamouvementstockphaparqualite.QT_CODEQUALITE = Dataset.Tables["TABLE"].Rows[Idx]["QT_CODEQUALITE"].ToString();
					clsPhamouvementstockphaparqualite.QT_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["QT_MONTANT"].ToString());
					clsPhamouvementstockphaparqualite.QT_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["QT_DESCRIPTION"].ToString();
					clsPhamouvementstockphaparqualites.Add(clsPhamouvementstockphaparqualite);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockphaparqualites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "EXEC PS_PHAMOUVEMENTSTOCKPHAPARQUALITE @AG_CODEAGENCE,@MS_NUMPIECE,@CODECRYPTAGE ";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MS_NUMPIECE, QT_CODEQUALITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MS_NUMPIECE , QT_MONTANT FROM dbo.FT_PHAMOUVEMENTSTOCKPHAPARQUALITE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MS_NUMPIECE, QT_CODEQUALITE)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

                case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND MS_NUMPIECE=@MS_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
                break;

				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND QT_CODEQUALITE=@QT_CODEQUALITE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@QT_CODEQUALITE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
