using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsProfilwebdroitWSDAL: ITableDAL<clsProfilwebdroit>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(PO_CODEPROFILWEB) AS PO_CODEPROFILWEB  FROM dbo.Profilwebdroit " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(PO_CODEPROFILWEB) AS PO_CODEPROFILWEB  FROM dbo.Profilwebdroit " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(PO_CODEPROFILWEB) AS PO_CODEPROFILWEB  FROM dbo.Profilwebdroit " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsProfilwebdroit comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsProfilwebdroit pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PD_AUTORISER  , PD_AJOUTER  , PD_MODIFIER  , PD_SUPPRIMER  , PD_APERCU  , PD_IMPRIMER  , PD_IMPRIMERTOUT  , PD_NUMEROORDRE  FROM dbo.Profilwebdroit " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsProfilwebdroit clsProfilwebdroit = new clsProfilwebdroit();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsProfilwebdroit.PD_AUTORISER = clsDonnee.vogDataReader["PD_AUTORISER"].ToString();
					clsProfilwebdroit.PD_AJOUTER = clsDonnee.vogDataReader["PD_AJOUTER"].ToString();
					clsProfilwebdroit.PD_MODIFIER = clsDonnee.vogDataReader["PD_MODIFIER"].ToString();
					clsProfilwebdroit.PD_SUPPRIMER = clsDonnee.vogDataReader["PD_SUPPRIMER"].ToString();
					clsProfilwebdroit.PD_APERCU = clsDonnee.vogDataReader["PD_APERCU"].ToString();
					clsProfilwebdroit.PD_IMPRIMER = clsDonnee.vogDataReader["PD_IMPRIMER"].ToString();
					clsProfilwebdroit.PD_IMPRIMERTOUT = clsDonnee.vogDataReader["PD_IMPRIMERTOUT"].ToString();
					clsProfilwebdroit.PD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PD_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsProfilwebdroit;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsProfilwebdroit>clsProfilwebdroit</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsProfilwebdroit clsProfilwebdroit)
		{
			//Préparation des paramètres
			SqlParameter vppParamPO_CODEPROFILWEB = new SqlParameter("@PO_CODEPROFILWEB", SqlDbType.VarChar, 2);
			vppParamPO_CODEPROFILWEB.Value  = clsProfilwebdroit.PO_CODEPROFILWEB ;
			SqlParameter vppParamOB_CODEOBJET = new SqlParameter("@OB_CODEOBJET", SqlDbType.Int);
			vppParamOB_CODEOBJET.Value  = clsProfilwebdroit.OB_CODEOBJET ;
			SqlParameter vppParamPD_AUTORISER = new SqlParameter("@PD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamPD_AUTORISER.Value  = clsProfilwebdroit.PD_AUTORISER ;
			SqlParameter vppParamPD_AJOUTER = new SqlParameter("@PD_AJOUTER", SqlDbType.VarChar, 1);
			vppParamPD_AJOUTER.Value  = clsProfilwebdroit.PD_AJOUTER ;
			SqlParameter vppParamPD_MODIFIER = new SqlParameter("@PD_MODIFIER", SqlDbType.VarChar, 1);
			vppParamPD_MODIFIER.Value  = clsProfilwebdroit.PD_MODIFIER ;
			SqlParameter vppParamPD_SUPPRIMER = new SqlParameter("@PD_SUPPRIMER", SqlDbType.VarChar, 1);
			vppParamPD_SUPPRIMER.Value  = clsProfilwebdroit.PD_SUPPRIMER ;
			SqlParameter vppParamPD_APERCU = new SqlParameter("@PD_APERCU", SqlDbType.VarChar, 1);
			vppParamPD_APERCU.Value  = clsProfilwebdroit.PD_APERCU ;
			SqlParameter vppParamPD_IMPRIMER = new SqlParameter("@PD_IMPRIMER", SqlDbType.VarChar, 1);
			vppParamPD_IMPRIMER.Value  = clsProfilwebdroit.PD_IMPRIMER ;
			SqlParameter vppParamPD_IMPRIMERTOUT = new SqlParameter("@PD_IMPRIMERTOUT", SqlDbType.VarChar, 1);
			vppParamPD_IMPRIMERTOUT.Value  = clsProfilwebdroit.PD_IMPRIMERTOUT ;
			SqlParameter vppParamPD_NUMEROORDRE = new SqlParameter("@PD_NUMEROORDRE", SqlDbType.Int);
			vppParamPD_NUMEROORDRE.Value  = clsProfilwebdroit.PD_NUMEROORDRE ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO PROFILWEBDROIT (  PO_CODEPROFILWEB, OB_CODEOBJET, PD_AUTORISER, PD_AJOUTER, PD_MODIFIER, PD_SUPPRIMER, PD_APERCU, PD_IMPRIMER, PD_IMPRIMERTOUT, PD_NUMEROORDRE) " +
					 "VALUES ( @PO_CODEPROFILWEB, @OB_CODEOBJET, @PD_AUTORISER, @PD_AJOUTER, @PD_MODIFIER, @PD_SUPPRIMER, @PD_APERCU, @PD_IMPRIMER, @PD_IMPRIMERTOUT, @PD_NUMEROORDRE) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFILWEB);
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

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsProfilwebdroit>clsProfilwebdroit</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsProfilwebdroit clsProfilwebdroit,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPD_AUTORISER = new SqlParameter("@PD_AUTORISER", SqlDbType.VarChar, 1);
			vppParamPD_AUTORISER.Value  = clsProfilwebdroit.PD_AUTORISER ;
			SqlParameter vppParamPD_AJOUTER = new SqlParameter("@PD_AJOUTER", SqlDbType.VarChar, 1);
			vppParamPD_AJOUTER.Value  = clsProfilwebdroit.PD_AJOUTER ;
			SqlParameter vppParamPD_MODIFIER = new SqlParameter("@PD_MODIFIER", SqlDbType.VarChar, 1);
			vppParamPD_MODIFIER.Value  = clsProfilwebdroit.PD_MODIFIER ;
			SqlParameter vppParamPD_SUPPRIMER = new SqlParameter("@PD_SUPPRIMER", SqlDbType.VarChar, 1);
			vppParamPD_SUPPRIMER.Value  = clsProfilwebdroit.PD_SUPPRIMER ;
			SqlParameter vppParamPD_APERCU = new SqlParameter("@PD_APERCU", SqlDbType.VarChar, 1);
			vppParamPD_APERCU.Value  = clsProfilwebdroit.PD_APERCU ;
			SqlParameter vppParamPD_IMPRIMER = new SqlParameter("@PD_IMPRIMER", SqlDbType.VarChar, 1);
			vppParamPD_IMPRIMER.Value  = clsProfilwebdroit.PD_IMPRIMER ;
			SqlParameter vppParamPD_IMPRIMERTOUT = new SqlParameter("@PD_IMPRIMERTOUT", SqlDbType.VarChar, 1);
			vppParamPD_IMPRIMERTOUT.Value  = clsProfilwebdroit.PD_IMPRIMERTOUT ;
			SqlParameter vppParamPD_NUMEROORDRE = new SqlParameter("@PD_NUMEROORDRE", SqlDbType.Int);
			vppParamPD_NUMEROORDRE.Value  = clsProfilwebdroit.PD_NUMEROORDRE ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE PROFILWEBDROIT SET " +
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

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  PROFILWEBDROIT " + this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfilwebdroit </returns>
		///<author>Home Technology</author>
		public List<clsProfilwebdroit> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PO_CODEPROFILWEB, OB_CODEOBJET, PD_AUTORISER, PD_AJOUTER, PD_MODIFIER, PD_SUPPRIMER, PD_APERCU, PD_IMPRIMER, PD_IMPRIMERTOUT, PD_NUMEROORDRE FROM dbo.Profilwebdroit " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsProfilwebdroit> clsProfilwebdroits = new List<clsProfilwebdroit>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsProfilwebdroit clsProfilwebdroit = new clsProfilwebdroit();
					clsProfilwebdroit.PO_CODEPROFILWEB = clsDonnee.vogDataReader["PO_CODEPROFILWEB"].ToString();
					clsProfilwebdroit.OB_CODEOBJET = int.Parse(clsDonnee.vogDataReader["OB_CODEOBJET"].ToString());
					clsProfilwebdroit.PD_AUTORISER = clsDonnee.vogDataReader["PD_AUTORISER"].ToString();
					clsProfilwebdroit.PD_AJOUTER = clsDonnee.vogDataReader["PD_AJOUTER"].ToString();
					clsProfilwebdroit.PD_MODIFIER = clsDonnee.vogDataReader["PD_MODIFIER"].ToString();
					clsProfilwebdroit.PD_SUPPRIMER = clsDonnee.vogDataReader["PD_SUPPRIMER"].ToString();
					clsProfilwebdroit.PD_APERCU = clsDonnee.vogDataReader["PD_APERCU"].ToString();
					clsProfilwebdroit.PD_IMPRIMER = clsDonnee.vogDataReader["PD_IMPRIMER"].ToString();
					clsProfilwebdroit.PD_IMPRIMERTOUT = clsDonnee.vogDataReader["PD_IMPRIMERTOUT"].ToString();
					clsProfilwebdroit.PD_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["PD_NUMEROORDRE"].ToString());
					clsProfilwebdroits.Add(clsProfilwebdroit);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsProfilwebdroits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsProfilwebdroit </returns>
		///<author>Home Technology</author>
		public List<clsProfilwebdroit> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsProfilwebdroit> clsProfilwebdroits = new List<clsProfilwebdroit>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  PO_CODEPROFILWEB, OB_CODEOBJET, PD_AUTORISER, PD_AJOUTER, PD_MODIFIER, PD_SUPPRIMER, PD_APERCU, PD_IMPRIMER, PD_IMPRIMERTOUT, PD_NUMEROORDRE FROM dbo.Profilwebdroit " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsProfilwebdroit clsProfilwebdroit = new clsProfilwebdroit();
					clsProfilwebdroit.PO_CODEPROFILWEB = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFILWEB"].ToString();
					clsProfilwebdroit.OB_CODEOBJET = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OB_CODEOBJET"].ToString());
					clsProfilwebdroit.PD_AUTORISER = Dataset.Tables["TABLE"].Rows[Idx]["PD_AUTORISER"].ToString();
					clsProfilwebdroit.PD_AJOUTER = Dataset.Tables["TABLE"].Rows[Idx]["PD_AJOUTER"].ToString();
					clsProfilwebdroit.PD_MODIFIER = Dataset.Tables["TABLE"].Rows[Idx]["PD_MODIFIER"].ToString();
					clsProfilwebdroit.PD_SUPPRIMER = Dataset.Tables["TABLE"].Rows[Idx]["PD_SUPPRIMER"].ToString();
					clsProfilwebdroit.PD_APERCU = Dataset.Tables["TABLE"].Rows[Idx]["PD_APERCU"].ToString();
					clsProfilwebdroit.PD_IMPRIMER = Dataset.Tables["TABLE"].Rows[Idx]["PD_IMPRIMER"].ToString();
					clsProfilwebdroit.PD_IMPRIMERTOUT = Dataset.Tables["TABLE"].Rows[Idx]["PD_IMPRIMERTOUT"].ToString();
					clsProfilwebdroit.PD_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PD_NUMEROORDRE"].ToString());
					clsProfilwebdroits.Add(clsProfilwebdroit);
				}
				Dataset.Dispose();
			}
		return clsProfilwebdroits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //vapNomParametre = new string[] { "@PO_CODEPROFILWEB", "@OB_CODEOBJET" };
            //vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };

            pvpChoixCritere1(vppCritere);

            this.vapRequete = "SELECT * FROM dbo.[FC_Profilwebdroit] (@PO_CODEPROFILWEB , @OB_CODEOBJET)" + this.vapCritere;
            this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PO_CODEPROFILWEB, OB_CODEOBJET ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT PO_CODEPROFILWEB , PD_AUTORISER FROM dbo.Profilwebdroit " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PO_CODEPROFILWEB, OB_CODEOBJET)</summary>
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
				this.vapCritere ="WHERE PO_CODEPROFILWEB=@PO_CODEPROFILWEB";
				vapNomParametre = new string[]{"@PO_CODEPROFILWEB"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PO_CODEPROFILWEB=@PO_CODEPROFILWEB AND OB_CODEOBJET=@OB_CODEOBJET";
				vapNomParametre = new string[]{"@PO_CODEPROFILWEB","@OB_CODEOBJET"};
				vapValeurParametre = new object[]{vppCritere[0],vppCritere[1]};
				break;
			}
		}


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PO_CODEPROFILWEB, OB_CODEOBJET)</summary>
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
                    this.vapCritere = "WHERE PO_CODEPROFILWEB=@PO_CODEPROFILWEB";
                    vapNomParametre = new string[] { "@PO_CODEPROFILWEB" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " ";
                    vapNomParametre = new string[] { "@PO_CODEPROFILWEB", "@OB_CODEOBJET" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE  LO_CODELOGICIEL=@LO_CODELOGICIEL  ";
                    vapNomParametre = new string[] { "@PO_CODEPROFILWEB", "@OB_CODEOBJET", "@LO_CODELOGICIEL" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = "WHERE  LO_CODELOGICIEL=@LO_CODELOGICIEL AND OB_RATTACHEA=@OB_RATTACHEA";
                    vapNomParametre = new string[] { "@PO_CODEPROFILWEB", "@OB_CODEOBJET", "@LO_CODELOGICIEL", "@OB_RATTACHEA" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;


            }
        }
	}
}
