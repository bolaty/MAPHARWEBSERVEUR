using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsProfildroitWSDAL: ITableDAL<clsProfildroit>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PO_CODEPROFIL) AS PO_CODEPROFIL  FROM dbo.PROFILDROIT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PO_CODEPROFIL) AS PO_CODEPROFIL  FROM dbo.PROFILDROIT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PO_CODEPROFIL) AS PO_CODEPROFIL  FROM dbo.PROFILDROIT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsProfildroit comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsProfildroit pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PD_AUTORISER  , PD_AJOUTER  , PD_MODIFIER  , PD_SUPPRIMER  , PD_APERCU  , PD_IMPRIMER  , PD_IMPRIMERTOUT  , PD_NUMEROORDRE  FROM dbo.PROFILDROIT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsProfildroit clsProfildroit = new clsProfildroit();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsProfildroit.PD_AUTORISER = clsDonnee.vogDataReader["PD_AUTORISER"].ToString();
					clsProfildroit.PD_AJOUTER = clsDonnee.vogDataReader["PD_AJOUTER"].ToString();
					clsProfildroit.PD_MODIFIER = clsDonnee.vogDataReader["PD_MODIFIER"].ToString();
					clsProfildroit.PD_SUPPRIMER = clsDonnee.vogDataReader["PD_SUPPRIMER"].ToString();
					clsProfildroit.PD_APERCU = clsDonnee.vogDataReader["PD_APERCU"].ToString();
					clsProfildroit.PD_IMPRIMER = clsDonnee.vogDataReader["PD_IMPRIMER"].ToString();
					clsProfildroit.PD_IMPRIMERTOUT = clsDonnee.vogDataReader["PD_IMPRIMERTOUT"].ToString();
					clsProfildroit.PD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PD_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsProfildroit;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsProfildroit>clsProfildroit</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsProfildroit clsProfildroit)
		{
			//Préparation des paramètres
			SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 2);
			vppParamPO_CODEPROFIL.Value  = clsProfildroit.PO_CODEPROFIL ;
			SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.Int);
			vppParamOB_CODEOBJET.Value  = clsProfildroit.OB_CODEOBJET ;
			SqlParameter vppParamPD_AUTORISER = new SqlParameter("@PD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamPD_AUTORISER.Value  = clsProfildroit.PD_AUTORISER ;
			SqlParameter vppParamPD_AJOUTER = new SqlParameter("@PD_AJOUTER", SqlDbType.VarChar, 1);
			vppParamPD_AJOUTER.Value  = clsProfildroit.PD_AJOUTER ;
			SqlParameter vppParamPD_MODIFIER = new SqlParameter("@PD_MODIFIER", SqlDbType.VarChar, 1);
			vppParamPD_MODIFIER.Value  = clsProfildroit.PD_MODIFIER ;
			SqlParameter vppParamPD_SUPPRIMER = new SqlParameter("@PD_SUPPRIMER", SqlDbType.VarChar, 1);
			vppParamPD_SUPPRIMER.Value  = clsProfildroit.PD_SUPPRIMER ;
			SqlParameter vppParamPD_APERCU = new SqlParameter("@PD_APERCU", SqlDbType.VarChar, 1);
			vppParamPD_APERCU.Value  = clsProfildroit.PD_APERCU ;
			SqlParameter vppParamPD_IMPRIMER = new SqlParameter("@PD_IMPRIMER", SqlDbType.VarChar, 1);
			vppParamPD_IMPRIMER.Value  = clsProfildroit.PD_IMPRIMER ;
			SqlParameter vppParamPD_IMPRIMERTOUT = new SqlParameter("@PD_IMPRIMERTOUT", SqlDbType.VarChar, 1);
			vppParamPD_IMPRIMERTOUT.Value  = clsProfildroit.PD_IMPRIMERTOUT ;
			SqlParameter vppParamPD_NUMEROORDRE = new SqlParameter("@PD_NUMEROORDRE", SqlDbType.Int);
			vppParamPD_NUMEROORDRE.Value  = clsProfildroit.PD_NUMEROORDRE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PROFILDROIT (  PO_CODEPROFIL, OB_CODEOBJET, PD_AUTORISER, PD_AJOUTER, PD_MODIFIER, PD_SUPPRIMER, PD_APERCU, PD_IMPRIMER, PD_IMPRIMERTOUT, PD_NUMEROORDRE) " +
					 "VALUES ( @PO_CODEPROFIL, @OB_CODEOBJET, @PD_AUTORISER, @PD_AJOUTER, @PD_MODIFIER, @PD_SUPPRIMER, @PD_APERCU, @PD_IMPRIMER, @PD_IMPRIMERTOUT, @PD_NUMEROORDRE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
			vppSqlCmd.Parameters.Add(vppParamOB_CODEOBJET);
			vppSqlCmd.Parameters.Add(vppParamPD_AUTORISER);
			vppSqlCmd.Parameters.Add(vppParamPD_AJOUTER);
			vppSqlCmd.Parameters.Add(vppParamPD_MODIFIER);
			vppSqlCmd.Parameters.Add(vppParamPD_SUPPRIMER);
			vppSqlCmd.Parameters.Add(vppParamPD_APERCU);
			vppSqlCmd.Parameters.Add(vppParamPD_IMPRIMER);
			vppSqlCmd.Parameters.Add(vppParamPD_IMPRIMERTOUT);
			vppSqlCmd.Parameters.Add(vppParamPD_NUMEROORDRE);
			//Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsProfildroit>clsProfildroit</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsProfildroit clsProfildroit,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPD_AUTORISER = new SqlParameter("@PD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamPD_AUTORISER.Value  = clsProfildroit.PD_AUTORISER ;
			SqlParameter vppParamPD_AJOUTER = new SqlParameter("@PD_AJOUTER", SqlDbType.VarChar, 1);
			vppParamPD_AJOUTER.Value  = clsProfildroit.PD_AJOUTER ;
			SqlParameter vppParamPD_MODIFIER = new SqlParameter("@PD_MODIFIER", SqlDbType.VarChar, 1);
			vppParamPD_MODIFIER.Value  = clsProfildroit.PD_MODIFIER ;
			SqlParameter vppParamPD_SUPPRIMER = new SqlParameter("@PD_SUPPRIMER", SqlDbType.VarChar, 1);
			vppParamPD_SUPPRIMER.Value  = clsProfildroit.PD_SUPPRIMER ;
			SqlParameter vppParamPD_APERCU = new SqlParameter("@PD_APERCU", SqlDbType.VarChar, 1);
			vppParamPD_APERCU.Value  = clsProfildroit.PD_APERCU ;
			SqlParameter vppParamPD_IMPRIMER = new SqlParameter("@PD_IMPRIMER", SqlDbType.VarChar, 1);
			vppParamPD_IMPRIMER.Value  = clsProfildroit.PD_IMPRIMER ;
			SqlParameter vppParamPD_IMPRIMERTOUT = new SqlParameter("@PD_IMPRIMERTOUT", SqlDbType.VarChar, 1);
			vppParamPD_IMPRIMERTOUT.Value  = clsProfildroit.PD_IMPRIMERTOUT ;
			SqlParameter vppParamPD_NUMEROORDRE = new SqlParameter("@PD_NUMEROORDRE", SqlDbType.Int);
			vppParamPD_NUMEROORDRE.Value  = clsProfildroit.PD_NUMEROORDRE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PROFILDROIT SET " +
							"PD_AUTORISER = @PD_AUTORISER, "+
							"PD_AJOUTER = @PD_AJOUTER, "+
							"PD_MODIFIER = @PD_MODIFIER, "+
							"PD_SUPPRIMER = @PD_SUPPRIMER, "+
							"PD_APERCU = @PD_APERCU, "+
							"PD_IMPRIMER = @PD_IMPRIMER, "+
							"PD_IMPRIMERTOUT = @PD_IMPRIMERTOUT, "+
							"PD_NUMEROORDRE = @PD_NUMEROORDRE " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPD_AUTORISER);
			vppSqlCmd.Parameters.Add(vppParamPD_AJOUTER);
			vppSqlCmd.Parameters.Add(vppParamPD_MODIFIER);
			vppSqlCmd.Parameters.Add(vppParamPD_SUPPRIMER);
			vppSqlCmd.Parameters.Add(vppParamPD_APERCU);
			vppSqlCmd.Parameters.Add(vppParamPD_IMPRIMER);
			vppSqlCmd.Parameters.Add(vppParamPD_IMPRIMERTOUT);
			vppSqlCmd.Parameters.Add(vppParamPD_NUMEROORDRE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PROFILDROIT "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfildroit </returns>
		///<author>Home Technology</author>
		public List<clsProfildroit> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PO_CODEPROFIL, OB_CODEOBJET, PD_AUTORISER, PD_AJOUTER, PD_MODIFIER, PD_SUPPRIMER, PD_APERCU, PD_IMPRIMER, PD_IMPRIMERTOUT, PD_NUMEROORDRE FROM dbo.PROFILDROIT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsProfildroit> clsProfildroits = new List<clsProfildroit>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsProfildroit clsProfildroit = new clsProfildroit();
					clsProfildroit.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString();
					clsProfildroit.OB_CODEOBJET = int.Parse(clsDonnee.vogDataReader["OB_CODEOBJET"].ToString());
					clsProfildroit.PD_AUTORISER = clsDonnee.vogDataReader["PD_AUTORISER"].ToString();
					clsProfildroit.PD_AJOUTER = clsDonnee.vogDataReader["PD_AJOUTER"].ToString();
					clsProfildroit.PD_MODIFIER = clsDonnee.vogDataReader["PD_MODIFIER"].ToString();
					clsProfildroit.PD_SUPPRIMER = clsDonnee.vogDataReader["PD_SUPPRIMER"].ToString();
					clsProfildroit.PD_APERCU = clsDonnee.vogDataReader["PD_APERCU"].ToString();
					clsProfildroit.PD_IMPRIMER = clsDonnee.vogDataReader["PD_IMPRIMER"].ToString();
					clsProfildroit.PD_IMPRIMERTOUT = clsDonnee.vogDataReader["PD_IMPRIMERTOUT"].ToString();
					clsProfildroit.PD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PD_NUMEROORDRE"].ToString());
					clsProfildroits.Add(clsProfildroit);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsProfildroits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfildroit </returns>
		///<author>Home Technology</author>
		public List<clsProfildroit> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsProfildroit> clsProfildroits = new List<clsProfildroit>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PO_CODEPROFIL, OB_CODEOBJET, PD_AUTORISER, PD_AJOUTER, PD_MODIFIER, PD_SUPPRIMER, PD_APERCU, PD_IMPRIMER, PD_IMPRIMERTOUT, PD_NUMEROORDRE FROM dbo.PROFILDROIT " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsProfildroit clsProfildroit = new clsProfildroit();
					clsProfildroit.PO_CODEPROFIL = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFIL"].ToString();
					clsProfildroit.OB_CODEOBJET = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OB_CODEOBJET"].ToString());
					clsProfildroit.PD_AUTORISER = Dataset.Tables["TABLE"].Rows[Idx]["PD_AUTORISER"].ToString();
					clsProfildroit.PD_AJOUTER = Dataset.Tables["TABLE"].Rows[Idx]["PD_AJOUTER"].ToString();
					clsProfildroit.PD_MODIFIER = Dataset.Tables["TABLE"].Rows[Idx]["PD_MODIFIER"].ToString();
					clsProfildroit.PD_SUPPRIMER = Dataset.Tables["TABLE"].Rows[Idx]["PD_SUPPRIMER"].ToString();
					clsProfildroit.PD_APERCU = Dataset.Tables["TABLE"].Rows[Idx]["PD_APERCU"].ToString();
					clsProfildroit.PD_IMPRIMER = Dataset.Tables["TABLE"].Rows[Idx]["PD_IMPRIMER"].ToString();
					clsProfildroit.PD_IMPRIMERTOUT = Dataset.Tables["TABLE"].Rows[Idx]["PD_IMPRIMERTOUT"].ToString();
					clsProfildroit.PD_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PD_NUMEROORDRE"].ToString());
					clsProfildroits.Add(clsProfildroit);
				}
				Dataset.Dispose();
			}
		return clsProfildroits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //vapNomParametre = new string[] { "@PO_CODEPROFIL", "@OB_CODEOBJET" };
            //vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };

            pvpChoixCritere1(vppCritere);

            this.vapRequete = "SELECT * FROM dbo.[FC_PROFILDROIT] (@PO_CODEPROFIL , @OB_CODEOBJET)" + this.vapCritere;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPROFIL, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PO_CODEPROFIL , PD_AUTORISER FROM dbo.PROFILDROIT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PO_CODEPROFIL, OB_CODEOBJET)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
				this.vapCritere ="WHERE PO_CODEPROFIL=@PO_CODEPROFIL";
				vapNomParametre = new string[]{"@PO_CODEPROFIL"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PO_CODEPROFIL=@PO_CODEPROFIL AND OB_CODEOBJET=@OB_CODEOBJET";
				vapNomParametre = new string[]{"@PO_CODEPROFIL","@OB_CODEOBJET"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PO_CODEPROFIL, OB_CODEOBJET)</summary>
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
                    this.vapCritere = "WHERE PO_CODEPROFIL=@PO_CODEPROFIL";
                    vapNomParametre = new string[] { "@PO_CODEPROFIL" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " ";
                    vapNomParametre = new string[] { "@PO_CODEPROFIL", "@OB_CODEOBJET" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE  LO_CODELOGICIEL=@LO_CODELOGICIEL  ";
                    vapNomParametre = new string[] { "@PO_CODEPROFIL", "@OB_CODEOBJET", "@LO_CODELOGICIEL" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = "WHERE  LO_CODELOGICIEL=@LO_CODELOGICIEL AND OB_RATTACHEA=@OB_RATTACHEA";
                    vapNomParametre = new string[] { "@PO_CODEPROFIL", "@OB_CODEOBJET", "@LO_CODELOGICIEL", "@OB_RATTACHEA" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;


            }
        }
	}
}
