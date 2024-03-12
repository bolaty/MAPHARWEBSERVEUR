using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsEtatWSDAL : ITableDAL<clsEtat>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : ET_INDEX,ET_NOMGROUPE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount( clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(ET_INDEX) AS ET_INDEX  FROM ETAT " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : ET_INDEX,ET_NOMGROUPE )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin( clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(ET_INDEX) AS ET_INDEX  FROM ETAT " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : ET_INDEX,ET_NOMGROUPE )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax( clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(ET_INDEX) AS ET_INDEX  FROM ETAT "+ this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : ET_INDEX,ET_NOMGROUPE )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsEtat">clsEtat</param>
		///<author>Home Technologie</author>
		public clsEtat pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT ET_DOSSIER,ET_NOMETAT,ET_LIBELLEETAT,ET_AFFICHER,ET_NUMEROORDRE FROM ETAT " + this.vapCritere ;
			vapCritere = "";

			clsEtat clsEtat = new clsEtat(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsEtat.ET_DOSSIER = clsDonnee.vogDataReader["ET_DOSSIER"].ToString();
					clsEtat.ET_NOMETAT = clsDonnee.vogDataReader["ET_NOMETAT"].ToString();
					clsEtat.ET_LIBELLEETAT = clsDonnee.vogDataReader["ET_LIBELLEETAT"].ToString();
					clsEtat.ET_AFFICHER = clsDonnee.vogDataReader["ET_AFFICHER"].ToString();
					clsEtat.ET_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["ET_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsEtat;
		}

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsEtat">clsEtat</param>
		///<author>Home Technologie</author>
		public void pvgInsert( clsDonnee clsDonnee,clsEtat clsEtat)
		{
			//Préparation des paramètres

			SqlParameter vppParamET_INDEX = new SqlParameter("@ET_INDEX", SqlDbType.NVarChar, 50);
			vppParamET_INDEX.Value = clsEtat.ET_INDEX;

			SqlParameter vppParamET_NOMGROUPE = new SqlParameter("@ET_NOMGROUPE", SqlDbType.NVarChar, 50);
			vppParamET_NOMGROUPE.Value = clsEtat.ET_NOMGROUPE;

			SqlParameter vppParamET_DOSSIER = new SqlParameter("@ET_DOSSIER", SqlDbType.NVarChar, 50);
			vppParamET_DOSSIER.Value = clsEtat.ET_DOSSIER;

			SqlParameter vppParamET_NOMETAT = new SqlParameter("@ET_NOMETAT", SqlDbType.NVarChar, 50);
			vppParamET_NOMETAT.Value = clsEtat.ET_NOMETAT;

			SqlParameter vppParamET_LIBELLEETAT = new SqlParameter("@ET_LIBELLEETAT", SqlDbType.NVarChar, 250);
			vppParamET_LIBELLEETAT.Value = clsEtat.ET_LIBELLEETAT;

			SqlParameter vppParamET_AFFICHER = new SqlParameter("@ET_AFFICHER", SqlDbType.VarChar, 1);
			vppParamET_AFFICHER.Value = clsEtat.ET_AFFICHER;

			SqlParameter vppParamET_NUMEROORDRE = new SqlParameter("@ET_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamET_NUMEROORDRE.Value = clsEtat.ET_NUMEROORDRE;

			//Préparation de la commande
			this.vapRequete = "INSERT INTO ETAT " +
			" (ET_INDEX,ET_NOMGROUPE,ET_DOSSIER,ET_NOMETAT,ET_LIBELLEETAT,ET_AFFICHER,ET_NUMEROORDRE)" + 
			" VALUES(@ET_INDEX,@ET_NOMGROUPE,@ET_DOSSIER,@ET_NOMETAT,@ET_LIBELLEETAT,@ET_AFFICHER,@ET_NUMEROORDRE)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamET_INDEX);
			vppSqlCmd.Parameters.Add(vppParamET_NOMGROUPE);
			vppSqlCmd.Parameters.Add(vppParamET_DOSSIER);
			vppSqlCmd.Parameters.Add(vppParamET_NOMETAT);
			vppSqlCmd.Parameters.Add(vppParamET_LIBELLEETAT);
			vppSqlCmd.Parameters.Add(vppParamET_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamET_NUMEROORDRE);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:ET_INDEX,ET_NOMGROUPE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsEtat">clsEtat</param>
		///<author>Home Technologie</author>
		public void pvgUpdate( clsDonnee clsDonnee , clsEtat clsEtat, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamET_NOMGROUPE = new SqlParameter("@ET_NOMGROUPE", SqlDbType.NVarChar, 50);
			vppParamET_NOMGROUPE.Value = clsEtat.ET_NOMGROUPE;

			SqlParameter vppParamET_DOSSIER = new SqlParameter("@ET_DOSSIER", SqlDbType.NVarChar, 50);
			vppParamET_DOSSIER.Value = clsEtat.ET_DOSSIER;

			SqlParameter vppParamET_NOMETAT = new SqlParameter("@ET_NOMETAT", SqlDbType.NVarChar, 50);
			vppParamET_NOMETAT.Value = clsEtat.ET_NOMETAT;

			SqlParameter vppParamET_LIBELLEETAT = new SqlParameter("@ET_LIBELLEETAT", SqlDbType.NVarChar, 250);
			vppParamET_LIBELLEETAT.Value = clsEtat.ET_LIBELLEETAT;

			SqlParameter vppParamET_AFFICHER = new SqlParameter("@ET_AFFICHER", SqlDbType.VarChar, 1);
			vppParamET_AFFICHER.Value = clsEtat.ET_AFFICHER;

			SqlParameter vppParamET_NUMEROORDRE = new SqlParameter("@ET_NUMEROORDRE", SqlDbType.TinyInt);
			vppParamET_NUMEROORDRE.Value = clsEtat.ET_NUMEROORDRE;

			 pvpChoixCritere(vppCritere); 

		//Préparation de la commande
			this.vapRequete = "UPDATE ETAT SET " + 
			" ET_NOMGROUPE = @ET_NOMGROUPE , " + 
			" ET_DOSSIER = @ET_DOSSIER , " + 
			" ET_NOMETAT = @ET_NOMETAT , " + 
			" ET_LIBELLEETAT = @ET_LIBELLEETAT , " + 
			" ET_AFFICHER = @ET_AFFICHER , " + 
			" ET_NUMEROORDRE = @ET_NUMEROORDRE" + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamET_NOMGROUPE);
			vppSqlCmd.Parameters.Add(vppParamET_DOSSIER);
			vppSqlCmd.Parameters.Add(vppParamET_NOMETAT);
			vppSqlCmd.Parameters.Add(vppParamET_LIBELLEETAT);
			vppSqlCmd.Parameters.Add(vppParamET_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamET_NUMEROORDRE);
			vapCritere = "";
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees(Ordre critere:ET_INDEX,ET_NOMGROUPE)</summary>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM ETAT " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : ET_INDEX,ET_NOMGROUPE )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de 'clsEtat' </returns>
		///<author>Home Technologie</author>
		public List<clsEtat> pvgSelect( clsDonnee clsDonnee, params string[] vppCritere )
		{
			List<clsEtat> clsEtats = new List<clsEtat>();

			pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM ETAT " +this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsEtat clsEtat = new clsEtat();
					clsEtat.ET_INDEX = clsDonnee.vogDataReader["ET_INDEX"].ToString();
					clsEtat.ET_NOMGROUPE = clsDonnee.vogDataReader["ET_NOMGROUPE"].ToString();
					clsEtat.ET_DOSSIER = clsDonnee.vogDataReader["ET_DOSSIER"].ToString();
					clsEtat.ET_NOMETAT = clsDonnee.vogDataReader["ET_NOMETAT"].ToString();
					clsEtat.ET_LIBELLEETAT = clsDonnee.vogDataReader["ET_LIBELLEETAT"].ToString();
					clsEtat.ET_AFFICHER = clsDonnee.vogDataReader["ET_AFFICHER"].ToString();
					clsEtat.ET_NUMEROORDRE =int.Parse(clsDonnee.vogDataReader["ET_NUMEROORDRE"].ToString());
					clsEtats.Add(clsEtat);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsEtats;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : ET_INDEX,ET_NOMGROUPE )</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de 'clsEtat' </returns>
		///<author>Home Technologie</author>
		public List<clsEtat> pvgSelectDataSet( clsDonnee clsDonnee, params string[] vppCritere )
		{
			List<clsEtat> clsEtats = new List<clsEtat>();
			DataSet Dataset = new DataSet();

			this.vapRequete = "SELECT * FROM ETAT "+ this.vapCritere ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsEtat clsEtat = new clsEtat();
					clsEtat.ET_INDEX = Dataset.Tables["TABLE"].Rows[Idx]["ET_INDEX"].ToString();
					clsEtat.ET_NOMGROUPE = Dataset.Tables["TABLE"].Rows[Idx]["ET_NOMGROUPE"].ToString();
					clsEtat.ET_DOSSIER = Dataset.Tables["TABLE"].Rows[Idx]["ET_DOSSIER"].ToString();
					clsEtat.ET_NOMETAT = Dataset.Tables["TABLE"].Rows[Idx]["ET_NOMETAT"].ToString();
					clsEtat.ET_LIBELLEETAT = Dataset.Tables["TABLE"].Rows[Idx]["ET_LIBELLEETAT"].ToString();
					clsEtat.ET_AFFICHER = Dataset.Tables["TABLE"].Rows[Idx]["ET_AFFICHER"].ToString();
                    clsEtat.ET_AFFICHERCOLNOMETATPORTRAIRE = Dataset.Tables["TABLE"].Rows[Idx]["ET_AFFICHERCOLNOMETATPORTRAIRE"].ToString();

					clsEtat.ET_NUMEROORDRE =int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["ET_NUMEROORDRE"].ToString());
					clsEtats.Add(clsEtat);
				}
				Dataset.Dispose();
			}
			return clsEtats;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
            //pvpChoixCritere(vppCritere);
            
            //this.vapCritere = " WHERE ET_NOMGROUPE=@ET_NOMGROUPE AND  OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ET_AFFICHER='O' AND OD_APERCU='O' ORDER BY ET_NUMEROORDRE";
            vapNomParametre = new string[] { "@ET_NOMGROUPE", "@OP_CODEOPERATEUR", "@ET_AFFICHER", "@OD_APERCU" };
			vapValeurParametre = new object[] { vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};

            this.vapRequete = "EXEC PS_LIBELLEEDITIONWEB @ET_NOMGROUPE,@OP_CODEOPERATEUR,@ET_AFFICHER,@OD_APERCU";// +this.vapCritere;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT ET_INDEX,ET_NOMGROUPE,ET_DOSSIER,ET_NOMETAT,ET_LIBELLEETAT,ET_AFFICHER,ET_NUMEROORDRE FROM ETAT " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		/// <param name="vppChamp">Champs du SELECT séparés par des virgules</param>
		/// <param name="vppChampOrdre">Champs du ORDER BY séparés par des virgules</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee , string vppChamp, string vppChampOrdre, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT "+ vppChamp + " FROM ETAT " + this.vapCritere ;
			if (vppChampOrdre != "") this.vapRequete = this.vapRequete + " ORDER BY " + vppChampOrdre ; 
			this.vapCritere = ""; 
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
                    this.vapCritere = "ORDER BY ET_NUMEROORDRE";
					vapNomParametre = new string[] { };
					vapValeurParametre = new object[] { };
					break ;				
				case 1:
                    this.vapCritere = " WHERE ET_NOMGROUPE=@ET_NOMGROUPE AND ET_AFFICHER='O' AND OD_APERCU='O' ORDER BY ET_NUMEROORDRE";
                    vapNomParametre = new string[] { "@ET_NOMGROUPE" };
					vapValeurParametre = new object[] { vppCritere[0]};
					break ;

				case 2:
                    this.vapCritere = " WHERE ET_NOMGROUPE=@ET_NOMGROUPE AND  OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ET_AFFICHER='O' AND OD_APERCU='O' ORDER BY ET_NUMEROORDRE";
                    vapNomParametre = new string[] { "@ET_NOMGROUPE", "@OP_CODEOPERATEUR" };
					vapValeurParametre = new object[] { vppCritere[0],vppCritere[1]};
					break ;

                case 3:
                    this.vapCritere = " WHERE ET_NOMGROUPE=@ET_NOMGROUPE AND  OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND  ET_INDEX=@ET_INDEX   AND ET_AFFICHER='O' AND OD_APERCU='O' ORDER BY ET_NUMEROORDRE";
                    vapNomParametre = new string[] { "@ET_NOMGROUPE", "@OP_CODEOPERATEUR", "@ET_INDEX" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[3] };
                    break;

			}
		}

        }
}