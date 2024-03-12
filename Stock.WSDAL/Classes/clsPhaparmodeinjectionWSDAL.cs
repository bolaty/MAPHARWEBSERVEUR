using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparmodeinjectionWSDAL: ITableDAL<clsPhaparmodeinjection>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(IN_CODEMODEINJECTION) AS IN_CODEMODEINJECTION  FROM dbo.FT_PHAPARMODEINJECTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(IN_CODEMODEINJECTION) AS IN_CODEMODEINJECTION  FROM dbo.FT_PHAPARMODEINJECTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(IN_CODEMODEINJECTION) AS IN_CODEMODEINJECTION  FROM dbo.FT_PHAPARMODEINJECTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparmodeinjection comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparmodeinjection pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT IN_LIBELLE  FROM dbo.FT_PHAPARMODEINJECTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparmodeinjection clsPhaparmodeinjection = new clsPhaparmodeinjection();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparmodeinjection.IN_LIBELLE = clsDonnee.vogDataReader["IN_LIBELLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparmodeinjection;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparmodeinjection>clsPhaparmodeinjection</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparmodeinjection clsPhaparmodeinjection)
		{
			//Préparation des paramètres
			SqlParameter vppParamIN_CODEMODEINJECTION = new SqlParameter("@IN_CODEMODEINJECTION1", SqlDbType.VarChar, 3);
			vppParamIN_CODEMODEINJECTION.Value  = clsPhaparmodeinjection.IN_CODEMODEINJECTION ;
			SqlParameter vppParamIN_LIBELLE = new SqlParameter("@IN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamIN_LIBELLE.Value  = clsPhaparmodeinjection.IN_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARMODEINJECTION  @IN_CODEMODEINJECTION1, @IN_LIBELLE, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamIN_CODEMODEINJECTION);
			vppSqlCmd.Parameters.Add(vppParamIN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparmodeinjection>clsPhaparmodeinjection</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparmodeinjection clsPhaparmodeinjection,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamIN_CODEMODEINJECTION = new SqlParameter("@IN_CODEMODEINJECTION", SqlDbType.VarChar, 3);
			vppParamIN_CODEMODEINJECTION.Value  = clsPhaparmodeinjection.IN_CODEMODEINJECTION ;
			SqlParameter vppParamIN_LIBELLE = new SqlParameter("@IN_LIBELLE", SqlDbType.VarChar, 150);
			vppParamIN_LIBELLE.Value  = clsPhaparmodeinjection.IN_LIBELLE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARMODEINJECTION  @IN_CODEMODEINJECTION, @IN_LIBELLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamIN_CODEMODEINJECTION);
			vppSqlCmd.Parameters.Add(vppParamIN_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAPARMODEINJECTION  @IN_CODEMODEINJECTION, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparmodeinjection </returns>
		///<author>Home Technology</author>
		public List<clsPhaparmodeinjection> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  IN_CODEMODEINJECTION, IN_LIBELLE FROM dbo.FT_PHAPARMODEINJECTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparmodeinjection> clsPhaparmodeinjections = new List<clsPhaparmodeinjection>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparmodeinjection clsPhaparmodeinjection = new clsPhaparmodeinjection();
					clsPhaparmodeinjection.IN_CODEMODEINJECTION = clsDonnee.vogDataReader["IN_CODEMODEINJECTION"].ToString();
					clsPhaparmodeinjection.IN_LIBELLE = clsDonnee.vogDataReader["IN_LIBELLE"].ToString();
					clsPhaparmodeinjections.Add(clsPhaparmodeinjection);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparmodeinjections;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparmodeinjection </returns>
		///<author>Home Technology</author>
		public List<clsPhaparmodeinjection> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparmodeinjection> clsPhaparmodeinjections = new List<clsPhaparmodeinjection>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  IN_CODEMODEINJECTION, IN_LIBELLE FROM dbo.FT_PHAPARMODEINJECTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparmodeinjection clsPhaparmodeinjection = new clsPhaparmodeinjection();
					clsPhaparmodeinjection.IN_CODEMODEINJECTION = Dataset.Tables["TABLE"].Rows[Idx]["IN_CODEMODEINJECTION"].ToString();
					clsPhaparmodeinjection.IN_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["IN_LIBELLE"].ToString();
					clsPhaparmodeinjections.Add(clsPhaparmodeinjection);
				}
				Dataset.Dispose();
			}
		return clsPhaparmodeinjections;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARMODEINJECTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT IN_CODEMODEINJECTION , IN_LIBELLE FROM dbo.FT_PHAPARMODEINJECTION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :IN_CODEMODEINJECTION)</summary>
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
				this.vapCritere ="WHERE IN_CODEMODEINJECTION=@IN_CODEMODEINJECTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@IN_CODEMODEINJECTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {

                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    //this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND PL_TYPECOMPTE='I' ";
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%'";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%'  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

            }
        }




	}
}
