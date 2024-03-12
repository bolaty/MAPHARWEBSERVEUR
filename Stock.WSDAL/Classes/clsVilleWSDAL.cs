using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsVilleWSDAL : ITableDAL<clsVille>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(VL_CODEVILLE) AS VL_CODEVILLE  FROM VILLE " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(VL_CODEVILLE) AS VL_CODEVILLE  FROM VILLE " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(VL_CODEVILLE) AS VL_CODEVILLE  FROM VILLE "+ this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsVille">clsVille</param>
		///<author>Home Technologie</author>
		public clsVille pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT ZN_CODEZONE,VL_LIBELLE,VL_DESCRIPTION FROM VUE_VILLE " + this.vapCritere;
			this.vapCritere = "";

			clsVille clsVille = new clsVille(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsVille.ZN_CODEZONE = clsDonnee.vogDataReader["ZN_CODEZONE"].ToString();
					clsVille.VL_LIBELLE = clsDonnee.vogDataReader["VL_LIBELLE"].ToString();
					clsVille.VL_DESCRIPTION = clsDonnee.vogDataReader["VL_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsVille;
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsVille">clsVille</param>
        ///<author>Home Technologie</author>
        public clsVille pvgTableLabelVilleReference(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere4(vppCritere);
            this.vapRequete = "SELECT VL_CODEVILLE,VL_LIBELLE,VL_DESCRIPTION FROM VUE_VILLE " + this.vapCritere;
            this.vapCritere = "";

            clsVille clsVille = new clsVille();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsVille.VL_CODEVILLE = clsDonnee.vogDataReader["VL_CODEVILLE"].ToString();
                    clsVille.VL_LIBELLE = clsDonnee.vogDataReader["VL_LIBELLE"].ToString();
                    clsVille.VL_DESCRIPTION = clsDonnee.vogDataReader["VL_DESCRIPTION"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsVille;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsVille">clsVille</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsVille clsVille)
		{
			//Préparation des paramètres

			SqlParameter vppParamVL_CODEVILLE = new SqlParameter("@VL_CODEVILLE", SqlDbType.VarChar, 8);
			vppParamVL_CODEVILLE.Value = clsVille.VL_CODEVILLE;

			SqlParameter vppParamZN_CODEZONE = new SqlParameter("@ZN_CODEZONE", SqlDbType.VarChar, 7);
			vppParamZN_CODEZONE.Value = clsVille.ZN_CODEZONE;

			SqlParameter vppParamVL_LIBELLE = new SqlParameter("@VL_LIBELLE", SqlDbType.VarChar, 150);
			vppParamVL_LIBELLE.Value = clsVille.VL_LIBELLE;

			SqlParameter vppParamVL_DESCRIPTION = new SqlParameter("@VL_DESCRIPTION", SqlDbType.VarChar, 500);
			vppParamVL_DESCRIPTION.Value = clsVille.VL_DESCRIPTION;

			//Préparation de la commande
			this.vapRequete = "INSERT INTO VILLE " +
			" (VL_CODEVILLE,ZN_CODEZONE,VL_LIBELLE,VL_DESCRIPTION)" + 
			" VALUES(@VL_CODEVILLE,@ZN_CODEZONE,@VL_LIBELLE,@VL_DESCRIPTION)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamVL_CODEVILLE);
			vppSqlCmd.Parameters.Add(vppParamZN_CODEZONE);
			vppSqlCmd.Parameters.Add(vppParamVL_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamVL_DESCRIPTION);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsVille">clsVille</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsVille clsVille, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamZN_CODEZONE = new SqlParameter("@ZN_CODEZONE", SqlDbType.VarChar, 7);
			vppParamZN_CODEZONE.Value = clsVille.ZN_CODEZONE;

			SqlParameter vppParamVL_LIBELLE = new SqlParameter("@VL_LIBELLE", SqlDbType.VarChar, 150);
			vppParamVL_LIBELLE.Value = clsVille.VL_LIBELLE;

			SqlParameter vppParamVL_DESCRIPTION = new SqlParameter("@VL_DESCRIPTION", SqlDbType.VarChar, 500);
			vppParamVL_DESCRIPTION.Value = clsVille.VL_DESCRIPTION;

			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE VILLE SET " + 
			" ZN_CODEZONE = @ZN_CODEZONE , " + 
			" VL_LIBELLE = @VL_LIBELLE , " + 
			" VL_DESCRIPTION = @VL_DESCRIPTION" + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamZN_CODEZONE);
			vppSqlCmd.Parameters.Add(vppParamVL_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamVL_DESCRIPTION);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}



        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsVille">clsVille</param>
        ///<param name="vppCritere">Les critères de modification</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateVilleReference(clsDonnee clsDonnee, clsVille clsVille, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamVL_REFERENCE = new SqlParameter("@VL_REFERENCE", SqlDbType.VarChar, 1);
            vppParamVL_REFERENCE.Value = clsVille.VL_REFERENCE;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE VILLE SET " +

        " VL_REFERENCE = @VL_REFERENCE" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande

            vppSqlCmd.Parameters.Add(vppParamVL_REFERENCE);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsVille">clsVille</param>
        ///<param name="vppCritere">Les critères de modification</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateVilleReference1(clsDonnee clsDonnee, clsVille clsVille, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamVL_REFERENCE = new SqlParameter("@VL_REFERENCE", SqlDbType.VarChar, 1);
            vppParamVL_REFERENCE.Value = clsVille.VL_REFERENCE;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE VILLE SET " +

        " VL_REFERENCE = 'N'" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande

            vppSqlCmd.Parameters.Add(vppParamVL_REFERENCE);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
            pvpChoixCritere2(vppCritere);
            this.vapRequete = "DELETE FROM SOCIETEVILLE " + this.vapCritere;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsVille </returns>
		///<author>Home Technologie</author>
		public List<clsVille> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsVille> clsVilles = new List<clsVille>();

			pvpChoixCritere1(vppCritere);

            this.vapRequete = "SELECT * FROM VUE_VILLE " + this.vapCritere + " AND SV_ACTIF ='O' " + " ORDER BY PY_LIBELLE,VL_LIBELLE";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsVille clsVille = new clsVille();
					clsVille.VL_CODEVILLE = clsDonnee.vogDataReader["VL_CODEVILLE"].ToString();
					clsVille.ZN_CODEZONE = clsDonnee.vogDataReader["ZN_CODEZONE"].ToString();
					clsVille.VL_LIBELLE = clsDonnee.vogDataReader["VL_LIBELLE"].ToString();
					clsVille.VL_DESCRIPTION = clsDonnee.vogDataReader["VL_DESCRIPTION"].ToString();
					clsVilles.Add(clsVille);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsVilles;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsVille </returns>
		///<author>Home Technologie</author>
		public List<clsVille> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsVille> clsVilles = new List<clsVille>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_VILLE " + this.vapCritere + " AND SV_ACTIF ='O' " + " ORDER BY PY_LIBELLE,VL_LIBELLE";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsVille clsVille = new clsVille();
					clsVille.VL_CODEVILLE = Dataset.Tables["TABLE"].Rows[Idx]["VL_CODEVILLE"].ToString();
					clsVille.ZN_CODEZONE = Dataset.Tables["TABLE"].Rows[Idx]["ZN_CODEZONE"].ToString();
					clsVille.VL_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["VL_LIBELLE"].ToString();
					clsVille.VL_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["VL_DESCRIPTION"].ToString();
					clsVilles.Add(clsVille);
				}
				Dataset.Dispose();
			}
			return clsVilles;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_VILLE " + this.vapCritere + " AND SV_ACTIF ='O' " + " ORDER BY PY_LIBELLE,VL_LIBELLE";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPaysVille(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_VILLE " + this.vapCritere + " AND SV_ACTIF ='O' " + " ORDER BY PY_LIBELLE,VL_LIBELLE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT VL_CODEVILLE,VL_LIBELLE,VL_REFERENCE FROM VUE_VILLE " + this.vapCritere + "  SV_ACTIF ='O' " + " ORDER BY PY_LIBELLE,VL_LIBELLE";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourComboSelonZone(clsDonnee clsDonnee ,params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@PY_CODEPAYS", "@ZN_CODEZONE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0],vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC [dbo].[PS_COMBOVILLESELONZONE] @PY_CODEPAYS,@ZN_CODEZONE,	@CODECRYPTAGE";
	        this.vapCritere = ""; 
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			{
				case 0:
                    this.vapCritere = "";
					vapNomParametre = new string[]{  };
					vapValeurParametre = new object[]{  };
					break ;				
				case 1:
                    this.vapCritere = " WHERE VL_CODEVILLE=@VL_CODEVILLE  "; 
					vapNomParametre = new string[]{ "@VL_CODEVILLE" };
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
                    this.vapCritere = " WHERE PY_CODEPAYS=@PY_CODEPAYS AND";
                    vapNomParametre = new string[] { "@PY_CODEPAYS" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PY_CODEPAYS=@PY_CODEPAYS AND ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PY_CODEPAYS" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PY_CODEPAYS=@PY_CODEPAYS  AND  VL_CODEVILLE=@VL_CODEVILLE AND";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PY_CODEPAYS", "@VL_CODEVILLE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] , vppCritere[2] };
                    break;


            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
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
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  VL_CODEVILLE=@VL_CODEVILLE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@VL_CODEVILLE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere3(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "WHERE";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE PY_CODEPAYS like '%'+@PY_CODEPAYS+'%'  ";
                    vapNomParametre = new string[] { "@PY_CODEPAYS" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE PY_CODEPAYS like '%'+@PY_CODEPAYS+'%' AND VL_LIBELLE  like '%'+@VL_LIBELLE+'%'  ";
                    vapNomParametre = new string[] { "@PY_CODEPAYS", "@VL_LIBELLE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PY_CODEPAYS=@PY_CODEPAYS  AND  VL_CODEVILLE=@VL_CODEVILLE AND";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PY_CODEPAYS", "@VL_CODEVILLE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;


            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : VL_CODEVILLE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere4(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "WHERE";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;

                case 1:
                    this.vapCritere = " WHERE  PY_CODEPAYS=@PY_CODEPAYS  AND VL_REFERENCE='O'   ";
                    vapNomParametre = new string[] { "@PY_CODEPAYS" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PY_CODEPAYS=@PY_CODEPAYS  AND  VL_CODEVILLE=@VL_CODEVILLE AND";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PY_CODEPAYS", "@VL_CODEVILLE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;


            }
        }

    }
}