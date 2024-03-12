using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

 namespace Stock.WSDAL
{

	public class clsOperateurWSDAL: ITableDAL<clsOperateur>
	{

		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
        private object[] vapValeurParametre = new object[] { };
        clsPlancomptableWSDAL clsPlancomptableWSDAL = new WSDAL.clsPlancomptableWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEUR   " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

 		///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEUR   " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

 		///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEUR  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

 		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsOperateur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsOperateur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , PO_CODEPROFIL  , PL_CODENUMCOMPTE  , OP_NOMPRENOM  , OP_LOGIN  , OP_MOTPASSE  , OP_ACTIF  , OP_TELEPHONE  , OP_EMAIL  , OP_JOURNEEOUVERTE  ,  OP_GESTIONNAIRE  ,OP_CAISSIER,OP_IMPRESSIONAUTOMATIQUE,OP_DATESAISIE  FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsOperateur clsOperateur = new clsOperateur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre)) 
 			{
				while(clsDonnee.vogDataReader.Read()) 
 				{
					clsOperateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString(); 
					clsOperateur.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString(); 
					clsOperateur.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString(); 
					clsOperateur.OP_NOMPRENOM = clsDonnee.vogDataReader["OP_NOMPRENOM"].ToString(); 
					clsOperateur.OP_LOGIN = clsDonnee.vogDataReader["OP_LOGIN"].ToString(); 
					clsOperateur.OP_MOTPASSE = clsDonnee.vogDataReader["OP_MOTPASSE"].ToString(); 
					clsOperateur.OP_ACTIF = clsDonnee.vogDataReader["OP_ACTIF"].ToString(); 
					clsOperateur.OP_TELEPHONE = clsDonnee.vogDataReader["OP_TELEPHONE"].ToString(); 
					clsOperateur.OP_EMAIL = clsDonnee.vogDataReader["OP_EMAIL"].ToString(); 
					clsOperateur.OP_JOURNEEOUVERTE = clsDonnee.vogDataReader["OP_JOURNEEOUVERTE"].ToString();
                    clsOperateur.OP_GESTIONNAIRE = clsDonnee.vogDataReader["OP_GESTIONNAIRE"].ToString();
                    clsOperateur.OP_CAISSIER = clsDonnee.vogDataReader["OP_CAISSIER"].ToString();
                    clsOperateur.OP_IMPRESSIONAUTOMATIQUE = clsDonnee.vogDataReader["OP_IMPRESSIONAUTOMATIQUE"].ToString(); 
					clsOperateur.OP_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["OP_DATESAISIE"].ToString()); 
				}
 				clsDonnee.vogDataReader.Dispose(); 
			}
 		return clsOperateur;
 		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsOperateur comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsOperateur pvgTableLabel1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE    AND   OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT AG_CODEAGENCE  , PO_CODEPROFIL  , PL_CODENUMCOMPTE  , OP_NOMPRENOM  , OP_LOGIN  , OP_MOTPASSE  , OP_ACTIF  , OP_TELEPHONE  , OP_EMAIL  , OP_JOURNEEOUVERTE  ,  OP_GESTIONNAIRE  ,OP_CAISSIER,OP_IMPRESSIONAUTOMATIQUE,OP_DATESAISIE ,PL_NUMCOMPTE  FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsOperateur clsOperateur = new clsOperateur();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsOperateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsOperateur.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString();
                    clsOperateur.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsOperateur.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
                    clsOperateur.OP_NOMPRENOM = clsDonnee.vogDataReader["OP_NOMPRENOM"].ToString();
                    clsOperateur.OP_LOGIN = clsDonnee.vogDataReader["OP_LOGIN"].ToString();
                    clsOperateur.OP_MOTPASSE = clsDonnee.vogDataReader["OP_MOTPASSE"].ToString();
                    clsOperateur.OP_ACTIF = clsDonnee.vogDataReader["OP_ACTIF"].ToString();
                    clsOperateur.OP_TELEPHONE = clsDonnee.vogDataReader["OP_TELEPHONE"].ToString();
                    clsOperateur.OP_EMAIL = clsDonnee.vogDataReader["OP_EMAIL"].ToString();
                    clsOperateur.OP_JOURNEEOUVERTE = clsDonnee.vogDataReader["OP_JOURNEEOUVERTE"].ToString();
                    clsOperateur.OP_GESTIONNAIRE = clsDonnee.vogDataReader["OP_GESTIONNAIRE"].ToString();
                    clsOperateur.OP_CAISSIER = clsDonnee.vogDataReader["OP_CAISSIER"].ToString();
                    clsOperateur.OP_IMPRESSIONAUTOMATIQUE = clsDonnee.vogDataReader["OP_IMPRESSIONAUTOMATIQUE"].ToString();
                    clsOperateur.OP_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["OP_DATESAISIE"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsOperateur;
        }



 		public void pvgInsert(clsDonnee clsDonnee, clsOperateur clsOperateur) 
 		{
            //Préparation des paramètres
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;
            SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 2);
            vppParamPO_CODEPROFIL.Value = clsOperateur.PO_CODEPROFIL;
            SqlParameter vppParamTO_CODETYPEOERATEUR = new SqlParameter("@TO_CODETYPEOERATEUR", SqlDbType.VarChar, 2);
            vppParamTO_CODETYPEOERATEUR.Value = clsOperateur.TO_CODETYPEOERATEUR;
            if (clsOperateur.TO_CODETYPEOERATEUR == "") vppParamTO_CODETYPEOERATEUR.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTE.Value = clsOperateur.PL_CODENUMCOMPTE;
            if (clsOperateur.PL_CODENUMCOMPTE == "") vppParamPL_CODENUMCOMPTE.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTECOFFREFORT = new SqlParameter("@PL_CODENUMCOMPTECOFFREFORT", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTECOFFREFORT = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTECOFFREFORT).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTECOFFREFORT.Value = clsOperateur.PL_CODENUMCOMPTECOFFREFORT;
            if (clsOperateur.PL_CODENUMCOMPTECOFFREFORT == "") vppParamPL_CODENUMCOMPTECOFFREFORT.Value = DBNull.Value;

            SqlParameter vppParamOP_NOMPRENOM = new SqlParameter("@OP_NOMPRENOM", SqlDbType.VarChar, 1000);
            vppParamOP_NOMPRENOM.Value = clsOperateur.OP_NOMPRENOM;
            SqlParameter vppParamOP_LOGIN = new SqlParameter("@OP_LOGIN", SqlDbType.VarChar, 1000);
            vppParamOP_LOGIN.Value = clsOperateur.OP_LOGIN;
            SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
            vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;
            SqlParameter vppParamOP_ACTIF = new SqlParameter("@OP_ACTIF", SqlDbType.VarChar, 1);
            vppParamOP_ACTIF.Value = clsOperateur.OP_ACTIF;
            SqlParameter vppParamOP_TELEPHONE = new SqlParameter("@OP_TELEPHONE", SqlDbType.VarChar, 1000);
            vppParamOP_TELEPHONE.Value = clsOperateur.OP_TELEPHONE;
            if (clsOperateur.OP_TELEPHONE == "") vppParamOP_TELEPHONE.Value = DBNull.Value;
            SqlParameter vppParamOP_EMAIL = new SqlParameter("@OP_EMAIL", SqlDbType.VarChar, 1000);
            vppParamOP_EMAIL.Value = clsOperateur.OP_EMAIL;
            if (clsOperateur.OP_EMAIL == "") vppParamOP_EMAIL.Value = DBNull.Value;
            SqlParameter vppParamOP_JOURNEEOUVERTE = new SqlParameter("@OP_JOURNEEOUVERTE", SqlDbType.VarChar, 1);
            vppParamOP_JOURNEEOUVERTE.Value = clsOperateur.OP_JOURNEEOUVERTE;
            SqlParameter vppParamOP_GESTIONNAIRE = new SqlParameter("@OP_GESTIONNAIRE", SqlDbType.VarChar, 1);
            vppParamOP_GESTIONNAIRE.Value = clsOperateur.OP_GESTIONNAIRE;
            SqlParameter vppParamOP_CAISSIER = new SqlParameter("@OP_CAISSIER", SqlDbType.VarChar, 1);
            vppParamOP_CAISSIER.Value = clsOperateur.OP_CAISSIER;
            SqlParameter vppParamOP_DATESAISIE = new SqlParameter("@OP_DATESAISIE", SqlDbType.DateTime);
            vppParamOP_DATESAISIE.Value = clsOperateur.OP_DATESAISIE;
            SqlParameter vppParamOP_IMPRESSIONAUTOMATIQUE = new SqlParameter("@OP_IMPRESSIONAUTOMATIQUE", SqlDbType.VarChar, 1);
            vppParamOP_IMPRESSIONAUTOMATIQUE.Value = clsOperateur.OP_IMPRESSIONAUTOMATIQUE;
            SqlParameter vppParamOP_MONTANTTOTALENCAISSEAUTORISE = new SqlParameter("@OP_MONTANTTOTALENCAISSEAUTORISE", SqlDbType.Money);
            vppParamOP_MONTANTTOTALENCAISSEAUTORISE.Value = clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE;
            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsOperateur.EN_CODEENTREPOT;
            if (clsOperateur.EN_CODEENTREPOT == "") vppParamEN_CODEENTREPOT.Value = DBNull.Value;
            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.BigInt);
            vppParamTI_IDTIERS.Value = clsOperateur.TI_IDTIERS;
            if (clsOperateur.TI_IDTIERS == "" || clsOperateur.TI_IDTIERS == "0") vppParamTI_IDTIERS.Value = DBNull.Value;


            SqlParameter vppParamOP_EXTOURNE = new SqlParameter("@OP_EXTOURNE", SqlDbType.VarChar, 1);
            vppParamOP_EXTOURNE.Value = clsOperateur.OP_EXTOURNE;
            SqlParameter vppParamOP_CREATIONJOURNE = new SqlParameter("@OP_CREATIONJOURNE", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONJOURNE.Value = clsOperateur.OP_CREATIONJOURNE;
            SqlParameter vppParamOP_FERMETUREJOURNE = new SqlParameter("@OP_FERMETUREJOURNE", SqlDbType.VarChar, 1);
            vppParamOP_FERMETUREJOURNE.Value = clsOperateur.OP_FERMETUREJOURNE;

            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsOperateur.SR_CODESERVICE;

            SqlParameter vppParamOP_CREATIONPROFILE = new SqlParameter("@OP_CREATIONPROFILE", SqlDbType.VarChar,1);
            vppParamOP_CREATIONPROFILE.Value = clsOperateur.OP_CREATIONPROFILE;

            SqlParameter vppParamOP_CREATIONOPERATEUR = new SqlParameter("@OP_CREATIONOPERATEUR", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONOPERATEUR.Value = clsOperateur.OP_CREATIONOPERATEUR;

            SqlParameter vppParamOP_SELECTIONOPERATEURAPPRO = new SqlParameter("@OP_SELECTIONOPERATEURAPPRO", SqlDbType.VarChar, 1);
            vppParamOP_SELECTIONOPERATEURAPPRO.Value = clsOperateur.OP_SELECTIONOPERATEURAPPRO;

            SqlParameter vppParamOP_SELECTIONOPERATEURVENTE = new SqlParameter("@OP_SELECTIONOPERATEURVENTE", SqlDbType.VarChar, 1);
            vppParamOP_SELECTIONOPERATEURVENTE.Value = clsOperateur.OP_SELECTIONOPERATEURVENTE;

            SqlParameter vppParamOP_CONTREPARTIEAUTOMATIQUEOD = new SqlParameter("@OP_CONTREPARTIEAUTOMATIQUEOD", SqlDbType.VarChar, 1);
            vppParamOP_CONTREPARTIEAUTOMATIQUEOD.Value = clsOperateur.OP_CONTREPARTIEAUTOMATIQUEOD;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE1, @PO_CODEPROFIL,@TO_CODETYPEOERATEUR, @PL_CODENUMCOMPTE,@PL_CODENUMCOMPTECOFFREFORT, @OP_NOMPRENOM, @OP_LOGIN, @OP_MOTPASSE, @OP_ACTIF, @OP_TELEPHONE, @OP_EMAIL, @OP_JOURNEEOUVERTE, @OP_DATESAISIE, @OP_GESTIONNAIRE, @OP_CAISSIER,@OP_IMPRESSIONAUTOMATIQUE,@OP_MONTANTTOTALENCAISSEAUTORISE,@EN_CODEENTREPOT,@TI_IDTIERS,@OP_EXTOURNE,@OP_CREATIONJOURNE,@OP_FERMETUREJOURNE,@SR_CODESERVICE,@OP_CREATIONPROFILE,@OP_CREATIONOPERATEUR,@OP_SELECTIONOPERATEURAPPRO,@OP_SELECTIONOPERATEURVENTE,@OP_CONTREPARTIEAUTOMATIQUEOD,@CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
            vppSqlCmd.Parameters.Add(vppParamTO_CODETYPEOERATEUR);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTECOFFREFORT);
            vppSqlCmd.Parameters.Add(vppParamOP_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamOP_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamOP_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamOP_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamOP_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamOP_JOURNEEOUVERTE);
            vppSqlCmd.Parameters.Add(vppParamOP_GESTIONNAIRE);
            vppSqlCmd.Parameters.Add(vppParamOP_CAISSIER);
            vppSqlCmd.Parameters.Add(vppParamOP_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_IMPRESSIONAUTOMATIQUE);
            vppSqlCmd.Parameters.Add(vppParamOP_MONTANTTOTALENCAISSEAUTORISE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamOP_EXTOURNE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONJOURNE);
            vppSqlCmd.Parameters.Add(vppParamOP_FERMETUREJOURNE);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONPROFILE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamOP_SELECTIONOPERATEURAPPRO);
            vppSqlCmd.Parameters.Add(vppParamOP_SELECTIONOPERATEURVENTE);
            vppSqlCmd.Parameters.Add(vppParamOP_CONTREPARTIEAUTOMATIQUEOD);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		public void pvgUpdate(clsDonnee clsDonnee, clsOperateur clsOperateur,params string[] vppCritere) 
 		{
            //Préparation des paramètres
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR1", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE1", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;
            SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 2);
            vppParamPO_CODEPROFIL.Value = clsOperateur.PO_CODEPROFIL;
            SqlParameter vppParamTO_CODETYPEOERATEUR = new SqlParameter("@TO_CODETYPEOERATEUR", SqlDbType.VarChar, 2);
            vppParamTO_CODETYPEOERATEUR.Value = clsOperateur.TO_CODETYPEOERATEUR;
            if (clsOperateur.TO_CODETYPEOERATEUR == "") vppParamTO_CODETYPEOERATEUR.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTE.Value = clsOperateur.PL_CODENUMCOMPTE;
            if (clsOperateur.PL_CODENUMCOMPTE == "") vppParamPL_CODENUMCOMPTE.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTECOFFREFORT = new SqlParameter("@PL_CODENUMCOMPTECOFFREFORT", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTECOFFREFORT = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTECOFFREFORT).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTECOFFREFORT.Value = clsOperateur.PL_CODENUMCOMPTECOFFREFORT;
            if (clsOperateur.PL_CODENUMCOMPTECOFFREFORT == "") vppParamPL_CODENUMCOMPTECOFFREFORT.Value = DBNull.Value;  

            SqlParameter vppParamOP_NOMPRENOM = new SqlParameter("@OP_NOMPRENOM", SqlDbType.VarChar, 1000);
            vppParamOP_NOMPRENOM.Value = clsOperateur.OP_NOMPRENOM;
            SqlParameter vppParamOP_LOGIN = new SqlParameter("@OP_LOGIN", SqlDbType.VarChar, 1000);
            vppParamOP_LOGIN.Value = clsOperateur.OP_LOGIN;
            SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
            vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;
            SqlParameter vppParamOP_ACTIF = new SqlParameter("@OP_ACTIF", SqlDbType.VarChar, 1);
            vppParamOP_ACTIF.Value = clsOperateur.OP_ACTIF;
            SqlParameter vppParamOP_TELEPHONE = new SqlParameter("@OP_TELEPHONE", SqlDbType.VarChar, 1000);
            vppParamOP_TELEPHONE.Value = clsOperateur.OP_TELEPHONE;
            if (clsOperateur.OP_TELEPHONE == "") vppParamOP_TELEPHONE.Value = DBNull.Value;
            SqlParameter vppParamOP_EMAIL = new SqlParameter("@OP_EMAIL", SqlDbType.VarChar, 1000);
            vppParamOP_EMAIL.Value = clsOperateur.OP_EMAIL;
            if (clsOperateur.OP_EMAIL == "") vppParamOP_EMAIL.Value = DBNull.Value;
            SqlParameter vppParamOP_JOURNEEOUVERTE = new SqlParameter("@OP_JOURNEEOUVERTE", SqlDbType.VarChar, 1);
            vppParamOP_JOURNEEOUVERTE.Value = clsOperateur.OP_JOURNEEOUVERTE;
            SqlParameter vppParamOP_GESTIONNAIRE = new SqlParameter("@OP_GESTIONNAIRE", SqlDbType.VarChar, 1);
            vppParamOP_GESTIONNAIRE.Value = clsOperateur.OP_GESTIONNAIRE;
            SqlParameter vppParamOP_CAISSIER = new SqlParameter("@OP_CAISSIER", SqlDbType.VarChar, 1);
            vppParamOP_CAISSIER.Value = clsOperateur.OP_CAISSIER;
            SqlParameter vppParamOP_DATESAISIE = new SqlParameter("@OP_DATESAISIE", SqlDbType.DateTime);
            vppParamOP_DATESAISIE.Value = clsOperateur.OP_DATESAISIE;
            SqlParameter vppParamOP_IMPRESSIONAUTOMATIQUE = new SqlParameter("@OP_IMPRESSIONAUTOMATIQUE", SqlDbType.VarChar, 1);
            vppParamOP_IMPRESSIONAUTOMATIQUE.Value = clsOperateur.OP_IMPRESSIONAUTOMATIQUE;
            SqlParameter vppParamOP_MONTANTTOTALENCAISSEAUTORISE = new SqlParameter("@OP_MONTANTTOTALENCAISSEAUTORISE", SqlDbType.Money);
            vppParamOP_MONTANTTOTALENCAISSEAUTORISE.Value = clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE;
            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
            vppParamEN_CODEENTREPOT.Value = clsOperateur.EN_CODEENTREPOT;
            if (clsOperateur.EN_CODEENTREPOT == "") vppParamEN_CODEENTREPOT.Value = DBNull.Value;
            SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.BigInt);
            vppParamTI_IDTIERS.Value = clsOperateur.TI_IDTIERS;
            if (clsOperateur.TI_IDTIERS == "" || clsOperateur.TI_IDTIERS == "0") vppParamTI_IDTIERS.Value = DBNull.Value;
           

            SqlParameter vppParamOP_EXTOURNE = new SqlParameter("@OP_EXTOURNE", SqlDbType.VarChar, 1);
            vppParamOP_EXTOURNE.Value = clsOperateur.OP_EXTOURNE;
            SqlParameter vppParamOP_CREATIONJOURNE = new SqlParameter("@OP_CREATIONJOURNE", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONJOURNE.Value = clsOperateur.OP_CREATIONJOURNE;
            SqlParameter vppParamOP_FERMETUREJOURNE = new SqlParameter("@OP_FERMETUREJOURNE", SqlDbType.VarChar, 1);
            vppParamOP_FERMETUREJOURNE.Value = clsOperateur.OP_FERMETUREJOURNE;

            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsOperateur.SR_CODESERVICE;

            SqlParameter vppParamOP_CREATIONPROFILE = new SqlParameter("@OP_CREATIONPROFILE", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONPROFILE.Value = clsOperateur.OP_CREATIONPROFILE;

            SqlParameter vppParamOP_CREATIONOPERATEUR = new SqlParameter("@OP_CREATIONOPERATEUR ", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONOPERATEUR.Value = clsOperateur.OP_CREATIONOPERATEUR;


            SqlParameter vppParamOP_SELECTIONOPERATEURAPPRO = new SqlParameter("@OP_SELECTIONOPERATEURAPPRO", SqlDbType.VarChar, 1);
            vppParamOP_SELECTIONOPERATEURAPPRO.Value = clsOperateur.OP_SELECTIONOPERATEURAPPRO;

            SqlParameter vppParamOP_SELECTIONOPERATEURVENTE = new SqlParameter("@OP_SELECTIONOPERATEURVENTE", SqlDbType.VarChar, 1);
            vppParamOP_SELECTIONOPERATEURVENTE.Value = clsOperateur.OP_SELECTIONOPERATEURVENTE;

            SqlParameter vppParamOP_CONTREPARTIEAUTOMATIQUEOD = new SqlParameter("@OP_CONTREPARTIEAUTOMATIQUEOD", SqlDbType.VarChar, 1);
            vppParamOP_CONTREPARTIEAUTOMATIQUEOD.Value = clsOperateur.OP_CONTREPARTIEAUTOMATIQUEOD;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR1, @AG_CODEAGENCE1, @PO_CODEPROFIL,@TO_CODETYPEOERATEUR, @PL_CODENUMCOMPTE,@PL_CODENUMCOMPTECOFFREFORT, @OP_NOMPRENOM, @OP_LOGIN, @OP_MOTPASSE, @OP_ACTIF, @OP_TELEPHONE, @OP_EMAIL, @OP_JOURNEEOUVERTE, @OP_DATESAISIE, @OP_GESTIONNAIRE,@OP_CAISSIER,@OP_IMPRESSIONAUTOMATIQUE,@OP_MONTANTTOTALENCAISSEAUTORISE,@EN_CODEENTREPOT,@TI_IDTIERS,@OP_EXTOURNE,@OP_CREATIONJOURNE,@OP_FERMETUREJOURNE,@SR_CODESERVICE,@OP_CREATIONPROFILE,@OP_CREATIONOPERATEUR,@OP_SELECTIONOPERATEURAPPRO,@OP_SELECTIONOPERATEURVENTE,@OP_CONTREPARTIEAUTOMATIQUEOD,@CODECRYPTAGE, 1 ";
            
            //this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE, @PO_CODEPROFIL, @TO_CODETYPEOERATEUR, @PL_CODENUMCOMPTE, @OP_NOMPRENOM, @OP_LOGIN, @OP_MOTPASSE, @OP_ACTIF, @OP_TELEPHONE, @OP_EMAIL, @OP_JOURNEEOUVERTE, @OP_GESTIONNAIRE, @OP_CAISSIER, @OP_DATESAISIE, @OP_IMPRESSIONAUTOMATIQUE, @OP_MONTANTTOTALENCAISSEAUTORISE, @EN_CODEENTREPOT, @TI_IDTIERS, @OP_EXTOURNE, @OP_CREATIONJOURNE, @OP_FERMETUREJOURNE, @CODECRYPTAGE, 1 ";
            
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
            vppSqlCmd.Parameters.Add(vppParamTO_CODETYPEOERATEUR);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTECOFFREFORT);
            vppSqlCmd.Parameters.Add(vppParamOP_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamOP_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamOP_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamOP_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamOP_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamOP_JOURNEEOUVERTE);
            vppSqlCmd.Parameters.Add(vppParamOP_GESTIONNAIRE);
            vppSqlCmd.Parameters.Add(vppParamOP_CAISSIER);
            vppSqlCmd.Parameters.Add(vppParamOP_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_IMPRESSIONAUTOMATIQUE);
            vppSqlCmd.Parameters.Add(vppParamOP_MONTANTTOTALENCAISSEAUTORISE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamOP_EXTOURNE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONJOURNE);
            vppSqlCmd.Parameters.Add(vppParamOP_FERMETUREJOURNE);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONPROFILE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONOPERATEUR);

            vppSqlCmd.Parameters.Add(vppParamOP_SELECTIONOPERATEURAPPRO);
            vppSqlCmd.Parameters.Add(vppParamOP_SELECTIONOPERATEURVENTE);
            vppSqlCmd.Parameters.Add(vppParamOP_CONTREPARTIEAUTOMATIQUEOD);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
            public void pvgUpdate1(clsDonnee clsDonnee, clsOperateur clsOperateur,params string[] vppCritere) 
            {
	            //Préparation des paramètres 
	            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt); 
	            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR ;

	            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
                vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;

	            SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 2);
                vppParamPO_CODEPROFIL.Value = clsOperateur.PO_CODEPROFIL;

                SqlParameter vppParamTO_CODETYPEOERATEUR = new SqlParameter("@TO_CODETYPEOERATEUR", SqlDbType.VarChar, 2);
                vppParamTO_CODETYPEOERATEUR.Value = clsOperateur.TO_CODETYPEOERATEUR;

                SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
                clsOperateur.PL_CODENUMCOMPTE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTE).PL_CODENUMCOMPTE;
                vppParamPL_CODENUMCOMPTE.Value = clsOperateur.PL_CODENUMCOMPTE;
                if (clsOperateur.PL_CODENUMCOMPTE == "") vppParamPL_CODENUMCOMPTE.Value = DBNull.Value;

                SqlParameter vppParamPL_CODENUMCOMPTECOFFREFORT = new SqlParameter("@PL_CODENUMCOMPTECOFFREFORT", SqlDbType.VarChar, 25);
                clsOperateur.PL_CODENUMCOMPTECOFFREFORT = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTECOFFREFORT).PL_CODENUMCOMPTE;
                vppParamPL_CODENUMCOMPTE.Value = clsOperateur.PL_CODENUMCOMPTE;
                if (clsOperateur.PL_CODENUMCOMPTE == "") vppParamPL_CODENUMCOMPTE.Value = DBNull.Value;  

                SqlParameter vppParamOP_NOMPRENOM = new SqlParameter("@OP_NOMPRENOM", SqlDbType.VarChar, 1000);
                vppParamOP_NOMPRENOM.Value = clsOperateur.OP_NOMPRENOM;

                SqlParameter vppParamOP_LOGIN = new SqlParameter("@OP_LOGIN", SqlDbType.VarChar, 1000);
                vppParamOP_LOGIN.Value = clsOperateur.OP_LOGIN;

                SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
                vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;

	            SqlParameter vppParamOP_ACTIF = new SqlParameter("@OP_ACTIF", SqlDbType.VarChar, 1);
                vppParamOP_ACTIF.Value = clsOperateur.OP_ACTIF;

                SqlParameter vppParamOP_TELEPHONE = new SqlParameter("@OP_TELEPHONE", SqlDbType.VarChar, 1000);
                vppParamOP_TELEPHONE.Value = clsOperateur.OP_TELEPHONE;

                SqlParameter vppParamOP_EMAIL = new SqlParameter("@OP_EMAIL", SqlDbType.VarChar, 1000);
                vppParamOP_EMAIL.Value = clsOperateur.OP_EMAIL;

	            SqlParameter vppParamOP_JOURNEEOUVERTE = new SqlParameter("@OP_JOURNEEOUVERTE", SqlDbType.VarChar, 1);
                vppParamOP_JOURNEEOUVERTE.Value = clsOperateur.OP_JOURNEEOUVERTE;

                SqlParameter vppParamOP_DATESAISIE = new SqlParameter("@OP_DATESAISIE", SqlDbType.DateTime);
                vppParamOP_DATESAISIE.Value = clsOperateur.OP_DATESAISIE;

                SqlParameter vppParamOP_GESTIONNAIRE = new SqlParameter("@OP_GESTIONNAIRE", SqlDbType.VarChar, 1);
                vppParamOP_GESTIONNAIRE.Value = clsOperateur.OP_GESTIONNAIRE;

           

                SqlParameter vppParamOP_CAISSIER = new SqlParameter("@OP_CAISSIER", SqlDbType.VarChar, 1);
                vppParamOP_CAISSIER.Value = clsOperateur.OP_CAISSIER;

                SqlParameter vppParamOP_IMPRESSIONAUTOMATIQUE = new SqlParameter("@OP_IMPRESSIONAUTOMATIQUE", SqlDbType.VarChar, 1);
                vppParamOP_IMPRESSIONAUTOMATIQUE.Value = clsOperateur.OP_IMPRESSIONAUTOMATIQUE;

          

                SqlParameter vppParamOP_MONTANTTOTALENCAISSEAUTORISE = new SqlParameter("@OP_MONTANTTOTALENCAISSEAUTORISE", SqlDbType.Money);
                vppParamOP_MONTANTTOTALENCAISSEAUTORISE.Value = clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE;

                SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 4);
                vppParamEN_CODEENTREPOT.Value = clsOperateur.EN_CODEENTREPOT;

                SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 50);
                vppParamTI_IDTIERS.Value = clsOperateur.TI_IDTIERS;
                if (clsOperateur.TI_IDTIERS == "") vppParamTI_IDTIERS.Value = DBNull.Value;
                if (clsOperateur.TI_IDTIERS == "0") vppParamTI_IDTIERS.Value = DBNull.Value;

                //SqlParameter vppParamOP_EXTOURNE = new SqlParameter("@OP_EXTOURNE", SqlDbType.VarChar, 1);
                //vppParamOP_EXTOURNE.Value = clsOperateur.OP_EXTOURNE;

           

                //SqlParameter vppParamOP_CREATIONJOURNE = new SqlParameter("@OP_CREATIONJOURNE", SqlDbType.VarChar, 1);
                //if (clsOperateur.OP_CREATIONJOURNE == "") vppParamOP_CREATIONJOURNE.Value = DBNull.Value;

                SqlParameter vppParamOP_FERMETUREJOURNE = new SqlParameter("@OP_FERMETUREJOURNE", SqlDbType.VarChar, 1);
                if (clsOperateur.OP_FERMETUREJOURNE == "") vppParamOP_FERMETUREJOURNE.Value = DBNull.Value;
                SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@OP_FERMETUREJOURNE", SqlDbType.VarChar, 1);
                if (clsOperateur.SR_CODESERVICE == "") vppParamSR_CODESERVICE.Value = DBNull.Value;


                SqlParameter vppParamOP_CREATIONPROFILE = new SqlParameter("@OP_CREATIONPROFILE", SqlDbType.VarChar, 1);
                if (clsOperateur.OP_CREATIONPROFILE == "") vppParamOP_CREATIONPROFILE.Value = DBNull.Value;

                SqlParameter vppParamOP_CREATIONOPERATEUR = new SqlParameter("@OP_CREATIONOPERATEUR ", SqlDbType.VarChar, 1);
                if (clsOperateur.OP_CREATIONOPERATEUR == "") vppParamOP_CREATIONOPERATEUR.Value = DBNull.Value;


                SqlParameter vppParamOP_SELECTIONOPERATEURAPPRO = new SqlParameter("@OP_SELECTIONOPERATEURAPPRO", SqlDbType.VarChar, 1);
                vppParamOP_SELECTIONOPERATEURAPPRO.Value = clsOperateur.OP_SELECTIONOPERATEURAPPRO;

                SqlParameter vppParamOP_SELECTIONOPERATEURVENTE = new SqlParameter("@OP_SELECTIONOPERATEURVENTE", SqlDbType.VarChar, 1);
                vppParamOP_SELECTIONOPERATEURVENTE.Value = clsOperateur.OP_SELECTIONOPERATEURVENTE;

                SqlParameter vppParamOP_CONTREPARTIEAUTOMATIQUEOD = new SqlParameter("@OP_CONTREPARTIEAUTOMATIQUEOD", SqlDbType.VarChar, 1);
                 vppParamOP_CONTREPARTIEAUTOMATIQUEOD.Value = clsOperateur.OP_CONTREPARTIEAUTOMATIQUEOD;



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50); 
	            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage; 

	            //Préparation de la commande 
                this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE, @PO_CODEPROFIL,@TO_CODETYPEOERATEUR, @PL_CODENUMCOMPTE,@PL_CODENUMCOMPTECOFFREFORT, @OP_NOMPRENOM, @OP_LOGIN, @OP_MOTPASSE, @OP_ACTIF, @OP_TELEPHONE, @OP_EMAIL, @OP_JOURNEEOUVERTE, @OP_DATESAISIE, @OP_GESTIONNAIRE,@OP_CAISSIER,@OP_IMPRESSIONAUTOMATIQUE,@OP_MONTANTTOTALENCAISSEAUTORISE,@EN_CODEENTREPOT,@TI_IDTIERS,'N','N',@OP_FERMETUREJOURNE,@SR_CODESERVICE,@OP_CREATIONPROFILE,@OP_CREATIONOPERATEUR,@OP_SELECTIONOPERATEURAPPRO,@OP_SELECTIONOPERATEURVENTE,@OP_CONTREPARTIEAUTOMATIQUEOD,@CODECRYPTAGE, 1 ";
                    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

	            //Ajout des paramètre à la commande 
	            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR); 
	            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE); 
	            vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
                vppSqlCmd.Parameters.Add(vppParamTO_CODETYPEOERATEUR);
	            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
                vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTECOFFREFORT); 
	            vppSqlCmd.Parameters.Add(vppParamOP_NOMPRENOM); 
	            vppSqlCmd.Parameters.Add(vppParamOP_LOGIN); 
	            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE); 
	            vppSqlCmd.Parameters.Add(vppParamOP_ACTIF); 
	            vppSqlCmd.Parameters.Add(vppParamOP_TELEPHONE); 
	            vppSqlCmd.Parameters.Add(vppParamOP_EMAIL); 
	            vppSqlCmd.Parameters.Add(vppParamOP_JOURNEEOUVERTE); 
	            vppSqlCmd.Parameters.Add(vppParamOP_DATESAISIE);
                vppSqlCmd.Parameters.Add(vppParamOP_GESTIONNAIRE);
                vppSqlCmd.Parameters.Add(vppParamOP_CAISSIER);
                vppSqlCmd.Parameters.Add(vppParamOP_IMPRESSIONAUTOMATIQUE);
                vppSqlCmd.Parameters.Add(vppParamOP_MONTANTTOTALENCAISSEAUTORISE);
                vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
                vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
                //vppSqlCmd.Parameters.Add(vppParamOP_EXTOURNE);
                //vppSqlCmd.Parameters.Add(vppParamOP_CREATIONJOURNE);
                vppSqlCmd.Parameters.Add(vppParamOP_FERMETUREJOURNE);
                vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
                vppSqlCmd.Parameters.Add(vppParamOP_CREATIONPROFILE);
                vppSqlCmd.Parameters.Add(vppParamOP_CREATIONOPERATEUR);

                vppSqlCmd.Parameters.Add(vppParamOP_SELECTIONOPERATEURAPPRO);
                vppSqlCmd.Parameters.Add(vppParamOP_SELECTIONOPERATEURVENTE);
                vppSqlCmd.Parameters.Add(vppParamOP_CONTREPARTIEAUTOMATIQUEOD);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE); 
	            //Ouverture de la connection et exécution de la commande 
                clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null); 
            }
        public void pvgUpdateDesactiverOperateur(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;

            SqlParameter vppParamOP_ACTIF = new SqlParameter("@OP_ACTIF", SqlDbType.VarChar, 1);
            vppParamOP_ACTIF.Value = clsOperateur.OP_ACTIF;

            SqlParameter vppParamOP_LOGIN = new SqlParameter("@OP_LOGIN", SqlDbType.VarChar,1000);
            vppParamOP_LOGIN.Value = clsOperateur.OP_LOGIN; 

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  '', @AG_CODEAGENCE , '' , '' , ''  ,''  , @OP_LOGIN , '' , @OP_ACTIF , '' , '' ,  '' ,'' ,'' ,'' ,'','','','','','','', '','','','','','','',@CODECRYPTAGE, 3 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamOP_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamOP_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null); 
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:OP_CODEOPERATEUR,SE_CODESERVICE)</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<param name="vppCritere1">critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateOP_MOTPASSE(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;

            SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
            vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE , '' , '' , '' ,'' , ''  , '' , @OP_MOTPASSE ,  '' , '' , '' ,'' , '' ,'' ,'','','','','','','','','','', '','', '','', @CODECRYPTAGE, 5 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null); 
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:OP_CODEOPERATEUR,SE_CODESERVICE)</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<param name="vppCritere1">critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateOP_JOURNEEOUVERTE(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;

            SqlParameter vppParamOP_JOURNEEOUVERTE = new SqlParameter("@OP_JOURNEEOUVERTE", SqlDbType.VarChar, 1);
            vppParamOP_JOURNEEOUVERTE.Value = clsOperateur.OP_JOURNEEOUVERTE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE, '' , '' , '' ,'' , '' , '' , '' ,'' , ''  , @OP_JOURNEEOUVERTE , '' , '' ,'' ,'','','','','','','','','','','','','','', @CODECRYPTAGE, 6 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamOP_JOURNEEOUVERTE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere) 
 		{
			//Préparation des paramètres 
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,25);
            vppParamAG_CODEAGENCE.Value = vppCritere[1];

			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt); 
			vppParamOP_CODEOPERATEUR.Value = vppCritere[0] ;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE , '' ,   '' , '' ,'' , '' , '' , '' , '' ,'' , '' , '','' , '','' ,'','','','','','','','','','','','','',@CODECRYPTAGE,2 ";
             SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande 
             vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null); 
		}

        public void pvgDelete1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
            vppParamAG_CODEAGENCE.Value = vppCritere[0];

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  '', @AG_CODEAGENCE , '' , '' , '' ,'' , '' , '' ,  '' , '' , '' , '' , '', '' , '','' ,'','','','','','','','','','','','','','',4 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateur </returns>
		///<author>Home Technology</author>
		public List<clsOperateur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  ,OP_GESTIONNAIRE, PO_CODEPROFIL  , PL_CODENUMCOMPTE  , OP_NOMPRENOM  , OP_LOGIN  , OP_MOTPASSE  , OP_ACTIF  , OP_TELEPHONE  , OP_EMAIL  , OP_JOURNEEOUVERTE  ,OP_CAISSIER, OP_DATESAISIE  FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsOperateur> clsOperateurs = new List<clsOperateur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre)) 
 			{
				while(clsDonnee.vogDataReader.Read()) 
 				{
					clsOperateur clsOperateur = new clsOperateur();
					clsOperateur.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString(); 
					clsOperateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString(); 
					clsOperateur.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString(); 
					clsOperateur.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString(); 
					clsOperateur.OP_NOMPRENOM = clsDonnee.vogDataReader["OP_NOMPRENOM"].ToString(); 
					clsOperateur.OP_LOGIN = clsDonnee.vogDataReader["OP_LOGIN"].ToString(); 
					clsOperateur.OP_MOTPASSE = clsDonnee.vogDataReader["OP_MOTPASSE"].ToString(); 
					clsOperateur.OP_ACTIF = clsDonnee.vogDataReader["OP_ACTIF"].ToString(); 
					clsOperateur.OP_TELEPHONE = clsDonnee.vogDataReader["OP_TELEPHONE"].ToString(); 
					clsOperateur.OP_EMAIL = clsDonnee.vogDataReader["OP_EMAIL"].ToString(); 
					clsOperateur.OP_JOURNEEOUVERTE = clsDonnee.vogDataReader["OP_JOURNEEOUVERTE"].ToString();
                    clsOperateur.OP_GESTIONNAIRE = clsDonnee.vogDataReader["OP_GESTIONNAIRE"].ToString();
                    clsOperateur.OP_CAISSIER = clsDonnee.vogDataReader["OP_CAISSIER"].ToString();
					clsOperateur.OP_DATESAISIE = DateTime.Parse( clsDonnee.vogDataReader["OP_DATESAISIE"].ToString()); 
					clsOperateurs.Add(clsOperateur); 
				}
 				clsDonnee.vogDataReader.Dispose(); 
			}
 			return clsOperateurs;
 		}

 		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOperateur </returns>
		///<author>Home Technology</author>
		public List<clsOperateur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			List<clsOperateur> clsOperateurs = new List<clsOperateur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , PO_CODEPROFIL  , PL_CODENUMCOMPTE  , OP_NOMPRENOM  , OP_LOGIN  , OP_MOTPASSE  , OP_ACTIF  , OP_TELEPHONE  , OP_EMAIL  , OP_JOURNEEOUVERTE  ,OP_CAISSIER, OP_DATESAISIE  FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0) 
 			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++) 
 				{
					clsOperateur clsOperateur = new clsOperateur();
					clsOperateur.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString(); 
					clsOperateur.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString(); 
					clsOperateur.PO_CODEPROFIL = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFIL"].ToString(); 
					clsOperateur.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString(); 
					clsOperateur.OP_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["OP_NOMPRENOM"].ToString(); 
					clsOperateur.OP_LOGIN = Dataset.Tables["TABLE"].Rows[Idx]["OP_LOGIN"].ToString(); 
					clsOperateur.OP_MOTPASSE = Dataset.Tables["TABLE"].Rows[Idx]["OP_MOTPASSE"].ToString(); 
					clsOperateur.OP_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["OP_ACTIF"].ToString(); 
					clsOperateur.OP_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["OP_TELEPHONE"].ToString(); 
					clsOperateur.OP_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["OP_EMAIL"].ToString(); 
					clsOperateur.OP_JOURNEEOUVERTE = Dataset.Tables["TABLE"].Rows[Idx]["OP_JOURNEEOUVERTE"].ToString();
                    clsOperateur.OP_GESTIONNAIRE = Dataset.Tables["TABLE"].Rows[Idx]["OP_GESTIONNAIRE"].ToString();
                    clsOperateur.OP_CAISSIER = Dataset.Tables["TABLE"].Rows[Idx]["OP_CAISSIER"].ToString(); 
					clsOperateur.OP_DATESAISIE = DateTime.Parse( Dataset.Tables["TABLE"].Rows[Idx]["OP_DATESAISIE"].ToString()); 
					clsOperateurs.Add(clsOperateur); 
				}
 				Dataset.Dispose(); 
			}
 		return clsOperateurs; 
 		}

 		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%')";

			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee, vppCritere);
            this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND (EN_CODEENTREPOT=@EN_CODEENTREPOT  OR OP_LOGIN='BILAN001000')";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };

            this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere + "   AND NOT (OP_LOGIN like '%ADMIN%')";

            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

 		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetLOGIN(clsDonnee clsDonnee, params string[] vppCritere) 
		{
            //pvpChoixCritere1(clsDonnee ,vppCritere);

            //this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND OP_LOGIN=@OP_LOGIN  AND OP_MOTPASSE=@OP_MOTPASSE   ";
            vapNomParametre = new string[] { "@CODECRYPTAGE","@OP_LOGIN", "@OP_MOTPASSE", "@TYPEOPERATEUR" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };

            //this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE)   ";// + this.vapCritere;
            this.vapRequete = "EXEC PS_WEBUSERLOGIN @OP_LOGIN, @OP_MOTPASSE, @TYPEOPERATEUR,@CODECRYPTAGE ";// + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgLOGIN(clsDonnee clsDonnee, params string[] vppCritere) 
        {
	        pvpChoixCritere1(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere;
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


 		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere) 
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%')";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

 		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOP_GESTIONNAIRE(clsDonnee clsDonnee, params string[] vppCritere) 
		{
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  OP_GESTIONNAIRE=@OP_GESTIONNAIRE ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_GESTIONNAIRE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O' };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR AS OP_GESTIONNAIRE,OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%')";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOP_CAISSIER(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CAISSIER=@OP_CAISSIER AND OP_JOURNEEOUVERTE=@OP_JOURNEEOUVERTE ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CAISSIER", "@OP_JOURNEEOUVERTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O', vppCritere[1],};
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM,PL_CODENUMCOMPTE FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%')";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOP_CAISSIERPassationFond(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CAISSIER=@OP_CAISSIER AND OP_JOURNEEOUVERTE=@OP_JOURNEEOUVERTE  AND OP_CODEOPERATEUR<>@OP_CODEOPERATEUR";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CAISSIER", "@OP_JOURNEEOUVERTE" , "@OP_CODEOPERATEUR"};
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O', vppCritere[1], vppCritere[2] };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM,PL_CODENUMCOMPTE,OP_LOGIN FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere +
             "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%')";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurEntrepot(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT *  FROM dbo.[FC_OPERATEURENTREPOT](@AG_CODEAGENCE,@OP_CODEOPERATEUR,@CODECRYPTAGE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
		///<param name=clsDonnee>Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOP_GESTIONNAIRE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  OP_GESTIONNAIRE=@OP_GESTIONNAIRE ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_GESTIONNAIRE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O' };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR AS OP_GESTIONNAIRE,OP_NOMPRENOM,OP_EMAIL,OP_TELEPHONE FROM dbo.FT_OPERATEUR(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%')";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }





        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,AG_CODEAGENCE,PO_CODEPROFIL,PL_CODENUMCOMPTE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

                case 2:
                    this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND  EN_CODEENTREPOT=@EN_CODEENTREPOT  AND   OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = " WHERE   AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND  OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND PO_CODEPROFIL=@PO_CODEPROFIL ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUR", "@PO_CODEPROFIL" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = " WHERE   AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR ANDPO_CODEPROFIL=@PO_CODEPROFIL AND  PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@OP_CODEOPERATEUR", "@PO_CODEPROFIL", "@PL_CODENUMCOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,AG_CODEAGENCE,PO_CODEPROFIL,PL_CODENUMCOMPTE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere1(clsDonnee clsDonnee,params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			{
				case 0:
					this.vapCritere ="" ;
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
					break ;				
				case 1:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
					break ;				
				case 2:
					this.vapCritere =" WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND OP_LOGIN=@OP_LOGIN";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_LOGIN" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
					break ;

                case 3:
                    this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND OP_LOGIN=@OP_LOGIN  AND OP_MOTPASSE=@OP_MOTPASSE   ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_LOGIN", "@OP_MOTPASSE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] , vppCritere[2] };
                    break;
            }
		}
        }
}