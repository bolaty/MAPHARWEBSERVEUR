using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhaparmoteurWSDAL: ITableDAL<clsPhaparmoteur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MO_CODEMOTEUR) AS MO_CODEMOTEUR  FROM dbo.PHAPARMOTEUR" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MO_CODEMOTEUR) AS MO_CODEMOTEUR  FROM dbo.PHAPARMOTEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MO_CODEMOTEUR) AS MO_CODEMOTEUR  FROM dbo.PHAPARMOTEUR " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaparmoteur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaparmoteur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AR_CODEARTICLE  , MO_CYLINDREE  , MO_PUISSANCEENDIN  , MO_PUISSANCEENKW  , MO_PUISSANCEFISCALE  , MO_NOMBREDEDECIBELS  , MO_REGIMEMOTEUR  , MO_NUMERODEBOITE  , MO_DEPOLUANTFAP  , BO_CODETYPEBOITE  , MO_NOMBREDESOUPAPES  , MO_NOMBREDEVITESSES  , IN_CODEMODEINJECTION  , MO_TURBOCOMPRESSEUR  , MO_NUMEROMOTEUR  , MO_NOMBREDECYLINDRE  , MO_CONSOMMATIONEXTRAURBAINE  , MO_CONSOMMATIONMIXTE , MO_CONSOMMATIONURBAINE, MO_CO2  FROM dbo.FT_PHAPARMOTEUR(@AG_CODEAGENCE ,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhaparmoteur clsPhaparmoteur = new clsPhaparmoteur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparmoteur.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparmoteur.MO_CYLINDREE = int.Parse(clsDonnee.vogDataReader["MO_CYLINDREE"].ToString());
					clsPhaparmoteur.MO_PUISSANCEENDIN = int.Parse(clsDonnee.vogDataReader["MO_PUISSANCEENDIN"].ToString());
					clsPhaparmoteur.MO_PUISSANCEENKW = int.Parse(clsDonnee.vogDataReader["MO_PUISSANCEENKW"].ToString());
					clsPhaparmoteur.MO_PUISSANCEFISCALE = int.Parse(clsDonnee.vogDataReader["MO_PUISSANCEFISCALE"].ToString());
					clsPhaparmoteur.MO_NOMBREDEDECIBELS = int.Parse(clsDonnee.vogDataReader["MO_NOMBREDEDECIBELS"].ToString());
					clsPhaparmoteur.MO_REGIMEMOTEUR = int.Parse(clsDonnee.vogDataReader["MO_REGIMEMOTEUR"].ToString());
					clsPhaparmoteur.MO_NUMERODEBOITE = clsDonnee.vogDataReader["MO_NUMERODEBOITE"].ToString();
					clsPhaparmoteur.MO_DEPOLUANTFAP = clsDonnee.vogDataReader["MO_DEPOLUANTFAP"].ToString();
					clsPhaparmoteur.BO_CODETYPEBOITE = clsDonnee.vogDataReader["BO_CODETYPEBOITE"].ToString();
					clsPhaparmoteur.MO_NOMBREDESOUPAPES = int.Parse(clsDonnee.vogDataReader["MO_NOMBREDESOUPAPES"].ToString());
					clsPhaparmoteur.MO_NOMBREDEVITESSES = int.Parse(clsDonnee.vogDataReader["MO_NOMBREDEVITESSES"].ToString());
					clsPhaparmoteur.IN_CODEMODEINJECTION = clsDonnee.vogDataReader["IN_CODEMODEINJECTION"].ToString();
					clsPhaparmoteur.MO_TURBOCOMPRESSEUR = clsDonnee.vogDataReader["MO_TURBOCOMPRESSEUR"].ToString();
					clsPhaparmoteur.MO_NUMEROMOTEUR = clsDonnee.vogDataReader["MO_NUMEROMOTEUR"].ToString();
					clsPhaparmoteur.MO_NOMBREDECYLINDRE = int.Parse(clsDonnee.vogDataReader["MO_NOMBREDECYLINDRE"].ToString());
					clsPhaparmoteur.MO_CONSOMMATIONEXTRAURBAINE = int.Parse(clsDonnee.vogDataReader["MO_CONSOMMATIONEXTRAURBAINE"].ToString());
					clsPhaparmoteur.MO_CONSOMMATIONMIXTE = int.Parse(clsDonnee.vogDataReader["MO_CONSOMMATIONMIXTE"].ToString());
                    clsPhaparmoteur.MO_CONSOMMATIONURBAINE = int.Parse(clsDonnee.vogDataReader["MO_CONSOMMATIONURBAINE"].ToString());
					clsPhaparmoteur.MO_CO2 = int.Parse(clsDonnee.vogDataReader["MO_CO2"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhaparmoteur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparmoteur>clsPhaparmoteur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhaparmoteur clsPhaparmoteur)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparmoteur.AG_CODEAGENCE;

			SqlParameter vppParamMO_CODEMOTEUR = new SqlParameter("@MO_CODEMOTEUR", SqlDbType.VarChar, 25);
			vppParamMO_CODEMOTEUR.Value  = clsPhaparmoteur.MO_CODEMOTEUR ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparmoteur.AR_CODEARTICLE ;
			SqlParameter vppParamMO_CYLINDREE = new SqlParameter("@MO_CYLINDREE", SqlDbType.Int);
			vppParamMO_CYLINDREE.Value  = clsPhaparmoteur.MO_CYLINDREE ;
			SqlParameter vppParamMO_PUISSANCEENDIN = new SqlParameter("@MO_PUISSANCEENDIN", SqlDbType.Int);
			vppParamMO_PUISSANCEENDIN.Value  = clsPhaparmoteur.MO_PUISSANCEENDIN ;
			SqlParameter vppParamMO_PUISSANCEENKW = new SqlParameter("@MO_PUISSANCEENKW", SqlDbType.Int);
			vppParamMO_PUISSANCEENKW.Value  = clsPhaparmoteur.MO_PUISSANCEENKW ;
			SqlParameter vppParamMO_PUISSANCEFISCALE = new SqlParameter("@MO_PUISSANCEFISCALE", SqlDbType.Int);
			vppParamMO_PUISSANCEFISCALE.Value  = clsPhaparmoteur.MO_PUISSANCEFISCALE ;
			SqlParameter vppParamMO_NOMBREDEDECIBELS = new SqlParameter("@MO_NOMBREDEDECIBELS", SqlDbType.Int);
			vppParamMO_NOMBREDEDECIBELS.Value  = clsPhaparmoteur.MO_NOMBREDEDECIBELS ;
			SqlParameter vppParamMO_REGIMEMOTEUR = new SqlParameter("@MO_REGIMEMOTEUR", SqlDbType.Int);
			vppParamMO_REGIMEMOTEUR.Value  = clsPhaparmoteur.MO_REGIMEMOTEUR ;
			SqlParameter vppParamMO_NUMERODEBOITE = new SqlParameter("@MO_NUMERODEBOITE", SqlDbType.VarChar, 1000);
			vppParamMO_NUMERODEBOITE.Value  = clsPhaparmoteur.MO_NUMERODEBOITE ;
			SqlParameter vppParamMO_DEPOLUANTFAP = new SqlParameter("@MO_DEPOLUANTFAP", SqlDbType.VarChar, 150);
			vppParamMO_DEPOLUANTFAP.Value  = clsPhaparmoteur.MO_DEPOLUANTFAP ;
			SqlParameter vppParamBO_CODETYPEBOITE = new SqlParameter("@BO_CODETYPEBOITE", SqlDbType.VarChar, 4);
			vppParamBO_CODETYPEBOITE.Value  = clsPhaparmoteur.BO_CODETYPEBOITE ;
			SqlParameter vppParamMO_NOMBREDESOUPAPES = new SqlParameter("@MO_NOMBREDESOUPAPES", SqlDbType.Int);
			vppParamMO_NOMBREDESOUPAPES.Value  = clsPhaparmoteur.MO_NOMBREDESOUPAPES ;
			SqlParameter vppParamMO_NOMBREDEVITESSES = new SqlParameter("@MO_NOMBREDEVITESSES", SqlDbType.Int);
			vppParamMO_NOMBREDEVITESSES.Value  = clsPhaparmoteur.MO_NOMBREDEVITESSES ;
			SqlParameter vppParamIN_CODEMODEINJECTION = new SqlParameter("@IN_CODEMODEINJECTION", SqlDbType.VarChar, 3);
			vppParamIN_CODEMODEINJECTION.Value  = clsPhaparmoteur.IN_CODEMODEINJECTION ;
			SqlParameter vppParamMO_TURBOCOMPRESSEUR = new SqlParameter("@MO_TURBOCOMPRESSEUR", SqlDbType.VarChar, 150);
			vppParamMO_TURBOCOMPRESSEUR.Value  = clsPhaparmoteur.MO_TURBOCOMPRESSEUR ;
			SqlParameter vppParamMO_NUMEROMOTEUR = new SqlParameter("@MO_NUMEROMOTEUR", SqlDbType.VarChar, 1000);
			vppParamMO_NUMEROMOTEUR.Value  = clsPhaparmoteur.MO_NUMEROMOTEUR ;
			SqlParameter vppParamMO_NOMBREDECYLINDRE = new SqlParameter("@MO_NOMBREDECYLINDRE", SqlDbType.Int);
			vppParamMO_NOMBREDECYLINDRE.Value  = clsPhaparmoteur.MO_NOMBREDECYLINDRE ;
			SqlParameter vppParamMO_CONSOMMATIONEXTRAURBAINE = new SqlParameter("@MO_CONSOMMATIONEXTRAURBAINE", SqlDbType.Int);
			vppParamMO_CONSOMMATIONEXTRAURBAINE.Value  = clsPhaparmoteur.MO_CONSOMMATIONEXTRAURBAINE ;

			SqlParameter vppParamMO_CONSOMMATIONMIXTE = new SqlParameter("@MO_CONSOMMATIONMIXTE", SqlDbType.Int);
			vppParamMO_CONSOMMATIONMIXTE.Value  = clsPhaparmoteur.MO_CONSOMMATIONMIXTE ;

            SqlParameter vppParamMO_CONSOMMATIONURBAINE = new SqlParameter("@MO_CONSOMMATIONURBAINE", SqlDbType.Int);
            vppParamMO_CONSOMMATIONURBAINE.Value = clsPhaparmoteur.MO_CONSOMMATIONURBAINE;

			SqlParameter vppParamMO_CO2 = new SqlParameter("@MO_CO2", SqlDbType.Int);
			vppParamMO_CO2.Value  = clsPhaparmoteur.MO_CO2 ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar,25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparmoteur.OP_CODEOPERATEUR;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARMOTEUR @AG_CODEAGENCE1, @MO_CODEMOTEUR, @AR_CODEARTICLE, @MO_CYLINDREE, @MO_PUISSANCEENDIN, @MO_PUISSANCEENKW, @MO_PUISSANCEFISCALE, @MO_NOMBREDEDECIBELS, @MO_REGIMEMOTEUR, @MO_NUMERODEBOITE, @MO_DEPOLUANTFAP, @BO_CODETYPEBOITE, @MO_NOMBREDESOUPAPES, @MO_NOMBREDEVITESSES, @IN_CODEMODEINJECTION, @MO_TURBOCOMPRESSEUR, @MO_NUMEROMOTEUR, @MO_NOMBREDECYLINDRE, @MO_CONSOMMATIONEXTRAURBAINE, @MO_CONSOMMATIONMIXTE, @MO_CONSOMMATIONURBAINE, @MO_CO2, @OP_CODEOPERATEUR, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMO_CODEMOTEUR);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamMO_CYLINDREE);
			vppSqlCmd.Parameters.Add(vppParamMO_PUISSANCEENDIN);
			vppSqlCmd.Parameters.Add(vppParamMO_PUISSANCEENKW);
			vppSqlCmd.Parameters.Add(vppParamMO_PUISSANCEFISCALE);
			vppSqlCmd.Parameters.Add(vppParamMO_NOMBREDEDECIBELS);
			vppSqlCmd.Parameters.Add(vppParamMO_REGIMEMOTEUR);
			vppSqlCmd.Parameters.Add(vppParamMO_NUMERODEBOITE);
			vppSqlCmd.Parameters.Add(vppParamMO_DEPOLUANTFAP);
			vppSqlCmd.Parameters.Add(vppParamBO_CODETYPEBOITE);
			vppSqlCmd.Parameters.Add(vppParamMO_NOMBREDESOUPAPES);
			vppSqlCmd.Parameters.Add(vppParamMO_NOMBREDEVITESSES);
			vppSqlCmd.Parameters.Add(vppParamIN_CODEMODEINJECTION);
			vppSqlCmd.Parameters.Add(vppParamMO_TURBOCOMPRESSEUR);
			vppSqlCmd.Parameters.Add(vppParamMO_NUMEROMOTEUR);
			vppSqlCmd.Parameters.Add(vppParamMO_NOMBREDECYLINDRE);
			vppSqlCmd.Parameters.Add(vppParamMO_CONSOMMATIONEXTRAURBAINE);
			vppSqlCmd.Parameters.Add(vppParamMO_CONSOMMATIONMIXTE);
            vppSqlCmd.Parameters.Add(vppParamMO_CONSOMMATIONURBAINE);
			vppSqlCmd.Parameters.Add(vppParamMO_CO2);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhaparmoteur>clsPhaparmoteur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhaparmoteur clsPhaparmoteur,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhaparmoteur.AG_CODEAGENCE;

			SqlParameter vppParamMO_CODEMOTEUR = new SqlParameter("@MO_CODEMOTEUR", SqlDbType.VarChar, 25);
			vppParamMO_CODEMOTEUR.Value  = clsPhaparmoteur.MO_CODEMOTEUR ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhaparmoteur.AR_CODEARTICLE ;
			SqlParameter vppParamMO_CYLINDREE = new SqlParameter("@MO_CYLINDREE", SqlDbType.Int);
			vppParamMO_CYLINDREE.Value  = clsPhaparmoteur.MO_CYLINDREE ;
			SqlParameter vppParamMO_PUISSANCEENDIN = new SqlParameter("@MO_PUISSANCEENDIN", SqlDbType.Int);
			vppParamMO_PUISSANCEENDIN.Value  = clsPhaparmoteur.MO_PUISSANCEENDIN ;
			SqlParameter vppParamMO_PUISSANCEENKW = new SqlParameter("@MO_PUISSANCEENKW", SqlDbType.Int);
			vppParamMO_PUISSANCEENKW.Value  = clsPhaparmoteur.MO_PUISSANCEENKW ;
			SqlParameter vppParamMO_PUISSANCEFISCALE = new SqlParameter("@MO_PUISSANCEFISCALE", SqlDbType.Int);
			vppParamMO_PUISSANCEFISCALE.Value  = clsPhaparmoteur.MO_PUISSANCEFISCALE ;
			SqlParameter vppParamMO_NOMBREDEDECIBELS = new SqlParameter("@MO_NOMBREDEDECIBELS", SqlDbType.Int);
			vppParamMO_NOMBREDEDECIBELS.Value  = clsPhaparmoteur.MO_NOMBREDEDECIBELS ;
			SqlParameter vppParamMO_REGIMEMOTEUR = new SqlParameter("@MO_REGIMEMOTEUR", SqlDbType.Int);
			vppParamMO_REGIMEMOTEUR.Value  = clsPhaparmoteur.MO_REGIMEMOTEUR ;
			SqlParameter vppParamMO_NUMERODEBOITE = new SqlParameter("@MO_NUMERODEBOITE", SqlDbType.VarChar, 1000);
			vppParamMO_NUMERODEBOITE.Value  = clsPhaparmoteur.MO_NUMERODEBOITE ;
			SqlParameter vppParamMO_DEPOLUANTFAP = new SqlParameter("@MO_DEPOLUANTFAP", SqlDbType.VarChar, 150);
			vppParamMO_DEPOLUANTFAP.Value  = clsPhaparmoteur.MO_DEPOLUANTFAP ;
			SqlParameter vppParamBO_CODETYPEBOITE = new SqlParameter("@BO_CODETYPEBOITE", SqlDbType.VarChar, 4);
			vppParamBO_CODETYPEBOITE.Value  = clsPhaparmoteur.BO_CODETYPEBOITE ;
			SqlParameter vppParamMO_NOMBREDESOUPAPES = new SqlParameter("@MO_NOMBREDESOUPAPES", SqlDbType.Int);
			vppParamMO_NOMBREDESOUPAPES.Value  = clsPhaparmoteur.MO_NOMBREDESOUPAPES ;
			SqlParameter vppParamMO_NOMBREDEVITESSES = new SqlParameter("@MO_NOMBREDEVITESSES", SqlDbType.Int);
			vppParamMO_NOMBREDEVITESSES.Value  = clsPhaparmoteur.MO_NOMBREDEVITESSES ;
			SqlParameter vppParamIN_CODEMODEINJECTION = new SqlParameter("@IN_CODEMODEINJECTION", SqlDbType.VarChar, 3);
			vppParamIN_CODEMODEINJECTION.Value  = clsPhaparmoteur.IN_CODEMODEINJECTION ;
			SqlParameter vppParamMO_TURBOCOMPRESSEUR = new SqlParameter("@MO_TURBOCOMPRESSEUR", SqlDbType.VarChar, 150);
			vppParamMO_TURBOCOMPRESSEUR.Value  = clsPhaparmoteur.MO_TURBOCOMPRESSEUR ;
			SqlParameter vppParamMO_NUMEROMOTEUR = new SqlParameter("@MO_NUMEROMOTEUR", SqlDbType.VarChar, 1000);
			vppParamMO_NUMEROMOTEUR.Value  = clsPhaparmoteur.MO_NUMEROMOTEUR ;
			SqlParameter vppParamMO_NOMBREDECYLINDRE = new SqlParameter("@MO_NOMBREDECYLINDRE", SqlDbType.Int);
			vppParamMO_NOMBREDECYLINDRE.Value  = clsPhaparmoteur.MO_NOMBREDECYLINDRE ;
			SqlParameter vppParamMO_CONSOMMATIONEXTRAURBAINE = new SqlParameter("@MO_CONSOMMATIONEXTRAURBAINE", SqlDbType.Int);
			vppParamMO_CONSOMMATIONEXTRAURBAINE.Value  = clsPhaparmoteur.MO_CONSOMMATIONEXTRAURBAINE ;
			SqlParameter vppParamMO_CONSOMMATIONMIXTE = new SqlParameter("@MO_CONSOMMATIONMIXTE", SqlDbType.Int);
			vppParamMO_CONSOMMATIONMIXTE.Value  = clsPhaparmoteur.MO_CONSOMMATIONMIXTE ;

            SqlParameter vppParamMO_CONSOMMATIONURBAINE = new SqlParameter("@MO_CONSOMMATIONURBAINE", SqlDbType.Int);
            vppParamMO_CONSOMMATIONURBAINE.Value = clsPhaparmoteur.MO_CONSOMMATIONURBAINE;

			SqlParameter vppParamMO_CO2 = new SqlParameter("@MO_CO2", SqlDbType.Int);
			vppParamMO_CO2.Value  = clsPhaparmoteur.MO_CO2 ;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar,25);
            vppParamOP_CODEOPERATEUR.Value = clsPhaparmoteur.OP_CODEOPERATEUR;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARMOTEUR  @AG_CODEAGENCE,@MO_CODEMOTEUR, @AR_CODEARTICLE, @MO_CYLINDREE, @MO_PUISSANCEENDIN, @MO_PUISSANCEENKW, @MO_PUISSANCEFISCALE, @MO_NOMBREDEDECIBELS, @MO_REGIMEMOTEUR, @MO_NUMERODEBOITE, @MO_DEPOLUANTFAP, @BO_CODETYPEBOITE, @MO_NOMBREDESOUPAPES, @MO_NOMBREDEVITESSES, @IN_CODEMODEINJECTION, @MO_TURBOCOMPRESSEUR, @MO_NUMEROMOTEUR, @MO_NOMBREDECYLINDRE, @MO_CONSOMMATIONEXTRAURBAINE, @MO_CONSOMMATIONMIXTE, @MO_CONSOMMATIONURBAINE, @MO_CO2, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMO_CODEMOTEUR);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamMO_CYLINDREE);
			vppSqlCmd.Parameters.Add(vppParamMO_PUISSANCEENDIN);
			vppSqlCmd.Parameters.Add(vppParamMO_PUISSANCEENKW);
			vppSqlCmd.Parameters.Add(vppParamMO_PUISSANCEFISCALE);
			vppSqlCmd.Parameters.Add(vppParamMO_NOMBREDEDECIBELS);
			vppSqlCmd.Parameters.Add(vppParamMO_REGIMEMOTEUR);
			vppSqlCmd.Parameters.Add(vppParamMO_NUMERODEBOITE);
			vppSqlCmd.Parameters.Add(vppParamMO_DEPOLUANTFAP);
			vppSqlCmd.Parameters.Add(vppParamBO_CODETYPEBOITE);
			vppSqlCmd.Parameters.Add(vppParamMO_NOMBREDESOUPAPES);
			vppSqlCmd.Parameters.Add(vppParamMO_NOMBREDEVITESSES);
			vppSqlCmd.Parameters.Add(vppParamIN_CODEMODEINJECTION);
			vppSqlCmd.Parameters.Add(vppParamMO_TURBOCOMPRESSEUR);
			vppSqlCmd.Parameters.Add(vppParamMO_NUMEROMOTEUR);
			vppSqlCmd.Parameters.Add(vppParamMO_NOMBREDECYLINDRE);
			vppSqlCmd.Parameters.Add(vppParamMO_CONSOMMATIONEXTRAURBAINE);
			vppSqlCmd.Parameters.Add(vppParamMO_CONSOMMATIONMIXTE); 
            vppSqlCmd.Parameters.Add(vppParamMO_CONSOMMATIONURBAINE);
			vppSqlCmd.Parameters.Add(vppParamMO_CO2);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAPARMOTEUR @AG_CODEAGENCE, @MO_CODEMOTEUR, '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '', '' , '' , '' , '' , '' , '' , '','',  @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparmoteur </returns>
		///<author>Home Technology</author>
		public List<clsPhaparmoteur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MO_CODEMOTEUR, AR_CODEARTICLE, MO_CYLINDREE, MO_PUISSANCEENDIN, MO_PUISSANCEENKW, MO_PUISSANCEFISCALE, MO_NOMBREDEDECIBELS, MO_REGIMEMOTEUR, MO_NUMERODEBOITE, MO_DEPOLUANTFAP, BO_CODETYPEBOITE, MO_NOMBREDESOUPAPES, MO_NOMBREDEVITESSES, IN_CODEMODEINJECTION, MO_TURBOCOMPRESSEUR, MO_NUMEROMOTEUR, MO_NOMBREDECYLINDRE, MO_CONSOMMATIONEXTRAURBAINE, MO_CONSOMMATIONMIXTE, MO_CONSOMMATIONURBAINE, MO_CO2 FROM dbo.FT_PHAPARMOTEUR(@AG_CODEAGENCE ,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhaparmoteur> clsPhaparmoteurs = new List<clsPhaparmoteur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhaparmoteur clsPhaparmoteur = new clsPhaparmoteur();
					clsPhaparmoteur.MO_CODEMOTEUR = clsDonnee.vogDataReader["MO_CODEMOTEUR"].ToString();
					clsPhaparmoteur.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhaparmoteur.MO_CYLINDREE = int.Parse(clsDonnee.vogDataReader["MO_CYLINDREE"].ToString());
					clsPhaparmoteur.MO_PUISSANCEENDIN = int.Parse(clsDonnee.vogDataReader["MO_PUISSANCEENDIN"].ToString());
					clsPhaparmoteur.MO_PUISSANCEENKW = int.Parse(clsDonnee.vogDataReader["MO_PUISSANCEENKW"].ToString());
					clsPhaparmoteur.MO_PUISSANCEFISCALE = int.Parse(clsDonnee.vogDataReader["MO_PUISSANCEFISCALE"].ToString());
					clsPhaparmoteur.MO_NOMBREDEDECIBELS = int.Parse(clsDonnee.vogDataReader["MO_NOMBREDEDECIBELS"].ToString());
					clsPhaparmoteur.MO_REGIMEMOTEUR = int.Parse(clsDonnee.vogDataReader["MO_REGIMEMOTEUR"].ToString());
					clsPhaparmoteur.MO_NUMERODEBOITE = clsDonnee.vogDataReader["MO_NUMERODEBOITE"].ToString();
					clsPhaparmoteur.MO_DEPOLUANTFAP = clsDonnee.vogDataReader["MO_DEPOLUANTFAP"].ToString();
					clsPhaparmoteur.BO_CODETYPEBOITE = clsDonnee.vogDataReader["BO_CODETYPEBOITE"].ToString();
					clsPhaparmoteur.MO_NOMBREDESOUPAPES = int.Parse(clsDonnee.vogDataReader["MO_NOMBREDESOUPAPES"].ToString());
					clsPhaparmoteur.MO_NOMBREDEVITESSES = int.Parse(clsDonnee.vogDataReader["MO_NOMBREDEVITESSES"].ToString());
					clsPhaparmoteur.IN_CODEMODEINJECTION = clsDonnee.vogDataReader["IN_CODEMODEINJECTION"].ToString();
					clsPhaparmoteur.MO_TURBOCOMPRESSEUR = clsDonnee.vogDataReader["MO_TURBOCOMPRESSEUR"].ToString();
					clsPhaparmoteur.MO_NUMEROMOTEUR = clsDonnee.vogDataReader["MO_NUMEROMOTEUR"].ToString();
					clsPhaparmoteur.MO_NOMBREDECYLINDRE = int.Parse(clsDonnee.vogDataReader["MO_NOMBREDECYLINDRE"].ToString());
					clsPhaparmoteur.MO_CONSOMMATIONEXTRAURBAINE = int.Parse(clsDonnee.vogDataReader["MO_CONSOMMATIONEXTRAURBAINE"].ToString());
					clsPhaparmoteur.MO_CONSOMMATIONMIXTE = int.Parse(clsDonnee.vogDataReader["MO_CONSOMMATIONMIXTE"].ToString());
                    clsPhaparmoteur.MO_CONSOMMATIONURBAINE = int.Parse(clsDonnee.vogDataReader["MO_CONSOMMATIONURBAINE"].ToString());
					clsPhaparmoteur.MO_CO2 = int.Parse(clsDonnee.vogDataReader["MO_CO2"].ToString());
					clsPhaparmoteurs.Add(clsPhaparmoteur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhaparmoteurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaparmoteur </returns>
		///<author>Home Technology</author>
		public List<clsPhaparmoteur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhaparmoteur> clsPhaparmoteurs = new List<clsPhaparmoteur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MO_CODEMOTEUR, AR_CODEARTICLE, MO_CYLINDREE, MO_PUISSANCEENDIN, MO_PUISSANCEENKW, MO_PUISSANCEFISCALE, MO_NOMBREDEDECIBELS, MO_REGIMEMOTEUR, MO_NUMERODEBOITE, MO_DEPOLUANTFAP, BO_CODETYPEBOITE, MO_NOMBREDESOUPAPES, MO_NOMBREDEVITESSES, IN_CODEMODEINJECTION, MO_TURBOCOMPRESSEUR, MO_NUMEROMOTEUR, MO_NOMBREDECYLINDRE, MO_CONSOMMATIONEXTRAURBAINE, MO_CONSOMMATIONMIXTE, MO_CONSOMMATIONURBAINE, MO_CO2 FROM dbo.FT_PHAPARMOTEUR(@AG_CODEAGENCE ,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhaparmoteur clsPhaparmoteur = new clsPhaparmoteur();
					clsPhaparmoteur.MO_CODEMOTEUR = Dataset.Tables["TABLE"].Rows[Idx]["MO_CODEMOTEUR"].ToString();
					clsPhaparmoteur.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhaparmoteur.MO_CYLINDREE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_CYLINDREE"].ToString());
					clsPhaparmoteur.MO_PUISSANCEENDIN = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_PUISSANCEENDIN"].ToString());
					clsPhaparmoteur.MO_PUISSANCEENKW = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_PUISSANCEENKW"].ToString());
					clsPhaparmoteur.MO_PUISSANCEFISCALE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_PUISSANCEFISCALE"].ToString());
					clsPhaparmoteur.MO_NOMBREDEDECIBELS = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_NOMBREDEDECIBELS"].ToString());
					clsPhaparmoteur.MO_REGIMEMOTEUR = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_REGIMEMOTEUR"].ToString());
					clsPhaparmoteur.MO_NUMERODEBOITE = Dataset.Tables["TABLE"].Rows[Idx]["MO_NUMERODEBOITE"].ToString();
					clsPhaparmoteur.MO_DEPOLUANTFAP = Dataset.Tables["TABLE"].Rows[Idx]["MO_DEPOLUANTFAP"].ToString();
					clsPhaparmoteur.BO_CODETYPEBOITE = Dataset.Tables["TABLE"].Rows[Idx]["BO_CODETYPEBOITE"].ToString();
					clsPhaparmoteur.MO_NOMBREDESOUPAPES = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_NOMBREDESOUPAPES"].ToString());
					clsPhaparmoteur.MO_NOMBREDEVITESSES = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_NOMBREDEVITESSES"].ToString());
					clsPhaparmoteur.IN_CODEMODEINJECTION = Dataset.Tables["TABLE"].Rows[Idx]["IN_CODEMODEINJECTION"].ToString();
					clsPhaparmoteur.MO_TURBOCOMPRESSEUR = Dataset.Tables["TABLE"].Rows[Idx]["MO_TURBOCOMPRESSEUR"].ToString();
					clsPhaparmoteur.MO_NUMEROMOTEUR = Dataset.Tables["TABLE"].Rows[Idx]["MO_NUMEROMOTEUR"].ToString();
					clsPhaparmoteur.MO_NOMBREDECYLINDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_NOMBREDECYLINDRE"].ToString());
					clsPhaparmoteur.MO_CONSOMMATIONEXTRAURBAINE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_CONSOMMATIONEXTRAURBAINE"].ToString());
					clsPhaparmoteur.MO_CONSOMMATIONMIXTE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_CONSOMMATIONMIXTE"].ToString());
                    clsPhaparmoteur.MO_CONSOMMATIONURBAINE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_CONSOMMATIONURBAINE"].ToString());
					clsPhaparmoteur.MO_CO2 = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_CO2"].ToString());
					clsPhaparmoteurs.Add(clsPhaparmoteur);
				}
				Dataset.Dispose();
			}
		return clsPhaparmoteurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAPARMOTEUR(@AG_CODEAGENCE ,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MO_CODEMOTEUR, IN_CODEMODEINJECTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MO_CODEMOTEUR , AR_CODEARTICLE FROM dbo.FT_PHAPARMOTEUR(@AG_CODEAGENCE ,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MO_CODEMOTEUR, IN_CODEMODEINJECTION)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MO_CODEMOTEUR=@MO_CODEMOTEUR";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MO_CODEMOTEUR" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MO_CODEMOTEUR=@MO_CODEMOTEUR AND IN_CODEMODEINJECTION=@IN_CODEMODEINJECTION";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MO_CODEMOTEUR", "@IN_CODEMODEINJECTION" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MO_CODEMOTEUR, IN_CODEMODEINJECTION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  AR_CODEARTICLE=@AR_CODEARTICLE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AR_CODEARTICLE" };
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
		        break;
		        case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MO_CODEMOTEUR=@MO_CODEMOTEUR AND IN_CODEMODEINJECTION=@IN_CODEMODEINJECTION";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MO_CODEMOTEUR", "@IN_CODEMODEINJECTION" };
		        vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
		        break;
	        }
        }



	}
}
