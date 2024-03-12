using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;
using System.IO;

namespace Stock.WSDAL
{
	public class clsCtsinistrephotoWSDAL: ITableDAL<clsCtsinistrephoto>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(SI_CODESINISTRE) AS SI_CODESINISTRE  FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtsinistrephoto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtsinistrephoto pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SI_CHEMINPHOTO  , SI_LIBELLEPHOTO  FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsCtsinistrephoto clsCtsinistrephoto = new clsCtsinistrephoto();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistrephoto.SI_CHEMINPHOTO = clsDonnee.vogDataReader["SI_CHEMINPHOTO"].ToString();
					clsCtsinistrephoto.SI_LIBELLEPHOTO = clsDonnee.vogDataReader["SI_LIBELLEPHOTO"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsCtsinistrephoto;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsCtsinistrephoto>clsCtsinistrephoto</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsCtsinistrephoto clsCtsinistrephoto)
		{
			//Préparation des paramètres
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistrephoto.SI_CODESINISTRE ;
			SqlParameter vppParamSI_NUMSEQUENCEPHOTO = new SqlParameter("@SI_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
			vppParamSI_NUMSEQUENCEPHOTO.Value  = clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO ;
			SqlParameter vppParamSI_CHEMINPHOTO = new SqlParameter("@SI_CHEMINPHOTO", SqlDbType.VarChar, 1000);
			vppParamSI_CHEMINPHOTO.Value  = clsCtsinistrephoto.SI_CHEMINPHOTO ;
			SqlParameter vppParamSI_LIBELLEPHOTO = new SqlParameter("@SI_LIBELLEPHOTO", SqlDbType.VarChar, 1000);
			vppParamSI_LIBELLEPHOTO.Value  = clsCtsinistrephoto.SI_LIBELLEPHOTO ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTREPHOTO  @SI_CODESINISTRE1, @SI_NUMSEQUENCEPHOTO1, @SI_CHEMINPHOTO1, @SI_LIBELLEPHOTO1, @CODECRYPTAGE1, 0,''  ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_NUMSEQUENCEPHOTO);
			vppSqlCmd.Parameters.Add(vppParamSI_CHEMINPHOTO);
			vppSqlCmd.Parameters.Add(vppParamSI_LIBELLEPHOTO);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsCtcontratchequereglementcaisse>clsCtcontratchequereglementcaisse</param>
        ///<author>Home Technology</author>
        public string pvgMiseAJour(clsDonnee clsDonnee, clsCtsinistrephoto clsCtsinistrephoto)
        {
            //Préparation des paramètres
            SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
            vppParamSI_CODESINISTRE.Value = clsCtsinistrephoto.SI_CODESINISTRE;
            SqlParameter vppParamSI_NUMSEQUENCEPHOTO = new SqlParameter("@SI_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
            vppParamSI_NUMSEQUENCEPHOTO.Value = clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO;
            SqlParameter vppParamSI_CHEMINPHOTO = new SqlParameter("@SI_CHEMINPHOTO", SqlDbType.VarChar, 1000);
            vppParamSI_CHEMINPHOTO.Value = clsCtsinistrephoto.SI_CHEMINPHOTO;
            SqlParameter vppParamSI_LIBELLEPHOTO = new SqlParameter("@SI_LIBELLEPHOTO", SqlDbType.VarChar, 1000);
            vppParamSI_LIBELLEPHOTO.Value = clsCtsinistrephoto.SI_LIBELLEPHOTO;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsCtsinistrephoto.TYPEOPERATION;

            SqlParameter vppParamSI_NUMSEQUENCEPHOTORETOUR = new SqlParameter("@SI_NUMSEQUENCEPHOTORETOUR", SqlDbType.VarChar, 150);

            //Préparation de la commande

            SqlCommand vppSqlCmd = new SqlCommand("PC_CTSINISTREPHOTO", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
            vppSqlCmd.Parameters.Add(vppParamSI_NUMSEQUENCEPHOTO);
            vppSqlCmd.Parameters.Add(vppParamSI_CHEMINPHOTO);
            vppSqlCmd.Parameters.Add(vppParamSI_LIBELLEPHOTO);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamSI_NUMSEQUENCEPHOTORETOUR);
            vppParamSI_NUMSEQUENCEPHOTORETOUR.Direction = ParameterDirection.Output;


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);

            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@SI_NUMSEQUENCEPHOTORETOUR"].Value.ToString();
        }



        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsCtsinistrephoto>clsCtsinistrephoto</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsCtsinistrephoto clsCtsinistrephoto,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamSI_CODESINISTRE = new SqlParameter("@SI_CODESINISTRE", SqlDbType.VarChar, 50);
			vppParamSI_CODESINISTRE.Value  = clsCtsinistrephoto.SI_CODESINISTRE ;
			SqlParameter vppParamSI_NUMSEQUENCEPHOTO = new SqlParameter("@SI_NUMSEQUENCEPHOTO", SqlDbType.VarChar, 25);
			vppParamSI_NUMSEQUENCEPHOTO.Value  = clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO ;
			SqlParameter vppParamSI_CHEMINPHOTO = new SqlParameter("@SI_CHEMINPHOTO", SqlDbType.VarChar, 1000);
			vppParamSI_CHEMINPHOTO.Value  = clsCtsinistrephoto.SI_CHEMINPHOTO ;
			SqlParameter vppParamSI_LIBELLEPHOTO = new SqlParameter("@SI_LIBELLEPHOTO", SqlDbType.VarChar, 1000);
			vppParamSI_LIBELLEPHOTO.Value  = clsCtsinistrephoto.SI_LIBELLEPHOTO ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTREPHOTO  @SI_CODESINISTRE, @SI_NUMSEQUENCEPHOTO, @SI_CHEMINPHOTO, @SI_LIBELLEPHOTO, @CODECRYPTAGE, 1,''";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamSI_CODESINISTRE);
			vppSqlCmd.Parameters.Add(vppParamSI_NUMSEQUENCEPHOTO);
			vppSqlCmd.Parameters.Add(vppParamSI_CHEMINPHOTO);
			vppSqlCmd.Parameters.Add(vppParamSI_LIBELLEPHOTO);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_CTSINISTREPHOTO  @SI_CODESINISTRE, @SI_NUMSEQUENCEPHOTO, '' , '' , @CODECRYPTAGE, 3,'' ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}


