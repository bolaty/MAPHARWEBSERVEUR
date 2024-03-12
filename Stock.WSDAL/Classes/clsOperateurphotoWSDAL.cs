using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{
    public class clsOperateurphotoWSDAL
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : AC_CODEACTIVITE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsActivite">clsActivite</param>
        ///<author>Home Technologie</author>
        public clsOperateurphoto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT OH_PHOTO,OH_SIGNATURE FROM OPERATEURPHOTO " + this.vapCritere;
            this.vapCritere = "";
            clsOperateurphoto clsOperateurphoto = new clsOperateurphoto();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    try
                    {
                        clsOperateurphoto.OH_PHOTO = (Byte[])clsDonnee.vogDataReader["OH_PHOTO"];
                    }
                    catch { }
                    try
                    {
                        clsOperateurphoto.OH_SIGNATURE = (Byte[])clsDonnee.vogDataReader["OH_SIGNATURE"];
                    }
                    catch { }
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsOperateurphoto;
        }


        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<author>Home Technologie</author>
        public void pvgInsert(clsDonnee clsDonnee, clsOperateurphoto clsOperateurphoto)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE2", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOperateurphoto.AG_CODEAGENCE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR2", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsOperateurphoto.OP_CODEOPERATEUR;

            SqlParameter vppParamOH_PHOTO = new SqlParameter("@OH_PHOTO", SqlDbType.VarBinary);
            vppParamOH_PHOTO.Value = clsOperateurphoto.OH_PHOTO;
            if (clsOperateurphoto.OH_PHOTO == null) vppParamOH_PHOTO.Value = DBNull.Value;

            SqlParameter vppParamOH_SIGNATURE = new SqlParameter("@OH_SIGNATURE", SqlDbType.VarBinary);
            vppParamOH_SIGNATURE.Value = clsOperateurphoto.OH_SIGNATURE;
            if (clsOperateurphoto.OH_SIGNATURE == null) vppParamOH_SIGNATURE.Value = DBNull.Value;

            //Préparation de la commande
            this.vapRequete = "INSERT INTO OPERATEURPHOTO (AG_CODEAGENCE,OP_CODEOPERATEUR,OH_PHOTO,OH_SIGNATURE) " +
                              "VALUES (@AG_CODEAGENCE2,@OP_CODEOPERATEUR2,@OH_PHOTO,@OH_SIGNATURE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamOH_PHOTO);
            vppSqlCmd.Parameters.Add(vppParamOH_SIGNATURE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees(Ordre critere:OP_CODEOPERATEUR)</summary>
        ///<param name="vppCritere">Les critères de suppression</param>
        ///<author>Home Technologie</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            //Préparation de la commande
            this.vapRequete = "DELETE FROM  OPERATEURPHOTO " + this.vapCritere; ;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :BU_CODEBUDGET)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR1 ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR1" };
                    vapValeurParametre = new object[] { vppCritere[0] ,vppCritere[1] };
                    break;

                
            }
        }

    }
}