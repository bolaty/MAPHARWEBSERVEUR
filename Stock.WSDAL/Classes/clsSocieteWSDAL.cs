using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsSocieteWSDAL : ITableDAL<clsSociete>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(SO_CODESOCIETE) AS SO_CODESOCIETE  FROM SOCIETE " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(SO_CODESOCIETE) AS SO_CODESOCIETE  FROM SOCIETE " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(SO_CODESOCIETE) AS SO_CODESOCIETE  FROM SOCIETE "+ this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsSociete">clsSociete</param>
		///<author>Home Technologie</author>
		public clsSociete pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT SO_CODESOCIETE,SO_RAISONSOCIAL,SO_BOITEPOSTAL,SO_TELEPHONE,SO_DIRECTEUR,SO_EMAIL,SO_SITEWEB,SO_ACTIF FROM SOCIETE " + this.vapCritere + " AND SO_ACTIF='O'";
			this.vapCritere = "";

			clsSociete clsSociete = new clsSociete(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
                    clsSociete.SO_CODESOCIETE = clsDonnee.vogDataReader["SO_CODESOCIETE"].ToString();
					clsSociete.SO_RAISONSOCIAL = clsDonnee.vogDataReader["SO_RAISONSOCIAL"].ToString();
					clsSociete.SO_BOITEPOSTAL = clsDonnee.vogDataReader["SO_BOITEPOSTAL"].ToString();
					clsSociete.SO_TELEPHONE = clsDonnee.vogDataReader["SO_TELEPHONE"].ToString();
					clsSociete.SO_DIRECTEUR = clsDonnee.vogDataReader["SO_DIRECTEUR"].ToString();
					clsSociete.SO_EMAIL = clsDonnee.vogDataReader["SO_EMAIL"].ToString();
					clsSociete.SO_SITEWEB = clsDonnee.vogDataReader["SO_SITEWEB"].ToString();
					clsSociete.SO_ACTIF = clsDonnee.vogDataReader["SO_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSociete;
		}

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsSociete">clsSociete</param>
        ///<author>Home Technologie</author>
        public clsSociete pvgTableLabelDATESYSTEMSERVEUR(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT GETDATE() AS DATESYSTEMSERVEUR";
            this.vapCritere = "";

            clsSociete clsSociete = new clsSociete();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsSociete.DATESYSTEMSERVEUR = DateTime.Parse(clsDonnee.vogDataReader["DATESYSTEMSERVEUR"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsSociete;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSociete">clsSociete</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsSociete clsSociete)
		{
			//Préparation des paramètres

			SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
			vppParamSO_CODESOCIETE.Value = clsSociete.SO_CODESOCIETE;

			SqlParameter vppParamSO_RAISONSOCIAL = new SqlParameter("@SO_RAISONSOCIAL", SqlDbType.VarChar, 150);
			vppParamSO_RAISONSOCIAL.Value = clsSociete.SO_RAISONSOCIAL;

			SqlParameter vppParamSO_BOITEPOSTAL = new SqlParameter("@SO_BOITEPOSTAL", SqlDbType.VarChar, 50);
			vppParamSO_BOITEPOSTAL.Value = clsSociete.SO_BOITEPOSTAL;

			SqlParameter vppParamSO_TELEPHONE = new SqlParameter("@SO_TELEPHONE", SqlDbType.VarChar, 80);
			vppParamSO_TELEPHONE.Value = clsSociete.SO_TELEPHONE;

			SqlParameter vppParamSO_DIRECTEUR = new SqlParameter("@SO_DIRECTEUR", SqlDbType.VarChar, 150);
			vppParamSO_DIRECTEUR.Value = clsSociete.SO_DIRECTEUR;

			SqlParameter vppParamSO_EMAIL = new SqlParameter("@SO_EMAIL", SqlDbType.VarChar, 150);
			vppParamSO_EMAIL.Value = clsSociete.SO_EMAIL;

			SqlParameter vppParamSO_SITEWEB = new SqlParameter("@SO_SITEWEB", SqlDbType.VarChar, 150);
			vppParamSO_SITEWEB.Value = clsSociete.SO_SITEWEB;

			SqlParameter vppParamSO_ACTIF = new SqlParameter("@SO_ACTIF", SqlDbType.VarChar, 1);
			vppParamSO_ACTIF.Value = clsSociete.SO_ACTIF;

			//Préparation de la commande
			this.vapRequete = "INSERT INTO SOCIETE " +
			" (SO_CODESOCIETE,SO_RAISONSOCIAL,SO_BOITEPOSTAL,SO_TELEPHONE,SO_DIRECTEUR,SO_EMAIL,SO_SITEWEB,SO_ACTIF)" + 
			" VALUES(@SO_CODESOCIETE,@SO_RAISONSOCIAL,@SO_BOITEPOSTAL,@SO_TELEPHONE,@SO_DIRECTEUR,@SO_EMAIL,@SO_SITEWEB,@SO_ACTIF)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
			vppSqlCmd.Parameters.Add(vppParamSO_RAISONSOCIAL);
			vppSqlCmd.Parameters.Add(vppParamSO_BOITEPOSTAL);
			vppSqlCmd.Parameters.Add(vppParamSO_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamSO_DIRECTEUR);
			vppSqlCmd.Parameters.Add(vppParamSO_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamSO_SITEWEB);
			vppSqlCmd.Parameters.Add(vppParamSO_ACTIF);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSociete">clsSociete</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsSociete clsSociete, params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamSO_RAISONSOCIAL = new SqlParameter("@SO_RAISONSOCIAL", SqlDbType.VarChar, 150);
			vppParamSO_RAISONSOCIAL.Value = clsSociete.SO_RAISONSOCIAL;

			SqlParameter vppParamSO_BOITEPOSTAL = new SqlParameter("@SO_BOITEPOSTAL", SqlDbType.VarChar, 50);
			vppParamSO_BOITEPOSTAL.Value = clsSociete.SO_BOITEPOSTAL;

			SqlParameter vppParamSO_TELEPHONE = new SqlParameter("@SO_TELEPHONE", SqlDbType.VarChar, 80);
			vppParamSO_TELEPHONE.Value = clsSociete.SO_TELEPHONE;

			SqlParameter vppParamSO_DIRECTEUR = new SqlParameter("@SO_DIRECTEUR", SqlDbType.VarChar, 150);
			vppParamSO_DIRECTEUR.Value = clsSociete.SO_DIRECTEUR;

			SqlParameter vppParamSO_EMAIL = new SqlParameter("@SO_EMAIL", SqlDbType.VarChar, 150);
			vppParamSO_EMAIL.Value = clsSociete.SO_EMAIL;

			SqlParameter vppParamSO_SITEWEB = new SqlParameter("@SO_SITEWEB", SqlDbType.VarChar, 150);
			vppParamSO_SITEWEB.Value = clsSociete.SO_SITEWEB;
            SqlParameter vppParamSO_SLOGAN = new SqlParameter("@SO_SLOGAN", SqlDbType.VarChar, 150);
            vppParamSO_SLOGAN.Value = clsSociete.SO_SLOGAN;
			SqlParameter vppParamSO_ACTIF = new SqlParameter("@SO_ACTIF", SqlDbType.VarChar, 1);
			vppParamSO_ACTIF.Value = clsSociete.SO_ACTIF;

			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE SOCIETE SET " + 
			" SO_RAISONSOCIAL = @SO_RAISONSOCIAL , " + 
			" SO_BOITEPOSTAL = @SO_BOITEPOSTAL , " + 
			" SO_TELEPHONE = @SO_TELEPHONE , " + 
			" SO_DIRECTEUR = @SO_DIRECTEUR , " + 
			" SO_EMAIL = @SO_EMAIL , " +
            " SO_SITEWEB = @SO_SITEWEB , " +
            " SO_SLOGAN = @SO_SLOGAN , " + 
			" SO_ACTIF = @SO_ACTIF" + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSO_RAISONSOCIAL);
			vppSqlCmd.Parameters.Add(vppParamSO_BOITEPOSTAL);
			vppSqlCmd.Parameters.Add(vppParamSO_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamSO_DIRECTEUR);
			vppSqlCmd.Parameters.Add(vppParamSO_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamSO_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamSO_SLOGAN);
			vppSqlCmd.Parameters.Add(vppParamSO_ACTIF);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM SOCIETE " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsSociete </returns>
		///<author>Home Technologie</author>
		public List<clsSociete> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSociete> clsSocietes = new List<clsSociete>();

			pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM SOCIETE " + this.vapCritere + " AND SO_ACTIF='O'";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsSociete clsSociete = new clsSociete();
					clsSociete.SO_CODESOCIETE = clsDonnee.vogDataReader["SO_CODESOCIETE"].ToString();
					clsSociete.SO_RAISONSOCIAL = clsDonnee.vogDataReader["SO_RAISONSOCIAL"].ToString();
					clsSociete.SO_BOITEPOSTAL = clsDonnee.vogDataReader["SO_BOITEPOSTAL"].ToString();
					clsSociete.SO_TELEPHONE = clsDonnee.vogDataReader["SO_TELEPHONE"].ToString();
					clsSociete.SO_DIRECTEUR = clsDonnee.vogDataReader["SO_DIRECTEUR"].ToString();
					clsSociete.SO_EMAIL = clsDonnee.vogDataReader["SO_EMAIL"].ToString();
					clsSociete.SO_SITEWEB = clsDonnee.vogDataReader["SO_SITEWEB"].ToString();
					clsSociete.SO_ACTIF = clsDonnee.vogDataReader["SO_ACTIF"].ToString();
					clsSocietes.Add(clsSociete);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSocietes;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsSociete </returns>
		///<author>Home Technologie</author>
		public List<clsSociete> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSociete> clsSocietes = new List<clsSociete>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM SOCIETE " + this.vapCritere + " AND SO_ACTIF='O'";
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsSociete clsSociete = new clsSociete();
					clsSociete.SO_CODESOCIETE = Dataset.Tables["TABLE"].Rows[Idx]["SO_CODESOCIETE"].ToString();
					clsSociete.SO_RAISONSOCIAL = Dataset.Tables["TABLE"].Rows[Idx]["SO_RAISONSOCIAL"].ToString();
					clsSociete.SO_BOITEPOSTAL = Dataset.Tables["TABLE"].Rows[Idx]["SO_BOITEPOSTAL"].ToString();
					clsSociete.SO_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["SO_TELEPHONE"].ToString();
					clsSociete.SO_DIRECTEUR = Dataset.Tables["TABLE"].Rows[Idx]["SO_DIRECTEUR"].ToString();
					clsSociete.SO_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["SO_EMAIL"].ToString();
					clsSociete.SO_SITEWEB = Dataset.Tables["TABLE"].Rows[Idx]["SO_SITEWEB"].ToString();
					clsSociete.SO_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["SO_ACTIF"].ToString();
					clsSocietes.Add(clsSociete);
				}
				Dataset.Dispose();
			}
			return clsSocietes;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM SOCIETE " + this.vapCritere + " AND SO_ACTIF='O'";
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM SOCIETE  WHERE SO_ACTIF='O'";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT SO_CODESOCIETE,SO_RAISONSOCIAL,SO_BOITEPOSTAL,SO_TELEPHONE,SO_DIRECTEUR,SO_EMAIL,SO_SITEWEB,SO_ACTIF FROM SOCIETE " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE)</summary>
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
			}
		}


        }
}