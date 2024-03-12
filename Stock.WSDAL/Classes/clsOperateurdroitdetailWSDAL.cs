using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsOperateurdroitdetailWSDAL: ITableDAL<clsOperateurdroitdetail>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(OP_CODEOBJET) AS OP_CODEOBJET  FROM dbo.FT_OPERATEURDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(OP_CODEOBJET) AS OP_CODEOBJET  FROM dbo.FT_OPERATEURDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(OP_CODEOBJET) AS OP_CODEOBJET  FROM dbo.FT_OPERATEURDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsOperateurdroitdetail comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsOperateurdroitdetail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , OD_AUTORISER  , OD_NUMEROORDRE  FROM dbo.FT_OPERATEURDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsOperateurdroitdetail clsOperateurdroitdetail = new clsOperateurdroitdetail();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroitdetail.AG_CODEAGENCE = double.Parse(clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString());
					clsOperateurdroitdetail.OD_AUTORISER = clsDonnee.vogDataReader["OD_AUTORISER"].ToString();
					clsOperateurdroitdetail.OD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["OD_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsOperateurdroitdetail;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOperateurdroitdetail>clsOperateurdroitdetail</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsOperateurdroitdetail clsOperateurdroitdetail)
		{
			//Préparation des paramètres
			SqlParameter vppParamOP_CODEOBJET = new SqlParameter("@OP_CODEOBJET1", SqlDbType.VarChar, 25);
			vppParamOP_CODEOBJET.Value  = clsOperateurdroitdetail.OP_CODEOBJET ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsOperateurdroitdetail.OP_CODEOPERATEUR ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.BigInt);
			vppParamAG_CODEAGENCE.Value  = clsOperateurdroitdetail.AG_CODEAGENCE ;
			SqlParameter vppParamOD_AUTORISER = new SqlParameter("@OD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamOD_AUTORISER.Value  = clsOperateurdroitdetail.OD_AUTORISER ;
			SqlParameter vppParamOD_NUMEROORDRE = new SqlParameter("@OD_NUMEROORDRE", SqlDbType.Int);
			vppParamOD_NUMEROORDRE.Value  = clsOperateurdroitdetail.OD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_OPERATEURDROITDETAIL  @OP_CODEOBJET1, @OP_CODEOPERATEUR1, @AG_CODEAGENCE, @OD_AUTORISER, @OD_NUMEROORDRE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOD_AUTORISER);
			vppSqlCmd.Parameters.Add(vppParamOD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOperateurdroitdetail>clsOperateurdroitdetail</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsOperateurdroitdetail clsOperateurdroitdetail,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamOP_CODEOBJET = new SqlParameter("@OP_CODEOBJET1", SqlDbType.VarChar, 25);
			vppParamOP_CODEOBJET.Value  = clsOperateurdroitdetail.OP_CODEOBJET ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsOperateurdroitdetail.OP_CODEOPERATEUR ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.BigInt);
			vppParamAG_CODEAGENCE.Value  = clsOperateurdroitdetail.AG_CODEAGENCE ;
			SqlParameter vppParamOD_AUTORISER = new SqlParameter("@OD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamOD_AUTORISER.Value  = clsOperateurdroitdetail.OD_AUTORISER ;
			SqlParameter vppParamOD_NUMEROORDRE = new SqlParameter("@OD_NUMEROORDRE", SqlDbType.Int);
			vppParamOD_NUMEROORDRE.Value  = clsOperateurdroitdetail.OD_NUMEROORDRE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_OPERATEURDROITDETAIL  @OP_CODEOBJET1, @OP_CODEOPERATEUR, @AG_CODEAGENCE, @OD_AUTORISER, @OD_NUMEROORDRE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOD_AUTORISER);
			vppSqlCmd.Parameters.Add(vppParamOD_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_OPERATEURDROITDETAIL  @OP_CODEOBJET, @OP_CODEOPERATEUR, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitdetail </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitdetail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  OP_CODEOBJET, OP_CODEOPERATEUR, AG_CODEAGENCE, OD_AUTORISER, OD_NUMEROORDRE FROM dbo.FT_OPERATEURDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsOperateurdroitdetail> clsOperateurdroitdetails = new List<clsOperateurdroitdetail>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroitdetail clsOperateurdroitdetail = new clsOperateurdroitdetail();
					clsOperateurdroitdetail.OP_CODEOBJET = clsDonnee.vogDataReader["OP_CODEOBJET"].ToString();
					clsOperateurdroitdetail.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroitdetail.AG_CODEAGENCE = double.Parse(clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString());
					clsOperateurdroitdetail.OD_AUTORISER = clsDonnee.vogDataReader["OD_AUTORISER"].ToString();
					clsOperateurdroitdetail.OD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["OD_NUMEROORDRE"].ToString());
					clsOperateurdroitdetails.Add(clsOperateurdroitdetail);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsOperateurdroitdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateurdroitdetail </returns>
		///<author>Home Technology</author>
		public List<clsOperateurdroitdetail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsOperateurdroitdetail> clsOperateurdroitdetails = new List<clsOperateurdroitdetail>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  OP_CODEOBJET, OP_CODEOPERATEUR, AG_CODEAGENCE, OD_AUTORISER, OD_NUMEROORDRE FROM dbo.FT_OPERATEURDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsOperateurdroitdetail clsOperateurdroitdetail = new clsOperateurdroitdetail();
					clsOperateurdroitdetail.OP_CODEOBJET = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOBJET"].ToString();
					clsOperateurdroitdetail.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroitdetail.AG_CODEAGENCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString());
					clsOperateurdroitdetail.OD_AUTORISER = Dataset.Tables["TABLE"].Rows[Idx]["OD_AUTORISER"].ToString();
					clsOperateurdroitdetail.OD_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OD_NUMEROORDRE"].ToString());
					clsOperateurdroitdetails.Add(clsOperateurdroitdetail);
				}
				Dataset.Dispose();
			}
		return clsOperateurdroitdetails;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEURDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgInsertIntoDatasetGrille(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OT_CODETYPEOBJET", "@OB_CODEOBJET" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            this.vapRequete = "SELECT * FROM dbo.[FC_OPERATEURDROITDEATAIL] (@OP_CODEOPERATEUR ,@OT_CODETYPEOBJET, @OB_CODEOBJET)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOBJET, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT OP_CODEOBJET , AG_CODEAGENCE FROM dbo.FT_OPERATEURDROITDETAIL(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :OP_CODEOBJET, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE OP_CODEOBJET=@OP_CODEOBJET";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@OP_CODEOBJET"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE  OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@OP_CODEOBJET","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
