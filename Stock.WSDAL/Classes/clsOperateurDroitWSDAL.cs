using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsOperateurdroitWSDAL : ITableDAL<clsOperateurdroit>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,OB_CODEOBJET ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount( clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(OB_CODEOBJET) AS OB_CODEOBJET  FROM OPERATEURDROIT " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,OB_CODEOBJET )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin( clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(OB_CODEOBJET) AS OB_CODEOBJET  FROM OPERATEURDROIT " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,OB_CODEOBJET )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax( clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(OB_CODEOBJET) AS OB_CODEOBJET  FROM OPERATEURDROIT "+ this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : OP_CODEOPERATEUR,OB_CODEOBJET )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsOperateurdroit">clsOperateurdroit</param>
		///<author>Home Technologie</author>
		public clsOperateurdroit pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT OD_AUTORISER,OD_AJOUTER,OD_MODIFIER,OD_SUPPRIMER,OD_APERCU,OD_IMPRIMER,OD_IMPRIMERTOUT,OD_NUMEROORDRE FROM OPERATEURDROIT " + this.vapCritere ;
			vapCritere = "";

			clsOperateurdroit clsOperateurdroit = new clsOperateurdroit(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsOperateurdroit.OD_AUTORISER = clsDonnee.vogDataReader["OD_AUTORISER"].ToString();
					clsOperateurdroit.OD_AJOUTER = clsDonnee.vogDataReader["OD_AJOUTER"].ToString();
					clsOperateurdroit.OD_MODIFIER = clsDonnee.vogDataReader["OD_MODIFIER"].ToString();
					clsOperateurdroit.OD_SUPPRIMER = clsDonnee.vogDataReader["OD_SUPPRIMER"].ToString();
					clsOperateurdroit.OD_APERCU = clsDonnee.vogDataReader["OD_APERCU"].ToString();
					clsOperateurdroit.OD_IMPRIMER = clsDonnee.vogDataReader["OD_IMPRIMER"].ToString();
					clsOperateurdroit.OD_IMPRIMERTOUT = clsDonnee.vogDataReader["OD_IMPRIMERTOUT"].ToString();
					clsOperateurdroit.OD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["OD_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsOperateurdroit;
		}

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsOperateurdroit">clsOperateurdroit</param>
		///<author>Home Technologie</author>
		public void pvgInsert( clsDonnee clsDonnee,clsOperateurdroit clsOperateurdroit)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
            vppParamAG_CODEAGENCE.Value = clsOperateurdroit.AG_CODEAGENCE;

			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
			vppParamOP_CODEOPERATEUR.Value = clsOperateurdroit.OP_CODEOPERATEUR;


			SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.Int);
			vppParamOB_CODEOBJET.Value = clsOperateurdroit.OB_CODEOBJET;

			SqlParameter vppParamOD_AUTORISER = new SqlParameter("@OD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamOD_AUTORISER.Value = clsOperateurdroit.OD_AUTORISER;

			SqlParameter vppParamOD_AJOUTER = new SqlParameter("@OD_AJOUTER", SqlDbType.VarChar, 1);
			vppParamOD_AJOUTER.Value = clsOperateurdroit.OD_AJOUTER;

			SqlParameter vppParamOD_MODIFIER = new SqlParameter("@OD_MODIFIER", SqlDbType.VarChar, 1);
			vppParamOD_MODIFIER.Value = clsOperateurdroit.OD_MODIFIER;

			SqlParameter vppParamOD_SUPPRIMER = new SqlParameter("@OD_SUPPRIMER", SqlDbType.VarChar, 1);
			vppParamOD_SUPPRIMER.Value = clsOperateurdroit.OD_SUPPRIMER;

			SqlParameter vppParamOD_APERCU = new SqlParameter("@OD_APERCU", SqlDbType.VarChar, 1);
			vppParamOD_APERCU.Value = clsOperateurdroit.OD_APERCU;

			SqlParameter vppParamOD_IMPRIMER = new SqlParameter("@OD_IMPRIMER", SqlDbType.VarChar, 1);
			vppParamOD_IMPRIMER.Value = clsOperateurdroit.OD_IMPRIMER;

			SqlParameter vppParamOD_IMPRIMERTOUT = new SqlParameter("@OD_IMPRIMERTOUT", SqlDbType.VarChar, 1);
			vppParamOD_IMPRIMERTOUT.Value = clsOperateurdroit.OD_IMPRIMERTOUT;

			SqlParameter vppParamOD_NUMEROORDRE = new SqlParameter("@OD_NUMEROORDRE", SqlDbType.Int);
			vppParamOD_NUMEROORDRE.Value = clsOperateurdroit.OD_NUMEROORDRE;

			//Préparation de la commande
			this.vapRequete = "INSERT INTO OPERATEURDROITWEB " +
            " (AG_CODEAGENCE, OP_CODEOPERATEUR,OB_CODEOBJET,OD_AUTORISER,OD_AJOUTER,OD_MODIFIER,OD_SUPPRIMER,OD_APERCU,OD_IMPRIMER,OD_IMPRIMERTOUT,OD_NUMEROORDRE)" +
            " VALUES(@AG_CODEAGENCE, @OP_CODEOPERATEUR,@OB_CODEOBJET,@OD_AUTORISER,@OD_AJOUTER,@OD_MODIFIER,@OD_SUPPRIMER,@OD_APERCU,@OD_IMPRIMER,@OD_IMPRIMERTOUT,@OD_NUMEROORDRE)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamOD_AUTORISER);
			vppSqlCmd.Parameters.Add(vppParamOD_AJOUTER);
			vppSqlCmd.Parameters.Add(vppParamOD_MODIFIER);
			vppSqlCmd.Parameters.Add(vppParamOD_SUPPRIMER);
			vppSqlCmd.Parameters.Add(vppParamOD_APERCU);
			vppSqlCmd.Parameters.Add(vppParamOD_IMPRIMER);
			vppSqlCmd.Parameters.Add(vppParamOD_IMPRIMERTOUT);
			vppSqlCmd.Parameters.Add(vppParamOD_NUMEROORDRE);

			//Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:OP_CODEOPERATEUR,OB_CODEOBJET)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsOperateurdroit">clsOperateurdroit</param>
		///<author>Home Technologie</author>
		public void pvgUpdate( clsDonnee clsDonnee , clsOperateurdroit clsOperateurdroit, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamOD_AUTORISER = new SqlParameter("@OD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamOD_AUTORISER.Value = clsOperateurdroit.OD_AUTORISER;

			SqlParameter vppParamOD_AJOUTER = new SqlParameter("@OD_AJOUTER", SqlDbType.VarChar, 1);
			vppParamOD_AJOUTER.Value = clsOperateurdroit.OD_AJOUTER;

			SqlParameter vppParamOD_MODIFIER = new SqlParameter("@OD_MODIFIER", SqlDbType.VarChar, 1);
			vppParamOD_MODIFIER.Value = clsOperateurdroit.OD_MODIFIER;

			SqlParameter vppParamOD_SUPPRIMER = new SqlParameter("@OD_SUPPRIMER", SqlDbType.VarChar, 1);
			vppParamOD_SUPPRIMER.Value = clsOperateurdroit.OD_SUPPRIMER;

			SqlParameter vppParamOD_APERCU = new SqlParameter("@OD_APERCU", SqlDbType.VarChar, 1);
			vppParamOD_APERCU.Value = clsOperateurdroit.OD_APERCU;

			SqlParameter vppParamOD_IMPRIMER = new SqlParameter("@OD_IMPRIMER", SqlDbType.VarChar, 1);
			vppParamOD_IMPRIMER.Value = clsOperateurdroit.OD_IMPRIMER;

			SqlParameter vppParamOD_IMPRIMERTOUT = new SqlParameter("@OD_IMPRIMERTOUT", SqlDbType.VarChar, 1);
			vppParamOD_IMPRIMERTOUT.Value = clsOperateurdroit.OD_IMPRIMERTOUT;

			SqlParameter vppParamOD_NUMEROORDRE = new SqlParameter("@OD_NUMEROORDRE", SqlDbType.Int);
			vppParamOD_NUMEROORDRE.Value = clsOperateurdroit.OD_NUMEROORDRE;

			 pvpChoixCritere(vppCritere); 

		//Préparation de la commande
			this.vapRequete = "UPDATE OPERATEURDROITWEB SET " + 
			" OD_AUTORISER = @OD_AUTORISER , " + 
			" OD_AJOUTER = @OD_AJOUTER , " + 
			" OD_MODIFIER = @OD_MODIFIER , " + 
			" OD_SUPPRIMER = @OD_SUPPRIMER , " + 
			" OD_APERCU = @OD_APERCU , " + 
			" OD_IMPRIMER = @OD_IMPRIMER , " + 
			" OD_IMPRIMERTOUT = @OD_IMPRIMERTOUT , " + 
			" OD_NUMEROORDRE = @OD_NUMEROORDRE" + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamOD_AUTORISER);
			vppSqlCmd.Parameters.Add(vppParamOD_AJOUTER);
			vppSqlCmd.Parameters.Add(vppParamOD_MODIFIER);
			vppSqlCmd.Parameters.Add(vppParamOD_SUPPRIMER);
			vppSqlCmd.Parameters.Add(vppParamOD_APERCU);
			vppSqlCmd.Parameters.Add(vppParamOD_IMPRIMER);
			vppSqlCmd.Parameters.Add(vppParamOD_IMPRIMERTOUT);
			vppSqlCmd.Parameters.Add(vppParamOD_NUMEROORDRE);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees(Ordre critere:OP_CODEOPERATEUR,OB_CODEOBJET)</summary>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
            pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM OPERATEURDROITWEB " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,OB_CODEOBJET )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de 'clsOperateurdroit' </returns>
		///<author>Home Technologie</author>
		public List<clsOperateurdroit> pvgSelect( clsDonnee clsDonnee, params string[] vppCritere )
		{
			List<clsOperateurdroit> clsOperateurdroits = new List<clsOperateurdroit>();

			pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM OPERATEURDROIT " +this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsOperateurdroit clsOperateurdroit = new clsOperateurdroit();
					clsOperateurdroit.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroit.OB_CODEOBJET =int.Parse(clsDonnee.vogDataReader["OB_CODEOBJET"].ToString());
					clsOperateurdroit.OD_AUTORISER = clsDonnee.vogDataReader["OD_AUTORISER"].ToString();
					clsOperateurdroit.OD_AJOUTER = clsDonnee.vogDataReader["OD_AJOUTER"].ToString();
					clsOperateurdroit.OD_MODIFIER = clsDonnee.vogDataReader["OD_MODIFIER"].ToString();
					clsOperateurdroit.OD_SUPPRIMER = clsDonnee.vogDataReader["OD_SUPPRIMER"].ToString();
					clsOperateurdroit.OD_APERCU = clsDonnee.vogDataReader["OD_APERCU"].ToString();
					clsOperateurdroit.OD_IMPRIMER = clsDonnee.vogDataReader["OD_IMPRIMER"].ToString();
					clsOperateurdroit.OD_IMPRIMERTOUT = clsDonnee.vogDataReader["OD_IMPRIMERTOUT"].ToString();
					clsOperateurdroit.OD_NUMEROORDRE =int.Parse(clsDonnee.vogDataReader["OD_NUMEROORDRE"].ToString());
					clsOperateurdroits.Add(clsOperateurdroit);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsOperateurdroits;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,OB_CODEOBJET )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de 'clsOperateurdroit' </returns>
		///<author>Home Technologie</author>
		public List<clsOperateurdroit> pvgSelectDataSet( clsDonnee clsDonnee, params string[] vppCritere )
		{
			List<clsOperateurdroit> clsOperateurdroits = new List<clsOperateurdroit>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM OPERATEURDROITWEB " + this.vapCritere ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsOperateurdroit clsOperateurdroit = new clsOperateurdroit();
					clsOperateurdroit.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsOperateurdroit.OB_CODEOBJET =int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OB_CODEOBJET"].ToString());
					clsOperateurdroit.OD_AUTORISER = Dataset.Tables["TABLE"].Rows[Idx]["OD_AUTORISER"].ToString();
					clsOperateurdroit.OD_AJOUTER = Dataset.Tables["TABLE"].Rows[Idx]["OD_AJOUTER"].ToString();
					clsOperateurdroit.OD_MODIFIER = Dataset.Tables["TABLE"].Rows[Idx]["OD_MODIFIER"].ToString();
					clsOperateurdroit.OD_SUPPRIMER = Dataset.Tables["TABLE"].Rows[Idx]["OD_SUPPRIMER"].ToString();
					clsOperateurdroit.OD_APERCU = Dataset.Tables["TABLE"].Rows[Idx]["OD_APERCU"].ToString();
					clsOperateurdroit.OD_IMPRIMER = Dataset.Tables["TABLE"].Rows[Idx]["OD_IMPRIMER"].ToString();
					clsOperateurdroit.OD_IMPRIMERTOUT = Dataset.Tables["TABLE"].Rows[Idx]["OD_IMPRIMERTOUT"].ToString();
					clsOperateurdroit.OD_NUMEROORDRE =int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OD_NUMEROORDRE"].ToString());
					clsOperateurdroits.Add(clsOperateurdroit);
				}
				Dataset.Dispose();
			}
			return clsOperateurdroits;
		}


        //public List<clsOperateurdroit> pvgDroitOperateur(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    List<clsOperateurdroit> clsOperateurdroits = new List<clsOperateurdroit>();
        //    DataSet Dataset = new DataSet();
        //    pvpChoixCritere1(vppCritere);

        //    this.vapRequete = "SELECT * FROM OPERATEURDROIT " + this.vapCritere;
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
        //    if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
        //    {
        //        for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
        //        {
        //            clsOperateurdroit clsOperateurdroit = new clsOperateurdroit();
        //            clsOperateurdroit.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
        //            clsOperateurdroit.OB_CODEOBJET = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OB_CODEOBJET"].ToString());
        //            clsOperateurdroit.OD_AUTORISER = Dataset.Tables["TABLE"].Rows[Idx]["OD_AUTORISER"].ToString();
        //            clsOperateurdroit.OD_AJOUTER = Dataset.Tables["TABLE"].Rows[Idx]["OD_AJOUTER"].ToString();
        //            clsOperateurdroit.OD_MODIFIER = Dataset.Tables["TABLE"].Rows[Idx]["OD_MODIFIER"].ToString();
        //            clsOperateurdroit.OD_SUPPRIMER = Dataset.Tables["TABLE"].Rows[Idx]["OD_SUPPRIMER"].ToString();
        //            clsOperateurdroit.OD_APERCU = Dataset.Tables["TABLE"].Rows[Idx]["OD_APERCU"].ToString();
        //            clsOperateurdroit.OD_IMPRIMER = Dataset.Tables["TABLE"].Rows[Idx]["OD_IMPRIMER"].ToString();
        //            clsOperateurdroit.OD_IMPRIMERTOUT = Dataset.Tables["TABLE"].Rows[Idx]["OD_IMPRIMERTOUT"].ToString();
        //            clsOperateurdroit.OD_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OD_NUMEROORDRE"].ToString());
        //            clsOperateurdroits.Add(clsOperateurdroit);
        //        }
        //        Dataset.Dispose();
        //    }
        //    return clsOperateurdroits;
        //}



         public List<string> pvgDroitOperateur(clsDonnee clsDonnee, params string[] vppCritere)
		{
            List<string> vlpNomMenus = new List<string>();
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@LO_CODELOGICIEL", "@OT_CODETYPEOBJET" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] ,vppCritere[3] };
            this.vapRequete = "SELECT * FROM [dbo].[FC_OPERATEURDROITDROITUTILISATEUR](@AG_CODEAGENCE,	@OP_CODEOPERATEUR,	@LO_CODELOGICIEL,@OT_CODETYPEOBJET)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                    vlpNomMenus.Add(clsDonnee.vogDataReader[0].ToString());
                clsDonnee.vogDataReader.Dispose();
            }
            return vlpNomMenus;
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT * FROM OPERATEURDROIT " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT OP_CODEOPERATEUR,OB_CODEOBJET,OD_AUTORISER,OD_AJOUTER,OD_MODIFIER,OD_SUPPRIMER,OD_APERCU,OD_IMPRIMER,OD_IMPRIMERTOUT,OD_NUMEROORDRE FROM OPERATEURDROIT " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}



        public DataSet pvgInsertIntoDatasetGrille(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OB_CODEOBJET" };
            //vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT * FROM dbo.[FC_OPERATEURDROITWEB1] (@AG_CODEAGENCE ,@OP_CODEOPERATEUR , @OB_CODEOBJET)" + this.vapCritere;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}
       


        public DataSet pvgInsertIntoDatasetDroitSurObjet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OB_CODEOBJET" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = "SELECT * FROM dbo.[FC_OPERATEURDROITSUROBJET] (@AG_CODEAGENCE, @OP_CODEOPERATEUR , @OB_CODEOBJET)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary> Cette fonction permet de definir les critères d'une requête  </summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(params string[] vppCritere)
		{
			switch (vppCritere.Length ) 
			{
				
				case 0:
					this.vapCritere ="" ;
					vapNomParametre = new string[] { };
					vapValeurParametre = new object[] { };
					break ;
				
				case 1:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
					vapValeurParametre = new object[] { vppCritere[0]};
					break ;
				
				case 2:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR "; 
					vapNomParametre = new string[] { "@AG_CODEAGENCE" ,"@OP_CODEOPERATEUR"};
					vapValeurParametre = new object[] { vppCritere[0],vppCritere[1]};
					break ;
				
				case 3:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND  OB_CODEOBJET=@OB_CODEOBJET"; 
					vapNomParametre = new string[] {"@AG_CODEAGENCE", "@OP_CODEOPERATEUR","@OB_CODEOBJET"};
					vapValeurParametre = new object[] { vppCritere[0],vppCritere[1],vppCritere[2]};
					break ;


                ////case 4:
                ////    this.vapCritere = " WHERE    AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR =@OP_CODEOPERATEUR AND OB_CODEOBJET IN( SELECT OB_CODEOBJET FROM LOGICIELOBJET WHERE LO_CODELOGICIEL=@LO_CODELOGICIEL AND OB_RATTACHEA=@OB_RATTACHEA  ";
                ////    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@LO_CODELOGICIEL", "@OB_RATTACHEA" };
                ////    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                ////    break;
			}
		}


        ///<summary> Cette fonction permet de definir les critères d'une requête  </summary>
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
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                case 2:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OB_CODEOBJET" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = " WHERE LO_CODELOGICIEL=@LO_CODELOGICIEL ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OB_CODEOBJET", "@LO_CODELOGICIEL" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

                case 5:
                    this.vapCritere = " WHERE   LO_CODELOGICIEL=@LO_CODELOGICIEL AND OB_RATTACHEA=@OB_RATTACHEA  ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OB_CODEOBJET", "@LO_CODELOGICIEL", "@OB_RATTACHEA" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;

            }
        }


        }
}