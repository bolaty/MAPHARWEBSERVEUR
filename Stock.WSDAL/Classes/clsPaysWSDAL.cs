using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsPaysWSDAL : ITableDAL<clsPays>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PY_CODEPAYS) AS PY_CODEPAYS  FROM PAYS " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PY_CODEPAYS) AS PY_CODEPAYS  FROM PAYS " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PY_CODEPAYS) AS PY_CODEPAYS  FROM PAYS "+ this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsPays">clsPays</param>
		///<author>Home Technologie</author>
		public clsPays pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT PY_CODEPOSTALE,DE_CODEDEVISE,ZT_CODEZONE,PY_LIBELLE,PY_LIBELLENATIONALITE,PY_REFERENCE FROM VUE_PAYS " + this.vapCritere;
			this.vapCritere = "";

			clsPays clsPays = new clsPays(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsPays.PY_CODEPOSTALE = clsDonnee.vogDataReader["PY_CODEPOSTALE"].ToString();
					clsPays.DE_CODEDEVISE = clsDonnee.vogDataReader["DE_CODEDEVISE"].ToString();
					clsPays.ZT_CODEZONE = clsDonnee.vogDataReader["ZT_CODEZONE"].ToString();
					clsPays.PY_LIBELLE = clsDonnee.vogDataReader["PY_LIBELLE"].ToString();
					clsPays.PY_LIBELLENATIONALITE = clsDonnee.vogDataReader["PY_LIBELLENATIONALITE"].ToString();
					clsPays.PY_REFERENCE = clsDonnee.vogDataReader["PY_REFERENCE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPays;
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : PY_CODEPAYS)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsPays">clsPays</param>
        ///<author>Home Technologie</author>
        public clsPays pvgTableLabelPaysReference(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT PY_CODEPAYS,PY_CODEPOSTALE,DE_CODEDEVISE,PY_LIBELLE,PY_LIBELLENATIONALITE,PY_REFERENCE FROM VUE_PAYS " + this.vapCritere + " AND  PY_REFERENCE='O' ";
            this.vapCritere = "";

            clsPays clsPays = new clsPays();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPays.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
                    clsPays.PY_CODEPOSTALE = clsDonnee.vogDataReader["PY_CODEPOSTALE"].ToString();
                    clsPays.DE_CODEDEVISE = clsDonnee.vogDataReader["DE_CODEDEVISE"].ToString();
                   
                    clsPays.PY_LIBELLE = clsDonnee.vogDataReader["PY_LIBELLE"].ToString();
                    clsPays.PY_LIBELLENATIONALITE = clsDonnee.vogDataReader["PY_LIBELLENATIONALITE"].ToString();
                    clsPays.PY_REFERENCE = clsDonnee.vogDataReader["PY_REFERENCE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPays;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPays">clsPays</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsPays clsPays)
		{
			//Préparation des paramètres

			SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 4);
			vppParamPY_CODEPAYS.Value = clsPays.PY_CODEPAYS;

			SqlParameter vppParamPY_CODEPOSTALE = new SqlParameter("@PY_CODEPOSTALE", SqlDbType.VarChar, 5);
			vppParamPY_CODEPOSTALE.Value = clsPays.PY_CODEPOSTALE;

			SqlParameter vppParamDE_CODEDEVISE = new SqlParameter("@DE_CODEDEVISE", SqlDbType.VarChar, 4);
			vppParamDE_CODEDEVISE.Value = clsPays.DE_CODEDEVISE;

			SqlParameter vppParamZT_CODEZONE = new SqlParameter("@ZT_CODEZONE", SqlDbType.VarChar, 7);
			vppParamZT_CODEZONE.Value = clsPays.ZT_CODEZONE;

			SqlParameter vppParamPY_LIBELLE = new SqlParameter("@PY_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPY_LIBELLE.Value = clsPays.PY_LIBELLE;

			SqlParameter vppParamPY_LIBELLENATIONALITE = new SqlParameter("@PY_LIBELLENATIONALITE", SqlDbType.VarChar, 150);
			vppParamPY_LIBELLENATIONALITE.Value = clsPays.PY_LIBELLENATIONALITE;

			SqlParameter vppParamPY_REFERENCE = new SqlParameter("@PY_REFERENCE", SqlDbType.VarChar, 1);
			vppParamPY_REFERENCE.Value = clsPays.PY_REFERENCE;

			//Préparation de la commande
			this.vapRequete = "INSERT INTO PAYS " +
			" (PY_CODEPAYS,PY_CODEPOSTALE,DE_CODEDEVISE,ZT_CODEZONE,PY_LIBELLE,PY_LIBELLENATIONALITE,PY_REFERENCE)" + 
			" VALUES(@PY_CODEPAYS,@PY_CODEPOSTALE,@DE_CODEDEVISE,@ZT_CODEZONE,@PY_LIBELLE,@PY_LIBELLENATIONALITE,@PY_REFERENCE)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
			vppSqlCmd.Parameters.Add(vppParamPY_CODEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamDE_CODEDEVISE);
			vppSqlCmd.Parameters.Add(vppParamZT_CODEZONE);
			vppSqlCmd.Parameters.Add(vppParamPY_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPY_LIBELLENATIONALITE);
			vppSqlCmd.Parameters.Add(vppParamPY_REFERENCE);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPays">clsPays</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsPays clsPays, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamPY_CODEPOSTALE = new SqlParameter("@PY_CODEPOSTALE", SqlDbType.VarChar, 5);
			vppParamPY_CODEPOSTALE.Value = clsPays.PY_CODEPOSTALE;

			SqlParameter vppParamDE_CODEDEVISE = new SqlParameter("@DE_CODEDEVISE", SqlDbType.VarChar, 4);
			vppParamDE_CODEDEVISE.Value = clsPays.DE_CODEDEVISE;

			SqlParameter vppParamZT_CODEZONE = new SqlParameter("@ZT_CODEZONE", SqlDbType.VarChar, 7);
			vppParamZT_CODEZONE.Value = clsPays.ZT_CODEZONE;

			SqlParameter vppParamPY_LIBELLE = new SqlParameter("@PY_LIBELLE", SqlDbType.VarChar, 150);
			vppParamPY_LIBELLE.Value = clsPays.PY_LIBELLE;

			SqlParameter vppParamPY_LIBELLENATIONALITE = new SqlParameter("@PY_LIBELLENATIONALITE", SqlDbType.VarChar, 150);
			vppParamPY_LIBELLENATIONALITE.Value = clsPays.PY_LIBELLENATIONALITE;

			SqlParameter vppParamPY_REFERENCE = new SqlParameter("@PY_REFERENCE", SqlDbType.VarChar, 1);
			vppParamPY_REFERENCE.Value = clsPays.PY_REFERENCE;

			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE PAYS SET " + 
			" PY_CODEPOSTALE = @PY_CODEPOSTALE , " + 
			" DE_CODEDEVISE = @DE_CODEDEVISE , " + 
			" ZT_CODEZONE = @ZT_CODEZONE , " + 
			" PY_LIBELLE = @PY_LIBELLE , " + 
			" PY_LIBELLENATIONALITE = @PY_LIBELLENATIONALITE , " + 
			" PY_REFERENCE = @PY_REFERENCE" + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPY_CODEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamDE_CODEDEVISE);
			vppSqlCmd.Parameters.Add(vppParamZT_CODEZONE);
			vppSqlCmd.Parameters.Add(vppParamPY_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamPY_LIBELLENATIONALITE);
			vppSqlCmd.Parameters.Add(vppParamPY_REFERENCE);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:PY_CODEPAYS)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPays">clsPays</param>
        ///<param name="vppCritere">Les critères de modification</param>
        ///<author>Home Technologie</author>
        public void pvgUpdatePaysReference(clsDonnee clsDonnee, clsPays clsPays, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamPY_REFERENCE = new SqlParameter("@PY_REFERENCE", SqlDbType.VarChar, 1);
            vppParamPY_REFERENCE.Value = clsPays.PY_REFERENCE;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE PAYS SET " +
            " PY_REFERENCE = @PY_REFERENCE" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamPY_REFERENCE);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "DELETE FROM SOCIETEPAYS " + this.vapCritere;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsPays </returns>
		///<author>Home Technologie</author>
		public List<clsPays> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPays> clsPayss = new List<clsPays>();

			pvpChoixCritere1(vppCritere);

            this.vapRequete = "SELECT * FROM VUE_PAYS " + this.vapCritere + " AND   SP_ACTIF='O'";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsPays clsPays = new clsPays();
					clsPays.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
					clsPays.PY_CODEPOSTALE = clsDonnee.vogDataReader["PY_CODEPOSTALE"].ToString();
					clsPays.DE_CODEDEVISE = clsDonnee.vogDataReader["DE_CODEDEVISE"].ToString();
					clsPays.ZT_CODEZONE = clsDonnee.vogDataReader["ZT_CODEZONE"].ToString();
					clsPays.PY_LIBELLE = clsDonnee.vogDataReader["PY_LIBELLE"].ToString();
					clsPays.PY_LIBELLENATIONALITE = clsDonnee.vogDataReader["PY_LIBELLENATIONALITE"].ToString();
					clsPays.PY_REFERENCE = clsDonnee.vogDataReader["PY_REFERENCE"].ToString();
					clsPayss.Add(clsPays);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPayss;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsPays </returns>
		///<author>Home Technologie</author>
		public List<clsPays> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPays> clsPayss = new List<clsPays>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere1(vppCritere);

            this.vapRequete = "SELECT * FROM VUE_PAYS " + this.vapCritere + " AND   SP_ACTIF='O'";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPays clsPays = new clsPays();
					clsPays.PY_CODEPAYS = Dataset.Tables["TABLE"].Rows[Idx]["PY_CODEPAYS"].ToString();
					clsPays.PY_CODEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["PY_CODEPOSTALE"].ToString();
					clsPays.DE_CODEDEVISE = Dataset.Tables["TABLE"].Rows[Idx]["DE_CODEDEVISE"].ToString();
					clsPays.ZT_CODEZONE = Dataset.Tables["TABLE"].Rows[Idx]["ZT_CODEZONE"].ToString();
					clsPays.PY_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PY_LIBELLE"].ToString();
					clsPays.PY_LIBELLENATIONALITE = Dataset.Tables["TABLE"].Rows[Idx]["PY_LIBELLENATIONALITE"].ToString();
					clsPays.PY_REFERENCE = Dataset.Tables["TABLE"].Rows[Idx]["PY_REFERENCE"].ToString();
					clsPayss.Add(clsPays);
				}
				Dataset.Dispose();
			}
			return clsPayss;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_PAYS " + this.vapCritere + " AND   SP_ACTIF='O'";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPays(clsDonnee clsDonnee ,params string[] vppCritere)
        {
	        pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM PAYS " + this.vapCritere + " ";
	        this.vapCritere = ""; 
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT PY_CODEPAYS,PY_LIBELLE,PY_CODEPOSTALE,PY_REFERENCE FROM VUE_PAYS " + this.vapCritere + "    SP_ACTIF='O' ORDER BY PY_LIBELLE ";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : PY_CODEPAYS)</summary>
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
					this.vapCritere =" WHERE PY_CODEPAYS=@PY_CODEPAYS "; 
					vapNomParametre = new string[]{ "@PY_CODEPAYS" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "WHERE";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PY_CODEPAYS=@PY_CODEPAYS ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PY_CODEPAYS" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }


        }
}