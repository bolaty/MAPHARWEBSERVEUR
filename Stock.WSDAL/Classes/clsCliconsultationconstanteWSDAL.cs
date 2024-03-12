using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsCliconsultationconstanteWSDAL: ITableDAL<clsCliconsultationconstante>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONCONSTANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONCONSTANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_CLICONSULTATIONCONSTANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCliconsultationconstante comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCliconsultationconstante pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT IN_CODEINGREDIENT  , CC_VALEUR  , OP_CODEOPERATEUR  FROM dbo.FT_CLICONSULTATIONCONSTANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCliconsultationconstante clsCliconsultationconstante = new clsCliconsultationconstante();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationconstante.IN_CODEINGREDIENT = clsDonnee.vogDataReader["IN_CODEINGREDIENT"].ToString();
					clsCliconsultationconstante.CC_VALEUR = clsDonnee.vogDataReader["CC_VALEUR"].ToString();
					clsCliconsultationconstante.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCliconsultationconstante;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationconstante>clsCliconsultationconstante</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCliconsultationconstante clsCliconsultationconstante)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationconstante.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationconstante.CO_CODECONSULTATION ;
			SqlParameter vppParamCC_NUMSEQUENCE = new SqlParameter("@CC_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamCC_NUMSEQUENCE.Value  = clsCliconsultationconstante.CC_NUMSEQUENCE ;
			SqlParameter vppParamCC_DATESAISIE = new SqlParameter("@CC_DATESAISIE", SqlDbType.DateTime);
			vppParamCC_DATESAISIE.Value  = clsCliconsultationconstante.CC_DATESAISIE ;
			SqlParameter vppParamIN_CODEINGREDIENT = new SqlParameter("@IN_CODEINGREDIENT", SqlDbType.VarChar, 3);
			vppParamIN_CODEINGREDIENT.Value  = clsCliconsultationconstante.IN_CODEINGREDIENT ;
			SqlParameter vppParamCC_VALEUR = new SqlParameter("@CC_VALEUR", SqlDbType.VarChar, 1000);
			vppParamCC_VALEUR.Value  = clsCliconsultationconstante.CC_VALEUR ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationconstante.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONCONSTANTE  @AG_CODEAGENCE, @CO_CODECONSULTATION, @CC_NUMSEQUENCE, @CC_DATESAISIE, @IN_CODEINGREDIENT, @CC_VALEUR, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCC_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCC_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamIN_CODEINGREDIENT);
			vppSqlCmd.Parameters.Add(vppParamCC_VALEUR);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCliconsultationconstante>clsCliconsultationconstante</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsCliconsultationconstante clsCliconsultationconstante,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsCliconsultationconstante.AG_CODEAGENCE ;
			SqlParameter vppParamCO_CODECONSULTATION = new SqlParameter("@CO_CODECONSULTATION", SqlDbType.VarChar, 50);
			vppParamCO_CODECONSULTATION.Value  = clsCliconsultationconstante.CO_CODECONSULTATION ;
			SqlParameter vppParamCC_NUMSEQUENCE = new SqlParameter("@CC_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamCC_NUMSEQUENCE.Value  = clsCliconsultationconstante.CC_NUMSEQUENCE ;
			SqlParameter vppParamCC_DATESAISIE = new SqlParameter("@CC_DATESAISIE", SqlDbType.DateTime);
			vppParamCC_DATESAISIE.Value  = clsCliconsultationconstante.CC_DATESAISIE ;
			SqlParameter vppParamIN_CODEINGREDIENT = new SqlParameter("@IN_CODEINGREDIENT", SqlDbType.VarChar, 3);
			vppParamIN_CODEINGREDIENT.Value  = clsCliconsultationconstante.IN_CODEINGREDIENT ;
			SqlParameter vppParamCC_VALEUR = new SqlParameter("@CC_VALEUR", SqlDbType.VarChar, 1000);
			vppParamCC_VALEUR.Value  = clsCliconsultationconstante.CC_VALEUR ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsCliconsultationconstante.OP_CODEOPERATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONCONSTANTE  @AG_CODEAGENCE, @CO_CODECONSULTATION, @CC_NUMSEQUENCE, @CC_DATESAISIE, @IN_CODEINGREDIENT, @CC_VALEUR, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCO_CODECONSULTATION);
			vppSqlCmd.Parameters.Add(vppParamCC_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCC_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamIN_CODEINGREDIENT);
			vppSqlCmd.Parameters.Add(vppParamCC_VALEUR);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CLICONSULTATIONCONSTANTE  @AG_CODEAGENCE, @CO_CODECONSULTATION, @CC_NUMSEQUENCE, @CC_DATESAISIE, '' , '' ,'', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationconstante </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationconstante> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, IN_CODEINGREDIENT, CC_VALEUR, OP_CODEOPERATEUR FROM dbo.FT_CLICONSULTATIONCONSTANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCliconsultationconstante> clsCliconsultationconstantes = new List<clsCliconsultationconstante>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCliconsultationconstante clsCliconsultationconstante = new clsCliconsultationconstante();
					clsCliconsultationconstante.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsCliconsultationconstante.CO_CODECONSULTATION = clsDonnee.vogDataReader["CO_CODECONSULTATION"].ToString();
					clsCliconsultationconstante.CC_NUMSEQUENCE = clsDonnee.vogDataReader["CC_NUMSEQUENCE"].ToString();
					clsCliconsultationconstante.CC_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CC_DATESAISIE"].ToString());
					clsCliconsultationconstante.IN_CODEINGREDIENT = clsDonnee.vogDataReader["IN_CODEINGREDIENT"].ToString();
					clsCliconsultationconstante.CC_VALEUR = clsDonnee.vogDataReader["CC_VALEUR"].ToString();
					clsCliconsultationconstante.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationconstantes.Add(clsCliconsultationconstante);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCliconsultationconstantes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCliconsultationconstante </returns>
		///<author>Home Technology</author>
		public List<clsCliconsultationconstante> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCliconsultationconstante> clsCliconsultationconstantes = new List<clsCliconsultationconstante>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, IN_CODEINGREDIENT, CC_VALEUR, OP_CODEOPERATEUR FROM dbo.FT_CLICONSULTATIONCONSTANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCliconsultationconstante clsCliconsultationconstante = new clsCliconsultationconstante();
					clsCliconsultationconstante.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsCliconsultationconstante.CO_CODECONSULTATION = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECONSULTATION"].ToString();
					clsCliconsultationconstante.CC_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["CC_NUMSEQUENCE"].ToString();
					clsCliconsultationconstante.CC_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CC_DATESAISIE"].ToString());
					clsCliconsultationconstante.IN_CODEINGREDIENT = Dataset.Tables["TABLE"].Rows[Idx]["IN_CODEINGREDIENT"].ToString();
					clsCliconsultationconstante.CC_VALEUR = Dataset.Tables["TABLE"].Rows[Idx]["CC_VALEUR"].ToString();
					clsCliconsultationconstante.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsCliconsultationconstantes.Add(clsCliconsultationconstante);
				}
				Dataset.Dispose();
			}
		return clsCliconsultationconstantes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_CLICONSULTATIONCONSTANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , IN_CODEINGREDIENT FROM dbo.FT_CLICONSULTATIONCONSTANTE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CO_CODECONSULTATION, CC_NUMSEQUENCE, CC_DATESAISIE, OP_CODEOPERATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND CC_NUMSEQUENCE=@CC_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@CC_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND CC_NUMSEQUENCE=@CC_NUMSEQUENCE AND CC_DATESAISIE=@CC_DATESAISIE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@CC_NUMSEQUENCE","@CC_DATESAISIE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECONSULTATION=@CO_CODECONSULTATION AND CC_NUMSEQUENCE=@CC_NUMSEQUENCE AND CC_DATESAISIE=@CC_DATESAISIE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@CO_CODECONSULTATION","@CC_NUMSEQUENCE","@CC_DATESAISIE","@OP_CODEOPERATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
			}
		}
	}
}
