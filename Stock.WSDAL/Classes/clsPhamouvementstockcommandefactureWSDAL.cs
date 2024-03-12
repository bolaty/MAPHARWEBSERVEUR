using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockcommandefactureWSDAL: ITableDAL<clsPhamouvementstockcommandefacture>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(MC_NUMPIECE) AS MC_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKCOMMANDEFACTURE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(MC_NUMPIECE) AS MC_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKCOMMANDEFACTURE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(MC_NUMPIECE) AS MC_NUMPIECE  FROM dbo.PHAMOUVEMENTSTOCKCOMMANDEFACTURE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMaxNumeroPiece(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere1(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(MC_NUMEROPIECE) AS MC_NUMEROPIECE   FROM dbo.PHAMOUVEMENTSTOCKCOMMANDEFACTURE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockcommandefacture comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockcommandefacture pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , MR_CODEMODEREGLEMENT  , NO_CODENATUREOPERATION  , MK_NUMPIECE  , MC_MONTANTDEBIT  , MC_MONTANTCREDIT  , MC_DATEPIECE  , MC_ANNULATIONPIECE  , MC_REFERENCEPIECE  , MC_LIBELLEOPERATION  , MC_NOMTIERS  FROM dbo.FT_PHAMOUVEMENTSTOCKCOMMANDEFACTURE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockcommandefacture clsPhamouvementstockcommandefacture = new clsPhamouvementstockcommandefacture();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockcommandefacture.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockcommandefacture.MR_CODEMODEREGLEMENT = clsDonnee.vogDataReader["MR_CODEMODEREGLEMENT"].ToString();
					clsPhamouvementstockcommandefacture.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockcommandefacture.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["MC_MONTANTDEBIT"].ToString());
					clsPhamouvementstockcommandefacture.MC_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["MC_MONTANTCREDIT"].ToString());
					clsPhamouvementstockcommandefacture.MC_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MC_DATEPIECE"].ToString());
					clsPhamouvementstockcommandefacture.MC_ANNULATIONPIECE = clsDonnee.vogDataReader["MC_ANNULATIONPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_REFERENCEPIECE = clsDonnee.vogDataReader["MC_REFERENCEPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_LIBELLEOPERATION = clsDonnee.vogDataReader["MC_LIBELLEOPERATION"].ToString();
					clsPhamouvementstockcommandefacture.MC_NOMTIERS = clsDonnee.vogDataReader["MC_NOMTIERS"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockcommandefacture;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockcommandefacture>clsPhamouvementstockcommandefacture</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockcommandefacture clsPhamouvementstockcommandefacture)
		{
			//Préparation des paramètres
            SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 25);
			vppParamMC_NUMPIECE.Value  = clsPhamouvementstockcommandefacture.MC_NUMPIECE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstockcommandefacture.AG_CODEAGENCE ;
			SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
			vppParamMR_CODEMODEREGLEMENT.Value  = clsPhamouvementstockcommandefacture.MR_CODEMODEREGLEMENT ;
			if(clsPhamouvementstockcommandefacture.MR_CODEMODEREGLEMENT== ""  ) vppParamMR_CODEMODEREGLEMENT.Value  = DBNull.Value;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 2);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhamouvementstockcommandefacture.NO_CODENATUREOPERATION ;
			SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMK_NUMPIECE.Value  = clsPhamouvementstockcommandefacture.MK_NUMPIECE ;
			SqlParameter vppParamMC_MONTANTDEBIT = new SqlParameter("@MC_MONTANTDEBIT", SqlDbType.Money);
			vppParamMC_MONTANTDEBIT.Value  = clsPhamouvementstockcommandefacture.MC_MONTANTDEBIT ;
            //if(clsPhamouvementstockcommandefacture.MC_MONTANTDEBIT== 0  ) vppParamMC_MONTANTDEBIT.Value  = DBNull.Value;
			SqlParameter vppParamMC_MONTANTCREDIT = new SqlParameter("@MC_MONTANTCREDIT", SqlDbType.Money);
			vppParamMC_MONTANTCREDIT.Value  = clsPhamouvementstockcommandefacture.MC_MONTANTCREDIT ;
            //if(clsPhamouvementstockcommandefacture.MC_MONTANTCREDIT== 0  ) vppParamMC_MONTANTCREDIT.Value  = DBNull.Value;
			SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
			vppParamMC_DATEPIECE.Value  = clsPhamouvementstockcommandefacture.MC_DATEPIECE ;
			SqlParameter vppParamMC_ANNULATIONPIECE = new SqlParameter("@MC_ANNULATIONPIECE", SqlDbType.VarChar, 1);
			vppParamMC_ANNULATIONPIECE.Value  = clsPhamouvementstockcommandefacture.MC_ANNULATIONPIECE ;
			SqlParameter vppParamMC_REFERENCEPIECE = new SqlParameter("@MC_REFERENCEPIECE", SqlDbType.VarChar, 1000);
			vppParamMC_REFERENCEPIECE.Value  = clsPhamouvementstockcommandefacture.MC_REFERENCEPIECE ;
			if(clsPhamouvementstockcommandefacture.MC_REFERENCEPIECE== ""  ) vppParamMC_REFERENCEPIECE.Value  = DBNull.Value;
			SqlParameter vppParamMC_LIBELLEOPERATION = new SqlParameter("@MC_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
			vppParamMC_LIBELLEOPERATION.Value  = clsPhamouvementstockcommandefacture.MC_LIBELLEOPERATION ;
			if(clsPhamouvementstockcommandefacture.MC_LIBELLEOPERATION== ""  ) vppParamMC_LIBELLEOPERATION.Value  = DBNull.Value;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockcommandefacture.TYPEOPERATION;

			SqlParameter vppParamMC_NOMTIERS = new SqlParameter("@MC_NOMTIERS", SqlDbType.VarChar, 1000);
			vppParamMC_NOMTIERS.Value  = clsPhamouvementstockcommandefacture.MC_NOMTIERS ;
            SqlParameter vppParamMC_NUMEROPIECE = new SqlParameter("@MC_NUMEROPIECE ", SqlDbType.VarChar, 50);
            vppParamMC_NUMEROPIECE.Value = clsPhamouvementstockcommandefacture.MC_NUMEROPIECE;

			if(clsPhamouvementstockcommandefacture.MC_NOMTIERS== ""  ) vppParamMC_NOMTIERS.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKCOMMANDEFACTURE  @MC_NUMPIECE, @AG_CODEAGENCE, @MR_CODEMODEREGLEMENT, @NO_CODENATUREOPERATION, @MK_NUMPIECE, @MC_MONTANTDEBIT, @MC_MONTANTCREDIT, @MC_DATEPIECE, @MC_ANNULATIONPIECE, @MC_REFERENCEPIECE, @MC_LIBELLEOPERATION, @MC_NOMTIERS,@MC_NUMEROPIECE , @CODECRYPTAGE, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamMC_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_REFERENCEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_LIBELLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

			vppSqlCmd.Parameters.Add(vppParamMC_NOMTIERS);
            vppSqlCmd.Parameters.Add(vppParamMC_NUMEROPIECE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockcommandefacture>clsPhamouvementstockcommandefacture</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockcommandefacture clsPhamouvementstockcommandefacture,params string[] vppCritere)
		{
			//Préparation des paramètres
            SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 25);
			vppParamMC_NUMPIECE.Value  = clsPhamouvementstockcommandefacture.MC_NUMPIECE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsPhamouvementstockcommandefacture.AG_CODEAGENCE ;
			SqlParameter vppParamMR_CODEMODEREGLEMENT = new SqlParameter("@MR_CODEMODEREGLEMENT", SqlDbType.VarChar, 2);
			vppParamMR_CODEMODEREGLEMENT.Value  = clsPhamouvementstockcommandefacture.MR_CODEMODEREGLEMENT ;
			if(clsPhamouvementstockcommandefacture.MR_CODEMODEREGLEMENT== ""  ) vppParamMR_CODEMODEREGLEMENT.Value  = DBNull.Value;
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 2);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhamouvementstockcommandefacture.NO_CODENATUREOPERATION ;
			SqlParameter vppParamMK_NUMPIECE = new SqlParameter("@MK_NUMPIECE", SqlDbType.VarChar, 50);
			vppParamMK_NUMPIECE.Value  = clsPhamouvementstockcommandefacture.MK_NUMPIECE ;
			SqlParameter vppParamMC_MONTANTDEBIT = new SqlParameter("@MC_MONTANTDEBIT", SqlDbType.Money);
			vppParamMC_MONTANTDEBIT.Value  = clsPhamouvementstockcommandefacture.MC_MONTANTDEBIT ;
			if(clsPhamouvementstockcommandefacture.MC_MONTANTDEBIT== 0  ) vppParamMC_MONTANTDEBIT.Value  = DBNull.Value;
			SqlParameter vppParamMC_MONTANTCREDIT = new SqlParameter("@MC_MONTANTCREDIT", SqlDbType.Money);
			vppParamMC_MONTANTCREDIT.Value  = clsPhamouvementstockcommandefacture.MC_MONTANTCREDIT ;
			if(clsPhamouvementstockcommandefacture.MC_MONTANTCREDIT==0  ) vppParamMC_MONTANTCREDIT.Value  = DBNull.Value;
			SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
			vppParamMC_DATEPIECE.Value  = clsPhamouvementstockcommandefacture.MC_DATEPIECE ;
			SqlParameter vppParamMC_ANNULATIONPIECE = new SqlParameter("@MC_ANNULATIONPIECE", SqlDbType.VarChar, 1);
			vppParamMC_ANNULATIONPIECE.Value  = clsPhamouvementstockcommandefacture.MC_ANNULATIONPIECE ;
			SqlParameter vppParamMC_REFERENCEPIECE = new SqlParameter("@MC_REFERENCEPIECE", SqlDbType.VarChar, 1000);
			vppParamMC_REFERENCEPIECE.Value  = clsPhamouvementstockcommandefacture.MC_REFERENCEPIECE ;
			if(clsPhamouvementstockcommandefacture.MC_REFERENCEPIECE== ""  ) vppParamMC_REFERENCEPIECE.Value  = DBNull.Value;
			SqlParameter vppParamMC_LIBELLEOPERATION = new SqlParameter("@MC_LIBELLEOPERATION", SqlDbType.VarChar, 1000);
			vppParamMC_LIBELLEOPERATION.Value  = clsPhamouvementstockcommandefacture.MC_LIBELLEOPERATION ;
			if(clsPhamouvementstockcommandefacture.MC_LIBELLEOPERATION== ""  ) vppParamMC_LIBELLEOPERATION.Value  = DBNull.Value;
			SqlParameter vppParamMC_NOMTIERS = new SqlParameter("@MC_NOMTIERS", SqlDbType.VarChar, 1000);
			vppParamMC_NOMTIERS.Value  = clsPhamouvementstockcommandefacture.MC_NOMTIERS ;
			if(clsPhamouvementstockcommandefacture.MC_NOMTIERS== ""  ) vppParamMC_NOMTIERS.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKCOMMANDEFACTURE  @MC_NUMPIECE, @AG_CODEAGENCE, @MR_CODEMODEREGLEMENT, @NO_CODENATUREOPERATION, @MK_NUMPIECE, @MC_MONTANTDEBIT, @MC_MONTANTCREDIT, @MC_DATEPIECE, @MC_ANNULATIONPIECE, @MC_REFERENCEPIECE, @MC_LIBELLEOPERATION, @MC_NOMTIERS, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMR_CODEMODEREGLEMENT);
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMK_NUMPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_MONTANTDEBIT);
			vppSqlCmd.Parameters.Add(vppParamMC_MONTANTCREDIT);
			vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_ANNULATIONPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_REFERENCEPIECE);
			vppSqlCmd.Parameters.Add(vppParamMC_LIBELLEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamMC_NOMTIERS);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKCOMMANDEFACTURE  @MC_NUMPIECE, @AG_CODEAGENCE , '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockcommandefacture </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockcommandefacture> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, NO_CODENATUREOPERATION, MK_NUMPIECE, MC_MONTANTDEBIT, MC_MONTANTCREDIT, MC_DATEPIECE, MC_ANNULATIONPIECE, MC_REFERENCEPIECE, MC_LIBELLEOPERATION, MC_NOMTIERS FROM dbo.FT_PHAMOUVEMENTSTOCKCOMMANDEFACTURE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockcommandefacture> clsPhamouvementstockcommandefactures = new List<clsPhamouvementstockcommandefacture>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockcommandefacture clsPhamouvementstockcommandefacture = new clsPhamouvementstockcommandefacture();
					clsPhamouvementstockcommandefacture.MC_NUMPIECE = clsDonnee.vogDataReader["MC_NUMPIECE"].ToString();
					clsPhamouvementstockcommandefacture.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockcommandefacture.MR_CODEMODEREGLEMENT = clsDonnee.vogDataReader["MR_CODEMODEREGLEMENT"].ToString();
					clsPhamouvementstockcommandefacture.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockcommandefacture.MK_NUMPIECE = clsDonnee.vogDataReader["MK_NUMPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_MONTANTDEBIT = double.Parse(clsDonnee.vogDataReader["MC_MONTANTDEBIT"].ToString());
					clsPhamouvementstockcommandefacture.MC_MONTANTCREDIT = double.Parse(clsDonnee.vogDataReader["MC_MONTANTCREDIT"].ToString());
					clsPhamouvementstockcommandefacture.MC_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MC_DATEPIECE"].ToString());
					clsPhamouvementstockcommandefacture.MC_ANNULATIONPIECE = clsDonnee.vogDataReader["MC_ANNULATIONPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_REFERENCEPIECE = clsDonnee.vogDataReader["MC_REFERENCEPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_LIBELLEOPERATION = clsDonnee.vogDataReader["MC_LIBELLEOPERATION"].ToString();
					clsPhamouvementstockcommandefacture.MC_NOMTIERS = clsDonnee.vogDataReader["MC_NOMTIERS"].ToString();
					clsPhamouvementstockcommandefactures.Add(clsPhamouvementstockcommandefacture);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockcommandefactures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockcommandefacture </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockcommandefacture> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockcommandefacture> clsPhamouvementstockcommandefactures = new List<clsPhamouvementstockcommandefacture>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT  MC_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, NO_CODENATUREOPERATION, MK_NUMPIECE, MC_MONTANTDEBIT, MC_MONTANTCREDIT, MC_DATEPIECE, MC_ANNULATIONPIECE, MC_REFERENCEPIECE, MC_LIBELLEOPERATION, MC_NOMTIERS FROM dbo.FT_PHAMOUVEMENTSTOCKCOMMANDEFACTURE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockcommandefacture clsPhamouvementstockcommandefacture = new clsPhamouvementstockcommandefacture();
					clsPhamouvementstockcommandefacture.MC_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MC_NUMPIECE"].ToString();
					clsPhamouvementstockcommandefacture.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsPhamouvementstockcommandefacture.MR_CODEMODEREGLEMENT = Dataset.Tables["TABLE"].Rows[Idx]["MR_CODEMODEREGLEMENT"].ToString();
					clsPhamouvementstockcommandefacture.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockcommandefacture.MK_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MK_NUMPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_MONTANTDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_MONTANTDEBIT"].ToString());
					clsPhamouvementstockcommandefacture.MC_MONTANTCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_MONTANTCREDIT"].ToString());
					clsPhamouvementstockcommandefacture.MC_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_DATEPIECE"].ToString());
					clsPhamouvementstockcommandefacture.MC_ANNULATIONPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MC_ANNULATIONPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_REFERENCEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MC_REFERENCEPIECE"].ToString();
					clsPhamouvementstockcommandefacture.MC_LIBELLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["MC_LIBELLEOPERATION"].ToString();
					clsPhamouvementstockcommandefacture.MC_NOMTIERS = Dataset.Tables["TABLE"].Rows[Idx]["MC_NOMTIERS"].ToString();
					clsPhamouvementstockcommandefactures.Add(clsPhamouvementstockcommandefacture);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockcommandefactures;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKCOMMANDEFACTURE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MC_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MC_NUMPIECE , AG_CODEAGENCE FROM dbo.FT_PHAMOUVEMENTSTOCKCOMMANDEFACTURE(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MC_NUMPIECE)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND MC_NUMPIECE=@MC_NUMPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MC_NUMPIECE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MC_NUMPIECE)</summary>
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
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE " ;
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;

                case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MC_DATEPIECE=@MC_DATEPIECE";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@MC_DATEPIECE" };
                vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
                break;

			}
		}


	}
}
