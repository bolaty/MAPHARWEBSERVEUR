using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstocklivraisonWSDAL: ITableDAL<clsPhamouvementstocklivraison>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(LV_NUMSEQUENCE) AS LV_NUMSEQUENCE  FROM dbo.PHAMOUVEMENTSTOCKLIVRAISON " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(LV_NUMSEQUENCE) AS LV_NUMSEQUENCE  FROM dbo.PHAMOUVEMENTSTOCKLIVRAISON " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(LV_NUMSEQUENCE) AS LV_NUMSEQUENCE  FROM dbo.PHAMOUVEMENTSTOCKLIVRAISON " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMaxNumPiece(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(LV_NUMEROPIECE) AS LV_NUMEROPIECE  FROM dbo.PHAMOUVEMENTSTOCKLIVRAISON " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstocklivraison comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstocklivraison pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , CH_IDCHAUFFEUR  , AR_CODEARTICLE  , MS_NUMPIECE  , NO_CODENATUREOPERATION  , LV_QUANTITELIVRER  , LV_DATELIVRAISON  , LV_ANNULATIONPIECE  , LV_NUMEROPIECE  , LV_MONTANTVERSE  , LV_REMETTANT  , LV_AGENTLIVREUR  FROM dbo.FT_PHAMOUVEMENTSTOCKLIVRAISON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstocklivraison clsPhamouvementstocklivraison = new clsPhamouvementstocklivraison();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstocklivraison.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstocklivraison.CH_IDCHAUFFEUR = clsDonnee.vogDataReader["CH_IDCHAUFFEUR"].ToString();
					clsPhamouvementstocklivraison.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhamouvementstocklivraison.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementstocklivraison.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstocklivraison.LV_QUANTITELIVRER = float.Parse(clsDonnee.vogDataReader["LV_QUANTITELIVRER"].ToString());
					clsPhamouvementstocklivraison.LV_DATELIVRAISON = DateTime.Parse(clsDonnee.vogDataReader["LV_DATELIVRAISON"].ToString());
					clsPhamouvementstocklivraison.LV_ANNULATIONPIECE = clsDonnee.vogDataReader["LV_ANNULATIONPIECE"].ToString();
					clsPhamouvementstocklivraison.LV_NUMEROPIECE = double.Parse(clsDonnee.vogDataReader["LV_NUMEROPIECE"].ToString());
					clsPhamouvementstocklivraison.LV_MONTANTVERSE = double.Parse(clsDonnee.vogDataReader["LV_MONTANTVERSE"].ToString());
					clsPhamouvementstocklivraison.LV_REMETTANT = clsDonnee.vogDataReader["LV_REMETTANT"].ToString();
					clsPhamouvementstocklivraison.LV_AGENTLIVREUR = clsDonnee.vogDataReader["LV_AGENTLIVREUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstocklivraison;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstocklivraison>clsPhamouvementstocklivraison</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstocklivraison clsPhamouvementstocklivraison)
		{
			//Préparation des paramètres
			SqlParameter vppParamLV_NUMSEQUENCE = new SqlParameter("@LV_NUMSEQUENCE", SqlDbType.VarChar, 50);
			vppParamLV_NUMSEQUENCE.Value  = clsPhamouvementstocklivraison.LV_NUMSEQUENCE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstocklivraison.AG_CODEAGENCE ;
			SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.VarChar, 25);
			vppParamCH_IDCHAUFFEUR.Value  = clsPhamouvementstocklivraison.CH_IDCHAUFFEUR ;

            SqlParameter vppParamTR_IDTRANSPORTEUR = new SqlParameter("@TR_IDTRANSPORTEUR", SqlDbType.VarChar, 25);
            vppParamTR_IDTRANSPORTEUR.Value = clsPhamouvementstocklivraison.TR_IDTRANSPORTEUR;
            if (clsPhamouvementstocklivraison.TR_IDTRANSPORTEUR == "") vppParamTR_IDTRANSPORTEUR.Value = DBNull.Value;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementstocklivraison.EN_CODEENTREPOT;
            if (clsPhamouvementstocklivraison.EN_CODEENTREPOT == "") vppParamEN_CODEENTREPOT.Value = DBNull.Value;

			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhamouvementstocklivraison.AR_CODEARTICLE ;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstocklivraison.MS_NUMPIECE ;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhamouvementstocklivraison.NO_CODENATUREOPERATION ;
			if(clsPhamouvementstocklivraison.NO_CODENATUREOPERATION== ""  ) vppParamNO_CODENATUREOPERATION.Value  = DBNull.Value;
			SqlParameter vppParamLV_QUANTITELIVRER = new SqlParameter("@LV_QUANTITELIVRER", SqlDbType.Float);
			vppParamLV_QUANTITELIVRER.Value  = clsPhamouvementstocklivraison.LV_QUANTITELIVRER ;
			SqlParameter vppParamLV_DATELIVRAISON = new SqlParameter("@LV_DATELIVRAISON", SqlDbType.DateTime);
			vppParamLV_DATELIVRAISON.Value  = clsPhamouvementstocklivraison.LV_DATELIVRAISON ;
			SqlParameter vppParamLV_ANNULATIONPIECE = new SqlParameter("@LV_ANNULATIONPIECE", SqlDbType.VarChar, 1);
			vppParamLV_ANNULATIONPIECE.Value  = clsPhamouvementstocklivraison.LV_ANNULATIONPIECE ;
			SqlParameter vppParamLV_NUMEROPIECE = new SqlParameter("@LV_NUMEROPIECE", SqlDbType.BigInt);
			vppParamLV_NUMEROPIECE.Value  = clsPhamouvementstocklivraison.LV_NUMEROPIECE ;
			if(clsPhamouvementstocklivraison.LV_NUMEROPIECE== 0  ) vppParamLV_NUMEROPIECE.Value  = DBNull.Value;
			SqlParameter vppParamLV_MONTANTVERSE = new SqlParameter("@LV_MONTANTVERSE", SqlDbType.Money);
			vppParamLV_MONTANTVERSE.Value  = clsPhamouvementstocklivraison.LV_MONTANTVERSE ;
			if(clsPhamouvementstocklivraison.LV_MONTANTVERSE== 0  ) vppParamLV_MONTANTVERSE.Value  = DBNull.Value;
			SqlParameter vppParamLV_REMETTANT = new SqlParameter("@LV_REMETTANT", SqlDbType.VarChar, 150);
			vppParamLV_REMETTANT.Value  = clsPhamouvementstocklivraison.LV_REMETTANT ;
			if(clsPhamouvementstocklivraison.LV_REMETTANT== ""  ) vppParamLV_REMETTANT.Value  = DBNull.Value;
			SqlParameter vppParamLV_AGENTLIVREUR = new SqlParameter("@LV_AGENTLIVREUR", SqlDbType.VarChar, 150);
			vppParamLV_AGENTLIVREUR.Value  = clsPhamouvementstocklivraison.LV_AGENTLIVREUR ;
			if(clsPhamouvementstocklivraison.LV_AGENTLIVREUR== ""  ) vppParamLV_AGENTLIVREUR.Value  = DBNull.Value;

            SqlParameter vppParamVH_CODEVEHICULE = new SqlParameter("@VH_CODEVEHICULE", SqlDbType.Int);
            vppParamVH_CODEVEHICULE.Value = clsPhamouvementstocklivraison.VH_CODEVEHICULE;
            //if (clsPhamouvementstocklivraison.VH_CODEVEHICULE == "") vppParamVH_CODEVEHICULE.Value = DBNull.Value;

			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKLIVRAISON  @LV_NUMSEQUENCE, @AG_CODEAGENCE, @CH_IDCHAUFFEUR,@TR_IDTRANSPORTEUR,@EN_CODEENTREPOT, @AR_CODEARTICLE, @MS_NUMPIECE, @NO_CODENATUREOPERATION, @LV_QUANTITELIVRER, @LV_DATELIVRAISON, @LV_ANNULATIONPIECE, @LV_NUMEROPIECE, @LV_MONTANTVERSE, @LV_REMETTANT, @LV_AGENTLIVREUR,@VH_CODEVEHICULE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLV_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamTR_IDTRANSPORTEUR);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamLV_QUANTITELIVRER);
			vppSqlCmd.Parameters.Add(vppParamLV_DATELIVRAISON);
			vppSqlCmd.Parameters.Add(vppParamLV_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamLV_NUMEROPIECE);
			vppSqlCmd.Parameters.Add(vppParamLV_MONTANTVERSE);
			vppSqlCmd.Parameters.Add(vppParamLV_REMETTANT);
			vppSqlCmd.Parameters.Add(vppParamLV_AGENTLIVREUR);
            vppSqlCmd.Parameters.Add(vppParamVH_CODEVEHICULE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}




        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstocklivraison>clsPhamouvementstocklivraison</param>
        ///<author>Home Technology</author>
        public string pvgMiseajour(clsDonnee clsDonnee, clsPhamouvementstocklivraison clsPhamouvementstocklivraison)
        {
            //Préparation des paramètres
            SqlParameter vppParamLV_NUMSEQUENCE = new SqlParameter("@LV_NUMSEQUENCE", SqlDbType.VarChar, 50);
            vppParamLV_NUMSEQUENCE.Value = clsPhamouvementstocklivraison.LV_NUMSEQUENCE;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstocklivraison.AG_CODEAGENCE;
            SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.VarChar, 25);
            vppParamCH_IDCHAUFFEUR.Value = clsPhamouvementstocklivraison.CH_IDCHAUFFEUR;
            if (clsPhamouvementstocklivraison.CH_IDCHAUFFEUR == "")
                vppParamCH_IDCHAUFFEUR.Value = DBNull.Value;


            SqlParameter vppParamTR_IDTRANSPORTEUR = new SqlParameter("@TR_IDTRANSPORTEUR", SqlDbType.VarChar, 25);
            vppParamTR_IDTRANSPORTEUR.Value = clsPhamouvementstocklivraison.TR_IDTRANSPORTEUR;
            if (clsPhamouvementstocklivraison.TR_IDTRANSPORTEUR == "") vppParamTR_IDTRANSPORTEUR.Value = DBNull.Value;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
            vppParamEN_CODEENTREPOT.Value = clsPhamouvementstocklivraison.EN_CODEENTREPOT;
            if (clsPhamouvementstocklivraison.EN_CODEENTREPOT == "") vppParamEN_CODEENTREPOT.Value = DBNull.Value;

            SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
            vppParamAR_CODEARTICLE.Value = clsPhamouvementstocklivraison.AR_CODEARTICLE;
            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementstocklivraison.MS_NUMPIECE;
            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementstocklivraison.NO_CODENATUREOPERATION;
            if (clsPhamouvementstocklivraison.NO_CODENATUREOPERATION == "") vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;
            SqlParameter vppParamLV_QUANTITELIVRER = new SqlParameter("@LV_QUANTITELIVRER", SqlDbType.Float);
            vppParamLV_QUANTITELIVRER.Value = clsPhamouvementstocklivraison.LV_QUANTITELIVRER;
            SqlParameter vppParamLV_DATELIVRAISON = new SqlParameter("@LV_DATELIVRAISON", SqlDbType.DateTime);
            vppParamLV_DATELIVRAISON.Value = clsPhamouvementstocklivraison.LV_DATELIVRAISON;
            SqlParameter vppParamLV_ANNULATIONPIECE = new SqlParameter("@LV_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamLV_ANNULATIONPIECE.Value = clsPhamouvementstocklivraison.LV_ANNULATIONPIECE;
            SqlParameter vppParamLV_NUMEROPIECE = new SqlParameter("@LV_NUMEROPIECE", SqlDbType.BigInt);
            vppParamLV_NUMEROPIECE.Value = clsPhamouvementstocklivraison.LV_NUMEROPIECE;
            if (clsPhamouvementstocklivraison.LV_NUMEROPIECE == 0) vppParamLV_NUMEROPIECE.Value = DBNull.Value;
            SqlParameter vppParamLV_MONTANTVERSE = new SqlParameter("@LV_MONTANTVERSE", SqlDbType.Money);
            vppParamLV_MONTANTVERSE.Value = clsPhamouvementstocklivraison.LV_MONTANTVERSE;
            //if (clsPhamouvementstocklivraison.LV_MONTANTVERSE == 0) vppParamLV_MONTANTVERSE.Value = DBNull.Value;
            SqlParameter vppParamLV_REMETTANT = new SqlParameter("@LV_REMETTANT", SqlDbType.VarChar, 150);
            vppParamLV_REMETTANT.Value = clsPhamouvementstocklivraison.LV_REMETTANT;
            if (clsPhamouvementstocklivraison.LV_REMETTANT == "") vppParamLV_REMETTANT.Value = DBNull.Value;
            SqlParameter vppParamLV_AGENTLIVREUR = new SqlParameter("@LV_AGENTLIVREUR", SqlDbType.VarChar, 150);
            vppParamLV_AGENTLIVREUR.Value = clsPhamouvementstocklivraison.LV_AGENTLIVREUR;
            if (clsPhamouvementstocklivraison.LV_AGENTLIVREUR == "") vppParamLV_AGENTLIVREUR.Value = DBNull.Value;

            SqlParameter vppParamVH_CODEVEHICULE = new SqlParameter("@VH_CODEVEHICULE", SqlDbType.Int);
            vppParamVH_CODEVEHICULE.Value = clsPhamouvementstocklivraison.VH_CODEVEHICULE;
            //if (clsPhamouvementstocklivraison.VH_CODEVEHICULE == "") vppParamVH_CODEVEHICULE.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementstocklivraison.TYPEOPERATION;


            SqlParameter vppParamLV_NUMPIECERETOUR = new SqlParameter("@LV_NUMPIECERETOUR", SqlDbType.VarChar, 50);

            SqlCommand vppSqlCmd = new SqlCommand("PC_PHAMOUVEMENTSTOCKLIVRAISON", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            ////Préparation de la commande
            //this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKLIVRAISON  @LV_NUMSEQUENCE, @AG_CODEAGENCE, @CH_IDCHAUFFEUR, @AR_CODEARTICLE, @MS_NUMPIECE, @NO_CODENATUREOPERATION, @LV_QUANTITELIVRER, @LV_DATELIVRAISON, @LV_ANNULATIONPIECE, @LV_NUMEROPIECE, @LV_MONTANTVERSE, @LV_REMETTANT, @LV_AGENTLIVREUR, @CODECRYPTAGE, 0 ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamLV_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
            vppSqlCmd.Parameters.Add(vppParamTR_IDTRANSPORTEUR);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamLV_QUANTITELIVRER);
            vppSqlCmd.Parameters.Add(vppParamLV_DATELIVRAISON);
            vppSqlCmd.Parameters.Add(vppParamLV_ANNULATIONPIECE);
            vppSqlCmd.Parameters.Add(vppParamLV_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamLV_MONTANTVERSE);
            vppSqlCmd.Parameters.Add(vppParamLV_REMETTANT);
            vppSqlCmd.Parameters.Add(vppParamLV_AGENTLIVREUR);
            vppSqlCmd.Parameters.Add(vppParamVH_CODEVEHICULE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamLV_NUMPIECERETOUR);
            vppParamLV_NUMPIECERETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@LV_NUMPIECERETOUR"].Value.ToString();
        }




		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstocklivraison>clsPhamouvementstocklivraison</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstocklivraison clsPhamouvementstocklivraison,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamLV_NUMSEQUENCE = new SqlParameter("@LV_NUMSEQUENCE", SqlDbType.VarChar, 50);
			vppParamLV_NUMSEQUENCE.Value  = clsPhamouvementstocklivraison.LV_NUMSEQUENCE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstocklivraison.AG_CODEAGENCE ;
			SqlParameter vppParamCH_IDCHAUFFEUR = new SqlParameter("@CH_IDCHAUFFEUR", SqlDbType.VarChar, 25);
			vppParamCH_IDCHAUFFEUR.Value  = clsPhamouvementstocklivraison.CH_IDCHAUFFEUR ;
			SqlParameter vppParamAR_CODEARTICLE = new SqlParameter("@AR_CODEARTICLE", SqlDbType.VarChar, 7);
			vppParamAR_CODEARTICLE.Value  = clsPhamouvementstocklivraison.AR_CODEARTICLE ;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstocklivraison.MS_NUMPIECE ;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 4);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhamouvementstocklivraison.NO_CODENATUREOPERATION ;
			if(clsPhamouvementstocklivraison.NO_CODENATUREOPERATION== ""  ) vppParamNO_CODENATUREOPERATION.Value  = DBNull.Value;
			SqlParameter vppParamLV_QUANTITELIVRER = new SqlParameter("@LV_QUANTITELIVRER", SqlDbType.Float);
			vppParamLV_QUANTITELIVRER.Value  = clsPhamouvementstocklivraison.LV_QUANTITELIVRER ;
			SqlParameter vppParamLV_DATELIVRAISON = new SqlParameter("@LV_DATELIVRAISON", SqlDbType.DateTime);
			vppParamLV_DATELIVRAISON.Value  = clsPhamouvementstocklivraison.LV_DATELIVRAISON ;
			SqlParameter vppParamLV_ANNULATIONPIECE = new SqlParameter("@LV_ANNULATIONPIECE", SqlDbType.VarChar, 1);
			vppParamLV_ANNULATIONPIECE.Value  = clsPhamouvementstocklivraison.LV_ANNULATIONPIECE ;
			SqlParameter vppParamLV_NUMEROPIECE = new SqlParameter("@LV_NUMEROPIECE", SqlDbType.BigInt);
			vppParamLV_NUMEROPIECE.Value  = clsPhamouvementstocklivraison.LV_NUMEROPIECE ;
			if(clsPhamouvementstocklivraison.LV_NUMEROPIECE== 0 ) vppParamLV_NUMEROPIECE.Value  = DBNull.Value;
			SqlParameter vppParamLV_MONTANTVERSE = new SqlParameter("@LV_MONTANTVERSE", SqlDbType.Money);
			vppParamLV_MONTANTVERSE.Value  = clsPhamouvementstocklivraison.LV_MONTANTVERSE ;
			if(clsPhamouvementstocklivraison.LV_MONTANTVERSE==0  ) vppParamLV_MONTANTVERSE.Value  = DBNull.Value;
			SqlParameter vppParamLV_REMETTANT = new SqlParameter("@LV_REMETTANT", SqlDbType.VarChar, 150);
			vppParamLV_REMETTANT.Value  = clsPhamouvementstocklivraison.LV_REMETTANT ;
			if(clsPhamouvementstocklivraison.LV_REMETTANT== ""  ) vppParamLV_REMETTANT.Value  = DBNull.Value;
			SqlParameter vppParamLV_AGENTLIVREUR = new SqlParameter("@LV_AGENTLIVREUR", SqlDbType.VarChar, 150);
			vppParamLV_AGENTLIVREUR.Value  = clsPhamouvementstocklivraison.LV_AGENTLIVREUR ;
			if(clsPhamouvementstocklivraison.LV_AGENTLIVREUR== ""  ) vppParamLV_AGENTLIVREUR.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKLIVRAISON  @LV_NUMSEQUENCE, @AG_CODEAGENCE, @CH_IDCHAUFFEUR, @AR_CODEARTICLE, @MS_NUMPIECE, @NO_CODENATUREOPERATION, @LV_QUANTITELIVRER, @LV_DATELIVRAISON, @LV_ANNULATIONPIECE, @LV_NUMEROPIECE, @LV_MONTANTVERSE, @LV_REMETTANT, @LV_AGENTLIVREUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamLV_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamCH_IDCHAUFFEUR);
			vppSqlCmd.Parameters.Add(vppParamAR_CODEARTICLE);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamLV_QUANTITELIVRER);
			vppSqlCmd.Parameters.Add(vppParamLV_DATELIVRAISON);
			vppSqlCmd.Parameters.Add(vppParamLV_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamLV_NUMEROPIECE);
			vppSqlCmd.Parameters.Add(vppParamLV_MONTANTVERSE);
			vppSqlCmd.Parameters.Add(vppParamLV_REMETTANT);
			vppSqlCmd.Parameters.Add(vppParamLV_AGENTLIVREUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKLIVRAISON  @LV_NUMSEQUENCE, @AG_CODEAGENCE, '' ,'' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' ,'' ,@CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstocklivraison </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstocklivraison> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  LV_NUMSEQUENCE, AG_CODEAGENCE, CH_IDCHAUFFEUR, AR_CODEARTICLE, MS_NUMPIECE, NO_CODENATUREOPERATION, LV_QUANTITELIVRER, LV_DATELIVRAISON, LV_ANNULATIONPIECE, LV_NUMEROPIECE, LV_MONTANTVERSE, LV_REMETTANT, LV_AGENTLIVREUR FROM dbo.FT_PHAMOUVEMENTSTOCKLIVRAISON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstocklivraison> clsPhamouvementstocklivraisons = new List<clsPhamouvementstocklivraison>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstocklivraison clsPhamouvementstocklivraison = new clsPhamouvementstocklivraison();
					clsPhamouvementstocklivraison.LV_NUMSEQUENCE = clsDonnee.vogDataReader["LV_NUMSEQUENCE"].ToString();
					clsPhamouvementstocklivraison.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstocklivraison.CH_IDCHAUFFEUR = clsDonnee.vogDataReader["CH_IDCHAUFFEUR"].ToString();
					clsPhamouvementstocklivraison.AR_CODEARTICLE = clsDonnee.vogDataReader["AR_CODEARTICLE"].ToString();
					clsPhamouvementstocklivraison.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementstocklivraison.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstocklivraison.LV_QUANTITELIVRER = float.Parse(clsDonnee.vogDataReader["LV_QUANTITELIVRER"].ToString());
					clsPhamouvementstocklivraison.LV_DATELIVRAISON = DateTime.Parse(clsDonnee.vogDataReader["LV_DATELIVRAISON"].ToString());
					clsPhamouvementstocklivraison.LV_ANNULATIONPIECE = clsDonnee.vogDataReader["LV_ANNULATIONPIECE"].ToString();
					clsPhamouvementstocklivraison.LV_NUMEROPIECE = double.Parse(clsDonnee.vogDataReader["LV_NUMEROPIECE"].ToString());
					clsPhamouvementstocklivraison.LV_MONTANTVERSE = double.Parse(clsDonnee.vogDataReader["LV_MONTANTVERSE"].ToString());
					clsPhamouvementstocklivraison.LV_REMETTANT = clsDonnee.vogDataReader["LV_REMETTANT"].ToString();
					clsPhamouvementstocklivraison.LV_AGENTLIVREUR = clsDonnee.vogDataReader["LV_AGENTLIVREUR"].ToString();
					clsPhamouvementstocklivraisons.Add(clsPhamouvementstocklivraison);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstocklivraisons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstocklivraison </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstocklivraison> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstocklivraison> clsPhamouvementstocklivraisons = new List<clsPhamouvementstocklivraison>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  LV_NUMSEQUENCE, AG_CODEAGENCE, CH_IDCHAUFFEUR, AR_CODEARTICLE, MS_NUMPIECE, NO_CODENATUREOPERATION, LV_QUANTITELIVRER, LV_DATELIVRAISON, LV_ANNULATIONPIECE, LV_NUMEROPIECE, LV_MONTANTVERSE, LV_REMETTANT, LV_AGENTLIVREUR FROM dbo.FT_PHAMOUVEMENTSTOCKLIVRAISON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstocklivraison clsPhamouvementstocklivraison = new clsPhamouvementstocklivraison();
					clsPhamouvementstocklivraison.LV_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["LV_NUMSEQUENCE"].ToString();
					clsPhamouvementstocklivraison.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementstocklivraison.CH_IDCHAUFFEUR = Dataset.Tables["TABLE"].Rows[Idx]["CH_IDCHAUFFEUR"].ToString();
					clsPhamouvementstocklivraison.AR_CODEARTICLE = Dataset.Tables["TABLE"].Rows[Idx]["AR_CODEARTICLE"].ToString();
					clsPhamouvementstocklivraison.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhamouvementstocklivraison.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstocklivraison.LV_QUANTITELIVRER = float.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LV_QUANTITELIVRER"].ToString());
					clsPhamouvementstocklivraison.LV_DATELIVRAISON = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LV_DATELIVRAISON"].ToString());
					clsPhamouvementstocklivraison.LV_ANNULATIONPIECE = Dataset.Tables["TABLE"].Rows[Idx]["LV_ANNULATIONPIECE"].ToString();
					clsPhamouvementstocklivraison.LV_NUMEROPIECE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LV_NUMEROPIECE"].ToString());
					clsPhamouvementstocklivraison.LV_MONTANTVERSE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["LV_MONTANTVERSE"].ToString());
					clsPhamouvementstocklivraison.LV_REMETTANT = Dataset.Tables["TABLE"].Rows[Idx]["LV_REMETTANT"].ToString();
					clsPhamouvementstocklivraison.LV_AGENTLIVREUR = Dataset.Tables["TABLE"].Rows[Idx]["LV_AGENTLIVREUR"].ToString();
					clsPhamouvementstocklivraisons.Add(clsPhamouvementstocklivraison);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstocklivraisons;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKLIVRAISON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetLivraison(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@ET_TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] , vppCritere[2] , vppCritere[3] , vppCritere[4] };
            this.vapRequete = "EXEC [dbo].[PS_ETATRELEVELIVRAISON]  @AG_CODEAGENCE,@MS_NUMPIECE,@MC_DATEPIECE1,@MC_DATEPIECE2 ,@ET_TYPEETAT,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetBonLivraison(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@MS_NUMPIECE", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@ET_TYPEETAT" , "@NO_CODENATUREOPERATION" , "@OP_CODEOPERATEUREDITION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] , vppCritere[2] , vppCritere[3] , vppCritere[4] , vppCritere[5] , vppCritere[6], vppCritere[7] };
            this.vapRequete = "EXEC [dbo].[PS_ETATBONLIVRAISON]  @AG_CODEAGENCE,@EN_CODEENTREPOT,@MS_NUMPIECE,@MC_DATEPIECE1,@MC_DATEPIECE2 ,@ET_TYPEETAT,@NO_CODENATUREOPERATION ,@OP_CODEOPERATEUREDITION ,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetFactureLivraison(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@LV_NUMEROPIECE", "@MC_DATEPIECE1", "@MC_DATEPIECE2", "@ET_TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] , vppCritere[2] , vppCritere[3] , vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC [dbo].[PS_ETATFACTURELIVRAISON]  @AG_CODEAGENCE,@MS_NUMPIECE,@LV_NUMEROPIECE,@MC_DATEPIECE1,@MC_DATEPIECE2 ,@ET_TYPEETAT,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetListeLivraison(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE", "@LV_DATELIVRAISON1" , "@LV_DATELIVRAISON2" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] };
            this.vapRequete = "EXEC [dbo].[PS_LIVRAISON]  @AG_CODEAGENCE,@MS_NUMPIECE,@LV_DATELIVRAISON1,@LV_DATELIVRAISON2,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : LV_NUMSEQUENCE, AG_CODEAGENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT LV_NUMSEQUENCE , CH_IDCHAUFFEUR FROM dbo.FT_PHAMOUVEMENTSTOCKLIVRAISON(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :LV_NUMSEQUENCE, AG_CODEAGENCE)</summary>
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
                this.vapCritere = "WHERE  AG_CODEAGENCE=@AG_CODEAGENCE AND MS_NUMPIECE=@MS_NUMPIECE ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MS_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
