using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsAgenceWSDAL : ITableDAL<clsAgence>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM AGENCE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM AGENCE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM AGENCE "+ this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsAgence">clsAgence</param>
		///<author>Home Technologie</author>
		public clsAgence pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
            switch (vppCritere.Length)
            {
                case 1:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND AG_ACTIF='O'";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
            }

			this.vapRequete = "SELECT AG_AGENCECODE,VL_CODEVILLE,AG_RAISONSOCIAL,AG_BOITEPOSTAL,AG_ADRESSEGEOGRAPHIQUE,AG_TELEPHONE,AG_FAX,AG_EMAIL,AG_NUMEROAGREMENT,AG_REFERENCE,AG_DATECREATION,AG_ACTIF,OP_CODEOPERATEUR FROM AGENCE " + this.vapCritere ;
            this.vapCritere = "";

			clsAgence clsAgence = new clsAgence(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsAgence.AG_AGENCECODE = clsDonnee.vogDataReader["AG_AGENCECODE"].ToString();
					clsAgence.VL_CODEVILLE = clsDonnee.vogDataReader["VL_CODEVILLE"].ToString();
					clsAgence.AG_RAISONSOCIAL = clsDonnee.vogDataReader["AG_RAISONSOCIAL"].ToString();
					clsAgence.AG_BOITEPOSTAL = clsDonnee.vogDataReader["AG_BOITEPOSTAL"].ToString();
					clsAgence.AG_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["AG_ADRESSEGEOGRAPHIQUE"].ToString();
					clsAgence.AG_TELEPHONE = clsDonnee.vogDataReader["AG_TELEPHONE"].ToString();
					clsAgence.AG_FAX = clsDonnee.vogDataReader["AG_FAX"].ToString();
					clsAgence.AG_EMAIL = clsDonnee.vogDataReader["AG_EMAIL"].ToString();
					clsAgence.AG_NUMEROAGREMENT = clsDonnee.vogDataReader["AG_NUMEROAGREMENT"].ToString();
					clsAgence.AG_REFERENCE = clsDonnee.vogDataReader["AG_REFERENCE"].ToString();
					clsAgence.AG_DATECREATION = DateTime.Parse(clsDonnee.vogDataReader["AG_DATECREATION"].ToString());
					clsAgence.AG_ACTIF = clsDonnee.vogDataReader["AG_ACTIF"].ToString();
					clsAgence.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsAgence;
		}


        /// <summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:AG_AGENCECODE)</summary>
        /// <param name="vppCritere">critères de la requète</param>
        /// <returns>Un BusinessObject comme valeur de retour de la fonction</returns></param>
        /// <author>Home Technologie</author>
        public clsAgence pvgTableLabelAG_AGENCECODE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  AG_AGENCECODE=@AG_AGENCECODE  AND AG_ACTIF='O'";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_AGENCECODE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
            this.vapRequete = "SELECT AG_AGENCECODE,AG_RAISONSOCIAL FROM AGENCE " + this.vapCritere;
            this.vapCritere = "";

            clsAgence clsAgence = new clsAgence();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsAgence.AG_AGENCECODE = clsDonnee.vogDataReader["AG_AGENCECODE"].ToString();
                    clsAgence.AG_RAISONSOCIAL = clsDonnee.vogDataReader["AG_RAISONSOCIAL"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsAgence;
        }

        /// <summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:AG_AGENCECODE)</summary>
        /// <param name="vppCritere">critères de la requète</param>
        /// <returns>Un BusinessObject comme valeur de retour de la fonction</returns></param>
        /// <author>Home Technologie</author>
        public clsAgence pvgTableLabelAG_RAISONSOCIAL(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  AG_RAISONSOCIAL=@AG_RAISONSOCIAL  AND AG_ACTIF='O'";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_RAISONSOCIAL" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
            this.vapRequete = "SELECT AG_RAISONSOCIAL FROM AGENCE " + this.vapCritere;
            this.vapCritere = "";

            clsAgence clsAgence = new clsAgence();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsAgence.AG_RAISONSOCIAL = clsDonnee.vogDataReader["AG_RAISONSOCIAL"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsAgence;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsAgence">clsAgence</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsAgence clsAgence)
		{
			//Préparation des paramètres

			SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
			vppParamSO_CODESOCIETE.Value = clsAgence.SO_CODESOCIETE;

			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value = clsAgence.AG_CODEAGENCE;

			SqlParameter vppParamAG_AGENCECODE = new SqlParameter("@AG_AGENCECODE", SqlDbType.VarChar, 4);
			vppParamAG_AGENCECODE.Value = clsAgence.AG_AGENCECODE;

			SqlParameter vppParamVL_CODEVILLE = new SqlParameter("@VL_CODEVILLE", SqlDbType.VarChar, 8);
			vppParamVL_CODEVILLE.Value = clsAgence.VL_CODEVILLE;

			SqlParameter vppParamAG_RAISONSOCIAL = new SqlParameter("@AG_RAISONSOCIAL", SqlDbType.VarChar, 150);
			vppParamAG_RAISONSOCIAL.Value = clsAgence.AG_RAISONSOCIAL;

			SqlParameter vppParamAG_BOITEPOSTAL = new SqlParameter("@AG_BOITEPOSTAL", SqlDbType.VarChar, 50);
			vppParamAG_BOITEPOSTAL.Value = clsAgence.AG_BOITEPOSTAL;

			SqlParameter vppParamAG_ADRESSEGEOGRAPHIQUE2 = new SqlParameter("@AG_ADRESSEGEOGRAPHIQUE2", SqlDbType.VarChar, 150);
			vppParamAG_ADRESSEGEOGRAPHIQUE2.Value = clsAgence.AG_ADRESSEGEOGRAPHIQUE2;

            SqlParameter vppParamAG_ADRESSEGEOGRAPHIQUE3 = new SqlParameter("@AG_ADRESSEGEOGRAPHIQUE3", SqlDbType.VarChar, 150);
            vppParamAG_ADRESSEGEOGRAPHIQUE3.Value = clsAgence.AG_ADRESSEGEOGRAPHIQUE3;

            SqlParameter vppParamAG_ADRESSEGEOGRAPHIQUE = new SqlParameter("@AG_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamAG_ADRESSEGEOGRAPHIQUE.Value = clsAgence.AG_ADRESSEGEOGRAPHIQUE;

			SqlParameter vppParamAG_TELEPHONE = new SqlParameter("@AG_TELEPHONE", SqlDbType.VarChar, 80);
			vppParamAG_TELEPHONE.Value = clsAgence.AG_TELEPHONE;

			SqlParameter vppParamAG_FAX = new SqlParameter("@AG_FAX", SqlDbType.VarChar, 80);
			vppParamAG_FAX.Value = clsAgence.AG_FAX;

			SqlParameter vppParamAG_EMAIL = new SqlParameter("@AG_EMAIL", SqlDbType.VarChar, 150);
			vppParamAG_EMAIL.Value = clsAgence.AG_EMAIL;

			SqlParameter vppParamAG_NUMEROAGREMENT = new SqlParameter("@AG_NUMEROAGREMENT", SqlDbType.VarChar, 150);
			vppParamAG_NUMEROAGREMENT.Value = clsAgence.AG_NUMEROAGREMENT;

			SqlParameter vppParamAG_REFERENCE = new SqlParameter("@AG_REFERENCE", SqlDbType.VarChar, 1);
			vppParamAG_REFERENCE.Value = clsAgence.AG_REFERENCE;

			SqlParameter vppParamAG_DATECREATION = new SqlParameter("@AG_DATECREATION", SqlDbType.DateTime);
			vppParamAG_DATECREATION.Value = clsAgence.AG_DATECREATION;

			SqlParameter vppParamAG_ACTIF = new SqlParameter("@AG_ACTIF", SqlDbType.VarChar, 1);
			vppParamAG_ACTIF.Value = clsAgence.AG_ACTIF;

			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value = clsAgence.OP_CODEOPERATEUR;
            if (clsAgence.OP_CODEOPERATEUR == "") vppParamOP_CODEOPERATEUR.Value = DBNull.Value;

            SqlParameter vppParamAG_NUMCPTECONTIBUABLE = new SqlParameter("@AG_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 150);
            vppParamAG_NUMCPTECONTIBUABLE.Value = clsAgence.AG_NUMCPTECONTIBUABLE;
            if (clsAgence.AG_NUMCPTECONTIBUABLE == "") vppParamAG_NUMCPTECONTIBUABLE.Value = DBNull.Value;

            SqlParameter vppParamRE_CODEREGIMEIMPOSITION = new SqlParameter("@RE_CODEREGIMEIMPOSITION", SqlDbType.VarChar, 150);
            vppParamRE_CODEREGIMEIMPOSITION.Value = clsAgence.RE_CODEREGIMEIMPOSITION;
            if (clsAgence.RE_CODEREGIMEIMPOSITION == "") vppParamRE_CODEREGIMEIMPOSITION.Value = DBNull.Value;

            SqlParameter vppParamAG_CENTREIMPOT = new SqlParameter("@AG_CENTREIMPOT", SqlDbType.VarChar, 150);
            vppParamAG_CENTREIMPOT.Value = clsAgence.AG_CENTREIMPOT;
            if (clsAgence.AG_CENTREIMPOT == "") vppParamAG_CENTREIMPOT.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            //this.vapRequete = "INSERT INTO AGENCE " +
            //" (SO_CODESOCIETE,AG_CODEAGENCE,AG_AGENCECODE,VL_CODEVILLE,AG_RAISONSOCIAL,AG_BOITEPOSTAL,AG_ADRESSEGEOGRAPHIQUE,AG_ADRESSEGEOGRAPHIQUE2,AG_ADRESSEGEOGRAPHIQUE3,AG_TELEPHONE,AG_FAX,AG_EMAIL,AG_NUMEROAGREMENT,AG_REFERENCE,AG_DATECREATION,AG_ACTIF,OP_CODEOPERATEUR)" + 
            //" VALUES(@SO_CODESOCIETE,@AG_CODEAGENCE,@AG_AGENCECODE,@VL_CODEVILLE,@AG_RAISONSOCIAL,@AG_BOITEPOSTAL,@AG_ADRESSEGEOGRAPHIQUE,@AG_ADRESSEGEOGRAPHIQUE2,@AG_ADRESSEGEOGRAPHIQUE3,@AG_TELEPHONE,@AG_FAX,@AG_EMAIL,@AG_NUMEROAGREMENT,@AG_REFERENCE,@AG_DATECREATION,@AG_ACTIF,@OP_CODEOPERATEUR)";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);


            //Préparation de la commande
            this.vapRequete = " EXECUTE [dbo].[PC_AGENCE] @SO_CODESOCIETE,@AG_CODEAGENCE,@AG_AGENCECODE,@VL_CODEVILLE,@AG_RAISONSOCIAL, @AG_BOITEPOSTAL, @AG_ADRESSEGEOGRAPHIQUE,@AG_ADRESSEGEOGRAPHIQUE2 ,@AG_ADRESSEGEOGRAPHIQUE3, @AG_TELEPHONE,@AG_FAX,@AG_EMAIL ,@AG_NUMEROAGREMENT,@AG_REFERENCE ,@AG_DATECREATION,@AG_ACTIF , @OP_CODEOPERATEUR,@AG_NUMCPTECONTIBUABLE,@RE_CODEREGIMEIMPOSITION,@AG_CENTREIMPOT, @CODECRYPTAGE,0";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);


			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAG_AGENCECODE);
			vppSqlCmd.Parameters.Add(vppParamVL_CODEVILLE);
			vppSqlCmd.Parameters.Add(vppParamAG_RAISONSOCIAL);
			vppSqlCmd.Parameters.Add(vppParamAG_BOITEPOSTAL);
			vppSqlCmd.Parameters.Add(vppParamAG_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamAG_ADRESSEGEOGRAPHIQUE2);
            vppSqlCmd.Parameters.Add(vppParamAG_ADRESSEGEOGRAPHIQUE3);
			vppSqlCmd.Parameters.Add(vppParamAG_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamAG_FAX);
			vppSqlCmd.Parameters.Add(vppParamAG_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamAG_NUMEROAGREMENT);
			vppSqlCmd.Parameters.Add(vppParamAG_REFERENCE);
			vppSqlCmd.Parameters.Add(vppParamAG_DATECREATION);
			vppSqlCmd.Parameters.Add(vppParamAG_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_NUMCPTECONTIBUABLE);
            vppSqlCmd.Parameters.Add(vppParamRE_CODEREGIMEIMPOSITION);
            vppSqlCmd.Parameters.Add(vppParamAG_CENTREIMPOT);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);


			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsAgence">clsAgence</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsAgence clsAgence, params string[] vppCritere)
		{
			//Préparation des paramètres


            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
            vppParamSO_CODESOCIETE.Value = clsAgence.SO_CODESOCIETE;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsAgence.AG_CODEAGENCE;

			SqlParameter vppParamAG_AGENCECODE = new SqlParameter("@AG_AGENCECODE", SqlDbType.VarChar, 4);
			vppParamAG_AGENCECODE.Value = clsAgence.AG_AGENCECODE;

			SqlParameter vppParamVL_CODEVILLE = new SqlParameter("@VL_CODEVILLE", SqlDbType.VarChar, 8);
			vppParamVL_CODEVILLE.Value = clsAgence.VL_CODEVILLE;

			SqlParameter vppParamAG_RAISONSOCIAL = new SqlParameter("@AG_RAISONSOCIAL", SqlDbType.VarChar, 150);
			vppParamAG_RAISONSOCIAL.Value = clsAgence.AG_RAISONSOCIAL;

			SqlParameter vppParamAG_BOITEPOSTAL = new SqlParameter("@AG_BOITEPOSTAL", SqlDbType.VarChar, 50);
			vppParamAG_BOITEPOSTAL.Value = clsAgence.AG_BOITEPOSTAL;

			SqlParameter vppParamAG_ADRESSEGEOGRAPHIQUE = new SqlParameter("@AG_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
			vppParamAG_ADRESSEGEOGRAPHIQUE.Value = clsAgence.AG_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamAG_ADRESSEGEOGRAPHIQUE2 = new SqlParameter("@AG_ADRESSEGEOGRAPHIQUE2", SqlDbType.VarChar, 150);
            vppParamAG_ADRESSEGEOGRAPHIQUE2.Value = clsAgence.AG_ADRESSEGEOGRAPHIQUE2;

            SqlParameter vppParamAG_ADRESSEGEOGRAPHIQUE3 = new SqlParameter("@AG_ADRESSEGEOGRAPHIQUE3", SqlDbType.VarChar, 150);
            vppParamAG_ADRESSEGEOGRAPHIQUE3.Value = clsAgence.AG_ADRESSEGEOGRAPHIQUE3;

			SqlParameter vppParamAG_TELEPHONE = new SqlParameter("@AG_TELEPHONE", SqlDbType.VarChar, 80);
			vppParamAG_TELEPHONE.Value = clsAgence.AG_TELEPHONE;

			SqlParameter vppParamAG_FAX = new SqlParameter("@AG_FAX", SqlDbType.VarChar, 80);
			vppParamAG_FAX.Value = clsAgence.AG_FAX;

			SqlParameter vppParamAG_EMAIL = new SqlParameter("@AG_EMAIL", SqlDbType.VarChar, 150);
			vppParamAG_EMAIL.Value = clsAgence.AG_EMAIL;

			SqlParameter vppParamAG_NUMEROAGREMENT = new SqlParameter("@AG_NUMEROAGREMENT", SqlDbType.VarChar, 150);
			vppParamAG_NUMEROAGREMENT.Value = clsAgence.AG_NUMEROAGREMENT;


            SqlParameter vppParamAG_REFERENCE = new SqlParameter("@AG_REFERENCE", SqlDbType.VarChar, 1);
            vppParamAG_REFERENCE.Value = clsAgence.AG_REFERENCE;

			SqlParameter vppParamAG_DATECREATION = new SqlParameter("@AG_DATECREATION", SqlDbType.DateTime);
			vppParamAG_DATECREATION.Value = clsAgence.AG_DATECREATION;


            SqlParameter vppParamAG_ACTIF = new SqlParameter("@AG_ACTIF", SqlDbType.VarChar, 1);
            vppParamAG_ACTIF.Value = clsAgence.AG_ACTIF;


			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value = clsAgence.OP_CODEOPERATEUR;
            if (clsAgence.OP_CODEOPERATEUR == "") vppParamOP_CODEOPERATEUR.Value = DBNull.Value;

            SqlParameter vppParamAG_NUMCPTECONTIBUABLE = new SqlParameter("@AG_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 150);
            vppParamAG_NUMCPTECONTIBUABLE.Value = clsAgence.AG_NUMCPTECONTIBUABLE;
            if (clsAgence.AG_NUMCPTECONTIBUABLE == "") vppParamAG_NUMCPTECONTIBUABLE.Value = DBNull.Value;


            SqlParameter vppParamRE_CODEREGIMEIMPOSITION = new SqlParameter("@RE_CODEREGIMEIMPOSITION", SqlDbType.VarChar, 150);
            vppParamRE_CODEREGIMEIMPOSITION.Value = clsAgence.RE_CODEREGIMEIMPOSITION;
            if (clsAgence.RE_CODEREGIMEIMPOSITION == "") vppParamRE_CODEREGIMEIMPOSITION.Value = DBNull.Value;

            SqlParameter vppParamAG_CENTREIMPOT = new SqlParameter("@AG_CENTREIMPOT", SqlDbType.VarChar, 150);
            vppParamAG_CENTREIMPOT.Value = clsAgence.AG_CENTREIMPOT;
            if (clsAgence.AG_CENTREIMPOT == "") vppParamAG_CENTREIMPOT.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;


            //pvpChoixCritere3(vppCritere); 

            ////Préparation de la commande
            //this.vapRequete = "UPDATE AGENCE SET " + 
            //" AG_AGENCECODE = @AG_AGENCECODE , " + 
            //" VL_CODEVILLE = @VL_CODEVILLE , " + 
            //" AG_RAISONSOCIAL = @AG_RAISONSOCIAL , " + 
            //" AG_BOITEPOSTAL = @AG_BOITEPOSTAL , " + 
            //" AG_ADRESSEGEOGRAPHIQUE = @AG_ADRESSEGEOGRAPHIQUE , " + 
            //" AG_ADRESSEGEOGRAPHIQUE2 = @AG_ADRESSEGEOGRAPHIQUE2 , " + 
            //" AG_ADRESSEGEOGRAPHIQUE3 = @AG_ADRESSEGEOGRAPHIQUE3 , " + 
            //" AG_TELEPHONE = @AG_TELEPHONE , " + 
            //" AG_FAX = @AG_FAX , " + 
            //" AG_EMAIL = @AG_EMAIL , " + 
            //" AG_NUMEROAGREMENT = @AG_NUMEROAGREMENT , " + 
            //" AG_DATECREATION = @AG_DATECREATION , " + 
            //" OP_CODEOPERATEUR = @OP_CODEOPERATEUR" + this.vapCritere ;

            //this.vapCritere = "";

            //Préparation de la commande
            this.vapRequete = " EXECUTE [dbo].[PC_AGENCE] @SO_CODESOCIETE,@AG_CODEAGENCE,@AG_AGENCECODE,@VL_CODEVILLE,@AG_RAISONSOCIAL, @AG_BOITEPOSTAL, @AG_ADRESSEGEOGRAPHIQUE,@AG_ADRESSEGEOGRAPHIQUE2 ,@AG_ADRESSEGEOGRAPHIQUE3, @AG_TELEPHONE,@AG_FAX,@AG_EMAIL ,@AG_NUMEROAGREMENT,@AG_REFERENCE ,@AG_DATECREATION,@AG_ACTIF , @OP_CODEOPERATEUR,@AG_NUMCPTECONTIBUABLE,@RE_CODEREGIMEIMPOSITION,@AG_CENTREIMPOT,@CODECRYPTAGE,1";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande

            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamAG_AGENCECODE);
			vppSqlCmd.Parameters.Add(vppParamVL_CODEVILLE);
			vppSqlCmd.Parameters.Add(vppParamAG_RAISONSOCIAL);
			vppSqlCmd.Parameters.Add(vppParamAG_BOITEPOSTAL);
			vppSqlCmd.Parameters.Add(vppParamAG_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamAG_ADRESSEGEOGRAPHIQUE2);
            vppSqlCmd.Parameters.Add(vppParamAG_ADRESSEGEOGRAPHIQUE3);
			vppSqlCmd.Parameters.Add(vppParamAG_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamAG_FAX);
			vppSqlCmd.Parameters.Add(vppParamAG_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamAG_NUMEROAGREMENT);
            vppSqlCmd.Parameters.Add(vppParamAG_REFERENCE);
			vppSqlCmd.Parameters.Add(vppParamAG_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamAG_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_NUMCPTECONTIBUABLE);
            vppSqlCmd.Parameters.Add(vppParamRE_CODEREGIMEIMPOSITION);
            vppSqlCmd.Parameters.Add(vppParamAG_CENTREIMPOT);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM AGENCE " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsAgence </returns>
		///<author>Home Technologie</author>
		public List<clsAgence> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsAgence> clsAgences = new List<clsAgence>();

			pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM VUE_AGENCE " + this.vapCritere + " AND AG_ACTIF='O'";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsAgence clsAgence = new clsAgence();
					clsAgence.SO_CODESOCIETE = clsDonnee.vogDataReader["SO_CODESOCIETE"].ToString();
					clsAgence.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsAgence.AG_AGENCECODE = clsDonnee.vogDataReader["AG_AGENCECODE"].ToString();
					clsAgence.VL_CODEVILLE = clsDonnee.vogDataReader["VL_CODEVILLE"].ToString();
                    clsAgence.ZN_CODEZONE = clsDonnee.vogDataReader["ZN_CODEZONE"].ToString();
					clsAgence.AG_RAISONSOCIAL = clsDonnee.vogDataReader["AG_RAISONSOCIAL"].ToString();
					clsAgence.AG_BOITEPOSTAL = clsDonnee.vogDataReader["AG_BOITEPOSTAL"].ToString();
					clsAgence.AG_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["AG_ADRESSEGEOGRAPHIQUE"].ToString();
					clsAgence.AG_TELEPHONE = clsDonnee.vogDataReader["AG_TELEPHONE"].ToString();
					clsAgence.AG_FAX = clsDonnee.vogDataReader["AG_FAX"].ToString();
					clsAgence.AG_EMAIL = clsDonnee.vogDataReader["AG_EMAIL"].ToString();
					clsAgence.AG_NUMEROAGREMENT = clsDonnee.vogDataReader["AG_NUMEROAGREMENT"].ToString();
					clsAgence.AG_REFERENCE = clsDonnee.vogDataReader["AG_REFERENCE"].ToString();
					clsAgence.AG_DATECREATION =DateTime.Parse(clsDonnee.vogDataReader["AG_DATECREATION"].ToString());
					clsAgence.AG_ACTIF = clsDonnee.vogDataReader["AG_ACTIF"].ToString();
					clsAgence.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsAgences.Add(clsAgence);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsAgences;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsAgence </returns>
		///<author>Home Technologie</author>
		public List<clsAgence> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsAgence> clsAgences = new List<clsAgence>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM AGENCE " + this.vapCritere + " AND AG_ACTIF='O'";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsAgence clsAgence = new clsAgence();
					clsAgence.SO_CODESOCIETE = Dataset.Tables["TABLE"].Rows[Idx]["SO_CODESOCIETE"].ToString();
					clsAgence.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsAgence.AG_AGENCECODE = Dataset.Tables["TABLE"].Rows[Idx]["AG_AGENCECODE"].ToString();
					clsAgence.VL_CODEVILLE = Dataset.Tables["TABLE"].Rows[Idx]["VL_CODEVILLE"].ToString();
                    //clsAgence.ZN_CODEZONE = Dataset.Tables["TABLE"].Rows[Idx]["ZN_CODEZONE"].ToString();
					clsAgence.AG_RAISONSOCIAL = Dataset.Tables["TABLE"].Rows[Idx]["AG_RAISONSOCIAL"].ToString();
					clsAgence.AG_BOITEPOSTAL = Dataset.Tables["TABLE"].Rows[Idx]["AG_BOITEPOSTAL"].ToString();
					clsAgence.AG_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["AG_ADRESSEGEOGRAPHIQUE"].ToString();
					clsAgence.AG_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["AG_TELEPHONE"].ToString();
					clsAgence.AG_FAX = Dataset.Tables["TABLE"].Rows[Idx]["AG_FAX"].ToString();
					clsAgence.AG_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["AG_EMAIL"].ToString();
					clsAgence.AG_NUMEROAGREMENT = Dataset.Tables["TABLE"].Rows[Idx]["AG_NUMEROAGREMENT"].ToString();
					clsAgence.AG_REFERENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_REFERENCE"].ToString();
					clsAgence.AG_DATECREATION =DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AG_DATECREATION"].ToString());
					clsAgence.AG_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["AG_ACTIF"].ToString();
					clsAgence.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsAgences.Add(clsAgence);
				}
				Dataset.Dispose();
			}
			return clsAgences;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_AGENCE " + this.vapCritere + " AND AG_ACTIF='O' ORDER BY AG_RAISONSOCIAL";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

		public DataSet pvgChargerDansDataSetExclusion(clsDonnee clsDonnee ,params string[] vppCritere)
		{
            pvpChoixCritereExclusion(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_AGENCE " + this.vapCritere + " AND AG_ACTIF='O' ORDER BY AG_RAISONSOCIAL";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_AGENCE " + this.vapCritere + " AND AG_ACTIF='O' ORDER BY AG_RAISONSOCIAL";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
            if (vppCritere.Length <= 2)
            {
                pvpChoixCritere(vppCritere);
                this.vapRequete = "SELECT AG_CODEAGENCE,AG_RAISONSOCIAL FROM AGENCE " + this.vapCritere + " AND AG_ACTIF='O' ORDER BY AG_RAISONSOCIAL";
            }
            else//Lorsque le critère possède l'exercice,il faut passer par la vue
            {
                pvpChoixCritere2(vppCritere);
                this.vapRequete = "SELECT AG_CODEAGENCE,AG_RAISONSOCIAL FROM VUE_AGENCE " + this.vapCritere + " AND AG_ACTIF='O' ORDER BY AG_RAISONSOCIAL";
            }
            //
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo1(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere2(vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE,AG_RAISONSOCIAL FROM AGENCE " + this.vapCritere + " AND AG_ACTIF='O' ORDER BY AG_RAISONSOCIAL";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : AC_CODEACTIVITE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetAgence(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
            this.vapRequete = "SELECT CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',AG_EMAIL) AS varchar(150)) AS AG_EMAIL,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',AG_EMAILMOTDEPASSE) AS varchar(150)) AS AG_EMAILMOTDEPASSE FROM AGENCE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			{
				case 0:
					this.vapCritere ="" ;
					vapNomParametre = new string[]{  };
					vapValeurParametre = new object[]{  };
					break ;				
				case 1:
					this.vapCritere =" WHERE SO_CODESOCIETE=@SO_CODESOCIETE "; 
					vapNomParametre = new string[]{ "@SO_CODESOCIETE" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
				case 2:
                        this.vapCritere = " WHERE SO_CODESOCIETE LIKE '%'+ @SO_CODESOCIETE + '%' AND  AG_CODEAGENCE=@AG_CODEAGENCE ";
                        vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_CODEAGENCE" };
                        vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  AG_CODEAGENCE=@AG_CODEAGENCE  AND  EX_EXERCICE=@EX_EXERCICE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_CODEAGENCE", "@EX_EXERCICE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;	
			}
		}

        public void pvpChoixCritereExclusion(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  CAST(AG_CODEAGENCE as varchar(5))<>@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  CAST(AG_CODEAGENCE as varchar(5))<>@AG_CODEAGENCE  AND  EX_EXERCICE=@EX_EXERCICE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_CODEAGENCE", "@EX_EXERCICE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere2(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  EX_EXERCICE=@EX_EXERCICE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@EX_EXERCICE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  EX_EXERCICE=@EX_EXERCICE AND ZN_CODEZONE=@ZN_CODEZONE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@EX_EXERCICE", "@ZN_CODEZONE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,AG_CODEAGENCE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere3(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  AG_CODEAGENCE=@AG_CODEAGENCE  AND  EX_EXERCICE=@EX_EXERCICE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_CODEAGENCE", "@EX_EXERCICE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }

        }
}