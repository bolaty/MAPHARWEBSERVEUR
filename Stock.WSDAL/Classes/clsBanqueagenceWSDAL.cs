using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsBanqueagenceWSDAL : ITableDAL<clsBanqueagence>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(AB_CODEAGENCEBANCAIRE) AS AB_CODEAGENCEBANCAIRE  FROM BANQUEAGENCE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(AB_CODEAGENCEBANCAIRE) AS AB_CODEAGENCEBANCAIRE  FROM BANQUEAGENCE " + this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(AB_CODEAGENCEBANCAIRE) AS AB_CODEAGENCEBANCAIRE  FROM BANQUEAGENCE "+ this.vapCritere ;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsBanqueagence">clsBanqueagence</param>
		///<author>Home Technologie</author>
		public clsBanqueagence pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT AB_LIBELLE,AB_ADRESSEGEOGRAPHIQUE,AB_BOITEPOSTALE,AB_TELEPHONE,AB_FAX,AB_EMAIL FROM BANQUEAGENCE " + this.vapCritere ;
			this.vapCritere = "";

			clsBanqueagence clsBanqueagence = new clsBanqueagence(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsBanqueagence.AB_LIBELLE = clsDonnee.vogDataReader["AB_LIBELLE"].ToString();
					clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["AB_ADRESSEGEOGRAPHIQUE"].ToString();
					clsBanqueagence.AB_BOITEPOSTALE = clsDonnee.vogDataReader["AB_BOITEPOSTALE"].ToString();
					clsBanqueagence.AB_TELEPHONE = clsDonnee.vogDataReader["AB_TELEPHONE"].ToString();
					clsBanqueagence.AB_FAX = clsDonnee.vogDataReader["AB_FAX"].ToString();
					clsBanqueagence.AB_EMAIL = clsDonnee.vogDataReader["AB_EMAIL"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBanqueagence;
		}

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsBanqueagence">clsBanqueagence</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsBanqueagence clsBanqueagence)
		{
			//Préparation des paramètres

			SqlParameter vppParamAB_CODEAGENCEBANCAIRE = new SqlParameter("@AB_CODEAGENCEBANCAIRE", SqlDbType.Int);
			vppParamAB_CODEAGENCEBANCAIRE.Value = clsBanqueagence.AB_CODEAGENCEBANCAIRE;

			SqlParameter vppParamBQ_CODEBANQUE = new SqlParameter("@BQ_CODEBANQUE", SqlDbType.Int);
			vppParamBQ_CODEBANQUE.Value = clsBanqueagence.BQ_CODEBANQUE;

			SqlParameter vppParamAB_LIBELLE = new SqlParameter("@AB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamAB_LIBELLE.Value = clsBanqueagence.AB_LIBELLE;

			SqlParameter vppParamAB_ADRESSEGEOGRAPHIQUE = new SqlParameter("@AB_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
			vppParamAB_ADRESSEGEOGRAPHIQUE.Value = clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE;

			SqlParameter vppParamAB_BOITEPOSTALE = new SqlParameter("@AB_BOITEPOSTALE", SqlDbType.VarChar, 150);
			vppParamAB_BOITEPOSTALE.Value = clsBanqueagence.AB_BOITEPOSTALE;

			SqlParameter vppParamAB_TELEPHONE = new SqlParameter("@AB_TELEPHONE", SqlDbType.VarChar, 80);
			vppParamAB_TELEPHONE.Value = clsBanqueagence.AB_TELEPHONE;

			SqlParameter vppParamAB_FAX = new SqlParameter("@AB_FAX", SqlDbType.VarChar, 80);
			vppParamAB_FAX.Value = clsBanqueagence.AB_FAX;

			SqlParameter vppParamAB_EMAIL = new SqlParameter("@AB_EMAIL", SqlDbType.VarChar, 80);
			vppParamAB_EMAIL.Value = clsBanqueagence.AB_EMAIL;

            SqlParameter vppParamBQ_ABREGE = new SqlParameter("@BQ_ABREGE", SqlDbType.VarChar, 150);
            vppParamBQ_ABREGE.Value = clsBanqueagence.BQ_ABREGE;

            SqlParameter vppParamBQ_CODEBIC = new SqlParameter("@BQ_CODEBIC", SqlDbType.VarChar, 150);
            vppParamBQ_CODEBIC.Value = clsBanqueagence.BQ_CODEBIC;

            SqlParameter vppParamBQ_SITEWEB = new SqlParameter("@BQ_SITEWEB", SqlDbType.VarChar, 150);
            vppParamBQ_SITEWEB.Value = clsBanqueagence.BQ_SITEWEB;

            SqlParameter vppParamBQ_AUTREINFOS = new SqlParameter("@BQ_AUTREINFOS", SqlDbType.VarChar, 150);
            vppParamBQ_AUTREINFOS.Value = clsBanqueagence.BQ_AUTREINFOS;

            SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
            vppParamCO_CODECOMMUNE.Value = clsBanqueagence.CO_CODECOMMUNE;



			//Préparation de la commande
			this.vapRequete = "INSERT INTO BANQUEAGENCE " +
            " (AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE,AB_LIBELLE,AB_ADRESSEGEOGRAPHIQUE,AB_BOITEPOSTALE,AB_TELEPHONE,AB_FAX,AB_EMAIL, BQ_ABREGE, BQ_CODEBIC, BQ_SITEWEB, BQ_AUTREINFOS, CO_CODECOMMUNE)" +
            " VALUES(@AB_CODEAGENCEBANCAIRE,@BQ_CODEBANQUE,@AB_LIBELLE,@AB_ADRESSEGEOGRAPHIQUE,@AB_BOITEPOSTALE,@AB_TELEPHONE,@AB_FAX,@AB_EMAIL, @BQ_ABREGE, @BQ_CODEBIC, @BQ_SITEWEB, @BQ_AUTREINFOS, @CO_CODECOMMUNE)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAB_CODEAGENCEBANCAIRE);
			vppSqlCmd.Parameters.Add(vppParamBQ_CODEBANQUE);
			vppSqlCmd.Parameters.Add(vppParamAB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamAB_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamAB_BOITEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamAB_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamAB_FAX);
			vppSqlCmd.Parameters.Add(vppParamAB_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamBQ_ABREGE);
            vppSqlCmd.Parameters.Add(vppParamBQ_CODEBIC);
            vppSqlCmd.Parameters.Add(vppParamBQ_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamBQ_AUTREINFOS);
            vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsBanqueagence">clsBanqueagence</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsBanqueagence clsBanqueagence, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamBQ_CODEBANQUE = new SqlParameter("@BQ_CODEBANQUE1", SqlDbType.Int);
			vppParamBQ_CODEBANQUE.Value = clsBanqueagence.BQ_CODEBANQUE;

			SqlParameter vppParamAB_LIBELLE = new SqlParameter("@AB_LIBELLE", SqlDbType.VarChar, 150);
			vppParamAB_LIBELLE.Value = clsBanqueagence.AB_LIBELLE;

			SqlParameter vppParamAB_ADRESSEGEOGRAPHIQUE = new SqlParameter("@AB_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
			vppParamAB_ADRESSEGEOGRAPHIQUE.Value = clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE;

			SqlParameter vppParamAB_BOITEPOSTALE = new SqlParameter("@AB_BOITEPOSTALE", SqlDbType.VarChar, 150);
			vppParamAB_BOITEPOSTALE.Value = clsBanqueagence.AB_BOITEPOSTALE;

			SqlParameter vppParamAB_TELEPHONE = new SqlParameter("@AB_TELEPHONE", SqlDbType.VarChar, 80);
			vppParamAB_TELEPHONE.Value = clsBanqueagence.AB_TELEPHONE;

			SqlParameter vppParamAB_FAX = new SqlParameter("@AB_FAX", SqlDbType.VarChar, 80);
			vppParamAB_FAX.Value = clsBanqueagence.AB_FAX;

			SqlParameter vppParamAB_EMAIL = new SqlParameter("@AB_EMAIL", SqlDbType.VarChar, 80);
			vppParamAB_EMAIL.Value = clsBanqueagence.AB_EMAIL;


            SqlParameter vppParamBQ_ABREGE = new SqlParameter("@BQ_ABREGE", SqlDbType.VarChar, 150);
            vppParamBQ_ABREGE.Value = clsBanqueagence.BQ_ABREGE;

            SqlParameter vppParamBQ_CODEBIC = new SqlParameter("@BQ_CODEBIC", SqlDbType.VarChar, 150);
            vppParamBQ_CODEBIC.Value = clsBanqueagence.BQ_CODEBIC;

            SqlParameter vppParamBQ_SITEWEB = new SqlParameter("@BQ_SITEWEB", SqlDbType.VarChar, 150);
            vppParamBQ_SITEWEB.Value = clsBanqueagence.BQ_SITEWEB;

            SqlParameter vppParamBQ_AUTREINFOS = new SqlParameter("@BQ_AUTREINFOS", SqlDbType.VarChar, 150);
            vppParamBQ_AUTREINFOS.Value = clsBanqueagence.BQ_AUTREINFOS;

            SqlParameter vppParamCO_CODECOMMUNE = new SqlParameter("@CO_CODECOMMUNE", SqlDbType.VarChar, 10);
            vppParamCO_CODECOMMUNE.Value = clsBanqueagence.CO_CODECOMMUNE;



			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE BANQUEAGENCE SET " + 
			" BQ_CODEBANQUE = @BQ_CODEBANQUE1 , " + 
			" AB_LIBELLE = @AB_LIBELLE , " + 
			" AB_ADRESSEGEOGRAPHIQUE = @AB_ADRESSEGEOGRAPHIQUE , " + 
			" AB_BOITEPOSTALE = @AB_BOITEPOSTALE , " + 
			" AB_TELEPHONE = @AB_TELEPHONE , " + 
			" AB_FAX = @AB_FAX , " + 
			" AB_EMAIL = @AB_EMAIL , " +
            " BQ_ABREGE = @BQ_ABREGE , " +
            " BQ_CODEBIC = @BQ_CODEBIC , " +
            " BQ_SITEWEB = @BQ_SITEWEB , " +
            " BQ_AUTREINFOS = @BQ_AUTREINFOS , " +
            " CO_CODECOMMUNE = @CO_CODECOMMUNE " + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamBQ_CODEBANQUE);
			vppSqlCmd.Parameters.Add(vppParamAB_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamAB_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamAB_BOITEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamAB_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamAB_FAX);
			vppSqlCmd.Parameters.Add(vppParamAB_EMAIL);

            vppSqlCmd.Parameters.Add(vppParamBQ_ABREGE);
            vppSqlCmd.Parameters.Add(vppParamBQ_CODEBIC);
            vppSqlCmd.Parameters.Add(vppParamBQ_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamBQ_AUTREINFOS);
            vppSqlCmd.Parameters.Add(vppParamCO_CODECOMMUNE);



			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM BANQUEAGENCE " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsBanqueagence </returns>
		///<author>Home Technologie</author>
		public List<clsBanqueagence> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBanqueagence> clsBanqueagences = new List<clsBanqueagence>();

			pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM BANQUEAGENCE " +this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsBanqueagence clsBanqueagence = new clsBanqueagence();
					clsBanqueagence.AB_CODEAGENCEBANCAIRE =int.Parse(clsDonnee.vogDataReader["AB_CODEAGENCEBANCAIRE"].ToString());
					clsBanqueagence.BQ_CODEBANQUE =int.Parse(clsDonnee.vogDataReader["BQ_CODEBANQUE"].ToString());
					clsBanqueagence.AB_LIBELLE = clsDonnee.vogDataReader["AB_LIBELLE"].ToString();
					clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["AB_ADRESSEGEOGRAPHIQUE"].ToString();
					clsBanqueagence.AB_BOITEPOSTALE = clsDonnee.vogDataReader["AB_BOITEPOSTALE"].ToString();
					clsBanqueagence.AB_TELEPHONE = clsDonnee.vogDataReader["AB_TELEPHONE"].ToString();
					clsBanqueagence.AB_FAX = clsDonnee.vogDataReader["AB_FAX"].ToString();
					clsBanqueagence.AB_EMAIL = clsDonnee.vogDataReader["AB_EMAIL"].ToString();

                    clsBanqueagence.BQ_ABREGE = clsDonnee.vogDataReader["BQ_ABREGE"].ToString();
                    clsBanqueagence.BQ_CODEBIC = clsDonnee.vogDataReader["BQ_CODEBIC"].ToString();
                    clsBanqueagence.BQ_SITEWEB = clsDonnee.vogDataReader["BQ_SITEWEB"].ToString();
                    clsBanqueagence.BQ_AUTREINFOS = clsDonnee.vogDataReader["BQ_AUTREINFOS"].ToString();
                    clsBanqueagence.CO_CODECOMMUNE = clsDonnee.vogDataReader["CO_CODECOMMUNE"].ToString();
                    

					clsBanqueagences.Add(clsBanqueagence);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsBanqueagences;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsBanqueagence </returns>
		///<author>Home Technologie</author>
		public List<clsBanqueagence> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsBanqueagence> clsBanqueagences = new List<clsBanqueagence>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);


			this.vapRequete = "SELECT * FROM BANQUEAGENCE "+ this.vapCritere ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsBanqueagence clsBanqueagence = new clsBanqueagence();
					clsBanqueagence.AB_CODEAGENCEBANCAIRE =int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AB_CODEAGENCEBANCAIRE"].ToString());
					clsBanqueagence.BQ_CODEBANQUE =int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["BQ_CODEBANQUE"].ToString());
					clsBanqueagence.AB_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["AB_LIBELLE"].ToString();
					clsBanqueagence.AB_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["AB_ADRESSEGEOGRAPHIQUE"].ToString();
					clsBanqueagence.AB_BOITEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["AB_BOITEPOSTALE"].ToString();
					clsBanqueagence.AB_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["AB_TELEPHONE"].ToString();
					clsBanqueagence.AB_FAX = Dataset.Tables["TABLE"].Rows[Idx]["AB_FAX"].ToString();
					clsBanqueagence.AB_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["AB_EMAIL"].ToString();

                    clsBanqueagence.BQ_ABREGE = Dataset.Tables["TABLE"].Rows[Idx]["BQ_ABREGE"].ToString();
                    clsBanqueagence.BQ_CODEBIC = Dataset.Tables["TABLE"].Rows[Idx]["BQ_CODEBIC"].ToString();
                    clsBanqueagence.BQ_SITEWEB = Dataset.Tables["TABLE"].Rows[Idx]["BQ_SITEWEB"].ToString();
                    clsBanqueagence.BQ_AUTREINFOS = Dataset.Tables["TABLE"].Rows[Idx]["BQ_AUTREINFOS"].ToString();
                    clsBanqueagence.CO_CODECOMMUNE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMMUNE"].ToString();

					clsBanqueagences.Add(clsBanqueagence);
				}
				Dataset.Dispose();
			}
			return clsBanqueagences;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT * FROM VUE_BANQUEAGENCE " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT AB_CODEAGENCEBANCAIRE, AB_LIBELLE, BQ_CODEBANQUE, AB_ADRESSEGEOGRAPHIQUE, AB_BOITEPOSTALE, AB_TELEPHONE, AB_FAX, AB_EMAIL, BQ_ABREGE, BQ_SITEWEB, BQ_AUTREINFOS, CO_CODECOMMUNE FROM BANQUEAGENCE " + this.vapCritere;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : AB_CODEAGENCEBANCAIRE,BQ_CODEBANQUE)</summary>
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
                    this.vapCritere = " WHERE BQ_CODEBANQUE=@BQ_CODEBANQUE ";
                    vapNomParametre = new string[] { "@BQ_CODEBANQUE" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
				case 2:
					this.vapCritere =" WHERE AB_CODEAGENCEBANCAIRE=@AB_CODEAGENCEBANCAIRE AND  BQ_CODEBANQUE=@BQ_CODEBANQUE "; 
					vapNomParametre = new string[]{ "@AB_CODEAGENCEBANCAIRE", "@BQ_CODEBANQUE" };
					vapValeurParametre = new object[]{ vppCritere[0], vppCritere[1] };
					break ;				
			}
		}


        }
}