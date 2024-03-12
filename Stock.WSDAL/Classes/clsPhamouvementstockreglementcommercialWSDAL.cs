using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockreglementcommercialWSDAL: ITableDAL<clsPhamouvementstockreglementcommercial>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MC_NUMPIECE) AS MC_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MIN(MC_NUMPIECE) AS MC_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL" + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(MC_NUMPIECE) AS MC_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglementcommercial comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglementcommercial pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , MR_CODEMODEREGLEMENT  , NO_CODENATUREOPERATION  , MS_NUMPIECE  , MC_MONTANTDEBIT  , MC_MONTANTCREDIT  , MC_DATEPIECE  , MC_ANNULATIONPIECE  , MC_REFERENCEPIECE  , MC_LIBELLEOPERATION  , MC_NOMTIERS  , CO_IDCOMMERCIAL  , MC_NUMEROPIECE  , MC_NUMSEQUENCE  , OP_CODEOPERATEUR  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockreglementcommercial clsPhamouvementstockreglementcommercial = new clsPhamouvementstockreglementcommercial();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementcommercial.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockreglementcommercial.MR_CODEMODEREGLEMENT = clsDonnee.vogDataReader["MR_CODEMODEREGLEMENT"].ToString();
					clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockreglementcommercial.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["MC_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["MC_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglementcommercial.MC_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MC_DATEPIECE"].ToString());
					clsPhamouvementstockreglementcommercial.MC_ANNULATIONPIECE = clsDonnee.vogDataReader["MC_ANNULATIONPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE = clsDonnee.vogDataReader["MC_REFERENCEPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION = clsDonnee.vogDataReader["MC_LIBELLEOPERATION"].ToString();
					clsPhamouvementstockreglementcommercial.MC_NOMTIERS = clsDonnee.vogDataReader["MC_NOMTIERS"].ToString();
					clsPhamouvementstockreglementcommercial.CO_IDCOMMERCIAL = clsDonnee.vogDataReader["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementstockreglementcommercial.MC_NUMEROPIECE = double.Parse(clsDonnee.vogDataReader["MC_NUMEROPIECE"].ToString());
					clsPhamouvementstockreglementcommercial.MC_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["MC_NUMSEQUENCE"].ToString());
					clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockreglementcommercial;
		}



		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementcommercial>clsPhamouvementstockreglementcommercial</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockreglementcommercial clsPhamouvementstockreglementcommercial)
		{
			//Préparation des paramètres
			SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMC_NUMPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_NUMPIECE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstockreglementcommercial.AG_CODEAGENCE ;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION ;
			if(clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION== ""  ) vppParamNO_CODENATUREOPERATION.Value  = DBNull.Value;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstockreglementcommercial.MS_NUMPIECE ;
			if(clsPhamouvementstockreglementcommercial.MS_NUMPIECE== ""  ) vppParamMS_NUMPIECE.Value  = DBNull.Value;
			SqlParameter vppParamMC_MONTANTDEBIT = new SqlParameter("@MC_MONTANTDEBIT", SqlDbType.Money);
			vppParamMC_MONTANTDEBIT.Value  = clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT ;
            //if(clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT== ""  ) vppParamMC_MONTANTDEBIT.Value  = DBNull.Value;
			SqlParameter vppParamMC_MONTANTCREDIT = new SqlParameter("@MC_MONTANTCREDIT", SqlDbType.Money);
			vppParamMC_MONTANTCREDIT.Value  = clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT ;
            //if(clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT=0  ) vppParamMC_MONTANTCREDIT.Value  = DBNull.Value;
			SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
			vppParamMC_DATEPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_DATEPIECE ;
			SqlParameter vppParamMC_ANNULATIONPIECE = new SqlParameter("@MC_ANNULATIONPIECE", SqlDbType.VarChar, 1);
			vppParamMC_ANNULATIONPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_ANNULATIONPIECE ;
			SqlParameter vppParamMC_REFERENCEPIECE = new SqlParameter("@MC_REFERENCEPIECE", SqlDbType.VarChar, 1000);
			vppParamMC_REFERENCEPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE ;
			if(clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE== ""  ) vppParamMC_REFERENCEPIECE.Value  = DBNull.Value;
			SqlParameter vppParamMC_LIBELLEOPERATION = new SqlParameter("@MC_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
			vppParamMC_LIBELLEOPERATION.Value  = clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION ;
			if(clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION== ""  ) vppParamMC_LIBELLEOPERATION.Value  = DBNull.Value;
			SqlParameter vppParamMC_NOMTIERS = new SqlParameter("@MC_NOMTIERS", SqlDbType.VarChar, 1000);
			vppParamMC_NOMTIERS.Value  = clsPhamouvementstockreglementcommercial.MC_NOMTIERS ;
			if(clsPhamouvementstockreglementcommercial.MC_NOMTIERS== ""  ) vppParamMC_NOMTIERS.Value  = DBNull.Value;
			SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar, 50);
			vppParamCO_IDCOMMERCIAL.Value  = clsPhamouvementstockreglementcommercial.CO_IDCOMMERCIAL ;
			SqlParameter vppParamMC_NUMEROPIECE = new SqlParameter("@MC_NUMEROPIECE", SqlDbType.BigInt);
			vppParamMC_NUMEROPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_NUMEROPIECE ;
			SqlParameter vppParamMC_NUMSEQUENCE = new SqlParameter("@MC_NUMSEQUENCE", SqlDbType.BigInt);
			vppParamMC_NUMSEQUENCE.Value  = clsPhamouvementstockreglementcommercial.MC_NUMSEQUENCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR ;
			if(clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR== ""  ) vppParamOP_CODEOPERATEUR.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL  @MC_NUMPIECE, @AG_CODEAGENCE,  @NO_CODENATUREOPERATION, @MS_NUMPIECE, @MC_MONTANTDEBIT, @MC_MONTANTCREDIT, @MC_DATEPIECE,  @MC_REFERENCEPIECE, @MC_LIBELLEOPERATION, @MC_NOMTIERS, @CO_IDCOMMERCIAL, @MC_NUMEROPIECE, @MC_NUMSEQUENCE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);

			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamMC_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_REFERENCEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_LIBELLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMC_NOMTIERS);
			vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
			vppSqlCmd.Parameters.Add(vppParamMC_NUMEROPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglementcommercial>clsPhamouvementstockreglementcommercial</param>
        ///<author>Home Technology</author>
        public string pvgInsert1(clsDonnee clsDonnee, clsPhamouvementstockreglementcommercial clsPhamouvementstockreglementcommercial)
        {
            //Préparation des paramètres
            SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMC_NUMPIECE.Value = clsPhamouvementstockreglementcommercial.MC_NUMPIECE;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPhamouvementstockreglementcommercial.AG_CODEAGENCE;
            SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
            vppParamNO_CODENATUREOPERATION.Value = clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION;
            if (clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION == "") vppParamNO_CODENATUREOPERATION.Value = DBNull.Value;
            SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
            vppParamMS_NUMPIECE.Value = clsPhamouvementstockreglementcommercial.MS_NUMPIECE;
            if (clsPhamouvementstockreglementcommercial.MS_NUMPIECE == "") vppParamMS_NUMPIECE.Value = DBNull.Value;
            SqlParameter vppParamMC_MONTANTDEBIT = new SqlParameter("@MC_MONTANTDEBIT", SqlDbType.Money);
            vppParamMC_MONTANTDEBIT.Value = clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT;
            //if(clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT== ""  ) vppParamMC_MONTANTDEBIT.Value  = DBNull.Value;
            SqlParameter vppParamMC_MONTANTCREDIT = new SqlParameter("@MC_MONTANTCREDIT", SqlDbType.Money);
            vppParamMC_MONTANTCREDIT.Value = clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT;
            //if(clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT=0  ) vppParamMC_MONTANTCREDIT.Value  = DBNull.Value;
            SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
            vppParamMC_DATEPIECE.Value = clsPhamouvementstockreglementcommercial.MC_DATEPIECE;
            SqlParameter vppParamMC_ANNULATIONPIECE = new SqlParameter("@MC_ANNULATIONPIECE", SqlDbType.VarChar, 1);
            vppParamMC_ANNULATIONPIECE.Value = clsPhamouvementstockreglementcommercial.MC_ANNULATIONPIECE;
            SqlParameter vppParamMC_REFERENCEPIECE = new SqlParameter("@MC_REFERENCEPIECE", SqlDbType.VarChar, 1000);
            vppParamMC_REFERENCEPIECE.Value = clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE;
            if (clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE == "") vppParamMC_REFERENCEPIECE.Value = DBNull.Value;
            SqlParameter vppParamMC_LIBELLEOPERATION = new SqlParameter("@MC_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
            vppParamMC_LIBELLEOPERATION.Value = clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION;
            if (clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION == "") vppParamMC_LIBELLEOPERATION.Value = DBNull.Value;
            SqlParameter vppParamMC_NOMTIERS = new SqlParameter("@MC_NOMTIERS", SqlDbType.VarChar, 1000);
            vppParamMC_NOMTIERS.Value = clsPhamouvementstockreglementcommercial.MC_NOMTIERS;
            if (clsPhamouvementstockreglementcommercial.MC_NOMTIERS == "") vppParamMC_NOMTIERS.Value = DBNull.Value;
            SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar, 50);
            vppParamCO_IDCOMMERCIAL.Value = clsPhamouvementstockreglementcommercial.CO_IDCOMMERCIAL;
            SqlParameter vppParamMC_NUMEROPIECE = new SqlParameter("@MC_NUMEROPIECE", SqlDbType.BigInt);
            vppParamMC_NUMEROPIECE.Value = clsPhamouvementstockreglementcommercial.MC_NUMEROPIECE;
            SqlParameter vppParamMC_NUMSEQUENCE = new SqlParameter("@MC_NUMSEQUENCE", SqlDbType.BigInt);
            vppParamMC_NUMSEQUENCE.Value = clsPhamouvementstockreglementcommercial.MC_NUMSEQUENCE;
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR;
            if (clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR == "") vppParamOP_CODEOPERATEUR.Value = DBNull.Value;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 50);
            vppParamTYPEOPERATION.Value = "0";

            SqlParameter vppParamMC_NUMPIECERETOUR = new SqlParameter("@MC_NUMPIECERETOUR", SqlDbType.VarChar, 25);
            vppParamMC_NUMPIECERETOUR.Value = "";

            //Préparation de la commande
            // this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL  @MC_NUMPIECE, @AG_CODEAGENCE,  @NO_CODENATUREOPERATION, @MS_NUMPIECE, @MC_MONTANTDEBIT, @MC_MONTANTCREDIT, @MC_DATEPIECE,  @MC_REFERENCEPIECE, @MC_LIBELLEOPERATION, @MC_NOMTIERS, @CO_IDCOMMERCIAL, @MC_NUMEROPIECE, @MC_NUMSEQUENCE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 0 ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            SqlCommand vppSqlCmd = new SqlCommand("PC_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);

            vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_MONTANTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamMC_MONTANTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_REFERENCEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_LIBELLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamMC_NOMTIERS);
            vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamMC_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECERETOUR);
            //Ouverture de la connection et exécution de la commande
            vppParamMC_NUMPIECERETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@MC_NUMPIECERETOUR"].Value.ToString();
        }




		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementcommercial>clsPhamouvementstockreglementcommercial</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockreglementcommercial clsPhamouvementstockreglementcommercial,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMC_NUMPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_NUMPIECE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstockreglementcommercial.AG_CODEAGENCE ;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION ;
			if(clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION== ""  ) vppParamNO_CODENATUREOPERATION.Value  = DBNull.Value;
			SqlParameter vppParamMS_NUMPIECE = new SqlParameter("@MS_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMS_NUMPIECE.Value  = clsPhamouvementstockreglementcommercial.MS_NUMPIECE ;
			if(clsPhamouvementstockreglementcommercial.MS_NUMPIECE== ""  ) vppParamMS_NUMPIECE.Value  = DBNull.Value;
			SqlParameter vppParamMC_MONTANTDEBIT = new SqlParameter("@MC_MONTANTDEBIT", SqlDbType.Money);
			vppParamMC_MONTANTDEBIT.Value  = clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT ;
            //if(clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT== ""  ) vppParamMC_MONTANTDEBIT.Value  = DBNull.Value;
			SqlParameter vppParamMC_MONTANTCREDIT = new SqlParameter("@MC_MONTANTCREDIT", SqlDbType.Money);
			vppParamMC_MONTANTCREDIT.Value  = clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT ;
            //if(clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT== ""  ) vppParamMC_MONTANTCREDIT.Value  = DBNull.Value;
			SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
			vppParamMC_DATEPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_DATEPIECE ;
			
			SqlParameter vppParamMC_REFERENCEPIECE = new SqlParameter("@MC_REFERENCEPIECE", SqlDbType.VarChar, 1000);
			vppParamMC_REFERENCEPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE ;
			if(clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE== ""  ) vppParamMC_REFERENCEPIECE.Value  = DBNull.Value;
			SqlParameter vppParamMC_LIBELLEOPERATION = new SqlParameter("@MC_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
			vppParamMC_LIBELLEOPERATION.Value  = clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION ;
			if(clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION== ""  ) vppParamMC_LIBELLEOPERATION.Value  = DBNull.Value;
			SqlParameter vppParamMC_NOMTIERS = new SqlParameter("@MC_NOMTIERS", SqlDbType.VarChar, 1000);
			vppParamMC_NOMTIERS.Value  = clsPhamouvementstockreglementcommercial.MC_NOMTIERS ;
			if(clsPhamouvementstockreglementcommercial.MC_NOMTIERS== ""  ) vppParamMC_NOMTIERS.Value  = DBNull.Value;
			SqlParameter vppParamCO_IDCOMMERCIAL = new SqlParameter("@CO_IDCOMMERCIAL", SqlDbType.VarChar, 50);
			vppParamCO_IDCOMMERCIAL.Value  = clsPhamouvementstockreglementcommercial.CO_IDCOMMERCIAL ;
			SqlParameter vppParamMC_NUMEROPIECE = new SqlParameter("@MC_NUMEROPIECE", SqlDbType.BigInt);
			vppParamMC_NUMEROPIECE.Value  = clsPhamouvementstockreglementcommercial.MC_NUMEROPIECE ;
			SqlParameter vppParamMC_NUMSEQUENCE = new SqlParameter("@MC_NUMSEQUENCE", SqlDbType.BigInt);
			vppParamMC_NUMSEQUENCE.Value  = clsPhamouvementstockreglementcommercial.MC_NUMSEQUENCE ;
			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value  = clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR ;
			if(clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR== ""  ) vppParamOP_CODEOPERATEUR.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL  @MC_NUMPIECE, @AG_CODEAGENCE, @NO_CODENATUREOPERATION, @MS_NUMPIECE, @MC_MONTANTDEBIT, @MC_MONTANTCREDIT, @MC_DATEPIECE, @MC_REFERENCEPIECE, @MC_LIBELLEOPERATION, @MC_NOMTIERS, @CO_IDCOMMERCIAL, @MC_NUMEROPIECE, @MC_NUMSEQUENCE, @OP_CODEOPERATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            //vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMS_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamMC_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
            //vppSqlCmd.Parameters.Add(vppParamMC_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_REFERENCEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_LIBELLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMC_NOMTIERS);
			vppSqlCmd.Parameters.Add(vppParamCO_IDCOMMERCIAL);
			vppSqlCmd.Parameters.Add(vppParamMC_NUMEROPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL  @MC_NUMPIECE, @AG_CODEAGENCE, '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' ,  @OP_CODEOPERATEUR, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementcommercial </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementcommercial> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MC_NUMPIECE, AG_CODEAGENCE,  NO_CODENATUREOPERATION, MS_NUMPIECE, MC_MONTANTDEBIT, MC_MONTANTCREDIT, MC_DATEPIECE,  MC_REFERENCEPIECE, MC_LIBELLEOPERATION, MC_NOMTIERS, CO_IDCOMMERCIAL, MC_NUMEROPIECE, MC_NUMSEQUENCE, OP_CODEOPERATEUR FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockreglementcommercial> clsPhamouvementstockreglementcommercials = new List<clsPhamouvementstockreglementcommercial>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementcommercial clsPhamouvementstockreglementcommercial = new clsPhamouvementstockreglementcommercial();
					clsPhamouvementstockreglementcommercial.MC_NUMPIECE = clsDonnee.vogDataReader["MC_NUMPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					
					clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockreglementcommercial.MS_NUMPIECE = clsDonnee.vogDataReader["MS_NUMPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["MC_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["MC_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglementcommercial.MC_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MC_DATEPIECE"].ToString());
					
					clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE = clsDonnee.vogDataReader["MC_REFERENCEPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION = clsDonnee.vogDataReader["MC_LIBELLEOPERATION"].ToString();
					clsPhamouvementstockreglementcommercial.MC_NOMTIERS = clsDonnee.vogDataReader["MC_NOMTIERS"].ToString();
					clsPhamouvementstockreglementcommercial.CO_IDCOMMERCIAL = clsDonnee.vogDataReader["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementstockreglementcommercial.MC_NUMEROPIECE = double.Parse(clsDonnee.vogDataReader["MC_NUMEROPIECE"].ToString());
					clsPhamouvementstockreglementcommercial.MC_NUMSEQUENCE = double.Parse(clsDonnee.vogDataReader["MC_NUMSEQUENCE"].ToString());
					clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockreglementcommercials.Add(clsPhamouvementstockreglementcommercial);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockreglementcommercials;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementcommercial </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementcommercial> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockreglementcommercial> clsPhamouvementstockreglementcommercials = new List<clsPhamouvementstockreglementcommercial>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, NO_CODENATUREOPERATION, MS_NUMPIECE, MC_MONTANTDEBIT, MC_MONTANTCREDIT, MC_DATEPIECE, MC_ANNULATIONPIECE, MC_REFERENCEPIECE, MC_LIBELLEOPERATION, MC_NOMTIERS, CO_IDCOMMERCIAL, MC_NUMEROPIECE, MC_NUMSEQUENCE, OP_CODEOPERATEUR FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockreglementcommercial clsPhamouvementstockreglementcommercial = new clsPhamouvementstockreglementcommercial();
					clsPhamouvementstockreglementcommercial.MC_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MC_NUMPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockreglementcommercial.MR_CODEMODEREGLEMENT = Dataset.Tables["TABLE"].Rows[Idx]["MR_CODEMODEREGLEMENT"].ToString();
					clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockreglementcommercial.MS_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MS_NUMPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_MONTANTDEBIT"].ToString());
					clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_MONTANTCREDIT"].ToString());
					clsPhamouvementstockreglementcommercial.MC_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_DATEPIECE"].ToString());
					clsPhamouvementstockreglementcommercial.MC_ANNULATIONPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MC_ANNULATIONPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MC_REFERENCEPIECE"].ToString();
					clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["MC_LIBELLEOPERATION"].ToString();
					clsPhamouvementstockreglementcommercial.MC_NOMTIERS = Dataset.Tables["TABLE"].Rows[Idx]["MC_NOMTIERS"].ToString();
					clsPhamouvementstockreglementcommercial.CO_IDCOMMERCIAL = Dataset.Tables["TABLE"].Rows[Idx]["CO_IDCOMMERCIAL"].ToString();
					clsPhamouvementstockreglementcommercial.MC_NUMEROPIECE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_NUMEROPIECE"].ToString());
					clsPhamouvementstockreglementcommercial.MC_NUMSEQUENCE = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_NUMSEQUENCE"].ToString());
					clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsPhamouvementstockreglementcommercials.Add(clsPhamouvementstockreglementcommercial);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockreglementcommercials;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MC_NUMPIECE , NO_CODENATUREOPERATION FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTCOMMERCIAL(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}




        public string pvgSoldeGlobalReglement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT  dbo.FC_COMMISSIONCOMMERCIAL(@AG_CODEAGENCE,@EN_CODEENTREPOT,@CO_NUMCOMMERCIAL,@DATEJOURNEE,@CODECRYPTAGE) ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@CO_NUMCOMMERCIAL", "@DATEJOURNEE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], clsDonnee.vogCleCryptage };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }





		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, OP_CODEOPERATEUR)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MC_NUMPIECE=@MC_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MC_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MC_NUMPIECE=@MC_NUMPIECE  AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MC_NUMPIECE", "@OP_CODEOPERATEUR" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
			}
		}
	}
}
