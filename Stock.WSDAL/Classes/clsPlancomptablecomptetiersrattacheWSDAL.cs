using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPlancomptablecomptetiersrattacheWSDAL: ITableDAL<clsPlancomptablecomptetiersrattache>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_PLANCOMPTABLECOMPTETIERSRATTACHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_PLANCOMPTABLECOMPTETIERSRATTACHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.FT_PLANCOMPTABLECOMPTETIERSRATTACHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPlancomptablecomptetiersrattache comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPlancomptablecomptetiersrattache pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PL_CODENUMCOMPTE  , COCHER  FROM dbo.FT_PLANCOMPTABLECOMPTETIERSRATTACHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPlancomptablecomptetiersrattache clsPlancomptablecomptetiersrattache = new clsPlancomptablecomptetiersrattache();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPlancomptablecomptetiersrattache.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPlancomptablecomptetiersrattache.COCHER = clsDonnee.vogDataReader["COCHER"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPlancomptablecomptetiersrattache;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlancomptablecomptetiersrattache>clsPlancomptablecomptetiersrattache</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPlancomptablecomptetiersrattache clsPlancomptablecomptetiersrattache)
		{
			//Préparation des paramètres
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS1", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsPlancomptablecomptetiersrattache.TI_IDTIERS ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 50);
			vppParamPL_CODENUMCOMPTE.Value  = clsPlancomptablecomptetiersrattache.PL_CODENUMCOMPTE ;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLECOMPTETIERSRATTACHE  @TI_IDTIERS1, @PL_CODENUMCOMPTE,  @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPlancomptablecomptetiersrattache>clsPlancomptablecomptetiersrattache</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPlancomptablecomptetiersrattache clsPlancomptablecomptetiersrattache,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
			vppParamTI_IDTIERS.Value  = clsPlancomptablecomptetiersrattache.TI_IDTIERS ;
			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 50);
			vppParamPL_CODENUMCOMPTE.Value  = clsPlancomptablecomptetiersrattache.PL_CODENUMCOMPTE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLECOMPTETIERSRATTACHE  @TI_IDTIERS, @PL_CODENUMCOMPTE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PLANCOMPTABLECOMPTETIERSRATTACHE  @TI_IDTIERS,'', @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlancomptablecomptetiersrattache </returns>
		///<author>Home Technology</author>
		public List<clsPlancomptablecomptetiersrattache> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TI_IDTIERS, PL_CODENUMCOMPTE, COCHER FROM dbo.FT_PLANCOMPTABLECOMPTETIERSRATTACHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPlancomptablecomptetiersrattache> clsPlancomptablecomptetiersrattaches = new List<clsPlancomptablecomptetiersrattache>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPlancomptablecomptetiersrattache clsPlancomptablecomptetiersrattache = new clsPlancomptablecomptetiersrattache();
					clsPlancomptablecomptetiersrattache.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
					clsPlancomptablecomptetiersrattache.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPlancomptablecomptetiersrattache.COCHER = clsDonnee.vogDataReader["COCHER"].ToString();
					clsPlancomptablecomptetiersrattaches.Add(clsPlancomptablecomptetiersrattache);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPlancomptablecomptetiersrattaches;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPlancomptablecomptetiersrattache </returns>
		///<author>Home Technology</author>
		public List<clsPlancomptablecomptetiersrattache> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPlancomptablecomptetiersrattache> clsPlancomptablecomptetiersrattaches = new List<clsPlancomptablecomptetiersrattache>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TI_IDTIERS, PL_CODENUMCOMPTE, COCHER FROM dbo.FT_PLANCOMPTABLECOMPTETIERSRATTACHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPlancomptablecomptetiersrattache clsPlancomptablecomptetiersrattache = new clsPlancomptablecomptetiersrattache();
					clsPlancomptablecomptetiersrattache.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();
					clsPlancomptablecomptetiersrattache.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsPlancomptablecomptetiersrattache.COCHER = Dataset.Tables["TABLE"].Rows[Idx]["COCHER"].ToString();
					clsPlancomptablecomptetiersrattaches.Add(clsPlancomptablecomptetiersrattache);
				}
				Dataset.Dispose();
			}
		return clsPlancomptablecomptetiersrattaches;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@TI_IDTIERS", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            this.vapRequete = "EXEC [PS_PLANCOMPTABLECOMPTETIERSRATTACHE] @TI_IDTIERS,@PL_NUMCOMPTE,@PL_TYPECOMPTE,@NC_CODENATURECOMPTE,@CODECRYPTAGE " ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TI_IDTIERS, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TI_IDTIERS , COCHER FROM dbo.FT_PLANCOMPTABLECOMPTETIERSRATTACHE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TI_IDTIERS, PL_CODENUMCOMPTE)</summary>
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
				this.vapCritere ="WHERE TI_IDTIERS=@TI_IDTIERS";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TI_IDTIERS"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TI_IDTIERS=@TI_IDTIERS AND PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TI_IDTIERS","@PL_CODENUMCOMPTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