        public void pvgDeletePhoto(clsDonnee clsDonnee, DataSet DataSet)
        {

            string pathImage = "";
            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            pathImage = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT3").PP_VALEUR;

            for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
            {
                //---Test de l'exitance du chemin de sauvegarde
                if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["SI_CHEMINPHOTO"].ToString() + ".jpg"))
                {
                    pvgSupprimerPhotoSignature(pathImage + DataSet.Tables[0].Rows[Idx]["SI_CHEMINPHOTO"].ToString() + ".jpg");
                    //DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["CH_CHEMINPHOTOCHEQUE"].ToString() + ".jpg");
                }

            }

        }


        public bool pvgSupprimerPhotoSignature(string chemin)
        {
            bool vlpResultat = false;
            if (File.Exists(chemin))
            {
                File.Delete(chemin);
                if (!File.Exists(chemin))
                    vlpResultat = true;
            }


            return vlpResultat;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_CTSINISTREPHOTO  @SI_CODESINISTRE, '', '' , '' , @CODECRYPTAGE, 2,'' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsCtsinistrephoto </returns>
        ///<author>Home Technology</author>
        public List<clsCtsinistrephoto> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO, SI_CHEMINPHOTO, SI_LIBELLEPHOTO FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsCtsinistrephoto> clsCtsinistrephotos = new List<clsCtsinistrephoto>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsCtsinistrephoto clsCtsinistrephoto = new clsCtsinistrephoto();
					clsCtsinistrephoto.SI_CODESINISTRE = clsDonnee.vogDataReader["SI_CODESINISTRE"].ToString();
					clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO = clsDonnee.vogDataReader["SI_NUMSEQUENCEPHOTO"].ToString();
					clsCtsinistrephoto.SI_CHEMINPHOTO = clsDonnee.vogDataReader["SI_CHEMINPHOTO"].ToString();
					clsCtsinistrephoto.SI_LIBELLEPHOTO = clsDonnee.vogDataReader["SI_LIBELLEPHOTO"].ToString();
					clsCtsinistrephotos.Add(clsCtsinistrephoto);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsCtsinistrephotos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistrephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistrephoto> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsCtsinistrephoto> clsCtsinistrephotos = new List<clsCtsinistrephoto>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO, SI_CHEMINPHOTO, SI_LIBELLEPHOTO FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsCtsinistrephoto clsCtsinistrephoto = new clsCtsinistrephoto();
					clsCtsinistrephoto.SI_CODESINISTRE = Dataset.Tables["TABLE"].Rows[Idx]["SI_CODESINISTRE"].ToString();
					clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO = Dataset.Tables["TABLE"].Rows[Idx]["SI_NUMSEQUENCEPHOTO"].ToString();
					clsCtsinistrephoto.SI_CHEMINPHOTO = Dataset.Tables["TABLE"].Rows[Idx]["SI_CHEMINPHOTO"].ToString();
					clsCtsinistrephoto.SI_LIBELLEPHOTO = Dataset.Tables["TABLE"].Rows[Idx]["SI_LIBELLEPHOTO"].ToString();
					clsCtsinistrephotos.Add(clsCtsinistrephoto);
				}
				Dataset.Dispose();
			}
		return clsCtsinistrephotos;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{

            string pathImage = "";
            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            pathImage = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "PHOT3").PP_VALEUR;

            DataSet DataSet = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            DataSet = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

            for (int Idx = 0; Idx < DataSet.Tables[0].Rows.Count; Idx++)
            {
                //---Test de l'exitance du chemin de sauvegarde
                if (File.Exists(pathImage + DataSet.Tables[0].Rows[Idx]["SI_CHEMINPHOTO"].ToString() + ".jpg"))
                {
                    DataSet.Tables[0].Rows[Idx]["SI_CHEMINPHOTO"] = ImageToBase64(pathImage + DataSet.Tables[0].Rows[Idx]["SI_CHEMINPHOTO"].ToString() + ".jpg");
                }

            }


            return DataSet;
            //pvpChoixCritere(clsDonnee ,vppCritere);
            //this.vapRequete = "SELECT *  FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
            //this.vapCritere = "";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT SI_CHEMINPHOTO,SI_CODESINISTRE , SI_LIBELLEPHOTO FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT SI_CODESINISTRE , SI_LIBELLEPHOTO FROM dbo.FT_CTSINISTREPHOTO(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO)</summary>
		///<param name="clsDonnee"> clsDonnee</param>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{"@CODECRYPTAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
				break;
				case 1 :
				this.vapCritere ="WHERE SI_CODESINISTRE=@SI_CODESINISTRE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SI_CODESINISTRE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE SI_CODESINISTRE=@SI_CODESINISTRE AND SI_NUMSEQUENCEPHOTO=@SI_NUMSEQUENCEPHOTO";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@SI_CODESINISTRE","@SI_NUMSEQUENCEPHOTO"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public bool pvgUploadPhotoSignature(clsDonnee clsDonnee, string PHOTO, string NOMPHOTO, string PP_CODEPARAMETRE)
        {
            bool vlpResultat = true;
            //List<clsMiccomptewebUserLogin> clsMiccomptewebUserLogins = new List<clsMiccomptewebUserLogin>();
            //clsMiccomptewebUserLogin clsMiccomptewebUserLogin = new clsMiccomptewebUserLogin();


            //List<clsMiccomptewebResultat> clsMiccomptewebResultats = new List<clsMiccomptewebResultat>();


            //---Récupération du chemin de sauvegarde
            clsParametre clsParametre = new clsParametre();
            clsParametreWSDAL clsParametreWSDAL = new clsParametreWSDAL();
            string pathPhoto = clsParametreWSDAL.pvgTableLabel(clsDonnee, PP_CODEPARAMETRE).PP_VALEUR;
            //string pathSignature = @clsParametreWSDAL.pvgTableLabel(clsDonnee, "SIGN").PP_VALEUR;
            //---Test de l'exitance du chemin de sauvegarde
            if (!Directory.Exists(pathPhoto))
            {
                vlpResultat = false;
                //clsMiccomptewebResultats = pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0262", "01");
                //clsMiccomptewebUserLogin.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
                //clsMiccomptewebUserLogin.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
                //clsMiccomptewebUserLogin.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
                //clsMiccomptewebUserLogins.Add(clsMiccomptewebUserLogin);
                return vlpResultat;
            }
            //if (!Directory.Exists(pathSignature))
            //{
            //    clsMiccomptewebResultats = pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0262", "01");
            //    clsMiccomptewebUserLogin.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //    clsMiccomptewebUserLogin.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //    clsMiccomptewebUserLogin.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //    clsMiccomptewebUserLogins.Add(clsMiccomptewebUserLogin);
            //    return clsMiccomptewebUserLogins;
            //}

            //---sauvegarde des immages
            if (PHOTO != "" && NOMPHOTO != "")
                Base64ToImageSave(PHOTO).Save(pathPhoto + NOMPHOTO + ".jpg");
            //clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new clsMiccomptewebmotpasseoublie();
            //clsMiccomptewebmotpasseoublie.SL_RESULTAT = "TRUE";
            //pvgRenommerFichierJoint( clsDonnee,  clsMiccomptewebmotpasseoublie);
            //if (SIGNATURE != "" && NOMSIGNATURE != "")
            //    Base64ToImageSave(SIGNATURE).Save(pathSignature + NOMSIGNATURE+ ".jpg");
            //---Message retourné au client
            //clsMiccomptewebResultats = pvgMobileSystemeException(clsDonnee, LG_CODELANGUE, "MSB0099", "02");
            //clsMiccomptewebUserLogin.SL_CODEMESSAGE = clsMiccomptewebResultats[0].SL_CODEMESSAGE;
            //clsMiccomptewebUserLogin.SL_RESULTAT = clsMiccomptewebResultats[0].SL_RESULTAT;
            //clsMiccomptewebUserLogin.SL_MESSAGE = clsMiccomptewebResultats[0].SL_MESSAGE;
            //clsMiccomptewebUserLogins.Add(clsMiccomptewebUserLogin);


            return vlpResultat;
        }


        public System.Drawing.Image Base64ToImageSave(string base64String)
        {

            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        public string ImageToBase64(string path)
        {
            string base64String = null;
            if (!File.Exists(path)) return "";
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }




    }
}
