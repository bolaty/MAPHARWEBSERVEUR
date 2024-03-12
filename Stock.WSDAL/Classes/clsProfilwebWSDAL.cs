using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

    public class clsProfilwebWSDAL : ITableDAL<clsProfilweb>
    {

        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(PO_CODEPROFILWEB) AS PO_CODEPROFILWEB  FROM Profilweb " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(PO_CODEPROFILWEB) AS PO_CODEPROFILWEB  FROM Profilweb " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(PO_CODEPROFILWEB) AS PO_CODEPROFILWEB  FROM Profilweb " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsProfilweb">clsProfilweb</param>
		///<author>Home Technologie</author>
		public clsProfilweb pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PO_LIBELLE FROM Profilweb " + this.vapCritere;
            vapCritere = "";

            clsProfilweb clsProfilweb = new clsProfilweb();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsProfilweb.PO_LIBELLE = clsDonnee.vogDataReader["PO_LIBELLE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsProfilweb;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfilweb">clsProfilweb</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee, clsProfilweb clsProfilweb)
        {
            //Préparation des paramètres

            SqlParameter vppParamPO_CODEPROFILWEB = new SqlParameter("@PO_CODEPROFILWEB1", SqlDbType.VarChar, 2);
            vppParamPO_CODEPROFILWEB.Value = clsProfilweb.PO_CODEPROFILWEB;

            SqlParameter vppParamPO_LIBELLE = new SqlParameter("@PO_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPO_LIBELLE.Value = clsProfilweb.PO_LIBELLE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_Profilweb  @PO_CODEPROFILWEB1, @PO_LIBELLE, @CODECRYPTAGE1, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFILWEB);
            vppSqlCmd.Parameters.Add(vppParamPO_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);

            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.ExecuteNonQuery();
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsProfilweb">clsProfilweb</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsProfilweb clsProfilweb, params string[] vppCritere)
        {
            //Préparation des paramètres

            SqlParameter vppParamPO_LIBELLE = new SqlParameter("@PO_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPO_LIBELLE.Value = clsProfilweb.PO_LIBELLE;

            pvpChoixCritere(clsDonnee, vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE Profilweb SET " +
            " PO_LIBELLE = @PO_LIBELLE" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamPO_LIBELLE);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "EXECUTE PC_Profilweb  @PO_CODEPROFILWEB, '' , @CODECRYPTAGE, 2 ";
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsProfilweb </returns>
		///<author>Home Technologie</author>
		public List<clsProfilweb> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsProfilweb> clsProfilwebs = new List<clsProfilweb>();

            pvpChoixCritere(clsDonnee, vppCritere);

            this.vapRequete = "SELECT * FROM Profilweb " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsProfilweb clsProfilweb = new clsProfilweb();
                    clsProfilweb.PO_CODEPROFILWEB = clsDonnee.vogDataReader["PO_CODEPROFILWEB"].ToString();
                    clsProfilweb.PO_LIBELLE = clsDonnee.vogDataReader["PO_LIBELLE"].ToString();
                    clsProfilwebs.Add(clsProfilweb);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsProfilwebs;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsProfilweb </returns>
		///<author>Home Technologie</author>
		public List<clsProfilweb> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsProfilweb> clsProfilwebs = new List<clsProfilweb>();
            DataSet Dataset = new DataSet();
            pvpChoixCritere(clsDonnee, vppCritere);

            this.vapRequete = "SELECT * FROM Profilweb " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsProfilweb clsProfilweb = new clsProfilweb();
                    clsProfilweb.PO_CODEPROFILWEB = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFILWEB"].ToString();
                    clsProfilweb.PO_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PO_LIBELLE"].ToString();
                    clsProfilwebs.Add(clsProfilweb);
                }
                Dataset.Dispose();
            }
            return clsProfilwebs;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapCritere = vppCritere.Length > 0 ? "" : " WHERE NOT (PO_LIBELLE like '%ADMIN%' OR PO_LIBELLE like'%BILAN%')";
            this.vapRequete = "SELECT * , SELECTIONNER ='N' FROM Profilweb " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            if (vppCritere.Length != 2)
                this.vapCritere = vppCritere.Length > 0 ? "" : " WHERE NOT (PO_LIBELLE like '%ADMIN%' OR PO_LIBELLE like'%BILAN%')";
            this.vapRequete = "SELECT PO_CODEPROFILWEB,PO_LIBELLE FROM Profilweb " + this.vapCritere;

            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB)</summary>
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
                    this.vapCritere = " WHERE PO_CODEPROFILWEB=@PO_CODEPROFILWEB AND  NOT (PO_LIBELLE like '%ADMIN%' OR PO_LIBELLE like'%BILAN%')";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@PO_CODEPROFILWEB" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

                case 2:
                    this.vapCritere = " WHERE PO_LIBELLE like '%'+@PO_LIBELLE+'%' AND  NOT (PO_LIBELLE like '%ADMIN%' OR PO_LIBELLE like'%BILAN%')";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@PO_LIBELLE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;


            }
        }


    }
}