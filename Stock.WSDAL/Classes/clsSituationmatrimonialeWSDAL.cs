using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;


namespace Stock.WSDAL
{

	public class clsSituationmatrimonialeWSDAL : ITableDAL<clsSituationmatrimoniale>
	{

        private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(SM_CODESITUATIONMATRIMONIALE) AS SM_CODESITUATIONMATRIMONIALE  FROM SITUATIONMATRIMONIALE " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(SM_CODESITUATIONMATRIMONIALE) AS SM_CODESITUATIONMATRIMONIALE  FROM SITUATIONMATRIMONIALE " + this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(SM_CODESITUATIONMATRIMONIALE) AS SM_CODESITUATIONMATRIMONIALE  FROM SITUATIONMATRIMONIALE "+ this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsSituationmatrimoniale">clsSituationmatrimoniale</param>
		///<author>Home Technologie</author>
		public clsSituationmatrimoniale pvgTableLabel(clsDonnee clsDonnee , params string[] vppCritere )
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT SM_LIBELLE,SM_NOMBREPARTPARENFANTS,SM_LIMITENOMBREPARTPARENFANTS,SM_NOMBREPARTSANSENFANT,SM_NOMBREPARTAVECENFANT FROM SITUATIONMATRIMONIALE " + this.vapCritere ;
			this.vapCritere = "";

			clsSituationmatrimoniale clsSituationmatrimoniale = new clsSituationmatrimoniale(); 

