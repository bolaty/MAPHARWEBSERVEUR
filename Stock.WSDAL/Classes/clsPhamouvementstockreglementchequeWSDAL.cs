using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockreglementchequeWSDAL: ITableDAL<clsPhamouvementstockreglementcheque>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT COUNT(AB_CODEAGENCEBANCAIRE) AS AB_CODEAGENCEBANCAIRE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTCHEQUE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(AB_CODEAGENCEBANCAIRE) AS AB_CODEAGENCEBANCAIRE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTCHEQUE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AB_CODEAGENCEBANCAIRE) AS AB_CODEAGENCEBANCAIRE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTCHEQUE" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglementcheque comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglementcheque pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , MS_NUMPIECE  ,  RC_NUMEROCHEQUE    FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCHEQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new clsPhamouvementstockreglementcheque();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementcheque.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockreglementcheque.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					
					clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE = clsDonnee.vogDataReader["RC_NUMEROCHEQUE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockreglementcheque;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementcheque>clsPhamouvementstockreglementcheque</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstockreglementcheque.AG_CODEAGENCE ;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 25);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstockreglementcheque.MS_NUMPIECE ;
			SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.VarChar, 25);
			vppParamAB_CODEAGENCEBANCAIRE.Value  = clsPhamouvementstockreglementcheque.AB_CODEAGENCEBANCAIRE ;
			SqlParameter vppParamRC_NUMEROCHEQUE = new SqlParameter("@RC_NUMEROCHEQUE", SqlDbType.VarChar, 1000);
			vppParamRC_NUMEROCHEQUE.Value  = clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE ;
			if(clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE== ""  ) vppParamRC_NUMEROCHEQUE.Value  = DBNull.Value;
            SqlParameter vppParamRC_VALEURCHEQUE = new SqlParameter("@RC_VALEURCHEQUE", SqlDbType.Money);
            vppParamRC_VALEURCHEQUE.Value = clsPhamouvementstockreglementcheque.RC_VALEURCHEQUE;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTCHEQUE  @AG_CODEAGENCE, @MS_NUMPIECE, @AB_CODEAGENCEBANCAIRE, @RC_NUMEROCHEQUE,@RC_VALEURCHEQUE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamRC_NUMEROCHEQUE);
            vppSqlCmd.Parameters.Add(vppParamRC_VALEURCHEQUE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementcheque>clsPhamouvementstockreglementcheque</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque,params string[] vppCritere)
		{
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglementcheque.AG_CODEAGENCE;
            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 25);
            vppParamMS_NUMPIECE.Value = clsPhamouvementstockreglementcheque.MS_NUMPIECE;
            SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.VarChar, 25);
            vppParamAB_CODEAGENCEBANCAIRE.Value = clsPhamouvementstockreglementcheque.AB_CODEAGENCEBANCAIRE;
            SqlParameter vppParamRC_NUMEROCHEQUE = new SqlParameter("@RC_NUMEROCHEQUE", SqlDbType.VarChar, 1000);
            vppParamRC_NUMEROCHEQUE.Value = clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE;
            if (clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE == "") vppParamRC_NUMEROCHEQUE.Value = DBNull.Value;
            SqlParameter vppParamRC_VALEURCHEQUE = new SqlParameter("@RC_VALEURCHEQUE", SqlDbType.Money);
            vppParamRC_VALEURCHEQUE.Value = clsPhamouvementstockreglementcheque.RC_VALEURCHEQUE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTCHEQUE  @AG_CODEAGENCE, @MS_NUMPIECE, @AB_CODEAGENCEBANCAIRE, @RC_NUMEROCHEQUE, @RC_VALEURCHEQUE, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
            vppSqlCmd.Parameters.Add(vppParamRC_NUMEROCHEQUE);
            vppSqlCmd.Parameters.Add(vppParamRC_VALEURCHEQUE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTCHEQUE  @AG_CODEAGENCE, @MS_NUMPIECE, @AB_CODEAGENCEBANCAIRE,  '' , '' ,0, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementcheque </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementcheque> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE,  RC_NUMEROCHEQUE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCHEQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques = new List<clsPhamouvementstockreglementcheque>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new clsPhamouvementstockreglementcheque();
					clsPhamouvementstockreglementcheque.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockreglementcheque.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementstockreglementcheque.AB_CODEAGENCEBANCAIRE = clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString();
					clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE = clsDonnee.vogDataReader["RC_NUMEROCHEQUE"].ToString();
					clsPhamouvementstockreglementcheques.Add(clsPhamouvementstockreglementcheque);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockreglementcheques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementcheque </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementcheque> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques = new List<clsPhamouvementstockreglementcheque>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE,  RC_NUMEROCHEQUE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCHEQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockreglementcheque clsPhamouvementstockreglementcheque = new clsPhamouvementstockreglementcheque();
					clsPhamouvementstockreglementcheque.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockreglementcheque.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhamouvementstockreglementcheque.AB_CODEAGENCEBANCAIRE = Dataset.Tables["TABLE"].Rows[Idx]["AB_CODEAGENCEBANCAIRE"].ToString();
					clsPhamouvementstockreglementcheque.RC_NUMEROCHEQUE = Dataset.Tables["TABLE"].Rows[Idx]["RC_NUMEROCHEQUE"].ToString();
					clsPhamouvementstockreglementcheques.Add(clsPhamouvementstockreglementcheque);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockreglementcheques;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCHEQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AB_CODEAGENCEBANCAIRE , DC_BRANCHE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCHEQUE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, MS_NUMPIECE, AB_CODEAGENCEBANCAIRE)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE AND AB_CODEAGENCEBANCAIRE=@AB_CODEAGENCEBANCAIRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MS_NUMPIECE","@AB_CODEAGENCEBANCAIRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
