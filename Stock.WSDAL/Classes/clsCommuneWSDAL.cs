using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsCommuneWSDAL : ITableDAL<clsCommune>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(CO_CODECOMMUNE) AS CO_CODECOMMUNE  FROM COMMUNE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(CO_CODECOMMUNE) AS CO_CODECOMMUNE  FROM COMMUNE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(CO_CODECOMMUNE) AS CO_CODECOMMUNE  FROM COMMUNE "+ this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsCommune">clsCommune</param>
		///<author>Home Technologie</author>
		public clsCommune pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT CO_LIBELLE,CO_DESCRIPTION FROM COMMUNE " + this.vapCritere ;
			this.vapCritere = "";

			clsCommune clsCommune = new clsCommune(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsCommune.CO_LIBELLE = clsDonnee.vogDataReader["CO_LIBELLE"].ToString();
					clsCommune.CO_DESCRIPTION = clsDonnee.vogDataReader["CO_DESCRIPTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCommune;
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsCommune">clsCommune</param>
        ///<author>Home Technologie</author>
        public clsCommune pvgTableLabelCommuneReference(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT CO_CODECOMMUNE, CO_LIBELLE,CO_DESCRIPTION FROM COMMUNE " + this.vapCritere;
            this.vapCritere = "";

            clsCommune clsCommune = new clsCommune();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsCommune.CO_LIBELLE = clsDonnee.vogDataReader["CO_LIBELLE"].ToString();
                    clsCommune.CO_DESCRIPTION = clsDonnee.vogDataReader["CO_DESCRIPTION"].ToString();
                    clsCommune.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();

                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsCommune;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCommune">clsCommune</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsCommune clsCommune)
		{
			//Préparation des paramètres

			SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
			vppParamCO_CODECOMMUNE.Value = clsCommune.CO_CODECOMMUNE;

			SqlParameter vppParamVL_CODEVILLE = new SqlParameter("@VL_CODEVILLE", SqlDbType.VarChar, 8);
			vppParamVL_CODEVILLE.Value = clsCommune.VL_CODEVILLE;

			SqlParameter vppParamCO_LIBELLE = new SqlParameter("@CO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamCO_LIBELLE.Value = clsCommune.CO_LIBELLE;

			SqlParameter vppParamCO_DESCRIPTION = new SqlParameter("@CO_DESCRIPTION", SqlDbType.VarChar, 500);
			vppParamCO_DESCRIPTION.Value = clsCommune.CO_DESCRIPTION;

            SqlParameter vppParamCO_REFERENCE = new SqlParameter("@CO_REFERENCE", SqlDbType.VarChar, 1);
            vppParamCO_REFERENCE.Value = clsCommune.CO_REFERENCE;


			//Préparation de la commande
			this.vapRequete = "INSERT INTO COMMUNE " +
            " (CO_CODECOMMUNE,VL_CODEVILLE,CO_LIBELLE,CO_DESCRIPTION,CO_REFERENCE)" +
            " VALUES(@CO_CODECOMMUNE,@VL_CODEVILLE,@CO_LIBELLE,@CO_DESCRIPTION,@CO_REFERENCE)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);
			vppSqlCmd.Parameters.Add(vppParamVL_CODEVILLE);
			vppSqlCmd.Parameters.Add(vppParamCO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCO_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamCO_REFERENCE);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCommune">clsCommune</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsCommune clsCommune, params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCO_LIBELLE = new SqlParameter("@CO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamCO_LIBELLE.Value = clsCommune.CO_LIBELLE;

			SqlParameter vppParamCO_DESCRIPTION = new SqlParameter("@CO_DESCRIPTION", SqlDbType.VarChar, 500);
			vppParamCO_DESCRIPTION.Value = clsCommune.CO_DESCRIPTION;
            SqlParameter vppParamCO_REFERENCE = new SqlParameter("@CO_REFERENCE", SqlDbType.VarChar, 1);
            vppParamCO_REFERENCE.Value = clsCommune.CO_REFERENCE;

			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE COMMUNE SET " + 
			" CO_LIBELLE = @CO_LIBELLE , " + 
			" CO_DESCRIPTION = @CO_DESCRIPTION ,"+
            " CO_REFERENCE = @CO_REFERENCE" + this.vapCritere;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamCO_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamCO_REFERENCE);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:CO_CODECOMMUNE,VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCommune">clsCommune</param>
        ///<param name="vppCritere">Les critères de modification</param>
        ///<author>Home Technologie</author>
        public void pvgUpdate1(clsDonnee clsDonnee, clsCommune clsCommune, params string[] vppCritere)
        {
            //Préparation des paramètres
            //SqlParameter vppParamCO_LIBELLE = new SqlParameter("@CO_LIBELLE", SqlDbType.VarChar, 150);
            //vppParamCO_LIBELLE.Value = clsCommune.CO_LIBELLE;

            //SqlParameter vppParamCO_DESCRIPTION = new SqlParameter("@CO_DESCRIPTION", SqlDbType.VarChar, 500);
            //vppParamCO_DESCRIPTION.Value = clsCommune.CO_DESCRIPTION;
            SqlParameter vppParamCO_REFERENCE = new SqlParameter("@CO_REFERENCE", SqlDbType.VarChar, 1);
            vppParamCO_REFERENCE.Value = clsCommune.CO_REFERENCE;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE COMMUNE SET " +
            " CO_REFERENCE = @CO_REFERENCE" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            //vppSqlCmd.Parameters.Add(vppParamCO_LIBELLE);
            //vppSqlCmd.Parameters.Add(vppParamCO_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamCO_REFERENCE);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM COMMUNE " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsCommune </returns>
		///<author>Home Technologie</author>
		public List<clsCommune> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCommune> clsCommunes = new List<clsCommune>();

			pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM COMMUNE " +this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsCommune clsCommune = new clsCommune();
					clsCommune.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();
					clsCommune.VL_CODEVILLE = clsDonnee.vogDataReader["VL_CODEVILLE"].ToString();
					clsCommune.CO_LIBELLE = clsDonnee.vogDataReader["CO_LIBELLE"].ToString();
					clsCommune.CO_DESCRIPTION = clsDonnee.vogDataReader["CO_DESCRIPTION"].ToString();
					clsCommunes.Add(clsCommune);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCommunes;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsCommune </returns>
		///<author>Home Technologie</author>
		public List<clsCommune> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCommune> clsCommunes = new List<clsCommune>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM COMMUNE "+ this.vapCritere ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCommune clsCommune = new clsCommune();
					clsCommune.CO_CODECOMMUNE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMMUNE"].ToString();
					clsCommune.VL_CODEVILLE = Dataset.Tables["TABLE"].Rows[Idx]["VL_CODEVILLE"].ToString();
					clsCommune.CO_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["CO_LIBELLE"].ToString();
					clsCommune.CO_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["CO_DESCRIPTION"].ToString();
					clsCommunes.Add(clsCommune);
				}
				Dataset.Dispose();
			}
			return clsCommunes;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT * FROM COMMUNE " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}





        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT CO_CODECOMMUNE,CO_LIBELLE FROM COMMUNE " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourComboSelonZoneCommercial(clsDonnee clsDonnee ,params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@VL_CODEVILLE", "@ZN_CODEZONE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC [dbo].[PS_COMBOCOMMUNESELONZONE] @VL_CODEVILLE,@ZN_CODEZONE,	@CODECRYPTAGE ";
	        this.vapCritere = ""; 
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
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
                    this.vapCritere = " WHERE VL_CODEVILLE=@VL_CODEVILLE ";
                    vapNomParametre = new string[] { "@VL_CODEVILLE" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
				case 2:
                    this.vapCritere = " WHERE VL_CODEVILLE=@VL_CODEVILLE AND  CO_CODECOMMUNE=@CO_CODECOMMUNE ";
                    vapNomParametre = new string[] { "@VL_CODEVILLE", "@CO_CODECOMMUNE" };
					vapValeurParametre = new object[]{ vppCritere[0], vppCritere[1] };
					break ;				
			}
		}




        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : CO_CODECOMMUNE,VL_CODEVILLE)</summary>
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
                    this.vapCritere = " WHERE VL_CODEVILLE=@VL_CODEVILLE ";
                    vapNomParametre = new string[] { "@VL_CODEVILLE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE VL_CODEVILLE=@VL_CODEVILLE AND  CO_REFERENCE=@CO_REFERENCE ";
                    vapNomParametre = new string[] { "@VL_CODEVILLE", "@CO_REFERENCE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }


        }
}