			 SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			if (clsDonnee .pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee .vogDataReader.Read())
				{
					clsSituationmatrimoniale.SM_LIBELLE = clsDonnee.vogDataReader["SM_LIBELLE"].ToString();
					clsSituationmatrimoniale.SM_NOMBREPARTPARENFANTS = double.Parse(clsDonnee.vogDataReader["SM_NOMBREPARTPARENFANTS"].ToString());
					clsSituationmatrimoniale.SM_LIMITENOMBREPARTPARENFANTS = double.Parse(clsDonnee.vogDataReader["SM_LIMITENOMBREPARTPARENFANTS"].ToString());
					clsSituationmatrimoniale.SM_NOMBREPARTSANSENFANT = double.Parse(clsDonnee.vogDataReader["SM_NOMBREPARTSANSENFANT"].ToString());
					clsSituationmatrimoniale.SM_NOMBREPARTAVECENFANT = double.Parse(clsDonnee.vogDataReader["SM_NOMBREPARTAVECENFANT"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSituationmatrimoniale;
		}

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSituationmatrimoniale">clsSituationmatrimoniale</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee,clsSituationmatrimoniale clsSituationmatrimoniale)
		{
			//Préparation des paramètres

			SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
			vppParamSX_CODESEXE.Value = clsSituationmatrimoniale.SX_CODESEXE;

			SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
			vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsSituationmatrimoniale.SM_CODESITUATIONMATRIMONIALE;

			SqlParameter vppParamSM_LIBELLE = new SqlParameter("@SM_LIBELLE", SqlDbType.VarChar, 150);
			vppParamSM_LIBELLE.Value = clsSituationmatrimoniale.SM_LIBELLE;

			SqlParameter vppParamSM_NOMBREPARTPARENFANTS = new SqlParameter("@SM_NOMBREPARTPARENFANTS", SqlDbType.Real);
			vppParamSM_NOMBREPARTPARENFANTS.Value = clsSituationmatrimoniale.SM_NOMBREPARTPARENFANTS;

			SqlParameter vppParamSM_LIMITENOMBREPARTPARENFANTS = new SqlParameter("@SM_LIMITENOMBREPARTPARENFANTS", SqlDbType.Real);
			vppParamSM_LIMITENOMBREPARTPARENFANTS.Value = clsSituationmatrimoniale.SM_LIMITENOMBREPARTPARENFANTS;

			SqlParameter vppParamSM_NOMBREPARTSANSENFANT = new SqlParameter("@SM_NOMBREPARTSANSENFANT", SqlDbType.Real);
			vppParamSM_NOMBREPARTSANSENFANT.Value = clsSituationmatrimoniale.SM_NOMBREPARTSANSENFANT;

			SqlParameter vppParamSM_NOMBREPARTAVECENFANT = new SqlParameter("@SM_NOMBREPARTAVECENFANT", SqlDbType.Real);
			vppParamSM_NOMBREPARTAVECENFANT.Value = clsSituationmatrimoniale.SM_NOMBREPARTAVECENFANT;

			//Préparation de la commande
			this.vapRequete = "INSERT INTO SITUATIONMATRIMONIALE " +
			" (SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE,SM_LIBELLE,SM_NOMBREPARTPARENFANTS,SM_LIMITENOMBREPARTPARENFANTS,SM_NOMBREPARTSANSENFANT,SM_NOMBREPARTAVECENFANT)" + 
			" VALUES(@SX_CODESEXE,@SM_CODESITUATIONMATRIMONIALE,@SM_LIBELLE,@SM_NOMBREPARTPARENFANTS,@SM_LIMITENOMBREPARTPARENFANTS,@SM_NOMBREPARTSANSENFANT,@SM_NOMBREPARTAVECENFANT)";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
			vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
			vppSqlCmd.Parameters.Add(vppParamSM_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamSM_NOMBREPARTPARENFANTS);
			vppSqlCmd.Parameters.Add(vppParamSM_LIMITENOMBREPARTPARENFANTS);
			vppSqlCmd.Parameters.Add(vppParamSM_NOMBREPARTSANSENFANT);
			vppSqlCmd.Parameters.Add(vppParamSM_NOMBREPARTAVECENFANT);

			//Ouverture de la connection et exécution de la commande
			vppSqlCmd.ExecuteNonQuery();
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSituationmatrimoniale">clsSituationmatrimoniale</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee , clsSituationmatrimoniale clsSituationmatrimoniale, params string[] vppCritere)
		{
			//Préparation des paramètres

			SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
			vppParamSX_CODESEXE.Value = clsSituationmatrimoniale.SX_CODESEXE;

			SqlParameter vppParamSM_LIBELLE = new SqlParameter("@SM_LIBELLE", SqlDbType.VarChar, 150);
			vppParamSM_LIBELLE.Value = clsSituationmatrimoniale.SM_LIBELLE;

			SqlParameter vppParamSM_NOMBREPARTPARENFANTS = new SqlParameter("@SM_NOMBREPARTPARENFANTS", SqlDbType.Real);
			vppParamSM_NOMBREPARTPARENFANTS.Value = clsSituationmatrimoniale.SM_NOMBREPARTPARENFANTS;

			SqlParameter vppParamSM_LIMITENOMBREPARTPARENFANTS = new SqlParameter("@SM_LIMITENOMBREPARTPARENFANTS", SqlDbType.Real);
			vppParamSM_LIMITENOMBREPARTPARENFANTS.Value = clsSituationmatrimoniale.SM_LIMITENOMBREPARTPARENFANTS;

			SqlParameter vppParamSM_NOMBREPARTSANSENFANT = new SqlParameter("@SM_NOMBREPARTSANSENFANT", SqlDbType.Real);
			vppParamSM_NOMBREPARTSANSENFANT.Value = clsSituationmatrimoniale.SM_NOMBREPARTSANSENFANT;

			SqlParameter vppParamSM_NOMBREPARTAVECENFANT = new SqlParameter("@SM_NOMBREPARTAVECENFANT", SqlDbType.Real);
			vppParamSM_NOMBREPARTAVECENFANT.Value = clsSituationmatrimoniale.SM_NOMBREPARTAVECENFANT;

			 pvpChoixCritere(vppCritere); 

			//Préparation de la commande
			this.vapRequete = "UPDATE SITUATIONMATRIMONIALE SET " + 
			" SX_CODESEXE = @SX_CODESEXE , " + 
			" SM_LIBELLE = @SM_LIBELLE , " + 
			" SM_NOMBREPARTPARENFANTS = @SM_NOMBREPARTPARENFANTS , " + 
			" SM_LIMITENOMBREPARTPARENFANTS = @SM_LIMITENOMBREPARTPARENFANTS , " + 
			" SM_NOMBREPARTSANSENFANT = @SM_NOMBREPARTSANSENFANT , " + 
			" SM_NOMBREPARTAVECENFANT = @SM_NOMBREPARTAVECENFANT" + this.vapCritere ;
			
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
			vppSqlCmd.Parameters.Add(vppParamSM_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamSM_NOMBREPARTPARENFANTS);
			vppSqlCmd.Parameters.Add(vppParamSM_LIMITENOMBREPARTPARENFANTS);
			vppSqlCmd.Parameters.Add(vppParamSM_NOMBREPARTSANSENFANT);
			vppSqlCmd.Parameters.Add(vppParamSM_NOMBREPARTAVECENFANT);
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee , params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere); 
			this.vapRequete = "DELETE FROM SITUATIONMATRIMONIALE " + this.vapCritere ;
			this.vapCritere = "";

			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre); 
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsSituationmatrimoniale </returns>
		///<author>Home Technologie</author>
		public List<clsSituationmatrimoniale> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSituationmatrimoniale> clsSituationmatrimoniales = new List<clsSituationmatrimoniale>();

			pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM SITUATIONMATRIMONIALE " +this.vapCritere ;
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			this.vapCritere = "";
			if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while (clsDonnee.vogDataReader.Read())
				{
					clsSituationmatrimoniale clsSituationmatrimoniale = new clsSituationmatrimoniale();
					clsSituationmatrimoniale.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
					clsSituationmatrimoniale.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsSituationmatrimoniale.SM_LIBELLE = clsDonnee.vogDataReader["SM_LIBELLE"].ToString();
					clsSituationmatrimoniale.SM_NOMBREPARTPARENFANTS =double.Parse(clsDonnee.vogDataReader["SM_NOMBREPARTPARENFANTS"].ToString());
					clsSituationmatrimoniale.SM_LIMITENOMBREPARTPARENFANTS =double.Parse(clsDonnee.vogDataReader["SM_LIMITENOMBREPARTPARENFANTS"].ToString());
					clsSituationmatrimoniale.SM_NOMBREPARTSANSENFANT =double.Parse(clsDonnee.vogDataReader["SM_NOMBREPARTSANSENFANT"].ToString());
					clsSituationmatrimoniale.SM_NOMBREPARTAVECENFANT =double.Parse(clsDonnee.vogDataReader["SM_NOMBREPARTAVECENFANT"].ToString());
					clsSituationmatrimoniales.Add(clsSituationmatrimoniale);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsSituationmatrimoniales;
		}

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsSituationmatrimoniale </returns>
		///<author>Home Technologie</author>
		public List<clsSituationmatrimoniale> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsSituationmatrimoniale> clsSituationmatrimoniales = new List<clsSituationmatrimoniale>();
			DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

			this.vapRequete = "SELECT * FROM SITUATIONMATRIMONIALE "+ this.vapCritere ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsSituationmatrimoniale clsSituationmatrimoniale = new clsSituationmatrimoniale();
					clsSituationmatrimoniale.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
					clsSituationmatrimoniale.SM_CODESITUATIONMATRIMONIALE = Dataset.Tables["TABLE"].Rows[Idx]["SM_CODESITUATIONMATRIMONIALE"].ToString();
					clsSituationmatrimoniale.SM_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["SM_LIBELLE"].ToString();
					clsSituationmatrimoniale.SM_NOMBREPARTPARENFANTS =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_NOMBREPARTPARENFANTS"].ToString());
					clsSituationmatrimoniale.SM_LIMITENOMBREPARTPARENFANTS =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_LIMITENOMBREPARTPARENFANTS"].ToString());
					clsSituationmatrimoniale.SM_NOMBREPARTSANSENFANT =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_NOMBREPARTSANSENFANT"].ToString());
					clsSituationmatrimoniale.SM_NOMBREPARTAVECENFANT =double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_NOMBREPARTAVECENFANT"].ToString());
					clsSituationmatrimoniales.Add(clsSituationmatrimoniale);
				}
				Dataset.Dispose();
			}
			return clsSituationmatrimoniales;
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT * FROM SITUATIONMATRIMONIALE " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee ,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT SM_CODESITUATIONMATRIMONIALE,SM_LIBELLE FROM SITUATIONMATRIMONIALE " + this.vapCritere ;
			this.vapCritere = ""; 
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SX_CODESEXE,SM_CODESITUATIONMATRIMONIALE)</summary>
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
					this.vapCritere =" WHERE SX_CODESEXE=@SX_CODESEXE "; 
					vapNomParametre = new string[]{ "@SX_CODESEXE" };
					vapValeurParametre = new object[]{ vppCritere[0] };
					break ;				
				case 2:
					this.vapCritere =" WHERE SX_CODESEXE=@SX_CODESEXE AND  SM_CODESITUATIONMATRIMONIALE=@SM_CODESITUATIONMATRIMONIALE "; 
					vapNomParametre = new string[]{ "@SX_CODESEXE", "@SM_CODESITUATIONMATRIMONIALE" };
					vapValeurParametre = new object[]{ vppCritere[0], vppCritere[1] };
					break ;				
			}
		}


        }
}